Imports Microsoft.Data.Sqlite

Namespace Data
    ''' <summary>
    ''' Acceso centralizado a SQLite (ciber.db junto al exe).
    ''' Crea el esquema si no existe y migra IPs legacy de My.Settings.
    ''' </summary>
    Public Module Db
        Public Function DbPath() As String
            Return IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ciber.db")
        End Function

        Public Function ConnectionString() As String
            Return "Data Source=" & DbPath()
        End Function

        Public Sub Init()
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "
                    CREATE TABLE IF NOT EXISTS Equipos(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NOT NULL UNIQUE,
                        Ip TEXT NOT NULL DEFAULT '',
                        Activo INTEGER NOT NULL DEFAULT 1);
                    CREATE TABLE IF NOT EXISTS Productos(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NOT NULL,
                        Categoria TEXT NOT NULL DEFAULT 'General',
                        Precio REAL NOT NULL DEFAULT 0,
                        Stock INTEGER NOT NULL DEFAULT 0,
                        Activo INTEGER NOT NULL DEFAULT 1);
                    CREATE TABLE IF NOT EXISTS Ventas(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Fecha TEXT NOT NULL,
                        Equipo TEXT NOT NULL DEFAULT 'Mostrador',
                        Total REAL NOT NULL DEFAULT 0,
                        MetodoPago TEXT NOT NULL DEFAULT 'Efectivo');
                    CREATE TABLE IF NOT EXISTS VentaDetalle(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        VentaId INTEGER NOT NULL REFERENCES Ventas(Id),
                        ProductoId INTEGER NOT NULL REFERENCES Productos(Id),
                        Cantidad INTEGER NOT NULL,
                        Precio REAL NOT NULL,
                        Subtotal REAL NOT NULL);
                    CREATE TABLE IF NOT EXISTS CargosPendientes(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Equipo TEXT NOT NULL,
                        Fecha TEXT NOT NULL,
                        ProductoId INTEGER NOT NULL REFERENCES Productos(Id),
                        Cantidad INTEGER NOT NULL,
                        Precio REAL NOT NULL,
                        Subtotal REAL NOT NULL);
                    CREATE TABLE IF NOT EXISTS VentaPagos(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        VentaId INTEGER NOT NULL REFERENCES Ventas(Id),
                        Metodo TEXT NOT NULL,
                        Monto REAL NOT NULL);
                    CREATE TABLE IF NOT EXISTS VentaServicios(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        VentaId INTEGER NOT NULL REFERENCES Ventas(Id),
                        Descripcion TEXT NOT NULL,
                        Cantidad REAL NOT NULL,
                        Precio REAL NOT NULL,
                        Subtotal REAL NOT NULL);
                    CREATE TABLE IF NOT EXISTS Sesiones(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Equipo TEXT NOT NULL,
                        Inicio TEXT NOT NULL,
                        Fin TEXT,
                        Minutos INTEGER NOT NULL DEFAULT 0,
                        Monto REAL NOT NULL DEFAULT 0);
                    CREATE TABLE IF NOT EXISTS SesionesActivas(
                        Equipo TEXT PRIMARY KEY,
                        Inicio TEXT NOT NULL,
                        Fin TEXT NOT NULL,
                        Recuperada INTEGER NOT NULL DEFAULT 0,
                        Finalizada INTEGER NOT NULL DEFAULT 0,
                        PausaDesde TEXT NOT NULL DEFAULT '');
                    CREATE TABLE IF NOT EXISTS Config(
                        Clave TEXT PRIMARY KEY,
                        Valor TEXT NOT NULL DEFAULT '');"
                    cmd.ExecuteNonQuery()
                End Using
                Try
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.CommandText = "ALTER TABLE SesionesActivas ADD COLUMN Recuperada INTEGER NOT NULL DEFAULT 0"
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try
                Try
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.CommandText = "ALTER TABLE SesionesActivas ADD COLUMN Finalizada INTEGER NOT NULL DEFAULT 0"
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try
                Try
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.CommandText = "ALTER TABLE SesionesActivas ADD COLUMN PausaDesde TEXT NOT NULL DEFAULT ''"
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try
            End Using
            MigrarEquiposLegacy()
            SeedProductos()
        End Sub

        Private Sub MigrarEquiposLegacy()
            Try
                Dim ips As New List(Of String) From {
                    My.Settings.ipPC1, My.Settings.ipPC2, My.Settings.ipPC3,
                    My.Settings.ipPC4, My.Settings.ipPC5, My.Settings.ipPC6,
                    My.Settings.ipPC7, My.Settings.ipPC8, My.Settings.ipPC9,
                    My.Settings.ipPC10}
                If ips.All(Function(s) String.IsNullOrWhiteSpace(s)) Then Return
                If ContarEquipos() > 0 Then Return
                For i As Integer = 0 To 9
                    GuardarEquipo("Equipo " & (i + 1).ToString(), If(ips(i), ""))
                Next
            Catch
            End Try
        End Sub

        Private Sub SeedProductos()
            Try
                If ContarProductos() > 0 Then Return
                Using cn As New SqliteConnection(ConnectionString())
                    cn.Open()
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.CommandText = "INSERT INTO Productos(Nombre,Categoria,Precio,Stock) VALUES
                            ('Impresión B/N','Papelería',5.0,500),
                            ('Impresión Color','Papelería',10.0,500),
                            ('Fotocopia','Papelería',3.0,1000),
                            ('Refresco Lata','Consumibles',20.0,48),
                            ('Agua 600ml','Consumibles',15.0,48),
                            ('Papas 45g','Consumibles',18.0,30)"
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch
            End Try
        End Sub

        '--- Equipos ---
        Public Function ListarEquipos() As DataTable
            Dim dt As New DataTable()
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT Id, Nombre, Ip FROM Equipos WHERE Activo=1 ORDER BY Id"
                    Using rd = cmd.ExecuteReader()
                        dt.Load(rd)
                    End Using
                End Using
            End Using
            Return dt
        End Function

        Public Sub GuardarEquipo(nombre As String, ip As String)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "INSERT INTO Equipos(Nombre,Ip) VALUES(@n,@ip)
                        ON CONFLICT(Nombre) DO UPDATE SET Ip=excluded.Ip, Activo=1"
                    cmd.Parameters.AddWithValue("@n", nombre)
                    cmd.Parameters.AddWithValue("@ip", If(ip, ""))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function IpDeEquipo(nombre As String) As String
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT Ip FROM Equipos WHERE Nombre=@n LIMIT 1"
                    cmd.Parameters.AddWithValue("@n", nombre)
                    Dim v = cmd.ExecuteScalar()
                    If v Is Nothing OrElse v Is DBNull.Value Then Return ""
                    Return CStr(v)
                End Using
            End Using
        End Function

        Public Function ContarEquipos() As Integer
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT COUNT(*) FROM Equipos WHERE Activo=1"
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        '--- Config ---
        Public Function GetConfig(clave As String, defecto As String) As String
            Try
                Using cn As New SqliteConnection(ConnectionString())
                    cn.Open()
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.CommandText = "SELECT Valor FROM Config WHERE Clave=@c"
                        cmd.Parameters.AddWithValue("@c", clave)
                        Dim v = cmd.ExecuteScalar()
                        If v Is Nothing Then Return defecto
                        Return CStr(v)
                    End Using
                End Using
            Catch
                Return defecto
            End Try
        End Function

        Public Sub SetConfig(clave As String, valor As String)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "INSERT INTO Config(Clave,Valor) VALUES(@c,@v)
                        ON CONFLICT(Clave) DO UPDATE SET Valor=excluded.Valor"
                    cmd.Parameters.AddWithValue("@c", clave)
                    cmd.Parameters.AddWithValue("@v", If(valor, ""))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function Puerto() As Integer
            Dim raw As String = GetConfig("puerto", My.Settings.puerto.ToString())
            Dim p As Integer
            If Integer.TryParse(raw, p) AndAlso p > 0 AndAlso p <= 65535 Then Return p
            Return 55555
        End Function

        '--- Productos / Ventas ---
        Public Function ContarProductos() As Integer
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT COUNT(*) FROM Productos WHERE Activo=1"
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        Public Function ListarProductos(filtro As String) As DataTable
            Dim dt As New DataTable()
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT Id, Nombre, Categoria, Precio, Stock FROM Productos
                        WHERE Activo=1 AND (Nombre LIKE @f OR Categoria LIKE @f) ORDER BY Nombre"
                    cmd.Parameters.AddWithValue("@f", "%" & If(filtro, "") & "%")
                    Using rd = cmd.ExecuteReader()
                        dt.Load(rd)
                    End Using
                End Using
            End Using
            Return dt
        End Function

        Public Function GuardarProducto(id As Integer, nombre As String, categoria As String, precio As Decimal, stock As Integer) As Integer
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    If id <= 0 Then
                        cmd.CommandText = "INSERT INTO Productos(Nombre,Categoria,Precio,Stock) VALUES(@n,@c,@p,@s); SELECT last_insert_rowid();"
                    Else
                        cmd.CommandText = "UPDATE Productos SET Nombre=@n, Categoria=@c, Precio=@p, Stock=@s WHERE Id=@id; SELECT @id;"
                        cmd.Parameters.AddWithValue("@id", id)
                    End If
                    cmd.Parameters.AddWithValue("@n", nombre.Trim())
                    cmd.Parameters.AddWithValue("@c", If(String.IsNullOrWhiteSpace(categoria), "General", categoria.Trim()))
                    cmd.Parameters.AddWithValue("@p", CDbl(precio))
                    cmd.Parameters.AddWithValue("@s", stock)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        Public Sub EliminarProducto(id As Integer)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "UPDATE Productos SET Activo=0 WHERE Id=@id"
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function RegistrarVenta(equipo As String, metodoPago As String, items As List(Of Tuple(Of Integer, Integer, Decimal)), Optional pagos As Dictionary(Of String, Decimal) = Nothing) As Integer
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim total As Decimal = 0
                    For Each it In items
                        total += it.Item2 * it.Item3
                    Next
                    Dim ventaId As Integer
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "INSERT INTO Ventas(Fecha,Equipo,Total,MetodoPago) VALUES(@f,@e,@t,@m); SELECT last_insert_rowid();"
                        cmd.Parameters.AddWithValue("@f", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmd.Parameters.AddWithValue("@e", If(String.IsNullOrWhiteSpace(equipo), "Mostrador", equipo))
                        cmd.Parameters.AddWithValue("@t", CDbl(total))
                        cmd.Parameters.AddWithValue("@m", metodoPago)
                        ventaId = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using
                    If pagos IsNot Nothing Then
                        For Each pago In pagos
                            If pago.Value <= 0D Then Continue For
                            Using cmd As SqliteCommand = cn.CreateCommand()
                                cmd.Transaction = tx
                                cmd.CommandText = "INSERT INTO VentaPagos(VentaId,Metodo,Monto) VALUES(@v,@m,@a)"
                                cmd.Parameters.AddWithValue("@v", ventaId)
                                cmd.Parameters.AddWithValue("@m", pago.Key)
                                cmd.Parameters.AddWithValue("@a", CDbl(pago.Value))
                                cmd.ExecuteNonQuery()
                            End Using
                        Next
                    End If
                    For Each it In items
                        Using cmd As SqliteCommand = cn.CreateCommand()
                            cmd.Transaction = tx
                            cmd.CommandText = "INSERT INTO VentaDetalle(VentaId,ProductoId,Cantidad,Precio,Subtotal)
                                VALUES(@v,@p,@c,@pr,@s)"
                            cmd.Parameters.AddWithValue("@v", ventaId)
                            cmd.Parameters.AddWithValue("@p", it.Item1)
                            cmd.Parameters.AddWithValue("@c", it.Item2)
                            cmd.Parameters.AddWithValue("@pr", CDbl(it.Item3))
                            cmd.Parameters.AddWithValue("@s", CDbl(it.Item2 * it.Item3))
                            cmd.ExecuteNonQuery()
                        End Using
                        Using cmd As SqliteCommand = cn.CreateCommand()
                            cmd.Transaction = tx
                            cmd.CommandText = "UPDATE Productos SET Stock = Stock - @c WHERE Id=@p"
                            cmd.Parameters.AddWithValue("@c", it.Item2)
                            cmd.Parameters.AddWithValue("@p", it.Item1)
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                    tx.Commit()
                    Return ventaId
                End Using
            End Using
        End Function

        Public Sub CargarProductosACuenta(equipo As String, items As List(Of Tuple(Of Integer, Integer, Decimal)))
            If String.IsNullOrWhiteSpace(equipo) OrElse equipo = "Mostrador" Then Throw New ArgumentException("Selecciona un equipo para cargar el consumo a su cuenta.")
            If items Is Nothing OrElse items.Count = 0 Then Throw New ArgumentException("El ticket está vacío.")
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using tx = cn.BeginTransaction()
                    For Each item In items
                        Using cmd As SqliteCommand = cn.CreateCommand()
                            cmd.Transaction = tx
                            cmd.CommandText = "UPDATE Productos SET Stock=Stock-@c WHERE Id=@p AND Activo=1 AND Stock>=@c"
                            cmd.Parameters.AddWithValue("@c", item.Item2)
                            cmd.Parameters.AddWithValue("@p", item.Item1)
                            If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException("Stock insuficiente o producto no disponible.")
                        End Using
                        Using cmd As SqliteCommand = cn.CreateCommand()
                            cmd.Transaction = tx
                            cmd.CommandText = "INSERT INTO CargosPendientes(Equipo,Fecha,ProductoId,Cantidad,Precio,Subtotal) VALUES(@e,@f,@p,@c,@pr,@s)"
                            cmd.Parameters.AddWithValue("@e", equipo)
                            cmd.Parameters.AddWithValue("@f", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            cmd.Parameters.AddWithValue("@p", item.Item1)
                            cmd.Parameters.AddWithValue("@c", item.Item2)
                            cmd.Parameters.AddWithValue("@pr", CDbl(item.Item3))
                            cmd.Parameters.AddWithValue("@s", CDbl(item.Item2 * item.Item3))
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                    tx.Commit()
                End Using
            End Using
        End Sub

        Public Function CargosPendientesEquipo(equipo As String) As DataTable
            Dim dt As New DataTable()
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT c.Id, p.Nombre, c.Cantidad, c.Precio, c.Subtotal, c.Fecha " &
                        "FROM CargosPendientes c JOIN Productos p ON p.Id=c.ProductoId WHERE c.Equipo=@e ORDER BY c.Id"
                    cmd.Parameters.AddWithValue("@e", equipo)
                    Using rd = cmd.ExecuteReader()
                        dt.Load(rd)
                    End Using
                End Using
            End Using
            Return dt
        End Function

        Public Function TotalCargosPendientes(equipo As String) As Decimal
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT COALESCE(SUM(Subtotal),0) FROM CargosPendientes WHERE Equipo=@e"
                    cmd.Parameters.AddWithValue("@e", equipo)
                    Return Convert.ToDecimal(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        Public Function LiquidarCuentaEquipo(equipo As String, minutos As Integer, tarifaHora As Decimal, pagos As Dictionary(Of String, Decimal)) As Integer
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim cargos As New DataTable()
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "SELECT ProductoId,Cantidad,Precio,Subtotal FROM CargosPendientes WHERE Equipo=@e ORDER BY Id"
                        cmd.Parameters.AddWithValue("@e", equipo)
                        Using rd = cmd.ExecuteReader()
                            cargos.Load(rd)
                        End Using
                    End Using
                    Dim totalProductos As Decimal = 0D
                    For Each row As DataRow In cargos.Rows
                        totalProductos += CDec(row("Subtotal"))
                    Next
                    Dim tarifaMinuto As Decimal = tarifaHora / 60D
                    Dim montoTiempo As Decimal = Math.Round(minutos * tarifaMinuto, 2)
                    Dim total As Decimal = totalProductos + montoTiempo
                    Dim pagado As Decimal = 0D
                    For Each pago In pagos.Values
                        If pago < 0D Then Throw New ArgumentException("Los montos de pago no pueden ser negativos.")
                        pagado += pago
                    Next
                    If total <= 0D Then Throw New InvalidOperationException("El equipo no tiene cargos pendientes.")
                    If Math.Abs(pagado - total) > 0.001D Then Throw New InvalidOperationException("Los pagos deben sumar exactamente el total de la cuenta.")
                    Dim metodo As String = "Mixto"
                    For Each pago In pagos
                        If pago.Value > 0D Then
                            If metodo = "Mixto" AndAlso pagos.Values.Where(Function(v) v > 0D).Count() = 1 Then metodo = pago.Key
                            Exit For
                        End If
                    Next
                    Dim ventaId As Integer
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "INSERT INTO Ventas(Fecha,Equipo,Total,MetodoPago) VALUES(@f,@e,@t,@m); SELECT last_insert_rowid();"
                        cmd.Parameters.AddWithValue("@f", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmd.Parameters.AddWithValue("@e", equipo)
                        cmd.Parameters.AddWithValue("@t", CDbl(total))
                        cmd.Parameters.AddWithValue("@m", metodo)
                        ventaId = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using
                    For Each row As DataRow In cargos.Rows
                        Using cmd As SqliteCommand = cn.CreateCommand()
                            cmd.Transaction = tx
                            cmd.CommandText = "INSERT INTO VentaDetalle(VentaId,ProductoId,Cantidad,Precio,Subtotal) VALUES(@v,@p,@c,@pr,@s)"
                            cmd.Parameters.AddWithValue("@v", ventaId)
                            cmd.Parameters.AddWithValue("@p", row("ProductoId"))
                            cmd.Parameters.AddWithValue("@c", row("Cantidad"))
                            cmd.Parameters.AddWithValue("@pr", row("Precio"))
                            cmd.Parameters.AddWithValue("@s", row("Subtotal"))
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                    If minutos > 0 AndAlso tarifaMinuto > 0D Then
                        Using cmd As SqliteCommand = cn.CreateCommand()
                            cmd.Transaction = tx
                            cmd.CommandText = "INSERT INTO VentaServicios(VentaId,Descripcion,Cantidad,Precio,Subtotal) VALUES(@v,'Uso de equipo (min)',@c,@p,@s)"
                            cmd.Parameters.AddWithValue("@v", ventaId)
                            cmd.Parameters.AddWithValue("@c", minutos)
                            cmd.Parameters.AddWithValue("@p", CDbl(tarifaMinuto))
                            cmd.Parameters.AddWithValue("@s", CDbl(montoTiempo))
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                    For Each pago In pagos
                        If pago.Value <= 0D Then Continue For
                        Using cmd As SqliteCommand = cn.CreateCommand()
                            cmd.Transaction = tx
                            cmd.CommandText = "INSERT INTO VentaPagos(VentaId,Metodo,Monto) VALUES(@v,@m,@a)"
                            cmd.Parameters.AddWithValue("@v", ventaId)
                            cmd.Parameters.AddWithValue("@m", pago.Key)
                            cmd.Parameters.AddWithValue("@a", CDbl(pago.Value))
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "DELETE FROM CargosPendientes WHERE Equipo=@e"
                        cmd.Parameters.AddWithValue("@e", equipo)
                        cmd.ExecuteNonQuery()
                    End Using
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "DELETE FROM SesionesActivas WHERE Equipo=@e"
                        cmd.Parameters.AddWithValue("@e", equipo)
                        cmd.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                    Return ventaId
                End Using
            End Using
        End Function

        Public Function HistorialVentas(desde As DateTime, hasta As DateTime) As DataTable
            Dim dt As New DataTable()
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT v.Id, v.Fecha, v.Equipo, " &
                        "COALESCE((SELECT group_concat(p.Nombre || ' x' || d.Cantidad || ' ($' || printf('%.2f', d.Subtotal) || ')', ', ') " &
                        "FROM VentaDetalle d INNER JOIN Productos p ON p.Id=d.ProductoId WHERE d.VentaId=v.Id), 'Sin detalle') AS Productos, " &
                        "COALESCE((SELECT group_concat(s.Descripcion || ' x' || CAST(s.Cantidad AS INTEGER) || ' ($' || printf('%.2f', s.Subtotal) || ')', ', ') " &
                        "FROM VentaServicios s WHERE s.VentaId=v.Id), '') AS Servicios, " &
                        "v.Total, " &
                        "CASE WHEN EXISTS(SELECT 1 FROM VentaPagos p WHERE p.VentaId=v.Id) THEN COALESCE((SELECT SUM(p.Monto) FROM VentaPagos p WHERE p.VentaId=v.Id AND p.Metodo='Efectivo'),0) WHEN v.MetodoPago='Efectivo' THEN v.Total ELSE 0 END AS Efectivo, " &
                        "CASE WHEN EXISTS(SELECT 1 FROM VentaPagos p WHERE p.VentaId=v.Id) THEN COALESCE((SELECT SUM(p.Monto) FROM VentaPagos p WHERE p.VentaId=v.Id AND p.Metodo='Transferencia'),0) WHEN v.MetodoPago='Transferencia' THEN v.Total ELSE 0 END AS Transferencia, " &
                        "CASE WHEN EXISTS(SELECT 1 FROM VentaPagos p WHERE p.VentaId=v.Id) THEN COALESCE((SELECT SUM(p.Monto) FROM VentaPagos p WHERE p.VentaId=v.Id AND p.Metodo='Tarjeta'),0) WHEN v.MetodoPago='Tarjeta' THEN v.Total ELSE 0 END AS Tarjeta, " &
                        "v.MetodoPago, COALESCE((SELECT group_concat(p.Metodo || ' $' || printf('%.2f', p.Monto), ', ') " &
                        "FROM VentaPagos p WHERE p.VentaId=v.Id), v.MetodoPago) AS Pagos FROM Ventas v " &
                        "WHERE v.Fecha BETWEEN @d AND @h ORDER BY v.Id DESC LIMIT 500"
                    cmd.Parameters.AddWithValue("@d", desde.ToString("yyyy-MM-dd 00:00:00"))
                    cmd.Parameters.AddWithValue("@h", hasta.ToString("yyyy-MM-dd 23:59:59"))
                    Using rd = cmd.ExecuteReader()
                        dt.Load(rd)
                    End Using
                End Using
            End Using
            Return dt
        End Function

        Public Function TotalVentasDia(fecha As DateTime) As Decimal
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT COALESCE(SUM(Total),0) FROM Ventas WHERE Fecha BETWEEN @d AND @h"
                    cmd.Parameters.AddWithValue("@d", fecha.ToString("yyyy-MM-dd 00:00:00"))
                    cmd.Parameters.AddWithValue("@h", fecha.ToString("yyyy-MM-dd 23:59:59"))
                    Return Convert.ToDecimal(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        Public Function ResumenPagos(desde As DateTime, hasta As DateTime) As Dictionary(Of String, Decimal)
            Dim resumen As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase) From {
                {"Efectivo", 0D}, {"Transferencia", 0D}, {"Tarjeta", 0D}
            }
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT Metodo, SUM(Monto) AS Total FROM (" &
                        "SELECT p.Metodo, p.Monto FROM VentaPagos p INNER JOIN Ventas v ON v.Id=p.VentaId WHERE v.Fecha BETWEEN @d AND @h " &
                        "UNION ALL " &
                        "SELECT v.MetodoPago AS Metodo, v.Total AS Monto FROM Ventas v WHERE v.Fecha BETWEEN @d AND @h " &
                        "AND NOT EXISTS(SELECT 1 FROM VentaPagos p WHERE p.VentaId=v.Id)) GROUP BY Metodo"
                    cmd.Parameters.AddWithValue("@d", desde.ToString("yyyy-MM-dd 00:00:00"))
                    cmd.Parameters.AddWithValue("@h", hasta.ToString("yyyy-MM-dd 23:59:59"))
                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            Dim metodo As String = Convert.ToString(rd("Metodo"))
                            If resumen.ContainsKey(metodo) Then resumen(metodo) = Convert.ToDecimal(rd("Total"))
                        End While
                    End Using
                End Using
            End Using
            Return resumen
        End Function

        Public Sub EliminarEquipo(id As Integer)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "UPDATE Equipos SET Activo=0 WHERE Id=@id"
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub RegistrarSesion(equipo As String, minutos As Integer)
            Try
                Using cn As New SqliteConnection(ConnectionString())
                    cn.Open()
                    Using cmd As SqliteCommand = cn.CreateCommand()
                        cmd.CommandText = "INSERT INTO Sesiones(Equipo,Inicio,Minutos) VALUES(@e,@i,@m)"
                        cmd.Parameters.AddWithValue("@e", equipo)
                        cmd.Parameters.AddWithValue("@i", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmd.Parameters.AddWithValue("@m", minutos)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch
            End Try
        End Sub

        Public Sub GuardarSesionActiva(equipo As String, inicio As DateTime, fin As DateTime)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "INSERT INTO SesionesActivas(Equipo,Inicio,Fin,Recuperada,Finalizada,PausaDesde) VALUES(@e,@i,@f,0,0,'') " &
                        "ON CONFLICT(Equipo) DO UPDATE SET Inicio=excluded.Inicio, Fin=excluded.Fin, Recuperada=0, Finalizada=0, PausaDesde=''"
                    cmd.Parameters.AddWithValue("@e", equipo)
                    cmd.Parameters.AddWithValue("@i", inicio.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@f", fin.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function SesionActiva(equipo As String) As DataRow
            Dim dt As New DataTable()
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT Inicio, Fin, Recuperada, Finalizada, PausaDesde FROM SesionesActivas WHERE Equipo=@e LIMIT 1"
                    cmd.Parameters.AddWithValue("@e", equipo)
                    Using rd = cmd.ExecuteReader()
                        dt.Load(rd)
                    End Using
                End Using
            End Using
            If dt.Rows.Count = 0 Then Return Nothing
            Return dt.Rows(0)
        End Function

        Public Sub MarcarSesionesRecuperadas()
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "UPDATE SesionesActivas SET Recuperada=1, PausaDesde=CASE WHEN PausaDesde='' THEN @p ELSE PausaDesde END WHERE Finalizada=0"
                    cmd.Parameters.AddWithValue("@p", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub MarcarSesionReanudada(equipo As String)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "UPDATE SesionesActivas SET Recuperada=0, Finalizada=0, PausaDesde='' WHERE Equipo=@e"
                    cmd.Parameters.AddWithValue("@e", equipo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub GuardarSesionPausada(equipo As String, inicio As DateTime, fin As DateTime, pausaDesde As DateTime)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "INSERT INTO SesionesActivas(Equipo,Inicio,Fin,Recuperada,Finalizada,PausaDesde) VALUES(@e,@i,@f,1,0,@p) " &
                        "ON CONFLICT(Equipo) DO UPDATE SET Inicio=excluded.Inicio, Fin=excluded.Fin, Recuperada=1, Finalizada=0, PausaDesde=excluded.PausaDesde"
                    cmd.Parameters.AddWithValue("@e", equipo)
                    cmd.Parameters.AddWithValue("@i", inicio.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@f", fin.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@p", pausaDesde.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub ActualizarSesionReanudada(equipo As String, inicio As DateTime, fin As DateTime)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "UPDATE SesionesActivas SET Inicio=@i, Fin=@f, Recuperada=0, Finalizada=0, PausaDesde='' WHERE Equipo=@e"
                    cmd.Parameters.AddWithValue("@i", inicio.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@f", fin.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@e", equipo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub FinalizarSesionActiva(equipo As String, fin As DateTime)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "UPDATE SesionesActivas SET Fin=@f, Recuperada=0, Finalizada=1 WHERE Equipo=@e"
                    cmd.Parameters.AddWithValue("@f", fin.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@e", equipo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub EliminarSesionActiva(equipo As String)
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "DELETE FROM SesionesActivas WHERE Equipo=@e"
                    cmd.Parameters.AddWithValue("@e", equipo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function ListarSesiones(fecha As DateTime) As DataTable
            Dim dt As New DataTable()
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT Id, Equipo, Inicio, Minutos FROM Sesiones
                        WHERE Inicio BETWEEN @d AND @h ORDER BY Id DESC LIMIT 300"
                    cmd.Parameters.AddWithValue("@d", fecha.ToString("yyyy-MM-dd 00:00:00"))
                    cmd.Parameters.AddWithValue("@h", fecha.ToString("yyyy-MM-dd 23:59:59"))
                    Using rd = cmd.ExecuteReader()
                        dt.Load(rd)
                    End Using
                End Using
            End Using
            Return dt
        End Function

        Public Function ContarVentasDia(fecha As DateTime) As Integer
            Using cn As New SqliteConnection(ConnectionString())
                cn.Open()
                Using cmd As SqliteCommand = cn.CreateCommand()
                    cmd.CommandText = "SELECT COUNT(*) FROM Ventas WHERE Fecha BETWEEN @d AND @h"
                    cmd.Parameters.AddWithValue("@d", fecha.ToString("yyyy-MM-dd 00:00:00"))
                    cmd.Parameters.AddWithValue("@h", fecha.ToString("yyyy-MM-dd 23:59:59"))
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function
    End Module
End Namespace

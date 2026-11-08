# Registro de cambios — ControlCyber v4.0 (sistema rehecho desde cero)

## v3.2 — Sesiones recuperables y pausa
- Cliente recibe pulso UDP del servidor; opción persistente para pausar/bloquear mesas al cerrar el servidor, y pausa automática tras 15 s sin pulso cuando está habilitada. Los equipos sin respuesta UDP durante 15 s también se guardan en pausa.
- Las sesiones activas se marcan recuperables al arrancar el servidor; el cronómetro queda detenido hasta **Reanudar**. Se persisten inicio, límite y momento de pausa para excluir la pausa del cobro.
- La transmisión de video usa un socket UDP de envío separado del socket no bloqueante que recibe comandos; así no se descartan silenciosamente los fragmentos de captura.
- Tarjetas muestran duración contratada y ofrecen **Cobrar** en una sesión activa o libre; la acción selecciona el equipo en POS, donde se calcula el consumo transcurrido para liquidar la cuenta.
- **Finalizar / cobrar** en una recuperación navega al Punto de venta y selecciona el equipo; POS muestra el tiempo e importe pausados junto a productos cargados y permite liquidar la cuenta.
- Casilla y botones de recuperación quedan declarados en los archivos `.Designer.vb`.

## v3.1 (en curso)
- **Acerca de:** botón Buscar actualizaciones contra `raw.../updaters/main/ciber.json` (`Net/Actualizador.vb`: parse manual, comparador numérico, timeout 8 s) + aviso silencioso al arrancar (solo cambia el botón a "Actualizar a vX"); Actualizar abre `kr-dev.site/?app=ciber`. Botón Términos de uso (`UI/TerminosForm`, texto espejo de `TERMINOS.md`).
- **Términos restrictivos** redactados (`TERMINOS.md`): uso gratuito, prohibida venta/alquiler/cobro, autoría KrDev, sin garantía. `README.md` cambia MIT → uso gratuito (confirmado por el dueño).
- **Fondo de bloqueo:** Red suma grupo (Elegir imagen + info + Enviar, destino Todos/equipo vía `cboCfgEq`); imagen a 1280 px JPEG q65, protocolo `FONDOINI:<n>` + `FONDO:<idx>:<b64>` en trozos de 6000 con 2 pasadas y pausa; cliente reensambla a `fondo.jpg`, lo muestra (Zoom) y persiste; cola drenada (80/tick) + buffer 2 MB.
- **Teclado bloqueado:** hook `WH_KEYBOARD_LL` (`Cliente/Seguridad/TecladoBloqueo.vb`) traga Win, Alt+Tab, Alt+Esc, Ctrl+Esc solo con bloqueo visible (VisibleChanged); Ctrl+Alt+Supr imposible desde app (documentado).
- **Estado WiFi:** En línea si ping OK **o** video visto hace <15 s (`ScreenHub.Remitentes()`); tri-estado gris preservado.
- Verificado: build 0 errores, comparador (3.2>3.1, 3.10>3.2), controles nuevos existen, arranque v3.1 sin errores.
- Fix WiFi real 2: `ScreenHub.Ensure()` al arrancar no bastó en la práctica → además `tPing` 20 s → 5 s con `_pingEnCurso` anti-solape (el dato estaba fresco pero la pantalla tardaba en mostrarlo).
- Fondo visible: `PantallaBlo` rediseñada con `picFondo` (Zoom) al fondo de Panel2 y textos/icono re-hijados a él con fondo transparente; `AplicarFondo()` usa `picFondo.Image`. Requiere `Cliente.exe` nuevo en la PC (el log v4.9 no trae FONDO).
- Arranque: el chequeo de updates ahora muestra el diálogo si hay versión nueva (la búsqueda sigue en segundo plano). `ciber.json` existe (3.2) y el comparador está probado.
- Cliente ya en 3.1 en bloqueo, reloj y log (el "3.0" visto era el exe viejo).
- Fix WiFi real: `ScreenHub.Ensure()` ahora arranca con el Dashboard (antes solo al abrir un visor, así que `Remitentes()` siempre estaba vacío y el híbrido nunca aplicaba).
- Fondo: combo propio `cboFondoEq` (Todos/equipo) en su grupo en vez de reutilizar el de configuración.
- Fix teclado explícito: `Instalar()`/`Desinstalar()` en cada transición del motor
  (Iniciar y BLOQUEO instalan; INICIAR, DESBLOQUEAR, CERRAR y clave local liberan),
  más `VisibleChanged` como respaldo. Probado sin excepciones (instalar/desinstalar).

Fecha: 2026-09-30. Solución: `ControlCyber.sln` (VB.NET WinForms, .NET Framework 4.8, x86).

## v4.0 — Rehacer completo
### Causa raíz del form de Ventas en blanco
- `Servidor/Ventas.Designer.vb` nunca agregaba `tpVenta/tpProd/tpHist` al `TabControl` (faltaban los 3 `tab.Controls.Add`). El `TabControl` quedaba vacío → formulario en blanco. Verificado por test: `TabPages=0` antes, `=3` después.
- Además `Ventas` no tenía icono. Ahora toma el del ejecutable principal con `Icon.ExtractAssociatedIcon` en `Ventas_Load`, y acepta `TabInicial` para abrir directo en Venta/Productos/Historial.

### Nuevo panel principal (adiós a los 10 tabs grises)
- `Servidor/UI/Dashboard.vb` (nuevo, UI 100% por código, sin diseñador frágil) y es ahora el formulario de arranque (`Application.myapp` + `Application.Designer.vb`: `MainForm=Dashboard`).
- Sidebar oscuro `#1F2937` con secciones: Equipos / Punto de venta / Caja del día / Red y equipos. Barra superior blanca con reloj en vivo y total del día. Fondo `#F3F4F6`.
- Página **Equipos**: tarjetas `UI/EquipoCard.vb` en `FlowLayoutPanel` (una por equipo en SQLite, ya no 10 fijos): semáforo verde/rojo por ping cada 20 s, H/M + Iniciar/Añadir, Bloquear/Desbloquear, mensaje con Enter, Ver pantalla, Bloq. Windows, Reiniciar/Apagar (con confirmación). Cada Iniciar registra la sesión en `Sesiones`.
- Página **Caja del día**: total + nº tickets, grid de ventas de hoy y grid de sesiones de hoy.
- Página **Red y equipos**: grid editable de IPs (validación), +Equipo, Guardar, Eliminar (baja lógica), puerto UDP con validación 1-65535. Reemplaza al viejo `RegPC`.
- Punto de venta abre el módulo `Ventas` (instancia reutilizada, `BringToFront`).
- `Theme.vb`: `StyleSideButton()`, `StyleGrid()` (cabecera oscura, filas alternadas), `CardPanel()`.
- `Db.vb`: `EliminarEquipo()`, `RegistrarSesion()`, `ListarSesiones()`, `ContarVentasDia()`.

### Cliente modernizado
- `PantallaBlo.vb`: tema oscuro (fondo `#1F2937`, lateral azul, textos blancos, `v4.0`), sigue `Borderless+Maximized+TopMost`.
- `TiempoServ.vb`: tema oscuro con verde/rojo para inicio/fin.

### Verificación v4.0
- `MSBuild Rebuild Debug/x86`: Servidor y Cliente OK, 0 errores.
- App real: `Servidor.exe` arranca con título `Control de Ciber v4.0`, genera `ciber.db`, sigue viva a los 7 s.
- Test STA x86: `Ventas TabPages=3`, `Dashboard controles=3`, `EquipoCard controles=2`.
- Los formularios viejos (`CiberControl`, `Main`, `RegPC`) quedan compilados pero sin uso (respaldo); el arranque ya no los toca.

### v4.1 — Corrección de layout y caracteres (2026-09-30)
Reportado con captura: sidebar superpuesto al contenido, tarjetas desordenadas (faltaban Añadir y fila de sistema, IP abajo), `Caja del dÃ­a` / `Â·`.
- **Sidebar superpuesto:** causa `Dock` — el panel `Fill` se agregaba al último y reclamaba toda el área, dibujándose debajo del sidebar y topbar (por eso las cabeceras de la fila 1 quedaban ocultas). Fix en `UI/Dashboard.vb`: agregar en orden `content`, `topBar`, `side`. Verificado numéricamente: `side=(0,0,230x681)`, `top=(230,0,954x64)`, `content=(230,64,954x617)`, sin intersecciones.
- **Tarjetas desordenadas:** el `body Fill` se agregaba después del `header Top` y las 5 filas `Dock Top` se apilaban en orden inverso (la fila de sistema quedaba oculta tras la cabecera y `Añadir` se cortaba por wrap del `FlowLayout`). `UI/EquipoCard.vb` reescrito con `TableLayoutPanel` de 5 filas fijas + paneles de posición absoluta; orden verificado: cabecera → IP → tiempo (H/M/Iniciar/Añadir) → bloqueo → mensaje → sistema, todo dentro de la tarjeta 372x300.
- **Caracteres (`dÃ­a`, `Â·`):** `Dashboard.vb` pasó por un `Get-Content/Sed-Content` que lo leyó como ANSI y horneó el mojibake (más BOM). Restaurados `día, módulo, ·, ¿, á, Ó` en `UI/Dashboard.vb` y agregado BOM UTF-8 a `EquipoCard.vb, Db.vb, Ventas.vb, Ventas.Designer.vb` para que el compilador siempre los lea como UTF-8.
- Página Red: orden de botones del Dock corregido (`+Equipo, Guardar, Eliminar` y `Puerto:, campo, Guardar puerto`); quitado `Anchor Right` en conflicto con el posicionado manual del topbar.

### v4.2 — POS/Productos/Historial integrados + VER en vivo (2026-09-30)
- **Red y equipos:** grid con cabeceras legibles (`ID | Equipo | IP del equipo`) y anchos fijos; `+Equipo` ahora usa el primer número libre (antes `count+1` podía duplicar `Equipo 10` y pisar su IP por el `ON CONFLICT`); `Guardar` lee del grid (compatible con el ordenado por ID).
- **Punto de venta dentro del Dashboard:** nuevo `UI/PosControl.vb` (página interna, estilo del sistema: buscador, catálogo + ticket, equipo/pago/cantidad, total y Cobrar). Ya no abre ventana aparte.
- **Productos independiente:** nuevo `UI/ProductosControl.vb` (página con editor + catálogo).
- **Historial independiente:** nuevo `UI/HistorialControl.vb` (página con filtros Desde/Hasta + total del periodo). La Caja del día sigue como resumen de hoy + sesiones.
- Sidebar: Equipos / Punto de venta / Productos / Historial / Caja del día / Red y equipos. `Ventas.vb` (ventana vieja) se retiró del build (archivos conservados como respaldo); `CiberControl` legacy desacoplado.
- **Botón VER en vivo:** nuevo `UI/ScreenHub.vb` — un solo socket UDP reparte capturas por IP de origen, así se abren varios visores sin `dirección ya en uso`. `pantallaEquipo` reescrito: estado `Conectando/En vivo/Sin señal` con diagnóstico (IP del servidor, puerto y firewall del cliente). Al pulsar VER el servidor envía comando `VER` y el cliente (`Config.vb`: `EnviarCaptura()` extraído + caso `VER`) responde con un cuadro inmediato; el streaming continuo bajó a cada 3 s (JPEG q55).
- Verificación: build Servidor 0 errores (a carpeta temporal porque el exe estaba en uso), Cliente OK; test STA: sidebar en orden, Pos/Productos/Historial/visor construyen; barrido de bytes confirma 0 secuencias de mojibake en los 9 archivos tocados.

### v4.3 — Grids, Acerca de y VER definitivo (2026-10-01)
- **Grids debajo del buscador (corregido en 5 zonas):** mismo bug de `Dock` — el `Fill` agregado al último tapaba la barra superior. Reordenado en `PosControl`, `ProductosControl`, `HistorialControl`, Caja (`split` antes que `sum`) y Red (`dgv`, `bar`, `hint`). Test STA: `sin-solape=True` en dashboard/pos/productos/historial.
- **Red:** además `+Equipo` con primer número libre y `Guardar` leyendo del grid ordenado.
- **Acerca de (nuevo):** sidebar + página con logo, versión 4.3, descripción, tabla (versión/BD/comunicación/desarrollador **KrDev**/módulos) y enlace `kr-dev.site` (LinkLabel que abre el navegador). Es el **único** lugar con enlace: quitado de footer del Dashboard (`v4.3`), `PantallaBlo` (`Desarrollado por KrDev`), `TiempoServ` y `CiberControl` legacy.
- **VER definitivo:** `ScreenHub` registra todo remitente (`Remitentes()`) aunque no tenga visor; el visor reenvía `VER` cada 3 s hasta el primer cuadro y muestra `puerto + remitentes vistos` para diagnosticar. El cliente aprendió la IP del servidor del último comando recibido (`_ultimoServidor`) y la usa si `ipServidor` está vacía; streaming cada 3 s JPEG q55.
- Limpieza firewall duplicado: `Remove-NetFirewallRule -DisplayName "Ciber Servidor UDP"` y crear una sola vez.
- Verificación: build Servidor+Cliente 0 errores a `Salida/`; app arranca `Control de Ciber v4.3` estable.

### v4.4 — Cliente sin configuración + archivo cifrado + limpieza (2026-10-01)
- **Cliente sin UI de configuración:** eliminados `Config` e `ingresarContrasena` (disco + proyecto). Arranque nuevo `Cliente.Arranque:Sub Main` (bucle de mensajes sin formulario). Nuevo `MotorCliente` con la misma lógica (tiempos, mensajes, captura, `SETCFG`, `VER`, `SALIR`) y `PantallaBlo` como única pantalla (su clave ahora valida contra el cfg cifrado; ya no abre nada al desbloquear).
- **`cliente.cfg` cifrado:** `Seguridad/Crypto.vb` (AES-256-CBC + clave embebida, SHA256 para la clave admin) y `Seguridad/ClienteCfg.vb` (puerto, servidor, ciber, tiempos, hash). Ilegible y antimanipulación (dato alterado = se ignora). Test: roundtrip OK, plano oculto, clave inicial `102250` válida.
- **Todo se controla desde el servidor:** panel nuevo en Red — equipo/Todos, puerto, IP servidor (prellenada con la IP local), ciber, tiempos, nueva clave → comando `SETCFG:clave:valor` que el cliente guarda cifrado y aplica en caliente (incluye reapertura de puerto). Cambio de puerto global además se propaga a los clientes antes de guardar y reinicia el `ScreenHub`.
- **Limpieza:** borrados del disco y de ambos `.vbproj`: `CiberControl.*`, `Main.*`, `RegPC.*`, `Ventas.*` (servidor) y `Config.*`, `ingresarContrasena.*` (cliente). `Application.Designer` del cliente apunta a `PantallaBlo` como respaldo.
- Versión unificada v4.4 en Dashboard, Acerca de, footer y TiempoServ.

### v4.5 — Diagnóstico definitivo del VER (2026-10-01)
- Síntoma: visor en `remitentes vistos: 0` = al servidor no llega ni la cabecera `TOTAL` (39 bytes): el cliente no envía, envía a otra IP o algo lo frena en el camino. No es reensamblado.
- **Prueba loopback del ScreenHub: OK.** `TOTAL:2` + 2 fragmentos → callback con bytes exactos (`HELLO-WORLD`), salida limpia. El canal del servidor está probado; el `StackOverflow` visto una vez fue del script de prueba (scriptblock de PowerShell como callback), no del programa.
- **`cliente.log` (nuevo):** el cliente escribe junto al exe `arranque v4.5 puerto=X servidor=Y`, `setcfg clave=Z`, `ver recibido`, `stream cuadros=N dest=IP:puerto` cada minuto y `captura error: ...`. Si en el cliente NO aparece el log, no corre el exe nuevo. Si aparece, dice exactamente a dónde envía.
- Versión v4.5 visible en Dashboard, Acerca de, TiempoServ y pantalla de bloqueo (sirve para confirmar el exe desplegado).

### v4.6 — Typo 198.x, nombre en vivo y pantalla blanca (2026-10-01)
- **Causa del VER:** el log mostró `servidor=198.168.1.7` (198, no 192): todo el video iba a una IP inexistente. Los comandos sí llegaban (`setcfg`, `ver recibido`) y la tarjeta en verde lo confirmaba. Solución: reenviar IP correcta desde Red → Configurar cliente.
- **SETCFG nombre ya aplicaba pero no se veía:** `PantallaBlo` solo leía el nombre al abrirse. Ahora `AplicarCfg` lo refresca en vivo en la pantalla abierta.
- **Pantalla de bloqueo blanca:** tema claro (fondo blanco, textos oscuros, nombre en azul).
- **Anti-typo:** al enviar IP de servidor que no es red privada (192.168/10/172.16-31) el Dashboard pide confirmación. Versión v4.6 en todo.

### v4.7 — Puerto global + SETCFG verificable (2026-10-01)
- **Por qué nombre/clave no entraban:** el puerto se podía cambiar por equipo y el servidor seguía apuntando al viejo → los pushes dejaban de llegar en silencio (tu log mostraba `setcfg`/`ver` y luego nada). Además el nombre solo se leía al abrir el bloqueo.
- **Puerto global único:** quitado el campo Puerto del panel Configurar cliente. El puerto solo se cambia con Guardar puerto (propaga a todos por el puerto viejo + reinicia escucha). Imposible divergir.
- **Aplicación visible:** el cliente registra `cfg aplicado ciber=X / tmsg=N / tpre=N / servidor=X / pass=***` en `cliente.log`; el nombre se refresca en vivo en el bloqueo abierto.
- Versión v4.7 en servidor, bloqueo y log (confirma el exe desplegado en cada PC).

### v4.8 — Video 1 fps + diseñador + cronómetro (2026-10-01)
- **Video casi en vivo:** captura cada 1 s a 960 px JPEG q50 (~30-45 KB, 5-7 fragmentos); `ScreenHub` descarta parciales de >4 s (evita cuadros mezclados); visor con fps, resolución y hora; imagen en `Zoom` (ajusta sin deformar).
- **Todo editable en diseñador:** `Dashboard, EquipoCard, PosControl, ProductosControl, HistorialControl` ahora son parciales `.vb` (lógica + `Handles`) + `.Designer.vb` (controles), registrados en el `.vbproj`. Los estilos siguen por `Theme` en runtime. `pantallaEquipo` suma `lblStatus` al diseñador.
- **Cronómetro restante (cliente):** `TiempoServ` muestra `Te quedan HH:MM:SS` en vivo (verde, rojo en preaviso) vía `MotorCliente.TiempoRestante()`; formulario más alto.
- **Bug cazado con pila:** `NullReferenceException` intermitente en `CargarRed` al fijar `Column.Width` con el grid en modo `Fill` (quirk WinForms sin handle). Fix: modo `None` + anchos + `Fill` solo en IP (igual en POS). 3/3 arranques limpios verificados. Errores de carga ahora van a `ciber_error.log` con pila completa.
- Versión v4.8 en todo.

### v4.9 — Calidad seleccionable del monitoreo (2026-10-01)
- **¿Resolución mayor? Sí:** el visor trae selector `Baja 640 / Media 960 / Alta 1280 / Muy alta 1600` (ancho px + JPEG 45/50/55/60). Comando nuevo `CALIDAD:ancho:q` que el cliente aplica en vivo, guarda en `cliente.cfg` y confirma con cuadro inmediato. La barra muestra la resolución real recibida.
- Nota: a 1600 px el cuadro pesa ~150-250 KB (~2 Mbps a 1 fps, bien en LAN cableada; en WiFi débil baja a Media).
- Versión v4.9 en servidor, bloqueo y log.

## v3.0 — Base SQLite + ventas (base de lo anterior)

## 1. Base de datos SQLite (nuevo)
- Paquete `Microsoft.Data.Sqlite 8.0.7` agregado a `Servidor/Servidor.vbproj` (restaura con MSBuild, despliega `e_sqlite3.dll` en `Salida/`).
- Nuevo `Servidor/Data/Db.vb`: helper central con `DbPath()=ciber.db` junto al exe, `Init()` con `CREATE TABLE IF NOT EXISTS`.
- Tablas: `Equipos(Id,Nombre,Ip)`, `Productos(Id,Nombre,Categoria,Precio,Stock)`, `Ventas(Id,Fecha,Equipo,Total,MetodoPago)`, `VentaDetalle(VentaId,ProductoId,Cantidad,Precio,Subtotal)`, `Sesiones(Equipo,Inicio,Minutos)`, `Config(Clave,Valor)`.
- `Puerto()` ahora se lee de `Config` con fallback a `My.Settings`; `MigrarEquiposLegacy()` importa `ipPC1..10` una sola vez; `SeedProductos()` precarga 6 artículos (impresiones, fotocopias, refrescos, agua, papas).
- Verificado en ejecución: `Salida/Servidor.exe` genera `ciber.db (40 KB)` y `Salida/Cliente.exe` permanece en ejecución sin crashear.

## 2. Módulo de ventas / papelería (nuevo)
- `Servidor/Ventas.vb` + `Ventas.Designer.vb` (registrados en `Servidor.vbproj`), formulario 1024x600 con 3 pestañas:
  - **Punto de venta:** buscador en vivo, catálogo, cantidad, carrito, total, equipo + método de pago, `Cobrar (F12)`. Descuenta stock en transacción.
  - **Productos / Papelería:** CRUD (Nuevo/Guardar/Eliminar lógico) con validación de nombre.
  - **Historial:** filtro por fechas, total del día, últimas 500 ventas.
- Acceso desde `CiberControl` con nuevo botón `btnVentas` (verde). `CiberControl.Designer.vb`: ventana ampliada 800x480 → 1024x585, `TabControl` 776x356 → 1000x440, fondo `#F3F4F6`.

## 3. Diseño más moderno
- Nuevo `Servidor/Theme.vb`: paleta (`Primary #2D89EF`, `Success #27AE60`, `Danger #E74C3C`, `Dark #1F2937`) + `StyleButton()` flat.
- Aplicado en `Main`, `CiberControl`, `Ventas` (botones Iniciar/Añadir/Bloquear/Cobrar, etc.).

## 4. Bugs corregidos
| # | Archivo:Línea (origen) | Bug | Fix |
|---|---|---|---|
| 1 | `Servidor/RegPC.vb:11` | `ipPC9 = ip8.Text` (equipo 9 nunca se guardaba) | `RegPC.vb` reescrito: guarda cada equipo en SQLite con validación `IPAddress.TryParse`; sincroniza `My.Settings` correctamente |
| 2 | `Servidor/Main.vb:259` | `picPantalla_Click` sin `Handles` (visor nunca abría) | Agregado `Handles picPantalla.Click` + `IpValida()` |
| 3 | `Servidor/pantallaEquipo.vb:13` | `totalFragments=-1` jamás asignado → imagen nunca se armaba; doble lógica `Task`+`Timer`, `MessageBox` en hilo, mezcla UTF7/UTF8 | Reescrito: protocolo `TOTAL:<n>` + fragmentos `D5`, solo `Task` con `CancellationToken`, `TimerRecibir.Enabled=False`, dispose de imágenes |
| 4 | `Cliente/Config.vb:28` | `New UdpClient(CInt(TextBoxPUERTO.Text))` antes de cargar settings → crash en primer arranque | Carga settings primero, `TryParse` con default 55555, `PUERTO_LOCAL` robusto |
| 5 | `Cliente/Config.vb:19-20` | `SERVIDOR_IP/PUERTO` cacheados como `Field` (cambiar IP exigía reinicio) | Convertidos a `ReadOnly Property` que leen `My.Settings` en vivo |
| 6 | `Cliente/Config.vb:136` + `Servidor/Main.vb` | `Split(":")` sin límite + `UTF7` → mensajes con `:` se truncaban; `UTF7` obsoleto | Nuevo `Servidor/Net/NetProtocol.vb` (UTF8, `Split(...,3)`, `Using UdpClient` por envío); cliente usa `UTF8` + `Split(...,3)` + `Available<=0` |
| 7 | `Cliente/Config.vb:43` | `TimerCaptura` comentado pero con `Interval=5000/Enabled=True` + fragmentos 8192 sin cabecera | `TimerCaptura_Tick` funcional: JPEG calidad 60, mitad de resolución, fragmentos 7000 + cabecera `TOTAL:`, sin `MessageBox` en loop |
| 8 | `Cliente/Cliente.vbproj:52` | `Release OutputPath=..\Servidor\bin\Release\` | Corregido a `..\Salida\` como Debug |
| 9 | `Servidor/Main.vb` | `Select Case x10` duplicado, `UdpClient ADMINISTRADOR` reutilizado sin dispose, `Ping` sin dispose, `TimerMINUTOS=60s` impreciso | `Main.vb` reescrito: IP desde `Db.IpDeEquipo()` + fallback legacy, `NetProtocol.SendUdp()` (dispose por envío), `Using Ping` + timeout 1500ms, registra `Sesiones`, chequeo cliente cada 15s |
| 10 | Cliente seguridad | `adminPass=102250` en claro, comparación directa en 2 forms | `HashPass()` SHA256 + `PassOk()` compatible legacy; `btnSavePass` hashea y limpia el textbox; `PantallaBlo` e `ingresarContrasena` usan `PassOk` |
| 11 | Cliente robustez | `CERRAR()`, `TimerMINUTOS`, registry sin `Using`, `shutdown` sin delay | `Try/Catch` por cierre, `shutdown /t 5`, `Using` en registry, validación IP servidor |

## 5. Archivos nuevos / modificados
- Nuevos: `Servidor/Data/Db.vb`, `Servidor/Net/NetProtocol.vb`, `Servidor/Theme.vb`, `Servidor/Ventas.vb`, `Servidor/Ventas.Designer.vb`, `CAMBIOS.md`.
- Modificados: `Servidor/Servidor.vbproj`, `Cliente/Cliente.vbproj`, `Servidor/Main.vb`, `Servidor/CiberControl.vb`, `Servidor/CiberControl.Designer.vb`, `Servidor/RegPC.vb`, `Servidor/pantallaEquipo.vb`, `Cliente/Config.vb`, `Cliente/PantallaBlo.vb`, `Cliente/ingresarContrasena.vb`.
- Compilación: `MSBuild 17.14` `Restore,Build Debug/x86` OK en ambos proyectos; binarios en `Salida/` + `ciber.db` auto-generada.

## 6. Pendiente / recomendaciones
- El monitoreo de pantalla UDP puede perder fragmentos en WiFi; a futuro usar TCP o reenvío; hoy funciona en LAN cableada.
- El bloqueo de cliente sigue siendo a nivel WinForms (no kiosco real): para endurecer, evaluar GPO + cuenta estándar + `Ctrl+Alt+Supr` deshabilitado por política.
- Migrar `My.Settings.puerto/adminPass` restantes a `Config`/`hash` en una v3.1 y agregar reporte de cierre de caja (ventas + tiempo) en PDF.

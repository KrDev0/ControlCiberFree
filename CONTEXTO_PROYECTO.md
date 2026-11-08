# Control de Ciber v3 — Contexto del proyecto (para IA)

> Nota de versión: el dueño mantiene las cadenas de versión en el código.
> No modificar textos de versión (`v4.x` en títulos/footers) sin su indicación.
> Este documento describe la **v3 del sistema** (reescritura completa).

## 1. Qué es
Sistema de administración para cibercafés con dos programas Windows que se hablan por red local (LAN):
- **Servidor** (`Servidor/` → `Salida/Servidor.exe`): lo usa el encargado. Control de tiempos por equipo, punto de venta, productos, historial, caja del día, red/equipos y monitoreo de pantallas en vivo.
- **Cliente** (`Cliente/` → `Salida/Cliente.exe`): corre en cada PC de clientes. Muestra pantalla de bloqueo, reloj de tiempo restante, mensajes del encargado y envía capturas de pantalla al servidor. **No tiene interfaz de configuración**: todo se controla desde el servidor.

## 2. Stack técnico
- VB.NET, WinForms, .NET Framework 4.8, plataforma x86.
- Solución: `ControlCyber.sln` (VS 2022, `MSBuild 17`, configuración `Debug|x86` → salida a `Salida/`).
- Servidor usa NuGet `Microsoft.Data.Sqlite 8.0.7` (`PackageReference` en `Servidor.vbproj`; despliega `e_sqlite3.dll` y `SQLitePCLRaw*` en `Salida/`).
- Cliente no tiene dependencias externas.
- Codificación de archivos: **UTF-8 con BOM** (obligatorio; sin BOM el compilador puede romper tildes/acentos). No usar `Get-Content/Set-Content` sin `-Encoding UTF8` sobre los `.vb`.
- `Option Strict Off`, `Option Explicit On`. Convención UI por código original migrada a diseñador: formularios nuevos son parciales `.vb` (lógica + `Handles`) + `.Designer.vb` (controles). Los estilos visuales se aplican en runtime vía `Theme` para no pelear con el diseñador.
- Arranque servidor: `My Project/Application.myapp` → `MainForm=Dashboard` (`Application.Designer.vb` en sincronía).
- Arranque cliente: `StartupObject=Cliente.Arranque` → `Arranque.Main()` (bucle `Application.Run()` sin formulario; `Application.Designer.vb` apunta a `PantallaBlo` solo como respaldo).

## 3. Mapa del repositorio
```
v2.0/
  ControlCyber.sln
  CAMBIOS.md               # changelog técnico por iteración
  CAMBIOS_VIDEO.md         # relato de cambios para video
  CONTEXTO_PROYECTO.md     # este archivo
  Salida/                  # binarios (Servidor.exe, Cliente.exe, DLLs, ciber.db)
  iconos/
  Servidor/
    Servidor.vbproj        # x86, PackageReference Microsoft.Data.Sqlite
    App.config
    Theme.vb               # paleta + StyleButton/StyleSideButton/StyleGrid
    Net/NetProtocol.vb     # BuildMessage/ParseMessage/SendUdp (UTF8)
    Data/Db.vb             # SQLite: Init + CRUD equipos/productos/ventas/sesiones/config
    UI/Dashboard.vb(.Designer.vb)      # ventana principal (arranque)
    UI/EquipoCard.vb(.Designer.vb)     # tarjeta de control por equipo
    UI/PosControl.vb(.Designer.vb)     # punto de venta embebido
    UI/ProductosControl.vb(.Designer.vb)
    UI/HistorialControl.vb(.Designer.vb)
    UI/ScreenHub.vb        # un socket UDP reparte capturas por IP de origen
    pantallaEquipo.vb(.Designer.vb)    # visor en vivo + selector de calidad
    My Project/
  Cliente/
    Cliente.vbproj         # x86, StartupObject=Cliente.Arranque
    App.config
    Arranque.vb            # Sub Main: Cargar cfg → Motor → Application.Run
    MotorCliente.vb        # escucha UDP, tiempos, mensajes, captura, SETCFG/VER/CALIDAD/SALIR
    Seguridad/Crypto.vb    # AES-256-CBC (clave embebida) + SHA256 + PassOk
    Seguridad/ClienteCfg.vb# cliente.cfg cifrado (puerto, servidor, ciber, tiempos, hash, video)
    PantallaBlo.vb(.Designer.vb)       # bloqueo fullscreen (única pantalla + clave local)
    TiempoServ.vb(.Designer.vb)        # reloj + cronómetro "Te quedan HH:MM:SS"
    Mensaje.vb(.Designer.vb)           # avisos del encargado
    My Project/
```
Formularios legacy (`CiberControl`, `Main`, `RegPC`, `Ventas`, `Config`, `ingresarContrasena`) fueron **eliminados del disco y de ambos `.vbproj`**.

## 4. Paleta (Theme.vb)
`Primary #2D89EF`, `Success #27AE60`, `Danger #E74C3C`, `Warn #F39C12`, `Dark #1F2937`, `Bg #F3F4F6`, `Muted #6B7280`. Sidebar oscuro, topbar blanca, tarjetas blancas.

## 5. Base de datos (Servidor, `ciber.db` junto al exe)
Creada por `Data/Db.vb:Init()` (`CREATE TABLE IF NOT EXISTS` + migración legacy + seed).
- `Equipos(Id, Nombre UNIQUE, Ip, Activo)` — tarjetas y página Red. Baja lógica (`Activo=0`).
- `Productos(Id, Nombre, Categoria, Precio, Stock, Activo)` — seed: 6 artículos (impresión B/N y color, fotocopia, refresco, agua, papas).
- `Ventas(Id, Fecha TEXT yyyy-MM-dd HH:mm:ss, Equipo, Total, MetodoPago)` + `VentaDetalle(VentaId, ProductoId, Cantidad, Precio, Subtotal)` — cobro en transacción con descuento de stock.
- `Sesiones(Equipo, Inicio, Minutos)` — se inserta al Iniciar tiempo desde la tarjeta.
- `Config(Clave, Valor)` — hoy solo `puerto` (default `55555`, fallback `My.Settings.puerto`).
- Reglas de puerto: **el puerto es global único**. Servidor escucha video en `Db.Puerto()`; clientes escuchan comandos en su `cliente.cfg:Puerto`. `RedGuardarPuerto` propaga el nuevo puerto a los clientes por el puerto viejo y reinicia `ScreenHub`. No existe puerto por equipo.

## 6. Protocolo UDP (todo UTF8, formato `COMANDO:p1:p2`, split limitado a 3 partes)
Dirección servidor→cliente al puerto del cliente; cliente→servidor a `IpServidor:Puerto`.
| Comando | p1 | p2 | Efecto cliente |
|---|---|---|---|
| `INICIAR` | horas | minutos | arranca sesión, desbloquea, muestra reloj |
| `AÑADIR` | horas | minutos | extiende `HORALIMITE` |
| `BLOQUEO` / `DESBLOQUEAR` | `0` | `0` | muestra/cierra bloqueo |
| `MENSAJE` | texto (admite `:`) | `0` | muestra `Mensaje` |
| `REINICIAR` / `APAGAR` | `0` | `0` | `shutdown /r\|/s /t 5 /f` |
| `BLOQUEARPC` | `0` | `0` | `LockWorkStation` |
| `VER` | `0` | `0` | envía un cuadro inmediato |
| `CALIDAD` | ancho 320-1920 | q 30-85 | cambia resolución/calidad, guarda, envía cuadro |
| `SETCFG` | clave | valor | `puerto/servidor/ciber/tmsg/tpre/pass` (+`videow/videoq`), guarda cifrado, aplica en caliente |
| `SALIR` | — | — | cierra el motor (`ExitThread`) |
| Tramas video | `TOTAL:<n>` luego `NNNNN+bytes` | JPEG | `ScreenHub` reensambla por IP (descarta parciales >4 s) |

## 7. Video en vivo
Cliente: `TimerCaptura` 1 s → captura escalada (`VideoW`, default 960, selector 640/960/1280/1600 + q 45/50/55/60) → JPEG → cabecera `TOTAL:<n>` + fragmentos 7000 B con prefijo `D5`. Servidor: `ScreenHub.Ensure(puerto)` (un socket para N visores; `Subscribe/Unsubscribe(ip)`; `Remitentes()` para diagnóstico) → `pantallaEquipo` muestra `Zoom` + barra `En vivo · IP · WxH · fps · hora` / `Sin señal (puerto, remitentes vistos)` y reenvía `VER` cada 2-3 s hasta el primer cuadro. Si `ipServidor` está vacía, el cliente usa la IP del último comando recibido.

## 8. Seguridad y config del cliente
- `cliente.cfg` (AES-256-CBC, IV aleatorio antepuesto, Base64; clave derivada por SHA256 de frase embebida en `Crypto.vb`). Dato alterado = se ignora y se usan defaults. Clave admin = SHA256 (inicial `102250` si no hay hash).
- Sin UI de config en cliente; desbloqueo local solo con clave del bloqueo. Diagnóstico: `cliente.log` (`arranque`, `setcfg clave=`, `cfg aplicado ...`, `ver recibido`, `stream cuadros=N dest=`, `captura error:`) y `ciber_error.log` en servidor (pila completa de errores de carga).

## 9. Compilar y probar
```powershell
$msb = "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe"
& $msb "Servidor\Servidor.vbproj" /t:Rebuild /p:Configuration=Debug /p:Platform=x86 /v:minimal
& $msb "Cliente\Cliente.vbproj"  /t:Rebuild /p:Configuration=Debug /p:Platform=x86 /v:minimal
```
- Si `Servidor.exe` está en uso, el build falla con acceso denegado: cerrarlo antes.
- Tests usados: STA x86 (`powershell x86 -STA`) instanciando formularios (conteo de controles/páginas, `Bounds` sin solapes `Dock`), loopback `ScreenHub` (`TOTAL:2` → bytes exactos), roundtrip AES, `PassOk`, arranque real del Servidor (título + 7 s vivo). No lanzar `Cliente.exe` en pruebas (abre el bloqueo fullscreen).
- Quirk conocido WinForms: no fijar `DataGridViewColumn.Width` con el grid en `AutoSizeMode.Fill` sin handle (NRE intermitente en `set_Thickness`). Patrón usado: grid en `None` + anchos + `Fill` solo en la columna variable.

## 10. Red / despliegue
- Mismo puerto UDP en servidor y clientes (default `55555`). Reglas firewall inbound UDP en ambos (perfil según red; `Any` si la red es pública). Terceros (antivirus con firewall) y aislamiento AP son las causas típicas de `remitentes: 0`.
- Despliegue cliente = copiar `Cliente.exe` nuevo + abrirlo (genera `cliente.cfg`/`cliente.log`) + empujar config desde Red → Configurar cliente.
- Limitaciones asumidas: bloqueo a nivel WinForms (no kiosco real; endurecer con GPO si se requiere), video UDP best-effort (ideal LAN cableada), sin reportes PDF (pendiente).

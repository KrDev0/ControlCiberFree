# Cómo instalar Control de Ciber v3.2

Guía para instalar el sistema desde cero en un ciber nuevo. Tiempo estimado: 20-30 minutos.

## 1. Requisitos
- PC mostrador (servidor) + PCs de clientes, todos en la **misma red local** (ideal: cable de red; WiFi funciona pero el monitoreo se ve mejor por cable).
- Windows 10 u 11 en todos los equipos.
- .NET Framework 4.8 (Windows 10 actualizado y Windows 11 ya lo traen; si falta, se instala gratis desde Microsoft).
- Permiso de **administrador** una sola vez (para la regla del firewall).

## 2. Archivos a copiar
De la carpeta `Salida/` del sistema:
- **Al mostrador:** `Servidor.exe`, `Servidor.exe.config`, `Microsoft.Data.Sqlite.dll`, `SQLitePCLRaw.*.dll`, `System.*.dll`, `e_sqlite3.dll` y la carpeta `runtimes` completa (SQLite la necesita).
- **A cada cliente:** solo `Cliente.exe` (+ `Cliente.exe.config`).
- **NO copies** estos archivos (son de tu ciber y se generan solos): `ciber.db`, `cliente.cfg`, `cliente.log`, `ciber_error.log`, ni los `.pdb` / `.xml`.
- Consejo: crea `C:\Ciber\Servidor` en el mostrador y `C:\Ciber\Cliente` en cada PC cliente y pega ahí lo correspondiente.

## 3. Servidor (mostrador)
1. Abre `Servidor.exe` (la primera vez como administrador: clic derecho → Ejecutar como administrador).
2. Se crea `ciber.db` junto al exe. Ahí se guardan equipos, productos, ventas, sesiones, tarifa y preferencias del servidor. **No borres ni reemplaces este archivo al actualizar** si quieres conservar esos datos.
3. Ve a **Red y equipos**: pulsa `+ Equipo` por cada PC (o edita los existentes), escribe su **IP** (ej. `192.168.1.21`) y pulsa **Guardar IPs**. Deja el puerto en `55555` salvo que choque con otro programa.
4. **Firewall del servidor** (Terminal como administrador):
```powershell
New-NetFirewallRule -DisplayName "Ciber Servidor UDP" -Direction Inbound -Protocol UDP -LocalPort 55555 -Profile Any -Action Allow
```
5. Anota la IP del servidor: `Win+R` → `cmd` → `ipconfig` → línea `Dirección IPv4` (ej. `192.168.1.50`). El panel puede prellenar esta IP; confirma que corresponda a la red local.

## 4. Cada PC cliente
1. Copia `Cliente.exe` y ábrelo: verás la pantalla de bloqueo con el nombre del ciber.
2. Se crean solos `cliente.cfg` (cifrado) y `cliente.log` junto al exe.
3. **Firewall del cliente** (Terminal como administrador):
```powershell
New-NetFirewallRule -DisplayName "Ciber Cliente UDP" -Direction Inbound -Protocol UDP -LocalPort 55555 -Profile Any -Action Allow
```
4. Si el antivirus tiene firewall propio (Avast, ESET, Kaspersky), permite también ahí el puerto UDP `55555` o al programa `Cliente.exe`.
5. Puedes habilitar el inicio automático del cliente desde el servidor; también puedes crear manualmente un acceso directo en `Win+R` → `shell:startup` si prefieres configurarlo directamente en Windows.

## 5. Primera configuración (desde el servidor, sin tocar los clientes)
1. En **Red → Configurar cliente**, elige **Todos** o un equipo, escribe IP del servidor (la del paso 3.5), nombre del ciber, tiempos y una **nueva clave** (la inicial es `102250`, cámbiala aquí). Configura también Administrador de tareas e inicio con Windows si lo necesitas. Pulsa **Enviar al cliente**.
2. En cada cliente abre `cliente.log` y confirma líneas `cfg aplicado ...`. Si no llegan, revisa el apartado 8.
3. Los perfiles enviados quedan guardados por equipo y para **Todos**. Al seleccionar un destino o volver a abrir el servidor se recuperan los valores; el fondo elegido también se conserva. La clave se mantiene cifrada en el perfil local del usuario Windows que ejecuta el servidor.
4. En **Punto de venta**, registra la tarifa por hora que usarás para cobrar el tiempo de PC.
5. Prueba **VER** en una tarjeta: debe pasar a `En vivo` en ~5 segundos. Cambia la **Calidad** (Baja/Media/Alta/Muy alta) a gusto.

## 6. Uso diario
- **Dar tiempo:** tarjeta del equipo → H/M → Iniciar (el cliente se desbloquea y ve su cronómetro `Te quedan HH:MM:SS`). **Añadir** suma minutos. Con 0 minutos la sesión es libre y puedes cobrar el tiempo transcurrido según la tarifa.
- **Cobrar una mesa:** pulsa **Cobrar** en su tarjeta para enviar la cuenta al POS. Ahí se ven el uso del PC y los productos cargados; puedes cobrar el total o repartirlo entre efectivo, tarjeta y transferencia. También puedes cobrar el consumo acumulado antes de terminar una sesión.
- **Cargar productos a una mesa:** en el POS selecciona el equipo antes de agregar productos y elige **Cargar a cuenta**. El importe se suma a su cuenta para cobrarlo junto con el tiempo de uso.
- **Recuperar sesiones:** si el servidor se cierra o un equipo se reinicia, la sesión puede aparecer pausada. Usa **Reanudar** para continuar el reloj o **Cobrar/Finalizar** para llevar el consumo al POS. En Red puedes definir si al cerrar el servidor se pausa el tiempo o sigue corriendo.
- **Inventario e historial:** Productos (Nuevo/Guardar/Eliminar). El historial detalla los artículos y cargos, y muestra cuánto se recibió en efectivo, transferencia y tarjeta. **Caja del día** resume esos métodos y las sesiones.
- **Seguridad del cliente:** desde Red puedes elegir si bloquear el Administrador de tareas y si iniciar el cliente con Windows. El cliente requiere seguir ejecutándose para recibir órdenes y pulsos del servidor.
- **Mensajes:** escribe en la tarjeta → Enviar (F5/Enter).
- La clave de desbloqueo en cada cliente es la que configuraste (también sirve si se cae la red).

## 7. Desinstalar
1. Cierra los programas y borra sus carpetas. Al eliminar `ciber.db` se perderán equipos, configuración, productos, ventas y sesiones guardadas; respáldalo antes si necesitas conservarlos. `cliente.cfg` y los logs también se almacenan junto a cada ejecutable.
2. Quita las reglas de firewall (administrador):
```powershell
Remove-NetFirewallRule -DisplayName "Ciber Servidor UDP"
Remove-NetFirewallRule -DisplayName "Ciber Cliente UDP"
```
3. Quita el acceso directo de `shell:startup` en los clientes.

## 8. Si algo no funciona
| Síntoma | Causa típica | Solución |
|---|---|---|
| Visor: `remitentes vistos: 0` | Al servidor no llega nada | Revisa `cliente.log` en el cliente: si no existe, no corre el exe nuevo; si dice `dest=(sin destino)`, envía la config; si apunta a otra IP, corrígela |
| `stream ... dest=198.168...` | Typo (198 en vez de 192) | Reenvía la IP correcta; el sistema avisa si la IP no es local |
| Tarjeta en rojo | Sin red con ese equipo | Revisa cable, que esté prendido y su IP en Red |
| La config no entra | Puertos distintos | `cliente.log` línea `arranque ... puerto=X` debe igualar el Puerto de Red; si difiere, borra `cliente.cfg` en el cliente, reabre (vuelve a 55555) y reenvía |
| Diálogo `Red` al abrir | Error de carga | Lee `ciber_error.log` junto al exe (trae el detalle) |
| Antivirus bloquea | Firewall propio del AV | Permite UDP 55555 o pausa 2 min para probar |
| Clientes por WiFi aislados | AP isolation | Usa cable o desactiva el aislamiento en el router |

Hecho por KrDev — más info en la sección **Acerca de** del programa (`kr-dev.site`).

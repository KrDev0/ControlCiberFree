# Control de Ciber v3 — Todos los cambios (guion para video)

Sistema de control para cibercafés rehecho desde cero: antes 10 pestañas grises con IPs a mano y protocolo frágil; ahora panel moderno, base de datos, punto de venta y monitoreo en vivo. Todo lo de abajo está implementado y probado en `Salida/`.

## 1. Nueva cara: el Dashboard
- **Antes:** 10 tabs idénticas, IPs en settings, límite fijo de 10 equipos.
- **Ahora:** sidebar oscuro con 7 secciones (Equipos, Punto de venta, Productos, Historial, Caja del día, Red y equipos, Acerca de), barra superior con reloj y total del día.
- *(Muestra: abre el Servidor, recorre el sidebar.)*

## 2. Tarjetas por equipo en vez de pestañas
- Cada equipo es una tarjeta con semáforo (verde En línea / rojo Sin conexión por ping cada 20 s), su IP y botones: Iniciar/Añadir tiempo (H/M), Bloquear/Desbloquear, mensaje con Enter, Ver pantalla, Bloq. Windows, Reiniciar y Apagar (estos dos piden confirmación).
- Cada Iniciar queda registrado como sesión en la base de datos.
- Los equipos salen de la BD: tantos como registres, ya no 10 fijos.
- *(Muestra: inicia tiempo en una tarjeta, envía un mensaje.)*

## 3. Punto de venta de consumibles y papelería
- Página interna con buscador en vivo, catálogo, ticket con cantidades, equipo, método de pago, total y Cobrar. Descuenta stock en transacción.
- Catálogo precargado: impresión B/N y color, fotocopias, refrescos, agua, papas.
- *(Muestra: arma un ticket y cobra; mira cómo baja el stock.)*

## 4. Productos, Historial y Caja
- **Productos:** alta/baja/modificación con validación (baja lógica, no se borra el historial).
- **Historial:** filtros por fecha con total del periodo.
- **Caja del día:** total, número de tickets, ventas y sesiones de hoy.
- *(Muestra: crea un producto, filtra el historial.)*

## 5. Red y equipos + configuración remota
- Grid `ID | Equipo | IP` con validación, `+Equipo` (usa el primer número libre), Guardar y Eliminar.
- Panel **Configurar cliente**: eliges equipo o Todos y envías IP del servidor, nombre del ciber, tiempos y nueva clave. El cliente lo guarda **cifrado** y lo aplica sin reiniciar.
- El puerto es **global único**: solo cambia con Guardar puerto y se propaga solo a los clientes.
- *(Muestra: cambia el nombre del ciber y mira la pantalla del cliente actualizarse en vivo.)*

## 6. Cliente sin configuración (a prueba de curiosos)
- Se eliminó toda la ventana de ajustes del cliente: ahora arranca solo con la pantalla de bloqueo y un motor oculto.
- Su configuración vive en `cliente.cfg` **cifrado con AES-256** (clave dentro del programa): si alguien lo edita a mano, el cliente lo ignora.
- La clave de desbloqueo viaja hasheada (SHA-256), nunca en claro. Clave inicial: `102250`.
- *(Muestra: abre cliente.cfg con bloc de notas — es ilegible — y el cliente sigue funcionando.)*

## 7. Monitoreo de pantallas en vivo (~1 fps)
- Botón **VER** en cada tarjeta: abre el visor con estado (`Conectando / En vivo con fps y resolución / Sin señal con diagnóstico de puerto y remitentes`).
- Un solo canal recibe a todos los clientes: puedes abrir varios visores a la vez.
- **Selector de calidad:** Baja 640 / Media 960 / Alta 1280 / Muy alta 1600. El cliente cambia al instante y lo recuerda.
- *(Muestra: abre dos visores, cambia a Alta 1280.)*

## 8. Cronómetro de tiempo restante
- El cliente mostraba hora actual, inicio y fin. Ahora suma **"Te quedan HH:MM:SS"** en grande (verde, rojo en preaviso) más aviso antes del corte y bloqueo automático al expirar.
- *(Muestra: inicia 1 minuto y mira la cuenta regresiva.)*

## 9. Pantalla de bloqueo blanca y Acerca de
- Bloqueo en tema claro con el nombre de tu ciber en azul.
- Sección **Acerca de**: versión, base de datos, módulos, desarrollador KrDev y enlace `kr-dev.site` (único enlace del sistema).

## 10. Los bugs que se cazaron (para la parte técnica del video)
1. El equipo 9 guardaba la IP del 8 (`ipPC9 = ip8.Text`).
2. Ventana de ventas en blanco: faltaban los `tab.Controls.Add` de las 3 pestañas.
3. Visor roto de origen: el total de fragmentos nunca se fijaba (`-1`).
4. Sidebar y grids superpuestos: el panel `Fill` agregado al último tapaba todo (se midió: `sin-solape=True`).
5. Tildes rotas (`dÃ­a`): archivos sin BOM UTF-8.
6. El misterio del video: el cliente enviaba a `198.168.1.7` en vez de `192.168.1.7` — se vio en `cliente.log`, y ahora el sistema avisa si la IP no es local.
7. Nombres/claves que "no entraban": el puerto había divergido entre cliente y servidor + la etiqueta no se refrescaba. Hoy el puerto es único y el log confirma cada `cfg aplicado`.
8. Crash intermitente al abrir Red: fijar anchos de columna con grid en modo `Fill` (quirk WinForms) — documentado con pila en `ciber_error.log`.

## 11. Cómo desplegarlo (cierre del video)
1. Copia `Servidor.exe` (+ DLLs) al mostrador y `Cliente.exe` a cada PC.
2. En Red registra IPs, deja el puerto (55555) y abre el puerto UDP en el firewall.
3. Desde Configurar cliente envía IP del servidor, nombre, tiempos y clave a Todos.
4. Pulsa VER: `En vivo` en ~5 segundos. El `cliente.log` de cada PC cuenta qué hace.

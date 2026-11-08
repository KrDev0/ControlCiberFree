# Control de Ciber v3.0 🚀

Primera versión pública del nuevo Control de Ciber: sistema rehecho desde cero con panel moderno, base de datos SQLite y monitoreo de pantallas en vivo.

## ✨ Lo nuevo
- **Dashboard** con sidebar oscuro y 7 secciones: Equipos, Punto de venta, Productos, Historial, Caja del día, Red y equipos, Acerca de. Reloj en vivo y total del día.
- **Tarjetas por equipo**: estado por ping (verde/rojo), iniciar/añadir tiempo, bloquear/desbloquear, mensajes, ver pantalla, apagar/reiniciar. Sin límite fijo de equipos y cada sesión queda registrada.
- **Punto de venta**: buscador en vivo, ticket con cantidades, métodos de pago y cobro con descuento automático de stock.
- **Productos, Historial y Caja**: catálogo con validación, ventas por fecha con totales y resumen diario con sesiones.
- **Monitoreo en vivo (~1 fps)**: botón VER por equipo, varios visores a la vez y selector de calidad (640 / 960 / 1280 / 1600 px).
- **Cliente sin configuración**: sin menús locales; todo se envía desde Red → Configurar cliente y se guarda **cifrado (AES-256)**. Clave inicial `102250` (cámbiala al instalar).
- **Cronómetro restante**: el cliente muestra `Te quedan HH:MM:SS` (rojo en preaviso), con aviso antes del corte y bloqueo automático.
- **Pantalla de bloqueo blanca** y sección **Acerca de** (KrDev · kr-dev.site).

## 🔧 Corregido desde la v2
Equipo 9 que guardaba la IP del 8, ventana de ventas en blanco, visor que nunca armaba la imagen, mensajes con `:` truncados, sidebar y grids superpuestos, tildes rotas y crash intermitente al abrir Red. Protocolo unificado en UTF-8, puerto UDP global único y logs de diagnóstico (`cliente.log`, `ciber_error.log`).

## 📦 Instalación
1. Descarga los binarios (`Servidor.exe` + DLLs para el mostrador, `Cliente.exe` para cada PC).
2. Registra las IPs en **Red y equipos** y abre el puerto UDP `55555` en el firewall.
3. Envía la configuración a los clientes desde **Red → Configurar cliente**.
4. Pulsa **VER**: `En vivo` en ~5 segundos.

Guía completa: `ComoInstalar.md`. Licencia MIT — hecho por **KrDev**.

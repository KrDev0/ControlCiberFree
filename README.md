# Control de Ciber v3.2 🖥️

Sistema gratuito para administrar cibercafés: controla tiempos por equipo, vende consumibles y papelería, monitorea pantallas en vivo y lleva la caja del día — todo desde un solo panel.

![VB.NET](https://img.shields.io/badge/VB.NET-WinForms-512BD4) ![Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4) ![SQLite](https://img.shields.io/badge/SQLite-003B57) ![License](https://img.shields.io/badge/license-Uso_gratuito-blue)

## ✨ Funciones

| Módulo | Qué hace |
|---|---|
| **Equipos** | Tarjetas con estado en vivo, sesiones de tiempo fijo o libre, tiempo transcurrido/restante e importe estimado. Permite pausar, reanudar y cobrar desde el POS; recupera sesiones tras cierres o reinicios. |
| **Punto de venta** | Catálogo y ticket. Carga productos a la cuenta de una mesa, muestra tiempo y cargos juntos y admite pagos en efectivo, tarjeta, transferencia o mixtos. |
| **Productos** | Catálogo de consumibles y papelería (alta/baja/modificación) |
| **Historial y Caja** | Ventas con detalle de productos y cargos, importe por método de pago y resumen del día (efectivo, transferencia y tarjeta). |
| **Monitoreo en vivo** | Ve la pantalla de cada PC (~1 fps) con calidad seleccionable (640 → 1600 px) |
| **Red y equipos** | IPs, puerto global y configuración remota por equipo o para todos. Guarda perfiles y fondo elegido para recuperarlos al volver a abrir el servidor. |
| **Cliente blindado** | Pantalla de bloqueo, cronómetro, pulso con el servidor y `cliente.cfg` cifrado con AES-256. El servidor puede configurar el Administrador de tareas, inicio con Windows y pausa al cerrar. |

## 🖥️ Requisitos
- Windows 10/11, PCs en la misma red local, .NET Framework 4.8.

## 🚀 Instalación
Guía paso a paso (20-30 min): **[ComoInstalar.md](ComoInstalar.md)**

Resumen:
1. Copia los archivos de `Salida/` según la [guía de instalación](ComoInstalar.md).
2. Registra las IPs en **Red y equipos** y abre el puerto UDP en el firewall.
3. Envía la configuración a los clientes desde **Red → Configurar cliente**; el servidor recuerda los perfiles.
4. Define la tarifa por hora en el POS, prueba **VER** y configura las opciones de inicio/bloqueo que necesites.

Las sesiones y ventas se guardan en `ciber.db` junto a `Servidor.exe`. Conserva ese archivo al actualizar para mantener equipos, productos, configuraciones, historial y sesiones recuperables.

## 🗂️ Estructura
```
ControlCyber.sln        # solución (Servidor + Cliente, x86)
Salida/                 # binarios listos para copiar
Servidor/               # panel del encargado (SQLite + UDP)
  UI/                   # Dashboard, tarjetas, POS, productos, historial, ScreenHub
  Data/ Net/            # base de datos y protocolo
Cliente/                # PCs de clientes (bloqueo, reloj, motor, cfg cifrado)
  Seguridad/            # AES-256 + cliente.cfg
```

## 🛠️ Desarrollo
- Documentación técnica: [CONTEXTO_PROYECTO.md](CONTEXTO_PROYECTO.md) · Cambios: [CAMBIOS.md](CAMBIOS.md) · Video: [CAMBIOS_VIDEO.md](CAMBIOS_VIDEO.md)
- Compilar (VS 2022, `Debug|x86`): ambos `.vbproj` generan en `Salida/`.
- Convenciones: archivos `.vb` en UTF-8 con BOM, formularios `.vb` + `.Designer.vb`, estilos en `Theme`, puerto UDP global único (`55555`).

## 👨‍💻 Autor
**KrDev** — [kr-dev.site](https://kr-dev.site)

## 📄 Licencia
Uso gratuito. Prohibida su venta, alquiler o cobro por el software o su instalación
como producto. Ver **Términos de uso** en el programa (Acerca de) o `TERMINOS.md`.
© KrDev — https://kr-dev.site

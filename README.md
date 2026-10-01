# Control de Ciber 🖥️

Sistema gratuito para administrar cibercafés: controla tiempos por equipo, vende consumibles y papelería, monitorea pantallas en vivo y lleva la caja del día — todo desde un solo panel.

![VB.NET](https://img.shields.io/badge/VB.NET-WinForms-512BD4) ![Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4) ![SQLite](https://img.shields.io/badge/SQLite-003B57) ![License](https://img.shields.io/badge/license-MIT-green)

## ✨ Funciones

| Módulo | Qué hace |
|---|---|
| **Equipos** | Tarjetas con estado en vivo (ping), iniciar/añadir tiempo, bloquear/desbloquear, mensajes, apagar/reiniciar y bloqueo de Windows |
| **Punto de venta** | Buscador, ticket, métodos de pago y cobro con descuento de stock |
| **Productos** | Catálogo de consumibles y papelería (alta/baja/modificación) |
| **Historial y Caja** | Ventas por fecha con totales + resumen del día y sesiones |
| **Monitoreo en vivo** | Ve la pantalla de cada PC (~1 fps) con calidad seleccionable (640 → 1600 px) |
| **Red y equipos** | Registro de IPs y configuración remota de los clientes (cifrada) |
| **Cliente blindado** | Sin menús de configuración: pantalla de bloqueo, cronómetro de tiempo restante y `cliente.cfg` cifrado con AES-256 |

## 🖥️ Requisitos
- Windows 10/11, PCs en la misma red local, .NET Framework 4.8.

## 🚀 Instalación
Guía paso a paso (20-30 min): **[ComoInstalar.md](ComoInstalar.md)**

Resumen:
1. Copia `Servidor.exe` (+ DLLs) al mostrador y `Cliente.exe` a cada PC.
2. Registra las IPs en **Red y equipos** y abre el puerto UDP en el firewall.
3. Envía la configuración a los clientes desde **Red → Configurar cliente**.
4. Pulsa **VER**: `En vivo` en ~5 segundos.

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
MIT — úsalo, modifícalo y compártelo libremente.

''' <summary>Diálogo de términos de uso (texto espejo de TERMINOS.md).</summary>
Public Class TerminosForm
    Inherits Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Try
            Theme.StyleButton(btnCerrar, Theme.Dark)
        Catch
        End Try
        txtTerminos.Text = Texto()
    End Sub

    Public Shared Function Texto() As String
        Return "TÉRMINOS DE USO — CONTROL DE CIBER" & vbCrLf &
            "Desarrollador: KrDev · https://kr-dev.site" & vbCrLf & vbCrLf &
            "1. LICENCIA DE USO. Se concede el uso gratuito del software en los equipos del licenciatario, con fines personales o comerciales (por ejemplo, en su cibercafé)." & vbCrLf & vbCrLf &
            "2. PROHIBIDA LA VENTA. Queda prohibido vender, alquilar, sublicenciar o cobrar por el software en sí o por su instalación como producto. Regalarlo o compartirlo sin costo está permitido." & vbCrLf & vbCrLf &
            "3. MODIFICACIONES. Puede adaptarse para uso propio. Debe conservarse el aviso de autoría (sección Acerca de)." & vbCrLf & vbCrLf &
            "4. SIN GARANTÍA. El software se entrega ""tal cual"", sin garantías de ningún tipo. El autor no responde por pérdida de datos, interrupciones del servicio ni daños derivados de su uso o mal uso." & vbCrLf & vbCrLf &
            "5. SOPORTE. No incluye soporte obligatorio. Ayuda y actualizaciones en https://kr-dev.site/?app=ciber." & vbCrLf & vbCrLf &
            "6. ACEPTACIÓN. El uso del software implica la aceptación de estos términos." & vbCrLf & vbCrLf &
            "© KrDev. Todos los derechos reservados salvo lo aquí concedido."
    End Function
End Class

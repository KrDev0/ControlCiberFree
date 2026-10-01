Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Criptografía del cliente. La frase secreta vive solo en este código:
''' el archivo cliente.cfg es ilegible/editable fuera del programa.
''' </summary>
Public Module Crypto
    ' Clave embebida en el binario. Cambiarla invalida cfg anteriores.
    Private Const FRASE_SECRETA As String = "KrDev-Ciber-2026::cfg-local-protegida-v1"

    Private Function ClaveAES() As Byte()
        Using sha As SHA256 = SHA256.Create()
            Return sha.ComputeHash(Encoding.UTF8.GetBytes(FRASE_SECRETA))
        End Using
    End Function

    Public Function Cifrar(textoPlano As String) As String
        Using aes As Aes = Aes.Create()
            aes.Key = ClaveAES()
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7
            aes.GenerateIV()
            Using ms As New MemoryStream()
                ms.Write(aes.IV, 0, aes.IV.Length)
                Using cs As New CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)
                    Dim bin As Byte() = Encoding.UTF8.GetBytes(If(textoPlano, ""))
                    cs.Write(bin, 0, bin.Length)
                    cs.FlushFinalBlock()
                End Using
                Return Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
    End Function

    Public Function Descifrar(b64 As String) As String
        Try
            Dim raw As Byte() = Convert.FromBase64String(b64)
            If raw.Length < 17 Then Return Nothing
            Using aes As Aes = Aes.Create()
                aes.Key = ClaveAES()
                aes.Mode = CipherMode.CBC
                aes.Padding = PaddingMode.PKCS7
                Dim iv(15) As Byte
                Array.Copy(raw, 0, iv, 0, 16)
                aes.IV = iv
                Using ms As New MemoryStream(raw, 16, raw.Length - 16)
                    Using cs As New CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read)
                        Using sr As New StreamReader(cs, Encoding.UTF8)
                            Return sr.ReadToEnd()
                        End Using
                    End Using
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Public Function HashPass(plain As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim b As Byte() = sha.ComputeHash(Encoding.UTF8.GetBytes(If(plain, "")))
            Return BitConverter.ToString(b).Replace("-", "").ToLowerInvariant()
        End Using
    End Function

    Public Function PassOk(input As String, stored As String) As Boolean
        If String.IsNullOrEmpty(stored) Then Return False
        If input = stored Then Return True ' compat con valor antiguo en claro
        Return HashPass(input) = stored.ToLowerInvariant()
    End Function
End Module

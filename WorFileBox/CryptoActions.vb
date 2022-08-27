Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Security.Principal
Imports System.Security.AccessControl
Public Class CryptoActions
    Public DefaultCryptoKey As String = "Pw3jakfBIVYydqFZhjyQLwaJTWGPn9" 'Default Cryptography Key
    Public Shared des As New TripleDESCryptoServiceProvider
    Public Shared hashmd5 As New MD5CryptoServiceProvider

    Private Sub CryptoActions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

#Region "Crypto"

    Sub CreatePrivateKey()
        Try
            Dim obj As New Random()
            Dim posibles As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
            Dim longitud As Integer = posibles.Length
            Dim letra As Char
            Dim longitudnuevacadena As Integer = 30
            Dim nuevacadena As String = Nothing
            For i As Integer = 0 To longitudnuevacadena - 1
                letra = posibles(obj.[Next](longitud))
                nuevacadena += letra.ToString()
            Next
            Debugger.CryptoKey = nuevacadena
            FileBox.CryptoPassword = Debugger.CryptoKey
            Debugger.SaveData()
            Console.WriteLine("Llave criptografica privada: " & nuevacadena)
        Catch ex As Exception
            Debugger.CryptoKey = DefaultCryptoKey
            FileBox.CryptoPassword = Debugger.CryptoKey
            Debugger.SaveData()
            Console.WriteLine("[CryptoActions@CreatePrivateKey]Error: " & ex.Message)
        End Try
    End Sub

    Function Encriptar(ByVal texto As String) As String
        If Trim(texto) = "" Then
            Encriptar = ""
        Else
            des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(DefaultCryptoKey))
            des.Mode = CipherMode.ECB
            Dim encrypt As ICryptoTransform = DES.CreateEncryptor()
            Dim buff() As Byte = UnicodeEncoding.ASCII.GetBytes(texto)
            Encriptar = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length))
        End If
        Return Encriptar
    End Function

    Function Desencriptar(ByVal texto As String) As String
        If Trim(texto) = "" Then
            Desencriptar = ""
        Else
            des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(DefaultCryptoKey))
            des.Mode = CipherMode.ECB
            Dim desencrypta As ICryptoTransform = DES.CreateDecryptor()
            Dim buff() As Byte = Convert.FromBase64String(texto)
            Desencriptar = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length))
        End If
        Return Desencriptar
    End Function

    Sub CallEncrypt(ByVal FileIN As String, ByVal FileOUT As String)
        Try
            Dim buffer As Byte()
            Using fs As New FileStream(FileIN, FileMode.Open, FileAccess.Read)
                Using ms As New MemoryStream()
                    Encrypt(fs, ms, Debugger.CryptoKey)
                    buffer = ms.ToArray()
                End Using
            End Using
            Using fs As New FileStream(FileOUT, FileMode.CreateNew, FileAccess.Write)
                fs.Write(buffer, 0, buffer.Length)
            End Using
        Catch ex As Exception
            Console.WriteLine("[CryptoActions@CallEncrypt]Error: " & ex.Message)
        End Try
    End Sub
    Sub CallDecrypt(ByVal FileIN As String, ByVal FileOUT As String)
        Try
            Dim buffer As Byte() = Nothing
            Using fs As New FileStream(FileIN, FileMode.Open, FileAccess.Read)
                Using ms As New MemoryStream()
                    Decrypt(fs, ms, Debugger.CryptoKey)
                    buffer = ms.ToArray()
                End Using
            End Using
            Using fs As New FileStream(FileOUT, FileMode.CreateNew, FileAccess.Write)
                fs.Write(buffer, 0, buffer.Length)
            End Using
        Catch ex As Exception
            Console.WriteLine("[CryptoActions@CallDecrypt]Error: " & ex.Message)
        End Try
    End Sub

    Friend Shared Sub Decrypt(inStream As Stream, outStream As Stream, pwd As String)
        Try
            Dim aes As New AesCryptoServiceProvider()
            aes.Mode = CipherMode.CFB
            aes.Key() = GetDeriveBytes(pwd, 32)
            aes.IV = GetDeriveBytes(pwd, 16)
            Dim stream As New CryptoStream(inStream, aes.CreateDecryptor(), CryptoStreamMode.Read)
            Dim length As Integer = 2048
            Dim buffer As Byte() = New Byte(length - 1) {}
            Try
                Dim i As Integer = stream.Read(buffer, 0, length)
                Do While (i > 0)
                    outStream.Write(buffer, 0, i)
                    i = stream.Read(buffer, 0, length)
                Loop
            Finally
                aes.Dispose()
                buffer = Nothing
            End Try
        Catch ex As Exception
            Console.WriteLine("[CryptoActions@Decrypt]Error: " & ex.Message)
        End Try
    End Sub
    Friend Shared Sub Encrypt(inStream As Stream, outStream As Stream, pwd As String)
        Try
            Dim aes As New AesCryptoServiceProvider()
            aes.Mode = CipherMode.CFB
            aes.Key() = GetDeriveBytes(pwd, 32)
            aes.IV = GetDeriveBytes(pwd, 16)
            Dim stream As New CryptoStream(outStream, aes.CreateEncryptor(), CryptoStreamMode.Write)
            Dim length As Integer = 2048
            Dim buffer As Byte() = New Byte(length - 1) {}
            Try
                Dim i As Integer = inStream.Read(buffer, 0, length)
                Do While (i > 0)
                    stream.Write(buffer, 0, i)
                    i = inStream.Read(buffer, 0, length)
                Loop
            Finally
                stream.FlushFinalBlock()
                aes.Dispose()
                buffer = Nothing
            End Try
        Catch ex As Exception
            Console.WriteLine("[CryptoActions@Encrypt]Error: " & ex.Message)
        End Try
    End Sub
    Friend Shared Function GetDeriveBytes(password As String, size As Integer) As Byte()
        If ((String.IsNullOrWhiteSpace(password)) OrElse (password.Length < 8)) Then
            MsgBox("Error en el Modulo 'GetDeriveBytes'" & vbCrLf & "La llave criptografica debe tener mas de 8 caracteres", MsgBoxStyle.Critical, "SystemTrail Modules")
        End If
        If ((size < 1) OrElse (size > 128)) Then
            MsgBox("Error en el Modulo 'GetDeriveBytes'" & vbCrLf & "El tamaño tiene que estar comprendido entre 1 y 128.", MsgBoxStyle.Critical, "SystemTrail Modules")
        End If
        Dim pwd As Byte() = UTF8Encoding.UTF8.GetBytes(password)
        Dim salt As Byte() = UTF8Encoding.UTF8.GetBytes(Convert.ToBase64String(pwd))
        Using bytes As New Rfc2898DeriveBytes(pwd, salt, 1000)
            ' Devolver la clave pseudoaletoria.
            Return bytes.GetBytes(size)
        End Using
    End Function
#End Region

#Region "SafeFolder"
    Sub LockDirectory()
        Try
            Dim attribute As System.IO.FileAttributes = FileAttributes.Hidden
            File.SetAttributes(FileBox.DIRCommons, attribute)
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Worcome Security")
            Console.WriteLine("[CryptoActions@LockDirectory:HideFolder]Error: " & ex.Message)
        End Try
        Try
            Dim ACCESO As FileSystemSecurity = File.GetAccessControl(FileBox.DIRCommons)
            Dim USUARIOS As New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing)
            ACCESO.AddAccessRule(New FileSystemAccessRule(USUARIOS, FileSystemRights.FullControl, AccessControlType.Deny))
            File.SetAccessControl(FileBox.DIRCommons, ACCESO)
            Console.WriteLine("[CryptoActions@LockDirectory:Lock]Directorio Bloqueado: " & FileBox.DIRCommons)
        Catch ex As Exception
            Console.WriteLine("[CryptoActions@LockDirectory:Lock]Error: " & ex.Message)
        End Try
    End Sub

    Sub UnLockDirectory()
        Try
            Dim attribute As System.IO.FileAttributes = FileAttributes.Normal
            'File.SetAttributes(DIRCommons, attribute)
        Catch ex As Exception
            Console.WriteLine("[CryptoActions@LockDirectory:ShowFolder]Error: " & ex.Message)
        End Try
        Try
            Dim ACCESO As FileSystemSecurity = File.GetAccessControl(FileBox.DIRCommons)
            Dim USUARIOS As New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing)
            ACCESO.RemoveAccessRule(New FileSystemAccessRule(USUARIOS, FileSystemRights.FullControl, AccessControlType.Deny))
            File.SetAccessControl(FileBox.DIRCommons, ACCESO)
            Console.WriteLine("[CryptoActions@LockDirectory:Unlock]Directorio Desbloqueado: " & FileBox.DIRCommons)
        Catch ex As Exception
            Console.WriteLine("[CryptoActions@UnLockDirectory:Unlock]Error: " & ex.Message)
        End Try
    End Sub
#End Region
End Class
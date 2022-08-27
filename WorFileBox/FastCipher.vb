Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Win32
Public Class FastCipher
    Public StartedFromDebugger As Boolean = False
    Dim MemoryList As New ArrayList
    Dim MemoryListCounter As Integer = -1

    Private Sub FastCipher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreatePrivateKey()
        If My.Settings.ContextMenuShellWindows = True Then
            CheckBox2.CheckState = CheckState.Checked
        End If
    End Sub

    Sub IndexFileToListBox()
        Try
            ListBox1.Items.Clear()
            For Each Item As String In MemoryList
                ListBox1.Items.Add(Item)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lblCreateKey_Click(sender As Object, e As EventArgs) Handles Label1.Click
        CreatePrivateKey()
    End Sub

    Private Sub btnCipher_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("¿Seguro que desea Cifrar los ficheros en la Lista?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            If MemoryList.Count = 0 Then
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("No hay arhivos para encriptar", MsgBoxStyle.Exclamation, "Worcome Securiry")
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("No files to encrypt", MsgBoxStyle.Exclamation, "Worcome Securiry")
                End If
            Else
                Encrypt()
            End If
        End If
    End Sub

    Private Sub btnDecipher_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("¿Seguro que desea Descifrar los ficheros en la Lista?" & vbCrLf & "Si los ficheros en la Lista no tienen el .ENC no son para Descifrar.", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            If MemoryList.Count = 0 Then
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("No hay arhivos para desencriptar", MsgBoxStyle.Exclamation, "Worcome Securiry")
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("No files to dencrypt", MsgBoxStyle.Exclamation, "Worcome Securiry")
                End If
            Else
                Decrypt()
            End If
        End If
    End Sub

    Sub Encrypt()
        Try
            For Each Fichero As String In MemoryList
                Dim NameFile As String = Nothing
                Dim DirectoryFile As String = IO.Path.GetDirectoryName(Fichero.ToString)
                NameFile = Fichero.ToString
                NameFile = NameFile.Remove(0, NameFile.LastIndexOf("\") + 1)
                CallEncrypt(Fichero, DirectoryFile & "\" & NameFile & ".enc")
                'RichTextBox1.AppendText("Fichero encriptado: " & NameFile & vbCrLf)
                For Each Archivo As String In My.Computer.FileSystem.GetFiles(DirectoryFile)
                    Dim tmpString As String = Nothing
                    tmpString = Archivo.ToString
                    tmpString = tmpString.Remove(0, tmpString.LastIndexOf("\") + 1)
                    If NameFile = tmpString Then
                        My.Computer.FileSystem.DeleteFile(DirectoryFile & "\" & tmpString)
                    End If
                Next
            Next
            MemoryList.Clear()
            MemoryListCounter = -1
            IndexFileToListBox()
            'RichTextBox1.ScrollToCaret()
        Catch ex As Exception
            Console.WriteLine("[FastCipher@Encrypt]Error: " & ex.Message)
        End Try
    End Sub
    Sub Decrypt()
        Try
            For Each Fichero As String In MemoryList
                Dim NameFile As String = Nothing
                Dim DirectoryFile As String = IO.Path.GetDirectoryName(Fichero.ToString)
                NameFile = Fichero.ToString
                NameFile = NameFile.Remove(0, NameFile.LastIndexOf("\") + 1)
                NameFile = NameFile.Replace(".enc", "")
                CallDecrypt(Fichero, DirectoryFile & "\" & NameFile)
                'RichTextBox1.AppendText("Fichero desencriptado: " & NameFile & vbCrLf)
                For Each Archivo As String In My.Computer.FileSystem.GetFiles(DirectoryFile)
                    Dim tmpString As String = Nothing
                    tmpString = Archivo.ToString
                    tmpString = tmpString.Remove(0, tmpString.LastIndexOf("\") + 1)
                    If NameFile = tmpString Then
                        My.Computer.FileSystem.DeleteFile(Fichero)
                    End If
                Next
            Next
            MemoryList.Clear()
            MemoryListCounter = -1
            'RichTextBox1.ScrollToCaret()
            IndexFileToListBox()
        Catch ex As Exception
            Console.WriteLine("[FastCipher@Decrypt]Error")
        End Try
    End Sub

    Private Sub Panel1_DragDrop(sender As Object, e As DragEventArgs) Handles Panel1.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim strRutaArchivos() As String
                Dim i As Integer
                strRutaArchivos = e.Data.GetData(DataFormats.FileDrop)
                Dim StringPassed As String
                For i = 0 To strRutaArchivos.Length - 1
                    StringPassed = strRutaArchivos(i).ToString
                    MemoryList.Add(StringPassed)
                    'RichTextBox1.AppendText("Item agregado: " & strRutaArchivos(i).ToString & vbCrLf)
                Next
                IndexFileToListBox()
            End If
        Catch ex As Exception
            Console.WriteLine("[FastCipher@Panel1_DragDrop]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub Panel1_DragEnter(sender As Object, e As DragEventArgs) Handles Panel1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Sub OpenFile(ByVal FileDIR As String)
        Try
            MemoryList.Add(FileDIR)
            'RichTextBox1.AppendText("Item agregado: " & FileDIR.ToString & vbCrLf)
            MsgBox("Se cargo '" & Path.GetFileName(FileDIR) & "' a FastCipher!")
            IndexFileToListBox()
        Catch ex As Exception
            Console.WriteLine("[FastCipher@OpenFile]Error:" & ex.Message)
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If TextBox1.PasswordChar = "●" Then
            TextBox1.PasswordChar = Nothing
        Else
            TextBox1.PasswordChar = "●"
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim menuCommand As String = String.Format("""{0}"" -FastCipher>%L", Application.ExecutablePath)
        If CheckBox2.CheckState = CheckState.Checked Then
            My.Settings.ContextMenuShellWindows = True
            Register("*", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("txtfile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("docxfile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("jpegfile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("pngfile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("mp3file", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("mpegfile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("AVIFile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("wmafile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("WMVFile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("giffile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("pdffile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("pptxfile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("encfile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("enc", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("decfile", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
            Register("dec", "FileBoxFastCipherShell", "FileBox FastCipher", menuCommand)
        Else
            My.Settings.ContextMenuShellWindows = False
            Unregister("*", "FileBoxFastCipherShell")
            Unregister("txtfile", "FileBoxFastCipherShell")
            Unregister("docxfile", "FileBoxFastCipherShell")
            Unregister("jpegfile", "FileBoxFastCipherShell")
            Unregister("pngfile", "FileBoxFastCipherShell")
            Unregister("mp3file", "FileBoxFastCipherShell")
            Unregister("mpegfile", "FileBoxFastCipherShell")
            Unregister("AVIFile", "FileBoxFastCipherShell")
            Unregister("wmafile", "FileBoxFastCipherShell")
            Unregister("WMVFile", "FileBoxFastCipherShell")
            Unregister("giffile", "FileBoxFastCipherShell")
            Unregister("pdffile", "FileBoxFastCipherShell")
            Unregister("pptxfile", "FileBoxFastCipherShell")
            Unregister("decfile", "FileBoxFastCipherShell")
            Unregister("dec", "FileBoxFastCipherShell")
            Unregister("encfile", "FileBoxFastCipherShell")
            Unregister("enc", "FileBoxFastCipherShell")
        End If
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Public Shared Sub Register(ByVal fileType As String, ByVal shellKeyName As String, ByVal menuText As String, ByVal menuCommand As String)
        Try
            Dim regPath As String = String.Format("{0}\shell\{1}", fileType, shellKeyName)
            Dim key As RegistryKey = Registry.ClassesRoot.CreateSubKey(regPath) 'Texto del Context Menu (Title)
            key.SetValue(Nothing, menuText)
            Dim key2 As RegistryKey = Registry.ClassesRoot.CreateSubKey(String.Format("{0}\command", regPath)) 'Ejecutar al abrir
            key2.SetValue(Nothing, menuCommand)
            Dim key3 As RegistryKey = Registry.ClassesRoot.CreateSubKey(String.Format("{0}", regPath)) 'Icono del Context Menu (Icon)
            key3.SetValue("Icon", String.Format("""{0}"",0", Application.ExecutablePath))
        Catch ex As Exception
            Console.WriteLine("[FastCipher@Register(MAIN)]Error:" & ex.Message)
        End Try
    End Sub

    Public Shared Sub Unregister(ByVal fileType As String, ByVal shellKeyName As String)
        Try
            Debug.Assert((Not String.IsNullOrEmpty(fileType) _
                        AndAlso Not String.IsNullOrEmpty(shellKeyName)))
            Dim regPath As String = String.Format("{0}\shell\{1}", fileType, shellKeyName)
            Registry.ClassesRoot.DeleteSubKeyTree(regPath)
        Catch ex As Exception
            Console.WriteLine("[FastCipher@Unregister]Error:" & ex.Message)
        End Try
    End Sub

#Region "CryptoActions"
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
            TextBox1.Text = nuevacadena
        Catch ex As Exception
            Console.WriteLine("[FastCipher@CreatePrivateKey]Error: " & ex.Message)
        End Try
    End Sub

    Sub CallEncrypt(ByVal FileIN As String, ByVal FileOUT As String)
        Try
            Dim buffer As Byte()
            Using fs As New FileStream(FileIN, FileMode.Open, FileAccess.Read)
                Using ms As New MemoryStream()
                    Encrypt(fs, ms, TextBox1.Text)
                    buffer = ms.ToArray()
                End Using
            End Using
            Using fs As New FileStream(FileOUT, FileMode.CreateNew, FileAccess.Write)
                fs.Write(buffer, 0, buffer.Length)
            End Using
        Catch ex As Exception
            Console.WriteLine("[FastCipher@CallEncrypt]Error: " & ex.Message)
        End Try
    End Sub
    Sub CallDecrypt(ByVal FileIN As String, ByVal FileOUT As String)
        Try
            Dim buffer As Byte() = Nothing
            Using fs As New FileStream(FileIN, FileMode.Open, FileAccess.Read)
                Using ms As New MemoryStream()
                    Decrypt(fs, ms, TextBox1.Text)
                    buffer = ms.ToArray()
                End Using
            End Using
            Using fs As New FileStream(FileOUT, FileMode.CreateNew, FileAccess.Write)
                fs.Write(buffer, 0, buffer.Length)
            End Using
        Catch ex As Exception
            Console.WriteLine("[FastCipher@CallDecrypt]Error: " & ex.Message)
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
            Console.WriteLine("[FastCipher@Decrypt]Error: " & ex.Message)
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
            Console.WriteLine("[FastCipher@Encrypt]Error: " & ex.Message)
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

    Private Sub FastCipher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("¿Seguro que desea salir?" & vbCrLf & "Si no guarda la CryptoKey no podra descifrar ningun fichero cifrado. Al salir la llave sera borrara y al volver se generara una nueva.", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            If StartedFromDebugger = True Then
                End
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        MsgBox("1/11" & vbCrLf & "Agrege un fichero con la funcion Arrastrar y Soltar dentro del panel gris", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("2/11" & vbCrLf & "Al agregar un fichero, puede agregar mas o puede clicar en Cifrar", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("3/11" & vbCrLf & "CIFRAR: Todos los ficheros en la lista seran cifrados con la llave que se muestra arriba", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("4/11" & vbCrLf & "CIFRAR: Su extencion final es .ENC (No quite el .ENC, si lo quita asegurese de volverlo a poner al Descifrar)", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("5/11" & vbCrLf & "Si arrastro y solto un fichero .ENC es porque este es solo para Descifrarlo. De precionar Cifrar podria perder el fichero.", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("6/11" & vbCrLf & "DESCIFRAR: Todos los ficheros que estan en la lista seran descifrados y se les quitara automaticamente el .ENC por su extencion original.", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("7/11" & vbCrLf & "DESCIFRAR: Si descifra un fichero sin el .ENC es posible que pierda el fichero.", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("8/11" & vbCrLf & "DESCIFRAR: El descifrado tiene lugar con la llave que se utilizo para cifrar.", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("9/11" & vbCrLf & "AVISO: Al cifrar un fichero copie su CryptoKey. Al volver a iniciar FastCipher esta sera removida y reemplazada por una nueva.", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("10/11" & vbCrLf & "AVISO: Sea cuidadoso, de cometer un error podria perder el o los ficheros.", MsgBoxStyle.Exclamation, "Worcome Security")
        MsgBox("11/11" & vbCrLf & "RECOMENDACION: Descarge FileShield para cifrar sus archivos en una Unidad Portatil como USB o poder protener varias carpetas dentro de un mismo PC.", MsgBoxStyle.Exclamation, "Worcome Security")
    End Sub
End Class
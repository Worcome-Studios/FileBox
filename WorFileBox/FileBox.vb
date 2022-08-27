Public Class FileBox
    Public DIRCommons As String = "C:\Users\" & Environment.UserName & "\FileBoxData"
    Public DIREncrypted As String = DIRCommons & "\EncryptedFiles"
    Public DIRDecrypted As String = DIRCommons & "\DecryptedFiles"
    Public CryptoPassword As String
    Public MemoryListDEN As New ArrayList
    Public MemoryListENC As New ArrayList
    Public MemoryListNAME As New ArrayList
    Public ContadorDEN As Integer = -1
    Public ContadorENC As Integer = -1
    Public ContadorNAME As Integer = -1

    Private Sub FileBox_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            MemoryNameActions("CreateList")
            MemoryListDENActions("OnClose")
            OnCloseCallToEncrypt()
            Threading.Thread.Sleep(150)
            Debugger.Close()
        Catch ex As Exception
            Console.WriteLine("[FileBox@FileBox_FormClosing:CallToEncrypt]Error: " & ex.Message)
        End Try
    End Sub

    Private Sub FileBox_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists(DIRCommons) = False Then
            My.Computer.FileSystem.CreateDirectory(DIRCommons)
        End If
        If My.Computer.FileSystem.DirectoryExists(DIREncrypted) = False Then
            My.Computer.FileSystem.CreateDirectory(DIREncrypted)
        End If
        If My.Computer.FileSystem.DirectoryExists(DIRDecrypted) = False Then
            My.Computer.FileSystem.CreateDirectory(DIRDecrypted)
        End If
        CryptoActions.UnLockDirectory()
        MemoryListDENActions("OnLoad")
        CommonStart()
        OnLoadCallToDecrypt()
    End Sub

#Region "Subs"
    Sub CommonStart()
        Try
            If Debugger.CryptoKey = Nothing Then
                If My.Settings.Espanglish = "Español" Then
                    Dim TextBoxVirtual = InputBox("Escriba una Llave Criptografica para comenzar a usar FileBox" & vbCrLf & "Si tiene una escribala y de click en 'Aceptar', si no es asi, de click en 'Cancelar' para que nosotros le demos una", "Worcome Security")
                    If TextBoxVirtual = Nothing Then
                        If MessageBox.Show("¿Quiere que creemos una Llave Criptografica privada de forma Automatica?" & vbCrLf & "Sera lo mas aleatoria posible", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            'Crea una llave aleatoria
                            CryptoActions.CreatePrivateKey()
                            CryptoPassword = Debugger.CryptoKey
                            My.Settings.Save()
                            My.Settings.Reload()
                        Else
                            MsgBox("Debe indicar una Llave Criptografica para poder usar FileBox" & vbCrLf & "Si no sabe, deje que nosotros le demos una!" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                            Me.Close()
                        End If
                        CommonStart()
                    Else
                        CryptoPassword = TextBoxVirtual
                        Debugger.CryptoKey = TextBoxVirtual
                        Debugger.SaveData()
                        My.Settings.Save()
                        My.Settings.Reload()
                    End If
                ElseIf My.Settings.Espanglish = "English" Then
                    Dim TextBoxVirtual = InputBox("Write a Cryptographic Key to start using FileBox" & vbCrLf & "If you have a scribe and click on 'Accept', if not, click on 'Cancel' for give you one", "Worcome Security")
                    If TextBoxVirtual = Nothing Then
                        If MessageBox.Show("Do you want us to create a private Cryptographic Key automatically?" & vbCrLf & "It will be as random as possible", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            'Crea una llave aleatoria
                            CryptoActions.CreatePrivateKey()
                            CryptoPassword = Debugger.CryptoKey
                            Debugger.SaveData()
                            My.Settings.Save()
                            My.Settings.Reload()
                        Else
                            MsgBox("It must indicate a Cryptographic Key to be able to use FileBox" & vbCrLf & "If you do not know, let us give you one!" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                            Me.Close()
                        End If
                        CommonStart()
                    Else
                        CryptoPassword = TextBoxVirtual
                        Debugger.CryptoKey = TextBoxVirtual
                        Debugger.SaveData()
                        My.Settings.Save()
                        My.Settings.Reload()
                    End If
                End If
            Else
                CryptoPassword = Debugger.CryptoKey
            End If
            If My.Computer.FileSystem.DirectoryExists(DIRCommons) = False Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons)
            End If
            If My.Computer.FileSystem.DirectoryExists(DIREncrypted) = False Then
                My.Computer.FileSystem.CreateDirectory(DIREncrypted)
            End If
            If My.Computer.FileSystem.DirectoryExists(DIRDecrypted) = False Then
                My.Computer.FileSystem.CreateDirectory(DIRDecrypted)
            End If
            Try
                MemoryNameActions("ReadItems")
            Catch ex As Exception
                Console.WriteLine("[FileBox@CommonStart:AddFileNames]Error: " & ex.Message)
            End Try
        Catch ex As Exception
            Console.WriteLine("[FileBox@CommonStart]Error: " & ex.Message)
        End Try
    End Sub
    Sub MemoryListDENActions(ByVal Action As String)
        Try
            If Action = "OnLoad" Then
                MemoryListDEN.Clear()
                For Each Linea As String In System.IO.File.ReadLines(DIRCommons & "\FileList.WorCODE")
                    MemoryListDEN.Add(Linea)
                Next
            ElseIf Action = "OnClose" Then
                If My.Computer.FileSystem.FileExists(DIRCommons & "\FileList.WorCODE") = True Then
                    My.Computer.FileSystem.DeleteFile(DIRCommons & "\FileList.WorCODE")
                End If
                Dim StringPassed As String = Nothing
                For Each Item As Object In MemoryListDEN
                    StringPassed = StringPassed & Item & vbCrLf
                Next
                My.Computer.FileSystem.WriteAllText(DIRCommons & "\FileList.WorCODE", StringPassed, False)
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@MemoryListActions]Error: " & ex.Message)
        End Try
    End Sub
    Sub MemoryNameActions(ByVal Action As String)
        Try
            If Action = "CreateList" Then
                If My.Computer.FileSystem.FileExists(DIRCommons & "\FileNames.WorCODE") = True Then
                    My.Computer.FileSystem.DeleteFile(DIRCommons & "\FileNames.WorCODE")
                End If
                MemoryListNAME.Clear()
                For Each Fichero As String In My.Computer.FileSystem.GetFiles(DIRDecrypted)
                    Fichero = Fichero.Remove(0, Fichero.LastIndexOf("\") + 1)
                    MemoryListNAME.Add(Fichero)
                Next
                Dim StringPassed As String = Nothing
                For Each Item As String In My.Computer.FileSystem.GetFiles(DIRDecrypted)
                    Item = Item.Remove(0, Item.LastIndexOf("\") + 1)
                    StringPassed = StringPassed & Item & vbCrLf
                Next
                My.Computer.FileSystem.WriteAllText(DIRCommons & "\FileNames.WorCODE", StringPassed, False)
            ElseIf Action = "ReadItems" Then
                MemoryListNAME.Clear()
                For Each Linea As String In System.IO.File.ReadLines(DIRCommons & "\FileNames.WorCODE")
                    MemoryListNAME.Add(Linea)
                Next
            ElseIf Action = "Refresh" Then
                MemoryListNAME.Clear()
                MemoryNameActions("CreateList")
                MemoryNameActions("ReadItems")
            End If
            MemoryListNAME.Remove("")
        Catch ex As Exception
            Console.WriteLine("[FileBox@MemoryNameActions]Error: " & ex.Message)
        End Try
    End Sub
    Sub IndexearArchivos()
        Try
            LB_ListBox1.Items.Clear()
            MemoryListDEN.Clear()
            For Each Linea As String In System.IO.File.ReadLines(DIRCommons & "\FileList.WorCODE")
                MemoryListDEN.Add(Linea)
                Linea = Linea.Remove(0, Linea.LastIndexOf("\") + 1)
                LB_ListBox1.Items.Add(Linea)
            Next
        Catch ex As Exception
            Console.WriteLine("[FileBox@IndexearArchivos]Error: " & ex.Message)
        End Try
    End Sub
    Sub OnLoadCallToDecrypt()
        Try
            Try
                ContadorNAME = 0
                For Each Fichero As String In My.Computer.FileSystem.GetFiles(DIREncrypted)
                    CryptoActions.CallDecrypt(Fichero, DIRDecrypted & "\" & MemoryListNAME(ContadorNAME))
                    ContadorNAME = ContadorNAME + 1
                Next
            Catch ex As Exception
                Console.WriteLine("[FileBox@OnLoadCallToDecrypt:CallToDecrypt]Error: " & ex.Message)
            End Try
            IndexearArchivos()
            Try
                For Each Fichero As String In My.Computer.FileSystem.GetFiles(DIREncrypted)
                    My.Computer.FileSystem.DeleteFile(Fichero)
                Next
            Catch ex As Exception
                Console.WriteLine("[FileBox@OnLoadCallToDecrypt:DeleteEncryptFiles]Error: " & ex.Message)
            End Try
        Catch ex As Exception
            Console.WriteLine("[FileBox@OnLoadCallToDecrypt]Error: " & ex.Message)
        End Try
    End Sub
    Sub OnCloseCallToEncrypt()
        Try
            Try
                ContadorNAME = 0
                For Each Fichero As String In My.Computer.FileSystem.GetFiles(DIRDecrypted)
                    CryptoActions.CallEncrypt(Fichero, DIREncrypted & "\" & MemoryListNAME(ContadorNAME))
                    ContadorNAME = ContadorNAME + 1
                Next
            Catch ex As Exception
                Console.WriteLine("[FileBox@OnCloseCallToEncrypt:CallToEncrypt]Error: " & ex.Message)
            End Try
            IndexearArchivos()
            Try
                For Each Fichero As String In My.Computer.FileSystem.GetFiles(DIRDecrypted)
                    My.Computer.FileSystem.DeleteFile(Fichero)
                Next
            Catch ex As Exception
                Console.WriteLine("[FileBox@OnCloseCallToEncrypt:DeleteDecryptFiles]Error: " & ex.Message)
            End Try
            CryptoActions.LockDirectory()
        Catch ex As Exception
            Console.WriteLine("[FileBox@OnCloseCallToEncrypt]Error: " & ex.Message)
        End Try
    End Sub
#End Region

#Region "Controles"
    Private Sub LB_ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LB_ListBox1.SelectedIndexChanged
        Try
            If LB_ListBox1.SelectedItem = "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" Or LB_ListBox1.SelectedItem = Nothing Then
                'no hace nada porque hay un Separador seleccionado o absolutamente nada
                FastColoredTextBox1.Clear()
                GroupBox1.Visible = False
                If My.Settings.Espanglish = "Español" Then
                    GroupBox1.Text = "Ver Archivo"
                ElseIf My.Settings.Espanglish = "English" Then
                    GroupBox1.Text = "View File"
                End If
            Else
                GroupBox1.Visible = True
                ContadorDEN = LB_ListBox1.SelectedIndex
                FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
                If My.Settings.Espanglish = "Español" Then
                    GroupBox1.Text = "Archivo Abierto: " & LB_ListBox1.SelectedItem
                ElseIf My.Settings.Espanglish = "English" Then
                    GroupBox1.Text = "Open File: " & LB_ListBox1.SelectedItem
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@LB_ListBox1_SelectedIndexChanged]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub LB_ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LB_ListBox1.MouseDoubleClick
        Try
            If LB_ListBox1.SelectedItem = "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" Or LB_ListBox1.SelectedItem = Nothing Then
                'no hace nada porque hay un Separador seleccionado o absolutamente nada
            Else
                GroupBox1.Visible = True
                ContadorDEN = LB_ListBox1.SelectedIndex
                FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
                If My.Settings.Espanglish = "Español" Then
                    GroupBox1.Text = "Archivo Abierto: " & LB_ListBox1.SelectedItem
                ElseIf My.Settings.Espanglish = "English" Then
                    GroupBox1.Text = "Open File: " & LB_ListBox1.SelectedItem
                End If
                Process.Start(MemoryListDEN(ContadorDEN))
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@LB_ListBox1_MouseDoubleClick]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub OpenFile_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            GroupBox1.Visible = True
            ContadorDEN = LB_ListBox1.SelectedIndex
            FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
            If My.Settings.Espanglish = "Español" Then
                GroupBox1.Text = "Archivo Abierto: " & LB_ListBox1.SelectedItem
            ElseIf My.Settings.Espanglish = "English" Then
                GroupBox1.Text = "Open File: " & LB_ListBox1.SelectedItem
            End If
            Process.Start(MemoryListDEN(ContadorDEN))
        Catch ex As Exception
            Console.WriteLine("[FileBox@LB_ListBox1_MouseDoubleClick]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub BTN_NewFile_Click(sender As Object, e As EventArgs) Handles BTN_NewFile.Click
        'Crear un nuevo archivo para escribir
        Try
            If My.Settings.Espanglish = "Español" Then
                Dim TextBoxVirtual = InputBox("Ingrese el nombre del nuevo archivo", "Worcome Security")
                If TextBoxVirtual = Nothing Then
                Else
                    My.Computer.FileSystem.WriteAllText(DIRDecrypted & "\" & TextBoxVirtual, FastColoredTextBox1.Text, False)
                    MemoryListDEN.Add(DIRDecrypted & "\" & TextBoxVirtual)
                    MemoryListDENActions("OnClose")
                    IndexearArchivos()
                    MemoryNameActions("CreateList")
                    LB_ListBox1.SelectedItem = TextBoxVirtual
                    ContadorDEN = LB_ListBox1.SelectedIndex
                    FastColoredTextBox1.Clear()
                    GroupBox1.Text = "Archivo Abierto: " & LB_ListBox1.SelectedItem
                End If
            ElseIf My.Settings.Espanglish = "English" Then
                Dim TextBoxVirtual = InputBox("Enter the name of the new file", "Worcome Security")
                If TextBoxVirtual = Nothing Then
                Else
                    My.Computer.FileSystem.WriteAllText(DIRDecrypted & "\" & TextBoxVirtual, FastColoredTextBox1.Text, False)
                    MemoryListDEN.Add(DIRDecrypted & "\" & TextBoxVirtual)
                    MemoryListDENActions("OnClose")
                    IndexearArchivos()
                    MemoryNameActions("CreateList")
                    LB_ListBox1.SelectedItem = TextBoxVirtual
                    ContadorDEN = LB_ListBox1.SelectedIndex
                    FastColoredTextBox1.Clear()
                    GroupBox1.Text = "Open File: " & LB_ListBox1.SelectedItem
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@BTN_NewFile_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub BTN_RemoveFile_Click(sender As Object, e As EventArgs) Handles BTN_RemoveFile.Click
        'Eliminar el archivo seleccionado
        Try
            If MessageBox.Show("¿Want to delete this file?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                If LB_ListBox1.SelectedItem = "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" Then
                    LB_ListBox1.Items.RemoveAt(LB_ListBox1.SelectedIndex)
                Else
                    My.Computer.FileSystem.DeleteFile(MemoryListDEN(ContadorDEN))
                    MemoryListDEN.RemoveAt(ContadorDEN)
                    LB_ListBox1.Items.Remove(LB_ListBox1.SelectedItem)
                    FastColoredTextBox1.Clear()
                    GroupBox1.Visible = False
                    If My.Settings.Espanglish = "Español" Then
                        GroupBox1.Text = "Ver archivo"
                    ElseIf My.Settings.Espanglish = "English" Then
                        GroupBox1.Text = "View file"
                    End If
                    ContadorDEN = -1
                    MemoryListDENActions("OnClose")
                    IndexearArchivos()
                    MemoryNameActions("CreateList")
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@BTN_RemoveFile_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub BTN_PNL_SaveChanges_Click(sender As Object, e As EventArgs) Handles BTN_PNL_SaveChanges.Click
        'Guardar los cambios en el archivo
        Try
            ContadorDEN = LB_ListBox1.SelectedIndex
            If My.Computer.FileSystem.FileExists(MemoryListDEN(ContadorDEN)) = True Then
                My.Computer.FileSystem.DeleteFile(MemoryListDEN(ContadorDEN))
            End If
            My.Computer.FileSystem.WriteAllText(MemoryListDEN(ContadorDEN), FastColoredTextBox1.Text, False)
        Catch ex As Exception
            Console.WriteLine("[FileBox@BTN_PNL_SaveChanges_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub BTN_PNL_CloseFile_Click(sender As Object, e As EventArgs) Handles BTN_PNL_CloseFile.Click
        'Cerrar el archivo sin guardar
        Try
            FastColoredTextBox1.Clear()
            GroupBox1.Visible = False
            If My.Settings.Espanglish = "Español" Then
                GroupBox1.Text = "Ver archivo"
            ElseIf My.Settings.Espanglish = "English" Then
                GroupBox1.Text = "View file"
            End If
            ContadorDEN = -1
        Catch ex As Exception
            Console.WriteLine("[FileBox@BTN_PNL_CloseFile_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub BTN_PNL_SaveChangesAndClose_Click(sender As Object, e As EventArgs) Handles BTN_PNL_SaveChangesAndClose.Click
        'Guardar y cerrar el Archivo
        Try
            ContadorDEN = LB_ListBox1.SelectedIndex
            If My.Computer.FileSystem.FileExists(MemoryListDEN(ContadorDEN)) = True Then
                My.Computer.FileSystem.DeleteFile(MemoryListDEN(ContadorDEN))
            End If
            My.Computer.FileSystem.WriteAllText(MemoryListDEN(ContadorDEN), FastColoredTextBox1.Text, False)
            FastColoredTextBox1.Clear()
            GroupBox1.Visible = False
            If My.Settings.Espanglish = "Español" Then
                GroupBox1.Text = "Ver archivo"
            ElseIf My.Settings.Espanglish = "English" Then
                GroupBox1.Text = "View file"
            End If
            ContadorDEN = -1
        Catch ex As Exception
            Console.WriteLine("[FileBox@BTN_PNL_SaveChanges_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub LB_ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles LB_ListBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub
    Private Sub LB_ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles LB_ListBox1.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim strRutaArchivos() As String
                Dim i As Integer
                strRutaArchivos = e.Data.GetData(DataFormats.FileDrop)
                Dim StringPassed As String
                Dim StringPassedTwo As String
                For i = 0 To strRutaArchivos.Length - 1
                    StringPassed = strRutaArchivos(i).ToString
                    StringPassed = StringPassed.Remove(0, StringPassed.LastIndexOf("\") + 1)
                    My.Computer.FileSystem.CopyFile(strRutaArchivos(i), DIRDecrypted & "\" & StringPassed)
                    StringPassedTwo = DIRDecrypted & "\" & StringPassed
                    MemoryListDEN.Add(StringPassedTwo)
                    StringPassedTwo = StringPassedTwo.Remove(0, StringPassedTwo.LastIndexOf("\") + 1)
                    LB_ListBox1.Items.Add(StringPassedTwo)
                Next
                FastColoredTextBox1.Clear()
                ContadorDEN = -1
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@LB_ListBox1_DragDrop]Error: " & ex.Message)
        End Try
    End Sub
#End Region

#Region "ContextMenus"
    Private Sub NewFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFileToolStripMenuItem.Click
        Try
            If My.Settings.Espanglish = "Español" Then
                Dim TextBoxVirtual = InputBox("Ingrese el nombre del nuevo archivo", "Worcome Security")
                If TextBoxVirtual = Nothing Then
                Else
                    My.Computer.FileSystem.WriteAllText(DIRDecrypted & "\" & TextBoxVirtual, FastColoredTextBox1.Text, False)
                    MemoryListDEN.Add(DIRDecrypted & "\" & TextBoxVirtual)
                    FastColoredTextBox1.Clear()
                    MemoryListDENActions("OnClose")
                    IndexearArchivos()
                    MemoryNameActions("CreateList")
                    LB_ListBox1.SelectedItem = TextBoxVirtual
                    ContadorDEN = LB_ListBox1.SelectedIndex
                    FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
                    GroupBox1.Text = "Archivo Abierto: " & LB_ListBox1.SelectedItem
                End If
            ElseIf My.Settings.Espanglish = "English" Then
                Dim TextBoxVirtual = InputBox("Enter the name of the new file", "Worcome Security")
                If TextBoxVirtual = Nothing Then
                Else
                    My.Computer.FileSystem.WriteAllText(DIRDecrypted & "\" & TextBoxVirtual, FastColoredTextBox1.Text, False)
                    MemoryListDEN.Add(DIRDecrypted & "\" & TextBoxVirtual)
                    FastColoredTextBox1.Clear()
                    MemoryListDENActions("OnClose")
                    IndexearArchivos()
                    MemoryNameActions("CreateList")
                    LB_ListBox1.SelectedItem = TextBoxVirtual
                    ContadorDEN = LB_ListBox1.SelectedIndex
                    FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
                    GroupBox1.Text = "Open File: " & LB_ListBox1.SelectedItem
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@NewFileToolStripMenuItem_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub RemoveFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveFileToolStripMenuItem.Click
        Try
            If MessageBox.Show("¿Want to delete this file?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                If LB_ListBox1.SelectedItem = "=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" Then
                    LB_ListBox1.Items.RemoveAt(LB_ListBox1.SelectedIndex)
                Else
                    My.Computer.FileSystem.DeleteFile(MemoryListDEN(ContadorDEN))
                    MemoryListDEN.RemoveAt(ContadorDEN)
                    LB_ListBox1.Items.Remove(LB_ListBox1.SelectedItem)
                    FastColoredTextBox1.Clear()
                    GroupBox1.Visible = False
                    If My.Settings.Espanglish = "Español" Then
                        GroupBox1.Text = "Ver Archivo"
                    ElseIf My.Settings.Espanglish = "English" Then
                        GroupBox1.Text = "View File"
                    End If
                    ContadorDEN = -1
                    MemoryListDENActions("OnClose")
                    IndexearArchivos()
                    MemoryNameActions("CreateList")
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@RemoveFileToolStripMenuItem_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub MoveToDesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveToDesktopToolStripMenuItem.Click
        Try
            ActionConfirm.Target(Debugger.Login_Password)
            If ActionConfirm.ShowDialog = DialogResult.OK Then
                My.Computer.FileSystem.MoveFile(MemoryListDEN(ContadorDEN), System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & LB_ListBox1.SelectedItem)
                IndexearArchivos()
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@MoveToDesktopToolStripMenuItem_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub CopyToDesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToDesktopToolStripMenuItem.Click
        Try
            ActionConfirm.Target(Debugger.Login_Password)
            If ActionConfirm.ShowDialog = DialogResult.OK Then
                My.Computer.FileSystem.CopyFile(MemoryListDEN(ContadorDEN), System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & LB_ListBox1.SelectedItem)
            End If
        Catch ex As Exception
            Console.WriteLine("[FileBox@CopyToDesktopToolStripMenuItem_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub ReloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem.Click
        IndexearArchivos()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
        About.Focus()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        ActionConfirm.Target(Debugger.Login_Password)
        If ActionConfirm.ShowDialog = DialogResult.OK Then
            BackUp.Show()
            BackUp.Focus()
        End If
    End Sub
    Private Sub LlaveCriptograficaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LlaveCriptograficaToolStripMenuItem.Click
        ActionConfirm.Target(Debugger.Login_Password)
        If ActionConfirm.ShowDialog = DialogResult.OK Then
            ChangeCryptoKey.Show()
            ChangeCryptoKey.Focus()
        End If
    End Sub
    Private Sub SeparatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeparatorToolStripMenuItem.Click
        Try
            LB_ListBox1.Items.Add("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=")
            MemoryListDEN.Add("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=")
        Catch ex As Exception
            Console.WriteLine("[FileBox@SeparatorToolStripMenuItem_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        Try
            If My.Settings.Espanglish = "Español" Then
                Dim TextBoxVirtual = InputBox("Ingrese el Nombre del archivo y su Extencion" & vbCrLf & "Ejemplo: BelloArchivo.txt", "Worcome Security")
                If TextBoxVirtual = Nothing Then
                Else
                    LB_ListBox1.SelectedItem = TextBoxVirtual
                End If
            ElseIf My.Settings.Espanglish = "English" Then
                Dim TextBoxVirtual = InputBox("Enter the File Name and its Extension" & vbCrLf & "Example: BeautifulFile.txt", "Worcome Security")
                If TextBoxVirtual = Nothing Then
                Else
                    LB_ListBox1.SelectedItem = TextBoxVirtual
                End If
            End If

        Catch ex As Exception
            Console.WriteLine("[FileBox@BuscarToolStripMenuItem_Click]Error: " & ex.Message)
        End Try
    End Sub
    Private Sub NormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalToolStripMenuItem.Click
        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom
        FastColoredTextBox1.Clear()
        FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
    End Sub
    Private Sub CSharpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSharpToolStripMenuItem.Click
        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp
        FastColoredTextBox1.Clear()
        FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
    End Sub
    Private Sub VisualBasicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualBasicToolStripMenuItem.Click
        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB
        FastColoredTextBox1.Clear()
        FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
    End Sub
    Private Sub HTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem.Click
        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML
        FastColoredTextBox1.Clear()
        FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
    End Sub
    Private Sub SQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLToolStripMenuItem.Click
        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL
        FastColoredTextBox1.Clear()
        FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
    End Sub
    Private Sub PHPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPToolStripMenuItem.Click
        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP
        FastColoredTextBox1.Clear()
        FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
    End Sub
    Private Sub JavaScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JavaScriptToolStripMenuItem.Click
        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS
        FastColoredTextBox1.Clear()
        FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(MemoryListDEN(ContadorDEN))
    End Sub
    Private Sub CifradoRapidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CifradoRapidoToolStripMenuItem.Click
        FastCipher.Show()
        FastCipher.Focus()
    End Sub
#End Region
End Class

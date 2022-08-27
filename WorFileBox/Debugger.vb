Public Class Debugger
    Public parametros As String
    Dim AppFiles As String = "C:\Users\" & System.Environment.UserName & "\AppData\Local\Worcome_Studios\Commons\AppFiles"
    Public Login_Username As String = Nothing
    Public Login_Password As String = Nothing
    Public Login_Email As String = Nothing
    Public IsRegistered As String = "False"
    Public CryptoKey As String = Nothing

    Private Sub Debugger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(DIRConfigFile) = False Then
            IsRegistered = "False"
        Else
            IsRegistered = "True"
        End If
        If My.Computer.FileSystem.DirectoryExists(AppFiles) = False Then
            My.Computer.FileSystem.CreateDirectory(AppFiles)
        End If
        If My.Computer.FileSystem.FileExists(FileBox.DIRCommons & "\CryptoKey.key") = True Then
            My.Computer.FileSystem.DeleteFile(FileBox.DIRCommons & "\CryptoKey.key")
        End If
        GetData()
        parametros = Microsoft.VisualBasic.Command
        If parametros = Nothing Then
            LoadPastAppFile()
        ElseIf parametros = "/FactoryReset" Then
            FactoryReset()
        ElseIf parametros.StartsWith("-FastCipher>") Then
            FastCipher.StartedFromDebugger = True
            Dim TEXTO As String = parametros
            Dim Cadena As String() = TEXTO.Split(">")
            Dim Tipo As String
            Dim Ruta As String
            Tipo = Cadena(0)
            Ruta = Cadena(1)
            FastCipher.OpenFile(Ruta)
            FastCipher.Show()
            FastCipher.Focus()
        Else
            RandomArgumentInsertedError()
        End If
    End Sub

    Private Sub Debugger_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

#Region "DataBase"

    Dim DIRConfigFile As String = FileBox.DIRCommons & "\DataBase_FileBox.db"
    Sub SaveData()
        CryptoActions.UnLockDirectory()
        If My.Computer.FileSystem.FileExists(DIRConfigFile) = True Then
            My.Computer.FileSystem.DeleteFile(DIRConfigFile)
        End If
        Try
            Dim tempString As New TextBox
            tempString.Text = "Username>" & Login_Username &
                vbCrLf & "Password>" & Login_Password &
                vbCrLf & "Email>" & Login_Email &
                vbCrLf & "IsRegistered>" & IsRegistered &
                vbCrLf & "CryptoKey>" & CryptoKey
            My.Computer.FileSystem.WriteAllText(DIRConfigFile, CryptoActions.Encriptar(tempString.Text), False)
            GetData()
        Catch ex As Exception
            Console.WriteLine("[Debugger@SaveData]Error: " & ex.Message)
        End Try
    End Sub

    Sub GetData()
        CryptoActions.UnLockDirectory()
        Try
            Dim tempString As New TextBox
            tempString.Text = CryptoActions.Desencriptar(My.Computer.FileSystem.ReadAllText(DIRConfigFile))
            Dim Lineas = tempString.Lines
            Login_Username = Lineas(0).Split(">"c)(1).Trim()
            Login_Password = Lineas(1).Split(">"c)(1).Trim()
            Login_Email = Lineas(2).Split(">"c)(1).Trim()
            IsRegistered = Lineas(3).Split(">"c)(1).Trim()
            CryptoKey = Lineas(4).Split(">"c)(1).Trim()
        Catch ex As Exception
            Console.WriteLine("[Debugger@GetData]Error: " & ex.Message)
        End Try
    End Sub
#End Region

    Sub CommonStart()
        Try
            If My.Settings.OfflineMode = False Then
                AppService.StartAppService(False, False, True, False, True)
                Threading.Thread.Sleep(150)
            End If
        Catch ex As Exception
            MsgBox("ERROR CRITICO CON 'AppService'", MsgBoxStyle.Critical, "Worcome Security")
        End Try
        If My.Settings.Espanglish = "0" Then
            LangSelector.ShowDialog()
        End If
        If My.Settings.Espanglish = "Español" Then
            Idioma.Español.LANG_Español()
        ElseIf My.Settings.Espanglish = "English" Then
            Idioma.Ingles.LANG_English()
        End If
        If IsRegistered = "False" Then
            SignUP.Show()
            SignIN.Close()
        Else
            SignUP.Close()
            SignIN.Show()
            SignIN.Focus()
            SignIN.TextBox1.Focus()
        End If
    End Sub

    Sub SignInPassed()
        FileBox.Show()
        SignIN.Close()
        SignUP.Close()
        FileBox.Focus()
    End Sub

    Sub SignUpPassed()
        CommonStart()
    End Sub

#Region "PastAppFile"
    Dim SecureWord As String
    Dim SecureVersion As String
    Dim SecureBoolean As Boolean = My.Settings.OnlyMe
    Sub LoadPastAppFile()
        If My.Settings.OnlyMe = True Then
            If My.Computer.FileSystem.FileExists(AppFiles & "\" & My.Application.Info.AssemblyName & "PastAppFile_OnlyMe.WorCODE") = False Then
                My.Computer.FileSystem.WriteAllText(AppFiles & "\" & My.Application.Info.AssemblyName & "PastAppFile_OnlyMe.WorCODE", "#Read modules and compares with the Original/Changed" & vbCrLf & "OnlyMe>" & SecureBoolean & vbCrLf & "Version>" & My.Application.Info.Version.ToString, False)
                ReadPastAppFile()
            ElseIf My.Computer.FileSystem.FileExists(AppFiles & "\" & My.Application.Info.AssemblyName & "PastAppFile_OnlyMe.WorCODE") = True Then
                ReadPastAppFile()
            End If
        ElseIf My.Settings.OnlyMe = False Then
            If My.Computer.FileSystem.FileExists(AppFiles & "\" & My.Application.Info.AssemblyName & "PastAppFile_OnlyMe.WorCODE") = True Then
                My.Computer.FileSystem.DeleteFile(AppFiles & "\" & My.Application.Info.AssemblyName & "PastAppFile_OnlyMe.WorCODE")
                CommonStart()
            End If
        End If
    End Sub

    Sub ReadPastAppFile()
        Dim Lines = System.IO.File.ReadAllLines(AppFiles & "\" & My.Application.Info.AssemblyName & "PastAppFile_OnlyMe.WorCODE")
        SecureWord = Lines(1).Split(">"c)(1).Trim()
        SecureVersion = Lines(2).Split(">"c)(1).Trim()
        If SecureWord = "True" Then
            If SecureVersion = My.Application.Info.Version.ToString = True Then
                'Seguir normalmente
                CommonStart()
            ElseIf SecureVersion = My.Application.Info.Version.ToString = False Then
                'No seguir
                MsgBox("La Aplicacion no se Ejecutara" & vbCrLf & "La Aplicacion original tiene 'OnlyMe' Activado", MsgBoxStyle.Information, "Worcome Security")
                End
            End If
        ElseIf SecureWord = "False" Then
            CommonStart()
        End If
    End Sub
#End Region

    Sub FactoryReset()
        If MessageBox.Show("¿Realmente quieres hacer un FactoryReset a la Aplicacion?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            If InputBox("Escribe la contraseña para Proceder con el 'FactoryReset'", "Worcome Security") = Login_Password Then
                Login_Username = Nothing
                IsRegistered = "False"
                Login_Email = Nothing
                Login_Password = Nothing
                CryptoKey = Nothing
                My.Settings.Espanglish = "0"
                CryptoActions.UnLockDirectory()
                Threading.Thread.Sleep(150)
                If My.Computer.FileSystem.DirectoryExists(FileBox.DIRCommons) = True Then
                    My.Computer.FileSystem.DeleteDirectory(FileBox.DIRCommons, FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
                If My.Computer.FileSystem.FileExists(DIRConfigFile) = True Then
                    My.Computer.FileSystem.DeleteFile(DIRConfigFile)
                End If
                My.Settings.Save()
                My.Settings.Reload()
                MsgBox("Aplicacion Vuelta a la Version de Fabrica" & vbCrLf & "Vuelva a Iniciar la Aplicacion", MsgBoxStyle.Information, "Worcome Security")
                End
            Else
                End
            End If
        Else
            CommonStart()
        End If
    End Sub

    Sub DevMode()
        Login_Username = Environment.UserName
        IsRegistered = "False"
        Login_Email = "wss@worcome.com"
        Login_Password = "15243"
        SaveData()
        My.Settings.Save()
        My.Settings.Reload()
        FileBox.Text = "Wor: FileBox | DEVELOPER MODE"
        Process.Start(FileBox.DIRCommons)
        MsgBox("Developer Mode: ACTIVADO" & vbCrLf & "Datos de Cuenta" & vbCrLf & "Nombre de Usuario: " & Login_Username & vbCrLf & "Contraseña: " & Login_Password & vbCrLf & "Correo: " & Login_Email, MsgBoxStyle.Exclamation, "Worcome Security")
        CommonStart()
    End Sub

    Sub RandomArgumentInsertedError()
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        MsgBox("Error en SystemTrail.Logic: The FCKN Value of Argument Line don't can be Random!" & vbCrLf & "Just Restart the App ;)", MsgBoxStyle.Critical, "SystemTrail Modules")
        My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) &
                                            "\[" & Format(DateAndTime.TimeOfDay, "HH" & " ") &
                                            Format(DateAndTime.TimeOfDay, "mm" & " ") &
                                            Format(DateAndTime.TimeOfDay, "ss" & "") &
                                            Format(DateAndTime.TimeOfDay, "tt") & "] " &
                                            "(" & My.Application.Info.AssemblyName &
                                            ")Crazy_CrashReport.txt",
                                            "Error Fatal en SystemTrail Module" & vbCrLf &
                                            "Informacion sobre el Error: Generado por el Debugger de la Aplicacion, Llamo a un Parametro de Ejecucion no Valido, El Cual fue ocacionado a Propocito por el Usuario (Que Loquillo Tú)" & vbCrLf &
                                            "El Sistema se encuentra Saludable, Solo Vuelve a Iniciar la Aplicacion sin Ningun Parametro." & vbCrLf & "INFO: Esta Aplicacion al Administrar datos delicados es muy facil que entre en Panico, Es normal y es por Seguridad." & vbCrLf & "Msg: Se que es entretenido ver mensajes de error, pero bro, me dañas ;<",
                                            False)
        Process.Start("http://worcomestudios.comule.com/Recursos/WorCommunity/Codigos_de_Error.txt")
        End
    End Sub
End Class
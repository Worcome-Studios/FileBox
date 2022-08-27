Class AppUpdate
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Worcome_Studios\Commons\AppManager"
    Dim DIRLeFile As String = DIRCommons & "\[UPDATE]" & My.Application.Info.AssemblyName & ".WorCODE"
    Public MyAssemblyName As String = My.Application.Info.AssemblyName
    Public Product As String
    Public Version As String
    Public URL As String
    Public WebBrowser As New WebBrowser
    Dim IdiomaAPP As String = "English"

    Private Sub AppUpdate_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles Me.HelpRequested
        If IdiomaAPP = "Spanish" Then
            MsgBox("Esta Aplicación se conecta a los Servidores de Servicios de Worcome.", MsgBoxStyle.Information, "Worcome Security")
        ElseIf IdiomaAPP = "English" Then
            MsgBox("This Application connects to Worcome Service Servers.", MsgBoxStyle.Information, "Worcome Security")
        End If
    End Sub
    Private Sub AppUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        If myCurrentLanguage.Culture.EnglishName.Contains("Spanish") Then
            Lang_Español()
            IdiomaAPP = "Spanish"
        ElseIf myCurrentLanguage.Culture.EnglishName.Contains("English") Then
            Lang_English()
            IdiomaAPP = "English"
        Else
            Lang_English()
            IdiomaAPP = "English"
        End If
        If AppService.OfflineApp = False Then
            If CSS1 = False Or CSS2 = False Or AMC = False Or AAP = False Then
                If AppService.IdiomaApp = "Spanish" Then
                    MsgBox("AppService no se ejecutó correctamente. Es posible que tenga problemas con este módulo.", MsgBoxStyle.Exclamation, "Worcome Security")
                ElseIf AppService.IdiomaApp = "English" Then
                    MsgBox("AppService did not run correctly. You may have problems with this module.", MsgBoxStyle.Exclamation, "Worcome Security")
                End If
            End If
        End If
        Try
            Me.Text = My.Application.Info.ProductName & " | Updates"
            If My.Computer.FileSystem.FileExists(DIRLeFile) = True Then
                My.Computer.FileSystem.DeleteFile(DIRLeFile)
            End If
            WebBrowser.ScriptErrorsSuppressed = True
            If IdiomaAPP = "Spanish" Then
                Label3.Text = "Nombre: " & My.Application.Info.ProductName &
                vbCrLf & "Titulo: " & My.Application.Info.Title &
                vbCrLf & "Descripción: " & My.Application.Info.Description &
                vbCrLf & "Nombre Ensamblado: " & My.Application.Info.AssemblyName &
                vbCrLf & "Versión: " & My.Application.Info.Version.ToString &
                vbCrLf & "Compañía: " & My.Application.Info.CompanyName &
                vbCrLf & "Marca: " & My.Application.Info.Trademark
            ElseIf IdiomaAPP = "English" Then
                Label3.Text = "Name: " & My.Application.Info.ProductName &
                vbCrLf & "Title: " & My.Application.Info.Title &
                vbCrLf & "Description: " & My.Application.Info.Description &
                vbCrLf & "Assembly Name: " & My.Application.Info.AssemblyName &
                vbCrLf & "Version: " & My.Application.Info.Version.ToString &
                vbCrLf & "Company: " & My.Application.Info.CompanyName &
                vbCrLf & "Brand: " & My.Application.Info.Trademark
            End If
        Catch ex As Exception
            Console.WriteLine("[AppUpdate]Error al Iniciar la Aplicacion: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If IdiomaAPP = "Spanish" Then
                Button1.Text = "Cargando..."
            ElseIf IdiomaAPP = "English" Then
                Button1.Text = "Loading..."
            End If
            DownloadFile(AppService.URL_AppUpdate & "/[UPDATE]" & MyAssemblyName & ".WorCODE")
        Catch ex As Exception
            Console.WriteLine("[AppUpdate]Error al Iniciar el Proceso de Descarga: " & ex.Message)
        End Try
    End Sub

    Sub DownloadFile(ByVal Link As String)
        Try
            Button1.Enabled = False
            If My.Computer.Network.IsAvailable = False Then
                If IdiomaAPP = "Spanish" Then
                    Button1.Text = "No hay Conexion a Internet"
                    MsgBox("El computador no está conectado a internet.", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf IdiomaAPP = "English" Then
                    Button1.Text = "No internet connection"
                    MsgBox("The computer is not connected to the internet.", MsgBoxStyle.Critical, "Worcome Security")
                End If
                Me.Close()
            ElseIf My.Computer.Network.IsAvailable = True Then
                My.Computer.Network.DownloadFile(Link, DIRLeFile)
                Threading.Thread.Sleep(100)
                ReadFile()
            End If
        Catch ex As Exception
            If IdiomaAPP = "Spanish" Then
                Button1.Text = "Error al Conectar"
                MsgBox("Fallo la conexión con el Servidor de Servicios de Worcome", MsgBoxStyle.Critical, "Worcome Security")
            ElseIf IdiomaAPP = "English" Then
                Button1.Text = "Error trying to connect"
                MsgBox("Connection to Worcome Service Server failed", MsgBoxStyle.Critical, "Worcome Security")
            End If
            Console.WriteLine("[AppUpdate]Error al Descargar el Archivo de Actualizacion: " & ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub ReadFile()
        Try
            Dim Lines = System.IO.File.ReadAllLines(DIRLeFile)
            Product = Lines(0).Split(">"c)(1).Trim()
            Version = Lines(1).Split(">"c)(1).Trim()
            URL = Lines(2).Split(">"c)(1).Trim()
            If IdiomaAPP = "Spanish" Then
                Button1.Text = "Leyendo datos..."
            ElseIf IdiomaAPP = "English" Then
                Button1.Text = "Reading data..."
            End If
            ReviewFile()
        Catch ex As Exception
            If IdiomaAPP = "Spanish" Then
                Button1.Text = "Error al Leer"
                MsgBox("Error al leer el archivo de actualización", MsgBoxStyle.Critical, "Worcome Security")
            ElseIf IdiomaAPP = "English" Then
                Button1.Text = "Read error"
                MsgBox("Error reading update file", MsgBoxStyle.Critical, "Worcome Security")
            End If
            Console.WriteLine("[AppUpdate]Error al Leer el Archivo de Actualizacion: " & ex.Message)
            Me.Close()
        End Try
    End Sub

    Dim ServerVersionRAW As String
    Dim ServerVersion_X000 As String
    Dim ServerVersion_0X00 As String
    Dim ServerVersion_00X0 As String
    Dim ServerVersion_000X As String
    Dim LocalVersionRAW As String
    Dim LocalVersion_X000 As String
    Dim LocalVersion_0X00 As String
    Dim LocalVersion_00X0 As String
    Dim LocalVersion_000X As String
    Sub ReviewFile()
        Try
            If IdiomaAPP = "Spanish" Then
                Button1.Text = "Comparando..."
            ElseIf IdiomaAPP = "English" Then
                Button1.Text = "Comparing..."
            End If
            Try
                Dim ServerVersionString As String() = Version.Split(".")
                ServerVersion_X000 = ServerVersionString(0)
                ServerVersion_0X00 = ServerVersionString(1)
                ServerVersion_00X0 = ServerVersionString(2)
                ServerVersion_000X = ServerVersionString(3)
                ServerVersionRAW = ServerVersion_X000 & ServerVersion_0X00 & ServerVersion_00X0 & ServerVersion_000X
            Catch ex As Exception
            End Try
            Try
                Dim LocalVersionString As String() = My.Application.Info.Version.ToString.Split(".")
                LocalVersion_X000 = LocalVersionString(0)
                LocalVersion_0X00 = LocalVersionString(1)
                LocalVersion_00X0 = LocalVersionString(2)
                LocalVersion_000X = LocalVersionString(3)
                LocalVersionRAW = LocalVersion_X000 & LocalVersion_0X00 & LocalVersion_00X0 & LocalVersion_000X
            Catch ex As Exception
            End Try
            If Product = My.Application.Info.ProductName.ToString = True Then
                If ServerVersionRAW = LocalVersionRAW Then
                    If IdiomaAPP = "Spanish" Then
                        Button1.Text = "No hay actualizaciones"
                        MsgBox("No hay actualizaciones disponibles", MsgBoxStyle.Information, "Worcome Security")
                    ElseIf IdiomaAPP = "English" Then
                        Button1.Text = "No Updates"
                        MsgBox("No updates available", MsgBoxStyle.Information, "Worcome Security")
                    End If
                    Me.Close()
                ElseIf ServerVersionRAW > LocalVersionRAW Then
                    If IdiomaAPP = "Spanish" Then
                        Button1.Text = "Actualización disponible"
                        MsgBox("Hay una nueva versión disponible!", MsgBoxStyle.Information, "Worcome Security")
                    ElseIf IdiomaAPP = "English" Then
                        Button1.Text = "Update available"
                        MsgBox("There is a new version available!", MsgBoxStyle.Information, "Worcome Security")
                    End If
                    Button1.Enabled = False
                    Me.TopMost = False
                    If URL = "None" Then
                        If IdiomaAPP = "Spanish" Then
                            MsgBox("No se pudo iniciar la descarga", MsgBoxStyle.Critical, "Worcome Security")
                        ElseIf IdiomaAPP = "English" Then
                            MsgBox("Could not start download", MsgBoxStyle.Critical, "Worcome Security")
                        End If
                    Else
                        WebBrowser.Navigate(URL)
                    End If
                ElseIf ServerVersionRAW < LocalVersionRAW Then
                    If IdiomaAPP = "Spanish" Then
                        Button1.Text = "No hay actualizaciones"
                        MsgBox("Tiene una versión superior a la encontrada en el servidor", MsgBoxStyle.Information, "Worcome Security")
                    ElseIf IdiomaAPP = "English" Then
                        Button1.Text = "No Updates"
                        MsgBox("Has a higher version than the one found on the server", MsgBoxStyle.Information, "Worcome Security")
                    End If
                    Me.Close()
                End If
            ElseIf Product = My.Application.Info.ProductName = False Then
                If IdiomaAPP = "Spanish" Then
                    Button1.Text = "Los Datos no Coinciden"
                    MsgBox("Los datos no coinciden con la firma actual", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf IdiomaAPP = "English" Then
                    Button1.Text = "Data does not match"
                    MsgBox("The data does not match the current signature", MsgBoxStyle.Critical, "Worcome Security")
                End If
                Me.Close()
            End If
            My.Computer.FileSystem.DeleteFile(DIRLeFile)
        Catch ex As Exception
            If IdiomaAPP = "Spanish" Then
                Button1.Text = "Error al Verificar"
                MsgBox("Error al comprobar los datos del archivo de actualización", MsgBoxStyle.Critical, "Worcome Security")
            ElseIf IdiomaAPP = "English" Then
                Button1.Text = "Error Verifying"
                MsgBox("Error checking update file data", MsgBoxStyle.Critical, "Worcome Security")
            End If
            Console.WriteLine("[AppUpdate]Error al Analizar el Archivo de Actualizacion: " & ex.Message)
            Me.Close()
        End Try
        If IdiomaAPP = "Spanish" Then
            Button1.Text = "Buscar actualizaciones"
        ElseIf IdiomaAPP = "English" Then
            Button1.Text = "Comparing..."
        End If
    End Sub

    Private Sub WhatsNuevo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(AppService.URL_AppUpdate_WhatsNew & "/WhatsNew_" & My.Application.Info.AssemblyName & ".txt")
    End Sub

    Sub Lang_Español()
        Label1.Text = "Buscar Actualizaciones"
        Label2.Text = "Revisa si la aplicación tiene una actualización disponible, siempre es bueno manejar la última versión."
        Button1.Text = "Buscar actualizaciones"
    End Sub

    Sub Lang_English()
        Label1.Text = "Search for Updates"
        Label2.Text = "Check if the application has an update available, it is always good to handle the latest version."
        Button1.Text = "Search for updates"
    End Sub
End Class
'Es AppUpdate un modulo de trafico Inutil. Digo, AppService comprueba la version al apenas iniciar, app update no.
'Peeero, AppUpdate tiene una interfaz y algo que AppService no, una variable URL de donde sacara la version actualizada.
'Implementar esa var URL en AppService es imposible, pues generaria problemas con los clientes desactualizados.
'
'Lo otro seria copiar AppUpdate pero al final de pie de los archivos de configuracion de AppService, asi quedaria un archivo ordenado
'este es un problema, pero se busca quitar los archivos de configuracion de AppUpdate y reemplazarlos con los que ya se descargaan de AppService.
'Lo mas logico aqui es mezclar a los dos, que se retro-alimenten uno del otro. Todo para una mejor experiencia del usuario.
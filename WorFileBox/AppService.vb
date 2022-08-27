Imports System.ComponentModel
Module AppService
    Dim DIRCommons As String = "C:\Users\" & System.Environment.UserName & "\AppData\Local\Worcome_Studios\Commons"
    Dim DIRAppManager As String = DIRCommons & "\AppManager"
    Dim DIRKeyManager As String = DIRAppManager & "\KeyManager"
    Dim DirAppPatch As String = Application.ExecutablePath

    Public OfflineApp As Boolean
    Public SecureMode As Boolean
    Dim AppManager As Boolean
    Dim SignAutority As Boolean
    Dim AppServiceStatus As Boolean

    Public IdiomaApp As String = "ENG"

    Public CSS1 As Boolean = False
    Public CSS2 As Boolean = False
    Public AMC As Boolean = False
    Public AAP As Boolean = False

    Public UsingServer As String = "WS1"
    Dim ServerStatus As String = Nothing
    Dim ServerMSG As String = Nothing
    Dim URLs_Update As String = Nothing
    Public URL_KeyAccessToken As String = "http://worcomestudios.comule.com/Recursos/InfoData/KeyAccessToken.WorCODE"
    Public URL_AppService As String = "http://worcomestudios.comule.com/Recursos/InfoData/WorAppServices"
    Public URL_AppUpdate As String = "http://worcomestudios.comule.com/Recursos/InfoData/Updates"
    Public URL_AppUpdate_WhatsNew As String = "http://worcomestudios.comule.com/Recursos/InfoData/WhatsNew"
    Public URL_AppHelper_Help As String = "http://worcomestudios.comule.com/Recursos/AppHelper"
    Public URL_Support_Post As String = "http://worcomestudios.comule.com/Recursos/WorCommunity/soporte.php"
    Public URL_Telemetry_Post As String = "http://worcomestudios.comule.com/Recursos/InfoData/TelemetryPost.php"

    Dim WithEvents DownloaderArrayServerSwitch As New Net.WebClient
    Dim WithEvents DownloaderArrayAppService As New Net.WebClient
    Dim DownloadURIServerSwitch As Uri
    Dim DownloadURIAppService As Uri

    Sub StartAppService(ByVal OffLineApp_SAS As Boolean, ByVal SecureModeSAS As Boolean, ByVal AppManager_SAS As Boolean, ByVal SignAutority_SAS As Boolean, ByVal AppServiceStatus_SAS As Boolean)
        Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        If myCurrentLanguage.Culture.EnglishName.Contains("Spanish") Then
            IdiomaApp = "ESP"
        ElseIf myCurrentLanguage.Culture.EnglishName.Contains("English") Then
            IdiomaApp = "ENG"
        Else
            IdiomaApp = "ENG"
        End If
        Console.WriteLine("[StartAppService]Iniciado en: " & vbCrLf & "Offline Mode: " & OffLineApp_SAS & vbCrLf & "Secure Mode: " & SecureModeSAS & vbCrLf & "AppManager: " & AppManager_SAS & vbCrLf & "SignAutority: " & SignAutority_SAS & vbCrLf & "AppService: " & AppServiceStatus_SAS)
        OfflineApp = OffLineApp_SAS
        SecureMode = SecureModeSAS
        AppManager = AppManager_SAS
        SignAutority = SignAutority_SAS
        AppServiceStatus = AppServiceStatus_SAS
        If SecureMode = True Then
            If My.Computer.Network.IsAvailable = False Then
                MsgBox("Esta aplicación necesita acceso a internet para continuar", MsgBoxStyle.Critical, "Worcome Security")
                End 'END_PROGRAM
            End If
        End If
        Try
            If My.Computer.FileSystem.DirectoryExists(DIRCommons) = False Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons)
            End If
            If My.Computer.FileSystem.DirectoryExists(DIRAppManager) = False Then
                My.Computer.FileSystem.CreateDirectory(DIRAppManager)
            End If
        Catch ex As Exception
        End Try
        If My.Computer.FileSystem.FileExists(DIRCommons & "\[" & My.Application.Info.AssemblyName & "]Status_WSS.ini") = True Then
            My.Computer.FileSystem.DeleteFile(DIRCommons & "\[" & My.Application.Info.AssemblyName & "]Status_WSS.ini")
        End If
        If OffLineApp_SAS = False Then
            DownloadURIServerSwitch = New Uri("https://docs.google.com/uc?export=download&id=1ztBhx9ROXfHTBknpAyJk49S3P0EeypOA")
            DownloaderArrayServerSwitch.DownloadFileAsync(DownloadURIServerSwitch, DIRCommons & "\[" & My.Application.Info.AssemblyName & "]Status_WSS.ini")
        Else
            Console.WriteLine("'AppService' Omitido")
        End If
    End Sub

    Private Sub DownloaderArrayServerSwitch_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles DownloaderArrayServerSwitch.DownloadFileCompleted
        ClueChangeServer(OfflineApp, SecureMode, AppManager, SignAutority, AppServiceStatus)
    End Sub

    Sub ClueChangeServer(ByVal OffLineApp_CCS As Boolean, ByVal SecureMode_CCS As Boolean, ByVal AppManager_CCS As Boolean, ByVal SignAutority_CCS As Boolean, ByVal AppServiceStatus_CCS As Boolean)
        Try
            Dim tempString As String = Nothing
            Dim TXBVR As New TextBox
            TXBVR.Text = My.Computer.FileSystem.ReadAllText(DIRCommons & "\[" & My.Application.Info.AssemblyName & "]Status_WSS.ini")
            Dim Linea = TXBVR.Lines
            UsingServer = Linea(1).Split(">"c)(1).Trim()
            ServerStatus = Linea(2).Split(">"c)(1).Trim()
            ServerMSG = Linea(3).Split(">"c)(1).Trim()
            URLs_Update = Linea(4).Split(">"c)(1).Trim()
            URL_KeyAccessToken = Linea(5).Split(">"c)(1).Trim()
            URL_AppService = Linea(6).Split(">"c)(1).Trim()
            URL_AppUpdate = Linea(7).Split(">"c)(1).Trim()
            URL_AppUpdate_WhatsNew = Linea(8).Split(">"c)(1).Trim()
            URL_AppHelper_Help = Linea(9).Split(">"c)(1).Trim()
            URL_Support_Post = Linea(10).Split(">"c)(1).Trim()
            URL_Telemetry_Post = Linea(11).Split(">"c)(1).Trim()
            If ServerStatus = "Stopped" Then
                If SecureMode = True Then
                    MsgBox("The Worcome Server are not working." & vbCrLf & "Try it later", MsgBoxStyle.Critical, "Worcome Security")
                    If ServerMSG = "None" Then
                    Else
                        MsgBox("Worcome Server Services" & vbCrLf & ServerMSG, MsgBoxStyle.Information, "Worcome Security")
                    End If
                    End 'END_PROGRAM
                End If
            Else
                If ServerMSG = "None" Then
                Else
                    MsgBox("Worcome Server Services" & vbCrLf & ServerMSG, MsgBoxStyle.Information, "Worcome Security")
                End If
            End If
            If tempString = "WS1" Then
                UsingServer = "WS1"
            ElseIf tempString = "WS2" Then
                UsingServer = "WS2"
            ElseIf tempString = "WS3" Then
                UsingServer = "WS3"
            End If
            Console.WriteLine("Using Server: " & UsingServer)
            CSS1 = True
        Catch ex As Exception
            Console.WriteLine("[AppService@ServerSwitch:AnalizeInformation]Error: " & ex.Message)
            If SecureMode_CCS = True Then
                If My.Computer.Network.IsAvailable = False Then
                    MsgBox("Esta aplicación necesita acceso a internet para continuar", MsgBoxStyle.Critical, "Worcome Security")
                Else
                    MsgBox("No se pudo conectar a los Servidores de Servicios de Worcome", MsgBoxStyle.Critical, "Worcome Security")
                End If
                End 'END_PROGRAM
            End If
        End Try
        Try
            If URLs_Update = "No" Then
                If UsingServer = "WS1" Then
                    URL_KeyAccessToken = "http://worcomestudios.comule.com/Recursos/InfoData/KeyAccessToken.WorCODE"
                    URL_AppService = "http://worcomestudios.comule.com/Recursos/InfoData/WorAppServices"
                    URL_AppUpdate = "http://worcomestudios.comule.com/Recursos/InfoData/Updates"
                    URL_AppUpdate_WhatsNew = "http://worcomestudios.comule.com/Recursos/InfoData/WhatsNew"
                    URL_AppHelper_Help = "http://worcomestudios.comule.com/Recursos/AppHelper"
                    URL_Support_Post = "http://worcomestudios.comule.com/Recursos/WorCommunity/soporte.php"
                    URL_Telemetry_Post = "http://worcomestudios.comule.com/Recursos/InfoData/TelemetryPost.php"
                    Console.WriteLine("AppService ahora estara utilizando el servidor 'Worcome Server 1'")
                ElseIf UsingServer = "WS2" Then
                    URL_KeyAccessToken = "http://worcomestudios.mywebcommunity.org/Recursos/WSS_Source/KeyAccessToken.WorCODE"
                    URL_AppService = "http://worcomestudios.mywebcommunity.org/Recursos/WSS_Source/WorAppServices"
                    URL_AppUpdate = "http://worcomestudios.mywebcommunity.org/Recursos/WSS_Source/Updates"
                    URL_AppUpdate_WhatsNew = "http://worcomestudios.mywebcommunity.org/Recursos/WSS_Source/WhatsNew"
                    URL_AppHelper_Help = "http://worcomestudios.mywebcommunity.org/Recursos/AppHelper"
                    URL_Support_Post = "http://worcomestudios.mywebcommunity.org/Recursos/WorCommunity/soporte.php"
                    URL_Telemetry_Post = "http://worcomestudios.mywebcommunity.org/Recursos/WSS_Source/TelemetryPost.php"
                    Console.WriteLine("AppService ahora estara utilizando el servidor 'Worcome Server 2'")
                ElseIf UsingServer = "WS3" Then
                    URL_KeyAccessToken = "http://worcomecorporations.000webhostapp.com/Source/WSS/KeyAccessToken.WorCODE"
                    URL_AppService = "http://worcomecorporations.000webhostapp.com/Source/WSS/WorAppServices"
                    URL_AppUpdate = "http://worcomecorporations.000webhostapp.com/Source/WSS/Updates"
                    URL_AppUpdate_WhatsNew = "http://worcomecorporations.000webhostapp.com/Source/WSS/WhatsNew"
                    URL_AppHelper_Help = "http://worcomecorporations.000webhostapp.com/Source/WSS/AppHelper"
                    URL_Support_Post = "http://worcomecorporations.000webhostapp.com/Source/WSS/soporte.php"
                    URL_Telemetry_Post = "http://worcomecorporations.000webhostapp.com/Source/WSS/TelemetryPost.php"
                    Console.WriteLine("AppService ahora estara utilizando el servidor 'Worcome Server 3'")
                End If
            End If
            CSS2 = True
        Catch ex As Exception
            Console.WriteLine("[AppService@ServerSwitch:ActionInformation]Error: " & ex.Message)
        End Try
        AppManagerCompatibility(OffLineApp_CCS, SecureMode_CCS, AppManager_CCS, SignAutority_CCS, AppServiceStatus_CCS)
    End Sub

    Sub AppManagerCompatibility(ByVal OffLineApp_AMC As Boolean, ByVal SecureMode_AMC As Boolean, ByVal AppManager_AMC As Boolean, ByVal SignAutority_AMC As Boolean, ByVal AppServiceStatus_AMC As Boolean)
        If AppManager_AMC = False Then
            Console.WriteLine("'AppManagerCompatibility' Omitido")
            AppServiceStatusStack(OffLineApp_AMC, SecureMode_AMC, AppServiceStatus_AMC)
        Else
            Try
                If My.Computer.FileSystem.DirectoryExists(DIRAppManager) = False Then
                    My.Computer.FileSystem.CreateDirectory(DIRAppManager)
                ElseIf My.Computer.FileSystem.DirectoryExists(DIRAppManager) = True Then
                    If My.Computer.FileSystem.FileExists(DIRAppManager & "\" & My.Application.Info.AssemblyName & ".WorCODE") = False Then
                        My.Computer.FileSystem.WriteAllText(DIRAppManager & "\" & My.Application.Info.AssemblyName & ".WorCODE",
                                                            "AssemblyName>" & My.Application.Info.AssemblyName &
                                                            vbCrLf & "ProductName>" & My.Application.Info.ProductName &
                                                            vbCrLf & "Description>" & My.Application.Info.Description &
                                                            vbCr & "Version>" & My.Application.Info.Version.ToString &
                                                            vbCrLf & "Patch>" & DirAppPatch, False)
                        AMC = True
                    ElseIf My.Computer.FileSystem.FileExists(DIRAppManager & "\" & My.Application.Info.AssemblyName & ".WorCODE") = True Then
                        My.Computer.FileSystem.DeleteFile(DIRAppManager & "\" & My.Application.Info.AssemblyName & ".WorCODE")
                        My.Computer.FileSystem.WriteAllText(DIRAppManager & "\" & My.Application.Info.AssemblyName & ".WorCODE",
                                                            "AssemblyName>" & My.Application.Info.AssemblyName &
                                                            vbCrLf & "ProductName>" & My.Application.Info.ProductName &
                                                            vbCrLf & "Description>" & My.Application.Info.Description &
                                                            vbCr & "Version>" & My.Application.Info.Version.ToString &
                                                            vbCrLf & "Patch>" & DirAppPatch, False)
                        AMC = True
                    End If
                End If
            Catch ex As Exception
                Console.WriteLine("[AppManager Compatibility]Error: " & ex.Message)
            End Try
            AppServiceStatusStack(OffLineApp_AMC, SecureMode_AMC, AppServiceStatus_AMC)
        End If
    End Sub

    Public ServerVersionRAW As String
    Public ServerVersion_X000 As String
    Public ServerVersion_0X00 As String
    Public ServerVersion_00X0 As String
    Public ServerVersion_000X As String
    Public LocalVersionRAW As String
    Public LocalVersion_X000 As String
    Public LocalVersion_0X00 As String
    Public LocalVersion_00X0 As String
    Public LocalVersion_000X As String
    Sub AppServiceStatusStack(ByVal OffLineApp_ASS As Boolean, ByVal SecureMode_ASS As Boolean, ByVal AppServiceStatus_ASS As Boolean)
        If My.Computer.FileSystem.FileExists(DIRCommons & "\WorAppService_" & My.Application.Info.AssemblyName & ".WorCODE") Then
            My.Computer.FileSystem.DeleteFile(DIRCommons & "\WorAppService_" & My.Application.Info.AssemblyName & ".WorCODE")
        End If
        If AppServiceStatus_ASS = False Then
            Console.WriteLine("'AppServiceStatus' Omitido")
            If OffLineApp_ASS = False Then
                Console.WriteLine("Aplicacion en Linea")
                DownloadURIAppService = New Uri(URL_AppService & "/Wor_Services___" & My.Application.Info.ProductName & ".WorCODE")
                DownloaderArrayAppService.DownloadFileAsync(DownloadURIAppService, DIRCommons & "\WorAppService_" & My.Application.Info.AssemblyName & ".WorCODE")
            Else
                Console.WriteLine("Aplicacion fuera de Linea")
            End If
        Else
            DownloadURIAppService = New Uri(URL_AppService & "/Wor_Services___" & My.Application.Info.ProductName & ".WorCODE")
            DownloaderArrayAppService.DownloadFileAsync(DownloadURIAppService, DIRCommons & "\WorAppService_" & My.Application.Info.AssemblyName & ".WorCODE")
        End If
    End Sub

    Private Sub DownloaderArrayAppService_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles DownloaderArrayAppService.DownloadFileCompleted
        ApplyAppService(OfflineApp, SecureMode, AppServiceStatus)
    End Sub

    Sub ApplyAppService(ByVal OffLineApp_AAS As Boolean, ByVal SecureMode_AAS As Boolean, ByVal AppServiceStatus_AAS As Boolean)
        Dim ServiceAssemblyName As String
        Dim ServiceStatus As String
        Dim ServiceURL As String
        Dim ServiceMessage As String
        Dim ServiceArgument As String
        Dim ServiceCommand As String
        Dim ServiceVersion As String
        Dim CriticalUpdate As String
        Dim CriticalUpdateMSG As String
        Try
            'My.Computer.Network.DownloadFile(URL_AppService & "/Wor_Services___" & My.Application.Info.ProductName & ".WorCODE", DIRCommons & "\WorAppService_" & My.Application.Info.AssemblyName & ".WorCODE")
            Dim Lines = System.IO.File.ReadAllLines(DIRCommons & "\WorAppService_" & My.Application.Info.AssemblyName & ".WorCODE")
            ServiceAssemblyName = Lines(0).Split(">"c)(1).Trim()
            ServiceStatus = Lines(1).Split(">"c)(1).Trim()
            ServiceURL = Lines(2).Split(">"c)(1).Trim()
            ServiceMessage = Lines(3).Split(">"c)(1).Trim()
            ServiceArgument = Lines(4).Split(">"c)(1).Trim()
            ServiceCommand = Lines(5).Split(">"c)(1).Trim()
            ServiceVersion = Lines(6).Split(">"c)(1).Trim()
            CriticalUpdate = Lines(7).Split(">"c)(1).Trim()
            CriticalUpdateMSG = Lines(8).Split(">"c)(1).Trim()
            Try
                Dim ServerVersionString As String() = ServiceVersion.Split(".")
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
            If ServiceAssemblyName = My.Application.Info.AssemblyName = True Then
                If ServiceURL = "None" Then
                    Console.WriteLine("[AppService]Sin URL para Ejecutar")
                Else
                    Process.Start(ServiceURL)
                    Console.WriteLine("[AppService]URL Ejecutada: " & ServiceURL)
                End If
                If ServiceMessage = "None" Then
                    Console.WriteLine("[AppService]Sin Mensajes para Ejecutar")
                Else
                    MsgBox(ServiceMessage, MsgBoxStyle.Information, "Worcome Security")
                    Console.WriteLine("[AppService]Mensaje Ejecutado: " & ServiceMessage)
                End If
                If ServiceArgument = "None" Then
                    Console.WriteLine("[AppService]Sin Argumentos para Iniciar")
                Else
                    Process.Start(DirAppPatch & " " & ServiceArgument)
                    Console.WriteLine("[AppService]Argumento Iniciado: " & ServiceCommand)
                End If
                If ServiceCommand = "None" Then
                    Console.WriteLine("[AppService]Sin Comandos para Ejecutar")
                Else
                    Process.Start(ServiceCommand)
                    Console.WriteLine("[AppService]Comando Ejecutado: " & ServiceCommand)
                End If
                'COMPROBACION DE CUAL VERSION ES MAYOR O INFERIOR A OTRA ENTRE LOCAL Y SERVIDOR
                If ServerVersionRAW = LocalVersionRAW Then 'La aplicacion esta actualizada     
                    Console.WriteLine("[AppService]La Aplicacion esta Actualizada")
                ElseIf ServerVersionRAW > LocalVersionRAW Then 'La aplicacion esta desactualziada
                    If CriticalUpdate = "True" Then
                        Console.WriteLine("[AppService]Actualizacion critica")
                        If CriticalUpdateMSG = "None" Then
                        Else
                            MsgBox(CriticalUpdateMSG, MsgBoxStyle.Information, "Worcome Security")
                            AppUpdate.ShowDialog()
                        End If
                        End 'END_PROGRAM
                    Else
                        If CriticalUpdateMSG = "None" Then
                        Else
                            MsgBox(CriticalUpdateMSG, MsgBoxStyle.Information, "Worcome Security")
                        End If
                        Console.WriteLine("[AppService]Hay una nueva version disponible")
                        'MsgBox("Hay una Actualizacion Disponible", MsgBoxStyle.Information, "Worcome Security")
                    End If
                ElseIf ServerVersionRAW < LocalVersionRAW Then 'La aplicacion esta re-actualizada
                    MsgBox("Actualmente está corriendo una versión superior a la del servidor", MsgBoxStyle.Information, "Worcome Security")
                Else 'No se sabe

                End If
                If ServiceStatus = "Enabled" Then
                    Console.WriteLine("[AppService]Aplicacion en Estado Activa")
                ElseIf ServiceStatus = "Disabled" Then
                    MsgBox("Los servicios de esta aplicación fueron desactivados por Worcome", MsgBoxStyle.Exclamation, "Worcome Security")
                    End 'END_PROGRAM
                ElseIf ServiceStatus = "Waiting" Then
                    MsgBox("Los servicios de esta aplicación están en espera...", MsgBoxStyle.Exclamation, "Worcome Security")
                    End 'END_PROGRAM
                ElseIf ServiceStatus = "Stopped" Then
                    MsgBox("Los servicios de esta aplicación fueron detenidos por Worcome", MsgBoxStyle.Exclamation, "Worcome Security")
                    End 'END_PROGRAM
                Else
                    Console.WriteLine("[AppService]Aplicacion en Estado Indefinida")
                    If SecureMode_AAS = True Then
                        Console.WriteLine("[AppService]Aplicacion en Estado Indefinida, Secure Mode esta Activado")
                        MsgBox("La aplicación está en un estado indefinido" & vbCrLf & "Secure Mode está activo" & vbCrLf & "La aplicación se cerrará", MsgBoxStyle.Critical, "Worcome Security")
                        End 'END_PROGRAM
                    End If
                End If
            End If
            AAP = True
        Catch ex As Exception
            Console.WriteLine("[AppService Status]Error: " & ex.Message)
            If SecureMode_AAS = True Then
                If My.Computer.Network.IsAvailable = False Then
                    MsgBox("Esta aplicación necesita acceso a internet para continuar", MsgBoxStyle.Critical, "Worcome Security")
                Else
                    MsgBox("No se pudo conectar a los Servidores de Servicios de Worcome", MsgBoxStyle.Critical, "Worcome Security")
                End If
                End 'END_PROGRAM
            End If
        End Try
    End Sub
End Module
'Last update 22/08/2020 06:56 PM Chile by ElCris009
'Updated 30/05/2020 09:45 PM Chile by ElCris009

'TO DO ?
'   Si es una app con SecureMode o Online obligado entonces se debera esperar a que AppService se ejhecute x completo para poder mostrar la ventana principal del programa
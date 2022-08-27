Public Class BackUp

    Private Sub BackUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCrearBackup_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ActionConfirm.Target(Debugger.Login_Username)
            If ActionConfirm.ShowDialog = DialogResult.OK Then
                ActionConfirm.Target(Debugger.Login_Email)
                If ActionConfirm.ShowDialog = DialogResult.OK Then
                    ActionConfirm.Target(Debugger.Login_Password)
                    If ActionConfirm.ShowDialog = DialogResult.OK Then
                        FileBox.MemoryNameActions("CreateList")
                        FileBox.OnCloseCallToEncrypt()
                        Threading.Thread.Sleep(150)
                        CryptoActions.UnLockDirectory()
                        Threading.Thread.Sleep(50)
                        My.Computer.FileSystem.CopyDirectory(FileBox.DIRCommons, System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FileBoxArchives", True)
                        My.Computer.Clipboard.SetText(Debugger.CryptoKey)
                        CryptoActions.LockDirectory()
                        If My.Settings.Espanglish = "Español" Then
                            MsgBox("La copia de seguridad fue creada correctamente." & vbCrLf & "La llave criptográfica fue añadida a su portapapeles." & vbCrLf & "FileBox se cerrará.", MsgBoxStyle.Information, "Worcome Security")
                        ElseIf My.Settings.Espanglish = "English" Then
                            MsgBox("The backup was created successfully!" & vbCrLf & "La llave criptográfica fue añadida a su portapapeles." & vbCrLf & "FileBox will close", MsgBoxStyle.Information, "Worcome Security")
                        End If
                        End
                    Else
                        If My.Settings.Espanglish = "Español" Then
                            MsgBox("La contraseña no coincide con la registrada." & vbCrLf & "FileBox se cerrará.", MsgBoxStyle.Critical)
                        ElseIf My.Settings.Espanglish = "English" Then
                            MsgBox("The password does not match the one registered." & vbCrLf & "FileBox will close.", MsgBoxStyle.Critical)
                        End If
                        FileBox.Close()
                    End If
                Else
                    If My.Settings.Espanglish = "Español" Then
                        MsgBox("El correo ingresado con coincide con el registrado." & vbCrLf & "FileBox se cerrará.", MsgBoxStyle.Critical)
                    ElseIf My.Settings.Espanglish = "English" Then
                        MsgBox("The email entered does not match the registered one." & vbCrLf & "FileBox will close.", MsgBoxStyle.Critical)
                    End If
                    FileBox.Close()
                End If
            Else
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("El nombre de usuario no coincide con el registrado." & vbCrLf & "FileBox se cerrará.", MsgBoxStyle.Critical)
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("The username does not match the registered one." & vbCrLf & "FileBox will close.", MsgBoxStyle.Critical)
                End If
                FileBox.Close()
            End If
        Catch ex As Exception
            Console.WriteLine("[BackUp@Button1_Click]Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Panel1_DragEnter(sender As Object, e As DragEventArgs) Handles Panel1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub pnlLeerBackup_DragDrop(sender As Object, e As DragEventArgs) Handles Panel1.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim strRutaArchivos() As String
                Dim i As Integer
                strRutaArchivos = e.Data.GetData(DataFormats.FileDrop)
                Dim TextBoxVirtual = InputBox("Ingrese la llave de cifrado correspondiente a la copia de seguridad abierta." & vbCrLf & "Enter the encryption key corresponding to the open backup.", "Worcome Security")
                If TextBoxVirtual = Nothing Then
                    If My.Settings.Espanglish = "Español" Then
                        MsgBox("Rellene con la información solicitada.", MsgBoxStyle.Exclamation, "Worcome Security")
                        MsgBox("No se completó la información necesaria." & vbCrLf & "La copia de seguridad no será aplicada." & vbCrLf & "FileBox se cerrará.", MsgBoxStyle.Information, "Worcome Security")
                    ElseIf My.Settings.Espanglish = "English" Then
                        MsgBox("Fill in the requested information.", MsgBoxStyle.Exclamation, "Worcome Security")
                        MsgBox("The necessary information was not completed." & vbCrLf & "The backup will not be applied." & vbCrLf & "FileBox will close", MsgBoxStyle.Information, "Worcome Security")
                    End If
                    FileBox.Close()
                Else
                    ActionConfirm.Target(Debugger.Login_Username)
                    If ActionConfirm.ShowDialog = DialogResult.OK Then
                        ActionConfirm.Target(Debugger.Login_Email)
                        If ActionConfirm.ShowDialog = DialogResult.OK Then
                            ActionConfirm.Target(Debugger.Login_Password)
                            If ActionConfirm.ShowDialog = DialogResult.OK Then
                                For i = 0 To strRutaArchivos.Length - 1
                                    My.Computer.FileSystem.CopyDirectory(strRutaArchivos(i), FileBox.DIRCommons, True)
                                Next
                                Threading.Thread.Sleep(150)
                                Debugger.CryptoKey = TextBoxVirtual
                                My.Settings.Save()
                                My.Settings.Reload()
                                FileBox.CryptoPassword = Debugger.CryptoKey
                                If My.Settings.Espanglish = "Español" Then
                                    MsgBox("Copia de Seguridad leída correctamente." & vbCrLf & "Vuelva a Iniciar la Aplicación.", MsgBoxStyle.Information, "Worcome Security")
                                ElseIf My.Settings.Espanglish = "English" Then
                                    MsgBox("Backup read correctly!" & vbCrLf & "Restart the application.", MsgBoxStyle.Information, "Worcome Security")
                                End If
                                End
                            Else
                                If My.Settings.Espanglish = "Español" Then
                                    MsgBox("La contraseña no coincide con la registrada." & vbCrLf & "FileBox se cerrará.", MsgBoxStyle.Critical)
                                ElseIf My.Settings.Espanglish = "English" Then
                                    MsgBox("The password does not match the one registered." & vbCrLf & "FileBox will close.", MsgBoxStyle.Critical)
                                End If
                                FileBox.Close()
                            End If
                        Else
                            If My.Settings.Espanglish = "Español" Then
                                MsgBox("El correo ingresado con coincide con el registrado." & vbCrLf & "FileBox se cerrará.", MsgBoxStyle.Critical)
                            ElseIf My.Settings.Espanglish = "English" Then
                                MsgBox("The email entered does not match the registered one." & vbCrLf & "FileBox will close.", MsgBoxStyle.Critical)
                            End If
                            FileBox.Close()
                        End If
                    Else
                        If My.Settings.Espanglish = "Español" Then
                            MsgBox("El nombre de usuario no coincide con el registrado." & vbCrLf & "FileBox se cerrará.", MsgBoxStyle.Critical)
                        ElseIf My.Settings.Espanglish = "English" Then
                            MsgBox("The username does not match the registered one." & vbCrLf & "FileBox will close.", MsgBoxStyle.Critical)
                        End If
                        FileBox.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("[BackUp@Panel1_DragDrop]Error: " & ex.Message)
        End Try
    End Sub
End Class
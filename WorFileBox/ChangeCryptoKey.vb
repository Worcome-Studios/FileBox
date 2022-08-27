Public Class ChangeCryptoKey

    Private Sub ChangeCryptoKey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.OnlyMe = True Then
            CheckBox1.CheckState = CheckState.Checked
        Else
            CheckBox1.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub btnShowCryptoKey_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Mostrar" Then
            If InputBox("Ingrese su Nombre de Usuario para continuar" & vbCrLf & "Enter your Username to continue", "Worcome Security") = Debugger.Login_Username Then
                If InputBox("Ingrese su Contraseña para continuar" & vbCrLf & "Enter your Password to continue", "Worcome Security") = Debugger.Login_Password Then
                    If InputBox("Ingrese su Correo para continuar" & vbCrLf & "Enter your Email to continue", "Worcome Security") = Debugger.Login_Email Then
                        TextBox1.Text = Debugger.CryptoKey
                        Button1.Text = "Ocultar"
                    Else
                        If My.Settings.Espanglish = "Español" Then
                            MsgBox("El Correo no coincide con el Registrado" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                        ElseIf My.Settings.Espanglish = "English" Then
                            MsgBox("The Mail does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                        End If
                        FileBox.Close()
                    End If
                Else
                    If My.Settings.Espanglish = "Español" Then
                        MsgBox("La Contraseña no coincide con la Registrada" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf My.Settings.Espanglish = "English" Then
                        MsgBox("The Password does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    FileBox.Close()
                End If
            Else
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("El Nombre de Usuario no coincide con el Registrado" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("The User Name does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                End If
                FileBox.Close()
            End If
        Else
            TextBox1.Text = Nothing
            Button1.Text = "Mostrar"
        End If
    End Sub

    Private Sub btnGenerateCryptoKey_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If InputBox("Ingrese su Nombre de Usuario para continuar" & vbCrLf & "Enter your Username to continue", "Worcome Security") = Debugger.Login_Username Then
            If InputBox("Ingrese su Contraseña para continuar" & vbCrLf & "Enter your Password to continue", "Worcome Security") = Debugger.Login_Password Then
                If InputBox("Ingrese su Correo para continuar" & vbCrLf & "Enter your Email to continues", "Worcome Security") = Debugger.Login_Email Then
                    'Generar Automaticamente
                    CryptoActions.CreatePrivateKey()
                    Threading.Thread.Sleep(150)
                    If My.Settings.Espanglish = "Español" Then
                        MsgBox("Llave Criptografica Creada Automaticamente!" & vbCrLf & "Vuelva a Iniciar la Aplicacion", MsgBoxStyle.Information, "Worcome Security")
                    ElseIf My.Settings.Espanglish = "English" Then
                        MsgBox("Cryptographic Key Created Automatically!" & vbCrLf & "Restart the Application", MsgBoxStyle.Information, "Worcome Security")
                    End If
                    FileBox.Close()
                Else
                    If My.Settings.Espanglish = "Español" Then
                        MsgBox("El Correo no coincide con el Registrado" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf My.Settings.Espanglish = "English" Then
                        MsgBox("The Mail does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    FileBox.Close()
                End If
            Else
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("La Contraseña no coincide con la Registrada" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("The Password does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                End If
                FileBox.Close()
            End If
        Else
            If My.Settings.Espanglish = "Español" Then
                MsgBox("El Nombre de Usuario no coincide con el Registrado" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
            ElseIf My.Settings.Espanglish = "English" Then
                MsgBox("The User Name does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
            End If
            FileBox.Close()
        End If
    End Sub

    Private Sub btnWriteCryptoKey_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If InputBox("Ingrese su Nombre de Usuario para continuar" & vbCrLf & "Enter your Username to continue", "Worcome Security") = Debugger.Login_Username Then
            If InputBox("Ingrese su Contraseña para continuar" & vbCrLf & "Enter your Password to continue", "Worcome Security") = Debugger.Login_Password Then
                If InputBox("Ingrese su Correo para continuar" & vbCrLf & "Enter your Email to continue", "Worcome Security") = Debugger.Login_Email Then
                    'Escribir una
                    Dim TextBoxVirtual = InputBox("Ingrese una Llave Criptografica", "Worcome Security")
                    If TextBoxVirtual = Nothing Then
                        If My.Settings.Espanglish = "Español" Then
                            MsgBox("Rellene con la Informacion Solicitada" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                        ElseIf My.Settings.Espanglish = "English" Then
                            MsgBox("Fill in the requested information" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                        End If
                        FileBox.Close()
                    Else
                        Debugger.CryptoKey = TextBoxVirtual
                        Debugger.SaveData()
                        My.Settings.Save()
                        My.Settings.Reload()
                        FileBox.CryptoPassword = Debugger.CryptoKey
                        Threading.Thread.Sleep(50)
                        If My.Settings.Espanglish = "Español" Then
                            MsgBox("Llave Criptografica Agregada Correctamente!" & vbCrLf & "Vuelva a Iniciar la Aplicacion", MsgBoxStyle.Information, "Worcome Security")
                        ElseIf My.Settings.Espanglish = "English" Then
                            MsgBox("Cryptographic Key Added Correctly!" & vbCrLf & "Restart the Application", MsgBoxStyle.Information, "Worcome Security")
                        End If
                        FileBox.Close()
                    End If
                Else
                    If My.Settings.Espanglish = "Español" Then
                        MsgBox("El Correo no coincide con el Registrado" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf My.Settings.Espanglish = "English" Then
                        MsgBox("The Mail does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    FileBox.Close()
                End If
            Else
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("La Contraseña no coincide con la Registrada" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("The Password does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
                End If
                FileBox.Close()
            End If
        Else
            If My.Settings.Espanglish = "Español" Then
                MsgBox("El Nombre de Usuario no coincide con el Registrado" & vbCrLf & "FileBox se Cerrara", MsgBoxStyle.Critical, "Worcome Security")
            ElseIf My.Settings.Espanglish = "English" Then
                MsgBox("The User Name does not match the Registered" & vbCrLf & "FileBox will close", MsgBoxStyle.Critical, "Worcome Security")
            End If
            FileBox.Close()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            My.Settings.OnlyMe = True
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            My.Settings.OnlyMe = False
        End If
        My.Settings.Save()
        My.Settings.Reload()
    End Sub
End Class
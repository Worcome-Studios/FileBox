Public Class SignIN
    Public SignINSecureClose As Boolean = False
    Dim TresAgain As Integer

    Private Sub SignIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Focus()
        TextBox1.Focus()
    End Sub

    Private Sub SignIN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If SignINSecureClose = True Then

        ElseIf SignINSecureClose = False Then
            Debugger.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TresAgain > 3 Then
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("Alcanzo el maximo de Intentos", MsgBoxStyle.Exclamation, "Worcome Security")
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("Reached the maximum of Attempts", MsgBoxStyle.Exclamation, "Worcome Security")
                End If
                End
            End If
            If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("Rellene con la informacion solicitada", MsgBoxStyle.Exclamation, "Worcome Security")
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("Fill in the requested information", MsgBoxStyle.Exclamation, "Worcome Security")
                End If
            Else
                If TextBox1.Text = Debugger.Login_Username And TextBox2.Text = Debugger.Login_Password Then
                    SignINSecureClose = True
                    Me.Hide()
                    Debugger.SignInPassed()
                Else
                    TresAgain = TresAgain + 1
                    If My.Settings.Espanglish = "Español" Then
                        MsgBox("Los datos no coinciden con el Registro", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf My.Settings.Espanglish = "English" Then
                        MsgBox("The data does not match the Registry", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Focus()
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("[SignIN@Button1_Click]Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        If TextBox2.PasswordChar = "●" Then
            TextBox2.PasswordChar = Nothing
        Else
            TextBox2.PasswordChar = "●"
        End If
    End Sub

    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles Label3.MouseEnter
        If My.Settings.Espanglish = "Español" Then
            Label3.Text = "Ver Contraseña"
        ElseIf My.Settings.Espanglish = "English" Then
            Label3.Text = "Show Password"
        End If
    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        If My.Settings.Espanglish = "Español" Then
            Label3.Text = "Contraseña"
        ElseIf My.Settings.Espanglish = "English" Then
            Label3.Text = "Password"
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class
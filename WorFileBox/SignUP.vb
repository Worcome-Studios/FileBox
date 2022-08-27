Public Class SignUP
    Public SignUPSecureClose As Boolean = False

    Private Sub SignUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SignUP_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If SignUPSecureClose = True Then

        ElseIf SignUPSecureClose = False Then
            Debugger.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Then
                If My.Settings.Espanglish = "Español" Then
                    MsgBox("Rellene con la informacion solicitada", MsgBoxStyle.Exclamation, "Worcome Security")
                ElseIf My.Settings.Espanglish = "English" Then
                    MsgBox("Fill in the requested information", MsgBoxStyle.Exclamation, "Worcome Security")
                End If
            Else
                SignUPSecureClose = True
                Debugger.Login_Username = TextBox1.Text
                Debugger.Login_Password = TextBox2.Text
                Debugger.Login_Email = TextBox3.Text
                Debugger.IsRegistered = "True"
                Debugger.SaveData()
                My.Settings.Save()
                My.Settings.Reload()
                Me.Hide()
                Debugger.SignUpPassed()
            End If
        Catch ex As Exception
            Console.WriteLine("[SignUP@Button1_Click]Error: " & ex.Message)
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
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class
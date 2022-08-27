Public Class ActionConfirm
    Dim Data As String

    Private Sub ActionConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub

    Sub Target(ByVal Dato As String)
        Try
            Data = Dato
            If Dato = Debugger.Login_Password Then
                Label3.Text = "Ingrese su Contraseña"
            ElseIf Dato = Debugger.Login_Username Then
                Label3.Text = "Ingrese su Nombre"
            ElseIf Dato = Debugger.Login_Email Then
                Label3.Text = "Ingrese su Correo"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = Nothing Then
            MsgBox("Rellene con al informacion solicitada", MsgBoxStyle.Critical, "Worcome Security")
            TextBox1.Focus()
        Else
            If TextBox1.Text = Data Then
                TextBox1.Clear()
                Label3.Text = "Ingrese la informacion"
                Me.Close()
            Else
                TextBox1.Clear()
                MsgBox("La informacion ingresada no coincide con el registro", MsgBoxStyle.Critical, "Worcome Security")
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class
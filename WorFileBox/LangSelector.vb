Public Class LangSelector

    Private Sub LangSelector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DomainUpDown1.Text = "Idioma / Language" Then
            MsgBox("Elige un Idioma" & vbCrLf & "Select a Language", MsgBoxStyle.Critical, "Worcome Security")
        Else
            If DomainUpDown1.SelectedItem = "Español(España)" Then
                Idioma.Español.LANG_Español()
                My.Settings.Espanglish = "Español"
            ElseIf DomainUpDown1.SelectedItem = "English(Unites States)" Then
                Idioma.Ingles.LANG_English()
                My.Settings.Espanglish = "English"
            End If
            My.Settings.Save()
            My.Settings.Reload()
            Me.Close()
        End If
    End Sub
End Class
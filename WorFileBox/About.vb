Public Class About

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.OfflineMode = True Then
            CheckBox1.CheckState = CheckState.Checked
        Else
            CheckBox1.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        AppSupport.Show()
        AppSupport.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AppUpdate.Show()
        AppUpdate.Focus()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If My.Settings.Espanglish = "Español" Then
            If MessageBox.Show("¿Quieres ver los Avisos de Seguridad?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                MsgBox("Avisos de Seguridad 1/3" & vbCrLf & "La Aplicacion tiene un 'Kernel' muy miedoso, por lo cual, ante cualquier problema o accion dudosa no dudara en cerrar todo para cumplir su objetivo de Proteger tus Archivos", MsgBoxStyle.Information, "Worcome Security")
                MsgBox("Avisos de Seguridad 2/3" & vbCrLf & "Se recomienda hacer copias de seguridad cada mes, esto evitara cualquier problema a largo plazo, y tambien anota tu llave criptografica en un Papel, ya que eso si es seguro!", MsgBoxStyle.Information, "Worcome Security")
                MsgBox("Avisos de Seguridad 3/3" & vbCrLf & "Activa el modulo 'OnlyMe', esto evitara que otra version de FileBox pueda acceder a tus Archivos (Activalo desde el fomulario de 'Llave Criptografica')", MsgBoxStyle.Information, "Worcome Security")
            End If
        ElseIf My.Settings.Espanglish = "English" Then
            If MessageBox.Show("Do you want to see the Security Notices?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                MsgBox("Safety notices 1/3" & vbCrLf & "The application has a very scary 'Kernel', so, in case of any problem or doubtful action, it will not hesitate to close everything to fulfill its objective of Protecting your Files", MsgBoxStyle.Information, "Worcome Security")
                MsgBox("Safety notices 2/3" & vbCrLf & "It is recommended to make backup copies every month, this will avoid any long-term problems, and also write down your cryptographic key in a paper, since that is safe!", MsgBoxStyle.Information, "Worcome Security")
                MsgBox("Safety notices 3/3" & vbCrLf & "Activate the 'OnlyMe' module, this will prevent another version of FileBox from accessing your Files (Activate it from the 'Cryptographic Key' form)", MsgBoxStyle.Information, "Worcome Security")
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            My.Settings.OfflineMode = True
        Else
            My.Settings.OfflineMode = False
        End If
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        AppHelper.Show()
        AppHelper.Focus()
    End Sub
End Class
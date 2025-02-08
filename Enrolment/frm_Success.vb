Public Class frm_Success

    Private Sub frm_Success_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblName.Text = memUserName
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class
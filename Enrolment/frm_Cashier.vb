Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frm_Cashier
    Dim isLogout As Integer = 0

    Private Sub frm_Cashier_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If isLogout = 0 Then
            Application.Exit()
        End If
    End Sub

    Private Sub frm_Cashier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim homechild As New frm_Success
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()


        Me.Text = "Cashier - " & memUserName

        Dim homechild2 As New frm_CashierQueue
        homechild2.MdiParent = Me
        homechild2.Dock = DockStyle.None
        homechild2.Show()

        LoadSettings()
        ToolStripStatusLabelUser.Text = memUser
        ToolStripStatusLabelSYsemester.Text = memSemester & " - " & memSY

    End Sub

    Private Sub LoadSettings()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_settings where fld_id=1"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                memSY = reader.GetString("fld_currentSY")
                memSemester = reader.GetString("fld_currentSem")
            End While
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SignoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignoutToolStripMenuItem.Click
        Login_Form.Show()
        Login_Form.TextBoxUsername.Text = ""
        Login_Form.TextBoxPassword.Text = ""
        Login_Form.TextBoxUsername.Focus()
        isLogout = 1
        Me.Close()
    End Sub
End Class
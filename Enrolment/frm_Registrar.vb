Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frm_Registrar
    Dim isLogout As Integer = 0
    Private Sub frm_Registrar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If isLogout = 0 Then
            Application.Exit()
        End If

    End Sub

    Private Sub frm_Registrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim homechild As New frm_Success
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()
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

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Login_Form.Show()
        Login_Form.TextBoxUsername.Text = ""
        Login_Form.TextBoxPassword.Text = ""
        Login_Form.TextBoxUsername.Focus()
        isLogout = 1
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub EnrollmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnrollmentToolStripMenuItem.Click
        Dim homechild As New frm_DialogBoxOldNew
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()
    End Sub

    Private Sub DataEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataEntryToolStripMenuItem.Click
        Dim homechild As New frm_preferences
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()
    End Sub

    Private Sub SubjectsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubjectsToolStripMenuItem.Click
        Dim homechild As New frm_CourseSubjects
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()
    End Sub

    Private Sub EnrollmentFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim homechild As New frm_ReportAllEnrollmentForm
        'homechild.MdiParent = Me
        'homechild.Dock = DockStyle.None
        'homechild.Show()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StudentToolStripMenuItem.Click
        Dim homechild As New frm_Students
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()
    End Sub

    Private Sub ListOfStudentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfStudentsToolStripMenuItem.Click
        Dim homechild As New frm_ReportStudents
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()
    End Sub

    Private Sub CurriculumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurriculumToolStripMenuItem.Click
        Dim homechild As New frm_ReportCurriculumvb
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()
    End Sub

    Private Sub EnrollmentFormsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnrollmentFormsToolStripMenuItem.Click
        Dim homechild As New frm_ReportAllEnrollmentForm
        homechild.MdiParent = Me
        homechild.Dock = DockStyle.None
        homechild.Show()
    End Sub
End Class
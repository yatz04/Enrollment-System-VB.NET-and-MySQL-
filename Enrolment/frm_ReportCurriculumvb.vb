Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports Microsoft.Reporting.WinForms

Public Class frm_ReportCurriculumvb
    Dim xxCourseID As String

    Private Sub frm_ReportCurriculumvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'db_enrollmentDataSet4.tbl_coursesubject' table. You can move, or remove it, as needed.
        'Me.tbl_coursesubjectTableAdapter.Fill(Me.db_enrollmentDataSet4.tbl_coursesubject)

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.ZoomMode.PageWidth)

        Dim rptparameterCourse As ReportParameter
        rptparameterCourse = New ReportParameter("ReportParameterCourse", "")
        Me.ReportViewer1.LocalReport.SetParameters(rptparameterCourse)

        Dim rptparameterMajor As ReportParameter
        rptparameterMajor = New ReportParameter("ReportParameterMajor", "")
        Me.ReportViewer1.LocalReport.SetParameters(rptparameterMajor)

        Me.ReportViewer1.RefreshReport()
        ReportViewer1.ZoomMode = ZoomMode.PageWidth

        LoadComboCourse()
        LoadComboMajor()
        'Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub HeaderPo()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.ZoomMode.PageWidth)

        Dim rptparameterCourse As ReportParameter
        rptparameterCourse = New ReportParameter("ReportParameterCourse", ComboCourse.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterCourse)

        Dim rptparameterMajor As ReportParameter
        rptparameterMajor = New ReportParameter("ReportParameterMajor", ComboMajor.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterMajor)

        Me.ReportViewer1.RefreshReport()
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        'ReportViewer1.ZoomPercent = 100
    End Sub

    Private Sub LoadComboCourse()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_Course"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                ComboCourse.Items.Add(reader.GetString("fld_CourseID") & " - " & reader.GetString("fld_Course"))
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadComboMajor()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_major"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                ComboMajor.Items.Add(reader.GetString("fld_Major"))
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadCurriculum()
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_coursesubject WHERE fld_CourseID='" & xxCourseID & "' AND fld_MajorCode='" & ComboMajor.Text & "' ORDER BY fld_CourseCode ASC"
            
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(query, conn)
            Dim ds As DataSet = New DataSet
            da.Fill(ds)
            ReportViewer1.LocalReport.DataSources.Clear()
            Dim rds As New Microsoft.Reporting.WinForms.ReportDataSource("dsCurriculum", ds.Tables(0))
            ReportViewer1.LocalReport.DataSources.Add(rds)

            ReportViewer1.RefreshReport()
            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.ZoomMode.PageWidth)
            ReportViewer1.ZoomMode = ZoomMode.PageWidth
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ComboCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCourse.SelectedIndexChanged
        Dim SearchForThis As String = " - "
        Dim FirstCharacter As Integer = ComboCourse.Text.IndexOf(SearchForThis)
        Dim findID As String = Mid(ComboCourse.Text, 1, FirstCharacter)
        xxCourseID = findID

        HeaderPo()
        LoadCurriculum()
    End Sub

    Private Sub ComboMajor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMajor.SelectedIndexChanged
        HeaderPo()
        LoadCurriculum()
    End Sub
End Class
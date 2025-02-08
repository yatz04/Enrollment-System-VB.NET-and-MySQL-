Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports Microsoft.Reporting.WinForms
Public Class frm_ReportStudents
    Dim xxSY As String
    Dim xxSem As String
    Dim xxCourseID As String

    Private Sub frm_ReportStudents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'db_enrollmentDataSet3.tbl_enrollment' table. You can move, or remove it, as needed.
        LoadSettings()
        HeaderPo()

        LoadComboCourse()
        LoadComboMajor()

        'Me.tbl_enrollmentTableAdapter.Fill(Me.db_enrollmentDataSet3.tbl_enrollment)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub HeaderPo()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.ZoomMode.PageWidth)

        Dim rptparameterSY As ReportParameter
        rptparameterSY = New ReportParameter("ReportParameterSY", "Academic Year " & xxSY)
        ReportViewer1.LocalReport.SetParameters(rptparameterSY)

        Dim rptparameterSemester As ReportParameter
        rptparameterSemester = New ReportParameter("ReportParameterSemester", xxSem & " Semester")
        ReportViewer1.LocalReport.SetParameters(rptparameterSemester)

        Me.ReportViewer1.RefreshReport()
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        'ReportViewer1.ZoomPercent = 100
    End Sub

    Private Sub LoadSettings()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_settings where fld_id=1"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                xxSY = reader.GetString("fld_currentSY")
                xxSem = reader.GetString("fld_currentSem")
            End While
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadEnrolledStudent()
        Try
            conn.Open()
            Dim query As String
            'Dim cmd As New MySqlCommand
            'Dim ta As New MySqlDataAdapter
            'Dim dt As New DataTable

            query = "SELECT * FROM tbl_enrollment WHERE fld_CourseID='" & xxCourseID & "' AND fld_Major='" & ComboMajor.Text & "' AND fld_Year='" & ComboYearLevel.Text & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
            'cmd = New MySqlCommand(query, conn)
            'ta = New MySqlDataAdapter(cmd)
            'ta.Fill(dt)
            'With Me.ReportViewer1.LocalReport
            '    .DataSources.Clear()
            '    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            'End With

            Dim da As MySqlDataAdapter = New MySqlDataAdapter(query, conn)
            Dim ds As DataSet = New DataSet
            da.Fill(ds)
            ReportViewer1.LocalReport.DataSources.Clear()
            Dim rds As New Microsoft.Reporting.WinForms.ReportDataSource("dsStudents", ds.Tables(0))
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

    Private Sub GetDeptHead()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT tbl_Course.fld_CourseID, tbl_Course.fld_Course, tbl_Course.fld_DepartmentID, tbl_Department.fld_DepartmentHead "
            query = query & "FROM tbl_Department INNER JOIN tbl_Course ON tbl_Department.fld_DepartmentID = tbl_Course.fld_DepartmentID "
            query = query & "WHERE tbl_Course.fld_CourseID='" & xxCourseID & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                Dim rptparameterDepartment As ReportParameter
                rptparameterDepartment = New ReportParameter("ReportParameterDepartment", reader.GetString("fld_DepartmentID"))
                ReportViewer1.LocalReport.SetParameters(rptparameterDepartment)

                Dim rptparameterHead As ReportParameter
                rptparameterHead = New ReportParameter("ReportParameterHead", reader.GetString("fld_DepartmentHead"))
                ReportViewer1.LocalReport.SetParameters(rptparameterHead)

                Me.ReportViewer1.RefreshReport()
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
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

    Private Sub ComboCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCourse.SelectedIndexChanged
        Dim SearchForThis As String = " - "
        Dim FirstCharacter As Integer = ComboCourse.Text.IndexOf(SearchForThis)
        Dim findID As String = Mid(ComboCourse.Text, 1, FirstCharacter)
        xxCourseID = findID

        HeaderPo()
        Dim rptparameterCourse As ReportParameter
        rptparameterCourse = New ReportParameter("ReportParameterCourse", ComboCourse.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterCourse)

        Dim rptparameterMajor As ReportParameter
        rptparameterMajor = New ReportParameter("ReportParameterMajor", ComboMajor.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterMajor)

        Dim rptparameterYearLevel As ReportParameter
        rptparameterYearLevel = New ReportParameter("ReportParameterYearLevel", ComboYearLevel.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterYearLevel)

        Me.ReportViewer1.RefreshReport()
        GetDeptHead()
        LoadEnrolledStudent()
    End Sub

    Private Sub ComboYearLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboYearLevel.SelectedIndexChanged
        HeaderPo()
        Dim rptparameterCourse As ReportParameter
        rptparameterCourse = New ReportParameter("ReportParameterCourse", ComboCourse.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterCourse)

        Dim rptparameterMajor As ReportParameter
        rptparameterMajor = New ReportParameter("ReportParameterMajor", ComboMajor.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterMajor)

        Dim rptparameterYearLevel As ReportParameter
        rptparameterYearLevel = New ReportParameter("ReportParameterYearLevel", ComboYearLevel.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterYearLevel)

        Me.ReportViewer1.RefreshReport()
        GetDeptHead()
        LoadEnrolledStudent()
    End Sub

    Private Sub ComboMajor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMajor.SelectedIndexChanged
        HeaderPo()
        Dim rptparameterCourse As ReportParameter
        rptparameterCourse = New ReportParameter("ReportParameterCourse", ComboCourse.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterCourse)

        Dim rptparameterMajor As ReportParameter
        rptparameterMajor = New ReportParameter("ReportParameterMajor", ComboMajor.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterMajor)

        Dim rptparameterYearLevel As ReportParameter
        rptparameterYearLevel = New ReportParameter("ReportParameterYearLevel", ComboYearLevel.Text)
        ReportViewer1.LocalReport.SetParameters(rptparameterYearLevel)

        Me.ReportViewer1.RefreshReport()
        GetDeptHead()
        LoadEnrolledStudent()
    End Sub
End Class
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports Microsoft.Reporting.WinForms

Public Class frm_ReportEnrollment
    Dim xxSY As String
    Dim xxSem As String
    Dim xxCourseID As String
    Private Sub frm_ReportEnrollment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'db_enrollmentDataSet1.temp_table' table. You can move, or remove it, as needed.
        'Me.temp_tableTableAdapter.Fill(Me.db_enrollmentDataSet1.temp_table)
        'TODO: This line of code loads data into the 'db_enrollmentDataSet2.tbl_accounts' table. You can move, or remove it, as needed.
        'Me.tbl_accountsTableAdapter.Fill(Me.db_enrollmentDataSet2.tbl_accounts)
        'TODO: This line of code loads data into the 'db_enrollmentDataSet.tbl_enrollment' table. You can move, or remove it, as needed.
        'Me.tbl_enrollmentTableAdapter.Fill(Me.db_enrollmentDataSet.tbl_enrollment)
        ''TODO: This line of code loads data into the 'db_enrollmentDataSet.tbl_subjects' table. You can move, or remove it, as needed.
        'Me.tbl_subjectsTableAdapter.Fill(Me.db_enrollmentDataSet.tbl_subjects)

        LoadSettings()
        Me.ReportViewerEnrollment.SetDisplayMode(Microsoft.Reporting.WinForms.ZoomMode.PageWidth)

        Dim rptparameterSY As ReportParameter
        rptparameterSY = New ReportParameter("ReportParameterSchoolYear", xxSY)
        Me.ReportViewerEnrollment.LocalReport.SetParameters(rptparameterSY)

        Dim rptparameterSemester As ReportParameter
        rptparameterSemester = New ReportParameter("ReportParameterSemester", xxSem)
        Me.ReportViewerEnrollment.LocalReport.SetParameters(rptparameterSemester)

        Me.ReportViewerEnrollment.RefreshReport()

        LoadEnrolledStudent(memIDNO)
        LoadData(memIDNO)
        GetDeptHead()
        GetSignatory()
        GetContactPerson(memIDNO)
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

    Private Sub LoadEnrolledStudent(ByVal findID As String)
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_enrollment INNER JOIN tbl_course ON tbl_Enrollment.fld_CourseID=tbl_Course.fld_CourseID WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
            'fld_ContactPerson`, `fld_ContactAddress`, `fld_ContactRelationship`, `fld_ContactCP`
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            'If reader.HasRows Then
            While reader.Read
                'xxDeptID = reader.GetString("fld_DepartmentID")

                Dim xRegular As String
                If reader.GetString("fld_Type") = 0 Then
                    xRegular = "Regular Student"
                Else
                    xRegular = "Irregular Student"
                End If
                Dim rptparameterRegular As ReportParameter
                rptparameterRegular = New ReportParameter("ReportParameterRegular", xRegular)
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterRegular)

                Dim xNewOld As String
                If reader.GetString("fld_NewOld") = 0 Then
                    xNewOld = "OLD"
                Else
                    xNewOld = "NEW"
                End If
                Dim rptparameterOldNew As ReportParameter
                rptparameterOldNew = New ReportParameter("ReportParameterType", xNewOld)
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterOldNew)

                Dim rptparameterID As ReportParameter
                rptparameterID = New ReportParameter("ReportParameterIDNO", findID)
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterID)
                Dim xName As String
                If reader.GetString("fld_Ext") = "" Then
                    xname = UCase(reader.GetString("fld_Lastname")) & ", " & reader.GetString("fld_Firstname") & " " & reader.GetString("fld_Middlename")
                Else
                    xname = UCase(reader.GetString("fld_Lastname")) & ", " & reader.GetString("fld_Firstname") & " " & reader.GetString("fld_Ext") & " " & reader.GetString("fld_Middlename")
                End If
                Dim rptparameterName As ReportParameter
                rptparameterName = New ReportParameter("ReportParameterName", xName)
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterName)

                Dim xStudentSignature As String
                If reader.GetString("fld_Middlename") = "" Then
                    xStudentSignature = UCase(reader.GetString("fld_Firstname") & " " & reader.GetString("fld_Lastname") & " " & reader.GetString("fld_Ext"))
                Else
                    xStudentSignature = UCase(reader.GetString("fld_Firstname") & " " & Mid(reader.GetString("fld_Middlename"), 1, 1) & ". " & reader.GetString("fld_Lastname") & " " & reader.GetString("fld_Ext"))
                End If
                Dim rptparameterStudentSignature As ReportParameter
                rptparameterStudentSignature = New ReportParameter("ReportParameterStudentSignature", xStudentSignature)
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterStudentSignature)

                xxCourseID = reader.GetString("fld_CourseID")
                Dim xCourse As String = reader.GetString("fld_CourseID") & " - " & reader.GetString("fld_Course")
                Dim rptparameterCourse As ReportParameter
                rptparameterCourse = New ReportParameter("ReportParameterCourse", xCourse)
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterCourse)

                Dim rptparameterMajor As ReportParameter
                rptparameterMajor = New ReportParameter("ReportParameterMajor", reader.GetString("fld_Major"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterMajor)

                Dim rptparameterYRLevel As ReportParameter
                rptparameterYRLevel = New ReportParameter("ReportParameterYearLevel", reader.GetString("fld_Year"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterYRLevel)

                Dim xdate As String = reader.GetString("fld_DateEnrolled")
                Dim rptparameterDate As ReportParameter
                rptparameterDate = New ReportParameter("ReportParameterDate", xdate)
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterDate)

                Me.ReportViewerEnrollment.RefreshReport()
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadData(ByVal findID As String)
        conn.Open()

        Dim cmd As New MySqlCommand
        Dim ta As New MySqlDataAdapter
        Dim dt As New DataTable

        Dim query1, query2 As String
        query1 = "SELECT fld_CourseCode, fld_CourseDescription, fld_Lec, fld_Lab, fld_Units FROM tbl_enrolledsubjects WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
        query2 = "SELECT fld_fees, fld_Amount FROM tbl_accounts WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"

        ' create a data adaptor
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(query1, conn)
        ' create a new data set
        Dim ds As DataSet = New DataSet
        ' fill the data adapter
        da.Fill(ds)
        ' clear the datasource
        ReportViewerEnrollment.LocalReport.DataSources.Clear()
        ' set the dataource (DataSet1 is defined in the matrix in the rdlc file)
        Dim rds1 As New Microsoft.Reporting.WinForms.ReportDataSource("dsEnrollment", ds.Tables(0))
        ' add a new datasource
        ReportViewerEnrollment.LocalReport.DataSources.Add(rds1)

        ' second table on one report
        Dim da2 As MySqlDataAdapter = New MySqlDataAdapter(query2, conn)
        Dim ds2 As DataSet = New DataSet
        da2.Fill(ds2)
        Dim rds2 As New Microsoft.Reporting.WinForms.ReportDataSource("dsAccount", ds2.Tables(0))
        ReportViewerEnrollment.LocalReport.DataSources.Add(rds2)

        ReportViewerEnrollment.RefreshReport()
        Me.ReportViewerEnrollment.SetDisplayMode(Microsoft.Reporting.WinForms.ZoomMode.PageWidth)
        conn.Close()
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

                Dim rptparameterSignatoryDeptCoor As ReportParameter
                rptparameterSignatoryDeptCoor = New ReportParameter("ReportParameterSignatoryDeptCoor", reader.GetString("fld_DepartmentHead"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterSignatoryDeptCoor)

                Me.ReportViewerEnrollment.RefreshReport()
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub GetSignatory()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_signatories WHERE fld_SigPosition='Cashier'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                Dim rptparameterSignatoryCashier As ReportParameter
                rptparameterSignatoryCashier = New ReportParameter("ReportParameterSignatoryCashier", reader.GetString("fld_SigName"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterSignatoryCashier)
            End While
            cmd.Dispose()
            reader.Close()
            query = "SELECT * FROM tbl_signatories WHERE fld_SigPosition='Registrar'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                Dim rptparameterSignatoryRegistrar As ReportParameter
                rptparameterSignatoryRegistrar = New ReportParameter("ReportParameterSignatoryRegistrar", reader.GetString("fld_SigName"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterSignatoryRegistrar)
            End While
            Me.ReportViewerEnrollment.RefreshReport()

            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub GetContactPerson(ByVal findID As String)
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT fld_ContactPerson, fld_ContactAddress, fld_ContactRelationship, fld_ContactCP FROM tbl_students WHERE fld_IDno='" & findID & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read

                Dim rptparameterContactPerson As ReportParameter
                rptparameterContactPerson = New ReportParameter("ReportParameterContactName", reader.GetString("fld_ContactPerson"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterContactPerson)

                Dim rptparameterContactAddress As ReportParameter
                rptparameterContactAddress = New ReportParameter("ReportParameterContactAddress", reader.GetString("fld_ContactAddress"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterContactAddress)

                Dim rptparameterContactRelationship As ReportParameter
                rptparameterContactRelationship = New ReportParameter("ReportParameterContactRelationship", reader.GetString("fld_ContactRelationship"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterContactRelationship)

                Dim rptparameterContactCP As ReportParameter
                rptparameterContactCP = New ReportParameter("ReportParameterContactNo", reader.GetString("fld_ContactCP"))
                ReportViewerEnrollment.LocalReport.SetParameters(rptparameterContactCP)

                Me.ReportViewerEnrollment.RefreshReport()
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

End Class
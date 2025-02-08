Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports Microsoft.Reporting.WinForms

Public Class frm_ReportAllEnrollmentForm
    Dim xxSY As String
    Dim xxSem As String
    Dim xxCourseID As String

    Private Sub frm_ReportAllEnrollmentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'db_enrollmentDataSet1.temp_table' table. You can move, or remove it, as needed.
        'Me.temp_tableTableAdapter.Fill(Me.db_enrollmentDataSet1.temp_table)
        'TODO: This line of code loads data into the 'db_enrollmentDataSet2.tbl_accounts' table. You can move, or remove it, as needed.
        'Me.tbl_accountsTableAdapter.Fill(Me.db_enrollmentDataSet2.tbl_accounts)

        'LoadSettings()
        'Me.ReportViewerAll.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

        'Dim rptparameterSY As ReportParameter
        'rptparameterSY = New ReportParameter("ReportParameterSchoolYear", xxSY)
        'ReportViewerAll.LocalReport.SetParameters(rptparameterSY)

        'Dim rptparameterSemester As ReportParameter
        'rptparameterSemester = New ReportParameter("ReportParameterSemester", xxSem)
        'ReportViewerAll.LocalReport.SetParameters(rptparameterSemester)

        'Me.ReportViewerAll.RefreshReport()

        'LoadEnrolledStudent()
        ''LoadData(memIDNO)
        'GetDeptHead()
        'GetSignatory()
        ''GetContactPerson(memIDNO)
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
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader
            Dim xxIDno As String = ""
            query = "SELECT * FROM tbl_enrollment INNER JOIN tbl_course ON tbl_Enrollment.fld_CourseID=tbl_Course.fld_CourseID WHERE fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            'If reader.HasRows Then
            While reader.Read

                Dim xRegular As String
                If reader.GetString("fld_Type") = 0 Then
                    xRegular = "Regular Student"
                Else
                    xRegular = "Irregular Student"
                End If
                Dim rptparameterRegular As ReportParameter
                rptparameterRegular = New ReportParameter("ReportParameterRegular", xRegular)
                ReportViewerAll.LocalReport.SetParameters(rptparameterRegular)

                Dim xNewOld As String
                If reader.GetString("fld_NewOld") = 0 Then
                    xNewOld = "OLD"
                Else
                    xNewOld = "NEW"
                End If
                Dim rptparameterOldNew As ReportParameter
                rptparameterOldNew = New ReportParameter("ReportParameterType", xNewOld)
                ReportViewerAll.LocalReport.SetParameters(rptparameterOldNew)

                xxIDno = reader.GetString("fld_IDno")
                Dim rptparameterID As ReportParameter
                rptparameterID = New ReportParameter("ReportParameterIDNO", xxIDno)
                ReportViewerAll.LocalReport.SetParameters(rptparameterID)
                Dim xName As String
                If reader.GetString("fld_Ext") = "" Then
                    xName = UCase(reader.GetString("fld_Lastname")) & ", " & reader.GetString("fld_Firstname") & " " & reader.GetString("fld_Middlename")
                Else
                    xName = UCase(reader.GetString("fld_Lastname")) & ", " & reader.GetString("fld_Firstname") & " " & reader.GetString("fld_Ext") & " " & reader.GetString("fld_Middlename")
                End If
                Dim rptparameterName As ReportParameter
                rptparameterName = New ReportParameter("ReportParameterName", xName)
                ReportViewerAll.LocalReport.SetParameters(rptparameterName)

                Dim xStudentSignature As String
                If reader.GetString("fld_Middlename") = "" Then
                    xStudentSignature = UCase(reader.GetString("fld_Firstname") & " " & reader.GetString("fld_Lastname") & " " & reader.GetString("fld_Ext"))
                Else
                    xStudentSignature = UCase(reader.GetString("fld_Firstname") & " " & Mid(reader.GetString("fld_Middlename"), 1, 1) & ". " & reader.GetString("fld_Lastname") & " " & reader.GetString("fld_Ext"))
                End If
                Dim rptparameterStudentSignature As ReportParameter
                rptparameterStudentSignature = New ReportParameter("ReportParameterStudentSignature", xStudentSignature)
                ReportViewerAll.LocalReport.SetParameters(rptparameterStudentSignature)

                xxCourseID = reader.GetString("fld_CourseID")
                Dim xCourse As String = reader.GetString("fld_CourseID") & " - " & reader.GetString("fld_Course")
                Dim rptparameterCourse As ReportParameter
                rptparameterCourse = New ReportParameter("ReportParameterCourse", xCourse)
                ReportViewerAll.LocalReport.SetParameters(rptparameterCourse)

                Dim rptparameterMajor As ReportParameter
                rptparameterMajor = New ReportParameter("ReportParameterMajor", reader.GetString("fld_Major"))
                ReportViewerAll.LocalReport.SetParameters(rptparameterMajor)

                Dim rptparameterYRLevel As ReportParameter
                rptparameterYRLevel = New ReportParameter("ReportParameterYearLevel", reader.GetString("fld_Year"))
                ReportViewerAll.LocalReport.SetParameters(rptparameterYRLevel)

                Dim xdate As String = reader.GetString("fld_DateEnrolled")
                Dim rptparameterDate As ReportParameter
                rptparameterDate = New ReportParameter("ReportParameterDate", xdate)
                ReportViewerAll.LocalReport.SetParameters(rptparameterDate)


                LoadData(xxIDno)
                GetContactPerson(xxIDno)

                Me.ReportViewerAll.RefreshReport()
                'PrintDocument1.Print()
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadData(ByVal findID As String)
        Dim Connectionstring As New MySqlConnection("Database=db_enrollment;Data Source=localhost;UserID=adminwaa;password=waaskul2019")

        Connectionstring.Open()

        Dim cmd As New MySqlCommand
        Dim ta As New MySqlDataAdapter
        Dim dt As New DataTable

        Dim query1, query2 As String
        query1 = "SELECT fld_CourseCode, fld_CourseDescription, fld_Lec, fld_Lab, fld_Units FROM tbl_enrolledsubjects WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
        query2 = "SELECT fld_fees, fld_Amount FROM tbl_accounts WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"

        ' create a data adaptor
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(query1, Connectionstring)
        ' create a new data set
        Dim ds As DataSet = New DataSet
        ' fill the data adapter
        da.Fill(ds)
        ' clear the datasource
        ReportViewerAll.LocalReport.DataSources.Clear()
        ' set the dataource (DataSet1 is defined in the matrix in the rdlc file)
        Dim rds1 As New Microsoft.Reporting.WinForms.ReportDataSource("dsEnrollment", ds.Tables(0))
        ' add a new datasource
        ReportViewerAll.LocalReport.DataSources.Add(rds1)

        ' second table on one report
        Dim da2 As MySqlDataAdapter = New MySqlDataAdapter(query2, Connectionstring)
        Dim ds2 As DataSet = New DataSet
        da2.Fill(ds2)
        Dim rds2 As New Microsoft.Reporting.WinForms.ReportDataSource("dsAccount", ds2.Tables(0))
        ReportViewerAll.LocalReport.DataSources.Add(rds2)

        ReportViewerAll.RefreshReport()
        Me.ReportViewerAll.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Connectionstring.Close()
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
                ReportViewerAll.LocalReport.SetParameters(rptparameterSignatoryDeptCoor)

                Me.ReportViewerAll.RefreshReport()
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
                ReportViewerAll.LocalReport.SetParameters(rptparameterSignatoryCashier)
            End While
            cmd.Dispose()
            reader.Close()
            query = "SELECT * FROM tbl_signatories WHERE fld_SigPosition='Registrar'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                Dim rptparameterSignatoryRegistrar As ReportParameter
                rptparameterSignatoryRegistrar = New ReportParameter("ReportParameterSignatoryRegistrar", reader.GetString("fld_SigName"))
                ReportViewerAll.LocalReport.SetParameters(rptparameterSignatoryRegistrar)
            End While
            Me.ReportViewerAll.RefreshReport()

            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub GetContactPerson(ByVal findID As String)
        Dim Connectionstring As New MySqlConnection("Database=db_enrollment;Data Source=localhost;UserID=adminwaa;password=waaskul2019")

        Try
            Connectionstring.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT fld_ContactPerson, fld_ContactAddress, fld_ContactRelationship, fld_ContactCP FROM tbl_students WHERE fld_IDno='" & findID & "'"
            cmd = New MySqlCommand(query, Connectionstring)
            reader = cmd.ExecuteReader
            While reader.Read

                Dim rptparameterContactPerson As ReportParameter
                rptparameterContactPerson = New ReportParameter("ReportParameterContactName", reader.GetString("fld_ContactPerson"))
                ReportViewerAll.LocalReport.SetParameters(rptparameterContactPerson)

                Dim rptparameterContactAddress As ReportParameter
                rptparameterContactAddress = New ReportParameter("ReportParameterContactAddress", reader.GetString("fld_ContactAddress"))
                ReportViewerAll.LocalReport.SetParameters(rptparameterContactAddress)

                Dim rptparameterContactRelationship As ReportParameter
                rptparameterContactRelationship = New ReportParameter("ReportParameterContactRelationship", reader.GetString("fld_ContactRelationship"))
                ReportViewerAll.LocalReport.SetParameters(rptparameterContactRelationship)

                Dim rptparameterContactCP As ReportParameter
                rptparameterContactCP = New ReportParameter("ReportParameterContactNo", reader.GetString("fld_ContactCP"))
                ReportViewerAll.LocalReport.SetParameters(rptparameterContactCP)

                Me.ReportViewerAll.RefreshReport()
            End While
            Connectionstring.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            Connectionstring.Close()
        End Try
    End Sub

End Class
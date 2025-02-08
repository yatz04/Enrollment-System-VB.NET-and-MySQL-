Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frm_CourseSubjects
    Dim xxSY As String
    Dim xxSem As String
    Dim daSubjCourse As MySqlDataAdapter
    Dim dtSubjCourse As New DataSet
    Dim dtComboSubject As New DataTable
    Dim xrecno As Integer
    Dim kungMeUna As Boolean
    Private Sub frm_CourseSubjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadComboCourse()
        LoadComboMajor()
        LoadDataGridcomboSubject()
        LoadRecords()
    End Sub

    Private Sub LoadRecords()

        xrecno = 0
        Try
            conn.Open()
            Dim query As String
            'query = "SELECT fld_CourseCode FROM tbl_coursesubject WHERE fld_CourseID='" & ComboCourse.Text & "' AND fld_MajorCode='" & ComboMajor.Text & "' AND fld_YearLevel='" & ComboYearLevel.Text & "' AND fld_Semester='" & xxSem & "'"
            query = "SELECT tbl_CourseSubject.fld_CourseCode, tbl_Subjects.fld_CourseDescription, tbl_Subjects.fld_Lec, tbl_Subjects.fld_Lab, tbl_Subjects.fld_Units "
            query = query & "FROM tbl_CourseSubject INNER JOIN tbl_Subjects ON tbl_CourseSubject.fld_CourseCode = tbl_Subjects.fld_CourseCode "
            query = query & "WHERE fld_CourseID='" & ComboCourse.Text & "' AND fld_MajorCode='" & ComboMajor.Text & "' AND fld_YearLevel='" & ComboYearLevel.Text & "' AND fld_Semester='" & ComboSemester.Text & "'"
            daSubjCourse = New MySqlDataAdapter(query, conn)
            'xrecno = daSubjCourse.
            dtSubjCourse.Clear()
            daSubjCourse.Fill(dtSubjCourse)
            xrecno = dtSubjCourse.Tables(0).Rows.Count
            DataGridView1.DataSource = dtSubjCourse.Tables(0)


            Dim SubjectComboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
            With SubjectComboBoxColumn
                .HeaderText = "Course Code"
                .DataPropertyName = "fld_CourseCode"
                .DataSource = dtComboSubject
                .ValueMember = "fld_CourseCode"
                .DisplayMember = "fld_CourseCode"
            End With
            Me.DataGridView1.Columns.RemoveAt(0)
            Me.DataGridView1.Columns.Insert(0, SubjectComboBoxColumn)

            DataGridView1.Columns(0).Width = 150
            DataGridView1.Columns(0).HeaderText = "Course Code"
            DataGridView1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridView1.Columns(1).Width = 350
            DataGridView1.Columns(1).HeaderText = "Subject"
            DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(2).HeaderText = "Lec"
            DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(3).HeaderText = "Lab"
            DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(4).Width = 100
            DataGridView1.Columns(4).HeaderText = "Units"
            DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadDataGridcomboSubject()
        dtComboSubject = New DataTable
        Try
            conn.Open()
            Dim query As String
            Dim adapter As New MySqlDataAdapter()

            query = "SELECT fld_CourseCode FROM tbl_Subjects"
            adapter = New MySqlDataAdapter(query, conn)
            adapter.Fill(dtComboSubject)
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ComboCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCourse.SelectedIndexChanged
        LoadRecords()
    End Sub

    Private Sub ComboMajor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMajor.SelectedIndexChanged
        LoadRecords()
    End Sub

    Private Sub ComboYearLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboYearLevel.SelectedIndexChanged
        LoadRecords()
    End Sub

    Private Sub LoadComboCourse()
        ComboCourse.Items.Clear()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_Course"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                ComboCourse.Items.Add(reader.GetString("fld_CourseID"))
            End While
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadComboMajor()
        ComboMajor.Items.Clear()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_Major WHERE fld_CourseID='" & ComboCourse.Text & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                ComboMajor.Items.Add(reader.GetString("fld_MajorCode"))
            End While
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If Not IsDBNull(DataGridView1.Rows(i).Cells(0).Value) Then
                Dim col1 As String = DataGridView1.Rows(i).Cells(0).Value
                'Dim col2 As String
                Try
                    conn.Open()
                    Dim query As String = ""
                    Dim cmd As New MySqlCommand
                    Dim reader As MySqlDataReader

                    query = "SELECT * FROM tbl_subjects WHERE fld_coursecode='" & col1 & "'"
                    cmd = New MySqlCommand(query, conn)
                    reader = cmd.ExecuteReader
                    While reader.Read
                        DataGridView1.Rows(i).Cells(1).Value = reader.GetString("fld_CourseDescription")
                        DataGridView1.Rows(i).Cells(2).Value = reader.GetString("fld_Lec")
                        DataGridView1.Rows(i).Cells(3).Value = reader.GetString("fld_Lab")
                        DataGridView1.Rows(i).Cells(4).Value = reader.GetString("fld_Units")
                    End While
                    conn.Close()
                Catch myerror As MySqlException
                    MessageBox.Show(myerror.Message)
                    conn.Close()
                End Try
            End If
        Next
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        CheckCurriculumExist()
        Try
            Dim cmd As New MySqlCommand
            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO tbl_coursesubject(fld_CourseID, fld_MajorCode, fld_YearLevel, fld_Semester, fld_CourseCode, fld_CourseDescription, fld_Lec, fld_Lab, fld_Units) VALUES (@xcourse, @xmajor, @xyrlevel, @xsemester, @xcoursecode, @xdescription, @xlec, @xlab, @xunits)"
            cmd.Parameters.Add("@xcourse", MySqlDbType.VarChar)
            cmd.Parameters.Add("@xmajor", MySqlDbType.VarChar)
            cmd.Parameters.Add("@xyrlevel", MySqlDbType.Int64)
            cmd.Parameters.Add("@xsemester", MySqlDbType.VarChar)
            cmd.Parameters.Add("@xcoursecode", MySqlDbType.VarChar)
            cmd.Parameters.Add("@xdescription", MySqlDbType.VarChar)
            cmd.Parameters.Add("@xlec", MySqlDbType.Decimal)
            cmd.Parameters.Add("@xlab", MySqlDbType.Decimal)
            cmd.Parameters.Add("@xunits", MySqlDbType.Decimal)

            conn.Open()

            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                'CheckRecordExist(i)
                'If kungMeUna = False Then

                cmd.Parameters(0).Value = ComboCourse.Text
                cmd.Parameters(1).Value = ComboMajor.Text
                cmd.Parameters(2).Value = ComboYearLevel.Text
                cmd.Parameters(3).Value = ComboSemester.Text
                cmd.Parameters(4).Value = DataGridView1.Rows(i).Cells(0).Value
                cmd.Parameters(5).Value = DataGridView1.Rows(i).Cells(1).Value
                cmd.Parameters(6).Value = DataGridView1.Rows(i).Cells(2).Value
                cmd.Parameters(7).Value = DataGridView1.Rows(i).Cells(3).Value
                cmd.Parameters(8).Value = DataGridView1.Rows(i).Cells(4).Value
                cmd.ExecuteNonQuery()
                'End If
            Next
            conn.Close()
            LoadRecords()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try

        
    End Sub

    Private Sub CheckCurriculumExist()
        Dim MeSueod As Boolean
        Dim dtxCurriculum As New DataTable
        Try
            conn.Open()

            Dim query As String = ""
            Dim adapter As New MySqlDataAdapter()
            'Dim cmd As New MySqlCommand
            'Dim reader As MySqlDataReader
            query = "SELECT * FROM tbl_coursesubject "
            query = query & "WHERE fld_CourseID='" & ComboCourse.Text & "' AND fld_MajorCode='" & ComboMajor.Text & "' AND fld_YearLevel='" & ComboYearLevel.Text & "' AND fld_Semester='" & ComboSemester.Text & "'"
            adapter = New MySqlDataAdapter(query, conn)
            adapter.Fill(dtxCurriculum)
            If dtxCurriculum.Rows.Count > 0 Then
                MeSueod = True
            Else
                MeSueod = False
            End If
            conn.Close()

            If MeSueod Then
                Dim query2 As String = ""
                query2 = "DELETE FROM tbl_coursesubject "
                query2 = query2 & "WHERE fld_CourseID='" & ComboCourse.Text & "' AND fld_MajorCode='" & ComboMajor.Text & "' AND fld_YearLevel='" & ComboYearLevel.Text & "' AND fld_Semester='" & ComboSemester.Text & "'"

                conn.Open()
                Dim cmd As New MySqlCommand
                cmd = New MySqlCommand(query2, conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            End If

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub CheckRecordExist(ByVal i As Integer)
        'Dim xcourse = DataGridView1.Rows(i).Cells(0).Value
        'Dim xmajor = DataGridView1.Rows(i).Cells(1).Value
        'Dim xyrlevel = DataGridView1.Rows(i).Cells(2).Value
        'Dim xsemester = DataGridView1.Rows(i).Cells(3).Value
        Dim xcoursecode = DataGridView1.Rows(i).Cells(0).Value
        If xcoursecode <> "" Then
            Dim dtxSubjects As New DataTable
            Try
                conn.Open()

                Dim query As String = ""
                Dim adapter As New MySqlDataAdapter()
                'Dim cmd As New MySqlCommand
                'Dim reader As MySqlDataReader
                query = "SELECT * FROM tbl_coursesubject "
                query = query & "WHERE fld_CourseID='" & ComboCourse.Text & "' AND fld_MajorCode='" & ComboMajor.Text & "' AND fld_YearLevel='" & ComboYearLevel.Text & "' AND fld_Semester='" & ComboSemester.Text & "' AND fld_CourseCode='" & xcoursecode & "'"
                adapter = New MySqlDataAdapter(query, conn)
                adapter.Fill(dtxSubjects)
                If dtxSubjects.Rows.Count > 0 Then
                    kungMeUna = True
                Else
                    kungMeUna = False
                End If
                'cmd = New MySqlCommand(query, conn)
                'reader = cmd.ExecuteReader
                'While reader.Read

                'End While
                conn.Close()
            Catch myerror As MySqlException
                MessageBox.Show(myerror.Message)
                conn.Close()
            End Try
        Else
            kungMeUna = True
        End If

        'dtComboSubject = New DataTable
        'Try
        '    conn.Open()
        '    Dim query As String
        '    Dim adapter As New MySqlDataAdapter()

        '    query = "SELECT fld_CourseCode FROM tbl_Subjects"
        '    adapter = New MySqlDataAdapter(query, conn)
        '    adapter.Fill(dtComboSubject)
        '    conn.Close()
        'Catch myerror As MySqlException
        '    MessageBox.Show(myerror.Message)
        '    conn.Close()
        'End Try
    End Sub

    Private Sub ComboSemester_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSemester.SelectedIndexChanged
        LoadRecords()
    End Sub
End Class
Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frm_Enroll
    Dim xxSY As String
    Dim xxSem As String
    Dim xxRegular As String
    Dim xxSubject As String
    Dim daSubjCourse As MySqlDataAdapter
    Dim dtSubjCourse As New DataSet
    Dim dtComboSubject As New DataTable
    Dim daAssessment As MySqlDataAdapter
    Dim dtAssessment As New DataSet
    Dim tempPast As Decimal
    Private Sub frm_Enroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.Text = "Enrollment Form - " & memSemester & " - " & memSY
        LabelWarning.Visible = False
        LoadSettings()
        LoadComboCourse()
        LoadComboMajor()
        conn.Open()
        Dim query As String
        Dim cmd As New MySqlCommand
        Dim reader As MySqlDataReader

        Try
            query = "SELECT * FROM tbl_enrollment WHERE fld_IDno='" & memIDNO & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                MessageBox.Show(memIDNO & " is already enrolled!")
                conn.Close()
                LoadEnrolledStudent(memIDNO)
                LoadSubjectsEnrolled(memIDNO)
                LoadAccount(memIDNO)
                ButtonSave.Enabled = False
                ButtonLoadSubjects.Enabled = False
                DataGridView1.Enabled = False
                DataGridView2.Enabled = False

                Dim homechild As New frm_ReportEnrollment
                homechild.MdiParent = frm_Registrar
                homechild.Dock = DockStyle.None
                homechild.Show()
            Else
                conn.Close()
                LoadProfile(memIDNO)

                LoadAssessment()
                lblPastAccounts.Text = tempPast.ToString("###,##0.00")
            End If
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try

        'LoadSubjects()
        'Panel1.Location = New Point((Me.DisplayRectangle.Width - Panel1.Width) / 2, (Me.Height - Panel1.Height) / 2)
    End Sub

    Private Sub LoadEnrolledStudent(ByVal findID As String)
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_enrollment WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            'If reader.HasRows Then
            While reader.Read
                txtIDNO.Text = reader.GetString("fld_IDNO")
                txtLast.Text = reader.GetString("fld_Lastname")
                txtFirst.Text = reader.GetString("fld_Firstname")
                txtMiddle.Text = reader.GetString("fld_Middlename")
                txtExt.Text = reader.GetString("fld_Ext")
                ComboCourse.Text = reader.GetString("fld_CourseID")
                ComboMajor.Text = reader.GetString("fld_Major")
                ComboYearLevel.Text = reader.GetString("fld_Year")
                If reader.GetString("fld_Type") = 0 Then
                    RadioRegular.Checked = True
                Else
                    RadioIrregular.Checked = True
                End If
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadSubjectsEnrolled(ByVal findID As String)
        LoadDataGridcomboSubject()
        Try
            conn.Open()
            Dim query As String
            query = "SELECT fld_CourseCode, fld_CourseDescription, fld_Lec, fld_Lab, fld_Units FROM tbl_enrolledsubjects WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
            daSubjCourse = New MySqlDataAdapter(query, conn)

            dtSubjCourse.Clear()
            daSubjCourse.Fill(dtSubjCourse)

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

            DataGridView1.Columns(1).Width = 370
            DataGridView1.Columns(1).HeaderText = "Subject"
            DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridView1.Columns(2).Width = 70
            DataGridView1.Columns(2).HeaderText = "Lec"
            DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(3).Width = 70
            DataGridView1.Columns(3).HeaderText = "Lab"
            DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(4).Width = 70
            DataGridView1.Columns(4).HeaderText = "Units"
            DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            conn.Close()

            Dim colLec, colLab, colUnits As Decimal
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not IsDBNull(row.Cells(0).Value) Then
                    colLec += row.Cells(2).Value
                    colLab += row.Cells(3).Value
                    colUnits += row.Cells(4).Value
                End If
            Next
            lblLec.Text = colLec
            lblLab.Text = colLab
            lblUnits.Text = colUnits

            Dim xcountSubjects As Integer = DataGridView1.Rows.Count - 1 '& " Subjects"
            If xcountSubjects > 1 Then
                lblNoSubjects.Text = xcountSubjects & " Subjects"
            Else
                lblNoSubjects.Text = xcountSubjects & " Subject"
            End If
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub LoadAccount(ByVal findID As String)
        Try
            conn.Open()
            Dim query As String
            query = "SELECT fld_fees, fld_Amount FROM tbl_accounts WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
            daAssessment = New MySqlDataAdapter(query, conn)
            dtAssessment.Clear()
            daAssessment.Fill(dtAssessment)

            DataGridView2.DataSource = dtAssessment.Tables(0)
            conn.Close()
            With DataGridView2
                .Columns(0).Width = 150
                .Columns(0).HeaderText = "Particulars"
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                .Columns(1).Width = 80
                .Columns(1).HeaderText = "Amount"
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(1).DefaultCellStyle.Format = "###,##0.00"
            End With
            'computetuition()
            ComputeTotals()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub CheckIfEnrolled(ByVal findID As String)
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter()
        'Try
        '    conn.Open()
        '    Dim query As String = ""
        '    query = "SELECT * FROM tbl_enrollment WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
        '    adapter = New MySqlDataAdapter(query, conn2)
        '    adapter.Fill(table)
        '    icount = table.Rows.Count

        '    conn2.Close()
        'Catch myerror As MySqlException
        '    MessageBox.Show(myerror.Message)
        'End Try

        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_enrollment WHERE fld_IDno='" & findID & "' AND fld_SY='" & xxSY & "' AND fld_Semester='" & xxSem & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                MessageBox.Show(findID & " is already enrolled!")
                conn.Close()
            Else

            End If

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadProfile(ByVal findID As String)
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_students where fld_IDno='" & findID & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            'If reader.HasRows Then
            While reader.Read
                txtIDNO.Text = reader.GetString("fld_IDNO")
                txtLast.Text = reader.GetString("fld_Lastname")
                txtFirst.Text = reader.GetString("fld_Firstname")
                txtMiddle.Text = reader.GetString("fld_Middlename")
                txtExt.Text = reader.GetString("fld_Ext")
                If varOldNew = 0 Then RadioOLD.Checked = True
                If varOldNew = 1 Then RadioNEW.Checked = True
            End While
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
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

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim xcountSubjects As Integer = DataGridView1.Rows.Count - 1
        Dim xxTotalFees As Double = lblAmnt.Text
        If RadioRegular.Checked = False And RadioIrregular.Checked = False Then
            MessageBox.Show("Please select an option! (Regular/Irregular)")
        Else
            If RadioRegular.Checked Then
                xxRegular = 0
            End If

            If RadioIrregular.Checked Then
                xxRegular = 1
            End If

            Try
                conn.Open()
                Dim query1 As String = ""
                Dim cmd1 As New MySqlCommand
                query1 = "INSERT INTO tbl_enrollment(fld_IDNO, fld_Lastname, fld_Firstname, fld_MiddleName, fld_Ext, "
                query1 = query1 & "fld_SY, fld_Semester, fld_CourseID, fld_Major, fld_Year, fld_Type, fld_NewOld, "
                query1 = query1 & "fld_NoSubjects, fld_NoLab, fld_NoLec, fld_NoUnits, fld_TotalFees, fld_DateEnrolled) "
                query1 = query1 & "VALUES ('" & txtIDNO.Text & "', '" & txtLast.Text & "', '" & txtFirst.Text & "', '" & txtMiddle.Text & "', '" & txtExt.Text & "', '"
                query1 = query1 & xxSY & "', '" & xxSem & "', '" & ComboCourse.Text & "', '" & ComboMajor.Text & "', '" & ComboYearLevel.Text & "', " & xxRegular & ", " & varOldNew & ", "
                query1 = query1 & xcountSubjects & ", " & lblLab.Text & ", " & lblLec.Text & ", " & lblUnits.Text & ", " & xxTotalFees & ", '" & Format(Now(), "yyyy-MM-dd") & "')"
                cmd1 = New MySqlCommand(query1, conn)
                cmd1.ExecuteNonQuery()
                conn.Close()

                'Dim response
                'response = MsgBox("Do you want to save the new record?", vbYesNo)
                'If response = vbYes Then
                '    memIDNO = txtIDNO.Text
                '    Dim homechild As New frm_Enroll
                '    homechild.MdiParent = frm_Registrar
                '    homechild.Dock = DockStyle.None
                '    homechild.Show()
                '    Me.Close()
                'Else
                '    txtLast.Focus()
                'End If
                SaveSubjectsEnrolled()
                SaveAccounts()
                MessageBox.Show(txtLast.Text & " is now enrolled!")
                'frm_DialogBoxOldNew.Show()
                'Me.Close()
            Catch myerror As MySqlException
                MessageBox.Show(myerror.Message)
                conn.Close()
            End Try
        End If
        Dim homechild As New frm_ReportEnrollment
        homechild.MdiParent = frm_Registrar
        homechild.Dock = DockStyle.None
        homechild.Show()
    End Sub

    Private Sub SaveAccounts()
        Dim dgFees As String
        Dim dgAmount As Decimal
        Try
            conn.Open()
            Dim query1 As String = ""
            Dim cmd1 As New MySqlCommand

            For x As Integer = 0 To DataGridView2.Rows.Count - 1
                dgFees = DataGridView2.Rows(x).Cells(0).Value
                dgAmount = DataGridView2.Rows(x).Cells(1).Value
                query1 = "INSERT INTO tbl_accounts(fld_IDNO, fld_SY, fld_Semester, fld_CourseID, fld_Major, fld_Year, fld_Type, fld_NewOld, fld_fees, fld_Amount, fld_DateEnrolled) "
                query1 = query1 & "VALUES (@txtIDNO, @xxSY, @xxSem, @ComboCourse, @ComboMajor, @ComboYearLevel, @xxRegular, @varOldNew, @dgFees, @dgAmount, @DateEnrolled)"
                cmd1 = New MySqlCommand(query1, conn)

                cmd1.Parameters.AddWithValue("@txtIDNO", txtIDNO.Text)
                cmd1.Parameters.AddWithValue("@xxSY", xxSY)
                cmd1.Parameters.AddWithValue("@xxSem", xxSem)
                cmd1.Parameters.AddWithValue("@ComboCourse", ComboCourse.Text)
                cmd1.Parameters.AddWithValue("@ComboMajor", ComboMajor.Text)
                cmd1.Parameters.AddWithValue("@ComboYearLevel", ComboYearLevel.Text)
                cmd1.Parameters.AddWithValue("@xxRegular", xxRegular)
                cmd1.Parameters.AddWithValue("@varOldNew", varOldNew)
                cmd1.Parameters.AddWithValue("@dgFees", dgFees)
                cmd1.Parameters.AddWithValue("@dgAmount", dgAmount)
                cmd1.Parameters.AddWithValue("@DateEnrolled", Format(Now(), "yyyy-MM-dd"))
                cmd1.ExecuteNonQuery()
                cmd1.Dispose()
            Next
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub SaveSubjectsEnrolled()
        Dim dgSubjCode As String
        Dim dgSubjDecs As String
        Dim dgLec As Integer
        Dim dgLab As Integer
        Dim dgUnits As Integer
        Try
            conn.Open()
            Dim query1 As String = ""
            Dim cmd1 As New MySqlCommand

            For x As Integer = 0 To DataGridView1.Rows.Count - 2 Step +1
                dgSubjCode = DataGridView1.Rows(x).Cells(0).Value
                dgSubjDecs = DataGridView1.Rows(x).Cells(1).Value
                dgLec = DataGridView1.Rows(x).Cells(2).Value
                dgLab = DataGridView1.Rows(x).Cells(3).Value
                dgUnits = DataGridView1.Rows(x).Cells(4).Value
                query1 = "INSERT INTO `tbl_enrolledsubjects`(fld_IDNO, fld_SY, fld_Semester, fld_CourseID, fld_Major, fld_Year, fld_Type, fld_NewOld, fld_CourseCode, fld_CourseDescription, fld_Lec, fld_Lab, fld_Units, fld_DateEnrolled) "
                query1 = query1 & "VALUES (@txtIDNO, @xxSY, @xxSem, @ComboCourse, @ComboMajor, @ComboYearLevel, @xxRegular, @varOldNew, @dgSubjCode, @dgSubjDecs, @dgLec, @dgLab, @dgUnits, @DateEnrolled)"
                cmd1 = New MySqlCommand(query1, conn)

                cmd1.Parameters.AddWithValue("@txtIDNO", txtIDNO.Text)
                cmd1.Parameters.AddWithValue("@xxSY", xxSY)
                cmd1.Parameters.AddWithValue("@xxSem", xxSem)
                cmd1.Parameters.AddWithValue("@ComboCourse", ComboCourse.Text)
                cmd1.Parameters.AddWithValue("@ComboMajor", ComboMajor.Text)
                cmd1.Parameters.AddWithValue("@ComboYearLevel", ComboYearLevel.Text)
                cmd1.Parameters.AddWithValue("@xxRegular", xxRegular)
                cmd1.Parameters.AddWithValue("@varOldNew", varOldNew)
                cmd1.Parameters.AddWithValue("@dgSubjCode", dgSubjCode)
                cmd1.Parameters.AddWithValue("@dgSubjDecs", dgSubjDecs)
                cmd1.Parameters.AddWithValue("@dgLec", dgLec)
                cmd1.Parameters.AddWithValue("@dgLab", dgLab)
                cmd1.Parameters.AddWithValue("@dgUnits", dgUnits)
                cmd1.Parameters.AddWithValue("@DateEnrolled", Format(Now(), "yyyy-MM-dd"))
                cmd1.ExecuteNonQuery()
                cmd1.Dispose()
            Next
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
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

    Private Sub ButtonLoadSubjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoadSubjects.Click
        LoadDataGridcomboSubject()
        LoadSubjects()
        computetuition()
        Dim xcountSubjects As Integer = DataGridView1.Rows.Count - 1 '& " Subjects"
        If xcountSubjects > 1 Then
            lblNoSubjects.Text = xcountSubjects & " Subjects"
        Else
            lblNoSubjects.Text = xcountSubjects & " Subject"
        End If
        ComputeTotals()
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

    Private Sub LoadSubjects()
        Try
            conn.Open()
            Dim query As String
            'query = "SELECT fld_CourseCode FROM tbl_coursesubject WHERE fld_CourseID='" & ComboCourse.Text & "' AND fld_MajorCode='" & ComboMajor.Text & "' AND fld_YearLevel='" & ComboYearLevel.Text & "' AND fld_Semester='" & xxSem & "'"
            query = "SELECT tbl_CourseSubject.fld_CourseCode, tbl_Subjects.fld_CourseDescription, tbl_Subjects.fld_Lec, tbl_Subjects.fld_Lab, tbl_Subjects.fld_Units "
            query = query & "FROM tbl_CourseSubject INNER JOIN tbl_Subjects ON tbl_CourseSubject.fld_CourseCode = tbl_Subjects.fld_CourseCode "
            query = query & "WHERE fld_CourseID='" & ComboCourse.Text & "' AND fld_MajorCode='" & ComboMajor.Text & "' AND fld_YearLevel='" & ComboYearLevel.Text & "' AND fld_Semester='" & memSemester & "'"
            daSubjCourse = New MySqlDataAdapter(query, conn)
            'xrecno = daSubjCourse.

            dtSubjCourse.Clear()
            daSubjCourse.Fill(dtSubjCourse)
            Dim xrecno As Integer = dtSubjCourse.Tables(0).Rows.Count
            If xrecno = 0 Then
                LabelWarning.Visible = True
            Else
                LabelWarning.Visible = False
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

                DataGridView1.Columns(1).Width = 370
                DataGridView1.Columns(1).HeaderText = "Subject"
                DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                DataGridView1.Columns(2).Width = 70
                DataGridView1.Columns(2).HeaderText = "Lec"
                DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridView1.Columns(3).Width = 70
                DataGridView1.Columns(3).HeaderText = "Lab"
                DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DataGridView1.Columns(4).Width = 70
                DataGridView1.Columns(4).HeaderText = "Units"
                DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            conn.Close()

            Dim colLec, colLab, colUnits As Decimal
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not IsDBNull(row.Cells(0).Value) Then
                    colLec += row.Cells(2).Value
                    colLab += row.Cells(3).Value
                    colUnits += row.Cells(4).Value
                End If
            Next
            lblLec.Text = colLec
            lblLab.Text = colLab
            lblUnits.Text = colUnits
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadAssessment()
        'Dim xNoSubj As Integer = DataGridView1.Rows.Count - 1
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_fees"
            daAssessment = New MySqlDataAdapter(query, conn)
            dtAssessment.Clear()
            daAssessment.Fill(dtAssessment)

            DataGridView2.DataSource = dtAssessment.Tables(0)
            conn.Close()
            With DataGridView2
                .Columns(0).Width = 150
                .Columns(0).HeaderText = "Particulars"
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                .Columns(1).Width = 80
                .Columns(1).HeaderText = "Amount"
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(1).DefaultCellStyle.Format = "###,##0.00"

                .Columns(2).Width = 0
                .Columns(2).HeaderText = ""
                .Columns(2).Visible = False
            End With
            computetuition()
            ComputeTotals()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub computetuition()
        Dim tempTuition As Decimal
        Try
            conn.Open()
            'Dim query As String
            'query = "SELECT * FROM tbl_fees WHERE fld_isdependent=1"
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_fees WHERE fld_isdependent=1"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                tempTuition = reader.GetDecimal("fld_Amount")
            End While

            conn.Close()

            Dim xNoSubj As Integer = DataGridView1.Rows.Count - 1
            If xNoSubj > 0 Then
                For Each row As DataGridViewRow In DataGridView2.Rows
                    If row.Cells(2).Value = 1 Then
                        row.Cells(1).Value = tempTuition * xNoSubj
                    End If
                Next
            End If

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ComputeTotals()
        Dim colAmnt As Decimal
        For Each row As DataGridViewRow In DataGridView2.Rows
            If Not IsDBNull(row.Cells(1).Value) Then
                colAmnt += row.Cells(1).Value
            End If
        Next
        lblAmnt.Text = colAmnt.ToString("###,##0.00")
        Dim xgrandtotal As Decimal = colAmnt + tempPast
        lblGrandTotal.Text = xgrandtotal.ToString("###,##0.00")

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
        Dim colLec, colLab, colUnits As Decimal
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not IsDBNull(row.Cells(0).Value) Then
                colLec += row.Cells(2).Value
                colLab += row.Cells(3).Value
                colUnits += row.Cells(4).Value
            End If
        Next
        lblLec.Text = colLec
        lblLab.Text = colLab
        lblUnits.Text = colUnits
        Dim xcountSubjects As Integer = DataGridView1.Rows.Count - 1 '& " Subjects"
        If xcountSubjects > 1 Then
            lblNoSubjects.Text = xcountSubjects & " Subjects"
        Else
            lblNoSubjects.Text = xcountSubjects & " Subject"
        End If
        computetuition()
        ComputeTotals()
    End Sub

    Private Sub DataGridView2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        ComputeTotals()
    End Sub

    Private Sub DataGridView1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        Dim colLec, colLab, colUnits As Decimal
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not IsDBNull(row.Cells(0).Value) Then
                colLec += row.Cells(2).Value
                colLab += row.Cells(3).Value
                colUnits += row.Cells(4).Value
            End If
        Next
        lblLec.Text = colLec
        lblLab.Text = colLab
        lblUnits.Text = colUnits

        Dim xcountSubjects As Integer = DataGridView1.Rows.Count - 1 '& " Subjects"
        If xcountSubjects > 1 Then
            lblNoSubjects.Text = xcountSubjects & " Subjects"
        Else
            lblNoSubjects.Text = xcountSubjects & " Subject"
        End If

        computetuition()
        ComputeTotals()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        If varOldNew = 1 Then
            Try
                conn.Open()
                Dim query As String = "DELETE FROM tbl_students WHERE fld_IDNO='" & txtIDNO.Text & "'"
                Dim cmd As New MySqlCommand
                'Dim reader As MySqlDataReader

                cmd = New MySqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch myerror As MySqlException
                MessageBox.Show(myerror.Message)
                conn.Close()
            End Try
        End If
        Me.Close()
    End Sub

End Class
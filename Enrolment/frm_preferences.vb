Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO.Ports
Imports System.IO
Imports Setting.IniFile
Public Class frm_preferences
    Dim daSY As MySqlDataAdapter
    Dim dtSY As New DataSet
    Dim daCourse As MySqlDataAdapter
    Dim dtCourse As New DataSet
    Dim daDepartment As MySqlDataAdapter
    Dim dtDepartment As New DataSet
    Dim dtComboDept As New DataTable
    Dim daSubject As MySqlDataAdapter
    Dim dtSubject As New DataSet
    Dim daFees As MySqlDataAdapter
    Dim dtFees As New DataSet
    Dim daSignatories As MySqlDataAdapter
    Dim dtSignatories As New DataSet

    Private Sub frm_preferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSettings()
        loadSY()
        loadCourses()
        loadDepartment()
        loadSubjects()
        loadFees()
        loadSignatories()
    End Sub

    Sub loadCourses()
        LoadDataGridcomboDept()
        
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_course"
            daCourse = New MySqlDataAdapter(query, conn)
            dtCourse.Clear()
            daCourse.Fill(dtCourse)
            DataGridCourse.DataSource = dtCourse.Tables(0)
            conn.Close()

            Dim deptComboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
            With deptComboBoxColumn
                .HeaderText = "Department"
                .DataPropertyName = "fld_DepartmentID"
                .DataSource = dtComboDept
                .ValueMember = "fld_DepartmentID"
                .DisplayMember = "fld_DepartmentID"
            End With
            Me.DataGridCourse.Columns.RemoveAt(2)
            Me.DataGridCourse.Columns.Insert(2, deptComboBoxColumn)

            DataGridCourse.Columns(0).Width = 100
            DataGridCourse.Columns(0).HeaderText = "Code"
            DataGridCourse.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridCourse.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridCourse.Columns(1).Width = 350
            DataGridCourse.Columns(1).HeaderText = "Course"
            DataGridCourse.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridCourse.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridCourse.Columns(2).Width = 200
            DataGridCourse.Columns(2).HeaderText = "Department"
            DataGridCourse.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridCourse.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Sub loadDepartment()
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_department"
            daDepartment = New MySqlDataAdapter(query, conn)
            dtDepartment.Clear()
            daDepartment.Fill(dtDepartment)
            DataGridDepartment.DataSource = dtDepartment.Tables(0)
            conn.Close()
            DataGridDepartment.Columns(0).Width = 300
            DataGridDepartment.Columns(0).HeaderText = "Department"
            DataGridDepartment.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridDepartment.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridDepartment.Columns(1).Width = 250
            DataGridDepartment.Columns(1).HeaderText = "Head"
            DataGridDepartment.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridDepartment.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub loadSubjects()
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_subjects"
            daSubject = New MySqlDataAdapter(query, conn)
            dtSubject.Clear()
            daSubject.Fill(dtSubject)
            DataGridSubjects.DataSource = dtSubject.Tables(0)
            conn.Close()
            DataGridSubjects.Columns(0).Width = 150
            DataGridSubjects.Columns(0).HeaderText = "Course Code"
            DataGridSubjects.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridSubjects.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridSubjects.Columns(1).Width = 350
            DataGridSubjects.Columns(1).HeaderText = "Subject"
            DataGridSubjects.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridSubjects.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridSubjects.Columns(2).Width = 50
            DataGridSubjects.Columns(2).HeaderText = "Lab"
            DataGridSubjects.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridSubjects.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridSubjects.Columns(3).Width = 50
            DataGridSubjects.Columns(3).HeaderText = "Lec"
            DataGridSubjects.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridSubjects.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridSubjects.Columns(4).Width = 50
            DataGridSubjects.Columns(4).HeaderText = "Units"
            DataGridSubjects.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridSubjects.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub loadFees()
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_fees"
            daFees = New MySqlDataAdapter(query, conn)
            dtFees.Clear()
            daFees.Fill(dtFees)
            DataGridFees.DataSource = dtFees.Tables(0)
            conn.Close()
            DataGridFees.Columns(0).Width = 300
            DataGridFees.Columns(0).HeaderText = "Fees"
            DataGridFees.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridFees.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridFees.Columns(1).Width = 100
            DataGridFees.Columns(1).HeaderText = "Amount"
            DataGridFees.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridFees.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridFees.Columns(1).DefaultCellStyle.Format = "###,##0.00"

            DataGridFees.Columns(2).Width = 100
            DataGridFees.Columns(2).HeaderText = "Is Dependent"
            DataGridFees.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridFees.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Sub loadSY()
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_SY"
            daSY = New MySqlDataAdapter(query, conn)
            dtSY.Clear()
            daSY.Fill(dtSY)
            DataGridAY.DataSource = dtSY.Tables(0)
            conn.Close()
            DataGridAY.Columns(0).Width = 200
            DataGridAY.Columns(0).HeaderText = "Academic Year"
            DataGridAY.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridAY.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Sub LoadcomboSY()
        ComboAY.Items.Clear()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_SY"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                ComboAY.Items.Add(reader.GetString("fld_SY"))
            End While
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Sub LoadDataGridcomboDept()
        dtComboDept = New DataTable
        Try
            conn.Open()
            Dim query As String
            Dim adapter As New MySqlDataAdapter()

            query = "SELECT fld_DepartmentID FROM tbl_Department"
            adapter = New MySqlDataAdapter(query, conn)
            adapter.Fill(dtComboDept)
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Sub LoadSettings()
        LoadcomboSY()

        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_settings where fld_id=1"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                ComboAY.Text = reader.GetString("fld_currentSY")
                ComboSem.Text = reader.GetString("fld_currentSem")
                txtPhoto.Text = reader.GetString("fld_PhotoPath")
            End While
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Sub loadSignatories()
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_signatories"
            daSignatories = New MySqlDataAdapter(query, conn)
            dtSignatories.Clear()
            daSignatories.Fill(dtSignatories)
            DataGridViewSignatories.DataSource = dtSignatories.Tables(0)
            conn.Close()

            DataGridViewSignatories.Columns(0).Width = 0
            DataGridViewSignatories.Columns(0).HeaderText = "ID"
            DataGridViewSignatories.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewSignatories.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridViewSignatories.Columns(1).Width = 300
            DataGridViewSignatories.Columns(1).HeaderText = "NAME"
            DataGridViewSignatories.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewSignatories.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridViewSignatories.Columns(2).Width = 250
            DataGridViewSignatories.Columns(2).HeaderText = "POSITION"
            DataGridViewSignatories.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewSignatories.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ButtonSY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSY.Click
        Try
            Dim command As New MySqlCommandBuilder(daSY)
            Dim changes As New DataSet
            changes = dtSY.GetChanges
            If changes IsNot Nothing Then
                daSY.Update(changes)
                daSY.Fill(dtSY)
                DataGridAY.DataSource = dtSY.Tables(0)
                loadSY()
            End If
            LoadcomboSY()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonCourse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCourse.Click
        Try
            Dim command As New MySqlCommandBuilder(daCourse)
            Dim changes As New DataSet
            changes = dtCourse.GetChanges
            If changes IsNot Nothing Then
                daCourse.Update(changes)
                daCourse.Fill(dtCourse)
                DataGridCourse.DataSource = dtCourse.Tables(0)
                loadCourses()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDepartment.Click
        Try
            Dim command As New MySqlCommandBuilder(daDepartment)
            Dim changes As New DataSet
            changes = dtDepartment.GetChanges
            If changes IsNot Nothing Then
                daDepartment.Update(changes)
                daDepartment.Fill(dtDepartment)
                DataGridDepartment.DataSource = dtDepartment.Tables(0)
                loadDepartment()
            End If
            loadCourses()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSettings.Click
        Try
            conn.Open()
            Dim cmd1 As New MySqlCommand("UPDATE tbl_settings SET fld_currentSY='" & ComboAY.Text & "',fld_currentSem='" & ComboSem.Text & "',fld_PhotoPath=?fld_PhotoPath WHERE fld_id=1", conn)
            cmd1.CommandType = CommandType.Text
            cmd1.Parameters.Add(New MySqlParameter("?fld_PhotoPath", txtPhoto.Text))
            cmd1.ExecuteNonQuery()
            MessageBox.Show("Settings was stored!")
            conn.Close()
            memSY = ComboAY.Text
            memSemester = ComboSem.Text
            frm_Registrar.ToolStripStatusLabelSYsemester.Text = memSemester & " - " & memSY
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ButtonSubjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubjects.Click
        Try
            Dim command As New MySqlCommandBuilder(daSubject)
            Dim changes As New DataSet
            changes = dtSubject.GetChanges
            If changes IsNot Nothing Then
                daSubject.Update(changes)
                daSubject.Fill(dtSubject)
                DataGridSubjects.DataSource = dtSubject.Tables(0)
                loadSubjects()
            End If
            'loadCourses()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonFees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFees.Click
        Try
            Dim command As New MySqlCommandBuilder(daFees)
            Dim changes As New DataSet
            changes = dtFees.GetChanges
            If changes IsNot Nothing Then
                daFees.Update(changes)
                daFees.Fill(dtFees)
                DataGridFees.DataSource = dtFees.Tables(0)
                loadFees()
            End If
            'loadCourses()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonSignatories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSignatories.Click
        Try
            Dim command As New MySqlCommandBuilder(daSignatories)
            Dim changes As New DataSet
            changes = dtSignatories.GetChanges
            If changes IsNot Nothing Then
                daSignatories.Update(changes)
                daSignatories.Fill(dtSignatories)
                DataGridViewSignatories.DataSource = dtSignatories.Tables(0)
                loadSignatories()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
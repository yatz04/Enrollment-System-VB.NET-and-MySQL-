Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frm_DialogBoxOldNew
    Dim i As Integer
    Dim meSueod As Boolean = True
    Private Sub ButtonConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConfirm.Click
        If RadioOLD.Checked Then
            If DataGridView1.SelectedRows.Count = 1 Then
                varOldNew = 0
                Me.Close()
                Dim homechild As New frm_Enroll
                homechild.MdiParent = frm_Registrar
                homechild.Dock = DockStyle.None
                homechild.Show()
            Else
                MessageBox.Show("Select a student!", "Required Input")
            End If
        ElseIf RadioNEW.Checked Then
            varOldNew = 1
            SaveNewRecord()
        Else
            MessageBox.Show("Select an option!", "Required Input")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub SaveNewRecord()
        Try
            conn.Open()
            Dim query1 As String = ""
            Dim cmd1 As New MySqlCommand
            'query1 = "INSERT INTO tbl_students(fld_idno, fld_lastname, fld_firstname, fld_middlename, fld_Ext, fld_address, fld_contactno, fld_Email, fld_sex, fld_dob, fld_ContactPerson, fld_ContactAddress, fld_ContactRelationship, fld_ContactCP) "
            'query1 = query1 & "VALUES ('" & txtIDNO.Text & "', '" & txtLast.Text & "', '" & txtFirst.Text & "', '" & txtMiddle.Text & "', '" & txtExt.Text & "', '" & txtAddress.Text & "', '" & txtContactno.Text & "', '" & txtEmail.Text & "', '" & ComboSex.Text & "', '" & Format(DateTimePickerDOB.Value, "yyyy-MM-dd") & "', '" & txtContactName.Text & "', '" & txtContactAddress.Text & "', '" & txtContactRelationship.Text & "', '" & txtContactCP.Text & "')"
            query1 = "UPDATE tbl_students SET fld_Lastname='" & txtLast.Text & "', fld_Firstname='" & txtFirst.Text & "', fld_Middlename='" & txtMiddle.Text & "', fld_Ext='" & txtExt.Text & "', "
            query1 = query1 & "fld_Sex='" & ComboSex.Text & "', fld_DOB='" & Format(DateTimePickerDOB.Value, "yyyy-MM-dd") & "', fld_Address='" & txtAddress.Text & "', fld_Contactno='" & txtContactno.Text & "', "
            query1 = query1 & "fld_Email='" & txtEmail.Text & "', fld_ContactPerson='" & txtContactName.Text & "', fld_ContactAddress='" & txtContactAddress.Text & "', fld_ContactRelationship='" & txtContactRelationship.Text & "', fld_ContactCP='" & txtContactCP.Text & "' WHERE fld_IDNO='" & txtIDNO.Text & "'"
            cmd1 = New MySqlCommand(query1, conn)
            cmd1.ExecuteNonQuery()
            conn.Close()

            Dim response As MsgBoxResult
            response = MsgBox("Save the new student record?", vbYesNo)
            If response = vbYes Then
                memIDNO = txtIDNO.Text
                Dim homechild As New frm_Enroll
                homechild.MdiParent = frm_Registrar
                homechild.Dock = DockStyle.None
                homechild.Show()
                Me.Close()
            Else
                txtLast.Focus()
            End If
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub frm_DialogBoxOldNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePickerDOB.Format = DateTimePickerFormat.Custom
        DateTimePickerDOB.CustomFormat = "MMMM dd, yyyy"
        RadioOLD.Checked = True
        PanelOLD.Visible = True
        PanelNEW.Visible = False
        'PanelOLD.Location = New Point(24, 100)
        'PanelNEW.Location = New Point(24, 100)
    End Sub

    Private Sub RadioOLD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioOLD.CheckedChanged
        If RadioOLD.Checked Then
            PanelOLD.Visible = True
            PanelNEW.Visible = False
        Else
            PanelOLD.Visible = False
            PanelNEW.Visible = True
        End If
    End Sub

    Private Sub RadioNEW_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioNEW.CheckedChanged
        If RadioNEW.Checked Then
            PanelNEW.Visible = True
            PanelOLD.Visible = False
            txtIDNO.Enabled = False

            Dim response As MsgBoxResult
            response = MsgBox("Create new student record? This will generate a NEW ID Number.", vbYesNo)
            If response = vbYes Then
                Dim xnumber As Integer
                Dim NewIDNO As String
                Dim xLastNumber As Integer
                Dim xcounter As Integer

                CheckifNone(xcounter)

                Dim xyear As String = Format(Now(), "yyyy")
                Dim addNum As String = ""

                If xcounter = 1 Then
                    xnumber = 1
                Else
                    checkLastnumber(xLastNumber)
                    xnumber = xLastNumber + 1
                End If

                Dim lengthID As Integer = xnumber.ToString.Length
                If lengthID < 4 Then
                    If lengthID = 3 Then
                        addNum = "0" & xnumber
                    ElseIf lengthID = 2 Then
                        addNum = "00" & xnumber
                    ElseIf lengthID = 1 Then
                        addNum = "000" & xnumber
                    End If
                    NewIDNO = xyear & "-" & addNum
                Else
                    addNum = xnumber
                    NewIDNO = xyear & "-" & addNum
                End If

                txtIDNO.Text = NewIDNO
                SaveNewIDNO(addNum)
            Else
                RadioOLD.Checked = True
            End If
            txtLast.Focus()
        Else
            PanelNEW.Visible = False
            PanelOLD.Visible = True
        End If
    End Sub

    Private Sub CheckifNone(ByRef tempCounter As Integer)
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            Dim query As String
            Dim command As MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT fld_LastNumber FROM tbl_students WHERE fld_SY='" & memSY & "'"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader()

            If reader.HasRows Then
                tempCounter = 5
            Else
                tempCounter = 1
            End If

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub checkLastnumber(ByRef tempLastNumber As Integer)
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            Dim query As String
            Dim command As MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT Max(fld_LastNumber) AS LastNumber FROM tbl_students WHERE fld_SY='" & memSY & "'"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    tempLastNumber = reader("LastNumber").ToString
                End While
            End If
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub SaveNewIDNO(ByRef tempLastNumber As Integer)
        Try
            conn.Open()
            Dim query1 As String = ""
            Dim cmd1 As New MySqlCommand
            query1 = "INSERT INTO tbl_students(fld_idno, fld_LastNumber, fld_SY, fld_YearEntered) "
            query1 = query1 & "VALUES ('" & txtIDNO.Text & "', " & tempLastNumber & ", '" & memSY & "', '" & Format(Now(), "yyyy") & "')"
            cmd1 = New MySqlCommand(query1, conn)
            cmd1.ExecuteNonQuery()
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub TextBoxSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxSearch.KeyDown

        'If e.KeyCode = Keys.Enter Then
        '    searchAccount()
        '    'If meSueod Then
        '    '    FirstRec = DataGridView1.Rows(0).Cells(0).Value.ToString
        '    '    'LoadProfile(FirstRec)
        '    'Else
        '    '    'ClearAll()
        '    'End If

        'End If
    End Sub

    Private Sub searchAccount()
        Try
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            'Dim reader As MySqlDataReader
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter()
            If TextBoxSearch.Text = "*" Then
                query = "SELECT fld_IDNO, fld_lastname, fld_firstname, fld_middlename FROM tbl_students ORDER BY fld_lastname"
            Else
                query = "SELECT fld_IDNO, fld_lastname, fld_firstname, fld_middlename FROM tbl_students WHERE fld_idno='" & TextBoxSearch.Text & "' OR fld_lastname='" & TextBoxSearch.Text & "' OR fld_firstname='" & TextBoxSearch.Text & "' OR fld_middlename='" & TextBoxSearch.Text & "' ORDER BY fld_lastname"
            End If
            adapter = New MySqlDataAdapter(query, conn)
            adapter.Fill(table)
            Dim count As Integer = table.Rows.Count
            'If count > 0 Then
            '    LabelNumRec.Text = count & " record(s)"
            '    meSueod = True
            'Else
            '    LabelNumRec.Text = count & " record"
            '    meSueod = False
            'End If
            DataGridView1.DataSource = table
            conn.Close()
            DataGridView1.Columns(0).Width = 120
            DataGridView1.Columns(1).Width = 150
            DataGridView1.Columns(2).Width = 150
            DataGridView1.Columns(3).Width = 150
            DataGridView1.Columns(0).HeaderText = "ID No."
            DataGridView1.Columns(1).HeaderText = "Last Name"
            DataGridView1.Columns(2).HeaderText = "First Name"
            DataGridView1.Columns(3).HeaderText = "Middle Name"

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(i)
        memIDNO = selectedRow.Cells(0).Value.ToString
    End Sub

    Private Sub TextBoxSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxSearch.KeyUp
        searchAccount()
    End Sub
End Class
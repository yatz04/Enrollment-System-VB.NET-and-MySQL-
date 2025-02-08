Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frm_Students
    
    Private Sub frm_Students_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtIDNO.Enabled = False
        DateTimePickerDOB.Format = DateTimePickerFormat.Custom
        DateTimePickerDOB.CustomFormat = " "
    End Sub

    Private Sub ToolStripButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSave.Click
        SaveNewRecord()
        'ClearFields()
        DisableAll()
        memIDNO = txtIDNO.Text
        ToolStripButtonNew.Enabled = True
        'varOldNew = 1
        'Dim homechild As New frm_Enroll
        'homechild.MdiParent = frm_Registrar
        'homechild.Dock = DockStyle.None
        'homechild.Show()
        '    Me.Close()
    End Sub

    Private Sub SaveNewRecord()
        Try
            conn.Open()
            Dim query1 As String = ""
            Dim cmd1 As New MySqlCommand
            query1 = "UPDATE tbl_students SET fld_Lastname='" & txtLast.Text & "', fld_Firstname='" & txtFirst.Text & "', fld_Middlename='" & txtMiddle.Text & "', fld_Ext='" & txtExt.Text & "', "
            query1 = query1 & "fld_Sex='" & ComboSex.Text & "', fld_DOB='" & Format(DateTimePickerDOB.Value, "yyyy-MM-dd") & "', fld_Address='" & txtAddress.Text & "', fld_Contactno='" & txtContactno.Text & "', "
            query1 = query1 & "fld_Email='" & txtEmail.Text & "', fld_ContactPerson='" & txtContactName.Text & "', fld_ContactAddress='" & txtContactAddress.Text & "', fld_ContactRelationship='" & txtContactRelationship.Text & "', fld_ContactCP='" & txtContactCP.Text & "' WHERE fld_IDNO='" & txtIDNO.Text & "'"
            cmd1 = New MySqlCommand(query1, conn)
            cmd1.ExecuteNonQuery()
            conn.Close()

            'Dim response
            'response = MsgBox("Save the new student record?", vbYesNo)
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
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ToolStripButtonNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonNew.Click

        ClearFields()
        EnableAll()

        ToolStripButtonNew.Enabled = False

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

        EnableAll()
        ToolStripButtonSave.Enabled = True
        txtLast.Focus()
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

    Private Sub SaveNewIDNO(ByRef tempLastNumber As Integer)
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
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

    Private Sub ClearFields()
        txtIDNO.Text = ""
        txtLast.Text = ""
        txtFirst.Text = ""
        txtMiddle.Text = ""
        txtExt.Text = ""
        txtAddress.Text = ""
        txtContactno.Text = ""
        txtEmail.Text = ""
        ComboSex.Text = ""
        DateTimePickerDOB.Format = DateTimePickerFormat.Custom
        DateTimePickerDOB.CustomFormat = " "
        txtContactName.Text = ""
        txtContactAddress.Text = ""
        txtContactCP.Text = ""
        txtContactRelationship.Text = ""
    End Sub

    Private Sub EnableAll()
        txtLast.Enabled = True
        txtFirst.Enabled = True
        txtMiddle.Enabled = True
        txtExt.Enabled = True
        txtAddress.Enabled = True
        txtContactno.Enabled = True
        txtEmail.Enabled = True
        ComboSex.Enabled = True
        DateTimePickerDOB.Enabled = True
        txtContactName.Enabled = True
        txtContactAddress.Enabled = True
        txtContactCP.Enabled = True
        txtContactRelationship.Enabled = True
    End Sub

    Private Sub DisableAll()
        txtLast.Enabled = False
        txtFirst.Enabled = False
        txtMiddle.Enabled = False
        txtExt.Enabled = False
        txtAddress.Enabled = False
        txtContactno.Enabled = False
        txtEmail.Enabled = False
        ComboSex.Enabled = False
        DateTimePickerDOB.Enabled = False
        txtContactName.Enabled = False
        txtContactAddress.Enabled = False
        txtContactCP.Enabled = False
        txtContactRelationship.Enabled = False
    End Sub

    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        DisableAll()
        searchAccount()
    End Sub

    Private Sub ToolStripButtonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonEdit.Click
        EnableAll()
        txtLast.Focus()
        ToolStripButtonNew.Enabled = False
    End Sub

    Private Sub searchAccount()
        ListBox1.Items.Clear()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader
            If TextBoxSearch.Text = "*" Then
                query = "SELECT fld_IDNO, fld_lastname, fld_firstname FROM tbl_students ORDER BY fld_lastname"
            Else
                query = "SELECT fld_IDNO, fld_lastname, fld_firstname FROM tbl_students WHERE fld_IDNO='" & TextBoxSearch.Text & "' OR fld_lastname='" & TextBoxSearch.Text & "' OR fld_firstname='" & TextBoxSearch.Text & "' OR fld_middlename='" & TextBoxSearch.Text & "' ORDER BY fld_lastname"
            End If
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            While reader.Read
                ListBox1.Items.Add(reader.GetString("fld_IDNO") & " - " & UCase(reader.GetString("fld_lastname")) & ", " & reader.GetString("fld_firstname"))
            End While
            conn.Close()

        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        DisableAll()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader
            Dim SearchForThis As String = " - "
            Dim FirstCharacter As Integer = ListBox1.Text.IndexOf(SearchForThis)
            Dim findID As String = Mid(ListBox1.Text, 1, FirstCharacter)
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
                ComboSex.Text = reader.GetString("fld_Sex")
                'Dim xdob As String = Convert.ToDateTime(reader("fld_DOB")).ToString("yyyy-MM-dd")
                'If Convert.ToDateTime(reader("fld_DOB")).ToString("yyyy-MM-dd") = "0001-01-01" Then
                '    DateTimePickerDOB.CustomFormat = " "
                'Else
                '    DateTimePickerDOB.Value = reader("fld_DOB")
                'End If
                If IsDBNull(reader("fld_DOB")) Or IsNothing(reader("fld_DOB")) Then
                    DateTimePickerDOB.CustomFormat = " "
                Else
                    DateTimePickerDOB.Format = DateTimePickerFormat.Custom
                    DateTimePickerDOB.CustomFormat = "MMMM dd, yyyy"
                    DateTimePickerDOB.Value = reader.GetString("fld_DOB")
                End If
                txtAddress.Text = reader.GetString("fld_Address")
                txtContactno.Text = reader.GetString("fld_Contactno")
                txtEmail.Text = reader.GetString("fld_Email")
                txtContactName.Text = reader.GetString("fld_ContactPerson")
                txtContactAddress.Text = reader.GetString("fld_ContactAddress")
                txtContactRelationship.Text = reader.GetString("fld_ContactRelationship")
                txtContactCP.Text = reader.GetString("fld_ContactCP")
            End While
            conn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ToolStripButtonDelete_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDelete.Click
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String
            Dim cmd As New MySqlCommand
            Dim reader As MySqlDataReader
            Dim SearchForThis As String = " - "
            Dim FirstCharacter As Integer = ListBox1.Text.IndexOf(SearchForThis)
            Dim findID As String = Mid(ListBox1.Text, 1, FirstCharacter)
            query = "DELETE FROM tbl_students WHERE fld_IDno='" & findID & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            conn.Close()
            ClearFields()
            searchAccount()
            MsgBox("The record was deleted successfully!")
        Catch myerror As MySqlException
            MessageBox.Show(myerror.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub DateTimePickerDOB_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerDOB.ValueChanged
        DateTimePickerDOB.Format = DateTimePickerFormat.Custom
        DateTimePickerDOB.CustomFormat = "MMMM dd, yyyy"
    End Sub
End Class
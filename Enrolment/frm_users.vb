Imports MySql.Data.MySqlClient
Imports MySql.Data


Public Class frm_users
    Dim SaveStatus As String

    Private Sub frm_users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccounts()
        GroupBox1.Enabled = False
        GroupBoxAllow.Enabled = False
        ToolStripButtonNew.Enabled = True
        ToolStripButtonSave.Enabled = False
        ToolStripButtonEdit.Enabled = False
        ToolStripButtonDelete.Enabled = False
        ToolStripButtonPreview.Enabled = False
    End Sub

    Private Sub LoadAccounts()
        Try
            ListBoxAccounts.Items.Clear()
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String
            Dim command As MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_UserAccounts ORDER BY fld_UserID"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader()

            If reader.HasRows Then
                While reader.Read()
                    ListBoxAccounts.Items.Add(reader("fld_UserID"))
                End While
            End If
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ClearAllAccounts()
        TextBoxUserID.Text = ""
        TextBoxUserName.Text = ""
        TextBoxPassword.Text = ""
        ComboBoxType.Text = ""
        CheckBoxAdd.Checked = False
        CheckBoxEdit.Checked = False
        CheckBoxDelete.Checked = False
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        Try
            ToolStripButtonSave.Enabled = False
            ToolStripButtonNew.Enabled = True
            ToolStripButtonEdit.Enabled = True
            ToolStripButtonDelete.Enabled = True
            ToolStripButtonPreview.Enabled = True
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            Dim query As String = ""
            Dim command As MySqlCommand
            Dim reader As MySqlDataReader
            Dim xmessage As String = ""

            Dim tempAdd As Integer
            Dim tempEdit As Integer
            Dim tempDelete As Integer

            If CheckBoxAdd.Checked = True Then
                tempAdd = 1
            Else
                tempAdd = 0
            End If
            If CheckBoxEdit.Checked = True Then
                tempEdit = 1
            Else
                tempEdit = 0
            End If
            If CheckBoxDelete.Checked = True Then
                tempDelete = 1
            Else
                tempDelete = 0
            End If

            If SaveStatus = "New" Then
                query = "INSERT INTO tbl_Useraccounts (fld_UserID, fld_UserName, fld_Password, fld_Type, fld_Add, fld_Edit, fld_Delete) "
                query = query & "VALUES('" & TextBoxUserID.Text & "', '" & TextBoxUserName.Text & "', '" & TextBoxPassword.Text & "', '" & ComboBoxType.Text & "', " & tempAdd & ", " & tempEdit & ", " & tempDelete & ")"
                xmessage = "New record has been successfully added!"
            ElseIf SaveStatus = "Update" Then
                query = "UPDATE tbl_Userccounts SET fld_UserID = '" & TextBoxUserID.Text & "', fld_UserName = '" & TextBoxUserName.Text & "', fld_Password = '" & TextBoxPassword.Text & "',"
                query = query & " fld_Type = '" & ComboBoxType.Text & "', fld_Add = " & tempAdd & ", fld_Edit = " & tempEdit & ", fld_Delete = " & tempDelete
                query = query & " WHERE fld_UserID='" & ListBoxAccounts.SelectedItem & "'"
                xmessage = "Record has been successfully updated!"
            End If
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader()
            conn.Close()
            LoadAccounts()

            MsgBox(xmessage)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        ToolStripButtonNew.Enabled = False
        ToolStripButtonSave.Enabled = True
        ToolStripButtonEdit.Enabled = False
        ToolStripButtonDelete.Enabled = False
        ToolStripButtonPreview.Enabled = False
        SaveStatus = "New"

        GroupBox1.Enabled = True
        GroupBoxAllow.Enabled = True
        ClearAllAccounts()
        TextBoxUserID.Focus()
    End Sub

    Private Sub ToolStripButtonDelete_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDelete.Click
        Try
            ToolStripButtonSave.Enabled = False
            ToolStripButtonNew.Enabled = True
            ToolStripButtonEdit.Enabled = False
            ToolStripButtonDelete.Enabled = False
            ToolStripButtonPreview.Enabled = False
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            Dim query As String = ""
            Dim command As MySqlCommand
            Dim reader As MySqlDataReader

            query = "DELETE * FROM tbl_Useraccounts WHERE fld_UserID='" & ListBoxAccounts.SelectedItem & "'"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader()
            conn.Close()
            ClearAllAccounts()
            LoadAccounts()

            MsgBox("The record was deleted successfully!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ToolStripButtonEdit_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEdit.Click
        ToolStripButtonSave.Enabled = True
        ToolStripButtonNew.Enabled = False
        ToolStripButtonEdit.Enabled = False
        ToolStripButtonDelete.Enabled = False
        ToolStripButtonPreview.Enabled = False
        SaveStatus = "Update"

        GroupBox1.Enabled = True
        GroupBoxAllow.Enabled = True
        TextBoxUserID.Focus()
    End Sub

    Private Sub ListBoxAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAccounts.SelectedIndexChanged
        Try
            ToolStripButtonNew.Enabled = True
            ToolStripButtonSave.Enabled = False
            ToolStripButtonEdit.Enabled = True
            ToolStripButtonDelete.Enabled = True
            ToolStripButtonPreview.Enabled = True

            GroupBox1.Enabled = False
            GroupBoxAllow.Enabled = False

            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String
            Dim command As MySqlCommand
            Dim reader As MySqlDataReader

            query = "SELECT * FROM tbl_Useraccounts WHERE fld_UserID='" & ListBoxAccounts.SelectedItem & "'"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader()

            If reader.HasRows Then
                While reader.Read()
                    TextBoxUserID.Text = reader("fld_UserID")
                    TextBoxUserName.Text = reader("fld_UserName")
                    TextBoxPassword.Text = reader("fld_Password")
                    ComboBoxType.Text = reader("fld_Type")
                    If reader("fld_Add") = 1 Then
                        CheckBoxAdd.Checked = True
                    Else
                        CheckBoxAdd.Checked = False
                    End If
                    If reader("fld_Edit") = 1 Then
                        CheckBoxEdit.Checked = True
                    Else
                        CheckBoxEdit.Checked = False
                    End If
                    If reader("fld_Delete") = 1 Then
                        CheckBoxDelete.Checked = True
                    Else
                        CheckBoxDelete.Checked = False
                    End If
                End While
            End If
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub
End Class
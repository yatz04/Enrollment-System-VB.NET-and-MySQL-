Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class Login_Form

    Private Sub Login_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BTN_LOGIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LOGIN.Click
        Dim cmd As New MySqlCommand
        Dim query As String
        memUser = TextBoxUsername.Text
        Dim reader As MySqlDataReader
        memUserType = ""

        Try
            conn.Open()
            query = "SELECT * FROM tbl_Useraccounts WHERE fld_UserID= '" & TextBoxUsername.Text & "' and fld_password= '" & TextBoxPassword.Text & "'"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader
            reader.Read()
            If reader.HasRows() Then
                'MessageBox.Show("Login success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                memUserType = reader.GetString("fld_Type")
                memUserName = reader.GetString("fld_Username")
                If memUserType = "Admin" Then
                    Main_Form.Show()
                ElseIf memUserType = "Cashier" Then
                    frm_Cashier.Show()
                ElseIf memUserType = "Registrar" Then
                    frm_Registrar.Show()
                ElseIf memUserType = "Teacher" Then
                    frm_Teacher.Show()
                End If
                'frm_Success.Show()
                Me.Hide()
            Else
                MsgBox("Invalid Login information.!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            conn.Close()

        Catch ex As MySqlException
            'MsgBox("Error connecting to database!")
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Private Sub BTN_CANCEL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CLOSE.Click
        Application.Exit()
    End Sub

    Private Sub TextBoxPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxPassword.KeyPress
        If e.KeyChar = Chr(13) Then 'Chr(13) is the Enter Key
            'Runs the Button1_Click Event
            BTN_LOGIN_Click(Me, EventArgs.Empty)
        End If
    End Sub
End Class
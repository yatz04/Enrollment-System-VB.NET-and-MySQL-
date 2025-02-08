Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frmSY

    Private Sub BTN_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_OK.Click
        memSY = ComboSY.Text
        Main_Form.Show()
        Me.Hide()

    End Sub

    Private Sub frmSY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim conn As New MySqlConnection("Database=db_enrolment;Data Source=localhost;UserID=root;password=")
        Dim cmd As New MySqlCommand
        Dim dtSY As New DataTable
        Dim daSY As New MySqlDataAdapter

        daSY = New MySqlDataAdapter("SELECT * FROM tbl_SY", conn)
        daSY.Fill(dtSY)
        
        Dim items = dtSY.AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
        ComboSY.Items.AddRange(items)
    End Sub
End Class
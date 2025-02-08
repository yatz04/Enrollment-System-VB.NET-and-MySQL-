Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO.Ports
Imports System.IO
Imports Setting.IniFile
Module Module2
    Public memUserName As String
    Public memUser As String
    Public memSY As String
    Public memSemester As String
    Public memUserType As String
    Public varOldNew As Integer

    Public memIDNO As String

    Public path As String = Directory.GetCurrentDirectory()
    Public ini As New Setting.IniFile(path & "\enroll.ini")
    Public DBHost As String = ini.ReadValue("SERVER IP Address", "IPaddress")
    Public DBUsername As String = ini.ReadValue("DATABASE SETTINGS", "username")
    Public DBPassword As String = ini.ReadValue("DATABASE SETTINGS", "password")

    Public conn As New MySqlConnection("Database=db_enrollment;Data Source=" & DBHost & ";UserID=" & DBUsername & ";password=" & DBPassword & ";Convert Zero Datetime=True;Allow Zero Datetime=True")
    'Public conn2 As New MySqlConnection("Database=db_waa_security;Data Source=" & DBHost & ";UserID=" & DBUsername & ";password=" & DBPassword)

End Module

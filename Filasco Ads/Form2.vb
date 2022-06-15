Option Explicit On
Imports System.Net
Imports MySql.Data.MySqlClient
Public Class Form2
#Region "declare"
    Dim mycmd As New MySqlCommand
    Dim myconnection As New DTConnection
    Dim objreader As MySqlDataReader
    Dim Mysqlconn As MySqlConnection
#End Region
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComboBox1.Items.Clear()
        Try
            Dim query As String
            Mysqlconn = myconnection.open
            query = "select * from register"
            mycmd = New MySqlCommand(query, Mysqlconn)
            objreader = mycmd.ExecuteReader

            While objreader.Read
                Dim sName = objreader.GetString("password")

                ComboBox1.Items.Add(sName)
            End While
            myconnection.close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MsgBox("Are you sure to update?", MsgBoxStyle.YesNo, Title:="Notice") = vbYes Then
            Try
                mycmd.Connection = myconnection.open
                mycmd.CommandText = "update register set password='" + TextBoxUpdateTo.Text + "' where user='" + TextBoxWhere.Text + "'"
                objreader = mycmd.ExecuteReader
                myconnection.close()
                MsgBox("Success!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class
﻿Public Class PULL_PACKET_DETAIL
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao_insert As New BAO.ClsDBSqlcommand
        Dim _IDA As Integer
        _IDA = TextBox1.Text
        bao_insert.insert_tabean_sub_packet_detail(_IDA)
        alert("Complete")
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class
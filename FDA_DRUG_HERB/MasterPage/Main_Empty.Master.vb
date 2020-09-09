﻿Public Class Main_Empty
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("staff") <> "" Then
            HyperLink1.Style.Add("display", "block")
        End If
        RunSession()
        If Not IsPostBack Then

            hl_name.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM
            hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER
            If Request.QueryString("tt") <> "" Then
                Label1.Text = "ระบบทะเบียนตำรับยา"
            End If
            Dim lt_str As String = ""
            If _CLS.SYSTEM_ID = "8738" Or _CLS.SYSTEM_ID = "8734" Then
                '              <div class="nav-catagory"  style="background: #ffed33">
                '	<div class="inner">
                '		<h3></h3>
                '	</div>
                '</div>
                lt_str = "<div class='nav-catagory'  style='background: #DF7401'>"
                lt_str &= " <div class='inner'> <h3></h3></div> </div>"
                lt_nav_catagory.Text = lt_str
            Else
                lt_str = "<div class='nav-catagory'  style='background: #ffed33'>"
                lt_str &= " <div class='inner'> <h3></h3></div> </div>"
                lt_nav_catagory.Text = lt_str
            End If

        End If
    End Sub

End Class
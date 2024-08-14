Imports Telerik.Web.UI
Public Class FRM_HERB_LCN_RENEW
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As String = ""
    Private _SID As String = ""
    Private _PROCESS_ID As String = ""
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        _IDA_LCN = Request.QueryString("lcn_ida")
        _SID = Request.QueryString("SID")
        _PROCESS_ID = Request.QueryString("process")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'bind_dd()
            ' RadGrid1.Rebind()
        End If
    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        Dim IDEN As String = Request.QueryString("identify")
        If IDEN = "" Then
            IDEN = _CLS.CITIZEN_ID_AUTHORIZE
        End If
        dt = bao.SP_DALCN_RENEW(IDEN, _IDA_LCN)
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = item("IDA").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            If e.CommandName = "HL_SELECT" Then

                If STATUS_ID <> 0 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CONFIRM.aspx?IDA=" & IDA & "&PROCESS_ID=" & _PROCESS_ID & "');", True)
                End If
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim IDA As String = item("IDA").Text
            Dim HL_SELECT As LinkButton = DirectCast(item("HL_SELECT").Controls(0), LinkButton)
            If STATUS_ID = 1 Then
                HL_SELECT.Text = "ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
            ElseIf STATUS_ID > 1 Then
                HL_SELECT.Text = "ดูข้อมูล"
            Else
                HL_SELECT.Text = "ดูข้อมูล"
            End If

        End If
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try

            Dim IDEN As String = Request.QueryString("identify")
            If IDEN = "" Then
                IDEN = _CLS.CITIZEN_ID_AUTHORIZE
            End If
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POP_UP_LCN_RENEW_ADD.aspx?IDA_LCN=" & _IDA_LCN & "&IDENTIFY=" & IDEN & "&PROCESS_ID=" & _PROCESS_ID & "');", True)
        Catch ex As Exception

        End Try
    End Sub
End Class
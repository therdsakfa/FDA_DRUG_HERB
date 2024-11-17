Imports Telerik.Web.UI
Public Class FRM_HERB_LCN_RENEW_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As Integer = 0
    Private _SID As String = ""
    Private _pvncd As Integer
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

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            'bind_dd()
            ' RadGrid1.Rebind()
        End If
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        Dim IDEN As String = Request.QueryString("identify")
        If IDEN = "" Then
            IDEN = _CLS.CITIZEN_ID_AUTHORIZE
        End If
        If _pvncd = 10 Then
            dt = bao.SP_DALCN_RENEW_STAFF()
            'DIV_PVNCD.Visible = True
        Else
            dt = bao.SP_DALCN_RENEW_STAFF_BY_PVNCD(_pvncd)
        End If

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

            'Dim IDA_LCN As Integer = item("IDA_LCN").Text
            Dim IDA As Integer = item("IDA").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim _PROCESS_ID As Integer = item("PROCESS_ID").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim IDA_LCN As Integer = item("FK_LCN").Text

            If e.CommandName = "HL_SELECT" Then
                If STATUS_ID = 31 Or STATUS_ID = 3 Or STATUS_ID = 12 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_STAFF_EDIT.aspx?IDA=" & IDA & "&PROCESS_ID=" & _PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                Else
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CONFIRM_STAFF.aspx?IDA=" & IDA & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                End If
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CONFIRM_STAFF.aspx?IDA=" & IDA & "&PROCESS_ID=" & _PROCESS_ID & "');", True)
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
            'If STATUS_ID = 1 Then
            '    HL_SELECT.Text = "ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
            'ElseIf STATUS_ID > 1 Then
            '    HL_SELECT.Text = "ดูข้อมูล"
            'Else
            '    HL_SELECT.Text = "ดูข้อมูล"
            'End If

        End If
    End Sub
End Class
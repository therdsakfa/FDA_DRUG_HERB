Imports Telerik.Web.UI
Public Class FRM_TABEAN_HERB_TEMPOLARY
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As Integer
    Private _IDEN As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")

        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
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
        If Not IsPostBack Then

        End If
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY(_IDEN, _IDA_LCN)
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'Dim IDA_LCN As Integer = item("IDA_LCN").Text
            Dim IDA As Integer = item("IDA").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            If e.CommandName = "HL_SELECT" Then

                If STATUS_ID <> 0 Then
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POPUP_TABEAN_HERB_TEMPOLARY_ADD.aspx?IDA=" & IDA & "&PROCESS_ID=" & _ProcessID & "');", True)
                End If
            ElseIf e.CommandName = "HL3_SELECT" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " FRM_TABEAN_HERB_TEMPOLARY_APPOINMENT.aspx?IDA=" & IDA & "&PROCESS_ID=" & _ProcessID & "');", True)
            End If

        End If
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim TR_ID As String = item("TR_ID").Text
            Dim IDA As String = item("IDA").Text

            Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            Dim HL4_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            HL3_SELECT.Style.Add("display", "none")
            HL4_SELECT.Style.Add("display", "none")

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
            dao.GetdatabyID_IDA(IDA)
            Dim _IDEN As String = ""
            _IDEN = dao.fields.IDEN_Confirm
            'If _CLS.CITIZEN_ID_AUTHORIZE Then
            '    _IDEN = _CLS.CITIZEN_ID_AUTHORIZE
            'Else
            '    _IDEN = _CLS.CITIZEN_ID
            'End If

            Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
            ' Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=HERB&acc_type=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            If Request.QueryString("staff") <> "" Then
                urls &= "&staff=1&identify=" & _IDEN & "&system=staffherb"
            Else
                urls &= "&staff=1&identify=" & _IDEN & "&system=herb"
            End If
            Dim H As HyperLink = e.Item.FindControl("HL4_SELECT")
            H.Style.Add("display", "none")
            H.Target = "_blank"
            H.NavigateUrl = urls

            If STATUS_ID = 2 Then
                'HL4_SELECT.Style.Add("display", "block")
                H.Style.Add("display", "block")
            End If
            If STATUS_ID = 3 Then
                HL3_SELECT.Style.Add("display", "block")
            End If

        End If
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_HERB_TEMPOLARY_ADD.aspx?PROCESS_ID=" & _ProcessID & "&IDA_LCN=" & _IDA_LCN & "&IDENTIFY=" & _IDEN & "');", True)
        Catch ex As Exception

        End Try
    End Sub
End Class
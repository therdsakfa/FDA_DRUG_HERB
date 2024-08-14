Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_HERB_TABEAN_NEW_EDIT
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_DR As String = ""
    Private _PROCESS_ID As String = ""
    Private _PROCESS_DR As String = ""

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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_DR = Request.QueryString("IDA_DR")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _PROCESS_DR = Request.QueryString("PROCESS_DR")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_HL()
        End If
    End Sub
    Function bind_data()
        Dim dt As New DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        DAO_WHO.GetdatabyID_FK_LCN(_IDA_LCN)
        'If _PROCESS_DR.Contains("201") Then
        '    dt = bao.SP_TABEAN_RENEW_TBN_CUSTOMER(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_DR)
        'ElseIf _PROCESS_DR.Contains("203") Then
        '    dt = bao.SP_TABEAN_RENEW_JJ_CUSTOMER(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_DR)
        'End If
        dt = bao.SP_TABEAN_EDIT_REQUEST_CUSTOMER(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_LCN)                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        'RadGrid1.DataBind()
        Return dt
    End Function
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffherb"
        Else
            urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=staffherb"
        End If

        hl_pay.NavigateUrl = urls

    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA_LCN As String = item("IDA_LCN").Text
            Dim TR_ID_LCN As String = item("TR_ID_LCN").Text
            Dim FK_IDA_LCT As String = ""
            Try
                FK_IDA_LCT = item("IDA_LCT").Text
            Catch ex As Exception

            End Try
            'Dim _PROCESS_JJ As Integer = item("DDHERB").Text
            Dim IDA As Integer = item("IDA").Text
            Dim FK_IDA As Integer = item("FK_IDA").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            If e.CommandName = "sel" Then

                If STATUS_ID = 1 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_TABEAN_NEW_EDIT_CONFIRM.aspx?IDA_LCT=" &
                                                                      IDA_LCN & "&TR_ID_LCN=" & TR_ID_LCN & "&IDA_DR=" & _IDA_DR & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID & "&staff=" & Request.QueryString("staff") & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "POPUP_HERB_TABEAN_NEW_EDIT_CONFIRM.aspx?IDA_LCT=" &
                                                                     IDA_LCN & "&TR_ID_LCN=" & TR_ID_LCN & "&IDA_DR=" & _IDA_DR & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID & "&staff=" & Request.QueryString("staff") & "');", True)
                End If
            ElseIf e.CommandName = "HL3_SELECT" Then
                'lbl_head1.Text = "ใบนัดหมาย 1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_NEW_EDIT_APPOINMENT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN & "');", True)

            ElseIf e.CommandName = "HL4_SELECT" Then
                'lbl_head1.Text = "ใบนัดหมาย 1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_NEW_EDIT_APPOINMENT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN & "');", True)

            End If
        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.DataSource = bind_data()
        RadGrid1.DataBind()                         'เรียกฟังก์ชั่น  load_GV_JJ   มาใช้งาน
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim STATUS_ID As String = item("STATUS_ID").Text

            Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            Dim HL4_SELECT As LinkButton = DirectCast(item("HL4_SELECT").Controls(0), LinkButton)
            HL3_SELECT.Style.Add("display", "none")
            HL4_SELECT.Style.Add("display", "none")
            Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
            ' Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=HERB&acc_type=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            If Request.QueryString("staff") <> "" Then
                urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffherb"
            Else
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=herb"
            End If

            'Dim H As HyperLink = e.Item.FindControl("HL5_SELECT")
            'H.Style.Add("display", "none")
            'H.Target = "_blank"
            'H.NavigateUrl = urls

            If STATUS_ID = 3 Then
                'HL3_SELECT.Style.Add("display", "block")
            ElseIf STATUS_ID = 23 Or STATUS_ID = 14 Or STATUS_ID = 6 Then
                HL4_SELECT.Style.Add("display", "block")
            End If
        End If
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_HERB_TABEAN_NEW_EDIT_ADD.aspx?IDA_DR=" & _IDA_DR & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & "&staff=" & Request.QueryString("staff") & "');", True)
    End Sub
End Class
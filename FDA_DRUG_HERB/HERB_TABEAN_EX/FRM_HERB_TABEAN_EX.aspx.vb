Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_EX
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID_LCN As String = ""
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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()
            load_HL()
            UC_Information.Shows(_IDA_LCN)
        End If
    End Sub

    Function bind_data()
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dt As DataTable
        '"0000000000000"
        Dim CID As String = _CLS.CITIZEN_ID_AUTHORIZE
        'dt = bao.SP_CUSTOMER_LCN_BY_IDENTIFY_NO120(CID)
        dt = bao.SP_TABEAN_HERB_EX_BY_FK_IDA_LCN(_IDA_LCN)
        Return dt

    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As String = item("IDA").Text
            Dim IDA_LCN As Integer = item("LCN_IDA").Text
            Dim TR_ID As String = item("TR_ID").Text
            Dim PROCESS_ID As String = item("PROCESS_ID").Text
            Dim FK_IDA_LCT As String = ""
            Try
                FK_IDA_LCT = item("FK_IDA").Text
            Catch ex As Exception

            End Try
            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            If e.CommandName = "HL_SELECT" Then
                If Request.QueryString("staff") = 1 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "&staff=" & Request.QueryString("staff") & "');", True)
                Else
                    If STATUS_ID = 4 Then
                        'lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "&staff=" & Request.QueryString("staff") & "');", True)
                    ElseIf STATUS_ID = 1 Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_CONFIRM.aspx?IDA=" & IDA & "&IDA_LCN=" & IDA_LCN & "&staff=" & Request.QueryString("staff") & "');", True)
                        'ElseIf STATUS_ID = 3 Then
                        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_HERB_TABEAN_EX_APPOINMENT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_EX/FRM_HERB_TABEAN_EX_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "&DD_HERB_NAME_ID=" & "&staff=" & Request.QueryString("staff") & "');", True)

                    End If
                End If
            ElseIf e.CommandName = "HL3_SELECT" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_HERB_TABEAN_EX_APPOINMENT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
            ElseIf e.CommandName = "HL_EDIT" Then
                'lbl_head1.Text = "คำขอจดแจ้งผลิตภัณฑ์สมุนไพร แบบ จจ.1"
                Response.Redirect("FRM_HERB_TABEAN_EX_EDIT_RQT.aspx?IDA_EX=" & IDA & "&IDA_LCN=" & IDA_LCN & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & PROCESS_ID & "&staff=" & Request.QueryString("staff"))
            End If

        End If
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim STATUS_ID As String = item("STATUS_ID").Text

            Dim HL_EDIT As LinkButton = DirectCast(item("HL_EDIT").Controls(0), LinkButton)
            Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            HL_EDIT.Style.Add("display", "none")
            HL3_SELECT.Style.Add("display", "none")
            If STATUS_ID = 4 Then
                HL_EDIT.Style.Add("display", "block")
            ElseIf STATUS_ID = 3 Then
                HL3_SELECT.Style.Add("display", "block")
            End If

        End If
    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffherb"
        Else
            urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=herb"
        End If

        hl_pay.NavigateUrl = urls

    End Sub
    Protected Sub btn_ex_add_Click(sender As Object, e As EventArgs) Handles btn_ex_add.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.fields.CREATE_DATE = Date.Now
        dao.insert()
        Response.Redirect("FRM_HERB_TABEAN_EX_ADD.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_EX=" & dao.fields.IDA & "&PROCESS_ID=" & _PROCESS_ID & "&staff=" & Request.QueryString("staff"))
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        'bind_data()                             'เรียกฟังก์ชั่น  load_GV_lcnno   มาใช้งาน
        RadGrid1.Rebind()
    End Sub
End Class
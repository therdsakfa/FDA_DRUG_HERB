Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_HERB_TABEAN_JJ_EDIT1
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCN As String = ""
    Private IDA_JJ As String = ""
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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        IDA_JJ = Request.QueryString("IDA_JJ")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
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
        dt = bao.SP_XML_TABEAN_JJ_EDIT_REQUEST(_CLS.CITIZEN_ID_AUTHORIZE, IDA_JJ)                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        'RadGrid1.DataBind()
        Return dt
    End Function

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
            Dim DD As Integer = 0
            Try
                DD = item("DD_HERB_NAME_ID").Text
            Catch ex As Exception

            End Try

            'Dim _PROCESS_JJ As Integer = item("DDHERB").Text
            Dim IDA As Integer = item("IDA").Text
            Dim FK_IDA As Integer = item("FK_IDA").Text
            Dim TR_ID_JJ As Integer = item("TR_ID_JJ").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            If e.CommandName = "HL_SELECT" Then

                If STATUS_ID = 1 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_COMFIRM.aspx?IDA_LCT=" &
                                                                      IDA_LCN & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "');", True)
                ElseIf STATUS_ID = 4 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_FILE_UPLOAD.aspx?IDA_LCT=" &
                                                                      IDA_LCN & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "');", True)

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_COMFIRM.aspx?IDA_LCT=" &
                                                                     IDA_LCN & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "');", True)
                End If
            ElseIf e.CommandName = "HL3_SELECT" Then
                'lbl_head1.Text = "ใบนัดหมาย 1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT_APPOINMENT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN & "');", True)
            ElseIf e.CommandName = "HL4_SELECT" Then
                'lbl_head1.Text = "ใบนัดหมาย 2"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT_APPOINMENT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN & "');", True)

            End If
        End If
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

            If STATUS_ID = 3 Then
                'HL3_SELECT.Style.Add("display", "block")
            ElseIf STATUS_ID = 23 Then
                HL4_SELECT.Style.Add("display", "block")
            End If
        End If
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()                        'เรียกฟังก์ชั่น  load_GV_JJ   มาใช้งาน
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.insert()
        ' FRM_HERB_TABEAN_JJ_EDIT_ADD
        Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT_ADD.aspx?IDA_JJ=" & IDA_JJ & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & dao.fields.IDA)
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
End Class
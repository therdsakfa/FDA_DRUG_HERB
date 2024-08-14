Imports Telerik.Web.UI

Public Class FRM_TABEAN_SEARCH_MAIN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _TR_ID_LCN As String = ""
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
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            RadGrid1.Rebind()
        End If
    End Sub

    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        'If txt_rgt_no.Text = "" Then
        '    dt = bao.SP_XML_TABEAN_HERB_BY_IDEN_124(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_LCN)
        'Else
        dt = bao.SP_XML_TABEAN_HERB_BY_REGISTER(txt_rgt_no.Text)
        'dt = bao.SP_XML_TABEAN_DRRQT_BY_RGTNO(txt_rgt_no.Text)
        'End If
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim IDA_DR As Integer = item("IDA").Text
            Dim FK_LCN_IDA As String = item("FK_LCN_IDA").Text
            Dim PROCESS_ID As String = item("PROCESS_ID").Text
            Dim TR_ID_DR As String = item("TR_ID").Text

            'Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            'H.NavigateUrl = "FRM_HERB_TABEAN_NEW_EDIT.aspx?IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & IDA_DR & "&MENU_GROUP=" & _MENU_GROUP & "&PROCESS_DR=" & PROCESS_ID & "&TR_ID_DR=" & TR_ID_DR & "&PROCESS_ID=" & _PROCESS_ID 'URL หน้า ยืนยัน
        End If
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim IDA_DR As Integer = item("IDA").Text
            Dim FK_LCN_IDA As String = item("FK_LCN_IDA").Text
            Dim PROCESS_ID As String = item("PROCESS_ID").Text
            Dim TR_ID_DR As String = item("TR_ID").Text
            Dim NEWCODE As String = item("Newcode").Text
            Dim IDA_G As String = item("IDA_G").Text

            'Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            'H.NavigateUrl = "FRM_HERB_TABEAN_NEW_EDIT.aspx?IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & IDA_DR & "&MENU_GROUP=" & _MENU_GROUP & "&PROCESS_DR=" & PROCESS_ID & "&TR_ID_DR=" & TR_ID_DR & "&PROCESS_ID=" & _PROCESS_ID 'URL หน้า ยืนยัน

            If e.CommandName = "sel" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('POPUP_SEARCH_TABEAN_DETAIL.aspx?IDA=" & IDA_DR & "&TR_ID=" & TR_ID_DR & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & FK_LCN_IDA & "&Newcode=" & NEWCODE & "&IDA_G=" & IDA_G & "');", True)
            End If
        End If
    End Sub

    Sub alert_error(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        dt = bao.SP_XML_TABEAN_HERB_BY_IDEN_AND_RGTNO(_CLS.CITIZEN_ID_AUTHORIZE, txt_rgt_no.Text)
        'dt = bao.SP_XML_TABEAN_HERB_BY_IDEN(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_LCN)
        'RadGrid1.DataSource = dt
        RadGrid1.Rebind()
    End Sub
End Class
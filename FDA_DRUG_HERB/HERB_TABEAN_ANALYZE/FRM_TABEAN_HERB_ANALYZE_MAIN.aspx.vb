Imports Telerik.Web.UI

Public Class FRM_TABEAN_HERB_ANALYZE_MAIN
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

        End If
    End Sub

    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        If DD_DRRGT_PROCESS_ID.SelectedValue = 20610 Then
            dt = bao.SP_XML_TABEAN_HERB_BY_IDEN(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_LCN)
        ElseIf DD_DRRGT_PROCESS_ID.SelectedValue = 20620 Then
            'dt = bao.SP_HERB_TABEAN_BY_IDEN_AND_FK_IDA(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_LCN, DD_DRRGT_PROCESS_ID.SelectedValue)
        ElseIf DD_DRRGT_PROCESS_ID.SelectedValue = 20630 Then
            dt = bao.SP_XML_TABEAN_JJ_BY_IDEN(_CLS.CITIZEN_ID_AUTHORIZE, _IDA_LCN)
        End If

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

            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            H.NavigateUrl = "FRM_TABEAN_SUBSTITUTE_SUB_DR.aspx?IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & IDA_DR & "&MENU_GROUP=" & _MENU_GROUP & "&PROCESS_ID_DR=" & PROCESS_ID & "&TR_ID_DR=" & TR_ID_DR & "&PROCESS_ID=" & DD_DRRGT_PROCESS_ID.SelectedValue 'URL หน้า ยืนยัน

        End If
    End Sub

    Private Sub DD_DRRGT_PROCESS_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_DRRGT_PROCESS_ID.SelectedIndexChanged

        If DD_DRRGT_PROCESS_ID.SelectedValue = 20610 Or DD_DRRGT_PROCESS_ID.SelectedValue = 20620 Or DD_DRRGT_PROCESS_ID.SelectedValue = 20630 Then
            TB1.Visible = True
            RadGrid1.Rebind()
        Else
            TB1.Visible = False
        End If

    End Sub

    Sub alert_error(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

End Class
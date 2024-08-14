Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_INFORM_SELECT_LCN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _SID As String = ""
    Private _PAGE_MENU As String = ""

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
        _SID = _CLS.SID_ID
        _PAGE_MENU = Request.QueryString("PAGE_MENU")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            If _PAGE_MENU = "" Then
                div_news.Visible = True
            Else
                div_news.Visible = False
                T1.Visible = True
            End If
        End If
    End Sub

    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable
        '"0000000000000"
        Dim CID As String = _CLS.CITIZEN_ID_AUTHORIZE
        dt = bao.SP_CUSTOMER_LCN_BY_IDENTIFY_NO120(CID)
        Return dt

    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA_LCN As Integer = item("IDA").Text
            Dim TR_ID_LCN As String = item("TR_ID").Text
            Dim PROCESS_ID As String = item("PROCESS_ID").Text
            Dim FK_IDA_LCT As String = ""
            Try
                FK_IDA_LCT = item("FK_IDA").Text
            Catch ex As Exception

            End Try

            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")

            H.NavigateUrl = "../HERB_TABEAN_INFORM/FRM_HERB_TABEAN_INFORM.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & PROCESS_ID & "&SID=" & _SID 'URL หน้า ยืนยัน

        End If
    End Sub

End Class
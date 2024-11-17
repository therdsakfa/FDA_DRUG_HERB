Imports Telerik.Web.UI
Public Class FRM_SELECT_PROCESS_LCN
    Inherits System.Web.UI.Page
    Private _MENU_GROUP As String = ""
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim TR_ID As String = item("TR_ID").Text
            Dim FK_IDA As String = ""
            Try
                FK_IDA = item("FK_IDA").Text
            Catch ex As Exception

            End Try
            'Dim DAO As New DAO_CPN.clsDBsyslcnsnm

            'Dim sql As String
            'sql = "select URL from tb_User where IDA = '&MAS_MENU=" & 

            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            If Request.QueryString("ttt") = 2 Then
                H.NavigateUrl = "../MAIN/FRM_SELECT_PROCESS_LCN_MAIN.aspx?lct_ida=" & FK_IDA & "&TR_ID=" & TR_ID & "&lcn_ida=" & IDA & "&ttt=" & Request.QueryString("ttt") & "&MENU_GROUP=" & _MENU_GROUP 'URL หน้า ยืนยัน
            Else
                H.NavigateUrl = "../MAIN/FRM_SELECT_PROCESS_LCN_MAIN.aspx?lct_ida=" & FK_IDA & "&TR_ID=" & TR_ID & "&lcn_ida=" & IDA & "&ttt=" & Request.QueryString("ttt") & "&MENU_GROUP=" & _MENU_GROUP 'URL หน้า ยืนยัน
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        'If IDGroup = 21020 Then
        'RadGrid1.DataSource = bao.SP_CUSTOMER_LCN_DR_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)
        RadGrid1.DataSource = bao.SP_CUSTOMER_LCN_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)
        'RadGrid1.DataSource = dt

    End Sub
End Class
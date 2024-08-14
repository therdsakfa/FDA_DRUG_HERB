Imports Telerik.Web.UI

Public Class FRM_HERB_WHO
    Inherits System.Web.UI.Page
    Private _MENU_GROUP As String = ""
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        '
        _MENU_GROUP = 999
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
        Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

    Function bind_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        '_CLS.CITIZEN_ID_AUTHORIZE
        Dim CITIZEN_ID_AUTHORIZE As String = "0000000000000"
        dt = bao.SP_CUSTOMER_LCN_DR_BY_IDENTIFY(CITIZEN_ID_AUTHORIZE)
        'RadGrid1.DataSource = dt
        'RadGrid1.Rebind()

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        'bind_data()
        'RadGrid1.DataBind()
        RadGrid1.DataSource = bind_data()
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

            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")

            H.NavigateUrl = "../HERB_WHOEVER/FRM_HERB_WHO_ADD.aspx?lct_ida=" & FK_IDA & "&TR_ID=" & TR_ID & "&lcn_ida=" & IDA & "&MENU_GROUP=" & _MENU_GROUP 'URL หน้า ยืนยัน


        End If
    End Sub

End Class
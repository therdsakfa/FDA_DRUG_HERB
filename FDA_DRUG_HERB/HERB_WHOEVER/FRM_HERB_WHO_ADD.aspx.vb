Imports Telerik.Web.UI

Public Class FRM_HERB_WHO_ADD
    Inherits System.Web.UI.Page
    Private _IDA_LCT As String
    Private _IDA_LCN As String
    Private _TR_ID_LCN As String
    Private _MENU_GROUP As String
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try

        _IDA_LCT = Request.QueryString("lct_ida")
        _IDA_LCN = Request.QueryString("lcn_ida")
        _TR_ID_LCN = Request.QueryString("TR_ID")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            RadGrid1.Rebind()
        End If
    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        lbl_head1.Text = "เพิ่มข้อมูล"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_WHO_ADD_DETAIT.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "');", True)
    End Sub

    Function bind_data()
        Dim bao As New BAO_WHO.tb_who
        Dim dt As New DataTable
        '_CLS.CITIZEN_ID_AUTHORIZE
        Dim CITIZEN_ID_AUTHORIZE As String = "0000000000000"
        dt = bao.SP_WHO_DALCN(CITIZEN_ID_AUTHORIZE)
        'RadGrid1.DataSource = dt
        'RadGrid1.Rebind()

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        'bind_data()
        'RadGrid1.Rebind()
        RadGrid1.DataSource = bind_data()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        'If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
        '    Dim item As GridDataItem
        '    item = e.Item
        '    Dim IDA As Integer = item("IDA").Text
        '    Dim TR_ID As String = item("TR_ID").Text
        '    Dim FK_IDA As String = ""
        '    Try
        '        FK_IDA = item("FK_IDA").Text
        '    Catch ex As Exception

        '    End Try

        '    Dim H As HyperLink = e.Item.FindControl("HL_SELECT")

        '    H.NavigateUrl = "../HERB_WHOEVER/FRM_HERB_WHO_ADD.aspx?lct_ida=" & FK_IDA & "&TR_ID=" & TR_ID & "&lcn_ida=" & IDA & "&MENU_GROUP=" & _MENU_GROUP 'URL หน้า ยืนยัน
        '    lbl_head1.Text = "เพิ่มข้อมูล"
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_WHO_DETAIT.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "');", True)

        'End If

    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

End Class
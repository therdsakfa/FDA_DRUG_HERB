Public Class FRM_HERB_TABEAN_JJ_PREVIEW_JJ2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _PROCESS_JJ As String
    Private _IDA_LCN As String
    Private _DD_HERB_NAME_ID As String

    Sub RunSession()
        _PROCESS_JJ = Request.QueryString("PROCESS_JJ")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")

        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

            Run_Pdf_Tabean_Herb()

        End If
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_PROCESS_JJ, dao.fields.STATUS_ID, "จจ2", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _PROCESS_JJ, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub

    'Function bind_data_uploadfile()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_main

    '    dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 1)

    '    Return dt
    'End Function

    'Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
    '    RadGrid2.DataSource = bind_data_uploadfile()
    'End Sub

    'Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If

    'End Sub

    'Function bind_data_file_recipe_production()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_main

    '    dt = bao.SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ(_DD_HERB_NAME_ID)

    '    Return dt
    'End Function

    'Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
    '    RadGrid3.DataSource = bind_data_file_recipe_production()
    'End Sub

    'Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text
    '        Dim DD_HERB_NAME_PRODUCT_ID As Integer = item("DD_HERB_NAME_PRODUCT_ID").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "FRM_HERB_TABEAN_JJ_RECIPE_PRODUCT_PREVIEW_FILE.aspx?IDA=" & IDA

    '    End If

    'End Sub

End Class
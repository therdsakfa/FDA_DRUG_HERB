Public Class FRM_HERB_LCN_RENEW_PHR_PREVIEW
    Inherits System.Web.UI.Page

    Private _id As Integer

    Private Sub get_querystring()
        _id = Request.QueryString("IDA")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_querystring()
        If Not IsPostBack Then
            bind_file()
        End If
    End Sub

    Private Sub bind_file()
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(_id)
        Dim _ProcessID As String = dao.fields.PROCESS_ID

        'Dim XML As New CLASS_GEN_XML.DALCN_PHR_NEW
        'LCN_PHR = XML.Gen_XML_PHR(_id)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.phr_status, "สมพ4", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_PHR") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PHR_PDF", _ProcessID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _id)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("PHR_XML", _ProcessID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _id)

        Dim FILENAME_XML As String = Path_XML
        Dim bao As New BAO.AppSettings

        'Dim paths As String = bao._PATH_XML_PDF_PHR

        'Dim PATH_XML As String
        'Path_XML = paths & "FILE_UPLOAD\" & FILENAME_XML

        Dim clsds As New ClassDataset
        Dim output As Byte()
        'Try
        '    output = clsds.UpLoadImageByte(Path_XML)
        '    Response.Clear()
        '    Response.ContentType = "application/pdf"
        '    Response.BinaryWrite(output)
        '    Response.Flush()
        '    Response.End()
        'Catch ex As Exception
        Blind_PDF()
        'output = clsds.UpLoadImageByte(Path_XML)
        'Response.Clear()
        'Response.ContentType = "application/pdf"
        'Response.BinaryWrite(output)
        'Response.Flush()
        'Response.End()
        'End Try


    End Sub
    Sub Blind_PDF()
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(_id)
        Dim _Process_ID As String = dao.fields.PROCESS_ID

        Dim XML As New CLASS_GEN_XML.DALCN_PHR_NEW
        LCN_PHR = XML.Gen_XML_PHR(_id)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_Process_ID, dao.fields.phr_status, "สมพ4", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_PHR") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PHR_PDF", _Process_ID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _id)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("PHR_XML", _Process_ID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _id)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _Process_ID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        '_CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        '_CLS.PDFNAME = PATH_PDF_OUTPUT
        '_CLS.FILENAME_XML = Path_XML
        'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub

End Class
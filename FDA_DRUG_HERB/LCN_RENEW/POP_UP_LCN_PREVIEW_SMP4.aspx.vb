Public Class POP_UP_LCN_PREVIEW_SMP4
    Inherits System.Web.UI.Page

    Private _id As Integer

    Private Sub get_querystring()
        _id = Request.QueryString("ida")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_querystring()
        If Not IsPostBack Then
            bind_file()
        End If
    End Sub

    Private Sub bind_file()
        Try
            'Dim dao As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            'dao.GetDataby_IDA(_id)
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            dao.GetDataby_IDA(_id)
            Dim PROCESS_ID As String = dao.fields.PROCESS_ID
            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(dao.fields.PROCESS_ID, dao.fields.phr_status, "สมพ4", 0)
            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_PHR") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            'Dim FILENAME_XML As String = dao.fields.NAME_FAKE
            Dim bao As New BAO.AppSettings
            Dim paths As String = bao._PATH_XML_PDF_PHR
            Dim PATH_XML As String
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PHR_PDF", PROCESS_ID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _id)
            PATH_XML = PATH_PDF_OUTPUT
            Dim clsds As New ClassDataset
            Dim output As Byte()
            output = clsds.UpLoadImageByte(PATH_XML)
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(output)
            Response.Flush()
            Response.End()
        Catch ex As Exception
            Blind_PDF()
            alert("ระบบไม่เจอเอกสารที่ท่านเปิด" & ex.Message)
        End Try
    End Sub
    Sub Blind_PDF()
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(_id)
        Dim _Process_ID As String = dao.fields.PROCESS_ID

        Dim XML As New CLASS_GEN_XML.DALCN_PHR_NEW
        LCN_PHR = XML.Gen_XML_PHR(_id)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_PROCESS_ID, dao.fields.phr_status, "สมพ4", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_PHR") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PHR_PDF", _Process_ID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _id)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("PHR_XML", _Process_ID, dao.fields.YEAR, dao.fields.TRANSECTION_ID_UPLOAD, _id)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID, PATH_PDF_OUTPUT)

        '_CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        '_CLS.PDFNAME = PATH_PDF_OUTPUT
        '_CLS.FILENAME_XML = Path_XML
        'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class
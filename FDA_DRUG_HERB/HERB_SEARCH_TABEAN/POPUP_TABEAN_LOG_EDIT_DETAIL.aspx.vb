Public Class POPUP_TABEAN_LOG_EDIT_DETAIL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_LCN As String

    Sub RunSession()
        _IDA = Request.QueryString("IDA")

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
        'Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        'dao_dq.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        Dim process_id As String = 30001
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(process_id, 0, "log", 0)
        _IDA_LCN = dao.fields.FK_LCN_IDA
        Dim XML As New CLASS_GEN_XML.TABEAN_NEW_EDIT
        TBN_NEW_EDIT = XML.GEN_XML_TABEAN_NEW_EDIT(_IDA, _IDA_LCN)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", process_id, Date.Now.Year, dao.fields.TR_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", process_id, Date.Now.Year, dao.fields.TR_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, process_id, PATH_PDF_OUTPUT)
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub
End Class
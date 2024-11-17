Public Class FRM_HERB_TABEAN_INFORM_PREVIEW_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _SLDDL As String

    Sub RunSession()
        _IDA = Request.QueryString("IDA")
        _SLDDL = Request.QueryString("SLDDL")
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
        'Dim bao_app As New BAO.AppSettings
        'bao_app.RunAppSettings()
        'Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        'dao_dq.GetDataby_IDA(_IDA)
        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        'dao.GetdatabyID_FK_IDA_DQ(_IDA)

        'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(dao_dq.fields.PROCESS_ID, dao_dq.fields.STATUS_ID, "จร2", 0)

        'Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path

        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", dao_dq.fields.PROCESS_ID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(_IDA)
        Dim PROCESS_ID As String = dao.fields.PROCESS_ID
        Dim IDA_LCN As String = dao.fields.FK_LCN

        Dim XML As New CLASS_GEN_XML.TABEAN_INFORM
        TBN_INFORM = XML.GEN_XML_INFORM_JR2(_IDA, IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(PROCESS_ID, dao.fields.STATUS_ID, "จร2", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_INFORM") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF_JR2", PROCESS_ID, Date.Now.Year, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML_JR2", PROCESS_ID, Date.Now.Year, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)
        lr_preview.Text = "<iframe id='iframe1'  style='height:9500px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub
End Class
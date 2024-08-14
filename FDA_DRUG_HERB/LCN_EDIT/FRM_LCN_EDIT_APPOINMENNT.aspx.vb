Public Class FRM_LCN_EDIT_APPOINMENNT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String = ""

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")

        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            bind_pdf()
        End If

    End Sub

    Private Sub bind_pdf()
        Dim cls As New CLASS_GEN_XML.APPOINTMAENT
        Dim xml As New CLASS_APPOINTMENT

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.FK_LCN_IDA)

        Dim dao_adr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_adr.GetDataby_IDA(dao_lcn.fields.FK_IDA)

        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao.fields.LCN_IDENTIFY)

        Dim LCNNO_DISPLAY_NEW As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanm As String = dao_lcn.fields.thanm
        Dim tel As String = dao_lcn.fields.tel
        Dim NAME_JJ As String = dao_lcn.fields.thanm
        Dim RCVNO_FULL As String = dao.fields.STAFF_RQ_NUMBER
        'Dim NAME_THAI_NAME_PLACE As String = dao.fields.thanameplace '& " / " & dao_lcn.fields.thanm
        Dim NAME_THAI_NAME_PLACE As String = dao_adr.fields.thanameplace '& " / " & dao_lcn.fields.thanm
        Dim date_con_full As String = ""
        Dim date_appo_full As String = ""
        Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
        Dim date_result_start As Date
        Dim date_result_end As Date
        Dim date_result_est_start As Date
        Dim date_result_est_end As Date
        Dim days_start As Integer = 0
        Dim days_end As Integer = 11
        Dim days_est_start As Integer = 0
        Dim days_est_end As Integer = 1
        Dim number_day_start As String = ""
        Dim number_day_end As String = ""
        Dim number_day_est_start As String = ""
        Dim number_day_est_end As String = ""
        'Try
        '    ws.GETDATE_WORKING(CDate(dao.fields.UPDATE_DATE), True, days_start, True, date_result_start, True)
        '    ws.GETDATE_WORKING(CDate(dao.fields.UPDATE_DATE), True, days_end, True, date_result_end, True)
        'Catch ex As Exception

        'End Try
        Dim date_pay As String = ""
        Try
            date_pay = date_to_thai(dao.fields.UPDATE_DATE)
        Catch ex As Exception
            date_pay = date_to_thai(dao.fields.DATE_CONFIRM)
        End Try
        ws.GETDATE_WORKING(CDate(date_pay), True, days_start, True, date_result_start, True)
        ws.GETDATE_WORKING(CDate(date_pay), True, days_end, True, date_result_end, True)

        number_day_start = date_result_start.ToLongDateString()
        number_day_end = date_result_end.ToLongDateString()
        number_day_est_start = date_result_est_start.ToLongDateString()
        number_day_est_end = date_result_est_end.ToLongDateString()

        'If dao.fields.STATUS_ID = 11 Then
        If dao.fields.STATUS_ID = 2 Then
            dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, dao.fields.STATUS_ID, "APPOINMENT_LCN_EDIT", 0)
            date_con_full = number_day_start
            date_appo_full = number_day_end
        End If

        cls.process_id = _ProcessID
        cls.lcnno_display_new = LCNNO_DISPLAY_NEW
        cls.rcvno_full = RCVNO_FULL
        cls.name_thai_name_place = NAME_THAI_NAME_PLACE
        cls.date_req_full = date_con_full
        cls.thanm = thanm
        'cls.thanm = thanm
        cls.NAME_CONTACT = dao.fields.Appoinment_Contact
        cls.TR_ID = dao.fields.TR_ID
        'cls.NAME_CONTACT = NAME_JJ
        cls.E_MAIL = dao.fields.Appoinment_Email
        cls.tel_callback = dao.fields.Appoinment_Phone
        'cls.tel_callback = tel
        cls.citizen_id = _CLS.CITIZEN_ID
        cls.appointment_date = date_appo_full
        cls.group_assign = "กลุ่มสถานที่ กองผลิตภัณฑ์สมุนไพร"

        xml = cls.XML_APOINTMENT()
        TB_AP = xml
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(_TR_ID)
        Dim YEAR As String = dao_up.fields.YEAR
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_EDIT_APPOINMENT") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_APPOINTMENT("HB_PDF", _ProcessID, YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_APPOINTMENT("HB_XML", _ProcessID, YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, "AP", PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
End Class
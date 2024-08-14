Public Class FRM_HERB_TABEAN_EX_APPOINMENT
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

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao.fields.CUSTOMER_CITIZEN_AUTHORIZE)

        Dim LCNNO_DISPLAY_NEW As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanm As String = dao_lcn.fields.thanm
        Dim tel As String = dao_lcn.fields.tel
        Dim NAME_JJ As String = dao.fields.CUSTOMER_NAME
        Dim RCVNO_FULL As String = dao.fields.RCVNO_DISPLAY
        Dim NAME_THAI_NAME_PLACE As String = dao.fields.EX_NAME_PRODUCT '& " / " & dao_lcn.fields.thanm

        'Dim date_req_day As Date
        'Dim date_req_month As Date
        'Dim date_req_year As Date
        'Dim date_req_full As String = ""

        'Dim date_con_day As Date
        'Dim date_con_month As Date
        'Dim date_con_year As Date
        Dim date_con_full As String = ""
        Dim date_appo_full As String = ""

        'Dim date_est_day As Date
        'Dim date_est_month As Date
        'Dim date_est_year As Date

        'Dim date_conceder_day As Date
        'Dim date_conceder_month As Date
        'Dim date_conceder_year As Date

        Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
        Dim date_result_start As Date
        Dim date_result_end As Date
        Dim date_result_est_start As Date
        Dim date_result_est_end As Date
        Dim days_start As Integer = 0
        Dim days_end As Integer = 0
        Dim days_est_start As Integer = 0
        Dim days_est_end As Integer = 0
        Dim number_day_start As String = ""
        Dim number_day_end As String = ""
        Dim number_day_est_start As String = ""
        Dim number_day_est_end As String = ""
        ws.GETDATE_WORKING(CDate(dao.fields.EX_DATE_CONFIRM), True, days_start, True, date_result_start, True)
        ws.GETDATE_WORKING(CDate(dao.fields.EX_DATE_CONFIRM), True, days_end, True, date_result_end, True)

        number_day_start = date_result_start.ToLongDateString()
        number_day_end = date_result_end.ToLongDateString()
        number_day_est_start = date_result_est_start.ToLongDateString()
        number_day_est_end = date_result_est_end.ToLongDateString()

        If dao.fields.STATUS_ID = 3 Then
            dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, dao.fields.STATUS_ID, "APPROVE_EX_1", 0)

            'date_con_day = dao_deeqt.fields.DATE_CONFIRM
            'date_con_month = dao_deeqt.fields.DATE_CONFIRM
            'date_con_year = dao_deeqt.fields.DATE_CONFIRM

            'date_con_full = date_con_day.Day.ToString() + 1 & " " & date_con_month.ToString("MMMM") & " " & con_year(date_con_year.Year)
            'date_req_full = date_con_day.Day.ToString() + 41 & " " & date_con_month.ToString("MMMM") & " " & con_year(date_con_year.Year)

            date_con_full = number_day_start
            date_appo_full = number_day_end

            'ElseIf dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 12 Then
            '    dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, dao.fields.STATUS_ID, "APPROVE_TBN_1", 0)

            '    'date_req_day = dao.fields.DATE_REQ
            '    'date_req_month = dao.fields.DATE_REQ
            '    'date_req_year = dao.fields.DATE_REQ

            '    'date_con_full = date_req_day.Day.ToString() + 1 & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
            '    'date_req_full = date_req_day.Day.ToString() + 41 & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)

            '    date_con_full = number_day_start
            '    date_appo_full = number_day_end

            'ElseIf dao.fields.STATUS_ID = 13 Then
            '    dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, dao.fields.STATUS_ID, "APPROVE_TBN_2", 0)

            '    date_con_full = number_day_est_start
            '    date_appo_full = number_day_est_end

            'date_est_day = dao_deeqt.fields.ESTIMATE_DATE
            'date_est_month = dao_deeqt.fields.ESTIMATE_DATE
            'date_est_year = dao_deeqt.fields.ESTIMATE_DATE

            'date_con_full = date_est_day.Day.ToString() + 1 & " " & date_est_month.ToString("MMMM") & " " & con_year(date_est_year.Year)
            'date_req_full = date_est_day.Day.ToString() + 41 & " " & date_est_month.ToString("MMMM") & " " & con_year(date_est_year.Year)
            'ElseIf dao.fields.STATUS_ID = 6 Then
            '    dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, dao.fields.STATUS_ID, "APPROVE_TBN_2", 0)

            '    date_conceder_day = dao_deeqt.fields.CONSIDER_DATE
            '    date_conceder_month = dao_deeqt.fields.CONSIDER_DATE
            '    date_conceder_year = dao_deeqt.fields.CONSIDER_DATE

            '    date_con_full = date_conceder_day.Day.ToString() & " " & date_conceder_month.ToString("MMMM") & " " & con_year(date_conceder_year.Year)
            '    date_req_full = date_conceder_day.Day.ToString() + 7 & " " & date_conceder_month.ToString("MMMM") & " " & con_year(date_conceder_year.Year)
        End If

        cls.process_id = _ProcessID
        cls.lcnno_display_new = LCNNO_DISPLAY_NEW
        cls.rcvno_full = RCVNO_FULL
        cls.name_thai_name_place = NAME_THAI_NAME_PLACE
        cls.date_req_full = date_con_full
        cls.thanm = thanm
        'cls.thanm = thanm
        cls.NAME_CONTACT = dao.fields.Appoinment_Contact
        'cls.NAME_CONTACT = NAME_JJ
        cls.E_MAIL = dao.fields.Appoinment_Email
        cls.tel_callback = dao.fields.Appoinment_Phone
        'cls.tel_callback = tel
        cls.citizen_id = _CLS.CITIZEN_ID
        cls.appointment_date = date_appo_full
        cls.group_assign = "ศูนย์บริการผลิตภัณฑ์สุขภาพเบ็ดเสร็จ"
        cls.DISCOUNT_DETAIL = dao.fields.Discount_RequestName
        cls.TR_ID = dao.fields.TR_ID

        xml = cls.XML_APOINTMENT()
        TB_AP = xml

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_APPOINTMENT("HB_PDF", _ProcessID, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_APPOINTMENT("HB_XML", _ProcessID, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, "AP", PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
End Class
Public Class FRM_TABEAN_HERB_TEMPOLARY_APPOINMENT
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

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_TABEAN_EDIT_TEMPOLARY
        Try
            dao_p.Getdataby_ID(dao.fields.Will_RequestID)
        Catch ex As Exception

        End Try


        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Try
            dao_lcn.GetDataby_IDA(dao.fields.FK_LCN)
            dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        Catch ex As Exception

        End Try

        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

        ' Dim LCNNO_DISPLAY_NEW As String = DAO_LCN.fields.LCNNO_DISPLAY_NEW
        Dim LCNNO_DISPLAY_NEW As String = ""
        Dim thanm As String = dao.fields.Name_Confirm
        'Dim tel As String = dao_lcn.fields.tel
        'Dim NAME_JJ As String = dao.fields.NAME_JJ
        Dim RCVNO_FULL As String = dao.fields.RCVNO_FULL
        Dim NAME_THAI_NAME_PLACE As String = ""
        If dao.fields.IDEN_Confirm = dao.fields.CITIZEN_ID_AUTHORIZE Then
            NAME_THAI_NAME_PLACE = dao_addr.fields.thanameplace
        End If

        'Dim NAME_THAI_NAME_PLACE As String = ""

        Dim date_con_full As String = ""
        Dim date_appo_full As String = ""


        Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
        Dim date_result_start As Date
        Dim date_result_end As Date

        Dim days_start As Integer = 1
        Dim days_end As Integer = 20

        Dim number_day_start As String = ""
        Dim number_day_end As String = ""
        Dim number_day_est_start As String = ""
        Dim number_day_est_end As String = ""

        Try
            If dao_p.fields.ID = 14 Then
                days_end = 20
            End If

        Catch ex As Exception

        End Try
        Dim date_pay As Date
        Try
            date_pay = dao.fields.DATE_PAY
        Catch ex As Exception
            date_pay = dao.fields.Date_Confirm
        End Try

        ws.GETDATE_WORKING(CDate(date_pay), True, days_start, True, date_result_start, True)
        ws.GETDATE_WORKING(CDate(date_pay), True, days_end, True, date_result_end, True)
        'ws.GETDATE_WORKING(CDate(dao.fields.DATE_CONFIRM), True, days_start, True, date_result_start, True)
        'ws.GETDATE_WORKING(CDate(dao.fields.DATE_CONFIRM), True, days_end, True, date_result_end, True)
        Dim bao2 As New BAO.ClsDBSqlcommand
        Dim stop_days As Double = 0

        number_day_start = date_result_start.ToLongDateString()
        number_day_end = date_result_end.ToLongDateString()

        If dao.fields.STATUS_ID = 3 Then
            dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, dao.fields.STATUS_ID, "APPROVE_TBN_1", 0)

            date_con_full = number_day_start
            date_appo_full = number_day_end

            cls.appointment_date = date_appo_full
            cls.DISCOUNT_DETAIL = ""
        End If

        cls.process_id = _ProcessID
        cls.lcnno_display_new = LCNNO_DISPLAY_NEW
        'cls.rcvno_full = RCVNO_FULL
        cls.rcvno_full = RCVNO_FULL
        cls.name_thai_name_place = NAME_THAI_NAME_PLACE
        cls.date_req_full = ""
        cls.thanm = thanm
        'cls.thanm = thanm
        cls.NAME_CONTACT = dao.fields.Contact_Person
        'cls.NAME_CONTACT = NAME_JJ
        cls.E_MAIL = dao.fields.E_mail
        cls.tel_callback = dao.fields.Phone
        'cls.tel_callback = tel
        cls.citizen_id = _CLS.CITIZEN_ID
        cls.group_assign = "ศูนย์บริการผลิตภัณฑ์สุขภาพเบ็ดเสร็จ"
        Try
            cls.TR_ID = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        cls.process_name = dao_p.fields.process_Name

        xml = cls.XML_APOINTMENT()
        TB_AP = xml
        Dim DATE_YEAR As String = con_year(Date.Now().Year())

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_APPOINTMENT("HB_PDF", _ProcessID, DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_APPOINTMENT("HB_XML", _ProcessID, DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, "AP", PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
End Class
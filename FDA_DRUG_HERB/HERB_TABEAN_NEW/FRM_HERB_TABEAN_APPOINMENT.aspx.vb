Public Class FRM_HERB_TABEAN_APPOINMENT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String = ""
    Private _APP_ID As String = ""

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID_DQ")
        _IDA = Request.QueryString("IDA_DQ")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _APP_ID = Request.QueryString("APPPOIN_ID")

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

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)
        Dim complex_cd As Integer = 0
        If dao.fields.COMPLEX_CD IsNot Nothing AndAlso Not IsDBNull(dao.fields.COMPLEX_CD) Then
            complex_cd = dao.fields.COMPLEX_CD
        End If

        Dim dao_c As New DAO_TABEAN_HERB.TB_MAS_COMPLEX_DATE_HERB
        dao_c.GetdatabyID(complex_cd)


        Dim LCNNO_DISPLAY_NEW As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanm As String = SEARCH_NAME_BY_CITIZEN(dao.fields.CITIZEN_ID_AUTHORIZE)
        Dim tel As String = dao_lcn.fields.tel
        Dim NAME_JJ As String = dao.fields.NAME_JJ
        Dim RCVNO_FULL As String = dao_deeqt.fields.RCVNO_NEW
        Dim NAME_THAI_NAME_PLACE As String = dao.fields.NAME_THAI '& " / " & dao.fields.NAME_PLACE_JJ

        'Dim date_req_day As Date
        'Dim date_req_month As Date
        'Dim date_req_year As Date
        'Dim date_req_full As String = ""

        'Dim date_con_day As Date
        'Dim date_con_month As Date
        'Dim date_con_year As Date
        Dim date_con_full As String = ""
        Dim date_appo_full As String = ""
        Dim Conplicate_name As String = ""

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
        Dim days_end As Integer = 19
        Dim days_est_start As Integer = 0
        Dim days_est_end As Integer = 19
        Dim number_day_start As String = ""
        Dim number_day_end As String = ""
        Dim number_day_est_start As String = ""
        Dim number_day_est_end As String = ""

        Dim days_est_logStart As Integer = 0
        Dim days_est_longEnd As Integer = 186
        Dim date_result_est_longStart As Date
        Dim date_result_est_longEnd As Date
        Dim number_day_est_longStart As String = ""
        Dim number_day_est_longEnd As String = ""

        ws.GETDATE_WORKING(CDate(dao.fields.DATE_CONFIRM), True, days_start, True, date_result_start, True)
        ws.GETDATE_WORKING(CDate(dao.fields.DATE_CONFIRM), True, days_end, True, date_result_end, True)
        Try
            ws.GETDATE_WORKING(CDate(dao_deeqt.fields.ESTIMATE_DATE), True, days_est_start, True, date_result_est_start, True)
            ws.GETDATE_WORKING(CDate(dao_deeqt.fields.ESTIMATE_DATE), True, days_est_end, True, date_result_est_end, True)
        Catch ex As Exception

        End Try
        number_day_start = date_result_start.ToLongDateString()
        number_day_end = date_result_end.ToLongDateString()
        number_day_est_start = date_result_est_start.ToLongDateString()
        number_day_est_end = date_result_est_end.ToLongDateString()
        Dim STATUS_ID As String = dao.fields.STATUS_ID
        If _APP_ID = 1 Then
            STATUS_ID = 3
            dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, STATUS_ID, "APPROVE_TBN_1", 0)

            cls.DISCOUNT_DETAIL = dao.fields.Discount_RequestName
            'date_con_day = dao_deeqt.fields.DATE_CONFIRM
            'date_con_month = dao_deeqt.fields.DATE_CONFIRM
            'date_con_year = dao_deeqt.fields.DATE_CONFIRM

            'date_con_full = date_con_day.Day.ToString() + 1 & " " & date_con_month.ToString("MMMM") & " " & con_year(date_con_year.Year)
            'date_req_full = date_con_day.Day.ToString() + 41 & " " & date_con_month.ToString("MMMM") & " " & con_year(date_con_year.Year)
            Dim date_pay As String = ""
            Try
                date_pay = date_to_thai(dao_deeqt.fields.DATE_PAY1)
            Catch ex As Exception
                date_pay = date_to_thai(dao_deeqt.fields.DATE_CONFIRM)
            End Try
            ws.GETDATE_WORKING(CDate(date_pay), True, days_start, True, date_result_start, True)
            ws.GETDATE_WORKING(CDate(date_pay), True, days_end, True, date_result_end, True)
            number_day_start = date_result_start.ToLongDateString()
            number_day_end = date_result_end.ToLongDateString()

            date_con_full = date_pay
            'date_con_full = number_day_start
            date_appo_full = number_day_end

            cls.appointment_date = date_appo_full
            cls.DISCOUNT_DETAIL = dao.fields.Discount_RequestName

        ElseIf dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 12 Then
            dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, dao.fields.STATUS_ID, "APPROVE_TBN_1", 0)

            'date_req_day = dao.fields.DATE_REQ
            'date_req_month = dao.fields.DATE_REQ
            'date_req_year = dao.fields.DATE_REQ

            'date_con_full = date_req_day.Day.ToString() + 1 & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)
            'date_req_full = date_req_day.Day.ToString() + 41 & " " & date_req_month.ToString("MMMM") & " " & con_year(date_req_year.Year)

            date_con_full = number_day_start
            date_appo_full = number_day_end

            'ElseIf dao.fields.STATUS_ID = 13 Then
        ElseIf _APP_ID = 2 Then
            STATUS_ID = 23
            If dao_c.fields.ID = 0 Then
                If _ProcessID = 20101 Or _ProcessID = 20102 Or _ProcessID = 20191 Or _ProcessID = 20192 Then
                    'days_est_end = 35
                    'days_est_end = 71
                    days_est_end = 50
                    days_est_longEnd = 210
                    'days_est_longEnd = 150
                ElseIf _ProcessID = 20103 Or _ProcessID = 20105 _
                Or _ProcessID = 20193 Or _ProcessID = 20195 Then
                    'days_est_end = 40
                    'days_est_end = 107
                    days_est_end = 64
                    days_est_longEnd = 235
                    'days_est_longEnd = 170
                ElseIf _ProcessID = 20104 Or _ProcessID = 20194 Then
                    days_est_end = 64
                    days_est_longEnd = 235
                    'days_est_end = 128
                    'days_est_longEnd = 170
                End If
            Else
                days_est_end = dao_c.fields.ESTIMATE_DATE
                days_est_longEnd = dao_c.fields.FINISH_DATE
                Conplicate_name = dao_c.fields.NAME_COMPLEX
            End If

            'days_est_end = 47
            Dim date_pay As Date
            Try
                date_pay = dao.fields.Estimate_Date_PAY
            Catch ex As Exception
                date_pay = dao_deeqt.fields.rcvdate
            End Try
            'Dim date_pay As Date = Date.Now
            '     ws.GETDATE_WORKING(CDate(dao_deeqt.fields.ESTIMATE_DATE), True, days_est_start, True, date_result_est_start, True)
            ws.GETDATE_WORKING(CDate(date_pay), True, days_est_start, True, date_result_est_start, True)
            ws.GETDATE_WORKING(CDate(date_pay), True, days_est_end, True, date_result_est_end, True)

            ws.GETDATE_WORKING(CDate(date_pay), True, days_est_logStart, True, date_result_est_longStart, True)
            ws.GETDATE_WORKING(CDate(date_pay), True, days_est_longEnd, True, date_result_est_longEnd, True)

            number_day_est_start = date_result_est_start.ToLongDateString()
            number_day_est_end = date_result_est_end.ToLongDateString()
            number_day_est_longStart = date_result_est_longStart.ToLongDateString()
            number_day_est_longEnd = date_result_est_longEnd.ToLongDateString()

            dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, STATUS_ID, "APPROVE_TBN_2", 0)

            date_con_full = number_day_est_start
            date_appo_full = number_day_est_end

            cls.DISCOUNT_DETAIL = dao.fields.Discount_EstimateName
            date_con_full = number_day_est_longStart
            cls.date_period_estimate_full = number_day_est_longEnd 'ระยะเวลาในการดำเนินการจนแล้วเสร็จ
            cls.appointment_date = date_appo_full 'วันที่นัดรับผลการประเมินเอกสารวิชาการครั้งที่ 1
            cls.date_estimate_full = date_con_full 'วันที่เริ่มประเมินเอกสารวิชาการ

            dao.fields.EXPECTED_DATE = date_result_est_end
            dao.fields.EXPECTED_DATE2 = date_result_est_end
            dao.fields.COMPLEX_DATE_MIN = number_day_est_end
            dao.fields.COMPLEX_DATE_MAX = number_day_est_longEnd
            dao.Update()
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
        cls.group_assign = "กลุ่มทะเบียนผลิตภัณฑ์ กองผลิตภัณฑ์สมุนไพร"

        Try
            cls.TR_ID = dao.fields.TR_ID
        Catch ex As Exception

        End Try

        xml = cls.XML_APOINTMENT()
        TB_AP = xml

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_APPOINTMENT("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_APPOINTMENT("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, "AP", PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
    Function SEARCH_NAME_BY_CITIZEN(ByVal citizen_id As String)
        Dim dao As New DAO_CPN.TB_syslcnsnm
        Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
        Dim obj As New XML_DATA
        Dim result As String = ""
        Dim FullName As String = ""
        result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
        obj = ConvertFromXml(Of XML_DATA)(result)
        Try
            Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON = 1 Then
                FullName = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            ElseIf TYPE_PERSON = 99 Then
                FullName = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    FullName = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    FullName = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm
                End If
            End If
        Catch ex As Exception
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End Try
        Return FullName
    End Function
End Class
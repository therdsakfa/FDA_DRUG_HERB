﻿Public Class FRM_HERB_APPOINMENT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_LCN As String
    Private _TR_ID As String
    Private _ProcessID As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_JJ")
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
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

        Dim LCNNO_DISPLAY_NEW As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanm As String = SEARCH_NAME_BY_CITIZEN(dao.fields.CITIZEN_ID_AUTHORIZE)
        Dim tel As String = dao_lcn.fields.tel
        Dim NAME_JJ As String = dao.fields.NAME_JJ
        Dim RCVNO_FULL As String = dao.fields.RCVNO_FULL
        Dim EMAIL As String = dao.fields.Appoinment_Email
        Dim NAME_THAI_NAME_PLACE As String = dao.fields.NAME_THAI '& " / " & dao.fields.NAME_PLACE_JJ

        'Dim date_req_day As Date
        'Dim date_req_month As Date
        'Dim date_req_year As Date
        'Dim date_req_full As String = ""

        Dim date_con_day As Date
        Dim date_con_month As Date
        Dim date_con_year As Date

        Dim date_con_day_end As Date
        Dim date_con_month_end As Date
        Dim date_con_year_end As Date

        Dim date_con_full As String = ""
        Dim date_con_full_END As String = ""

        Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
        Dim date_result_start As Date
        Dim date_result_end As Date
        Dim date_result_longStart As Date
        Dim date_result_longEnd As Date
        Dim days_start As Integer = 0
        Dim days_end As Integer = 10
        Dim days_logStart As Integer = 0
        Dim days_longEnd As Integer = 90
        If _ProcessID = 20301 Or _ProcessID = 20302 Or _ProcessID = 20303 Then
            'days_end = 8
            days_end = 10
            'days_end = 15
        ElseIf _ProcessID = 20304 Or _ProcessID = 20305 Then
            'days_end = 12
            days_end = 10
            'days_end = 17
        End If
        Dim number_day_start As String = ""
        Dim number_day_end As String = ""
        Dim number_day_longStart As String = ""
        Dim number_day_longEnd As String = ""
        Dim date_pay As Date
        Try
            date_pay = dao.fields.DATE_PAY1
        Catch ex As Exception
            date_pay = dao.fields.DATE_CONFIRM
        End Try
        ws.GETDATE_WORKING(CDate(date_pay), True, days_start, True, date_result_start, True)
        ws.GETDATE_WORKING(CDate(date_pay), True, days_end, True, date_result_end, True)
        number_day_start = date_result_start.ToLongDateString()
        number_day_end = date_result_end.ToLongDateString()


        'ws.GETDATE_WORKING(CDate(date_pay), True, days_est_start, True, date_result_est_start, True)
        'ws.GETDATE_WORKING(CDate(date_pay), True, days_est_end, True, date_result_est_end, True)

        ws.GETDATE_WORKING(CDate(date_pay), True, days_logStart, True, date_result_longStart, True)
        ws.GETDATE_WORKING(CDate(date_pay), True, days_longEnd, True, date_result_longEnd, True)

        number_day_longStart = date_result_longStart.ToLongDateString()
        number_day_longEnd = date_result_longEnd.ToLongDateString()
        'date_con_full = number_day_longStart
        If dao.fields.STATUS_ID >= 3 Then
            date_con_full = number_day_start
            date_con_full_END = number_day_end
        End If
        cls.TR_ID = dao.fields.TR_ID_JJ
        cls.process_id = _ProcessID
        cls.lcnno_display_new = LCNNO_DISPLAY_NEW
        cls.rcvno_full = RCVNO_FULL
        cls.name_thai_name_place = NAME_THAI_NAME_PLACE
        cls.date_req_full = date_con_full
        cls.thanm = thanm
        cls.NAME_CONTACT = NAME_JJ
        cls.citizen_id = _CLS.CITIZEN_ID
        cls.tel_callback = tel
        cls.E_MAIL = EMAIL
        cls.appointment_date = date_con_full_END
        cls.date_period_estimate_full = number_day_longEnd 'ระยะเวลาในการดำเนินการจนแล้วเสร็จ
        cls.date_estimate_full = date_con_full 'วันที่เริ่มประเมินเอกสารวิชาการ
        'cls.group_assign = "กลุ่มทะเบียนผลิตภัณฑ์"
        cls.group_assign = "กลุ่มกำกับดูแลก่อนออกสู่ตลาด"
        cls.DISCOUNT_DETAIL = dao.fields.Discount_RequestName

        xml = cls.XML_APOINTMENT()
        TB_AP = xml
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_APPOINTMENT(_ProcessID, 3, "APPROVE_JJ", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_APPOINTMENT("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_APPOINTMENT("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

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
    'Sub Bind_Date()
    '    Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
    '    Dim date_result As Date
    '    ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)
    '    lbl_number_day.Text = date_result.ToLongDateString()

    'End Sub

End Class
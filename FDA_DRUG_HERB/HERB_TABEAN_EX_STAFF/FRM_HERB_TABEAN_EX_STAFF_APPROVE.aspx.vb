Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_EX_STAFF_APPROVE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

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

            'Run_Pdf_Tabean_Herb_Yorbor8()
            bind_data()
            'bind_mas_staff()
            Run_Pdf_Tabean_Herb_8()
        End If
    End Sub
    Public Sub Run_Pdf_TB_Herb_EX()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(dao.fields.process_id, dao.fields.STATUS_ID, "ตย1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EX") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE_EX\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub
    Public Sub Run_Pdf_yorbor8()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        Dim lcntpcd As String = ""
        Dim process_id As String = ""

        dao.GetDataby_IDA(_IDA)
        If dao.fields.lcntpcd.Contains("ผ") Then
            lcntpcd = "ผยบ8"
            process_id = 1706
        Else
            lcntpcd = "นยบ8"
            process_id = 1707
        End If


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(process_id, dao.fields.STATUS_ID, lcntpcd, 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_TEMPLATE & "' ></iframe>"

    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        OFF_APP.Text = dao.fields.EX_OFF_APP
        DATE_APP.Text = dao.fields.EX_DATE_APP
        'Try
        '    DD_OFF_APP.SelectedValue = dao.fields.EX_OFF_APP_ID
        'Catch ex As Exception

        'End Try
        NOTE_APP.Text = dao.fields.EX_NOTE_APP
    End Sub
    'Public Sub bind_mas_staff()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_MAS_STAFF_NAME_HERB()

    '    DD_OFF_APP.DataSource = dt
    '    DD_OFF_APP.DataBind()
    '    DD_OFF_APP.Items.Insert(0, "-- กรุณาเลือก --")
    'End Sub

    Public Sub Run_Pdf_Tabean_Herb_8()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_EX
        TABEAN_EX = XML.gen_xml_TB_EX(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(dao.fields.process_id, dao.fields.STATUS_ID, "ตย1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EX") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE_EX\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TABEAN_EX("HB_XML", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, dao.fields.process_id, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
    Public Sub Run_Pdf_Tabean_Herb_Yorbor8()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Dim lcntpcd As String = ""
        Dim process_id As String = ""

        dao.GetDataby_IDA(_IDA)
        If dao.fields.lcntpcd.Contains("ผ") Then
            lcntpcd = "ยบ8"
            process_id = 200008
        Else
            lcntpcd = "ยบ8"
            process_id = 200008
        End If

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_EX
        TABEAN_EX = XML.gen_xml_TB_EX(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(process_id, dao.fields.STATUS_ID, lcntpcd, 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_YORBOR8") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TABEAN_EX("HB_XML", process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, process_id, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
    Sub xml(ByVal drsamp_ida As Integer)
        Dim get_session As CLS_SESSION = Session("product_id")
        Dim cls_xml As New CLASS_DRSAMP
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_master As New BAO_MASTER

        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_IDA)
        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(_IDA)
        Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
        dao_dalcn.GetDataby_IDA(_IDA_LCN)

        cls_xml = Gen_XML()
        Dim write_date As Date = dao_drsamp.fields.WRITE_DATE
        dao_drsamp.fields.WRITE_DATE = DateAdd(DateInterval.Year, 543, write_date)
        cls_xml.drsamp = dao_drsamp.fields  'ใบ
        cls_xml.regis = dao.fields
        cls_xml.DT_SHOW.DT1 = bao.SP_DRUG_REGISTRATION(dao.fields.IDA) 'บัญชีรายการยา
        cls_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(dao.fields.FK_IDA) 'เลขที่ใบอนุญาต
        cls_xml.DT_SHOW.DT3 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(dao.fields.IDA) 'ตัวยาสำคัญ
        cls_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(dao.fields.IDA) 'ขนาดบรรจุ
        cls_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao.fields.IDA) 'ขนาดบรรจุ
        Try
            cls_xml.DRUG_COLOR = dao.fields.DRUG_COLOR
        Catch ex As Exception

        End Try
        Try
            'PACK_SIZE = dao_pid.fields.PACKAGE_DETAIL 'dt_pack(0)("contain_detail")
            cls_xml.PACK_SIZE = dao.fields.PACKAGE_DETAIL
        Catch ex As Exception

        End Try
        Try
            cls_xml.DT_SHOW.DT6 = bao.SP_regis(dao.fields.IDA)
            cls_xml.DT_SHOW.DT9 = bao.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(dao.fields.IDA)
        Catch ex As Exception

        End Try
        Try
            'cls_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(dao_dalcn.fields.IDA) 'ผู้มีหน้าที่ปฏิบัติการ
            For Each dr As DataRow In bao_master.SP_DALCN_PHR_BY_FK_IDA(dao_dalcn.fields.IDA).Rows
                If dr("IDA") = dao_drsamp.fields.phr_fk Then
                    cls_xml.phr_fullname = dr("PHR_FULLNAME")
                    cls_xml.phr_nm = dr("FULLNAMEs")
                End If
            Next
        Catch ex As Exception

        End Try

        cls_xml.DT_SHOW.DT7 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(dao.fields.IDA) 'ดึงตัวยาสำคัญ multi
        cls_xml.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
        cls_xml.DT_SHOW.DT8 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao.fields.IDA)    'ขนาดบรรจุ multi
        cls_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID) 'ผู้ยื่น
        Try
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(_IDA_LCN) 'ผู้ดำเนิน
            cls_xml.DT_SHOW.DT20 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_NEW(dao.fields.IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            cls_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
        Catch ex As Exception

        End Try
        Dim dao_pac As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_pac.GetDataby_FK_IDA(dao.fields.IDA)
        Dim sum As String = ""

        For Each dao_pac.fields In dao_pac.datas
            If dao_pac.fields.CHECK_PACKAGE = True Then
                If sum <> "" Then
                    sum = sum & ", "
                    sum = sum & dao_pac.fields.IM_DETAIL
                Else
                    sum = dao_pac.fields.IM_DETAIL
                End If
            End If
        Next

        Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
        'unit_physic.GetDataby_sunitcd(CInt(lbl_sunit_ida.Text))

        cls_xml.IMPORT_AMOUNTS = dao_drsamp.fields.QUANTITY & " " & unit_physic.fields.unit_name

        Dim bao2 As New BAO.AppSettings
        bao2.RunAppSettings()
        Dim paths As String = bao2._PATH_DEFAULT
        Dim file_template As String = ""
        Dim lcntpcd As String = ""
        Dim process_id As String = ""

        dao.GetDataby_IDA(_IDA)
        If dao.fields.LCNTPCD.Contains("ผ") Then
            lcntpcd = "ผยบ8"
            process_id = 1706
        Else
            lcntpcd = "นยบ8"
            process_id = 1707
        End If
        'Dim process As String = "-"
        'If get_session.PVCODE = "6" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8.pdf"
        '    process = "1701"
        'ElseIf get_session.PVCODE = "7" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYOR8.pdf"
        '    process = "1702"
        'ElseIf get_session.PVCODE = "8" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8.pdf"
        '    process = "1703"
        'ElseIf get_session.PVCODE = "9" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORBOR8.pdf"
        '    process = "1704"
        'ElseIf get_session.PVCODE = "10" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8(VEJAI).pdf" '"C:\path\DRUG\PDF_TEMPLATE\PDF_DRUG_PORYOR8.pdf"
        '    process = "1705"
        'ElseIf get_session.PVCODE = "11" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8_HERB_AUTO.pdf"
        '    process = "1706"
        '    'ElseIf get_session.PVCODE = "9" Then
        '    '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORBOR8.pdf"
        '    '    process = "1707"
        'End If

        Dim path_XML As String = paths & "XML_TRADER_DOWNLOAD\" & "DA-" & process_id & "-" & dao.fields.RCVNO_DISPLAY + ".xml"
        Dim file_PDF As String = paths & "PDF_TRADER_DOWNLOAD\" & "DA-" & process_id & "-" & dao.fields.RCVNO_DISPLAY + ".pdf"

        Dim objStreamWriter As New StreamWriter(path_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        convert_XML_To_PDF(file_PDF, path_XML, file_template)
        Dim pdf_name As String = process_id & "-" & dao.fields.RCVNO_DISPLAY

        _CLS.FILENAME_PDF = file_PDF                                                                                                 ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", pdf_name)

        Session("CLS") = _CLS

    End Sub
    Private Function GEN_XML() As CLASS_DRSAMP
        Dim class_xml As New CLASS_DRSAMP

        Return class_xml
    End Function
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_EX(_TR_ID, 17, dao.fields.process_id)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_EX/FRM_HERB_TABEAN_EX_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Protected Sub DD_PDF_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_PDF_ID.SelectedIndexChanged
        If DD_PDF_ID.SelectedValue = 1 Then
            Run_Pdf_Tabean_Herb_8()
        ElseIf DD_PDF_ID.SelectedValue = 2 Then
            'Run_Pdf_yorbor8()
            Run_Pdf_Tabean_Herb_Yorbor8()
        End If
    End Sub
End Class
﻿Imports System.IO
Imports System.Xml.Serialization

Public Class POPUP_LCN_LCT_KEEP_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _type As String
    Private _CLS As New CLS_SESSION


    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _type = Request.QueryString("type")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BindData_PDF()
            show_btn(_IDA)
        End If
    End Sub
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"

        End If


    End Sub

    Private Sub BindData_PDF()
        '------------------------------------------------------------
        Dim CITIZEN_ID_AUTHORIZE As String = IDENTIFY_by_LCNSID(_CLS.LCNSID_CUSTOMER)

        Dim PDF_XML_NCT As New XML_PDF_NCT_LCT
        '--------------------------------------------------------------------
        PDF_XML_NCT.MAIN_IDA = _IDA
        PDF_XML_NCT.XML_CITIZEN_ID_AUTHORIZE = CITIZEN_ID_AUTHORIZE
        PDF_XML_NCT.XML_TYPE = _type

        '  PDF_XML_NCT.BindData_PDF(_IDA)

        '----------------------------------------------------------------------------

        Dim statusID As Integer = 0
        Dim ProcessID As Integer = 0

        Dim grouptype As String = "00"

        Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
        dao_la.GetDataby_IDA(_IDA)

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao_la.fields.TR_ID)

        'Dim IDA As Integer = dao_la.fields.IDA
        Dim tr_id As String = dao_la.fields.TR_ID
        Dim LCNSID As String = dao_la.fields.lcnsid
        ' Dim CITIZEN_ID_AUTHORIZE As String = _XML_CITIZEN_ID_AUTHORIZE
        Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID

        statusID = dao_la.fields.STATUS_ID
        ProcessID = dao_up.fields.PROCESS_ID



        Dim cls_NCONVERTRQT As New Gen_XML.GEN_XML_NCT_LCT_ADDR

        cls_NCONVERTRQT.CITIZEN_ID = dao_la.fields.CITIZEN_ID
        cls_NCONVERTRQT.CITIZEN_AUTHORIZE = CITIZEN_ID_AUTHORIZE
        cls_NCONVERTRQT.IDA = _IDA


        Dim class_xml As New CLS_LOCATION
        class_xml = cls_NCONVERTRQT.gen_xml_nct_lctaddr()
        class_xml.NCT_LCTADDRs = dao_la.fields


        Dim cls_LOCATION_BSN As New DAO_CPN.TB_LOCATION_BSN
        cls_LOCATION_BSN.Getdata_by_fk_id(_IDA)
        class_xml.LOCATION_BSNs = cls_LOCATION_BSN.Details
        '_______________SHOW___________________

        Dim bao_show As New BAO_SHOW
        Try
            class_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(CITIZEN_ID) 'ชื่อผู้ ทำ PDF
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT5 = bao_show.SP_SP_SYSTHMBL() 'ตำบล ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT6 = bao_show.SP_SP_SYSAMPHR() 'อำเภอ ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT7 = bao_show.SP_SP_SYSCHNGWT() 'จังหวัด ไว้ใส่ ดรอปดาว

        class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX() 'คำนำหน้า ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(LCNSID) 'bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, LCNSID) 'สถานที่หลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID) 'ชื่อและข้อมูลผู้ประกอบการ



        class_xml.SHOW_THAI_birthdate = " "

        XML_LOCATIONs = class_xml

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(ProcessID, 0, statusID, grouptype, 0)

        Dim paths As String = _PATH_DEFALUT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DRUG", ProcessID, con_year(Date.Now.Year), TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DRUG", ProcessID, con_year(Date.Now.Year), TR_ID)

        Dim objStreamWriter As New StreamWriter(Path_XML)
        Dim x As New XmlSerializer(class_xml.GetType)
        x.Serialize(objStreamWriter, class_xml)
        objStreamWriter.Close()






        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, ProcessID, Path_PDF) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO



        '_XML_PATH_PDF = Path_PDF
        ' HiddenField1.Value = PDF_XML_NCT.XML_PATH_PDF

        HiddenField1.Value = Path_PDF
        '----------------------------------------------------------------------------

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & Path_PDF & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & Path_PDF ' Link เปิดไฟล์ตัวใหญ่


        'show_btn() 'ตรวจสอบปุ่ม




    End Sub

    'Private Sub BindData_PDF()
    '    Dim CITIZEN_ID_AUTHORIZE As String = IDENTIFY_by_LCNSID(_CLS.LCNSID_CUSTOMER)

    '    Dim PDF_XML_NCT As New XML_PDF_NCT_LCT
    '    PDF_XML_NCT.MAIN_IDA = _IDA
    '    PDF_XML_NCT.XML_CITIZEN_ID_AUTHORIZE = CITIZEN_ID_AUTHORIZE
    '    PDF_XML_NCT.XML_TYPE = _type

    '    PDF_XML_NCT.BindData_PDF(_IDA)
    '    HiddenField1.Value = PDF_XML_NCT.XML_PATH_PDF

    '    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PDF_XML_NCT.XML_PATH_PDF & "' ></iframe>"
    '    hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & PDF_XML_NCT.XML_PATH_PDF ' Link เปิดไฟล์ตัวใหญ่


    '    'Dim dao_ll As New DAO_NCT.TB_LICENSE_LOCATION

    '    'Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
    '    'Dim dao_up As New DAO_NCT.TB_TRANSACTION_UPLOAD

    '    'dao_la.GetDataby_IDA(_IDA)
    '    ''dao_la.GetDataby_IDA(dao_ll.fields.FK_IDA)
    '    'dao_up.Getdata_byid(dao_la.fields.TR_ID)
    '    'Dim IDA As Integer = dao_la.fields.IDA
    '    'Dim LCNSID As String = dao_la.fields.lcnsid
    '    'Dim CITIZEN_ID_AUTHORIZE As String = IDENTIFY_by_LCNSID(LCNSID)
    '    'Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID


    '    'Dim statusID As Integer = 0
    '    'Dim grouptype As String = "00"


    '    'Dim dao_NCONVENTRQT As New DAO_CPN.TB_LOCATION_ADDRESS
    '    'dao_NCONVENTRQT.GetDataby_IDA(_IDA)

    '    'Dim cls_NCONVERTRQT As New Gen_XML.GEN_XML_NCT_LCT_ADDR

    '    'cls_NCONVERTRQT.CITIZEN_ID = dao_NCONVENTRQT.fields.CITIZEN_ID
    '    'cls_NCONVERTRQT.CITIZEN_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
    '    'cls_NCONVERTRQT.IDA = _CLS.IDA



    '    'Dim class_xml As New XML_NCT_LCTADDR
    '    'class_xml = cls_NCONVERTRQT.gen_xml_nct_lctaddr()
    '    'class_xml.NCT_LCTADDRs = dao_NCONVENTRQT.fields

    '    ''_______________SHOW___________________

    '    'Dim bao_show As New BAO_SHOW
    '    'Try

    '    '    class_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(CITIZEN_ID)
    '    'Catch ex As Exception

    '    'End Try

    '    'class_xml.DT_SHOW.DT5 = bao_show.SP_SP_SYSTHMBL()
    '    'class_xml.DT_SHOW.DT6 = bao_show.SP_SP_SYSAMPHR()
    '    'class_xml.DT_SHOW.DT7 = bao_show.SP_SP_SYSCHNGWT()

    '    'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX()
    '    'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, LCNSID)
    '    'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID)
    '    'class_xml.SHOW_THAI_birthdate = " "




    '    'XML_NCT_LCTADDRs = class_xml

    '    'statusID = dao_NCONVENTRQT.fields.STATUS_ID


    '    'Dim bao_P As New BAO.PROCESS
    '    'Dim ProcessID As Integer = bao_P.GET_PROCESS_ID(_type, grouptype)

    '    'Dim dao_pdftemplate As New DAO_NCT.TB_MAS_TEMPLATE_PROCESS
    '    'dao_pdftemplate.GetDataby_TEMPLAETE(ProcessID, _type, statusID, grouptype, 0)

    '    'Dim paths As String = _PATH_FILE
    '    'Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("NCT", ProcessID, con_year, _TR_ID)
    '    'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("NCT", ProcessID, con_year, _TR_ID)


    '    'LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, ProcessID, Path_PDF) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

    '    'HiddenField1.Value = Path_PDF

    '    'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & Path_PDF & "' ></iframe>"
    '    'hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & Path_PDF ' Link เปิดไฟล์ตัวใหญ่





    'End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim filename As String = HiddenField1.Value
        Try
            load_pdf(filename)
        Catch ex As Exception

        End Try
    End Sub

    Sub load_pdf(ByVal filename As String)
        Try

            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")

            Response.BinaryWrite(clsds.UpLoadImageByte(filename)) '"C:\path\PDF_XML_CLASS\"

        Catch ex As Exception

        Finally

            Response.Flush()
            Response.Close()
            Response.End()
        End Try

    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim bao As New BAO.GenNumber
        Dim rcvno As String = bao.GEN_RCVNO_NO(con_year(Year(Date.Now)), _CLS.PVCODE, "98", _IDA)

        Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = 3
        dao.fields.rcvdate = Date.Now
        dao.fields.rcvno = rcvno
        dao.update()

        alert("เลขรับ คือ " & dao.fields.rcvno)
    End Sub


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = 2
        dao.update()
    End Sub

End Class
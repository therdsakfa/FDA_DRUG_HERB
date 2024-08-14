Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Public Class FRM_LCN_SUBSTITUTE_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _newcode As String
    Private _iden As String

    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _iden = Request.QueryString("identify")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'txt_appdate.Text = Date.Now.ToShortDateString()
            Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
            dao.Getdata_by_IDA(_IDA)
            If dao.fields.STATUS_ID = 8 Then
                BindData_PDF_LCN()
            Else
                BindData_PDF()
            End If
            If dao.fields.STATUS_ID = 8 Then
                Panel1.Style.Add("display", "block")
                Panel3.Style.Add("display", "block")
            Else
                Panel1.Style.Add("display", "none")
                Panel3.Style.Add("display", "none")
            End If
            'bind_ddl_rqt()
            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv(_TR_ID)
            Bind_ddl_Status_staff()
            bind_mas_staff()
        End If
    End Sub
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 7 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
            ddl_cnsdcd.Style.Add("display", "none")
        End If
        If dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 5 Then
            btn_preview.Enabled = True
            'btn_preview.CssClass = "btn-danger btn-lg"
        Else
            btn_preview.Enabled = False
            btn_preview.CssClass = "btn-danger btn-lg"
        End If
        'If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 9 Then btn_preview
        '    'btn_load.Enabled = True
        '    'btn_load.CssClass = "btn-danger btn-lg"

        'Else
        '    'btn_load.Enabled = False
        '    'btn_load.CssClass = "btn-danger btn-lg"
        'End If
        DATE_REQ.Text = Date.Now
    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DDL_STAFF_NAME.DataSource = dt
        DDL_STAFF_NAME.DataBind()
        DDL_STAFF_NAME.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl1 As Integer = 0
        Dim int_group_ddl2 As Integer = 0
        Dim int_group_ddl As Integer = 0
        Dim status_id1 As Integer = 0
        Dim dao_sub As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        Try
            dao_sub.Getdata_by_IDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        Try
            status_id1 = dao_sub.fields.STATUS_ID
        Catch ex As Exception

        End Try
        'If dao_sub.fields.STATUS_ID <= 2 Then
        '    int_group_ddl = 1
        'ElseIf dao_sub.fields.STATUS_ID = 11 Then
        '    int_group_ddl = 2
        'ElseIf dao_sub.fields.STATUS_ID > 2 And dao_sub.fields.STATUS_ID < 6 Then
        '    int_group_ddl = 3
        'ElseIf dao_sub.fields.STATUS_ID >= 6 And dao_sub.fields.STATUS_ID < 11 Then
        '    int_group_ddl = 4
        'End If
        If status_id1 = 2 Then
            int_group_ddl1 = 1
            int_group_ddl2 = 0
        ElseIf status_id1 = 9 Then
            int_group_ddl1 = 2
            int_group_ddl2 = 0
        ElseIf status_id1 = 11 Then
            int_group_ddl1 = 3
            int_group_ddl2 = 0
        End If
        dt = Get_DDL_DATA(13, int_group_ddl1, int_group_ddl2)

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME_STAFF"
        ddl_cnsdcd.DataBind()
    End Sub
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        'Dim dt As New DataTable
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim dta As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dta = bao.Queryds(sql)
        Return dta
    End Function

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim cls_dalcn_edt As New CLASS_GEN_XML.DALCN_SUB(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID, "1", "10")
        Dim lct_ida As Integer = 0 '101680
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        Dim FK_IDA As Integer = dao.fields.FK_IDA
        dao_phr.GetDataby_FK_IDA(dao.fields.FK_IDA)
        Dim bao_cls As New BAO.ClsDBSqlcommand
        Dim Cls_XML As New CLASS_DALCN_SUBSTITUTE
        ' class_xml = cls_dalcn.gen_xml()
        'Cls_XML.DALCN_NCT_SUBSTITUTEs = dao.fields
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Try
            dao_main.GetDataby_IDA(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao_bsn.GetDataby_LCN_IDA(dao_main.fields.IDA)
        Catch ex As Exception

        End Try
        Dim bao_show As New BAO_SHOW
        Try
            lct_ida = dao_main.fields.FK_IDA
        Catch ex As Exception

        End Try
        Dim identify As String = ""
        Try
            identify = dao_main.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        Try
            Cls_XML.DT_SHOW.DT1 = bao_show.SP_Lisense_Name_and_Addr(dao.fields.CITIZEN_ID_AUTHORIZE)
        Catch ex As Exception

        End Try


        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

        Dim dao_herb As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        dao_herb.GetDataby_LCN_IDA(dao.fields.FK_IDA)


        Try
            Dim dt_thanm As DataTable = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_iden, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            For Each dr As DataRow In dt_thanm.Rows
                dr("thanm") = dao_herb.fields.licen
            Next
            'Dim dt_thanm2 As DataTable
            'dt_thanm2 = dt_thanm.Clone
            'Dim dr_nm As DataRow = dt_thanm2.NewRow()
            'dr_nm("thanm") = dao_e.fields.licen_loca
            'dt_thanm2.Rows.Add(dr_nm)
            Cls_XML.DT_SHOW.DT2 = dt_thanm
        Catch ex As Exception

        End Try
        'Try
        '    Cls_XML.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(dao_bsn.fields.BSN_IDENTIFY) 'ผู้ดำเนิน
        '    Cls_XML.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        'Catch ex As Exception

        'End Try
        Try
            Cls_XML.DT_SHOW.DT3 = bao_show.SP_LOCATION_ADDRESS_BY_FK_IDA(dao.fields.FK_IDA)
            '  Cls_XML.DT_SHOW.DT3 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao_main.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Catch ex As Exception

        End Try
        Dim lcnno_auto As String = ""
        Dim rcvno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_format_new As String = ""
        Dim MAIN_LCN_IDA As Integer = 0
        Dim lcnno_format_new As String = ""
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            If dao.fields.rcvno <> 0 Then
                rcvno_auto = dao.fields.rcvno
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(lcnno_auto) > 0 Then
                If dao_main.fields.lcnno > 1000000 Then
                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    Else
                        'lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        lcnno_format = dao_main.fields.LCNNO_DISPLAY_NEW
                    End If
                Else
                    lcnno_format_new = dao_main.fields.LCNNO_DISPLAY_NEW
                End If

                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then
                rcvno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/25" & Left(rcvno_auto, 2)
            End If
            rcvno_format_new = dao.fields.rcvno_new
        Catch ex As Exception

        End Try

        Dim bsn_name As String = ""
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = dao.fields.CITIZEN_ID
        Catch ex As Exception

        End Try
        Dim ws_2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws_2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)
        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
        Try
            'bsn_name = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            bsn_name = dao_bsn.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try

        Dim rcvdate As Date
        Dim rcvdate2 As String = ""
        Try
            If dao.fields.rcvdate IsNot Nothing Then
                rcvdate = dao.fields.rcvdate
                rcvdate2 = CDate(rcvdate).ToString("dd/MM/yyy")
            End If

        Catch ex As Exception

        End Try
        Dim bao_master As New BAO_MASTER
        Cls_XML.LCNNO_FORMAT = lcnno_format
        Cls_XML.LCNNO_SHOW = lcnno_format
        Cls_XML.LCNNO_FORMAT_NEW = lcnno_format_new
        Cls_XML.RCVNO_FORMAT = rcvno_format
        Cls_XML.RCVNO_FORMAT_NEW = rcvno_format_new
        Cls_XML.RCVDATE_DISPLAY = rcvdate2
        Cls_XML.PHR_NAME = dao_phr.fields.PHR_NAME
        Cls_XML.WTIRE_DATE = dao.fields.WTIRE_DATE
        Cls_XML.PUR_POSE = dao.fields.PURPOSE
        Cls_XML.OPENTIME = dao_main.fields.opentime
        Cls_XML.LCN_TYPE = dao.fields.LCN_TYPE
        Cls_XML.CITIZEN_AUTHORIZE = dao_main.fields.CITIZEN_ID_AUTHORIZE
        Cls_XML.TEL = dao_main.fields.tel
        Cls_XML.BSN_NAME = bsn_name
        Cls_XML.DT_MASTER.DT1 = bao_master.SP_PHR_BY_FK_IDA_SUB(dao.fields.FK_IDA)
        'Try
        '    Cls_XML.DT_MASTER.DT10 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.FK_IDA)
        'Catch ex As Exception

        'End Try
        p_dalcn_subtitute = Cls_XML
        'Dim dao_sub As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        'dao_sub.Getdata_by_IDA(_IDA)
        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim Process_ID As String = dao.fields.PROCESS_ID
        Dim TR_ID As String = dao.fields.TR_ID
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP_PREVIEW(Process_ID, statusId, 0, 0)
        Dim YEAR As String = dao_up.fields.YEAR
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", Process_ID, YEAR, TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", Process_ID, YEAR, TR_ID)
        'load_PDF(filename)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, Process_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่

        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", Process_ID, YEAR, TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        If ddl_cnsdcd.SelectedItem.Text.Contains("กรุณาเลือก") Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกสถานะ');", True)
        ElseIf DDL_STAFF_NAME.SelectedItem.Text.Contains("กรุณาเลือก") Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกจนท.ที่รับผิดชอบ');", True)
        Else
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Dim bao As New BAO.GenNumber
            Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
            Dim RCVNO As Integer = 0
            Dim RCVNO_NEW As Integer = 0
            Dim PROCESS_ID As Integer
            Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
            dao.Getdata_by_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            PROCESS_ID = dao_up.fields.PROCESS_ID

            Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
            dao_date.fields.FK_IDA = _IDA
            Try
                dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

            dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
            'dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            'dao_date.fields.STATUS_ID = 4
            dao_date.fields.DATE_NOW = Date.Now
            dao_date.fields.PROCESS_ID = PROCESS_ID
            dao_date.insert()

            If STATUS_ID = 3 Then
                'dao.fields.STATUS_ID = STATUS_ID
                'Dim bao2 As New BAO.GenNumber
                'RCVNO = bao2.GEN_NO_07(con_year(Date.Now.Year), _CLS.PVCODE, IIf(IsDBNull(dao.fields.lcnno), "", dao.fields.lcnno), PROCESS_ID, 0, 0, _IDA, "")
                'dao.fields.rcvno = RCVNO
                'Try
                '    dao.fields.rcvdate = txt_appdate.Text
                'Catch ex As Exception

                'End Try
                'dao.fields.STATUS_ID = STATUS_ID
                'RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                'dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

                'Try
                '    dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
                'Catch ex As Exception

                'End Try
                'dao.fields.STATUS_ID = STATUS_ID
                'dao.update()

                'alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
            ElseIf STATUS_ID = 5 Then
                'dao.fields.STATUS_ID = STATUS_ID
                'dao.update()
                Response.Redirect("POPUP_STAFF_LCN_SUBTITUTE_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & PROCESS_ID)

            ElseIf STATUS_ID = 4 Then
                dao.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

                Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_p.GetDataby_Process_ID(PROCESS_ID)
                Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

                Dim bao2 As New BAO.GenNumber
                Dim RCVNO_HERB_NEW As Integer
                Dim LCNNO_V2 As Integer
                RCVNO_HERB_NEW = bao2.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)

                Dim _year As Integer = con_year(Date.Now.Year)
                If _year < 2500 Then
                    _year += 543
                End If

                LCNNO_V2 = con_year(Date.Now.Year).Substring(2, 2) & RCVNO_HERB_NEW
                dao.fields.lcnno = LCNNO_V2

                dao.fields.rcvno_new = "HB " & _CLS.PVCODE & "-" & PROCESS_ID & "-" & con_year(Date.Now.Year).Substring(2, 2) & "-" & RCVNO_HERB_NEW

                'RCVNO_NEW = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                'dao.fields.rcvno_new = RCVNO_NEW 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                dao.fields.rcv_staff_ID = DDL_STAFF_NAME.SelectedValue
                dao.fields.rcv_staff_Name = DDL_STAFF_NAME.SelectedItem.Text
                dao.fields.STATUS_ID = 9
                dao.update()

                alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)

                'dao.fields.STATUS_ID = 9
                'dao.update()
                'alert("รับคำขอแล้ว")
            ElseIf STATUS_ID = 8 Then
                'dao.fields.appdate = CDate(txt_appdate.Text)
                dao.fields.app_Staff_ID = DDL_STAFF_NAME.SelectedValue
                dao.fields.app_Staff_Name = DDL_STAFF_NAME.SelectedItem.Text
                dao.update()
                Response.Redirect("POPUP_STAFF_LCN_SUBTITUTE_APP_DATE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & PROCESS_ID)

            ElseIf STATUS_ID = 7 Then
                'Response.Redirect("FRM_STAFF_LCN_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                'dao.fields.STATUS_ID = STATUS_ID

                dao.update()
                AddLogStatus(STATUS_ID, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                'alert("ดำเนินการเรียบร้อยแล้ว")
                Response.Redirect("FRM_SUBTITUBE_REMARK_CANCEL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & PROCESS_ID)

            End If
        End If

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub BindData_PDF_LCN(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao_sub As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao_sub.Getdata_by_IDA(_IDA)
        Dim IDA As String = dao_sub.fields.FK_IDA
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim lcnno_format_NEW As String = ""
        Dim pvncd As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(IDA)

        Dim ProcessID As String = ""
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If PROCESS_ID = "" Then
            PROCESS_ID = dao.fields.PROCESS_ID
        End If
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception

        End Try
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntpcd = Chn_lcntpcd(lcntpcd)
        Dim lcnsid_da As Integer = 0
        Try
            lcnsid_da = dao.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, lcnsid_da, lcnno:=lcnno_auto, lcntpcd:=lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()

        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(1, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        'class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA(IDA)
        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao.fields.FK_IDA) ' 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)

        Dim tt As Integer = 0
        If dao.fields.lcntpcd.Contains("ผ") Then
            tt = 1
            'ElseIf dao.fields.lcntpcd.Contains("น") Then
            '   tt = 2
        Else
            tt = 3
        End If
        If tt = 1 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB(IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(IDA, tt)
        ElseIf tt = 2 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB_V3(IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(IDA, tt)
        ElseIf tt = 3 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB2(IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(IDA, tt)
        End If

        Dim dt9 As New DataTable

        'dt9 = class_xml.DT_SHOW.DT9
        For Each drr As DataRow In class_xml.DT_SHOW.DT9.Rows
            Try
                drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
            Catch ex As Exception

            End Try
            Try
                '
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                drr("tharoom") = NumEng2Thai(drr("tharoom"))
            Catch ex As Exception

            End Try
            Try
                drr("thanameplace") = NumEng2Thai(drr("thanameplace"))
            Catch ex As Exception

            End Try
            Try
                drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
            Catch ex As Exception

            End Try
            Try
                drr("tel1") = NumEng2Thai(drr("tel1"))
            Catch ex As Exception

            End Try
            '
            '
            Try
                drr("thamu") = NumEng2Thai(drr("thamu"))
            Catch ex As Exception

            End Try
            Try
                drr("thafloor") = NumEng2Thai(drr("thafloor"))
            Catch ex As Exception

            End Try
            Try
                drr("thasoi") = NumEng2Thai(drr("thasoi"))
            Catch ex As Exception

            End Try
            Try
                drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
            Catch ex As Exception

            End Try
            Try
                drr("tharoad") = NumEng2Thai(drr("tharoad"))
            Catch ex As Exception

            End Try
            Try
                drr("zipcode") = NumEng2Thai(drr("zipcode"))
            Catch ex As Exception

            End Try
            Try
                drr("tel") = NumEng2Thai(drr("tel"))
            Catch ex As Exception

            End Try
            Try
                drr("fax") = NumEng2Thai(drr("fax"))
            Catch ex As Exception

            End Try
            Try
                drr("Mobile") = NumEng2Thai(drr("Mobile"))
            Catch ex As Exception

            End Try
            Try
                drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
            Catch ex As Exception

            End Try

        Next
        'class_xml.DT_SHOW.DT9 = dt9

        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Dim DT11 As New DataTable
        Try
            'DT11 = class_xml.DT_SHOW.DT11
            For Each drr As DataRow In class_xml.DT_SHOW.DT11.Rows
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"

        Try
            Dim dao_phr_c As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr_c.GetDataby_FK_IDA(IDA)
            Dim c_phr As Integer = 0
            For Each dao_phr_c.fields In dao_phr_c.datas
                c_phr += 1
            Next
            class_xml.PHR_COUNT = c_phr
        Catch ex As Exception

        End Try

        Try
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            ' class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            'SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        Catch ex As Exception

        End Try

        'Dim bao_lisense_neme As New BAO.ClsDBSqlcommand
        Try
            class_xml.DT_MASTER.DT38 = bao_show.SP_Lisense_Name_and_Addr(_iden) 'ผู้ขออนุญาต
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        Dim DT13 As New DataTable
        Try
            DT13 = class_xml.DT_SHOW.DT13
            For Each drr As DataRow In DT13.Rows
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน

        Dim BSN_IDENTIFY As String = ""
        Try
            'If MAIN_LCN_IDA <> 0 Then
            '    Dim dao_lcn2 As New DAO_DRUG.ClsDBdalcn
            '    dao_lcn2.GetDataby_IDA(MAIN_LCN_IDA)
            'End If
            BSN_IDENTIFY = NumEng2Thai(dao.fields.BSN_IDENTIFY)
        Catch ex As Exception

        End Try
        Dim MAIN_LCN_IDA As Integer = 0
        'If IsNothing(dao.fields.MAIN_LCN_IDA) = False Then
        '    If (Integer.TryParse(dao.fields.MAIN_LCN_IDA, MAIN_LCN_IDA) = True) Then        'เปลี่ยน ร
        '        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        '    End If
        'End If
        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(BSN_IDENTIFY) 'ผู้ดำเนิน
        'If MAIN_LCN_IDA <> 0 Then
        '    'ใบย่อย
        '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(MAIN_LCN_IDA) 'ผู้ดำเนิน

        '    'Dim dao_mn As New DAO_DRUG.ClsDBdalcn
        '    'dao_mn.GetDataby_IDA(MAIN_LCN_IDA)
        '    'lcnno_auto = dao_mn.fields.lcnno
        'Else

        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(IDA) 'ผู้ดำเนิน
        'End If
        Dim dt14 As New DataTable
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(IDA)
        Try
            If dao_frgn.fields.addr_status = 0 Or dao_frgn.fields.addr_status = 1 Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_DALCN_CURRENT_ADDRESS(IDA)
            ElseIf dao_frgn.fields.addr_status = Nothing Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(IDA)
            End If

        Catch ex As Exception

        End Try
        'Dim DT39 As New DataTable
        'Try
        '    DT39 = class_xml.DT_MASTER.DT39
        '    For Each drr As DataRow In DT39.Rows
        '        drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
        '        drr("CREATE_DATE") = NumEng2Thai(drr("CREATE_DATE"))
        '        drr("AGE") = NumEng2Thai(drr("AGE"))
        '        drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
        '        drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
        '        drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
        '        'fulladdr
        '    Next
        'Catch ex As Exception

        'End Try
        Try
            dt14 = class_xml.DT_SHOW.DT14
            For Each drr As DataRow In dt14.Rows
                drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA) 'ผู้มีหน้าที่ปฏิบัติการ
        'Dim DT18 As New DataTable

        'DT18 = class_xml.DT_MASTER.DT18
        'For Each drr As DataRow In DT18.Rows
        '    Try
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Catch ex As Exception

        '    End Try

        'Next
        class_xml.DT_SHOW.DT35 = bao_master.SP_DALCN_FRGN_DATA(IDA)

        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao.fields.IDA)
        Dim DT24 As New DataTable
        Try
            DT24 = class_xml.DT_MASTER.DT24
            For Each drr As DataRow In DT24.Rows
                Try
                    drr("thanameplace2") = NumEng2Thai(drr("thanameplace2"))
                Catch ex As Exception

                End Try
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
            class_xml.DT_MASTER.DT24 = DT24
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        Dim DT25 As New DataTable
        Try
            DT25 = class_xml.DT_MASTER.DT25
            For Each drr As DataRow In DT25.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        Dim DT26 As New DataTable
        Try
            DT26 = class_xml.DT_MASTER.DT26
            For Each drr As DataRow In DT26.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        Dim DT27 As New DataTable
        Try
            DT27 = class_xml.DT_MASTER.DT27
            For Each drr As DataRow In DT27.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 1)
        Dim DT28 As New DataTable
        Try
            DT28 = class_xml.DT_MASTER.DT28
            For Each drr As DataRow In DT28.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 2)
        Dim DT29 As New DataTable
        Try
            DT29 = class_xml.DT_MASTER.DT29
            For Each drr As DataRow In DT29.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"

        class_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(dao.fields.IDA)
        Dim DT31 As New DataTable

        DT31 = class_xml.DT_MASTER.DT31
        For Each drr As DataRow In DT31.Rows
            Try
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Catch ex As Exception

            End Try

        Next


        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try
        'Try
        '    If Len(lcnno_auto) > 0 Then

        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
        '        Else
        '            lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
        Try
            If dao.fields.REVOCATION Is Nothing Or Trim(dao.fields.REVOCATION) = "" Then
                If Len(lcnno_auto) > 0 Then

                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                        lcnno_format = dao.fields.pvnabbr & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                    'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)

                End If

                lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW

            Else

                Dim _type_da As String = ""
                If dao.fields.PROCESS_ID = "120" Then
                    _type_da = "3"
                ElseIf dao.fields.PROCESS_ID = "121" Then
                    _type_da = "2"
                ElseIf dao.fields.PROCESS_ID = "122" Then
                    _type_da = "1"
                End If

                If Not dao.fields.LCNNO_DISPLAY_NEW Is Nothing Then
                    lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    'Try
                    '    Dim App_Date As Date = dao.fields.appdate
                    '    If App_Date > #10/1/2019 12:00:00 AM# Then
                    '        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    '    Else
                    '        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then
                        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    End If
                    'lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                Else
                    lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

            Try
                'lcnno_format = 
                'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                    class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                Else
                    class_xml.HEAD_LCNNO = dao_main2.fields.pvnabbr & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                End If

                class_xml.HEAD_LCNNO = NumEng2Thai(class_xml.HEAD_LCNNO)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT32 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT32.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"
        class_xml.DT_MASTER.DT33 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT33.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"

        class_xml.DT_MASTER.DT34 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 3)
        Dim DT34 As New DataTable
        Try
            DT34 = class_xml.DT_MASTER.DT34
            For Each drr As DataRow In DT34.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
                drr("PHR_CERTIFICATE_TRAINING1") = NumEng2Thai(drr("PHR_CERTIFICATE_TRAINING1"))
                '
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT34.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_3_1_ROW"


        'class_xml.LCNNO_SHOW = lcnno_format
        'class_xml.SHOW_LCNNO = lcnno_text
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        ' If MAIN_LCN_IDA = 0 Then

        'class_xml.LCNNO_SHOW = NumEng2Thai(lcnno_format)
        'class_xml.LCNNO_SHOW_NEW = NumEng2Thai(lcnno_format_NEW)

        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.LCNNO_SHOW_NUMTHAI = NumEng2Thai(lcnno_format)
        class_xml.LCNNO_SHOW_NEW = lcnno_format_NEW
        class_xml.LCNNO_SHOW_NEW_NUMTHAI = NumEng2Thai(lcnno_format_NEW)
        class_xml.SHOW_LCNNO = lcnno_text
        class_xml.SHOW_LCNNO_NUMTHAI = NumEng2Thai(lcnno_text)

        Try

            class_xml.COUNT_PHESAJ1 = dao_PHR2.CountDataby_FK_IDA_and_Type(IDA, 1)
        Catch ex As Exception

        End Try

        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ2 = dao_PHR2.CountDataby_FK_IDA_and_Type(IDA, 2)
        Catch ex As Exception

        End Try
        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ3 = dao_PHR2.CountDataby_FK_IDA_and_Type(IDA, 3)
        Catch ex As Exception

        End Try
        'Else

        '    class_xml.LCNNO_SHOW = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(dao_main.fields.lcnno, 5))) & "/25" & Left(dao_main.fields.lcnno, 2)
        '    class_xml.SHOW_LCNNO = dao_main.fields.LCNNO_MANUAL
        'End If
        class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = NumEng2Thai(appdate.Day)
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = NumEng2Thai(con_year(appdate.Year))

                If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then

                    class_xml.RCVDAY_NUMTHAI_NEW = NumEng2Thai(appdate.Day.ToString())
                    class_xml.RCVMONTH_NUMTHAI_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NUMTHAI_NEW = NumEng2Thai(con_year(appdate.Year))

                    class_xml.RCVDAY_NEW = appdate.Day.ToString()
                    class_xml.RCVMONTH_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NEW = con_year(appdate.Year)


                End If


                class_xml.RCVDAY_NUMTHAI = NumEng2Thai(appdate.Day.ToString())
                class_xml.RCVMONTH_NUMTHAI = appdate.ToString("MMMM")
                class_xml.RCVYEAR_NUMTHAI = NumEng2Thai(con_year(appdate.Year))

                class_xml.RCVDAY = appdate.Day.ToString()
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(appdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)
            End If
        Else
            If IsNothing(dao.fields.expyear) = False Then
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                class_xml.EXP_YEAR = NumEng2Thai(expyear)
            End If
        End If
        If IsNothing(dao.fields.expdate) = False Then
            Dim expdate As Date
            If Date.TryParse(dao.fields.expdate, expdate) = True Then
                class_xml.SHOW_EXPDATE_DAY = expdate.Day
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR = con_year(expdate.Year)

                class_xml.SHOW_EXPDATE_DAY_NUMTHAI = NumEng2Thai(expdate.Day)
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR_NUMTHAI = NumEng2Thai(con_year(expdate.Year))


                class_xml.EXPDAY = NumEng2Thai(expdate.Day.ToString())
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXPYEAR = NumEng2Thai(con_year(expdate.Year))
                'Try
                '    class_xml.EXP_YEAR = dao.fields.expyear 'con_year(appdate.Year)
                'Catch ex As Exception
                '    class_xml.EXP_YEAR = con_year(appdate.Year)
                'End Try
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(expdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)

            End If
        End If




        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHRi
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        For Each dao_PHR.fields In dao_PHR.Details
            Try
                If dao_PHR.fields.PHR_TEXT_WORK_TIME <> "" Then
                    dao_PHR.fields.PHR_TEXT_WORK_TIME = NumEng2Thai(dao_PHR.fields.PHR_TEXT_WORK_TIME)
                End If
            Catch ex As Exception

            End Try
            class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        Next
        '-------------------------------------


        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
            Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
            cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm)
            Catch ex As Exception

            End Try
            class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)



        Catch ex As Exception

        End Try
        class_xml.dalcns = dao.fields
        Try
            class_xml.dalcns.CATEGORY_DRUG = NumEng2Thai(class_xml.dalcns.CATEGORY_DRUG)
        Catch ex As Exception

        End Try
        Try
            'class_xml.dalcns.opentime = NumEng2Thai(dao.fields.opentime)
            class_xml.dalcns.opentime = dao.fields.opentime
        Catch ex As Exception

        End Try

        class_xml.syslctaddr_engaddr = dao.fields.syslctaddr_engaddr
        class_xml.syslctaddr_floor = dao.fields.syslctaddr_floor
        class_xml.syslctaddr_mu = dao.fields.syslctaddr_mu
        class_xml.syslctaddr_room = dao.fields.syslctaddr_room
        class_xml.syslctaddr_thaaddr = dao.fields.syslctaddr_thaaddr
        class_xml.syslctaddr_thasoi = dao.fields.syslctaddr_thasoi

        Try
            If dao.fields.lcntpcd = "ขสม" Then
                class_xml.LCN_TYPE = "ขาย"
                class_xml.LCN_TYPE_ID = "3"
            ElseIf dao.fields.lcntpcd = "ผสม" Then
                class_xml.LCN_TYPE = "ผลิต"
                class_xml.LCN_TYPE_ID = "1"
            ElseIf dao.fields.lcntpcd = "นสม" Then
                class_xml.LCN_TYPE = "นำเข้า"
                class_xml.LCN_TYPE_ID = "2"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_pph As New DAO_DRUG.ClsDBDALCN_PHR
            dao_pph.GetDataby_FK_IDA(IDA)
            If dao_pph.fields.PHR_LAW_SECTION = "1" Then
                class_xml.MASTRA = "มาตรา 31"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๑"
                class_xml.MASTRA_NO = "31"
                class_xml.MASTRA_NO_NUMTHAI = "๓๑"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "2" Then
                class_xml.MASTRA = "มาตรา 32"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๒"
                class_xml.MASTRA_NO = "32"
                class_xml.MASTRA_NO_NUMTHAI = "๓๒"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "3" Then
                class_xml.MASTRA = "มาตรา 33"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๓"
                class_xml.MASTRA_NO = "33"
                class_xml.MASTRA_NO_NUMTHAI = "๓๓"
            End If
        Catch ex As Exception

        End Try

        ' p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dalcn2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_dalcn2)

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = ""
        Try
            lcntype = dao.fields.lcntpcd
        Catch ex As Exception

        End Try

        'Dim url2 As String = "https://medicina.fda.moph.go.th/FDA_DRUG"
        'Dim Cls_qr As New QR_CODE.GEN_QR_CODE
        'Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2)

        Dim Process_sub As String
        Process_sub = dao_sub.fields.PROCESS_ID
        statusId = dao_sub.fields.STATUS_ID

        lcntype = Chn_lcntpcd(lcntype)
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim template_id As Integer = 0
        If statusId = 8 Then
            Dim Group As Integer
            Try
                template_id = dao.fields.TEMPLATE_ID
            Catch ex As Exception
                template_id = 0
            End Try
            If template_id = 1 Then
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP_V1(Process_sub, statusId, 0, _group:=1)

            Else
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP_V1(Process_sub, statusId, 0, _group:=0)
            End If

        Else
            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP_V1(Process_sub, 8, 0, _group:=0)
        End If

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)


        'Try
        Dim url As String = ""
        ' If Request.QueryString("status") = 8 Or Request.QueryString("status") = 14 Then
        url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
        'Else
        '    url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF_VIEW.aspx?filename=" & filename
        'End If

        'Dim url As String 
        class_xml.QR_CODE = QR_CODE_IMG(url)
        'Catch ex As Exception

        'End Try


        p_dalcn = class_xml


        'Dim p_dalcn2 As New XML_CENTER.CLASS_DALCN
        'p_dalcn2 = p_dalcn

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        'load_pdf(filename)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        'hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
        _CLS.FILENAME_PDF = NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
    End Sub

    Private Sub ddl_template_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_template.SelectedIndexChanged
        Dim dao_sub As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao_sub.Getdata_by_IDA(_IDA)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(dao_sub.fields.FK_IDA)
        update_template(dao_sub.fields.FK_IDA)
        BindData_PDF_LCN()
    End Sub
    Sub update_template(ByVal ida As String)
        If ddl_template.SelectedValue <> "0" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(ida)
            dao.fields.TEMPLATE_ID = ddl_template.SelectedValue
            dao.update()
        End If

    End Sub
    'Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
    '    Dim dao As New DAO_DRUG.ClsDBdalcn
    '    dao.GetDataby_IDA(_IDA)
    '    If dao.fields.STATUS_ID = 8 Then
    '        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    '    End If
    'End Sub
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub
    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        Try
            imgBin = reader.ReadBytes(stream.Length)
        Catch ex As Exception
        Finally
            stream.Close()
            reader.Close()
        End Try
        Return imgBin
    End Function

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim _group As Integer = 0


        BindData_PDF_LCN(_group:=0)
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        dao.fields.STATUS_ID = 78
        dao.update()

        AddLogStatus(78, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        alert("ดำเนินการยกเลิกคำขอแล้ว")
    End Sub

End Class
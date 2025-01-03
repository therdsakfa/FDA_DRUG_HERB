﻿Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Imports Telerik.Web.UI

Public Class UC_DS_NORYORBOR8
    Inherits System.Web.UI.UserControl
    Private _CLS As CLS_SESSION
    Public _process As String '= "1704"
    Private _lct_ida As String
    Private _lcn_ida As String
    Private _main_ida As String
    Private main_ida As Integer
    Private _write_at As String
    Private _phesaj As String


    Sub RunSession()
        'Try
        '    If Session("CLS") Is Nothing Then
        '        Response.Redirect("http://privus.fda.moph.go.th/")
        '    Else
        '        _CLS = Session("CLS")
        '        Try
        '            _process = Request.QueryString("process_id")
        '        Catch ex As Exception

        '        End Try
        '        _lcn_ida = Request("lcn_ida").ToString()
        '        '_lcn_ida = 41017
        '        _main_ida = Request("main_ida").ToString()
        '        main_ida = CInt(_main_ida)
        '        Try
        '            _write_at = Request("write_at").ToString()
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            _phesaj = Request("phesaj").ToString()
        '        Catch ex As Exception
        '        End Try
        '        ' _process = Request.QueryString("")
        '        _lcn_ida = Request("lcn_ida").ToString()
        '        Dim dao As New DAO_DRUG.ClsDBdalcn
        '        dao.GetDataby_IDA(_lcn_ida)
        '        If dao.fields.lcntpcd.Contains("ผย") Then
        '            _process = "1701"
        '            If dao.fields.lcntpcd.Contains("ผยบ") Then
        '                _process = "1703"

        '                If Request.QueryString("tt") <> "" Then
        '                    _process = "1706"
        '                End If
        '            End If

        '        ElseIf dao.fields.lcntpcd.Contains("นย") Then
        '            _process = "1702"
        '            If dao.fields.lcntpcd.Contains("นยบ") Then
        '                _process = "1704"

        '                If Request.QueryString("tt") <> "" Then
        '                    _process = "1707"
        '                End If
        '            End If
        '        End If
        '    End If

        'Catch ex As Exception
        '    Response.Redirect("http://privus.fda.moph.go.th/")
        'End Try
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _lcn_ida = Request("lcn_ida").ToString()
                '_lcn_ida = 41017
                _main_ida = Request("main_ida").ToString()
                main_ida = CInt(_main_ida)
                Try
                    _write_at = Request("write_at").ToString()
                Catch ex As Exception
                End Try
                Try
                    _phesaj = Request("phesaj").ToString()
                Catch ex As Exception
                End Try
                Try
                    _process = Request.QueryString("process_id")
                Catch ex As Exception

                End Try
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim cls_session As New CLS_SESSION
        cls_session.IDA = _main_ida
        If Request.QueryString("tt") <> "" Then
            cls_session.PVCODE = "12"
        Else
            cls_session.PVCODE = "9"
        End If
        Session.Add("product_id", cls_session)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        RunSession()
        If Not IsPostBack Then
            txt_WRITE_DATE.Text = Date.Now.ToShortDateString 'แสดงวันที่
            bind_ddl_unit()
            'load_ddl()
            set_label()
            If Request.QueryString("tt") <> "" Then
                txt_WRITE_AT.Text = "ออกโดยระบบอิเล็กทรอนิกส์"
            End If
            If Request.QueryString("tt") <> "" Then
                btn_save.Text = "บันทึก ยบ.8"
                btn_package.Visible = False
                btn_add.Visible = False
                txt_WRITE_AT.Enabled = True
            End If
        End If
    End Sub
    'Public Sub load_ddl() 'เลือกเลขที่บัญชีรายการยา
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    bao.SP_DRUG_PRODUCT_ID_BY_IDEN_SELECT2(_lcn_ida, _process)

    '    dt = bao.dt
    '    ddl_search.DataSource = dt
    '    ddl_search.DataTextField = "RCVNO_DISPLAY"
    '    ddl_search.DataValueField = "IDA"
    '    ddl_search.DataBind()

    '    Dim item As New ListItem
    '    item.Text = "กรุณาเลือกเลขที่บัญชีรายการยา"
    '    item.Value = "0"
    '    ddl_search.Items.Insert(0, item)
    'End Sub
    Public Sub bind_ddl_unit() 'เลือกหน่วยขนาดบรรจุ
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MAS_UNIT_CONTAIN

        Dim item As New ListItem("-", "0")
        'imp_detail(main_ida)
        'ddl_munit.DataSource = dt
        'ddl_munit.DataTextField = "unitnm"
        'ddl_munit.DataValueField = "IDA"
        'ddl_munit.DataBind()

        'ddl_bunit.DataSource = dt
        'ddl_bunit.DataTextField = "unitnm"
        'ddl_bunit.DataValueField = "IDA"
        'ddl_bunit.DataBind()

        'ddl_munit.Items.Insert(0, item)
        'ddl_bunit.Items.Insert(0, item)
    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.ClsDBdrsamp)
        dao.fields.WRITE_AT = txt_WRITE_AT.Text     'เขียนที่
        dao.fields.WRITE_DATE = txt_WRITE_DATE.Text 'วันที่เขียน
        Try
            dao.fields.WRITE_DATE = CDate(txt_WRITE_DATE.Text) 'ดึงข้อมูลเขียนที่
        Catch ex As Exception

        End Try
    End Sub
    Public Sub set_label() 'ดึงข้อมูลแสดง
        Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_drugname.GetDataby_IDA(main_ida)
            lbl_drugthanm.Text = dao_drugname.fields.DRUG_NAME_THAI '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
            lbl_drugengnm.Text = dao_drugname.fields.DRUG_NAME_OTHER
            'lbl_unit.Text = dao_drugname.fields.FK_DOSAGE_FORM    'หน่วยนับตามรูปแบบยา
            lbl_sunit_ida.Text = dao_drugname.fields.UNIT_NORMAL   'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
            lbl_nature.Text = dao_drugname.fields.DRUG_COLOR
            'lbl_dosage.Text = dao_drugname.fields.STRENGTH_DRUG 'ปริมาณที่จะผลิต/นำสั่ง
            pid.Text = dao_drugname.fields.RCVNO_DISPLAY

        Catch ex As Exception

        End Try

        Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_package.GetDataby_FK_IDA(dao_drugname.fields.IDA)
        dao_package.fields.SMALL_UNIT = lbl_sunit_ida.Text     'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ

        Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT 'ตารางเก็บหน่วยขนาดบรรจุ
        Try
            dao_unit.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
            lbl_unit.Text = dao_unit.fields.unit_name 'หน่วยนับตามรูปแบบยา
            'lbl_unit2.Text = dao_unit.fields.unit_name 'หน่วยของปริมาณที่จะผลิต/นำสั่ง
            lbl_sunit.Text = dao_unit.fields.unit_name 'หน่วยของขนาดบรรจุ
        Catch ex As Exception

        End Try
        '--------------------------------------------------------------------------------------

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn 'ตาราางเก็บที่อยู่
        dao_lcn.GetDataby_IDA(dao_drugname.fields.FK_IDA)
        If dao_lcn.fields.lcntpcd = "นยบ" Then '"นยบ8"
            rdb_direct_register.Checked = True
            rdb_direct_license.Checked = True
            rdb_direct_registers.Checked = True
            rdb_direct.Checked = True
        ElseIf dao_lcn.fields.lcntpcd = "นยบ" Then '"นยบ8"
            rdb_sample_drug.Checked = False
            rdb_manufacture.Checked = False
            rdb_samples_drug.Checked = False
            rdb_drug_produce.Checked = False
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เลขที่นี้ไม่มี นยบ8 ในระบบ');", True)
        End If
        'dao_lcn.GetDataEditby_IDEN(dao_drugname.fields.CITIZEN_ID_AUTHORIZE)
        'txt_WRITE_AT.Text = dao_lcn.fields.WRITE_AT             'เขียนที่
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Try
            dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
            'dao_lcn.GetDataEditby_IDEN(dao_drugname.fields.CITIZEN_ID_AUTHORIZE)
            'txt_WRITE_AT.Text = dao_lcn.fields.WRITE_AT            'เขียนที่
            lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY  'เลขที่ใบอนุญาต
            lbl_number.Text = dao_addr.fields.thaaddr               'ที่อยู่
            lbl_place_name.Text = dao_addr.fields.thanameplace            'สถานที่ผลิต / นำสั่ง
            lbl_lane.Text = dao_addr.fields.thasoi                'ซอย
            lbl_road.Text = dao_addr.fields.tharoad              'ถนน
            lbl_village_no.Text = dao_addr.fields.thamu         'หมู่
            lbl_sub_district.Text = dao_addr.fields.thathmblnm 'ตำบล
            lbl_district.Text = dao_addr.fields.thaamphrnm     'อำเภอ
            lbl_province.Text = dao_addr.fields.thachngwtnm   'จังหวัด
            lbl_tel.Text = dao_addr.fields.tel 'เบอร์โทร
        Catch ex As Exception

        End Try

        Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
        dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd) 'ชื่อผู้รับอนุญาต
        lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต
        Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
        Dim dao_lo_bsn As New DAO_CPN.TB_LOCATION_BSN
        Try

            dao_lo_bsn.Getdata_by_bsnid(dao_lcn.fields.bsnid)
        Catch ex As Exception

        End Try
        Try

            dao_prefix2.Getdata_byid(dao_lo_bsn.fields.BSN_PREFIXTHAICD)
        Catch ex As Exception

        End Try
        Try

            lbl_bsn_name.Text = dao_prefix2.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ
        Catch ex As Exception

        End Try

        Dim bao As New BAO_MASTER
        ddl_phesaj.DataSource = bao.SP_DALCN_PHR_BY_FK_IDA(dao_lcn.fields.IDA)
        ddl_phesaj.DataTextField = "FULLNAMEs"
        ddl_phesaj.DataValueField = "IDA"
        ddl_phesaj.DataBind()
        Dim item As New ListItem
        item.Text = "เลือกผู้มีหน้าที่ปฏิบัติการ"
        item.Value = "0"
        ddl_phesaj.Items.Insert(0, item)

        Dim baophr As New BAO.ClsDBSqlcommand
        ddl_snunit.DataSource = baophr.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(dao_drugname.fields.IDA)
        ddl_snunit.DataTextField = "unit_name"
        ddl_snunit.DataValueField = "SMALL_UNIT"
        ddl_snunit.DataBind()
        Dim item2 As New ListItem
        item2.Text = "เลือกหน่วยนับตามรูปแบบยา"
        item2.Value = "0"
        ddl_snunit.Items.Insert(0, item2)

        Try
            txt_WRITE_AT.Text = _write_at
        Catch ex As Exception
        End Try
        Try
            ddl_phesaj.SelectedValue = _phesaj
        Catch ex As Exception
        End Try
        'ดึงตัวยาสำคัญ

        RadGrid1_NeedDataSource(dao_drugname.fields.IDA) 'ดึงตัวยาสำคัญ

        HiddenField1.Value = dao_drugname.fields.IDA

        Unit_Radgrid(dao_drugname.fields.IDA) 'ดึงขนาดบรรจุ

        package(dao_drugname.fields.IDA)

        RadGrid5_NeedDataSource(dao_drugname.fields.IDA)
        Smtext_unit(dao_drugname.fields.IDA)

    End Sub
    Private Sub RadGrid1_NeedDataSource(lcnno As Integer) 'ตัวยาสำคัญ
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(lcnno)

        Catch ex As Exception

        End Try
        RadGrid1.DataSource = dt
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao_drugname As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao_drugname.GetDataby_IDA(item("IDA").Text)

                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                Unit_Radgrid(dao_drugname.fields.IDA)
                'imp_detail(dao.fields.FK_IDA)
            End If
        End If
        RadGrid2.Rebind()
    End Sub
    Public Sub Unit_Radgrid(ByVal ida As Integer)

        RadGrid2.Rebind()
    End Sub
    'Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
    '    If ddl_search.SelectedValue = 0 Then
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเลขบัญชีรายการยา');", True)
    '    Else
    '        Dim lcn_no As String = ddl_search.SelectedItem.Text 'ปุ่มดึงข้อมูล
    '        set_label(lcn_no)

    '        Dim check_lcntpcd As New DAO_DRUG.ClsDBDRUG_REGISTRATION
    '        check_lcntpcd.GetDataby_product(lcn_no)

    '        Dim check As New DAO_DRUG.ClsDBdalcn
    '        check.GetDataby_IDA(check_lcntpcd.fields.FK_IDA)

    '        If check.fields.lcntpcd = "นยบ" Then '"นยบ8"
    '            rdb_direct_register.Checked = True
    '            rdb_direct_license.Checked = True
    '            rdb_direct_registers.Checked = True
    '            rdb_direct.Checked = True
    '        ElseIf check.fields.lcntpcd = "นยบ" Then '"นยบ8"
    '            rdb_sample_drug.Checked = False
    '            rdb_manufacture.Checked = False
    '            rdb_samples_drug.Checked = False
    '            rdb_drug_produce.Checked = False
    '        Else
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เลขที่นี้ไม่มี นยบ8 ในระบบ');", True)
    '        End If
    '    End If
    'End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click 'ปุ่มเพิ่มขนาดบรรจุ
        If main_ida = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเลขบัญชีรายการยา');", True)
        ElseIf txt_packagename.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกชื่อขนาดบรรจุ');", True)
        ElseIf txt_sunit.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกจำนวนขนาดบรรจุ');", True)
        ElseIf ddl_munit.SelectedValue = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกขนาดบรรจุ');", True)
        ElseIf txt_mamount.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกจำนวนขนาดบรรจุ');", True)
        ElseIf ddl_bunit.SelectedValue = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกขนาดบรรจุ');", True)
        ElseIf txt_barcode.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกหมายเลขบาร์โค้ด');", True)
            'ElseIf ddl_snunit.SelectedValue = 0 Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกหน่วยนับตามรูปแบบยา');", True)
        Else
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
            Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_drugname.GetDataby_IDA(main_ida)
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.SMALL_UNIT = lbl_sunit_ida.Text            'เลือกขนาดของหน่วยเล็ก
            Catch ex As Exception
            End Try
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.MEDIUM_UNIT = ddl_munit.SelectedValue  'เลือกขนาดของหน่วยกลาง
            Catch ex As Exception

            End Try
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.BIG_UNIT = ddl_bunit.SelectedValue     'เลือกขนาดของหน่วยใหญ่
            Catch ex As Exception

            End Try
            dao.fields.FK_IDA = dao_drugname.fields.IDA
            dao.fields.PACKAGE_NAME = txt_packagename.Text 'ชื่อขนาดบรรจุ
            dao.fields.SMALL_AMOUNT = txt_sunit.Text         'จำนวนขนาดบรรจุเล็ก
            Try
                dao.fields.MEDIUM_AMOUNT = txt_mamount.Text        'จำนวนขนาดบรรจุกลาง
            Catch ex As Exception
                dao.fields.MEDIUM_AMOUNT = 1
            End Try
            dao.fields.BARCODE = txt_barcode.Text            'บาร์โค้ดขนาดบรรจุ
            dao.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เพิ่มข้อมูลขนาดบรรจุเรียบร้อย');", True)
            Unit_Radgrid(dao_drugname.fields.IDA)
            package(dao_drugname.fields.IDA)
        End If
    End Sub
    Protected Sub ddl_munit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_munit.SelectedIndexChanged
        lbl_munit.Text = ddl_munit.SelectedItem.Text
        sum()
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim i As Integer = 0
        Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL

        i = dao_package.CountDataby_FK_IDA(_main_ida)
        If main_ida = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเลขบัญชีรายการยา');", True)
        ElseIf txt_WRITE_AT.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเขียนที่');", True)
        ElseIf ddl_phesaj.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกผู้มีหน้าที่ปฏิบัติการ');", True)
            'ElseIf txt_imp.Text = "" Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาบันทึกผลิตภัณฑ์ที่ต้องการนำเข้า');", True)
        ElseIf i = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเพิ่มขนาดบรรจุ');", True)
        Else
            Dim save As New DAO_DRUG.ClsDBdrsamp
            'chk_package() 'อัพเดท checkbox ใน radgrid
            Thread.CurrentThread.CurrentCulture = New CultureInfo("th-TH")
            save.fields.WRITE_AT = txt_WRITE_AT.Text 'เก็บเขียนที่
            save.fields.WRITE_DATE = Date.Now 'เก็บวันที่

            Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION 'ชื่อยา
            dao_drugname.GetDataby_IDA(main_ida)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_drugname.fields.FK_IDA)
            If rdb_sample_drug.Checked = True Then
                save.fields.CHK_PERMISSION_REQUEST = 1 'ผลิตยาตัวอย่าง
                save.fields.CHK_PERMISSION_GET = 1 'ผลิตยาแผนโบราณ
                save.fields.CHK_PERMISSION_ASK = 1 'ผลิตยาตัวอย่าง
                save.fields.CHK_PERMISSION_DESCRIPTION = 1 'ยาที่ผลิต
            ElseIf rdb_direct_register.Checked = True Then
                save.fields.CHK_PERMISSION_REQUEST = 2 'นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักร
                save.fields.CHK_PERMISSION_GET = 2 'นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรตามใบอนุญาต
                save.fields.CHK_PERMISSION_ASK = 2 'นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียน
                save.fields.CHK_PERMISSION_DESCRIPTION = 2 'ยาที่นำนำหรือสั่งเข้ามาในราชอาณาจักร
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกคำขออนุญาต');", True)
            End If

            'เก็บข้อมูลในตาราง drsamp
            save.fields.lcnno = dao_drugname.fields.FK_IDA 'เก็บเลขที่ใบอนุญาต
            save.fields.lcn = dao_lcn.fields.lcnno
            save.fields.lcnsid = dao_lcn.fields.lcnsid
            save.fields.pvncd = dao_lcn.fields.pvncd
            save.fields.lcntpcd = "นยบ8" 'เก็บประเภทของใบอนุญาต
            save.fields.thadrgnm = lbl_drugthanm.Text 'เก็บชื่อยาภาษาไทย
            save.fields.engdrgnm = lbl_drugengnm.Text 'เก็บชื่อยาภาษาอังกฤษ
            save.fields.PRODUCT_ID_IDA = dao_drugname.fields.IDA 'เก็บค่า IDA

            'รวมจำนวนการนำเข้าทุกขนาดบรรจุ
            Dim dao_pac As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            dao_pac.GetDataby_FK_IDA(dao_drugname.fields.IDA)
            Dim qty As Integer = 0

            For Each dao_pac.fields In dao_pac.datas
                If dao_pac.fields.CHECK_PACKAGE = True Then
                    If qty = 0 Then
                        qty = dao_pac.fields.SUM
                    Else
                        qty = qty + dao_pac.fields.SUM
                    End If
                End If
            Next

            save.fields.QUANTITY = qty
            save.fields.QUANTITY_UNIT = dao_pac.fields.SMALL_UNIT
            save.fields.phr_fk = ddl_phesaj.SelectedValue
            save.fields.CUSTOMER_CITIZEN_SUBMIT = _CLS.CITIZEN_ID
            save.fields.CUSTOMER_CITIZEN_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            save.fields.process_id = _process
            'save.insert()
            If qty = 0 Then
                save.update()
            Else
                save.fields.QUANTITY = qty
                save.fields.QUANTITY_UNIT = dao_pac.fields.SMALL_UNIT
                save.insert()
            End If

            save.GetDataby_PRODUCT_ID_IDA(dao_pac.fields.FK_IDA)
            'dao_pac.fields.DRSAMP_IDA = save.fields.IDA
            dao_pac.update()
            xml(save.fields.IDA)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
            'Dim ws As New AUTHENTICATION_104.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอยาตัวอย่าง", _process)
            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอยาตัวอย่าง", _process)
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอยาตัวอย่าง", _process)

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอยาตัวอย่าง", _process)

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try
        End If
    End Sub
    'Sub chk_package()
    '    Dim package_detail As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL

    '    For Each item As GridDataItem In RadGrid2.Items

    '        Dim cb_chk As CheckBox = DirectCast(item("TemplateColumn").FindControl("checkColumn"), CheckBox)
    '        If cb_chk.Checked = True Then

    '            package_detail.GetDataby_IDA(item("IDA").Text)
    '            package_detail.fields.CHECK_PACKAGE = 1
    '            package_detail.update()

    '        End If
    '    Next
    'End Sub
    Protected Sub rdb_sample_drug_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_sample_drug.CheckedChanged
        rdb_manufacture.Checked = True
        rdb_samples_drug.Checked = True
        rdb_drug_produce.Checked = True
        rdb_direct_license.Checked = False
        rdb_direct_registers.Checked = False
        rdb_direct.Checked = False
    End Sub
    Protected Sub rdb_direct_register_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_direct_register.CheckedChanged
        rdb_direct_license.Checked = True
        rdb_direct_registers.Checked = True
        rdb_direct.Checked = True
        rdb_manufacture.Checked = False
        rdb_samples_drug.Checked = False
        rdb_drug_produce.Checked = False
    End Sub
    Sub xml(ByVal drsamp_ida As Integer)
        Dim get_session As CLS_SESSION = Session("product_id")
        Dim cls_xml As New CLASS_DRSAMP
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_master As New BAO_MASTER

        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(main_ida)
        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(main_ida)
        Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
        dao_dalcn.GetDataby_IDA(dao.fields.FK_IDA)

        cls_xml = GEN_XML()
        Dim write_date As Date = dao_drsamp.fields.WRITE_DATE
        dao_drsamp.fields.WRITE_DATE = DateAdd(DateInterval.Year, 543, write_date)
        cls_xml.drsamp = dao_drsamp.fields  'ใบ
        cls_xml.regis = dao.fields
        cls_xml.DT_SHOW.DT1 = bao.SP_DRUG_REGISTRATION(main_ida) 'บัญชีรายการยา
        cls_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(_lcn_ida) 'เลขที่ใบอนุญาต
        cls_xml.DT_SHOW.DT3 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(main_ida) 'ตัวยาสำคัญ
        cls_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(main_ida) 'ขนาดบรรจุ
        cls_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(main_ida) 'ขนาดบรรจุ
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
            cls_xml.DT_SHOW.DT6 = bao.SP_regis(main_ida)
            cls_xml.DT_SHOW.DT9 = bao.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(main_ida)
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

        cls_xml.DT_SHOW.DT7 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(main_ida) 'ดึงตัวยาสำคัญ multi
        cls_xml.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
        cls_xml.DT_SHOW.DT8 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(main_ida)    'ขนาดบรรจุ multi
        cls_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID) 'ผู้ยื่น
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        Try

            cls_xml.DT_SHOW.DT20 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_NEW(main_ida) 'สารสำคัญ/ส่วนประกอบ(รวม)
            cls_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
        Catch ex As Exception

        End Try
        Dim dao_pac As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_pac.GetDataby_FK_IDA(main_ida)
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
        unit_physic.GetDataby_sunitcd(CInt(lbl_sunit_ida.Text))

        cls_xml.IMPORT_AMOUNTS = dao_drsamp.fields.QUANTITY & " " & unit_physic.fields.unit_name

        Dim bao2 As New BAO.AppSettings
        bao2.RunAppSettings()
        Dim paths As String = bao2._PATH_DEFAULT
        Dim file_template As String = ""
        Dim process As String = "-"
        If get_session.PVCODE = "6" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8.pdf"
            process = "1701"
        ElseIf get_session.PVCODE = "7" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYOR8.pdf"
            process = "1702"
        ElseIf get_session.PVCODE = "8" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8.pdf"
            process = "1703"
        ElseIf get_session.PVCODE = "9" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORBOR8.pdf"
            process = "1704"
        ElseIf get_session.PVCODE = "10" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8(VEJAI).pdf" '"C:\path\DRUG\PDF_TEMPLATE\PDF_DRUG_PORYOR8.pdf"
            process = "1705"
        ElseIf get_session.PVCODE = "11" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8_HERB_AUTO.pdf"
            process = "1706"
        ElseIf get_session.PVCODE = "12" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8_HERB_AUTO.pdf" '"PDF_TEMPLATE\PDF_DRUG_NORYORBOR8.pdf"
            process = "1707"
        End If

        'If _process = "1701" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8.pdf"
        '    process = "1701"
        'ElseIf _process = "1702" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYOR8.pdf"
        '    process = "1702"
        'ElseIf _process = "1703" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8.pdf"
        '    process = "1703"
        'ElseIf _process = "1704" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORBOR8.pdf"
        '    process = "1704"
        'ElseIf _process = "1705" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8(VEJAI).pdf" '"C:\path\DRUG\PDF_TEMPLATE\PDF_DRUG_PORYOR8.pdf"
        '    process = "1705"
        'ElseIf _process = "1706" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8_HERB_AUTO.pdf"
        '    process = "1706"
        'ElseIf _process = "1707" Then
        '    file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8_HERB_AUTO.pdf" '"PDF_TEMPLATE\PDF_DRUG_NORYORBOR8.pdf"
        '    process = "1707"
        'End If

        Dim path_XML As String = paths & "XML_TRADER_DOWNLOAD\" & "DA-" & process & "-" & dao.fields.RCVNO_DISPLAY + ".xml"
        Dim file_PDF As String = paths & "PDF_TRADER_DOWNLOAD\" & "DA-" & process & "-" & dao.fields.RCVNO_DISPLAY + ".pdf"

        Dim objStreamWriter As New StreamWriter(path_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        convert_XML_To_PDF(file_PDF, path_XML, file_template)
        Dim pdf_name As String = process & "-" & dao.fields.RCVNO_DISPLAY

        _CLS.FILENAME_PDF = file_PDF                                                                                                 ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", pdf_name)

        Session("CLS") = _CLS

        LoadPdf()
    End Sub
    '    after_save()
    'End Sub
    'Sub after_save(ByVal a As Integer)
    '    Dim cls As New CLS_SESSION
    '    cls.IDA = ddl_search.SelectedValue
    '    cls.TRANSECTION_UP_ID = a
    '    cls.PVCODE = "9"
    '    Session.Add("product_id", cls)
    '    Response.Redirect("DS_DOWNLOAD_PDF.aspx?lcn_ida=" & _lcn_ida)
    'End Sub

    Private Function GEN_XML() As CLASS_DRSAMP
        Dim class_xml As New CLASS_DRSAMP

        Return class_xml
    End Function
    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('Download เสร็จสิ้น');", True)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    ''' <summary>
    ''' ใส่ค่าในฟิลที่ null
    ''' </summary>
    ''' <param name="ob"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend Function AddValue(ByVal ob As Object) As Object
        Dim props As System.Reflection.PropertyInfo
        For Each props In ob.GetType.GetProperties()

            '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
            Dim p_type As String = props.PropertyType.ToString()
            If props.CanWrite = True Then
                If p_type.ToUpper = "System.String".ToUpper Then
                    props.SetValue(ob, " ", Nothing)
                ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.Double".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.float".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                    props.SetValue(ob, Date.Now, Nothing)
                Else
                    Try
                        props.SetValue(ob, 0, Nothing)
                    Catch ex As Exception
                        props.SetValue(ob, Nothing, Nothing)
                    End Try


                End If
            End If

            'prop.SetValue(cls1, "")
            'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
        Next props

        Return ob
    End Function
    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        'Dim ws As New AUTHENTICATION_104.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด modal คำขอยาตัวอย่าง", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด modal คำขอยาตัวอย่าง", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด modal คำขอยาตัวอย่าง", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด modal คำขอยาตัวอย่าง", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
        'Dim get_session As CLS_SESSION = Session("product_id")
        'If get_session.PVCODE = "6" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1701 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'ElseIf get_session.PVCODE = "7" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1702 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'ElseIf get_session.PVCODE = "8" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1703 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'ElseIf get_session.PVCODE = "9" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1704 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'ElseIf get_session.PVCODE = "10" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1705 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'End If
    End Sub

    Private Sub txt_qty_TextChanged(sender As Object, e As EventArgs) Handles txt_qty.TextChanged
        sum()
    End Sub

    Sub sum()
        Try
            Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)

            Dim sum As Integer = 0
            sum = CInt(dao_package.fields.SMALL_AMOUNT) * CInt(dao_package.fields.MEDIUM_AMOUNT)
            sum = sum * CInt(txt_qty.Text)

            lbl_import_sum.Text = "( " & sum & " " & lbl_unit.Text & ")"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_package_Click(sender As Object, e As EventArgs) Handles btn_package.Click

        ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Response.Redirect('" & "../DS/DURG8_ADD.aspx?IDA=" & main_ida & "&sunit_ida=" & lbl_sunit_ida.Text & "&process=" & _process & "');", True)
        Response.Redirect("../DS/FRM_DS_DRUG8_ADD.aspx?main_ida=" & main_ida & "&lcn_ida=" & _lcn_ida & "&sunit_ida=" & lbl_sunit_ida.Text & "&process=" & _process & "&write_at=" & txt_WRITE_AT.Text & "&phesaj=" & ddl_phesaj.Text)
        'Response.Write("<script>window.open('" + ("../DS/UC/UC_DRUG8_ADD.aspx?IDA=" & main_ida & "&sunit_ida=" & lbl_sunit_ida.Text & "&process=" & _process) + "','_ new', 'width=400,height=200');</script>")
        'If Label2.Text = "on" Then
        '    Label2.Text = "off"
        '    package2.Style.Add("display", "in-line")
        '    package3.Style.Add("display", "in-line")
        'Else
        '    Label2.Text = "on"
        '    package2.Style.Add("display", "none")
        '    package3.Style.Add("display", "none")
        'End If

    End Sub

    Sub package(ByVal fk_ida As Integer)
        'Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        'Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
        Dim item As New ListItem("---เลือกขนาดบรรจุ---", "0")
        'dao_package.GetDataby_FK_IDA(fk_ida)
        Dim bao As New BAO.ClsDBSqlcommand
        'dao_unit.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
        ddl_package_unit.DataSource = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA_add(main_ida)
        ddl_package_unit.DataTextField = "small_sum"
        ddl_package_unit.DataValueField = "IDA"
        ddl_package_unit.DataBind()
        ddl_package_unit.Items.Insert(0, item)
    End Sub
    Protected Sub ddl_package_unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_package_unit.SelectedIndexChanged
        Try
            Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)
            Dim dao_mas_unit As New DAO_DRUG.TB_drsunit
            dao_mas_unit.GetDataby_sunitcd(dao_package.fields.BIG_UNIT)
            imp_unit.Text = dao_mas_unit.fields.sunitengnm
        Catch ex As Exception

        End Try

        sum()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)
        Dim dao_mas_unit As New DAO_DRUG.TB_drsunit
        dao_mas_unit.GetDataby_sunitcd(dao_package.fields.MEDIUM_UNIT)
        Dim dao_mas_unit1 As New DAO_DRUG.TB_drsunit
        dao_mas_unit1.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
        Dim dao_mas_unit2 As New DAO_DRUG.TB_drsunit
        dao_mas_unit2.GetDataby_sunitcd(dao_package.fields.BIG_UNIT)
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(main_ida)
        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_package.fields.FK_IDA)
        ' dao_package.fields.FK_IDA = dao_drsamp.fields.IDA
        If dao_package.fields.CHECK_PACKAGE = True Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ขนาดบรรจุนี้ มีปริมาณที่จะผลิต/นำสั่งแล้ว');", True)
        Else
            dao_package.fields.IM_QTY = CInt(txt_qty.Text)
            Dim sum As Integer = CInt(dao_package.fields.SMALL_AMOUNT) * CInt(dao_package.fields.MEDIUM_AMOUNT)
            sum = sum * CInt(txt_qty.Text)
            dao_package.fields.SUM = sum
            dao_package.fields.IM_DETAIL = dao_package.fields.SMALL_AMOUNT & " " & dao_mas_unit1.fields.sunitthanm & " x " & dao_package.fields.MEDIUM_AMOUNT & " " & dao_mas_unit.fields.sunitthanm & " x " & dao_package.fields.BIG_AMOUNT & " " & dao_mas_unit2.fields.sunitthanm & " จำนวน " & txt_qty.Text & " " & dao_mas_unit2.fields.sunitengnm & " (" & sum & " " & lbl_unit.Text & ")"
            dao_package.fields.CHECK_PACKAGE = 1
            dao_package.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
            RadGrid5_NeedDataSource(dao_package.fields.FK_IDA)

        End If
        'Dim ws As New AUTHENTICATION_104.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "บันทึกปริมาณที่จะนำสั่งยาตัวอย่าง", _process)
        ' RadGrid2.Rebind()

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "บันทึกปริมาณที่จะนำสั่งยาตัวอย่าง", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "บันทึกปริมาณที่จะนำสั่งยาตัวอย่าง", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "บันทึกปริมาณที่จะนำสั่งยาตัวอย่าง", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try

    End Sub

    'Sub imp_detail(ByVal fk_ida As Integer)
    '    Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
    '    dao_package.GetDataby_FK_IDA(fk_ida)
    '    txt_imp.Text = ""
    '    For Each dao_package.fields In dao_package.datas
    '        If dao_package.fields.CHECK_PACKAGE = True Then
    '            If txt_imp.Text = "" Then
    '                txt_imp.Text = dao_package.fields.IM_DETAIL
    '            Else
    '                txt_imp.Text = txt_imp.Text & "<br/>" & dao_package.fields.IM_DETAIL
    '            End If
    '        Else

    '        End If
    '    Next
    'End Sub
    Sub Smtext_unit(ByVal fk_ida As Integer)
        Dim dao_package As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_package.GetDataby_IDA(fk_ida)
        Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT



        Try

            dao_unit.GetDataby_sunitcd(dao_package.fields.UNIT_NORMAL)
            Stext_unit.Text = dao_unit.fields.short_unit

        Catch ex As Exception

        End Try
    End Sub

    Sub chk_active_package(ByVal lcn_dis As String)
        Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION 'ชื่อยา
        dao_drugname.GetDataby_product(lcn_dis)
        Dim pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        pack.GetData_chk_by_FK_IDA(dao_drugname.fields.FK_IDA)

        For Each pack.fields In pack.datas
            If IsNothing(pack.fields.DATE_ADD) Then

            Else
                Dim chkdate180 As Date
                chkdate180 = pack.fields.DATE_ADD
                chkdate180 = chkdate180.AddDays(180)

                If chkdate180 < Date.Now Then
                    pack.fields.CHECK_PACKAGE = False
                    pack.update()
                End If
            End If
        Next
    End Sub

    Protected Sub ddl_snunit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_snunit.SelectedIndexChanged
        lbl_sunit_ida.Text = ddl_snunit.SelectedValue    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
        lbl_unit.Text = ddl_snunit.SelectedItem.Text 'หน่วยนับตามรูปแบบยา
        lbl_sunit.Text = ddl_snunit.SelectedItem.Text 'หน่วยของขนาดบรรจุ
    End Sub

    'Protected Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    dt = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA(HiddenField1.Value)

    '    RadGrid2.DataSource = dt
    'End Sub

    Private Sub RadGrid5_NeedDataSource(fk_ida As Integer)
        Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL

        dao_package.GetDataby_FK_IDA2(fk_ida)
        'For Each dao_package.fields In dao_package.datas
        'Next
        RadGrid5.DataSource = dao_package.datas
        RadGrid5.Rebind()
    End Sub
    Private Sub RadGrid5_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid5.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                'dao.GetDataAll()
                dao.fields.CHECK_PACKAGE = Nothing
                dao.fields.IM_DETAIL = Nothing
                dao.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid5_NeedDataSource(main_ida)
            End If
        End If
        'Dim ws As New AUTHENTICATION_104.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ลบปริมาณนำสั่งยาตัวอย่าง", _process)
        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ลบปริมาณนำสั่งยาตัวอย่าง", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ลบปริมาณนำสั่งยาตัวอย่าง", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ลบปริมาณนำสั่งยาตัวอย่าง", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
    End Sub
End Class
Imports Telerik.Web.UI
Public Class UC_TABEAN_EDIT_EX1
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA As String = ""
    Private _IDA_EX As String = ""
    Private _PROCESS_ID_LCN As String = ""

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA = Request.QueryString("IDA")
        _IDA_EX = Request.QueryString("IDA_EX")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()
            bind_dd_pack_1()
            bind_dd_pack_2()
            bind_dd_pack_3()
            bind_dd_unit_1()
            bind_dd_unit_2()
            bind_dd_unit_3()
            Get_data()
            bind_dd_TYPE_PRODUCK()
            'package()

        End If
    End Sub
    Public Sub Get_data()
        Dim dao_ex As New DAO_DRUG.ClsDBdrsamp
        dao_ex.GetDataby_IDA(_IDA_EX)
        EX_NAME_PRODUCT.Text = dao_ex.fields.EX_NAME_PRODUCT
        Try
            DD_TYPE_PRODUCK.SelectedValue = dao_ex.fields.EX_PRODUCK_TYPE_ID
        Catch ex As Exception

        End Try
        style_color.Text = dao_ex.fields.EX_STYLE_COLOR
        txt_quantity_produced.Text = dao_ex.fields.EX_QUANTITY_PRODUCESD
        'txt_packing_size.Text = dao_ex.fields.EX_PACKING_SIZE
        'txt_packing_size.Text = dao_ex.fields.EX_PACKING_SIZE
        Try
            'ddl_package_unit.SelectedValue = dao_ex.fields.EX_PACKAGE_ID
        Catch ex As Exception

        End Try

    End Sub
    Public Sub bind_dd_pack_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_PRIMARY()

        DD_PCAK_1.DataSource = dt
        DD_PCAK_1.DataBind()
        DD_PCAK_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_pack_2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_SECONDARY()

        DD_PCAK_2.DataSource = dt
        DD_PCAK_2.DataBind()
        DD_PCAK_2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_pack_3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_TERTIRY()

        DD_PCAK_3.DataSource = dt
        DD_PCAK_3.DataBind()
        DD_PCAK_3.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_PRIMARY()

        DD_UNIT_1.DataSource = dt
        DD_UNIT_1.DataBind()
        DD_UNIT_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_SCONDARY()

        DD_UNIT_2.DataSource = dt
        DD_UNIT_2.DataBind()
        DD_UNIT_2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_TERTIARY()

        DD_UNIT_3.DataSource = dt
        DD_UNIT_3.DataBind()
        DD_UNIT_3.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_TYPE_PRODUCK()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_TYPE_PRODUCK()

        DD_TYPE_PRODUCK.DataSource = dt
        DD_TYPE_PRODUCK.DataBind()
        DD_TYPE_PRODUCK.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim PROCESS_ID_LCN As String = dao_lcn.fields.PROCESS_ID
        Dim sys_p As String = dao_lcn.fields.syslcnsnm_prefixnm
        Dim sys_n As String = dao_lcn.fields.syslcnsnm_thanm
        Dim sys_l As String = dao_lcn.fields.syslcnsnm_thalnm

        'Dim dao_lcnaddr As New DAO_DRUG.ClsDBdalcnaddr
        'dao_lcnaddr.GetDataby_FK_IDA(_IDA_LCN)

        'Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        'dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        dt_lcn = bao.SP_Lisense_Name_and_Addr(_CLS.CITIZEN_ID_AUTHORIZE)

        'Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        'dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)

        Dim dao_cpnaddr As New DAO_CPN.clsDBsyslctaddr
        dao_cpnaddr.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
        Dim cpnaddr_th As String = dao_cpnaddr.fields.thmblnm
        Dim cpnaddr_am As String = dao_cpnaddr.fields.amphrnm
        Dim cpnaddr_ch As String = dao_cpnaddr.fields.chngwtnm
        Dim cpnaddr_zi As String = dao_cpnaddr.fields.zipcode


        For Each dr As DataRow In dt_lcn.Rows
            Try
                TextBox1.Text = dr("tha_fullname")
                TextBox3.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
        Next
        'TextBox1.Text = _CLS.THANM
        TextBox2.Text = dao_lcn.fields.BSN_THAIFULLNAME
        'TextBox3.Text = _CLS.THANM
        DD_CATEGORY_ID.SelectedValue = PROCESS_ID_LCN
        DD_CATEGORY_ID_SUB.SelectedValue = PROCESS_ID_LCN
        TextBox4.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
        TextBox5.Text = dao_lcn.fields.thanm

        'TextBox6.Text = dao_lcnaddr.fields.number_addr
        'TextBox7.Text = dao_lcnaddr.fields.moo
        'TextBox8.Text = dao_lcnaddr.fields.soi
        'TextBox9.Text = dao_lcnaddr.fields.road
        TextBox10.Text = cpnaddr_th
        TextBox11.Text = cpnaddr_am
        TextBox12.Text = cpnaddr_ch + " " + cpnaddr_zi
        TextBox13.Text = dao_lcn.fields.tel

    End Sub
    Public Sub set_data()
        Dim PROCESS_ID As String = 200001
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_ex As New DAO_DRUG.ClsDBdrsamp
        dao_ex.fields.CUSTOMER_CITIZEN_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_ex.fields.CUSTOMER_CITIZEN_SUBMIT = _CLS.CITIZEN_ID

        dao_ex.fields.EX_DATE_YEAR = Date.Now.Year
        dao_ex.fields.EX_NAME_PRODUCT = EX_NAME_PRODUCT.Text
        'dao_ex.fields.EX_PACKING_SIZE = txt_packing_size.Text
        Try
            dao_ex.fields.EX_PRODUCK_TYPE_ID = DD_TYPE_PRODUCK.SelectedValue
        Catch ex As Exception

        End Try
        dao_ex.fields.EX_QUANTITY_PRODUCESD = txt_quantity_produced.Text
        Try
            'dao_ex.fields.EX_SUM_UNIT = txt_sum_unit.Text
            'dao_ex.fields.EX_PACKAGE_ID = ddl_package_unit.SelectedValue
        Catch ex As Exception

        End Try
        dao_ex.fields.EX_STYLE_COLOR = style_color.Text
        dao_ex.fields.process_id = PROCESS_ID
        dao_ex.update()
    End Sub
    'Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

    '    Dim PROCESS_ID As String = 200001
    '    Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
    '    dao_lcn.GetDataby_IDA(_IDA_LCN)
    '    Dim dao_ex As New DAO_DRUG.ClsDBdrsamp
    '    dao_ex.fields.CUSTOMER_CITIZEN_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
    '    dao_ex.fields.CUSTOMER_CITIZEN_SUBMIT = _CLS.CITIZEN_ID

    '    dao_ex.fields.EX_DATE_YEAR = Date.Now.Year
    '    dao_ex.fields.EX_NAME_PRODUCT = EX_NAME_PRODUCT.Text
    '    dao_ex.fields.EX_PACKING_SIZE = txt_packing_size.Text
    '    dao_ex.fields.EX_PRODUCK_TYPE = PRODUCK_TYPE.Text
    '    dao_ex.fields.EX_QUANTITY_PRODUCESD = txt_quantity_produced.Text
    '    dao_ex.fields.EX_STYLE_COLOR = style_color.Text
    '    dao_ex.fields.process_id = PROCESS_ID
    '    dao_ex.update()


    '    Run_Pdf_Tabean_Ex_Herb_1(PROCESS_ID, dao_ex.fields.IDA)

    '    alert_nature("บันทึกข้อมูล และ อัพโหลดเอกสารเรียบร้อย")
    '    If dao_ex.fields.EX_EDIT = 1 Then
    '        Response.Redirect("FRM_HERB_TABEAN_EX.aspx?&IDA_LCN=" & _IDA_LCN)
    '    End If

    'End Sub
    Public Sub Run_Pdf_Tabean_Ex_Herb_1(ByVal PROCESS_ID As String, ByVal IDA_EX As String)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(IDA_EX)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_EX
        TABEAN_EX = XML.gen_xml_TB_EX(dao.fields.IDA, IDA_EX)

        Dim lcntype As String = "ตย1"

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(PROCESS_ID, dao.fields.STATUS_ID, lcntype, 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EX") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE_EX\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", PROCESS_ID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TABEAN_EX("HB_XML", PROCESS_ID, con_year(Date.Now.Year), dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
        ' Response.Redirect("FRM_HERB_TABEAN_EX_CONFIRM.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
    End Sub

    Sub alert_nature(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_TABEAN_SUBSTITUTE_CONFIRM.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_DR=" & _IDA_DR & "&TR_ID_DR=" & _TR_ID_DR & "&PROCESS_ID_DR=" & _PROCESS_ID_DR & "&PROCESS_ID=" & _PROCESS_ID & "&TR_ID=" & _TR_ID & "&DRRGT_REASON_ID=" & _DRRGT_REASON_ID & "&PROCESS_TYPE_ID=" & _PROCESS_TYPE_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    'Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
    '    Response.Redirect("FRM_HERB_TABEAN_EX.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
    'End Sub

    Protected Sub btn_size_pack_Click(sender As Object, e As EventArgs) Handles btn_size_pack.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EX_SIZE_PACK
        Dim dao_PZ As New DAO_TABEAN_HERB.TB_DRSAMP_PACKAGE_SIZE

        dao.fields.FK_IDA_EX = _IDA_EX

        If DD_PCAK_1.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_1.SelectedValue = "-- กรุณาเลือก --" _
           Or DD_PCAK_2.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_2.SelectedValue = "-- กรุณาเลือก --" Then ' _
            'Or DD_PCAK_3.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_3.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูล Primary Seceondary Tertiary Packaging');", True)
        Else
            dao.fields.PACK_F_ID = DD_PCAK_1.SelectedValue
            dao.fields.PACK_F_NAME = DD_PCAK_1.SelectedItem.Text
            dao.fields.NO_1 = NO_1.Text
            dao.fields.UNIT_F_ID = DD_UNIT_1.SelectedValue
            dao.fields.UNIT_F_NAME = DD_UNIT_1.SelectedItem.Text

            dao.fields.PACK_S_ID = DD_PCAK_2.SelectedValue
            dao.fields.PACK_S_NAME = DD_PCAK_2.SelectedItem.Text
            dao.fields.NO_2 = NO_2.Text
            dao.fields.UNIT_S_ID = DD_UNIT_2.SelectedValue
            dao.fields.UNIT_S_NAME = DD_UNIT_2.SelectedItem.Text

            Try
                dao.fields.PACK_T_ID = DD_PCAK_3.SelectedValue
                dao.fields.PACK_T_NAME = DD_PCAK_3.SelectedItem.Text
                dao.fields.NO_3 = NO_3.Text
                dao.fields.UNIT_T_ID = DD_UNIT_3.SelectedValue
                dao.fields.UNIT_T_NAME = DD_UNIT_3.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_T_ID = 0
                dao.fields.PACK_T_NAME = ""
                dao.fields.NO_3 = ""
                dao.fields.UNIT_T_ID = 0
                dao.fields.UNIT_T_NAME = ""
            End Try


            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_USER = _CLS.THANM

            dao.insert()
            insert_package_full(dao.fields.IDA)
            sum(dao.fields.IDA)
        End If

        DD_PCAK_1.ClearSelection()
        DD_UNIT_1.ClearSelection()
        DD_PCAK_2.ClearSelection()
        DD_UNIT_2.ClearSelection()
        DD_PCAK_3.ClearSelection()
        DD_UNIT_3.ClearSelection()
        NO_1.Text = ""
        NO_2.Text = ""
        NO_3.Text = ""

        'package(_IDA_EX)


        RadGrid4.Rebind()
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid4_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid4.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EX_SIZE_PACK
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid4.Rebind()
                'package(_IDA_EX)
                Dim dao_dr As New DAO_TABEAN_HERB.TB_DRSAMP_PACKAGE_SIZE
                dao_dr.GetdatabyID_FK_IDA_PZ(IDA)
                dao_dr.fields.ACTIVEFACT = 0
                dao_dr.Update()
                sum(IDA)
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EX_SIZE_PACK
        dao_size.GetdatabyID_FK_IDA_EX2(_IDA_EX)

        RadGrid4.DataSource = dao_size.datas

    End Sub

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        bind_size()
    End Sub
    'Sub package()
    '    Dim item As New ListItem("---เลือกขนาดบรรจุ---", "0")
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    ddl_package_unit.DataSource = bao.SP_DRSAMP_EX_PACKAGE_DETAIL_BY_FK_IDA_add(_IDA_EX)
    '    ddl_package_unit.DataTextField = "small_sum"
    '    ddl_package_unit.DataValueField = "UNIT_F_ID"
    '    ddl_package_unit.DataBind()
    '    ddl_package_unit.Items.Insert(0, item)
    'End Sub
    'Protected Sub ddl_package_unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_package_unit.SelectedIndexChanged
    '    Try
    '        Dim dao_package As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EX_SIZE_PACK
    '        dao_package.GetdatabyID_FK_IDA_EX_AND_UNIT(_IDA_EX, ddl_package_unit.SelectedValue)
    '        txt_unit.Text = dao_package.fields.UNIT_S_NAME
    '    Catch ex As Exception

    '    End Try

    '    'sum()
    'End Sub
    Sub sum(ByVal IDA As Integer)
        Try
            Dim sum_pagkage As Integer = 0
            Dim dao_package As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EX_SIZE_PACK
            dao_package.GetdatabyID_IDA(_IDA_EX)
            Dim dao_packsize As New DAO_TABEAN_HERB.TB_DRSAMP_PACKAGE_SIZE
            dao_packsize.GetdatabyID_FK_IDA_EX2(_IDA_EX)
            For Each dao_packsize.fields In dao_packsize.datas
                sum_pagkage = sum_pagkage + CInt(dao_packsize.fields.SUM_PACKAGE_UNIT)
            Next

            txt_quantity_produced.Text = sum_pagkage & " " & dao_packsize.fields.UNIT_PACKAGE
            'txt_unit.Text = dao_packsize.fields.UNIT_PACKAGE
        Catch ex As Exception

        End Try
    End Sub
    Private Sub insert_package_full(ByVal IDA As Integer)
        Dim dao_package As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EX_SIZE_PACK
        dao_package.GetdatabyID_IDA(IDA)
        Dim sum As Integer = 0
        Dim NO_3_sum As Integer = 0
        Dim NO_sum As String = ""
        Dim NO_sum1 As String = ""
        Dim NO_sum2 As String = ""
        Try
            sum = CInt(dao_package.fields.NO_1) * CInt(dao_package.fields.NO_2) * CInt(dao_package.fields.NO_3)
            NO_sum = Convert.ToString(dao_package.fields.NO_1) & " " & dao_package.fields.UNIT_F_NAME & " x " & Convert.ToString(dao_package.fields.NO_2) & " " & dao_package.fields.UNIT_S_NAME & " x " & Convert.ToString(dao_package.fields.NO_3) & " " & dao_package.fields.UNIT_T_NAME & "(" & sum & " " & dao_package.fields.UNIT_F_NAME & ")"
        Catch ex As Exception
            sum = CInt(dao_package.fields.NO_1) * CInt(dao_package.fields.NO_2)
            NO_sum = dao_package.fields.NO_1 & " " & dao_package.fields.UNIT_F_NAME & " x " & dao_package.fields.NO_2 & " " & dao_package.fields.UNIT_S_NAME & "(" & sum & " " & dao_package.fields.UNIT_F_NAME & ")"
        End Try
        'sum = sum * CInt(txt_quantity_produced.Text) vbcrlf
        'NO_sum = dao_package.fields.NO_1 & " " & dao_package.fields.UNIT_F_NAME & " x " & dao_package.fields.NO_2 & " " & dao_package.fields.UNIT_S_NAME & " = " & sum & " " & dao_package.fields.UNIT_F_NAME
        'NO_sum = dao_package.fields.NO_1 & " " & dao_package.fields.UNIT_F_NAME & "x " & dao_package.fields.NO_2 & " " & dao_package.fields.UNIT_S_NAME & "(" & sum & " " & dao_package.fields.UNIT_F_NAME & ")"
        Dim dao As New DAO_TABEAN_HERB.TB_DRSAMP_PACKAGE_SIZE
        dao.fields.PACKAGE_FULL = NO_sum
        dao.fields.SUM_PACKAGE_UNIT = sum
        dao.fields.FK_IDA_EX = _IDA_EX
        dao.fields.UNIT_PACKAGE = dao_package.fields.UNIT_F_NAME
        dao.fields.FK_IDA_PZ = IDA
        dao.fields.ACTIVEFACT = 1
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.CREATE_USER = _CLS.THANM

        dao.fields.PACK_F_ID = DD_PCAK_1.SelectedValue
        dao.fields.PACK_F_NAME = DD_PCAK_1.SelectedItem.Text
        dao.fields.NO_1 = NO_1.Text
        dao.fields.UNIT_F_ID = DD_UNIT_1.SelectedValue
        dao.fields.UNIT_F_NAME = DD_UNIT_1.SelectedItem.Text

        dao.fields.PACK_S_ID = DD_PCAK_2.SelectedValue
        dao.fields.PACK_S_NAME = DD_PCAK_2.SelectedItem.Text
        dao.fields.NO_2 = NO_2.Text
        dao.fields.UNIT_S_ID = DD_UNIT_2.SelectedValue
        dao.fields.UNIT_S_NAME = DD_UNIT_2.SelectedItem.Text

        Try
            dao.fields.PACK_T_ID = DD_PCAK_3.SelectedValue
            dao.fields.PACK_T_NAME = DD_PCAK_3.SelectedItem.Text
            dao.fields.NO_3 = NO_3.Text
            dao.fields.UNIT_T_ID = DD_UNIT_3.SelectedValue
            dao.fields.UNIT_T_NAME = DD_UNIT_3.SelectedItem.Text
        Catch ex As Exception
            dao.fields.PACK_T_ID = 0
            dao.fields.PACK_T_NAME = ""
            dao.fields.NO_3 = ""
            dao.fields.UNIT_T_ID = 0
            dao.fields.UNIT_T_NAME = ""
        End Try

        dao.insert()
    End Sub
    Private Sub bind_package_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_DRSAMP_PACKAGE_SIZE
        dao_size.GetdatabyID_FK_IDA_EX2(_IDA_EX)
        RadGrid1.DataSource = dao_size.datas
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        bind_package_size()
    End Sub
    'Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
    '    sum()

    '    Dim dao_package As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EX_SIZE_PACK
    '    Dim dao As New DAO_DRUG.ClsDBdrsamp
    '    dao.GetDataby_IDA(_IDA_EX)
    '    dao_package.GetdatabyID_FK_IDA_EX_AND_UNIT(_IDA_EX, ddl_package_unit.SelectedValue)
    '    txt_packing_size.Text = dao_package.fields.PACK_F_NAME & " " & dao_package.fields.NO_1 & " " & dao_package.fields.UNIT_F_NAME & " x " & dao_package.fields.PACK_S_NAME & " " & dao_package.fields.NO_2 & " " & dao_package.fields.UNIT_S_NAME & " จำนวน " & txt_quantity_produced.Text & " " & dao_package.fields.UNIT_S_NAME & " " & txt_sum_unit.Text
    'End Sub
End Class
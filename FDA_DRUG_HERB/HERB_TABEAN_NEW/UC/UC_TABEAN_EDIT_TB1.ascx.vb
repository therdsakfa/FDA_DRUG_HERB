Imports System.Globalization
Imports Telerik.Web.UI

Public Class UC_TABEAN_EDIT_TB1
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA_DQ As String = ""
    Private _PROCESS_ID_DQ As String = ""
    Private TR_ID_DQ As String = ""

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
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _IDA_DQ = Request.QueryString("IDA_DQ")
        _PROCESS_ID_DQ = Request.QueryString("PROCESS_ID_DQ")
        TR_ID_DQ = Request.QueryString("TR_ID")

    End Sub

    Shared PLACE_IDA As Integer = 0
    Shared PLACE_NAME As String = ""
    Shared PLACE_ADDRESS As String = ""
    Shared IDA_ADDRESS As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            bind_data()
            bind_rg()
            'bind_dd_age_unit()
            bind_dd_stype()
            bind_dd_syndrome()
            bind_dd_eatting()
            bind_dd_eatting_condition()
            bind_dd_warning()
            bind_dd_manufac()
            bind_dd_storage()
            bind_dd_pack_1()
            bind_dd_pack_2()
            bind_dd_pack_3()
            bind_dd_unit_1()
            bind_dd_unit_2()
            bind_dd_unit_3()

            UC_ATTACH1.NAME = "เอกสารแนบ สูตรตำรับ"
            UC_ATTACH1.BindData("สูตรตำรับ", 1, "pdf", "0", "6")
            UC_ATTACH2.NAME = "เอกสารแนบ กรรมวิธีการผลิต"
            UC_ATTACH2.BindData("กรรมวิธีการผลิต", 1, "pdf", "0", "8")

            Try
                DD_CATEGORY_ID.SelectedValue = _PROCESS_ID_LCN
            Catch ex As Exception

            End Try

            If Request.QueryString("staff") = 1 Then
                SALE_CHANNEL_SET.Visible = True
                STAFF_KEY_SET.Visible = True
                STAFF_HIDE_SET.Visible = False
            Else
                SALE_CHANNEL_SET.Visible = False
                STAFF_KEY_SET.Visible = False
                STAFF_HIDE_SET.Visible = True
            End If

            If _PROCESS_ID_LCN = 121 Then
                foreign.Visible = True
            Else
                foreign.Visible = False
            End If

            If _PROCESS_ID_DQ = 20901 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20902 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20903 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20904 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            Else
                DD_CATEGORY_OUT_ID.Visible = False
                lab_category_out_id.Visible = False
            End If

        End If
    End Sub

    Public Sub bind_data()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        Dim thanm As String = dao_lcn.fields.thanm
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        NAME_TB.Text = _CLS.THANM
        NAME_PLACE_TB.Text = locationaddress
    End Sub

    Public Sub bind_dd_warning()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_WARNING()

        DD_WARNING.DataSource = dt
        DD_WARNING.DataBind()
        DD_WARNING.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_manufac()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_MENUFACTRUE()

        DD_MANUFAC_ID.DataSource = dt
        DD_MANUFAC_ID.DataBind()
        DD_MANUFAC_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_storage()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STORAGE_JJ()

        DD_STORAGE_ID.DataSource = dt
        DD_STORAGE_ID.DataBind()
        DD_STORAGE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_warning_sub(ByVal fk_ida As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_WARNING_SUB(fk_ida)

        DD_WARNING_SUB.DataSource = dt
        DD_WARNING_SUB.DataBind()
        DD_WARNING_SUB.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    'Public Sub bind_dd_age_unit()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_PRODUCT_AGE_JJ()

    '    DD_PRO_AGE.DataSource = dt
    '    DD_PRO_AGE.DataBind()
    '    DD_PRO_AGE.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    Public Sub bind_dd_stype()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STYPE_JJ()

        DD_STYPE_ID.DataSource = dt
        DD_STYPE_ID.DataBind()
        DD_STYPE_ID.Items.Insert(0, "-- กรุณาเลือก --")

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

    Public Sub bind_dd_syndrome()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ()

        DD_SYNDROME_ID.DataSource = dt
        DD_SYNDROME_ID.DataBind()
        DD_SYNDROME_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_eatting()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_JJ()

        DD_EATTING_ID.DataSource = dt
        DD_EATTING_ID.DataBind()
        DD_EATTING_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_eatting_condition()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_CONDITION()

        DD_EATING_CONDITION_ID.DataSource = dt
        DD_EATING_CONDITION_ID.DataBind()
        DD_EATING_CONDITION_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_frgn()
    End Sub

    Sub Search_frgn()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_syspdcfrgn_SEARCH(txt_search.Text)

        RadGrid2.DataSource = dt
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        If txt_search.Text <> "" Then
            Search_frgn()
        End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim frgncd As Integer = 0
            Dim PLACE_NAME_THAI As String = ""
            Dim PLACE_NAME_ENG As String = ""

            PLACE_IDA = item("IDA").Text
            PLACE_NAME_THAI = item("thafrgnnm").Text
            PLACE_NAME_ENG = item("engfrgnnm").Text

            PLACE_NAME = PLACE_NAME_ENG & " " & PLACE_NAME_THAI
            txt_search.Text = PLACE_NAME
            txt_search_ida.Text = PLACE_IDA

            Try
                frgncd = item("frgncd").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dt As New DataTable
                Dim bao As New BAO_SHOW
                dt = bao.SP_drfrgnaddr_BY_frgncd(frgncd)
                HiddenField1.Value = frgncd
                RadGrid3.DataSource = dt

                RadGrid3.Rebind()

            End If

        End If
    End Sub

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource

    End Sub

    Private Sub RadGrid3_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid3.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "sel" Then
                IDA_ADDRESS = item("IDA").Text
                PLACE_ADDRESS = item("fulladdr2").Text

                txt_address.Text = PLACE_ADDRESS
                txt_address_ida.Text = IDA_ADDRESS
            End If
        End If
    End Sub
    Public Sub bind_rg()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        Dim thanm As String = dao_lcn.fields.thanm
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB

        dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        Try
            DD_TYPE_NAME.SelectedValue = dao.fields.TYPE_ID
        Catch ex As Exception

        End Try
        Try
            DD_TYPE_SUB_ID.SelectedValue = dao.fields.TYPE_SUB_ID
        Catch ex As Exception

        End Try
        Try
            DD_CATEGORY_ID.SelectedValue = CATEGORY_ID
        Catch ex As Exception

        End Try
        NAME_THAI.Text = dao.fields.NAME_THAI
        NAME_ENG.Text = dao.fields.NAME_ENG
        NAME_OTHER.Text = dao.fields.NAME_OTHER
        If dao.fields.STYPE_ID IsNot Nothing Then
            DD_STYPE_ID.SelectedValue = dao.fields.STYPE_ID
        End If

        NATURE.Text = dao.fields.NATURE
        'PRODUCT_PROCESS.Text = dao.fields.PRODUCT_PROCESS
        'DD_MANUFAC_ID.SelectedValue = dao.fields.MANUFAC_ID

        Try
            'WEIGHT_TABLE_CAP.Text = dao.fields.WEIGHT_TABLE_CAP
            'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = dao.fields.WEIGHT_TABLE_CAP_UNIT_ID
            SIZE_PACK.Text = dao.fields.SIZE_PACK
        Catch ex As Exception

        End Try

        Try
            'DD_PRO_AGE.SelectedValue = 1
        Catch ex As Exception

        End Try
        Try
            DD_SYNDROME_ID.SelectedValue = dao.fields.SYNDROME_ID
        Catch ex As Exception

        End Try

        PROPERTIES.Text = dao.fields.PROPERTIES
        SIZE_USE.Text = dao.fields.SIZE_USE
        HOW_USE.Text = dao.fields.HOW_USE
        Try
            DD_EATTING_ID.SelectedValue = dao.fields.EATTING_ID
        Catch ex As Exception

        End Try
        If dao.fields.EATING_CONDITION_ID = 1 Then
            EATING_CONDITION_NAME.Text = dao.fields.EATING_CONDITION_NAME
            R_EATING_CONDITION_TEXT.Visible = False
        End If
        Try
            DD_STORAGE_ID.SelectedValue = dao.fields.STORAGE_ID
        Catch ex As Exception

        End Try


        'TREATMENT.Text = dao.fields.TREATMENT
        If dao.fields.TREATMENT_AGE = 3 Then
            TREATMENT_AGE_MONTH_SUB.Enabled = False
        Else
            TREATMENT_AGE_MONTH_SUB.Enabled = True
        End If

        If dao.fields.TREATMENT_AGE IsNot Nothing Then
            TREATMENT_AGE_YEAR.SelectedValue = dao.fields.TREATMENT_AGE
        End If
        If dao.fields.CONTRAINDICATION_ID IsNot Nothing Then
            R_CONTRAINDICATION.SelectedValue = dao.fields.CONTRAINDICATION_ID
        End If
        If dao.fields.CONTRAINDICATION_ID = 1 Then
            CONTRAINDICATION_NAME.Text = dao.fields.CONTRAINDICATION_NAME
            R_CONTRAINDICATION_TEXT.Visible = True
        End If
        If dao.fields.WARNING_ID IsNot Nothing Then
            R_WARNING.SelectedValue = dao.fields.WARNING_ID
        End If
        If dao.fields.WARNING_ID = 1 Then
            WARNING_NAME.Text = dao.fields.WARNING_NAME
            R_WARNING_TEXT.Visible = True
        End If
        If dao.fields.CAUTION_ID IsNot Nothing Then
            R_CAUTION.SelectedValue = dao.fields.CAUTION_ID
        End If
        If dao.fields.CAUTION_ID = 1 Then
            CAUTION_NAME.Text = dao.fields.CAUTION_NAME
            R_CAUTION_TEXT.Visible = True
        End If
        If dao.fields.ADV_REACTIVETION_ID IsNot Nothing Then
            R_ADV_REACTIVETION.SelectedValue = dao.fields.ADV_REACTIVETION_ID
        End If
        If dao.fields.ADV_REACTIVETION_ID = 1 Then
            ADV_REACTIVETION_NAME.Text = dao.fields.ADV_REACTIVETION_NAME
            R_ADV_REACTIVETION_TEXT.Visible = True
        End If
        If dao.fields.SALE_CHANNEL_ID IsNot Nothing Then
            DD_SALE_CHANNEL.SelectedValue = dao.fields.SALE_CHANNEL_ID
        End If
        NOTE.Text = dao.fields.NOTE

    End Sub
    'Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

    '    'Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
    '    'dao_lcn.GetDataby_IDA(_IDA_LCN)
    '    'Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
    '    'dao_deeqt.GetDataby_IDA(_IDA_DQ)
    '    'Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
    '    'dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

    '    'If dao_tabean.fields.IDA <> 0 Then
    '    '    update_data()
    '    '    Response.Redirect("../HERB_TABEAN_STAFF_NEW/FRM_HERB_TABEAN_STAFF_TABEAN.aspx?TR_ID_LCN=" & dao_lcn.fields.TR_ID & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & dao_lcn.fields.IDA & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID & "&IDA_DQ=" & dao_deeqt.fields.IDA & "&PROCESS_ID_DQ=" & dao_deeqt.fields.PROCESS_ID & "&staff=" & "1")
    '    'Else
    '    '    save_data()
    '    'End If

    '    'Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
    '    'dao_deeqt.GetDataby_IDA(_IDA_DQ)

    '    'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
    '    'dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

    '    'dao_deeqt.fields.STATUS_ID = 5
    '    'dao_deeqt.update()
    '    'dao.fields.STATUS_ID = 5
    '    'dao.Update()

    '    ''Dim bao_tran As New BAO_TRANSECTION
    '    ''bao_tran.insert_transection_jj(_PROCESS_ID_DQ, dao.fields.IDA, dao.fields.STATUS_ID)

    '    'Run_Pdf_Tabean_Herb_5()
    '    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    '    ''Response.Redirect(Request.Url.AbsoluteUri)
    '    'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _DDHERB & "&IDA=" & _IDA)
    'End Sub
    Public Sub Run_Pdf_Tabean_Herb_5()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA_DQ, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_PROCESS_ID_DQ, dao_deeqt.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _PROCESS_ID_DQ, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_DQ, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _PROCESS_ID_DQ, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_DQ, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID_DQ, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Sub update_data()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Dim lcnno_auto As String = dao_lcn.fields.lcnno
        Dim lcnno_auto_sub As String = Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)

        'Dim locnnodisplay As String = dao_lcn.fields.lcntpcd & " " & dao_lcn.fields.pvnabbr & " " & lcnno_auto_sub
        Dim locnnodisplay As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim PVNCD As Integer = dao_lcn.fields.pvncd
        Dim PVNABBR As String = dao_lcn.fields.pvnabbr
        Dim thanm As String = dao_lcn.fields.thanm
        Dim lcnsid As String = dao_lcn.fields.lcnsid
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace



        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        TR_ID = bao_tran.insert_transection(_PROCESS_ID_DQ)

        dao_deeqt.fields.FK_LCN_IDA = _IDA_LCN
        dao_deeqt.fields.TR_ID = TR_ID
        dao_deeqt.fields.lcnsid = lcnsid
        dao_deeqt.fields.pvncd = PVNCD
        dao_deeqt.fields.pvnabbr = PVNABBR
        dao_deeqt.fields.PROCESS_ID = _PROCESS_ID_DQ

        dao_deeqt.fields.thadrgnm = NAME_THAI.Text
        dao_deeqt.fields.engdrgnm = NAME_ENG.Text

        dao_deeqt.fields.STATUS_ID = 1
        dao_deeqt.fields.TYPE_TBN = 1
        dao_deeqt.fields.IDENTIFY = _CLS.CITIZEN_ID
        dao_deeqt.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_deeqt.fields.DATE_YEAR = con_year(Date.Now.Year)
        dao_deeqt.fields.CREATE_DATE = Date.Now
        dao_deeqt.fields.CREATE_BY = _CLS.THANM
        If Request.QueryString("staff") = 1 Then
            dao_deeqt.fields.INOFFICE_STAFF_ID = 1
            dao_deeqt.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
        End If

        dao_deeqt.update()
        'Or DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = "-- กรุณาเลือก --"  Or DD_EATING_CONDITION_ID.SelectedValue = "-- กรุณาเลือก --"  'Or DD_STORAGE_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_PRO_AGE.SelectedValue = "-- กรุณาเลือก --"
        If DD_TYPE_NAME.SelectedValue = "-- กรุณาเลือก --" Or DD_TYPE_SUB_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_CATEGORY_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_SYNDROME_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_EATTING_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or R_CONTRAINDICATION.SelectedValue = "" Or R_CAUTION.SelectedValue = "" Or R_ADV_REACTIVETION.SelectedValue = "" _
            Or DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --" Or R_WARNING.SelectedValue = "" Then

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        ElseIf R_WARNING.SelectedValue = 1 And DD_WARNING.SelectedValue = "-- กรุณาเลือก --" And DD_WARNING_SUB.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน คำเตือน');", True)
        Else

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

            dao.fields.IDA_LCN = _IDA_LCN
            If _IDA_DQ <> "" Then
                dao.fields.FK_IDA_DQ = _IDA_DQ
            Else
                dao.fields.FK_IDA_DQ = dao_deeqt.fields.IDA
            End If
            dao.fields.LCN_ID = _IDA_LCN
            dao.fields.LCNNO = locnnodisplay
            dao.fields.NAME_JJ = _CLS.THANM
            dao.fields.NAME_PLACE_JJ = locationaddress
            dao.fields.LCN_NAME = thanm
            dao.fields.LCN_THANAMEPLACE = thanameplace
            dao.fields.TR_ID = TR_ID

            Try
                dao.fields.FOREIGN_NAME_ID = txt_search_ida.Text
                dao.fields.FOREIGN_NAME = txt_search.Text
                dao.fields.FOREIGN_NAME_PLACE_ID = txt_address_ida.Text
                dao.fields.FOREIGN_NAME_PLACE = txt_address.Text
            Catch ex As Exception

            End Try

            dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
            dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text
            dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
            dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
            dao.fields.CATEGORY_ID = DD_CATEGORY_ID.SelectedValue
            dao.fields.CATEGORY_NAME = DD_CATEGORY_ID.SelectedItem.Text
            Try
                dao.fields.CATEGORY_OUT_ID = DD_CATEGORY_OUT_ID.SelectedValue
                dao.fields.CATEGORY_OUT_NAME = DD_CATEGORY_OUT_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.fields.NAME_THAI = NAME_THAI.Text
            dao.fields.NAME_ENG = NAME_ENG.Text
            dao.fields.NAME_OTHER = NAME_OTHER.Text

            dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
            dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text

            dao.fields.SIZE_PACK = SIZE_PACK.Text
            dao.fields.PRODUCT_JJ = _PROCESS_ID_DQ
            dao.fields.NATURE = NATURE.Text
            'dao.fields.PRODUCT_PROCESS = PRODUCT_PROCESS.Text
            'dao.fields.MANUFAC_ID = DD_MANUFAC_ID.SelectedValue
            'dao.fields.MANUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text
            'dao.fields.WEIGHT_TABLE_CAP = WEIGHT_TABLE_CAP.Text

            'dao.fields.WEIGHT_TABLE_CAP_UNIT_ID = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue
            'dao.fields.WEIGHT_TABLE_CAP_UNIT_NAME = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text
            Try
                dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
                dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
            Catch ex As Exception

            End Try


            dao.fields.PROPERTIES = PROPERTIES.Text
            dao.fields.SIZE_USE = SIZE_USE.Text
            dao.fields.HOW_USE = HOW_USE.Text

            dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
            dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
            If DD_EATTING_ID.SelectedValue = 9 Then
                dao.fields.EATTING_NAME_DETAIL = EATTING_TEXT.Text
                R_EATTING_TEXT.Visible = True
            Else
                dao.fields.EATTING_NAME_DETAIL = "ไม่มี"
            End If
            'dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
            'If R_EATING_CONDITION.SelectedValue = 1 Then
            '    dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
            '    R_EATING_CONDITION_TEXT.Visible = True
            'End If

            Try
                dao.fields.EATING_CONDITION_ID = DD_EATING_CONDITION_ID.SelectedValue
                dao.fields.EATING_CONDITION_NAME = DD_EATING_CONDITION_ID.SelectedItem.Text
                If DD_EATING_CONDITION_ID.SelectedValue = 14 Then
                    dao.fields.EATING_CONDITION_NAME_DETAIL = EATING_CONDITION_NAME.Text
                    R_EATING_CONDITION_TEXT.Visible = False
                Else
                    dao.fields.EATING_CONDITION_NAME_DETAIL = "ไม่มี"
                End If
            Catch ex As Exception

            End Try

            dao.fields.STORAGE_ID = DD_STORAGE_ID.SelectedValue
            dao.fields.STORAGE_NAME = DD_STORAGE_ID.SelectedItem.Text
            'dao.fields.TREATMENT = TREATMENT.Text
            'dao.fields.TREATMENT_AGE = TREATMENT_AGE.Text
            Try
                dao.fields.TREATMENT_AGE = TREATMENT_AGE_YEAR.SelectedValue
                dao.fields.TREATMENT_AGE_MONTH = TREATMENT_AGE_MONTH_SUB.SelectedValue

                'dao.fields.TREATMENT_AGE_ID = DD_PRO_AGE.SelectedValue
                'dao.fields.TREATMENT_AGE_NAME = DD_PRO_AGE.SelectedItem.Text
            Catch ex As Exception
                dao.fields.TREATMENT_AGE = 0
                dao.fields.TREATMENT_AGE_MONTH = TREATMENT_AGE_MONTH_SUB.SelectedValue
            End Try

            dao.fields.CONTRAINDICATION_ID = R_CONTRAINDICATION.SelectedValue
            If R_CONTRAINDICATION.SelectedValue = 1 Then
                dao.fields.CONTRAINDICATION_NAME = CONTRAINDICATION_NAME.Text
                R_CONTRAINDICATION_TEXT.Visible = True
            Else
                dao.fields.CONTRAINDICATION_NAME = "ไม่มี"
            End If

            dao.fields.WARNING_TYPE_ID = R_WARNING.SelectedValue
            If R_WARNING.SelectedValue = 1 Then
                dao.fields.WARNING_TYPE_NAME = "มี"
                DD_WARNING.Visible = True

                dao.fields.WARNING_ID = DD_WARNING.SelectedValue

                If DD_WARNING.SelectedValue = 1 Then
                    dao.fields.WARNING_SUB_ID = DD_WARNING_SUB.SelectedValue
                    dao.fields.WARNING_SUB_NAME = DD_WARNING_SUB.SelectedItem.Text
                    R_WARNING_TEXT.Visible = False
                Else
                    dao.fields.WARNING_NAME = WARNING_NAME.Text
                    dao.fields.WARNING_SUB_NAME = WARNING_NAME.Text
                    R_WARNING_TEXT.Visible = True
                End If

            Else
                dao.fields.WARNING_SUB_NAME = "ไม่มี"
                'dao.fields.WARNING_TYPE_NAME = "ไม่มี"
                DD_WARNING.Visible = False
            End If

            dao.fields.CAUTION_ID = R_CAUTION.SelectedValue
            If R_CAUTION.SelectedValue = 1 Then
                dao.fields.CAUTION_NAME = CAUTION_NAME.Text
                R_CAUTION_TEXT.Visible = True
            Else
                dao.fields.CAUTION_NAME = "ไม่มี"
            End If

            dao.fields.ADV_REACTIVETION_ID = R_ADV_REACTIVETION.SelectedValue
            If R_ADV_REACTIVETION.SelectedValue = 1 Then
                dao.fields.ADV_REACTIVETION_NAME = ADV_REACTIVETION_NAME.Text
                R_ADV_REACTIVETION_TEXT.Visible = True
            Else
                dao.fields.ADV_REACTIVETION_NAME = "ไม่มี"
            End If

            dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
            dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text

            dao.fields.NOTE = NOTE.Text

            dao.fields.STATUS_ID = 1
            dao.fields.ACTIVEFACT = 1
            dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_BY = _CLS.THANM

            'dao.fields.MENU_GROUP = _MENU_GROUP
            Try
                dao.fields.TR_ID_LCN = _TR_ID_LCN
            Catch ex As Exception

            End Try

            dao.fields.DATE_YEAR = con_year(Date.Now().Year())

            dao.Update()

            If UC_ATTACH1.CHK_TBN = False Or UC_ATTACH2.CHK_TBN = False Then
                alert_nature("กรุณาแนบไฟล์ เอกสารแนบไฟล์ ชื่อสมุนไพร/สารกัด/สารช่วย และ กรรมวิธีการผลิต")
            ElseIf UC_ATTACH1.CHK_TBN = False And UC_ATTACH2.CHK_TBN = False Then
                alert_nature("กรุณาแนบไฟล์ เอกสารแนบไฟล์ ชื่อสมุนไพร/สารกัด/สารช่วย และ กรรมวิธีการผลิต")
            Else
                UC_ATTACH1.insert_TBN(TR_ID, _PROCESS_ID_DQ, dao_deeqt.fields.IDA, 6)
                UC_ATTACH2.insert_TBN(TR_ID, _PROCESS_ID_DQ, dao_deeqt.fields.IDA, 8)
                'chk_file1.Text = UC_ATTACH1.NAME
                'chk_file2.Text = UC_ATTACH2.NAME
                alert_summit("กรุณาอัพโหลดเอกสารแนบ", dao_deeqt.fields.IDA)
            End If

        End If
    End Sub
    Sub save_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Dim lcnno_auto As String = dao_lcn.fields.lcnno
        Dim lcnno_auto_sub As String = Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)

        'Dim locnnodisplay As String = dao_lcn.fields.lcntpcd & " " & dao_lcn.fields.pvnabbr & " " & lcnno_auto_sub
        Dim locnnodisplay As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim PVNCD As Integer = dao_lcn.fields.pvncd
        Dim PVNABBR As String = dao_lcn.fields.pvnabbr
        Dim thanm As String = dao_lcn.fields.thanm
        Dim lcnsid As String = dao_lcn.fields.lcnsid
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace



        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        TR_ID = bao_tran.insert_transection(_PROCESS_ID_DQ)

        dao_deeqt.fields.FK_LCN_IDA = _IDA_LCN
        dao_deeqt.fields.TR_ID = TR_ID
        dao_deeqt.fields.lcnsid = lcnsid
        dao_deeqt.fields.pvncd = PVNCD
        dao_deeqt.fields.pvnabbr = PVNABBR
        dao_deeqt.fields.PROCESS_ID = _PROCESS_ID_DQ

        dao_deeqt.fields.thadrgnm = NAME_THAI.Text
        dao_deeqt.fields.engdrgnm = NAME_ENG.Text

        dao_deeqt.fields.STATUS_ID = 1
        dao_deeqt.fields.TYPE_TBN = 1
        dao_deeqt.fields.IDENTIFY = _CLS.CITIZEN_ID
        dao_deeqt.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_deeqt.fields.DATE_YEAR = con_year(Date.Now.Year)
        dao_deeqt.fields.CREATE_DATE = Date.Now
        dao_deeqt.fields.CREATE_BY = _CLS.THANM
        If Request.QueryString("staff") = 1 Then
            dao_deeqt.fields.INOFFICE_STAFF_ID = 1
            dao_deeqt.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
        End If

        dao_deeqt.update()
        'Or DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = "-- กรุณาเลือก --"  Or DD_EATING_CONDITION_ID.SelectedValue = "-- กรุณาเลือก --"  'Or DD_STORAGE_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_PRO_AGE.SelectedValue = "-- กรุณาเลือก --"
        If DD_TYPE_NAME.SelectedValue = "-- กรุณาเลือก --" Or DD_TYPE_SUB_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_CATEGORY_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_SYNDROME_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_EATTING_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or R_CONTRAINDICATION.SelectedValue = "" Or R_CAUTION.SelectedValue = "" Or R_ADV_REACTIVETION.SelectedValue = "" _
            Or DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --" Or R_WARNING.SelectedValue = "" Then

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        ElseIf R_WARNING.SelectedValue = 1 And DD_WARNING.SelectedValue = "-- กรุณาเลือก --" And DD_WARNING_SUB.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน คำเตือน');", True)
        Else

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB

            dao.fields.IDA_LCN = _IDA_LCN
            If _IDA_DQ <> "" Then
                dao.fields.FK_IDA_DQ = _IDA_DQ
            Else
                dao.fields.FK_IDA_DQ = dao_deeqt.fields.IDA
            End If
            dao.fields.LCN_ID = _IDA_LCN
            dao.fields.LCNNO = locnnodisplay
            dao.fields.NAME_JJ = _CLS.THANM
            dao.fields.NAME_PLACE_JJ = locationaddress
            dao.fields.LCN_NAME = thanm
            dao.fields.LCN_THANAMEPLACE = thanameplace
            dao.fields.TR_ID = TR_ID

            Try
                dao.fields.FOREIGN_NAME_ID = txt_search_ida.Text
                dao.fields.FOREIGN_NAME = txt_search.Text
                dao.fields.FOREIGN_NAME_PLACE_ID = txt_address_ida.Text
                dao.fields.FOREIGN_NAME_PLACE = txt_address.Text
            Catch ex As Exception

            End Try

            dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
            dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text
            dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
            dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
            dao.fields.CATEGORY_ID = DD_CATEGORY_ID.SelectedValue
            dao.fields.CATEGORY_NAME = DD_CATEGORY_ID.SelectedItem.Text
            Try
                dao.fields.CATEGORY_OUT_ID = DD_CATEGORY_OUT_ID.SelectedValue
                dao.fields.CATEGORY_OUT_NAME = DD_CATEGORY_OUT_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.fields.NAME_THAI = NAME_THAI.Text
            dao.fields.NAME_ENG = NAME_ENG.Text
            dao.fields.NAME_OTHER = NAME_OTHER.Text

            dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
            dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text

            dao.fields.SIZE_PACK = SIZE_PACK.Text
            dao.fields.PRODUCT_JJ = _PROCESS_ID_DQ
            dao.fields.NATURE = NATURE.Text
            'dao.fields.PRODUCT_PROCESS = PRODUCT_PROCESS.Text
            'dao.fields.MANUFAC_ID = DD_MANUFAC_ID.SelectedValue
            'dao.fields.MANUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text
            'dao.fields.WEIGHT_TABLE_CAP = WEIGHT_TABLE_CAP.Text

            'dao.fields.WEIGHT_TABLE_CAP_UNIT_ID = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue
            'dao.fields.WEIGHT_TABLE_CAP_UNIT_NAME = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text
            Try
                dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
                dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
            Catch ex As Exception

            End Try


            dao.fields.PROPERTIES = PROPERTIES.Text
            dao.fields.SIZE_USE = SIZE_USE.Text
            dao.fields.HOW_USE = HOW_USE.Text

            dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
            dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
            If DD_EATTING_ID.SelectedValue = 9 Then
                dao.fields.EATTING_NAME_DETAIL = EATTING_TEXT.Text
                R_EATTING_TEXT.Visible = True
            Else
                dao.fields.EATTING_NAME_DETAIL = "ไม่มี"
            End If
            'dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
            'If R_EATING_CONDITION.SelectedValue = 1 Then
            '    dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
            '    R_EATING_CONDITION_TEXT.Visible = True
            'End If

            Try
                dao.fields.EATING_CONDITION_ID = DD_EATING_CONDITION_ID.SelectedValue
                dao.fields.EATING_CONDITION_NAME = DD_EATING_CONDITION_ID.SelectedItem.Text
                If DD_EATING_CONDITION_ID.SelectedValue = 14 Then
                    dao.fields.EATING_CONDITION_NAME_DETAIL = EATING_CONDITION_NAME.Text
                    R_EATING_CONDITION_TEXT.Visible = False
                Else
                    dao.fields.EATING_CONDITION_NAME_DETAIL = "ไม่มี"
                End If
            Catch ex As Exception

            End Try

            dao.fields.STORAGE_ID = DD_STORAGE_ID.SelectedValue
            dao.fields.STORAGE_NAME = DD_STORAGE_ID.SelectedItem.Text
            'dao.fields.TREATMENT = TREATMENT.Text
            'dao.fields.TREATMENT_AGE = TREATMENT_AGE.Text
            Try
                dao.fields.TREATMENT_AGE = TREATMENT_AGE_YEAR.SelectedValue
                dao.fields.TREATMENT_AGE_MONTH = TREATMENT_AGE_MONTH_SUB.SelectedValue

                'dao.fields.TREATMENT_AGE_ID = DD_PRO_AGE.SelectedValue
                'dao.fields.TREATMENT_AGE_NAME = DD_PRO_AGE.SelectedItem.Text
            Catch ex As Exception
                dao.fields.TREATMENT_AGE = 0
                dao.fields.TREATMENT_AGE_MONTH = TREATMENT_AGE_MONTH_SUB.SelectedValue
            End Try

            dao.fields.CONTRAINDICATION_ID = R_CONTRAINDICATION.SelectedValue
            If R_CONTRAINDICATION.SelectedValue = 1 Then
                dao.fields.CONTRAINDICATION_NAME = CONTRAINDICATION_NAME.Text
                R_CONTRAINDICATION_TEXT.Visible = True
            Else
                dao.fields.CONTRAINDICATION_NAME = "ไม่มี"
            End If

            dao.fields.WARNING_TYPE_ID = R_WARNING.SelectedValue
            If R_WARNING.SelectedValue = 1 Then
                dao.fields.WARNING_TYPE_NAME = "มี"
                DD_WARNING.Visible = True

                dao.fields.WARNING_ID = DD_WARNING.SelectedValue

                If DD_WARNING.SelectedValue = 1 Then
                    dao.fields.WARNING_SUB_ID = DD_WARNING_SUB.SelectedValue
                    dao.fields.WARNING_SUB_NAME = DD_WARNING_SUB.SelectedItem.Text
                    R_WARNING_TEXT.Visible = False
                Else
                    dao.fields.WARNING_NAME = WARNING_NAME.Text
                    dao.fields.WARNING_SUB_NAME = WARNING_NAME.Text
                    R_WARNING_TEXT.Visible = True
                End If

            Else
                dao.fields.WARNING_SUB_NAME = "ไม่มี"
                'dao.fields.WARNING_TYPE_NAME = "ไม่มี"
                DD_WARNING.Visible = False
            End If

            dao.fields.CAUTION_ID = R_CAUTION.SelectedValue
            If R_CAUTION.SelectedValue = 1 Then
                dao.fields.CAUTION_NAME = CAUTION_NAME.Text
                R_CAUTION_TEXT.Visible = True
            Else
                dao.fields.CAUTION_NAME = "ไม่มี"
            End If

            dao.fields.ADV_REACTIVETION_ID = R_ADV_REACTIVETION.SelectedValue
            If R_ADV_REACTIVETION.SelectedValue = 1 Then
                dao.fields.ADV_REACTIVETION_NAME = ADV_REACTIVETION_NAME.Text
                R_ADV_REACTIVETION_TEXT.Visible = True
            Else
                dao.fields.ADV_REACTIVETION_NAME = "ไม่มี"
            End If

            dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
            dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text

            dao.fields.NOTE = NOTE.Text

            dao.fields.STATUS_ID = 1
            dao.fields.ACTIVEFACT = 1
            dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_BY = _CLS.THANM

            dao.fields.MENU_GROUP = _MENU_GROUP
            Try
                dao.fields.TR_ID_LCN = _TR_ID_LCN
            Catch ex As Exception

            End Try

            dao.fields.DATE_YEAR = con_year(Date.Now().Year())

            dao.insert()

            If UC_ATTACH1.CHK_TBN = False Or UC_ATTACH2.CHK_TBN = False Then
                alert_nature("กรุณาแนบไฟล์ เอกสารแนบไฟล์ ชื่อสมุนไพร/สารกัด/สารช่วย และ กรรมวิธีการผลิต")
            ElseIf UC_ATTACH1.CHK_TBN = False And UC_ATTACH2.CHK_TBN = False Then
                alert_nature("กรุณาแนบไฟล์ เอกสารแนบไฟล์ ชื่อสมุนไพร/สารกัด/สารช่วย และ กรรมวิธีการผลิต")
            Else
                UC_ATTACH1.insert_TBN(TR_ID, _PROCESS_ID_DQ, dao_deeqt.fields.IDA, 6)
                UC_ATTACH2.insert_TBN(TR_ID, _PROCESS_ID_DQ, dao_deeqt.fields.IDA, 8)
                'chk_file1.Text = UC_ATTACH1.NAME
                'chk_file2.Text = UC_ATTACH2.NAME
                alert_summit("กรุณาอัพโหลดเอกสารแนบ", dao_deeqt.fields.IDA)
            End If

        End If

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE(7)
        For Each dao_up_mas.fields In dao_up_mas.datas
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
            dao_up.fields.TR_ID = TR_ID
            dao_up.fields.PROCESS_ID = _PROCESS_ID_DQ
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.FK_IDA = _IDA_DQ
            dao_up.fields.TYPE = 7
            dao_up.insert()
        Next
    End Sub
    'Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
    '    Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
    '    dao_lcn.GetDataby_IDA(_IDA_LCN)
    '    Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
    '    dao_deeqt.GetDataby_IDA(_IDA_DQ)
    '    Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
    '    dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
    '    If Request.QueryString("staff") = 1 Then
    '        Response.Redirect("../HERB_TABEAN_STAFF_NEW/FRM_HERB_TABEAN_STAFF_TABEAN.aspx?TR_ID_LCN=" & dao_lcn.fields.TR_ID & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & dao_lcn.fields.IDA & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID & "&IDA_DQ=" & dao_deeqt.fields.IDA & "&PROCESS_ID_DQ=" & dao_deeqt.fields.PROCESS_ID & "&staff=" & "1")
    '    Else
    '        Response.Redirect("FRM_HERB_TABEAN.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ)
    '    End If
    'End Sub
    'Protected Sub R_EATING_CONDITION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles R_EATING_CONDITION.SelectedIndexChanged
    '    If R_EATING_CONDITION.SelectedValue = 1 Then
    '        R_EATING_CONDITION_TEXT.Visible = True
    '    Else
    '        R_EATING_CONDITION_TEXT.Visible = False
    '    End If
    'End Sub
    Protected Sub R_CONTRAINDICATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles R_CONTRAINDICATION.SelectedIndexChanged
        If R_CONTRAINDICATION.SelectedValue = 1 Then
            R_CONTRAINDICATION_TEXT.Visible = True
        Else
            R_CONTRAINDICATION_TEXT.Visible = False
        End If
    End Sub
    Protected Sub R_CAUTION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles R_CAUTION.SelectedIndexChanged
        If R_CAUTION.SelectedValue = 1 Then
            R_CAUTION_TEXT.Visible = True
        Else
            R_CAUTION_TEXT.Visible = False
        End If
    End Sub
    Protected Sub R_WARNING_SelectedIndexChanged(sender As Object, e As EventArgs) Handles R_WARNING.SelectedIndexChanged
        If R_WARNING.SelectedValue = 1 Then
            DD_WARNING.Visible = True
        Else
            DD_WARNING.ClearSelection()
            DD_WARNING_SUB.ClearSelection()
            R_WARNING_TEXT.InnerText = ""

            DD_WARNING.Visible = False
            R_WARNING_TEXT.Visible = False
            DD_WARNING_SUB.Visible = False
        End If
    End Sub
    Protected Sub R_ADV_REACTIVETION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles R_ADV_REACTIVETION.SelectedIndexChanged
        If R_ADV_REACTIVETION.SelectedValue = 1 Then
            R_ADV_REACTIVETION_TEXT.Visible = True
        Else
            R_ADV_REACTIVETION_TEXT.Visible = False
        End If
    End Sub

    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_ADD_DETAIL_UPLOAD_FILE.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Sub alert_nature(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Protected Sub DD_WARNING_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_WARNING.SelectedIndexChanged
        If DD_WARNING.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        ElseIf DD_WARNING.SelectedValue = 1 Then
            bind_dd_warning_sub(DD_WARNING.SelectedValue)
            DD_WARNING_SUB.Visible = True
            R_WARNING_TEXT.Visible = False
        Else
            DD_WARNING_SUB.Visible = False
            R_WARNING_TEXT.Visible = True
        End If

    End Sub

    Protected Sub DD_EATTING_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_EATTING_ID.SelectedIndexChanged
        If DD_EATTING_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        ElseIf DD_EATTING_ID.SelectedValue = 9 Then
            R_EATTING_TEXT.Visible = True
        Else
            R_EATTING_TEXT.Visible = False
        End If
    End Sub

    Protected Sub DD_EATING_CONDITION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_EATING_CONDITION_ID.SelectedIndexChanged
        If DD_EATING_CONDITION_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        ElseIf DD_EATING_CONDITION_ID.SelectedValue = 14 Then
            R_EATING_CONDITION_TEXT.Visible = True
        Else
            R_EATING_CONDITION_TEXT.Visible = False
        End If
    End Sub

    Protected Sub btn_add_muc_add_Click(sender As Object, e As EventArgs) Handles btn_add_muc_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE

        dao.fields.FK_IDA_DQ = _IDA_DQ
        dao.fields.NO_ID = NO_ID.Text
        If DD_MANUFAC_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทกระบวนการ');", True)
        Else
            dao.fields.MENUFAC_ID = DD_MANUFAC_ID.SelectedValue
            dao.fields.MENUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text

            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_USER = _CLS.THANM

            dao.insert()
        End If

        DD_MANUFAC_ID.ClearSelection()
        NO_ID.Text = ""

        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Protected Sub btn_size_pack_Click(sender As Object, e As EventArgs) Handles btn_size_pack.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST

        dao.fields.FK_IDA_DQ = _IDA_DQ

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

        RadGrid4.Rebind()
    End Sub

    Private Sub RadGrid4_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid4.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid4.Rebind()
            End If
        End If
    End Sub

    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
        dao_size.GetdatabyID_FK_IDA_DQ2(_IDA_DQ)

        RadGrid4.DataSource = dao_size.datas

    End Sub

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        bind_size()
    End Sub

    Private Sub bind_manu()
        Dim dao_manu As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
        dao_manu.GetdatabyID_FK_IDA_DQ2(_IDA_DQ)

        RadGrid1.DataSource = dao_manu.datas

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        bind_manu()
    End Sub
    Protected Sub TREATMENT_AGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TREATMENT_AGE_YEAR.SelectedIndexChanged
        If TREATMENT_AGE_YEAR.SelectedValue = "3" Then
            TREATMENT_AGE_MONTH_SUB.ClearSelection()
            TREATMENT_AGE_MONTH_SUB.Enabled = False
        Else
            TREATMENT_AGE_MONTH_SUB.Enabled = True
        End If
    End Sub
End Class
Imports System.Globalization
Imports Telerik.Web.UI

Public Class POPUP_HERB_TABEAN_INFORM_ADD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID As String = ""
    Private _PROCESS_JJ As String = ""
    Private _SID As String = ""
    Private _DD_HERB_NAME_ID As String = ""

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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _PROCESS_JJ = Request.QueryString("PROCESS_JJ")
        _TR_ID = Request.QueryString("TR_ID")
        _SID = Request.QueryString("SID")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")

    End Sub

    Shared PLACE_IDA As Integer = 0
    Shared PLACE_NAME As String = ""
    Shared PLACE_ADDRESS As String = ""
    Shared IDA_ADDRESS As Integer = 0
    'Shared THANM As String = ""

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
            'bind_dd_HERB_PROCESS()
            bind_dd_herb()
            bind_chkbox()
            Bind_Mas_data()
            bind_unit4()
            'UC_officer_che.bind_unit1()
            'UC_officer_che.bind_unit2()
            'UC_officer_che.bind_unit3()
            'UC_officer_che.bind_unit4()
            'UC_officer_che.get_data_drgperunit()
            'UC_officer_che.bind_unit_each()
            'UC_officer_che.bind_lbl()
            '' UC_recipe.bind_ddl_atc()            UC_officer_che.bind_unit_head()
            'UC_officer_che.bind_unit()

            UC_ATTACH1.NAME = "เอกสารแนบ สูตรตำรับ"
            UC_ATTACH1.BindData("สูตรตำรับ", 1, "pdf", "0", "6")
            UC_ATTACH2.NAME = "เอกสารแนบ กรรมวิธีการผลิต"
            UC_ATTACH2.BindData("กรรมวิธีการผลิต", 1, "pdf", "0", "8")

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
            dao.GetdatabyID_IDA(_IDA)
            Try
                If Request.QueryString("staff") = 2 Then
                    SALE_CHANNEL_SET.Visible = True
                    STAFF_KEY_SET.Visible = True
                    STAFF_HIDE_SET.Visible = False
                ElseIf Request.QueryString("staff") = 1 Then
                    'SALE_CHANNEL_SET.Visible = False
                    'STAFF_KEY_SET.Visible = False
                    STAFF_HIDE_SET.Visible = True
                Else
                    SALE_CHANNEL_SET.Visible = False
                    STAFF_KEY_SET.Visible = False
                    STAFF_HIDE_SET.Visible = False
                End If
            Catch ex As Exception

            End Try


            If _PROCESS_ID_LCN = 121 Then
                foreign.Visible = True
            Else
                foreign.Visible = False
            End If

            'If _PROCESS_ID = 20201 Then
            '    'DD_CATEGORY_OUT_ID.Visible = True
            '    lab_category_out_id.Visible = True
            'ElseIf _PROCESS_ID = 20202 Then
            '    'DD_CATEGORY_OUT_ID.Visible = True
            '    lab_category_out_id.Visible = True
            'ElseIf _PROCESS_ID = 20203 Then
            '    'DD_CATEGORY_OUT_ID.Visible = True
            '    lab_category_out_id.Visible = True
            'ElseIf _PROCESS_ID = 20204 Then
            '    'DD_CATEGORY_OUT_ID.Visible = True
            '    lab_category_out_id.Visible = True
            'Else
            '    'DD_CATEGORY_OUT_ID.Visible = False
            '    lab_category_out_id.Visible = False
            'End If

        End If
    End Sub
    Public Sub bind_unit4()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit_cas.DataSource = dt
        ddl_unit_cas.DataTextField = "sunitnmsht"
        ddl_unit_cas.DataValueField = "sunitcd"
        ddl_unit_cas.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit_cas.Items.Insert(0, item)
    End Sub
  Public Sub bind_q()
    Dim item As New ListItem
    item.Text = "--กรุณาเลือก--"
    item.Value = "1"
        ddl_duty_cas.Items.Insert(0, item)
    End Sub
  Protected Sub btn_search_name_cas_Click(sender As Object, e As EventArgs) Handles btn_search_name_cas.Click
    rg_search_iowa.Rebind()
  End Sub
  Private Sub rg_search_iowa_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_search_iowa.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        If txt_search_name_cas.Text <> "" Then
            dt = bao.SP_DRIOWA_SEARCH_RESULT(txt_search_name_cas.Text)
        End If

        rg_search_iowa.DataSource = dt
    End Sub
    Private Sub rg_search_iowa_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_search_iowa.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim name_cas As String = ""
            Dim cas_no As String = ""

            'PLACE_IDA = item("IDA").Text
            name_cas = item("iowanm").Text
            'PLACE_NAME_ENG = item("engfrgnnm").Text

            'PLACE_NAME = PLACE_NAME_ENG.Replace("&nbsp;", "") & " " & PLACE_NAME_THAI.Replace("&nbsp;", "")
            'txt_search.Text = PLACE_NAME
            'txt_search_ida.Text = PLACE_IDA

            If e.CommandName = "sel" Then
                txt_thai_name_cas.Text = name_cas
            End If

        End If
    End Sub
    Public Sub Bind_Mas_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        ' Dim thanm As String = dao_lcn.fields.thanm
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_DETAIL_JJ
        '_PROCESS_JJ = _PROCESS_ID
        If _PROCESS_ID = 20301 Then _PROCESS_JJ = 20301
        If _PROCESS_ID = 20302 Then _PROCESS_JJ = 20302
        If _PROCESS_ID = 20303 Then _PROCESS_JJ = 20303
        If _PROCESS_ID = 20304 Then _PROCESS_JJ = 20304
        dao.GetdatabyID_DD_HERB_NAME_ID(_DD_HERB_NAME_ID, _PROCESS_JJ)

        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try

        Dim THANM As String = dao_lcn.fields.thanm
        Dim name_cus As String = ""
        name_cus = _CLS.THANM_CUSTOMER
        'If name_cus Is Nothing Or name_cus = "" Or name_cus = " " Then
        '    NAME_JJ.Text = THANM
        'Else
        '    NAME_JJ.Text = _CLS.THANM_CUSTOMER
        'End If
        'NAME_JJ.Text = _CLS.THANM

        Dim dao_who As New DAO_WHO.TB_WHO_DALCN
        dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
        If _SID = "2" Then
            THANM = dao_who.fields.THANM_NAME
            'NAME_JJ.Text = THANM
        ElseIf _SID = 1 Then
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            'NAME_JJ.Text = THANM
        End If
        'Dim THANM As String = dao_lcn.fields.thanm
        'If thanm = "" Or thanm Is Nothing Then
        '    thanm = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
        'Else
        '    thanm = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        'End If

        'NAME_PLACE_JJ.Text = locationaddress

        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            tb_location.GetDataby_LCN_IDA(_IDA_LCN)
        Catch ex As Exception

        End Try
        Dim dao_pfx As New DAO_CPN.TB_sysprefix
        Dim BSN_THAIFULLNAME As String = ""
        Try
            dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
            Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
            Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
            Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
            BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

        Catch ex As Exception

        End Try

        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)

        Dim TYPE_PERSON As Integer = dao_cpn.fields.type
        Dim NATION As String = dao_lcn.fields.NATION
        If _SID = 2 Then
            data_show3.Visible = False
        Else
            If TYPE_PERSON = 1 Then
                data_show3.Visible = False
            ElseIf TYPE_PERSON = 99 Then
                data_show3.Visible = True
                txt_agent99.Text = BSN_THAIFULLNAME
            End If
        End If
        Try
            DD_TYPE_NAME.SelectedValue = dao.fields.TYPE_ID
            DD_TYPE_SUB_ID.SelectedValue = dao.fields.TYPE_SUB_ID
            DD_CATEGORY_ID.SelectedValue = CATEGORY_ID
            DD_STYPE_ID.SelectedValue = dao.fields.STYPE_ID
        Catch ex As Exception

        End Try

        NAME_THAI.Text = dao.fields.NAME_THAI
        NAME_ENG.Text = dao.fields.NAME_ENG
        NAME_OTHER.Text = dao.fields.NAME_OTHER
        'RECIPE_NAME.Text = dao.fields.RECIPE_NAME
        Try
            'ACCOUNT_NO.Text = dao.fields.ACCOUNT_NO
            'ARTICLE_NO.Text = dao.fields.ARTICLE_NO
        Catch ex As Exception

        End Try
        'PRODUCT_JJ.Text = dao.fields.PRODUCT_JJ
        NATURE.Text = dao.fields.NATURE
        'PRODUCT_PROCESS.Text = dao.fields.PRODUCT_PROCESS
        'DD_MANUFAC_ID.SelectedValue = dao.fields.MANUFAC_ID

        Try
            'WEIGHT_TABLE_CAP.Text = dao.fields.WEIGHT_TABLE_CAP
            'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = dao.fields.WEIGHT_TABLE_CAP_UNIT_ID
            'SIZE_PACK.Text = dao.fields.SIZE_PACK
        Catch ex As Exception

        End Try

        Try
            'DD_PRO_AGE.SelectedValue = 1
        Catch ex As Exception

        End Try

        'DD_SYNDROME_ID.SelectedValue = dao.fields.SYNDROME_ID
        PROPERTIES.Text = dao.fields.PROPERTIES
        SIZE_USE.Text = dao.fields.SIZE_USE
        'HOW_USE.Text = dao.fields.HOW_USE
        Try
            DD_EATTING_ID.SelectedValue = dao.fields.EATTING_ID
            'R_EATING_CONDITION.SelectedValue = dao.fields.EATING_CONDITION_ID
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
        Try
            TREATMENT_AGE_YEAR.SelectedValue = dao.fields.TREATMENT_AGE
            R_CONTRAINDICATION.SelectedValue = dao.fields.CONTRAINDICATION_ID
        Catch ex As Exception

        End Try
        If dao.fields.CONTRAINDICATION_ID = 1 Then
            CONTRAINDICATION_NAME.Text = dao.fields.CONTRAINDICATION_NAME
            R_CONTRAINDICATION_TEXT.Visible = True
        End If
        Try
            R_WARNING.SelectedValue = dao.fields.WARNING_ID
        Catch ex As Exception

        End Try

        If dao.fields.WARNING_ID = 1 Then
            WARNING_NAME.Text = dao.fields.WARNING_NAME
            R_WARNING_TEXT.Visible = True
        End If
        Try
            R_CAUTION.SelectedValue = dao.fields.CAUTION_ID

        Catch ex As Exception

        End Try
        If dao.fields.CAUTION_ID = 1 Then
            CAUTION_NAME.Text = dao.fields.CAUTION_NAME
            R_CAUTION_TEXT.Visible = True
        End If
        Try
            R_ADV_REACTIVETION.SelectedValue = dao.fields.ADV_REACTIVETION_ID
        Catch ex As Exception

        End Try
        If dao.fields.ADV_REACTIVETION_ID = 1 Then
            ADV_REACTIVETION_NAME.Text = dao.fields.ADV_REACTIVETION_NAME
            R_ADV_REACTIVETION_TEXT.Visible = True
        End If
        Try
            DD_SALE_CHANNEL.SelectedValue = dao.fields.SALE_CHANNEL_ID
        Catch ex As Exception

        End Try
        NOTE.Text = dao.fields.NOTE
    End Sub
    Public Sub bind_data()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        ' Dim thanm As String = dao_lcn.fields.thanm
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try

        Dim THANM As String = dao_lcn.fields.thanm
        Dim dao_who As New DAO_WHO.TB_WHO_DALCN
        dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
        If _SID = "2" Then
            THANM = dao_who.fields.THANM_NAME
        Else
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
        End If

        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            tb_location.GetDataby_LCN_IDA(_IDA_LCN)
        Catch ex As Exception

        End Try
        Dim dao_pfx As New DAO_CPN.TB_sysprefix
        Dim BSN_THAIFULLNAME As String = ""
        Try
            dao_pfx.Getdata_byid(tb_location.fields.BSN_PREFIXTHAICD)
            Dim BSN_PRIFRFIX As String = dao_pfx.fields.thanm
            Dim BSN_THAINAME As String = tb_location.fields.BSN_THAINAME
            Dim BSN_THAILASTNAME As String = tb_location.fields.BSN_THAILASTNAME
            BSN_THAIFULLNAME = BSN_PRIFRFIX & " " & BSN_THAINAME & " " & BSN_THAILASTNAME

        Catch ex As Exception

        End Try

        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)

        Dim dao_cpnWho As New DAO_CPN.clsDBsyslcnsid
        dao_cpnWho.GetDataby_identify(_CLS.CITIZEN_ID_AUTHORIZE)
        Dim TYPE_PERSON_WHO As Integer = dao_cpnWho.fields.type

        Dim TYPE_PERSON As Integer = dao_cpn.fields.type
        Dim NATION As String = dao_lcn.fields.NATION
        If _SID = 2 Then
            If TYPE_PERSON_WHO = 1 Then
                data_show3.Visible = False
            ElseIf TYPE_PERSON_WHO = 99 Then
                data_show3.Visible = True
                '    txt_agent99.Text = BSN_THAIFULLNAME

            End If
        Else
            If TYPE_PERSON = 1 Then
                data_show3.Visible = False
            ElseIf TYPE_PERSON = 99 Then
                data_show3.Visible = True
                txt_agent99.Text = BSN_THAIFULLNAME
                TXT_SEARCH_TN.Text = tb_location.fields.BSN_IDENTIFY

            End If
        End If
        dao_who.GetdatabyID_FK_LCN_IDEN(_IDA_LCN, _CLS.CITIZEN_ID)
        If _SID = "2" Then
            If TYPE_PERSON_WHO = 1 Then
                THANM = _CLS.THANM
                NAME_TB.Text = THANM
            Else
                THANM = dao_who.fields.THANM_NAME
                NAME_TB.Text = THANM
            End If

        Else
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
            NAME_TB.Text = THANM
        End If
        NAME_PLACE_TB.Text = locationaddress
    End Sub

    Public Sub bind_dd_herb()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        If _PROCESS_ID = 20201 Then
            'DD_TYPE_NAME.SelectedValue = 20201
            DD_TYPE_NAME.SelectedValue = 1
            DD_TYPE_SUB_ID.SelectedValue = 1
        ElseIf _PROCESS_ID = 20202 Then
            'DD_TYPE_NAME.SelectedValue = 20102
            DD_TYPE_NAME.SelectedValue = 1
            DD_TYPE_SUB_ID.SelectedValue = 2
        ElseIf _PROCESS_ID = 20203 Then
            'DD_TYPE_NAME.SelectedValue = 20103
            DD_TYPE_NAME.SelectedValue = 1
            DD_TYPE_SUB_ID.SelectedValue = 3
        ElseIf _PROCESS_ID = 20204 Then
            'DD_TYPE_NAME.SelectedValue = 20204
            DD_TYPE_NAME.SelectedValue = 2
            DD_TYPE_SUB_ID.SelectedValue = 4
        End If
    End Sub
    Public Sub bind_chkbox()

        Dim dao_lcn As New DAO_TABEAN_HERB.TB_MAS_NAME_HEAD_TABEAN_JR
        dao_lcn.GetAll()
        'Chk_Head_nm.DataSource = dao_lcn.datas
        'Chk_Head_nm.DataBind()
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

            PLACE_NAME = PLACE_NAME_ENG.Replace("&nbsp;", "") & " " & PLACE_NAME_THAI.Replace("&nbsp;", "")
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
                PLACE_ADDRESS = item("fulladdr4").Text

                txt_address.Text = PLACE_ADDRESS
                txt_address_ida.Text = IDA_ADDRESS
                txt_address.Text.ToUpper()
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

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL

        dao.GetdatabyID_FK_IDA(_IDA)
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

        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try
        If _SID = 2 Then
            Dim citizen_id As String = _CLS.CITIZEN_ID_AUTHORIZE
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Try
                Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
                If TYPE_PERSON = 1 Then
                    thanm = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                ElseIf TYPE_PERSON = 99 Then
                    thanm = _CLS.THANM_CUSTOMER
                    'thanm = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                        thanm = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    Else
                        thanm = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    End If
                End If
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End Try


        Else
            If thanm = "" Or thanm Is Nothing Then
                thanm = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
            Else
                thanm = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
        End If


        NATURE.Text = dao.fields.NATURE
        'PRODUCT_PROCESS.Text = dao.fields.PRODUCT_PROCESS
        'DD_MANUFAC_ID.SelectedValue = dao.fields.MANUFAC_ID

        Try
            'WEIGHT_TABLE_CAP.Text = dao.fields.WEIGHT_TABLE_CAP
            'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = dao.fields.WEIGHT_TABLE_CAP_UNIT_ID
            'SIZE_PACK.Text = dao.fields.SIZE_PACK
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
        NAME_TB.Text = thanm
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
        dao_tabean.GetdatabyID_FK_IDA(_IDA)
        save_data()

    End Sub
    Sub save_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_inform As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao_inform.GetdatabyID_IDA(_IDA)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
        dao_tabean.GetdatabyID_FK_IDA(_IDA)

        Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        DAO_WHO.GetdatabyID_FK_LCN(_IDA_LCN)
        Dim TP_PERSON As Integer = 0
        Try
            TP_PERSON = DAO_WHO.fields.TYPEPERSON
        Catch ex As Exception
            TP_PERSON = 0
        End Try
        'เพิ่มสารช่วย

        Dim lcnno_auto As String = dao_lcn.fields.lcnno
        Dim lcnno_auto_sub As String = Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Dim THANM As String = dao_lcn.fields.thanm
        'Dim dao_who As New DAO_WHO.TB_WHO_DALCN
        DAO_WHO.GetdatabyID_FK_LCN(_IDA_LCN)
        If _SID = "2" Then
            THANM = DAO_WHO.fields.THANM_NAME
        Else
            If THANM = "" Or THANM Is Nothing Then
                THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
            Else
                THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
            End If
        End If
        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            tb_location.GetDataby_LCN_IDA(_IDA_LCN)
        Catch ex As Exception

        End Try
        'Dim locnnodisplay As String = dao_lcn.fields.lcntpcd & " " & dao_lcn.fields.pvnabbr & " " & lcnno_auto_sub
        Dim locnnodisplay As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim PVNCD As Integer = dao_lcn.fields.pvncd
        Dim PVNABBR As String = dao_lcn.fields.pvnabbr
        Dim lcnsid As String = dao_lcn.fields.lcnsid
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        TR_ID = bao_tran.insert_transection(_PROCESS_ID)

        dao_inform.fields.FK_LCN = _IDA_LCN
        dao_inform.fields.TR_ID = TR_ID
        dao_inform.fields.lcnsid = lcnsid
        dao_inform.fields.pvncd = PVNCD
        'dao_inform.fields.pvnabbr = PVNABBR
        dao_inform.fields.PROCESS_ID = _PROCESS_ID

        dao_inform.fields.thadrgnm = NAME_THAI.Text
        dao_inform.fields.engdrgnm = NAME_ENG.Text
        Try
            If _SID = "2" Then
                dao_inform.fields.WHO_ID = 1
                DAO_WHO.fields.FK_IDA = dao_inform.fields.IDA
                DAO_WHO.Update()
            Else
                dao_inform.fields.WHO_ID = 0
            End If
        Catch ex As Exception

        End Try
        dao_inform.fields.STATUS_ID = 1
        'dao_inform.fields.TYPE_TBN = 1
        dao_inform.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao_inform.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_inform.fields.YEAR = con_year(Date.Now.Year)
        dao_inform.fields.CREATE_DATE = Date.Now
        dao_inform.fields.CREATE_BY = _CLS.THANM
        If Request.QueryString("staff") = 1 Then
            dao_inform.fields.INOFFICE_STAFF_ID = 1
            dao_inform.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
        End If
        dao_inform.fields.FK_LCT = dao_lcn.fields.FK_IDA
        dao_inform.fields.LCNNO = dao_lcn.fields.lcnno
        dao_inform.fields.LCNNO_NEW = dao_lcn.fields.LCNNO_DISPLAY_NEW
        dao_inform.fields.lcntpcd = dao_lcn.fields.lcntpcd
        dao_inform.fields.ACTIVEFACT = 1
        dao_inform.fields.YEAR = con_year(Date.Now().Year())
        dao_inform.fields.Date_Year = con_year(Date.Now().Year())
        If dao_inform.fields.IDA = 0 Then dao_inform.insert() Else dao_inform.Update()
        _IDA = dao_inform.fields.IDA
        'Or DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = "-- กรุณาเลือก --"  Or DD_EATING_CONDITION_ID.SelectedValue = "-- กรุณาเลือก --"  'Or DD_STORAGE_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_PRO_AGE.SelectedValue = "-- กรุณาเลือก --" Or DD_SYNDROME_ID.SelectedValue = "-- กรุณาเลือก --"
        If DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" _
              Or DD_TYPE_NAME.SelectedValue = "-- กรุณาเลือก --" Or DD_TYPE_SUB_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_CATEGORY_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_EATTING_ID.SelectedValue = "-- กรุณาเลือก --" Or DDL_RECIPE_NAME.SelectedValue = "-- กรุณาเลือก --" _
            Or R_CONTRAINDICATION.SelectedValue = "" Or R_CAUTION.SelectedValue = "" Or R_ADV_REACTIVETION.SelectedValue = "" _
            Or DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --" Or R_WARNING.SelectedValue = "" Then

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
            'ElseIf R_WARNING.SelectedValue = 1 And DD_WARNING.SelectedValue = "-- กรุณาเลือก --" And DD_WARNING_SUB.SelectedValue = "-- กรุณาเลือก --" Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน คำเตือน');", True)
            'ElseIf Request.QueryString("staff") = 1 And DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --" Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกช่องทางการขาย');", True)
        Else

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL

            dao.fields.IDA_LCN = _IDA_LCN
            If _IDA <> "" Then
                dao.fields.FK_IDA = _IDA
            Else
                dao.fields.FK_IDA = dao_inform.fields.IDA
            End If
            dao.fields.LCN_ID = _IDA_LCN
            dao.fields.LCNNO = locnnodisplay
            dao.fields.NAME_TABEAN = _CLS.THANM
            dao.fields.NAME_PLACE_TABEAN = locationaddress
            ' dao.fields.LCN_NAME = THANM
            dao.fields.LCN_NAME = NAME_TB.Text
            dao.fields.LCN_THANAMEPLACE = thanameplace
            dao.fields.TR_ID = TR_ID
            dao.fields.TYPEPERSON = TP_PERSON

            Try
                dao.fields.FOREIGN_NAME_ID = txt_search_ida.Text
                dao.fields.FOREIGN_NAME = striptags(txt_search.Text)
                dao.fields.FOREIGN_NAME_PLACE_ID = txt_address_ida.Text
                dao.fields.FOREIGN_NAME_PLACE = txt_address.Text.ToUpper()
            Catch ex As Exception

            End Try

            dao.fields.AGENT_99 = txt_agent99.Text
            dao.fields.IDEN_AGENT_99 = TXT_SEARCH_TN.Text
            Try
                dao.fields.PERSON_AGE = txt_person_age.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.NATIONALITY_PERSON_ID = DDL_NATION.SelectedValue
                dao.fields.NATIONALITY_PERSON = DDL_NATION.SelectedItem.Text
                dao.fields.NATIONALITY_PERSON_OTHER = txt_nation_person.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
                dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
                dao.fields.CATEGORY_ID = DD_CATEGORY_ID.SelectedValue
                dao.fields.CATEGORY_NAME = DD_CATEGORY_ID.SelectedItem.Text
                dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
                dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text

            Catch ex As Exception

            End Try

            'Try
            '    dao.fields.CATEGORY_OUT_ID = DD_CATEGORY_OUT_ID.SelectedValue
            '    dao.fields.CATEGORY_OUT_NAME = DD_CATEGORY_OUT_ID.SelectedItem.Text
            'Catch ex As Exception

            'End Try

            Try
                dao.fields.PRODUCER_ID = RBL_CHK_PRODUCER.SelectedValue
                If RBL_CHK_PRODUCER.SelectedValue = 1 Then
                    dao.fields.PRODUCER_NAME = "มี"
                Else
                    dao.fields.PRODUCER_NAME = "ไม่มี"
                End If

            Catch ex As Exception

            End Try

            dao.fields.NAME_THAI = NAME_THAI.Text
            dao.fields.NAME_ENG = NAME_ENG.Text
            dao.fields.NAME_OTHER = NAME_OTHER.Text

            dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
            dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text

            'dao.fields.SIZE_PACK = SIZE_PACK.Text
            dao.fields.PRODUCT_JJ = _PROCESS_ID
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

            Try
                dao.fields.RECIPE_NAME = RECIPE_NAME.Text
                dao.fields.RECIPE_UNIT_ID = DDL_RECIPE_NAME.SelectedValue
                dao.fields.RECIPE_UNIT_NAME = DDL_RECIPE_NAME.SelectedItem.Text
            Catch ex As Exception

            End Try


            dao.fields.PROPERTIES = PROPERTIES.Text
            dao.fields.SIZE_USE = SIZE_USE.Text
            dao.fields.HOW_USE = HOW_USE.Text

            Try
                dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
                dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                If DD_EATTING_ID.SelectedValue = 9 Then
                    'dao.fields.EATTING_NAME_DETAIL = EATTING_TEXT.Text
                    dao.fields.EATTING_NAME_DETAIL = "ไม่มี"
                    R_EATTING_TEXT.Visible = True
                End If
            Catch ex As Exception

            End Try

            'dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
            'If R_EATING_CONDITION.SelectedValue = 1 Then
            '    dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
            '    R_EATING_CONDITION_TEXT.Visible = True
            'End If

            Try
                dao.fields.EATING_CONDITION_ID = DD_EATING_CONDITION_ID.SelectedValue
                dao.fields.EATING_CONDITION_NAME = DD_EATING_CONDITION_ID.SelectedItem.Text
                If DD_EATING_CONDITION_ID.SelectedValue = 14 Then
                    'dao.fields.EATING_CONDITION_NAME_DETAIL = EATING_CONDITION_NAME.Text
                    dao.fields.EATING_CONDITION_NAME_DETAIL = "ไม่มี"
                End If
            Catch ex As Exception

            End Try

            Try
                dao.fields.STORAGE_ID = DD_STORAGE_ID.SelectedValue
                dao.fields.STORAGE_NAME = DD_STORAGE_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

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
                Try
                    dao.fields.WARNING_ID = DD_WARNING.SelectedValue
                Catch ex As Exception

                End Try

                Try
                    If DD_WARNING.SelectedValue = 1 Then
                        dao.fields.WARNING_SUB_ID = DD_WARNING_SUB.SelectedValue
                        dao.fields.WARNING_SUB_NAME = DD_WARNING_SUB.SelectedItem.Text
                        R_WARNING_TEXT.Visible = False
                    Else
                        dao.fields.WARNING_NAME = WARNING_NAME.Text
                        dao.fields.WARNING_SUB_NAME = WARNING_NAME.Text
                        R_WARNING_TEXT.Visible = True
                    End If
                Catch ex As Exception

                End Try
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

            Try
                dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
                dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
            Catch ex As Exception

            End Try


            dao.fields.NOTE = NOTE.Text

            dao.fields.STATUS_ID = 1
            dao.fields.ACTIVEFACT = 1
            dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_BY = _CLS.THANM
            ' dao.fields.MENU_GROUP = _MENU_GROUP
            dao.fields.DATE_YEAR = con_year(Date.Now().Year())

            For Each item As GridDataItem In RG_CAS.Items
                Try
                    Dim dao_cas As New DAO_TABEAN_HERB.TB_TABEAN_INFROM_DETIAL_CAS
                    dao_cas.fields.ennm_cas = item("ennm_cas").Text
                    dao_cas.fields.thnm_cas = item("thnm_cas").Text
                    'dao_cas.fields.QTY = dr("")
                    'dao_cas.fields.IOWA = dr("")
                    'dao_cas.fields.AORI = "I"
                    dao_cas.fields.number_cas = item("num_cas").Text
                    dao_cas.fields.duty_cas_id = item("duty_cas_id").Text
                    dao_cas.fields.duty_cas_nm = item("duty_cas").Text
                    dao_cas.fields.amount_cas = item("amoun_cas").Text
                    dao_cas.fields.unit_cas_id = item("uni_cas_id").Text
                    dao_cas.fields.unit_cas_nm = item("uni_cas").Text
                    dao_cas.fields.ACTIVE = 1
                    dao_cas.fields.FK_IDA = _IDA
                    dao_cas.insert()
                Catch ex As Exception
                    ' Handle the exception (e.g., log it or display an error message)
                End Try
            Next
            If dao.fields.IDA = 0 Then dao.insert() Else dao.Update()

            Try
                If Request.QueryString("staff") = 1 Then
                    Try
                        UC_ATTACH1.insert_TBN(TR_ID, _PROCESS_ID, dao_inform.fields.IDA, 6)
                        UC_ATTACH2.insert_TBN(TR_ID, _PROCESS_ID, dao_inform.fields.IDA, 8)
                        'chk_file1.Text = UC_ATTACH1.NAME
                        'chk_file2.Text = UC_ATTACH2.NAME
                        alert_summit("กรุณาอัพโหลดเอกสารแนบ", dao_inform.fields.IDA)
                    Catch ex As Exception
                        alert_summit("กรุณาอัพโหลดเอกสารแนบ", dao_inform.fields.IDA)
                    End Try
                Else

                    'If UC_ATTACH1.CHK_TBN = False Or UC_ATTACH2.CHK_TBN = False Then
                    '    alert_nature("กรุณาแนบไฟล์ เอกสารแนบไฟล์ ชื่อสมุนไพร/สารกัด/สารช่วย และ กรรมวิธีการผลิต")
                    'ElseIf UC_ATTACH1.CHK_TBN = False And UC_ATTACH2.CHK_TBN = False Then
                    '    alert_nature("กรุณาแนบไฟล์ เอกสารแนบไฟล์ ชื่อสมุนไพร/สารกัด/สารช่วย และ กรรมวิธีการผลิต")
                    'Else
                    UC_ATTACH1.insert_TBN(TR_ID, _PROCESS_ID, dao_inform.fields.IDA, 6)
                    UC_ATTACH2.insert_TBN(TR_ID, _PROCESS_ID, dao_inform.fields.IDA, 8)
                    alert_summit("กรุณาอัพโหลดเอกสารแนบ", dao_inform.fields.IDA)
                    'End If
                End If
            Catch ex As Exception

            End Try
        End If

        ADD_File_Uploads(202, TR_ID, 0)
        If cb_Head_Menu_2.Checked = True Then ADD_File_Uploads(202, TR_ID, 2)
        If cb_Head_Menu_3.Checked = True Then ADD_File_Uploads(202, TR_ID, 3)
        If cb_Head_Menu_4.Checked = True Then ADD_File_Uploads(202, TR_ID, 4)
        If cb_Head_Menu_5.Checked = True Then ADD_File_Uploads(202, TR_ID, 5)
    End Sub
    Sub ADD_File_Uploads(ByVal Type_ID As Integer, ByVal TR_ID As Integer, ByVal HEAD_ID As Integer)
        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE_AND_HEAD_ID(Type_ID, HEAD_ID)
        For Each dao_up_mas.fields In dao_up_mas.datas
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
            dao_up.fields.TR_ID = TR_ID
            dao_up.fields.PROCESS_ID = _PROCESS_ID
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.TYPE = 1
            dao_up.insert()
        Next
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_inform As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao_inform.GetdatabyID_IDA(_IDA)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
        dao_tabean.GetdatabyID_FK_IDA(_IDA)
        'If Request.QueryString("staff") = 2 Then
        '    Response.Redirect("../HERB_TABEAN_STAFF_NEW/FRM_HERB_TABEAN_STAFF_TABEAN.aspx?TR_ID_LCN=" & dao_lcn.fields.TR_ID & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & dao_lcn.fields.IDA & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID & "&IDA_DQ=" & dao_inform.fields.IDA & "&PROCESS_ID_DQ=" & dao_inform.fields.PROCESS_ID & "&staff=" & "1")
        'Else
        Response.Redirect("FRM_HERB_TABEAN.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA & "&PROCESS_ID_DQ=" & _PROCESS_ID)
        'End If
    End Sub
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
        url = "POPUP_HERB_TABEAN_INFORM_UPLOAD.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA=" & _IDA & "&PROCESS_ID=" & _PROCESS_ID & "&staff=" & Request.QueryString("staff") & "&SID=" & _SID
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
            R_EATING_CONDITION_TEXT.Visible = False
        Else
            R_EATING_CONDITION_TEXT.Visible = False
        End If
    End Sub

    Protected Sub btn_add_muc_add_Click(sender As Object, e As EventArgs) Handles btn_add_muc_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_MANUFACTRUE

        dao.fields.FK_IDA = _IDA
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

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_MANUFACTRUE
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Protected Sub btn_size_pack_Click(sender As Object, e As EventArgs) Handles btn_size_pack.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_SIZE_PACK_FST

        dao.fields.FK_IDA = _IDA

        If DD_PCAK_1.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_1.SelectedValue = "-- กรุณาเลือก --" Then '_
            'Or DD_PCAK_2.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_2.SelectedValue = "-- กรุณาเลือก --" Then ' _
            'Or DD_PCAK_3.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_3.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูล Primary Seceondary Tertiary Packaging');", True)
        Else
            dao.fields.PACK_F_ID = DD_PCAK_1.SelectedValue
            dao.fields.PACK_F_NAME = DD_PCAK_1.SelectedItem.Text
            dao.fields.NO_1 = NO_1.Text
            dao.fields.UNIT_F_ID = DD_UNIT_1.SelectedValue
            dao.fields.UNIT_F_NAME = DD_UNIT_1.SelectedItem.Text
            Try
                dao.fields.PACK_S_ID = DD_PCAK_2.SelectedValue
                dao.fields.PACK_S_NAME = DD_PCAK_2.SelectedItem.Text
                dao.fields.NO_2 = NO_2.Text
                dao.fields.UNIT_S_ID = DD_UNIT_2.SelectedValue
                dao.fields.UNIT_S_NAME = DD_UNIT_2.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_S_ID = 0
                dao.fields.PACK_S_NAME = ""
                dao.fields.NO_2 = ""
                dao.fields.UNIT_S_ID = 0
                dao.fields.UNIT_S_NAME = ""
            End Try


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

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_SIZE_PACK_FST
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid4.Rebind()
            End If
        End If
    End Sub

    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_SIZE_PACK_FST
        dao_size.GetdatabyID_FK_IDA(_IDA)
        RadGrid4.DataSource = dao_size.datas

    End Sub

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        bind_size()
    End Sub

    Private Sub bind_manu()
        Dim dao_manu As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_MANUFACTRUE
        dao_manu.GetdatabyID_FK_IDA(_IDA)
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

    Protected Sub RBL_CHK_PRODUCER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_CHK_PRODUCER.SelectedIndexChanged
        If RBL_CHK_PRODUCER.SelectedValue = 1 Then
            DIV_PRODUCER_SHOW1.Visible = True
            DIV_PRODUCER_SHOW2.Visible = True
        Else
            DIV_PRODUCER_SHOW1.Visible = False
            DIV_PRODUCER_SHOW2.Visible = False
        End If
    End Sub

    Protected Sub BTN_SEARCH_PRODUCER_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_PRODUCER.Click
        Search_FN()
        RadGrid_LCNNO.Rebind()
    End Sub
    Sub Search_FN()
        Dim pvncd As Integer = 0
        Try
            pvncd = _CLS.PVCODE
        Catch ex As Exception
            pvncd = 0
        End Try

        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_DALCN_STAFF_SEARCH()
        Dim dt As New DataTable
        Try
            dt = bao.dt
        Catch ex As Exception

        End Try
        Dim r_result As DataRow()
        Dim str_where As String = ""
        Dim dt2 As New DataTable
        'str_where = "CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
        If TXT_LCNNO_SEARCH.Text <> "" Then

            If str_where <> "" Then
                str_where &= " and LCNNO_DISPLAY_NEW like '%" & TXT_LCNNO_SEARCH.Text & "%' or lcnno_no like '%" & TXT_LCNNO_SEARCH.Text & "%'"
            Else
                str_where &= " LCNNO_DISPLAY_NEW like '%" & TXT_LCNNO_SEARCH.Text & "%' or lcnno_no like '%" & TXT_LCNNO_SEARCH.Text & "%'"
            End If
        End If
        ' pvncd = 12
        If pvncd <> 10 Then
            If str_where <> "" Then
                str_where &= " and pvncd=" & pvncd
            Else
                str_where &= " pvncd=" & pvncd
            End If

        End If

        r_result = dt.Select(str_where)

        dt2 = dt.Clone

        For Each dr As DataRow In r_result
            dt2.Rows.Add(dr.ItemArray)
        Next
        DIV_LCNNO_SHOW_GRID.Visible = True
        RadGrid_LCNNO.DataSource = dt2
    End Sub
    Private Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click

        For Each item As GridDataItem In RadGrid_LCNNO.SelectedItems
            Dim lcntpcd As String = ""
            Dim dao_da As New DAO_DRUG.ClsDBdalcn
            Try
                dao_da.GetDataby_IDA(item("IDA").Text)
                lcntpcd = dao_da.fields.lcntpcd
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
            dao.fields.FK_LCN_IDA = item("IDA").Text
            dao.fields.lpvncd = dao.fields.lpvncd
            dao.fields.lcnno = dao.fields.lcnno
            dao.fields.lcnsid = dao.fields.lcnsid
            dao.fields.FK_IDA = Request.QueryString("IDA_DQ")
            dao.fields.PROCESS_ID = _PROCESS_ID
            'dao.fields.funccd = ddl_work_type.SelectedValue
            dao.insert()
        Next

        'KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "เพิ่มผู้ผลิตในประเทศ", _CLS.CITIZEN_ID)
        DIV_PRODUCER_SHOW_GRID.Visible = True
        RadGrid_PRODUCER.Rebind()
    End Sub
    Private Sub RadGrid_PRODUCER_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid_PRODUCER.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        dt = bao.SP_DRRQT_PRODUCER_IN_BY_FK_IDA_V2(Request.QueryString("IDA_DQ"))

        RadGrid_PRODUCER.DataSource = dt
    End Sub
    Private Sub RadGrid_PRODUCER_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid_PRODUCER.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim lbl_comment As Label = DirectCast(item("work_type").FindControl("lbl_work_type"), Label)
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)


            Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
            dao.GetDataby_IDA(item("IDA").Text)
            Try
                rcb_work_type.SelectedValue = dao.fields.funccd
            Catch ex As Exception

            End Try
            Try

                If dao.fields.funccd = 1 Then
                    lbl_comment.Text = "ผลิตยาสำเร็จรูป"
                ElseIf dao.fields.funccd = 2 Then
                    lbl_comment.Text = "แบ่งบรรจุ"
                ElseIf dao.fields.funccd = 3 Then
                    lbl_comment.Text = "ตรวจปล่อยหรือผ่านเพื่อจำหน่าย"
                ElseIf dao.fields.funccd = 9 Then
                    lbl_comment.Text = "อื่นๆ"
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub RadGrid_PRODUCER_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid_PRODUCER.ItemCommand
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_infor As New BAO.information

        If e.CommandName = "_del" Then
            Dim item As GridDataItem
            item = e.Item
            Dim old_data As String = ""
            Dim new_data As String = ""
            If Request.QueryString("tt") <> "" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
            Else
                Try
                    Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
                    dao.GetDataby_IDA(item("IDA_DQ").Text)
                    dao.delete()
                    alert("ลบเรียบร้อยแล้ว")

                Catch ex As Exception

                End Try
                'KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "ลบผู้ผลิตในประเทศ", _CLS.CITIZEN_ID)
                RadGrid_PRODUCER.Rebind()
            End If
        End If
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub btn_save_work_type_Click(sender As Object, e As EventArgs) Handles btn_save_work_type.Click
        For Each item As GridDataItem In RadGrid_PRODUCER.Items
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)

            Dim dao_pro As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
            dao_pro.GetDataby_IDA(item("IDA").Text)
            dao_pro.fields.funccd = rcb_work_type.SelectedValue
            dao_pro.update()
        Next
        alert("บันทึกเรียบร้อยแล้ว")
        RadGrid_PRODUCER.Rebind()
    End Sub
    Public Function striptags(ByVal html As String) As String
        Return Regex.Replace(html, "\s", "")
    End Function

    Protected Sub DDL_NATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_NATION.SelectedIndexChanged
        If DDL_NATION.SelectedValue = 1 Then
            data_show1.Visible = False
            data_show2.Visible = False
        Else
            data_show1.Visible = True
            data_show2.Visible = True
        End If
    End Sub

    'Protected Sub BTN_SEARCH_TN_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_TN.Click
    '    Dim dao As New DAO_CPN.TB_syslcnsnm

    '    If TXT_SEARCH_TN.Text IsNot Nothing Then
    '        Dim citizen_id As String = TXT_SEARCH_TN.Text
    '        Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
    '        Dim obj As New XML_DATA
    '        'Dim cls As New CLS_COMMON.convert
    '        Dim result As String = ""
    '        'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
    '        result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
    '        obj = ConvertFromXml(Of XML_DATA)(result)
    '        Try
    '            Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
    '            If TYPE_PERSON = 1 Then
    '                txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
    '            ElseIf TYPE_PERSON = 99 Then
    '                txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
    '            Else
    '                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
    '                    txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
    '                Else
    '                    txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
    '                End If
    '            End If
    '        Catch ex As Exception
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
    '        End Try
    '    Else
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
    '    End If
    'End Sub

    Protected Sub cb_Head_Menu_1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Head_Menu_1.CheckedChanged
        If cb_Head_Menu_1.Checked = True Then
            NAME_THAI.ReadOnly = False
            NAME_THAI.Enabled = True
            NAME_ENG.ReadOnly = False
            NAME_ENG.Enabled = True
            NAME_OTHER.ReadOnly = False
            NAME_OTHER.Enabled = True
        Else
            NAME_THAI.ReadOnly = True
            NAME_THAI.Enabled = False
            NAME_ENG.ReadOnly = True
            NAME_ENG.Enabled = False
            NAME_OTHER.ReadOnly = True
            NAME_OTHER.Enabled = False
        End If
    End Sub

    Protected Sub cb_Head_Menu_2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Head_Menu_2.CheckedChanged

    End Sub

    Protected Sub cb_Head_Menu_3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Head_Menu_3.CheckedChanged
        If cb_Head_Menu_3.Checked = True Then
            STAFF_HIDE_SET.Visible = True
            Detail_Cass_New.Visible = True
        Else
            STAFF_HIDE_SET.Visible = False
            Detail_Cass_New.Visible = False
        End If
    End Sub

    Protected Sub cb_Head_Menu_4_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Head_Menu_4.CheckedChanged
        If cb_Head_Menu_4.Checked = True Then
            SIZE_USE.ReadOnly = False
            SIZE_USE.Enabled = True
            HOW_USE.ReadOnly = False
            HOW_USE.Enabled = True
            DD_EATTING_ID.Enabled = True
            DD_EATING_CONDITION_ID.Enabled = True
            EATING_CONDITION_NAME.ReadOnly = True
            EATING_CONDITION_NAME.Enabled = True
        Else
            SIZE_USE.ReadOnly = True
            SIZE_USE.Enabled = False
            HOW_USE.ReadOnly = True
            HOW_USE.Enabled = False
            DD_EATTING_ID.Enabled = False
            DD_EATING_CONDITION_ID.Enabled = False
            EATING_CONDITION_NAME.ReadOnly = True
            EATING_CONDITION_NAME.Enabled = False
        End If
    End Sub

    Protected Sub cb_Head_Menu_5_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Head_Menu_5.CheckedChanged
        If cb_Head_Menu_5.Checked = True Then
            PROPERTIES.ReadOnly = False
            PROPERTIES.Enabled = True
        Else
            PROPERTIES.ReadOnly = True
            PROPERTIES.Enabled = False
        End If
    End Sub

    Protected Sub cb_Head_Menu_6_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Head_Menu_6.CheckedChanged
        If cb_Head_Menu_6.Checked = True Then
            DD_PCAK_1.Enabled = True
            DD_PCAK_2.Enabled = True
            DD_PCAK_3.Enabled = True

            NO_1.ReadOnly = False
            NO_1.Enabled = True
            NO_2.ReadOnly = False
            NO_2.Enabled = True
            NO_3.ReadOnly = False
            NO_3.Enabled = True

            DD_UNIT_1.Enabled = True
            DD_UNIT_2.Enabled = True
            DD_UNIT_3.Enabled = True
        Else
            DD_PCAK_1.Enabled = False
            DD_PCAK_2.Enabled = False
            DD_PCAK_3.Enabled = False

            NO_1.ReadOnly = True
            NO_1.Enabled = False
            NO_2.ReadOnly = True
            NO_2.Enabled = False
            NO_3.ReadOnly = True
            NO_3.Enabled = False

            DD_UNIT_1.Enabled = False
            DD_UNIT_2.Enabled = False
            DD_UNIT_3.Enabled = False
        End If
    End Sub
    Private Function serialgrid(ByVal R As RadGrid) As DataTable
        Dim DT As New DataTable
        DT = gridaddcolumn(R)
        grid_reindex(DT, "num")
        For Each g As GridDataItem In R.Items
            Dim dr As DataRow = DT.NewRow()
            For Each C As DataColumn In DT.Columns
                dr(C.ColumnName) = g(C.ColumnName).Text
            Next
            DT.Rows.Add(dr)
        Next
        Return DT
    End Function

    Private Overloads Function gridaddcolumn(ByVal R As RadGrid) As DataTable
        Dim DT As New DataTable
        For Each G As GridColumn In R.Columns
            DT.Columns.Add(G.UniqueName)
        Next
        Return DT
    End Function

    Private Sub grid_reindex(ByRef dt As DataTable, ByVal Cname As String)
        Dim i As Integer = 1
        For Each dr As DataRow In dt.Rows
            dr(Cname) = i
            i = i + 1
        Next
    End Sub

  Private Sub btn_add_cas_Click(sender As Object, e As EventArgs) Handles btn_add_cas.Click
    Dim dt As New DataTable
        dt = serialgrid(RG_CAS)
        Dim dr As DataRow = dt.NewRow
        dr("thnm_cas") = txt_thai_name_cas.Text
        dr("ennm_cas") = txt_eng_name_cas.Text
        dr("num_cas") = txt_number_cas.Text
        dr("duty_cas") = ddl_duty_cas.Text
        dr("duty_cas_id") = ddl_duty_cas.SelectedValue
        dr("amoun_cas") = txt_amount_cas.Text
        dr("uni_cas") = ddl_unit_cas.Text
        dr("uni_cas_id") = ddl_unit_cas.SelectedValue
        dt.Rows.Add(dr)
        'grid_reindex(dt, "num")
        RG_CAS.DataSource = dt
        RG_CAS.DataBind()
        Clear_Result()
    End Sub
    Private Sub RG_CAS_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RG_CAS.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "result_CAS" Then
                RG_CAS.Rebind()
            End If
        End If
    End Sub
    Sub Clear_Result()
        txt_thai_name_cas.Text = Nothing
        txt_eng_name_cas.Text = Nothing
        txt_number_cas.Text = Nothing
        ddl_duty_cas.Text = Nothing
        txt_amount_cas.Text = Nothing
        ddl_unit_cas.Text = Nothing
    End Sub
End Class

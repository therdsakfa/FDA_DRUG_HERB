Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_ADD_DETAIL
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA_DQ As String = ""
    Private _PROCESS_ID_DQ As String = ""
    Private TR_ID_DQ As String = ""
    Private _SID As String = ""
    Private _R_ID As String = ""
    Private _WHO_IDA As String = ""

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
        _SID = Request.QueryString("SID")
        _R_ID = Request.QueryString("R_ID")
        _WHO_IDA = Request.QueryString("WHO_IDA")

    End Sub

    Shared PLACE_IDA As Integer = 0
    Shared _FRGNCD As Integer = 0
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
            bind_dd_HERB_PROCESS()
            bind_dd_herb()

            UC_officer_che.bind_unit1()
            UC_officer_che.bind_unit2()
            UC_officer_che.bind_unit3()
            UC_officer_che.bind_unit4()
            UC_officer_che.get_data_drgperunit()
            UC_officer_che.bind_unit_each()
            UC_officer_che.bind_lbl()
            ' UC_recipe.bind_ddl_atc()            UC_officer_che.bind_unit_head()
            UC_officer_che.bind_unit()


            UC_ATTACH1.NAME = "เอกสารแนบ สูตรตำรับ"
            UC_ATTACH1.BindData("สูตรตำรับ", 1, "pdf", "0", "6")
            UC_ATTACH2.NAME = "เอกสารแนบ กรรมวิธีการผลิต"
            UC_ATTACH2.BindData("กรรมวิธีการผลิต", 1, "pdf", "0", "8")

            Try
                If _PROCESS_ID_DQ.Contains(2019) Then
                    If _PROCESS_ID_LCN = 121 Then
                        DD_CATEGORY_ID.SelectedValue = 1210
                        DD_CATEGORY_OUT_ID.SelectedValue = 1200
                    ElseIf _PROCESS_ID_LCN = 122 Then
                        DD_CATEGORY_ID.SelectedValue = 1220
                        DD_CATEGORY_OUT_ID.SelectedValue = 1200
                    End If
                Else
                    DD_CATEGORY_ID.SelectedValue = _PROCESS_ID_LCN
                End If

            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA_DQ)
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
                    STAFF_HIDE_SET.Visible = True
                End If
            Catch ex As Exception

            End Try


            If _PROCESS_ID_LCN = 121 Then
                foreign.Visible = True
            Else
                foreign.Visible = False
            End If

            If _PROCESS_ID_DQ = 20191 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20192 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20193 Then
                DD_CATEGORY_OUT_ID.Visible = True
                lab_category_out_id.Visible = True
            ElseIf _PROCESS_ID_DQ = 20194 Then
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
        Dim dao_local As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_local.GetDataby_IDA(dao_lcn.fields.FK_IDA)

        Dim thanameplace As String = dao_local.fields.thanameplace
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace
        If thanameplace Is Nothing Then
            thanameplace = dao_lcn.fields.thanameplace
        End If
        ' Dim thanm As String = dao_lcn.fields.thanm
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try
        Dim THANM As String = ""
        Try
            THANM = GET_NAME_BY_IDEN(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
        Catch ex As Exception

        End Try

        Dim dao_who As New DAO_WHO.TB_WHO_DALCN
        'dao_who.GetdatabyID_FK_LCN(_IDA_LCN)
        Try
            dao_who.GetdatabyID_IDA(_WHO_IDA)
        Catch ex As Exception

        End Try
        'If _SID = "2" Then
        '    THANM = dao_who.fields.THANM_NAME
        'End If


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

        Dim dao_cpnWho As New DAO_CPN.clsDBsyslcnsid
        dao_cpnWho.GetDataby_identify(_CLS.CITIZEN_ID_AUTHORIZE)
        Dim TYPE_PERSON_WHO As Integer = 0
        Try
            TYPE_PERSON_WHO = dao_cpnWho.fields.type
        Catch ex As Exception
            TYPE_PERSON_WHO = 0
        End Try


        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)

        Dim TYPE_PERSON As Integer = 0
        Try
            TYPE_PERSON = dao_cpn.fields.type
        Catch ex As Exception
            TYPE_PERSON = 0
        End Try
        Dim NATION As String = dao_lcn.fields.NATION
        If _SID = 2 Then
            If TYPE_PERSON_WHO = 1 Then
                data_show3.Visible = False
            Else
                data_show3.Visible = True
            End If
        Else
            If TYPE_PERSON = 1 Then
                data_show3.Visible = False
            Else
                data_show3.Visible = True
                txt_agent99.Text = BSN_THAIFULLNAME

            End If
        End If
        NAME_TB.Text = THANM
        NAME_PLACE_TB.Text = thanameplace
    End Sub
    Public Sub bind_dd_HERB_PROCESS()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_DD_HERB(_R_ID)

        DD_TYPE_NAME.DataSource = dt
        DD_TYPE_NAME.DataBind()
        DD_TYPE_NAME.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub


    Public Sub bind_dd_herb()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        If _PROCESS_ID_DQ = 20101 Then
            DD_TYPE_NAME.SelectedValue = 20101
            DD_TYPE_SUB_ID.SelectedValue = 1
        ElseIf _PROCESS_ID_DQ = 20102 Then
            DD_TYPE_NAME.SelectedValue = 20102
            DD_TYPE_SUB_ID.SelectedValue = 2
        ElseIf _PROCESS_ID_DQ = 20103 Then
            DD_TYPE_NAME.SelectedValue = 20103
            DD_TYPE_SUB_ID.SelectedValue = 3
        ElseIf _PROCESS_ID_DQ = 20104 Then
            DD_TYPE_NAME.SelectedValue = 20104
            DD_TYPE_SUB_ID.SelectedValue = 4
        ElseIf _PROCESS_ID_DQ = 20191 Then
            DD_TYPE_NAME.SelectedValue = 20191
            DD_TYPE_SUB_ID.SelectedValue = 1
        ElseIf _PROCESS_ID_DQ = 20192 Then
            DD_TYPE_NAME.SelectedValue = 20192
            DD_TYPE_SUB_ID.SelectedValue = 2
        ElseIf _PROCESS_ID_DQ = 20193 Then
            DD_TYPE_NAME.SelectedValue = 20193
            DD_TYPE_SUB_ID.SelectedValue = 3
        ElseIf _PROCESS_ID_DQ = 20194 Then
            DD_TYPE_NAME.SelectedValue = 20194
            DD_TYPE_SUB_ID.SelectedValue = 4
        End If
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


            PLACE_NAME = PLACE_NAME_ENG.Replace("&nbsp;", "") & " " & PLACE_NAME_THAI.Replace("&nbsp;", "")
            txt_search.Text = PLACE_NAME
            txt_search_ida.Text = PLACE_IDA

            Try
                frgncd = item("frgncd").Text
                _FRGNCD = frgncd
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
                'PLACE_ADDRESS = item("fulladdr2").Text
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

        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try
        'If _SID = 2 Then
        '    Dim citizen_id As String = _CLS.CITIZEN_ID_AUTHORIZE
        '    Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
        '    Dim obj As New XML_DATA
        '    'Dim cls As New CLS_COMMON.convert
        '    Dim result As String = ""
        '    'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
        '    result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
        '    obj = ConvertFromXml(Of XML_DATA)(result)
        '    Try
        '        Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
        '        If TYPE_PERSON = 1 Then
        '            thanm = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
        '        Else
        '            If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
        '                thanm = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
        '            Else
        '                thanm = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm
        '            End If
        '        End If
        '    Catch ex As Exception
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        '    End Try


        'Else
        '    If thanm = "" Or thanm Is Nothing Then
        '        thanm = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
        '    Else
        '        thanm = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        '    End If
        'End If

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
        If dao.fields.WARNING_TYPE_ID IsNot Nothing Then
            R_WARNING.SelectedValue = dao.fields.WARNING_TYPE_ID
        End If
        If dao.fields.WARNING_TYPE_ID = 1 Then
            WARNING_NAME.Text = dao.fields.WARNING_NAME
            DD_WARNING.SelectedValue = dao.fields.WARNING_ID
            DD_WARNING.Visible = True
            R_WARNING_TEXT.Visible = True
        End If
        'If dao.fields.WARNING_ID IsNot Nothing Then
        '    R_WARNING.SelectedValue = dao.fields.WARNING_ID
        'End If
        'If dao.fields.WARNING_ID = 1 Then
        '    WARNING_NAME.Text = dao.fields.WARNING_NAME
        '    R_WARNING_TEXT.Visible = True
        'End If
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
        'NAME_TB.Text = thanm
        If Request.QueryString("staff") = 2 Then
            btn_save.Text = "บันทึกข้อมูล"
        End If
        Try
            txt_person_age.Text = dao.fields.PERSON_AGE
        Catch ex As Exception

        End Try
        Try
            DDL_NATION.SelectedValue = dao.fields.NATIONALITY_PERSON_ID
        Catch ex As Exception

        End Try
        Try
            DD_EATING_CONDITION_ID.SelectedValue = dao.fields.EATING_CONDITION_ID
        Catch ex As Exception

        End Try

    End Sub
    Public Function GET_NAME_BY_IDEN(ByVal identify As String)
        Dim FULL_NAME As String = ""
        Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
        Dim obj As New XML_DATA
        'Dim cls As New CLS_COMMON.convert
        Dim result As String = ""
        'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
        result = ws_center.GET_DATA_IDENTIFY(identify, identify, "FUSION", "P@ssw0rdfusion440")
        obj = ConvertFromXml(Of XML_DATA)(result)
        Try
            Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON = 1 Then
                FULL_NAME = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    FULL_NAME = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    FULL_NAME = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm
                End If
            End If
        Catch ex As Exception

        End Try
        Return FULL_NAME
    End Function
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        If dao_tabean.fields.IDA <> 0 Then
            If Request.QueryString("staff") = 2 Then
                update_data()
                Run_Pdf_Tabean_Herb()
                alert_summit_staff("บันทึกข้อมูลเรีบยร้อย")
                'Response.Redirect("../HERB_TABEAN_STAFF_NEW/FRM_HERB_TABEAN_STAFF_TABEAN.aspx?TR_ID_LCN=" & dao_lcn.fields.TR_ID & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & dao_lcn.fields.IDA & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID & "&IDA_DQ=" & dao_deeqt.fields.IDA & "&PROCESS_ID_DQ=" & dao_deeqt.fields.PROCESS_ID & "&staff=" & "1")
            Else
                If DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลรูปแบบ');", True)
                Else
                    save_data()
                End If
            End If
        Else
            If DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลรูปแบบ');", True)
            Else
                save_data()
            End If
        End If

        'Response.Redirect(Request.Url.AbsoluteUri)
        'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _DDHERB & "&IDA=" & _IDA)
    End Sub
    Public Sub Run_Pdf_Tabean_Herb()
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA_DQ, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_PROCESS_ID_DQ, dao.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _PROCESS_ID_DQ, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_DQ, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _PROCESS_ID_DQ, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_DQ, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID_DQ, PATH_PDF_OUTPUT)

        'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Sub alert_summit_staff(ByVal text As String)
        Dim url As String = ""
        url = "../HERB_TABEAN_STAFF_NEW/FRM_HERB_TABEAN_STAFF_TABEAN.aspx?"
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Sub update_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        'DAO_WHO.GetdatabyID_FK_LCN(_IDA_LCN)
        Try
            DAO_WHO.GetdatabyID_IDA(_WHO_IDA)
        Catch ex As Exception

        End Try
        Dim TP_PERSON As Integer = 0
        Try
            TP_PERSON = DAO_WHO.fields.TYPEPERSON
        Catch ex As Exception
            TP_PERSON = 0
        End Try

        If dao_deeqt.fields.IDA <> 0 Then

        End If

        Dim lcnno_auto As String = dao_lcn.fields.lcnno
        Dim lcnno_auto_sub As String = Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)


        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

        Dim THANM As String = dao_lcn.fields.thanm
        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            tb_location.GetDataby_LCN_IDA(_IDA_LCN)
        Catch ex As Exception

        End Try

        dao_deeqt.fields.thadrgnm = NAME_THAI.Text
        dao_deeqt.fields.engdrgnm = NAME_ENG.Text
        dao_deeqt.update()
        If DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        Else

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
            'dao.fields.LCN_NAME = NAME_TB.Text
            Try
                dao.fields.FOREIGN_NAME_ID = txt_search_ida.Text
                dao.fields.FOREIGN_NAME = striptags(txt_search.Text)
                dao.fields.FOREIGN_NAME_PLACE_ID = txt_address_ida.Text
                dao.fields.FOREIGN_NAME_PLACE = txt_address.Text.ToUpper()
            Catch ex As Exception

            End Try

            dao.fields.AGENT_99 = txt_agent99.Text
            dao.fields.IDEN_AGENT_99 = TXT_SEARCH_TN.Text
            dao.fields.PERSON_AGE = txt_person_age.Text
            Try
                dao.fields.NATIONALITY_PERSON_ID = DDL_NATION.SelectedValue
                dao.fields.NATIONALITY_PERSON = DDL_NATION.SelectedItem.Text
                dao.fields.NATIONALITY_PERSON_OTHER = txt_nation_person.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
                dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text
                dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
                dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
                dao.fields.CATEGORY_ID = DD_CATEGORY_ID.SelectedValue
                dao.fields.CATEGORY_NAME = DD_CATEGORY_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.CATEGORY_OUT_ID = DD_CATEGORY_OUT_ID.SelectedValue
                dao.fields.CATEGORY_OUT_NAME = DD_CATEGORY_OUT_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

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

            Try
                dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
                dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
            Catch ex As Exception

            End Try


            dao.fields.SIZE_PACK = SIZE_PACK.Text
            'dao.fields.PRODUCT_JJ = _PROCESS_ID_DQ
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

            Try
                dao.fields.TREATMENT_AGE = TREATMENT_AGE_YEAR.SelectedValue
                dao.fields.TREATMENT_AGE_MONTH = TREATMENT_AGE_MONTH_SUB.SelectedValue
            Catch ex As Exception
                dao.fields.TREATMENT_AGE = 0
                dao.fields.TREATMENT_AGE_MONTH = TREATMENT_AGE_MONTH_SUB.SelectedValue
            End Try
            Try
                dao.fields.CONTRAINDICATION_ID = R_CONTRAINDICATION.SelectedValue
            Catch ex As Exception

            End Try
            Try
                If R_CONTRAINDICATION.SelectedValue = 1 Then
                    dao.fields.CONTRAINDICATION_NAME = CONTRAINDICATION_NAME.Text
                    R_CONTRAINDICATION_TEXT.Visible = True
                Else
                    dao.fields.CONTRAINDICATION_NAME = "ไม่มี"
                End If
            Catch ex As Exception

            End Try
            Try
                dao.fields.WARNING_TYPE_ID = R_WARNING.SelectedValue
            Catch ex As Exception

            End Try
            Try
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
            Catch ex As Exception

            End Try

            Try
                dao.fields.CAUTION_ID = R_CAUTION.SelectedValue
            Catch ex As Exception

            End Try
            Try
                If R_CAUTION.SelectedValue = 1 Then
                    dao.fields.CAUTION_NAME = CAUTION_NAME.Text
                    R_CAUTION_TEXT.Visible = True
                Else
                    dao.fields.CAUTION_NAME = "ไม่มี"
                End If
            Catch ex As Exception

            End Try

            Try
                dao.fields.ADV_REACTIVETION_ID = R_ADV_REACTIVETION.SelectedValue
            Catch ex As Exception

            End Try
            Try
                If R_ADV_REACTIVETION.SelectedValue = 1 Then
                    dao.fields.ADV_REACTIVETION_NAME = ADV_REACTIVETION_NAME.Text
                    R_ADV_REACTIVETION_TEXT.Visible = True
                Else
                    dao.fields.ADV_REACTIVETION_NAME = "ไม่มี"
                End If
            Catch ex As Exception

            End Try

            Try
                dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
                dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.fields.NOTE = NOTE.Text

            dao.Update()

        End If

        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        dt = bao.SP_drfrgnaddr_BY_frgncd(_FRGNCD)
        If _FRGNCD <> 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_pro As New DAO_DRUG.TB_DRRQT_PRODUCER
                dao_pro.GetDataby_FK_IDA(_IDA_DQ)
                dao_pro.fields.FK_IDA = _IDA_DQ
                dao_pro.fields.frgncd = _FRGNCD
                Try
                    dao_pro.fields.addr_ida = dr("addr_ida")
                Catch ex As Exception

                End Try
                Try
                    dao_pro.fields.FK_PRODUCER = dr("FK_PRODUCER")
                Catch ex As Exception

                End Try
                'Try
                '    dao_pro.fields.PRODUCER_WORK_TYPE = dr("PRODUCER_WORK_TYPE")
                'Catch ex As Exception

                'End Try
                'Try
                '    dao_pro.fields.REFERENCE_GMP = dr("REFERENCE_GMP")
                'Catch ex As Exception

                'End Try
                Try
                    dao_pro.fields.frgnlctcd = dr("frgnlctcd")
                Catch ex As Exception

                End Try
                dao_pro.update()
            Next
            'dao.fields.PRODUCER_WORK_TYPE = ddl_work_type.SelectedValue
        End If
    End Sub
    Sub save_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        'DAO_WHO.GetdatabyID_FK_LCN(_IDA_LCN)
        Try
            DAO_WHO.GetdatabyID_IDA(_WHO_IDA)
        Catch ex As Exception

        End Try

        If dao_deeqt.fields.IDA <> 0 Then

        End If

        Dim lcnno_auto As String = DAO_LCN.fields.lcnno
        Dim lcnno_auto_sub As String = Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)


        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

        'Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        'Try
        '    dao_esub.GetDataby_LCN_IDA(_IDA_LCN)
        'Catch ex As Exception

        'End Try
        Dim dao_pfx2 As New DAO_CPN.TB_sysprefix
        Dim THANM As String = dao_lcn.fields.thanm
        Try
            dao_pfx2.Getdata_byid(dao_customer.fields.prefixcd)
        Catch ex As Exception

        End Try
        If THANM = "" Or THANM Is Nothing Then
            THANM = dao_pfx2.fields.thanm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
        Else
            THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        End If
        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            tb_location.GetDataby_LCN_IDA(_IDA_LCN)
        Catch ex As Exception

        End Try
        'Dim locnnodisplay As String = dao_lcn.fields.lcntpcd & " " & dao_lcn.fields.pvnabbr & " " & lcnno_auto_sub
        Dim locnnodisplay As String = DAO_LCN.fields.LCNNO_DISPLAY_NEW
        Dim thanameplace As String = DAO_LCN.fields.thanameplace
        Dim CATEGORY_ID As String = DAO_LCN.fields.PROCESS_ID
        Dim PVNCD As Integer = DAO_LCN.fields.pvncd
        Dim PVNABBR As String = dao_lcn.fields.pvnabbr
        Dim lcnsid As String = DAO_LCN.fields.lcnsid
        Dim locationaddress As String = DAO_LCN.fields.LOCATION_ADDRESS_thanameplace



        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        TR_ID = bao_tran.insert_transection(_PROCESS_ID_DQ)

        dao_deeqt.fields.FK_LCN_IDA = _IDA_LCN
        dao_deeqt.fields.TR_ID = TR_ID
        dao_deeqt.fields.lcnsid = lcnsid
        'dao_deeqt.fields.pvncd = PVNCD
        dao_deeqt.fields.pvncd = 10
        dao_deeqt.fields.pvnabbr = PVNABBR
        dao_deeqt.fields.PROCESS_ID = _PROCESS_ID_DQ
        dao_deeqt.fields.lcnno = dao_lcn.fields.lcnno
        dao_deeqt.fields.lcntpcd = dao_lcn.fields.lcntpcd

        dao_deeqt.fields.thadrgnm = NAME_THAI.Text
        dao_deeqt.fields.engdrgnm = NAME_ENG.Text

        dao_deeqt.fields.STATUS_ID = 1
        dao_deeqt.fields.TYPE_TBN = 1
        dao_deeqt.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        dao_deeqt.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_deeqt.fields.DATE_YEAR = con_year(Date.Now.Year)
        dao_deeqt.fields.CREATE_DATE = Date.Now
        'dao_deeqt.fields.CREATE_BY = _CLS.THANM
        dao_deeqt.fields.CREATE_BY = _CLS.THANM
        If _CLS.THANM = Nothing Then
            dao_deeqt.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
        End If
        If Request.QueryString("staff") = 1 Then
            dao_deeqt.fields.INOFFICE_STAFF_ID = 1
            dao_deeqt.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
        End If

        Try
            If _SID = "2" Then
                dao_deeqt.fields.WHO_ID = 1
                DAO_WHO.fields.FK_IDA = dao_deeqt.fields.IDA
                DAO_WHO.Update()
                dao_deeqt.fields.FK_IDA_WHO = _WHO_IDA
            Else
                dao_deeqt.fields.WHO_ID = 0
            End If
        Catch ex As Exception

        End Try
        dao_deeqt.update()
        'Or DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = "-- กรุณาเลือก --"  Or DD_EATING_CONDITION_ID.SelectedValue = "-- กรุณาเลือก --"  'Or DD_STORAGE_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_PRO_AGE.SelectedValue = "-- กรุณาเลือก --" Or DD_SYNDROME_ID.SelectedValue = "-- กรุณาเลือก --"
        'If DD_TYPE_NAME.SelectedValue = "-- กรุณาเลือก --" Or DD_TYPE_SUB_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_CATEGORY_ID.SelectedValue = "-- กรุณาเลือก --" _
        'If DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" Then
        '    '    Or DD_EATTING_ID.SelectedValue = "-- กรุณาเลือก --" Or DDL_RECIPE_NAME.SelectedValue = "-- กรุณาเลือก --" _
        '    '    Or R_CONTRAINDICATION.SelectedValue = "" Or R_CAUTION.SelectedValue = "" Or R_ADV_REACTIVETION.SelectedValue = "" _
        '    '    Or DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --" Or R_WARNING.SelectedValue = "" Then

        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        '    'ElseIf R_WARNING.SelectedValue = 1 And DD_WARNING.SelectedValue = "-- กรุณาเลือก --" And DD_WARNING_SUB.SelectedValue = "-- กรุณาเลือก --" Then
        '    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน คำเตือน');", True)
        '    'ElseIf Request.QueryString("staff") = 1 And DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --" Then
        '    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกช่องทางการขาย');", True)
        'Else

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
            ' dao.fields.LCN_NAME = THANM
            dao.fields.LCN_NAME = NAME_TB.Text
            dao.fields.LCN_THANAMEPLACE = thanameplace
            dao.fields.TR_ID = TR_ID
            'dao.fields.TYPEPERSON = TP_PERSON

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

        Catch ex As Exception
            dao.fields.PERSON_AGE = txt_person_age.Text
        End Try
        Try
                dao.fields.NATIONALITY_PERSON_ID = DDL_NATION.SelectedValue
                dao.fields.NATIONALITY_PERSON = DDL_NATION.SelectedItem.Text
                dao.fields.NATIONALITY_PERSON_OTHER = txt_nation_person.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
                dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text
                dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
                dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
                dao.fields.CATEGORY_ID = DD_CATEGORY_ID.SelectedValue
                dao.fields.CATEGORY_NAME = DD_CATEGORY_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.CATEGORY_OUT_ID = DD_CATEGORY_OUT_ID.SelectedValue
                dao.fields.CATEGORY_OUT_NAME = DD_CATEGORY_OUT_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

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

            Try
                dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
                dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
            Catch ex As Exception

            End Try


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
            Try
                dao.fields.CONTRAINDICATION_ID = R_CONTRAINDICATION.SelectedValue
            Catch ex As Exception

            End Try
            Try
                If R_CONTRAINDICATION.SelectedValue = 1 Then
                    dao.fields.CONTRAINDICATION_NAME = CONTRAINDICATION_NAME.Text
                    R_CONTRAINDICATION_TEXT.Visible = True
                Else
                    dao.fields.CONTRAINDICATION_NAME = "ไม่มี"
                End If
            Catch ex As Exception

            End Try

            Try
                dao.fields.WARNING_TYPE_ID = R_WARNING.SelectedValue
            Catch ex As Exception

            End Try
            Try
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
            Catch ex As Exception

            End Try

            Try
                dao.fields.CAUTION_ID = R_CAUTION.SelectedValue
            Catch ex As Exception

            End Try
            Try
                If R_CAUTION.SelectedValue = 1 Then
                    dao.fields.CAUTION_NAME = CAUTION_NAME.Text
                    R_CAUTION_TEXT.Visible = True
                Else
                    dao.fields.CAUTION_NAME = "ไม่มี"
                End If
            Catch ex As Exception

            End Try

            Try
                dao.fields.ADV_REACTIVETION_ID = R_ADV_REACTIVETION.SelectedValue
            Catch ex As Exception

            End Try
            Try
                If R_ADV_REACTIVETION.SelectedValue = 1 Then
                    dao.fields.ADV_REACTIVETION_NAME = ADV_REACTIVETION_NAME.Text
                    R_ADV_REACTIVETION_TEXT.Visible = True
                Else
                    dao.fields.ADV_REACTIVETION_NAME = "ไม่มี"
                End If
            Catch ex As Exception

            End Try


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
            Try
                dao.fields.TR_ID_LCN = _TR_ID_LCN
            Catch ex As Exception

            End Try
            dao.fields.DATE_YEAR = con_year(Date.Now().Year())
            dao.insert()
            Try
                If Request.QueryString("staff") = 1 Then
                    Try
                        UC_ATTACH1.insert_TBN(TR_ID, _PROCESS_ID_DQ, dao_deeqt.fields.IDA, 6)
                        UC_ATTACH2.insert_TBN(TR_ID, _PROCESS_ID_DQ, dao_deeqt.fields.IDA, 8)
                        'chk_file1.Text = UC_ATTACH1.NAME
                        'chk_file2.Text = UC_ATTACH2.NAME
                        alert_summit("กรุณาอัพโหลดเอกสารแนบ", dao_deeqt.fields.IDA)
                    Catch ex As Exception
                        alert_summit("กรุณาอัพโหลดเอกสารแนบ", dao_deeqt.fields.IDA)
                    End Try
                Else

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

            Catch ex As Exception

            End Try


        'End If '''''''''''''''

        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        dt = bao.SP_drfrgnaddr_BY_frgncd(_FRGNCD)
        If _FRGNCD <> 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dao_pro As New DAO_DRUG.TB_DRRQT_PRODUCER
                dao_pro.fields.FK_IDA = _IDA_DQ
                dao_pro.fields.frgncd = _FRGNCD
                Try
                    dao_pro.fields.addr_ida = dr("addr_ida")
                Catch ex As Exception

                End Try
                Try
                    dao_pro.fields.FK_PRODUCER = dr("FK_PRODUCER")
                Catch ex As Exception

                End Try
                'Try
                '    dao_pro.fields.PRODUCER_WORK_TYPE = dr("PRODUCER_WORK_TYPE")
                'Catch ex As Exception

                'End Try
                'Try
                '    dao_pro.fields.REFERENCE_GMP = dr("REFERENCE_GMP")
                'Catch ex As Exception

                'End Try
                Try
                    dao_pro.fields.frgnlctcd = dr("frgnlctcd")
                Catch ex As Exception

                End Try
                dao_pro.insert()
            Next
            'dao.fields.PRODUCER_WORK_TYPE = ddl_work_type.SelectedValue
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
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        If Request.QueryString("staff") = 2 Then
            Response.Redirect("../HERB_TABEAN_STAFF_NEW/FRM_HERB_TABEAN_STAFF_TABEAN.aspx?TR_ID_LCN=" & dao_lcn.fields.TR_ID & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & dao_lcn.fields.IDA & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID & "&IDA_DQ=" & dao_deeqt.fields.IDA & "&PROCESS_ID_DQ=" & dao_deeqt.fields.PROCESS_ID & "&staff=" & "1")
        Else
            Response.Redirect("FRM_HERB_TABEAN.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ)
        End If
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
        url = "FRM_HERB_TABEAN_ADD_DETAIL_UPLOAD_FILE.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ & "&staff=" & Request.QueryString("staff") & "&SID=" & _SID
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
        If TREATMENT_AGE_YEAR.SelectedValue = "5" Then
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
            dao.fields.PROCESS_ID = _PROCESS_ID_DQ
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
    Protected Sub BTN_SEARCH_TN_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_TN.Click
        Dim dao As New DAO_CPN.TB_syslcnsnm

        If TXT_SEARCH_TN.Text IsNot Nothing Then
            Dim citizen_id As String = TXT_SEARCH_TN.Text
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
                    txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                ElseIf TYPE_PERSON = 99 Then
                    txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                        txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    Else
                        txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    End If
                End If
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End Try

            'Try
            '    lcnsid = obj.SYSLCNSNMs.lcnsid
            'Catch ex As Exception

            'End Try

            'prefixcd = obj.SYSLCNSNMs.prefixcd
            'prefixnm = obj.SYSLCNSNMs.prefixnm

            'ADDRESSPERSON.Text = obj.SYSLCTADDRs.Fulladdr
            'TEL.Text = obj.TEL
            'EMAIL.Text = obj.EMAIL
            'thaaddr = obj.SYSLCTADDRs.thaaddr
            'tharoom = obj.SYSLCTADDRs.room
            'thamu = obj.SYSLCTADDRs.mu
            'thafloor = obj.SYSLCTADDRs.floor
            'thasoi = obj.SYSLCTADDRs.thasoi
            'thabuilding = obj.SYSLCTADDRs.building
            'tharoad = obj.SYSLCTADDRs.tharoad
            'Try
            '    zipcode = obj.SYSLCTADDRs.zipcode
            'Catch ex As Exception

            'End Try
            'thathmblnm = obj.SYSLCTADDRs.thmblnm
            'thaamphrnm = obj.SYSLCTADDRs.amphrnm
            'thachngwtnm = obj.SYSLCTADDRs.chngwtnm
            'fax = obj.SYSLCTADDRs.fax

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
        End If
    End Sub
End Class
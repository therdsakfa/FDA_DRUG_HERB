Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_JJ_ADD_DETAIL
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _DD_HERB_NAME_ID As String = ""
    Private _PROCESS_JJ As String = ""
    Private _IDA As String = ""
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
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")
        _PROCESS_JJ = Request.QueryString("PROCESS_JJ")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try

    End Sub

    Shared PLACE_IDA As Integer = 0
    Shared PLACE_NAME As String = ""
    Shared PLACE_ADDRESS As String = ""
    Shared TXT_MENUFACTRUE_DETAIL As String = ""
    Shared IDA_ADDRESS As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            'bind_dd_age_unit()
            bind_data_ddl()
            bind_dd_stype()
            'bind_dd_syndrome()
            bind_dd_eatting()
            'bind_dd_manufac()
            bind_dd_storage()
            bind_dd_syndrome_detail()
            bind_dd_menufactrue_detail()
            bind_dd_how_use_detail()
            'TREATMENT_AGE_YEAR.SelectedValue = 1
            bind_rg()

            If _PROCESS_ID_LCN = 121 Then
                foreign.Visible = True
            Else
                foreign.Visible = False
            End If

        End If
    End Sub

    Public Sub bind_dd_age_unit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PRODUCT_AGE_JJ()

        'DD_PRO_AGE.DataSource = dt
        'DD_PRO_AGE.DataBind()
        'DD_PRO_AGE.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_data_ddl()
        If _PROCESS_JJ = 20301 Then
            DD_TYPE_SUB_ID.SelectedValue = 1
        ElseIf _PROCESS_JJ = 20302 Then
            DD_TYPE_SUB_ID.SelectedValue = 2
        ElseIf _PROCESS_JJ = 20303 Then
            DD_TYPE_SUB_ID.SelectedValue = 3
        ElseIf _PROCESS_JJ = 20304 Then
            DD_TYPE_SUB_ID.SelectedValue = 4
        End If

    End Sub

    Public Sub bind_dd_stype()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STYPE_JJ()

        DD_STYPE_ID.DataSource = dt
        DD_STYPE_ID.DataBind()
        DD_STYPE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    'Public Sub bind_dd_syndrome()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ()

    '    DD_SYNDROME_ID.DataSource = dt
    '    DD_SYNDROME_ID.DataBind()
    '    DD_SYNDROME_ID.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    Public Sub bind_dd_syndrome_detail()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_SYNDROME_DETAIL_JJ(_DD_HERB_NAME_ID, _PROCESS_JJ)
        Dim temp As String = ""
        For Each dr In dt.Rows
            If temp = "" Then
                temp = dr("SYNDROME_NAME")
            Else
                temp = temp & "," & dr("SYNDROME_NAME")
            End If
        Next
        TXT_SYNDROME_DETAIL.Text = temp
    End Sub

    Public Sub bind_dd_menufactrue_detail()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_MENUFACTRUE_DETAIL_JJ(_DD_HERB_NAME_ID)
        Dim temp As String = ""
        For Each dr In dt.Rows
            If temp = "" Then
                temp = dr("MANUFAC_NAME")
            Else
                temp = temp & "," & dr("MANUFAC_NAME")
            End If
        Next
        TXT_MENUFACTRUE_DETAIL = temp
    End Sub

    Public Sub bind_dd_how_use_detail()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_HOW_USE_JJ(_DD_HERB_NAME_ID)
        Dim temp As String = ""
        For Each dr In dt.Rows
            If temp = "" Then
                temp = dr("HOW_USE_NAME")
            Else
                temp = temp & "," & dr("HOW_USE_NAME")
            End If
        Next
        HOW_USE.Text = temp
    End Sub

    Public Sub bind_dd_eatting()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_JJ()

        DD_EATTING_ID.DataSource = dt
        DD_EATTING_ID.DataBind()
        DD_EATTING_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    'Public Sub bind_dd_manufac()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_MENUFACTRUE()

    '    DD_MANUFAC_ID.DataSource = dt
    '    DD_MANUFAC_ID.DataBind()
    '    DD_MANUFAC_ID.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    Public Sub bind_dd_storage()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STORAGE_JJ()

        DD_STORAGE_ID.DataSource = dt
        DD_STORAGE_ID.DataBind()
        DD_STORAGE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_frgn()
        RadGrid1.Rebind()
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

    'Protected Sub btn_choose_Click(sender As Object, e As EventArgs) Handles btn_choose.Click

    'For Each item2 As GridDataItem In RadGrid2.SelectedItems
    '    Dim PLACE_NAME As String = ""
    '    Dim PLACE_NAME_THAI As String = ""
    '    Dim PLACE_NAME_ENG As String = ""

    '    PLACE_NAME_THAI = item2("thafrgnnm").Text
    '    PLACE_NAME_ENG = item2("engfrgnnm").Text

    '    PLACE_NAME = PLACE_NAME_ENG & " " & PLACE_NAME_THAI
    '    txt_search.Text = PLACE_NAME
    'Next

    'For Each item3 As GridDataItem In RadGrid3.SelectedItems
    '    Dim PLACE_ADDRESS As String = ""
    '    PLACE_ADDRESS = item3("fulladdr2").Text

    '    txt_address.Text = PLACE_ADDRESS
    'Next

    'End Sub

    Public Sub bind_rg()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        'Dim thanm As String = dao_lcn.fields.thanm
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_DETAIL_JJ

        dao.GetdatabyID_DD_HERB_NAME_ID(_DD_HERB_NAME_ID, _PROCESS_JJ)

        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try

        Dim THANM As String = dao_lcn.fields.thanm
        If thanm = "" Or thanm Is Nothing Then
            thanm = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm & " " & dao_customer.fields.thalnm
        Else
            thanm = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        End If

        'If _CLS.THANM_CUSTOMER = Nothing Then
        '    NAME_JJ.Text = thanm
        'Else
        '    NAME_JJ.Text = _CLS.THANM_CUSTOMER
        'End If
        'NAME_JJ.Text = _CLS.THANM
        NAME_JJ.Text = THANM
        NAME_PLACE_JJ.Text = locationaddress

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
        If TYPE_PERSON = 1 Then
            data_show3.Visible = False
        ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 11 Or TYPE_PERSON = 3 Or TYPE_PERSON = 4 Then
            data_show3.Visible = True
            txt_agent99.Text = BSN_THAIFULLNAME
        End If

        DD_TYPE_NAME.SelectedValue = dao.fields.TYPE_ID
        DD_TYPE_SUB_ID.SelectedValue = dao.fields.TYPE_SUB_ID
        DD_CATEGORY_ID.SelectedValue = CATEGORY_ID
        NAME_THAI.Text = dao.fields.NAME_THAI
        NAME_ENG.Text = dao.fields.NAME_ENG
        NAME_OTHER.Text = dao.fields.NAME_OTHER
        DD_STYPE_ID.SelectedValue = dao.fields.STYPE_ID
        RECIPE_NAME.Text = dao.fields.RECIPE_NAME
        ACCOUNT_NO.Text = dao.fields.ACCOUNT_NO
        ARTICLE_NO.Text = dao.fields.ARTICLE_NO
        PRODUCT_JJ.Text = dao.fields.PRODUCT_JJ
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

        'DD_SYNDROME_ID.SelectedValue = dao.fields.SYNDROME_ID
        PROPERTIES.Text = dao.fields.PROPERTIES
        SIZE_USE.Text = dao.fields.SIZE_USE
        'HOW_USE.Text = dao.fields.HOW_USE
        DD_EATTING_ID.SelectedValue = dao.fields.EATTING_ID
        R_EATING_CONDITION.SelectedValue = dao.fields.EATING_CONDITION_ID
        If dao.fields.EATING_CONDITION_ID = 1 Then
            EATING_CONDITION_NAME.Text = dao.fields.EATING_CONDITION_NAME
            R_EATING_CONDITION_TEXT.Visible = False
        End If

        DD_STORAGE_ID.SelectedValue = dao.fields.STORAGE_ID

        'TREATMENT.Text = dao.fields.TREATMENT
        If dao.fields.TREATMENT_AGE = 3 Then
            TREATMENT_AGE_MONTH_SUB.Enabled = False
        Else
            TREATMENT_AGE_MONTH_SUB.Enabled = True
        End If
        TREATMENT_AGE_YEAR.SelectedValue = dao.fields.TREATMENT_AGE
        R_CONTRAINDICATION.SelectedValue = dao.fields.CONTRAINDICATION_ID
        If dao.fields.CONTRAINDICATION_ID = 1 Then
            CONTRAINDICATION_NAME.Text = dao.fields.CONTRAINDICATION_NAME
            R_CONTRAINDICATION_TEXT.Visible = True
        End If
        R_WARNING.SelectedValue = dao.fields.WARNING_ID
        If dao.fields.WARNING_ID = 1 Then
            WARNING_NAME.Text = dao.fields.WARNING_NAME
            R_WARNING_TEXT.Visible = True
        End If
        R_CAUTION.SelectedValue = dao.fields.CAUTION_ID
        If dao.fields.CAUTION_ID = 1 Then
            CAUTION_NAME.Text = dao.fields.CAUTION_NAME
            R_CAUTION_TEXT.Visible = True
        End If
        R_ADV_REACTIVETION.SelectedValue = dao.fields.ADV_REACTIVETION_ID
        If dao.fields.ADV_REACTIVETION_ID = 1 Then
            ADV_REACTIVETION_NAME.Text = dao.fields.ADV_REACTIVETION_NAME
            R_ADV_REACTIVETION_TEXT.Visible = True
        End If
        DD_SALE_CHANNEL.SelectedValue = dao.fields.SALE_CHANNEL_ID
        NOTE.Text = dao.fields.NOTE

    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)

        Dim lcnno_auto As String = dao_lcn.fields.lcnno
        Dim lcnno_auto_sub As String = Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)


        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao.fields.CITIZEN_ID_AUTHORIZE)

        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)

        Dim dao_esub As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        Dim dao_pfx2 As New DAO_CPN.TB_sysprefix
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
            dao_pfx2.Getdata_byid(dao_customer.fields.prefixcd)
        Catch ex As Exception

        End Try
        Try
            dao_esub.GetDataby_LCN_IDA(_IDA_LCN)
        Catch ex As Exception

        End Try
        Dim THANM As String = dao_lcn.fields.thanm
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

        'Dim locnnodisplay As String = dao_lcn.fields.lcntpcd & " " & dao_lcn.fields.pvnabbr & " " & lcnno_auto_sub
        Dim locnnodisplay As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim PVNCD As Integer = dao_lcn.fields.pvncd
        'Dim thanm As String = dao_lcn.fields.thanm
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        If txt_person_age.Text <> "" And DDL_NATION.SelectedValue <> 0 Then
            If NATURE.Text <> "" Then
                'If NATURE.Text <> "" And DD_PRO_AGE.SelectedValue <> "-- กรุณาเลือก --" And TREATMENT_AGE.Text <> "" Then
                If TREATMENT_AGE_MONTH_SUB.SelectedValue <> 0 Or TREATMENT_AGE_YEAR.SelectedValue <> 0 Then
                    If dao.fields.IDA = 0 Then

                        dao.fields.LCN_ID = _IDA_LCN
                        dao.fields.LCNNO = locnnodisplay

                        If Request.QueryString("staff") = 1 Then
                            dao.fields.NAME_JJ = _CLS.THANM_CUSTOMER
                        Else
                            dao.fields.NAME_JJ = _CLS.THANM
                        End If

                        dao.fields.NAME_PLACE_JJ = locationaddress
                        '_CLS.THANM_CUSTOMER
                        dao.fields.LCN_NAME = thanm
                        dao.fields.LCN_THANAMEPLACE = thanameplace

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
                        dao.fields.NAME_THAI = NAME_THAI.Text
                        dao.fields.NAME_THAI_R = NAME_THAI_R.Text
                        dao.fields.NAME_THAIFULL = NAME_THAI.Text & " " & NAME_THAI_R.Text
                        dao.fields.NAME_ENG = NAME_ENG.Text
                        dao.fields.NAME_OTHER = NAME_OTHER.Text
                        dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
                        dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
                        dao.fields.RECIPE_NAME = RECIPE_NAME.Text
                        dao.fields.ACCOUNT_NO = ACCOUNT_NO.Text
                        dao.fields.ARTICLE_NO = ARTICLE_NO.Text
                        dao.fields.PRODUCT_JJ = PRODUCT_JJ.Text
                        dao.fields.NATURE = NATURE.Text

                        'dao.fields.MANUFAC_ID = DD_MANUFAC_ID.SelectedValue
                        'dao.fields.MANUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text
                        Try
                            dao.fields.MANUFAC_NAME_DETAIL = TXT_MENUFACTRUE_DETAIL
                        Catch ex As Exception

                        End Try

                        dao.fields.AGENT_99 = txt_agent99.Text
                        dao.fields.PERSON_AGE = txt_person_age.Text
                        Try
                            dao.fields.NATIONALITY_PERSON_ID = DDL_NATION.SelectedValue
                            dao.fields.NATIONALITY_PERSON = DDL_NATION.SelectedItem.Text
                            dao.fields.NATIONALITY_PERSON_OTHER = txt_nation_person.Text
                        Catch ex As Exception

                        End Try

                        'dao.fields.PRODUCT_PROCESS = PRODUCT_PROCESS.Text

                        'dao.fields.WEIGHT_TABLE_CAP = WEIGHT_TABLE_CAP.Text
                        'dao.fields.WEIGHT_TABLE_CAP_UNIT_ID = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue
                        'dao.fields.WEIGHT_TABLE_CAP_UNIT_NAME = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text
                        dao.fields.SIZE_PACK = SIZE_PACK.Text

                        'dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
                        'dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
                        dao.fields.SYNDROME_NAME_DETAIL = TXT_SYNDROME_DETAIL.Text
                        dao.fields.PROPERTIES = PROPERTIES.Text
                        dao.fields.SIZE_USE = SIZE_USE.Text
                        dao.fields.HOW_USE = HOW_USE.Text
                        dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
                        dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text

                        dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
                        If R_EATING_CONDITION.SelectedValue = 1 Then
                            dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
                            R_EATING_CONDITION_TEXT.Visible = True
                        Else
                            dao.fields.EATING_CONDITION_NAME = "ไม่มี"
                        End If

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
                        dao.fields.WARNING_ID = R_WARNING.SelectedValue
                        If R_WARNING.SelectedValue = 1 Then
                            dao.fields.WARNING_NAME = WARNING_NAME.Text
                            R_WARNING_TEXT.Visible = True
                        Else
                            dao.fields.WARNING_NAME = "ไม่มี"
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
                        'dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
                        dao.fields.CREATE_DATE = Date.Now
                        'dao.fields.CREATE_BY = _CLS.THANM
                        dao.fields.CREATE_BY = _CLS.THANM
                            If _CLS.THANM = Nothing Then
                                dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
                            End If

                            dao.fields.MENU_GROUP = _MENU_GROUP
                        Try
                            dao.fields.IDA_LCT = _IDA_LCT
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.TR_ID_LCN = _TR_ID_LCN
                        Catch ex As Exception

                        End Try

                        dao.fields.IDA_LCN = _IDA_LCN
                        dao.fields.DD_HERB_NAME_ID = _DD_HERB_NAME_ID
                        dao.fields.DDHERB = _PROCESS_JJ

                        dao.fields.PVNCD = PVNCD
                        dao.fields.DATE_YEAR = con_year(Date.Now().Year())

                        If Request.QueryString("staff") = 1 Then
                            dao.fields.INOFFICE_STAFF_ID = 1
                            dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
                            dao.fields.CREATE_BY_ID = 1
                        Else
                            dao.fields.CREATE_BY_ID = 0
                        End If
                        dao.insert()

                    Else
                        dao.GetdatabyID_IDA(_IDA)

                        dao.fields.LCN_ID = _IDA_LCN
                        dao.fields.LCNNO = locnnodisplay
                        dao.fields.LCN_NAME = thanm
                        dao.fields.LCN_THANAMEPLACE = thanameplace


                        If Request.QueryString("staff") = 1 Then
                            dao.fields.NAME_JJ = _CLS.THANM_CUSTOMER
                        Else
                            dao.fields.NAME_JJ = _CLS.THANM
                        End If

                        dao.fields.NAME_PLACE_JJ = locationaddress
                        dao.fields.LCN_NAME = _CLS.THANM_CUSTOMER

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
                        dao.fields.NAME_THAI = NAME_THAI.Text
                        dao.fields.NAME_ENG = NAME_ENG.Text
                        dao.fields.NAME_OTHER = NAME_OTHER.Text
                        dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
                        dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
                        dao.fields.RECIPE_NAME = RECIPE_NAME.Text
                        dao.fields.ACCOUNT_NO = ACCOUNT_NO.Text
                        dao.fields.ARTICLE_NO = ARTICLE_NO.Text
                        dao.fields.PRODUCT_JJ = PRODUCT_JJ.Text
                        dao.fields.NATURE = NATURE.Text

                        'dao.fields.MANUFAC_ID = DD_MANUFAC_ID.SelectedValue
                        'dao.fields.MANUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text
                        Try
                            dao.fields.MANUFAC_NAME_DETAIL = TXT_MENUFACTRUE_DETAIL
                        Catch ex As Exception

                        End Try


                        'dao.fields.PRODUCT_PROCESS = PRODUCT_PROCESS.Text

                        'dao.fields.WEIGHT_TABLE_CAP = WEIGHT_TABLE_CAP.Text
                        'dao.fields.WEIGHT_TABLE_CAP_UNIT_ID = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue
                        'dao.fields.WEIGHT_TABLE_CAP_UNIT_NAME = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text
                        dao.fields.SIZE_PACK = SIZE_PACK.Text

                        'dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
                        'dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
                        dao.fields.SYNDROME_NAME_DETAIL = TXT_SYNDROME_DETAIL.Text
                        dao.fields.PROPERTIES = PROPERTIES.Text
                        dao.fields.SIZE_USE = SIZE_USE.Text
                        dao.fields.HOW_USE = HOW_USE.Text
                        dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
                        dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text

                        dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
                        If R_EATING_CONDITION.SelectedValue = 1 Then
                            dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
                            R_EATING_CONDITION_TEXT.Visible = True
                        Else
                            dao.fields.EATING_CONDITION_NAME = "ไม่มี"
                        End If

                        dao.fields.STORAGE_ID = DD_STORAGE_ID.SelectedValue
                        dao.fields.STORAGE_NAME = DD_STORAGE_ID.SelectedItem.Text
                        'dao.fields.TREATMENT = TREATMENT.Text
                        'dao.fields.TREATMENT_AGE = TREATMENT_AGE_YEAR.SelectedValue
                        'dao.fields.TREATMENT_AGE_MONth = TREATMENT_AGE_MONTH.SelectedValue
                        'dao.fields.TREATMENT_AGE_ID = DD_PRO_AGE.SelectedValue
                        'dao.fields.TREATMENT_AGE_NAME = DD_PRO_AGE.SelectedItem.Text

                        dao.fields.CONTRAINDICATION_ID = R_CONTRAINDICATION.SelectedValue
                        If R_CONTRAINDICATION.SelectedValue = 1 Then
                            dao.fields.CONTRAINDICATION_NAME = CONTRAINDICATION_NAME.Text
                            R_CONTRAINDICATION_TEXT.Visible = True
                        Else
                            dao.fields.CONTRAINDICATION_NAME = "ไม่มี"
                        End If
                        dao.fields.WARNING_ID = R_WARNING.SelectedValue
                        If R_WARNING.SelectedValue = 1 Then
                            dao.fields.WARNING_NAME = WARNING_NAME.Text
                            R_WARNING_TEXT.Visible = True
                        Else
                            dao.fields.WARNING_NAME = "ไม่มี"
                        End If
                        dao.fields.CAUTION_ID = R_CAUTION.SelectedValue
                        If R_CAUTION.SelectedValue = 1 Then
                            dao.fields.CAUTION_NAME = CAUTION_NAME.Text

                        Else
                            dao.fields.CAUTION_NAME = "ไม่มี"
                            R_CAUTION_TEXT.Visible = True

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

                        dao.fields.STATUS_ID = 5
                        dao.fields.ACTIVEFACT = 1
                        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                        'dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
                        dao.fields.CREATE_DATE = Date.Now
                        dao.fields.CREATE_BY = _CLS.THANM
                            If _CLS.THANM = Nothing Then
                                dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
                            End If
                            dao.fields.MENU_GROUP = _MENU_GROUP
                        Try
                            dao.fields.IDA_LCT = _IDA_LCT
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.TR_ID_LCN = _TR_ID_LCN
                        Catch ex As Exception

                        End Try
                        dao.fields.IDA_LCN = _IDA_LCN
                        dao.fields.DD_HERB_NAME_ID = _DD_HERB_NAME_ID
                        dao.fields.DDHERB = _PROCESS_JJ

                        Dim staff_idsid As String = ""
                        Try
                            staff_idsid = Request.QueryString("staff")
                        Catch ex As Exception

                        End Try
                        If Request.QueryString("staff") = 1 Then
                            dao.fields.INOFFICE_STAFF_ID = 1
                            dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
                        End If
                        dao.Update()

                    End If

                    dao.GetdatabyID_IDA(_IDA)

                    ''เก็บสะถานนะทั้ง ระบบไว้
                    Dim TR_ID As String = ""
                    Dim bao_tran As New BAO_TRANSECTION
                    'TR_ID = bao_tran.insert_transection_jj(_PROCESS_JJ, dao.fields.IDA, dao.fields.STATUS_ID)
                    'เลขดำเนินการ รันใหม่
                    Dim bao_gen As New BAO.GenNumber
                    TR_ID = bao_gen.GEN_NO_JJ(con_year(Date.Now.Year), dao.fields.PVNCD, _PROCESS_JJ, dao.fields.IDA, _IDA_LCN)
                    dao.fields.TR_ID_JJ = TR_ID
                    dao.Update()

                    Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
                    dao_up_mas.GetdatabyID_TYPE(1)
                    For Each dao_up_mas.fields In dao_up_mas.datas
                        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                        dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                        dao_up.fields.TR_ID = TR_ID
                        dao_up.fields.FK_IDA = dao.fields.IDA
                        dao_up.fields.PROCESS_ID = _PROCESS_JJ
                        dao_up.fields.FK_IDA_LCN = _IDA_LCN
                        dao_up.fields.TYPE = 1
                        dao_up.insert()
                    Next
                    alert_summit("โปรดตรวจสอบสูตรและกรรมวิธีการผลิต", dao.fields.IDA)

                Else
                    alert_nature("กรุณากรอกข้อมูลอายุการเก็บรักษา")
                End If
            Else
                alert_nature("กรุณากรอกข้อมูล ลักษณะยา และ อายุ หน่วยอายุ")
            End If
        Else
            alert_nature("กรุณากรอกข้อมูล อายุ และ สัญชาติ")
        End If
        'Response.Redirect(Request.Url.AbsoluteUri)
        'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _DDHERB & "&IDA=" & _IDA)
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
    End Sub
    Protected Sub R_EATING_CONDITION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles R_EATING_CONDITION.SelectedIndexChanged
        If R_EATING_CONDITION.SelectedValue = 1 Then
            R_EATING_CONDITION_TEXT.Visible = True
        Else
            R_EATING_CONDITION_TEXT.Visible = False
        End If
    End Sub
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
            R_WARNING_TEXT.Visible = True
        Else
            R_WARNING_TEXT.Visible = False
        End If
    End Sub
    Protected Sub R_ADV_REACTIVETION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles R_ADV_REACTIVETION.SelectedIndexChanged
        If R_ADV_REACTIVETION.SelectedValue = 1 Then
            R_ADV_REACTIVETION_TEXT.Visible = True
        Else
            R_ADV_REACTIVETION_TEXT.Visible = False
        End If
    End Sub
    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_JJ_SUB_PACKSIZE(_DD_HERB_NAME_ID, _PROCESS_JJ)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub

    Sub alert_summit(ByVal text As String, ByVal ida_jj As Integer)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_JJ_ADD_DETAIL_CHKACC.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & ida_jj & "&staff=" & Request.QueryString("staff") & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Sub alert_nature(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Protected Sub TREATMENT_AGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TREATMENT_AGE_YEAR.SelectedIndexChanged
        If TREATMENT_AGE_YEAR.SelectedValue = "3" Then
            TREATMENT_AGE_MONTH_SUB.ClearSelection()
            TREATMENT_AGE_MONTH_SUB.Enabled = False
        Else
            TREATMENT_AGE_MONTH_SUB.Enabled = True
        End If
    End Sub

    'Protected Sub DD_PRO_AGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_PRO_AGE.SelectedIndexChanged
    '    If DD_PRO_AGE.SelectedValue = 1 Then
    '        div_hide.Style.Add("display", "block")
    '        div_hide2.Style.Add("display", "block")
    '        TREATMENT_AGE_YEAR.Style.Add("display", "block")
    '        TREATMENT_AGE_MONTH.Style.Add("display", "none")
    '        'TREATMENT_AGE_MONTH.Visible = True
    '    Else
    '        div_hide.Style.Add("display", "none")
    '        div_hide2.Style.Add("display", "none")
    '        TREATMENT_AGE_MONTH.Style.Add("display", "block")
    '        TREATMENT_AGE_YEAR.Style.Add("display", "none")
    '    End If
    'End Sub
    Protected Sub DDL_NATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_NATION.SelectedIndexChanged
        If DDL_NATION.SelectedValue = 1 Then
            data_show1.Visible = False
            data_show2.Visible = False
        Else
            data_show1.Visible = True
            data_show2.Visible = True
        End If
    End Sub
End Class
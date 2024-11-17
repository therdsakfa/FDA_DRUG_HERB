Imports System.Globalization
Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_JJ_EDIT_REQUEST
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
            bind_dd_stype()
            'bind_dd_syndrome()
            bind_dd_eatting()
            'bind_dd_manufac()
            bind_dd_storage()
            bind_dd_syndrome_detail()
            bind_dd_menufactrue_detail()
            bind_dd_how_use_detail()
            'TREATMENT_AGE_YEAR.SelectedValue = 1
            Get_Data_By_Process()
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
    Sub Get_Data_By_Process()
        If _PROCESS_JJ = 20304 Then
            NAME_THAI.ReadOnly = False
            NAME_THAI.BorderStyle = BorderStyle.NotSet
            NAME_ENG.ReadOnly = False
            NAME_ENG.BorderStyle = BorderStyle.NotSet
            NAME_OTHER.ReadOnly = False
            NAME_OTHER.BorderStyle = BorderStyle.NotSet
            RECIPE_NAME.ReadOnly = False
            RECIPE_NAME.BorderStyle = BorderStyle.NotSet
            ACCOUNT_NO.ReadOnly = False
            ACCOUNT_NO.BorderStyle = BorderStyle.NotSet
            ARTICLE_NO.ReadOnly = False
            ARTICLE_NO.BorderStyle = BorderStyle.NotSet
            PRODUCT_JJ.ReadOnly = False
            PRODUCT_JJ.BorderStyle = BorderStyle.NotSet
            SIZE_PACK.ReadOnly = False
            SIZE_PACK.BorderStyle = BorderStyle.NotSet
            TXT_SYNDROME_DETAIL.ReadOnly = False
            TXT_SYNDROME_DETAIL.BorderStyle = BorderStyle.NotSet
            PROPERTIES.ReadOnly = False
            PROPERTIES.BorderStyle = BorderStyle.NotSet
            SIZE_USE.ReadOnly = False
            SIZE_USE.BorderStyle = BorderStyle.NotSet
            HOW_USE.ReadOnly = False
            HOW_USE.BorderStyle = BorderStyle.NotSet
            NOTE.ReadOnly = False
            NOTE.BorderStyle = BorderStyle.NotSet
            ADV_REACTIVETION_NAME.ReadOnly = False
            ADV_REACTIVETION_NAME.BorderStyle = BorderStyle.NotSet
            CONTRAINDICATION_NAME.ReadOnly = False
            CONTRAINDICATION_NAME.BorderStyle = BorderStyle.NotSet
            CAUTION_NAME.ReadOnly = False
            CAUTION_NAME.BorderStyle = BorderStyle.NotSet
            WARNING_NAME.ReadOnly = False
            WARNING_NAME.BorderStyle = BorderStyle.NotSet

            DD_TYPE_NAME.Enabled = True
            DD_STYPE_ID.Enabled = True
            DD_EATTING_ID.Enabled = True
            DD_SALE_CHANNEL.Enabled = True
            DD_STORAGE_ID.Enabled = True
            R_EATING_CONDITION.Enabled = True
            R_CONTRAINDICATION.Enabled = True
            R_WARNING.Enabled = True
            R_CAUTION.Enabled = True
            R_ADV_REACTIVETION.Enabled = True
            'R_ADV_REACTIVETION.Enabled = True
        End If
    End Sub

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
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        Dim thanm As String = dao_lcn.fields.thanm
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_DETAIL_JJ

        dao.GetdatabyID_DD_HERB_NAME_ID(_DD_HERB_NAME_ID, _PROCESS_JJ)
        If dao_jj.fields.ACTIVEFACT Then
            NAME_JJ.Text = dao_jj.fields.NAME_JJ
            NAME_PLACE_JJ.Text = locationaddress
            txt_agent99.Text = dao_jj.fields.AGENT_99
            txt_agent99_id.Text = dao_jj.fields.AGENT_99_IDEN
            txt_person_age.Text = dao_jj.fields.PERSON_AGE
            If dao_jj.fields.NATIONALITY_PERSON_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.NATIONALITY_PERSON_ID) Then
                DDL_NATION.SelectedValue = dao_jj.fields.NATIONALITY_PERSON_ID
                txt_nation_person.Text = dao_jj.fields.NATIONALITY_PERSON_OTHER
            End If
            If dao_jj.fields.TYPE_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.TYPE_ID) Then DD_TYPE_NAME.SelectedValue = dao_jj.fields.TYPE_ID
            If dao_jj.fields.TYPE_SUB_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.TYPE_SUB_ID) Then DD_TYPE_SUB_ID.SelectedValue = dao_jj.fields.TYPE_SUB_ID
            DD_CATEGORY_ID.SelectedValue = CATEGORY_ID
            NAME_THAI.Text = dao_jj.fields.NAME_THAI
            NAME_ENG.Text = dao_jj.fields.NAME_ENG
            NAME_OTHER.Text = dao_jj.fields.NAME_OTHER
            If dao_jj.fields.STYPE_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.STYPE_ID) Then DD_STYPE_ID.SelectedValue = dao_jj.fields.STYPE_ID
            RECIPE_NAME.Text = dao_jj.fields.RECIPE_NAME
            If dao_jj.fields.ACCOUNT_NO IsNot Nothing AndAlso IsNumeric(dao_jj.fields.ACCOUNT_NO) Then ACCOUNT_NO.Text = dao_jj.fields.ACCOUNT_NO
            If dao_jj.fields.ARTICLE_NO IsNot Nothing AndAlso IsNumeric(dao_jj.fields.ARTICLE_NO) Then ARTICLE_NO.Text = dao_jj.fields.ARTICLE_NO
            PRODUCT_JJ.Text = dao_jj.fields.PRODUCT_JJ
            NATURE.Text = dao_jj.fields.NATURE
            'PRODUCT_PROCESS.Text = dao.fields.PRODUCT_PROCESS
            'DD_MANUFAC_ID.SelectedValue = dao.fields.MANUFAC_ID

            Try
                'WEIGHT_TABLE_CAP.Text = dao.fields.WEIGHT_TABLE_CAP
                'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = dao.fields.WEIGHT_TABLE_CAP_UNIT_ID
                SIZE_PACK.Text = dao_jj.fields.SIZE_PACK
            Catch ex As Exception

            End Try

            Try
                'DD_PRO_AGE.SelectedValue = 1
            Catch ex As Exception

            End Try

            'DD_SYNDROME_ID.SelectedValue = dao.fields.SYNDROME_ID
            PROPERTIES.Text = dao_jj.fields.PROPERTIES
            SIZE_USE.Text = dao_jj.fields.SIZE_USE
            'HOW_USE.Text = dao.fields.HOW_USE
            If dao_jj.fields.EATTING_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.EATTING_ID) Then DD_EATTING_ID.SelectedValue = dao_jj.fields.EATTING_ID
            If dao_jj.fields.EATING_CONDITION_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.EATING_CONDITION_ID) Then R_EATING_CONDITION.SelectedValue = dao_jj.fields.EATING_CONDITION_ID
            If dao_jj.fields.EATING_CONDITION_ID = 1 Then
                EATING_CONDITION_NAME.Text = dao.fields.EATING_CONDITION_NAME
                R_EATING_CONDITION_TEXT.Visible = True
            End If
            If dao_jj.fields.STORAGE_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.STORAGE_ID) Then DD_STORAGE_ID.SelectedValue = dao_jj.fields.STORAGE_ID
            'TREATMENT.Text = dao.fields.TREATMENT
            If dao_jj.fields.TREATMENT_AGE IsNot Nothing AndAlso IsNumeric(dao_jj.fields.TREATMENT_AGE) Then
                If dao_jj.fields.TREATMENT_AGE = 3 Then
                    TREATMENT_AGE_MONTH_SUB.Enabled = False
                Else
                    TREATMENT_AGE_MONTH_SUB.Enabled = True
                End If
            End If
            If dao_jj.fields.TREATMENT_AGE_MONTH IsNot Nothing AndAlso IsNumeric(dao_jj.fields.TREATMENT_AGE_MONTH) Then TREATMENT_AGE_MONTH_SUB.SelectedValue = dao_jj.fields.TREATMENT_AGE_MONTH
            If dao_jj.fields.TREATMENT_AGE IsNot Nothing AndAlso IsNumeric(dao_jj.fields.TREATMENT_AGE) Then TREATMENT_AGE_YEAR.SelectedValue = dao_jj.fields.TREATMENT_AGE
            NATURE.Text = dao_jj.fields.NATURE
            If dao_jj.fields.CONTRAINDICATION_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.CONTRAINDICATION_ID) Then
                R_CONTRAINDICATION.SelectedValue = dao_jj.fields.CONTRAINDICATION_ID
                If dao_jj.fields.CONTRAINDICATION_ID = 1 Then
                    CONTRAINDICATION_NAME.Text = dao_jj.fields.CONTRAINDICATION_NAME
                    R_CONTRAINDICATION_TEXT.Visible = True
                End If
            End If
            If dao_jj.fields.WARNING_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.WARNING_ID) Then
                R_WARNING.SelectedValue = dao_jj.fields.WARNING_ID
                If dao_jj.fields.WARNING_ID = 1 Then
                    WARNING_NAME.Text = dao.fields.WARNING_NAME
                    R_WARNING_TEXT.Visible = True
                End If
            End If
            If dao_jj.fields.CAUTION_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.CAUTION_ID) Then
                R_CAUTION.SelectedValue = dao_jj.fields.CAUTION_ID
                If dao_jj.fields.CAUTION_ID = 1 Then
                    CAUTION_NAME.Text = dao_jj.fields.CAUTION_NAME
                    R_CAUTION_TEXT.Visible = True
                End If
            End If
            If dao_jj.fields.ADV_REACTIVETION_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.ADV_REACTIVETION_ID) Then
                R_ADV_REACTIVETION.SelectedValue = dao_jj.fields.ADV_REACTIVETION_ID
                If dao_jj.fields.ADV_REACTIVETION_ID = 1 Then
                    ADV_REACTIVETION_NAME.Text = dao_jj.fields.ADV_REACTIVETION_NAME
                    R_ADV_REACTIVETION_TEXT.Visible = True
                End If
            End If
            If dao_jj.fields.SALE_CHANNEL_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.SALE_CHANNEL_ID) Then DD_SALE_CHANNEL.SelectedValue = dao_jj.fields.SALE_CHANNEL_ID
            NOTE.Text = dao.fields.NOTE
        Else
            NAME_JJ.Text = dao_jj.fields.NAME_JJ
            NAME_PLACE_JJ.Text = locationaddress
            txt_agent99.Text = dao_jj.fields.AGENT_99
            txt_agent99_id.Text = dao_jj.fields.AGENT_99_IDEN
            txt_person_age.Text = dao_jj.fields.PERSON_AGE
            If dao_jj.fields.NATIONALITY_PERSON_ID IsNot Nothing AndAlso IsNumeric(dao_jj.fields.NATIONALITY_PERSON_ID) Then
                DDL_NATION.SelectedValue = dao_jj.fields.NATIONALITY_PERSON_ID
                txt_nation_person.Text = dao_jj.fields.NATIONALITY_PERSON_OTHER
            End If
            If dao.fields.TYPE_ID IsNot Nothing AndAlso IsNumeric(dao.fields.TYPE_ID) Then DD_TYPE_NAME.SelectedValue = dao.fields.TYPE_ID
            If dao.fields.TYPE_SUB_ID IsNot Nothing AndAlso IsNumeric(dao.fields.TYPE_SUB_ID) Then DD_TYPE_SUB_ID.SelectedValue = dao.fields.TYPE_SUB_ID
            DD_CATEGORY_ID.SelectedValue = CATEGORY_ID
            NAME_THAI.Text = dao.fields.NAME_THAI
            NAME_ENG.Text = dao.fields.NAME_ENG
            NAME_OTHER.Text = dao.fields.NAME_OTHER
            If dao.fields.STYPE_ID IsNot Nothing AndAlso IsNumeric(dao.fields.STYPE_ID) Then DD_STYPE_ID.SelectedValue = dao.fields.STYPE_ID
            RECIPE_NAME.Text = dao.fields.RECIPE_NAME
            If dao.fields.ACCOUNT_NO IsNot Nothing AndAlso IsNumeric(dao.fields.ACCOUNT_NO) Then ACCOUNT_NO.Text = dao.fields.ACCOUNT_NO
            If dao.fields.ARTICLE_NO IsNot Nothing AndAlso IsNumeric(dao.fields.ARTICLE_NO) Then ARTICLE_NO.Text = dao.fields.ARTICLE_NO
            PRODUCT_JJ.Text = dao_jj.fields.PRODUCT_JJ
            NATURE.Text = dao_jj.fields.NATURE
            'PRODUCT_PROCESS.Text = dao.fields.PRODUCT_PROCESS
            'DD_MANUFAC_ID.SelectedValue = dao.fields.MANUFAC_ID

            Try
                'WEIGHT_TABLE_CAP.Text = dao.fields.WEIGHT_TABLE_CAP
                'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = dao.fields.WEIGHT_TABLE_CAP_UNIT_ID
                SIZE_PACK.Text = dao_jj.fields.SIZE_PACK
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
            If dao.fields.EATTING_ID IsNot Nothing AndAlso IsNumeric(dao.fields.EATTING_ID) Then DD_EATTING_ID.SelectedValue = dao.fields.EATTING_ID
            If dao.fields.EATING_CONDITION_ID IsNot Nothing AndAlso IsNumeric(dao.fields.EATING_CONDITION_ID) Then R_EATING_CONDITION.SelectedValue = dao.fields.EATING_CONDITION_ID
            If dao.fields.EATING_CONDITION_ID = 1 Then
                EATING_CONDITION_NAME.Text = dao.fields.EATING_CONDITION_NAME
                R_EATING_CONDITION_TEXT.Visible = True
            End If
            If dao.fields.STORAGE_ID IsNot Nothing AndAlso IsNumeric(dao.fields.STORAGE_ID) Then DD_STORAGE_ID.SelectedValue = dao.fields.STORAGE_ID
            'TREATMENT.Text = dao.fields.TREATMENT
            If dao.fields.TREATMENT_AGE IsNot Nothing AndAlso IsNumeric(dao.fields.TREATMENT_AGE) Then
                If dao_jj.fields.TREATMENT_AGE = 3 Then
                    TREATMENT_AGE_MONTH_SUB.Enabled = False
                Else
                    TREATMENT_AGE_MONTH_SUB.Enabled = True
                End If
            End If
            If dao_jj.fields.TREATMENT_AGE_MONTH IsNot Nothing AndAlso IsNumeric(dao_jj.fields.TREATMENT_AGE_MONTH) Then TREATMENT_AGE_MONTH_SUB.SelectedValue = dao_jj.fields.TREATMENT_AGE_MONTH
            If dao_jj.fields.TREATMENT_AGE IsNot Nothing AndAlso IsNumeric(dao_jj.fields.TREATMENT_AGE) Then TREATMENT_AGE_YEAR.SelectedValue = dao_jj.fields.TREATMENT_AGE
            NATURE.Text = dao_jj.fields.NATURE
            If dao.fields.CONTRAINDICATION_ID IsNot Nothing AndAlso IsNumeric(dao.fields.CONTRAINDICATION_ID) Then
                R_CONTRAINDICATION.SelectedValue = dao.fields.CONTRAINDICATION_ID
                If dao.fields.CONTRAINDICATION_ID = 1 Then
                    CONTRAINDICATION_NAME.Text = dao.fields.CONTRAINDICATION_NAME
                    R_CONTRAINDICATION_TEXT.Visible = True
                End If
            End If
            If dao.fields.WARNING_ID IsNot Nothing AndAlso IsNumeric(dao.fields.ARTICLE_NO) Then
                R_WARNING.SelectedValue = dao.fields.WARNING_ID
                If dao.fields.WARNING_ID = 1 Then
                    WARNING_NAME.Text = dao.fields.WARNING_NAME
                    R_WARNING_TEXT.Visible = True
                End If
            End If
            If dao.fields.CAUTION_ID IsNot Nothing AndAlso IsNumeric(dao.fields.ARTICLE_NO) Then
                R_CAUTION.SelectedValue = dao.fields.CAUTION_ID
                If dao.fields.CAUTION_ID = 1 Then
                    CAUTION_NAME.Text = dao.fields.CAUTION_NAME
                    R_CAUTION_TEXT.Visible = True
                End If
            End If
            If dao.fields.ADV_REACTIVETION_ID IsNot Nothing AndAlso IsNumeric(dao.fields.ADV_REACTIVETION_ID) Then
                R_ADV_REACTIVETION.SelectedValue = dao.fields.ADV_REACTIVETION_ID
                If dao.fields.ADV_REACTIVETION_ID = 1 Then
                    ADV_REACTIVETION_NAME.Text = dao.fields.ADV_REACTIVETION_NAME
                    R_ADV_REACTIVETION_TEXT.Visible = True
                End If
            End If
            If dao.fields.SALE_CHANNEL_ID IsNot Nothing AndAlso IsNumeric(dao.fields.SALE_CHANNEL_ID) Then DD_SALE_CHANNEL.SelectedValue = dao.fields.SALE_CHANNEL_ID
            NOTE.Text = dao.fields.NOTE
        End If
        If Request.QueryString("staff") = 1 Then
            BTN_SEARCH_AG99.Visible = True
        Else
            BTN_SEARCH_AG99.Visible = False
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)

        Dim lcnno_auto As String = dao_lcn.fields.lcnno
        Dim lcnno_auto_sub As String = Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)

        'Dim locnnodisplay As String = dao_lcn.fields.lcntpcd & " " & dao_lcn.fields.pvnabbr & " " & lcnno_auto_sub
        Dim locnnodisplay As String = dao_lcn.fields.LCNNO_DISPLAY_NEW
        Dim thanameplace As String = dao_lcn.fields.thanameplace
        Dim CATEGORY_ID As String = dao_lcn.fields.PROCESS_ID
        Dim PVNCD As Integer = dao_lcn.fields.pvncd
        Dim thanm As String = dao_lcn.fields.thanm
        Dim locationaddress As String = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

        If NATURE.Text <> "" And TREATMENT_AGE_YEAR.SelectedValue <> "" Or TREATMENT_AGE_MONTH_SUB.SelectedValue <> "" Then
            'If NATURE.Text <> "" And DD_PRO_AGE.SelectedValue <> "-- กรุณาเลือก --" And TREATMENT_AGE.Text <> "" Then
            If dao.fields.IDA = 0 Then

                dao.fields.LCN_ID = _IDA_LCN
                dao.fields.LCNNO = locnnodisplay
                dao.fields.NAME_JJ = _CLS.THANM
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
                dao.fields.MANUFAC_NAME_DETAIL = TXT_MENUFACTRUE_DETAIL

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
                dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
                dao.fields.CREATE_DATE = Date.Now
                dao.fields.CREATE_BY = _CLS.THANM

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
                End If
                dao.insert()

            Else
                dao.GetdatabyID_IDA(_IDA)

                'dao.fields.LCN_ID = _IDA_LCN
                'dao.fields.LCNNO = locnnodisplay
                'dao.fields.LCN_NAME = thanm
                'dao.fields.LCN_THANAMEPLACE = thanameplace

                'dao.fields.NAME_JJ = _CLS.THANM
                'dao.fields.NAME_PLACE_JJ = locationaddress
                'dao.fields.LCN_NAME = _CLS.THANM_CUSTOMER

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
                If Not String.IsNullOrEmpty(DD_STYPE_ID.SelectedValue) AndAlso DD_STYPE_ID.SelectedValue <> "-- กรุณาเลือก --" Then
                    dao.fields.STYPE_ID = Convert.ToInt32(DD_STYPE_ID.SelectedValue)
                End If
                dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
                dao.fields.RECIPE_NAME = RECIPE_NAME.Text
                Try
                    dao.fields.ACCOUNT_NO = ACCOUNT_NO.Text

                Catch ex As Exception

                End Try
                Try
                    dao.fields.ARTICLE_NO = ARTICLE_NO.Text
                Catch ex As Exception

                End Try
                dao.fields.PRODUCT_JJ = PRODUCT_JJ.Text
                dao.fields.NATURE = NATURE.Text

                'dao.fields.MANUFAC_ID = DD_MANUFAC_ID.SelectedValue
                'dao.fields.MANUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text
                dao.fields.MANUFAC_NAME_DETAIL = TXT_MENUFACTRUE_DETAIL

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
                Try
                    dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
                    dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
                    If R_EATING_CONDITION.SelectedValue = 1 Then
                        dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
                        R_EATING_CONDITION_TEXT.Visible = True
                    Else
                        dao.fields.EATING_CONDITION_NAME = "ไม่มี"
                    End If
                Catch ex As Exception

                End Try
                Try
                    dao.fields.STORAGE_ID = DD_STORAGE_ID.SelectedValue
                    dao.fields.STORAGE_NAME = DD_STORAGE_ID.SelectedItem.Text
                Catch ex As Exception

                End Try
                'dao.fields.TREATMENT = TREATMENT.Text
                'dao.fields.TREATMENT_AGE = TREATMENT_AGE_YEAR.SelectedValue
                'dao.fields.TREATMENT_AGE_MONth = TREATMENT_AGE_MONTH.SelectedValue
                'dao.fields.TREATMENT_AGE_ID = DD_PRO_AGE.SelectedValue
                'dao.fields.TREATMENT_AGE_NAME = DD_PRO_AGE.SelectedItem.Text
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
                    If R_CONTRAINDICATION.SelectedValue = 1 Then
                        dao.fields.CONTRAINDICATION_NAME = CONTRAINDICATION_NAME.Text
                        R_CONTRAINDICATION_TEXT.Visible = True
                    Else
                        dao.fields.CONTRAINDICATION_NAME = "ไม่มี"
                    End If
                Catch ex As Exception

                End Try
                Try
                    dao.fields.WARNING_ID = R_WARNING.SelectedValue
                    If R_WARNING.SelectedValue = 1 Then
                        dao.fields.WARNING_NAME = WARNING_NAME.Text
                        R_WARNING_TEXT.Visible = True
                    Else
                        dao.fields.WARNING_NAME = "ไม่มี"
                    End If
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CAUTION_ID = R_CAUTION.SelectedValue
                    If R_CAUTION.SelectedValue = 1 Then
                        dao.fields.CAUTION_NAME = CAUTION_NAME.Text

                    Else
                        dao.fields.CAUTION_NAME = "ไม่มี"
                        R_CAUTION_TEXT.Visible = True

                    End If
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ADV_REACTIVETION_ID = R_ADV_REACTIVETION.SelectedValue
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

                'dao.fields.STATUS_ID = 5
                dao.fields.ACTIVEFACT = 1
                dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
                dao.fields.CREATE_DATE = Date.Now
                If _MENU_GROUP <> "" Then
                    dao.fields.MENU_GROUP = _MENU_GROUP
                End If
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
                dao.fields.AGENT_99_IDEN = txt_agent99_id.Text
                dao.fields.AGENT_99 = txt_agent99.Text
                Try
                    dao.fields.NATIONALITY_PERSON_ID = DDL_NATION.SelectedValue
                    dao.fields.NATIONALITY_PERSON = DDL_NATION.SelectedItem.Text
                    dao.fields.NATIONALITY_PERSON_OTHER = DDL_NATION.SelectedItem.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.PERSON_AGE = txt_person_age.Text
                Catch ex As Exception

                End Try
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
            gen_xml_jj1()
            alert("บันทึกข้อมูลคำข้อแล้ว")
        Else
            alert_nature("กรุณากรอกข้อมูล ลักษณะยา และ อายุ หน่วยอายุ")
        End If
        'Response.Redirect(Request.Url.AbsoluteUri)
        'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _DDHERB & "&IDA=" & _IDA)
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _PROCESS_JJ)
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
        url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & ida_jj & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Sub alert_nature(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub TREATMENT_AGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TREATMENT_AGE_YEAR.SelectedIndexChanged
        If TREATMENT_AGE_YEAR.SelectedValue = "3" Then
            TREATMENT_AGE_MONTH_SUB.ClearSelection()
            TREATMENT_AGE_MONTH_SUB.Enabled = False
        Else
            TREATMENT_AGE_MONTH_SUB.Enabled = True
        End If
    End Sub
    Sub gen_xml_jj1()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
        TB_JJ = XML.gen_xml(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_PROCESS_JJ, dao.fields.STATUS_ID, "จจ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _PROCESS_JJ, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _PROCESS_JJ, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_JJ, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
    Protected Sub BTN_SEARCH_TN_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_AG99.Click
        Dim dao As New DAO_CPN.TB_syslcnsnm
        If Request.QueryString("staff") = 1 Then
            If txt_agent99_id.Text IsNot Nothing Then
                Dim citizen_id As String = txt_agent99_id.Text
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
                        txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    ElseIf TYPE_PERSON = 99 Then
                        txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm
                    Else
                        If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                            txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                        Else
                            txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & " " & obj.SYSLCNSNMs.thanm
                        End If
                    End If
                Catch ex As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
                End Try
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
            End If
        Else
            alert_nature("สิทธ์ของท่านไม่สามารถค้นหาข้อมูลได้")
        End If
    End Sub
End Class
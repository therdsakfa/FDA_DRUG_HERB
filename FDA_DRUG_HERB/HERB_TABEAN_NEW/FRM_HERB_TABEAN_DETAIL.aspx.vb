Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_DETAIL
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA_DQ As String = ""
    Private _PROCESS_ID_DQ As String = ""
    Private _TR_ID As String = ""

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
        _TR_ID = Request.QueryString("TR_ID")

    End Sub

    Shared PLACE_IDA As Integer = 0
    Shared PLACE_NAME As String = ""
    Shared PLACE_ADDRESS As String = ""
    Shared IDA_ADDRESS As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

            bind_dd_age_unit()
            bind_dd_stype()
            bind_dd_syndrome()
            bind_dd_eatting()
            bind_dd_eatting_condition()
            bind_dd_warning()
            bind_dd_storage()
            'bind_dd_manufac()
            'bind_dd_pack_1()
            'bind_dd_pack_2()
            'bind_dd_pack_3()
            'bind_dd_unit_1()
            'bind_dd_unit_2()
            'bind_dd_unit_3()

            bind_rg()

            If _PROCESS_ID_LCN = 121 Then
                foreign.Visible = True
            Else
                foreign.Visible = False
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

    Public Sub bind_dd_warning_sub(ByVal fk_ida As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_WARNING_SUB(fk_ida)

        DD_WARNING_SUB.DataSource = dt
        DD_WARNING_SUB.DataBind()
        DD_WARNING_SUB.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_age_unit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PRODUCT_AGE_JJ()

        DD_PRO_AGE.DataSource = dt
        DD_PRO_AGE.DataBind()
        DD_PRO_AGE.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_stype()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STYPE_JJ()

        DD_STYPE_ID.DataSource = dt
        DD_STYPE_ID.DataBind()
        DD_STYPE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    'Public Sub bind_dd_pack_1()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_PRIMARY()

    '    DD_PCAK_1.DataSource = dt
    '    DD_PCAK_1.DataBind()
    '    DD_PCAK_1.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    'Public Sub bind_dd_pack_2()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_SECONDARY()

    '    DD_PCAK_2.DataSource = dt
    '    DD_PCAK_2.DataBind()
    '    DD_PCAK_2.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    'Public Sub bind_dd_pack_3()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_TERTIRY()

    '    DD_PCAK_3.DataSource = dt
    '    DD_PCAK_3.DataBind()
    '    DD_PCAK_3.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    'Public Sub bind_dd_unit_1()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_PRIMARY()

    '    DD_UNIT_1.DataSource = dt
    '    DD_UNIT_1.DataBind()
    '    DD_UNIT_1.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    'Public Sub bind_dd_unit_2()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_SCONDARY()

    '    DD_UNIT_2.DataSource = dt
    '    DD_UNIT_2.DataBind()
    '    DD_UNIT_2.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    'Public Sub bind_dd_unit_3()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_TERTIARY()

    '    DD_UNIT_3.DataSource = dt
    '    DD_UNIT_3.DataBind()
    '    DD_UNIT_3.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

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

    Public Sub bind_rg()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)

        Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean_herb.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Try
            txt_search_ida.Text = dao_tabean_herb.fields.FOREIGN_NAME_ID
            txt_search.Text = dao_tabean_herb.fields.FOREIGN_NAME
            txt_address_ida.Text = dao_tabean_herb.fields.FOREIGN_NAME_PLACE_ID
            txt_address.Text = dao_tabean_herb.fields.FOREIGN_NAME_PLACE
        Catch ex As Exception

        End Try

        NAME_TB.Text = dao_tabean_herb.fields.NAME_JJ
        NAME_PLACE_TB.Text = dao_tabean_herb.fields.NAME_PLACE_JJ

        DD_TYPE_NAME.SelectedValue = dao_tabean_herb.fields.TYPE_ID
        DD_TYPE_NAME.SelectedItem.Text = dao_tabean_herb.fields.TYPE_NAME
        DD_TYPE_SUB_ID.SelectedValue = dao_tabean_herb.fields.TYPE_SUB_ID
        DD_TYPE_SUB_ID.SelectedItem.Text = dao_tabean_herb.fields.TYPE_SUB_NAME
        DD_CATEGORY_ID.SelectedValue = dao_tabean_herb.fields.CATEGORY_ID
        DD_CATEGORY_ID.SelectedItem.Text = dao_tabean_herb.fields.CATEGORY_NAME
        DD_CATEGORY_OUT_ID.SelectedValue = dao_tabean_herb.fields.CATEGORY_OUT_ID
        DD_CATEGORY_OUT_ID.SelectedItem.Text = dao_tabean_herb.fields.CATEGORY_OUT_NAME

        NAME_THAI.Text = dao_tabean_herb.fields.NAME_THAI
        NAME_ENG.Text = dao_tabean_herb.fields.NAME_ENG
        NAME_OTHER.Text = dao_tabean_herb.fields.NAME_OTHER
        DD_STYPE_ID.SelectedValue = dao_tabean_herb.fields.STYPE_ID
        DD_STYPE_ID.SelectedItem.Text = dao_tabean_herb.fields.STYPE_NAME
        SIZE_PACK.Text = dao_tabean_herb.fields.SIZE_PACK
        NATURE.Text = dao_tabean_herb.fields.NATURE
        'WEIGHT_TABLE_CAP.Text = dao_tabean_herb.fields.WEIGHT_TABLE_CAP
        'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = dao_tabean_herb.fields.WEIGHT_TABLE_CAP_UNIT_ID
        'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text = dao_tabean_herb.fields.WEIGHT_TABLE_CAP_UNIT_NAME
        Try
            DD_SYNDROME_ID.SelectedValue = dao_tabean_herb.fields.SYNDROME_ID
            DD_SYNDROME_ID.SelectedItem.Text = dao_tabean_herb.fields.SYNDROME_NAME
        Catch ex As Exception

        End Try

        PROPERTIES.Text = dao_tabean_herb.fields.PROPERTIES
        SIZE_USE.Text = dao_tabean_herb.fields.SIZE_USE
        HOW_USE.Text = dao_tabean_herb.fields.HOW_USE

        DD_EATTING_ID.SelectedValue = dao_tabean_herb.fields.EATTING_ID
        DD_EATTING_ID.SelectedItem.Text = dao_tabean_herb.fields.EATTING_NAME
        If DD_EATTING_ID.SelectedValue = 9 Then
            EATTING_TEXT.Text = dao_tabean_herb.fields.EATTING_NAME_DETAIL
            R_EATTING_TEXT.Visible = True
        End If

        DD_EATING_CONDITION_ID.SelectedValue = dao_tabean_herb.fields.EATING_CONDITION_ID
        DD_EATING_CONDITION_ID.SelectedItem.Text = dao_tabean_herb.fields.EATING_CONDITION_NAME
        If DD_EATING_CONDITION_ID.SelectedValue = 14 Then
            EATING_CONDITION_NAME.Text = dao_tabean_herb.fields.EATING_CONDITION_NAME_DETAIL
            R_EATING_CONDITION_TEXT.Visible = True
        End If
        Try
            DD_STORAGE_ID.SelectedValue = dao_tabean_herb.fields.STORAGE_ID
        Catch ex As Exception

        End Try

        'TREATMENT.Text = dao_tabean_herb.fields.TREATMENT
        TREATMENT_AGE.Text = dao_tabean_herb.fields.TREATMENT_AGE
        Try
            DD_PRO_AGE.SelectedValue = dao_tabean_herb.fields.TREATMENT_AGE_ID
            DD_PRO_AGE.SelectedItem.Text = dao_tabean_herb.fields.TREATMENT_AGE_NAME
        Catch ex As Exception

        End Try


        R_CONTRAINDICATION.SelectedValue = dao_tabean_herb.fields.CONTRAINDICATION_ID
        If R_CONTRAINDICATION.SelectedValue = 1 Then
            CONTRAINDICATION_NAME.Text = dao_tabean_herb.fields.CONTRAINDICATION_NAME
            R_CONTRAINDICATION_TEXT.Visible = True
        End If

        R_WARNING.SelectedValue = dao_tabean_herb.fields.WARNING_TYPE_ID
        If R_WARNING.SelectedValue = 1 Then
            DD_WARNING.Visible = True
        Else
            DD_WARNING.Visible = False
        End If

        Try
            DD_WARNING.SelectedValue = dao_tabean_herb.fields.WARNING_ID
            If DD_WARNING.SelectedValue = 1 Then
                DD_WARNING_SUB.Visible = True
                R_WARNING_TEXT.Visible = False
                bind_dd_warning_sub(dao_tabean_herb.fields.WARNING_SUB_ID)
                DD_WARNING_SUB.SelectedValue = dao_tabean_herb.fields.WARNING_SUB_ID
                DD_WARNING_SUB.SelectedItem.Text = dao_tabean_herb.fields.WARNING_SUB_NAME
            Else
                WARNING_NAME.Text = dao_tabean_herb.fields.WARNING_NAME
                R_WARNING_TEXT.Visible = True
                DD_WARNING_SUB.Visible = False
            End If
        Catch ex As Exception

        End Try

        R_CAUTION.SelectedValue = dao_tabean_herb.fields.CAUTION_ID
        If R_CAUTION.SelectedValue = 1 Then
            CAUTION_NAME.Text = dao_tabean_herb.fields.CAUTION_NAME
            R_CAUTION_TEXT.Visible = True
        End If

        R_ADV_REACTIVETION.SelectedValue = dao_tabean_herb.fields.ADV_REACTIVETION_ID
        If R_ADV_REACTIVETION.SelectedValue = 1 Then
            ADV_REACTIVETION_NAME.Text = dao_tabean_herb.fields.ADV_REACTIVETION_NAME
            R_ADV_REACTIVETION_TEXT.Visible = True
        End If

        DD_SALE_CHANNEL.SelectedValue = dao_tabean_herb.fields.SALE_CHANNEL_ID
        DD_SALE_CHANNEL.SelectedItem.Text = dao_tabean_herb.fields.SALE_CHANNEL_NAME
        NOTE.Text = dao_tabean_herb.fields.NOTE

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("FRM_HERB_TABEAN.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ)
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

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_deeqt.fields.TR_ID, 7, _PROCESS_ID_DQ, _IDA_DQ)

        Return dt
    End Function

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Function bind_data_uploadfile_6()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 6, _PROCESS_ID_DQ, _IDA_DQ)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile_6()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Function bind_data_uploadfile_8()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 8, _PROCESS_ID_DQ, _IDA_DQ)

        Return dt
    End Function

    Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
        RadGrid5.DataSource = bind_data_uploadfile_8()
    End Sub

    Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

End Class
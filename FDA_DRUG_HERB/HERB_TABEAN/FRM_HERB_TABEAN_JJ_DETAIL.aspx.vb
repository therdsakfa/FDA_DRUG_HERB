Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_JJ_DETAIL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _DD_HERB_NAME_ID As String = ""
    Private _PROCESS_JJ As String = ""
    Private _TR_ID_JJ As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA As String = ""

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
        _TR_ID_JJ = Request.QueryString("TR_ID_JJ")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _IDA = Request.QueryString("IDA")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'bind_dd_age_unit()
            bind_dd_stype()
            'bind_dd_syndrome()
            bind_dd_eatting()
            'bind_dd_manufac()
            bind_dd_storage()

            bind_rg()

            If _PROCESS_ID_LCN = 121 Then
                foreign.Visible = True
            Else
                foreign.Visible = False
            End If
        End If
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

    'Public Sub bind_dd_syndrome()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ()

    '    DD_SYNDROME_ID.DataSource = dt
    '    DD_SYNDROME_ID.DataBind()
    '    DD_SYNDROME_ID.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    Public Sub bind_dd_eatting()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_JJ()

        DD_EATTING_ID.DataSource = dt
        DD_EATTING_ID.DataBind()
        DD_EATTING_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_storage()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STORAGE_JJ()

        DD_STORAGE_ID.DataSource = dt
        DD_STORAGE_ID.DataBind()
        DD_STORAGE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    'Public Sub bind_dd_manufac()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_DD_MAS_TABEAN_HERB_MENUFACTRUE()

    '    DD_MANUFAC_ID.DataSource = dt
    '    DD_MANUFAC_ID.DataBind()
    '    DD_MANUFAC_ID.Items.Insert(0, "-- กรุณาเลือก --")

    'End Sub

    'Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
    '    Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ

    '    If dao.fields.IDA = 0 Then
    '        dao.fields.NAME_JJ = _CLS.THANM
    '        dao.fields.LCN_NAME = _CLS.THANM_CUSTOMER
    '        dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
    '        dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text
    '        dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
    '        dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
    '        dao.fields.CATEGORY_ID = DD_CATEGORY_ID.SelectedValue
    '        dao.fields.CATEGORY_NAME = DD_CATEGORY_ID.SelectedItem.Text
    '        dao.fields.NAME_THAI = NAME_THAI.Text
    '        dao.fields.NAME_ENG = NAME_ENG.Text
    '        dao.fields.NAME_OTHER = NAME_OTHER.Text
    '        dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
    '        dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
    '        dao.fields.RECIPE_NAME = RECIPE_NAME.Text
    '        dao.fields.ACCOUNT_NO = ACCOUNT_NO.Text
    '        dao.fields.ARTICLE_NO = ARTICLE_NO.Text
    '        dao.fields.PRODUCT_JJ = PRODUCT_JJ.Text
    '        dao.fields.NATURE = NATURE.Text
    '        dao.fields.PRODUCT_PROCESS = PRODUCT_PROCESS.Text

    '        dao.fields.WEIGHT_TABLE_CAP = WEIGHT_TABLE_CAP.Text
    '        dao.fields.WEIGHT_TABLE_CAP_UNIT_ID = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue
    '        dao.fields.WEIGHT_TABLE_CAP_UNIT_NAME = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text
    '        dao.fields.SIZE_PACK = SIZE_PACK.Text

    '        dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
    '        dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
    '        dao.fields.PROPERTIES = PROPERTIES.Text
    '        dao.fields.SIZE_USE = SIZE_USE.Text
    '        dao.fields.HOW_USE = HOW_USE.Text
    '        dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
    '        dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text

    '        dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
    '        If R_EATING_CONDITION.SelectedValue = 1 Then
    '            dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
    '            R_EATING_CONDITION_TEXT.Visible = True
    '        End If
    '        dao.fields.TREATMENT = TREATMENT.Text
    '        dao.fields.TREATMENT_AGE = TREATMENT_AGE.Text
    '        dao.fields.CONTRAINDICATION_ID = R_CONTRAINDICATION.SelectedValue
    '        If R_CONTRAINDICATION.SelectedValue = 1 Then
    '            dao.fields.CONTRAINDICATION_NAME = CONTRAINDICATION_NAME.Text
    '            R_CONTRAINDICATION_TEXT.Visible = True
    '        End If
    '        dao.fields.WARNING_ID = R_WARNING.SelectedValue
    '        If R_WARNING.SelectedValue = 1 Then
    '            dao.fields.WARNING_NAME = WARNING_NAME.Text
    '            R_WARNING_TEXT.Visible = True
    '        End If
    '        dao.fields.CAUTION_ID = R_CAUTION.SelectedValue
    '        If R_CAUTION.SelectedValue = 1 Then
    '            dao.fields.CAUTION_NAME = CAUTION_NAME.Text
    '            R_CAUTION_TEXT.Visible = True
    '        End If
    '        dao.fields.ADV_REACTIVETION_ID = R_ADV_REACTIVETION.SelectedValue
    '        If R_ADV_REACTIVETION.SelectedValue = 1 Then
    '            dao.fields.ADV_REACTIVETION_NAME = ADV_REACTIVETION_NAME.Text
    '            R_ADV_REACTIVETION_TEXT.Visible = True
    '        End If
    '        dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
    '        dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
    '        dao.fields.NOTE = NOTE.Text

    '        dao.fields.STATUS_ID = 2
    '        dao.fields.ACTIVEFACT = 1
    '        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
    '        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
    '        dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
    '        dao.fields.CREATE_DATE = Date.Now

    '        dao.fields.LCNNO = _CLS.LCNNO
    '        dao.fields.LCN_ADDR = "ที่อยู่ทดสอบ"
    '        dao.fields.MENU_GROUP = _MENU_GROUP
    '        Try
    '            dao.fields.IDA_LCT = _IDA_LCT
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            dao.fields.TR_ID_LCN = _TR_ID_LCN
    '        Catch ex As Exception

    '        End Try

    '        dao.fields.IDA_LCN = _IDA_LCN
    '        dao.fields.DD_HERB_NAME_ID = _DD_HERB_NAME_ID
    '        dao.fields.DDHERB = _DDHERB

    '        dao.insert()

    '        Response.Redirect("FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _DDHERB)
    '    Else
    '        dao.GetdatabyID_DD_HERB_NAME_ID(_DD_HERB_NAME_ID)

    '        dao.fields.NAME_JJ = _CLS.THANM
    '        dao.fields.LCN_NAME = _CLS.THANM_CUSTOMER
    '        dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
    '        dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text
    '        dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
    '        dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
    '        dao.fields.CATEGORY_ID = DD_CATEGORY_ID.SelectedValue
    '        dao.fields.CATEGORY_NAME = DD_CATEGORY_ID.SelectedItem.Text
    '        dao.fields.NAME_THAI = NAME_THAI.Text
    '        dao.fields.NAME_ENG = NAME_ENG.Text
    '        dao.fields.NAME_OTHER = NAME_OTHER.Text
    '        dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
    '        dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
    '        dao.fields.RECIPE_NAME = RECIPE_NAME.Text
    '        dao.fields.ACCOUNT_NO = ACCOUNT_NO.Text
    '        dao.fields.ARTICLE_NO = ARTICLE_NO.Text
    '        dao.fields.PRODUCT_JJ = PRODUCT_JJ.Text
    '        dao.fields.NATURE = NATURE.Text
    '        dao.fields.PRODUCT_PROCESS = PRODUCT_PROCESS.Text

    '        dao.fields.WEIGHT_TABLE_CAP = WEIGHT_TABLE_CAP.Text
    '        dao.fields.WEIGHT_TABLE_CAP_UNIT_ID = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue
    '        dao.fields.WEIGHT_TABLE_CAP_UNIT_NAME = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text
    '        dao.fields.SIZE_PACK = SIZE_PACK.Text

    '        dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
    '        dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
    '        dao.fields.PROPERTIES = PROPERTIES.Text
    '        dao.fields.SIZE_USE = SIZE_USE.Text
    '        dao.fields.HOW_USE = HOW_USE.Text
    '        dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
    '        dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text

    '        dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
    '        If R_EATING_CONDITION.SelectedValue = 1 Then
    '            dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
    '            R_EATING_CONDITION_TEXT.Visible = True
    '        End If
    '        dao.fields.TREATMENT = TREATMENT.Text
    '        dao.fields.TREATMENT_AGE = TREATMENT_AGE.Text
    '        dao.fields.CONTRAINDICATION_ID = R_CONTRAINDICATION.SelectedValue
    '        If R_CONTRAINDICATION.SelectedValue = 1 Then
    '            dao.fields.CONTRAINDICATION_NAME = CONTRAINDICATION_NAME.Text
    '            R_CONTRAINDICATION_TEXT.Visible = True
    '        End If
    '        dao.fields.WARNING_ID = R_WARNING.SelectedValue
    '        If R_WARNING.SelectedValue = 1 Then
    '            dao.fields.WARNING_NAME = WARNING_NAME.Text
    '            R_WARNING_TEXT.Visible = True
    '        End If
    '        dao.fields.CAUTION_ID = R_CAUTION.SelectedValue
    '        If R_CAUTION.SelectedValue = 1 Then
    '            dao.fields.CAUTION_NAME = CAUTION_NAME.Text
    '        Else
    '            R_CAUTION_TEXT.Visible = True
    '        End If
    '        dao.fields.ADV_REACTIVETION_ID = R_ADV_REACTIVETION.SelectedValue
    '        If R_ADV_REACTIVETION.SelectedValue = 1 Then
    '            dao.fields.ADV_REACTIVETION_NAME = ADV_REACTIVETION_NAME.Text
    '            R_ADV_REACTIVETION_TEXT.Visible = True
    '        End If
    '        dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
    '        dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
    '        dao.fields.NOTE = NOTE.Text

    '        dao.fields.STATUS_ID = 2
    '        dao.fields.ACTIVEFACT = 1
    '        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
    '        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
    '        dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
    '        dao.fields.CREATE_DATE = Date.Now

    '        dao.fields.LCNNO = _CLS.LCNNO
    '        dao.fields.LCN_ADDR = "ที่อยู่ทดสอบ"
    '        dao.fields.MENU_GROUP = _MENU_GROUP
    '        Try
    '            dao.fields.IDA_LCT = _IDA_LCT
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            dao.fields.TR_ID_LCN = _TR_ID_LCN
    '        Catch ex As Exception

    '        End Try
    '        dao.fields.IDA_LCN = _IDA_LCN
    '        dao.fields.DD_HERB_NAME_ID = _DD_HERB_NAME_ID
    '        dao.fields.DDHERB = _DDHERB

    '        dao.Update()

    '        Response.Redirect("FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _DDHERB)
    '    End If

    'End Sub

    Public Sub bind_rg()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        Try
            dao.GetdatabyID_IDA_DD_HERB_NAME_ID(_IDA, _DD_HERB_NAME_ID)

            NAME_JJ.Text = dao.fields.NAME_JJ
            NAME_PLACE_JJ.Text = dao.fields.LCN_NAME
            DD_TYPE_NAME.SelectedValue = dao.fields.TYPE_ID
            DD_TYPE_SUB_ID.SelectedValue = dao.fields.TYPE_SUB_ID
            DD_CATEGORY_ID.SelectedValue = dao.fields.CATEGORY_ID

            Try
                txt_search.Text = dao.fields.FOREIGN_NAME
                txt_address.Text = dao.fields.FOREIGN_NAME_PLACE
            Catch ex As Exception

            End Try

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
            'dao.fields.MANUFAC_NAME_DETAIL = TXT_MENUFACTRUE_DETAIL
            Try
                'WEIGHT_TABLE_CAP.Text = dao.fields.WEIGHT_TABLE_CAP
                'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = dao.fields.WEIGHT_TABLE_CAP_UNIT_ID
                SIZE_PACK.Text = dao.fields.SIZE_PACK
            Catch ex As Exception

            End Try

            'DD_SYNDROME_ID.SelectedValue = dao.fields.SYNDROME_ID
            TXT_SYNDROME_DETAIL.Text = dao.fields.SYNDROME_NAME_DETAIL

            PROPERTIES.Text = dao.fields.PROPERTIES
            SIZE_USE.Text = dao.fields.SIZE_USE
            HOW_USE.Text = dao.fields.HOW_USE
            DD_EATTING_ID.SelectedValue = dao.fields.EATTING_ID
            R_EATING_CONDITION.SelectedValue = dao.fields.EATING_CONDITION_ID
            If dao.fields.EATING_CONDITION_ID = 1 Then
                EATING_CONDITION_NAME.Text = dao.fields.EATING_CONDITION_NAME
                R_EATING_CONDITION_TEXT.Visible = True
            End If

            DD_STORAGE_ID.SelectedValue = dao.fields.STORAGE_ID
            'TREATMENT.Text = dao.fields.TREATMENT
            Try
                Dim TREATMENT_AGE As Integer = 0
                Dim TREATMENT_AGE_MONTH As Integer = 0
                If dao.fields.TREATMENT_AGE Is Nothing Then
                    TREATMENT_AGE = 0
                Else
                    TREATMENT_AGE = dao.fields.TREATMENT_AGE
                End If
                If dao.fields.TREATMENT_AGE_MONTH Is Nothing Or dao.fields.TREATMENT_AGE_MONTH = "-" Then
                    TREATMENT_AGE_MONTH = 0
                Else
                    TREATMENT_AGE_MONTH = dao.fields.TREATMENT_AGE_MONTH
                End If

                TREATMENT_AGE_YEAR.SelectedValue = TREATMENT_AGE
                TREATMENT_AGE_MONTH_SUB.SelectedValue = TREATMENT_AGE_MONTH

                'Dim dao_mas_product_age As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_PRODUCT_AGE_JJ
                'dao_mas_product_age.GetdatabyID_PRO_AGE()
                'DD_PRO_AGE.SelectedValue = dao.fields.TREATMENT_AGE_ID
                'DD_PRO_AGE.SelectedItem.Text = dao.fields.TREATMENT_AGE_NAME
            Catch ex As Exception

            End Try

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
        Catch ex As Exception

        End Try

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

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID_JJ, 1, _PROCESS_JJ, _IDA)

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
            H.NavigateUrl = "FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Function bind_data_file_recipe_production()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ(_DD_HERB_NAME_ID, _PROCESS_JJ)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_file_recipe_production()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim DD_HERB_NAME_PRODUCT_ID As Integer = item("DD_HERB_NAME_PRODUCT_ID").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_JJ_RECIPE_PRODUCT_PREVIEW_FILE.aspx?IDA=" & IDA

        End If

    End Sub
    Protected Sub TREATMENT_AGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TREATMENT_AGE_YEAR.SelectedIndexChanged
        If TREATMENT_AGE_YEAR.SelectedValue = "3" Then
            TREATMENT_AGE_MONTH_SUB.ClearSelection()
            TREATMENT_AGE_MONTH_SUB.Enabled = False
        Else
            TREATMENT_AGE_MONTH_SUB.Enabled = True
        End If
    End Sub
    'Protected Sub btn_download_jj1_Click(sender As Object, e As EventArgs) Handles btn_download_jj1.Click
    '    Response.ContentType = "Application/pdf"
    '    Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf")
    '    Response.TransmitFile(Server.MapPath("../PDF/จจ๑.PDF"))
    'End Sub
End Class
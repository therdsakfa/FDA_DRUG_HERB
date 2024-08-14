Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_MASTER_JJ_DETAIL
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _HERB_ID As String = ""
    Private _PROCESS_ID As String = ""
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

        _IDA = Request.QueryString("IDA")
        _HERB_ID = Request.QueryString("HERB_ID")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            bind_data_ddl()
            bind_dd_stype()
            bind_dd_eatting()
            bind_dd_storage()
            bind_dd_syndrome_detail()
            bind_dd_pack_1()
            bind_dd_pack_2()
            bind_dd_pack_3()
            bind_dd_unit_1()
            bind_dd_unit_2()
            bind_dd_unit_3()
            bind_dd_syndrome()
            Bind_Data()

            UC_TABEAN_JJ_DETAIL_CAS.bind_unit()
            UC_TABEAN_JJ_DETAIL_CAS.bind_unit4()
            UC_TABEAN_JJ_DETAIL_CAS.bind_unit_each()
            UC_ATTACH1.NAME = name_recipe.Text
            UC_ATTACH1.BindData("", 1, "pdf", "0", "1")
            UC_ATTACH2.NAME = name_production_process.Text
            UC_ATTACH2.BindData("", 1, "pdf", "0", "1")

        End If
    End Sub

    Public Sub Bind_Data()
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_JJ
        dao.GetdatabyID_HEAD_AND_PROCESS(_HERB_ID, _PROCESS_ID)
        Dim dao_detail As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_DETAIL_JJ
        dao_detail.GetdatabyID_DD_HERB_NAME_ID(_HERB_ID, _PROCESS_ID)
        'NAME_THAI.Text = dao.fields.HERB_NAME

        dao_detail.GetdatabyID_DD_HERB_NAME_ID(_HERB_ID, _PROCESS_ID)

        Dim name_cus As String = ""
        name_cus = _CLS.THANM_CUSTOMER

        Try
            DD_TYPE_NAME.SelectedValue = dao_detail.fields.TYPE_ID
            DD_TYPE_SUB_ID.SelectedValue = dao_detail.fields.TYPE_SUB_ID
            'DD_CATEGORY_ID.SelectedValue = CATEGORY_ID
            DD_STYPE_ID.SelectedValue = dao_detail.fields.STYPE_ID
        Catch ex As Exception

        End Try

        NAME_THAI.Text = dao_detail.fields.NAME_THAI
        NAME_ENG.Text = dao_detail.fields.NAME_ENG
        NAME_OTHER.Text = dao_detail.fields.NAME_OTHER
        RECIPE_NAME.Text = dao_detail.fields.RECIPE_NAME
        TXT_SYNDROME_DETAIL.Text = dao_detail.fields.SYNDROME_NAME
        HOW_USE.Text = dao_detail.fields.HOW_USE


        Try
            ACCOUNT_NO.Text = dao_detail.fields.ACCOUNT_NO
            ARTICLE_NO.Text = dao_detail.fields.ARTICLE_NO
        Catch ex As Exception

        End Try
        PRODUCT_JJ.Text = dao_detail.fields.PRODUCT_JJ
        'NATURE.Text = dao_detail.fields.NATURE

        Try
            SIZE_PACK.Text = dao_detail.fields.SIZE_PACK
        Catch ex As Exception

        End Try

        Try
            'DD_PRO_AGE.SelectedValue = 1
        Catch ex As Exception

        End Try
        PROPERTIES.Text = dao_detail.fields.PROPERTIES
        SIZE_USE.Text = dao_detail.fields.SIZE_USE
        Try
            DD_EATTING_ID.SelectedValue = dao_detail.fields.EATTING_ID
            R_EATING_CONDITION.SelectedValue = dao_detail.fields.EATING_CONDITION_ID
        Catch ex As Exception

        End Try
        If dao_detail.fields.EATING_CONDITION_ID = 1 Then
            EATING_CONDITION_NAME.Text = dao_detail.fields.EATING_CONDITION_NAME
            R_EATING_CONDITION_TEXT.Visible = False
        End If
        Try
            DD_STORAGE_ID.SelectedValue = dao_detail.fields.STORAGE_ID
        Catch ex As Exception

        End Try
        Try
            R_CONTRAINDICATION.SelectedValue = dao_detail.fields.CONTRAINDICATION_ID

        Catch ex As Exception

        End Try
        If dao_detail.fields.CONTRAINDICATION_ID = 1 Then
            CONTRAINDICATION_NAME.Text = dao_detail.fields.CONTRAINDICATION_NAME
            R_CONTRAINDICATION_TEXT.Visible = True
        End If
        Try
            R_WARNING.SelectedValue = dao_detail.fields.WARNING_ID
        Catch ex As Exception

        End Try

        If dao_detail.fields.WARNING_ID = 1 Then
            WARNING_NAME.Text = dao_detail.fields.WARNING_NAME
            R_WARNING_TEXT.Visible = True
        End If
        Try
            R_CAUTION.SelectedValue = dao_detail.fields.CAUTION_ID

        Catch ex As Exception

        End Try
        If dao_detail.fields.CAUTION_ID = 1 Then
            CAUTION_NAME.Text = dao_detail.fields.CAUTION_NAME
            R_CAUTION_TEXT.Visible = True
        End If
        Try
            R_ADV_REACTIVETION.SelectedValue = dao_detail.fields.ADV_REACTIVETION_ID
        Catch ex As Exception

        End Try
        If dao_detail.fields.ADV_REACTIVETION_ID = 1 Then
            ADV_REACTIVETION_NAME.Text = dao_detail.fields.ADV_REACTIVETION_NAME
            R_ADV_REACTIVETION_TEXT.Visible = True
        End If
        Try
            DD_SALE_CHANNEL.SelectedValue = dao_detail.fields.SALE_CHANNEL_ID
        Catch ex As Exception

        End Try
        NOTE.Text = dao_detail.fields.NOTE
    End Sub
    Public Sub bind_dd_stype()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STYPE_JJ()

        DD_STYPE_ID.DataSource = dt
        DD_STYPE_ID.DataBind()
        DD_STYPE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

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
    Public Sub bind_dd_syndrome()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_SYNDROME_JJ()

        DD_SYNDROME_ID.DataSource = dt
        DD_SYNDROME_ID.DataBind()
        DD_SYNDROME_ID.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub bind_dd_syndrome_detail()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_SYNDROME_DETAIL_JJ(_HERB_ID, _PROCESS_ID)
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
    Protected Sub BTN_ADD_SYNDROME_Click(sender As Object, e As EventArgs) Handles BTN_ADD_SYNDROME.Click
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_SYNDROME_DETAIL_JJ
        Dim dao2 As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_SYNDROME_DETAIL_JJ
        dao2.GetdatabyID_PROCESS(_PROCESS_ID)
        dao.fields.PROCESS_ID = _PROCESS_ID
        dao.fields.DD_HERB_NAME_ID = _HERB_ID
        dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
        dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
        If dao2.fields.SEQ Is Nothing Then dao.fields.SEQ = +1 Else dao.fields.SEQ = dao2.fields.SEQ + 1
        dao.fields.IS_EXPAND = 1
        dao.insert()
        bind_dd_syndrome_detail()
    End Sub

    Public Sub bind_data_ddl()
        If _PROCESS_ID = 20301 Then
            DD_TYPE_SUB_ID.SelectedValue = 1
        ElseIf _PROCESS_ID = 20302 Then
            DD_TYPE_SUB_ID.SelectedValue = 2
        ElseIf _PROCESS_ID = 20303 Then
            DD_TYPE_SUB_ID.SelectedValue = 3
        ElseIf _PROCESS_ID = 20304 Then
            DD_TYPE_SUB_ID.SelectedValue = 4
        End If

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

    Protected Sub btn_size_pack_Click(sender As Object, e As EventArgs) Handles btn_size_pack.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_SUB_PACKSIZE

        dao.fields.FK_IDA = _HERB_ID
        dao.fields.PROCESS_ID = _PROCESS_ID

        If DD_PCAK_1.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_1.SelectedValue = "-- กรุณาเลือก --" Then '_
            'Or DD_PCAK_2.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_2.SelectedValue = "-- กรุณาเลือก --" Then ' _
            'Or DD_PCAK_3.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_3.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูล Primary Seceondary Tertiary Packaging');", True)
        Else
            dao.fields.PACK_FSIZE_ID = DD_PCAK_1.SelectedValue
            dao.fields.PACK_FSIZE_NAME = DD_PCAK_1.SelectedItem.Text
            dao.fields.PACK_FSIZE_VOLUME = NO_1.Text
            dao.fields.PACK_FSIZE_UNIT_ID = DD_UNIT_1.SelectedValue
            dao.fields.PACK_FSIZE_UNIT_NAME = DD_UNIT_1.SelectedItem.Text
            Try
                dao.fields.PACK_SECSIZE_ID = DD_PCAK_2.SelectedValue
                dao.fields.PACK_SECSIZE_NAME = DD_PCAK_2.SelectedItem.Text
                dao.fields.PACK_SECSIZE_VOLUME = NO_2.Text
                dao.fields.PACK_SECSIZE_UNIT_ID = DD_UNIT_2.SelectedValue
                dao.fields.PACK_SECSIZE_UNIT_NAME = DD_UNIT_2.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_SECSIZE_ID = 0
                dao.fields.PACK_SECSIZE_NAME = ""
                dao.fields.PACK_SECSIZE_VOLUME = 0
                dao.fields.PACK_SECSIZE_UNIT_ID = 0
                dao.fields.PACK_SECSIZE_UNIT_NAME = ""
            End Try


            Try
                dao.fields.PACK_THSIZE_ID = DD_PCAK_3.SelectedValue
                dao.fields.PACK_THSIZE_NAME = DD_PCAK_3.SelectedItem.Text
                dao.fields.PACK_THSSIZE_VOLUME = NO_3.Text
                dao.fields.PACK_THSIZE_UNIT_ID = DD_UNIT_3.SelectedValue
                dao.fields.PACK_THSIZE_UNIT_NAME = DD_UNIT_3.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_THSIZE_ID = 0
                dao.fields.PACK_THSIZE_NAME = ""
                dao.fields.PACK_THSSIZE_VOLUME = 0
                dao.fields.PACK_THSIZE_UNIT_ID = 0
                dao.fields.PACK_THSIZE_UNIT_NAME = ""
            End Try


            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_BY = _CLS.THANM

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

        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_SUB_PACKSIZE
                dao.GetData_ByIDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_JJ_SUB_PACKSIZE
        dao_size.GetData_ByFkIDA(_HERB_ID)

        RadGrid1.DataSource = dao_size.datas

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        bind_size()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_DETAIL_JJ
        dao.GetdatabyID_DD_HERB_NAME_ID(_HERB_ID, _PROCESS_ID)
        If dao.fields.IDA = 0 Then

            Try
                dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
                dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text

            Catch ex As Exception

            End Try

            Try
                dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
                dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
                dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
                dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.STORAGE_ID = DD_STORAGE_ID.SelectedValue
                dao.fields.STORAGE_NAME = DD_STORAGE_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.fields.NAME_THAI = NAME_THAI.Text
            dao.fields.NAME_ENG = NAME_ENG.Text
            dao.fields.NAME_OTHER = NAME_OTHER.Text
            dao.fields.RECIPE_NAME = RECIPE_NAME.Text
            dao.fields.ACCOUNT_NO = ACCOUNT_NO.Text
            dao.fields.ARTICLE_NO = ARTICLE_NO.Text
            dao.fields.PRODUCT_JJ = PRODUCT_JJ.Text
            dao.fields.SIZE_PACK = SIZE_PACK.Text
            dao.fields.SYNDROME_NAME = TXT_SYNDROME_DETAIL.Text
            dao.fields.PROPERTIES = PROPERTIES.Text
            dao.fields.SIZE_USE = SIZE_USE.Text
            dao.fields.HOW_USE = HOW_USE.Text

            dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
            If R_EATING_CONDITION.SelectedValue = 1 Then
                dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
                R_EATING_CONDITION_TEXT.Visible = True
            Else
                dao.fields.EATING_CONDITION_NAME = "ไม่มี"
            End If

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

            Try
                dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
                dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.fields.NOTE = NOTE.Text
            dao.fields.DD_HERB_NAME_ID = _HERB_ID
            dao.fields.PROCESS_ID = _PROCESS_ID
            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            If _CLS.THANM = Nothing Then
                dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
            Else
                dao.fields.CREATE_BY = _CLS.THANM
            End If
            dao.insert()

            Try

                If UC_ATTACH1.CHK_MASTER_FILE_JJ = False Or UC_ATTACH2.CHK_MASTER_FILE_JJ = False Then
                    alert_nature("กรุณาแนบ เอกสารแนบไฟล์ สูตรและกรรมวิธีการผลิต")
                ElseIf UC_ATTACH1.CHK_MASTER_FILE_JJ = False And UC_ATTACH2.CHK_MASTER_FILE_JJ = False Then
                    alert_nature("กรุณาแนบ เอกสารแนบไฟล์ สูตรและกรรมวิธีการผลิต")
                Else
                    UC_ATTACH1.insert_master_flie_jj(_PROCESS_ID, _HERB_ID, 1)
                    UC_ATTACH2.insert_master_flie_jj(_PROCESS_ID, _HERB_ID, 2)
                    'chk_file1.Text = UC_ATTACH1.NAME
                    'chk_file2.Text = UC_ATTACH2.NAME
                    alert_summit("บันทึกข้อมูลเรีบยร้อย")
                End If

            Catch ex As Exception

            End Try

        Else


            Try
                dao.fields.TYPE_ID = DD_TYPE_NAME.SelectedValue
                dao.fields.TYPE_NAME = DD_TYPE_NAME.SelectedItem.Text

            Catch ex As Exception

            End Try

            Try
                dao.fields.TYPE_SUB_ID = DD_TYPE_SUB_ID.SelectedValue
                dao.fields.TYPE_SUB_NAME = DD_TYPE_SUB_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.STYPE_ID = DD_STYPE_ID.SelectedValue
                dao.fields.STYPE_NAME = DD_STYPE_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
                dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.STORAGE_ID = DD_STORAGE_ID.SelectedValue
                dao.fields.STORAGE_NAME = DD_STORAGE_ID.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.fields.NAME_THAI = NAME_THAI.Text
            dao.fields.NAME_ENG = NAME_ENG.Text
            dao.fields.NAME_OTHER = NAME_OTHER.Text
            dao.fields.RECIPE_NAME = RECIPE_NAME.Text
            Try
                dao.fields.ACCOUNT_NO = ACCOUNT_NO.Text
                dao.fields.ARTICLE_NO = ARTICLE_NO.Text
            Catch ex As Exception

            End Try


            dao.fields.PRODUCT_JJ = PRODUCT_JJ.Text
            dao.fields.SIZE_PACK = SIZE_PACK.Text
            dao.fields.SYNDROME_NAME = TXT_SYNDROME_DETAIL.Text
            dao.fields.PROPERTIES = PROPERTIES.Text
            dao.fields.SIZE_USE = SIZE_USE.Text
            dao.fields.HOW_USE = HOW_USE.Text

            dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
            If R_EATING_CONDITION.SelectedValue = 1 Then
                dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
                R_EATING_CONDITION_TEXT.Visible = True
            Else
                dao.fields.EATING_CONDITION_NAME = "ไม่มี"
            End If

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

            Try
                dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
                dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.fields.NOTE = NOTE.Text
            dao.fields.DD_HERB_NAME_ID = _HERB_ID
            dao.fields.PROCESS_ID = _PROCESS_ID
            dao.fields.ACTIVEFACT = 1
            dao.fields.UPDATE_DATE = Date.Now
            If _CLS.THANM = Nothing Then
                dao.fields.UPDATE_BY = _CLS.AUTHORIZE_NAME
            Else
                dao.fields.UPDATE_BY = _CLS.THANM
            End If
            dao.Update()

            Try
                If chk_file_attach() = True Then
                    If UC_ATTACH1.CHK_MASTER_FILE_JJ = False Or UC_ATTACH2.CHK_MASTER_FILE_JJ = False Then
                        alert_nature("กรุณาแนบ เอกสารแนบไฟล์ สูตรและกรรมวิธีการผลิต")
                    ElseIf UC_ATTACH1.CHK_MASTER_FILE_JJ = False And UC_ATTACH2.CHK_MASTER_FILE_JJ = False Then
                        alert_nature("กรุณาแนบ เอกสารแนบไฟล์ สูตรและกรรมวิธีการผลิต")
                    Else
                        UC_ATTACH1.NAME = name_recipe.Text
                        UC_ATTACH2.NAME = name_production_process.Text
                        UC_ATTACH1.insert_master_flie_jj(_PROCESS_ID, _HERB_ID, 1)
                        UC_ATTACH2.insert_master_flie_jj(_PROCESS_ID, _HERB_ID, 2)
                        'chk_file1.Text = UC_ATTACH1.NAME
                        'chk_file2.Text = UC_ATTACH2.NAME
                        alert_summit("บันทึกข้อมูลเรีบยร้อย")
                    End If
                Else
                    If UC_ATTACH1.CHK_MASTER_FILE_JJ = True Or UC_ATTACH2.CHK_MASTER_FILE_JJ = True Then
                        UC_ATTACH1.NAME = name_recipe.Text
                        UC_ATTACH2.NAME = name_production_process.Text
                        UC_ATTACH1.insert_master_flie_jj(_PROCESS_ID, _HERB_ID, 1)
                        UC_ATTACH2.insert_master_flie_jj(_PROCESS_ID, _HERB_ID, 2)
                    Else

                    End If
                    alert_summit("บันทึกข้อมูลเรีบยร้อย")
                End If
            Catch ex As Exception

            End Try

        End If

    End Sub
    Function chk_file_attach()
        Dim id As Boolean
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        dao.GetdatabyID_DD_HERB_NAME_PRODUCT_ID_AND_PROCESS_AND_TYPE(_HERB_ID, _PROCESS_ID, 1)
        If dao.fields.IDA <> 0 Then
            id = False
        Else
            id = True
        End If
        Return id
    End Function
    Private Sub RG_ATTACH1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_ATTACH1.NeedDataSource
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        'dao.GetdatabyID_DD_HERB_NAME_PRODUCT_ID_AND_PROCESS(_HERB_ID, _PROCESS_ID)
        dao.GetdatabyID_DD_HERB_NAME_PRODUCT_ID_AND_PROCESS_AND_TYPE(_HERB_ID, _PROCESS_ID, 1)
        RG_ATTACH1.DataSource = dao.datas
    End Sub
    Private Sub RG_ATTACH1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_ATTACH1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_STAFF/FRM_HERB_TABEAN_MASTER_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub
    Private Sub RG_ATTACH2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_ATTACH2.NeedDataSource
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        'dao.GetdatabyID_DD_HERB_NAME_PRODUCT_ID_AND_PROCESS(_HERB_ID, _PROCESS_ID)
        dao.GetdatabyID_DD_HERB_NAME_PRODUCT_ID_AND_PROCESS_AND_TYPE(_HERB_ID, _PROCESS_ID, 2)
        RG_ATTACH2.DataSource = dao.datas
    End Sub
    Private Sub RG_ATTACH2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_ATTACH2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_STAFF/FRM_HERB_TABEAN_MASTER_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub
    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'Response.Redirect("FRM_HERB_TABEAN_JJ.aspx?DD_HERB_NAME_ID=" & _HERB_ID & "&PROCESS_JJ=" & _PROCESS_ID)
        Response.Redirect("FRM_HERB_TABEAN_JJ.aspx")
    End Sub

    Sub alert_nature(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Sub alert_summit(ByVal text As String) ', ByVal ida As Integer
        Dim url As String = ""
        'url = "FRM_HERB_TABEAN_MASTER_JJ.aspx?HERB_ID=" & _HERB_ID & "&PROCESS_ID=" & _PROCESS_ID
        url = "FRM_HERB_TABEAN_MASTER_JJ.aspx"
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class
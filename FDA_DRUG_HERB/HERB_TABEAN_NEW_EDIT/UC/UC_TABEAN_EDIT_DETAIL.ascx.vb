Imports Telerik.Web.UI
Public Class UC_TABEAN_EDIT_DETAIL
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Shared _IDA_DQ As String = ""
    Private _IDA_LCN As String = ""
    Private _Process_ID As String = ""
    Shared PLACE_IDA As Integer = 0
    Shared PLACE_NAME As String = ""
    Shared PLACE_ADDRESS As String = ""
    Shared TXT_MENUFACTRUE_DETAIL As String = ""
    Shared IDA_ADDRESS As Integer = 0
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
        _IDA = Request.QueryString("IDA")
        _IDA_DR = Request.QueryString("IDA_DR")
        '_IDA_DQ = Request.QueryString("IDA_DR")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _Process_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            GET_PANEL_SHOW()
            GET_DATA()
            bind_dd_eatting()
            bind_dd_eatting_condition()
            bind_dd_storage()

            UC_officer_che.bind_unit1()
            UC_officer_che.bind_unit2()
            UC_officer_che.bind_unit3()
            UC_officer_che.bind_unit4()
            UC_officer_che.get_data_drgperunit()
            UC_officer_che.bind_unit_each()
            UC_officer_che.bind_lbl()
            ' UC_recipe.bind_ddl_atc()            UC_officer_che.bind_unit_head()
            UC_officer_che.bind_unit()

        End If
    End Sub
    Sub GET_DATA()
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_g.GetDataby_IDA(_IDA_DR)
            _IDA_DQ = dao_g.fields.FK_DRRQT
            dao.GetDataby_IDA(_IDA_DQ)
            dao_tn.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        Catch ex As Exception

        End Try

        'NAME_THAI.Text = dao_tn.fields.NAME_THAI
        'NAME_THAI_NEW.Text = dao_tn.fields.NAME_THAI
        NAME_THAI.Text = dao_g.fields.thadrgnm
        NAME_THAI_NEW.Text = dao_g.fields.thadrgnm
        'NAME_ENG.Text = dao_tn.fields.NAME_ENG
        'NAME_ENG_NEW.Text = dao_tn.fields.NAME_ENG
        NAME_ENG.Text = dao_g.fields.engdrgnm
        NAME_ENG_NEW.Text = dao_g.fields.engdrgnm
        NAME_OTHER.Text = dao_tn.fields.NAME_OTHER
        NAME_OTHER_NEW.Text = dao_tn.fields.NAME_OTHER

        txt_PROPERTIES.Text = dao_tn.fields.PROPERTIES
        txt_PROPERTIES_NEW.Text = dao_tn.fields.PROPERTIES

        txt_SizePack.Text = dao_tn.fields.SIZE_USE
        txt_SizePack_New.Text = dao_tn.fields.SIZE_USE

        txt_EATTING.Text = dao_tn.fields.EATTING_NAME
        Try
            DD_EATTING_ID.SelectedValue = dao_tn.fields.EATTING_ID
        Catch ex As Exception

        End Try

        EATING_CONDITION_NAME.Text = dao_tn.fields.EATING_CONDITION_NAME
        Try
            txt_STORAGE.Text = dao_tn.fields.STORAGE_NAME
            DD_STORAGE_ID.SelectedValue = dao_tn.fields.STORAGE_ID
        Catch ex As Exception

        End Try
        Try
            If dao_tn.fields.TREATMENT_AGE Is Nothing Or dao_tn.fields.TREATMENT_AGE = 0 Then
                txt_TREATMENT_AGE.Text = dao_tn.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
            ElseIf dao_tn.fields.TREATMENT_AGE_MONTH Is Nothing Or dao_tn.fields.TREATMENT_AGE_MONTH = 0 Then
                txt_TREATMENT_AGE.Text = dao_tn.fields.TREATMENT_AGE & " " & "ปี"
            Else
                txt_TREATMENT_AGE.Text = dao_tn.fields.TREATMENT_AGE & " " & "ปี" & " " & dao_tn.fields.TREATMENT_AGE_MONTH & " " & "เดือน"
            End If
            TREATMENT_AGE_YEAR.SelectedValue = dao_tn.fields.TREATMENT_AGE_ID
            TREATMENT_AGE_MONTH_SUB.SelectedValue = dao_tn.fields.TREATMENT_AGE_MONTH
        Catch ex As Exception

        End Try

        Try
            txt_SALE_CHANNEL.Text = dao_tn.fields.SALE_CHANNEL_NAME
            DD_SALE_CHANNEL.SelectedValue = dao_tn.fields.SALE_CHANNEL_ID
        Catch ex As Exception

        End Try
        If IsNothing(dao_tn.fields.EATTING_NAME_DETAIL) = False Then
            txt_EATTING.Text = dao_tn.fields.EATTING_NAME_DETAIL
        Else
            txt_EATTING.Text = dao_tn.fields.EATTING_NAME
        End If
        If IsNothing(dao_tn.fields.EATING_CONDITION_NAME_DETAIL) = False Then
            txt_EATING_CONDITION.Text = dao_tn.fields.EATING_CONDITION_NAME_DETAIL
        Else
            txt_EATING_CONDITION.Text = dao_tn.fields.EATING_CONDITION_NAME
        End If

        Dim bao As New BAO_MASTER
        Dim dao_lo As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_tb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Dim dt As New DataTable
        Try
            dao_tb.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
            dt = bao.SP_ADDR_BY_IDA(dao_tb.fields.IDA_LCN)
        Catch ex As Exception

        End Try
        Dim addr As String = ""
        If dt.Rows.Count > 0 Then
            addr = dt(0)("fulladdr")
        End If
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(dao_tb.fields.IDA_LCN)
        Catch ex As Exception

        End Try
        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try
        Dim THANM As String = dao_lcn.fields.thanm
        If THANM = "" Or THANM Is Nothing Then
            THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
        Else
            THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        End If
        Txt_Thanm_Old.Text = dao_tb.fields.LCN_NAME
        Try
            dao.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        Catch ex As Exception

        End Try

        Try
            txt_addr_Old.Text = addr
        Catch ex As Exception

        End Try
        Try
            txt_addrnm_Old.Text = dao_lo.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            'If dao_lcn.fields.LCNNO_DISPLAY_NEW = "" Or dao_lcn.fields.LCNNO_DISPLAY_NEW = Nothing Then
            '    txt_lcnno_Old.Text = dao_lcn.fields.LCNNO_DISPLAY
            'Else
            '    txt_lcnno_Old.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
            'End If
            txt_lcnno_Old.Text = dao_tb.fields.LCNNO
        Catch ex As Exception

        End Try
        Try
            txt_address.Text = dao_tb.fields.FOREIGN_NAME_PLACE
        Catch ex As Exception

        End Try
    End Sub
    Sub GET_PANEL_SHOW()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao.GetdatabyID_FK_IDA(_IDA)
        If dao.fields.NAME_PRODUCT_ID = True Then
            Panel1.Style.Add("display", "block")
        End If
        If dao.fields.NAME_LOCATION_ID = True Then
            Panel2.Style.Add("display", "block")
        End If
        'If dao.fields.PRODUCT_RECIPE_ID = True Then
        '    Panel3.Style.Add("display", "block")
        'End If
        If dao.fields.PRODUCTION_PROCESS_ID = True Then
            Panel4.Style.Add("display", "block")
        End If
        If dao.fields.PROPERTIES_ID = True Then
            Panel5.Style.Add("display", "block")
        End If
        If dao.fields.SIZE_USE_ID = True Then
            Panel6.Style.Add("display", "block")
        End If
        If dao.fields.PREPARE_EAT_ID = True Then
            Panel7.Style.Add("display", "block")
        End If
        If dao.fields.EAT_CONDITION_ID = True Then
            Panel8.Style.Add("display", "block")
        End If
        If dao.fields.STORAGE_ID = True Then
            Panel9.Style.Add("display", "block")
        End If
        'If dao.fields.CONTAINER_PACKING_ID = True Then
        '    Panel10.Style.Add("display", "block")
        'End If
        If dao.fields.QUALITY_CONTROL_ID = True Then
            Panel11.Style.Add("display", "block")
        End If
        If dao.fields.CER_LCN_ID = True Then
            Panel12.Style.Add("display", "block")
        End If
        If dao.fields.ETIQUETQ_ID = True Then
            Panel13.Style.Add("display", "block")
        End If
        If dao.fields.PRODUCT_DOCUMENT_ID = True Then
            Panel14.Style.Add("display", "block")
        End If
        If dao.fields.CHANNEL_SALE_ID = True Then
            Panel15.Style.Add("display", "block")
        End If
        If dao.fields.SUB_NAME_ENG = True Then
            DIV_NAME_ENG.Visible = True
        End If
        If dao.fields.SUB_NAME_OTHER = True Then
            DIV_NAME_OTHER.Visible = True
        End If
        If dao.fields.SUB_NAME_EXPORT = True Then
            DIV_NAME_ENG.Visible = True
        End If
        If dao.fields.SUB_Location1_ID = True Then
            Div_check1_2.Visible = True
        End If
        If dao.fields.SUB_Location2_ID = True Then
            Div_check1_2.Visible = True
        End If
        If dao.fields.SUB_Location3_ID = True Then
            div_check_3.Visible = True
        End If
    End Sub
    Sub SAVE_DATA_EDIT()
        RunSession()
        Dim dao_edit As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao_edit.GetdatabyID_IDA(_IDA)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao.GetdatabyID_FK_IDA(_IDA)
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        Dim dao_q As New DAO_DRUG.ClsDBdrrqt
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_g.GetDataby_IDA(_IDA_DR)
            _IDA_DQ = dao_g.fields.FK_DRRQT
            dao_q.GetDataby_IDA(_IDA_DQ)
            dao_tn.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        Catch ex As Exception

        End Try
        If dao.fields.NAME_PRODUCT_ID = True Then
            'dao_edit.fields.thadrgnm = NAME_THAI_NEW.Text
            dao_d.fields.NAME_THAI = NAME_THAI_NEW.Text
            'dao_edit.fields.engdrgnm = NAME_ENG_NEW.Text
            dao_d.fields.NAME_ENG = NAME_ENG_NEW.Text
        End If
        If dao.fields.NAME_LOCATION_ID = True Then

        End If
        'If dao.fields.PRODUCT_RECIPE_ID = True Then
        '    Panel3.Style.Add("display", "block")
        'End If
        If dao.fields.PRODUCTION_PROCESS_ID = True Then

        End If
        If dao.fields.PROPERTIES_ID = True Then
            dao_d.fields.PROPERTIES = txt_PROPERTIES_NEW.Text
        End If
        If dao.fields.SIZE_USE_ID = True Then
            dao_d.fields.SIZE_USE = txt_SizePack.Text
        End If
        If dao.fields.PREPARE_EAT_ID = True Then
            dao_d.fields.EATTING_NAME_DETAIL = txt_EATTING.Text
        End If
        If dao.fields.EAT_CONDITION_ID = True Then

        End If
        If dao.fields.STORAGE_ID = True Then
            Try
                dao_d.fields.TREATMENT_AGE_ID = TREATMENT_AGE_YEAR.SelectedValue
            Catch ex As Exception

            End Try
            Try
                dao_d.fields.TREATMENT_AGE_MONTH = TREATMENT_AGE_MONTH_SUB.SelectedValue
            Catch ex As Exception

            End Try
        End If
        'If dao.fields.CONTAINER_PACKING_ID = True Then
        '    Panel10.Style.Add("display", "block")
        'End If
        If dao.fields.QUALITY_CONTROL_ID = True Then

        End If
        If dao.fields.CER_LCN_ID = True Then

        End If
        If dao.fields.ETIQUETQ_ID = True Then

        End If
        If dao.fields.PRODUCT_DOCUMENT_ID = True Then

        End If
        If dao.fields.CHANNEL_SALE_ID = True Then
            Try
                dao_d.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
                dao_d.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
            Catch ex As Exception

            End Try
        End If
        dao_d.fields.ACTIVEFACT = 1
        'dao_edit.Update()
        dao_d.Update()
    End Sub
    Function bind_data2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        Dim _PROCESS_JJ As Integer = 0
        If dao.fields.DDHERB IsNot Nothing Then
            _PROCESS_JJ = dao.fields.DDHERB
        End If
        'SIZE_PACK.Text = dao.fields.SIZE_PACK
        'SIZE_PACK_NEW.Text = dao.fields.SIZE_PACK

        dt = bao.SP_TABEAN_JJ_EDIT_SUB_PACKSIZE(_IDA, _PROCESS_JJ)

        Return dt
    End Function
    Public Sub bind_dd_pack_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_PRIMARY()

        DD_PCAK_1.DataSource = dt
        DD_PCAK_1.DataBind()
        DD_PCAK_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Protected Sub btn_size_pack_Click(sender As Object, e As EventArgs) Handles btn_size_pack.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST

        'dao.fields.FK_IDA_DQ = _IDA_DR
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

        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid2.Rebind()
            End If
        End If
    End Sub

    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
        ' dao_size.GetdatabyID_FK_IDA_DQ2(_IDA_DR)
        dao_size.GetdatabyID_FK_IDA_DQ2(_IDA_DQ)

        RadGrid2.DataSource = dao_size.datas

    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        bind_size()
    End Sub
    Function bind_datatable2()
        Dim DT As New DataTable
        Try
            Dim dao_g As New DAO_DRUG.ClsDBdrrgt
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            Try
                dao_g.GetDataby_IDA(_IDA_DR)
                _IDA_DQ = dao_g.fields.FK_DRRQT
                dao.GetDataby_IDA(_IDA_DQ)
                dao_tn.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
            Catch ex As Exception

            End Try
            If dao_g.fields.PROCESS_ID = 1400001 Then
                Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
                Try
                    dao_a.GetDataby_TR_ID_And_Process(dao_g.fields.TR_ID, dao_g.fields.PROCESS_ID)
                Catch ex As Exception

                End Try
                Return dao_a.datas
                'bao._PATH_DEFAULT & "upload\" & dao_a.fields.NAME_FAKE)
            Else
                Dim TR_ID_JJ As Integer = 0
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                Dim bao As New BAO_TABEAN_HERB.tb_main
                Dim TR_ID As Integer = 0
                If IsNothing(dao.fields.TR_ID) = False Then
                    TR_ID = dao.fields.TR_ID
                End If
                'DT = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_q.fields.TR_ID_JJ, 1, dao_q.fields.DDHERB)
                DT = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_EDIT(TR_ID, 1, dao.fields.PROCESS_ID)
                Return DT
            End If
        Catch ex As Exception

        End Try

    End Function
    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_datatable2()
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
    Public Sub bind_dd_storage()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STORAGE_JJ()

        DD_STORAGE_ID.DataSource = dt
        DD_STORAGE_ID.DataBind()
        DD_STORAGE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Protected Sub btn_add_muc_add_Click(sender As Object, e As EventArgs) Handles btn_add_muc_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE

        dao.fields.FK_IDA_DQ = _IDA
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

        RadGrid7.Rebind()
    End Sub
    Private Sub bind_manu()
        Dim dao_manu As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
        dao_manu.GetdatabyID_FK_IDA_DQ2(_IDA)

        RadGrid7.DataSource = dao_manu.datas

    End Sub

    Private Sub RadGrid6_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid7.NeedDataSource
        bind_manu()
    End Sub
    Protected Sub Btn_ResetData_Click(sender As Object, e As EventArgs) Handles Btn_ResetData.Click
        Dim bao As New BAO_MASTER
        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_q As New DAO_DRUG.ClsDBdrrqt
        Dim dao_t As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Dim dt As New DataTable
        Try
            dao_q.GetDataby_IDA(_IDA_DQ)
            dao_t.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
            dt = bao.SP_ADDR_BY_IDA(dao_q.fields.FK_LCN_IDA)
        Catch ex As Exception

        End Try
        Dim addr As String = ""
        If dt.Rows.Count > 0 Then
            addr = dt(0)("fulladdr")
        End If
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(dao_q.fields.FK_LCN_IDA)
        Catch ex As Exception

        End Try
        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try
        Dim THANM As String = dao_lcn.fields.thanm
        If THANM = "" Or THANM Is Nothing Then
            THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
        Else
            THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        End If
        Txt_Thanm.Text = THANM

        dao.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        Try
            Txt_Addr.Text = addr
        Catch ex As Exception

        End Try
        Try
            Txt_AddrNm.Text = dao.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            If dao_lcn.fields.LCNNO_DISPLAY_NEW = "" Or dao_lcn.fields.LCNNO_DISPLAY_NEW = Nothing Then
                Txt_LCNNO.Text = dao_lcn.fields.LCNNO_DISPLAY
            Else
                Txt_LCNNO.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_frgn()
        'RadGrid1.Rebind()
    End Sub

    Sub Search_frgn()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_syspdcfrgn_SEARCH(txt_search.Text)

        RadGrid2.DataSource = dt
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        If txt_search.Text <> "" Then
            Search_frgn()
        End If
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
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
                RadGrid4.DataSource = dt

                RadGrid4.Rebind()

            End If

        End If
    End Sub

End Class
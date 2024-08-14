Imports System.Globalization
Imports Telerik.Web.UI
Public Class FRM_TABEAN_HERB_EDIT_REQUEST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _Process_ID As String
    Private _IDA_LCN As String
    Private _TR_ID_LCN As String
    Private _IDA_LCT As String
    Private _DD_HERB_NAME_ID As String
    Private _PROCESS_ID_LCN As String
    Private _MENU_GROUP As String


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

        _Process_ID = Request.QueryString("PROCESS_ID_DQ")
        _IDA = Request.QueryString("IDA_DQ")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            'bind_dd_age_unit()
            bind_dd_stype()
            'bind_dd_syndrome() 
            bind_dd_eatting()
            bind_dd_eatting_condition()
            bind_dd_warning()
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
    Public Sub bind_dd_eatting_condition()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_EATTING_CONDITION()

        DD_EATING_CONDITION_ID.DataSource = dt
        DD_EATING_CONDITION_ID.DataBind()
        DD_EATING_CONDITION_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_warning()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_WARNING()

        DD_WARNING.DataSource = dt
        DD_WARNING.DataBind()
        DD_WARNING.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_storage()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_STORAGE_JJ()

        DD_STORAGE_ID.DataSource = dt
        DD_STORAGE_ID.DataBind()
        DD_STORAGE_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_rg()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean_herb.GetdatabyID_FK_IDA_DQ(_IDA)

        Try
            txt_search_ida.Text = dao_tabean_herb.fields.FOREIGN_NAME_ID
            txt_search.Text = dao_tabean_herb.fields.FOREIGN_NAME
            txt_address_ida.Text = dao_tabean_herb.fields.FOREIGN_NAME_PLACE_ID
            txt_address.Text = dao_tabean_herb.fields.FOREIGN_NAME_PLACE
        Catch ex As Exception

        End Try

        NAME_TB.Text = dao_tabean_herb.fields.NAME_JJ
        NAME_PLACE_TB.Text = dao_tabean_herb.fields.NAME_PLACE_JJ

        Try
            DD_TYPE_NAME.SelectedValue = dao_tabean_herb.fields.TYPE_ID
        Catch ex As Exception

        End Try
        Try
            DD_TYPE_NAME.SelectedItem.Text = dao_tabean_herb.fields.TYPE_NAME
        Catch ex As Exception

        End Try
        Try
            DD_TYPE_SUB_ID.SelectedValue = dao_tabean_herb.fields.TYPE_SUB_ID
        Catch ex As Exception

        End Try
        Try
            DD_TYPE_SUB_ID.SelectedItem.Text = dao_tabean_herb.fields.TYPE_SUB_NAME
        Catch ex As Exception

        End Try
        Try
            DD_CATEGORY_ID.SelectedValue = dao_tabean_herb.fields.CATEGORY_ID
        Catch ex As Exception

        End Try
        Try
            DD_CATEGORY_ID.SelectedItem.Text = dao_tabean_herb.fields.CATEGORY_NAME
        Catch ex As Exception

        End Try
        Try
            DD_CATEGORY_OUT_ID.SelectedValue = dao_tabean_herb.fields.CATEGORY_OUT_ID
        Catch ex As Exception

        End Try
        Try
            DD_CATEGORY_OUT_ID.SelectedItem.Text = dao_tabean_herb.fields.CATEGORY_OUT_NAME
        Catch ex As Exception

        End Try
        NAME_THAI.Text = dao_tabean_herb.fields.NAME_THAI
        NAME_ENG.Text = dao_tabean_herb.fields.NAME_ENG
        NAME_OTHER.Text = dao_tabean_herb.fields.NAME_OTHER

        Try
            DD_STYPE_ID.SelectedValue = dao_tabean_herb.fields.STYPE_ID
        Catch ex As Exception

        End Try
        Try
            DD_STYPE_ID.SelectedItem.Text = dao_tabean_herb.fields.STYPE_NAME
        Catch ex As Exception

        End Try

        SIZE_PACK.Text = dao_tabean_herb.fields.SIZE_PACK
        NATURE.Text = dao_tabean_herb.fields.NATURE
        'WEIGHT_TABLE_CAP.Text = dao_tabean_herb.fields.WEIGHT_TABLE_CAP
        'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = dao_tabean_herb.fields.WEIGHT_TABLE_CAP_UNIT_ID
        'DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text = dao_tabean_herb.fields.WEIGHT_TABLE_CAP_UNIT_NAME
        'Try
        '    DD_SYNDROME_ID.SelectedValue = dao_tabean_herb.fields.SYNDROME_ID
        '    DD_SYNDROME_ID.SelectedItem.Text = dao_tabean_herb.fields.SYNDROME_NAME
        'Catch ex As Exception

        'End Try

        PROPERTIES.Text = dao_tabean_herb.fields.PROPERTIES
        SIZE_USE.Text = dao_tabean_herb.fields.SIZE_USE
        HOW_USE.Text = dao_tabean_herb.fields.HOW_USE

        Try
            DD_EATTING_ID.SelectedValue = dao_tabean_herb.fields.EATTING_ID
            DD_EATTING_ID.SelectedItem.Text = dao_tabean_herb.fields.EATTING_NAME

            If DD_EATTING_ID.SelectedValue = 9 Then
                EATTING_TEXT.Text = dao_tabean_herb.fields.EATTING_NAME_DETAIL
                R_EATTING_TEXT.Visible = True
            End If
        Catch ex As Exception

        End Try

        Try
            DD_EATING_CONDITION_ID.SelectedValue = dao_tabean_herb.fields.EATING_CONDITION_ID
            DD_EATING_CONDITION_ID.SelectedItem.Text = dao_tabean_herb.fields.EATING_CONDITION_NAME
            If DD_EATING_CONDITION_ID.SelectedValue = 14 Then
                EATING_CONDITION_NAME.Text = dao_tabean_herb.fields.EATING_CONDITION_NAME_DETAIL
                R_EATING_CONDITION_TEXT.Visible = True
            End If
        Catch ex As Exception

        End Try

        Try
            DD_STORAGE_ID.SelectedValue = dao_tabean_herb.fields.STORAGE_ID
        Catch ex As Exception

        End Try

        'TREATMENT.Text = dao_tabean_herb.fields.TREATMENT
        'TREATMENT_AGE.Text = dao_tabean_herb.fields.TREATMENT_AGE
        Try
            If dao_tabean_herb.fields.TREATMENT_AGE = 3 Then
                TREATMENT_AGE_MONTH_SUB.Enabled = False
            Else
                TREATMENT_AGE_MONTH_SUB.Enabled = True
            End If
            TREATMENT_AGE_MONTH_SUB.SelectedValue = dao_tabean_herb.fields.TREATMENT_AGE_MONTH
            TREATMENT_AGE_YEAR.SelectedValue = dao_tabean_herb.fields.TREATMENT_AGE
            NATURE.Text = dao_tabean_herb.fields.NATURE
        Catch ex As Exception

        End Try
        'Try
        '    DD_PRO_AGE.SelectedValue = dao_tabean_herb.fields.TREATMENT_AGE_ID
        '    DD_PRO_AGE.SelectedItem.Text = dao_tabean_herb.fields.TREATMENT_AGE_NAME
        'Catch ex As Exception

        'End Try

        Try
            R_CONTRAINDICATION.SelectedValue = dao_tabean_herb.fields.CONTRAINDICATION_ID
            If R_CONTRAINDICATION.SelectedValue = 1 Then
                CONTRAINDICATION_NAME.Text = dao_tabean_herb.fields.CONTRAINDICATION_NAME
                R_CONTRAINDICATION_TEXT.Visible = True
            End If
        Catch ex As Exception

        End Try
        Try
            R_WARNING.SelectedValue = dao_tabean_herb.fields.WARNING_TYPE_ID
            If R_WARNING.SelectedValue = 1 Then
                DD_WARNING.Visible = True
            Else
                DD_WARNING.Visible = False
            End If
        Catch ex As Exception

        End Try
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

        Try
            R_CAUTION.SelectedValue = dao_tabean_herb.fields.CAUTION_ID
            If R_CAUTION.SelectedValue = 1 Then
                CAUTION_NAME.Text = dao_tabean_herb.fields.CAUTION_NAME
                R_CAUTION_TEXT.Visible = True
            End If
        Catch ex As Exception

        End Try
        Try
            R_ADV_REACTIVETION.SelectedValue = dao_tabean_herb.fields.ADV_REACTIVETION_ID
            If R_ADV_REACTIVETION.SelectedValue = 1 Then
                ADV_REACTIVETION_NAME.Text = dao_tabean_herb.fields.ADV_REACTIVETION_NAME
                R_ADV_REACTIVETION_TEXT.Visible = True
            End If
        Catch ex As Exception

        End Try
        'Try
        '    DD_SALE_CHANNEL.SelectedValue = dao_tabean_herb.fields.SALE_CHANNEL_ID
        '    DD_SALE_CHANNEL.SelectedItem.Text = dao_tabean_herb.fields.SALE_CHANNEL_NAME
        'Catch ex As Exception

        'End Try

        NOTE.Text = dao_tabean_herb.fields.NOTE

    End Sub
    Public Sub bind_dd_warning_sub(ByVal fk_ida As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_WARNING_SUB(fk_ida)

        DD_WARNING_SUB.DataSource = dt
        DD_WARNING_SUB.DataBind()
        DD_WARNING_SUB.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub Run_Pdf_Tabean_Herb_new()
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_PROCESS_ID, dao.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID, PATH_PDF_OUTPUT)

        'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Protected Sub TREATMENT_AGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TREATMENT_AGE_YEAR.SelectedIndexChanged
        If TREATMENT_AGE_YEAR.SelectedValue = "3" Then
            TREATMENT_AGE_MONTH_SUB.ClearSelection()
            TREATMENT_AGE_MONTH_SUB.Enabled = False
        Else
            TREATMENT_AGE_MONTH_SUB.Enabled = True
        End If
    End Sub
    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
        dao_size.GetdatabyID_FK_IDA_DQ2(_IDA)

        RadGrid4.DataSource = dao_size.datas

    End Sub

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        bind_size()
    End Sub

    'Private Sub bind_manu()
    '    Dim dao_manu As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
    '    dao_manu.GetdatabyID_FK_IDA_DQ2(_IDA)

    '    RadGrid1.DataSource = dao_manu.datas

    'End Sub

    'Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
    '    bind_manu()
    'End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_deeqt.fields.TR_ID, 7, _Process_ID, _IDA)

        Return dt
    End Function

    'Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
    '    RadGrid2.DataSource = bind_data_uploadfile()
    'End Sub

    'Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If

    'End Sub

    Function bind_data_uploadfile_6()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 6, _Process_ID, _IDA)

        Return dt
    End Function

    'Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
    '    RadGrid3.DataSource = bind_data_uploadfile_6()
    'End Sub

    'Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If
    'End Sub

    Function bind_data_uploadfile_8()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 8, _Process_ID, _IDA)

        Return dt
    End Function

    'Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
    '    RadGrid5.DataSource = bind_data_uploadfile_8()
    'End Sub

    'Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If
    'End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            update_data()
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        End Try


    End Sub
    Sub update_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean.GetdatabyID_FK_IDA_DQ(_IDA)

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
        'Dim bao_tran As New BAO_TRANSECTION
        'TR_ID = bao_tran.insert_transection(_Process_ID)

        dao_deeqt.fields.FK_LCN_IDA = _IDA_LCN
        TR_ID = dao_deeqt.fields.TR_ID
        dao_deeqt.fields.lcnsid = lcnsid
        dao_deeqt.fields.pvncd = PVNCD
        dao_deeqt.fields.pvnabbr = PVNABBR
        dao_deeqt.fields.PROCESS_ID = _Process_ID

        dao_deeqt.fields.thadrgnm = NAME_THAI.Text
        dao_deeqt.fields.engdrgnm = NAME_ENG.Text

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
        'Or DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue = "-- กรุณาเลือก --"  Or DD_EATING_CONDITION_ID.SelectedValue = "-- กรุณาเลือก --"  'Or DD_STORAGE_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_PRO_AGE.SelectedValue = "-- กรุณาเลือก --" Or DD_SYNDROME_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --"
        If DD_TYPE_NAME.SelectedValue = "-- กรุณาเลือก --" Or DD_TYPE_SUB_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_CATEGORY_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_STYPE_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_EATTING_ID.SelectedValue = "-- กรุณาเลือก --" _
            Or R_CONTRAINDICATION.SelectedValue = "" Or R_CAUTION.SelectedValue = "" Or R_ADV_REACTIVETION.SelectedValue = "" _
            Or R_WARNING.SelectedValue = "" Then

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        ElseIf R_WARNING.SelectedValue = 1 And DD_WARNING.SelectedValue = "-- กรุณาเลือก --" And DD_WARNING_SUB.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน คำเตือน');", True)
        Else

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(_IDA)

            dao.fields.IDA_LCN = _IDA_LCN
            If _IDA <> "" Then
                dao.fields.FK_IDA_DQ = _IDA
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
            dao.fields.PRODUCT_JJ = _Process_ID
            dao.fields.NATURE = NATURE.Text
            'dao.fields.PRODUCT_PROCESS = PRODUCT_PROCESS.Text
            'dao.fields.MANUFAC_ID = DD_MANUFAC_ID.SelectedValue
            'dao.fields.MANUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text
            'dao.fields.WEIGHT_TABLE_CAP = WEIGHT_TABLE_CAP.Text

            'dao.fields.WEIGHT_TABLE_CAP_UNIT_ID = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedValue
            'dao.fields.WEIGHT_TABLE_CAP_UNIT_NAME = DD_WEIGHT_TABLE_CAP_UNIT_ID.SelectedItem.Text
            'Try
            '    dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
            '    dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
            'Catch ex As Exception

            'End Try


            dao.fields.PROPERTIES = PROPERTIES.Text
            dao.fields.SIZE_USE = SIZE_USE.Text
            dao.fields.HOW_USE = HOW_USE.Text

            dao.fields.EATTING_ID = DD_EATTING_ID.SelectedValue
            dao.fields.EATTING_NAME = DD_EATTING_ID.SelectedItem.Text
            If DD_EATTING_ID.SelectedValue = 9 Then
                'dao.fields.EATTING_NAME_DETAIL = EATTING_TEXT.Text
                dao.fields.EATTING_NAME_DETAIL = "ไม่มี"
                R_EATTING_TEXT.Visible = True
            End If
            'dao.fields.EATING_CONDITION_ID = R_EATING_CONDITION.SelectedValue
            'If R_EATING_CONDITION.SelectedValue = 1 Then
            '    dao.fields.EATING_CONDITION_NAME = EATING_CONDITION_NAME.Text
            '    R_EATING_CONDITION_TEXT.Visible = True
            'End If

            'Try
            '    dao.fields.PRODUCER_ID = RBL_CHK_PRODUCER.SelectedValue
            '    If RBL_CHK_PRODUCER.SelectedValue = 1 Then
            '        dao.fields.PRODUCER_NAME = "มี"
            '    Else
            '        dao.fields.PRODUCER_NAME = "ไม่มี"
            '    End If

            'Catch ex As Exception

            'End Try

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

            'dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
            'dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text

            dao.fields.NOTE = NOTE.Text

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

            Run_Pdf_Tabean_Herb_new()

            alert("บันทึกข้อมูลคำข้อแล้ว")
        End If
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class
Imports Telerik.Web.UI
Public Class POPUP_HERB_TABEAN_INFORM_EDIT_REQUEST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _IDA As String
    Private _SID As String
    Private _IDEN As String
    Sub RunSession()
        '_ProcessID = 10104
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")
        _SID = Request.QueryString("SID")
        _IDA = Request.QueryString("IDA")

        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
            dao.GetdatabyID_IDA(Request.QueryString("_IDA"))
            Bind_Data()
            'load_gv()
            bind_data2()
            bind_rg()
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
            bind_dd_herb()

            UC_ATTACH1.NAME = "เอกสารแนบ สูตรตำรับ"
            UC_ATTACH1.BindData("สูตรตำรับ", 1, "pdf", "0", "6")
            UC_ATTACH2.NAME = "เอกสารแนบ กรรมวิธีการผลิต"
            UC_ATTACH2.BindData("กรรมวิธีการผลิต", 1, "pdf", "0", "8")
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
        NAME_TB.Text = thanm

    End Sub
    Public Sub bind_data2()

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
        If _ProcessID = 20201 Then
            DD_TYPE_NAME.SelectedValue = 20201
            DD_TYPE_SUB_ID.SelectedValue = 1
        ElseIf _PROCESSID = 20202 Then
            DD_TYPE_NAME.SelectedValue = 20102
            DD_TYPE_SUB_ID.SelectedValue = 2
        ElseIf _PROCESSID = 20203 Then
            DD_TYPE_NAME.SelectedValue = 20103
            DD_TYPE_SUB_ID.SelectedValue = 3
        ElseIf _PROCESSID = 20204 Then
            DD_TYPE_NAME.SelectedValue = 20204
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
    Public Sub load_gv()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(Request.QueryString("IDA"))

        Dim dao_a As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_a.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(_IDA, dao.fields.TR_ID, _ProcessID, 3)
        Try
            RG_StaffFile.DataSource = dao_a.datas
            RG_StaffFile.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RG_StaffFile_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_StaffFile.NeedDataSource
        load_gv()
    End Sub
    Private Sub RG_StaffFile_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_StaffFile.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_EXHIBITION/FRM_TABEAN_HERB_EXHIBITION_PREVIEWaspx.aspx?ida=" & IDA
        End If

    End Sub
    Sub Bind_Data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(Request.QueryString("IDA"))
        If dao.fields.Check_Edit_ID = True Then
            Check_Edit.Visible = True
            TXT_EDIT_NOTE.Text = dao.fields.Note_Edit
        End If
        If dao.fields.Check_Edit_FileUpload_ID = True Then
            Check_Edit_Uplaod.Visible = True
            NOTE_EDIT.Text = dao.fields.Note_Edit_FileUpload
        End If
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim check_id As String = ""
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(Request.QueryString("IDA"))
        If dao.fields.Check_Edit_FileUpload_ID = True Then
            If check_file() = False Then
                alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
            Else
                If dao.fields.Check_Edit_ID = False Then
                    dao.fields.STATUS_ID = 10
                    dao.Update()
                    AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, Request.QueryString("IDA"))
                    alert("บันทึกข้อมูลแล้ว รอเจ้าหน้าที่ตรวจสอบความถูกต้อง")
                End If
            End If
        End If
        If dao.fields.Check_Edit_ID = True Then
            If check_id = 1 Then
                dao.fields.STATUS_ID = 10
                dao.Update()
                AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, Request.QueryString("IDA"))
                alert("บันทึกข้อมูลแล้ว รอเจ้าหน้าที่ตรวจสอบความถูกต้อง")
            End If

        End If


    End Sub

    Function bind_data_RG_Edit()
        Dim dt As DataTable
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(_IDA)

        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, 1, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RG_Edit_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_Edit.NeedDataSource
        RG_Edit.DataSource = bind_data_RG_Edit()
    End Sub
    Private Sub RG_Edit_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_Edit.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_EXHIBITION/FRM_TABEAN_HERB_EXHIBITION_PREVIEWaspx.aspx?ida=" & IDA
        End If

    End Sub
    Public Sub BindTable()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(_IDA)
        Dim tr_id As Integer = 0
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        Dim dao_att As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        Dim group As Integer = 0

        'dao_f.GetDataby_TR_ID(tr_id)
        dao_f.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(_IDA, tr_id, _ProcessID, 2)

        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas


            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.DUCUMENT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.DUCUMENT_NAME
            End Try
            tc.Width = 700
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.NAME_REAL
            tc.Width = 100
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim img As New Image
            If dao_f.fields.NAME_REAL Is Nothing OrElse dao_f.fields.NAME_REAL = "" Then
                Dim AA As String = "../Images/cancel.png"
                img.ImageUrl = AA
                img.Width = 20
                img.Height = 20
            Else
                Dim AA As String = "../Images/correct.png"
                img.ImageUrl = AA
                img.Width = 20
                img.Height = 20
            End If
            tc.Controls.Add(img)
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim f As New FileUpload
            f.ID = "F" & dao_f.fields.IDA
            tc.Controls.Add(f)
            tr.Cells.Add(tc)

            tb_upload_file.Rows.Add(tr)
            rows = rows + 1
        Next
    End Sub
    Sub BIND_PDF_TABEAN()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_EXHIBITION
        TBN_EXHIBITION = XML.Gen_XML_EXHIBITION(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "นท1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EXHIBITION") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", _ProcessID, Date.Now.Year, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", _ProcessID, Date.Now.Year, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Function check_file()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(TR_ID, _IDA, _ProcessID, 1)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
            End If
        Next

        Return ck_file
    End Function
    Protected Sub btn_add_no_Click(sender As Object, e As EventArgs) Handles btn_add_no.Click
        Dim tr_id As Integer = 0
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao.GetdatabyID_IDA(_IDA)
        tr_id = dao.fields.TR_ID
        For Each tr As TableRow In tb_upload_file.Rows
            Dim IDA As Integer = tr.Cells(1).Text

            Dim f As New FileUpload
            f = tr.FindControl("F" & IDA)
            If f.HasFile Then
                Dim name_real As String = f.FileName
                Dim Array_NAME_REAL() As String = Split(name_real, ".")
                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                If exten.ToUpper = "PDF" Then
                    Dim bao As New BAO.AppSettings
                    Dim dao_f As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_f.GetdatabyID_IDA(IDA)

                    Dim Name_fake As String = "HB-" & _ProcessID & "-" & Date.Now.Year & "-" & tr_id & ".pdf"
                    dao_f.fields.NAME_FAKE = Name_fake
                    dao_f.fields.NAME_REAL = f.FileName
                    dao_f.fields.CREATE_DATE = Date.Now
                    dao_f.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_EXHIBITION
                    f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                Else
                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If

            End If

        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "FRM_PHR_HERB_UPLOAD.aspx?IDA=" & ida
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
End Class
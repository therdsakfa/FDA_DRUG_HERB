Public Class uc_rnp_general_data
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String = ""
    Private _IDA_LCN As Integer
    Private _IDA As Integer
    Private _IDEN As String
    Private TR_ID As String = ""
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")
        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
            _IDA = Request.QueryString("IDA")
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
        If Not IsPostBack Then
            Get_data()
            'bind_ddl_prefix()
            UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
            UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
        End If
    End Sub
    Sub Get_data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_lcn124 As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        dao_lcn124.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_licen As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        dao_licen.GetDataby_u1(dao_lcn124.fields.Newcode_not)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao_lcn.fields.IDA)

        If dao_lcn124.fields.IDA = 0 Then
            txt_Rename_Name.Text = dao_lcn.fields.syslcnsnm_prefixnm & "" & dao_lcn.fields.syslcnsnm_thanm & "" & dao_lcn.fields.syslcnsnm_thalnm
            'txt_phr_name.Text = dao_phr.fields.PHR_NAME
            txt_phr_name.Text = dao_bsn.fields.BSN_THAIFULLNAME
            TxT_LCN_NUM.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
            TxT_Business_Name.Text = dao_addr.fields.thanameplace
            txt_addr.Text = dao_addr.fields.thaaddr
            txt_Building.Text = dao_addr.fields.thabuilding
            txt_mu.Text = dao_addr.fields.thamu
            txt_Soi.Text = dao_addr.fields.thasoi
            txt_road.Text = dao_addr.fields.tharoad
            txt_tambol.Text = dao_addr.fields.thathmblnm
            txt_ampher.Text = dao_addr.fields.thaamphrnm
            txt_changwat.Text = dao_addr.fields.thachngwtnm
            txt_zipcode.Text = dao_addr.fields.zipcode
            txt_tel.Text = dao_addr.fields.tel
            txt_Opentime.Text = dao_lcn.fields.opentime
            'txt_Write_Date.Text = Date.Now.ToString("dd/MM/yyyy")
            'Txt_Write_At.Text = "อย"
        Else
            txt_Rename_Name.Text = dao_licen.fields.licen
            txt_phr_name.Text = dao_lcn124.fields.grannm_lo
            TxT_LCN_NUM.Text = dao_lcn124.fields.lcnno_display_new
            TxT_Business_Name.Text = dao_lcn124.fields.thanm
            txt_addr.Text = dao_lcn124.fields.thaaddr
            txt_Building.Text = dao_lcn124.fields.thabuilding
            txt_mu.Text = dao_lcn124.fields.thamu
            txt_Soi.Text = dao_lcn124.fields.thasoi
            txt_road.Text = dao_lcn124.fields.tharoad
            txt_tambol.Text = dao_lcn124.fields.thathmblnm
            txt_ampher.Text = dao_lcn124.fields.thaamphrnm
            txt_changwat.Text = dao_lcn124.fields.thachngwtnm
            txt_zipcode.Text = dao_lcn124.fields.zipcode
            txt_tel.Text = dao_lcn124.fields.tel
            txt_Opentime.Text = dao_lcn124.fields.licen_time
        End If
        If IsNothing(dao.fields.head_menu_normal) = False Then CheckBox_lcn.Checked = dao.fields.head_menu_normal
        If IsNothing(dao.fields.head_menu_bsn) = False Then CheckBox_Bsn.Checked = dao.fields.head_menu_bsn
        If IsNothing(dao.fields.head_menu_phr) = False Then CheckBox_Phr.Checked = dao.fields.head_menu_phr
        If IsNothing(dao.fields.head_menu_lo) = False Then CheckBox_Location.Checked = dao.fields.head_menu_lo
        If IsNothing(dao.fields.head_menu_lo_keep) = False Then CheckBox_Keep.Checked = dao.fields.head_menu_lo_keep
        If IsNothing(dao.fields.head_menu_drug_group) = False Then CheckBox_Drug_Group.Checked = dao.fields.head_menu_drug_group
        txt_note_edit.Text = dao.fields.Note_Edit
        If IsNothing(dao.fields.SUB_CerSD_TYPE) = False Then rdl_cer.SelectedValue = dao.fields.SUB_CerSD_TYPE
        If IsNothing(dao.fields.CerSD_TYPE) = False Then rdl_CerSD.SelectedValue = dao.fields.CerSD_TYPE
        If IsNothing(dao.fields.EnterpriseType) = False Then rdl_enterprise.SelectedValue = dao.fields.EnterpriseType
        If Not String.IsNullOrEmpty(dao.fields.Check_Confirm) AndAlso dao.fields.Check_Confirm = "N" Then
            incorrect_id.Visible = True
        Else
            incorrect_id.Visible = False ' Optional: กำหนดค่าอื่นถ้าจำเป็น
        End If
    End Sub
    Private Sub rg_bsn_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_bsn.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_LOCATION_BSN_BY_LCN_IDA(Request.QueryString("IDA_LCN")) 'ผู้ดำเนิน
        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            rg_bsn.DataSource = dt
        End If
    End Sub
    Private Sub rgphr_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgphr.NeedDataSource
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        Try
            dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(Request.QueryString("IDA_LCN"))
        Catch ex As Exception
            'FRM_STAFF_LCN_PHR_EDIT.aspx
        End Try
        If dt.Rows.Count > 0 Then
            rgphr.DataSource = dt
        End If

    End Sub
    Private Sub rglocation_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rglocation.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        Try
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("IDA_LCN"))
            If dao.fields.FK_IDA <> 0 Then
                'dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
                dt = bao.SP_LOCATION_ADDRESS_by_DALCN_IDA(Request.QueryString("IDA_LCN"))
            End If

        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            rglocation.DataSource = dt
        End If

    End Sub
    Private Sub rgkeep_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgkeep.NeedDataSource
        Dim bao_mas As New BAO_MASTER
        Dim dt As New DataTable
        Try
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(Request.QueryString("IDA"))
            dt = bao_mas.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(Request.QueryString("IDA_LCN"))
        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            rgkeep.DataSource = dt
        Else
            dv_lckeep.Visible = False
        End If

    End Sub
End Class
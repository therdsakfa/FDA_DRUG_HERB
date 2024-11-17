Public Class POP_UP_LCN_RENEW_CHECK
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
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
    'Public Sub bind_ddl_prefix()
    '    Dim bao As New BAO_SHOW
    '    Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

    '    ddl_prefix.DataSource = dt
    '    ddl_prefix.DataBind()
    '    ddl_prefix.Items.Insert(0, "-- กรุณาเลือก --")
    'End Sub
    Sub Get_data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_FK_LCN(_IDA_LCN, True)
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
        'If dao_lcn124.fields.IDA = 0 Then
        'txt_Rename_Name.Text = dao_lcn.fields.syslcnsnm_prefixnm & "" & dao_lcn.fields.thanm
        txt_Rename_Name.Text = GET_NAME_BY_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
        'txt_phr_name.Text = dao_phr.fields.PHR_NAME
        Try
            Dim dao_prefix As New DAO_CPN.TB_sysprefix
            dao_prefix.Getdata_byid(dao_bsn.fields.BSN_PREFIXTHAICD)
            txt_phr_name.Text = dao_prefix.fields.thanm & " " & dao_bsn.fields.BSN_THAINAME & " " & dao_bsn.fields.BSN_THAILASTNAME
        Catch ex As Exception

        End Try
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
        If dao_lcn.fields.fax IsNot Nothing Then txt_fax.Text = dao_lcn.fields.fax Else txt_fax.Text = "-"
        If dao.fields.CerSD_TYPE IsNot Nothing AndAlso dao.fields.CerSD_TYPE <> 0 Then rdl_CerSD.SelectedValue = dao.fields.CerSD_TYPE
        If dao.fields.CerSD_TYPE IsNot Nothing AndAlso dao.fields.CerSD_TYPE = 1 Then
            If dao.fields.SUB_CerSD_TYPE IsNot Nothing AndAlso dao.fields.SUB_CerSD_TYPE <> 0 Then
                rdl_cer.SelectedValue = dao.fields.SUB_CerSD_TYPE
                chk_rad1.Style.Add("display", "block")
            Else
                chk_rad1.Style.Add("display", "block")
            End If
        End If
        If dao.fields.EnterpriseType IsNot Nothing AndAlso dao.fields.EnterpriseType <> 0 Then rdl_enterprise.SelectedValue = dao.fields.EnterpriseType
        If dao.fields.STATUS_ID IsNot Nothing AndAlso dao.fields.STATUS_ID <> 0 Then
            btn_save.Enabled = False
            btn_save2.Enabled = False
            rdl_enterprise.Enabled = False
            rdl_CerSD.Enabled = False
            rdl_cer.Enabled = False
        End If
        'txt_Write_Date.Text = Date.Now.ToString("dd/MM/yyyy")
        'Txt_Write_At.Text = "อย"
        'Else
        '    txt_Rename_Name.Text = dao_licen.fields.licen
        '    txt_phr_name.Text = dao_lcn124.fields.grannm_lo
        '    TxT_LCN_NUM.Text = dao_lcn124.fields.lcnno_display_new
        '    TxT_Business_Name.Text = dao_lcn124.fields.thanm
        '    txt_addr.Text = dao_lcn124.fields.thaaddr
        '    txt_Building.Text = dao_lcn124.fields.thabuilding
        '    txt_mu.Text = dao_lcn124.fields.thamu
        '    txt_Soi.Text = dao_lcn124.fields.thasoi
        '    txt_road.Text = dao_lcn124.fields.tharoad
        '    txt_tambol.Text = dao_lcn124.fields.thathmblnm
        '    txt_ampher.Text = dao_lcn124.fields.thaamphrnm
        '    txt_changwat.Text = dao_lcn124.fields.thachngwtnm
        '    txt_zipcode.Text = dao_lcn124.fields.zipcode
        '    txt_tel.Text = dao_lcn124.fields.tel
        '    txt_Opentime.Text = dao_lcn124.fields.licen_time
        '    txt_fax.Text = "-"
        '    If dao.fields.CerSD_TYPE IsNot Nothing AndAlso dao.fields.CerSD_TYPE = 0 Then rdl_CerSD.SelectedValue = dao.fields.CerSD_TYPE
        '    If dao.fields.EnterpriseType IsNot Nothing AndAlso dao.fields.EnterpriseType = 0 Then rdl_enterprise.SelectedValue = dao.fields.EnterpriseType
        'End If
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POP_UP_LCN_RENEW_UPLOAD_FILE.aspx?IDA=" & ida & "&PROCESS_ID=" & _ProcessID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    'Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
    '    Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    'End Sub
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
    Sub Data_set(ByVal dao As DAO_LCN.TB_DALCN_RENEW_PRE)
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CREATE_BY = _CLS.THANM
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.FK_LCN = _IDA_LCN
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CREATE_BY = _CLS.THANM
        dao.fields.CREATE_DATE = Date.Now
    End Sub

    Protected Sub btn_save2_Click(sender As Object, e As EventArgs) Handles btn_save2.Click
        Try
            If String.IsNullOrEmpty(rdl_enterprise.SelectedValue) OrElse rdl_enterprise.SelectedValue = "0" Then
                alert("กรุณาเลือกเงื่อนไขการจดทะเบียนวิสาหกิจ")
                UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
                UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
            Else
                If String.IsNullOrEmpty(rdl_CerSD.SelectedValue) OrElse rdl_CerSD.SelectedValue = "0" Then
                    alert("กรุณาเลือกกาารรับรองมาตรฐานสถานที่")
                    UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
                    UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
                Else
                    If rdl_CerSD.SelectedValue = "1" AndAlso String.IsNullOrEmpty(rdl_cer.SelectedValue) Then
                        alert("กรุณาเลิอกประเภทกกาารรับรองมาตรฐานสถานที่")
                        UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
                        UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
                    Else
                        'Dim EnterpriseChk As String = rdl_enterprise.SelectedValue
                        'If EnterpriseChk = "" Then EnterpriseChk = 0
                        'If (Convert.ToInt32(EnterpriseChk)) = 0 Then
                        '    alert("กรุณาเลือกเงื่อนไขเพิ่มเติมก่อนดำเนินรายการต่อ")
                        'Else
                        Dim bao_tran As New BAO_TRANSECTION
                        Dim TR_ID As String = ""
                        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
                        dao.GET_DATA_BY_FK_LCN(_IDA_LCN, True)
                        Dim dao_licen As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
                        dao_licen.GetDataby_LCN_IDA(_IDA_LCN)
                        Dim dao_li As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
                        dao_li.GetDataby_LCN_IDA(_IDA_LCN)
                        Data_set(dao)
                        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                        dao_lcn.GetDataby_IDA(_IDA_LCN)
                        'If _ProcessID Is Nothing Then
                        '    _ProcessID = 10511
                        'End If
                        dao.fields.PROCESS_ID = _ProcessID
                        If dao.fields.IDA = 0 Then
                            Try
                                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                                TR_ID = bao_tran.insert_transection(_ProcessID)

                                dao.fields.Newcode_Not = dao_licen.fields.Newcode_not
                                dao.fields.lcnno_display_new = dao_licen.fields.lcnno_display_new
                                dao.fields.Licensee_name = dao_li.fields.licen
                                dao.fields.Licensed_location = dao_licen.fields.thanm
                                dao.fields.CerSD_TYPE = rdl_CerSD.SelectedValue
                                If Not String.IsNullOrEmpty(rdl_cer.SelectedValue) Then dao.fields.SUB_CerSD_TYPE = rdl_cer.SelectedValue
                                dao.fields.EnterpriseType = rdl_enterprise.SelectedValue
                                dao.fields.FK_LCT = DAO_LCN.fields.FK_IDA
                                dao.fields.process_lcn = DAO_LCN.fields.PROCESS_ID
                                dao.fields.pvncd = dao_licen.fields.chngwtcd
                            Catch ex As Exception

                            End Try
                            dao.fields.TR_ID = TR_ID
                            dao.fields.Check_Confirm = "N"
                            dao.fields.ACTIVEFACT = True
                            If Request.QueryString("staff") <> "" Then
                                dao.fields.INOFFICE_STAFF_ID = Request.QueryString("staff")
                                dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
                            End If
                            dao.insert()
                        Else
                            If Not String.IsNullOrEmpty(rdl_CerSD.SelectedValue) Then dao.fields.CerSD_TYPE = rdl_CerSD.SelectedValue
                            If Not String.IsNullOrEmpty(rdl_cer.SelectedValue) Then dao.fields.SUB_CerSD_TYPE = rdl_cer.SelectedValue
                            If Not String.IsNullOrEmpty(rdl_enterprise.SelectedValue) Then dao.fields.EnterpriseType = rdl_enterprise.SelectedValue
                            dao.update()
                            TR_ID = dao.fields.TR_ID
                        End If
                        _IDA = dao.fields.IDA
                        INSERT_FILE_ATTACH(0, 0, TR_ID, _ProcessID)
                        If rdl_CerSD.SelectedValue = 1 Then
                            INSERT_FILE_ATTACH(11, 11, TR_ID, _ProcessID)
                        ElseIf rdl_CerSD.SelectedValue = 2 Then
                            INSERT_FILE_ATTACH(1, 1, TR_ID, _ProcessID)
                        End If
                        If rdl_enterprise.SelectedValue = 1 OrElse rdl_enterprise.SelectedValue = 2 OrElse rdl_enterprise.SelectedValue = 3 OrElse
                       rdl_enterprise.SelectedValue = 4 Then
                            INSERT_FILE_ATTACH(3, 3, TR_ID, _ProcessID)
                        End If
                        If Request.QueryString("staff") <> "" Then
                            'INSERT_FILE_ATTACH(1, 1, TR_ID, _ProcessID)
                            INSERT_FILE_ATTACH(2, 2, TR_ID, _ProcessID)
                            'INSERT_FILE_ATTACH(3, 1, TR_ID, _ProcessID)
                        End If
                        Response.Redirect("POP_UP_LCN_RENEW_CHECK_EDIT.aspx?IDA=" & dao.fields.IDA & "&IDA_LCN=" & _IDA_LCN & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & _ProcessID & "&CONDITION=N")
                        'End If
                    End If
                End If
            End If

        Catch ex As Exception
            Dim error_ms As String = "ระบบเกิดข้อผิดผลาดกรูณาติดต่อผู้ดูแลระบบ " & ex.Message
            alert(error_ms)
            UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
            UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
        End Try
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            If String.IsNullOrEmpty(rdl_enterprise.SelectedValue) OrElse rdl_enterprise.SelectedValue = "0" Then
                alert("กรุณาเลือกเงื่อนไขการจดทะเบียนวิสาหกิจ")
                UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
                UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
            Else
                If String.IsNullOrEmpty(rdl_CerSD.SelectedValue) OrElse rdl_CerSD.SelectedValue = "0" Then
                    alert("กรุณาเลือกกาารรับรองมาตรฐานสถานที่")
                    UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
                    UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
                Else
                    If rdl_CerSD.SelectedValue = "1" AndAlso String.IsNullOrEmpty(rdl_cer.SelectedValue) Then
                        alert("กรุณาเลิอกประเภทกกาารรับรองมาตรฐานสถานที่")
                        UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
                        UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
                    Else
                        'Dim EnterpriseChk As String = rdl_enterprise.SelectedValue
                        'If EnterpriseChk = "" Then EnterpriseChk = 0
                        'If (Convert.ToInt32(EnterpriseChk)) = 0 Then
                        '    alert("กรุณาเลือกเงื่อนไขเพิ่มเติมก่อนดำเนินรายการต่อ")
                        'Else
                        Dim bao_tran As New BAO_TRANSECTION
                        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
                        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                        dao_lcn.GetDataby_IDA(_IDA_LCN)
                        dao.GET_DATA_BY_FK_LCN(_IDA_LCN, True)
                        Dim dao_licen As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
                        dao_licen.GetDataby_LCN_IDA(_IDA_LCN)
                        Dim dao_li As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
                        dao_li.GetDataby_LCN_IDA(_IDA_LCN)
                        Data_set(dao)
                        'If _ProcessID Is Nothing Then
                        '    _ProcessID = 10511
                        'End If
                        dao.fields.PROCESS_ID = _ProcessID
                        If dao.fields.IDA = 0 Then
                            Try
                                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                                TR_ID = bao_tran.insert_transection(_ProcessID)
                                dao.fields.CerSD_TYPE = rdl_CerSD.SelectedValue
                                If Not String.IsNullOrEmpty(rdl_cer.SelectedValue) Then dao.fields.SUB_CerSD_TYPE = rdl_cer.SelectedValue
                                dao.fields.EnterpriseType = rdl_enterprise.SelectedValue
                                dao.fields.Newcode_Not = dao_licen.fields.Newcode_not
                                dao.fields.lcnno_display_new = dao_licen.fields.lcnno_display_new
                                dao.fields.Licensee_name = dao_li.fields.licen
                                dao.fields.Licensed_location = dao_licen.fields.thanm
                            Catch ex As Exception

                            End Try
                            'dao.fields.EnterpriseType = rdl_enterprise.SelectedValue
                            dao.fields.FK_LCT = dao_lcn.fields.FK_IDA
                            dao.fields.process_lcn = dao_lcn.fields.PROCESS_ID
                            dao.fields.pvncd = dao_licen.fields.chngwtcd
                            dao.fields.PROCESS_ID = _ProcessID
                            dao.fields.TR_ID = TR_ID
                            dao.fields.CREATE_ID = _CLS.CITIZEN_ID
                            dao.fields.Check_Confirm = "Y"
                            dao.fields.ACTIVEFACT = True
                            dao.fields.YEAR = Date.Now.Year
                            If Request.QueryString("staff") <> "" Then
                                dao.fields.INOFFICE_STAFF_ID = Request.QueryString("staff")
                                dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID_AUTHORIZE
                            End If
                            dao.insert()
                            _IDA = dao.fields.IDA
                        Else
                            If Not String.IsNullOrEmpty(rdl_CerSD.SelectedValue) Then dao.fields.CerSD_TYPE = rdl_CerSD.SelectedValue
                            If Not String.IsNullOrEmpty(rdl_cer.SelectedValue) Then dao.fields.SUB_CerSD_TYPE = rdl_cer.SelectedValue
                            If Not String.IsNullOrEmpty(rdl_enterprise.SelectedValue) Then dao.fields.EnterpriseType = rdl_enterprise.SelectedValue
                            dao.update()
                            TR_ID = dao.fields.TR_ID
                        End If
                        _IDA = dao.fields.IDA
                        INSERT_FILE_ATTACH(0, 0, TR_ID, _ProcessID)
                        If rdl_CerSD.SelectedValue = 1 Then
                            INSERT_FILE_ATTACH(11, 11, TR_ID, _ProcessID)
                        ElseIf rdl_CerSD.SelectedValue = 2 Then
                            INSERT_FILE_ATTACH(1, 1, TR_ID, _ProcessID)
                        End If
                        If rdl_enterprise.SelectedValue = 1 OrElse rdl_enterprise.SelectedValue = 2 OrElse rdl_enterprise.SelectedValue = 3 OrElse
                       rdl_enterprise.SelectedValue = 4 Then
                            INSERT_FILE_ATTACH(3, 3, TR_ID, _ProcessID)
                        End If
                        If Request.QueryString("staff") <> "" Then
                            'INSERT_FILE_ATTACH(1, 1, TR_ID, _ProcessID)
                            INSERT_FILE_ATTACH(2, 2, TR_ID, _ProcessID)
                            'INSERT_FILE_ATTACH(3, 1, TR_ID, _ProcessID)
                        End If
                        Response.Redirect("POP_UP_LCN_RENEW_CHECK_UPLOAD.aspx?IDA=" & dao.fields.IDA & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _ProcessID & "&CONDITION=Y")
                        'End If
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error_ms As String = "ระบบเกิดข้อผิดผลาดกรูณาติดต่อผู้ดูแลระบบ " & ex.Message
            alert(error_ms)
            UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
            UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
        End Try

    End Sub
    Sub INSERT_FILE_ATTACH(ByVal Head_ID As Integer, ByVal ID As Integer, ByVal TR_ID As String, ByVal Process_ID As String)
        Dim dao_mas As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        dao_mas.GetDataby_HEAD_ID_AND_PROCESS(ID, _ProcessID)
        Dim dao_up1 As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_up1.GetDaTaby_TR_ID_PROCECSS_TYPE_And_HEAD_ID(TR_ID, Process_ID, 1, Head_ID)
        If dao_up1.fields.IDA = 0 Then
            For Each dao_mas.fields In dao_mas.datas
                Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                dao_up.fields.CREATE_DATE = Date.Now
                dao_up.fields.PROCESS_ID = _ProcessID
                dao_up.fields.DOCUMENT_NAME = dao_mas.fields.DOCUMENT_NAME
                dao_up.fields.FK_IDA = _IDA_LCN
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE = 1
                dao_up.fields.TR_ID = TR_ID
                dao_up.fields.DocID = dao_mas.fields.ID
                dao_up.fields.Head_ID = Head_ID
                dao_up.fields.Forcible = dao_mas.fields.Forcible
                dao_up.fields.Active = True
                dao_up.insert()
            Next
        End If
    End Sub

    Protected Sub rdl_CerSD_SelectIndexChanged(sender As Object, e As EventArgs) Handles rdl_CerSD.SelectedIndexChanged
        If rdl_CerSD.SelectedValue = 1 Then
            chk_rad1.Style.Add("display", "block")
        Else
            chk_rad1.Style.Add("display", "none")
        End If
        UC_LCN_DRUG_GROUP.bind_type(Request.QueryString("IDA_LCN"))
        UC_LCN_DRUG_GROUP.bind_table(Request.QueryString("IDA_LCN"))
    End Sub
End Class
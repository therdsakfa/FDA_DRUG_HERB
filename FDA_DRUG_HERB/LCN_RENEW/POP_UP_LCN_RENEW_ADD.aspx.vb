Imports Telerik.Web.UI
Public Class POP_UP_LCN_RENEW_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String = ""
    Private _IDA_LCN As Integer
    Private _IDEN As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")

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
        If Not IsPostBack Then

            bind_ddl_prefix()
            'UC_ATTACH1.NAME = "แผนที่ตั้งและสถานที่ประกอบการ:"
            'UC_ATTACH1.Bind_data("แผนที่ตั้งและสถานที่ประกอบการ:", 1)
            Get_data()
        End If
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_emc_prefix.DataSource = dt
        ddl_emc_prefix.DataBind()
        ddl_emc_prefix.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub Get_data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim Process_lcn As Integer = dao_lcn.fields.PROCESS_ID
        Dim dao_licen As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        dao_licen.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_li As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        dao_li.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao_lcn.fields.IDA)
        Dim dao_p As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao_p.GET_DATA_BY_FK_LCN_AP(_IDA_LCN, True)
        txt_Rename_Name.Text = dao_li.fields.licen
        'txt_phr_name.Text = dao_phr.fields.PHR_NAME
        txt_phr_name.Text = dao_li.fields.grannm_lo
        TxT_LCN_NUM.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
        TxT_Business_Name.Text = dao_licen.fields.thanm
        txt_addr.Text = dao_addr.fields.thaaddr
        txt_Building.Text = dao_addr.fields.thabuilding
        txt_floor.Text = dao_addr.fields.thafloor
        txt_room.Text = dao_addr.fields.tharoom
        txt_mu.Text = dao_addr.fields.thamu
        txt_Soi.Text = dao_addr.fields.thasoi
        txt_road.Text = dao_addr.fields.tharoad
        txt_tambol.Text = dao_addr.fields.thathmblnm
        txt_ampher.Text = dao_addr.fields.thaamphrnm
        txt_changwat.Text = dao_addr.fields.thachngwtnm
        txt_zipcode.Text = dao_addr.fields.zipcode
        txt_tel.Text = dao_addr.fields.tel
        Try
            txt_latitude.Text = dao_addr.fields.latitude
            txt_longitude.Text = dao_addr.fields.longitude
        Catch ex As Exception

        End Try
        txt_Opentime.Text = dao_lcn.fields.opentime
        txt_Write_Date.Text = Date.Now.ToString("dd/MM/yyyy")
        Txt_Write_At.Text = "อย"
        If dao.fields.CerSD_TYPE IsNot Nothing AndAlso dao.fields.CerSD_TYPE = 1 Then
            If dao.fields.CerSD_TYPE IsNot Nothing AndAlso dao.fields.CerSD_TYPE <> 0 Then rdl_CerSD.SelectedValue = dao.fields.CerSD_TYPE
            If dao.fields.SUB_CerSD_TYPE IsNot Nothing AndAlso dao.fields.SUB_CerSD_TYPE <> 0 Then
                rdl_cer.SelectedValue = dao.fields.SUB_CerSD_TYPE
                chk_rad1.Style.Add("display", "block")
            Else
                chk_rad1.Style.Add("display", "block")
            End If
        End If
        txt_emc_email.Text = dao_p.fields.emc_contact_email
        txt_emc_name.Text = dao_p.fields.emc_contact_name
        txt_emc_lname.Text = dao_p.fields.emc_contact_lname
        txt_emc_tel.Text = dao_p.fields.emc_contact_tel
        If dao_p.fields.emc_prefix_id IsNot Nothing AndAlso dao_p.fields.emc_prefix_id <> 0 Then ddl_emc_prefix.SelectedValue = dao_p.fields.emc_prefix_id
        If dao_p.fields.CerSD_TYPE IsNot Nothing AndAlso dao_p.fields.CerSD_TYPE <> 0 Then
            rdl_CerSD.SelectedValue = dao_p.fields.CerSD_TYPE
            rdl_CerSD.Enabled = True
        Else
            rdl_CerSD.SelectedValue = 2
        End If
        If dao_lcn.fields.PROCESS_ID = 120 Or dao_lcn.fields.PROCESS_ID = 121 Then
            rdl_CerSD.Enabled = False
        End If
        If dao_p.fields.EnterpriseType IsNot Nothing AndAlso dao_p.fields.EnterpriseType <> 0 Then
            rdl_enterprise.SelectedValue = dao_p.fields.EnterpriseType
            rdl_enterprise.Enabled = True
        Else
            rdl_enterprise.SelectedValue = 5
        End If
        If _CLS.PVCODE <> 10 Then
            Dim dao_chw As New DAO_CPN.clsDBsyschngwt
            dao_chw.GetData_by_chngwtcd(_CLS.PVCODE)
            Txt_Write_At.Text = "สสจ." & dao_chw.fields.thachngwtnm
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_FK_LCN(_IDA_LCN, True)
        Dim TR_ID As String = ""
        Dim IDA As Integer = 0
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao_licen As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        dao_licen.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_li As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        dao_li.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao_lcn.fields.IDA)
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        ' ดึงค่า latitude และ longitude ที่กรอกเข้ามาจาก txt_latitude.Text และ txt_longitude.Text
        Dim newLatitude As String = txt_latitude.Text
        Dim newLongitude As String = txt_longitude.Text
        If RDO_PHR_YES.Checked = False And RDO_PHR_NO.Checked = False Then
            alert("กรุณาเลือกการยื่นเอกสารผู้มีหน้าที่ปฏิบัติการ")
        Else
            If String.IsNullOrEmpty(rdl_CerSD.SelectedValue) AndAlso rdl_CerSD.SelectedValue <> "0" AndAlso dao_lcn.fields.PROCESS_ID = 122 Then
                alert("กรุณาเลือกกาารรับรองมาตรฐานสถานที่")
            Else
                If rdl_enterprise.SelectedValue = 0 Then
                    alert("กรุณาเลือกประเภทจดทะเบียนสถานที่")
                Else
                    ' เช็คว่าค่าใหม่ที่กรอกมาไม่เหมือนกับค่าปัจจุบันที่อยู่ใน DAO
                    If dao_addr.fields.latitude <> newLatitude OrElse dao_addr.fields.longitude <> newLongitude Then
                        ' ทำการอัพเดทเฉพาะเมื่อค่าใหม่ไม่เหมือนกับค่าปัจจุบัน
                        dao_addr.fields.latitude = newLatitude
                        dao_addr.fields.longitude = newLongitude
                        dao_addr.update()
                    End If
                    dao.fields.LCNNO_NEW_DISPLAY = TxT_LCN_NUM.Text
                    dao.fields.RENREW_NAME = txt_Rename_Name.Text
                    dao.fields.PHR_NAME = txt_phr_name.Text
                    dao.fields.BUSINESS_PLACE_NAME = TxT_Business_Name.Text
                    dao.fields.WRITE_AT = Txt_Write_At.Text
                    dao.fields.WRITE_DATE = txt_Write_Date.Text
                    dao.fields.thaaddr = txt_addr.Text
                    dao.fields.thabuilding = txt_Building.Text
                    Try
                        dao.fields.emc_prefix_id = ddl_emc_prefix.SelectedValue
                        dao.fields.emc_prefix_name = ddl_emc_prefix.SelectedItem.Text
                    Catch ex As Exception

                    End Try
                    dao.fields.emc_contact_email = txt_emc_email.Text
                    dao.fields.emc_contact_tel = txt_emc_tel.Text
                    dao.fields.emc_contact_name = txt_emc_name.Text
                    dao.fields.emc_contact_lname = txt_emc_lname.Text
                    dao.fields.emc_fullname = ddl_emc_prefix.SelectedItem.Text & txt_emc_name.Text & " " & txt_emc_lname.Text
                    Try
                        dao.fields.thamu = txt_mu.Text
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.CerSD_TYPE = rdl_CerSD.SelectedValue
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.SUB_CerSD_TYPE = rdl_cer.SelectedValue
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.EnterpriseType = rdl_enterprise.SelectedValue
                    Catch ex As Exception

                    End Try
                    'Try
                    '    dao.fields.system_ID = _CLS.SYSTEM_ID
                    'Catch ex As Exception

                    'End Try
                    dao.fields.thasoi = txt_Soi.Text
                    dao.fields.tharoad = txt_road.Text
                    dao.fields.thathmblnm = txt_tambol.Text
                    dao.fields.thaamphrnm = txt_ampher.Text
                    dao.fields.thachngwtnm = txt_changwat.Text
                    dao.fields.zipcode = txt_zipcode.Text
                    dao.fields.TEL = txt_tel.Text
                    dao.fields.fax = txt_fax.Text
                    dao.fields.OPENTIME = txt_Opentime.Text
                    dao.fields.STATUS_ID = 0
                    dao.fields.DOWNLOAD_TYPE = 0
                    dao.fields.ACTIVEFACT = 1
                    dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                    dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                    dao.fields.CREATE_BY = _CLS.THANM
                    If Request.QueryString("staff") = 1 Then
                        dao.fields.CREATE_ID = 1
                        dao.fields.INOFFICE_STAFF_ID = 1
                        dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
                    End If
                    dao.fields.lcnsid = dao_licen.fields.lcnsid
                    dao.fields.Newcode_Not = dao_licen.fields.Newcode_not
                    dao.fields.lcntpcd = dao_licen.fields.lcntpcd
                    dao.fields.FK_LCN = dao_lcn.fields.IDA
                    dao.fields.FK_LCT = dao_lcn.fields.FK_IDA
                    dao.fields.ORIGINAL_EXPIRE_DATE = dao_lcn.fields.expdate
                    dao.fields.ORIGINAL_EXPIRE_YEAR = dao_lcn.fields.expyear
                    dao.fields.process_lcn = dao_lcn.fields.PROCESS_ID
                    dao.fields.pvncd = dao_licen.fields.chngwtcd
                    If dao_lcn.fields.PROCESS_ID = 120 Then
                        dao.fields.PROCESS_ID = 10903
                    ElseIf dao_lcn.fields.PROCESS_ID = 121 Then
                        dao.fields.PROCESS_ID = 10902
                    ElseIf dao_lcn.fields.PROCESS_ID = 122 Then
                        dao.fields.PROCESS_ID = 10901
                    End If
                    dao.fields.YEAR = con_year(Date.Now().Year())
                    dao.fields.FK_PHR = dao_phr.fields.PHR_IDA
                    Try
                        dao.fields.SYSTEM_ID = _CLS.SYSTEM_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.latitude = txt_latitude.Text
                        dao_addr.fields.latitude = txt_latitude.Text
                    Catch ex As Exception
                        dao.fields.latitude = 0
                    End Try
                    Try
                        dao.fields.longitude = txt_longitude.Text
                        dao_addr.fields.longitude = txt_longitude.Text
                    Catch ex As Exception
                        dao.fields.longitude = 0
                    End Try
                    Try
                        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                        bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                        If dao.fields.IDA = 0 Then
                            TR_ID = bao_tran.insert_transection(_ProcessID)
                            dao.fields.TR_ID = TR_ID
                        End If
                    Catch ex As Exception

                    End Try
                    If dao.fields.IDA = 0 Then dao.insert() Else dao.update()
                    IDA = dao.fields.IDA
                    _ProcessID = dao.fields.PROCESS_ID
                    TR_ID = dao.fields.TR_ID
                    'Dim chk_file As Boolean
                    Try
                        'UC_ATTACH1.insert_renew(TR_ID, _ProcessID, IDA, 1)
                        'If chk_file = False Then
                        '    alert_summit("", 0)
                        'End If
                    Catch ex As Exception

                    End Try
                    'Dim TR_ID_RE As Integer = 0
                    Dim dao_p As New DAO_LCN.TB_DALCN_RENEW_PRE
                    dao_p.GET_DATA_BY_FK_LCN_AP(_IDA_LCN, True)
                    Dim TR_ID_RE As Integer = Convert.ToInt32(dao_p.fields.TR_ID)
                    Dim head_id As Integer = 0
                    Dim Pocess_pre As Integer = 10511
                    Dim id As Integer = 0
                    Dim id2 As Integer = 0
                    Dim type_p As String = ""
                    Dim type_b As String = ""
                    Dim type_l As String = ""
                    Dim process As Integer = 0
                    Dim dao_attgroup As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
                    Dim dao_attgroup2 As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
                    TR_ID = TR_ID
                    process = _ProcessID
                    Dim TYPE_ID As Integer = 1
                    dao_attgroup.GetDataby_TYPE_ID_AND_PROCESS(1, process)
                    Dim dao_at As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    'dao_at.GetDataby_Fk_ida_ProcessID_TR_ID(dao_p.fields.IDA, dao_p.fields.PROCESS_ID, TR_ID_RE)
                    dao_at.GetDataby_FK_IDA_AND_TR_ID(dao_p.fields.IDA, TR_ID_RE)
                    Dim CerSD_ID As Integer = 0
                    Dim EnterP_ID As Integer = rdl_enterprise.SelectedValue
                    Dim btn As Button = CType(sender, Button)
                    If dao_p.fields.IDA = 0 Then
                        INSERT_FILE_ATTACH(IDA, 0, TR_ID, Pocess_pre, 1)
                        INSERT_FILE_ATTACH(IDA, 2, TR_ID, _ProcessID, 1)
                        If rdl_CerSD.SelectedValue = 1 Then
                            INSERT_FILE_ATTACH(IDA, 11, TR_ID, Pocess_pre, 1)
                        ElseIf rdl_CerSD.SelectedValue = 2 Then
                            INSERT_FILE_ATTACH(IDA, 1, TR_ID, Pocess_pre, 1)
                        End If
                        If rdl_enterprise.SelectedValue = 1 OrElse rdl_enterprise.SelectedValue = 2 OrElse rdl_enterprise.SelectedValue = 3 _
                            OrElse rdl_enterprise.SelectedValue = 4 Then
                            INSERT_FILE_ATTACH(IDA, 3, TR_ID, Pocess_pre, 1)
                        End If
                    Else
                        For Each dao_at.fields In dao_at.datas
                            Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                            dao_att.fields.DOCUMENT_NAME = dao_at.fields.DOCUMENT_NAME
                            dao_att.fields.NAME_FAKE = dao_at.fields.NAME_FAKE
                            dao_att.fields.NAME_REAL = dao_at.fields.NAME_REAL
                            dao_att.fields.TYPE_PERSON = 0
                            dao_att.fields.TYPE_LOCAL = 0
                            dao_att.fields.TYPE_BSN = 0
                            dao_att.fields.TYPE = TYPE_ID
                            dao_att.fields.FK_IDA = dao.fields.IDA
                            dao_att.fields.TR_ID = TR_ID
                            dao_att.fields.PROCESS_ID = _ProcessID
                            dao_att.fields.Forcible = dao_at.fields.Forcible
                            dao_att.fields.TYPE_PERSON_NAME = ""
                            dao_att.fields.TYPE_LOCAL_NAME = ""
                            dao_att.fields.TYPE_BSN_NAME = ""
                            dao_att.fields.DocID = dao_at.fields.DocID
                            dao_att.fields.FilePath = dao_at.fields.FilePath
                            dao_att.fields.Active = dao_at.fields.Active
                            dao_att.insert()
                        Next
                    End If
                    Dim dao_att1 As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    dao_att1.GetDataby_TR_ID_AND_PROCESS_AND_DOC(TR_ID, process, "คำรับรองของผู้มีหน้าที่ปฏิบัติการตามแบบ สมพ. ๔")
                    If RDO_PHR_YES.Checked = True Then
                        dao_att1.fields.NAME_FAKE = "HB-" & process & "-" & Date.Now.Year & "-" & TR_ID & "_" & dao_att1.fields.IDA & "." & "pdf"
                        dao_att1.fields.NAME_REAL = "คำรับรองของผู้มีหน้าที่ปฏิบัติการตามแบบ สมพ. ๔"
                        dao_att1.update()
                    End If
                    If RDO_PHR_NO.Checked = True Then
                        'INSERT_FILE_ATTACH(IDA, 3, TR_ID, process, 1)
                        INSERT_FILE_ATTACH(IDA, 4, TR_ID, process, 1)
                    End If
                    AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, dao.fields.IDA)
                    alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", IDA, _ProcessID)
                End If
            End If
        End If
    End Sub
    Sub INSERT_FILE_ATTACH(ByVal IDA As Integer, ByVal HeadID As Integer, ByVal TR_ID As String, ByVal Process_ID As String, ByVal TYPE_ID As String)
        Dim dao_mas As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        dao_mas.GetDataby_HEAD_ID_AND_PROCESS(HeadID, Process_ID)
        Dim dao_up1 As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_up1.GetDaTaby_FK_TR_PROCECSS_And_HEAD_ID(IDA, TR_ID, Process_ID, HeadID)
        If dao_up1.fields.IDA = 0 Then
            For Each dao_mas.fields In dao_mas.datas
                Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                dao_up.fields.CREATE_DATE = Date.Now
                dao_up.fields.PROCESS_ID = _ProcessID
                dao_up.fields.DOCUMENT_NAME = dao_mas.fields.DOCUMENT_NAME
                dao_up.fields.FK_IDA = _IDA_LCN
                dao_up.fields.FK_IDA = IDA
                dao_up.fields.TYPE = TYPE_ID
                dao_up.fields.TR_ID = TR_ID
                dao_up.fields.DocID = dao_mas.fields.ID
                dao_up.fields.TYPE_PERSON = dao_mas.fields.HEAD_ID
                dao_up.fields.Head_ID = dao_mas.fields.HEAD_ID
                dao_up.fields.TYPE_PERSON_NAME = ""
                dao_up.fields.TYPE_LOCAL_NAME = ""
                dao_up.fields.TYPE_BSN_NAME = ""
                dao_up.fields.Active = True
                dao_up.fields.Forcible = dao_mas.fields.Forcible
                dao_up.insert()
            Next
        End If
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer, ByVal Process_ID As Integer)
        Dim url As String = ""
        url = "POP_UP_LCN_RENEW_UPLOAD_FILE.aspx?IDA=" & ida & "&PROCESS_ID=" & Process_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub RDO_PHR_YES_CheckedChanged(sender As Object, e As EventArgs) Handles RDO_PHR_YES.CheckedChanged
        panel_phr.Style.Add("display", "block")
        GetdatatablePHR()
        rgphr.Rebind()
    End Sub
    Protected Sub RDO_PHR_NO_CheckedChanged(sender As Object, e As EventArgs) Handles RDO_PHR_NO.CheckedChanged
        panel_phr.Style.Add("display", "none")
    End Sub
    Sub GetdatatablePHR()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        Try
            dt = bao.SP_SMP_BY_FK_LCN_IDA(_IDA_LCN)
            'dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(_IDA_LCN)
        Catch ex As Exception
            'FRM_STAFF_LCN_PHR_EDIT.aspx
        End Try
        If dt.Rows.Count > 0 Then
            rgphr.DataSource = dt
            rgphr.Rebind()
            panel_phr.Visible = True
        Else
            alert("ผู้มีหน้าที่ปฏิบัติการ ไม่ได้ยื่นคำขอ สมพ 4 ผ่านระบบ ให้ท่านยื่นเอกสารผู้มีหน้าที่ปฏิบัติการ โดยการยื่นแบบกระดาษ")
            RDO_PHR_NO.Checked = True
            panel_phr.Visible = False
        End If
    End Sub

    Private Sub rgphr_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgphr.NeedDataSource
        'Dim bao As New BAO_SHOW
        'Dim dt As New DataTable
        'Try
        '   dt = bao.SP_SMP_BY_FK_LCN_IDA(_IDA_LCN)
        '    'dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(_IDA_LCN)
        'Catch ex As Exception
        '    'FRM_STAFF_LCN_PHR_EDIT.aspx
        'End Try
        'If dt.Rows.Count > 0 Then
        '    rgphr.DataSource = dt
        '    panel_phr.Visible = True
        'Else
        '    alert("ผู้มีหน้าที่ปฏิบัติการ ไม่ได้ยื่นคำขอ สมพ 4 ผ่านระบบ ให้ท่านยื่นเอกสารผู้มีหน้าที่ปฏิบัติการ โดยการยื่นแบบกระดาษ")
        '    RDO_PHR_NO.Checked = True
        '    panel_phr.Visible = False
        'End If
    End Sub
    Private Sub rgphr_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgphr.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("PHR_IDA").Text
            Dim PATH As String = ""
            Dim bao As New BAO.AppSettings
            Dim paths As String = bao._PATH_XML_PDF_PHR
            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PHR_PREVIEW.aspx?ida=" & IDA '& "&path= " & paths
        End If

    End Sub
    Private Sub rgphr_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgphr.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item

        '    Dim IDA As Integer = item("PHR_IDA").Text
        '    'Dim STATUS_ID As Integer = item("STATUS_ID").Text

        '    If e.CommandName = "sel" Then
        '        Response.Redirect("../LCN_RENEW/POP_UP_LCN_PREVIEW_SMP4.aspx?ida=" & IDA) '& " ,target=_blank")
        '    End If
        'End If
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Protected Sub rdl_CerSD_SelectIndexChanged(sender As Object, e As EventArgs) Handles rdl_CerSD.SelectedIndexChanged
        If rdl_CerSD.SelectedValue = 1 Then
            chk_rad1.Style.Add("display", "block")
        Else
            chk_rad1.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub txt_latitude_TextChanged(sender As Object, e As EventArgs) Handles txt_latitude.TextChanged
        Dim newLatitude As String = txt_latitude.Text
        Dim newLongitude As String = txt_longitude.Text
        ' เช็คว่าค่าใหม่ที่กรอกมาไม่เหมือนกับค่าปัจจุบันที่อยู่ใน DAO
        Try
            Double.TryParse(txt_latitude.Text, newLatitude)
            If newLatitude < 5.0 Or newLatitude > 21.0 Then
                alert("กรุณากรอกค่าระหว่าง 5.0 ถึง 21.0")
            End If
        Catch ex As Exception
            alert("กรุณากรอกค่าเป้นตัวเลข")
        End Try

    End Sub

    Protected Sub txt_longitude_TextChanged(sender As Object, e As EventArgs) Handles txt_longitude.TextChanged
        Dim newLatitude As String = txt_latitude.Text
        Dim newLongitude As String = txt_longitude.Text
        Double.TryParse(txt_longitude.Text, newLongitude)
        If newLongitude < 97.0 Or newLongitude > 106.0 Then
            alert("กรุณากรอกค่าระหว่าง 97.0 ถึง 106.0")
        End If
    End Sub
End Class
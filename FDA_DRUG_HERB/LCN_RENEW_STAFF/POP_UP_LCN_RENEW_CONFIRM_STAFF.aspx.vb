Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Imports Telerik.Web.UI
Public Class POP_UP_LCN_RENEW_CONFIRM_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As String
    Private _IDA_RN As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDA_RN = Request.QueryString("IDA")

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
            HiddenField2.Value = 0
            bind_dd()
            bind_mas_staff()
            GetData()
            Bind_PDF()
        End If
    End Sub
    Sub GetData()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA_RN)
        Dim SSID As Integer = dao.fields.STATUS_ID
        RDP_DATE_REQ.SelectedDate = Date.Now
        If SSID = 7 Or SSID = 77 Or SSID = 78 Or SSID = 777 Then
            DD_STATUS.SelectedValue = SSID
            DD_STATUS.Enabled = False
            RDP_DATE_REQ.Enabled = True
            DD_OFF_REQ.Visible = False
            btn_sumit.Enabled = False
        ElseIf SSID = 76 Then
            DD_STATUS.SelectedValue = SSID
            DD_STATUS.Enabled = False
            RDP_DATE_REQ.Enabled = False
            DD_OFF_REQ.Enabled = False
            btn_sumit.Enabled = False
        End If
        DD_OFF_REQ.SelectedValue = _CLS.CITIZEN_ID
        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        lbl_emc_name.Text = dao.fields.emc_prefix_name & " " & dao.fields.emc_contact_name & " " & dao.fields.emc_contact_lname
        If dao.fields.emc_contact_tel = "" Then lbl_emc_tel.Text = "-" Else lbl_emc_tel.Text = dao.fields.emc_contact_tel
        lbl_emc_email.Text = dao.fields.emc_contact_email
        If dao.fields.CerSD_TYPE IsNot Nothing AndAlso dao.fields.CerSD_TYPE = 1 Then
            If dao.fields.CerSD_TYPE IsNot Nothing AndAlso dao.fields.CerSD_TYPE <> 0 Then rdl_CerSD.SelectedValue = dao.fields.CerSD_TYPE
            If dao.fields.SUB_CerSD_TYPE IsNot Nothing AndAlso dao.fields.SUB_CerSD_TYPE <> 0 Then
                rdl_cer.SelectedValue = dao.fields.SUB_CerSD_TYPE
                Div_Sub_Cer.Style.Add("display", "block")
            Else
                Div_Sub_Cer.Style.Add("display", "block")
            End If
        End If
        If dao.fields.CerSD_TYPE IsNot Nothing AndAlso dao.fields.CerSD_TYPE <> 0 Then
            rdl_CerSD.SelectedValue = dao.fields.CerSD_TYPE
            rdl_CerSD.Enabled = True
        Else
            rdl_CerSD.SelectedValue = 2
        End If
        If dao.fields.EnterpriseType IsNot Nothing AndAlso dao.fields.EnterpriseType <> 0 Then
            rdl_enterprise.SelectedValue = dao.fields.EnterpriseType
            rdl_enterprise.Enabled = True
        Else
            rdl_enterprise.SelectedValue = 5
        End If
    End Sub
    'Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
    Protected Sub btn_sumit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sumit.Click
        'btn_sumit.Enabled = False
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        Dim bao As New BAO.GenNumber
        Dim RCVNO As String = ""
        Dim RCVNO_HERB_NEW As String = ""
        Dim STATUS_ID As Integer
        Dim ddl_id As Integer = DD_OFF_REQ.SelectedValue
        Dim ddl_name As String = DD_OFF_REQ.SelectedItem.Text
        dao.GET_DATA_BY_IDA(_IDA_RN)
        Dim TR_ID As Integer = 0
        TR_ID = dao.fields.TR_ID
        'If STATUS_ID = 8 And UC_ATTACH2.CHK_JJ = False Then
        '    alert_return("กรุณาแนบไฟล์ เอกสาร สมพ2 ที่ลงนามแล้ว")
        'Else
        If dao.fields.STATUS_ID = 21 Then
            STATUS_ID = 21
            Dim Status_pay As Integer = 0
            Dim dao_fee As New DAO_FEE.TB_feedtl
            dao_fee.Getdata_by_fk_id_process_id_and_ssid(_IDA_RN, _ProcessID, STATUS_ID)
            If dao_fee.fields.fk_id = _IDA_RN Then Status_pay = 1
            If Status_pay = 1 Then
                alert("เนื่องจากมีการออกใบสั่งชำระเงินแล้ว กรุณาทำการยกเลิกใบสั่งชำระแล้วทำรายการใหม่อีกครั้ง")
            Else
                dao.fields.Staff_operate_discount_date = RDP_DATE_REQ.SelectedDate
                dao.fields.Staff_operate_discount_by = DD_OFF_REQ.SelectedItem.Text
                dao.fields.Staff_operate_discount = DD_OFF_REQ.SelectedValue
                dao.fields.ML_FEE = txt_price_fee.Text
                Dim dao_f As New DAO_LCN.TB_MAS_DALCN_FEE_DISCOUNT
                dao_f.GET_DATA_BY_ID(ddl_fee_discount.SelectedValue)
                dao.fields.Fee_discount_ID = ddl_fee_discount.SelectedValue
                dao.fields.Fee_discount_NM = ddl_fee_discount.SelectedItem.Text
                dao.fields.Fee_discount_Detail = dao_f.fields.FEE_DETAIL
                dao.fields.Fee_discount_Note = txt_Fee_discount_Note.Text
                If ddl_fee_discount.SelectedValue = 2 Then dao.fields.STATUS_ID = 22
                Bind_PDF()
                dao.fields.UPDATE_DATE = DateTime.Now
                dao.update()
                AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA_RN)
                AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA_RN, ddl_id, ddl_name)
                alert("อัพเดทคำขอแล้ว")
            End If
        Else
            STATUS_ID = DD_STATUS.SelectedValue
            dao.fields.STATUS_ID = STATUS_ID
            If STATUS_ID = 8 Then
                'If _CLS.PVCODE <> 10 Then
                '    If UC_ATTACH2.CHK_JJ = False Then
                '        alert_return("กรุณาแนบไฟล์ เอกสาร สมพ2 ที่ลงนามแล้ว")
                '    ElseIf UC_ATTACH2.CHK_JJ = False Then
                '        alert_return("กรุณาแนบไฟล์ เอกสาร สมพ2 ที่ลงนามแล้ว")
                '    Else
                '        UC_ATTACH2.insert_renew_lcn(TR_ID, _ProcessID, _IDA_RN, 4)
                '    End If
                'Else
                If UC_ATTACH2.CHK_JJ = False Then

                Else
                    UC_ATTACH2.insert_renew_lcn(TR_ID, _ProcessID, _IDA_RN, 4)
                End If
                'End If
                dao.fields.appdate = CDate(RDP_DATE_REQ.SelectedDate)
                dao.fields.app_staff_name = DD_OFF_REQ.SelectedItem.Text
                dao.fields.DOWNLOAD_TYPE = 1
            ElseIf STATUS_ID = 23 Then
                dao.fields.staff_examine_date = CDate(RDP_DATE_REQ.SelectedDate)
                dao.fields.staff_examine_nm = DD_OFF_REQ.SelectedItem.Text
                dao.fields.staff_examine_id = DD_OFF_REQ.SelectedValue
                Bind_PDF()
            ElseIf STATUS_ID = 6 Then
                dao.fields.cnsdate = CDate(RDP_DATE_REQ.SelectedDate)
                dao.fields.cnsstaff_name = DD_OFF_REQ.SelectedItem.Text
                Bind_PDF()
            ElseIf STATUS_ID = 4 Then
                dao.fields.rcvdate = CDate(RDP_DATE_REQ.SelectedDate)
                dao.fields.rcv_staff_name = DD_OFF_REQ.SelectedItem.Text
                Bind_PDF()
            ElseIf STATUS_ID = 31 Or STATUS_ID = 3 Or STATUS_ID = 12 Then
                dao.fields.staff_edit_name = DD_OFF_REQ.SelectedItem.Text
                dao.fields.staff_edit_date = CDate(RDP_DATE_REQ.SelectedDate)
                dao.fields.staff_edit_id = DD_OFF_REQ.SelectedValue
                dao.fields.UPDATE_DATE = DateTime.Now
                dao.update()
                Dim dao_u As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                dao_u.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(TR_ID, _ProcessID, 2)
                For Each dao_u.fields In dao_u.datas
                    dao_u.fields.Active = False
                    dao_u.update()
                Next
                dao_u.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(TR_ID, _ProcessID, 3)
                dao_u.fields.Active = False
                dao_u.update()
                AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA_RN)
                Response.Redirect("POP_UP_LCN_RENEW_STAFF_EDIT.aspx?IDA=" & _IDA_RN & "&TR_ID=" & dao.fields.TR_ID & "&PROCESS_ID=" & _ProcessID)
            End If
            dao.fields.UPDATE_DATE = DateTime.Now
            dao.update()
            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA_RN)
            AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA_RN, ddl_id, ddl_name)
            If STATUS_ID = 8 Then
                renew_date()
                Bind_PDF()
                BindData_PDF()
            End If
            alert("อัพเดทคำขอแล้ว")
        End If
        'End If
    End Sub

    Sub renew_date()
        Dim dao_rn As New DAO_LCN.TB_DALCN_RENEW
        dao_rn.GET_DATA_BY_IDA(_IDA_RN)
        Dim _IDA As Integer = dao_rn.fields.FK_LCN
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim ExpDate_old As Date
        Dim ExpDate_new As Date
        Dim ExpYear_Old As String = dao_rn.fields.ORIGINAL_EXPIRE_YEAR
        Dim ExpYear_New As Integer
        If Not dao_rn.fields.NEW_EXPIRE_DATE.HasValue Then
            ExpDate_old = dao.fields.expdate
            If IsNothing(CDate(RDP_DATE_REQ.SelectedDate)) = False Then
                Dim appdate As Date = CDate(CDate(RDP_DATE_REQ.SelectedDate))
                Dim expyear As Integer = 0
                ExpDate_new = dao.fields.expdate
                ExpDate_new = ExpDate_new.AddYears(5)
                ExpYear_New = (ExpDate_new.Year.ToString() + 543)
                'ExpYear_New = (ExpYear_New + 5)
                Try
                    'expyear = Year(appdate)
                    'If expyear <> 0 Then
                    '    If expyear < 2500 Then
                    '        expyear += 543
                    '    End If
                    '    'dao.fields.expyear = expyear
                    '    dao.fields.expyear = ExpYear_New
                    'End If
                    dao.fields.expyear = ExpYear_New
                Catch ex As Exception

                End Try

                Try
                    If dao.fields.PROCESS_ID = "120" Or dao.fields.PROCESS_ID = "121" Or dao.fields.PROCESS_ID = "122" Then
                        'dao.fields.expdate = DateAdd(DateInterval.Year, 5, appdate)
                        dao.fields.expdate = ExpDate_new
                    End If

                Catch ex As Exception

                End Try
                'dao.fields.STATUS_ID = 8
                dao.update()
            End If
            dao_rn.fields.EXPIRE_DATE = ExpDate_new
            dao_rn.fields.EXPIRE_YEAR = ExpYear_New
            dao_rn.fields.NEW_EXPIRE_DATE = ExpDate_new
            dao_rn.fields.NEW_EXPIRE_YEAR = ExpYear_New
            dao_rn.update()
            'End If
            'alert("บันทึกข้อมูลเรียบร้อย")
            Dim dao_lcn As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            dao_lcn.GetDataby_IDA_DALCN(_IDA_LCN)
            dao_lcn.fields.expdate = ExpDate_new
            dao_lcn.fields.lmdfdate = DateTime.Now
            dao_lcn.fields.UPDATE_DATE = DateTime.Now
            dao_lcn.update()
            Run_Service(_IDA)
            Try
                Dim dao_log As New DAO_LCN.TB_LOG_RENEW_HERB
                dao_log.fields.date_renew = Date.Now
                dao_log.fields.ExpDate_Old = ExpDate_old
                dao_log.fields.ExpDate_New = ExpDate_new
                dao_log.fields.ExpYear_Old = ExpYear_Old
                dao_log.fields.ExpYear_New = ExpYear_New
                dao_log.fields.FK_IDA = dao.fields.IDA
                dao_log.fields.TR_ID = dao.fields.TR_ID
                dao_log.fields.PROCESS_ID = dao.fields.PROCESS_ID
                dao_log.fields.citizen_id = _CLS.CITIZEN_ID
                dao_log.fields.description = "ต่ออายุใบอนุญาต"
                dao_log.insert()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub Run_Service(ByVal IDA As Integer)
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.HERB_UPDATE_LICEN(IDA, _CLS.CITIZEN_ID)
    End Sub
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim ss_id As Integer = 0
        Dim ss_id2 As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA_RN)
        Dim SSID As Integer = dao.fields.STATUS_ID
        Dim SSID_ED As Integer = 0
        If dao.fields.STATUS_EDIT IsNot Nothing AndAlso dao.fields.STATUS_EDIT <> 0 Then SSID_ED = dao.fields.STATUS_EDIT
        Dim STGroup As Integer = 109
        Dim dao_s As New DAO_DRUG.ClsDBMAS_STATUS
        dao_s.GetDataBy_StatusGroupAndStatusID(501, SSID)
        If (SSID = 32 Or SSID = 22) And (SSID_ED = 0 Or SSID_ED = 1) Then
            ss_id = 0
            ss_id2 = 11
            'ElseIf SSID = 32 Or SSID = 22 Then
            '    ss_id = 0
            '    ss_id2 = 11
        ElseIf (SSID = 32 Or SSID = 22 Or SSID = 23) And (SSID_ED = 2 Or SSID_ED = 1) Then
            ss_id = 0
            ss_id2 = 1
        ElseIf (SSID = 32 Or SSID = 22 Or SSID = 23) And SSID_ED = 0 Then
            ss_id = 0
            ss_id2 = 1
        ElseIf (SSID = 4 Or SSID = 61 Or SSID = 62 Or SSID = 63 Or SSID = 64 Or SSID = 65 Or SSID = 66 Or SSID = 67) Then
            ss_id = 0
            ss_id2 = 2
            btn_lcn_edit.Visible = True
            btn_drug_group_edit.Visible = True
        ElseIf SSID = 8 Then
            P12.Visible = False
            btn_sumit.Visible = False
            'KEEP_PAY.Visible = False
            btn_preview.Visible = True
            panel_file_att.Visible = True
        Else
            ss_id = 0
        End If
        If SSID = 21 Then
            dao.GET_DATA_BY_IDA(_IDA_RN)
            Dim dao_f As New DAO_FEE.TB_feetype
            Dim process_lcn As Integer = dao.fields.process_lcn
            dao_f.GetDataby_PROCESS_ID_AND_STATUS_ID(_ProcessID, dao.fields.STATUS_ID)
            If dao.fields.ML_FEE IsNot Nothing AndAlso dao.fields.ML_FEE <> 0 Then txt_price_fee.Text = dao.fields.ML_FEE Else txt_price_fee.Text = dao_f.fields.value
            If dao.fields.Fee_discount_ID IsNot Nothing AndAlso dao.fields.Fee_discount_ID <> 0 Then ddl_fee_discount.SelectedValue = dao.fields.Fee_discount_ID
            If dao.fields.Fee_discount_Note IsNot Nothing AndAlso dao.fields.Fee_discount_Note <> "" Then txt_Fee_discount_Note.Text = dao.fields.Fee_discount_Note
            DIV_FEE_DISCOUNT.Visible = True
            DIV_STATUS_DDL.Visible = False
            bind_ddl_fee_discount()
        End If
        If SSID = 8 OrElse SSID = 4 Or SSID = 61 Or SSID = 62 Or SSID = 63 Or SSID = 64 Or SSID = 65 Or SSID = 66 Or SSID = 67 Then
            btn_preview.Visible = True
        End If
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2(STGroup, ss_id, ss_id2, 0)
        dt = bao.dt
        DD_STATUS.DataSource = dt
        DD_STATUS.DataValueField = "STATUS_ID"
        DD_STATUS.DataTextField = "STATUS_NAME_STAFF"
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        Dim PVNCD As Integer = _CLS.PVCODE
        Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_NAME_HERB
        dao_s.GetDataby_CZTNO(_CLS.CITIZEN_ID)
        Dim Staff_id As Integer = 0
        If dao_s.fields.IDA <> 0 Then Staff_id = dao_s.fields.IDA
        If PVNCD = 10 Then
            dt = bao.SP_MAS_STAFF_NAME_HERB()
        Else
            dt = bao.SP_MAS_STAFF_NAME_HERB_BY_PVNCD(PVNCD)
        End If
        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
        Dim CitizenID As String = _CLS.CITIZEN_ID
        If dao_s.fields.IDA <> 0 Then DD_OFF_REQ.SelectedValue = Staff_id
    End Sub
    Public Sub bind_ddl_fee_discount()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim ss_id As Integer = 0
        Dim ss_id2 As Integer = 0
        Dim dao As New DAO_LCN.TB_MAS_DALCN_FEE_DISCOUNT
        dao.GetDataAll_IsUse()
        ddl_fee_discount.DataSource = dao.datas
        ddl_fee_discount.DataValueField = "ID"
        ddl_fee_discount.DataTextField = "DiscountName"
        ddl_fee_discount.DataBind()
        ddl_fee_discount.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub Bind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA_RN)
        'Dim _ProcessID As String = 10501
        Dim XML As New CLASS_GEN_XML.DALCN_RENEW
        LCN_RENEW = XML.Gen_XML_LCN_RENEW(_IDA_RN, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "สมพ5", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_RENREW") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PDF", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA_RN)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("XML", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA_RN)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    'Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
    '    Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    'End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA_RN)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
            'STATUS_UPLOAD_ID = 1
        Catch ex As Exception
            STATUS_UPLOAD_ID = 1
        End Try

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, STATUS_UPLOAD_ID)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat.NeedDataSource
        rgat.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgat.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
    Function bind_data_uploadfile2()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA_RN)
        Dim STATUS_UPLOAD_ID As Integer = 0
        'Try
        '    STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        '    'STATUS_UPLOAD_ID = 1
        'Catch ex As Exception
        '    STATUS_UPLOAD_ID = 1
        'End Try

        dt = bao.SP_DALCN_UPLOAD_FILE_EDIT_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 2)

        Return dt
    End Function

    Private Sub rgat_edit_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat_edit.NeedDataSource
        rgat_edit.DataSource = bind_data_uploadfile2()
    End Sub

    Private Sub rgat_edit_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgat_edit.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_ST")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
        End If
    End Sub
    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim _group As Integer = 0
        HiddenField2.Value = 0
        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 1
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 0
        End If
        'show01.Visible = True
        BindData_PDF(_group:=_group)

    End Sub
    Private Sub BindData_PDF(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao_rn As New DAO_LCN.TB_DALCN_RENEW
        dao_rn.GET_DATA_BY_IDA(_IDA_RN)
        Dim _IDA As Integer = dao_rn.fields.FK_LCN
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim lcnno_format_NEW As String = ""
        Dim pvncd As String = ""
        Dim _TR_ID As String = ""
        Dim _iden As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)
        Try
            _TR_ID = dao_up.fields.ID
            _iden = dao.fields.CITIZEN_ID
        Catch ex As Exception

        End Try
        Dim ProcessID As String = ""
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If PROCESS_ID = "" Then
            PROCESS_ID = dao.fields.PROCESS_ID
        End If
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception

        End Try
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntpcd = Chn_lcntpcd(lcntpcd)
        Dim lcnsid_da As Integer = 0
        Try
            lcnsid_da = dao.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, lcnsid_da, lcnno:=lcnno_auto, lcntpcd:=lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()

        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(1, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        'class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA(_IDA)
        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao.fields.FK_IDA) ' 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)

        Dim tt As Integer = 0
        If dao.fields.lcntpcd.Contains("ผ") Then
            tt = 1
            'ElseIf dao.fields.lcntpcd.Contains("น") Then
            '   tt = 2
        Else
            tt = 3
        End If
        If tt = 1 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        ElseIf tt = 2 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB_V3(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        ElseIf tt = 3 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB2(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        End If

        Dim dt9 As New DataTable

        'dt9 = class_xml.DT_SHOW.DT9
        For Each drr As DataRow In class_xml.DT_SHOW.DT9.Rows
            Try
                drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
            Catch ex As Exception

            End Try
            Try
                '
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                drr("tharoom") = NumEng2Thai(drr("tharoom"))
            Catch ex As Exception

            End Try
            Try
                drr("thanameplace") = NumEng2Thai(drr("thanameplace"))
            Catch ex As Exception

            End Try
            Try
                drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
            Catch ex As Exception

            End Try
            Try
                drr("tel1") = NumEng2Thai(drr("tel1"))
            Catch ex As Exception

            End Try
            '
            '
            Try
                drr("thamu") = NumEng2Thai(drr("thamu"))
            Catch ex As Exception

            End Try
            Try
                drr("thafloor") = NumEng2Thai(drr("thafloor"))
            Catch ex As Exception

            End Try
            Try
                drr("thasoi") = NumEng2Thai(drr("thasoi"))
            Catch ex As Exception

            End Try
            Try
                drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
            Catch ex As Exception

            End Try
            Try
                drr("tharoad") = NumEng2Thai(drr("tharoad"))
            Catch ex As Exception

            End Try
            Try
                drr("zipcode") = NumEng2Thai(drr("zipcode"))
            Catch ex As Exception

            End Try
            Try
                drr("tel") = NumEng2Thai(drr("tel"))
            Catch ex As Exception

            End Try
            Try
                drr("fax") = NumEng2Thai(drr("fax"))
            Catch ex As Exception

            End Try
            Try
                drr("Mobile") = NumEng2Thai(drr("Mobile"))
            Catch ex As Exception

            End Try
            Try
                drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
            Catch ex As Exception

            End Try

        Next
        'class_xml.DT_SHOW.DT9 = dt9

        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Dim DT11 As New DataTable
        Try
            'DT11 = class_xml.DT_SHOW.DT11
            For Each drr As DataRow In class_xml.DT_SHOW.DT11.Rows
                Try
                    If drr("thaaddr") = "" Then
                        drr("thaaddr") = "-"
                    End If
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"

        Try
            Dim dao_phr_c As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr_c.GetDataby_FK_IDA(_IDA)
            Dim c_phr As Integer = 0
            For Each dao_phr_c.fields In dao_phr_c.datas
                c_phr += 1
            Next
            class_xml.PHR_COUNT = c_phr
        Catch ex As Exception

        End Try

        Try
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            ' class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            'SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        Catch ex As Exception

        End Try

        'Dim bao_lisense_neme As New BAO.ClsDBSqlcommand
        Try
            class_xml.DT_MASTER.DT38 = bao_show.SP_Lisense_Name_and_Addr(_iden) 'ผู้ขออนุญาติ
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        Dim DT13 As New DataTable
        Try
            DT13 = class_xml.DT_SHOW.DT13
            For Each drr As DataRow In DT13.Rows
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน

        Dim BSN_IDENTIFY As String = ""
        Try
            'If MAIN_LCN_IDA <> 0 Then
            '    Dim dao_lcn2 As New DAO_DRUG.ClsDBdalcn
            '    dao_lcn2.GetDataby_IDA(MAIN_LCN_IDA)
            'End If
            BSN_IDENTIFY = NumEng2Thai(dao.fields.BSN_IDENTIFY)
        Catch ex As Exception

        End Try
        Dim MAIN_LCN_IDA As Integer = 0
        'If IsNothing(dao.fields.MAIN_LCN_IDA) = False Then
        '    If (Integer.TryParse(dao.fields.MAIN_LCN_IDA, MAIN_LCN_IDA) = True) Then        'เปลี่ยน ร
        '        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        '    End If
        'End If
        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(BSN_IDENTIFY) 'ผู้ดำเนิน
        'If MAIN_LCN_IDA <> 0 Then
        '    'ใบย่อย
        '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(MAIN_LCN_IDA) 'ผู้ดำเนิน

        '    'Dim dao_mn As New DAO_DRUG.ClsDBdalcn
        '    'dao_mn.GetDataby_IDA(MAIN_LCN_IDA)
        '    'lcnno_auto = dao_mn.fields.lcnno
        'Else

        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        'End If
        Dim dt14 As New DataTable
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        Try
            If dao_frgn.fields.addr_status = 0 Or dao_frgn.fields.addr_status = 1 Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_DALCN_CURRENT_ADDRESS(_IDA)
            ElseIf dao_frgn.fields.addr_status = Nothing Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            End If

        Catch ex As Exception

        End Try
        'Dim DT39 As New DataTable
        'Try
        '    DT39 = class_xml.DT_MASTER.DT39
        '    For Each drr As DataRow In DT39.Rows
        '        drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
        '        drr("CREATE_DATE") = NumEng2Thai(drr("CREATE_DATE"))
        '        drr("AGE") = NumEng2Thai(drr("AGE"))
        '        drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
        '        drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
        '        drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
        '        'fulladdr
        '    Next
        'Catch ex As Exception

        'End Try
        Try
            dt14 = class_xml.DT_SHOW.DT14
            For Each drr As DataRow In dt14.Rows
                drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA) 'ผู้มีหน้าที่ปฎิบัติการ
        'Dim DT18 As New DataTable

        'DT18 = class_xml.DT_MASTER.DT18
        'For Each drr As DataRow In DT18.Rows
        '    Try
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Catch ex As Exception

        '    End Try

        'Next
        class_xml.DT_SHOW.DT35 = bao_master.SP_DALCN_FRGN_DATA(_IDA)

        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao.fields.IDA)
        Dim DT24 As New DataTable
        Try
            DT24 = class_xml.DT_MASTER.DT24
            For Each drr As DataRow In DT24.Rows
                Try
                    drr("thanameplace2") = NumEng2Thai(drr("thanameplace2"))
                Catch ex As Exception

                End Try
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
            class_xml.DT_MASTER.DT24 = DT24
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        Dim DT25 As New DataTable
        Try
            DT25 = class_xml.DT_MASTER.DT25
            For Each drr As DataRow In DT25.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        Dim DT26 As New DataTable
        Try
            DT26 = class_xml.DT_MASTER.DT26
            For Each drr As DataRow In DT26.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        Dim DT27 As New DataTable
        Try
            DT27 = class_xml.DT_MASTER.DT27
            For Each drr As DataRow In DT27.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 1)
        Dim DT28 As New DataTable
        Try
            DT28 = class_xml.DT_MASTER.DT28
            For Each drr As DataRow In DT28.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 2)
        Dim DT29 As New DataTable
        Try
            DT29 = class_xml.DT_MASTER.DT29
            For Each drr As DataRow In DT29.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"

        class_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(dao.fields.IDA)
        Dim DT31 As New DataTable

        DT31 = class_xml.DT_MASTER.DT31
        For Each drr As DataRow In DT31.Rows
            Try
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Catch ex As Exception

            End Try

        Next


        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try
        'Try
        '    If Len(lcnno_auto) > 0 Then

        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
        '        Else
        '            lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
        Try
            If dao.fields.REVOCATION Is Nothing Or Trim(dao.fields.REVOCATION) = "" Then
                If Len(lcnno_auto) > 0 Then

                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                        lcnno_format = dao.fields.pvnabbr & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                    'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)

                End If

                lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW

            Else

                Dim _type_da As String = ""
                If dao.fields.PROCESS_ID = "120" Then
                    _type_da = "3"
                ElseIf dao.fields.PROCESS_ID = "121" Then
                    _type_da = "2"
                ElseIf dao.fields.PROCESS_ID = "122" Then
                    _type_da = "1"
                End If

                If Not dao.fields.LCNNO_DISPLAY_NEW Is Nothing Then
                    lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    'Try
                    '    Dim App_Date As Date = dao.fields.appdate
                    '    If App_Date > #10/1/2019 12:00:00 AM# Then
                    '        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    '    Else
                    '        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then
                        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    End If
                    'lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                Else
                    lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

            Try
                'lcnno_format = 
                'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                    class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                Else
                    class_xml.HEAD_LCNNO = dao_main2.fields.pvnabbr & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                End If

                class_xml.HEAD_LCNNO = NumEng2Thai(class_xml.HEAD_LCNNO)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT32 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT32.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"
        class_xml.DT_MASTER.DT33 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT33.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"

        class_xml.DT_MASTER.DT34 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 3)
        Dim DT34 As New DataTable
        Try
            DT34 = class_xml.DT_MASTER.DT34
            For Each drr As DataRow In DT34.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
                drr("PHR_CERTIFICATE_TRAINING1") = NumEng2Thai(drr("PHR_CERTIFICATE_TRAINING1"))
                '
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT34.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_3_1_ROW"

        Dim rcvno_format As String = ""
        Dim RCV_DATE As String = ""
        Try
            'rcvno_format = dao.fields.RCVNO_NEW
            rcvno_format = dao.fields.RCVDATE_DISPLAY
        Catch ex As Exception

        End Try

        Dim rcvdate1 As Date
        Dim rcvdate2 As String = ""
        Try
            If dao.fields.rcvdate IsNot Nothing Then
                rcvdate1 = dao.fields.rcvdate
                rcvdate2 = CDate(rcvdate1).ToString("dd/MM/yyy")
            End If

        Catch ex As Exception

        End Try

        'class_xml.LCNNO_SHOW = lcnno_format
        'class_xml.SHOW_LCNNO = lcnno_text
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        Dim dao_li As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        dao_li.GetDataby_IDA_DALCN(_IDA_LCN)
        ' If MAIN_LCN_IDA = 0 Then
        'lcnno_format = dao.fields.LCNNO_DISPLAY
        'class_xml.LCNNO_SHOW = NumEng2Thai(lcnno_format)  RCVNO_FORMAT
        'class_xml.LCNNO_SHOW_NEW = NumEng2Thai(lcnno_format_NEW)
        Dim create_date As Date
        Try
            create_date = dao_up.fields.UPLOAD_DATE
        Catch ex As Exception
            Try
                create_date = dao.fields.CREATE_DATE
            Catch ex2 As Exception

            End Try
        End Try
        ' Compare create_date to 1/1/2563 (equivalent to 1/1/2020 in Gregorian calendar)
        If create_date > New Date(2020, 1, 1) Then
            ' Your code to handle the case where create_date is after 1/1/2563
            lcnno_format = dao_li.fields.lcnno_noo
            class_xml.LCNNO_SHOW = lcnno_format

        End If
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.RCVDATE_DISPLAY = rcvdate2
        class_xml.LCNNO_SHOW_NUMTHAI = NumEng2Thai(lcnno_format)
        class_xml.LCNNO_SHOW_NEW = lcnno_format_NEW
        class_xml.LCNNO_SHOW_NEW_NUMTHAI = NumEng2Thai(lcnno_format_NEW)
        class_xml.SHOW_LCNNO = lcnno_text
        class_xml.SHOW_LCNNO_NUMTHAI = NumEng2Thai(lcnno_text)
        Try

            class_xml.COUNT_PHESAJ1 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 1)
        Catch ex As Exception

        End Try

        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ2 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 2)
        Catch ex As Exception

        End Try
        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ3 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 3)
        Catch ex As Exception

        End Try
        'Else

        '    class_xml.LCNNO_SHOW = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(dao_main.fields.lcnno, 5))) & "/25" & Left(dao_main.fields.lcnno, 2)
        '    class_xml.SHOW_LCNNO = dao_main.fields.LCNNO_MANUAL
        'End If
        class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = NumEng2Thai(appdate.Day)
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = NumEng2Thai(con_year(appdate.Year))

                If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then

                    class_xml.RCVDAY_NUMTHAI_NEW = NumEng2Thai(appdate.Day.ToString())
                    class_xml.RCVMONTH_NUMTHAI_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NUMTHAI_NEW = NumEng2Thai(con_year(appdate.Year))

                    class_xml.RCVDAY_NEW = appdate.Day.ToString()
                    class_xml.RCVMONTH_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NEW = con_year(appdate.Year)


                End If


                class_xml.RCVDAY_NUMTHAI = NumEng2Thai(appdate.Day.ToString())
                class_xml.RCVMONTH_NUMTHAI = appdate.ToString("MMMM")
                class_xml.RCVYEAR_NUMTHAI = NumEng2Thai(con_year(appdate.Year))

                class_xml.RCVDAY = appdate.Day.ToString()
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(appdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)
            End If
        Else
            If IsNothing(dao.fields.expyear) = False Then
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                class_xml.EXP_YEAR = NumEng2Thai(expyear)
            End If
        End If
        If IsNothing(dao.fields.expdate) = False Then
            Dim expdate As Date
            If Date.TryParse(dao.fields.expdate, expdate) = True Then
                class_xml.SHOW_EXPDATE_DAY = expdate.Day
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR = con_year(expdate.Year)

                class_xml.SHOW_EXPDATE_DAY_NUMTHAI = NumEng2Thai(expdate.Day)
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR_NUMTHAI = NumEng2Thai(con_year(expdate.Year))


                class_xml.EXPDAY = NumEng2Thai(expdate.Day.ToString())
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXPYEAR = NumEng2Thai(con_year(expdate.Year))
                'Try
                '    class_xml.EXP_YEAR = dao.fields.expyear 'con_year(appdate.Year)
                'Catch ex As Exception
                '    class_xml.EXP_YEAR = con_year(appdate.Year)
                'End Try
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(expdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)

            End If
        End If




        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHRi
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        For Each dao_PHR.fields In dao_PHR.Details
            Try
                If dao_PHR.fields.PHR_TEXT_WORK_TIME <> "" Then
                    dao_PHR.fields.PHR_TEXT_WORK_TIME = NumEng2Thai(dao_PHR.fields.PHR_TEXT_WORK_TIME)
                End If
            Catch ex As Exception

            End Try
            class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        Next
        '-------------------------------------


        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
            Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
            cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm)
            Catch ex As Exception

            End Try
            class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)



        Catch ex As Exception

        End Try
        class_xml.dalcns = dao.fields
        Try
            class_xml.dalcns.CATEGORY_DRUG = NumEng2Thai(class_xml.dalcns.CATEGORY_DRUG)
        Catch ex As Exception

        End Try
        Try
            'class_xml.dalcns.opentime = NumEng2Thai(dao.fields.opentime)
            class_xml.dalcns.opentime = dao.fields.opentime
        Catch ex As Exception

        End Try

        class_xml.syslctaddr_engaddr = dao.fields.syslctaddr_engaddr
        class_xml.syslctaddr_floor = dao.fields.syslctaddr_floor
        class_xml.syslctaddr_mu = dao.fields.syslctaddr_mu
        class_xml.syslctaddr_room = dao.fields.syslctaddr_room
        class_xml.syslctaddr_thaaddr = dao.fields.syslctaddr_thaaddr
        class_xml.syslctaddr_thasoi = dao.fields.syslctaddr_thasoi

        Try
            If dao.fields.lcntpcd = "ขสม" Then
                class_xml.LCN_TYPE = "ขาย"
                class_xml.LCN_TYPE_ID = "3"
            ElseIf dao.fields.lcntpcd = "ผสม" Then
                class_xml.LCN_TYPE = "ผลิต"
                class_xml.LCN_TYPE_ID = "1"
            ElseIf dao.fields.lcntpcd = "นสม" Then
                class_xml.LCN_TYPE = "นำเข้า"
                class_xml.LCN_TYPE_ID = "2"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_pph As New DAO_DRUG.ClsDBDALCN_PHR
            dao_pph.GetDataby_FK_IDA(_IDA)
            If dao_pph.fields.PHR_LAW_SECTION = "1" Then
                class_xml.MASTRA = "มาตรา 31"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๑"
                class_xml.MASTRA_NO = "31"
                class_xml.MASTRA_NO_NUMTHAI = "๓๑"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "2" Then
                class_xml.MASTRA = "มาตรา 32"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๒"
                class_xml.MASTRA_NO = "32"
                class_xml.MASTRA_NO_NUMTHAI = "๓๒"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "3" Then
                class_xml.MASTRA = "มาตรา 33"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๓"
                class_xml.MASTRA_NO = "33"
                class_xml.MASTRA_NO_NUMTHAI = "๓๓"
            End If
        Catch ex As Exception

        End Try
        ''Dim URL_LINK As String = ""
        'Dim link As New WS_SHORTEN.RESPONSE_DATA
        'Try
        '    link = GET_SHORTEN_LINK(_IDA_LCN, _CLS.CITIZEN_ID_AUTHORIZE)
        '    class_xml.SHORT_CODE = link.CODE
        'Catch ex As Exception

        'End Try

        ' p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dalcn2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_dalcn2)

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = ""
        Try
            lcntype = dao.fields.lcntpcd
        Catch ex As Exception

        End Try

        'Dim url2 As String = "https://medicina.fda.moph.go.th/FDA_DRUG"
        'Dim Cls_qr As New QR_CODE.GEN_QR_CODE
        'Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2)try
        Dim ExpiteDate As Date
        Dim ExpiteDateNew As Date
        Dim ExpiteYear As String
        Dim thaiCulture As New CultureInfo("th-TH")
        Dim month As Integer = 0
        Try
            ExpiteDate = dao_rn.fields.ORIGINAL_EXPIRE_DATE
        Catch ex As Exception
            ExpiteDate = dao.fields.expdate
        End Try
        Try
            ExpiteDateNew = dao_rn.fields.NEW_EXPIRE_DATE
        Catch ex As Exception
            ExpiteDateNew = dao.fields.expdate
        End Try
        Try
            ExpiteYear = dao_rn.fields.NEW_EXPIRE_YEAR
        Catch ex As Exception

        End Try
        month = ExpiteDate.Month
        class_xml.EXPDAY = ExpiteDate.Day
        class_xml.EXPMONTH = thaiCulture.DateTimeFormat.GetMonthName(month)
        class_xml.EXPYEAR = ExpiteDate.Year
        class_xml.EXPDATE_FULL = ExpiteDate.Day & " " & thaiCulture.DateTimeFormat.GetMonthName(month) & " " & ExpiteDate.Year
        Try
            If dao_rn.fields.STATUS_ID = 8 Then
                Dim APP_DATE As Date = dao_rn.fields.appdate
                month = ExpiteDateNew.Month
                class_xml.EXPDAY_NEW = ExpiteDateNew.Day
                class_xml.EXPMONTH_NEW = thaiCulture.DateTimeFormat.GetMonthName(month)
                class_xml.EXPYEAR_NEW = ExpiteYear ' Convert to Buddhist Era
                class_xml.EXPDATE_FULL_NEW = ExpiteDateNew.Day & " " & thaiCulture.DateTimeFormat.GetMonthName(month) & " " & ExpiteYear

                class_xml.APPDAY = APP_DATE.Day.ToString()
                class_xml.APPMONTH_NEW = APP_DATE.ToString("MMMM")
                class_xml.APPYEAR_NEW = con_year(APP_DATE.Year)
            Else
                month = ExpiteDateNew.Month
                class_xml.EXPDAY_NEW = ExpiteDateNew.Day
                class_xml.EXPMONTH_NEW = thaiCulture.DateTimeFormat.GetMonthName(month)
                class_xml.EXPYEAR_NEW = (ExpiteDate.Year.ToString() + 5 + 543) ' Add 543 to get Buddhist Era
                class_xml.EXPDATE_FULL_NEW = ExpiteDateNew.Day & " " & thaiCulture.DateTimeFormat.GetMonthName(month) & " " & (ExpiteDateNew.Year)
            End If

        Catch ex As Exception
            class_xml.EXPDAY_NEW = ExpiteDate.Date.ToString() - 1
            class_xml.EXPMONTH_NEW = thaiCulture.DateTimeFormat.GetMonthName(month)
            class_xml.EXPYEAR_NEW = (ExpiteDate.Year.ToString() + 5 + 543) ' Add 543 to get Buddhist Era
            class_xml.EXPDATE_FULL_NEW = class_xml.EXPDAY_NEW & " " & class_xml.EXPMONTH_NEW & " " & class_xml.EXPYEAR_NEW
        End Try
        lcntype = Chn_lcntpcd(lcntype)
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim template_id As Integer = 0
        Dim dao_chw As New DAO_CPN.clsDBsyschngwt
        dao_chw.GetData_by_chngwtcd(dao_rn.fields.pvncd)
        If dao_rn.fields.STATUS_ID = 8 Then
            If dao_rn.fields.pvncd = 10 Then
                class_xml.POSITION_NAME = "กระทรวงสาธารณสุข"
                class_xml.SIGNATURE_NAME = "สำนักงานคณะกรรมการอาหารและยา"
                class_xml.SIGNATURE_PROVINCE = dao_chw.fields.thachngwtnm
            Else
                class_xml.POSITION_NAME = "กระทรวงสาธารณสุข"
                class_xml.SIGNATURE_NAME = "สำนักงานสาธารณสุขจังหวัด" & dao_chw.fields.thachngwtnm
                class_xml.SIGNATURE_PROVINCE = dao_chw.fields.thachngwtnm
            End If
        End If
        If _ProcessID = 10901 Or _ProcessID = 10902 Or _ProcessID = 10903 Then
            If dao_rn.fields.pvncd = 10 Then
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(_ProcessID, "สมพ2", dao_rn.fields.STATUS_ID, HiddenField2.Value, 0)
            Else
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(_ProcessID, "สมพ2", dao_rn.fields.STATUS_ID, HiddenField2.Value, 2)
            End If
        Else
            If statusId = 8 Then
                Dim Group As Integer
                If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
                    Try
                        template_id = dao.fields.TEMPLATE_ID
                    Catch ex As Exception
                        template_id = 0
                    End Try
                    If template_id = 2 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
                    ElseIf template_id = 1 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 99)
                    Else
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 0, _group:=9)
                    End If
                ElseIf _group = 2 Or _group = 3 Then
                    If template_id = 1 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                    End If
                Else
                    Try
                        template_id = dao.fields.TEMPLATE_ID
                    Catch ex As Exception
                        template_id = 0
                    End Try
                    If template_id = 2 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
                    ElseIf template_id = 1 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 99)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 0)
                    End If

                End If
            Else
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                'If template_id = 2 Then
                '    If statusId > 6 Then
                '        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
                '    Else
                '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                '    End If
                'Else
                If _group = 1 Then
                    If template_id = 2 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
                    ElseIf template_id = 1 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=99)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                    End If
                ElseIf _group = 2 Then
                    If template_id = 1 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                    End If
                ElseIf _group = 3 Then
                    If template_id = 1 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=1)
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                    End If
                Else
                    If template_id = 1 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=99)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=0)
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                    End If
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
                'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
                'End If
            End If
        End If

        'Dim paths As String = bao._PATH_DEFAULT
        Dim Paths As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_RENREW") 'path
        Dim PDF_TEMPLATE As String = Paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = Paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = Paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)


        Dim url As String = ""

        url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename

        class_xml.QR_CODE = QR_CODE_IMG(url)

        p_dalcn = class_xml

        ' ในส่วนการแปลงไฟล์ PDF และการกำหนด iframe

        'Dim p_dalcn2 As New XML_CENTER.CLASS_DALCN
        'p_dalcn2 = p_dalcn

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        'load_pdf(filename)

        'Dim output As Byte() = convert_pdf_gdc(UpLoadImageByte(filename), lcnno_format_NEW, _CLS.CITIZEN_ID, link.URL, _IDA_LCN)
        ' เก็บ byte array ของไฟล์ PDF ใน session
        'Session("PDFFile") = output

        'lr_preview.Text = "<iframe id='iframe1' style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx'></iframe>"
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        'hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
        _CLS.FILENAME_PDF = NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
    End Sub

    Private Function UpLoadImageByte(filename As String) As Byte()
        ' ตรวจสอบว่าไฟล์มีอยู่จริงหรือไม่
        If File.Exists(filename) Then
            ' อ่านไฟล์และแปลงเป็น byte array
            Return File.ReadAllBytes(filename)
        Else
            Throw New FileNotFoundException("File not found: " & filename)
        End If
    End Function

    Public Function GET_SHORTEN_LINK(ByVal lctlcnno As String, ByVal identify As String)
        Dim bao_app As New BAO.AppSettings
        Dim wsShorten As New WS_SHORTEN.WS_SHORTEN
        Dim reqData As New WS_SHORTEN.REQ_DATA
        Dim link As New WS_SHORTEN.RESPONSE_DATA
        Dim URL_FULL As String = ""
        'Dim url As String = ""
        URL_FULL = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "LCN_RENEW_STAFF/FRM_HERB_LCN_RENEW_STAFF.aspx" & "?Token=PREVIEW&iden=" & identify & "&id=" & lctlcnno
        'URL_FULL = bao_app._URL_QRCODE & "?Token=PREVIEW&iden=" & identify & "&id=" & lctlcnno
        Try
            With reqData
                .LOGIN_ENABLE = 0
                .REF_ID = lctlcnno
                .SEND_SHORT_CODE = 0
                .SESSION_DATA = ""
                .SYSTEM_APP = "HERB"
                .URL = URL_FULL
                .YEARs = 2564
            End With
            link = wsShorten.SHORTEN_CREATE(reqData)
        Catch ex As Exception

        End Try
        Return link
    End Function
    Public Function convert_pdf_gdc(ByVal b As Byte(), ByVal LCTLCNNO As String, ByVal citizen_id As String, ByVal url_shorten As String, ByVal ID As Integer) As Byte()
        Dim template_id As String = ""
        Dim type_licen As String = ""
        Dim process_id As String = ""
        Dim bao_app As New BAO.AppSettings
        Dim output As Byte()
        'Dim wsShorten As New WS_SHORTEN.WS_SHORTEN
        'Dim reqData As New WS_SHORTEN.REQ_DATA
        'Dim link As New WS_SHORTEN.RESPONSE_DATA

        'Dim dao_main As New DAO_LOCATION.TB_MAIN_DATA_DRIVE
        'dao_main.GetDataByLctlcnnoUpdate(LCTLCNNO)

        'Dim dao_location As New DAO_LOCATION.TB_SEARCH_FOOD_LCN
        'dao_location.Getdata_by_lctlcnno(LCTLCNNO)

        'Dim URL_FULL As String = ""
        'URL_FULL = bao_app._URL_QRCODE & "?Token=PREVIEW&iden=" & dao_location.fields.IDENTIFY & "&id=" & LCTLCNNO

        'Try
        '    With reqData
        '        .LOGIN_ENABLE = 0
        '        .REF_ID = LCTLCNNO
        '        .SEND_SHORT_CODE = 0
        '        .SESSION_DATA = ""
        '        .SYSTEM_APP = "FD"
        '        .URL = URL_FULL
        '        .YEARs = 2564
        '    End With
        '    link = wsShorten.SHORTEN_CREATE(reqData)
        'Catch ex As Exception

        'End Try
        Dim version As String = 0
        Try
            version = "ID" & ID
        Catch ex As Exception

        End Try

        'If bao_app._SET_DEMO = 0 Then
        '    If dao_location.fields.lcntypecd = "12" Then
        '        process_id = "335012"
        '        template_id = "4a60623b-a62e-4a96-b74e-7eced2b56b6c"
        '    ElseIf dao_location.fields.lcntypecd = "11" Then
        '        If CInt(dao_location.fields.laber) <= 49 And CDec(dao_location.fields.machine) < 50 Then
        '            process_id = "335211"
        '            template_id = "4adc88c4-112b-49c4-b47f-f161201b8585"
        '        Else
        '            process_id = "335111"
        '            template_id = "951ef506-e3ba-456d-8e03-64aabb50ec1d"
        '        End If
        '    End If
        'Else 'ตัวเทส
        '    If dao_location.fields.lcntypecd = "12" Then
        '        process_id = "335012"
        '        template_id = "cf14ea35-d939-4c4a-92aa-0c0cba6927d2"
        '    ElseIf dao_location.fields.lcntypecd = "11" Then
        '        If CInt(dao_location.fields.laber) <= 49 And CDec(dao_location.fields.machine) < 50 Then
        '            process_id = "335211"
        '            template_id = "20e9aca2-76c8-45a0-9514-7f9156f34a71"
        '        Else
        '            process_id = "335111"
        '            template_id = "74cd2f4c-1313-4cce-81d6-5527385c8fbe"
        '        End If
        '    End If
        'End If

        Dim ws_f As New WS_FLATTEN.WS_FLATTEN


        'Dim bbb As Byte()
        'bbb = ws_f.FlattenPDF_DIGITAL_V4(F_PDF.FileBytes, "10321523", "4a60623b-a62e-4a96-b74e-7eced2b56b6c", "1331000214562", "http://thfda.cc/?CODE=FD64179879", "ID1044", "335012")


        'bt = ws.FlattenPDF_DIGITAL_V4(bt, FDPDTNO, "37db111d-6208-4d77-89b1-af6a97cdc695", CITIZEN_ID, link.URL, version)

        Try
            Dim ws As New WS_FLATTEN_NEW.WS_FLATTEN
            ws.Timeout = 360000
            'output = ws.FlattenPDF(b)

            output = ws.FlattenPDF_DIGITAL_V4(b, LCTLCNNO, template_id, citizen_id, url_shorten, version, process_id)
        Catch ex As Exception
            output = b
        End Try
        Return output
    End Function
    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = 8 Then
            panel_file_upload.Visible = True
            UC_ATTACH2.NAME = "เอกสาร สมพ2 ที่ลงนามแล้ว"
            UC_ATTACH2.BindData("เอกสาร สมพ2 ที่ลงนามแล้ว", 1, "pdf", "0", "4")
        Else
            panel_file_upload.Visible = False
        End If
    End Sub
    Function bind_data_uploadfile_4()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA_RN)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 4)
        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_4()
    End Sub
    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
        End If
    End Sub

    Protected Sub btn_drug_group_edit_Click(sender As Object, e As EventArgs) Handles btn_drug_group_edit.Click
        Dim dao_r As New DAO_LCN.TB_DALCN_RENEW
        dao_r.GET_DATA_BY_IDA(_IDA_RN)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(dao_r.fields.FK_LCN)
        Dim IDA_LCN As Integer = dao.fields.IDA
        Dim TR_LCN As Integer = dao.fields.TR_ID
        Dim PROCESS_LCN As Integer = dao.fields.PROCESS_ID
        Response.Redirect("../LCN/POPUP_LCN_DRUG_GROUP_HERB.aspx?ida=" & IDA_LCN & "&TR_ID=" & TR_LCN & "&process=" & PROCESS_LCN)
    End Sub

    Protected Sub btn_lcn_edit_Click(sender As Object, e As EventArgs) Handles btn_lcn_edit.Click
        Dim dao_r As New DAO_LCN.TB_DALCN_RENEW
        dao_r.GET_DATA_BY_IDA(_IDA_RN)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(dao_r.fields.FK_LCN)
        Dim _IDEN As String = dao.fields.CITIZEN_ID_AUTHORIZE
        Dim IDA_LCN As Integer = dao.fields.IDA
        Dim PROCESS_LCN As Integer = dao.fields.PROCESS_ID
        Response.Redirect("POP_UP_LCN_RENEW_CHECK_STAFF_EDIT.aspx?IDA=" & _IDA_RN & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID=" & PROCESS_LCN & "&IDENTIFY=" & _IDEN & "&IDA_RENEW=" & _IDA_RN)
    End Sub
    Protected Sub ddl_fee_discount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_fee_discount.SelectedIndexChanged
        Dim ddl_id As Integer = ddl_fee_discount.SelectedValue
        Dim dao As New DAO_LCN.TB_MAS_DALCN_FEE_DISCOUNT
        dao.GET_DATA_BY_ID(ddl_id)
        If ddl_id <> 0 Then
            txt_price_fee.Text = SUM_Discount(dao.fields.REQUEST_Fee)
        End If
    End Sub
    Function SUM_Discount(ByVal Discount As Integer)
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA_RN)
        Dim dao_f As New DAO_FEE.TB_feetype
        dao_f.GetDataby_PROCESS_ID_AND_STATUS_ID(_ProcessID, dao.fields.STATUS_ID)
        Dim number1 As Integer = 0
        Dim number2 As Integer = 0
        Dim number3 As Integer = 100
        Dim answer1 As Decimal
        Dim sum1 As Integer
        Dim sum2 As Integer
        If Discount = Nothing Then
            number2 = 0
        Else
            number2 = Discount
        End If
        number1 = dao_f.fields.value

        sum1 = number1 * number2
        sum2 = sum1 / number3
        answer1 = number1 - sum2
        Return answer1
    End Function
    'Protected Sub btn_priview_Click(sender As Object, e As EventArgs) Handles btn_priview.Click
    '    Dim Url As String = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?IDA=" & _IDA_RN '& "&SLDDL=" & DDL_TB2_SELECT.SelectedValue
    '    Response.Write("<script>window.open('" & Url & "','_blank')</script>")
    'End Sub
End Class

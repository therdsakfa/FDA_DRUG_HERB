Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_JJ_EDIT_STAFF_INTAKE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src=''></iframe>"
            'Run_Pdf_Tabean_Herb()
            bind_data()
            bind_dd()
            bind_mas_staff()
            bind_mas_cancel()
            Bind_PDF()
            BIND_MAS_OTHER_REQUEST()
            BIND_MAS_POSITION_STAFF()
            Bind_PRICE_ESTIMATE_REQUEST()
            Bind_DD_Discount()

            UC_ATTACH1.NAME = "เอกสารแนบ"
            UC_ATTACH1.BindData("เอกสารแนบ", 1, "pdf", "0", "77")
        End If
    End Sub

    Public Sub bind_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        If dao.fields.STATUS_ID = 13 Then
            KEEP_PAY.Visible = True
            btn_sumit.Visible = True
            btn_keep_pay.Visible = False
            'PS1.Visible = True
            'OE1.Visible = True
            'OE2.Visible = True
        ElseIf dao.fields.STATUS_ID = 8 Then
            KEEP_PAY.Visible = False
            btn_sumit.Visible = False
            btn_keep_pay.Visible = False
            'PS1.Visible = False
            'OE1.Visible = False
            'OE2.Visible = False
        Else
            KEEP_PAY.Visible = True
            btn_sumit.Visible = True
            btn_keep_pay.Visible = False
            'PS1.Visible = False
            'OE1.Visible = False
        End If
        Try
            DD_ESTIMATE_PAY.SelectedValue = 130
            Dim dao_ml As New DAO_TABEAN_HERB.TB_MAS_PRICE_ESTIMATE_REQUEST_HERB
            dao_ml.Getdataby_Process_ID(_ProcessID)
            TXT_BATH.Text = dao_ml.fields.Price
        Catch ex As Exception

        End Try
        If dao.fields.STATUS_UPLOAD_ID >= 2 Then
            AT_FILE.Visible = True
            txt_edit_staff.Text = dao.fields.NOTE_EDIT
            STAFF_NAME.Text = dao.fields.EDIT_RQ_NAME
            txt_edit_date.Text = date_to_thai(dao.fields.EDIT_RQ_DATE)
        End If

        DATE_REQ.Text = Date.Now.ToString("dd/MM/yyyy")
        If dao.fields.FOREIGN_TO_STAFF <> "" Then
            ADDR_FOREIGN_CHK.Visible = True
            Txt_Txt_Addr_to_Staff.Text = dao.fields.FOREIGN_TO_STAFF
        End If
        Try
            lbl_create_by.Text = dao.fields.CREATE_BY
            lbl_create_date.Text = dao.fields.CREATE_DATE
        Catch ex As Exception

        End Try
        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(_IDA)
        If dao_cb.fields.IDA <> 0 Then
            If dao_cb.fields.Label_And_Ducumant = 1 Then
                AT_OLDDocument.Visible = True
            Else
                AT_OLDDocument.Visible = False
            End If

        End If
    End Sub
    Public Sub Bind_PRICE_ESTIMATE_REQUEST()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_PRICE_ESTIMATE_REQUEST(_ProcessID)

        DD_ESTIMATE_PAY.DataSource = dt
        DD_ESTIMATE_PAY.DataValueField = "ID"
        DD_ESTIMATE_PAY.DataTextField = "Request_Show"
        DD_ESTIMATE_PAY.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        DD_ESTIMATE_PAY.Items.Insert(0, item)
    End Sub
    Sub Bind_DD_Discount()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_PRICE_DISCOUNT_TABEAN_HERB()

        DD_DISCOUNT.DataSource = dt
        DD_DISCOUNT.DataValueField = "ID"
        DD_DISCOUNT.DataTextField = "DiscountName"
        DD_DISCOUNT.DataBind()
        'DD_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")

        Dim item As New RadComboBoxItem
        item.Text = "ไม่มีส่วนลดตามประกาศฯ ค่าใช้จ่ายที่จะจัดเก็บจากผู้ยื่นคำขอ"
        item.Value = "0"
        DD_DISCOUNT.Items.Insert(0, item)
    End Sub
    Public Function date_to_thai(ByVal _date As Date)
        Dim dateD_TH As String = ""
        Dim dateM_TH As String = ""
        Dim dateY_TH As String = ""
        Dim dateD As Date
        Dim dateM As Date
        Dim dateY As Date
        Dim date_FULL As String = ""
        Try
            _date = _date
            _date = CDate(_date).ToString("dd/MM/yyy")
            dateD = _date
            dateM = _date
            dateY = _date

            dateD_TH = dateD.Day.ToString()
            dateM_TH = dateM.ToString("MMMM")
            dateY_TH = con_year(dateY.Year)
            date_FULL = dateD_TH & " " & dateM_TH & " " & dateY_TH
        Catch ex As Exception

        End Try

        Return date_FULL
    End Function
    Public Sub bind_mas_cancel()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        If dao.fields.STATUS_ID = 3 Or dao.fields.STATUS_ID = 9 Then
            dt = bao.SP_MAS_DDL_STAFF_REMARK_CANCEL()
            DDL_CANCLE_REMARK.DataValueField = "remark_cancle_id"
            DDL_CANCLE_REMARK.DataTextField = "remark_cancle_name"

        Else
            dt = bao.SP_MAS_DDL_SECTION_CANCEL()
            DDL_CANCLE_REMARK.DataValueField = "DDL_ID"
            DDL_CANCLE_REMARK.DataTextField = "DDL_NAME"
        End If
        DDL_CANCLE_REMARK.DataSource = dt
        DDL_CANCLE_REMARK.DataBind()
        DDL_CANCLE_REMARK.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Protected Sub Bind_PDF()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID_JJ As Integer = dao.fields.TR_ID_JJ

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ_EDIT
        TB_JJ_EDIT = XML.Gen_XML_JJ3_Edit(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_EDIT") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub BIND_MAS_POSITION_STAFF()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_POSITION_NAME()

        'DD_POSITION_STAFF.DataSource = dt
        'DD_POSITION_STAFF.DataBind()
        'DD_POSITION_STAFF.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub BIND_MAS_OTHER_REQUEST()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_OTHER_REQUEST_NAME()

        'DD_OTHER_REQUEST.DataSource = dt
        'DD_OTHER_REQUEST.DataBind()
        'DD_OTHER_REQUEST.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        Dim ss_id As Integer = 0
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        If dao.fields.STATUS_ID = 3 Then
            ss_id = 1
        ElseIf dao.fields.STATUS_ID = 12 Or dao.fields.STATUS_ID = 11 Then
            ss_id = 2
        ElseIf dao.fields.STATUS_ID = 13 Then
            ss_id = 3
        ElseIf dao.fields.STATUS_ID = 5 Then
            ss_id = 5
        End If
        dt = bao.SP_DD_STATUS_JJ_EDIT(ss_id)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        If dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 14 Then
            dao.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
            dao.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
            dao.fields.NOTE_CANCEL = NOTE_CANCLE.Text
            dao.Update()
            UC_ATTACH1.insert_JJ_EDIT(_TR_ID, _ProcessID, dao.fields.IDA, 77)
            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        ElseIf dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 10 Then
            If DDL_CANCLE_REMARK.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเหตุผล');", True)
            Else
                'dao.fields.POSITION_NAME = DD_POSITION_STAFF.SelectedItem.Text
                'dao.fields.POSITION_ID = DD_POSITION_STAFF.SelectedValue
                dao.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                dao.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
                dao.fields.NOTE_CANCEL = NOTE_CANCLE.Text
                dao.fields.CANCEL_STAFF_ID = DD_OFF_REQ.SelectedValue
                dao.fields.CANCEL_STAFF_NM = DD_OFF_REQ.SelectedItem.Text
                dao.fields.cncdate = DATE_REQ.Text
                dao.Update()
                AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            End If
        Else
            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
            Else
                If dao.fields.STATUS_ID = 12 Or dao.fields.STATUS_ID = 11 Then
                    Dim bao As New BAO.GenNumber
                    Dim RCVNO As String = ""
                    Dim RCVNO_HERB_NEW As String = ""
                    'Dim pvncd As String = dao.fields.pvncd
                    Dim pvncd As String = 10

                    If dao.fields.RCVNO_FULL = "" Then
                        RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), pvncd, dao.fields.DDHERB, _IDA)
                        Dim TR_ID As String = dao.fields.TR_ID_JJ
                        Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
                        RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, dao.fields.DDHERB, _IDA)
                        Dim RCVNO_FULL As String = "HB" & " " & pvncd & "-" & dao.fields.DDHERB & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
                        dao.fields.RCVNO_FULL = RCVNO_FULL
                    End If
                    dao.fields.OFF_REQ_ID = DD_OFF_REQ.SelectedValue
                    dao.fields.OFF_REQ = DD_OFF_REQ.SelectedItem.Text 'จนท.รับคำขอ'
                    dao.fields.DATE_REQ = Date.Now
                    Try
                        dao.fields.Discount_EstimateID = DD_DISCOUNT.SelectedValue
                        dao.fields.Discount_EstimateName = DD_DISCOUNT.SelectedItem.Text
                        dao.fields.Estimate_PAY_ID = DD_ESTIMATE_PAY.SelectedValue
                        dao.fields.Estimate_PAY_Name = DD_ESTIMATE_PAY.SelectedItem.Text
                        dao.fields.ML_ESTIMATE = TXT_BATH.Text
                    Catch ex As Exception

                    End Try

                    If (DD_STATUS.SelectedValue = 12) And TXT_BATH.Text = 0 Then
                        dao.fields.STATUS_ID = 23
                        dao.fields.STATUS_ID = 23
                        'Else
                        '    dao.fields.STATUS_ID = 12
                        '    dao.fields.STATUS_ID = 12
                    End If

                    dao.Update()
                    AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)

                    Dim bao_tn As New BAO_TABEAN_HERB.tb_dd
                    bao_tn.SP_INSERT_DRUG_PAYMENT_CENTER_L44(dao.fields.CITIZEN_ID_AUTHORIZE, _IDA, dao.fields.DDHERB)
                ElseIf dao.fields.STATUS_ID = 4 Then
                    dao.fields.EDIT_RQ_ID = DD_OFF_REQ.SelectedValue
                    dao.fields.EDIT_RQ_NAME = DD_OFF_REQ.SelectedItem.Text
                    dao.fields.EDIT_RQ_DATE = Date.Now


                    Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
                    dao_up_mas.GetdatabyID_TYPE(4)
                    For Each dao_up_mas.fields In dao_up_mas.datas
                        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                        dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                        dao_up.fields.TR_ID = _TR_ID
                        dao_up.fields.PROCESS_ID = _ProcessID
                        dao_up.fields.FK_IDA = _IDA
                        dao_up.fields.FK_IDA_LCN = _IDA_LCN
                        dao_up.fields.TYPE = 2
                        dao_up.insert()
                    Next

                    Dim dt As DataTable
                    Dim bao As New BAO_TABEAN_HERB.tb_main
                    Dim STATUS_UPLOAD_ID As Integer = 0
                    Try
                        If dao.fields.STATUS_UPLOAD_ID Is Nothing Then
                            dao.fields.STATUS_UPLOAD_ID = 1
                        End If
                    Catch ex As Exception
                        STATUS_UPLOAD_ID = 1
                        dao.fields.STATUS_UPLOAD_ID = STATUS_UPLOAD_ID
                    End Try
                    dao.Update()
                    Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT_STAFF_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&IDA_LCN=" & _IDA_LCN)

                    AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                End If
            End If
        End If


        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

    End Sub
    Sub Update_data_jj()
        Dim dao_c As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_c.GetdatabyID_FK_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_JJ As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_JJ.GetdatabyID_IDA(dao.fields.FK_IDA)
        If dao_c.fields.NAME_PRODUCK_1 = 1 Then
            'dao_JJ.fields.NAME_THAI = dao.fields.NAME_THAI
            dao_JJ.fields.NAME_ENG = dao.fields.NAME_ENG
        End If
        If dao_c.fields.NAME_PRODUCK_2 = 1 Then
            dao_JJ.fields.NAME_OTHER = dao.fields.NAME_OTHER
        End If
        If dao_c.fields.NAME_PRODUCK_3 = 1 Then
            dao_JJ.fields.NAME_ENG = dao.fields.NAME_ENG
        End If
        If dao_c.fields.NAME_PRODUCK_4 = 1 Then
            dao_JJ.fields.NAME_OTHER = dao.fields.NAME_OTHER
        End If
        If dao_c.fields.NAME_ADDR1 = 1 Then

        End If
        If dao_c.fields.NAME_ADDR2 = 1 Then

        End If
        If dao_c.fields.NAME_ADDR3 = 1 Then

        End If
        If dao_c.fields.Size_Packet = 1 Then
            Dim dao_sp_jj As New DAO_TABEAN_HERB.TB_TABEAN_SUBPACKAGE
            Dim dao_sp_edit2 As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_SUBPACKAGE
            dao_sp_jj.GetData_ByFkIDA(dao.fields.FK_IDA)
            dao_sp_edit2.GetData_ByFkIDA(_IDA)
            For Each dao_sp_jj.fields In dao_sp_jj.datas
                dao_sp_jj.fields.ACTIVEFACT = 0
                dao_sp_jj.Update()
            Next
            For Each dao_sp_edit2.fields In dao_sp_edit2.datas
                Dim dao_sp_edit As New DAO_TABEAN_HERB.TB_TABEAN_SUBPACKAGE
                dao_sp_edit.fields.FK_IDA = dao_JJ.fields.IDA
                'dao_sp_edit.fields.FK_IDA_JJ = dao_sp_jj.fields.FK_IDA
                dao_sp_edit.fields.PROCESS_ID = dao_JJ.fields.DDHERB
                dao_sp_edit.fields.PACK_FSIZE_VOLUME = dao_sp_edit2.fields.PACK_FSIZE_VOLUME
                dao_sp_edit.fields.PACK_FSIZE_ID = dao_sp_edit2.fields.PACK_FSIZE_ID
                dao_sp_edit.fields.PACK_FSIZE_NAME = dao_sp_edit2.fields.PACK_FSIZE_NAME
                dao_sp_edit.fields.PACK_FSIZE_UNIT_ID = dao_sp_edit2.fields.PACK_FSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_FSIZE_UNIT_NAME = dao_sp_edit2.fields.PACK_FSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_SECSIZE_VOLUME = dao_sp_edit2.fields.PACK_SECSIZE_VOLUME
                dao_sp_edit.fields.PACK_SECSIZE_ID = dao_sp_edit2.fields.PACK_SECSIZE_ID
                dao_sp_edit.fields.PACK_SECSIZE_NAME = dao_sp_edit2.fields.PACK_SECSIZE_NAME
                dao_sp_edit.fields.PACK_SECSIZE_UNIT_ID = dao_sp_edit2.fields.PACK_SECSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_SECSIZE_UNIT_NAME = dao_sp_edit2.fields.PACK_SECSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_THSSIZE_VOLUME = dao_sp_edit2.fields.PACK_THSSIZE_VOLUME
                dao_sp_edit.fields.PACK_THSIZE_ID = dao_sp_edit2.fields.PACK_THSIZE_ID
                dao_sp_edit.fields.PACK_THSIZE_NAME = dao_sp_edit2.fields.PACK_THSIZE_NAME
                dao_sp_edit.fields.PACK_THSIZE_UNIT_ID = dao_sp_edit2.fields.PACK_THSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_THSIZE_UNIT_NAME = dao_sp_edit2.fields.PACK_THSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_NOTE = dao_sp_edit2.fields.PACK_NOTE
                dao_sp_edit.fields.ACTIVEFACT = 1
                dao_sp_edit.fields.CREATE_DATE = dao_sp_edit2.fields.CREATE_DATE
                dao_sp_edit.fields.CREATE_BY = dao_sp_edit2.fields.CREATE_BY
                dao_sp_edit.fields.UPDATE_DATE = dao_sp_edit2.fields.UPDATE_DATE
                dao_sp_edit.fields.UPDATE_BY = dao_sp_edit2.fields.UPDATE_BY
                'dao_sp_edit.fields.NO_1 = dao_sp_jj.fields.NO_1
                'dao_sp_edit.fields.NO_2 = dao_sp_jj.fields.NO_2
                'dao_sp_edit.fields.NO_3 = dao_sp_jj.fields.NO_3
                dao_sp_edit.insert()
            Next
        End If
        If dao_c.fields.Label_And_Ducumant = 1 Then

        End If
        dao_JJ.Update()
    End Sub
    Protected Sub btn_keep_pay_Click(sender As Object, e As EventArgs) Handles btn_keep_pay.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        dao.fields.STATUS_ID = 13
        dao.Update()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกสถานะ');", True)
        Else
            If DD_STATUS.SelectedValue = 10 Or DD_STATUS.SelectedValue = 7 Or DD_STATUS.SelectedValue = 14 Then
                D_Discount.Visible = False
                Label5.Text = "วันที่"
                div_upload.Visible = True
                D_CALCEL.Visible = True
            ElseIf DD_STATUS.SelectedValue = 9 Then
                D_Discount.Visible = False
                div_upload.Visible = True
                D_CALCEL.Visible = True
            ElseIf DD_STATUS.SelectedValue = 4 Then
                D_Discount.Visible = False
                Label5.Text = "วันที่"
                div_upload.Visible = False
                D_CALCEL.Visible = False
            Else
                D_Discount.Visible = True
                div_staff.Visible = True
                D_CALCEL.Visible = False
            End If
        End If

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        Catch ex As Exception
            STATUS_UPLOAD_ID = 1
        End Try

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID_JJ, 1, dao.fields.DDHERB, _IDA)
        Return dt
    End Function

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_PREVIEW.aspx?ida=" & IDA

        End If
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile2()
    End Sub
    Function bind_data_uploadfile2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        Catch ex As Exception
            STATUS_UPLOAD_ID = 3
        End Try


        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID_JJ, 3, dao.fields.DDHERB, _IDA)

        Return dt
    End Function

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_PREVIEW.aspx?ida=" & IDA

        End If
    End Sub
    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile3()
    End Sub
    Function bind_data_uploadfile3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        Catch ex As Exception
            STATUS_UPLOAD_ID = 1
        End Try


        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID_JJ, 2, dao.fields.DDHERB, _IDA)

        Return dt
    End Function

    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_PREVIEW.aspx?ida=" & IDA

        End If
    End Sub
    Function bind_data_uploadfile_77()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID_JJ, 77, dao.fields.DDHERB, _IDA)

        Return dt
    End Function

    Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
        RadGrid5.DataSource = bind_data_uploadfile_77()
    End Sub

    Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_PREVIEW.aspx?ida=" & IDA

        End If
    End Sub

    'Protected Sub DD_OFF_REQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OFF_REQ.SelectedIndexChanged
    '    Dim NAME_ID As String = ""
    '    NAME_ID = DD_OFF_REQ.SelectedValue

    'End Sub
    Public Function BindTable()
        Dim DT As New DataTable
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(dao.fields.FK_IDA)
        Dim TR_ID_JJ As Integer = 0
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Dim bao As New BAO_TABEAN_HERB.tb_main
        'DT = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_jj.fields.TR_ID_JJ, 1, dao_jj.fields.DDHERB)
        DT = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_EDIT(dao_jj.fields.TR_ID_JJ, 1, dao_jj.fields.DDHERB)
        Return DT
    End Function

    Private Sub RadGrid6_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid6.NeedDataSource
        RadGrid6.DataSource = BindTable()
    End Sub

    Private Sub RadGrid6_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid6.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA
        End If
    End Sub
    Protected Sub DD_ESTIMATE_PAY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ESTIMATE_PAY.SelectedIndexChanged
        If DD_ESTIMATE_PAY.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ค่าประเมินเอกสารทางวิชาการ');", True)
        Else
            Dim ML_PAY As Double = 0
            ML_PAY = SUM_Discount(_ProcessID)
            TXT_BATH.Text = ML_PAY
        End If
    End Sub
    Protected Sub DD_DISCOUNT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_DISCOUNT.SelectedIndexChanged
        If DD_ESTIMATE_PAY.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ค่าประเมินเอกสารทางวิชาการ');", True)
        Else
            Dim ML_PAY As Double = 0
            ML_PAY = SUM_Discount(_ProcessID)
            TXT_BATH.Text = ML_PAY
        End If
    End Sub
    Function SUM_Discount(ByVal Process_ID As Integer)
        'Dim dao_ml As New DAO_TABEAN_HERB.TB_MAS_PRICE_REQUEST_HERB
        'dao_ml.Getdataby_Process_ID(Process_ID)
        Dim dao_ml As New DAO_TABEAN_HERB.TB_MAS_PRICE_ESTIMATE_REQUEST_HERB
        dao_ml.Getdataby_Process_ID_AND_ID(Process_ID, DD_ESTIMATE_PAY.SelectedValue)
        Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
        dao_p.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
        Dim number1 As Integer = 0
        Dim number2 As Integer = 0
        Dim number3 As Integer = 100
        Dim answer1 As Decimal
        Dim sum1 As Integer
        Dim sum2 As Integer
        If dao_p.fields.REQUEST_Fee = Nothing Then
            number2 = 0
        Else
            number2 = dao_p.fields.ESTIMATE_Fee
        End If
        number1 = dao_ml.fields.Price

        sum1 = number1 * number2
        sum2 = sum1 / number3
        answer1 = number1 - sum2
        Return answer1
    End Function
End Class
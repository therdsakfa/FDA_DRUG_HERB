Imports System.IO
Imports System.Xml.Serialization
Imports Newtonsoft.Json
Imports System.Web.Script.Serialization
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Imports System.Xml
Imports System.Collections.Generic
Imports System.Text
Imports System.Globalization6

Public Class POPUP_TABEAN_NEW_EDIT_STAFF_APPROVE
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _Process_ID As String
    Private _IDA_LCN As String
    Private _IDA_DR As String
    Shared NEWCODE As String = ""
    Shared NEWCODE_U As String = ""
    Private _XML_DRUG_IOW_TO1 As New XML_DRUG_IOW_TO
    Public Property XML_DRUG_IOW_TO1() As XML_DRUG_IOW_TO
        Get
            Return _XML_DRUG_IOW_TO1
        End Get
        Set(ByVal value As XML_DRUG_IOW_TO)
            _XML_DRUG_IOW_TO1 = value
        End Set
    End Property

    Private _XML_DRUG_IOW_TYPE1 As New XML_DRUG_IOW_TYPE
    Public Property XML_DRUG_IOW_TYPE1() As XML_DRUG_IOW_TYPE
        Get
            Return _XML_DRUG_IOW_TYPE1
        End Get
        Set(ByVal value As XML_DRUG_IOW_TYPE)
            _XML_DRUG_IOW_TYPE1 = value
        End Set
    End Property
    Sub RunSession()
        _Process_ID = Request.QueryString("process_id")
        _IDA = Request.QueryString("IDA")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_DR = Request.QueryString("IDA_DR")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()
            bind_dd()
            bind_mas_staff()
            bind_mas_cancel()
            BIND_PDF_TABEAN()
            BIND_MAS_POSITION_STAFF()
            BIND_MAS_OTHER_REQUEST()
            Bind_DDL_SLCHN()
            Bind_DDL_Kindnm()
            'Updata_data_tabean_to_BC()
            'Updata_data_tabean_to_124()
            UC_ATTACH1.NAME = "เอกสารแนบยกเลิกคำขอ"
            UC_ATTACH1.BindData("เอกสารแนบยกเลิกคำขอ", 1, "pdf", "0", "77")

            UC_ATTACH2.NAME = "เอกสาร ทบ.3"
            UC_ATTACH2.BindData("เอกสาร ทบ.3", 1, "pdf", "0", "14")
        End If
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        If dao.fields.STATUS_ID = 8 Then
            KEEP_PAY.Visible = False
            btn_sumit.Visible = False
            div_btn_cancel.Visible = False
            D_SLCN.Visible = False
        Else
            KEEP_PAY.Visible = True
            btn_sumit.Visible = True
            uc_upload1.Visible = True
            D_SLCN.Visible = True
        End If
        DATE_REQ.SelectedDate = Date.Now.ToString("dd/MM/yyyy")
        lbl_create_by.Text = dao.fields.CREATE_BY
        txt_remark_edit.Text = dao.fields.Reason_Staff
        RDP_CANCEL_DATE.SelectedDate = Date.Now
        Try
            lbl_create_date.Text = dao.fields.CREATE_DATE
        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataValueField = "IDA"
        DD_OFF_REQ.DataTextField = "STAFF_NAME"
        DD_OFF_REQ.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        DD_OFF_REQ.Items.Insert(0, item)
    End Sub
    Public Sub Bind_DDL_Kindnm()
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        Dim dao As New DAO_DRUG.TB_drkdofdrg
        dao.GETDATA_ACTIVE_Y()

        DDL_Kindnm.DataSource = dao.Details
        DDL_Kindnm.DataValueField = "kindcd"
        DDL_Kindnm.DataTextField = "thakindnm"
        DDL_Kindnm.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        DDL_Kindnm.Items.Insert(0, item)
        Try
            Dim dao_g As New DAO_DRUG.ClsDBdrrgt
            dao_g.GetDataby_IDA(_IDA_DR)
            If IsNothing(dao_g.fields.kindcd) = False Then DDL_Kindnm.SelectedValue = dao_g.fields.kindcd
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Bind_DDL_SLCHN()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_SALE()

        DDL_SLCHN.DataSource = dt
        DDL_SLCHN.DataValueField = "SALE_CHANNEL_ID"
        DDL_SLCHN.DataTextField = "SALE_CHANNEL_NAME"
        DDL_SLCHN.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        DDL_SLCHN.Items.Insert(0, item)

    End Sub
    Public Sub BIND_MAS_OTHER_REQUEST()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_OTHER_REQUEST_NAME()

        DD_OTHER_REQUEST.DataSource = dt
        DD_OTHER_REQUEST.DataBind()
        DD_OTHER_REQUEST.Items.Insert(0, "-")
    End Sub
    Public Sub BIND_MAS_POSITION_STAFF()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_POSITION_NAME()

        DD_POSITION_STAFF.DataSource = dt
        DD_POSITION_STAFF.DataBind()
        DD_POSITION_STAFF.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub bind_mas_cancel()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        If dao.fields.STATUS_ID = 2 Then
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
    Sub BIND_PDF_TABEAN()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        _IDA_LCN = dao.fields.FK_LCN_IDA
        Dim XML As New CLASS_GEN_XML.TABEAN_NEW_EDIT
        TBN_NEW_EDIT = XML.GEN_XML_TABEAN_NEW_EDIT(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_Process_ID, dao.fields.STATUS_ID, "ทบ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EDIT") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", _Process_ID, Date.Now.Year, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", _Process_ID, Date.Now.Year, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _Process_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Public Sub bind_dd()

        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl1 As Integer = 0
        Dim int_group_ddl2 As Integer = 0
        Dim status_id1 As Integer = 0
        Dim dao_sub As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao_sub.GetdatabyID_IDA(Request.QueryString("IDA"))

        status_id1 = dao_sub.fields.STATUS_ID
        If status_id1 = 6 Then
            int_group_ddl1 = 4
            int_group_ddl2 = 0
        End If
        dt = Get_DDL_DATA(204, int_group_ddl1, int_group_ddl2)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataValueField = "STATUS_ID"
        DD_STATUS.DataTextField = "STATUS_NAME_STAFF"
        DD_STATUS.DataBind()

    End Sub
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        'Dim dt As New DataTable
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim dta As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dta = bao.Queryds(sql)
        Return dta
    End Function
    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        'If UC_ATTACH1.CHK_TBN = False Then
        '    alert_nature("กรุณาแนบไฟล์ เอกสาร ทบ.3 ที่อนุมัติแล้ว")
        'Else

        '    UC_ATTACH1.insert_TBN_EDIT(_TR_ID, _Process_ID, _IDA, 14)
        '    alert_summit("อัพโหลดเอกสารแนบ ทบ.3 เรียบร้อย")
        'End If
        If dao.fields.STATUS_ID = 8 Then
            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกสถานะ หรือเจ้าหน้าที่รับผิดชอบ');", True)
                'ElseIf UC_ATTACH2.CHK_TBN = False Then
                '    alert_nature("กรุณานบไฟล์ เอกสาร ทบ.3 ที่อนุมัติแล้ว")
            Else
                dao.fields.appdate_StaffID = DD_OFF_REQ.SelectedValue
                dao.fields.appdate_StaffName = DD_OFF_REQ.SelectedItem.Text
                'dao.fields.appdate = Date.Now
                'dao.fields.appdate = DATE_REQ.Text
                dao.fields.appdate = CDate(DATE_REQ.SelectedDate)
                dao.fields.Reason_Staff = txt_remark_edit.Text
                If txt_remark_edit.Text <> "" Then
                    dao.fields.Update_reason = DateTime.Now
                End If
                Try
                    dao.fields.Other_commands = DD_OTHER_REQUEST.SelectedItem.Text
                    dao.fields.Other_commands_ID = DD_OTHER_REQUEST.SelectedValue
                    dao.fields.Other_commands_Day = txt_day_other.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.Position_Licensor = DD_POSITION_STAFF.SelectedItem.Text
                    dao.fields.Position_Licensor_ID = DD_POSITION_STAFF.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    If DDL_SLCHN.SelectedValue <> "-- กรุณาเลือก --" Then
                        dao_d.fields.SALE_CHANNEL_ID = DDL_SLCHN.SelectedValue
                        dao_d.fields.SALE_CHANNEL_NAME = DDL_SLCHN.SelectedItem.Text
                    End If
                Catch ex As Exception

                End Try
                Try
                    If DDL_Kindnm.SelectedValue <> "-- กรุณาเลือก --" Then
                        dao_d.fields.TYPE_SUB_ID = DDL_Kindnm.SelectedValue
                        dao_d.fields.TYPE_SUB_NAME = DDL_Kindnm.SelectedItem.Text
                    End If
                Catch ex As Exception

                End Try
                Try
                    If UC_ATTACH2.CHK_TBN = True Then
                        UC_ATTACH1.insert_TBN_Edit(_TR_ID, _Process_ID, _IDA, 14)
                    End If
                Catch ex As Exception

                End Try
                dao.Update()
                dao_d.Update()
                AddLogStatus(dao.fields.STATUS_ID, _Process_ID, _CLS.CITIZEN_ID, _IDA)
                Updata_data_tabean_to_124()
                Updata_data_tabean_to_168()
                BIND_PDF_TABEAN()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            End If
        ElseIf dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 10 Then
            dao.fields.NOTE_CANCEL = NOTE_CANCLE.Text
            Try
                dao.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                dao.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
            Catch ex As Exception

            End Try
            'dao.fields.cancel_date = Date.Now
            dao.fields.cancel_date = RDP_CANCEL_DATE.SelectedDate
            dao.fields.cancel_by = _CLS.THANM
            dao.fields.cancel_iden = _CLS.CITIZEN_ID
            UC_ATTACH1.insert_TBN_EDIT(_TR_ID, _Process_ID, dao.fields.IDA, 77)
            dao.Update()
            AddLogStatus(dao.fields.STATUS_ID, _Process_ID, _CLS.CITIZEN_ID, _IDA)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        End If

    End Sub
    Public Sub Updata_data_tabean_to_168()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_c As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao_c.GetdatabyID_FK_IDA(_IDA)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        dao_g.GetDataby_IDA(_IDA_DR)
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_tabean.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
        Catch ex As Exception

        End Try
        If dao_c.fields.NAME_PRODUCT_ID = True Then
            If dao_d.fields.NAME_THAI IsNot Nothing Then dao_tabean.fields.NAME_ENG = dao_d.fields.NAME_THAI
            If dao_d.fields.NAME_THAI IsNot Nothing Then dao_tabean.fields.NAME_OTHER = dao_d.fields.NAME_OTHER
            If dao_d.fields.NAME_THAI IsNot Nothing Then dao_tabean.fields.NAME_EXPORT = dao_d.fields.NAME_EXPORT
        End If
        If dao_c.fields.NAME_LOCATION_ID = True Then
            If dao_c.fields.SUB_Location1_ID = True Or dao_c.fields.SUB_Location2_ID = True Then
                If dao_c.fields.SUB_Location1_ID = True Then
                    If dao_d.fields.LCN_ID IsNot Nothing Then dao_tabean.fields.LCN_ID = dao_d.fields.LCN_ID
                    dao_tabean.fields.LCN_ADDR = dao_d.fields.LCN_ADDR
                    dao_tabean.fields.LCN_NAME = dao_d.fields.LCN_NAME
                    dao_tabean.fields.LCN_THANAMEPLACE = dao_d.fields.LCN_THANAMEPLACE
                    'dao_tabean.fields.COMPANY_NAME = dao_d.fields.LCN_NAME
                End If
            End If
            If dao_c.fields.SUB_Location3_ID = True Then
                If dao_d.fields.FOREIGN_NAME_ID IsNot Nothing Then dao_tabean.fields.FOREIGN_NAME_ID = dao_d.fields.FOREIGN_NAME_ID
                dao_tabean.fields.FOREIGN_NAME = dao_d.fields.FOREIGN_NAME
                dao_tabean.fields.FOREIGN_NAME_PLACE = dao_d.fields.FOREIGN_NAME_PLACE
                If dao_d.fields.FOREIGN_NAME_PLACE_ID IsNot Nothing Then dao_tabean.fields.FOREIGN_NAME_PLACE_ID = dao_d.fields.FOREIGN_NAME_PLACE_ID
            End If
        End If
        If dao_c.fields.PRODUCT_RECIPE_ID = True Then

        End If
        If dao_c.fields.PRODUCTION_PROCESS_ID = True Then
            Dim dao_pp As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_MANUFACTRUE
            dao_pp.GetdatabyID_FK_IDA(_IDA)
            Dim dao_pp_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
            Try
                dao_pp_tabean.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
            Catch ex As Exception

            End Try
            If dao_pp_tabean.fields.IDA <> 0 Then
                dao_pp_tabean.Delete()
            End If
            For Each dao_pp.fields In dao_pp.datas
                Dim dao_pp_new As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_MANUFACTRUE
                dao_pp_new.GetdatabyID_FK_IDA(_IDA)
                With dao_pp_new.fields
                    .FK_IDA = dao_pp.fields.FK_IDA
                    .FK_IDA_DQ = dao_pp.fields.FK_IDA_DQ
                    .NO_ID = dao_pp.fields.NO_ID
                    .MENUFAC_ID = dao_pp.fields.MENUFAC_ID
                    .MENUFAC_NAME = dao_pp.fields.MENUFAC_NAME
                    .ACTIVEFACT = dao_pp.fields.ACTIVEFACT
                    .CREATE_DATE = dao_pp.fields.CREATE_DATE
                    .CREATE_USER = dao_pp.fields.CREATE_USER
                    .UPDATE_DATE = dao_pp.fields.UPDATE_DATE
                    .UPDATE_USER = dao_pp.fields.UPDATE_USER
                End With
                dao_pp_new.insert()
            Next
        End If
        If dao_c.fields.PROPERTIES_ID = True Then
            dao_tabean.fields.PROPERTIES = dao_d.fields.PROPERTIES
        End If
        If dao_c.fields.SIZE_USE_ID = True Then
            dao_tabean.fields.SIZE_USE = dao_d.fields.SIZE_USE
        End If
        If dao_c.fields.PREPARE_EAT_ID = True Then
            If dao_d.fields.EATTING_ID IsNot Nothing Then dao_tabean.fields.EATTING_ID = dao_d.fields.EATTING_ID
            dao_tabean.fields.EATTING_NAME = dao_d.fields.EATTING_NAME
            dao_tabean.fields.EATTING_NAME_DETAIL = dao_d.fields.EATTING_NAME_DETAIL
        End If
        If dao_c.fields.EAT_CONDITION_ID = True Then
            If dao_d.fields.EATING_CONDITION_ID IsNot Nothing Then dao_tabean.fields.EATING_CONDITION_ID = dao_d.fields.EATING_CONDITION_ID
            dao_tabean.fields.EATING_CONDITION_NAME = dao_d.fields.EATING_CONDITION_NAME
            dao_tabean.fields.EATING_CONDITION_NAME_DETAIL = dao_d.fields.EATING_CONDITION_NAME_DETAIL
        End If
        If dao_c.fields.STORAGE_ID = True Then
            If dao_d.fields.STORAGE_ID IsNot Nothing Then dao_tabean.fields.STORAGE_ID = dao_d.fields.STORAGE_ID
            dao_tabean.fields.STORAGE_NAME = dao_d.fields.STORAGE_NAME

            dao_tabean.fields.TREATMENT_AGE_MONTH = dao_d.fields.TREATMENT_AGE_MONTH
            dao_tabean.fields.TREATMENT_AGE = dao_d.fields.TREATMENT_AGE
            If dao_d.fields.TREATMENT_AGE_ID IsNot Nothing Then dao_tabean.fields.TREATMENT_AGE_ID = dao_d.fields.TREATMENT_AGE_ID
        End If
        If dao_c.fields.CONTAINER_PACKING_ID = True Then
            dao_tabean.fields.SIZE_PACK = dao_d.fields.SIZE_PACK

            Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK
            dao_size.GetdatabyID_FK_IDA(_IDA)
            Dim dao_size_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
            dao_size_tabean.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
            If dao_size_tabean.fields.IDA <> 0 Then
                dao_size_tabean.Delete()
            End If
            For Each dao_size.fields In dao_size.datas
                Dim dao_size_new As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
                'dao_size_new.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
                With dao_size_new.fields
                    '.FK_IDA = dao_size.fields.FK_IDA
                    .FK_IDA_DQ = dao_size.fields.FK_IDA_DQ
                    .PACK_F_ID = dao_size.fields.PACK_F_ID
                    .PACK_F_NAME = dao_size.fields.PACK_F_NAME
                    .NO_1 = dao_size.fields.NO_1
                    .UNIT_F_ID = dao_size.fields.UNIT_F_ID
                    .UNIT_F_NAME = dao_size.fields.UNIT_F_NAME
                    .PACK_S_ID = dao_size.fields.PACK_S_ID
                    .PACK_S_NAME = dao_size.fields.PACK_S_NAME
                    .NO_2 = dao_size.fields.NO_2
                    .UNIT_S_ID = dao_size.fields.UNIT_S_ID
                    .UNIT_S_NAME = dao_size.fields.UNIT_S_NAME
                    .PACK_T_ID = dao_size.fields.PACK_T_ID
                    .PACK_T_NAME = dao_size.fields.PACK_T_NAME
                    .NO_3 = dao_size.fields.NO_3
                    .UNIT_T_ID = dao_size.fields.UNIT_T_ID
                    .UNIT_T_NAME = dao_size.fields.UNIT_T_NAME
                    .ACTIVEFACT = dao_size.fields.ACTIVEFACT
                    .CREATE_DATE = dao_size.fields.CREATE_DATE
                    .CREATE_USER = dao_size.fields.CREATE_USER
                    .UPDATE_DATE = dao_size.fields.UPDATE_DATE
                    .UPDATE_USER = dao_size.fields.UPDATE_USER
                End With
                dao_size_new.insert()
            Next
        End If
        If dao_c.fields.QUALITY_CONTROL_ID = True Then

        End If
        If dao_c.fields.ETIQUETQ_ID = True Then

        End If
        If dao_c.fields.CHANNEL_SALE_ID = True Then
            dao_tabean.fields.SALE_CHANNEL_ID = dao_d.fields.SALE_CHANNEL_ID
            dao_tabean.fields.SALE_CHANNEL_NAME = dao_d.fields.SALE_CHANNEL_ID
        End If
        dao_tabean.Update()
    End Sub
    Public Sub Updata_data_tabean_to_124()
        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        Dim cls_xml As New Cls_XML
        Dim p2 As New LGT_IOW_E
        Dim xml_str As String
        Dim dao_h As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        dao_g.GetDataby_IDA(_IDA_DR)
        Try
            If dao_g.fields.rgtno IsNot Nothing Then
                dao_h.GetDataby_4Key(dao_g.fields.rgtno, dao_g.fields.rgttpcd, dao_g.fields.drgtpcd, dao_g.fields.pvncd)
            Else
                dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
            End If
            NEWCODE = dao_h.fields.Newcode
            NEWCODE_U = dao_h.fields.Newcode_U
        Catch ex As Exception
            dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
        End Try
        Dim dao_tabean As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_tabean.GetdatabyID_FK_IDA_DQ(dao_g.fields.FK_DRRQT)
        Catch ex As Exception

        End Try
        xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(NEWCODE)
        p2 = ConvertFromXml(Of LGT_IOW_E)(xml_str)   'ดึงไฟล์xml จาก BC
        Dim dao_c As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao_c.GetdatabyID_FK_IDA(_IDA)
#Region "ชื่อของผลิตภัณฑ์"

        If dao_c.fields.NAME_PRODUCT_ID = True Then
            If dao_c.fields.SUB_NAME_THAI = True Then p2.XML_SEARCH_DRUG_DR.thadrgnm = dao_d.fields.NAME_THAI
            'If dao_d.fields.NAME_THAI IsNot Nothing Then p2.XML_SEARCH_DRUG_DR.thadrgnm = dao_d.fields.NAME_THAI
            p2.XML_SEARCH_DRUG_DR.engdrgnm = dao_d.fields.NAME_ENG

        End If
#End Region

#Region "ที่อยู่ของสถานที่"

        If dao_c.fields.NAME_LOCATION_ID = True Then
            Dim dao_herb_lcn As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            dao_herb_lcn.GetDataby_LCN_IDA(dao_d.fields.IDA_LCN)
            Dim dao_licen_loca As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
            dao_licen_loca.GetDataby_LCN_IDA(dao_d.fields.IDA_LCN)
            If dao_c.fields.SUB_Location1_ID = True Or dao_c.fields.SUB_Location2_ID = True Then
                If dao_c.fields.SUB_Location1_ID = True Then
                    p2.XML_SEARCH_DRUG_DR.lpvncd = dao_herb_lcn.fields.pvncd
                    p2.XML_SEARCH_DRUG_DR.thanm = dao_herb_lcn.fields.thanm
                    p2.XML_SEARCH_DRUG_DR.lcnno = dao_herb_lcn.fields.lcnno
                    p2.XML_SEARCH_DRUG_DR.lcnno_no = dao_herb_lcn.fields.lcnno_no
                    p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_herb_lcn.fields.lcntpcd
                    p2.XML_SEARCH_DRUG_DR.thanm_locaion = dao_herb_lcn.fields.thanm
                    p2.XML_SEARCH_DRUG_DR.licen_loca = dao_licen_loca.fields.licen
                    p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_herb_lcn.fields.lcntpcd
                    p2.XML_SEARCH_DRUG_DR.fulladdr = dao_herb_lcn.fields.thanm_addr
                    p2.XML_SEARCH_DRUG_DR.thaaddr_thanm = dao_herb_lcn.fields.thaaddr
                    p2.XML_SEARCH_DRUG_DR.tharoom_thanm = dao_herb_lcn.fields.tharoom
                    p2.XML_SEARCH_DRUG_DR.thafloor_thanm = dao_herb_lcn.fields.thafloor
                    p2.XML_SEARCH_DRUG_DR.thabuilding_thanm = dao_herb_lcn.fields.thabuilding
                    p2.XML_SEARCH_DRUG_DR.thasoi_thanm = dao_herb_lcn.fields.thasoi
                    p2.XML_SEARCH_DRUG_DR.tharoad_thanm = dao_herb_lcn.fields.tharoad
                    p2.XML_SEARCH_DRUG_DR.thamu_thanm = dao_herb_lcn.fields.thamu
                    p2.XML_SEARCH_DRUG_DR.thathmblnm_thanm = dao_herb_lcn.fields.thathmblnm
                    p2.XML_SEARCH_DRUG_DR.thaamphrnm_thanm = dao_herb_lcn.fields.thaamphrnm
                    p2.XML_SEARCH_DRUG_DR.zipcode_thanm = dao_herb_lcn.fields.zipcode
                    p2.XML_SEARCH_DRUG_DR.tel_thanm = dao_herb_lcn.fields.tel
                    p2.XML_SEARCH_DRUG_DR.Newcode_not = dao_herb_lcn.fields.Newcode_not
                ElseIf dao_c.fields.SUB_Location2_ID = True Then
                    p2.XML_SEARCH_DRUG_DR.lpvncd = dao_herb_lcn.fields.pvncd
                    p2.XML_SEARCH_DRUG_DR.thanm = dao_herb_lcn.fields.thanm
                    p2.XML_SEARCH_DRUG_DR.lcnno = dao_herb_lcn.fields.lcnno
                    p2.XML_SEARCH_DRUG_DR.lcnno_no = dao_herb_lcn.fields.lcnno_no
                    p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_herb_lcn.fields.lcntpcd
                    p2.XML_SEARCH_DRUG_DR.thanm_locaion = dao_herb_lcn.fields.thanm
                    p2.XML_SEARCH_DRUG_DR.licen_loca = dao_licen_loca.fields.licen
                    p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_herb_lcn.fields.lcntpcd
                    p2.XML_SEARCH_DRUG_DR.fulladdr = dao_herb_lcn.fields.thanm_addr
                    p2.XML_SEARCH_DRUG_DR.thaaddr_thanm = dao_herb_lcn.fields.thaaddr
                    p2.XML_SEARCH_DRUG_DR.tharoom_thanm = dao_herb_lcn.fields.tharoom
                    p2.XML_SEARCH_DRUG_DR.thafloor_thanm = dao_herb_lcn.fields.thafloor
                    p2.XML_SEARCH_DRUG_DR.thabuilding_thanm = dao_herb_lcn.fields.thabuilding
                    p2.XML_SEARCH_DRUG_DR.thasoi_thanm = dao_herb_lcn.fields.thasoi
                    p2.XML_SEARCH_DRUG_DR.tharoad_thanm = dao_herb_lcn.fields.tharoad
                    p2.XML_SEARCH_DRUG_DR.thamu_thanm = dao_herb_lcn.fields.thamu
                    p2.XML_SEARCH_DRUG_DR.thathmblnm_thanm = dao_herb_lcn.fields.thathmblnm
                    p2.XML_SEARCH_DRUG_DR.thaamphrnm_thanm = dao_herb_lcn.fields.thaamphrnm
                    p2.XML_SEARCH_DRUG_DR.zipcode_thanm = dao_herb_lcn.fields.zipcode
                    p2.XML_SEARCH_DRUG_DR.tel_thanm = dao_herb_lcn.fields.tel
                    p2.XML_SEARCH_DRUG_DR.Newcode_not = dao_herb_lcn.fields.Newcode_not
                End If
            End If

            If dao_c.fields.SUB_Location3_ID = True Then
                p2.XML_SEARCH_DRUG_DR.engfrgnnm = dao_d.fields.FOREIGN_NAME
                p2.XML_SEARCH_DRUG_DR.engfrgnnm_addr = dao_d.fields.FOREIGN_NAME_PLACE
            End If

        End If
#End Region

#Region "ตำรับผลิตภัณฑ์สมุนไพร"

        If dao_c.fields.PRODUCT_RECIPE_ID = True Then
            'Dim dao_recipe As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_IOWA
            'dao_recipe.GetDataby_Newcode_U(NEWCODE_U)
            'Dim dao_iow As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_IOWA
            ''Dim dao_iow_gp As New DAO_DRUG_ESUB.TB_XML_DRUG_IOW
            'Dim dao_iow_gp As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_IOWA
            'dao_iow_gp.GetDataby_Newcode_U_GROUP(NEWCODE_U)

            Dim dt_iow As New DataTable
            Dim bao_iow As New BAO.ClsDBSqlcommand
            Try
                dt_iow = bao_iow.SP_XML_HERB_EDIT_IOW_BY_IDA(_IDA_DR)
                'dt_iow = bao_iow.SP_XML_DRUG_IOW_BY_IDA(_IDA_DR)
            Catch ex As Exception

            End Try
            'Dim dao_iow As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
            'Dim dao_iow_gp As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW
            'dao_iow_gp.GetDataby_Newcode_U_GROUP(dao_dr.fields.Newcode_U)
            Dim dt_iow_set As New DataTable
            Dim bao_iow_set As New BAO.ClsDBSqlcommand

            For Each dr As DataRow In dt_iow.Rows ' dao_iow_gp.datas
                ' dao_iow.GetDataby_Newcode_U(dao_dr.fields.Newcode_U, dr.ToString.Substring(12).Replace("}", "")) ' Substring=12 เพ
                Try
                    dt_iow_set = bao_iow_set.SP_XML_HERB_EDIT_IOW_BY_IDA_FK_SET(_IDA_DR, dr("flineno"))
                Catch ex As Exception

                End Try
                For Each dr_set As DataRow In dt_iow_set.Rows 'dao_iow.datas
                    Dim lgt_iow As New XML_DRUG_IOW_TO

                    If IsNothing(dr_set("IDA")) = False Then
                        lgt_iow.XML_DRUG_IOW.IDA = dr_set("IDA")
                    Else
                        lgt_iow.XML_DRUG_IOW.IDA = 0
                    End If

                    If IsNothing(dr_set("pvncd")) = False Then
                        lgt_iow.XML_DRUG_IOW.pvncd = dr_set("pvncd")
                    Else
                        lgt_iow.XML_DRUG_IOW.pvncd = ""
                    End If

                    If IsNothing(dr_set("rgttpcd")) = False Then
                        lgt_iow.XML_DRUG_IOW.rgttpcd = dr_set("rgttpcd")
                    Else
                        lgt_iow.XML_DRUG_IOW.rgttpcd = ""
                    End If

                    If IsNothing(dr_set("rgtno")) = False Then
                        lgt_iow.XML_DRUG_IOW.rgtno = dr_set("rgtno")
                    Else
                        lgt_iow.XML_DRUG_IOW.rgtno = ""
                    End If

                    If IsNothing(dr_set("lcnno")) = False Then
                        lgt_iow.XML_DRUG_IOW.lcnno = dr_set("lcnno")
                    Else
                        lgt_iow.XML_DRUG_IOW.lcnno = ""
                    End If
                    If IsNothing(dr_set("register")) = False Then
                        lgt_iow.XML_DRUG_IOW.register = dr_set("register")
                    Else
                        lgt_iow.XML_DRUG_IOW.register = ""
                    End If

                    If IsNothing(dr_set("lcnsid")) = False Then
                        lgt_iow.XML_DRUG_IOW.lcnsid = dr_set("lcnsid")
                    Else
                        lgt_iow.XML_DRUG_IOW.lcnsid = ""
                    End If


                    If IsNothing(dr_set("CITIZEN_AUTHORIZE")) = False Then
                        lgt_iow.XML_DRUG_IOW.CITIZEN_AUTHORIZE = dr_set("CITIZEN_AUTHORIZE")
                    Else
                        lgt_iow.XML_DRUG_IOW.CITIZEN_AUTHORIZE = ""
                    End If

                    If IsNothing(dr_set("flineno")) = False Then
                        lgt_iow.XML_DRUG_IOW.flineno = dr_set("flineno")
                    Else
                        lgt_iow.XML_DRUG_IOW.flineno = ""
                    End If

                    If IsNothing(dr_set("drgqty")) = False Then
                        lgt_iow.XML_DRUG_IOW.drgqty = dr_set("drgqty")
                    Else
                        lgt_iow.XML_DRUG_IOW.drgqty = ""
                    End If

                    If IsNothing(dr_set("drgperunit")) = False Then
                        lgt_iow.XML_DRUG_IOW.drgperunit = dr_set("drgperunit")
                    Else
                        lgt_iow.XML_DRUG_IOW.drgperunit = ""
                    End If

                    If IsNothing(dr_set("drgcdt")) = False Then
                        lgt_iow.XML_DRUG_IOW.drgcdt = dr_set("drgcdt")
                    Else
                        lgt_iow.XML_DRUG_IOW.drgcdt = ""
                    End If

                    If IsNothing(dr_set("thadsgnm")) = False Then
                        lgt_iow.XML_DRUG_IOW.thadsgnm = dr_set("thadsgnm")
                    Else
                        lgt_iow.XML_DRUG_IOW.thadsgnm = ""
                    End If


                    If IsNothing(dr_set("rid")) = False Then
                        lgt_iow.XML_DRUG_IOW.rid = dr_set("rid")
                    Else
                        lgt_iow.XML_DRUG_IOW.rid = ""
                    End If


                    If IsNothing(dr_set("iowacd")) = False Then
                        lgt_iow.XML_DRUG_IOW.iowacd = dr_set("iowacd")
                    Else
                        lgt_iow.XML_DRUG_IOW.iowacd = ""
                    End If


                    If IsNothing(dr_set("iowanm")) = False Then
                        lgt_iow.XML_DRUG_IOW.iowanm = dr_set("iowanm")
                    Else
                        lgt_iow.XML_DRUG_IOW.iowanm = ""
                    End If
                    If IsNothing(dr_set("SinggleContent")) = False Then
                        lgt_iow.XML_DRUG_IOW.SinggleContent = dr_set("SinggleContent")
                    Else
                        lgt_iow.XML_DRUG_IOW.SinggleContent = ""
                    End If

                    If IsNothing(dr_set("UnitForSinggleContent")) = False Then
                        lgt_iow.XML_DRUG_IOW.UnitForSinggleContent = dr_set("UnitForSinggleContent")
                    Else
                        lgt_iow.XML_DRUG_IOW.UnitForSinggleContent = ""
                    End If

                    If IsNothing(dr_set("qtytxt_all")) = False Then
                        lgt_iow.XML_DRUG_IOW.qtytxt_all = dr_set("qtytxt_all")
                    Else
                        lgt_iow.XML_DRUG_IOW.qtytxt_all = ""
                    End If

                    If IsNothing(dr_set("qtytxt")) = False Then
                        lgt_iow.XML_DRUG_IOW.qtytxt = dr_set("qtytxt")
                    Else
                        lgt_iow.XML_DRUG_IOW.qtytxt = ""
                    End If

                    If IsNothing(dr_set("qty")) = False Then
                        lgt_iow.XML_DRUG_IOW.qty = dr_set("qty")
                    Else
                        lgt_iow.XML_DRUG_IOW.qty = ""
                    End If


                    If IsNothing(dr_set("qty_y")) = False Then
                        lgt_iow.XML_DRUG_IOW.qty_y = dr_set("qty_y")
                    Else
                        lgt_iow.XML_DRUG_IOW.qty_y = ""
                    End If



                    If IsNothing(dr_set("qty_y")) = False Then
                        lgt_iow.XML_DRUG_IOW.qty_y = dr_set("qty_y")
                    Else
                        lgt_iow.XML_DRUG_IOW.qty_y = ""
                    End If



                    If IsNothing(dr_set("sunitengnm")) = False Then
                        lgt_iow.XML_DRUG_IOW.sunitengnm = dr_set("sunitengnm")
                    Else
                        lgt_iow.XML_DRUG_IOW.sunitengnm = ""
                    End If


                    If IsNothing(dr_set("thadrgnm")) = False Then
                        lgt_iow.XML_DRUG_IOW.thadrgnm = dr_set("thadrgnm")
                    Else
                        lgt_iow.XML_DRUG_IOW.thadrgnm = ""
                    End If

                    If IsNothing(dr_set("engdrgnm")) = False Then
                        lgt_iow.XML_DRUG_IOW.engdrgnm = dr_set("engdrgnm")
                    Else
                        lgt_iow.XML_DRUG_IOW.engdrgnm = ""
                    End If


                    If IsNothing(dr_set("aori")) = False Then
                        lgt_iow.XML_DRUG_IOW.aori = dr_set("aori")
                    Else
                        lgt_iow.XML_DRUG_IOW.aori = ""
                    End If


                    If IsNothing(dr_set("aori_description")) = False Then
                        lgt_iow.XML_DRUG_IOW.aori_description = dr_set("aori_description")
                    Else
                        lgt_iow.XML_DRUG_IOW.aori_description = ""
                    End If

                    If IsNothing(dr_set("remark")) = False Then
                        lgt_iow.XML_DRUG_IOW.remark = dr_set("remark")
                    Else
                        lgt_iow.XML_DRUG_IOW.remark = ""
                    End If


                    If IsNothing(dr_set("cncnm")) = False Then
                        lgt_iow.XML_DRUG_IOW.cncnm = dr_set("cncnm")
                    Else
                        lgt_iow.XML_DRUG_IOW.cncnm = ""
                    End If



                    If IsNothing(dr_set("licen_loca")) = False Then
                        lgt_iow.XML_DRUG_IOW.licen_loca = dr_set("licen_loca")
                    Else
                        lgt_iow.XML_DRUG_IOW.licen_loca = ""
                    End If

                    If IsNothing(dr_set("Newcode_U")) = False Then
                        lgt_iow.XML_DRUG_IOW.Newcode_U = dr_set("Newcode_U")
                    Else
                        lgt_iow.XML_DRUG_IOW.Newcode_U = ""
                    End If


                    If IsNothing(dr_set("Newcode_rid")) = False Then
                        lgt_iow.XML_DRUG_IOW.Newcode_rid = dr_set("Newcode_rid")
                    Else
                        lgt_iow.XML_DRUG_IOW.Newcode_rid = ""
                    End If

                    If IsNothing(dr_set("Newcode_R")) = False Then
                        lgt_iow.XML_DRUG_IOW.Newcode_R = dr_set("Newcode_R")
                    Else
                        lgt_iow.XML_DRUG_IOW.Newcode_R = ""
                    End If



                    If IsNothing(dr_set("RoleinFomular")) = False Then
                        lgt_iow.XML_DRUG_IOW.RoleinFomular = dr_set("RoleinFomular")
                    Else
                        lgt_iow.XML_DRUG_IOW.RoleinFomular = ""
                    End If

                    If IsNothing(dr_set("ConditionContent")) = False Then
                        lgt_iow.XML_DRUG_IOW.ConditionContent = dr_set("ConditionContent")
                    Else
                        lgt_iow.XML_DRUG_IOW.ConditionContent = ""
                    End If


                    If IsNothing(dr_set("MultiplyNumberStart")) = False Then
                        lgt_iow.XML_DRUG_IOW.MultiplyNumberStart = dr_set("MultiplyNumberStart")
                    Else
                        lgt_iow.XML_DRUG_IOW.MultiplyNumberStart = ""
                    End If


                    If IsNothing(dr_set("BaseNumberStart")) = False Then
                        lgt_iow.XML_DRUG_IOW.BaseNumberStart = dr_set("BaseNumberStart")
                    Else
                        lgt_iow.XML_DRUG_IOW.BaseNumberStart = ""
                    End If



                    If IsNothing(dr_set("PowerNumberStart")) = False Then
                        lgt_iow.XML_DRUG_IOW.PowerNumberStart = dr_set("PowerNumberStart")
                    Else
                        lgt_iow.XML_DRUG_IOW.PowerNumberStart = ""
                    End If


                    If IsNothing(dr_set("MultiplyNumberEND")) = False Then
                        lgt_iow.XML_DRUG_IOW.MultiplyNumberEND = dr_set("MultiplyNumberEND")
                    Else
                        lgt_iow.XML_DRUG_IOW.MultiplyNumberEND = ""
                    End If

                    If IsNothing(dr_set("BaseNumberEND")) = False Then
                        lgt_iow.XML_DRUG_IOW.BaseNumberEND = dr_set("BaseNumberEND")
                    Else
                        lgt_iow.XML_DRUG_IOW.BaseNumberEND = ""
                    End If


                    If IsNothing(dr_set("PowerNumberEND")) = False Then
                        lgt_iow.XML_DRUG_IOW.PowerNumberEND = dr_set("PowerNumberEND")
                    Else
                        lgt_iow.XML_DRUG_IOW.PowerNumberEND = ""
                    End If


                    If IsNothing(dr_set("UnitForRangeContent")) = False Then
                        lgt_iow.XML_DRUG_IOW.UnitForRangeContent = dr_set("UnitForRangeContent")
                    Else
                        lgt_iow.XML_DRUG_IOW.UnitForRangeContent = ""
                    End If
                    If IsNothing(dr_set("IDA_DRRGT_DETAIL_CAS")) = False Then
                        lgt_iow.XML_DRUG_IOW.IDA_DRRGT_DETAIL_CAS = dr_set("IDA_DRRGT_DETAIL_CAS")
                    Else
                        lgt_iow.XML_DRUG_IOW.IDA_DRRGT_DETAIL_CAS = 0
                    End If


                    Dim dt_eq As New DataTable
                    Dim bao_eq As New BAO.ClsDBSqlcommand
                    Try
                        dt_eq = bao_eq.SP_XML_HERB_IOW_EQ_BY_FK_IDA_FK_SET(dr_set("IDA"), dr_set("flineno"))
                    Catch ex As Exception

                    End Try


                    'Dim dao_iow_eq As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW_EQ  ' ถ้าเป็น List of2 ต้องใช้อันนี้ และ การที่นำเข้ามาไว้ใน next คือ List ซ้อน List  ชื่อสารที่อยู่ในแต่ละผลิตภัณฑ์ย่อย
                    'dao_iow_eq.GetDataby_Newcode_RID(dao_iow.fields.Newcode_rid)

                    For Each dr_eq As DataRow In dt_eq.Rows
                        Dim lgt_eq As New LGT_IOW_EQ_TO                            ' XML_CMT_TYPE2 คือตารางชื่อสาร  

                        lgt_eq.XML_DRUG_IOW_EQ.IDA = dr_eq("IDA")
                        If IsNothing(dr_eq("IDA")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.IDA = dr_eq("IDA")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.IDA = 0
                        End If



                        If IsNothing(dr_eq("pvncd")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.pvncd = dr_eq("pvncd")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.pvncd = ""
                        End If


                        If IsNothing(dr_eq("drgtpcd")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.drgtpcd = dr_eq("drgtpcd")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.drgtpcd = ""
                        End If

                        If IsNothing(dr_eq("rgttpcd")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.rgttpcd = dr_eq("rgttpcd")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.rgttpcd = ""
                        End If

                        If IsNothing(dr_eq("rgtno")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.rgtno = dr_eq("rgtno")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.rgtno = ""
                        End If

                        If IsNothing(dr_eq("lcnno")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.lcnno = dr_eq("lcnno")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.lcnno = ""
                        End If

                        If IsNothing(dr_eq("register")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.register = dr_eq("register")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.register = ""
                        End If

                        If IsNothing(dr_eq("CITIZEN_AUTHORIZE")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.CITIZEN_AUTHORIZE = dr_eq("CITIZEN_AUTHORIZE")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.CITIZEN_AUTHORIZE = ""
                        End If

                        If IsNothing(dr_eq("thadrgnm")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.thadrgnm = dr_eq("thadrgnm")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.thadrgnm = ""
                        End If


                        If IsNothing(dr_eq("engdrgnm")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.engdrgnm = dr_eq("engdrgnm")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.engdrgnm = ""
                        End If

                        If IsNothing(dr_eq("flineno")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.flineno = dr_eq("flineno")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.flineno = ""
                        End If

                        If IsNothing(dr_eq("drgqty")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.drgqty = dr_eq("drgqty")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.drgqty = ""
                        End If


                        If IsNothing(dr_eq("drgperunit")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.drgperunit = dr_eq("drgperunit")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.drgperunit = ""
                        End If

                        If IsNothing(dr_eq("drgcdt")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.drgcdt = dr_eq("drgcdt")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.drgcdt = ""
                        End If

                        If IsNothing(dr_eq("drgcdt_condition")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.drgcdt_condition = dr_eq("drgcdt_condition")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.drgcdt_condition = ""
                        End If


                        If IsNothing(dr_eq("rid")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.rid = dr_eq("rid")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.rid = ""
                        End If

                        If IsNothing(dr_eq("elineno")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.elineno = dr_eq("elineno")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.elineno = ""
                        End If

                        If IsNothing(dr_eq("iowacd")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.iowacd = dr_eq("iowacd")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.iowacd = ""
                        End If


                        If IsNothing(dr_eq("iowanm")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.iowanm = dr_eq("iowanm")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.iowanm = ""
                        End If

                        If IsNothing(dr_eq("SinggleContent")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.SinggleContent = dr_eq("SinggleContent")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.SinggleContent = ""
                        End If

                        If IsNothing(dr_eq("UnitForSinggleContent")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.UnitForSinggleContent = dr_eq("UnitForSinggleContent")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.UnitForSinggleContent = ""
                        End If


                        If IsNothing(dr_eq("qty")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.qty = dr_eq("qty")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.qty = ""
                        End If

                        If IsNothing(dr_eq("ConditionContent")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.ConditionContent = dr_eq("ConditionContent")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.ConditionContent = ""
                        End If

                        If IsNothing(dr_eq("MultiplyNumberStart")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberStart = dr_eq("MultiplyNumberStart")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberStart = ""
                        End If


                        If IsNothing(dr_eq("BaseNumberStart")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.BaseNumberStart = dr_eq("BaseNumberStart")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.BaseNumberStart = ""
                        End If

                        If IsNothing(dr_eq("PowerNumberStart")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.PowerNumberStart = dr_eq("PowerNumberStart")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.PowerNumberStart = ""
                        End If

                        If IsNothing(dr_eq("MultiplyNumberEND")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberEND = dr_eq("MultiplyNumberEND")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberEND = ""
                        End If


                        If IsNothing(dr_eq("BaseNumberEND")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.BaseNumberEND = dr_eq("BaseNumberEND")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.BaseNumberEND = ""
                        End If

                        If IsNothing(dr_eq("PowerNumberEND")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.PowerNumberEND = dr_eq("PowerNumberEND")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.PowerNumberEND = ""
                        End If

                        If IsNothing(dr_eq("UnitForRangeContent")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.UnitForRangeContent = dr_eq("UnitForRangeContent")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.UnitForRangeContent = ""
                        End If


                        If IsNothing(dr_eq("aori")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.aori = dr_eq("aori")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.aori = ""
                        End If

                        If IsNothing(dr_eq("Newcode")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.Newcode = dr_eq("Newcode")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.Newcode = ""
                        End If

                        If IsNothing(dr_eq("Newcode_rid")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.Newcode_rid = dr_eq("Newcode_rid")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.Newcode_rid = ""
                        End If


                        If IsNothing(dr_eq("Newcode_R")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.Newcode_R = dr_eq("Newcode_R")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.Newcode_R = ""
                        End If

                        If IsNothing(dr_eq("licen_loca")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.licen_loca = dr_eq("licen_loca")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.licen_loca = ""
                        End If

                        If IsNothing(dr_eq("thaclassnm")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.thaclassnm = dr_eq("thaclassnm")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.thaclassnm = ""
                        End If


                        If IsNothing(dr_eq("cncnm")) = False Then
                            lgt_eq.XML_DRUG_IOW_EQ.cncnm = dr_eq("cncnm")
                        Else
                            lgt_eq.XML_DRUG_IOW_EQ.cncnm = ""
                        End If
                        'XML_DRUG_IOW_TO1.LGT_IOW_EQ_TO.Add(lgt_eq)
                        'lgt_iow.LGT_IOW_EQ_TO.Add(lgt_eq)

                    Next
                    XML_DRUG_IOW_TO1.XML_DRUG_IOW = lgt_iow.XML_DRUG_IOW

                    'XML_DRUG_IOW_TYPE1.XML_DRUG_IOW_TO.Add(XML_DRUG_IOW_TO1)

                    XML_DRUG_IOW_TO1 = New XML_DRUG_IOW_TO
                Next


                'p2.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Add(XML_DRUG_IOW_TYPE1)
                XML_DRUG_IOW_TYPE1 = New XML_DRUG_IOW_TYPE
            Next

            'p2.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Add(XML_DRUG_IOW_TYPE1)
        End If
#End Region

#Region "กรรมวิธีการผลิต"

        If dao_c.fields.PRODUCTION_PROCESS_ID = True Then

        End If
#End Region

#Region "สรรพคุณ/ข้อบ่งใช้/ ข้อความกล่าวอ้างทางสุขภาพ"

        If dao_c.fields.PROPERTIES_ID = True Then
            p2.XML_SEARCH_DRUG_DR.indication = dao_d.fields.PROPERTIES
        End If
#End Region

#Region "ขนาดและวิธีการใช้/ ภาชนะและขนาดบรรจุ"

        If dao_c.fields.SIZE_USE_ID = True Or dao_c.fields.CONTAINER_PACKING_ID = True Then
            'dao_d.fields.SIZE_PACK = txt_SizePack_New.Te
            Dim dao_contain As New DAO_XML_DRUG_HERB.TB_XML_DRUG_CONTAIN_HERB
            dao_contain.GetDataby_Newcode(NEWCODE)
            If dao_contain.Details.Count <> 0 Then

                For Each dao_contain.fields In dao_contain.datas
                    Dim lgt_contain As New LGT_XML_DRUG_CONTAIN

                    If IsNothing(dao_contain.fields.IDA) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.IDA = dao_contain.fields.IDA
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.IDA = 0
                    End If
                    If IsNothing(dao_contain.fields.pvncd) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.pvncd = dao_contain.fields.pvncd
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.pvncd = ""
                    End If
                    If IsNothing(dao_contain.fields.drgtpcd) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.drgtpcd = dao_contain.fields.drgtpcd
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.drgtpcd = ""
                    End If
                    If IsNothing(dao_contain.fields.rgttpcd) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.rgttpcd = dao_contain.fields.rgttpcd
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.rgttpcd = ""
                    End If
                    If IsNothing(dao_contain.fields.rgtno) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.rgtno = dao_contain.fields.rgtno
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.rgtno = ""
                    End If
                    If IsNothing(dao_contain.fields.lcnno) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.lcnno = dao_contain.fields.lcnno
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.lcnno = ""
                    End If
                    If IsNothing(dao_contain.fields.rid) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.rid = dao_contain.fields.rid
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.rid = ""
                    End If
                    If IsNothing(dao_contain.fields.SUBTITLE_SIZE_DRUG) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = dao_d.fields.SIZE_PACK
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = ""
                    End If
                    If IsNothing(dao_contain.fields.SMALL_AMOUNT) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.SMALL_AMOUNT = dao_contain.fields.SMALL_AMOUNT
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.SMALL_AMOUNT = 0.0
                    End If
                    If IsNothing(dao_contain.fields.SMALL_UNIT) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.SMALL_UNIT = dao_contain.fields.SMALL_UNIT
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.SMALL_UNIT = ""
                    End If
                    If IsNothing(dao_contain.fields.BIG_UNIT) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.BIG_UNIT = dao_contain.fields.BIG_UNIT
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.BIG_UNIT = ""
                    End If
                    If IsNothing(dao_contain.fields.BIG_AMOUNT) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.BIG_AMOUNT = dao_contain.fields.BIG_AMOUNT
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.BIG_AMOUNT = 0.0
                    End If
                    If IsNothing(dao_contain.fields.MEDIUM_AMOUNT) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = dao_contain.fields.MEDIUM_AMOUNT
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = 0.0
                    End If
                    If IsNothing(dao_contain.fields.MEDIUM_UNIT) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.MEDIUM_UNIT = dao_contain.fields.MEDIUM_UNIT
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.MEDIUM_UNIT = ""
                    End If
                    If IsNothing(dao_contain.fields.BARCODE) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.BARCODE = dao_contain.fields.BARCODE
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.BARCODE = ""
                    End If
                    If IsNothing(dao_contain.fields.SUM) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.SUM = dao_contain.fields.SUM
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.SUM = ""
                    End If

                    If IsNothing(dao_contain.fields.CONRAIN) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.CONRAIN = dao_contain.fields.CONRAIN
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.CONRAIN = ""
                    End If
                    If IsNothing(dao_contain.fields.STATUS_CONRAIN) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.STATUS_CONRAIN = dao_contain.fields.STATUS_CONRAIN
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.STATUS_CONRAIN = ""
                    End If
                    If IsNothing(dao_contain.fields.updateDate) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.updateDate = dao_contain.fields.updateDate
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.updateDate = Date.Now
                    End If
                    If IsNothing(dao_contain.fields.cncdate) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.cncdate = dao_contain.fields.cncdate
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.cncdate = Date.Now
                    End If
                    If IsNothing(dao_contain.fields.Newcode) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.Newcode = dao_contain.fields.Newcode
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.Newcode = ""
                    End If
                    If IsNothing(dao_contain.fields.IDA_DRRGT_PACKAGE_DETAIL) = False Then
                        lgt_contain.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = dao_contain.fields.IDA_DRRGT_PACKAGE_DETAIL
                    Else
                        lgt_contain.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = 0
                    End If
                    'p2.LGT_XML_DRUG_CONTAIN.Add(lgt_contain)
                Next
            Else

                'For Each dao_export.fields In dao_export.Details
                Dim lgt_contain1 As New LGT_XML_DRUG_CONTAIN
                lgt_contain1.XML_DRUG_CONTAIN.IDA = 0
                lgt_contain1.XML_DRUG_CONTAIN.pvncd = ""
                lgt_contain1.XML_DRUG_CONTAIN.drgtpcd = ""
                lgt_contain1.XML_DRUG_CONTAIN.rgttpcd = ""
                lgt_contain1.XML_DRUG_CONTAIN.pvncd = ""
                lgt_contain1.XML_DRUG_CONTAIN.rgtno = ""
                lgt_contain1.XML_DRUG_CONTAIN.rid = ""
                lgt_contain1.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = ""
                lgt_contain1.XML_DRUG_CONTAIN.SMALL_AMOUNT = ""
                lgt_contain1.XML_DRUG_CONTAIN.SMALL_UNIT = ""
                lgt_contain1.XML_DRUG_CONTAIN.BIG_UNIT = ""
                lgt_contain1.XML_DRUG_CONTAIN.BIG_AMOUNT = 0
                lgt_contain1.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = ""
                lgt_contain1.XML_DRUG_CONTAIN.MEDIUM_UNIT = ""
                lgt_contain1.XML_DRUG_CONTAIN.BARCODE = ""
                lgt_contain1.XML_DRUG_CONTAIN.SUM = ""
                lgt_contain1.XML_DRUG_CONTAIN.CONRAIN = ""
                lgt_contain1.XML_DRUG_CONTAIN.STATUS_CONRAIN = ""
                lgt_contain1.XML_DRUG_CONTAIN.updateDate = Date.Now
                lgt_contain1.XML_DRUG_CONTAIN.cncdate = Date.Now
                lgt_contain1.XML_DRUG_CONTAIN.Newcode = ""
                lgt_contain1.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = 0
                'p2.LGT_XML_DRUG_CONTAIN.Add(lgt_contain1)
                'Next
            End If
            'p2.LGT_XML_DRUG_CONTAIN = dao_contain.datas
        End If
#End Region

#Region "วิธีเตรียมก่อนรับประทาน"
        If dao_c.fields.PREPARE_EAT_ID = True Then
            p2.XML_SEARCH_DRUG_DR.PREPARE_EAT = dao_d.fields.EATTING_NAME
        End If
#End Region

#Region "เงื่อนไขการรับประทาน"
        If dao_c.fields.EAT_CONDITION_ID = True Then
            p2.XML_SEARCH_DRUG_DR.EAT_CONDITION = dao_d.fields.EATING_CONDITION_NAME
        End If
#End Region

#Region "การเก็บรักษา/อายุการเก็บรักษา"
        If dao_c.fields.STORAGE_ID = True Then
            p2.XML_SEARCH_DRUG_DR.STORAGE = dao_d.fields.STORAGE_NAME
        End If
#End Region

#Region "ภาชนะและขนาดบรรจุ"

        'If dao_c.fields.CONTAINER_PACKING_ID = True Then
        '    'dao_d.fields.SIZE_PACK = txt_SizePack_New.Te
        '    Dim dao_contain As New DAO_XML_DRUG_HERB.TB_XML_DRUG_CONTAIN_HERB
        '    dao_contain.GetDataby_Newcode(NEWCODE)
        '    If dao_contain.Details.Count <> 0 Then

        '        For Each dao_contain.fields In dao_contain.datas
        '            Dim lgt_contain As New LGT_XML_DRUG_CONTAIN

        '            If IsNothing(dao_contain.fields.IDA) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.IDA = dao_contain.fields.IDA
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.IDA = 0
        '            End If
        '            If IsNothing(dao_contain.fields.pvncd) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.pvncd = dao_contain.fields.pvncd
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.pvncd = ""
        '            End If
        '            If IsNothing(dao_contain.fields.drgtpcd) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.drgtpcd = dao_contain.fields.drgtpcd
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.drgtpcd = ""
        '            End If
        '            If IsNothing(dao_contain.fields.rgttpcd) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.rgttpcd = dao_contain.fields.rgttpcd
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.rgttpcd = ""
        '            End If
        '            If IsNothing(dao_contain.fields.rgtno) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.rgtno = dao_contain.fields.rgtno
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.rgtno = ""
        '            End If
        '            If IsNothing(dao_contain.fields.lcnno) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.lcnno = dao_contain.fields.lcnno
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.lcnno = ""
        '            End If
        '            If IsNothing(dao_contain.fields.rid) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.rid = dao_contain.fields.rid
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.rid = ""
        '            End If
        '            If IsNothing(dao_contain.fields.SUBTITLE_SIZE_DRUG) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = dao_d.fields.SIZE_PACK
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = ""
        '            End If
        '            If IsNothing(dao_contain.fields.SMALL_AMOUNT) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.SMALL_AMOUNT = dao_contain.fields.SMALL_AMOUNT
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.SMALL_AMOUNT = 0.0
        '            End If
        '            If IsNothing(dao_contain.fields.SMALL_UNIT) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.SMALL_UNIT = dao_contain.fields.SMALL_UNIT
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.SMALL_UNIT = ""
        '            End If
        '            If IsNothing(dao_contain.fields.BIG_UNIT) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.BIG_UNIT = dao_contain.fields.BIG_UNIT
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.BIG_UNIT = ""
        '            End If
        '            If IsNothing(dao_contain.fields.BIG_AMOUNT) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.BIG_AMOUNT = dao_contain.fields.BIG_AMOUNT
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.BIG_AMOUNT = 0.0
        '            End If
        '            If IsNothing(dao_contain.fields.MEDIUM_AMOUNT) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = dao_contain.fields.MEDIUM_AMOUNT
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = 0.0
        '            End If
        '            If IsNothing(dao_contain.fields.MEDIUM_UNIT) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.MEDIUM_UNIT = dao_contain.fields.MEDIUM_UNIT
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.MEDIUM_UNIT = ""
        '            End If
        '            If IsNothing(dao_contain.fields.BARCODE) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.BARCODE = dao_contain.fields.BARCODE
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.BARCODE = ""
        '            End If
        '            If IsNothing(dao_contain.fields.SUM) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.SUM = dao_contain.fields.SUM
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.SUM = ""
        '            End If

        '            If IsNothing(dao_contain.fields.CONRAIN) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.CONRAIN = dao_contain.fields.CONRAIN
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.CONRAIN = ""
        '            End If
        '            If IsNothing(dao_contain.fields.STATUS_CONRAIN) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.STATUS_CONRAIN = dao_contain.fields.STATUS_CONRAIN
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.STATUS_CONRAIN = ""
        '            End If
        '            If IsNothing(dao_contain.fields.updateDate) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.updateDate = dao_contain.fields.updateDate
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.updateDate = Date.Now
        '            End If
        '            If IsNothing(dao_contain.fields.cncdate) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.cncdate = dao_contain.fields.cncdate
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.cncdate = Date.Now
        '            End If
        '            If IsNothing(dao_contain.fields.Newcode) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.Newcode = dao_contain.fields.Newcode
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.Newcode = ""
        '            End If
        '            If IsNothing(dao_contain.fields.IDA_DRRGT_PACKAGE_DETAIL) = False Then
        '                lgt_contain.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = dao_contain.fields.IDA_DRRGT_PACKAGE_DETAIL
        '            Else
        '                lgt_contain.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = 0
        '            End If
        '            p2.LGT_XML_DRUG_CONTAIN.Add(lgt_contain)
        '        Next
        '    Else

        '        'For Each dao_export.fields In dao_export.Details
        '        Dim lgt_contain1 As New LGT_XML_DRUG_CONTAIN
        '        lgt_contain1.XML_DRUG_CONTAIN.IDA = 0
        '        lgt_contain1.XML_DRUG_CONTAIN.pvncd = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.drgtpcd = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.rgttpcd = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.pvncd = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.rgtno = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.rid = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.SMALL_AMOUNT = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.SMALL_UNIT = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.BIG_UNIT = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.BIG_AMOUNT = 0
        '        lgt_contain1.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.MEDIUM_UNIT = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.BARCODE = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.SUM = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.CONRAIN = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.STATUS_CONRAIN = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.updateDate = Date.Now
        '        lgt_contain1.XML_DRUG_CONTAIN.cncdate = Date.Now
        '        lgt_contain1.XML_DRUG_CONTAIN.Newcode = ""
        '        lgt_contain1.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = 0
        '        p2.LGT_XML_DRUG_CONTAIN.Add(lgt_contain1)
        '        'Next
        '    End If
        '    'p2.LGT_XML_DRUG_CONTAIN = dao_contain.datas
        'End If
#End Region

#Region "วิธีควบคุมคุณภาพและข้อกำหนดเฉพาะของผลิตภัณฑ์สมุนไพร"
        If dao_c.fields.QUALITY_CONTROL_ID = True Then

        End If
#End Region

#Region "ฉลาก"

        If dao_c.fields.ETIQUETQ_ID = True Then

        End If
#End Region

#Region "ช่องทางการจำหน่าย"
        Dim SALE_CHANNEL As String = dao_d.fields.SALE_CHANNEL_NAME
        If dao_c.fields.CHANNEL_SALE_ID = True Then
            If Not String.IsNullOrEmpty(dao_d.fields.SALE_CHANNEL_NAME) AndAlso dao_d.fields.SALE_CHANNEL_NAME <> "-- กรุณาเลือก --" Then
                p2.XML_SEARCH_DRUG_DR.sale_channel = dao_d.fields.SALE_CHANNEL_NAME
                dao_h.fields.sale_channel = dao_d.fields.SALE_CHANNEL_NAME
            End If
        ElseIf Not String.IsNullOrEmpty(dao_d.fields.SALE_CHANNEL_NAME) AndAlso dao_d.fields.SALE_CHANNEL_NAME <> "-- กรุณาเลือก --" Then
            p2.XML_SEARCH_DRUG_DR.sale_channel = dao_d.fields.SALE_CHANNEL_NAME
            dao_h.fields.sale_channel = dao_d.fields.SALE_CHANNEL_NAME
        End If
#End Region

#Region "ชนิดยา"
        If Not String.IsNullOrEmpty(dao_d.fields.TYPE_SUB_NAME) AndAlso dao_d.fields.TYPE_SUB_NAME <> "-- กรุณาเลือก --" Then
            p2.XML_SEARCH_DRUG_DR.thakindnm = dao_d.fields.TYPE_SUB_NAME
            dao_h.fields.thakindnm = dao_d.fields.TYPE_SUB_NAME
        End If
        'If dao_d.fields.TYPE_SUB_NAME <> "" Or dao_d.fields.TYPE_SUB_NAME <> "-- กรุณาเลือก --" Then
        '    p2.XML_SEARCH_DRUG_DR.thakindnm = dao_d.fields.TYPE_SUB_NAME
        '    dao_h.fields.thakindnm = dao_d.fields.TYPE_SUB_NAME
        'End If
#End Region

        If dao_c.fields.OTHER_ID = True Then
            If dao_c.fields.Sub_Other_thanm = True Then
                dao_h.fields.holder_name = dao_d.fields.holder_name
                dao_h.fields.CITIZEN_AUTHORIZE = dao_d.fields.Holder_Iden
                dao_h.fields.Identify = dao_d.fields.Holder_Iden
                dao_h.fields.addr_who = dao_d.fields.addr_who
                dao_h.fields.holder_name = dao_d.fields.licen_addr
            End If
            If dao_c.fields.Sub_Other_thanm = True Then
                dao_h.fields.Newcode_not = dao_d.fields.Newcode_Not
                dao_h.fields.licen_loca = dao_d.fields.licen_nm
                dao_h.fields.fulladdr = dao_d.fields.licen_addr
                dao_h.fields.thanm_locaion = dao_d.fields.licen_thanm
                'dao_h.fields.Newcode_not = dao_d.fields.licen_no_new
                dao_h.fields.lcnno = dao_d.fields.licen_lcnno
                dao_h.fields.lcnno_no = dao_d.fields.licen_lcnno_no
                dao_h.fields.lcntpcd = dao_d.fields.licen_lcntpcd
                dao_h.fields.lpvncd = dao_d.fields.licen_lpvncd

                p2.XML_SEARCH_DRUG_DR.Newcode_not = dao_d.fields.Newcode_Not
                p2.XML_SEARCH_DRUG_DR.licen_loca = dao_d.fields.licen_nm
                p2.XML_SEARCH_DRUG_DR.fulladdr = dao_d.fields.licen_addr
                p2.XML_SEARCH_DRUG_DR.thanm_locaion = dao_d.fields.licen_thanm
                p2.XML_SEARCH_DRUG_DR.lcnno = dao_d.fields.licen_lcnno
                p2.XML_SEARCH_DRUG_DR.lcnno_no = dao_d.fields.licen_lcnno_no
                p2.XML_SEARCH_DRUG_DR.lcntpcd = dao_d.fields.licen_lcntpcd
                p2.XML_SEARCH_DRUG_DR.lpvncd = dao_d.fields.licen_lpvncd
            End If
            'Dim dao_licen As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            'dao_licen.GetDataby_LCN_IDA(dao_d.fields.IDA_LCN)
            'Dim dao_licen_loca As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
            'dao_licen_loca.GetDataby_LCN_IDA(dao_d.fields.IDA_LCN)
            'dao_licen.fields.licen = dao_d.fields.licen_nm
            'dao_licen_loca.fields.licen = dao_d.fields.licen_nm
            'dao_licen.fields.CITIZEN_AUTHORIZE = dao_d.fields.licen_Iden
            'dao_licen_loca.fields.CITIZEN_AUTHORIZE = dao_d.fields.licen_Iden
            'dao_licen.update()
            'dao_licen_loca.update()
        End If

        dao_h.update()
        SEND_XML(p2)

        'Dim ws_update As New WS_DRUG.WS_DRUG
        '
        Dim pvncd As String = dao_g.fields.pvncd
        Dim rgttpcd As String = dao_g.fields.rgttpcd
        Dim drgtpcd As String = dao_g.fields.drgtpcd
        Dim rgtno As String = dao_g.fields.rgtno
        Dim remark As String = "อัพเดพข้อมูลผ่านระบบแก้ไขดปลี่ยนแปลง ทบ3"
        Dim iden_edit As String = _CLS.CITIZEN_ID_AUTHORIZE
        Dim system As String = "HERB"

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.XML_DRUG_BC_UPDATE_TB(NEWCODE_U, _CLS.CITIZEN_ID_AUTHORIZE) 'อัพเดทข้อมูลผ่าน sevice
        Dim bao As New BAO.ClsDBSqlcommand
        If dao_c.fields.OTHER_ID = True Then bao.SP_UPDATE_LOCATION_NAME_PRODUCT_HERB(pvncd, rgttpcd, drgtpcd, rgtno)

        'ws_drug.HERB_UPDATE_DR(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)

    End Sub
    Public Sub SEND_XML(ByVal OB As Object)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        'Dim dao_log As New DAO_DRUG.TB_TESTANGULAR_LOG
        'dao_log.fields.STATUS_ID = 8
        'dao_log.fields.PROCESS_ID = CInt(model.process_id)
        'dao_log.fields.TR_ID = model.Newcode
        'dao_log.fields.TIME = Date.Now
        Try

            Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
            ws_fields.PROCESS_ID = dao.fields.PROCESS_ID 'เลขกระบวนการ
            ws_fields.TR_ID = NEWCODE_U 'dao.fields.TR_ID 'เลขTRANSATION
            ws_fields.REF_TR_ID = NEWCODE_U 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
            ws_fields.IDENTIFY = _CLS.CITIZEN_ID 'เลขนิติบุคคล
            ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
            ws_fields.SOP_STATUS = dao.fields.STATUS_ID 'สถานะคำขอนะ
            ws_fields.SYSTEM_ID = "HERB" 'เลขสารระบบ
            ws_fields.SOP_REMARK = dao.fields.REMARK 'ความเห็น จนทที่พิมพ์มา
            ws_fields.XML_DATA = CLASSTOXMLSTR(OB) 'classxml ข้อมูล
            Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
            ws_blockchain.WS_BLOCK_CHAIN_V3(ws_fields)
            dao.fields.REMARK = "ส่งxmlไปเก็บที่svสำเร็จ"
        Catch ex As Exception
            'dao_log.fields.REMARK = ex.ToString
        End Try
        'dao_log.insert()
    End Sub
    Public Function CLASSTOXMLSTR(ByVal cls_rev As Object) 'เอา class มารับ class ที่ส่งเข้ามา
        Dim x2 As New XmlSerializer(cls_rev.GetType())
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim mem2 As New MemoryStream()
        Using writer As XmlWriter = XmlWriter.Create(mem2, settings)
            x2.Serialize(writer, cls_rev)
            writer.Flush()
            writer.Close()
        End Using
        Dim B64 As String = ""
        B64 = Convert.ToBase64String(mem2.GetBuffer())
        Return B64
    End Function
    Sub alert_nature(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Sub alert_summit(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = 9 Or DD_STATUS.SelectedValue = 7 Or DD_STATUS.SelectedValue = 10 Or DD_STATUS.SelectedValue = 5 Or DD_STATUS.SelectedValue = 78 Then
            p2.Visible = True
            P12.Visible = False
        Else
            p2.Visible = False
            P12.Visible = True
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, 1, _Process_ID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW_EDIT/FRM_HERB_TABEAN_NEW_EDIT_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub

    Protected Sub DD_OTHER_REQUEST_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OTHER_REQUEST.SelectedIndexChanged
        If DD_OTHER_REQUEST.SelectedValue = "-" Then
            Div_DayOrtherRequest.Visible = False
        Else
            Div_DayOrtherRequest.Visible = True
        End If
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("POPUP_TABEAN_NEW_EDIT_STAFF_CANCEL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&PROCESS_ID=" & _Process_ID)
    End Sub
    Protected Sub btn_dbd_Click(sender As Object, e As EventArgs) Handles btn_dbd.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim IDENTIFY As String = _CLS.CITIZEN_ID
        Dim COMPANY_INDENTIFY As String = dao.fields.CITIZEN_ID_AUTHORIZE
        Dim TOKEN As String = _CLS.TOKEN
        Dim TR_ID As String = "" 'รอพี่บิ๊กกำหนดชื่อตัวแปรอีกที
        Dim ORG As String = "HERB"
        TR_ID = "HB-" & _Process_ID & "-" & dao.fields.DATE_YEAR & "-" & _TR_ID
        Dim URL As String = DBD_LINK(IDENTIFY, COMPANY_INDENTIFY, TR_ID, TOKEN)
        'Response.Redirect(URL)
        Response.Write("<script language='javascript'>window.open('" & URL & "','_blank','');")
        Response.Write("</script>")
    End Sub

    Protected Sub btn_Closed_Click(sender As Object, e As EventArgs) Handles btn_Closed.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class

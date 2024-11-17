Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class POPUP_TABEAN_NEW_EDIT_STAFF_INTAKE
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _Process_ID As String
    Private _IDA_LCN As String
    Private _IDA_DR As String

    Sub RunSession()
        _Process_ID = Request.QueryString("process_id")
        _IDA = Request.QueryString("IDA")
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
            bind_data()
            bind_dd()
            bind_mas_staff()
            bind_mas_cancel()
            BIND_PDF_TABEAN()
            Bind_PRICE_ESTIMATE_REQUEST()
            Bind_DD_Discount()

            UC_ATTACH1.NAME = "เอกสารแนบยกเลิกคำขอ"
            UC_ATTACH1.BindData("เอกสารแนบยกเลิกคำขอ", 1, "pdf", "0", "77")

            UC_ATTACH2.NAME = "เอกสาร ทบ.3"
            UC_ATTACH2.BindData("เอกสาร ทบ.3", 1, "pdf", "0", "14")
        End If
    End Sub
    Public Sub Bind_PRICE_ESTIMATE_REQUEST()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_PRICE_ESTIMATE_REQUEST(_Process_ID)

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
    Public Sub bind_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        'If dao.fields.STATUS_ID = 6 Then
        '    KEEP_PAY.Visible = False
        '    btn_sumit.Visible = False
        '    btn_keep_pay.Visible = True
        'Else
        If dao.fields.STATUS_ID = 3 Or dao.fields.STATUS_ID = 18 Then
            Div_Process.Visible = True
            KEEP_PAY.Visible = True
            btn_sumit.Visible = True
            btn_keep_pay.Visible = False
        Else
            KEEP_PAY.Visible = True
            btn_sumit.Visible = True
            btn_keep_pay.Visible = False
        End If
        DATE_REQ.Text = Date.Now.ToString("dd/MM/yyyy")
        lbl_create_by.Text = dao.fields.CREATE_BY
        txt_remark_edit.Text = dao.fields.Reason_Staff
        RDP_CANCEL_DATE.SelectedDate = Date.Now
        Try
            lbl_create_date.Text = dao.fields.CREATE_DATE
        Catch ex As Exception

        End Try
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

        lr_preview.Text = "<iframe id='iframe1'  style='height:1500px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
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
        If status_id1 = 3 Or status_id1 = 18 Then
            int_group_ddl1 = 2
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
        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        If dao.fields.STATUS_ID = 12 Then
            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกสถานะ หรือเจ้าหน้าที่รับผิดชอบ');", True)
            ElseIf DD_ESTIMATE_PAY.SelectedValue = 0 Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ค่าประเมินเอกสารทางวิชาการ');", True)
            Else
                '_Process_ID = DD_PROCESS_ID.SelectedValue
                dao.fields.rcv_StaffID = DD_OFF_REQ.SelectedValue
                dao.fields.rcv_StaffName = DD_OFF_REQ.SelectedItem.Text
                dao.fields.rcvdate = Date.Now
                dao.fields.Reason_Staff = txt_remark_edit.Text
                If txt_remark_edit.Text <> "" Then
                    dao.fields.Update_reason = DateTime.Now
                End If
                If dao.fields.RCVNO_NEW = "" Then

                    Dim bao As New BAO.GenNumber
                    Dim RCVNO As String = ""
                    Dim RCVNO_HERB_NEW As String = ""
                    'Dim pvncd As String = dao.fields.pvncd
                    Dim pvncd As String = 10

                    RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), pvncd, _Process_ID, _IDA)
                    Dim TR_ID As String = dao.fields.TR_ID
                    Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
                    RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, _Process_ID, _IDA)
                    Dim RCVNO_FULL As String = "HB" & " " & pvncd & "-" & _Process_ID & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
                    dao.fields.RCVNO_NEW = RCVNO_FULL
                    dao.fields.rcvno = RCVNO
                End If
                Try
                    dao.fields.REQUEST_LEVEL = DD_PROCESS_ID.SelectedItem.Text
                    dao.fields.REQUEST_LEVEL_ID = DD_PROCESS_ID.SelectedValue
                Catch ex As Exception

                End Try
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
            End If
            dao.Update()
            AddLogStatus(dao.fields.STATUS_ID, _Process_ID, _CLS.CITIZEN_ID, _IDA)

            Dim bao_tn As New BAO_TABEAN_HERB.tb_dd
            bao_tn.SP_INSERT_DRUG_PAYMENT_CENTER_L44(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.IDA, dao.fields.PROCESS_ID)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        ElseIf dao.fields.STATUS_ID = 11 Or dao.fields.STATUS_ID = 16 Then
            Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
            dao_up_mas.GetdatabyID_TYPE(22)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.TR_ID = Request.QueryString("TR_ID")
                dao_up.fields.PROCESS_ID = _Process_ID
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.FK_IDA_LCN = Request.QueryString("IDA_LCN")
                dao_up.fields.TYPE = 22
                dao_up.insert()
            Next
            If dao.fields.STATUS_ID = 11 Then
                dao.fields.EDIT_RQ_ID = _CLS.CITIZEN_ID
                dao.fields.EDIT_RQ_NAME = _CLS.THANM
                dao.fields.EDIT_RQ_DATE = Date.Now
            Else
                dao.fields.EDIT_RQ2_ID = _CLS.CITIZEN_ID
                dao.fields.EDIT_RQ2_NAME = _CLS.THANM
                dao.fields.EDIT_RQ2_DATE = Date.Now
            End If
            dao.Update()
            AddLogStatus(dao.fields.STATUS_ID, _Process_ID, _CLS.CITIZEN_ID, _IDA)
            Dim bao_tn As New BAO_TABEAN_HERB.tb_dd
            bao_tn.SP_INSERT_DRUG_PAYMENT_CENTER_L44(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.IDA, dao.fields.PROCESS_ID)
            Response.Redirect("POPUP_TABEAN_NEW_EDIT_STAFF_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & dao.fields.TR_ID & "&process_id=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN)
        ElseIf dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 10 Or dao.fields.STATUS_ID = 78 Then
            If DDL_CANCLE_REMARK.SelectedValue = "-- กรุณาเลือก --" Then
                lbl_chk_ddlcc.Visible = True
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก);", True)
            Else
                lbl_chk_ddlcc.Visible = True
                dao.fields.NOTE_CANCEL = NOTE_CANCLE.Text
                Try
                    dao.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                    dao.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
                    dao.fields.cancel_date = RDP_CANCEL_DATE.SelectedDate
                    dao.fields.cancel_iden = _CLS.CITIZEN_ID
                Catch ex As Exception

                End Try
                UC_ATTACH1.insert_TBN_Edit(_TR_ID, _Process_ID, dao.fields.IDA, 77)
                dao.Update()
                AddLogStatus(dao.fields.STATUS_ID, _Process_ID, _CLS.CITIZEN_ID, _IDA)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            End If
        End If

    End Sub
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
            Div_Process.Visible = False
        ElseIf DD_STATUS.SelectedValue = 11 Or DD_STATUS.SelectedValue = 16 Then
            p2.Visible = False
            P12.Visible = True
            Div_Process.Visible = False
        Else
            p2.Visible = False
            P12.Visible = True
            Div_Process.Visible = True
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
    Protected Sub DD_ESTIMATE_PAY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ESTIMATE_PAY.SelectedIndexChanged
        If DD_ESTIMATE_PAY.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ค่าประเมินเอกสารทางวิชาการ');", True)
        Else
            Dim ML_PAY As Double = 0
            ML_PAY = SUM_Discount(_Process_ID)
            TXT_BATH.Text = ML_PAY
        End If
    End Sub
    Protected Sub DD_DISCOUNT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_DISCOUNT.SelectedIndexChanged
        If DD_ESTIMATE_PAY.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ค่าประเมินเอกสารทางวิชาการ');", True)
        Else
            Dim ML_PAY As Double = 0
            ML_PAY = SUM_Discount(_Process_ID)
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

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("POPUP_TABEAN_NEW_EDIT_STAFF_CANCEL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&PROCESS_ID=" & _Process_ID)
    End Sub
    Protected Sub btn_upload_file_Click(sender As Object, e As EventArgs) Handles btn_upload_file.Click
        Response.Redirect("POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _Process_ID)
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
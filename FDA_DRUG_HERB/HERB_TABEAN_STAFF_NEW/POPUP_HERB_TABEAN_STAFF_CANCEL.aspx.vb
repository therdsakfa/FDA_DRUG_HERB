Imports Telerik.Web.UI
Public Class POPUP_HERB_TABEAN_STAFF_CANCEL
        Inherits System.Web.UI.Page
        Private _CLS As New CLS_SESSION
        Private _IDA As String
        Private _TR_ID As String
        Private _ProcessID As String
        Private _STATUS_ID As String
        Private _IDA_LCN As String
        Private _TR_ID_LCN As String
        Private _IDA_LCT As String
        Private _DD_HERB_NAME_ID As String
        Private _PROCESS_ID_LCN As String
        Private _MENU_GROUP As String

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _STATUS_ID = Request.QueryString("STATUS_ID")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            RunSession()
            If Not IsPostBack Then
                'Run_Pdf_Tabean_Herb()
                set_txt()
            bind_mas_cancel()
            UC_ATTACH1.NAME = "เอกสารแนบประกอบการยกเลิกคำขอ"
            UC_ATTACH1.BindData("เอกสารแนบประกอบการยกเลิกคำขอ", 1, "pdf", "0", "78")
        End If
        End Sub
        Sub set_txt()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        txt_cancel_date.Text = Date.Now.ToString("dd'/'MM'/'yyyy")
        End Sub
        Public Sub bind_mas_cancel()
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_dd
            dt = bao.SP_MAS_STATUS_CANCEL_TABEAN_HERB(3)
        'dt = bao.SP_MAS_DDL_SECTION_CANCEL()
        DD_CANCEL.DataSource = dt
            DD_CANCEL.DataValueField = "ID"
            DD_CANCEL.DataTextField = "STATUS_CAUSE"
            DD_CANCEL.DataBind()
        'DD_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")
        Dim item As New RadComboBoxItem
            item.Text = "--กรุณาเลือกรายการ--"
            item.Value = "0"
            DD_CANCEL.Items.Insert(0, item)
        End Sub
    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim message As String = "กรุณากรอกข้อมูลให้ครบ"
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim dao_q As New DAO_DRUG.ClsDBdrrqt
        dao_q.GetDataby_IDA(_IDA)
        If _TR_ID IsNot Nothing Then _TR_ID = dao_q.fields.TR_ID
        If DD_CANCEL.SelectedValue = 0 Then
            message = "โปรดเลือกเหตุผลในการยกเลิก"
            ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
        Else
            dao.fields.STATUS_ID = _STATUS_ID
            dao.fields.cancel_by = _CLS.THANM
            dao.fields.cancel_date = Date.Now
            dao.fields.cancel_iden = _CLS.CITIZEN_ID
            dao.fields.DD_CANCEL_ID = DD_CANCEL.SelectedValue
            dao.fields.DD_CANCEL_NM = DD_CANCEL.SelectedItem.Text
            dao.fields.NOTE_CANCEL = txt_cencel_note.Text
            dao.Update()
            dao_q.fields.STATUS_ID = _STATUS_ID
            dao_q.fields.REMARK = txt_cencel_note.Text
            dao_q.update()
            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            If UC_ATTACH1.CHK_TBN() = True Then UC_ATTACH1.insert_TBN(_TR_ID, _ProcessID, _IDA, 78)
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, dao.fields.STATUS_ID)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        End If
    End Sub
End Class
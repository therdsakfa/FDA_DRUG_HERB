Imports Telerik.Web.UI
Public Class POPUP_TABEAN_HERB_TEMPOLARY_CONFIRM
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")

        Try
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
            BIND_DATA()
            bind_dd_price()
            bind_dd()
            bind_mas_staff()

            UC_ATTACH2.NAME = "เอกสารแนบ"
            UC_ATTACH2.BindData("เอกสารแนบ", 1, "pdf", "0", "8")
        End If
    End Sub
    Public Sub BIND_DATA()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        dao.GetdatabyID_IDA(_IDA)
        txt_date_confirm.Text = dao.fields.Date_Confirm
        txt_email.Text = dao.fields.E_mail
        txt_phone.Text = dao.fields.Phone
        txt_ML_PAY.Text = dao.fields.ML_PAY
        TXT_SEARCH_TN.Text = dao.fields.IDEN_Confirm
        txt_name_request.Text = dao.fields.Name_Confirm
        TXT_SEARCH_TN2.Text = dao.fields.Contact_Person_Identify
        txt_name_contact.Text = dao.fields.Contact_Person
        Try
            DD_PRICE_REQUEST.SelectedValue = dao.fields.Will_RequestID
        Catch ex As Exception

        End Try
        If DD_PRICE_REQUEST.SelectedValue = 11 Or DD_PRICE_REQUEST.SelectedValue = 12 _
            Or DD_PRICE_REQUEST.SelectedValue = 13 Then
            NumberPage.Visible = True
            txt_numbre_page.Text = dao.fields.Number_Pages
        End If
        ROVNO_FULL.Text = dao.fields.RCVNO_FULL
        DATE_REQ.Text = Date.Now
        If dao.fields.STATUS_ID = 8 Then
            KEEP_PAY.Visible = False
        End If
        Dim dao2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao2.GetdatabyID_TR_ID_PROCESS_ID(dao.fields.TR_ID, _ProcessID)
        Dim status_upload8 As Integer = dao2.fields.TYPE
        If status_upload8 = 8 Then
            uc_upload1.Visible = False
            uc_upload1_btn.Visible = False
            uc_upload1_radgrid.Visible = True
            RadGrid4.DataBind()
        End If
    End Sub
    Public Sub bind_dd_price()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_PRICE_TABEAN_EDIT_TEMPOLARY()

        DD_PRICE_REQUEST.DataSource = dt
        DD_PRICE_REQUEST.DataValueField = "ID"
        DD_PRICE_REQUEST.DataTextField = "Expense_Name"
        DD_PRICE_REQUEST.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-"
        item.Value = 0
        DD_PRICE_REQUEST.Items.Insert(0, item)

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
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        dao.GetdatabyID_IDA(_IDA)

        status_id1 = dao.fields.STATUS_ID
        If status_id1 = 3 Then
            int_group_ddl1 = 1
            int_group_ddl2 = 0
        End If
        dt = Get_DDL_DATA(419, int_group_ddl1, int_group_ddl2)

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
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        dao.GetdatabyID_IDA(_IDA)
        dao.fields.STATUS_ID = DD_STATUS.SelectedValue

        If dao.fields.STATUS_ID = 3 Then
        ElseIf dao.fields.STATUS_ID = 8 Then
            dao.fields.Staff_ID = DD_OFF_REQ.SelectedValue
            dao.fields.Staff_Name = DD_OFF_REQ.SelectedItem.Text
            dao.fields.Staff_App_Date = Date.Now
        ElseIf dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 10 Then

        End If
        dao.Update()
        AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub
    Protected Sub btn_savefileApprove_2_Click(sender As Object, e As EventArgs) Handles btn_savefileApprove_2.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        dao.GetdatabyID_IDA(_IDA)
        If UC_ATTACH2.CHK_TBN = False Then
            alert_nature("กรุณาแนบไฟล์ เอกสาร ที่อนุมัติแล้ว")
        ElseIf UC_ATTACH2.CHK_TBN = False Then
            alert_nature("กรุณาแนบไฟล์ เอกสาร ที่อนุมัติแล้ว")
        Else
            UC_ATTACH2.insert_TBNTEMPO(dao.fields.TR_ID, _ProcessID, _IDA, 8)
            alert_summit("อัพโหลดเอกสารแนบ เรียบร้อย")
        End If

        uc_upload1.Visible = False
        uc_upload1_btn.Visible = False
        uc_upload1_radgrid.Visible = True
        RadGrid4.Rebind()
    End Sub
    Sub alert_nature(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Sub alert_summit(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Function bind_data_uploadfile_8()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        dao.GetdatabyID_IDA(_IDA)
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, 8, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_8()
    End Sub

    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_TABEAN_HERB_TEMPOLARY_PREVIEW.aspx?ida=" & IDA

        End If
    End Sub
End Class
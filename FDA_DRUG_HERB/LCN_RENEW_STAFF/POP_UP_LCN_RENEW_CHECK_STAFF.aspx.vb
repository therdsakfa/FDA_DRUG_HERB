Imports Telerik.Web.UI
Public Class POP_UP_LCN_RENEW_CHECK_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As Integer
    Private _IDA As Integer
    Private _IDEN As String
    Private _PROCESS_ID As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _IDA_LCN = Request.QueryString("IDA_LCN")
            _IDEN = Request.QueryString("IDENTIFY")
            _PROCESS_ID = Request.QueryString("PROCESS_ID")
            _IDA = Request.QueryString("IDA")
            _IDEN = Request.QueryString("IDENTIFY")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_status()
            bind_mas_staff()
            Getdata()
        End If
    End Sub
    Sub Getdata()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        If dao.fields.STATUS_ID = 8 Then
            DD_STATUS.SelectedValue = dao.fields.STATUS_ID
            DD_STATUS.Enabled = False
            DD_OFF_REQ.SelectedValue = dao.fields.Completed_StaffID
            DD_OFF_REQ.Enabled = False
            Try
                DATE_REQ.Text = dao.fields.Completed_date
            Catch ex As Exception
                'DATE_REQ.Text = dao.fields.DATE_CONFIRM
            End Try
            DATE_REQ.ReadOnly = False
            DATE_REQ.Enabled = False
            btn_sumit.Enabled = False
            btn_sumit.CssClass = "btn-danger btn-lg"
            btn_edit.Enabled = False
            btn_edit.CssClass = "btn-danger btn-lg"
        ElseIf dao.fields.STATUS_ID = 4 Then
            btn_edit.Enabled = False
            btn_edit.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 5 Then
            DD_STATUS.SelectedValue = dao.fields.STATUS_ID
            DD_STATUS.Enabled = False
            DD_OFF_REQ.SelectedValue = dao.fields.Completed_StaffID
            DD_OFF_REQ.Enabled = False
            Try
                DATE_REQ.Text = dao.fields.Completed_date
            Catch ex As Exception
                'DATE_REQ.Text = dao.fields.DATE_CONFIRM
            End Try
            DATE_REQ.ReadOnly = False
            DATE_REQ.Enabled = False
            btn_sumit.Enabled = False
            'btn_sumit.CssClass = "btn-danger btn-lg"
            btn_edit.Enabled = False
            'btn_edit.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Public Sub bind_status()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim ss_id As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        If dao.fields.STATUS_ID = 2 Or dao.fields.STATUS_ID = 4 Or dao.fields.STATUS_ID = 51 Then
            ss_id = 1
        End If
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(10511, ss_id)
        dt = bao.dt

        DD_STATUS.DataSource = dt
        DD_STATUS.DataValueField = "STATUS_ID"
        DD_STATUS.DataTextField = "STATUS_NAME_STAFF"
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")
        DATE_REQ.Text = Date.Now

    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        Catch ex As Exception
            STATUS_UPLOAD_ID = 1
        End Try
        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _PROCESS_ID, STATUS_UPLOAD_ID)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_fileAtt.NeedDataSource
        rg_fileAtt.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_fileAtt.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = DD_STATUS.SelectedValue
        Dim ddl_id As Integer = 0
        Dim TR_ID As Integer = 0
        Dim ddl_name As String = ""
        dao.GET_DATA_BY_IDA(_IDA)
        TR_ID = dao.fields.TR_ID
        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        If dao.fields.STATUS_ID = 8 Then
            dao.fields.Completed_date = DATE_REQ.Text
            dao.fields.Completed_StaffNM = DD_OFF_REQ.SelectedItem.Text
            dao.fields.Completed_StaffID = DD_OFF_REQ.SelectedValue
        ElseIf dao.fields.STATUS_ID = 3 Then
            dao.fields.Send_EditDate = DATE_REQ.Text
            dao.fields.Note_Edit_Staff = ""
            dao.fields.SendEditStaffNM = DD_OFF_REQ.SelectedItem.Text
            dao.fields.SendEditStaffID = DD_OFF_REQ.SelectedValue
            dao.update()
            Dim dao_u As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_u.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(TR_ID, _PROCESS_ID, 2)
            For Each dao_u.fields In dao_u.datas
                dao_u.fields.Active = False
                dao_u.update()
            Next
            dao_u.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(TR_ID, _PROCESS_ID, 3)
            dao_u.fields.Active = False
            dao_u.update()
            AddLogStatus(dao.fields.STATUS_ID, _PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
            Response.Redirect("POP_UP_LCN_RENEW_CHECK_STAFF_EDIT_FILE.aspx?IDA=" & _IDA & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&TR_ID=" & dao.fields.TR_ID & "&IDENTIFY=" & _IDEN)
        End If
        dao.update()
        AddLogStatus_lcn(STATUS_ID, _PROCESS_ID, _CLS.CITIZEN_ID, _IDA, ddl_id, ddl_name)
        alert("อัพเดทคำขอแล้ว")
    End Sub
    Function bind_data_uploadfile2()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _PROCESS_ID, 2)
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
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA_LCN)
        Response.Redirect("POP_UP_LCN_RENEW_CHECK_STAFF_EDIT.aspx?IDA=" & _IDA & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & dao.fields.PROCESS_ID & "&IDENTIFY=" & dao.fields.CITIZEN_ID_AUTHORIZE)
    End Sub
End Class
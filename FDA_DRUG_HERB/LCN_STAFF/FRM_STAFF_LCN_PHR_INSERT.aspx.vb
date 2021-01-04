Public Class FRM_STAFF_LCN_PHR_INSERT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            UC_PHR_ADD1.bind_ddl_prefix()
            UC_PHR_ADD1.bind_ddl_job()
            UC_PHR_ADD1.bind_ddl_work_type()
            UC_PHR_ADD1.bind_lcn_type()
            UC_PHR_ADD1.set_data_sakha()

        End If
    End Sub



    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        UC_PHR_ADD1.set_data(dao)
        dao.fields.FK_IDA = Request.QueryString("IDA")
        dao.fields.PHR_STATUS_UPLOAD = 1
        dao.insert()
        'dao_hs.insert()
        Dim List_DALCN As New List(Of DALCN_PHR_TRAINING)
        List_DALCN = Session("Lst_DALCN")
        Dim a As String = ""
        If List_DALCN IsNot Nothing Then
            Dim c_num As Integer = List_DALCN.Count
            For Each item In List_DALCN
                If item.IDA = 0 Then
                    Dim dao_drug As New DAO_DRUG.ClsDBDALCN_PHR_TRAINING
                    dao_drug.fields.NAME_SIMINAR = item.NAME_SIMINAR
                    dao_drug.fields.SIMINAR_DATE = item.SIMINAR_DATE
                    dao_drug.fields.FK_IDA = dao.fields.FK_IDA
                    dao_drug.fields.phr_IDA = dao.fields.PHR_IDA
                    dao_drug.insert()
                Else
                    Dim dao_drug As New DAO_DRUG.ClsDBDALCN_PHR_TRAINING
                    dao_drug.GetDataby_IDA(item.IDA)
                    dao_drug.fields.NAME_SIMINAR = item.NAME_SIMINAR
                    dao_drug.fields.SIMINAR_DATE = item.SIMINAR_DATE
                    dao_drug.fields.FK_IDA = dao.fields.FK_IDA
                    dao_drug.fields.phr_IDA = dao.fields.PHR_IDA
                    dao_drug.update()
                End If
            Next
        ElseIf List_DALCN Is Nothing Then

        End If

        UC_PHR_ADD1.Clear()
        'List_DALCN.Clear()
        'Session.Clear()
        'Session.Abandon()
        'Session.RemoveAll()

        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.HERB_INSERT_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)

        KEEP_LOGS_EDIT(Request.QueryString("ida"), "บันทึกผู้ปฏิบัติการ " & UC_PHR_ADD1.Get_Name_In(), _CLS.CITIZEN_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        UC_PHR_ADD1.Clear()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

End Class
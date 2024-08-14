Imports Telerik.Web.UI
Public Class UC_LABELS_AND_DUCQUMENT
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As String = ""
    Private _IDA As String = ""
    Private IDA_JJ As String = ""

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        _IDA = Request.QueryString("IDA")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        IDA_JJ = Request.QueryString("IDA_JJ")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

    Sub SET_SHOW()
        ID4.Visible = True
    End Sub

    Sub Save_Data(ByVal IDA As Integer)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(IDA)

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If CB1.Checked = True Then
                dao_cb.fields.Label_And_Ducumant = 1
                dao_up_mas.GetdatabyID_TYPE(113)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = dao.fields.TR_ID_JJ
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.PROCESS_ID = dao.fields.DDHERB
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next
            Else
                dao_cb.fields.Label_And_Ducumant = 0
            End If
            dao_cb.Update()
        Else
            dao_cb.fields.FK_IDA = IDA
            If CB1.Checked = True Then
                dao_cb.fields.Label_And_Ducumant = 1
                dao_up_mas.GetdatabyID_TYPE(113)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = dao.fields.TR_ID_JJ
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.PROCESS_ID = dao.fields.DDHERB
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next
            Else
                dao_cb.fields.Label_And_Ducumant = 0
            End If
            dao_cb.insert()
        End If

        dao.fields.SUPPORT_EDIT_ID = 1
        dao.Update()
    End Sub
    Sub Update_Data(ByVal IDA As Integer)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(IDA)

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If CB1.Checked = True Then
                dao_cb.fields.Label_And_Ducumant = 1
                dao_up_mas.GetdatabyID_TYPE(113)
            Else
                dao_cb.fields.Label_And_Ducumant = 0
            End If
            dao_cb.Update()
        Else
            dao_cb.fields.FK_IDA = IDA
            If CB1.Checked = True Then
                dao_cb.fields.Label_And_Ducumant = 1
                dao_up_mas.GetdatabyID_TYPE(113)
            Else
                dao_cb.fields.Label_And_Ducumant = 0
            End If
            dao_cb.insert()
        End If
    End Sub
    Public Function BindTable()

        Dim dao_ed As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao_ed.GetdatabyID_IDA(_IDA)

        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(_IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If dao_cb.fields.Label_And_Ducumant = 1 Then
                CB1.Checked = True
                Sub_CB1.Visible = True
                'SIZE_PACK_NEW.Text = dao_ed.fields.SIZE_PACK
            End If

        End If

        Dim DT As New DataTable
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(Request.QueryString("IDA_JJ"))
        Dim TR_ID_JJ As Integer = 0
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Dim bao As New BAO_TABEAN_HERB.tb_main
        'DT = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_jj.fields.TR_ID_JJ, 1, dao_jj.fields.DDHERB)
        DT = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_EDIT_V2(dao_jj.fields.TR_ID_JJ, 1, dao_jj.fields.DDHERB, IDA_JJ)
        Return DT
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = BindTable()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            'H.NavigateUrl = "../FRM_HERB_TABEAN_JJ_EDIT_PREVIEW.aspx?ida=" & IDA
            H.NavigateUrl = "../../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Protected Sub CB1_CheckedChanged(sender As Object, e As EventArgs) Handles CB1.CheckedChanged
        If CB1.Checked = True Then
            Sub_CB1.Visible = True
            RadGrid1.Rebind()
        Else
            Sub_CB1.Visible = False
        End If
    End Sub
End Class
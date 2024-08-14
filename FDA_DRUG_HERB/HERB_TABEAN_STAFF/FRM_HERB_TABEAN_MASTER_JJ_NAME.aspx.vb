Public Class FRM_HERB_TABEAN_MASTER_JJ_NAME
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _HERB_ID As String = ""
    Private _PROCESS_ID As String = ""
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
        _HERB_ID = Request.QueryString("HERB_ID")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Get_data()
        End If
    End Sub
    Sub Get_data()
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_JJ
        dao.GetdatabyID_HEAD_AND_PROCESS(_HERB_ID, _PROCESS_ID)
        HERB_NAME.Text = dao.fields.HERB_NAME
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_JJ
        dao.GetdatabyID_HEAD_AND_PROCESS(_HERB_ID, _PROCESS_ID)
        If dao.fields.IDA = 0 Then
            Dim dao_seq As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_JJ
            dao_seq.Getdataby_seq(_PROCESS_ID)
            dao.fields.HERB_NAME = HERB_NAME.Text
            dao.fields.HERB_NAME_DD = HERB_NAME.Text
            dao.fields.HERB_ID = dao_seq.fields.SEQ + 1
            dao.fields.SEQ = dao_seq.fields.SEQ + 1
            dao.fields.PROCESS_ID = _PROCESS_ID
            dao.fields.IS_EXPAND = 1
            dao.insert()
        Else
            dao.fields.HERB_NAME = HERB_NAME.Text
            dao.fields.HERB_NAME_DD = HERB_NAME.Text
            dao.Update()
        End If

        'Response.Redirect("FRM_HERB_TABEAN_MASTER_JJ.aspx?PROCESS_JJ=" & _PROCESS_ID)
        Response.Redirect("FRM_HERB_TABEAN_MASTER_JJ.aspx")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'Response.Redirect("FRM_HERB_TABEAN_MASTER_JJ.aspx?PROCESS_JJ=" & _PROCESS_ID)
        Response.Redirect("FRM_HERB_TABEAN_MASTER_JJ.aspx")
    End Sub
End Class
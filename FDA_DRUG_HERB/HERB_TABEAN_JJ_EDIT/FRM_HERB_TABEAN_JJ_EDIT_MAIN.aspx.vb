Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_JJ_EDIT_MAIN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _PROCEESS_ID As String = ""
    Private _SID_ID As String = ""

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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _PROCEESS_ID = Request.QueryString("PROCESS_ID")
        _SID_ID = _CLS.SID_ID
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    Function bind_data()
        Dim _IDA_LCN As Integer = 0
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        DAO_WHO.GetdatabyID_FK_LCN(_IDA_LCN)
        Dim TP_PERSON As Integer = 0
        Try
            TP_PERSON = DAO_WHO.fields.TYPEPERSON
        Catch ex As Exception
            TP_PERSON = 0
        End Try

        If _SID_ID = 2 Then
            dt = bao.SP_XML_TABEAN_JJ_EDIT(_CLS.CITIZEN_ID_AUTHORIZE)
        Else
            dt = bao.SP_XML_TABEAN_JJ_EDIT(_CLS.CITIZEN_ID_AUTHORIZE)
        End If


        Return dt
    End Function

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA_LCN As Integer = item("IDA_LCN").Text
            Dim TR_ID_LCN As String = item("TR_ID_LCN").Text
            Dim IDA_JJ As String = item("IDA").Text
            If e.CommandName = "sel" Then
                Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT.aspx?IDA_JJ=" & IDA_JJ & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID=" & _PROCEESS_ID)
            End If
            RadGrid1.Rebind()

        End If
    End Sub


End Class
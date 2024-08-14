Public Class FRM_HERB_CON
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_Q As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _TR_ID_LCN As String
    Private _IDA_LCT As String
    Private _DD_HERB_NAME_ID As String
    Private _PROCESS_ID_LCN As String
    Private _MENU_GROUP As String
    Private _STAFF_ID As String

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID_DQ")
        _IDA = Request.QueryString("IDA_DQ")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_Q = Request.QueryString("IDA_DQ")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _STAFF_ID = Request.QueryString("staff")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

End Class
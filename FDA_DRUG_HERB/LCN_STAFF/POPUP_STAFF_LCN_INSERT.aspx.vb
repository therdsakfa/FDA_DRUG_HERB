Public Class FRM_STAFF_LCN_INSERT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _lct_ida As String = ""
    Private _YEARS As String
    Private _type_id As String
    Private _IDA As String

    Sub RunQuery()
        Try
            _CLS = Session("CLS")
            _lct_ida = Request.QueryString("lct_ida")
            _type_id = Request.QueryString("type_id")
            _ProcessID = Request.QueryString("process")
            _IDA = Request.QueryString("ida")
            _ProcessID = Request.QueryString("process")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
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
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            UC_LCN_HERB_PHESAJ.bind_lcn_type()
            UC_LCN_HERB_PHESAJ.bind_ddl_prefix()
            UC_LCN_HERB_PHESAJ.bind_ddl_phr_type()
            'If Request.QueryString("phr_ida") <> "" Then
            '    Panel2.Style.Add("display", "none")
            'Else
            '    Panel2.Style.Add("display", "block")
            'End If

        End If
    End Sub

End Class
Public Class POPUP_STAFF_LCN_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Public _ProcessID As String
    Private _lct_ida As String = ""
    Private _YEARS As String
    Private _type_id As String
    Private _IDA As String
    Public phr_ida As String

    Sub RunQuery()
        Try
            _CLS = Session("CLS")
            _lct_ida = Request.QueryString("lct_ida")
            _type_id = Request.QueryString("type_id")
            _ProcessID = Request.QueryString("process")
            _IDA = Request.QueryString("ida")
            _ProcessID = Request.QueryString("process")
            phr_ida = Request.QueryString("PHR_IDA")
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
        RunQuery()
        If Not IsPostBack Then
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            dao.GetDataby_IDA(phr_ida)
            UC_LCN_HERBB_PHESAJ_EDIT.bind_lcn_type()
            UC_LCN_HERBB_PHESAJ_EDIT.bind_ddl_prefix()
            UC_LCN_HERBB_PHESAJ_EDIT.bind_ddl_phr_type()
            UC_LCN_HERBB_PHESAJ_EDIT.select_mastra(_ProcessID)
            UC_LCN_HERBB_PHESAJ_EDIT.Get_data(dao)
        End If
    End Sub
End Class
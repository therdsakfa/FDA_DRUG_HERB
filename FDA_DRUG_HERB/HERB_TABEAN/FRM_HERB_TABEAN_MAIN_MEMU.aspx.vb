Public Class FRM_HERB_TABEAN_MAIN_MEMU
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Protected Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        'Response.Redirect("FRM_HERB_TABEAN_NEW.aspx?MENU_GROUP=1")
        _CLS.BTN_GROUPS = 1
        Response.Redirect("FRM_HERB_TABEAN_SELECT_SID.aspx?MENU_GROUP=1")
    End Sub

    Private Sub btn_other_Click(sender As Object, e As EventArgs) Handles btn_other.Click
        'Response.Redirect("FRM_HERB_TABEAN_OTHER.aspx?MENU_GROUP=2")
        'Response.Redirect("../HERB_TABEAN_SUBSTITUTE/FRM_HERB_TABEAN_SUB_MENU.aspx?MENU_GROUP=2")
        'Response.Redirect("FRM_HERB_TABEAN_OTHER.aspx?MENU_GROUP=2")
        _CLS.BTN_GROUPS = 2
        Response.Redirect("../HERB_TABEAN/FRM_TABEAN_HERB_SELECT_LCN_OTHER.aspx?MENU_GROUP=2")
    End Sub

End Class
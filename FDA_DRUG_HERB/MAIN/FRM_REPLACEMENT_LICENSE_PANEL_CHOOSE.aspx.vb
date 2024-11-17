Public Class FRM_REPLACEMENT_LICENSE_PANEL_CHOOSE
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        'Response.Redirect("../LOCATION/FRM_LCN_LCT.aspx?MENU_GROUP=1&ttt=1")
        Dim script As String = "<script type='text/javascript'>alert('ไม่สามารถสร้างคำขอใหม่ได้ขณะนี้ กรุณาติดต่อเจ้าหน้าที่');</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", script)
    End Sub

    Private Sub btn_other_Click(sender As Object, e As EventArgs) Handles btn_other.Click
        Response.Redirect("FRM_SELECT_PROCESS_LCN.aspx?MENU_GROUP=1&ttt=2")
    End Sub
End Class
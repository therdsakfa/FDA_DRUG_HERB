Public Class POPUP_LCN_DRUG_GROUP_HERB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UC_TABLE_DRUG_GROUP_CHANGE_HERB.bind_type(Request.QueryString("ida"))
        UC_TABLE_DRUG_GROUP_CHANGE_HERB.bind_table(Request.QueryString("ida"))
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UC_TABLE_DRUG_GROUP_CHANGE_HERB.save_data(Request.QueryString("ida"))
        alert("บันทึกเรียบร้อย")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class
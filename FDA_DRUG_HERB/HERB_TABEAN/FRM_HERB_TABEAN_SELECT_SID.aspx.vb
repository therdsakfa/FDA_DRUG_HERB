Public Class FRM_HERB_TABEAN_SELECT_SID
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""

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
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Protected Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        _CLS.SID_ID = 1
        'Response.Redirect("FRM_TABEAN_HERB_SELECT_LCN_MAIN.aspx?MENU_GROUP=1" & "&SID=1")
        Response.Redirect("FRM_HERB_TABEAN_NEW.aspx?MENU_GROUP=1&SID=1")
    End Sub

    Protected Sub btn_other_Click(sender As Object, e As EventArgs) Handles btn_other.Click
        Dim DAO_WHO As New DAO_WHO.TB_WHO_DALCN
        Dim CITIZEN_ID As String = _CLS.CITIZEN_ID
        Try
            DAO_WHO.GetdatabyID_IDEN(CITIZEN_ID)
            If DAO_WHO.fields.IDA = Nothing Then
                alert("ท่านไม่มีใบอณุญาตที่ได้รับมอบ")
            Else
                _CLS.SID_ID = 1
                Response.Redirect("FRM_HERB_TABEAN_NEW_WHO.aspx?MENU_GROUP=1" & "&SID=2")
            End If
        Catch ex As Exception
            alert("ท่านไม่มีใบอณุญาตที่ได้รับมอบ")
        End Try


    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class
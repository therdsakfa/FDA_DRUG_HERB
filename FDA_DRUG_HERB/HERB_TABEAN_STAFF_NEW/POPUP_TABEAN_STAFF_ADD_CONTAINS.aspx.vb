Imports Telerik.Web.UI

Public Class POPUP_TABEAN_STAFF_ADD_CONTAINS
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then

            UC_officer_che.bind_unit1()
            UC_officer_che.bind_unit2()
            UC_officer_che.bind_unit3()
            UC_officer_che.bind_unit4()
            UC_officer_che.get_data_drgperunit()
            UC_officer_che.bind_unit_each()
            UC_officer_che.bind_lbl()
            ' UC_recipe.bind_ddl_atc()            UC_officer_che.bind_unit_head()
            UC_officer_che.bind_unit()


        End If

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Response.Redirect("FRM_HERB_TABEAN_STAFF_TABEAN_INAPPROVE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&IDA_LCN=" & _IDA_LCN)
    End Sub
End Class
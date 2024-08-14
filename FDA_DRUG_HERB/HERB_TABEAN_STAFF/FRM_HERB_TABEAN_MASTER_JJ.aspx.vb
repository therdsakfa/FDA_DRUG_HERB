Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_MASTER_JJ
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RadGrid1.Rebind()
        End If
    End Sub

    Protected Sub DD_HERB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_HERB.SelectedIndexChanged
        bind_data()
        RadGrid1.Rebind()
    End Sub

    Protected Sub btn_add_name_jj_Click(sender As Object, e As EventArgs) Handles btn_add_name_jj.Click

        Dim PROCESS_JJ As Integer = 0
        PROCESS_JJ = DD_HERB.SelectedValue

        If PROCESS_JJ = 0 Then
            alert_normal("กรุณาเลือกประเภท")
        Else
            lbl_head1.Text = "เพิ่มชื่อยา"
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_MASTER_JJ_NAME.aspx?PROCESS_ID=" & PROCESS_JJ & "');", True)
        End If

    End Sub

    Function bind_data()
        Dim dt As DataTable

        Dim PROCESS_JJ As Integer = 0
        PROCESS_JJ = DD_HERB.SelectedValue

        Dim bao As New BAO_TABEAN_HERB.master_jj
        dt = bao.SP_MAS_TABEAN_HERB_NAME_JJ(PROCESS_JJ)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim bao_infor As New BAO.information
            Dim item As GridDataItem = e.Item

            Dim _IDA As String = item("IDA").Text
            Dim _HERB_ID As String = item("HERB_ID").Text
            Dim _PROCESS_ID As String = item("PROCESS_ID").Text

            If e.CommandName = "JJ_SELECT" Then
                lbl_head1.Text = "เพิ่มรายละเอียด"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_MASTER_JJ_DETAIL.aspx?IDA=" & _IDA & "&HERB_ID=" & _HERB_ID & "&PROCESS_ID=" & _PROCESS_ID & "');", True)
            ElseIf e.CommandName = "JJ_EDIT" Then
                lbl_head1.Text = "แก้ไขรายละเอียด"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_MASTER_JJ_NAME.aspx?IDA=" & _IDA & "&HERB_ID=" & _HERB_ID & "&PROCESS_ID=" & _PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

End Class
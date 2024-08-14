Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_INFORM_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _rgt_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Dim PROCESS_ID As Integer = 0
            Dim IDA_DR As Integer = 0
            Dim IDA_LCN As Integer = 0
            Dim STATUS_ID As Integer = 0
            Try
                IDA = item("IDA").Text
                PROCESS_ID = item("PROCESS_ID").Text
                IDA_LCN = item("FK_LCN").Text
                STATUS_ID = item("STATUS_ID").Text
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                If STATUS_ID = 11 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_HERB_TABEAN_INFORM_STAFF_EDIT.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_HERB_TABEAN_INFORM_CONFIRM_STAFF.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                End If
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_HERB_TABEAN_INFORM_CONFIRM_STAFF.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dt As New DataTable
        Try
            dt = bao.SP_TABEAN_INFORM_STAFF()
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class
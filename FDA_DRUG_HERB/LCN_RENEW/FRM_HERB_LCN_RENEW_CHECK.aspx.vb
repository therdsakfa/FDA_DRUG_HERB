Imports Telerik.Web.UI
Public Class FRM_HERB_LCN_RENEW_CHECK
    Inherits System.Web.UI.Page
    Private _MENU_GROUP As String = ""
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String = ""
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _ProcessID = Request.QueryString("process")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim PROCESS_ID As Integer = item("PROCESS_PRE").Text
            Dim IDA_PRE As Integer
            Try
                IDA_PRE = item("IDA_PRE").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "HL_SELECT" Then
                'lbl_head1.Text = "รายละเเอียดใยอนุญาต"
                If Request.QueryString("staff") = "" Then
                    If STATUS_ID = 5 Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CHECK_EDIT_FILE.aspx?IDA_LCN=" & IDA & "&IDA=" & IDA_PRE & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CHECK.aspx?IDA_LCN=" & IDA & "&IDA=" & IDA_PRE & "&PROCESS_ID=" & _ProcessID & "');", True)
                    End If
                ElseIf STATUS_ID = 5 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CHECK_EDIT_FILE.aspx?IDA_LCN=" & IDA & "&IDA=" & IDA_PRE & "&staff=1" & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CHECK.aspx?IDA_LCN=" & IDA & "&IDA=" & IDA_PRE & "&staff=1" & "&PROCESS_ID=" & _ProcessID & "');", True)
                End If
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        'If IDGroup = 21020 Then
        RadGrid1.DataSource = bao.SP_CUSTOMER_LCN_RNP_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)
        'RadGrid1.DataSource = dt

    End Sub
End Class
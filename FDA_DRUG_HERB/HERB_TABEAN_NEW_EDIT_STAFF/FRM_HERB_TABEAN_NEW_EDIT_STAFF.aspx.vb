Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_NEW_EDIT_STAFF
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
            Dim TR_ID As Integer = 0
            Try
                IDA = item("IDA").Text
                PROCESS_ID = item("PROCESS_ID").Text
                STATUS_ID = item("STATUS_ID").Text
                TR_ID = item("TR_ID").Text
                IDA_DR = item("FK_IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
            dao.GetdatabyID_IDA(IDA)
            Try
                IDA_LCN = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                If STATUS_ID = 3 Or STATUS_ID = 18 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_STAFF_INTAKE.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                ElseIf STATUS_ID = 19 Or STATUS_ID = 20 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_STAFF_INTAKE_EDIT.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                ElseIf STATUS_ID = 11 Or STATUS_ID = 16 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_STAFF_EDIT.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                ElseIf STATUS_ID = 8 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_STAFF_APPROVE.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "&IDA_DR=" & IDA_DR & "');", True)
                ElseIf STATUS_ID = 17 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_ESTIMATE.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "&IDA_DR=" & IDA_DR & "');", True)
                ElseIf STATUS_ID = 14 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_CONSIDER.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "');", True)
                ElseIf STATUS_ID = 6 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_STAFF_APPROVE.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "&IDA_DR=" & IDA_DR & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_STAFF_COMFIRM.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "&IDA_DR=" & IDA_DR & "');", True)
                End If
            ElseIf e.CommandName = "sel2" Then
                If STATUS_ID = 3 Or STATUS_ID = 12 Or STATUS_ID = 14 Or STATUS_ID = 17 Or STATUS_ID = 18 Or STATUS_ID = 23 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_TABEAN_NEW_EDIT_STAFF_ADD_DATA.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "&IDA_DR=" & IDA_DR & "');", True)
                    'Response.Redirect("../HERB_TABEAN_NEW_EDIT/POPUP_HERB_TABEAN_EDIT_SELECT_LIST.aspx?IDA=" & IDA & "&process_id=" & PROCESS_ID & "&TR_ID=" & TR_ID & "&IDA_LCN=" & IDA_LCN & "&IDA_DR=" & IDA_DR)
                End If
            End If
        End If
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim STATUS_ID As String = item("STATUS_ID").Text

            Dim SELECT_ADD_DATA As LinkButton = DirectCast(item("btn_Select2").Controls(0), LinkButton)
            SELECT_ADD_DATA.Style.Add("display", "none")

            If STATUS_ID = 3 Or STATUS_ID = 12 Or STATUS_ID = 14 Or STATUS_ID = 17 Or STATUS_ID = 18 Or STATUS_ID = 23 Then
                SELECT_ADD_DATA.Style.Add("display", "block")
            End If

        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_TABEAN_EDIT_REQUEST_STAFF()
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class
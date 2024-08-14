Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_JJ_EDIT_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _LCNNO_DISPLAY As String = ""

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
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _LCNNO_DISPLAY = Request.QueryString("LCNNO_DISPLAY")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            RadGrid1.Rebind()
        End If
    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt = bao.SP_TABEAN_OFFICER_JJ_EDIT_REQUEST()

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim bao_infor As New BAO.information
            Dim item As GridDataItem = e.Item

            Dim _IDA As String = item("IDA").Text
            Dim _DDHERB As String = item("DDHERB").Text
            Dim tr_id As String = item("TR_ID_JJ").Text
            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim LCN_ID As String = item("IDA_LCN").Text

            If e.CommandName = "JJ_SELECT" Then
                'If STATUS_ID <> Nothing Then
                '    lbl_head1.Text = "ข้อมูลแก้ไขจดแจ้งของผู้ประกอบการยื่นคำขอ"
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT_STAFF_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                'Else
                If STATUS_ID = 4 Then
                    lbl_head1.Text = "รายละเอียดการแก้ไข"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT_STAFF_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 3 Or STATUS_ID = 5 Then
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT_STAFF_INTAKE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                Else
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT_STAFF_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                End If
            End If
        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim _IDA As String = item("IDA").Text
            Dim _DDHERB As String = item("DDHERB").Text
            Dim tr_id As String = item("TR_ID_JJ").Text
            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim LCN_ID As String = item("IDA_LCN").Text

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(_IDA)


            Dim JJ_SELECT As LinkButton = DirectCast(item("JJ_SELECT").Controls(0), LinkButton)
            'JJ_SELECT.Style.Add("display", "none")

            If dao.fields.STATUS_ID = 4 Then
                'item("JJ_SELECT").Text = "รายละเอียดการแก้ไข"
                JJ_SELECT.Text = "รายละเอียดของการแก้ไข"
            Else
                JJ_SELECT.Text = "ดูข้อมูล"
            End If

        End If

    End Sub
End Class
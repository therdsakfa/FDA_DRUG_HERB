Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_EX_STAFF
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
        dt = bao.SP_TABEAN_HERB_EX_STAFF()

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
            Dim _PROCESS_ID As String = item("process_id").Text
            Dim tr_id As String = item("TR_ID").Text
            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim LCN_ID As String = item("LCN_IDA").Text

            If e.CommandName = "EX_SELECT" Then
                If STATUS_ID = 3 Or STATUS_ID = 5 Then
                    'lbl_head1.Text = "ข้อมูลจดแจ้งของผู้ประกอบการยื่นคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_STAFF_INTAKE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 16 Then
                    'lbl_head1.Text = "ข้อมูลจดแจ้ง เสนอลงนาม"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_STAFF_INOFFER.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 13 Then
                    'lbl_head1.Text = "ข้อมูลจดแจ้ง อนุมัติ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_STAFF_INAPPROVE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 19 Then
                    'lbl_head1.Text = "ทบทวน"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_STAFF_INTAKE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 4 Then
                    ' lbl_head1.Text = "แก้ไขข้อมูล"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_STAFF_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 6 Then
                    'lbl_head1.Text = "แก้ไขข้อมูล"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_STAFF_INAPPROVE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 12 Or STATUS_ID = 11 Then
                    'lbl_head1.Text = "ตรวจสอบก่อนลงนาม"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_STAFF_INOFFER.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 8 Then
                    ' lbl_head1.Text = "อนุมัติคำขอเรียบร้อยแล้ว"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EX_STAFF_APPROVE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & LCN_ID & "');", True)
                End If

            End If
        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class
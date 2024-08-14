Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_STAFF_TABEAN
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
        dt = bao.SP_DRUG_DRRQT_MAIN_STAFF_NEW()

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
            Dim _DDHERB As String = item("PROCESS_ID").Text
            Dim tr_id As String = item("TR_ID").Text
            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim LCN_ID As String = item("LCN_ID").Text
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            dao_dal.GetDataby_IDA(LCN_ID)
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)

            If e.CommandName = "JJ_SELECT" Then
                If STATUS_ID = 3 Or STATUS_ID = 5 Then
                    lbl_head1.Text = "ข้อมูลทะเบียนของผู้ประกอบการยื่นคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_INTAKE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)

                ElseIf STATUS_ID = 12 Or STATUS_ID = 11 Or STATUS_ID = 17 Or STATUS_ID = 23 Then
                    lbl_head1.Text = "ข้อมูลทะเบียน ประเมิน"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_ESTIMATE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 9 Or STATUS_ID = 6 Then
                    lbl_head1.Text = "ข้อมูลทะเบียน "
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_KEEP_PAY.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 13 Or STATUS_ID = 15 Then
                    lbl_head1.Text = "ข้อมูลทะเบียน เสนอลงนาม"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_INOFFER.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 21 Then
                    lbl_head1.Text = "ข้อมูลทะเบียน อนุมัติ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_INAPPROVE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 4 Then
                    lbl_head1.Text = "แก้ไขข้อมูล"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 8 Then
                    lbl_head1.Text = "อนุมัติคำขอเรียบร้อยแล้ว"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_APPROVE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 14 Then
                    lbl_head1.Text = "แก้ไขข้อมูล"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_EDIT2.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_APPROVE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                ElseIf STATUS_ID = 24 Then
                    lbl_head1.Text = "ทบทวน ประเมิน"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_STAFF_TABEAN_ESTIMATE.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                Else
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_TABEAN_STAFF_DETAIL.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _DDHERB & "&IDA_LCN=" & LCN_ID & "');", True)
                End If
            ElseIf e.CommandName = "JJ_ADD_SELECT" Then
                Dim dao_tbn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
                dao_tbn.GetdatabyID_FK_IDA_DQ(_IDA)
                Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                dao_lcn.GetDataby_IDA(dao.fields.FK_LCN_IDA)

                Dim SID As String = ""
                Dim R_ID As String = ""
                If dao.fields.WHO_ID <> 0 Then
                    SID = 2
                Else
                    SID = 1
                End If
                Try
                    If _DDHERB.Contains(2019) Then
                        R_ID = 2
                    Else
                        R_ID = 1
                    End If

                Catch ex As Exception

                End Try
                Response.Redirect("../HERB_TABEAN_NEW/FRM_HERB_TABEAN_ADD_DETAIL.aspx?TR_ID_LCN=" & dao_dal.fields.TR_ID & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & dao_dal.fields.IDA _
                                  & "&PROCESS_ID_LCN=" & dao.fields.PROCESS_ID & "&IDA_DQ=" & dao.fields.IDA & "&PROCESS_ID_DQ=" & _DDHERB & "&staff=2" & "&R_ID=" & R_ID & "&SID=" & SID _
                                  & "&PROCESS_ID_LCN=" & dao_lcn.fields.PROCESS_ID)
            End If
        End If
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim STATUS_ID As String = item("STATUS_ID").Text

            Dim JJ_ADD_SELECT As LinkButton = DirectCast(item("JJ_ADD_SELECT").Controls(0), LinkButton)
            JJ_ADD_SELECT.Style.Add("display", "none")

            If STATUS_ID = 9 Or STATUS_ID = 24 Or STATUS_ID = 13 Or STATUS_ID = 15 Or STATUS_ID = 11 Or STATUS_ID = 3 Or STATUS_ID = 21 Then
                JJ_ADD_SELECT.Style.Add("display", "block")
            End If

        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

End Class
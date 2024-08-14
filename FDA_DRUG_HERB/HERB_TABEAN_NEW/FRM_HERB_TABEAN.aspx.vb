Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _SID As String = ""
    Private _WHO_IDA As String = ""

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
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _SID = Request.QueryString("SID")
        _WHO_IDA = Request.QueryString("WHO_IDA")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'bind_dd()
            RadGrid1.Rebind()
        End If
    End Sub

    Private Sub R_DD_HERB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles R_DD_HERB.SelectedIndexChanged
        If R_DD_HERB.SelectedValue = 1 Then
            DD_HERB.Visible = True
            dd_type.Visible = True
            bind_dd_HERB()
            'DD_HERB_OUT.Visible = False
            btn_tb_herb.Visible = False
        ElseIf R_DD_HERB.SelectedValue = 2 Then
            DD_HERB.Visible = True
            dd_type.Visible = True
            bind_dd_HERB()
            'DD_HERB_OUT.Visible = False
            btn_tb_herb.Visible = False
        End If
    End Sub
    Public Sub bind_dd_HERB()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_DD_HERB(R_DD_HERB.SelectedValue)

        DD_HERB.DataSource = dt
        DD_HERB.DataBind()
        DD_HERB.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Protected Sub DD_HERB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_HERB.SelectedIndexChanged
        If DD_HERB.SelectedValue Is Nothing = False Then
            'If DD_HERB.SelectedValue = 20101 Then
            btn_tb_herb.Visible = True
            'ElseIf DD_HERB.SelectedValue = 20102 Then
            '    btn_tb_herb.Visible = True
            'ElseIf DD_HERB.SelectedValue = 20103 Then
            '    btn_tb_herb.Visible = True
            'ElseIf DD_HERB.SelectedValue = 20104 Then
            '    btn_tb_herb.Visible = True
        Else
            btn_tb_herb.Visible = False
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
        End If
    End Sub

    'Private Sub DD_HERB_OUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_HERB_OUT.SelectedIndexChanged
    '    If DD_HERB_OUT.SelectedValue = 20901 Then
    '        btn_tb_herb.Visible = True
    '    ElseIf DD_HERB_OUT.SelectedValue = 20902 Then
    '        btn_tb_herb.Visible = False
    '    ElseIf DD_HERB_OUT.SelectedValue = 20903 Then
    '        btn_tb_herb.Visible = False
    '    ElseIf DD_HERB_OUT.SelectedValue = 20904 Then
    '        btn_tb_herb.Visible = False
    '    Else
    '        btn_tb_herb.Visible = False
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
    '    End If
    'End Sub

    Protected Sub btn_tb_herb_Click(sender As Object, e As EventArgs) Handles btn_tb_herb.Click
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.fields.CREATE_DATE = Date.Now
        dao.insert()
        Dim DD_H As String = ""
        If R_DD_HERB.SelectedValue = 1 Then
            DD_H = DD_HERB.SelectedValue
        ElseIf R_DD_HERB.SelectedValue = 2 Then
            DD_H = DD_HERB.SelectedValue
        End If
        If Request.QueryString("staff") = 1 Then
            _MENU_GROUP = 1
            Response.Redirect("FRM_HERB_TABEAN_ADD_DETAIL.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & dao.fields.IDA & "&PROCESS_ID_DQ=" & DD_H & "&staff=" & Request.QueryString("staff") & "&SID=" & _SID & "&R_ID=" & R_DD_HERB.SelectedValue & "&WHO_IDA=" & _WHO_IDA)
        Else
            Response.Redirect("FRM_HERB_TABEAN_ADD_DETAIL.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & dao.fields.IDA & "&PROCESS_ID_DQ=" & DD_H & "&SID=" & _SID & "&R_ID=" & R_DD_HERB.SelectedValue & "&WHO_IDA=" & _WHO_IDA)

        End If
        'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_HEALTH_2 & "&DDHERB=" & DD_H & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
        'Response.Redirect("FRM_HERB_TABEAN_ADD_DETAIL.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & dao.fields.IDA & "&PROCESS_ID_DQ=" & DD_HERB.SelectedValue)
        ' Response.Redirect("FRM_HERB_TABEAN_ADD_DETAIL.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & dao.fields.IDA & "&PROCESS_ID_DQ=" & DD_H)

    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        'Dim C_ID As String = _CLS.CITIZEN_ID_AUTHORIZE
        'dt = bao.SP_TABEAN_JJ(C_ID)       
        If Request.QueryString("SID") = "2" Then
            '     dt = bao.SP_TABEAN_HERB_BY_FK_IDA_LCN_AND_CID_WHO(_IDA_LCN, _CLS.CITIZEN_ID)
            dt = bao.SP_TABEAN_HERB_WHO(_IDA_LCN, _CLS.CITIZEN_ID_AUTHORIZE)
        Else
            dt = bao.SP_TABEAN_HERB_BY_FK_IDA_LCN(_IDA_LCN)
        End If
        'dt = bao.SP_TABEAN_HERB_BY_FK_IDA_LCN(_IDA_LCN)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    'Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound

    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA_LCN As Integer = item("IDA_LCN").Text
    '        Dim TR_ID_LCN As String = item("TR_ID_LCN").Text
    '        Dim FK_IDA_LCT As String = ""
    '        Try
    '            FK_IDA_LCT = item("FK_IDA_LCT").Text
    '        Catch ex As Exception

    '        End Try
    '        Dim DD As Integer = item("DD_HERB_NAME_ID").Text
    '        Dim DD_H As Integer = item("DDHERB").Text
    '        Dim IDA As Integer = item("IDA").Text
    '        Dim TR_ID_JJ As Integer = item("TR_ID_JJ").Text
    '        Dim STATUS_ID As Integer = item("STATUS_ID").Text

    '        Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
    '        If H.Text = "ดูรายละเอียด" And STATUS_ID = 4 Then
    '            lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&process=" & DD_H & "');", True)
    '        ElseIf H.Text = "ดูรายละเอียด" Then
    '            H.NavigateUrl = "FRM_HERB_TABEAN_JJ_DETAIL.aspx?IDA_LCT=" & FK_IDA_LCT & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&DDHERB=" & DD_H & "&IDA=" & IDA & "&TR_ID_JJ=" & TR_ID_JJ 'URL หน้า ยืนยัน
    '        End If

    '    End If
    'End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA_LCN As Integer = item("FK_LCN_IDA").Text
            Dim IDA_DQ As Integer = item("IDA").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim TR_ID_DQ As Integer = item("TR_ID").Text
            Dim PROCESS_ID_DQ As Integer = item("PROCESS_ID").Text

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(IDA_LCN)
            Dim TR_ID_LCN As String = dao_lcn.fields.TR_ID

            If e.CommandName = "HL_SELECT" Then

                If STATUS_ID = 4 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร ครั้งที่ 1"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EDIT.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & IDA_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&TR_ID=" & TR_ID_DQ & "');", True)
                ElseIf STATUS_ID = 14 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร ครั้งที่ 2"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_EDIT_2.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & IDA_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&TR_ID=" & TR_ID_DQ & "');", True)
                ElseIf STATUS_ID = 1 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_CONFIRM.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & IDA_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&TR_ID=" & TR_ID_DQ & "&staff=" & Request.QueryString("staff") & "');", True)
                    'Response.Redirect("FRM_HERB_TABEAN_ADD_DETAIL.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & IDA_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&TR_ID=" & TR_ID_DQ)
                ElseIf STATUS_ID = 2 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_CONFIRM.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & IDA_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&TR_ID=" & TR_ID_DQ & "&staff=" & Request.QueryString("staff") & "');", True)
                    'Response.Redirect("FRM_HERB_TABEAN_ADD_DETAIL_UPLOAD_FILE.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & IDA_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&TR_ID=" & TR_ID_DQ)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_CONFIRM.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & IDA_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&TR_ID=" & TR_ID_DQ & "');", True)
                    'Response.Redirect("FRM_HERB_TABEAN_DETAIL.aspx?TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & IDA_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&TR_ID=" & TR_ID_DQ)
                End If
            ElseIf e.CommandName = "HL1_SELECT" Then
                lbl_head1.Text = "คำขอทะเบียนผลิตภัณฑ์สมุนไพร แบบ ทบ1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_PREVIEW_TABEAN.aspx?IDA_DQ=" & IDA_DQ & "&TR_ID=" & TR_ID_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&IDA_LCN=" & IDA_LCN & "');", True)
            ElseIf e.CommandName = "HL2_SELECT" Then
                lbl_head1.Text = "ใบรับทะเบียนผลิตภัณฑ์สมุนไพร แบบ ทบ2"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_PREVIEW_TABEAN2.aspx?IDA_DQ=" & IDA_DQ & "&TR_ID=" & TR_ID_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&IDA_LCN=" & IDA_LCN & "');", True)
            ElseIf e.CommandName = "HL3_SELECT" Then
                lbl_head1.Text = "ใบนัดหมาย 1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_APPOINMENT.aspx?IDA_DQ=" & IDA_DQ & "&TR_ID=" & TR_ID_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&IDA_LCN=" & IDA_LCN & "&APPPOIN_ID=1" & "');", True)
            ElseIf e.CommandName = "HL4_SELECT" Then
                lbl_head1.Text = "ใบนัดหมาย 2"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_APPOINMENT.aspx?IDA_DQ=" & IDA_DQ & "&TR_ID=" & TR_ID_DQ & "&PROCESS_ID_DQ=" & PROCESS_ID_DQ & "&IDA_LCN=" & IDA_LCN & "&APPPOIN_ID=2" & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim STATUS_ID As String = item("STATUS_ID").Text

            Dim HL1_SELECT As LinkButton = DirectCast(item("HL1_SELECT").Controls(0), LinkButton)
            Dim HL2_SELECT As LinkButton = DirectCast(item("HL2_SELECT").Controls(0), LinkButton)
            Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            Dim HL4_SELECT As LinkButton = DirectCast(item("HL4_SELECT").Controls(0), LinkButton)
            Dim HL5_SELECT As LinkButton = DirectCast(item("HL4_SELECT").Controls(0), LinkButton)

            HL1_SELECT.Style.Add("display", "none")
            HL2_SELECT.Style.Add("display", "none")
            HL3_SELECT.Style.Add("display", "none")
            HL4_SELECT.Style.Add("display", "none")

            Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
            ' Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=HERB&acc_type=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            If Request.QueryString("staff") <> "" Then
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=staffherb"
            Else
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=herb"
            End If
            Dim H As HyperLink = e.Item.FindControl("HL5_SELECT")
            H.Style.Add("display", "none")
            H.Target = "_blank"
            H.NavigateUrl = urls

            If STATUS_ID = 8 Then
                HL2_SELECT.Style.Add("display", "block")
                HL1_SELECT.Style.Add("display", "block")
                'HL4_SELECT.Style.Add("display", "block")
                'ElseIf STATUS_ID = 6 Or STATUS_ID = 11 Or STATUS_ID = 12 Or STATUS_ID = 13 Then
            ElseIf STATUS_ID >= 1 Then
                HL1_SELECT.Style.Add("display", "block")
            End If
            If STATUS_ID = 23 Or STATUS_ID = 6 Or STATUS_ID = 8 Or STATUS_ID = 21 Or STATUS_ID = 13 Then
                HL4_SELECT.Style.Add("display", "block")
            End If
            If STATUS_ID = 3 Or STATUS_ID = 6 Or STATUS_ID = 8 Or STATUS_ID = 11 Or STATUS_ID = 12 Or STATUS_ID = 13 Or STATUS_ID = 21 Or STATUS_ID = 23 Then
                'HL3_SELECT.Style.Add("display", "block")
            ElseIf STATUS_ID = 2 Or STATUS_ID = 9 Then
                H.Style.Add("display", "block")
            ElseIf STATUS_ID = 6 Then
                H.Style.Add("display", "block")
                'HL4_SELECT.Style.Add("display", "block")
            End If
        End If
    End Sub

End Class
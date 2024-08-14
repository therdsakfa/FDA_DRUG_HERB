Imports Telerik.Web.UI
Public Class FRM_LCN_EDIT
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    'Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _IDA As String = ""
    Private _iden As String
    Private _CLS_CITIZEN_ID_AUTHORIZE As String = ""
    Private _CLS_CITIZEN_ID As String = ""
    Private _CLS_THANM As String = ""



    Sub RunSession()

        _IDA = Request.QueryString("lcn_ida")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        '_process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            TEXT_LOAD()
            load_HL()
        End If

    End Sub
    Private Sub TEXT_LOAD()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        TXT_LCNNO.Text = dao.fields.LCNNO_DISPLAY_NEW
        TXT_LCB_NAME.Text = dao.fields.LOCATION_ADDRESS_thanameplace
    End Sub


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim bao_infor As New BAO.information
            Dim item As GridDataItem = e.Item

            Dim STATUS_ID As Integer = 0
            Try
                STATUS_ID = item("STATUS_ID").Text
            Catch ex As Exception
                STATUS_ID = 0
            End Try

            Dim IDA As Integer = item("IDA").Text
            Dim TR_ID As String = item("TR_ID").Text
            Dim LCN_EDIT_REASON_TYPE As Integer = item("LCN_EDIT_REASON_TYPE").Text

            Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
            dao.GetDataby_IDA(IDA)
            Dim PROCESS_ID As Integer = dao.fields.LCN_PROCESS_ID

            Dim _process As String = ""
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA)
            _process = dao_lcn.fields.PROCESS_ID



            If e.CommandName = "HL_SELECT" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_EDIT_CONFIRM.aspx?process=" & PROCESS_ID & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&LCN_IDA=" & _IDA & "&STATUS_ID=" & STATUS_ID & "&TR_ID_LCN_EDIT=" & TR_ID & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&detail=" & 1 & "&IDA=" & IDA & "');", True)
            ElseIf e.CommandName = "DETAIL" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_EDIT.aspx?process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&LCN_IDA=" & _IDA & "&STATUS_ID=" & STATUS_ID & "&TR_ID_LCN_EDIT=" & TR_ID & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&detail=" & 1 & "&IDA=" & IDA & "');", True)
            ElseIf e.CommandName = "HL3_SELECT" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_LCN_EDIT_APPOINMENNT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & _lct_ida & "');", True)
            ElseIf e.CommandName = "LCN_EDIT_DETAIL" Then
                If STATUS_ID = 9 Then
                    'lbl_head1.Text = "ข้อมูลขอเอกสาร (เพิ่มเติม) ยื่นคำขอแก้ไขใบอนุญาต"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_EDIT.aspx?process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&LCN_IDA=" & _IDA & "&STATUS_ID=" & STATUS_ID & "&TR_ID_LCN_EDIT=" & TR_ID & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&detail=" & 2 & "&IDA=" & IDA & "');", True)
                End If
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource


        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_IDA, 2)

        RadGrid1.DataSource = dt


    End Sub

    Protected Sub SUB_ADD_Click(sender As Object, e As EventArgs) Handles SUB_ADD.Click
        Dim _process As String = ""
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA)
        _process = dao_lcn.fields.PROCESS_ID

        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_IDA, 2)

        Dim status_id As Integer = 0

        For Each dr In dt.Rows
            status_id = dr("STATUS_ID")
        Next

        If Request.QueryString("lcn_ida") = "" Then

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_EDIT.aspx?process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&LCN_IDA=" & _IDA & "&STATUS_ID=" & status_id & "&staff=" & Request.QueryString("staff") & "&detail=" & 0 & "');", True)
        End If
    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffherb"
        Else
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=herb"
        End If

        hl_pay.NavigateUrl = urls
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim lcn_ida As Integer = _IDA
            Dim STATUS_ID As Integer = 0
            Try
                STATUS_ID = item("STATUS_ID").Text
            Catch ex As Exception
                STATUS_ID = 0
            End Try

            Dim FILE_NUMBER_NAME As Integer = 0

            FILE_NUMBER_NAME = 69
            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_EDIT/FRM_LCN_EDIT_PREVIEW_FILE.aspx?file_id=" & FILE_NUMBER_NAME & "&lcn_ida=" & lcn_ida


            Dim HL2_SELECT As LinkButton = DirectCast(item("LCN_EDIT_DETAIL").Controls(0), LinkButton)
            'HL2_SELECT.Style.Add("display", "none")

            'HL2_SELECT.Style.Add("display", "none")
            Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)

            HL3_SELECT.Style.Add("display", "none")
            If STATUS_ID = 2 Then
                HL3_SELECT.Style.Add("display", "block")
            End If

            If STATUS_ID <> 9 Then
                HL2_SELECT.Style.Add("display", "none")
                H.Style.Add("display", "none")
            End If

        End If

    End Sub
End Class
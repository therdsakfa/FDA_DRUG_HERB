Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_LCN_DRUG_TRANSFER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    Private _iden As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
            _lcn_ida = Request.QueryString("lcn_ida")
            _type = Request.QueryString("type")
            _process_for = Request.QueryString("process_for")
            _iden = Request.QueryString("identify")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_lbl_name()
            load_HL()
        End If
    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffherb"
        Else
            urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=herb"
        End If

        hl_pay.NavigateUrl = urls

    End Sub
    Private Sub load_lbl_name()

        Dim dao_menu As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu.GetDataby_Process2(_process)

        Dim dao_menu2 As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu2.GetDataby_Process2(_process_for)
        If String.IsNullOrEmpty(_process_for) = False Then
            lbl_name_2.Text = " (" & dao_menu2.fields.NAME & ") > "
        End If

        lbl_name.Text = " (" & dao_menu.fields.NAME & ")" 'ดึงชื่อเมนูมาแสดง

    End Sub
    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        Dim IDEN As String = Request.QueryString("identify")
        If IDEN = "" Then
            IDEN = _CLS.CITIZEN_ID_AUTHORIZE
        End If
        dt = bao.SP_DALCN_TRANSFER_CUSTOMER(IDEN, _lcn_ida)
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

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = item("IDA").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim IDA_LCN As Integer = item("FK_LCN").Text
            Dim PROCESS_ID As Integer = item("PROCESS_ID").Text

            If e.CommandName = "HL_SELECT" Then

                If STATUS_ID <> 0 Then
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_TRANSFER_COMFIRM.aspx?IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "&staff=" & Request.QueryString("staff") & "');", True)
                End If
            ElseIf e.CommandName = "HL3_SELECT" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POPUP_LCN_TRANSFER_APPOINMENT.aspx?IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & IDA_LCN & "&staff=" & Request.QueryString("staff") & "');", True)

            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim IDA As String = item("IDA").Text
            Dim HL_SELECT As LinkButton = DirectCast(item("HL_SELECT").Controls(0), LinkButton)
            Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            HL3_SELECT.Style.Add("display", "none")
            If STATUS_ID = 1 Then
                HL_SELECT.Text = "ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
            ElseIf STATUS_ID > 1 Then
                HL_SELECT.Text = "ดูข้อมูล"
            Else
                HL_SELECT.Text = "ดูข้อมูล"
            End If
            If STATUS_ID = 13 Or STATUS_ID = 3 Or STATUS_ID = 6 Or STATUS_ID = 8 Then
                HL3_SELECT.Style.Add("display", "block")
            End If
        End If
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_TRANSFER.aspx?lcn_ida=" & _lcn_ida & "&lct_ida=" & _lct_ida & "&process=" & _process & "&identify=" & _iden & "&staff=" & Request.QueryString("staff") & "');", True)
    End Sub
End Class
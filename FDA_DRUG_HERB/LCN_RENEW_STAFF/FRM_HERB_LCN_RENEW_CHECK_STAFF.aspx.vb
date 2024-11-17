Imports Telerik.Web.UI
Public Class FRM_HERB_LCN_RENEW_CHECK_STAFF
    Inherits System.Web.UI.Page
    Private _pvncd As Integer
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            load_ddl_chwt()
        End If
    End Sub
    Public Sub load_ddl_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()
        rcb_search_pvncd.DataSource = dt
        rcb_search_pvncd.DataBind()
        'ddl_Province.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Private Sub RG_RNP_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RG_RNP.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim selectedValue As String = rcb_search_pvncd.SelectedValue
        Dim pvncd As Integer = 0
        ' ตรวจสอบว่า selectedValue ไม่เป็นค่าว่าง ไม่เป็น 0 และเป็นเลขจำนวนเต็ม
        If Not String.IsNullOrEmpty(selectedValue) AndAlso Integer.TryParse(selectedValue, pvncd) AndAlso pvncd <> 0 Then
            Try
                dt = bao.SP_STAFF_LCN_RNP_BY_PVNCD(pvncd)
            Catch ex As Exception
                ' Handle exceptions
            End Try
        Else
            Try
                If _pvncd = 10 Then
                    dt = bao.SP_STAFF_LCN_RNP()
                    DIV_PVNCD.Visible = True
                Else
                    dt = bao.SP_STAFF_LCN_RNP_BY_PVNCD(_pvncd)
                End If
            Catch ex As Exception
                ' Handle exceptions
            End Try
        End If
        If dt.Rows.Count > 0 Then
            RG_RNP.DataSource = dt
        End If
    End Sub
    Private Sub RG_RNP_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RG_RNP.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim IDA_LCN As Integer = item("FK_LCN").Text
            Dim TR_ID As Integer = item("TR_ID").Text
            Dim IDENTIFY As String = item("CITIZEN_ID_AUTHORIZE").Text
            Dim PROCESS_ID As String = item("PROCESS_ID").Text
            Dim STATUS_ID As String = item("STATUS_ID").Text
            If e.CommandName = "HL_SELECT" Then
                If STATUS_ID = 3 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CHECK_STAFF_EDIT_FILE.aspx?IDA=" & IDA & "&IDA_LCN=" & IDA_LCN & "&IDENTIFY=" & IDENTIFY & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CHECK_STAFF.aspx?IDA=" & IDA & "&IDA_LCN=" & IDA_LCN & "&IDENTIFY=" & IDENTIFY & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                End If
            End If
        End If
    End Sub

    Protected Sub rcb_search_pvncd_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles rcb_search_pvncd.SelectedIndexChanged
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'Try
        '    If rcb_search_pvncd.SelectedValue = 10 Then
        '        dt = bao.SP_STAFF_LCN_RNP_BY_PVNCD(rcb_search_pvncd.SelectedValue)
        '    Else
        '        dt = bao.SP_STAFF_LCN_RNP_BY_PVNCD(rcb_search_pvncd.SelectedValue)
        '    End If

        'Catch ex As Exception

        'End Try
        'If dt.Rows.Count > 0 Then
        '    RG_RNP.DataSource = dt
        'End If
        RG_RNP.Rebind()
    End Sub
End Class
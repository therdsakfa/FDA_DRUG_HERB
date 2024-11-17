Imports Telerik.Web.UI
Public Class FRM_HERB_LCN_RENEW
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As String = ""
    Private _SID As String = ""
    Private _PROCESS_ID As String = ""
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

        _IDA_LCN = Request.QueryString("lcn_ida")
        _SID = Request.QueryString("SID")
        _PROCESS_ID = Request.QueryString("process")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_HL()
            'bind_dd()
            ' RadGrid1.Rebind()
        End If
    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        Dim IDEN As String = Request.QueryString("identify")
        If IDEN = "" Then
            IDEN = _CLS.CITIZEN_ID_AUTHORIZE
        End If
        dt = bao.SP_DALCN_RENEW(IDEN, _IDA_LCN)
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
            Dim FK_LCN As Integer = item("FK_LCN").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim PROCESS_ID As Integer = item("PROCESS_ID").Text

            If e.CommandName = "HL_SELECT" Then
                If STATUS_ID = 31 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_EDIT_REQUEST.aspx?IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "&IDA_LCN=" & FK_LCN & "');", True)
                ElseIf STATUS_ID = 0 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_UPLOAD_FILE.aspx?IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                Else
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & " POP_UP_LCN_RENEW_CONFIRM.aspx?IDA=" & IDA & "&PROCESS_ID=" & PROCESS_ID & "');", True)
                End If
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
            If STATUS_ID = 1 Then
                HL_SELECT.Text = "ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
            ElseIf STATUS_ID > 1 Then
                HL_SELECT.Text = "ดูข้อมูล"
            ElseIf STATUS_ID = 1 Then
                HL_SELECT.Text = "อัพเดทข้อมูล"
            Else
                HL_SELECT.Text = "ดูข้อมูล"
            End If

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
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            Dim This_Year As String = Date.Now.Year
            Dim dao As New DAO_LCN.TB_DALCN_RENEW
            dao.GET_DATA_BY_FK_LCN_ACTICE(_IDA_LCN)
            Dim dao_pre As New DAO_LCN.TB_DALCN_RENEW_PRE
            dao_pre.GET_DATA_BY_FK_LCN(_IDA_LCN, True)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim Dao_licen As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
            Dao_licen.GetDataby_IDA_DALCN(_IDA_LCN)
            Dim Renew_Year As String = dao.fields.YEAR - 543
            Dim Status_ID As Integer = 0
            Dim PreStatus_ID As Integer = 0
            Dim Process_ID As Integer = 0
            Dim cncnm As String = Dao_licen.fields.cncnm
            Dim exp_date As Date
            exp_date = dao_lcn.fields.expdate
            'exp_date = Date.Now.AddDays(-1)
            If dao_lcn.fields.PROCESS_ID = 120 Then
                Process_ID = 10903
            ElseIf dao_lcn.fields.PROCESS_ID = 121 Then
                Process_ID = 10902
            ElseIf dao_lcn.fields.PROCESS_ID = 122 Then
                Process_ID = 10901
            End If
            If dao.fields.IDA <> 0 Then Status_ID = dao.fields.STATUS_ID
            If dao_pre.fields.IDA <> 0 Then PreStatus_ID = dao_pre.fields.STATUS_ID
            If cncnm.Contains("ยกเลิก") Then
                alert("ไม่สามารถสร้างคำขอได้ เนื่องจากสถานะใบอนุญาตเเป็นยกเลิก")
            Else
                Dim Date_Count As Integer = (exp_date - DateTime.Now).Days
                If Date_Count > 90 Then
                    alert("ยังไม่สามารถยื่นคำขอได้ เนื่องจากไม่อยู่ในช่วงเวลาต่ออายุ")
                    ' Check if exp_date is more than 30 days from the current date
                ElseIf Date_Count < -30 Then
                    alert("ไม่สามารถยื่นคำขอได้ เนื่องจากวันหมดอายุเกิน 30 วันจากวันปัจจุบัน")
                ElseIf Renew_Year = This_Year And dao.fields.ACTIVEFACT = 1 AndAlso Status_ID <> 7 AndAlso Status_ID <> 65 AndAlso Status_ID <> 77 _
               AndAlso Status_ID <> 777 AndAlso Status_ID <> 78 AndAlso Status_ID <> 76 AndAlso Status_ID <> 9 Then
                    alert("ไม่สามารถสร้างคำขอได้ เนื่องจากมีคำขออยู่ในระบบแล้ว ")
                ElseIf dao_pre.fields.IDA <> 0 And PreStatus_ID <> 8 Then
                    alert("ไม่สามารถสร้างคำขอได้ เนื่องจากมีคำขอตรวจสอบข้อมูลอยู่ในระบบและยังไม่ได้ยังไม่ได้รับการอนุญาต")
                Else
                    Dim IDEN As String = Request.QueryString("identify")
                    If IDEN = "" Then
                        IDEN = _CLS.CITIZEN_ID_AUTHORIZE
                    End If
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POP_UP_LCN_RENEW_ADD.aspx?IDA_LCN=" & _IDA_LCN & "&IDENTIFY=" & IDEN & "&PROCESS_ID=" & Process_ID & "&staff=" & Request.QueryString("staff") & "');", True)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
End Class
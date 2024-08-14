Imports Telerik.Web.UI
Public Class POPUP_TABEAN_HERB_TEMPOLARY_ADD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As Integer
    Private _IDEN As String
    Private _IDA As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")
        _IDA = Request.QueryString("IDA")
        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BIND_DATA()
            bind_dd_price()
        End If
    End Sub
    Public Sub BIND_DATA()
        txt_date_confirm.Text = Date.Now
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        dao.GetdatabyID_IDA(_IDA)
        If dao.fields.IDA <> 0 Then
            txt_date_confirm.Text = dao.fields.Date_Confirm
            txt_date_confirm.ReadOnly = True
            txt_email.Text = dao.fields.E_mail
            txt_email.ReadOnly = True
            txt_phone.Text = dao.fields.Phone
            txt_phone.ReadOnly = True
            txt_ML_PAY.Text = dao.fields.ML_PAY
            txt_ML_PAY.ReadOnly = True
            TXT_SEARCH_TN.Text = dao.fields.IDEN_Confirm
            TXT_SEARCH_TN.ReadOnly = True
            BTN_SEARCH_TN.Visible = False
            txt_name_request.Text = dao.fields.Name_Confirm
            txt_name_request.ReadOnly = True
            TXT_SEARCH_TN2.Text = dao.fields.Contact_Person_Identify
            TXT_SEARCH_TN2.ReadOnly = True
            BTN_SEARCH_TN2.Visible = False
            txt_name_contact.Text = dao.fields.Contact_Person
            txt_name_contact.ReadOnly = True
            Try
                DD_PRICE_REQUEST.SelectedValue = dao.fields.Will_RequestID
            Catch ex As Exception

            End Try
            If DD_PRICE_REQUEST.SelectedValue = 11 Or DD_PRICE_REQUEST.SelectedValue = 12 _
                Or DD_PRICE_REQUEST.SelectedValue = 13 Then
                NumberPage.Visible = True
                txt_numbre_page.Text = dao.fields.Number_Pages
                txt_numbre_page.ReadOnly = True
            End If
            'E1.Visible = False
            btn_save.Visible = False
            If dao.fields.STATUS_ID = 2 Then
                btn_edit.Visible = True
            End If
        Else
            TXT_SEARCH_TN.Text = _IDEN
            Dim citizen_id As String = TXT_SEARCH_TN.Text
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Try
                Dim TYPE_PERSON As String = obj.SYSLCNSIDs.type
                If TYPE_PERSON = 1 Then
                    txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                ElseIf TYPE_PERSON = 99 Then
                    txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                        txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    Else
                        txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    End If
                End If
            Catch ex As Exception

            End Try

        End If

    End Sub
    Public Sub bind_dd_price()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_PRICE_TABEAN_EDIT_TEMPOLARY()

        DD_PRICE_REQUEST.DataSource = dt
        DD_PRICE_REQUEST.DataValueField = "ID"
        DD_PRICE_REQUEST.DataTextField = "Expense_Name"
        DD_PRICE_REQUEST.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-"
        item.Value = 0
        DD_PRICE_REQUEST.Items.Insert(0, item)

    End Sub
    Protected Sub DD_PRICE_REQUEST_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_PRICE_REQUEST.SelectedIndexChanged
        If DD_PRICE_REQUEST.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกความประสงค์');", True)
        ElseIf DD_PRICE_REQUEST.SelectedValue = 11 Or DD_PRICE_REQUEST.SelectedValue = 12 _
            Or DD_PRICE_REQUEST.SelectedValue = 13 Then
            Dim dao As New DAO_TABEAN_HERB.TB_MAS_PRICE_TABEAN_EDIT_TEMPOLARY
            dao.Getdataby_ID(DD_PRICE_REQUEST.SelectedValue)
            NumberPage.Visible = True
            txt_numbre_page.Text = 1
            txt_ML_PAY.Text = dao.fields.PRICE
        ElseIf DD_PRICE_REQUEST.SelectedValue = 7 Then
            Dim dao As New DAO_TABEAN_HERB.TB_MAS_PRICE_TABEAN_EDIT_TEMPOLARY
            dao.Getdataby_ID(DD_PRICE_REQUEST.SelectedValue)
            NumberPage.Visible = True
            txt_numbre_page.Text = 1
            txt_ML_PAY.Text = dao.fields.PRICE
            Label6.Text = "จำนวนทะเบียน"
        Else
            Dim dao As New DAO_TABEAN_HERB.TB_MAS_PRICE_TABEAN_EDIT_TEMPOLARY
            dao.Getdataby_ID(DD_PRICE_REQUEST.SelectedValue)
            txt_ML_PAY.Text = dao.fields.PRICE
            NumberPage.Visible = False
        End If
    End Sub
    Private Sub txt_numbre_page_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numbre_page.TextChanged
        txt_ML_PAY.Text = SUM_PRICE()
    End Sub
    Function SUM_PRICE()
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_PRICE_TABEAN_EDIT_TEMPOLARY
        dao.Getdataby_ID(DD_PRICE_REQUEST.SelectedValue)
        Dim number1 As Integer = 0
        Dim number2 As Integer = 0
        Dim answer1 As Decimal
        number1 = dao.fields.PRICE
            number2 = txt_numbre_page.Text
        answer1 = number1 * number2
        Return answer1
    End Function
    Protected Sub BTN_SEARCH_TN_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_TN.Click
        Dim dao As New DAO_CPN.TB_syslcnsnm

        If TXT_SEARCH_TN.Text IsNot Nothing Then
            Dim citizen_id As String = TXT_SEARCH_TN.Text
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Try
                If obj.SYSLCNSIDs.type Is Nothing Then
                    txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
                    If TYPE_PERSON = 1 Then
                        txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    ElseIf TYPE_PERSON = 99 Then
                        txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    Else
                        If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                            txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                        Else
                            txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                        End If
                    End If
                End If
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End Try

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
        End If
    End Sub
    Protected Sub BTN_SEARCH_TN2_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_TN2.Click
        Dim dao As New DAO_CPN.TB_syslcnsnm

        If TXT_SEARCH_TN2.Text IsNot Nothing Then
            Dim citizen_id As String = TXT_SEARCH_TN2.Text
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Try
                If obj.SYSLCNSIDs.type Is Nothing Then
                    txt_name_contact.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
                    If TYPE_PERSON = 1 Then
                        txt_name_contact.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    ElseIf TYPE_PERSON = 99 Then
                        txt_name_contact.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    Else
                        If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                            txt_name_contact.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                        Else
                            txt_name_contact.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                        End If
                    End If
                End If
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End Try

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
        End If
    End Sub
    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        dao.GetdatabyID_IDA(_IDA)
        txt_date_confirm.ReadOnly = False
        txt_email.ReadOnly = False
        txt_phone.ReadOnly = False
        txt_ML_PAY.ReadOnly = False
        TXT_SEARCH_TN.ReadOnly = False
        txt_name_contact.ReadOnly = False
        txt_name_request.ReadOnly = False
        TXT_SEARCH_TN2.ReadOnly = False

        BTN_SEARCH_TN.Visible = True
        BTN_SEARCH_TN2.Visible = True

        If DD_PRICE_REQUEST.SelectedValue = 11 Or DD_PRICE_REQUEST.SelectedValue = 12 _
                Or DD_PRICE_REQUEST.SelectedValue = 13 Then
            'NumberPage.Visible = True
            txt_numbre_page.ReadOnly = False
        ElseIf DD_PRICE_REQUEST.SelectedValue = 7 Then
            txt_numbre_page.ReadOnly = False
        End If
        btn_save.Visible = True
        btn_edit.Visible = False
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If txt_name_request.Text Is Nothing Or txt_name_request.Text = "" _
            Or txt_name_contact.Text Is Nothing Or txt_name_contact.Text = "" _
            Or txt_date_confirm.Text Is Nothing Or txt_name_contact.Text = "" _
            Or txt_email.Text Is Nothing Or txt_email.Text = "" _
             Or txt_phone.Text Is Nothing Or txt_phone.Text = "" Then
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครบถ้วน');", True)
            If txt_name_request.Text Is Nothing Or txt_name_request.Text = "" Then
                lbl_name_request.Visible = True
            Else
                lbl_name_request.Visible = False
            End If
            If txt_name_contact.Text Is Nothing Or txt_name_contact.Text = "" Then
                lbl_name_contact.Visible = True
            Else
                lbl_name_contact.Visible = False
            End If
            If txt_date_confirm.Text Is Nothing Or txt_date_confirm.Text = "" Then
                lbl_date_confirm.Visible = True
            Else
                lbl_date_confirm.Visible = False
            End If
            If txt_email.Text Is Nothing Or txt_email.Text = "" Then
                lbl_email.Visible = True
            Else
                lbl_email.Visible = False
            End If
            If txt_phone.Text Is Nothing Or txt_phone.Text = "" Then
                lbl_phone.Visible = True
            Else
                lbl_phone.Visible = False
            End If
        ElseIf DD_PRICE_REQUEST.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกความประสงค์');", True)
            lbl_PRICE_REQUEST.Visible = True
        Else
            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
            dao.GetdatabyID_IDA(_IDA)
            Dim dao_mas As New DAO_TABEAN_HERB.TB_MAS_PRICE_TABEAN_EDIT_TEMPOLARY
            Try
                dao_mas.Getdataby_ID(DD_PRICE_REQUEST.SelectedValue)
            Catch ex As Exception

            End Try

            If dao.fields.IDA <> 0 Then
                dao.fields.Name_Confirm = txt_name_request.Text
                dao.fields.IDEN_Confirm = TXT_SEARCH_TN.Text
                dao.fields.Date_Confirm = txt_date_confirm.Text
                dao.fields.Create_Date = Date.Now
                dao.fields.Create_By = _CLS.THANM
                dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao.fields.ACTIVEFACT = 1
                dao.fields.STATUS_ID = 2
                dao.fields.E_mail = txt_email.Text
                dao.fields.Contact_Person = txt_name_contact.Text
                dao.fields.Contact_Person_Identify = TXT_SEARCH_TN2.Text
                dao.fields.Phone = txt_phone.Text
                dao.fields.ML_PAY = txt_ML_PAY.Text
                dao.fields.Will_RequestID = DD_PRICE_REQUEST.SelectedValue
                dao.fields.Will_RequestName = DD_PRICE_REQUEST.SelectedItem.Text
                dao.fields.RCVNO_HERB = txt_rcvno_herb.Text
                Try
                    dao.fields.Number_Pages = txt_numbre_page.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.Number_Of_Registers = txt_numbre_page.Text
                Catch ex As Exception

                End Try
                dao.fields.PROCESS_ID = _ProcessID
                dao.fields.PROCESS_CODE = dao_mas.fields.PROCESS_CODE
                Try
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                    bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

                    TR_ID = bao_tran.insert_transection(_ProcessID)
                Catch ex As Exception

                End Try
                dao.fields.TR_ID = TR_ID
                If DD_PRICE_REQUEST.SelectedValue = 15 Or DD_PRICE_REQUEST.SelectedValue = 16 Or DD_PRICE_REQUEST.SelectedValue = 17 Then
                    dao.fields.PAYMENT_TYPE = 1
                Else
                    dao.fields.PAYMENT_TYPE = 2
                End If
                dao.Update()
            Else
                dao.fields.Name_Confirm = txt_name_request.Text
                dao.fields.IDEN_Confirm = TXT_SEARCH_TN.Text
                dao.fields.Date_Confirm = txt_date_confirm.Text
                dao.fields.Create_Date = Date.Now
                dao.fields.Create_By = _CLS.THANM
                dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao.fields.ACTIVEFACT = 1
                dao.fields.STATUS_ID = 2
                dao.fields.E_mail = txt_email.Text
                dao.fields.Contact_Person = txt_name_contact.Text
                dao.fields.Contact_Person_Identify = TXT_SEARCH_TN2.Text
                dao.fields.Phone = txt_phone.Text
                dao.fields.ML_PAY = txt_ML_PAY.Text
                dao.fields.Will_RequestID = DD_PRICE_REQUEST.SelectedValue
                dao.fields.Will_RequestName = DD_PRICE_REQUEST.SelectedItem.Text
                dao.fields.FK_LCN = _IDA_LCN
                dao.fields.RCVNO_HERB = txt_rcvno_herb.Text
                Try
                    dao.fields.Number_Pages = txt_numbre_page.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.Number_Of_Registers = txt_numbre_page.Text
                Catch ex As Exception

                End Try
                dao.fields.PROCESS_ID = _ProcessID
                dao.fields.PROCESS_CODE = dao_mas.fields.PROCESS_CODE
                Try
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                    bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

                    TR_ID = bao_tran.insert_transection(_ProcessID)
                Catch ex As Exception

                End Try
                dao.fields.TR_ID = TR_ID
                If DD_PRICE_REQUEST.SelectedValue = 15 Or DD_PRICE_REQUEST.SelectedValue = 16 Or DD_PRICE_REQUEST.SelectedValue = 17 Then
                    dao.fields.PAYMENT_TYPE = 1
                Else
                    dao.fields.PAYMENT_TYPE = 2
                End If
                dao.insert()

                Try
                    Dim IDA As Integer = dao.fields.IDA
                    Dim dao2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
                    dao2.GetdatabyID_IDA(IDA)
                    Dim RCVNO_NEW As String = ""
                    Dim RCVNO_HERB_NEW As String = ""
                    Dim pvncd As String = 10
                    Dim bao As New BAO.GenNumber
                    Dim RCVNO As String = ""
                    RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, IDA)
                    dao2.fields.RCVNO = RCVNO

                    Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
                    RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, IDA)
                    Dim RCVNO_FULL As String = "HB" & " " & pvncd & "-" & dao_mas.fields.PROCESS_CODE & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
                    dao2.fields.RCVNO_FULL = RCVNO_FULL

                    dao2.Update()
                    AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, IDA)
                Catch ex As Exception

                End Try

            End If

            'Dim bao_tn As New BAO_TABEAN_HERB.tb_dd
            'bao_tn.SP_INSERT_DRUG_PAYMENT_CENTER_L44(dao.fields.CITIZEN_ID_AUTHORIZE, _IDA, dao.fields.PROCESS_ID)
            Dim SW As New SW_HERB_PAYMENT.SW_LCN_EDIT_PAYMENT
            SW.INSERT_HERB_PAYMENT_CENTER_L44(dao.fields.CITIZEN_ID_AUTHORIZE, _IDA, _ProcessID)
            alert("บันทึกเรียบร้อยแล้ว กรุณาออกใบสั่งชำระค่าคำขอ")
        End If
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
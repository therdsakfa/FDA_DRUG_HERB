Imports Telerik.Web.UI
Public Class POPUP_LCN_EDIT_CONFIRM_DETAIL
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _TR_ID As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID_LCN As String = ""
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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Bind_DD_Discount()
        End If
    End Sub
    Sub Bind_DD_Discount()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_PRICE_DISCOUNT_DALCN_HERB()

        DD_DISCOUNT.DataSource = dt
        DD_DISCOUNT.DataValueField = "ID"
        DD_DISCOUNT.DataTextField = "DiscountName"
        DD_DISCOUNT.DataBind()
        'DD_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")

        Dim item As New RadComboBoxItem
        item.Text = "ไม่มีส่วนลดตามประกาศฯ ค่าใช้จ่ายที่จะจัดเก็บจากผู้ยื่นคำขอ"
        item.Value = "0"
        DD_DISCOUNT.Items.Insert(0, item)
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim message As String = "กรุณากรอกข้อมูลให้ครบ"
        If txt_name_appoinment.Text = "" Then
            Check_1.Visible = True
            ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
        ElseIf txt_email_Appoinment.Text = "" Then
            Check_2.Visible = True
            ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
        ElseIf txt_Phone_Appoinment.Text = "" Then
            Check_3.Visible = True
            ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
        ElseIf DD_DISCOUNT.SelectedValue = "-- กรุณาเลือก --" Then
            message = "กรุณาเลือกส่วนลด"
            ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
        Else
            Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
            dao.GetDataby_IDA(_IDA)
            'dao.fields.REF_NO = txt_ref_no.Text
            dao.fields.DATE_CONFIRM = Date.Now
            'dao.fields.STATUS_ID = 3
            Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
            dao_p.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
            'dao.fields.CONFIRM = Date.Now
            Dim RCVNO_NEW As String = ""
            Dim RCVNO_HERB_NEW As String = ""
            'Dim pvncd As String = dao.fields.pvncd
            Dim pvncd As String = 10
            Dim bao As New BAO.GenNumber
            Dim RCVNO As String = ""

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn

            dao_lcn.GetDataby_IDA(_IDA_LCN)
            Dim PVNCD1 As Integer = 0
            Try
                PVNCD1 = dao_lcn.fields.pvncd
            Catch ex As Exception

            End Try
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, dao.fields.LCN_PROCESS_ID, _IDA)

            dao.fields.rcvno = RCVNO

            'RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), PVNCD1, dao.fields.LCN_PROCESS_ID, _IDA)
            Dim TR_ID As String = dao.fields.TR_ID
            Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, dao.fields.LCN_PROCESS_ID, _IDA)
            Dim RCVNO_FULL As String = "HB" & " " & PVNCD1 & "-" & dao.fields.LCN_PROCESS_ID & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
            dao.fields.RCVNO_DISPLAY = RCVNO_FULL
            dao.fields.rcvdate = Date.Now

            Dim RQ_NUM As Integer = 0
            Dim bao_gen As New BAO.GenNumber

            RQ_NUM = GEN_NO_INTAKE(con_year(Date.Now.Year), dao.fields.LCN_PROCESS_ID, _IDA_LCN)

            Dim RQ_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            dao.fields.STAFF_RQ_NUMBER = "HB " & pvncd & "-" & _PROCESS_ID.ToString & "-" & RQ_YEAR & "-" & RQ_NUM.ToString

            dao.fields.Appoinment_Contact = txt_name_appoinment.Text
            dao.fields.Appoinment_Email = txt_email_Appoinment.Text
            dao.fields.Appoinment_Phone = txt_Phone_Appoinment.Text
            dao.fields.Discount_Detail = TextBox1.Text
            Try
                dao.fields.Discount_RequestID = DD_DISCOUNT.SelectedValue
                dao.fields.Discount_RequestName = DD_DISCOUNT.SelectedItem.Text
                dao.fields.ML_REQUEST = SUM_Discount(dao.fields.LCN_PROCESS_ID)
            Catch ex As Exception

            End Try
            If dao_p.fields.REQUEST_Fee = 100 Then
                dao.fields.STATUS_ID = 2
            Else
                dao.fields.STATUS_ID = 1
            End If

            dao.update()
            AddLogStatus(dao.fields.STATUS_ID, _PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
            ' Run_PDF_TABEAN_HERB_EX()

            Dim bao_tn As New BAO_TABEAN_HERB.tb_dd
            bao_tn.SP_INSERT_DRUG_PAYMENT_CENTER_L44(dao.fields.CITIZEN_ID_AUTHORIZE, _IDA, dao.fields.LCN_PROCESS_ID)
            alert("ยื่นคำขอแล้ว กรุณาชำระค่าคำขอ")
        End If

    End Sub
    Function SUM_Discount(ByVal Process_ID As Integer)
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim dao_ml As New DAO_TABEAN_HERB.TB_MAS_PRICE_REQUEST_HERB
        dao_ml.Getdataby_Process_ID(Process_ID)
        Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
        Dim dao_p2 As New DAO_LCN.TB_MAS_PRICE_DISCOUNT_DALCN_HERB
        dao_p.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
        dao_p2.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
        Dim number1 As Integer = 0
        Dim number2 As Integer = 0
        Dim number3 As Integer = 100
        Dim answer1 As Decimal
        Dim sum1 As Integer
        Dim sum2 As Integer
        If dao_p2.fields.REQUEST_Fee = Nothing Then
            number2 = 0
        Else
            number2 = dao_p2.fields.REQUEST_Fee
        End If
        number1 = dao.fields.ML_REQUEST

        sum1 = number1 * number2
        sum2 = sum1 / number3
        answer1 = number1 - sum2
        Return answer1
    End Function
    Function GEN_NO_INTAKE(ByVal YEAR As String, ByVal PROCESS_ID As Integer, ByVal LCN_IDA As Integer)
        Dim int_no As Integer

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBER
        dao1.GetDataby_GEN(YEAR, PROCESS_ID, LCN_IDA)
        If IsNothing(dao1.fields.GEN_NO) = True Then
            int_no = 0
        Else
            int_no = dao1.fields.GEN_NO
        End If

        int_no = int_no + 1
        Dim str_no As String = int_no

        Dim dao2 As New DAO_LCN.TB_LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBER
        dao2.fields.PROCESS_ID = PROCESS_ID
        dao2.fields.FK_IDA_LCN = LCN_IDA
        dao2.fields.GEN_NO = str_no
        dao2.fields.STATUS = 1
        dao2.fields.UPLOAD_DATE = Date.Now()
        dao2.fields.YEAR = con_year(Date.Now().Year())
        dao2.insert()

        Return str_no
    End Function
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("POPUP_LCN_EDIT_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN)
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub DD_DISCOUNT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_DISCOUNT.SelectedIndexChanged
        If DD_DISCOUNT.SelectedValue = "-" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกส่วนลด');", True)
        End If
    End Sub
End Class
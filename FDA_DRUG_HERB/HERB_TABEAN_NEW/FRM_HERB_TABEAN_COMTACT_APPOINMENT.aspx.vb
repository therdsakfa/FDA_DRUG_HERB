Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_COMTACT_APPOINMENT
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_Q As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _TR_ID_LCN As String
    Private _IDA_LCT As String
    Private _DD_HERB_NAME_ID As String
    Private _PROCESS_ID_LCN As String
    Private _MENU_GROUP As String
    Private _STAFF_ID As String

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID_DQ")
        _IDA = Request.QueryString("IDA_DQ")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA_Q = Request.QueryString("IDA_DQ")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _STAFF_ID = Request.QueryString("staff")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
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
        dt = bao.SP_MAS_PRICE_DISCOUNT_TABEAN_HERB()

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
            Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
            dao_deeqt.GetDataby_IDA(_IDA_Q)
            Dim dao_t As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao_t.GetdatabyID_FK_IDA_DQ(_IDA_Q)
            Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
            dao_p.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
            dao_t.fields.DATE_CONFIRM = Date.Now

            dao_t.fields.Appoinment_Contact = txt_name_appoinment.Text
            dao_t.fields.Appoinment_Email = txt_email_Appoinment.Text
            dao_t.fields.Appoinment_Phone = txt_Phone_Appoinment.Text
            dao_t.fields.Discount_Detail = txt_Discount_Detail.Text
            Try
                dao_t.fields.Discount_RequestID = DD_DISCOUNT.SelectedValue
                dao_t.fields.Discount_RequestName = DD_DISCOUNT.SelectedItem.Text
                dao_t.fields.ML_REQUEST = SUM_Discount(dao_deeqt.fields.PROCESS_ID)
            Catch ex As Exception

            End Try
            If dao_p.fields.REQUEST_Fee = 100 Then
                dao_deeqt.fields.STATUS_ID = 3
                dao_t.fields.STATUS_ID = 3
            Else
                dao_t.fields.STATUS_ID = 2
                dao_deeqt.fields.STATUS_ID = 2
            End If
            'dao_t.fields.STATUS_ID = 3
            'dao_t.fields.STATUS_ID = 2
            dao_t.Update()

            'dao_deeqt.fields.STATUS_ID = 3
            'dao_deeqt.fields.STATUS_ID = 2
            dao_deeqt.update()

            Dim bao_tn As New BAO_TABEAN_HERB.tb_dd
            bao_tn.SP_INSERT_DRUG_PAYMENT_CENTER_L44(dao_deeqt.fields.CITIZEN_ID_AUTHORIZE, _IDA, dao_deeqt.fields.PROCESS_ID)
            alert("ยื่นคำขอแล้ว กรุณาชำระค่าคำขอ")
        End If

    End Sub
    Function SUM_Discount(ByVal Process_ID As Integer)
        Dim dao_ml As New DAO_TABEAN_HERB.TB_MAS_PRICE_REQUEST_HERB
        dao_ml.Getdataby_Process_ID(Process_ID)
        Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
        dao_p.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
        Dim number1 As Integer = 0
        Dim number2 As Integer = 0
        Dim number3 As Integer = 100
        Dim answer1 As Decimal
        Dim sum1 As Integer
        Dim sum2 As Integer
        If dao_p.fields.REQUEST_Fee = Nothing Then
            number2 = 0
        Else
            number2 = dao_p.fields.REQUEST_Fee
        End If
        number1 = dao_ml.fields.Price

        sum1 = number1 * number2
        sum2 = sum1 / number3
        answer1 = number1 - sum2
        Return answer1
    End Function

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_HERB_TABEAN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
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
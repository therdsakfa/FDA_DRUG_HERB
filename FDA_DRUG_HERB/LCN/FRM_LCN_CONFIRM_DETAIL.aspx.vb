Imports Telerik.Web.UI
Public Class FRM_LCN_CONFIRM_DETAIL
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID As String = ""
    Private b64 As String
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

        _TR_ID = Request.QueryString("TR_ID")
        _IDA = Request.QueryString("IDA")
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
            Dim bao As New BAO.GenNumber
            Dim RCVNO As Integer
            Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(_IDA)
            dao.GetDataby_IDA(Integer.Parse(_IDA))
            dao.fields.DATE_CONFIRM = Date.Now
            'Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
            Dim dao_p As New DAO_LCN.TB_MAS_PRICE_DISCOUNT_DALCN_HERB
            dao_p.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
            dao.GetDataby_IDA(Integer.Parse(_IDA))
            'If Request.QueryString("staff") <> "" Then
            '    dao.fields.STATUS_ID = 11
            'Else
            '    dao.fields.STATUS_ID = 2
            'End If
            'dao.update()
            Dim PROESS As String = Request.QueryString("process")
            Dim PROESS_NEW As String = ""
            If dao.fields.PROCESS_NEW = "" Then
                If PROESS = 120 Then
                    PROESS_NEW = 10102
                ElseIf PROESS = 121 Then
                    PROESS_NEW = 10103
                ElseIf PROESS = 122 Then
                    PROESS_NEW = 10101
                End If
            Else
                PROESS_NEW = dao.fields.PROCESS_NEW
            End If

            If b64 = Nothing Then
                b64 = Session("b64")
            End If
            Dim years As String = ""
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_tr.GetDataby_IDA(dao.fields.TR_ID)
            Try
                years = dao_tr.fields.YEAR

            Catch ex As Exception

            End Try
            Dim tr_id As String = ""
            tr_id = "DA-" & PROESS_NEW & "-" & years & "-" & _TR_ID

            Dim LCNNO_V2 As Integer
            Dim bao2 As New BAO.GenNumber
            Dim RCVNO_HERB_NEW As Integer
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROESS_NEW, _IDA)
            dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
            RCVNO_HERB_NEW = bao2.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, PROESS_NEW, _IDA)
            Dim _year As Integer = con_year(Date.Now.Year)
            If _year < 2500 Then
                _year += 543
            End If
            dao.fields.RCVNO_DISPLAY = BAO.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
                dao.fields.DATE_CONFIRM = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            LCNNO_V2 = con_year(Date.Now.Year).Substring(2, 2) & RCVNO_HERB_NEW
            dao.fields.RCVNO_DISPLAY = "HB " & _CLS.PVCODE & "-" & PROESS_NEW & "-" & con_year(Date.Now.Year).Substring(2, 2) & "-" & RCVNO_HERB_NEW
            dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
            dao.fields.Appoinment_Contact = txt_name_appoinment.Text
            dao.fields.Appoinment_Email = txt_email_Appoinment.Text
            dao.fields.Appoinment_Phone = txt_Phone_Appoinment.Text
            dao.fields.Discount_Detail = TextBox1.Text
            Try
                dao.fields.Discount_RequestID = DD_DISCOUNT.SelectedValue
                dao.fields.Discount_RequestName = DD_DISCOUNT.SelectedItem.Text
                dao.fields.ML_REQUEST = SUM_Discount(dao.fields.PROCESS_ID)
            Catch ex As Exception

            End Try
            If dao_p.fields.REQUEST_Fee = 100 Then
                dao.fields.STATUS_ID = 11
                'dao.fields.STATUS_ID = 3
            Else
                dao.fields.STATUS_ID = 2
            End If

            dao.update()
            ' Run_PDF_TABEAN_HERB_EX()
            Dim cls_sop As New CLS_SOP
            cls_sop.BLOCK_SOP(_CLS.CITIZEN_ID, PROESS_NEW, "2", "ยื่นคำขอ", tr_id, b64)
            cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "USER", PROESS_NEW, _CLS.PVCODE, 2, "ส่งเรื่องและรอพิจารณา", "SOP-DRUG-10-" & PROESS_NEW & "-1", "รับคำขอ", "รอเจ้าหน้าที่รับคำขอ", "STAFF", tr_id, SOP_STATUS:="ยื่นคำขอ")
            Try
                AddLogStatus(dao.fields.STATUS_ID, PROESS_NEW, _CLS.CITIZEN_ID, _IDA)
            Catch ex As Exception

            End Try

            Session("b64") = Nothing

            Dim bao_tn As New BAO_TABEAN_HERB.tb_dd
            bao_tn.SP_INSERT_DRUG_PAYMENT_CENTER_L44(dao.fields.CITIZEN_ID_AUTHORIZE, _IDA, dao.fields.PROCESS_ID)
            alert("ยื่นคำขอแล้ว กรุณาชำระค่าคำขอ")
        End If

    End Sub
    Function SUM_Discount(ByVal Process_ID As Integer)
        Dim dao_ml As New DAO_TABEAN_HERB.TB_MAS_PRICE_REQUEST_HERB
        dao_ml.Getdataby_Process_ID(Process_ID)
        Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
        Dim dao_p2 As New DAO_LCN.TB_MAS_PRICE_DISCOUNT_DALCN_HERB
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
        Response.Redirect("FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
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
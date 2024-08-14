Imports Telerik.Web.UI
Public Class POP_UP_LCN_TRANSFER_COMFIRM_DETAIL
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
            Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
            dao.GET_DATA_BY_IDA(_IDA)
            'dao.fields.REF_NO = txt_ref_no.Text
            dao.fields.DATE_CONFIRM = Date.Now
            'dao.fields.STATUS_ID = 3
            Dim dao_p As New DAO_LCN.TB_MAS_PRICE_DISCOUNT_DALCN_HERB
            dao_p.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
            'dao.fields.CONFIRM = Date.Now
            Dim bao As New BAO.GenNumber
                Dim RCVNO As String = ""
            'RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, dao.fields.PROCESS_ID, _IDA)
            Dim RCVNO_NEW As String = ""
                Dim RCVNO_HERB_NEW As String = ""
            'Dim pvncd As String = dao.fields.pvncd
            Dim pvncd As String = ""
            Try
                pvncd = dao.fields.pvncd
            Catch ex As Exception
                pvncd = 10
            End Try

            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), pvncd, dao.fields.PROCESS_ID, _IDA)
            Dim TR_ID As String = dao.fields.TR_ID
                Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, dao.fields.PROCESS_ID, _IDA)
            dao.fields.RCVNO = RCVNO
            Dim RCVNO_FULL As String = "HB" & " " & pvncd & "-" & dao.fields.process_id & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
            dao.fields.RCVNO_NEW = RCVNO_FULL
            dao.fields.rcvdate = Date.Now

                dao.fields.Appoinment_Contact = txt_name_appoinment.Text
                dao.fields.Appoinment_Email = txt_email_Appoinment.Text
                dao.fields.Appoinment_Phone = txt_Phone_Appoinment.Text
                dao.fields.Discount_Detail = txt_Discount_Detail.Text
                Try
                    dao.fields.Discount_RequestID = DD_DISCOUNT.SelectedValue
                    dao.fields.Discount_RequestName = DD_DISCOUNT.SelectedItem.Text
                    dao.fields.ML_REQUEST = SUM_Discount(dao.fields.process_id)
                Catch ex As Exception

                End Try
                If dao_p.fields.REQUEST_Fee = 100 Then
                dao.fields.STATUS_ID = 13
            Else
                    dao.fields.STATUS_ID = 2
                End If
            dao.fields.DATE_CONFIRM = Date.Now
            dao.update()
                ' Run_PDF_TABEAN_HERB_EX()
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
    Sub Blind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA)
        'Dim _ProcessID As String = 10501
        Dim XML As New CLASS_GEN_XML.DALCN_TRANSFER
        LCN_TRANSFER = XML.Gen_XML_LCN_TRANSFER(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_PROCESS_ID, dao.fields.STATUS_ID, "สมพ7", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_TRANSFER") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PDF", _PROCESS_ID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("XML", _PROCESS_ID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("POP_UP_LCN_TRANSFER_COMFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&PROCESS_ID=" & _PROCESS_ID)
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
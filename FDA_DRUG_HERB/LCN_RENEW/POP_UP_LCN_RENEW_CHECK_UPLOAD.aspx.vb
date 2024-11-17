Public Class POP_UP_LCN_RENEW_CHECK_UPLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _TR_ID As String = ""
    Private _IDA_LCN As String = ""
    Private _ProcessID As String = ""
    Private _Condition As String = ""

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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _ProcessID = Request.QueryString("PROCESS_ID")
        _Condition = Request.QueryString("CONDITION")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then
            bind_ddl_prefix()
            Getdata()
        End If
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
        ddl_prefix.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub Getdata()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_lo As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Try
            dao.GET_DATA_BY_IDA(_IDA)
            dao_lo.GetDataby_IDA(dao.fields.FK_LCT) 'ถ้า fk_lct is null ใช้ dao_lcn.field.fk_ida
            txt_emc_email.Text = dao.fields.emc_contact_email
            txt_emc_name.Text = dao.fields.emc_contact_name
            txt_emc_lname.Text = dao.fields.emc_contact_lname
            txt_emc_tel.Text = dao.fields.emc_contact_tel
            txt_latitude.Text = dao_lo.fields.latitude
            txt_longitude.Text = dao_lo.fields.longitude
            ddl_prefix.SelectedValue = dao.fields.emc_prefix_id
        Catch ex As Exception

        End Try
        If _Condition = "Y" Then
            btn_save2.Visible = False
        ElseIf _Condition = "N" Then
            btn_save.Visible = False
        End If
    End Sub
    Public Sub BindTable()

        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        Dim tr_id As Integer = 0
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        Dim dao_att As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        Dim group As Integer = 0
        'dao_f.GetDataby_TR_ID(tr_id)
        dao_f.GetDataby_TR_ID_TYPE(tr_id, 0)

        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        If _Condition = "N" Then
            dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_AND_DOCID(tr_id)
        Else
            dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_V2(tr_id)
        End If

        Dim rows As Integer = 1
        'For Each dao_f.fields In dao_f.datas
        For Each dr As DataRow In dt.Rows
            Dim IDA As Integer = dr("IDA")
            Dim DOCUMENT_NAME As String = dr("DOCUMENT_NAME").ToString
            Dim NAME_REAL As String = dr("NAME_REAL").ToString
            Dim HEAD_CHK As String = dr("ANNOTATION")
            Dim SUB_MAIN_MENU As String = ""
            Try
                SUB_MAIN_MENU = dr("SUB_MAIN_MENU")
            Catch ex As Exception
                Try
                    SUB_MAIN_MENU = dr("SQE_ID")
                Catch ex2 As Exception
                    SUB_MAIN_MENU = rows
                End Try
            End Try
            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell
            tc = New TableCell
            'Dim SEQ_ID As String = SUB_MAIN_MENU
            'Dim TITEL_ID As String = dr("TITEL_ID")
            tc.Text = SUB_MAIN_MENU
            tr.Cells.Add(tc)

            tc = New TableCell()
            tc.Text = IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell()
            Try
                Dim documentName As String = DOCUMENT_NAME
                ' Set text and style based on condition
                If Convert.ToBoolean(dr("Forcible")) = True Then
                    documentName = Replace(documentName, "\n", "<br/>")
                    tc.Text = documentName & "<span style='color:red;'>*</span>"
                Else
                    documentName = Replace(documentName, "\n", "<br/>")
                    tc.Text = documentName
                End If
            Catch ex As Exception
                tc.Text = DOCUMENT_NAME
            End Try
            tc.Width = 700
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim f As New FileUpload
            If HEAD_CHK <> 1 Then
                f.ID = "F" & IDA
                tc.Controls.Add(f)
                tr.Cells.Add(tc)
            End If

            tc = New TableCell
            Dim img As New Image
            If HEAD_CHK = 1 Then

            Else
                If NAME_REAL Is Nothing OrElse NAME_REAL = "" Then
                    Dim AA As String = "../Images/cancel.png"
                    img.ImageUrl = AA
                    img.Width = 20
                    img.Height = 20
                Else
                    Dim AA As String = "../Images/correct.png"
                    img.ImageUrl = AA
                    img.Width = 20
                    img.Height = 20
                End If
                tc.Controls.Add(img)
                tr.Cells.Add(tc)
            End If

            tc = New TableCell
            Dim h As New HyperLink
            Dim urls As String = ""
            h.ID = "H" & IDA
            If NAME_REAL Is Nothing OrElse NAME_REAL = "" Then
                h.Style.Add("display", "none")
            Else
                h.Style.Add("display", "block")
            End If
            urls = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
            h.Target = "_blank"
            h.NavigateUrl = urls
            h.Text = NAME_REAL
            tc.Controls.Add(h)
            tr.Cells.Add(tc)

            tb_type_menu.Rows.Add(tr)
            rows = rows + 1
        Next
    End Sub
    Sub SET_DATA(ByVal dao As DAO_LCN.TB_DALCN_RENEW_PRE)
        dao.fields.emc_contact_email = txt_emc_email.Text
        dao.fields.emc_contact_name = txt_emc_name.Text
        dao.fields.emc_contact_lname = txt_emc_lname.Text
        dao.fields.emc_contact_tel = txt_emc_tel.Text
        dao.fields.latitude = txt_latitude.Text
        dao.fields.longitude = txt_longitude.Text
        dao.fields.emc_prefix_id = ddl_prefix.SelectedValue
        dao.fields.emc_prefix_name = ddl_prefix.SelectedItem.Text
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        ' ดึงค่า latitude และ longitude ที่กรอกเข้ามาจาก txt_latitude.Text และ txt_longitude.Text
        Dim newLatitude As String = txt_latitude.Text
        Dim newLongitude As String = txt_longitude.Text
        ' เช็คว่าค่าใหม่ที่กรอกมาไม่เหมือนกับค่าปัจจุบันที่อยู่ใน DAO
        Double.TryParse(txt_latitude.Text, newLatitude)
        Double.TryParse(txt_longitude.Text, newLongitude)
        If newLatitude < 5.0 AndAlso newLatitude > 21.0 Then
            alert_normal("กรุณากรอกค่าระหว่าง 5.0 ถึง 21.0")
        ElseIf newLongitude < 97.0 AndAlso newLongitude > 106.0 Then
            alert_normal("กรุณากรอกค่าระหว่าง 97.0 ถึง 106.0")
        Else
            If dao_addr.fields.latitude <> newLatitude OrElse dao_addr.fields.longitude <> newLongitude Then
                ' ทำการอัพเดทเฉพาะเมื่อค่าใหม่ไม่เหมือนกับค่าปัจจุบัน
                dao_addr.fields.latitude = newLatitude
                dao_addr.fields.longitude = newLongitude
                dao_addr.update()
            End If
            If check_file_1() = False Then
                alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
            Else
                dao.fields.latitude = dao_addr.fields.latitude
                dao.fields.longitude = dao_addr.fields.longitude
                dao.fields.STATUS_ID = 4
                dao.fields.STATUS_UPLOAD_ID = 1
                dao.fields.DATE_CONFIRM = DateTime.Now
                SET_DATA(dao)
                dao.update()
                alert("บันทึกข้อมูลส่วนที่ 2 แล้ว")
            End If
        End If
    End Sub

    Protected Sub btn_save2_Click(sender As Object, e As EventArgs) Handles btn_save2.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        ' ดึงค่า latitude และ longitude ที่กรอกเข้ามาจาก txt_latitude.Text และ txt_longitude.Text
        Dim newLatitude As String = txt_latitude.Text
        Dim newLongitude As String = txt_longitude.Text
        ' เช็คว่าค่าใหม่ที่กรอกมาไม่เหมือนกับค่าปัจจุบันที่อยู่ใน DAO
        Try
            Double.TryParse(txt_latitude.Text, newLatitude)
            Double.TryParse(txt_longitude.Text, newLongitude)
            If newLatitude < 5.0 AndAlso newLatitude > 21.0 Then
                alert_normal("กรุณากรอกค่าระหว่าง 5.0 ถึง 21.0")
            ElseIf newLongitude < 97.0 AndAlso newLongitude > 106.0 Then
                alert_normal("กรุณากรอกค่าระหว่าง 97.0 ถึง 106.0")
            Else
                If dao_addr.fields.latitude <> newLatitude OrElse dao_addr.fields.longitude <> newLongitude Then
                    ' ทำการอัพเดทเฉพาะเมื่อค่าใหม่ไม่เหมือนกับค่าปัจจุบัน
                    dao_addr.fields.latitude = newLatitude
                    dao_addr.fields.longitude = newLongitude
                    dao_addr.update()
                End If
                If check_file_1() = False Then
                    alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
                Else
                    dao.fields.latitude = dao_addr.fields.latitude
                    dao.fields.longitude = dao_addr.fields.longitude
                    dao.fields.STATUS_ID = 2
                    dao.fields.STATUS_UPLOAD_ID = 1
                    dao.fields.DATE_CONFIRM = DateTime.Now
                    SET_DATA(dao)
                    dao.update()
                    'alert("บันทึกข้อมูลส่วนที่ 2 แล้ว")
                    'Panel_Sent_Mail.Style.Add("display", "block")
                    btn_save2.Visible = False
                    btn_close.Visible = True
                    alert("บันทึกข้อมูลแล้ว")
                End If
            End If
        Catch ex As Exception
            alert_normal("กรุณากรอกค่า Latitude, Longitude ให้อยู่ระหว่างค่าที่กำหนด")
        End Try
    End Sub
    Private Function check_file_1()

        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID
        'Dim _ProcessID As Integer = 10104

        Dim dao_check As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_check.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(TR_ID, _ProcessID, 1)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.Forcible = True And dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
                'ElseIf dao_check.fields.Forcible = 0 Then
                '    ck_file = False
                '    Exit For
            End If
        Next

        Return ck_file
    End Function
    Private Function check_file()
        Dim CHK_UPLOAD1 As String = ""
        Dim dao_check As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_check.GetDaTaby_FK_TR_PROCECSS_And_TYPE_ID(_IDA, _TR_ID, _ProcessID, 2)
        Dim ck_file As Boolean = True
        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.DOCUMENT_NAME = CHK_UPLOAD1 Then
                If dao_check.fields.NAME_FAKE Is Nothing Then
                    ck_file = False
                    Exit For
                End If
            End If
        Next
        Return ck_file
    End Function
    Protected Sub btn_att_Click(sender As Object, e As EventArgs) Handles btn_att.Click
        Dim tr_id As Integer = 0
        'Dim PROCESS_ID As Integer = 10104
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        tr_id = dao.fields.TR_ID
        For Each tr As TableRow In tb_type_menu.Rows
            Dim IDA As Integer = tr.Cells(1).Text
            Dim f As New FileUpload
            f = tr.FindControl("F" & IDA)
            If f IsNot Nothing AndAlso f.HasFile Then
                Dim name_real As String = f.FileName
                Dim Array_NAME_REAL() As String = Split(name_real, ".")
                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                If exten.ToUpper = "PDF" Then
                    Dim bao As New BAO.AppSettings
                    Dim paths As String = bao._PATH_XML_PDF_LCN_RENREW
                    Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    dao_f.GetDataby_IDA(IDA)

                    Dim Name_fake As String = "HB-" & _ProcessID & "-" & Date.Now.Year & "-" & tr_id & "-" & dao_f.fields.IDA & ".pdf"
                    dao_f.fields.NAME_FAKE = Name_fake
                    dao_f.fields.NAME_REAL = f.FileName
                    dao_f.fields.CREATE_DATE = Date.Now
                    dao_f.fields.FilePath = paths & "FILE_UPLOAD\" & Name_fake
                    dao_f.fields.Active = True
                    dao_f.update()
                    f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                Else
                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If
        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Sub alert_normal2(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub txt_latitude_TextChanged(sender As Object, e As EventArgs) Handles txt_latitude.TextChanged
        Dim latitude As Double
        ' ตรวจสอบว่าค่าที่กรอกเป็นตัวเลขหรือไม่
        If Double.TryParse(txt_latitude.Text, latitude) Then
            ' ตรวจสอบว่าค่าอยู่ในช่วงที่กำหนดหรือไม่
            If latitude >= 5.0 AndAlso latitude <= 21.0 Then
                'lblMessage.Text = "ค่าอยู่ในช่วงที่กำหนด"
            Else
                'lblMessage.Text = "กรุณากรอกค่าระหว่าง 5.0 ถึง 21.0"
                alert_normal("กรุณากรอกค่าระหว่าง 5.0 ถึง 21.0")
            End If
        Else
            'lblMessage.Text = "กรุณากรอกตัวเลขที่ถูกต้อง"
            txt_latitude.Focus()
        End If
    End Sub

    Protected Sub txt_longitude_TextChanged(sender As Object, e As EventArgs) Handles txt_longitude.TextChanged
        Dim longitude As Double
        ' ตรวจสอบว่าค่าที่กรอกเป็นตัวเลขหรือไม่
        If Double.TryParse(txt_longitude.Text, longitude) Then
            ' ตรวจสอบว่าค่าอยู่ในช่วงที่กำหนดหรือไม่
            If longitude >= 97.0 AndAlso longitude <= 106.0 Then
                'lblMessage.Text = "ค่าอยู่ในช่วงที่กำหนด"
            Else
                'lblMessage.Text = "กรุณากรอกค่าระหว่าง 97.0 ถึง 106.0"
                alert_normal("กรุณากรอกค่าระหว่าง 97.0 ถึง 106.0")
            End If
        Else
            'lblMessage.Text = "กรุณากรอกตัวเลขที่ถูกต้อง"
            txt_longitude.Focus()
        End If
    End Sub
End Class
Public Class POPUP_LCN_EDIT_UPLOAD1
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA_LCT As String = ""
    Private _TR_ID As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID As String = ""
    Private _IDA As String = ""
    Private _STATUS_ID As String = ""
    Private _detial_type As String = ""

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

        _IDA_LCT = Request.QueryString("IDA_LCT")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _STATUS_ID = Request.QueryString("STATUS_ID")
        _detial_type = Request.QueryString("detial_type")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub

    Public Sub BindTable()

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim ddl1 As Integer = 0
        Dim ddl2 As Integer = 0

        ddl1 = dao.fields.LCN_EDIT_REASON_TYPE
        Try
            ddl2 = dao.fields.FK_SUB_REASON_TYPE
        Catch ex As Exception
            ddl2 = 0
        End Try

        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE
        Dim dao_at As New DAO_LCN.TB_MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE
        Dim group As Integer = 0

        Dim Process As Integer = 10201


        Dim rows As Integer = 1

        If _STATUS_ID = 9 And _detial_type = 2 Then 'ขอเอกสารเพิ่มเติม
            'edit1.Visible = False 'ปิด DDL ขอแก้ไข ให้อัพไฟล์อย่างเดียว
            'edit2.Visible = False 'ปิด DDL ปิดเหตุผลการแก้ไข ให้อัพไฟล์อย่างเดียว
            cm1.Text = "*โปรดแนบไฟล์เอกสาร (เพิ่มเติม)"
            dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_AND_TYPE_EDIT(Process, ddl1, ddl2, 2, True)


            For Each dao_f.fields In dao_f.datas
                If dao_f.fields.FILE_NUMBER_NAME <> 69 Then
                    Dim tr As New TableRow
                    tr.CssClass = "rows"
                    Dim tc As New TableCell
                    'Dim tc1 As New TableCell
                    Dim GET_UPLOAD_HEAD_ID As Integer = 0
                    Dim GET_TITEL_ID As Integer = 0
                    Dim GET_TITEL_ID2 As Integer = 0

                    tc = New TableCell
                    tc.Text = dao_f.fields.HEAD_ID
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    tc.Text = dao_f.fields.FILE_NUMBER_NAME
                    tc.Style.Add("display", "none")
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Try
                        tc.Text = Replace(dao_f.fields.SUB_DOCUMENT_NAME, "\n", "<br/>")
                    Catch ex As Exception
                        tc.Text = dao_f.fields.SUB_DOCUMENT_NAME
                    End Try
                    tc.Width = 900
                    tr.Cells.Add(tc)

                    dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(Process, GET_UPLOAD_HEAD_ID, GET_TITEL_ID, GET_TITEL_ID2, _TR_ID, 1)

                    If dao_f.fields.NAME_REAL <> "" Then
                        tc = New TableCell
                        tc.Text = dao_f.fields.NAME_REAL
                        tc.Width = 100
                        tr.Cells.Add(tc)

                        tc = New TableCell
                        Dim img As New Image
                        Dim AA As String = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/correct.png"
                        img.ImageUrl = AA
                        img.Width = 20
                        img.Height = 20
                        tc.Controls.Add(img)
                        tc.Width = 40
                        tr.Cells.Add(tc)

                        tc = New TableCell
                        Dim f As New FileUpload
                        f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
                        tc.Controls.Add(f)
                        'tc.Width = 100
                        tr.Cells.Add(tc)
                    Else
                        tc = New TableCell
                        'tc.Text = dao_f.fields.NAME_REAL
                        tc.Width = 100
                        tr.Cells.Add(tc)

                        tc = New TableCell
                        Dim img As New Image
                        Dim AA As String = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/cancel.png"
                        img.ImageUrl = AA
                        img.Width = 20
                        img.Height = 20
                        tc.Controls.Add(img)
                        tc.Width = 40
                        tr.Cells.Add(tc)

                        tc = New TableCell
                        Dim f As New FileUpload
                        f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
                        tc.Controls.Add(f)
                        tr.Cells.Add(tc)
                    End If

                    tb_type_menu.Rows.Add(tr)
                    rows = rows + 1
                End If


            Next
        ElseIf _detial_type = 0 Or _detial_type = 1 Then
            dao_at.GetDataby_DDL(ddl1, ddl2, True)

            For Each dao_at.fields In dao_at.datas

                Dim tr As New TableRow
                tr.CssClass = "rows"
                Dim tc As New TableCell
                'Dim tc1 As New TableCell
                Dim GET_UPLOAD_HEAD_ID As Integer = 0
                Dim GET_TITEL_ID As Integer = 0
                Dim GET_TITEL_ID2 As Integer = 0
                'เช็คว่า HEAD_ID ตัวเดียวกันไหม
                GET_UPLOAD_HEAD_ID = dao_at.fields.HEAD_ID
                GET_TITEL_ID = dao_at.fields.TITEL_ID
                GET_TITEL_ID2 = dao_at.fields.TITLE_ID2

                tc = New TableCell
                tc.Text = rows
                tr.Cells.Add(tc)

                tc = New TableCell
                tc.Text = dao_at.fields.ID
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)

                tc = New TableCell
                Try
                    tc.Text = Replace(dao_at.fields.DUCUMENT_NAME, "\n", "<br/>")
                Catch ex As Exception
                    tc.Text = dao_at.fields.DUCUMENT_NAME
                End Try
                tc.Width = 900
                tr.Cells.Add(tc)

                dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(Process, GET_UPLOAD_HEAD_ID, GET_TITEL_ID, GET_TITEL_ID2, _TR_ID, 1)

                If dao_f.fields.HEAD_ID = GET_UPLOAD_HEAD_ID And dao_f.fields.FK_TITEL_ID = GET_TITEL_ID And dao_f.fields.FK_TITEL_ID2 = GET_TITEL_ID2 Then
                    tc = New TableCell
                    tc.Text = dao_f.fields.NAME_REAL
                    tc.Width = 100
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Dim img As New Image
                    Dim AA As String = ""
                    If dao_f.fields.NAME_REAL <> "" Then
                        AA = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/correct.png"
                    Else
                        AA = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/cancel.png"
                    End If

                    img.ImageUrl = AA
                    img.Width = 20
                    img.Height = 20
                    tc.Controls.Add(img)
                    tc.Width = 40
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Dim f As New FileUpload
                    'If _STATUS_ID <> 0 Then
                    '    f.Enabled = True
                    '    tc = New TableCell
                    '    tr.Cells.Add(tc)
                    'Else
                    '    f.ID = "F" & dao_at.fields.ID
                    '    tc.Controls.Add(f)
                    '    'tc.Width = 100
                    '    tr.Cells.Add(tc)
                    'End If
                    f.ID = "F" & dao_at.fields.ID
                    tc.Controls.Add(f)
                    'tc.Width = 100
                    tr.Cells.Add(tc)

                Else
                    tc = New TableCell
                    'tc.Text = dao_f.fields.NAME_REAL
                    tc.Width = 100
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Dim img As New Image
                    Dim AA As String = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/cancel.png"
                    img.ImageUrl = AA
                    img.Width = 20
                    img.Height = 20
                    tc.Controls.Add(img)
                    tc.Width = 40
                    tr.Cells.Add(tc)

                    tc = New TableCell
                    Dim f As New FileUpload
                    'If _STATUS_ID <> 0 Then
                    '    f.Enabled = True
                    '    tc = New TableCell
                    '    tr.Cells.Add(tc)
                    'Else
                    '    f.ID = "F" & dao_at.fields.ID
                    '    tc.Controls.Add(f)
                    '    'tc.Width = 100
                    '    tr.Cells.Add(tc)
                    'End If
                    f.ID = "F" & dao_at.fields.ID
                    tc.Controls.Add(f)
                    'tc.Width = 100
                    tr.Cells.Add(tc)
                End If

                tb_type_menu.Rows.Add(tr)
                rows = rows + 1
            Next
        End If
    End Sub

    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID
        Dim DD_HERB_PROCESS As String = _PROCESS_ID

        If check_file() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else

            'dao.fields.DATE_CONFIRM = Date.Now
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.STATUS_ID = 1
            'dao.fields.STATUS_UPLOAD_ID = 1
            dao.Update()

            alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาออกใบสั่งชำระค่าคำขอ")
            'Response.Redirect(Request.Url.AbsoluteUri)
        End If

    End Sub

    Private Function check_file()

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        'Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Dim dao_check As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID, _PROCESS_ID, 1)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
            End If
        Next

        Return ck_file
    End Function

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = "FRM_LCN_EDIT.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & _IDA & "&IDA_LCN=" & _IDA_LCN
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';parent.close_modal();</script> ")
    End Sub

    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _ProcessID & "&IDA=" & _IDA
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Sub alert_file_error(ByVal text As String)
        Dim url As String = ""
        url = "POPUP_LCN_EDIT_UPLOAD.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & _IDA & "&IDA_LCN=" & _IDA_LCN
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_add_no_Click(sender As Object, e As EventArgs) Handles btn_add_no.Click
        Try
            Dim lcn_edit_process As Integer = 0
            lcn_edit_process = _PROCESS_ID

            Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
            dao.GetDataby_IDA(_IDA)
            Dim ddl1 As Integer = 0
            Dim ddl2 As Integer = 0

            ddl1 = dao.fields.LCN_EDIT_REASON_TYPE
            Try
                ddl2 = dao.fields.FK_SUB_REASON_TYPE
            Catch ex As Exception
                ddl2 = 0
            End Try
            'BindTable()

            'Dim tr As TableRow
            'tr = tb_type_menu.DataBind()
            For Each tr As TableRow In tb_type_menu.Rows
                Dim HEAD_ID As Integer = tr.Cells(0).Text 'เอาข้อมูลช่องแรกมา
                Dim IDA_FILE As Integer = tr.Cells(1).Text 'เอาข้อมูลช่องแรกมา
                Dim GET_SUB_DOC_NAME As String = tr.Cells(2).Text

                Dim f As New FileUpload

                f = tr.FindControl("F" & IDA_FILE)
                If f.HasFile Then
                    Dim name_real As String = f.FileName
                    Dim Array_NAME_REAL() As String = Split(name_real, ".")
                    Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                    Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                    If exten.ToUpper = "PDF" Then
                        Dim bao As New BAO.AppSettings
                        Dim dao_f As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE

                        Dim Name_fake As String = "HB-" & lcn_edit_process & "-" & Date.Now.Year & "-" & IDA_FILE & "-" & _TR_ID & ".pdf"
                        Dim GET_IDA_UPLOAD As Integer = 0
                        If _detial_type = 0 Then
                            dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(lcn_edit_process, HEAD_ID, ddl1, ddl2, _TR_ID, True)
                        ElseIf _detial_type = 2 Then
                            dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID_EDIT_FILE(lcn_edit_process, HEAD_ID, ddl1, ddl2, _TR_ID, _detial_type, True)
                        End If

                        Try
                            GET_IDA_UPLOAD = dao_f.fields.IDA
                        Catch ex As Exception
                            GET_IDA_UPLOAD = 0
                        End Try
                        If GET_IDA_UPLOAD = 0 Then

                            dao_f.fields.FILE_NUMBER_NAME = IDA_FILE
                            dao_f.fields.TR_ID = _TR_ID

                            dao_f.fields.DATE_YEAR = con_year(Date.Now().Year())
                            dao_f.fields.NAME_FAKE = Name_fake
                            dao_f.fields.NAME_REAL = f.FileName
                            dao_f.fields.CREATE_DATE = System.DateTime.Now

                            dao_f.fields.PROCESS_ID = lcn_edit_process
                            dao_f.fields.FK_IDA = _IDA_LCN
                            'dao_f.fields.TYPE = TYPE 'ลำดับไฟล์เก็บไว้เรียกข้อมูล


                            dao_f.fields.TYPE_LOCAL_NAME = dao.fields.LCN_EDIT_REASON_NAME
                            If ddl2 <> 0 Then
                                dao_f.fields.DUCUMENT_NAME = dao.fields.FK_SUB_REASON_NAME
                            End If
                            dao_f.fields.SUB_DOCUMENT_NAME = GET_SUB_DOC_NAME
                            dao_f.fields.HEAD_ID = HEAD_ID
                            dao_f.fields.FK_TITEL_ID = ddl1
                            dao_f.fields.FK_TITEL_ID2 = ddl2
                            dao_f.fields.TYPE = 1

                            dao_f.fields.ACTIVE = 1

                            dao_f.insert()
                        Else
                            dao_f.fields.HEAD_ID = HEAD_ID
                            dao_f.fields.NAME_FAKE = Name_fake
                            dao_f.fields.NAME_REAL = f.FileName
                            dao_f.fields.UPDATE_DATE = System.DateTime.Now

                            dao_f.fields.TYPE = 1

                            dao_f.update()
                        End If

                        'Dim paths As String = bao._PATH_DEFAULT
                        Dim paths As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3")
                        f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                    Else
                        alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                    End If
                End If

            Next

            'เมื่ออัพไฟล์ (เพิ่มเติม) ให้ update status = 8  ;ยื่นเอกสาร (เพิ่มเติม)
            If _STATUS_ID = 9 Then
                Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT
                Dim _YEAR As String = con_year(Date.Now().Year())
                dao_update.GetDataby_LCN_IDA_AND_YEAR_TR_ID_AND_ACTIVE(_IDA_LCN, _YEAR, _TR_ID, True)

                dao_update.fields.STATUS_ID = 11
                dao_update.fields.STATUS_NAME = "ยื่นเอกสาร (เพิ่มเติม)"
                dao_update.fields.UPDATE_DATE = System.DateTime.Now
                dao_update.update()

                bind_pdf_xml_11(dao_update.fields.IDA, _IDA_LCN, dao_update.fields.LCN_PROCESS_ID, dao_update.fields.STATUS_ID, dao_update.fields.DATE_YEAR, dao_update.fields.TR_ID)

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดเรียบร้อยแล้ว');", True)
            End If

            tb_type_menu.Rows.Clear() 'เคลียข้อมูล table 
            'BindTable() 'Upload แล้ว bind tableใหม่
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดไม่สำเร็จ');", True)
        End Try

        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Public Sub bind_pdf_xml_11(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, LCN_IDA, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
End Class
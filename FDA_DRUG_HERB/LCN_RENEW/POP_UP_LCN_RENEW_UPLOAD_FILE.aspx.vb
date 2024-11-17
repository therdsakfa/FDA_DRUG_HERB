Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization
Public Class POP_UP_LCN_RENEW_UPLOAD_FILE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _IDA_PHR As String = ""
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
        _IDA_PHR = Request.QueryString("_IDA_PHR")
        _ProcessID = Request.QueryString("PROCESS_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub

    Public Sub BindTable()

        'Dim dao As New DAO_LCN.TB_DALCN_RENEW
        'dao.GET_DATA_BY_IDA(_IDA)
        'Dim tr_id As Integer = 0
        'Try
        '    tr_id = dao.fields.TR_ID
        'Catch ex As Exception

        'End Try

        'Dim url_img As New BAO.AppSettings
        'Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        'Dim dao_att As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        'Dim group As Integer = 0

        'dao_f.GetDataby_TR_ID(tr_id)

        'Dim rows As Integer = 1
        'For Each dao_f.fields In dao_f.datas


        '    Dim tr As New TableRow
        '    tr.CssClass = "rows"
        '    Dim tc As New TableCell

        '    tc = New TableCell
        '    tc.Text = rows
        '    tr.Cells.Add(tc)

        '    tc = New TableCell
        '    tc.Text = dao_f.fields.IDA
        '    tc.Style.Add("display", "none")
        '    tr.Cells.Add(tc)

        '    tc = New TableCell
        '    Try
        '        tc.Text = Replace(dao_f.fields.DOCUMENT_NAME, "\n", "<br/>")
        '    Catch ex As Exception
        '        tc.Text = dao_f.fields.DOCUMENT_NAME
        '    End Try
        '    tc.Width = 900
        '    tr.Cells.Add(tc)

        '    tc = New TableCell
        '    Dim H As New HyperLink
        '    H.Target = "_blank"
        '    H.Text = dao_f.fields.NAME_REAL
        '    Dim NameReal As String = "คำรับรองของผู้มีหน้าที่ปฏิบัติการ"
        '    'If isnothing(dao_f.fields.NAME_REAL) = False Then
        '    '    NameReal = dao_f.fields.NAME_REAL
        '    'End If
        '    If IsNothing(dao_f.fields.NAME_REAL) = False Then
        '        If dao_f.fields.NAME_REAL.Contains(NameReal) Then
        '            H.NavigateUrl = "../LCN_PHR/FRM_PHR_HERB_PREVIEW.aspx?ida=" & _IDA_PHR
        '        Else
        '            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & _IDA
        '        End If
        '    End If
        '    H.Width = 300
        '    tc.Controls.Add(H)
        '    tr.Cells.Add(tc)

        '    tc = New TableCell
        '    Dim img As New Image
        '    If dao_f.fields.NAME_REAL Is Nothing OrElse dao_f.fields.NAME_REAL = "" Then
        '        Dim AA As String = "../Images/cancel.png"
        '        img.ImageUrl = AA
        '        img.Width = 20
        '        img.Height = 20
        '    Else
        '        Dim AA As String = "../Images/correct.png"
        '        img.ImageUrl = AA
        '        img.Width = 20
        '        img.Height = 20
        '    End If
        '    tc.Controls.Add(img)
        '    tr.Cells.Add(tc)

        '    tc = New TableCell
        '    Dim f As New FileUpload
        '    f.ID = "F" & dao_f.fields.IDA
        '    tc.Controls.Add(f)
        '    tr.Cells.Add(tc)

        '    tb_type_menu.Rows.Add(tr)
        '    rows = rows + 1
        'Next
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Dim dao_p As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao_p.GET_DATA_BY_FK_LCN(_IDA_LCN, True)
        If dao_p.fields.Check_Confirm_Y = 1 Then
            _Condition = "N"
        Else
            _Condition = "Y"
        End If

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
            dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_V3(tr_id, 1)
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
            Dim SEQ_ID As String = SUB_MAIN_MENU
            Dim TITEL_ID As String = dr("TITEL_ID")

            'If dao_f.fields.DOCUMENT_NAME = "สำเนาทะเบียนบ้าน" Then
            '    SEQ_ID = 8.1
            'ElseIf dao_f.fields.DOCUMENT_NAME = "หนังสือยินยอมให้ใช้สถานที่ (กรณีไม่ได้เป็นเจ้าของกรรมสิทธ์)" Then
            '    SEQ_ID = 8.2
            'ElseIf dao_f.fields.DOCUMENT_NAME = "สัญญาซื้อขายสิ่งปลูกสร้าง/ใบอนุญาตก่อสร้าง/เอกสารอ้างกรรมสิทธ์ (กรณีทะเบียนบ้านไม่มีผู้อยู่อาศัย)" Then
            '    SEQ_ID = 8.3
            'Else
            '    SEQ_ID = rows
            'End If
            'If SUB_MAIN_MENU = 8 Then
            '    SEQ_ID = SUB_MAIN_MENU
            'Else
            '    SEQ_ID = rows
            'End If
            tc.Text = SUB_MAIN_MENU
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)
            tc = New TableCell
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
            tc.Width = 900
            tr.Cells.Add(tc)

            'If dr("TITEL_ID") = 1 Then
            '    tc = New TableCell
            '    Try
            '        tc.Text = "*"
            '        tc.Style.Add("coler", "RED")
            '    Catch ex As Exception
            '    End Try
            '    tc.Width = 10
            '    tr.Cells.Add(tc)
            'End If

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
    Protected Sub BTN_CONFIRM_Click(sender As Object, e As EventArgs) Handles BTN_SUBMIT.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        If check_file() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            'Dim script As String = "showCustomDialog();"
            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowModal", script, True)
            Dim Checked_yes As Boolean = RDO_YES.Checked
            Dim Checked_no As Boolean = RDO_NO.Checked
            If Checked_yes = True Then
                'If check_file() = False Then
                '    alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
                'Else
                dao.fields.STATUS_UPLOAD_ID = 1
                dao.fields.Check_Confirm_Y = Checked_yes
                'dao.fields.CREATE_ID = _CLS.CITIZEN_ID
                dao.fields.CREATE_DATE = Date.Now
                dao.fields.UPDATE_DATE = DateTime.Now
                dao.update()
                alert_summit("กรุณาตรวจสอบข้อมูลก่อนยื่นคำขอ", _IDA, dao.fields.FK_LCN)
                'End If
            End If
            If Checked_no = True Then
                dao.fields.STATUS_UPLOAD_ID = 1
                dao.fields.Check_Confirm_N = Checked_no
                dao.fields.STATUS_ID = 15
                'dao.fields.CREATE_ID = _CLS.CITIZEN_ID
                dao.fields.CREATE_DATE = Date.Now
                dao.update()
                alert("สถานที่ผลิตของท่านไม่เป็นไปตามข้อกำหนด ไม่สามารถยื่นคำขอต่ออายุใบอนุญาตฯ ได้")
            End If
        End If
    End Sub
    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        If check_file() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            dao.fields.STATUS_UPLOAD_ID = 1
            dao.fields.STATUS_ID = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.UPDATE_DATE = DateTime.Now
            dao.update()
            alert_summit("กรุณาตรวจสอบข้อมูลก่อนยื่นคำขอ", _IDA, dao.fields.FK_LCN)
        End If

        'Dim script As String = "showCustomDialog();"
        'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ShowModal", script, True)
        'Dim Checked_yes As Boolean = RDO_YES.Checked
        'Dim Checked_no As Boolean = RDO_NO.Checked
        'If Checked_yes = True Then
        '    If check_file() = False Then
        '        alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        '    Else
        '        dao.fields.STATUS_UPLOAD_ID = 1
        '        dao.fields.Check_Confirm_Y = Checked_yes
        '        dao.update()
        '        alert_summit("กรุณาตรวจสอบข้อมูลก่อนยื่นคำขอ", _IDA, dao.fields.FK_LCN)
        '    End If
        'End If
        'If Checked_no = True Then
        '    dao.fields.STATUS_UPLOAD_ID = 1
        '    dao.fields.Check_Confirm_N = Checked_no
        '    dao.fields.STATUS_ID = 15
        '    dao.update()
        '    alert("สถานที่ผลิตของท่านไม่เป็นไปตามข้อกำหนด ไม่สามารถยื่นคำขอต่ออายุใบอนุญาตฯ ได้")
        'End If
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer, ByVal ida_lcn As Integer)
        Dim url As String = ""
        url = "POP_UP_LCN_RENEW_CONFIRM.aspx?IDA=" & ida & "&PROCESS_ID=" & _ProcessID & "&IDA_LCN=" & ida_lcn
        Response.Write("<script type='text/javascript'>window.location='" & url & "';</script> ")
        'Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Sub Blind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        'Dim _ProcessID As String = 10501
        Dim XML As New CLASS_GEN_XML.DALCN_RENEW
        LCN_RENEW = XML.Gen_XML_LCN_RENEW(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, 1, "สมพ5", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_RENREW") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PDF", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("XML", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Function check_file()

        Dim dao As New DAO_LCN.TB_DALCN_RENEW
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
    Protected Sub btn_add_no_Click(sender As Object, e As EventArgs) Handles btn_add_no.Click
        Dim tr_id As Integer = 0
        'Dim PROCESS_ID As Integer = 10104
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        tr_id = dao.fields.TR_ID

        For Each tr As TableRow In tb_type_menu.Rows
            Dim IDA As Integer = tr.Cells(1).Text

            Dim f As New FileUpload
            Try
                f = tr.FindControl("F" & IDA)
                If f.HasFile Then
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
            Catch ex As Exception

            End Try
        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    'Private Function check_file()

    '    Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
    '    dao.GetdatabyID_IDA_PROCESS(_IDA, _PROCESS_JJ)
    '    Dim TR_ID_JJ As Integer = dao.fields.TR_ID_JJ

    '    Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
    '    dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID_JJ, _PROCESS_JJ, 1)

    '    Dim ck_file As Boolean = True

    '    For Each dao_check.fields In dao_check.datas
    '        If dao_check.fields.NAME_FAKE Is Nothing Then
    '            ck_file = False
    '            Exit For
    '        End If
    '    Next

    '    Return ck_file
    'End Function

End Class
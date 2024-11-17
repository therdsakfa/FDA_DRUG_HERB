Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _DD_HERB_NAME_ID As String = ""
    Private _PROCESS_JJ As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _SID As String = ""

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
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")
        _PROCESS_JJ = Request.QueryString("PROCESS_JJ")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _SID = Request.QueryString("SID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub

    Public Sub BindTable()

        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        'dao_jj.GetdatabyID_IDA_LCN(_IDA_LCN, _DD_HERB_NAME_ID)
        dao_jj.GetdatabyID_IDA(_IDA)
        Dim TR_ID_JJ As Integer = 0
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        If dao_jj.fields.TR_ID_JJ <> 0 Then
            TR_ID_JJ = dao_jj.fields.TR_ID_JJ
            'dao_up.GetdatabyID_TR_ID(TR_ID_JJ)
            'dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(TR_ID_JJ, _PROCESS_JJ, 1)
            dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(_IDA, TR_ID_JJ, _PROCESS_JJ, 1)

            Dim rows As Integer = 1
            For Each dao_up.fields In dao_up.datas
                Dim tr As New TableRow
                tr.CssClass = "rows"
                Dim tc As New TableCell

                tc = New TableCell
                tc.Text = rows
                tr.Cells.Add(tc)

                tc = New TableCell
                tc.Text = dao_up.fields.IDA
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)

                tc = New TableCell
                Try
                    tc.Text = Replace(dao_up.fields.DUCUMENT_NAME, "\n", "<br/>")
                Catch ex As Exception
                    tc.Text = dao_up.fields.DUCUMENT_NAME
                End Try
                tc.Width = 900
                tr.Cells.Add(tc)

                tc = New TableCell
                'tc.Text = dao_up.fields.NAME_REAL
                Try
                    tc.Text = dao_up.fields.NAME_REAL
                Catch ex As Exception
                    tc.Text = ""
                End Try
                tc.Width = 100
                tr.Cells.Add(tc)

                tc = New TableCell
                tc.Width = 50
                Dim img As New Image
                Try
                    If dao_up.fields.NAME_REAL Is Nothing OrElse dao_up.fields.NAME_REAL = "" Then
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
                Catch ex As Exception

                End Try
                tc.Controls.Add(img)
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim f As New FileUpload
                f.ID = "F" & dao_up.fields.IDA
                tc.Controls.Add(f)
                tr.Cells.Add(tc)

                tb_type_menu.Rows.Add(tr)
                rows = rows + 1
            Next

        End If

    End Sub

    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA_LCN(_IDA_LCN, _DD_HERB_NAME_ID)
        Dim TR_ID_JJ As Integer = dao.fields.TR_ID_JJ
        Dim DD_HERB_PROCESS As String = _PROCESS_JJ

        'For Each tr As TableRow In tb_type_menu.Rows
        '    Dim IDA As Integer = tr.Cells(1).Text

        '    Dim f As New FileUpload
        '    f = tr.FindControl("F" & IDA)
        '    If f.HasFile Then
        '        Dim name_real As String = f.FileName
        '        Dim Array_NAME_REAL() As String = Split(name_real, ".")
        '        Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
        '        Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
        '        If exten.ToUpper = "PDF" Then
        '            Dim bao As New BAO.AppSettings
        '            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        '            Dim Name_fake As String = "HB-" & _PROCESS_JJ & "-" & Date.Now.Year & "-" & TR_ID_JJ & "-" & IDA & ".pdf"

        '            dao_up.GetdatabyID_IDA(IDA)

        '            dao_up.fields.NAME_FAKE = Name_fake
        '            dao_up.fields.NAME_REAL = f.FileName
        '            dao_up.fields.CREATE_DATE = Date.Now
        '            dao_up.fields.FK_IDA = dao.fields.IDA
        '            dao_up.fields.FK_IDA_LCN = _IDA_LCN
        '            dao_up.fields.CREATE_DATE = Date.Now
        '            dao_up.fields.ACTIVE = 1

        '            Try
        '                dao_up.fields.TR_ID = _TR_ID_LCN
        '            Catch ex As Exception

        '            End Try

        '            dao_up.fields.PROCESS_ID = _PROCESS_JJ

        '            dao_up.Update()

        '            Dim paths As String = bao._PATH_XML_PDF_TABEAN_JJ
        '            f.SaveAs(paths & "UPLOAD_FILE_JJ\" & Name_fake)
        '        Else
        '            alert_file_error(name_real & "กรุณาแนบเป็นไฟล์ PDF")
        '            'alert_no_file(name_real & "กรุณาแนบเป็นไฟล์ PDF")
        '        End If
        '    End If

        'Next

        If check_file() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else

            dao.fields.DATE_CONFIRM = Date.Now
            dao.fields.STATUS_ID = 1
            dao.Update()

            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(_PROCESS_JJ, dao.fields.IDA, dao.fields.STATUS_ID)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
            TB_JJ = XML.gen_xml(_IDA, _IDA_LCN)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_PROCESS_JJ, dao.fields.STATUS_ID, "จจ1", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ1\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _PROCESS_JJ, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _PROCESS_JJ, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_JJ, PATH_PDF_OUTPUT)

            _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
            _CLS.PDFNAME = PATH_PDF_OUTPUT
            _CLS.FILENAME_XML = Path_XML

            alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาออกใบสั่งชำระค่าคำขอ")
            'Response.Redirect(Request.Url.AbsoluteUri)
        End If

    End Sub

    Private Function check_file()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA_PROCESS(_IDA, _PROCESS_JJ)
        Dim TR_ID_JJ As Integer = dao.fields.TR_ID_JJ

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID_JJ, _PROCESS_JJ, 1)

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
        url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&SID=" & _SID & "&identify=" & Request.QueryString("identify") & "&SID=" & Request.QueryString("SID")
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';parent.close_modal();</script> ")
    End Sub

    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _ProcessID & "&IDA=" & _IDA
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Sub alert_file_error(ByVal text As String)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&SID=" & _SID & "&identify=" & Request.QueryString("identify") & "&SID=" & Request.QueryString("SID")
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_add_no_Click(sender As Object, e As EventArgs) Handles btn_add_no.Click

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        'dao.GetdatabyID_IDA_LCN(_IDA_LCN, _DD_HERB_NAME_ID)
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID_JJ As Integer = dao.fields.TR_ID_JJ
        Dim DD_HERB_PROCESS As String = _PROCESS_JJ

        For Each tr As TableRow In tb_type_menu.Rows
            Dim IDA As Integer = tr.Cells(1).Text

            Dim f As New FileUpload
            f = tr.FindControl("F" & IDA)
            If f.HasFile Then
                Dim name_real As String = f.FileName
                Dim Array_NAME_REAL() As String = Split(name_real, ".")
                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                If exten.ToUpper = "PDF" Then
                    Dim bao As New BAO.AppSettings
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    Dim Name_fake As String = "HB-" & _PROCESS_JJ & "-" & Date.Now.Year & "-" & TR_ID_JJ & "-" & IDA & ".pdf"

                    dao_up.GetdatabyID_IDA(IDA)

                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.ACTIVE = 1S

                    Try
                        dao_up.fields.TR_ID = TR_ID_JJ
                    Catch ex As Exception

                    End Try

                    dao_up.fields.PROCESS_ID = _PROCESS_JJ

                    dao_up.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_JJ
                    f.SaveAs(paths & "UPLOAD_FILE_JJ\" & Name_fake)
                Else
                    alert_file_error(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                    'alert_no_file(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If

        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
End Class
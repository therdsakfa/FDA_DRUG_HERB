Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization
Public Class POP_UP_LCN_RENEW_UPLOAD_FILE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _IDA_LCN As String = ""
    Private _ProcessID As String = ""

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
        _ProcessID = Request.QueryString("PROCESS_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub

    Public Sub BindTable()

        Dim dao As New DAO_LCN.TB_DALCN_RENEW
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

        dao_f.GetDataby_TR_ID(tr_id)

        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas


            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.DUCUMENT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.DUCUMENT_NAME
            End Try
            tc.Width = 900
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.NAME_REAL
            tc.Width = 100
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim img As New Image
            If dao_f.fields.NAME_REAL Is Nothing OrElse dao_f.fields.NAME_REAL = "" Then
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

            tc = New TableCell
            Dim f As New FileUpload
            f.ID = "F" & dao_f.fields.IDA
            tc.Controls.Add(f)
            tr.Cells.Add(tc)

            tb_type_menu.Rows.Add(tr)
            rows = rows + 1
        Next
    End Sub

    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
        If check_file() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            Dim dao As New DAO_LCN.TB_DALCN_RENEW
            dao.GET_DATA_BY_IDA(_IDA)
            dao.fields.STATUS_UPLOAD_ID = 1
            dao.update()
            alert("แนบไฟล์แล้ว กรุณากดดูข้อมูลเพื่อตรวจสอบความถูกต้องก่อนยื่นคำขอ")
        End If
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
            If dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
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
            f = tr.FindControl("F" & IDA)
            If f.HasFile Then
                Dim name_real As String = f.FileName
                Dim Array_NAME_REAL() As String = Split(name_real, ".")
                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                If exten.ToUpper = "PDF" Then
                    Dim bao As New BAO.AppSettings
                    Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    dao_f.GetDataby_IDA(IDA)

                    Dim Name_fake As String = "RNW-" & _ProcessID & "-" & Date.Now.Year & "-" & tr_id & ".pdf"
                    dao_f.fields.NAME_FAKE = Name_fake
                    dao_f.fields.NAME_REAL = f.FileName
                    dao_f.fields.CREATE_DATE = Date.Now
                    dao_f.update()

                    Dim paths As String = bao._PATH_XML_PDF_LCN_RENREW
                    f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                Else
                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If

            End If


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
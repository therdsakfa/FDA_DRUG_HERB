Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization

Public Class POPUP_HERB_TABEAN_INFORM_UPLOAD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID As String = ""
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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _SID = Request.QueryString("SID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub

    Public Sub BindTable()

        Dim dao_inform As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao_inform.GetdatabyID_IDA(_IDA)

        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Dim TR_ID As Integer = 0

        If dao_inform.fields.TR_ID <> 0 Then
            TR_ID = dao_inform.fields.TR_ID
            'dao_up.GetdatabyID_TR_ID(TR_ID)
            'dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(TR_ID, _PROCESS_ID, 7)
            dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(_IDA, TR_ID, _PROCESS_ID, 1)

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
                tc.Width = 50
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

        Dim dao_inform As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao_inform.GetdatabyID_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_INFORM_DETAIL
        dao.GetdatabyID_FK_IDA(_IDA)

        Dim TR_ID As Integer = dao_inform.fields.TR_ID
        Dim DD_HERB_PROCESS As String = dao_inform.fields.PROCESS_ID

        'If Request.QueryString("staff") = "1" And check_file() = False Then
        '    'alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        '    alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาชำระค่าคำขอ")
        'ElseIf check_file() = True Then
        dao_inform.fields.DATE_CONFIRM = Date.Now
            dao_inform.fields.NAME_CONFIRM = _CLS.THANM
            dao_inform.fields.STATUS_ID = 1
            dao_inform.fields.STATUS_UPLOAD_ID = 1
            dao_inform.Update()

            dao.fields.DATE_CONFIRM = Date.Now
            dao.fields.NAME_CONFIRM = _CLS.THANM
            dao.fields.STATUS_ID = 1
            dao.Update()

            Dim XML As New CLASS_GEN_XML.TABEAN_INFORM
            TBN_INFORM = XML.GEN_XML_INFORM(_IDA, _IDA_LCN)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_PROCESS_ID, dao_inform.fields.STATUS_ID, "จร1", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_INFORM") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", _PROCESS_ID, Date.Now.Year, _IDA)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", _PROCESS_ID, Date.Now.Year, _IDA)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID, PATH_PDF_OUTPUT)

            _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
            _CLS.PDFNAME = PATH_PDF_OUTPUT
            _CLS.FILENAME_XML = Path_XML

            alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาชำระค่าคำขอ")
        'Response.Redirect(Request.Url.AbsoluteUri)

        'Else
        '    alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        '    ' alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาชำระค่าคำขอ")
        'End If

    End Sub

    Private Function check_file()

        Dim dao_inform As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao_inform.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao_inform.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID, _PROCESS_ID, 7)

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
        url = "FRM_HERB_TABEAN_INFORM.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA & "&PROCESS_ID_DQ=" & _PROCESS_ID & "&staff=" & Request.QueryString("staff") & "&SID=" & _SID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Sub alert_file_error(ByVal text As String)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_INFORM_UPLOAD.aspx?MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA & "&PROCESS_ID_DQ=" & _PROCESS_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_add_no_Click(sender As Object, e As EventArgs) Handles btn_add_no.Click
        Dim dao_inform As New DAO_TABEAN_HERB.TB_TABEAN_INFORM
        dao_inform.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao_inform.fields.TR_ID
        Dim PROCESS_ID As String = dao_inform.fields.PROCESS_ID
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
                    Dim Name_fake As String = "HB-" & PROCESS_ID & "-" & Date.Now.Year & "-" & TR_ID & "-" & IDA & ".pdf"
                    dao_up.GetdatabyID_IDA(IDA)

                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = _IDA
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.ACTIVE = 1
                    dao_up.fields.PROCESS_ID = PROCESS_ID
                    dao_up.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_INFORM
                    f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                Else
                    alert_file_error(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If

        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

End Class
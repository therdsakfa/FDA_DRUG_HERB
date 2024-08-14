Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_HERB_TABEAN_ADD_DETAIL_UPLOAD_FILE
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA_DQ As String = ""
    Private _PROCESS_ID_DQ As String = ""
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
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _IDA_DQ = Request.QueryString("IDA_DQ")
        _PROCESS_ID_DQ = Request.QueryString("PROCESS_ID_DQ")
        _SID = Request.QueryString("SID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub

    Public Sub BindTable()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)

        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Dim TR_ID As Integer = 0

        If dao_deeqt.fields.TR_ID <> 0 Then
            TR_ID = dao_deeqt.fields.TR_ID
            'dao_up.GetdatabyID_TR_ID(TR_ID)
            'dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(TR_ID, _PROCESS_ID_DQ, 7)
            dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(_IDA_DQ, TR_ID, _PROCESS_ID_DQ, 7)

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

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Dim TR_ID As Integer = dao_deeqt.fields.TR_ID
        Dim DD_HERB_PROCESS As String = dao_deeqt.fields.PROCESS_ID

        If Request.QueryString("staff") = "1" And check_file() = False Then
            'alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
            alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาชำระค่าคำขอ")
        ElseIf check_file() = True Then

            'Dim RCVNO As Integer
            'Dim bao_gen As New BAO.GenNumber
            'RCVNO = bao_gen.GEN_NO_TBN(con_year(Date.Now.Year), dao_deeqt.fields.pvncd, 1, _IDA_DQ, dao_deeqt.fields.FK_LCN_IDA)
            'Dim DATE_YEAR As String = con_year(Date.Now.Year).Substring(2, 2)
            'Dim RCVNO_FULL As String = "HB" & " " & dao_deeqt.fields.pvncd & "-" & _PROCESS_ID_DQ & "-" & DATE_YEAR & "-" & RCVNO
            'dao_deeqt.fields.RCVNO_NEW = RCVNO_FULL

            dao_deeqt.fields.DATE_CONFIRM = Date.Now
            dao_deeqt.fields.NAME_CONFIRM = _CLS.THANM
            dao_deeqt.fields.STATUS_ID = 1
            dao_deeqt.update()

            dao.fields.DATE_CONFIRM = Date.Now
            dao.fields.NAME_CONFIRM = _CLS.THANM
            dao.fields.STATUS_ID = 1
            dao.Update()

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
            TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA_DQ, _IDA_LCN)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_PROCESS_ID_DQ, dao.fields.STATUS_ID, "ทบ1", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _PROCESS_ID_DQ, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_DQ, dao_deeqt.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _PROCESS_ID_DQ, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_DQ, dao_deeqt.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID_DQ, PATH_PDF_OUTPUT)

            _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
            _CLS.PDFNAME = PATH_PDF_OUTPUT
            _CLS.FILENAME_XML = Path_XML

            alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาชำระค่าคำขอ")
            'Response.Redirect(Request.Url.AbsoluteUri)

        Else
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
            ' alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาชำระค่าคำขอ")
        End If

    End Sub

    Private Function check_file()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)
        Dim TR_ID As Integer = dao_deeqt.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID, _PROCESS_ID_DQ, 7)

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
        url = "FRM_HERB_TABEAN.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ & "&staff=" & Request.QueryString("staff") & "&SID=" & _SID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _ProcessID & "&IDA=" & _IDA
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Sub alert_file_error(ByVal text As String)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_ADD_DETAIL_UPLOAD_FILE.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_add_no_Click(sender As Object, e As EventArgs) Handles btn_add_no.Click
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)

        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        'dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Dim TR_ID As Integer = dao_deeqt.fields.TR_ID
        Dim PROCESS_ID As String = dao_deeqt.fields.PROCESS_ID

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
                    'dao_up.fields.FK_IDA = dao.fields.IDA
                    'dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.ACTIVE = 1

                    Try
                        dao_up.fields.TR_ID = TR_ID
                    Catch ex As Exception

                    End Try

                    dao_up.fields.PROCESS_ID = PROCESS_ID

                    dao_up.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_TBN
                    f.SaveAs(paths & "UPLOAD_PDF_TABEAN_TBN\" & Name_fake)
                Else
                    alert_file_error(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If

        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

End Class
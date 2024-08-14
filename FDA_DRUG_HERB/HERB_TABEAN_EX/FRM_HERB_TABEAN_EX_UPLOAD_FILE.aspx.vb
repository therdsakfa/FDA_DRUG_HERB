Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization
Public Class FRM_HERB_TABEAN_EX_UPLOAD_FILE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _IDA_EX As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID_LCN As String = ""

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
        _IDA_EX = Request.QueryString("IDA_EX")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub

    Public Sub BindTable()

        Dim dao_ex As New DAO_DRUG.ClsDBdrsamp
        dao_ex.GetDataby_IDA(_IDA_EX)
        Dim TR_ID_EX As Integer = 0
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        If dao_ex.fields.TR_ID <> 0 Then
            TR_ID_EX = dao_ex.fields.TR_ID
            'dao_up.GetdatabyID_TR_ID(TR_ID_JJ)
            dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(TR_ID_EX, dao_ex.fields.process_id, 17)

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
                tc.Width = 300
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

        Dim dao_ex As New DAO_DRUG.ClsDBdrsamp
        dao_ex.GetDataby_IDA(_IDA_EX)
        Dim TR_ID_EX As Integer = dao_ex.fields.TR_ID
        Dim PROCESS_ID As String = dao_ex.fields.process_id

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
                    Dim Name_fake As String = "HB-" & PROCESS_ID & "-" & Date.Now.Year & "-" & TR_ID_EX & "-" & IDA & ".pdf"

                    dao_up.GetdatabyID_IDA(IDA)

                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = dao_ex.fields.IDA
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.ACTIVE = 1

                    Try
                        dao_up.fields.TR_ID = dao_ex.fields.TR_ID
                    Catch ex As Exception

                    End Try

                    dao_up.fields.PROCESS_ID = PROCESS_ID

                    dao_up.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_EX
                    f.SaveAs(paths & "UPLOAD_PDF_TABEAN_EX\" & Name_fake)
                Else
                    alert_file_error(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                    'alert_no_file(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If

        Next

        If Request.QueryString("staff") = "1" And check_file() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
            Response.Redirect(Request.Url.AbsoluteUri)
        Else

            Dim TR_ID As String = dao_ex.fields.TR_ID
            Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            Dim RCVNO_FULL As String = "HB" & " " & dao_ex.fields.pvncd & "-" & PROCESS_ID & "-" & DATE_YEAR & "-" & TR_ID

            'dao_ex.fields.RCVNO_FULL = RCVNO_FULL

            'ยื่นคำขอ รอชำระเงิน
            'dao.fields.STATUS_ID = 2
            'dao.fields.DATE_CONFIRM = Date.Now
            'ชำระเงิน รอตรวจรับคำขอ
            'dao.fields.DATE_CONFIRM = Date.Now
            'dao.fields.STATUS_ID = 1
            dao_ex.update()

            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(PROCESS_ID, dao_ex.fields.IDA, dao_ex.fields.STATUS_ID)

            alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณากดดูรายละเอียดเพื่อยื่นคำขอ")

            'Response.Redirect(Request.Url.AbsoluteUri)
        End If

    End Sub

    Private Function check_file()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA_EX)
        Dim TR_ID_EX As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID_EX, dao.fields.process_id, 17)

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
        url = "FRM_HERB_TABEAN_EX.aspx?IDA_LCN=" & _IDA_LCN & "&IDA=" & _IDA_EX & "&PROCESS_ID=" & _PROCESS_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _ProcessID & "&IDA=" & _IDA
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Sub alert_file_error(ByVal text As String)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_EX_UPLOAD_FILE.aspx?IDA_LCN=" & _IDA_LCN & "&IDA=" & _IDA_EX & "&PROCESS_ID=" & _PROCESS_ID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
End Class
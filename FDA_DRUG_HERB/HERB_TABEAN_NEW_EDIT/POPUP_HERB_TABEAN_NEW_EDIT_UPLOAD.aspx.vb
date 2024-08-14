Public Class POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
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

        _IDA_LCT = Request.QueryString("IDA_LCT")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _IDA_DR = Request.QueryString("IDA_DR")
        _SID = Request.QueryString("SID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then

        End If
    End Sub

    Public Sub BindTable()

        Dim dao_sub As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao_sub.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = 0
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        If dao_sub.fields.TR_ID <> 0 Then
            TR_ID = dao_sub.fields.TR_ID
            'dao_up.GetdatabyID_TR_ID(TR_ID_JJ)
            'dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(TR_ID_JJ, _PROCESS_ID, 1)
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

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID
        Dim DD_HERB_PROCESS As String = _PROCESS_ID

        If Request.QueryString("staff") = "1" And check_file() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            If Request.QueryString("staff") = "1" Then
                dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
                dao.fields.INOFFICE_STAFF_ID = 1
            End If
            dao.fields.DATE_CONFIRM = Date.Now
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_BY = _CLS.CITIZEN_ID
            'dao.fields.IDENTIFY = _CLS.CITIZEN_ID
            dao.fields.DATE_YEAR = con_year(Date.Now.Year)
            dao.fields.STATUS_ID = 1
            dao.fields.STATUS_UPLOAD_ID = 1
            dao.Update()

            alert_normal("แนบไฟล์เรียบร้อยแล้ว กรุณาออกใบสั่งชำระค่าคำขอ")
            'Response.Redirect(Request.Url.AbsoluteUri)
        End If

    End Sub

    Private Function check_file()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
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
        url = "FRM_HERB_TABEAN_NEW_EDIT.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & _IDA & "&SID=" & _SID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';parent.close_modal();</script> ")
    End Sub

    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _ProcessID & "&IDA=" & _IDA
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Sub alert_file_error(ByVal text As String)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _PROCESS_ID & "&IDA=" & _IDA & "&SID=" & _SID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_add_no_Click(sender As Object, e As EventArgs) Handles btn_add_no.Click

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID
        Dim DD_HERB_PROCESS As String = _PROCESS_ID

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
                    Dim Name_fake As String = "HB-" & _PROCESS_ID & "-" & Date.Now.Year & "-" & TR_ID & "-" & IDA & ".pdf"

                    dao_up.GetdatabyID_IDA(IDA)

                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    '   dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.ACTIVE = 1

                    Try
                        dao_up.fields.TR_ID = TR_ID
                    Catch ex As Exception

                    End Try

                    dao_up.fields.PROCESS_ID = _PROCESS_ID

                    dao_up.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_EDIT
                    f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                Else
                    alert_file_error(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                    'alert_no_file(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If

        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
End Class
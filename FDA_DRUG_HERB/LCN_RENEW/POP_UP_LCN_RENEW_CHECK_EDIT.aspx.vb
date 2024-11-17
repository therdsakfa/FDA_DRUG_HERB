Public Class POP_UP_LCN_RENEW_CHECK_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String = ""
    Private _IDA_LCN As Integer
    Private _IDA As Integer
    Private _IDEN As String
    Private _TR_ID As String = ""
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        BindTable()
        If Not IsPostBack Then
            Get_data()
        End If
    End Sub
    Sub Get_data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        If IsNothing(dao.fields.head_menu_normal) = False Then CheckBox_lcn.Checked = dao.fields.head_menu_normal
        If IsNothing(dao.fields.head_menu_bsn) = False Then CheckBox_Bsn.Checked = dao.fields.head_menu_bsn
        If IsNothing(dao.fields.head_menu_phr) = False Then CheckBox_Phr.Checked = dao.fields.head_menu_phr
        If IsNothing(dao.fields.head_menu_lo) = False Then CheckBox_Location.Checked = dao.fields.head_menu_lo
        If IsNothing(dao.fields.head_menu_lo_keep) = False Then CheckBox_Keep.Checked = dao.fields.head_menu_lo_keep
        If IsNothing(dao.fields.head_menu_drug_group) = False Then CheckBox_Drug_Group.Checked = dao.fields.head_menu_drug_group
        txt_note_edit.Text = dao.fields.Note_Edit
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
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        Dim dao_att As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        Dim group As Integer = 0

        dao_up.GetDataby_TR_ID(tr_id)

        If _TR_ID <> 0 Then

            'dao_up.GetdatabyID_IDA_TYPE(_IDA, 2)
            dao_up.GetDaTaby_FK_TR_PROCECSS_And_TYPE_ID_AND_DOC_ID2(_IDA, _TR_ID, _ProcessID, 1, 684, 685)
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

                tc = New TableCell()
                Dim DOCUMENT_NAME As String = dao_up.fields.DOCUMENT_NAME
                Try
                    Dim documentName As String = DOCUMENT_NAME
                    ' Set text and style based on condition
                    If Convert.ToBoolean(dao_up.fields.Forcible) = True Then
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

                '    tc = New TableCell
                '    tc.Text = dao_up.fields.NAME_REAL
                'tc.Width = 400
                'tr.Cells.Add(tc)
                tc = New TableCell
                Dim h As New HyperLink
                Dim urls As String = ""
                h.ID = "H" & dao_up.fields.IDA
                If dao_up.fields.NAME_REAL Is Nothing OrElse dao_up.fields.NAME_REAL = "" Then
                    h.Style.Add("display", "none")
                Else
                    h.Style.Add("display", "block")
                End If
                urls = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & dao_up.fields.IDA
                h.Target = "_blank"
                h.NavigateUrl = urls
                h.Text = dao_up.fields.NAME_REAL
                tc.Width = 100
                tc.Controls.Add(h)
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim img As New Image
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

        Dim TR_ID As Integer = _TR_ID
        Dim DD_HERB_PROCESS As String = _ProcessID

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
                    Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    Dim Name_fake As String = "HB-" & DD_HERB_PROCESS & "-" & Date.Now.Year & "-" & TR_ID & "-" & IDA & ".pdf"
                    dao_up.GetDataby_IDA(IDA)
                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = _IDA
                    'dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    'dao_up.fields.ACTIVE = 1
                    Try
                        dao_up.fields.TR_ID = TR_ID
                    Catch ex As Exception

                    End Try
                    dao_up.fields.PROCESS_ID = DD_HERB_PROCESS
                    dao_up.update()
                    Dim paths As String = bao._PATH_XML_PDF_LCN_RENREW
                    f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                Else
                    'alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If
        Next

        If check_file() = False Then
            alert_normal("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            'alert_normal("แนบไฟล์เรียบร้อยแล้ว กดบันทึก")
            Response.Redirect(Request.Url.AbsoluteUri)
            'BindTable()
        End If

        'alert_normal("แนบไฟล์เรียบร้อยแล้ว")

    End Sub

    Private Function check_file()
        Dim CHK_UPLOAD1 As String = "ใบอนุญาตสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร"
        Dim CHK_UPLOAD2 As String = "หนังสือรับรองการผ่านการอบรมหลักสูตรผู้มีหน้าที่ปฏิบัติการ"
        Dim dao_check As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_check.GetDaTaby_FK_TR_PROCECSS_And_TYPE_ID(_IDA, _TR_ID, _ProcessID, 1)
        Dim ck_file As Boolean = True
        For Each dao_check.fields In dao_check.datas
            If CheckBox_Phr.Checked = True Then
                If dao_check.fields.DOCUMENT_NAME = CHK_UPLOAD1 Or dao_check.fields.DOCUMENT_NAME.Contains(CHK_UPLOAD2) Then
                    If dao_check.fields.NAME_FAKE Is Nothing Then
                        ck_file = False
                        Exit For
                    End If
                End If
            Else
                If dao_check.fields.DOCUMENT_NAME = CHK_UPLOAD1 Then
                    If dao_check.fields.NAME_FAKE Is Nothing Then
                        ck_file = False
                        Exit For
                    End If
                End If
            End If
        Next
        Return ck_file
    End Function

    Sub alert_normal(ByVal text As String)
        Dim url As String = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If check_file() = False Then
            If CheckBox_Phr.Checked = True Then
                alert_normal("กรุณาแนบไฟล์หนังสือรับรองการผ่านการอบรมหลักสูตรผู้มีหน้าที่ปฏิบัติการ")
            Else
                alert_normal("กรุณาแนบไฟล์ใบอนุญาตสถานที่")
            End If
        Else
            Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
            dao.GET_DATA_BY_IDA(_IDA)
            dao.fields.Note_Edit = txt_note_edit.Text
            dao.fields.head_menu_normal = CheckBox_lcn.Checked
            dao.fields.head_menu_bsn = CheckBox_Bsn.Checked
            dao.fields.head_menu_phr = CheckBox_Phr.Checked
            dao.fields.head_menu_lo = CheckBox_Location.Checked
            dao.fields.head_menu_lo_keep = CheckBox_Keep.Checked
            dao.fields.head_menu_drug_group = CheckBox_Drug_Group.Checked
            dao.update()
            Response.Redirect("POP_UP_LCN_RENEW_CHECK_UPLOAD.aspx?IDA=" & dao.fields.IDA & "&IDA_LCN=" & _IDA_LCN & "&CONDITION=N")
        End If
    End Sub

    Protected Sub CheckBox_lcn_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_lcn.CheckedChanged
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.head_menu_normal = CheckBox_lcn.Checked
        dao.update()
    End Sub

    Private Sub CheckBox_Bsn_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Bsn.CheckedChanged
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.head_menu_bsn = CheckBox_Bsn.Checked
        dao.update()
    End Sub

    Private Sub CheckBox_Phr_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Phr.CheckedChanged
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.head_menu_phr = CheckBox_Phr.Checked
        dao.update()
    End Sub

    Private Sub CheckBox_Location_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Location.CheckedChanged
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.head_menu_lo = CheckBox_Location.Checked
        dao.update()
    End Sub
    Private Sub CheckBox_Keep_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Keep.CheckedChanged
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.head_menu_lo_keep = CheckBox_Keep.Checked
        dao.update()
    End Sub

    Private Sub CheckBox_Drug_Group_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Drug_Group.CheckedChanged
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.head_menu_drug_group = CheckBox_Drug_Group.Checked
        dao.update()
    End Sub

    Protected Sub txt_note_edit_TextChanged(sender As Object, e As EventArgs) Handles txt_note_edit.TextChanged
        Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao.GET_DATA_BY_IDA(_IDA)
        dao.fields.Note_Edit = txt_note_edit.Text
        dao.update()
    End Sub
End Class
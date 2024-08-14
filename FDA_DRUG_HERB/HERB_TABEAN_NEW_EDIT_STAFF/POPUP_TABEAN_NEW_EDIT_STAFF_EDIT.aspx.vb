
Imports Telerik.Web.UI
Public Class POPUP_TABEAN_NEW_EDIT_STAFF_EDIT
        Inherits System.Web.UI.Page
        Private _CLS As New CLS_SESSION
        Private _IDA As String
        Private _TR_ID As String
    Private _Process_ID As String
    Private _IDA_LCN As String = ""
    Private _IDA_LCT As String = ""

    Sub RunSession()
        _Process_ID = Request.QueryString("process_id")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")

        Try
                _CLS = Session("CLS")
            Catch ex As Exception
                Response.Redirect("http://privus.fda.moph.go.th/")
            End Try
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            RunSession()
            If Not IsPostBack Then
                bind_data()
            BIND_PDF_TABEAN()
        End If
            BindTable()
        End Sub

        Public Sub bind_data()
            Dim dao_chk As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE(22)
        For Each dao_up_mas.fields In dao_up_mas.datas

            dao_chk.GetdatabyID_TR_ID_PROCESS_ID(_TR_ID, _Process_ID)
            If dao_chk.fields.IDA = 0 Then
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.TR_ID = _TR_ID
                dao_up.fields.PROCESS_ID = _Process_ID
                dao_up.fields.FK_IDA_LCN = _IDA_LCN
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE = 22
                dao_up.fields.ACTIVE = 1
                dao_up.fields.CREATE_DATE = Date.Now
                dao_up.insert()
            End If
        Next

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        NOTE_EDIT.Text = dao.fields.NOTE_EDIT
        'If R_NATURE.SelectedValue <> "" Then
        '    R_NATURE.SelectedValue = dao.fields.NATURE_ID_EDIT
        'End If
        'Try
        '    R_NATURE.SelectedValue = dao.fields.NATURE_ID_EDIT
        'Catch ex As Exception

        'End Try

        lbl_edit_by.Text = dao.fields.EDIT_RQ_NAME
        Try
            lbl_edit_date.Text = dao.fields.EDIT_RQ_DATE
        Catch ex As Exception

        End Try


        'Dim Type_ID As Integer = 0
        ''Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        'dao_chk.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(_IDA, _TR_ID, _Process_ID)
        'Type_ID = dao_chk.fields.TYPE
        'If Type_ID = 1 Or Type_ID = 2 Then
        '    RadGrid1.Visible = False
        '    RadGrid4.Visible = True
        'Else
        '    RadGrid1.Visible = False
        '    RadGrid4.Visible = True

        '    btn_sumit.Enabled = False
        '    btn_sumit.CssClass = "btn-danger btn-lg"
        'End If

    End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        'Dim Type_ID As Integer = 0
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        'dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO()

        Dim Type_ID As Integer = 0
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(_IDA, _TR_ID, _Process_ID)
        Type_ID = dao_up.fields.TYPE
        If Type_ID = 1 Or Type_ID = 2 Or Type_ID = 22 Then
            'RadGrid1.Visible = False
            RadGrid4.Visible = False
        Else
            RadGrid1.Visible = False

            btn_sumit.Enabled = False
            btn_sumit.CssClass = "btn-danger btn-lg"
            btn_add_upload.Enabled = False
            set_show.Visible = False
        End If
        'dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO()
        dt = bao.SP_MAS_TABEAN_HERB_EDIT_UPLOADFILE(_IDA)
        Dim index As Integer = 0
        dt.Columns.Add("ID")

        For Each item As DataRow In dt.Rows
            index += 1

            item("ID") = index
        Next
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim IDA_UPLOAD As Integer = 0
        Dim NAME_FILE As String = ""

        For Each item As GridDataItem In RadGrid1.SelectedItems
            IDA_UPLOAD = item("ID").Text
            NAME_FILE = item("DUCUMENT_NAME").Text

            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DUCUMENT_NAME = NAME_FILE
            dao_up.fields.TR_ID = _TR_ID
            dao_up.fields.PROCESS_ID = _Process_ID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.TYPE = 3
            dao_up.fields.ACTIVE = 1
            dao_up.fields.CREATE_DATE = Date.Now
            dao_up.insert()

        Next

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        'If R_NATURE.SelectedValue <> "" Then
        '    dao.fields.NATURE_ID_EDIT = R_NATURE.SelectedValue
        'End If
        Try
            If dao.fields.STATUS_ID = 11 Then
                dao.fields.EDIT_RQ_ID = _CLS.CITIZEN_ID
                dao.fields.EDIT_RQ_NAME = _CLS.THANM
                dao.fields.EDIT_RQ_DATE = Date.Now
                dao.fields.NOTE_EDIT = NOTE_EDIT.Text
            Else
                dao.fields.EDIT_RQ2_ID = _CLS.CITIZEN_ID
                dao.fields.EDIT_RQ2_NAME = _CLS.THANM
                dao.fields.EDIT_RQ2_DATE = Date.Now
                dao.fields.NOTE_EDIT2 = NOTE_EDIT.Text
            End If
        Catch ex As Exception

        End Try


        dao.Update()

        'AddLogStatus(dao.fields.STATUS_ID, _Process_ID, _CLS.CITIZEN_ID, _IDA)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิก');parent.close_modal();", True)
    End Sub

    Public Sub BindTable()
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        If _TR_ID <> 0 Then

            'dao_up.GetdatabyID_IDA_TYPE(_IDA, 2)
            dao_up.GetdatabyID_TR_ID_PROCESS_TYPE(_TR_ID, _Process_ID, 22)

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
                tc.Text = dao_up.fields.NAME_REAL
                tc.Width = 100
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
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID
        Dim DD_HERB_PROCESS As String = _Process_ID

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
                    Dim Name_fake As String = "HB-" & _Process_ID & "-" & con_year(Date.Now.Year) & "-" & TR_ID & "-" & IDA & ".pdf"

                    dao_up.GetdatabyID_IDA(IDA)

                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 22
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.ACTIVE = 1

                    Try
                        dao_up.fields.TR_ID = dao.fields.TR_ID
                    Catch ex As Exception

                    End Try

                    dao_up.fields.PROCESS_ID = _Process_ID

                    dao_up.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_EDIT
                    f.SaveAs(paths & "FILE_UPLOAD\" & Name_fake)
                Else
                    alert_file_error(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                    'alert_no_file(name_real & "กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If

        Next

        If check_file() = False Then
            alert_normal("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            alert_normal("แนบไฟล์เรียบร้อยแล้ว กดบันทึก")
        End If

        'alert_normal("แนบไฟล์เรียบร้อยแล้ว")

    End Sub
    Sub alert_file_error(ByVal text As String)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID=" & _Process_ID & "&IDA=" & _IDA
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Private Function check_file()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID, _Process_ID, 2)

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
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 22, _Process_ID, _IDA)

        Return dt
    End Function
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile_edit()
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_ST")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW_EDIT/FRM_HERB_TABEAN_NEW_EDIT_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
    Function bind_data_uploadfile1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, 1, _Process_ID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile1()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW_EDIT/FRM_HERB_TABEAN_NEW_EDIT_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
    Sub BIND_PDF_TABEAN()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        _IDA_LCN = dao.fields.FK_LCN_IDA
        Dim XML As New CLASS_GEN_XML.TABEAN_NEW_EDIT
        TBN_NEW_EDIT = XML.GEN_XML_TABEAN_NEW_EDIT(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_Process_ID, dao.fields.STATUS_ID, "ทบ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EDIT") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", _Process_ID, Date.Now.Year, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", _Process_ID, Date.Now.Year, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _Process_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub

    Function bind_data_uploadfile_4()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(_IDA, dao.fields.TR_ID, _Process_ID)
        Type_ID = dao_up.fields.TYPE
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN(dao.fields.TR_ID, 3, _Process_ID, dao.fields.FK_LCN_IDA)
        Return dt
        End Function

        Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
            RadGrid4.DataSource = bind_data_uploadfile_4()
        End Sub
    End Class
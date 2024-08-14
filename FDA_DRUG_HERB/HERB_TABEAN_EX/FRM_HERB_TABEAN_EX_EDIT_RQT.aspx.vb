Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_EX_EDIT_RQT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_EX As String
    Private _TR_ID As String
    Private _Process_ID As String
    Private _IDA_LCN As String
    Private _TR_ID_LCN As String
    Private _PROCESS_ID_LCN As String
    Private _MENU_GROUP As String


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

        _Process_ID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA_DQ")
        _IDA_EX = Request.QueryString("IDA_EX")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        BindTable()
        If Not IsPostBack Then
            bind_data()
        End If
    End Sub
    Public Sub bind_data()
        Dim dao_ex As New DAO_DRUG.ClsDBdrsamp
        dao_ex.GetDataby_IDA(_IDA_EX)
        NOTE_EDIT.Text = dao_ex.fields.EX_NOTE_EDIT_UPLOAD
        TXT_EDIT_NOTE_TB1.Text = dao_ex.fields.EX_NOTE_EDIT
        If dao_ex.fields.EX_EDIT = 1 Then
            EDIT_EX1_SHOW.Visible = True
        ElseIf dao_ex.fields.EX_EDIT = 2 Then
            UC_TABEAN_EDIT_EX2.Visible = True
        ElseIf dao_ex.fields.EX_EDIT = 3 Then
            UC_TABEAN_EDIT_EX2.Visible = True
            EDIT_EX1_SHOW.Visible = True
        End If
    End Sub
    Public Sub Run_Pdf_Tabean_Herb_ex()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA_EX)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_EX
        TABEAN_EX = XML.gen_xml_TB_EX(_IDA_EX, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(dao.fields.process_id, dao.fields.STATUS_ID, "ตย1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EX") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE_EX\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TABEAN_EX("HB_XML", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, dao.fields.process_id, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
        ' lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub

    Function bind_data_uploadfile_edit_file_head()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 19, _Process_ID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile_edit_file_head()
    End Sub
    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 18, _Process_ID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile_edit()
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_EX_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub
    Public Sub BindTable()

        Dim dt As DataTable
        dt = bind_data_uploadfile_edit_file_head()

        Dim TR_ID As Integer = _TR_ID
        'Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        If TR_ID <> 0 Then

            Dim rows As Integer = 1
            For Each dr In dt.Rows
                Dim tr As New TableRow
                tr.CssClass = "rows"
                Dim tc As New TableCell

                tc = New TableCell
                tc.Text = rows
                tr.Cells.Add(tc)

                tc = New TableCell
                'tc.Text = dao_up.fields.IDA
                tc.Text = dr("IDA")
                tc.Style.Add("display", "none")
                tr.Cells.Add(tc)

                tc = New TableCell
                Try
                    tc.Text = Replace(dr("DUCUMENT_NAME"), "\n", "<br/>")
                Catch ex As Exception
                    tc.Text = dr("DUCUMENT_NAME")
                End Try
                tc.Width = 900
                tr.Cells.Add(tc)

                tc = New TableCell
                Try
                    tc.Text = dr("NAME_REAL")
                Catch ex As Exception
                    tc.Text = ""
                End Try

                tc.Width = 300
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim img As New Image
                Try
                    If dr("NAME_REAL") Is Nothing OrElse dr("NAME_REAL") = "" Then
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
                f.ID = "F" & dr("IDA")
                tc.Controls.Add(f)
                tr.Cells.Add(tc)

                tb_type_menu.Rows.Add(tr)
                rows = rows + 1
            Next

        End If

    End Sub
    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click

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
                    Dim Name_fake As String = "HB-" & _Process_ID & "-" & Date.Now.Year & "-" & _TR_ID & "-" & IDA & ".pdf"

                    dao_up.GetdatabyID_IDA(IDA)

                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = _IDA_EX
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 20
                    dao_up.fields.ACTIVE = 1

                    Try
                        dao_up.fields.TR_ID = _TR_ID
                    Catch ex As Exception

                    End Try

                    dao_up.fields.PROCESS_ID = _Process_ID

                    dao_up.Update()

                    Dim paths As String = bao._PATH_XML_PDF_TABEAN_TBN
                    f.SaveAs(paths & "UPLOAD_PDF_TABEAN_TBN\" & Name_fake)
                Else
                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If

            End If

        Next

        If check_file() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            alert_normal("แนบไฟล์เรียบร้อยแล้ว กดบันทึก รอจนท.ตรวจสอบ")
        End If

    End Sub

    Private Function check_file()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA_EX)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID, _Process_ID, 20)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
            End If
        Next

        Return ck_file
    End Function
    Sub update_data()

    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao_ex As New DAO_DRUG.ClsDBdrsamp
        dao_ex.GetDataby_IDA(_IDA_EX)
        If dao_ex.fields.EX_EDIT = 1 Then
            UC_TABEAN_EDIT_EX2.set_data()
        ElseIf dao_ex.fields.EX_EDIT = 3 Then
            UC_TABEAN_EDIT_EX2.set_data()
        End If
        dao_ex.fields.STATUS_ID = 5
        dao_ex.update()
        Response.Redirect("FRM_HERB_TABEAN_EX.aspx?&IDA_LCN=" & _IDA_LCN)
    End Sub

End Class
Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_EDIT_2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA_DQ As String
    Private _TR_ID As String
    Private _PROCESS_ID_DQ As String
    Private _IDA_LCN As String = ""

    Sub RunSession()
        _PROCESS_ID_DQ = Request.QueryString("PROCESS_ID_DQ")
        _IDA_DQ = Request.QueryString("IDA_DQ")
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
        BindTable()

        If Not IsPostBack Then
            bind_data()
        End If
    End Sub

    Public Sub bind_data()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA_DQ)
        If dao.fields.NOTE_EDIT IsNot Nothing Then
            NOTE_EDIT.Text = dao.fields.NOTE_EDIT
        Else
            NOTE_EDIT.Text = ""
        End If
        If dao.fields.CHK_EDIT_TB1 = 1 And dao.fields.CHK_UPLOAD_TB = 1 Then
            EDIT_TB1_SHOW.Visible = True
            EDIT_UPLOAD_SHOW.Visible = True
            TXT_EDIT_NOTE_TB1.Text = dao.fields.NOTE_EDIT_TB1
        ElseIf dao.fields.CHK_EDIT_TB1 = 1 Then
            EDIT_TB1_SHOW.Visible = False
        ElseIf dao.fields.CHK_EDIT_TB1 = 1 Then
            EDIT_TB1_SHOW.Visible = True
            EDIT_UPLOAD_SHOW.Visible = False
            TXT_EDIT_NOTE_TB1.Text = dao.fields.NOTE_EDIT_TB1
        End If
    End Sub

    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 11, _PROCESS_ID_DQ, _IDA_DQ)

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
            H.NavigateUrl = "FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Function bind_data_uploadfile_edit_file_head()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 12, _PROCESS_ID_DQ, _IDA_DQ)

        Return dt
    End Function

    'Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
    '    RadGrid2.DataSource = bind_data_uploadfile_edit_file_head()
    'End Sub

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

                tc.Width = 100
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
                    Dim Name_fake As String = "HB-" & _PROCESS_ID_DQ & "-" & Date.Now.Year & "-" & _TR_ID & "-" & IDA & ".pdf"

                    dao_up.GetdatabyID_IDA(IDA)

                    dao_up.fields.NAME_FAKE = Name_fake
                    dao_up.fields.NAME_REAL = f.FileName
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.fields.FK_IDA = _IDA_DQ
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.ACTIVE = 1

                    Try
                        dao_up.fields.TR_ID = _TR_ID
                    Catch ex As Exception

                    End Try

                    dao_up.fields.PROCESS_ID = _PROCESS_ID_DQ

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

        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA_DQ)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_check.GetdatabyID_TR_ID_PROCESS_ID_ALL(TR_ID, _PROCESS_ID_DQ, 10)

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

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        If dao.fields.CHK_EDIT_TB1 = 1 Then
            UC_TABEAN_EDIT_TB1.update_data()
        End If
        dao_deeqt.fields.STATUS_ID = 17
        dao_deeqt.update()
        dao.fields.STATUS_ID = 17
        dao.Update()

        'Dim bao_tran As New BAO_TRANSECTION
        'bao_tran.insert_transection_jj(_PROCESS_ID_DQ, dao.fields.IDA, dao.fields.STATUS_ID)

        Run_Pdf_Tabean_Herb_17()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_17()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA_DQ)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA_DQ)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA_DQ, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_PROCESS_ID_DQ, dao_deeqt.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _PROCESS_ID_DQ, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_DQ, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _PROCESS_ID_DQ, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA_DQ, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID_DQ, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&DDHERB=" & _ProcessID & "&IDA=" & _IDA
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

End Class
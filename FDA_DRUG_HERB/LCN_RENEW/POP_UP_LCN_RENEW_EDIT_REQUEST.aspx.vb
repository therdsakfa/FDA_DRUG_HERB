Imports Telerik.Web.UI
Imports Telerik.Web.UI.Scheduler.Views
Public Class POP_UP_LCN_RENEW_EDIT_REQUEST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _IDA As String
    Private _IDEN As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")
        _IDA = Request.QueryString("IDA")
        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
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
            Bind_Data()
        End If
    End Sub
    Sub Get_data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao_lcn.fields.IDA)
        NOTE_EDIT.Text = dao.fields.Note_Edit
        'txt_Rename_Name.Text = dao_lcn.fields.syslcnsnm_prefixnm & "" & dao_lcn.fields.thanm
        ''txt_phr_name.Text = dao_phr.fields.PHR_NAME
        'txt_phr_name.Text = dao_bsn.fields.BSN_THAIFULLNAME
        'TxT_LCN_NUM.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
        'TxT_Business_Name.Text = dao_addr.fields.thanameplace
        'txt_addr.Text = dao_addr.fields.thaaddr
        'txt_Building.Text = dao_addr.fields.thabuilding
        'txt_mu.Text = dao_addr.fields.thamu
        'txt_Soi.Text = dao_addr.fields.thasoi
        'txt_road.Text = dao_addr.fields.tharoad
        'txt_tambol.Text = dao_addr.fields.thathmblnm
        'txt_ampher.Text = dao_addr.fields.thaamphrnm
        'txt_changwat.Text = dao_addr.fields.thachngwtnm
        'txt_zipcode.Text = dao_addr.fields.zipcode
        'txt_tel.Text = dao_addr.fields.tel
        'txt_Opentime.Text = dao_lcn.fields.opentime
        'txt_Write_Date.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub
    Public Sub load_gv()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(Request.QueryString("IDA"))
        Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
        Try
            RG_StaffFile.DataSource = dao_a.datas
            RG_StaffFile.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RG_StaffFile_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_StaffFile.NeedDataSource
        load_gv()
    End Sub
    Private Sub RG_StaffFile_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_StaffFile.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
        End If
    End Sub
    Sub Bind_Data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(Request.QueryString("IDA"))
        If dao.fields.Check_Edit_ID = True Then
            'Check_Edit.Visible = True
            Get_data()
            'TXT_EDIT_NOTE.Text = dao.fields.Note_Edit
        End If
        If dao.fields.Check_Edit_FileUpload_ID = True Then
            Check_Edit_Uplaod.Visible = True
            NOTE_EDIT.Text = dao.fields.Note_Edit_FileUpload
        End If
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(Request.QueryString("IDA"))
        'If dao.fields.Check_Edit_FileUpload_ID = True Then
        If check_file_edit() = False Then
            alert_no_file("กรุณาแนบไฟล์ให้ครบทุกข้อ")
        Else
            'If dao.fields.Check_Edit_ID = False Then
            dao.fields.STATUS_ID = 32
            dao.fields.UPDATE_DATE = DateTime.Now
            dao.update()
            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, Request.QueryString("IDA"))
            alert("บันทึกข้อมูลแล้ว รอเจ้าหน้าที่ตรวจสอบความถูกต้อง")
            'End If
        End If
        'End If
        'If dao.fields.Check_Edit_ID = True Then
        '    Try
        'dao.fields.latitude = txt_latitude.Text
        'Catch ex As Exception
        '        dao.fields.latitude = 0
        '    End Try
        'Try
        '    'dao.fields.longitude = txt_longitude.Text
        'Catch ex As Exception
        '    dao.fields.longitude = 0
        ''End Try
        'dao.fields.STATUS_ID = 32
        'dao.update()
        'AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, Request.QueryString("IDA"))
        'alert("บันทึกข้อมูลแล้ว รอเจ้าหน้าที่ตรวจสอบความถูกต้อง")
        'End If
    End Sub

    Function bind_data_RG_Edit()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 1)
        Return dt
    End Function

    Private Sub RG_Edit_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_Edit.NeedDataSource
        RG_Edit.DataSource = bind_data_RG_Edit()
    End Sub
    Private Sub RG_Edit_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_Edit.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA
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

        'dao_f.GetDataby_TR_ID(tr_id)
        dao_f.GetDaTaby_TR_ID_And_TYPE_AND_FK_IDA(tr_id, 2, _IDA)

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
                tc.Text = Replace(dao_f.fields.DOCUMENT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.DOCUMENT_NAME
            End Try
            tc.Width = 700
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

            tb_upload_file.Rows.Add(tr)
            rows = rows + 1
        Next
    End Sub
    Sub Bind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        'Dim _ProcessID As String = 10501
        Dim XML As New CLASS_GEN_XML.DALCN_RENEW
        LCN_RENEW = XML.Gen_XML_LCN_RENEW(_IDA, _IDA_LCN)
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "สมพ5", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_RENREW") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PDF", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("XML", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA)
        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Sub alert_no_file(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Function check_file()

        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_check.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(TR_ID, _ProcessID, 2)

        Dim ck_file As Boolean = True

        For Each dao_check.fields In dao_check.datas
            If dao_check.fields.Forcible = True And dao_check.fields.NAME_FAKE Is Nothing Then
                ck_file = False
                Exit For
            End If
        Next

        Return ck_file
    End Function
    Private Function check_file_edit()

        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Dim TR_ID As Integer = dao.fields.TR_ID

        Dim dao_check As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_check.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(TR_ID, _ProcessID, 2)

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
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        tr_id = dao.fields.TR_ID
        For Each tr As TableRow In tb_upload_file.Rows
            Dim IDA As Integer = tr.Cells(1).Text
            Dim bao As New BAO.AppSettings
            Dim f As New FileUpload
            f = tr.FindControl("F" & IDA)
            If f.HasFile Then
                Dim name_real As String = f.FileName
                Dim Array_NAME_REAL() As String = Split(name_real, ".")
                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                Dim paths As String = bao._PATH_XML_PDF_LCN_RENREW
                If exten.ToUpper = "PDF" Then
                    Dim dao_f As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                    dao_f.GetDataby_IDA(IDA)
                    Dim Name_fake As String = "HB-" & _ProcessID & "-" & Date.Now.Year & "-" & tr_id & "-" & dao_f.fields.IDA & ".pdf"
                    paths = paths & "FILE_UPLOAD\" & Name_fake
                    dao_f.fields.NAME_FAKE = Name_fake
                    dao_f.fields.NAME_REAL = f.FileName
                    dao_f.fields.CREATE_DATE = Date.Now
                    dao_f.fields.FilePath = paths
                    dao_f.fields.Active = True
                    dao_f.update()
                    f.SaveAs(paths)
                Else
                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If
        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class

Imports Telerik.Web.UI
Imports Telerik.Web.UI.Scheduler.Views
Public Class POP_UP_LCN_RENEW_STAFF_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String = ""
    Private _STATUS_ID As String = ""

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _STATUS_ID = Request.QueryString("STATUS_ID")
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
            Bind_PDF()
        End If
    End Sub
    Sub Bind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
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
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Try
            'If dao.fields.Check_Edit_ID = True Then
            '    'DIV_SHOW_TXT_EDIT_TB1.Visible = True
            '    'TXT_EDIT_NOTE_TB1.Text = dao.fields.Note_Edit
            '    'TXT_EDIT_NOTE_TB1.ReadOnly = True
            '    'CHK_TB1_EDIT.Checked = dao.fields.Check_Edit_ID
            '    'CHK_TB1_EDIT.Enabled = True
            'Else
            '    'DIV_SHOW_TXT_EDIT_TB1.Visible = False
            'End If
            'If dao.fields.Check_Edit_FileUpload_ID = True Then
            '    DIV_EDIT_UPLOAD1.Visible = True
            '    DIV_EDIT_UPLOAD2.Visible = True
            rgat_edit.Rebind()
            rgat.Rebind()
            Dim status_ed As Integer = 0
            Dim status_id As Integer = dao.fields.STATUS_ID
            If dao.fields.STATUS_EDIT IsNot Nothing AndAlso dao.fields.STATUS_EDIT <> 0 Then status_ed = dao.fields.STATUS_EDIT
            If status_id = 12 Or status_ed = 1 Then
                NOTE_EDIT.Text = dao.fields.Note_Edit
            Else
                NOTE_EDIT.Text = dao.fields.NOTE_EDIT2
            End If

            'NOTE_EDIT.ReadOnly = True
            'CHK_UPLOAD_EDIT.Checked = dao.fields.Check_Edit_FileUpload_ID
            'CHK_UPLOAD_EDIT.Enabled = True
            'Else
            '    DIV_EDIT_UPLOAD1.Visible = False
            '    DIV_EDIT_UPLOAD2.Visible = False
            'End If
        Catch ex As Exception

        End Try
        'Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
        'dao_a.GetDataby_TR_ID(dao.fields.TR_ID)
        Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
        If dao_a.fields.IDA <> 0 Then
            img_cf.Visible = True
            img_not.Visible = False
            lbl_upload_file.Text = dao_a.fields.NAME_REAL
        End If
        'INSERT_FILE_ATTACH(_IDA, 0, _TR_ID, 10511, 0)
        'INSERT_FILE_ATTACH(_IDA, 1, _TR_ID, 10511, 1)
        INSERT_FILE_ATTACH(_IDA, 4, _TR_ID, _ProcessID, 1)

        'Dim dao_p As New DAO_LCN.TB_DALCN_RENEW_PRE
        'dao_p.GET_DATA_BY_FK_LCN_AP(_IDA_LCN, True)
        'Dim TR_ID_RE As Integer = Convert.ToInt32(dao_p.fields.TR_ID)
        'Dim dao_at As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        ''dao_at.GetDataby_Fk_ida_ProcessID_TR_ID(dao_p.fields.IDA, dao_p.fields.PROCESS_ID, TR_ID_RE)
        'dao_at.GetDataby_FK_IDA_AND_TR_ID(dao_p.fields.IDA, TR_ID_RE)
        'Dim TYPE_ID As Integer = 1
        'For Each dao_at.fields In dao_at.datas
        '    Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        '    dao_att.fields.DOCUMENT_NAME = dao_at.fields.DOCUMENT_NAME
        '    dao_att.fields.NAME_FAKE = dao_at.fields.NAME_FAKE
        '    dao_att.fields.NAME_REAL = dao_at.fields.NAME_REAL
        '    dao_att.fields.TYPE_PERSON = 0
        '    dao_att.fields.TYPE_LOCAL = 0
        '    dao_att.fields.TYPE_BSN = 0
        '    dao_att.fields.TYPE = TYPE_ID
        '    dao_att.fields.FK_IDA = dao.fields.IDA
        '    dao_att.fields.TR_ID = _TR_ID
        '    dao_att.fields.PROCESS_ID = _ProcessID
        '    dao_att.fields.Forcible = dao_at.fields.Forcible
        '    dao_att.fields.TYPE_PERSON_NAME = ""
        '    dao_att.fields.TYPE_LOCAL_NAME = ""
        '    dao_att.fields.TYPE_BSN_NAME = ""
        '    dao_att.fields.DocID = dao_at.fields.DocID
        '    dao_att.fields.FilePath = dao_at.fields.FilePath
        '    dao_att.fields.Active = dao_at.fields.Active
        '    dao_att.insert()
        'Next
    End Sub
    Private Sub load_HL(ByVal IDA As String)
        Dim url As String = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA

        ST_AT.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Dim dao_p As New DAO_LCN.TB_DALCN_RENEW_PRE
        dao_p.GET_DATA_BY_FK_LCN(_IDA_LCN, True)
        Dim Condition_ID As String = dao_p.fields.Check_Confirm
        Dim bao_show As New BAO_SHOW
        Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        'Dim dao_up As New DAO_DRUG.TB_MAS_DOCUMENT_NAME_UPLOAD_DALCN
        dao_up.GetDataby_FK_IDA_AND_TR_ID_AND_PROCESS(_IDA, _TR_ID, _ProcessID)
        Type_ID = dao_up.fields.TYPE
        If Type_ID = 1 Then
            'RadGrid1.Visible = False
            rgat_edit2.Visible = False
            ' dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO() 
        Else
            rgat_edit.Visible = False
            'RadGrid4.Visible = True
            btn_sumit.Enabled = False
            btn_sumit.CssClass = "btn-danger btn-lg"
            btn_add_upload.Enabled = False
            btn_add_upload.CssClass = "btn-danger btn-lg"
            'set_show.Visible = False
        End If

        If Condition_ID = "N" Then
            dt = bao_show.SP_DALCN_UPLOAD_FILE_BY_TR_ID_AND_DOCID_ED(_TR_ID)
        Else
            dt = bao_show.SP_DALCN_UPLOAD_FILE_BY_TR_ID_ED(_TR_ID, 1)
        End If
        'dt = bao.SP_DALCN_UPLOAD_FILE_TYPE_BY_PROCESS(_ProcessID)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat_edit.NeedDataSource
        rgat_edit.DataSource = bind_data_uploadfile()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim IDA_UPLOAD As Integer = 0
        Dim NAME_FILE As String = ""
        For Each item As GridDataItem In rgat_edit.SelectedItems
            IDA_UPLOAD = item("ID").Text
            NAME_FILE = item("DOCUMENT_NAME").Text
            Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_up.fields.DOCUMENT_NAME = NAME_FILE
            dao_up.fields.TR_ID = _TR_ID
            dao_up.fields.PROCESS_ID = _ProcessID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.TYPE = 2
            'dao_up.fields.a = 1
            dao_up.fields.CREATE_DATE = Date.Now
            dao_up.fields.Active = True
            dao_up.insert()
        Next
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        If dao.fields.STATUS_ID = 12 Then
            dao.fields.Note_Edit = NOTE_EDIT.Text
            dao.fields.STATUS_EDIT = 1
        Else
            dao.fields.NOTE_EDIT2 = NOTE_EDIT.Text
            dao.fields.STATUS_EDIT = 2
        End If

        'If CHK_TB1_EDIT.Checked = True Then
        'dao.fields.Check_Edit_ID = CHK_TB1_EDIT.Checked
        '    dao.fields.Note_Edit = TXT_EDIT_NOTE_TB1.Text
        'Else
        'dao.fields.Check_Edit_ID = CHK_TB1_EDIT.Checked
        'End If
        'If CHK_UPLOAD_EDIT.Checked = True Then
        '    dao.fields.Check_Edit_FileUpload_ID = CHK_UPLOAD_EDIT.Checked
        dao.fields.Note_Edit_FileUpload = NOTE_EDIT.Text
        dao.fields.STATUS_ID = 31
        dao.fields.UPDATE_DATE = DateTime.Now
        'Else
        '    dao.fields.Check_Edit_FileUpload_ID = CHK_UPLOAD_EDIT.Checked
        'End If
        Try
            'dao.fields.staff_edit_id = _CLS.CITIZEN_ID
            'dao.fields.staff_edit_name = _CLS.NAME
            'dao.fields.staff_edit_name = Date.Now
        Catch ex As Exception

        End Try
        dao.update()

        AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA, NOTE_EDIT.Text)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub
    Sub INSERT_FILE_ATTACH(ByVal IDA As Integer, ByVal HeadID As Integer, ByVal TR_ID As String, ByVal Process_ID As String, ByVal TYPE_ID As String)
        Dim dao_mas As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
        dao_mas.GetDataby_HEAD_ID_AND_PROCESS(HeadID, Process_ID)
        Dim dao_up1 As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
        dao_up1.GetDaTaby_FK_TR_PROCECSS_And_HEAD_ID(IDA, TR_ID, Process_ID, HeadID)
        If dao_up1.fields.IDA = 0 Then
            For Each dao_mas.fields In dao_mas.datas
                Dim dao_up As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                dao_up.fields.CREATE_DATE = Date.Now
                dao_up.fields.PROCESS_ID = _ProcessID
                dao_up.fields.DOCUMENT_NAME = dao_mas.fields.DOCUMENT_NAME
                'dao_up.fields.FK_IDA = _IDA_LCN
                dao_up.fields.FK_IDA = IDA
                dao_up.fields.TYPE = TYPE_ID
                dao_up.fields.TR_ID = TR_ID
                dao_up.fields.DocID = dao_mas.fields.ID
                dao_up.fields.TYPE_PERSON = dao_mas.fields.HEAD_ID
                dao_up.fields.TYPE_PERSON_NAME = ""
                dao_up.fields.TYPE_LOCAL_NAME = ""
                dao_up.fields.TYPE_BSN_NAME = ""
                dao_up.fields.Active = True
                dao_up.fields.Forcible = dao_mas.fields.Forcible
                dao_up.fields.Head_ID = dao_mas.fields.HEAD_ID
                dao_up.insert()
            Next
        End If
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'Dim dao As New DAO_LCN.TB_DALCN_RENEW
        'dao.GET_DATA_BY_IDA(_IDA)
        'dao.fields.STATUS_ID = 31
        'dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click
        If UC_ATTACH_LCN.check = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
        Else
            Dim dao As New DAO_LCN.TB_DALCN_RENEW
            dao.GET_DATA_BY_IDA(_IDA)
            Dim Year As String
            Year = con_year(Date.Now.Year)
            Dim path As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_RENREW")
            UC_ATTACH_LCN.ATTACH_LCN(dao.fields.TR_ID, dao.fields.FK_LCN, dao.fields.PROCESS_ID, Year, "3", path)
            Dim up_edit As String = ""
            'Dim dao_a As New DAO_DRUG.ClsDBFILE_ATTACH
            'dao_a.GetDataby_TR_ID(dao.fields.TR_ID)
            Dim dao_a As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
            dao_a.GetDataby_TR_ID_AND_PROCESS_AND_TYPE(dao.fields.TR_ID, dao.fields.PROCESS_ID, 3)
            If dao_a.fields.IDA <> 0 Then
                img_cf.Visible = True
                img_not.Visible = False
                lbl_upload_file.Text = dao_a.fields.NAME_REAL
            End If
            load_HL(dao_a.fields.IDA)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แนบไฟล์เรียบร้อยแล้ว');", True)
        End If
    End Sub
    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    'Protected Sub CHK_TB1_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_TB1_EDIT.CheckedChanged
    '    If CHK_TB1_EDIT.Checked = True Then
    '        DIV_SHOW_TXT_EDIT_TB1.Visible = True
    '    Else
    '        DIV_SHOW_TXT_EDIT_TB1.Visible = False
    '    End If
    'End Sub

    'Protected Sub CHK_UPLOAD_EDIT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_UPLOAD_EDIT.CheckedChanged
    '    If CHK_UPLOAD_EDIT.Checked = True Then
    '        DIV_EDIT_UPLOAD1.Visible = True
    '        DIV_EDIT_UPLOAD2.Visible = True
    '        rgat_edit.Rebind()
    '        rgat.Rebind()
    '    Else
    '        DIV_EDIT_UPLOAD1.Visible = False
    '        DIV_EDIT_UPLOAD2.Visible = False
    '    End If
    'End Sub
    Function bind_data_uploadfile_1()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 1)
        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat.NeedDataSource
        rgat.DataSource = bind_data_uploadfile_1()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgat.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_RENEW/FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
    Function bind_data_uploadfile_4()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, 2)
        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgat_edit2.NeedDataSource
        rgat_edit2.DataSource = bind_data_uploadfile_4()
    End Sub

End Class
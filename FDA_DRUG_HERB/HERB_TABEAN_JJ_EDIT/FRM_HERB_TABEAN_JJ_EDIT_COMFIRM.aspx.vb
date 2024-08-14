Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_JJ_EDIT_COMFIRM
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _ProcessID As String = ""

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
        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            set_btn()
            Dim PATH_PDF_OUTPUT As String = ""
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
            Run_Pdf_Tabean_Herb()
            gen_xml_jj()
        End If
    End Sub

    Sub set_btn()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        If dao.fields.STATUS_ID = 1 Then
            btn_cancle_request.Visible = True
            btn_cancel.Visible = False
        Else
            btn_cancle_request.Visible = False
            btn_cancel.Visible = True
        End If

        If dao.fields.STATUS_ID = 77 Or dao.fields.STATUS_ID = 78 Or dao.fields.STATUS_ID = 79 Or dao.fields.STATUS_ID = 7 _
            Or dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 10 Or dao.fields.STATUS_ID = 14 Or dao.fields.STATUS_ID = 17 _
            Or dao.fields.STATUS_ID = 75 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
            btn_cancle_request.Enabled = False
            btn_cancle_request.CssClass = "btn-danger btn-lg"
        End If

        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_edit.Enabled = False
            btn_edit.CssClass = "btn-danger btn-lg"
            btn_editUpload.Enabled = False
            btn_editUpload.CssClass = "btn-danger btn-lg"
        ElseIf dao.fields.STATUS_ID = 8 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
            'btn_load.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 10 Then
            dv_btn.Visible = False
            dv_cancel.Visible = True
            txt_cancel_remark.Text = dao.fields.DD_CANCEL_NM
            NOTE_CANCLE.Text = dao.fields.NOTE_CANCEL
        End If
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_EDIT") 'path
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        'dao.GetdatabyID_IDA(_IDA)
        ''dao.fields.REF_NO = txt_ref_no.Text
        'dao.fields.DATE_CONFIRM = Date.Now
        'dao.fields.STATUS_ID = 3

        'Dim TR_ID_JJ As String = dao.fields.TR_ID_JJ
        'Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
        'Dim RCVNO_FULL As String = "HB" & " " & dao.fields.PVNCD & "-" & _ProcessID & "-" & DATE_YEAR & "-" & TR_ID_JJ

        'dao.fields.RCVNO_FULL = RCVNO_FULL

        'dao.Update()

        gen_xml_jj()
        'alert("ยื่นคำขอแล้ว")
        Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT_COMFIRM_DETAIL.aspx?IDA=" & _IDA)
    End Sub
    Sub gen_xml_jj()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim _IDA_LCN As String = dao.fields.IDA_LCN
        Dim _PROCESS_ID As String = dao.fields.DDHERB

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ_EDIT
        TB_JJ_EDIT = XML.Gen_XML_JJ3_Edit(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_PROCESS_ID, dao.fields.STATUS_ID, "จจ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_EDIT") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)

        dao.fields.DATE_CONFIRM = Date.Now
        dao.fields.STATUS_ID = 78
        dao.Update()

        'gen_xml_jj1()
        alert("ยกเลิกคำขอแล้ว")
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_cancle_request_Click(sender As Object, e As EventArgs) Handles btn_cancle_request.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        dao.fields.STATUS_ID = 75
        dao.Update()

        'gen_xml_jj1()
        alert("ยกเลิกคำขอแล้ว")
    End Sub

    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Response.Redirect("POPUP_TABEAN_JJ_EDIT_REQUEST.aspx?IDA=" & _IDA & "&IDA_JJ=" & dao.fields.FK_IDA & "&PROCESS_ID=" & _ProcessID)
    End Sub

    Protected Sub btn_editUpload_Click(sender As Object, e As EventArgs) Handles btn_editUpload.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Response.Redirect("POPUP_TABEAN_JJ_EDIT_UPLOAD.aspx?IDA=" & _IDA & "&IDA_JJ=" & dao.fields.FK_IDA & "&PROCESS_ID=" & _ProcessID)
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        Catch ex As Exception
            STATUS_UPLOAD_ID = 1
        End Try

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID_JJ, STATUS_UPLOAD_ID, dao.fields.DDHERB, _IDA)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_JJ_EDIT_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub
    Function bind_data_uploadfile_77()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID_JJ, 77, dao.fields.DDHERB, _IDA)

        Return dt
    End Function

    Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
        RadGrid5.DataSource = bind_data_uploadfile_77()
    End Sub

    Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_JJ_EDIT/FRM_HERB_TABEAN_JJ_EDIT_PREVIEW.aspx?ida=" & IDA

        End If
    End Sub
End Class
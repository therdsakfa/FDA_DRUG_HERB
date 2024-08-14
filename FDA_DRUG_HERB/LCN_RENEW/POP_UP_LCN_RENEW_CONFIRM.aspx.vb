Imports Telerik.Web.UI
Public Class POP_UP_LCN_RENEW_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_LCN As String
    Private _ProcessID As String = ""

    Sub RunSession()
        _IDA = Request.QueryString("IDA")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _ProcessID = Request.QueryString("PROCESS_ID")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Blind_PDF()
            set_btn()
        End If
    End Sub

    Sub set_btn()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        If dao.fields.STATUS_ID = 1 Then
            btn_cancel.Visible = False
        Else
            btn_cancel.Visible = True
        End If

        If dao.fields.STATUS_ID = 77 Or dao.fields.STATUS_ID = 78 Or dao.fields.STATUS_ID = 79 Or dao.fields.STATUS_ID = 7 _
            Or dao.fields.STATUS_ID = 9 Or dao.fields.STATUS_ID = 10 Or dao.fields.STATUS_ID = 14 Or dao.fields.STATUS_ID = 17 _
            Or dao.fields.STATUS_ID = 75 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If

        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            'btn_edit.Enabled = False
            'btn_edit.CssClass = "btn-danger btn-lg"
            'btn_editUpload.CssClass = "btn-danger btn-lg"
        ElseIf dao.fields.STATUS_ID = 8 Then
            'btn_editUpload.Enabled = False
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)

        dao.fields.STATUS_ID = 2
        dao.fields.DATE_CONFIRM = Date.Now
        dao.update()
        alert("ยื่นคำขอแล้ว")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)

        dao.fields.STATUS_ID = 78
        dao.update()
        alert("ยกเลิกคำขอแล้ว")
    End Sub

    'Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
    '    'Response.Redirect("FRM_PHR_HERB_EDIT.aspx?IDA=" & _IDA)
    'End Sub

    'Protected Sub btn_editUpload_Click(sender As Object, e As EventArgs) Handles btn_editUpload.Click
    '    'Response.Redirect("FRM_PHR_HERB_EDIT.aspx?IDA=" & _IDA)
    'End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Sub Blind_PDF()
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
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        dao.GET_DATA_BY_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
            'STATUS_UPLOAD_ID = 1
        Catch ex As Exception
            STATUS_UPLOAD_ID = 0
        End Try

        dt = bao.SP_DALCN_UPLOAD_FILE_BY_TR_ID_PROCESS_AND_TYPE(dao.fields.TR_ID, _ProcessID, STATUS_UPLOAD_ID)

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
            H.NavigateUrl = "FRM_HERB_LCN_RENEW_PREVIEW.aspx?ida=" & IDA

        End If

    End Sub

End Class

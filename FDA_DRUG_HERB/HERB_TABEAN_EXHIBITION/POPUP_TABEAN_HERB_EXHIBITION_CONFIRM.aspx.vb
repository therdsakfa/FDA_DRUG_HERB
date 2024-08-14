Imports Telerik.Web.UI
Public Class POPUP_TABEAN_HERB_EXHIBITION_CONFIRM
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
    Private _Process_ID As String = ""

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
        _IDA_DR = Request.QueryString("IDA_DR")
        If Request.QueryString("IDA_LCN") <> "" Then
            _IDA_LCN = Request.QueryString("IDA_LCN")
        Else
            _IDA_LCN = 0
        End If
        _Process_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BLIND_PDF_TABEAN()
            set_btn()
        End If
    End Sub

    Sub set_btn()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION
        dao.GetdatabyID_IDA(_IDA)

        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 77 Or dao.fields.STATUS_ID = 75 Or dao.fields.STATUS_ID = 7 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 1 Then
            btn_cancel.Text = "ยกเลิกการสร้างคำขอ"
        End If
    End Sub
    Sub BLIND_PDF_TABEAN()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_EXHIBITION
        TBN_EXHIBITION = XML.Gen_XML_EXHIBITION(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_Process_ID, dao.fields.STATUS_ID, "นท1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EXHIBITION") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("HB_PDF", _Process_ID, Date.Now.Year, _IDA)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("HB_XML", _Process_ID, Date.Now.Year, _IDA)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _Process_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION
        dao.GetdatabyID_IDA(_IDA)
        If dao.fields.STATUS_ID = 1 Then
            dao.fields.STATUS_ID = 75
        Else
            dao.fields.STATUS_ID = 77
        End If
        dao.Update()
        AddLogStatus(dao.fields.STATUS_ID, dao.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
        alert("ยกเลิกคำขอแล้ว")
    End Sub


    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_RENEW_UPLOAD.aspx?IDA=" & ida & "&PROCESS_ID=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & _IDA_DR
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub


    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION
        dao.GetdatabyID_IDA(_IDA)

        dao.fields.DATE_CONFIRM = Date.Now
        dao.fields.STATUS_ID = 2
        dao.Update()

        Response.Redirect("POPUP_TABEAN_HERB_EXHIBITION_CONFIRM_DETAIL.aspx?IDA=" & _IDA & "&PROCESS_ID=" & _Process_ID)
        'alert("ยืนคำขอเรียบร้อย")

    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION
        dao.GetdatabyID_IDA(_IDA)
        Dim STATUS_UPLOAD_ID As Integer = 0
        Try
            STATUS_UPLOAD_ID = dao.fields.STATUS_UPLOAD_ID
        Catch ex As Exception
            STATUS_UPLOAD_ID = 0
        End Try

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao.fields.TR_ID, STATUS_UPLOAD_ID, _Process_ID, _IDA)

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
            H.NavigateUrl = "FRM_TABEAN_HERB_EXHIBITION_PREVIEWaspx.aspx?ida=" & IDA

        End If

    End Sub

    Protected Sub btn_close_Click1(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
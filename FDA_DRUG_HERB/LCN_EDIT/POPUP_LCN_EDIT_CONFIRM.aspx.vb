Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class POPUP_LCN_EDIT_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _TR_ID As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _PROCESS_ID As String = ""
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
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("LCN_IDA")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _PROCESS_ID = Request.QueryString("process")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            set_btn()
            Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
            dao.GetDataby_IDA(_IDA)
            Bind_Pdf()

        End If
    End Sub
    Sub set_btn()
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        If dao.fields.STATUS_ID <> 0 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            'btn_edit.Enabled = False
            'btn_edit.CssClass = "btn-danger btn-lg"
        End If
        If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 78 Or dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 77 Then
                btn_cancel.Enabled = False
                btn_cancel.CssClass = "btn-danger btn-lg"
                'btn_load.CssClass = "btn-d7anger btn-lg"
            End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Response.Redirect("POPUP_LCN_EDIT_CONFIRM_DETAIL.aspx?IDA=" & _IDA & "&PROCESS_ID=" & _PROCESS_ID)
    End Sub
    Public Sub Bind_Pdf()
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim _YEAR As String = dao.fields.DATE_YEAR
        Dim _tr_id_xml As String = dao.fields.TR_ID
        Dim _StatusID As String = dao.fields.STATUS_ID
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, _IDA_LCN, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_PROCESS_ID, _StatusID, "สมพ3", 0)
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_PROCESS_ID, _StatusID, "สมพ3", 1)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _PROCESS_ID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _PROCESS_ID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _PROCESS_ID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = 78
        dao.update()

        AddLogStatus(dao.fields.STATUS_ID, dao.fields.LCN_PROCESS_ID, _CLS.CITIZEN_ID, dao.fields.IDA)
        alert("ยกเลิกคำขอแล้ว")

    End Sub

    'Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
    '    Response.Redirect("FRM_HERB_TABEAN_EX_EDIT.aspx?IDA_EX=" & _IDA & "&IDA_LCN=" & _IDA_LCN)
    'End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_DALCN_EDIT_UPLOAD_FILE(dao.fields.TR_ID, 1)
        'dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_EX(dao.fields.TR_ID, 17, dao.fields.LCN_PROCESS_ID)

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
            H.NavigateUrl = "../HERB_TABEAN_EX/FRM_HERB_TABEAN_EX_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA


        End If

    End Sub
End Class
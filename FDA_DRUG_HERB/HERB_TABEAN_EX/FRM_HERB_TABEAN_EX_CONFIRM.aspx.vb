Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_EX_CONFIRM
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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/แบบแจ้งผลิตหรือนำเข้าผลิตภัณฑ์สมุนไพร.pdf'></iframe>"
            'Run_PDF_TABEAN_HERB_EX()
            set_btn()
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_IDA)
            'If dao.fields.STATUS_ID = 8 Then
            '    Run_Pdf_Tabean_Herb_Yorbor8()
            'Else
            Run_PDF_TABEAN_HERB_EX()
            'End If
        End If
    End Sub
    Sub set_btn()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_edit.Enabled = False
            btn_edit.CssClass = "btn-danger btn-lg"
        ElseIf dao.fields.STATUS_ID = 8 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
            'btn_load.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        'Dim dao As New DAO_DRUG.ClsDBdrsamp
        'dao.GetDataby_IDA(_IDA)
        ''dao.fields.REF_NO = txt_ref_no.Text
        'dao.fields.EX_DATE_CONFIRM = Date.Now
        ''dao.fields.STATUS_ID = 3
        'dao.fields.STATUS_ID = 2
        'dao.update()

        'alert("ยื่นคำขอแล้ว")
        Response.Redirect("FRM_HERB_TABEAN_EX_CONFIRM_DETAIL.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA=" & _IDA & "&PROCESS_ID=" & _PROCESS_ID)
    End Sub
    Public Sub Run_PDF_TABEAN_HERB_EX()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_EX
        TABEAN_EX = XML.gen_xml_TB_EX(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(dao.fields.process_id, dao.fields.STATUS_ID, "ตย1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EX") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE_EX\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TABEAN_EX("HB_XML", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, dao.fields.process_id, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Public Sub Run_Pdf_TB_Herb_EX()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(dao.fields.process_id, dao.fields.STATUS_ID, "ตย1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EX") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE_EX\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub
    Public Sub Run_Pdf_Tabean_Herb_Yorbor8()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Dim lcntpcd As String = ""
        Dim process_id As String = ""

        dao.GetDataby_IDA(_IDA)
        If dao.fields.lcntpcd.Contains("ผ") Then
            lcntpcd = "ยบ8"
            process_id = 200008
        Else
            lcntpcd = "ยบ8"
            process_id = 200008
        End If

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_EX
        TABEAN_EX = XML.gen_xml_TB_EX(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_EX_TEMPLAETE1(process_id, dao.fields.STATUS_ID, lcntpcd, 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_YORBOR8") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TABEAN_EX("HB_XML", process_id, dao.fields.EX_DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, process_id, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = 78
        dao.update()
        alert("ยกเลิกคำขอแล้ว")
    End Sub

    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Response.Redirect("FRM_HERB_TABEAN_EX_EDIT.aspx?IDA_EX=" & _IDA & "&IDA_LCN=" & _IDA_LCN)
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_EX(dao.fields.TR_ID, 17, dao.fields.process_id)

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
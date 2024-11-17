Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_JJ_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _TR_ID_LCN As String
    Private _IDA_LCT As String
    Private _DD_HERB_NAME_ID As String
    Private _PROCESS_ID_LCN As String
    Private _MENU_GROUP As String

    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_JJ")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            gen_xml_jj1()
            'Run_Pdf_Tabean_Herb()
            set_btn()
            set_txt()
        End If
    End Sub
    Sub set_btn()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
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
        End If
        If dao.fields.STATUS_ID = 8 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
            'btn_load.CssClass = "btn-danger btn-lg"
        End If

    End Sub
    Sub set_txt()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        txt_ref_no.Text = dao.fields.REF_NO
        If dao.fields.STATUS_ID <> 1 Then
            txt_ref_no.ReadOnly = True
        Else
            txt_ref_no.ReadOnly = False
        End If

        If dao.fields.STATUS_ID >= 4 Then
            div_cm_staff.Visible = True
        Else
            div_cm_staff.Visible = False
        End If
        txt_edit_staff.Text = dao.fields.NOTE_EDIT

        Try
            Dim all_days As Double = 0
            Dim DAY_WORK As Integer = 90
            Dim date_result As Date
            Dim start_date2 As Date
            Dim end_date2 As Date
            Dim holiday2 As Integer = 0
            Dim day_all2 As Integer = 0
            Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
            'ws.GETDATE_WORKING(CDate(dao.fields.DATE_CONFIRM), True, DAY_WORK, True, date_result, True)
            'TXT_DAY_WORK.Text = date_result
            'ws.GETDATE_COUNT_DAY(CDate(dao.fields.DATE_CONFIRM), True, Date.Now, True, all_days, True)
            'TXT_DAY_WORK.Text = all_days

            Try
                start_date2 = CDate(dao.fields.DATE_CONFIRM)
            Catch ex As Exception

            End Try
            Try
                end_date2 = CDate(date_result)
            Catch ex As Exception

            End Try
            day_all2 = DateDiff(DateInterval.Day, start_date2, end_date2)
            ws.GETDATE_COUNT_DAY(start_date2, True, end_date2, True, holiday2, True)
            all_days = day_all2 - holiday2

            'TXT_DAY_WORK.Text = all_days
        Catch ex As Exception
            'all_days = all_days - holi_all
        End Try
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 1, _ProcessID, _IDA)

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
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 3, _ProcessID, _IDA)

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

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub
    Function bind_data_file_recipe_production()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        Dim HERB_ID As Integer = dao.fields.DD_HERB_NAME_ID

        dt = bao.SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ(HERB_ID, _ProcessID)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_file_recipe_production()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            'Dim DD_HERB_NAME_PRODUCT_ID As Integer = item("DD_HERB_NAME_PRODUCT_ID").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_RECIPE_PRODUCT_PREVIEW_FILE.aspx?IDA=" & IDA

        End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        If txt_ref_no.Text <> "" Then
            'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            'dao.GetdatabyID_IDA(_IDA)
            'dao.fields.REF_NO = txt_ref_no.Text
            'dao.fields.DATE_CONFIRM = Date.Now
            ''dao.fields.STATUS_ID = 3
            'dao.fields.STATUS_ID = 2

            ''เก็บสะถานนะทั้ง ระบบไว้
            ''Dim TR_ID As String = ""
            ''Dim bao_tran As New BAO_TRANSECTION
            ''bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, dao.fields.STATUS_ID)
            '''เลขดำเนินการ รันใหม่
            ''Dim bao_gen As New BAO.GenNumber
            ''TR_ID = bao_gen.GEN_NO_JJ(con_year(Date.Now.Year), dao.fields.PVNCD, _ProcessID, _IDA, _IDA_LCN)
            ''dao.fields.TR_ID_JJ = TR_ID

            'Dim TR_ID_JJ As String = dao.fields.TR_ID_JJ
            'Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            'Dim RCVNO_FULL As String = "HB" & " " & dao.fields.PVNCD & "-" & _ProcessID & "-" & DATE_YEAR & "-" & TR_ID_JJ

            'dao.fields.RCVNO_FULL = RCVNO_FULL

            'dao.Update()

            'gen_xml_jj1()
            'Response.Redirect("POPUP_CONFIRM_CLICK.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA=" & _IDA)
            ' alert("ยื่นคำขอแล้ว")
            Response.Redirect("FRM_HERB_TABEAN_JJ_CONFIRM_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & _TR_ID & "&SID=" & Request.QueryString("SID"))
        End If

    End Sub

    Sub gen_xml_jj1()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
        TB_JJ = XML.gen_xml(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        'dao.fields.DATE_CONFIRM = Date.Now
        'dao.fields.STATUS_ID = 78
        'dao.Update()

        'gen_xml_jj1()
        'alert("ยกเลิกคำขอแล้ว")
        Dim url As String = ""
        Dim status_is As String = 78
        url = "FRM_HERB_TABEAN_JJ_CENCEL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" _
            & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" _
            & _TR_ID & "&OPF=" & Request.QueryString("OPF") & "&STATUS_ID=" & status_is & "&SID=" & Request.QueryString("SID")
        Response.Redirect(url)
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        'dao.GetdatabyID_IDA(_IDA)
        If _ProcessID = 20304 Then
            Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT_REQUEST.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA=" & _IDA & "&SID=" & Request.QueryString("SID"))
        Else
            Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT_REQUEST.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA=" & _IDA & "&SID=" & Request.QueryString("SID"))

        End If
    End Sub

    'Private Sub btn_edit_uploadfile_Click(sender As Object, e As EventArgs) Handles btn_edit_uploadfile.Click
    '    'Windows.parent.close_modal()
    '    'Response.Write("<script type='text/javascript'>alert('" + "ต้องการแก้ไขไฟล์อัพโหลด" + "');parent.close_modal();</script> ")
    '    'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)

    '    Dim url As String = ""
    '    url = "FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN
    '    Response.Write("<script type='text/javascript'>alert('" + "ต้องการแก้ไขไฟล์อัพโหลด" + "');parent.close_modal();window.location='" & url & "';</script> ")

    '    'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)

    'End Sub

    Protected Sub btn_cancle_request_Click(sender As Object, e As EventArgs) Handles btn_cancle_request.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        'dao.fields.STATUS_ID = 75
        'dao.Update()

        'gen_xml_jj1()
        'alert("ยกเลิกคำขอแล้ว")
        Dim url As String = ""
        Dim status_is As String = 75
        url = "FRM_HERB_TABEAN_JJ_CENCEL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" _
            & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" _
            & _TR_ID & "&OPF=" & Request.QueryString("OPF") & "&STATUS_ID=" & status_is & "&SID=" & Request.QueryString("SID")
        Response.Redirect(url)
    End Sub
    Sub alert_EditUp(ByVal text As String)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE_EDIT.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&SID=" & Request.QueryString("SID")
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_editUpload_Click(sender As Object, e As EventArgs) Handles btn_editUpload.Click
        alert("test")
        'alert_EditUp("test")

        'Dim url As String = ""
        'url = "FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN
        'Response.Write("<script type='text/javascript'>alert('" + "ต้องการแก้ไขไฟล์อัพโหลด" + "');parent.close_modal();window.location='" & url & "';</script> ")

        Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE_EDIT.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _ProcessID & "&IDA=" & _IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&SID=" & Request.QueryString("SID"))
    End Sub
    Function bind_data_uploadfile_4()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim Type_ID As Integer = 0
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(_IDA, _TR_ID, _ProcessID)
        Type_ID = dao_up.fields.TYPE
        'dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN(_TR_ID, 3, _ProcessID, dao.fields.IDA_LCN)
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 2, _ProcessID, _IDA)
        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_4()
    End Sub
    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_ST")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

End Class
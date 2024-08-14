Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_STAFF_JJ_APPROVE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
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
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/จจ๒.pdf'></iframe>"
            'Run_Pdf_Tabean_Herb_8()
            Run_Pdf_Tabean_Herb_JJ2()
            bind_data()

            UC_ATTACH1.NAME = "เอกสาร จจ.2 ที่อนุมัติแล้ว"
            UC_ATTACH1.BindData("เอกสาร จจ.2 ที่อนุมัติแล้ว", 1, "pdf", "0", "13")

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao.GetdatabyID_TR_ID_PROCESS_ID(_TR_ID, _ProcessID)
            Dim status_upload13 As Integer = dao.fields.TYPE
            If status_upload13 = 13 Then
                uc_upload1.Visible = False
                uc_upload1_btn.Visible = False
                uc_upload1_radgrid.Visible = True
                RadGrid4.DataBind()
            End If

        End If
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_JJ2()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ2", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Public Sub Run_Pdf_Tabean_Herb_8()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

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

    Public Sub bind_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        Dim DD_STATUS As Integer = dao.fields.STATUS_ID
        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        RCVNO_FULL.Text = dao.fields.RCVNO_FULL
        RGTNO_FULL.Text = dao.fields.RGTNO_FULL
        DATE_APP.Text = dao.fields.DATE_APP
        NOTE_APP.Text = dao.fields.NOTE_APP
        OFF_APP.Text = dao.fields.OFF_APP

        Dim dao_status As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_STATUS_JJ
        dao_status.Getdataby_STATUS_ID(DD_STATUS)
        STATUS.Text = dao_status.fields.STATUS_NAME


        Dim dao_tr As New DAO_TABEAN_HERB.TB_TABEAN_TRANSACTION_JJ
        dao_tr.GetdatabyID_FK_IDA_JJ(_IDA)
        Dim dao_st As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_STATUS_JJ
        dao_st.Getdataby_STATUS_ID_GROUP(dao.fields.STATUS_ID, 2)
        'NAME_ST.Text = dao_st.fields.STATUS_NAME
        STAFF_NAME.Text = dao_tr.fields.STAFF_NAME

        txt_edit_staff.Text = dao.fields.NOTE_EDIT

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

    Protected Sub btn_download_jj1_Click(sender As Object, e As EventArgs) Handles btn_download_jj1.Click
        'Response.ContentType = "Application/pdf"
        'Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf")
        'Response.TransmitFile(Server.MapPath("../PDF/จจ๑.PDF"))

        'Dim bao_app As New BAO.AppSettings
        'bao_app.RunAppSettings()

        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        'dao.GetdatabyID_IDA(_IDA)

        'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ1", 0)

        'Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path

        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        'Dim FILENAME_PDF_OUTPUT As String = NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        'load_PDF(PATH_PDF_OUTPUT, FILENAME_PDF_OUTPUT)

        Dim Url As String = "FRM_HERB_TABEAN_STAFF_JJ_PREVIEW_JJ1.aspx?IDA=" & _IDA
        Response.Write("<script>window.open('" & Url & "','_blank')</script>")

    End Sub

    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    Function bind_data_file_recipe_production()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        dt = bao.SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ(dao.fields.DD_HERB_NAME_ID, _ProcessID)

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
            Dim DD_HERB_NAME_PRODUCT_ID As Integer = item("DD_HERB_NAME_PRODUCT_ID").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_RECIPE_PRODUCT_PREVIEW_FILE.aspx?IDA=" & IDA

        End If

    End Sub

    Protected Sub btn_savefileapprove_jj2_Click(sender As Object, e As EventArgs) Handles btn_savefileapprove_jj2.Click

        If UC_ATTACH1.CHK_JJ = False Then
            alert_nature("กรุณาแนบไฟล์ เอกสาร จจ.2 ที่อนุมัติแล้ว")
        ElseIf UC_ATTACH1.CHK_JJ = False Then
            alert_nature("กรุณาแนบไฟล์ เอกสาร จจ.2 ที่อนุมัติแล้ว")
        Else
            UC_ATTACH1.insert_JJ2(_TR_ID, _ProcessID, _IDA, 13)
            alert_summit("อัพโหลดเอกสารแนบ จจ.2 เรียบร้อย")
        End If

        uc_upload1.Visible = False
        uc_upload1_btn.Visible = False
        uc_upload1_radgrid.Visible = True
        RadGrid4.Rebind()
    End Sub

    Sub alert_summit(ByVal text As String)
        'Dim url As String = ""
        'url = "FRM_HERB_TABEAN_ADD_DETAIL_UPLOAD_FILE.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ
        'Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Sub alert_nature(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Function bind_data_uploadfile_13()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 13, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_13()
    End Sub

    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Function bind_data_uploadfile_5()
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

    Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
        RadGrid5.DataSource = bind_data_uploadfile_5()
    End Sub
    Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_ST")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub
    Protected Sub DDL_JJ2_SELECT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_JJ2_SELECT.SelectedIndexChanged
        If DDL_JJ2_SELECT.SelectedValue = 1 Then
            Run_Pdf_Tabean_Herb_JJ2()
        Else
            Run_Pdf_Tabean_Herb_JJ2_LONG()
        End If
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_JJ2_LONG()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ2", 1)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
End Class
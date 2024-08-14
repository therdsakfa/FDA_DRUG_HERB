Imports Telerik.Web.UI
Public Class POPUP_SEARCH_TABEAN_DETAIL
        Inherits System.Web.UI.Page
        Private _CLS As New CLS_SESSION
        Private _IDA As String
    Private _TR_ID As Integer
    Private _ProcessID As String
    Private _IDA_LCN As String
    Private _Newcode As String
    Private _IDA_G As String
    Private _YEARS As String
    Dim _group As Integer = 0

    Sub RunSession()
        _ProcessID = Request.QueryString("process_id")
        _IDA = Request.QueryString("IDA")
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception
            _TR_ID = 0
        End Try

        _IDA_LCN = Request.QueryString("IDA_LCN")
        _Newcode = Request.QueryString("Newcode")
        _IDA_G = Request.QueryString("IDA_G")
        Try
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception

        End Try
        Try
                _CLS = Session("CLS")
            Catch ex As Exception
                Response.Redirect("http://privus.fda.moph.go.th/")
            End Try
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            RunSession()
        If Not IsPostBack Then
            HiddenField2.Value = 0
            If _ProcessID = "1400001" Then
                BindData_PDF_SAI(_Newcode)
            Else
                'Run_Pdf_Tabean_Herb()
                Run_Pdf_Tabean_Herb_2_8()
            End If
            bind_data()

        End If
    End Sub

        Public Sub Run_Pdf_Tabean_Herb()
            Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim dao_dg As New DAO_DRUG.ClsDBdrrgt
        dao_dg.GetDataby_IDA(_IDA)
        Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_dq.GetDataby_IDA(dao_dg.fields.FK_DRRQT)
            dao.GetdatabyID_FK_IDA_DQ(dao_dg.fields.FK_DRRQT)
        Catch ex As Exception

        End Try

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_dq.fields.STATUS_ID, "ทบ2", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path

            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)

            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        End Sub
        Public Sub Run_Pdf_Tabean_Herb_Long()
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()
            Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
            dao_dq.GetDataby_IDA(_IDA)
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_dq.fields.STATUS_ID, "ทบ2", 1)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path

            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)

            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        End Sub

        Public Sub Run_Pdf_Tabean_Herb_2_8()
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
            dao_deeqt.GetDataby_IDA(_IDA)
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(_IDA)
            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
            TBN_NEW = XML.gen_xml_tbn_2(dao.fields.IDA, _IDA, _IDA_LCN)
            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "ทบ2", 0)


            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

            _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
            _CLS.PDFNAME = PATH_PDF_OUTPUT
            _CLS.FILENAME_XML = Path_XML
            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        End Sub
        Public Sub bind_data()
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)
            Dim DD_STATUS As Integer = dao.fields.STATUS_ID
        'RCVNO_FULL.Text = dao.fields.RCVNO_NEW
        If dao.fields.RGTNO_NEW IsNot Nothing Then RGTNO_FULL.Text = dao.fields.RGTNO_NEW Else RGTNO_FULL.Text = "-"
        If dao.fields.SIGN_NAME IsNot Nothing Then OFF_APP.Text = dao.fields.SIGN_NAME Else OFF_APP.Text = "-"
        If dao.fields.appdate IsNot Nothing Then DATE_APP.Text = dao.fields.appdate Else DATE_APP.Text = "-"
        'If dao.fields.NOTE_APPROVE IsNot Nothing Then NOTE_APP.Text = dao.fields.NOTE_APPROVE Else NOTE_APP.Text = "-"
        'NOTE_APP.Text = dao.fields.NOTE_APPROVE
        Dim dao_status As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_STATUS_JJ
            dao_status.Getdataby_STATUS_ID(DD_STATUS)
        'STATUS.Text = dao_status.fields.STATUS_NAME
        'TXT_STAFF_NAME_EDIT.Text = dao.fields.EDIT_RQ_NAME
        'TXT_STAFF_NAME_EDIT2.Text = dao.fields.EDIT_RQ2_NAME
        Dim dao_edit As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao_edit.GetdatabyID_FK_IDA(_IDA_G)
        If dao_edit.fields.IDA <> 0 Then
            div_edit1.Visible = True
        Else
            div_edit1.Visible = False
        End If

    End Sub

        Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao_G As New DAO_DRUG.ClsDBdrrgt
        dao_G.GetDataby_IDA(_IDA_G)
        Dim TR_ID As String = 0
        If dao_G.fields.TR_ID IsNot Nothing Then TR_ID = dao_G.fields.TR_ID
        If _ProcessID = "1400001" Then
            If TR_ID <> "" And TR_ID <> "0" Then
                Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
                dao.GetDataby_TR_ID(TR_ID) 'ดึงข้อมูลโดยการ where TR_ID
                RG_EDIT.DataSource = dao.datas 'ใส่ข้อมูลลงตาราง
                RG_EDIT.DataBind() 'รันข้อมูลทุกrowของตาราง
            Else
                dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 7, _ProcessID, _IDA)
            End If
        Else
            dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 7, _ProcessID, _IDA)
        End If
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
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Private Sub RG_EDIT_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RG_EDIT.NeedDataSource
        RG_EDIT.DataSource = bind_data_log_tabean_edit()
    End Sub
    Private Sub RG_EDIT_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RG_EDIT.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_SEARCH_TABEAN/POPUP_TABEAN_LOG_EDIT_DETAIL.aspx?ida=" & IDA

        End If
    End Sub
    Function bind_data_log_tabean_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        dt = bao.SP_TABEAN_LOG_EDIT_DETAIL_BY_IDA_G(_IDA_G)
        'If dt.Rows IsNot Nothing Then
        '    dt = bao.SP_TABEAN_LOG_EDIT_DETAIL_BY_IDA_G(_IDA)
        'End If
        dt.Columns.Add("NO_EDIT")
        Dim index As Integer = 0
        For Each dr As DataRow In dt.Rows
            index += 1
            dr("NO_EDIT") = "แก้ไขข้อมูลครั้งที่ " & index
        Next
        Return dt
    End Function
    'Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
    '    RadGrid2.DataSource = bind_data_uploadfile_edit()
    'End Sub

    'Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If
    'End Sub

    'Protected Sub btn_download_tb1_Click(sender As Object, e As EventArgs) Handles btn_download_tb1.Click

    '        Dim Url As String = "FRM_HERB_TABEAN_STAFF_TABEAN_PREVIEW_TABEAN1.aspx?IDA=" & _IDA
    '        Response.Write("<script>window.open('" & Url & "','_blank')</script>")

    '    End Sub

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

        Function bind_data_uploadfile_6()
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 6, _ProcessID, _IDA)

        Return dt
        End Function

    'Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
    '    RadGrid3.DataSource = bind_data_uploadfile_6()
    'End Sub

    'Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If
    'End Sub

    Function bind_data_uploadfile_8()
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 8, _ProcessID, _IDA)

        Return dt
        End Function

    '    Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
    '        RadGrid5.DataSource = bind_data_uploadfile_8()
    '    End Sub

    'Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If
    'End Sub
    Sub alert_summit(ByVal text As String)
            'Dim url As String = ""
            'url = "FRM_HERB_TABEAN_ADD_DETAIL_UPLOAD_FILE.aspx?TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&IDA_DQ=" & _IDA_DQ & "&PROCESS_ID_DQ=" & _PROCESS_ID_DQ
            'Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
            Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
        End Sub

        Sub alert_nature(ByVal text As String)
            Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
        End Sub

        Function bind_data_uploadfile_14()
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 14, _ProcessID, _IDA)

        Return dt
        End Function

    'Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
    '    RadGrid4.DataSource = bind_data_uploadfile_14()
    'End Sub

    'Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If
    'End Sub

    'Protected Sub DDL_TB2_SELECT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_TB2_SELECT.SelectedIndexChanged
    '        Dim Url As String = "FRM_HERB_TABEAN_STAFF_TABEAN_PREVIEW_TABEAN2.aspx?IDA=" & _IDA & "&SLDDL=" & DDL_TB2_SELECT.SelectedValue
    '        If DDL_TB2_SELECT.SelectedValue = 1 Then
    '            Run_Pdf_Tabean_Herb()
    '        Else
    '            Run_Pdf_Tabean_Herb_Long()
    '        End If

    '    End Sub
    Function bind_data_uploadfile_9()
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_main
            Dim Type_ID As Integer = 0
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(_IDA)
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(_IDA, _TR_ID, _ProcessID)
            Type_ID = dao_up.fields.TYPE
        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 9, _ProcessID, _IDA)
        Return dt
        End Function

    '    Private Sub RadGrid6_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid6.NeedDataSource
    '        RadGrid6.DataSource = bind_data_uploadfile_9()
    '    End Sub
    'Private Sub RadGrid6_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid6.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As Integer = item("IDA").Text

    '        Dim H As HyperLink = e.Item.FindControl("PV_ST")
    '        H.Target = "_blank"
    '        H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

    '    End If

    'End Sub
    Private Sub BindData_PDF_SAI(ByVal newcode As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""
        Dim lcnno As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drgtpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim tr_id As String = 0
        Dim IDA_regist As Integer = 0
        Dim lcnsid As Integer = 0
        Dim lcntpcd As String = ""
        Dim appdate As Date
        Dim expdate As Date
        Dim pvnabbr As String = ""
        Dim dsgcd As String = ""
        Dim STATUS_ID As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim FK_LCN_IDA As Integer = 0
        Dim wong_lep As String = ""
        Try
            STATUS_ID = Request.QueryString("STATUS_ID") 'Get_drrqt_Status(_IDA)
        Catch ex As Exception

        End Try
        Dim tamrap_id As Integer = 0
        Dim class_xml As New CLASS_DR

        Dim dao_e As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
        dao_e.GetDataby_u1_frn_no(newcode)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        ' dao.GetDataby_IDA(_IDA)
        dao.GetDataby_4key(dao_e.fields.rgtno, dao_e.fields.drgtpcd, dao_e.fields.rgttpcd, dao_e.fields.pvncd)
        Dim dao2 As New DAO_DRUG.ClsDBdrrqt
        Try
            class_xml.drrgts = dao.fields
        Catch ex As Exception

        End Try
        Try
            dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
            'regis_ida = dao.fields.FK_IDA
            tamrap_id = dao2.fields.feepayst
        Catch ex As Exception

        End Try
        Try
            'Dim dao_color As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR			เก่า
            Dim dao_color As New DAO_XML_DRUG_HERB.TB_XML_DRUG_COLOR_HERB
            dao_color.GetDataby_Newcode(newcode)
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_color.fields.drgchrtha
        Catch ex As Exception

        End Try
        Try
            'Dim dao_class As New DAO_DRUG.TB_drkdofdrg
            'dao_class.GetData_by_kindcd(dao.fields.kindcd)
            class_xml.DRUG_CLASS_NAME = dao_e.fields.thakindnm
        Catch ex As Exception

        End Try
        If dao_e.fields.lcntpcd IsNot Nothing Then
            lcntpcd = dao_e.fields.lcntpcd
            Try
                If dao_e.fields.lcntpcd.Contains("ผย") Or dao_e.fields.lcntpcd.Contains("ผส") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try
            lcnno = dao_e.fields.lcnno
            Try
                If dao_e.fields.lcntpcd.Contains("ผยบ") Or dao_e.fields.lcntpcd.Contains("นยบ") Or dao_e.fields.lcntpcd.Contains("ผสม") Or dao_e.fields.lcntpcd.Contains("นสม") Then
                    TABEAN_TYPE1 = "1"
                    'cls_xml.TABEAN_TYPE2 = "2"
                Else
                    TABEAN_TYPE1 = "2"
                    'cls_xml.TABEAN_TYPE2 = "0"
                End If
            Catch ex As Exception

            End Try
        End If

        Try
            CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
        Catch ex As Exception

        End Try
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
        Try
            dao_rq.GetDataby_IDA(dao.fields.FK_DRRQT)
        Catch ex As Exception

        End Try

        Try
            IDA_regist = dao_rq.fields.FK_IDA
        Catch ex As Exception

        End Try
        Try
            FK_LCN_IDA = dao.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Try
            lcnsid = dao.fields.lcnsid
        Catch ex As Exception

        End Try

        DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
        pvncd = dao_e.fields.pvncd
        rgttpcd = dao_e.fields.rgttpcd
        dsgcd = dao_e.fields.dsgcd
        Try
            STATUS_ID = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try

        Try
            rcvno_auto = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao_e.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = dao_e.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            drgtpcd = dao_e.fields.drgtpcd
        Catch ex As Exception

        End Try
        Try
            appdate = dao.fields.appdate
        Catch ex As Exception

        End Try
        Try
            expdate = dao_e.fields.expdate
        Catch ex As Exception

        End Try
        pvnabbr = dao_e.fields.pvnabbr
        Try
            drug_name_th = dao_e.fields.thadrgnm
            'drug_name
        Catch ex As Exception
            drug_name_th = "-"
        End Try
        Try
            drug_name_eng = dao_e.fields.engdrgnm
        Catch ex As Exception
            drug_name_eng = "-"
        End Try

        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(IDA_regist)
        Catch ex As Exception

        End Try

        Dim dao_lcn As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        Try
            dao_lcn.GetDataby_u1(dao_e.fields.Newcode_not)
            lcntpcd = dao_lcn.fields.lcntpcd
            pvnabbr = dao_lcn.fields.pvnabbr
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        'Dim _process As Integer = 0
        'Try
        '    Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        '    dao_tr.GetDataby_IDA(tr_id)
        '    _process = dao_tr.fields.PROCESS_ID
        'Catch ex As Exception

        'End Try


        Try
            class_xml.DRUG_STRENGTH = dao_e.fields.potency
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)
            'Dim dao_cas As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_IOW
            'dao_cas.GetDataby_Newcode_U(newcode)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
            'class_xml.DRRGT_DETAIL_Cs.AORI = dao_cas.fields.aori
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try




        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        If lcntpcd IsNot Nothing Then
            Try
                head_type = ""
                If lcntpcd.Contains("บ") Or lcntpcd.Contains("สม") Then
                    head_type = "โบราณ"
                Else
                    head_type = "ปัจจุบัน"
                End If
            Catch ex As Exception

            End Try
        End If

        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try

            dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_dos.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try

        Try
            pvncd = pvncd
        Catch ex As Exception
            pvncd = ""
        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try



        If IsNothing(appdate) = False Then
            Dim appdate2 As Date
            If Date.TryParse(appdate, appdate2) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                If class_xml.SHOW_LCNDATE_YEAR = 544 Then
                    class_xml.SHOW_LCNDATE_DAY = ""
                    class_xml.SHOW_LCNDATE_MONTH = ""
                    class_xml.SHOW_LCNDATE_YEAR = ""
                End If

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If

        If IsNothing(expdate) = False Then
            Dim expdate2 As Date
            If Date.TryParse(expdate, expdate2) = True Then
                class_xml.EXPDAY = expdate.Day
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXP_YEAR = con_year(expdate.Year)
                Try
                    class_xml.EXPDATESHORT = expdate.Day & "/" & expdate.Month & "/" & con_year(expdate.Year)
                Catch ex As Exception

                End Try

                If class_xml.EXP_YEAR = 544 Then
                    class_xml.EXPDAY = ""
                    class_xml.EXPMONTH = ""
                    class_xml.EXP_YEAR = ""
                    class_xml.EXPDATESHORT = ""
                End If


            End If
        End If

        Dim aa As String = ""
        Dim aa2 As String = ""

        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = dao_e.fields.register 'rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try
        Dim pvnabbr2 As String = ""
        Try
            pvnabbr2 = dao_e.fields.pvnabbr2
        Catch ex As Exception

        End Try
        If lcntpcd IsNot Nothing Then
            Try

                'If dao_e.fields.lcntpcd.Contains("ผย1") Then
                '    If dao_e.fields.pvnabbr = "กท" Then
                '        lcnno_format = CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
                '    Else
                '        lcnno_format = dao_e.fields.pvnabbr2 & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2)
                '    End If

                'Else
                If lcntpcd.Contains("สม") Then
                    lcnno_format = dao_lcn.fields.lcnno_display_new
                Else
                    lcnno_format = pvnabbr2 & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
                End If

                'End If


            Catch ex As Exception
                lcnno_format = pvnabbr2 & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
            End Try
        End If

        'dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)

        Try
            rcvno_format = dao_e.fields.register_rcvno 'rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
        Catch ex As Exception

        End Try

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If


        Try
            rgtno_format = dao_e.fields.register
        Catch ex As Exception

        End Try


        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = "ไทย"
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        class_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2

        Dim bao_show As New BAO_SHOW
        Try
            class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.IDA_dalcn) 'ข้อมูลสถานที่จำลอง
        Catch ex As Exception

        End Try


        Try
            Dim dt_thanm As DataTable = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_e.fields.Identify, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            For Each dr As DataRow In dt_thanm.Rows
                dr("thanm") = dao_e.fields.licen_loca
            Next
            'Dim dt_thanm2 As DataTable
            'dt_thanm2 = dt_thanm.Clone
            'Dim dr_nm As DataRow = dt_thanm2.NewRow()
            'dr_nm("thanm") = dao_e.fields.licen_loca
            'dt_thanm2.Rows.Add(dr_nm)
            class_xml.DT_SHOW.DT17 = dt_thanm
        Catch ex As Exception

        End Try

        'Dim dao_det_prop As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR			เก่า
        Dim dao_det_prop As New DAO_XML_DRUG_HERB.TB_XML_DRUG_COLOR_HERB
        dao_det_prop.GetDataby_Newcode(newcode)
        Try
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.drgchrtha
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 1)
        class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 2)
        class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 10)
        class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"

        class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 3)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"



        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        dao_dal.GetDataby_IDA(dao_lcn.fields.IDA)
        class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_NEWCODE_SAI(newcode)
        class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        class_xml.DT_SHOW.DT23 = bao_show.SP_drrgt_cas(_IDA)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        class_xml.DT_SHOW.DT21 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(dao.fields.IDA, 9, LCNTPCD_GROUP)
        class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
        class_xml.DT_SHOW.DT23 = bao_show.SP_DRRGT_CAS_EQTO(_IDA)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"


        Dim lcntype As String = "0" 'dao.fields.lcntpcd

        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(_ProcessID)
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
        Catch ex As Exception

        End Try




        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(_ProcessID, STATUS_ID, HiddenField2.Value, 0)
        '------------------------(E)------------------------
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try

            dao = New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_IDA)
            dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
            E_VALUE = dao_drgtpcd.fields.engdrgtpnm

        Catch ex As Exception

        End Try

        Dim NAME_TEMPLATE As String = ""
        If E_VALUE <> "(E)" Then
            NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE

            If Request.QueryString("STATUS_ID") = "8" Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    'NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    Try
                        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                        dao_rg.GetDataby_IDA(_IDA)
                        dao_rq = New DAO_DRUG.ClsDBdrrqt
                        dao_rq.GetDataby_IDA(dao_rg.fields.FK_DRRQT)
                        Dim dao_tr As New DAO_DRUG.TB_MAS_TAMRAP_NAME
                        dao_tr.GetDataby_TAMRAP_ID(dao_rq.fields.dvcd)
                        If rgttpcd = "G" And dao_tr.fields.IS_AUTO = 1 Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        Else
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Else

            End If

            If Request.QueryString("STATUS_ID") = "14" Or Request.QueryString("STATUS_ID") = "18" And HiddenField2.Value = 1 Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                End If
            End If
        Else
            If Request.QueryString("STATUS_ID") = "8" Or Request.QueryString("STATUS_ID") = "14" Then
                NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"
            Else
                NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            End If
        End If

        '-----------------------------------------------------



        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_OUTPUT As String = ""
        Dim XML_PATH As String = ""

        If STATUS_ID = "1" Then
            PDF_OUTPUT = "PDF_TRADER_STAFF_UPLOAD"
            XML_PATH = "XML_TRADER_STAFF_UPLOAD"
        ElseIf STATUS_ID = "2" Or STATUS_ID = "3" Or STATUS_ID = "4" Then
            PDF_OUTPUT = "PDF_TRADER_STAFF_EMP"
            XML_PATH = "XML_TRADER_STAFF_EMP"
        Else
            PDF_OUTPUT = dao_pdftemplate.fields.PDF_OUTPUT
            XML_PATH = dao_pdftemplate.fields.XML_PATH
        End If

        If tamrap_id <> 0 Then
            If Request.QueryString("status") = "8" Then
                Dim dao3 As New DAO_DRUG.ClsDBdrrgt
                dao3.GetDataby_IDA(_IDA)
                dao_rq = New DAO_DRUG.ClsDBdrrqt
                Try
                    dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                    If dao_rq.fields.feetpcd = "1" Then
                        NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                    ElseIf dao_rq.fields.feetpcd = "99" Then
                        NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    End If
                Catch ex As Exception

                End Try

            ElseIf Request.QueryString("status") = "15" Or Request.QueryString("status") = "14" Then
                If HiddenField2.Value = "1" Then
                    dao_rq = New DAO_DRUG.ClsDBdrrqt
                    Try
                        dao_rq.GetDataby_IDA(_IDA)
                        If dao_rq.fields.feetpcd = "1" Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        ElseIf dao_rq.fields.feetpcd = "99" Then
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
                End If

            Else
                NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
            End If
        End If



        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE 'dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID) ' dao_pdftemplate.fields.PDF_OUTPUT
        Dim Path_XML As String = paths & XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID) 'dao_pdftemplate.fields.XML_PATH
        Try
            Dim url As String = ""
            ' If Request.QueryString("status") = 8 Or Request.QueryString("status") = 14 Then
            url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
            'Else
            '    url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF_VIEW.aspx?filename=" & filename
            'End If

            'Dim url As String 
            class_xml.QR_CODE = QR_CODE_IMG(url)
        Catch ex As Exception

        End Try
        p_dr = class_xml
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename

    End Sub
    'Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click

    '    If HiddenField2.Value = 0 Then
    '        HiddenField2.Value = 1
    '        _group = 1
    '    ElseIf HiddenField2.Value = 1 Then
    '        HiddenField2.Value = 0
    '        _group = 0
    '    End If
    '    BindData_PDF()
    'End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""
        Dim lcnno As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drgtpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim tr_id As String = 0
        Dim IDA_regist As Integer = 0
        Dim lcnsid As Integer = 0
        Dim lcntpcd As String = ""
        Dim appdate As Date
        Dim expdate As Date
        Dim pvnabbr As String = ""
        Dim dsgcd As String = ""
        Dim STATUS_ID As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim FK_LCN_IDA As Integer = 0
        Dim wong_lep As String = ""
        Try
            STATUS_ID = Request.QueryString("STATUS_ID") 'Get_drrqt_Status(_IDA)
        Catch ex As Exception

        End Try
        Dim tamrap_id As Integer = 0
        Dim class_xml As New CLASS_DR
        If STATUS_ID <> 8 Then
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)
            Try
                tamrap_id = dao.fields.feepayst
            Catch ex As Exception

            End Try
            Try
                If dao.fields.lcntpcd.Contains("ผย") Or dao.fields.lcntpcd.Contains("ผส") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try

            lcnno = dao.fields.lcnno
            IDA_regist = dao.fields.FK_IDA
            tr_id = dao.fields.TR_ID
            lcnsid = dao.fields.lcnsid
            DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            pvncd = dao.fields.pvncd
            rgttpcd = dao.fields.rgttpcd
            dsgcd = dao.fields.dsgcd
            STATUS_ID = dao.fields.STATUS_ID
            'Try
            '    TABEAN_TYPE1 = dao.fields.TABEAN_TYPE
            'Catch ex As Exception

            'End Try
            Try
                TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try

            Try
                rcvno_auto = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                FK_LCN_IDA = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            Try
                lcnno_auto = dao.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                rgtno_auto = dao.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                drgtpcd = dao.fields.drgtpcd
            Catch ex As Exception

            End Try
            Try
                appdate = dao.fields.appdate
            Catch ex As Exception

            End Try
            Try
                expdate = dao.fields.expdate
            Catch ex As Exception

            End Try
            pvnabbr = dao.fields.pvnabbr
            Try
                drug_name_th = dao.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try
                class_xml.drrqts = dao.fields
            Catch ex As Exception

            End Try
            Try
                Dim dao_class As New DAO_DRUG.TB_drkdofdrg
                dao_class.GetData_by_kindcd(dao.fields.kindcd)
                class_xml.DRUG_CLASS_NAME = dao_class.fields.thakindnm
            Catch ex As Exception

            End Try

        Else

            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_IDA)
            Dim dao2 As New DAO_DRUG.ClsDBdrrqt
            Try
                class_xml.drrgts = dao.fields
            Catch ex As Exception

            End Try
            Try
                dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
                'regis_ida = dao.fields.FK_IDA
                tamrap_id = dao2.fields.feepayst
            Catch ex As Exception

            End Try
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try
                Dim dao_class As New DAO_DRUG.TB_drkdofdrg
                dao_class.GetData_by_kindcd(dao.fields.kindcd)
                class_xml.DRUG_CLASS_NAME = dao_class.fields.thakindnm
            Catch ex As Exception

            End Try
            Try
                If dao.fields.lcntpcd.Contains("ผย") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try
            lcnno = dao.fields.lcnno
            Try
                If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                    TABEAN_TYPE1 = "1"
                    'cls_xml.TABEAN_TYPE2 = "2"
                Else
                    TABEAN_TYPE1 = "2"
                    'cls_xml.TABEAN_TYPE2 = "0"
                End If
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
            Try
                dao_rq.GetDataby_IDA(dao.fields.FK_DRRQT)
            Catch ex As Exception

            End Try

            Try
                IDA_regist = dao_rq.fields.FK_IDA
            Catch ex As Exception

            End Try
            Try
                FK_LCN_IDA = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            Try
                lcnsid = dao.fields.lcnsid
            Catch ex As Exception

            End Try

            DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            pvncd = dao.fields.pvncd
            rgttpcd = dao.fields.rgttpcd
            dsgcd = dao.fields.dsgcd
            Try
                STATUS_ID = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try

            Try
                rcvno_auto = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                lcnno_auto = dao.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                rgtno_auto = dao.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                drgtpcd = dao.fields.drgtpcd
            Catch ex As Exception

            End Try
            Try
                appdate = dao.fields.appdate
            Catch ex As Exception

            End Try
            Try
                expdate = dao.fields.expdate
            Catch ex As Exception

            End Try
            pvnabbr = dao.fields.pvnabbr
            Try
                drug_name_th = dao.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
        End If

        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(IDA_regist)
        Catch ex As Exception

        End Try

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(FK_LCN_IDA)
        Catch ex As Exception

        End Try
        Try
            lcntpcd = dao_lcn.fields.lcntpcd

        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_lcn.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        Catch ex As Exception

        End Try
        Dim _process As Integer = 0
        Try
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_tr.GetDataby_IDA(tr_id)
            _process = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try


        Try
            class_xml.DRUG_STRENGTH = DRUG_STRENGTH
        Catch ex As Exception

        End Try

        Try
            Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
            dao_color.GetDataby_FK_IDA(_IDA)
            class_xml.DRRGT_COLORs = dao_color.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try




        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        Try
            head_type = ""
            If lcntpcd.Contains("บ") Or lcntpcd.Contains("สม") Then
                head_type = "โบราณ"
            Else
                head_type = "ปัจจุบัน"
            End If
        Catch ex As Exception

        End Try

        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try

            dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_dos.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try

        Try
            pvncd = pvncd
        Catch ex As Exception
            pvncd = ""
        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try



        If IsNothing(appdate) = False Then
            Dim appdate2 As Date
            If Date.TryParse(appdate, appdate2) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                If class_xml.SHOW_LCNDATE_YEAR = 544 Then
                    class_xml.SHOW_LCNDATE_DAY = ""
                    class_xml.SHOW_LCNDATE_MONTH = ""
                    class_xml.SHOW_LCNDATE_YEAR = ""
                End If

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If

        If IsNothing(expdate) = False Then
            Dim expdate2 As Date
            If Date.TryParse(expdate, expdate2) = True Then
                class_xml.EXPDAY = expdate.Day
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXP_YEAR = con_year(expdate.Year)
                Try
                    class_xml.EXPDATESHORT = expdate.Day & "/" & expdate.Month & "/" & con_year(expdate.Year)
                Catch ex As Exception

                End Try

                If class_xml.EXP_YEAR = 544 Then
                    class_xml.EXPDAY = ""
                    class_xml.EXPMONTH = ""
                    class_xml.EXP_YEAR = ""
                    class_xml.EXPDATESHORT = ""
                End If


            End If
        End If

        Dim aa As String = ""
        Dim aa2 As String = ""
        If Request.QueryString("status") = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try

            Try
                Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
                daodrgtype2.GetDataby_drgtpcd(dao_rq.fields.rgtdrgtpcd)

                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        Else
            Dim dao3 As New DAO_DRUG.ClsDBdrrqt
            dao3.GetDataby_IDA(_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype2.GetDataby_drgtpcd(dao3.fields.rgtdrgtpcd)
            Try
                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        End If
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try
        'If pvncd <> "" Then
        '    If pvncd <> "10" Then
        '        rgtno_format &= " " & "(" & pvncd & ")"
        '    End If
        'End If
        'Try
        '    If Len(rgtno_auto) > 0 Then
        '        rgtno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try


        Try
            If STATUS_ID = 8 Then
                If Len(lcnno_auto) > 0 Then
                    'If pvnabbr <> "กท" Then
                    '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    '    Else
                    '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    End If
                    'Else

                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                    dao4.GetDataby_IDA(_IDA)
                    'If dao4.fields.USE_PVNABBR2 IsNot Nothing Then
                    '    'If dao4.fields.USE_PVNABBR2 = "1" Then
                    '    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    'End If
                    'Else
                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    End If
                End If
            Else
                If Len(lcnno_auto) > 0 Then
                    'If pvnabbr <> "กท" Then
                    '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    '    Else
                    '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    End If
                    'Else

                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    Dim dao4 As New DAO_DRUG.ClsDBdrrqt
                    dao4.GetDataby_IDA(_IDA)
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

        'Try
        '    If Len(lcnno_auto) > 0 Then

        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
        '        Else
        '            lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try
        Try
            If Len(rcvno_auto) > 0 Then
                If aa2 = "(NG)" Then
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
                Else
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
                End If

            End If
        Catch ex As Exception

        End Try

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            'drug_name = drug_name_th

            'drug_name = drug_name_th & " / " & drug_name_eng
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If
        If STATUS_ID = 8 Then
            Dim dt_rgtno As New DataTable
            Dim bao_rgtno As New BAO.ClsDBSqlcommand
            dt_rgtno = bao_rgtno.SP_DRRGT_RGTNO_DISPLAY_BY_IDA(_IDA)
            Try
                rgtno_format = dt_rgtno(0)("rgtno_display")
            Catch ex As Exception

            End Try
        Else
            Dim dt_rgtno As New DataTable
            Dim bao_rgtno As New BAO.ClsDBSqlcommand
            dt_rgtno = bao_rgtno.SP_DRRQT_RGTNO_DISPLAY_BY_IDA(_IDA)
            Try
                rgtno_format = dt_rgtno(0)("rgtno_display")
            Catch ex As Exception

            End Try
        End If
        'drug_name = drug_name_th & "/" & drug_name_eng
        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = "ไทย"
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        class_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2
        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try


        Dim bao_show As New BAO_SHOW
        Try
            class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid) 'ข้อมูลบริษัท
        Try
            If STATUS_ID = "8" Then
                Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                dao4.GetDataby_IDA(_IDA)
                class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao4.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            Else
                Dim dao4 As New DAO_DRUG.ClsDBdrrqt
                dao4.GetDataby_IDA(_IDA)
                class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao4.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            End If
        Catch ex As Exception

        End Try
        'class_xml.DT_SHOW.DT3 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน

        'class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ
        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ

        If STATUS_ID <> 8 Then

            Dim dao_det_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            dao_det_prop.GetDataby_FKIDA(_IDA)
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
            Catch ex As Exception

            End Try

            Dim dt_pack As New DataTable
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRQT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
            Try
                PACK_SIZE = dt_pack(0)("contain_detail")
                class_xml.PACK_SIZE = PACK_SIZE
            Catch ex As Exception

            End Try
            Try
                Dim dao_dpn As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
                dao_dpn.GetDataby_FKIDA(_IDA)
                class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
            Catch ex As Exception

            End Try

            class_xml.DT_SHOW.DT8 = bao_show.SP_DRRQT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
            class_xml.DT_SHOW.DT9 = bao_show.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
            class_xml.DT_SHOW.DT9.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
            class_xml.DT_SHOW.DT20 = bao_show.SP_DRRQT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRRQT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
            class_xml.DT_SHOW.DT12 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRQT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ


            'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRQT_DATA(_IDA)

            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 1)
            class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
            class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
            class_xml.DT_SHOW.DT15 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
            class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"

            class_xml.DT_SHOW.DT16 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 10)
            class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"
            Try
                class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao_lcn.fields.FK_IDA)
                class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
            Catch ex As Exception

            End Try

            class_xml.DT_SHOW.DT23 = bao_show.SP_drrqt_cas(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"

            class_xml.DT_SHOW.DT21 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
            class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"

            class_xml.DT_SHOW.DT23 = bao_show.SP_DRRQT_CAS_EQTO(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"


        Else
            'Dim dao_rq As New DAO_DRUG.ClsDBdrrgt
            'dao_rq.GetDataby_FK_DRRQT(_IDA)
            '_IDA = dao_rq.fields.IDA

            Dim dao_det_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            dao_det_prop.GetDataby_FK_IDA(_IDA)
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
            Catch ex As Exception

            End Try

            Dim dt_pack As New DataTable
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
            Try
                PACK_SIZE = dt_pack(0)("contain_detail")
                class_xml.PACK_SIZE = PACK_SIZE
            Catch ex As Exception

            End Try
            Try
                Dim dao_dpn As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
                dao_dpn.GetDataby_FKIDA(_IDA)
                class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
            Catch ex As Exception

            End Try
            class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
            class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
            class_xml.DT_SHOW.DT10 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT10.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
            class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
            'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_DATA(_IDA)

            'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
            'class_xml.DT_SHOW.DT15.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_2NO"
            'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
            'class_xml.DT_SHOW.DT16.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_3NO"
            'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 4)
            'class_xml.DT_SHOW.DT17.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_4NO"

            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 1)
            class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 2)
            class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
            class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 10)
            class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"

            class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 3)
            class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"

            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao_lcn.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
            class_xml.DT_SHOW.DT23 = bao_show.SP_drrgt_cas(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"
            class_xml.DT_SHOW.DT21 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
            class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
            class_xml.DT_SHOW.DT23 = bao_show.SP_DRRGT_CAS_EQTO(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        End If

        Dim lcntype As String = "0" 'dao.fields.lcntpcd
        'Try
        '    Dim rcvdate As Date = dao.fields.rcvdate
        '    dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
        '    class_xml.drrgts = dao.fields



        'Catch ex As Exception

        'End Try
        'Try
        '    lcntype = dao.fields.rgttpcd
        'Catch ex As Exception

        'End Try

        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(_ProcessID)
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try




        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        ''dao_pdftemplate.GetDataby_TEMPLAETE(_process, lcntype, statusId, 0)

        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(_ProcessID, STATUS_ID, HiddenField2.Value, 0)
        '------------------------(E)------------------------
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try
            If Request.QueryString("STATUS_ID") = "8" Then 'Or Request.QueryString("STATUS_ID") = "14"
                Dim dao As New DAO_DRUG.ClsDBdrrgt
                dao.GetDataby_IDA(_IDA)
                dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
                E_VALUE = dao_drgtpcd.fields.engdrgtpnm
            Else
                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)
                dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
                Try
                    E_VALUE = dao_drgtpcd.fields.engdrgtpnm
                Catch ex As Exception
                    E_VALUE = ""
                End Try

            End If
        Catch ex As Exception

        End Try
        'Dim NAME_TEMPLATE As String = ""
        'If E_VALUE <> "(E)" Then
        '    NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
        'Else
        '    If Request.QueryString("STATUS_ID") = "8" Then
        '        If HiddenField2.Value = 1 Then
        '            NAME_TEMPLATE = "DA_YOR_2_E.pdf"
        '        Else
        '            NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"
        '        End If
        '    Else
        '        NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
        '    End If
        'End If
        Dim NAME_TEMPLATE As String = ""
        If E_VALUE <> "(E)" Then
            NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE

            If Request.QueryString("STATUS_ID") = "8" Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    'NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    Try
                        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                        dao_rg.GetDataby_IDA(_IDA)
                        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                        dao_rq.GetDataby_IDA(dao_rg.fields.FK_DRRQT)
                        Dim dao_tr As New DAO_DRUG.TB_MAS_TAMRAP_NAME
                        dao_tr.GetDataby_TAMRAP_ID(dao_rq.fields.dvcd)
                        If rgttpcd = "G" And dao_tr.fields.IS_AUTO = 1 Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        Else
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Else

            End If

            If Request.QueryString("STATUS_ID") = "14" And HiddenField2.Value = 1 Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                End If
            End If
        Else
            If Request.QueryString("STATUS_ID") = "8" Or Request.QueryString("STATUS_ID") = "14" Then
                NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"
            Else
                NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            End If
        End If

        '-----------------------------------------------------



        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_OUTPUT As String = ""
        Dim XML_PATH As String = ""

        If STATUS_ID = "1" Then
            PDF_OUTPUT = "PDF_TRADER_STAFF_UPLOAD"
            XML_PATH = "XML_TRADER_STAFF_UPLOAD"
        ElseIf STATUS_ID = "2" Or STATUS_ID = "3" Or STATUS_ID = "4" Then
            PDF_OUTPUT = "PDF_TRADER_STAFF_EMP"
            XML_PATH = "XML_TRADER_STAFF_EMP"
        Else
            PDF_OUTPUT = dao_pdftemplate.fields.PDF_OUTPUT
            XML_PATH = dao_pdftemplate.fields.XML_PATH
        End If

        If tamrap_id <> 0 Then
            If Request.QueryString("status") = "8" Then
                Dim dao3 As New DAO_DRUG.ClsDBdrrgt
                dao3.GetDataby_IDA(_IDA)
                Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                Try
                    dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                    If dao_rq.fields.feetpcd = "1" Then
                        NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                    ElseIf dao_rq.fields.feetpcd = "99" Then
                        NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    End If
                Catch ex As Exception

                End Try

            ElseIf Request.QueryString("status") = "15" Or Request.QueryString("status") = "14" Then
                If HiddenField2.Value = "1" Then
                    Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                    Try
                        dao_rq.GetDataby_IDA(_IDA)
                        If dao_rq.fields.feetpcd = "1" Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        ElseIf dao_rq.fields.feetpcd = "99" Then
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
                End If

            Else
                NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
            End If
        End If
        p_dr = class_xml

        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE 'dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, _TR_ID) ' dao_pdftemplate.fields.PDF_OUTPUT
        Dim Path_XML As String = paths & XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, _TR_ID) 'dao_pdftemplate.fields.XML_PATH
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
End Class
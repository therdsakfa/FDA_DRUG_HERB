Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_STAFF_JJ_INOFFER
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
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_REPORT_RDLC.aspx?IDA=" & _IDA & "&rpt=1' ></iframe>"
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/จจ๑.pdf'></iframe>"
            Run_Pdf_Tabean_Herb()
            bind_data()
            bind_dd()
            bind_mas_staff()
            bind_data_rgtno()
            bind_mas_ml()
            bind_dd_discount()
            bind_mas_cancel()

            UC_ATTACH1.NAME = "เอกสารแนบ"
            UC_ATTACH1.BindData("เอกสารแนบ", 1, "pdf", "0", "77")
        End If
    End Sub
    Public Sub bind_mas_cancel()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STATUS_CANCEL_TABEAN_HERB(2)
        'dt = bao.SP_MAS_DDL_STAFF_REMARK_CANCEL()

        DDL_CANCLE_REMARK.DataSource = dt
        DDL_CANCLE_REMARK.DataBind()
        DDL_CANCLE_REMARK.Items.Insert(0, "-- กรุณาเลือก --")
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

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_OFFER.DataSource = dt
        DD_OFF_OFFER.DataBind()
        DD_OFF_OFFER.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Public Sub bind_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        RCVNO_FULL.Text = dao.fields.RCVNO_FULL
        DD_OFF_OFFER.Text = _CLS.NAME
        DATE_OFFER.Text = Date.Now.ToString("dd/MM/yyyy")

        Dim dao_tr As New DAO_TABEAN_HERB.TB_TABEAN_TRANSACTION_JJ
        dao_tr.GetdatabyID_FK_IDA_JJ(_IDA)
        Dim dao_st As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_STATUS_JJ
        dao_st.Getdataby_STATUS_ID_GROUP(dao.fields.STATUS_ID, 2)
        'NAME_ST.Text = dao_st.fields.STATUS_NAME
        STAFF_NAME.Text = dao_tr.fields.STAFF_NAME

        txt_edit_staff.Text = dao.fields.NOTE_EDIT

    End Sub

    Public Sub bind_mas_ml()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        'dt = bao.SP_MAS_TABEAN_HERB_ML()
        dt = bao.SP_MAS_TABEAN_HERB_ML_PROCESSID(_ProcessID)

        DD_ML_ID.DataSource = dt
        DD_ML_ID.DataBind()
        DD_ML_ID.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Public Sub bind_data_rgtno()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        RGTNO_FULL.Text = dao.fields.RGTNO_FULL
        'If dao.fields.RGTNO_FULL = "" Then

        '    RGTNO_FULL.Text = dao.fields.RGTNO_FULL
        '    'Dim RG As String = GEN_RGTNO(dao.fields.RGTTPCD)

        '    'RGTNO_FULL.Text = dao.fields.RGTTPCD & " " & RG
        '    'dao.fields.RGTNO_FULL = RGTNO_FULL.Text
        '    'dao.Update()
        'End If
        'RGTNO_FULL.Text = dao.fields.RGTNO_FULL
    End Sub

    Private Function GEN_RGTNO(ByVal rgttpcd As String) As String

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim str_no As String = ""

        If dao.fields.IDA = 1 And dao.fields.DATE_YEAR = con_year(Date.Now.Year) Then
            Dim max_no As Integer = 0
            Try
                max_no = CInt("00002")
                max_no += 1

            Catch ex As Exception

            End Try

            str_no = max_no.ToString()
            str_no = String.Format("{0:50000}", max_no.ToString("50000"))
            dao.fields.RGTNO_JJ = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            dao.Update()
            'str_no = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            str_no = str_no & "/" & dao.fields.DATE_YEAR.Substring(2, 2)
        Else
            Dim max_no As Integer = 0

            Dim dt As New DataTable
            Dim bao_max As New BAO_TABEAN_HERB.tb_main
            Dim _YEAR As String
            _YEAR = con_year(Date.Now.Year)
            dt = bao_max.SP_TABEAN_HERB_GET_MAX_RGTNO_JJ(rgttpcd, _YEAR.Substring(2, 2))
            Try
                max_no = dt(0)("MAX_ID")
                max_no += 1
            Catch ex As Exception

            End Try

            str_no = max_no.ToString()
            str_no = String.Format("{0:50000}", max_no.ToString("50000"))
            dao.fields.RGTNO_JJ = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            dao.Update()
            str_no = str_no & "/" & _YEAR.Substring(2, 2)
            'str_no = _YEAR.Substring(2, 2) & str_no
        End If

        Return str_no
    End Function

    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_STATUS_JJ(2)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

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

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ');", True)
        ElseIf DD_STATUS.SelectedValue = 6 Then
            P12.Visible = True
            p2.Visible = False
        ElseIf DD_STATUS.SelectedValue = 77 Or DD_STATUS.SelectedValue = 78 Or DD_STATUS.SelectedValue = 79 Or DD_STATUS.SelectedValue = 7 _
            Or DD_STATUS.SelectedValue = 9 Or DD_STATUS.SelectedValue = 10 Or DD_STATUS.SelectedValue = 14 Or DD_STATUS.SelectedValue = 17 Then
            p2.Visible = True
            P12.Visible = False
        Else
            P12.Visible = False
            p2.Visible = False
        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        Dim bao_tran As New BAO_TRANSECTION
        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            bao_tran.THANM = _CLS.THANM
        Catch ex As Exception

        End Try
        ' Dim bao_tran As New BAO_TRANSECTION
        bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        'dao.Update()
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)

        If DD_STATUS.SelectedValue = 19 Then
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.Update()

            bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
            Run_Pdf_Tabean_Herb_19()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        ElseIf DD_STATUS.SelectedValue = 10 Then
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.fields.NOTE_CANCEL = NOTE_CANCLE.Text
            dao.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
            dao.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
            dao.Update()

            bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)


            Run_Pdf_Tabean_Herb_6()
            UC_ATTACH1.insert_JJ2(_TR_ID, _ProcessID, dao.fields.IDA, 77)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        Else
            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_OFFER.SelectedValue = "-- กรุณาเลือก --" _
           Or DD_ML_ID.SelectedValue = "-- กรุณาเลือก --" Or TXT_SUM.Text = "" Or DDL_DISCOUNT.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Then Thenใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ ประเภท ยอดสุทธิ หรือ เลือกเจ้าหน้าที่');", True)
            ElseIf DD_STATUS.SelectedValue = 6 Then
                Try
                    dao.fields.DATE_OFFER = DateTime.ParseExact(DATE_OFFER.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                Catch ex As Exception
                    dao.fields.DATE_OFFER = Date.Now
                End Try
                dao.fields.NOTE_OFFER = NOTE_OFFER.Text
                'dao.fields.OFF_OFFER = OFF_OFFER.Text
                dao.fields.OFF_OFFER_ID = DD_OFF_OFFER.SelectedValue
                dao.fields.OFF_OFFER = DD_OFF_OFFER.SelectedItem.Text
                dao.fields.RGTNO_FULL = RGTNO_FULL.Text
                If TXT_SUM.Text = 0 Then
                    dao.fields.STATUS_ID = 13
                Else
                    dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                End If
                'dao.fields.STATUS_ID = DD_STATUS.SelectedValue

                dao.fields.ML_ID = DD_ML_ID.SelectedValue
                dao.fields.ML_NAME = DD_ML_ID.SelectedItem.Text
                dao.fields.ML_PAY = TXT_BATH.Text
                'dao.fields.ML_MINUS = TXT_MINUS.Text
                dao.fields.ML_MINUS = DDL_DISCOUNT.SelectedItem.Text
                dao.fields.ML_SUM = TXT_SUM.Text
                dao.fields.ML_KEY_NAME = _CLS.THANM
                dao.fields.ML_KEY_DATE = Date.Now

                dao.Update()


                bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)

                Run_Pdf_Tabean_Herb_6()
                Run_Pdf_Tabean_Herb_6_2()
                Run_Pdf_Tabean_Herb_6_2_LONG()
                'Dim SW_PAY As New SW_HERB_PAYMENT.SW_LCN_EDIT_PAYMENT
                'SW_PAY.HERB_PAYMENT(dao.fields.IDA, _ProcessID, "0", "0")
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            ElseIf DD_STATUS.SelectedValue = 10 Then
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.fields.NOTE_CANCEL = NOTE_CANCLE.Text
                dao.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                dao.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
                dao.Update()

                bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)


                Run_Pdf_Tabean_Herb_6()
                UC_ATTACH1.insert_JJ2(_TR_ID, _ProcessID, dao.fields.IDA, 77)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            End If
        End If

    End Sub

    Public Sub Run_Pdf_Tabean_Herb_6()
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

    End Sub

    Public Sub Run_Pdf_Tabean_Herb_6_2()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
        TB_JJ = XML.gen_xml_2(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ2", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ2\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
    Public Sub Run_Pdf_Tabean_Herb_6_2_LONG()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
        TB_JJ = XML.gen_xml_2(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "จจ2", 1)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ2\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
    Public Sub Run_Pdf_Tabean_Herb_19()
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

    End Sub

    'Protected Sub btn_download_jj2_Click(sender As Object, e As EventArgs) Handles btn_download_jj2.Click
    '    'Response.ContentType = "Application/pdf"
    '    'Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf")
    '    'Response.TransmitFile(Server.MapPath("../PDF/จจ๒.PDF"))

    '    load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    'End Sub


    'Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
    '    Dim dao As New DAO_DRUG.ClsDBdalcn
    '    dao.GetDataby_IDA(_IDA)
    '    If dao.fields.STATUS_ID = 8 Then
    '        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    '    End If
    'End Sub

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

    Protected Sub DD_ML_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ML_ID.SelectedIndexChanged
        Dim dao_ml As New DAO_TABEAN_HERB.TB_TABEAN_HERB_ML

        If DD_ML_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทค่าธรรมเนียม');", True)
        Else
            dao_ml.GetdatabyID_IDA(DD_ML_ID.SelectedValue)

            TXT_BATH.Text = dao_ml.fields.ML_PAY
            DDL_DISCOUNT.ClearSelection()
            TXT_SUM.Text = ""
            'TXT_MINUS.Text = ""
            'TXT_SUM.Text = ""
        End If
    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim Url As String = "FRM_HERB_TABEAN_STAFF_JJ_PREVIEW_JJ2.aspx?IDA=" & _IDA & "&SLDDL=" & DDL_JJ2_SELECT.SelectedValue
        Response.Write("<script>window.open('" & Url & "','_blank')</script>")

    End Sub

    'Protected Sub TXT_MINUS_TextChanged(sender As Object, e As EventArgs) Handles TXT_MINUS.TextChanged
    '    Dim number1 As Integer = 0
    '    Dim number2 As Integer = 0
    '    Dim number3 As Integer = 100
    '    Dim answer1 As Decimal
    '    Dim sum1 As Integer
    '    Dim sum2 As Integer

    '    number1 = TXT_BATH.Text
    '    number2 = TXT_MINUS.Text
    '    sum1 = number1 * number2
    '    sum2 = sum1 / number3
    '    answer1 = number1 - sum2
    '    TXT_SUM.Text = answer1
    'End Sub
    Public Sub bind_dd_discount()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_DISCOUNT_TABEAN()

        DDL_DISCOUNT.DataSource = dt
        DDL_DISCOUNT.DataBind()
        DDL_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Protected Sub DDL_DISCOUNT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_DISCOUNT.SelectedIndexChanged
        Dim dao_ml As New DAO_TABEAN_HERB.TB_TABEAN_HERB_ML

        If DDL_DISCOUNT.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทค่าธรรมเนียม');", True)
        Else
            Try
                Dim number1 As Integer = 0
                Dim number2 As Integer = 0
                Dim number3 As Integer = 100
                Dim answer1 As Decimal
                Dim sum1 As Integer
                Dim sum2 As Integer

                number1 = TXT_BATH.Text
                number2 = DDL_DISCOUNT.SelectedItem.Text
                sum1 = number1 * number2
                sum2 = sum1 / number3
                answer1 = number1 - sum2
                TXT_SUM.Text = answer1
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทค่าธรรมเนียม');", True)
            End Try
        End If

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
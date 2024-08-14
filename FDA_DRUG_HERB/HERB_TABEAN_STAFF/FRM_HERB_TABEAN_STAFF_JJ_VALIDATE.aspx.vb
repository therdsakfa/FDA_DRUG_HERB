Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_STAFF_JJ_VALIDATE
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
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src=''></iframe>"

            Run_Pdf_Tabean_Herb()
            bind_data()
            bind_dd()
            bind_mas_staff()
            bind_data_rgtno()
            'bind_tabean_group()
            'bind_ddl_rgttpcd()
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
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
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

    Public Sub bind_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        If dao.fields.RCVNO_FULL <> "" Then
            P12.Visible = True
            'ROVNO_FULL.Text = dao.fields.RCVNO_FULL
        End If
        DD_OFF_REQ.Text = _CLS.NAME

        DATE_REQ.Text = Date.Now.ToString("dd/MM/yyyy")

        Dim dao_tr As New DAO_TABEAN_HERB.TB_TABEAN_TRANSACTION_JJ
        dao_tr.GetdatabyID_FK_IDA_JJ(_IDA)
        Dim dao_st As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_STATUS_JJ
        dao_st.Getdataby_STATUS_ID_GROUP(dao.fields.STATUS_ID, 2)
        'NAME_ST.Text = dao_st.fields.STATUS_NAME
        STAFF_NAME.Text = dao_tr.fields.STAFF_NAME

        txt_edit_staff.Text = dao.fields.NOTE_EDIT

    End Sub
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        Dim ss_id As Integer = 0
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        'If dao.fields.STATUS_ID = 3 Then
        '    ss_id = 1
        'ElseIf dao.fields.STATUS_ID = 5 Then
        '    ss_id = 4
        'End If
        dt = bao.SP_DD_STATUS_JJ(5)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_data_rgtno()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        If dao.fields.RGTNO_FULL = "" Then

            Dim RG As String = GEN_RGTNO(dao.fields.RGTTPCD)

            RGTNO_FULL.Text = dao.fields.RGTTPCD & " " & RG
            'dao.fields.RGTNO_FULL = RGTNO_FULL.Text
            'dao.Update()
        End If
        RGTNO_FULL.Text = dao.fields.RGTNO_FULL
    End Sub

    Private Function GEN_RGTNO(ByVal rgttpcd As String) As String

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim str_no As String = ""
        Dim year As String = con_year(Date.Now.Year)

        If dao.fields.IDA = 1 And dao.fields.DATE_YEAR = con_year(Date.Now.Year) Then
            Dim max_no As Integer = 0
            Try
                max_no = CInt("00002")
                max_no += 1

            Catch ex As Exception

            End Try

            str_no = max_no.ToString()
            str_no = String.Format("{0:50000}", max_no.ToString("50000"))
            dao.fields.RGTNO_JJ = year.Substring(2, 2) & str_no
            dao.Update()
            'str_no = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            str_no = str_no & "/" & year.Substring(2, 2)
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
            dao.fields.RGTNO_JJ = _YEAR.Substring(2, 2) & str_no
            dao.Update()
            str_no = str_no & "/" & _YEAR.Substring(2, 2)
            'str_no = _YEAR.Substring(2, 2) & str_no
            dao.fields.RGTNO_FULL = dao.fields.RGTTPCD & " " & str_no
            dao.Update()
        End If

        Return str_no
    End Function
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

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim bao_tran As New BAO_TRANSECTION
        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            bao_tran.THANM = _CLS.THANM
        Catch ex As Exception

        End Try
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        If DD_STATUS.SelectedItem.Text.Contains("กรุณาเลือก") Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกสถานะ');", True)
        Else
            If DD_STATUS.SelectedValue = 16 Then

                If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ หรือ เลือกเจ้าหน้าที่');", True)
                Else
                    'dao.fields.RGTTPCD_ID = ddl_rgttpcd.SelectedItem.Value
                    dao.fields.RGTTPCD = "G"
                    'dao.fields.RGTNO_JJ = RGTNO_JJ.Text
                    'dao.fields.RGTTPCD_GROUP_ID = ddl_tabean_group.SelectedItem.Value
                    'dao.fields.RGTTPCD_GROUP = ddl_tabean_group.SelectedItem.Text

                    'Dim dao_druggroup As New DAO_DRUG.ClsDBdrdrgtype
                    'dao_druggroup.GetDataby_drgtpcd(dao.fields.RGTTPCD_GROUP_ID)
                    'dao.fields.RGTTPCD_GROUP_ENG = dao_druggroup.fields.engdrgtpnm

                    'dao.fields.RGTNO_FULL = ddl_rgttpcd.SelectedItem.Text & " " & RGTNO_JJ.Text & " " & dao.fields.RGTTPCD_GROUP_ENG

                    Try
                        dao.fields.VALIDATE_DATE = DateTime.ParseExact(DATE_REQ.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                    Catch ex As Exception
                        dao.fields.VALIDATE_DATE = Date.Now
                    End Try

                    'dao.fields.OFF_REQ = OFF_REQ.Text
                    dao.fields.VALIDATE_ID = DD_OFF_REQ.SelectedValue
                    dao.fields.VALIDATE_NAME = DD_OFF_REQ.SelectedItem.Text
                    dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                    'Dim TR_ID As String = dao.fields.TR_ID_JJ
                    'Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
                    'Dim RCVNO_FULL As String = "HB" & " " & dao.fields.PVNCD & "-" & _ProcessID & "-" & DATE_YEAR & "-" & TR_ID

                    'dao.fields.RCVNO_FULL = RCVNO_FULL

                    dao.Update()

                    'Dim bao_tran As New BAO_TRANSECTION
                    bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)

                    Run_Pdf_Tabean_Herb_16()
                    Run_Pdf_Tabean_Herb_16_2()
                    Run_Pdf_Tabean_Herb_16_2_LONG()
                    'Run_Pdf_Tabean_Herb_APPROVE_12_11()
                End If
            ElseIf DD_STATUS.SelectedValue = 17 Then
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.fields.NOTE_CANCEL = NOTE_CANCLE.Text
                dao.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                dao.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
                dao.Update()


                'Dim bao_tran As New BAO_TRANSECTION
                bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.Update()

                Run_Pdf_Tabean_Herb_16()
                UC_ATTACH1.insert_JJ2(_TR_ID, _ProcessID, dao.fields.IDA, 77)
            End If

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        End If
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_16()
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

    Public Sub Run_Pdf_Tabean_Herb_APPROVE_16()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
        TB_JJ = XML.gen_xml_approve(_IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "APPROVE_JJ_1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_APPOINTMENT("HB_PDF", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_APPOINTMENT("HB_XML", _ProcessID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, _IDA, dao.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Public Sub Run_Pdf_Tabean_Herb_16_2()
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
    Public Sub Run_Pdf_Tabean_Herb_16_2_LONG()
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

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ');", True)
        ElseIf DD_STATUS.SelectedValue = 16 Then
            P12.Visible = True
            p2.Visible = False
        ElseIf DD_STATUS.SelectedValue = 77 Or DD_STATUS.SelectedValue = 78 Or DD_STATUS.SelectedValue = 79 Or DD_STATUS.SelectedValue = 7 _
            Or DD_STATUS.SelectedValue = 9 Or DD_STATUS.SelectedValue = 10 Or DD_STATUS.SelectedValue = 14 Or DD_STATUS.SelectedValue = 17 Then
            p2.Visible = True
            P12.Visible = False
        Else
            p2.Visible = True
        End If
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
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

    Private Sub DD_OFF_REQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OFF_REQ.SelectedIndexChanged
        If DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกเจ้าหน้าที่');", True)
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
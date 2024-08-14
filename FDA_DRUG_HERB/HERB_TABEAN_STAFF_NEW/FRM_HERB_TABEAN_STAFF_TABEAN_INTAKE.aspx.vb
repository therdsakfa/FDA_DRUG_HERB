Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_STAFF_TABEAN_INTAKE
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
            bind_dd()
            bind_mas_staff()
            'Run_Pdf_Tabean_Herb()
            Run_PDF_Tabean()
            bind_ddl_rgttpcd()
            'bind_mas_cancel()
            bind_tabean_group()
            bind_data()
            Bind_PRICE_ESTIMATE_REQUEST()
            Bind_DD_Discount()

            UC_ATTACH1.NAME = "เอกสารแนบ"
            UC_ATTACH1.BindData("เอกสารแนบ", 1, "pdf", "0", "77")
        End If
    End Sub
    'Public Sub bind_mas_cancel()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_MAS_STATUS_CANCEL_TABEAN_HERB(1)
    '    'dt = bao.SP_MAS_DDL_STAFF_REMARK_CANCEL()

    '    DDL_CANCLE_REMARK.DataSource = dt
    '    DDL_CANCLE_REMARK.DataBind()
    '    DDL_CANCLE_REMARK.Items.Insert(0, "-- กรุณาเลือก --")
    'End Sub
    Sub bind_mas_cancel(ByVal ID As String)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STATUS_CANCEL_TABEAN_HERB(ID)

        DDL_CANCLE_REMARK.DataSource = dt
        DDL_CANCLE_REMARK.DataValueField = "ID"
        DDL_CANCLE_REMARK.DataTextField = "STATUS_CAUSE"
        DDL_CANCLE_REMARK.DataBind()
        'DD_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        DDL_CANCLE_REMARK.Items.Insert(0, item)
    End Sub
    Sub bind_tabean_group()
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dt As New DataTable
        dt = bao.SP_drdrgtype_Tabean_New()
        ddl_tabean_group.DataSource = dt
        ddl_tabean_group.DataTextField = "thadrgtpnm"
        ddl_tabean_group.DataValueField = "drgtpcd"
        ddl_tabean_group.DataBind()

        Dim item As New ListItem
        item.Text = "-"
        item.Value = ""
        ddl_tabean_group.Items.Insert(0, item)
    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Public Sub Bind_PRICE_ESTIMATE_REQUEST()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_PRICE_ESTIMATE_REQUEST(_ProcessID)

        DD_ESTIMATE_PAY.DataSource = dt
        DD_ESTIMATE_PAY.DataValueField = "ID"
        DD_ESTIMATE_PAY.DataTextField = "Request_Show"
        DD_ESTIMATE_PAY.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        DD_ESTIMATE_PAY.Items.Insert(0, item)
    End Sub
    Sub Bind_DD_Discount()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_PRICE_DISCOUNT_TABEAN_HERB()

        DD_DISCOUNT.DataSource = dt
        DD_DISCOUNT.DataValueField = "ID"
        DD_DISCOUNT.DataTextField = "DiscountName"
        DD_DISCOUNT.DataBind()
        'DD_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")

        Dim item As New RadComboBoxItem
        item.Text = "ไม่มีส่วนลดตามประกาศฯ ค่าใช้จ่ายที่จะจัดเก็บจากผู้ยื่นคำขอ"
        item.Value = "0"
        DD_DISCOUNT.Items.Insert(0, item)
    End Sub
    Public Sub Run_Pdf_Tabean_Herb()
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:1500px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Sub Run_PDF_Tabean()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        dao_dq.GetDataby_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(dao_dq.fields.PROCESS_ID, dao.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", dao_dq.fields.PROCESS_ID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", dao_dq.fields.PROCESS_ID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, dao_dq.fields.PROCESS_ID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:1500px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"


        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)

        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        If dao.fields.rcvno <> "" Then
            P12.Visible = True
            ROVNO_FULL.Text = dao.fields.rcvno
        End If
        DD_OFF_REQ.Text = _CLS.NAME

        DATE_REQ.Text = Date.Now.ToString("dd/MM/yyyy")

        Dim Process_ID As String = dao.fields.PROCESS_ID
        If Process_ID.Contains("2019") Then
            ddl_tabean_group.SelectedValue = 3
            'Else
            '    div_tabean_group.Visible = False
        End If
    End Sub

    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        Dim ss_id As Integer = 0
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        If dao_deeqt.fields.STATUS_ID = 3 Then
            ss_id = 1
        ElseIf dao_deeqt.fields.STATUS_ID = 5 Then
            ss_id = 5
        End If

        dt = bao.SP_DD_STATUS_TABEAN(ss_id)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_deeqt.fields.TR_ID, 7, _ProcessID, _IDA)

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

    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(dao_deeqt.fields.TR_ID, 10, _ProcessID, _IDA)

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
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click

        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)

        Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean_herb.GetdatabyID_FK_IDA_DQ(_IDA)
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ ');", True)

            'ElseIf DD_STATUS.SelectedValue = 77 Then
            '    Response.Redirect("POPUP_HERB_TABEAN_STAFF_CANCEL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&IDA_LCN=" & _IDA_LCN & "&STATUS_ID=" & DD_STATUS.SelectedValue)
            '    'ElseIf DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกประเภททะเบียน');", True)
        Else
            If DD_STATUS.SelectedValue = 12 Or DD_STATUS.SelectedValue = 11 Or DD_STATUS.SelectedValue = 9 Then
                If Chk_ddl() = 0 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกประเภททะเบียน');", True)
                ElseIf DD_ESTIMATE_PAY.SelectedValue = 0 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ค่าประเมินเอกสารทางวิชาการ');", True)
                Else
                    If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ หรือ เลือกเจ้าหน้าที่');", True)
                    Else

                        Try
                            dao.fields.rcvdate = DateTime.ParseExact(DATE_REQ.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                        Catch ex As Exception
                            dao.fields.rcvdate = Date.Now
                        End Try


                        Try
                            dao.fields.HerbFromNarcotics_ID = DD_HerbFromNarcotics.SelectedValue
                            dao.fields.HerbFromNarcotics_Name = DD_HerbFromNarcotics.SelectedItem.Text
                        Catch ex As Exception

                        End Try

                        'Dim RCVNO As Integer
                        'Dim bao_gen As New BAO.GenNumber
                        'RCVNO = bao_gen.GEN_NO_TBN(con_year(Date.Now.Year), dao.fields.pvncd, 1, _IDA, dao.fields.FK_LCN_IDA)
                        'Dim DATE_YEAR As String = con_year(Date.Now.Year).Substring(2, 2)
                        'Dim RCVNO_FULL As String = "HB" & " " & dao.fields.pvncd & "-" & _ProcessID & "-" & DATE_YEAR & "-" & RCVNO
                        'dao.fields.RCVNO_NEW = RCVNO_FULL

                        If ddl_rgttpcd.SelectedValue = "-- กรุณาเลือก --" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภททะเบียน');", True)
                        Else
                            dao.fields.rgttpcd_id = ddl_rgttpcd.SelectedValue
                            dao.fields.rgttpcd = ddl_rgttpcd.SelectedItem.Text

                            Try
                                If ddl_tabean_group.SelectedValue = "-" Or ddl_tabean_group.SelectedValue = "" Then
                                    dao.fields.drgtpcd = 2
                                Else
                                    dao.fields.drgtpcd = ddl_tabean_group.SelectedValue
                                End If
                            Catch ex As Exception
                                dao.fields.drgtpcd = 2
                            End Try
                        End If

                        If DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก จนท. ที่รับผิดชอบ');", True)
                        Else
                            dao.fields.STAFF_RCV_ID = DD_OFF_REQ.SelectedValue
                            dao.fields.STAFF_RCV_NAME = DD_OFF_REQ.SelectedItem.Text
                        End If

                        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก สถานะ');", True)
                        Else
                            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                            dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
                        End If

                        Try
                            dao_tabean_herb.fields.Discount_EstimateID = DD_DISCOUNT.SelectedValue
                            dao_tabean_herb.fields.Discount_EstimateName = DD_DISCOUNT.SelectedItem.Text
                            dao_tabean_herb.fields.Estimate_PAY_ID = DD_ESTIMATE_PAY.SelectedValue
                            dao_tabean_herb.fields.Estimate_PAY_Name = DD_ESTIMATE_PAY.SelectedItem.Text
                            dao_tabean_herb.fields.ML_ESTIMATE = TXT_BATH.Text
                        Catch ex As Exception

                        End Try

                        If (DD_STATUS.SelectedValue = 12 Or DD_STATUS.SelectedValue = 11 Or DD_STATUS.SelectedValue = 9) And TXT_BATH.Text = 0 Then
                            dao.fields.STATUS_ID = 23
                            dao_tabean_herb.fields.STATUS_ID = 23
                            'Else
                            '    dao.fields.STATUS_ID = 12
                            '    dao_tabean_herb.fields.STATUS_ID = 12
                        End If

                        dao.update()
                        dao_tabean_herb.Update()

                        Run_Pdf_Tabean_Herb_12_11()
                        'Run_Pdf_Tabean_Herb_APPROVE_1_11_12()
                        Dim bao_tran As New BAO_TRANSECTION
                        bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)

                        AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)

                        Dim bao_tn As New BAO_TABEAN_HERB.tb_dd
                        bao_tn.SP_INSERT_DRUG_PAYMENT_CENTER_L44(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.IDA, dao.fields.PROCESS_ID)
                    End If
                End If


            ElseIf DD_STATUS.SelectedValue = 4 Then
                Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
                dao_up_mas.GetdatabyID_TYPE(9)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = _TR_ID
                    dao_up.fields.PROCESS_ID = _ProcessID
                    dao_up.fields.FK_IDA = _IDA
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 9
                    dao_up.fields.ACTIVE = 1
                    dao_up.fields.CREATE_DATE = Date.Now
                    dao_up.insert()
                Next

                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.update()

                dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao_tabean_herb.Update()
                'ElseIf DD_STATUS.SelectedValue = 9 Then
                '    dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                '    dao.update()

                '    Dim bao_tran As New BAO_TRANSECTION
                '    bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                '    dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                '    dao.update()

                '    dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
                '    dao_tabean_herb.Update()
            ElseIf DD_STATUS.SelectedValue = 77 Then
                If DDL_CANCLE_REMARK.SelectedValue = 0 Then
                    lbl_CANCLE_REMARK.Visible = True
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาตรวจสอบข้อมูล');", True)
                Else
                    dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                    dao.fields.REMARK = NOTE_CANCLE.Text
                    dao.update()

                    dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
                    dao_tabean_herb.fields.cancel_by = _CLS.THANM
                    dao_tabean_herb.fields.cancel_date = Date.Now
                    dao_tabean_herb.fields.cancel_iden = _CLS.CITIZEN_ID
                    dao_tabean_herb.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                    dao_tabean_herb.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
                    dao_tabean_herb.fields.NOTE_CANCEL = NOTE_CANCLE.Text
                    dao_tabean_herb.Update()

                    AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                    Dim bao_tran As New BAO_TRANSECTION
                    bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                    Run_Pdf_Tabean_Herb_12_11()
                    UC_ATTACH1.insert_TBN(_TR_ID, _ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                End If
            ElseIf DD_STATUS.SelectedValue = 18 Then
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.fields.REMARK = NOTE_CANCLE.Text
                dao.update()

                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.update()

                dao_tabean_herb.fields.NOTE_CANCEL = NOTE_CANCLE.Text
                dao_tabean_herb.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
                Try
                    dao_tabean_herb.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                Catch ex As Exception

                End Try
                dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao_tabean_herb.Update()

                Run_Pdf_Tabean_Herb_12_11()
                UC_ATTACH1.insert_TBN(_TR_ID, _ProcessID, dao.fields.IDA, 77)

            ElseIf DD_STATUS.SelectedValue = 20 Then
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.fields.REMARK = NOTE_CANCLE.Text
                dao.update()

                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.update()

                dao_tabean_herb.fields.NOTE_CANCEL = NOTE_CANCLE.Text
                dao_tabean_herb.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
                Try
                    dao_tabean_herb.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
                Catch ex As Exception

                End Try
                dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao_tabean_herb.Update()

                Run_Pdf_Tabean_Herb_12_11()
                UC_ATTACH1.insert_TBN(_TR_ID, _ProcessID, dao.fields.IDA, 77)
            End If
        End If

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_12_11()
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Public Sub Run_Pdf_Tabean_Herb_APPROVE_1_11_12()
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_approve(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "APPROVE_TBN_1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ');", True)
        ElseIf DD_STATUS.SelectedValue = 12 Or DD_STATUS.SelectedValue = 11 Or DD_STATUS.SelectedValue = 9 Then
            P12.Visible = True
            P15.Visible = True
            p2.Visible = False
            'Submit_BG.Style.Add("color", "#155724")
            'Submit_BG.Style.Add(" background-color", "#d4edda")
            'Submit_BG.Style.Add("border-color", "#155724")
        ElseIf DD_STATUS.SelectedValue = 78 Or DD_STATUS.SelectedValue = 79 Or DD_STATUS.SelectedValue = 7 _
            Or DD_STATUS.SelectedValue = 9 Or DD_STATUS.SelectedValue = 10 Or DD_STATUS.SelectedValue = 19 Or DD_STATUS.SelectedValue = 18 _
            Or DD_STATUS.SelectedValue = 20 Then
            p2.Visible = True
            P12.Visible = False
            P15.Visible = False
            'Submit_BG.Style.Add("color", "#721c24")
            'Submit_BG.Style.Add(" background-color", "#f8d7da")
            'Submit_BG.Style.Add("border-color", "#721c24")
            bind_mas_cancel(1)
        ElseIf DD_STATUS.SelectedValue = 77 Or DD_STATUS.SelectedValue = 78 Then
            p2.Visible = True
            P12.Visible = False
            P15.Visible = False
            'Submit_BG.Style.Add("color", "#721c24")
            'Submit_BG.Style.Add(" background-color", "#f8d7da")
            'Submit_BG.Style.Add("border-color", "#721c24")
            bind_mas_cancel(3)
        Else
            'Submit_BG.Style.Add("color", "#856404")
            'Submit_BG.Style.Add(" background-color", "#fff3cd")
            'Submit_BG.Style.Add("border-color", "#856404")
            P12.Visible = False
            P15.Visible = False
            p2.Visible = False
        End If
    End Sub
    Function Chk_ddl() As Integer
        Dim i As Integer = 0
        If ddl_rgttpcd.SelectedValue <> "" Then
            i += 1
        End If
        Return i
    End Function

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Sub bind_ddl_rgttpcd()

        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_TABEAN_DRUGGROUP_JJ()

        ddl_rgttpcd.DataSource = dt
        ddl_rgttpcd.DataTextField = "rgttpcd"
        ddl_rgttpcd.DataValueField = "IDA"
        ddl_rgttpcd.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        ddl_rgttpcd.Items.Insert(0, item)

    End Sub

    Private Sub DD_OFF_REQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OFF_REQ.SelectedIndexChanged
        If DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกเจ้าหน้าที่');", True)
        End If
    End Sub

    Function bind_data_uploadfile_6()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 6, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile_6()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Function bind_data_uploadfile_8()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 8, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
        RadGrid5.DataSource = bind_data_uploadfile_8()
    End Sub

    Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub
    Protected Sub DD_ESTIMATE_PAY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ESTIMATE_PAY.SelectedIndexChanged
        If DD_ESTIMATE_PAY.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ค่าประเมินเอกสารทางวิชาการ');", True)
        Else
            Dim ML_PAY As Double = 0
            ML_PAY = SUM_Discount(_ProcessID)
            TXT_BATH.Text = ML_PAY
        End If
    End Sub
    Protected Sub DD_DISCOUNT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_DISCOUNT.SelectedIndexChanged
        If DD_ESTIMATE_PAY.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ค่าประเมินเอกสารทางวิชาการ');", True)
        Else
            Dim ML_PAY As Double = 0
            ML_PAY = SUM_Discount(_ProcessID)
            TXT_BATH.Text = ML_PAY
        End If
    End Sub
    Function SUM_Discount(ByVal Process_ID As Integer)
        'Dim dao_ml As New DAO_TABEAN_HERB.TB_MAS_PRICE_REQUEST_HERB
        'dao_ml.Getdataby_Process_ID(Process_ID)
        Dim dao_ml As New DAO_TABEAN_HERB.TB_MAS_PRICE_ESTIMATE_REQUEST_HERB
        dao_ml.Getdataby_Process_ID_AND_ID(Process_ID, DD_ESTIMATE_PAY.SelectedValue)
        Dim dao_p As New DAO_TABEAN_HERB.TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
        dao_p.GetdatabyID_ID(DD_DISCOUNT.SelectedValue)
        Dim number1 As Integer = 0
        Dim number2 As Integer = 0
        Dim number3 As Integer = 100
        Dim answer1 As Decimal
        Dim sum1 As Integer
        Dim sum2 As Integer
        If dao_p.fields.REQUEST_Fee = Nothing Then
            number2 = 0
        Else
            number2 = dao_p.fields.ESTIMATE_Fee
        End If
        number1 = dao_ml.fields.Price

        sum1 = number1 * number2
        sum2 = sum1 / number3
        answer1 = number1 - sum2
        Return answer1
    End Function

    Protected Sub btn_dbd_Click(sender As Object, e As EventArgs) Handles btn_dbd.Click
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim IDENTIFY As String = _CLS.CITIZEN_ID
        Dim COMPANY_INDENTIFY As String = dao_deeqt.fields.CITIZEN_ID_AUTHORIZE
        Dim TOKEN As String = _CLS.TOKEN
        Dim TR_ID As String = "" 'รอพี่บิ๊กกำหนดชื่อตัวแปรอีกที
        Dim ORG As String = "HERB"
        TR_ID = "HB-" & _ProcessID & "-" & dao_deeqt.fields.DATE_YEAR & "-" & _TR_ID
        Dim URL As String = DBD_LINK(IDENTIFY, COMPANY_INDENTIFY, TR_ID, TOKEN)
        'Response.Redirect(URL)
        Response.Write("<script language='javascript'>window.open('" & Url & "','_blank','');")
        Response.Write("</script>")
    End Sub

    Protected Sub btn_Closed_Click(sender As Object, e As EventArgs) Handles btn_Closed.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
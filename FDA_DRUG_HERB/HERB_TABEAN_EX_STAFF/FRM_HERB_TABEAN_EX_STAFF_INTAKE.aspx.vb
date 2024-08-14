Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_EX_STAFF_INTAKE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
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
            'Run_Pdf_TB_Herb_EX()
            Run_Pdf_Tabean_Herb_Intake()
            bind_mas_staff()
            bind_dd()
            bind_data()
        End If
    End Sub
    Public Sub bind_data()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        'DD_OFF_APP.Text = dao.fields.EX_OFF_APP
        DATE_REQ.Text = Date.Now.ToString("dd/MM/yyyy")
        If dao.fields.STATUS_ID = 5 Then
            Div1.Visible = True
        End If
    End Sub
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        If dao.fields.STATUS_ID = 5 Then
            dt = bao.SP_DD_STATUS_TABEAN_EX(4)
        Else
            dt = bao.SP_DD_STATUS_TABEAN_EX(1)

        End If

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ');", True)
        ElseIf DD_STATUS.SelectedValue = 12 Or DD_STATUS.SelectedValue = 11 Then
            P12.Visible = True
        Else
            P12.Visible = False
        End If
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
        'Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TABEAN_EX("HB_PDF", dao.fields.process_id, dao.fields.DATE_YEAR, dao.fields.TR_ID, _IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_TEMPLATE & "' ></iframe>"

    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        If DD_STATUS.SelectedItem.Text.Contains("กรุณาเลือก") Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกสถานะ');", True)
        Else
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue

            'dao.fields.STATUS_ID = DD_STATUS.SelectedValue

            If DD_STATUS.SelectedValue = 12 Or DD_STATUS.SelectedValue = 11 Then

                If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ หรือ เลือกเจ้าหน้าที่');", True)
                Else
                    Try
                        dao.fields.EX_DATE_REQ = DateTime.ParseExact(DATE_REQ.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                    Catch ex As Exception
                        dao.fields.EX_DATE_REQ = Date.Now
                    End Try

                    'Dim bao As New BAO.GenNumber
                    'Dim RCVNO As String = ""
                    'RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, dao.fields.process_id, _IDA)

                    'dao.fields.rcvno = RCVNO
                    'dao.fields.rcvdate = Date.Now
                    dao.fields.EX_OFF_REQ_ID = DD_OFF_REQ.SelectedValue
                    dao.fields.EX_OFF_REQ = DD_OFF_REQ.SelectedItem.Text
                    dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                    dao.update()

                    Run_Pdf_Tabean_Herb_Intake()
                End If

            ElseIf DD_STATUS.SelectedValue = 4 Then

                Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
                dao_up_mas.GetdatabyID_TYPE(18)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = _TR_ID
                    dao_up.fields.PROCESS_ID = dao.fields.process_id
                    dao_up.fields.FK_IDA = _IDA
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 18
                    dao_up.insert()
                Next

                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.insert_transection_jj(dao.fields.process_id, dao.fields.IDA, DD_STATUS.SelectedValue)

                dao.update()
            ElseIf DD_STATUS.SelectedValue = 9 Then
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.Update()
            End If

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        End If
    End Sub
    Public Sub Run_Pdf_Tabean_Herb_Intake()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

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

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_EX(_TR_ID, 17, dao.fields.process_id)

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
    Function bind_data_uploadfile2()
        Dim dt As DataTable
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_EX(_TR_ID, 20, dao.fields.process_id)

        Return dt
    End Function

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile2()
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
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
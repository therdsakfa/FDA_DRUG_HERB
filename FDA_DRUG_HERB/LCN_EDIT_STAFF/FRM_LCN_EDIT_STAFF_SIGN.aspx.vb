Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_LCN_EDIT_STAFF_SIGN
    Inherits System.Web.UI.Page

    Private _LCN_IDA As Integer
    Private _ProcessID As String
    Private _REASON_TYPE As String
    Private _STATUS_GROUP As Integer
    Private _STATUS_ID As Integer
    Private _ddl1 As Integer
    Private _ddl2 As Integer
    Private _IDA As Integer

    Private _TR_LCN_EDIT As String

    Private _CLS As New CLS_SESSION
    Private _CLS_CITIZEN_ID_AUTHORIZE As String = ""
    Private _CLS_CITIZEN_ID As String = ""
    Private _CLS_THANM As String = ""

    Sub RunSession()

        _LCN_IDA = Request.QueryString("LCN_IDA")
        _REASON_TYPE = Request.QueryString("LCN_EDIT_REASON_TYPE")
        _STATUS_GROUP = Request.QueryString("STATUS_GROUP")
        _STATUS_ID = Request.QueryString("STATUS_ID")

        _ddl1 = Request.QueryString("ddl_up1")
        _ddl2 = Request.QueryString("ddl_up2")
        _IDA = Request.QueryString("IDA")

        _TR_LCN_EDIT = Request.QueryString("TR_LCN_EDIT")



        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

            BIND_STATUS()
            bind_mas_staff()

            bind_data()

            Run_PDF_SMP3()
        End If
        _CLS_CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        _CLS_CITIZEN_ID = _CLS.CITIZEN_ID
        _CLS_THANM = _CLS.THANM
    End Sub

    Public Sub bind_data()
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        'dao.GetDataby_LCN_IDA_AND_YEAR_TR_ID_AND_ACTIVE(_LCN_IDA, _YEAR, _TR_LCN_EDIT, True)
        dao.GetDataby_IDA(_IDA)
        TXT_RQ_NUMBER.Text = dao.fields.STAFF_RQ_NUMBER
        TXT_SIGN_DATE.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub

    Public Sub BIND_STATUS()
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_LCN_EDIT_STATUS(6)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub


    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DDL_SIGN_STAFF.DataSource = dt
        DDL_SIGN_STAFF.DataBind()
        DDL_SIGN_STAFF.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Function bind_data_uploadfile()
        Dim dt As DataTable
        ' Dim bao As New BAO_LCN.TABLE_VIEW
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_DALCN_EDIT_UPLOAD_FILE(dao.fields.TR_ID, 1)
        'dt = bao.SP_LCN_APPROVE_EDIT_GET_UPLOAD_FILE(_REASON_TYPE)

        Return dt
    End Function

    'Function bind_data_uploadfile()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_LCN.TABLE_VIEW

    '    dt = bao.SP_LCN_APPROVE_EDIT_GET_UPLOAD_FILE(_REASON_TYPE)

    '    Return dt
    'End Function

    Public Sub Run_PDF_SMP3()

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(dao.fields.LCN_PROCESS_ID, dao.fields.STATUS_ID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", dao.fields.LCN_PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID, dao.fields.IDA, dao.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim lcn_ida As Integer = _LCN_IDA
            Dim FILE_NUMBER_NAME As Integer = item("FILE_NUMBER_NAME").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../LCN_EDIT/FRM_LCN_EDIT_PREVIEW_FILE.aspx?file_id=" & FILE_NUMBER_NAME & "&lcn_ida=" & lcn_ida

        End If

    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click

        Dim dao_log As New DAO_DRUG.TB_LOG_STATUS
        dao_log.fields.STATUS_ID = DD_STATUS.SelectedValue
        dao_log.fields.PROCESS_ID = 10201
        dao_log.fields.STATUS_DATE = System.DateTime.Now
        dao_log.fields.IDENTIFY = _CLS_CITIZEN_ID
        dao_log.fields.FK_IDA = _LCN_IDA
        dao_log.insert()

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        'dao.GetDataBY_LCN_IDA_LCN_EDIT_REASON_TYPE_YEAR(_LCN_IDA, _ddl1, _YEAR, True)
        dao.GetDataBY_IDA_LCN_IDA_LCN_EDIT_REASON_TYPE(_IDA, _LCN_IDA, _ddl1, True)

        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        dao.fields.STATUS_NAME = DD_STATUS.SelectedItem.Text

        Try
            dao.fields.STAFF_SIGN_DATE = DateTime.ParseExact(TXT_SIGN_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.STAFF_SIGN_DATE = System.DateTime.Now
        End Try

        dao.fields.STAFF_SIGN_NAME_ID = DDL_SIGN_STAFF.SelectedValue
        dao.fields.STAFF_SIGN_NAME = DDL_SIGN_STAFF.SelectedItem.Text
        dao.fields.STAFF_SIGN_NOTE = TXT_SIGN_NOTE.Text

        dao.update()

        AddLogStatus(dao.fields.STATUS_ID, dao.fields.LCN_PROCESS_ID, _CLS.CITIZEN_ID, dao.fields.IDA)

        Dim ida_xml As Integer = 0
        Dim process_xml As Integer = 0
        Dim year_xml As Integer = 0
        Dim tr_id_xml As Integer = 0
        ida_xml = dao.fields.IDA
        process_xml = dao.fields.LCN_PROCESS_ID
        year_xml = dao.fields.DATE_YEAR
        tr_id_xml = dao.fields.TR_ID

        bind_pdf_xml_5(ida_xml, _LCN_IDA, process_xml, dao.fields.STATUS_ID, year_xml, tr_id_xml)

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)


    End Sub

    Public Sub bind_pdf_xml_5(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, LCN_IDA, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
        End If
    End Sub
    Protected Sub btn_dbd_Click(sender As Object, e As EventArgs) Handles btn_dbd.Click
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        dao.GetDataby_IDA(_IDA)
        Dim IDENTIFY As String = _CLS.CITIZEN_ID
        Dim COMPANY_INDENTIFY As String = dao.fields.CITIZEN_ID_AUTHORIZE
        Dim TOKEN As String = _CLS.TOKEN
        Dim TR_ID As String = "" '_TR_LCN_EDIT 'รอพี่บิ๊กกำหนดชื่อตัวแปรอีกที
        Dim ORG As String = "HERB"
        TR_ID = "HB-" & dao.fields.LCN_PROCESS_ID & "-" & dao.fields.DATE_YEAR & "-" & dao.fields.TR_ID
        Dim URL As String = DBD_LINK(IDENTIFY, COMPANY_INDENTIFY, TR_ID, TOKEN)
        'Response.Redirect(URL)
        Response.Write("<script language='javascript'>window.open('" & URL & "','_blank','');")
        Response.Write("</script>")
    End Sub

    Protected Sub btn_Closed_Click(sender As Object, e As EventArgs) Handles btn_Closed.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
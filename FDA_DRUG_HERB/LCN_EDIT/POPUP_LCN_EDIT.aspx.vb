Public Class POPUP_LCN_EDIT1
    Inherits System.Web.UI.Page

    'Private _IDA As String
    ' Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _lcn_ida As String
    Private _STATUS_ID As Integer
    Shared _detial_type As Integer

    Private _CLS As New CLS_SESSION
    Private _CLS_CITIZEN_ID_AUTHORIZE As String = ""
    Private _CLS_CITIZEN_ID As String = ""
    Private _CLS_THANM As String = ""



    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        ''_la_IDA = Request.QueryString("la_IDA")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        '_IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("LCN_IDA")
        _STATUS_ID = Request.QueryString("STATUS_ID")
        _detial_type = Request.QueryString("detail")

        _CLS = Session("CLS")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'set_txt_label()
            If _detial_type = 1 Then
                btn_save.Visible = False
            ElseIf _detial_type = 2 Then
                btn_save.Visible = False
            Else
                btn_save.Visible = True
            End If
        End If

        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_lcn_ida, 2)

        Dim status_id As Integer = 0

        For Each dr In dt.Rows
            status_id = dr("STATUS_ID")
        Next

        'UC_LCN_EDIT1.bind_type_CHK_BOX(_lcn_ida)
        'UC_LCN_EDIT1.bind_table_CHK_BOX(_lcn_ida)



    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        UC_LCN_EDIT1.save_data_DDL()
        UC_LCN_EDIT1.save_data(dao)

        'Dim dt1 As New DataTable
        'Try
        '    dt1 = UC_LCN_EDIT1.get_dt_edit(_lcn_ida)
        'Catch ex As Exception

        'End Try


        Dim tr_id As String = ""
        Dim lcn_edit_process As Integer = 0
        Dim ddl1 As Integer = 0
        Dim ddl2 As Integer = 0
        ddl1 = dao.fields.LCN_EDIT_REASON_TYPE
        Try
            ddl2 = dao.fields.FK_SUB_REASON_TYPE
        Catch ex As Exception
        End Try

        tr_id = dao.fields.TR_ID
        lcn_edit_process = dao.fields.LCN_PROCESS_ID

        Dim dt As New DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        Dim YEAR_S As String = ""
        YEAR_S = con_year(Date.Now().Year())
        'dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA_FILE_UPLOAD_FOR_UPDATE(_lcn_ida, ddl1, ddl2, 1, YEAR_S)

        'For Each dr As DataRow In dt.Rows
        '    Dim dao_up As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE
        '    Dim IDA As String = ""
        '    IDA = dr("IDA")
        '    dao_up.GetDataby_IDA(IDA)
        '    dao_up.fields.TR_ID = tr_id
        '    dao_up.update()
        'Next



        'If dt.Rows.Count <> 0 Then

        '    For Each dr As DataRow In dt.Rows
        '        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT
        '        Dim get_ida As Integer = 0
        '        get_ida = dr("IDA")
        '        dao_update.GetDataby_IDA_YEAR(get_ida, YEAR_S, True)
        '        dao_update.fields.ACTIVE = 0
        '        dao_update.fields.UPDATE_DATE = System.DateTime.Now
        '        dao_update.update()
        '    Next
        'End If



        dao.GetDataby_IDA_YEAR(_lcn_ida, YEAR_S, True)
        Dim ida_xml As Integer = 0
        Dim process_xml As Integer = 0
        Dim year_xml As Integer = 0
        Dim tr_id_xml As Integer = 0

        ida_xml = dao.fields.IDA
        process_xml = dao.fields.LCN_PROCESS_ID
        year_xml = dao.fields.DATE_YEAR
        tr_id_xml = dao.fields.TR_ID

        dao.fields.citizen_id = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CREATE_BY = _CLS.THANM
        dao.fields.CREATE_IDEN = _CLS.CITIZEN_ID
        Try
            If Request.QueryString("staff") = 1 Then
                dao.fields.OFF_OFFER_ID = 1
                dao.fields.OFF_OFFER = _CLS.CITIZEN_ID
            Else
                dao.fields.OFF_OFFER_ID = 0
                dao.fields.OFF_OFFER = ""
            End If
        Catch ex As Exception

        End Try


        Dim dao_ddl As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL2_REASON
        dao_ddl.GET_DATA_BY_FK_LCN_IDA(_lct_ida, 1)
        If dao.fields.LCN_EDIT_REASON_TYPE = 12 Then
            dao.fields.ML_REQUEST = 500
        Else
            dao.fields.ML_REQUEST = 300
        End If
        dao.fields.STATUS_ID = 0
        dao.update()

        AddLogStatus(dao.fields.STATUS_ID, dao.fields.LCN_PROCESS_ID, _CLS.CITIZEN_ID, dao.fields.IDA)

        bind_pdf_xml_2(ida_xml, _lcn_ida, process_xml, dao.fields.STATUS_ID, year_xml, tr_id_xml)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_lcn_ida)
        Dim IDA_LCT As Integer = 0
        If dao_lcn.fields.FK_IDA <> 0 Then
            IDA_LCT = dao_lcn.fields.FK_IDA
        End If
        Dim url As String = ""
        url = "POPUP_LCN_EDIT_UPLOAD.aspx?IDA_LCT=" & IDA_LCT & "&TR_ID=" & dao.fields.TR_ID & "&IDA_LCN=" & dao.fields.FK_LCN_IDA & "&PROCESS_ID=" & dao.fields.LCN_PROCESS_ID & "&IDA=" & dao.fields.IDA _
            & "&detial_type=" & _detial_type & "&STATUS_ID=" & dao.fields.STATUS_ID
        Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');window.location='" & url & "';</script> ")

    End Sub

    Public Sub bind_pdf_xml_2(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, LCN_IDA, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 0)
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 1)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
End Class
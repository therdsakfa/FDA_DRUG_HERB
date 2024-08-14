Public Class FRM_HERB_TABEAN_JJ_EDIT_ADD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As String = ""
    Private IDA_JJ As String = ""
    Private _PROCESS_ID As String = ""
    Private _IDA As String = ""

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

        _IDA_LCN = Request.QueryString("IDA_LCN")
        IDA_JJ = Request.QueryString("IDA_JJ")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_editname()
            get_data()
            UC_PACKING_SIZE.bind_dd_pack_1()
            UC_PACKING_SIZE.bind_dd_pack_2()
            UC_PACKING_SIZE.bind_dd_pack_3()
            UC_PACKING_SIZE.bind_dd_unit_1()
            UC_PACKING_SIZE.bind_dd_unit_2()
            UC_PACKING_SIZE.bind_dd_unit_3()
        End If
    End Sub

    Public Sub get_data()
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(IDA_JJ)
        txt_IDEN.Text = dao_jj.fields.CITIZEN_ID_AUTHORIZE
        NAME_JJ.Text = dao_jj.fields.LCN_NAME
        Txt_RgtNO_JJ.Text = dao_jj.fields.RGTNO_FULL
        Txt_Name_Thai.Text = dao_jj.fields.NAME_THAI
        txt_Name_Eng.Text = dao_jj.fields.NAME_ENG
        Txt_jj_no.Text = dao_jj.fields.RGTNO_FULL
        Txt_SALE_CHANNEL_NAME.Text = dao_jj.fields.SALE_CHANNEL_NAME
        txt_agent99.Text = dao_jj.fields.AGENT_99
        'TXT_SEARCH_TN.Text = dao_jj.fields.AGENT_99
        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_identify(dao_jj.fields.CITIZEN_ID_AUTHORIZE)

        Dim TYPE_PERSON As Integer = dao_cpn.fields.type
        If TYPE_PERSON = 1 Then
            Dim citizen_id As String = dao_jj.fields.CITIZEN_ID_AUTHORIZE
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            Dim result As String = ""
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
        Else
            txt_agent99.Text = dao_jj.fields.AGENT_99
        End If
        'Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        'dao_bsn.GetDataby_LCN_IDA(dao_jj.fields.IDA_LCN)
        'Txt_thanm_JJ.Text = dao_jj.fields.NAME_JJ
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If ddl_editname.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการที่จะขอแก้ไขเปลี่ยนแปลง');", True)
        Else
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
            dao.GetdatabyID_IDA(_IDA)
            Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao_jj.GetdatabyID_IDA(IDA_JJ)
            dao.fields.FK_IDA = dao_jj.fields.IDA
            'dao.fields.TR_ID_JJ = dao_jj.fields.TR_ID_JJ
            'dao.fields.RCVNO_FULL = dao_jj.fields.RCVNO_FULL
            dao.fields.RGTNO_FULL = dao_jj.fields.RGTNO_FULL
            dao.fields.CITIZEN_ID_AUTHORIZE = dao_jj.fields.CITIZEN_ID_AUTHORIZE
            dao.fields.AGENT_99 = txt_agent99.Text
            dao.fields.AGENT99_NM = txt_agent99.Text
            dao.fields.AGENT99_ID = TXT_SEARCH_TN.Text
            dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao.fields.CREATE_BY = _CLS.THANM
            dao.fields.DD_HERB_NAME_ID = dao_jj.fields.DD_HERB_NAME_ID
            dao.fields.DDHERB = _PROCESS_ID
            dao.fields.IDA_LCT = dao_jj.fields.IDA_LCT
            dao.fields.IDA_LCN = dao_jj.fields.LCN_ID
            dao.fields.TR_ID_LCN = dao_jj.fields.TR_ID_LCN
            dao.fields.MAIN_PROCESS_ID = dao_jj.fields.MAIN_PROCESS_ID
            dao.fields.PRODUCT_PROCESS = dao_jj.fields.PRODUCT_PROCESS
            dao.fields.MAIN_PROCESS_NAME = dao_jj.fields.MAIN_PROCESS_NAME
            dao.fields.NAME_THAI = dao_jj.fields.NAME_THAI
            dao.fields.LCN_NAME = dao_jj.fields.LCN_NAME
            dao.fields.LCN_THANAMEPLACE = dao_jj.fields.LCN_THANAMEPLACE
            dao.fields.NAME_OTHER = dao_jj.fields.NAME_OTHER
            dao.fields.NAME_JJ = dao_jj.fields.NAME_JJ
            dao.fields.NAME_THAIFULL = dao_jj.fields.NAME_THAIFULL
            dao.fields.NAME_THAI_R = dao_jj.fields.NAME_THAI_R
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.ACTIVEFACT = 1
            dao.fields.STATUS_ID = 1
            dao.Update()

            Dim dao2 As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
            dao2.GetdatabyID_IDA(dao.fields.IDA)
            Dim TR_ID As String = ""
            Dim _PROCESS_JJ As String = ""
            '_PROCESS_JJ = dao_jj.fields.DDHERB
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(_PROCESS_ID, dao.fields.IDA, dao.fields.STATUS_ID)
            'เลขดำเนินการ รันใหม่
            Dim bao_gen As New BAO.GenNumber
            TR_ID = bao_gen.GEN_NO_JJ_EDIT(con_year(Date.Now.Year), 10, _PROCESS_ID, dao.fields.IDA, _IDA_LCN)
            dao2.fields.TR_ID_JJ = TR_ID
            dao2.Update()

            Try
                UC_EDIT_NAME_PRODUCT.save_data(dao.fields.IDA)
                UC_PACKING_SIZE.save_data(dao.fields.IDA)
                UC_ADDRESS_PRODUTION_SITE.save_data(dao.fields.IDA)
                UC_LABELS_ANDDUCQUMENT.Save_Data(dao.fields.IDA)
            Catch ex As Exception

            End Try

            Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
            dao.GetdatabyID_IDA(_IDA)
            dao_up_mas.GetdatabyID_TYPE(204)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.TR_ID = dao2.fields.TR_ID_JJ
                dao_up.fields.FK_IDA = dao2.fields.IDA
                dao_up.fields.PROCESS_ID = dao2.fields.DDHERB
                dao_up.fields.FK_IDA_LCN = _IDA_LCN
                dao_up.fields.TYPE = 1
                dao_up.insert()
            Next

            Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT_UPLOAD.aspx?IDA_JJ=" & IDA_JJ & "&IDA_LCN=" & _IDA_LCN & "&IDA=" & dao.fields.IDA & "&PROCESS_ID=" & _PROCESS_ID & "&TR_ID=" & TR_ID)

        End If
    End Sub

    Public Sub bind_editname()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_DDL_TABEAN_JJ_EDIT_REQUEST()

        ddl_editname.DataSource = dt
        ddl_editname.DataBind()
        ddl_editname.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT.aspx?IDA_JJ=" & IDA_JJ & "&IDA_LCN=" & _IDA_LCN)
    End Sub

    Protected Sub btn_select_edit_Click(sender As Object, e As EventArgs) Handles btn_select_edit.Click
        If ddl_editname.SelectedValue = 1 Then
            UC_EDIT_NAME_PRODUCT.SET_SHOW()
        ElseIf ddl_editname.SelectedValue = 2 Then
            UC_ADDRESS_PRODUTION_SITE.SET_SHOW()
        ElseIf ddl_editname.SelectedValue = 3 Then
            INSERT_SIZEPACK()
            UC_PACKING_SIZE.SET_SHOW()
        ElseIf ddl_editname.SelectedValue = 4 Then
            UC_LABELS_ANDDUCQUMENT.SET_SHOW()
        End If
    End Sub

    Sub INSERT_SIZEPACK()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(IDA_JJ)
        Dim dao_sp_jj As New DAO_TABEAN_HERB.TB_TABEAN_SUBPACKAGE
        Dim dao_sp_edit2 As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_SUBPACKAGE
        dao_sp_jj.GetData_ByFkIDA(dao.fields.DD_HERB_NAME_ID)
        dao_sp_edit2.GetData_ByFkIDA(_IDA)
        Dim _PROCESS_JJ As Integer = 0

        If dao.fields.DDHERB IsNot Nothing Then
            _PROCESS_JJ = dao.fields.DDHERB
        End If
        If IsNothing(dao_sp_edit2.fields.IDA) = True Or dao_sp_edit2.fields.IDA = 0 Then
            For Each dao_sp_jj.fields In dao_sp_jj.datas
                Dim dao_sp_edit As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_SUBPACKAGE
                dao_sp_edit.fields.FK_IDA = _IDA
                dao_sp_edit.fields.FK_IDA_JJ = dao_sp_jj.fields.FK_IDA
                dao_sp_edit.fields.PROCESS_ID = _PROCESS_JJ
                dao_sp_edit.fields.PACK_FSIZE_VOLUME = dao_sp_jj.fields.PACK_FSIZE_VOLUME
                dao_sp_edit.fields.PACK_FSIZE_ID = dao_sp_jj.fields.PACK_FSIZE_ID
                dao_sp_edit.fields.PACK_FSIZE_NAME = dao_sp_jj.fields.PACK_FSIZE_NAME
                dao_sp_edit.fields.PACK_FSIZE_UNIT_ID = dao_sp_jj.fields.PACK_FSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_FSIZE_UNIT_NAME = dao_sp_jj.fields.PACK_FSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_SECSIZE_VOLUME = dao_sp_jj.fields.PACK_SECSIZE_VOLUME
                dao_sp_edit.fields.PACK_SECSIZE_ID = dao_sp_jj.fields.PACK_SECSIZE_ID
                dao_sp_edit.fields.PACK_SECSIZE_NAME = dao_sp_jj.fields.PACK_SECSIZE_NAME
                dao_sp_edit.fields.PACK_SECSIZE_UNIT_ID = dao_sp_jj.fields.PACK_SECSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_SECSIZE_UNIT_NAME = dao_sp_jj.fields.PACK_SECSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_THSSIZE_VOLUME = dao_sp_jj.fields.PACK_THSSIZE_VOLUME
                dao_sp_edit.fields.PACK_THSIZE_ID = dao_sp_jj.fields.PACK_THSIZE_ID
                dao_sp_edit.fields.PACK_THSIZE_NAME = dao_sp_jj.fields.PACK_THSIZE_NAME
                dao_sp_edit.fields.PACK_THSIZE_UNIT_ID = dao_sp_jj.fields.PACK_THSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_THSIZE_UNIT_NAME = dao_sp_jj.fields.PACK_THSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_NOTE = dao_sp_jj.fields.PACK_NOTE
                dao_sp_edit.fields.ACTIVEFACT = dao_sp_jj.fields.ACTIVEFACT
                dao_sp_edit.fields.CREATE_DATE = dao_sp_jj.fields.CREATE_DATE
                dao_sp_edit.fields.CREATE_BY = dao_sp_jj.fields.CREATE_BY
                dao_sp_edit.fields.UPDATE_DATE = dao_sp_jj.fields.UPDATE_DATE
                dao_sp_edit.fields.UPDATE_BY = dao_sp_jj.fields.UPDATE_BY
                'dao_sp_edit.fields.NO_1 = dao_sp_jj.fields.NO_1
                'dao_sp_edit.fields.NO_2 = dao_sp_jj.fields.NO_2
                'dao_sp_edit.fields.NO_3 = dao_sp_jj.fields.NO_3
                dao_sp_edit.insert()
            Next
        Else
            For Each dao_sp_jj.fields In dao_sp_jj.datas
                Dim dao_sp_edit As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_SUBPACKAGE
                dao_sp_edit.fields.FK_IDA = _IDA
                dao_sp_edit.fields.FK_IDA_JJ = dao_sp_jj.fields.FK_IDA
                dao_sp_edit.fields.PROCESS_ID = _PROCESS_JJ
                dao_sp_edit.fields.PACK_FSIZE_VOLUME = dao_sp_jj.fields.PACK_FSIZE_VOLUME
                dao_sp_edit.fields.PACK_FSIZE_ID = dao_sp_jj.fields.PACK_FSIZE_ID
                dao_sp_edit.fields.PACK_FSIZE_NAME = dao_sp_jj.fields.PACK_FSIZE_NAME
                dao_sp_edit.fields.PACK_FSIZE_UNIT_ID = dao_sp_jj.fields.PACK_FSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_FSIZE_UNIT_NAME = dao_sp_jj.fields.PACK_FSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_SECSIZE_VOLUME = dao_sp_jj.fields.PACK_SECSIZE_VOLUME
                dao_sp_edit.fields.PACK_SECSIZE_ID = dao_sp_jj.fields.PACK_SECSIZE_ID
                dao_sp_edit.fields.PACK_SECSIZE_NAME = dao_sp_jj.fields.PACK_SECSIZE_NAME
                dao_sp_edit.fields.PACK_SECSIZE_UNIT_ID = dao_sp_jj.fields.PACK_SECSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_SECSIZE_UNIT_NAME = dao_sp_jj.fields.PACK_SECSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_THSSIZE_VOLUME = dao_sp_jj.fields.PACK_THSSIZE_VOLUME
                dao_sp_edit.fields.PACK_THSIZE_ID = dao_sp_jj.fields.PACK_THSIZE_ID
                dao_sp_edit.fields.PACK_THSIZE_NAME = dao_sp_jj.fields.PACK_THSIZE_NAME
                dao_sp_edit.fields.PACK_THSIZE_UNIT_ID = dao_sp_jj.fields.PACK_THSIZE_UNIT_ID
                dao_sp_edit.fields.PACK_THSIZE_UNIT_NAME = dao_sp_jj.fields.PACK_THSIZE_UNIT_NAME
                dao_sp_edit.fields.PACK_NOTE = dao_sp_jj.fields.PACK_NOTE
                dao_sp_edit.fields.ACTIVEFACT = dao_sp_jj.fields.ACTIVEFACT
                dao_sp_edit.fields.CREATE_DATE = dao_sp_jj.fields.CREATE_DATE
                dao_sp_edit.fields.CREATE_BY = dao_sp_jj.fields.CREATE_BY
                dao_sp_edit.fields.UPDATE_DATE = dao_sp_jj.fields.UPDATE_DATE
                dao_sp_edit.fields.UPDATE_BY = dao_sp_jj.fields.UPDATE_BY
                'dao_sp_edit.fields.NO_1 = dao_sp_jj.fields.NO_1
                'dao_sp_edit.fields.NO_2 = dao_sp_jj.fields.NO_2
                'dao_sp_edit.fields.NO_3 = dao_sp_jj.fields.NO_3
                dao_sp_edit.Update()
            Next
        End If
    End Sub
    Protected Sub BTN_SEARCH_TN_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_TN.Click
        Dim dao As New DAO_CPN.TB_syslcnsnm

        If TXT_SEARCH_TN.Text IsNot Nothing Then
            Dim citizen_id As String = TXT_SEARCH_TN.Text
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)
            Try
                Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
                If TYPE_PERSON = 1 Then
                    txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Or TYPE_PERSON = 4 Or TYPE_PERSON = 11 Then
                    txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                        txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    Else
                        txt_agent99.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    End If
                End If
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End Try

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
        End If
    End Sub
End Class
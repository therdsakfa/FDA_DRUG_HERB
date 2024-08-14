Public Class POPUP_TABEAN_JJ_EDIT_REQUEST
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
            'bind_editname()
            get_data()
            UC_Packing_Size.bind_dd_pack_1()
            UC_Packing_Size.bind_dd_pack_2()
            UC_Packing_Size.bind_dd_pack_3()
            UC_Packing_Size.bind_dd_unit_1()
            UC_Packing_Size.bind_dd_unit_2()
            UC_Packing_Size.bind_dd_unit_3()
        End If
    End Sub

    Public Sub get_data()
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(IDA_JJ)
        txt_IDEN.Text = dao_jj.fields.CITIZEN_ID_AUTHORIZE
        NAME_JJ.Text = dao_jj.fields.NAME_JJ
        Txt_RgtNO_JJ.Text = dao_jj.fields.RGTNO_FULL
        Txt_Name_Thai.Text = dao_jj.fields.NAME_THAI
        txt_Name_Eng.Text = dao_jj.fields.NAME_ENG
        Txt_jj_no.Text = dao_jj.fields.RGTNO_FULL
        Txt_SALE_CHANNEL_NAME.Text = dao_jj.fields.SALE_CHANNEL_NAME
        Txt_thanm_JJ.Text = dao_jj.fields.NAME_JJ

        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(_IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If dao_cb.fields.NAME_PRODUCK_1 = 1 Or dao_cb.fields.NAME_PRODUCK_2 = 1 Or dao_cb.fields.NAME_PRODUCK_3 = 1 Or dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                UC_EDIT_NAME_PRODUCT.SET_SHOW()
            End If
            If dao_cb.fields.NAME_ADDR1 = 1 Or dao_cb.fields.NAME_ADDR2 = 1 Or dao_cb.fields.NAME_ADDR3 = 1 Then
                UC_ADDRESS_PRODUTION_SITE.SET_SHOW()
            End If
            If dao_cb.fields.Size_Packet = 1 Then
                UC_PACKING_SIZE.SET_SHOW()
            End If
            If dao_cb.fields.Label_And_Ducumant = 1 Then
                UC_LABELS_ANDDUCQUMENT.SET_SHOW()
            End If
        End If

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)


        If dao.fields.EDIT_RQ_ID = 1 Then
            UC_EDIT_NAME_PRODUCT.SET_SHOW()
        ElseIf dao.fields.EDIT_RQ_ID = 2 Then
            UC_ADDRESS_PRODUTION_SITE.SET_SHOW()
        ElseIf dao.fields.EDIT_RQ_ID = 3 Then
            UC_PACKING_SIZE.SET_SHOW()
        ElseIf dao.fields.EDIT_RQ_ID = 4 Then
            UC_LABELS_ANDDUCQUMENT.SET_SHOW()
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(IDA_JJ)
        'dao.fields.FK_IDA = dao_jj.fields.IDA
        ''dao.fields.TR_ID_JJ = dao_jj.fields.TR_ID_JJ
        ''dao.fields.RCVNO_FULL = dao_jj.fields.RCVNO_FULL
        'dao.fields.RGTNO_FULL = dao_jj.fields.RGTNO_FULL
        'dao.fields.CITIZEN_ID_AUTHORIZE = dao_jj.fields.CITIZEN_ID_AUTHORIZE
        'dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        'dao.fields.CREATE_BY = _CLS.CITIZEN_ID
        'dao.fields.DD_HERB_NAME_ID = dao_jj.fields.DD_HERB_NAME_ID
        'dao.fields.DDHERB = _PROCESS_ID
        'dao.fields.IDA_LCT = dao_jj.fields.IDA_LCT
        'dao.fields.IDA_LCN = dao_jj.fields.LCN_ID
        'dao.fields.TR_ID_LCN = dao_jj.fields.TR_ID_LCN
        'dao.fields.MAIN_PROCESS_ID = dao_jj.fields.MAIN_PROCESS_ID
        'dao.fields.PRODUCT_PROCESS = dao_jj.fields.PRODUCT_PROCESS
        'dao.fields.MAIN_PROCESS_NAME = dao_jj.fields.MAIN_PROCESS_NAME
        'dao.fields.NAME_THAI = dao_jj.fields.NAME_THAI
        'dao.fields.LCN_NAME = dao_jj.fields.LCN_NAME
        'dao.fields.LCN_THANAMEPLACE = dao_jj.fields.LCN_THANAMEPLACE
        'dao.fields.NAME_OTHER = dao_jj.fields.NAME_OTHER
        'dao.fields.NAME_JJ = dao_jj.fields.NAME_JJ
        'dao.fields.CREATE_DATE = Date.Now
        'dao.fields.ACTIVEFACT = 1
        'dao.fields.STATUS_ID = 1
        dao.Update()

        'Dim dao2 As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        'dao2.GetdatabyID_IDA(dao.fields.IDA)
        'Dim TR_ID As String = ""
        'Dim _PROCESS_JJ As String = ""
        ''_PROCESS_JJ = dao_jj.fields.DDHERB
        'Dim bao_tran As New BAO_TRANSECTION
        'bao_tran.insert_transection_jj(_PROCESS_ID, dao.fields.IDA, dao.fields.STATUS_ID)
        ''เลขดำเนินการ รันใหม่
        'Dim bao_gen As New BAO.GenNumber
        'TR_ID = bao_gen.GEN_NO_JJ_EDIT(con_year(Date.Now.Year), 10, _PROCESS_ID, dao.fields.IDA, _IDA_LCN)
        'dao2.fields.TR_ID_JJ = TR_ID
        'dao2.Update()

        Try
            UC_EDIT_NAME_PRODUCT.Update_data(dao.fields.IDA)
            UC_PACKING_SIZE.Update_data(dao.fields.IDA)
            UC_ADDRESS_PRODUTION_SITE.Update_data(dao.fields.IDA)
            UC_LABELS_ANDDUCQUMENT.Update_Data(dao.fields.IDA)
        Catch ex As Exception

        End Try

        Response.Redirect("FRM_HERB_TABEAN_JJ_EDIT_COMFIRM.aspx?IDA_JJ=" & IDA_JJ & "&IDA_LCN=" & _IDA_LCN & "&IDA=" & dao.fields.IDA & "&PROCESS_ID=" & _PROCESS_ID)
    End Sub

    'Public Sub bind_editname()
    '    Dim dt As DataTable
    '    Dim bao As New BAO_TABEAN_HERB.tb_dd
    '    dt = bao.SP_MAS_DDL_TABEAN_JJ_EDIT_REQUEST()

    '    ddl_editname.DataSource = dt
    '    ddl_editname.DataBind()
    '    ddl_editname.Items.Insert(0, "-- กรุณาเลือก --")
    'End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    'Protected Sub btn_select_edit_Click(sender As Object, e As EventArgs) Handles btn_select_edit.Click

    '    If ddl_editname.SelectedValue = 1 Then
    '        UC_EDIT_NAME_PRODUCT.SET_SHOW()
    '    ElseIf ddl_editname.SelectedValue = 2 Then
    '        UC_ADDRESS_PRODUTION_SITE.SET_SHOW()
    '    ElseIf ddl_editname.SelectedValue = 3 Then
    '        UC_PACKING_SIZE.SET_SHOW()
    '    ElseIf ddl_editname.SelectedValue = 4 Then
    '        UC_LABELS_ANDDUCQUMENT.SET_SHOW()
    '    End If
    'End Sub
End Class
Public Class UC_EDIT_NAME_PRODUCT
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As String = ""
    Private IDA_JJ As String = ""
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
        _IDA = Request.QueryString("IDA")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        IDA_JJ = Request.QueryString("IDA_JJ")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            get_data()
        End If
    End Sub

    Protected Sub cb_sub_menu_1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_sub_menu_1.CheckedChanged
        If cb_sub_menu_1.Checked = True Then
            CB1.Visible = True
        Else
            CB1.Visible = False
        End If
    End Sub

    Protected Sub cb_sub_menu_2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_sub_menu_2.CheckedChanged
        If cb_sub_menu_2.Checked = True Then
            CB2.Visible = True
        Else
            CB2.Visible = False
        End If
    End Sub
    Sub SET_SHOW()
        ID1.Visible = True
    End Sub

    Protected Sub cb_sub_menu_3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_sub_menu_3.CheckedChanged
        If cb_sub_menu_3.Checked = True Then
            CB3.Visible = True
        Else
            CB3.Visible = False
        End If
    End Sub

    Protected Sub cb_sub_menu_4_CheckedChanged(sender As Object, e As EventArgs) Handles cb_sub_menu_4.CheckedChanged
        If cb_sub_menu_4.Checked = True Then
            CB4.Visible = True
        Else
            CB4.Visible = False
        End If
    End Sub

    Sub get_data()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_JJ As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_JJ.GetdatabyID_IDA(IDA_JJ)
        If dao_JJ.fields.NAME_ENG = Nothing Then
            NAME_ENG.Text = "ไม่มี"
        Else
            NAME_ENG.Text = dao_JJ.fields.NAME_ENG
            NAME_ENG_NEW.Text = dao_JJ.fields.NAME_ENG
        End If
        If dao_JJ.fields.NAME_OTHER = Nothing Then
            NAME_OTHER.Text = "ไม่มี"
        Else
            NAME_OTHER.Text = dao_JJ.fields.NAME_OTHER
            NAME_OTHER_NEW.Text = dao_JJ.fields.NAME_OTHER
        End If

        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(_IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If dao_cb.fields.NAME_PRODUCK_1 = 1 Then
                cb_sub_menu_1.Checked = True
                CB1.Visible = True
                NAME_ENG_NEW.Text = dao.fields.NAME_ENG
            End If
            If dao_cb.fields.NAME_PRODUCK_2 = 1 Then
                cb_sub_menu_2.Checked = True
                CB2.Visible = True
                NAME_OTHER_NEW.Text = dao.fields.NAME_OTHER
            End If
            If dao_cb.fields.NAME_PRODUCK_3 = 1 Then
                cb_sub_menu_3.Checked = True
                CB3.Visible = True
                NAME_OTHER_NEW.Text = dao.fields.NAME_OTHER
            End If
            If dao_cb.fields.NAME_PRODUCK_4 = 1 Then
                cb_sub_menu_4.Checked = True
                CB4.Visible = True
                NAME_OTHER_NEW.Text = dao.fields.NAME_OTHER
            End If
            'Else
            '    dao_cb.fields.FK_IDA = _IDA
            '    If dao_cb.fields.NAME_PRODUCK_1 = 1 Then

            '    End If
            '    If dao_cb.fields.NAME_PRODUCK_2 = 1 Then

            '    End If
            '    If dao_cb.fields.NAME_PRODUCK_3 = 1 Then

            '    End If
            '    If dao_cb.fields.NAME_PRODUCK_4 = 1 Then

            '    End If
        End If
    End Sub

    Sub save_data(ByVal IDA As Integer)
        Dim log As New DAO_TABEAN_HERB.TB_LOG_EDIT_JJ
        Try
            log.Getdataby_FK_IDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If log.fields.IDA <> 0 Then
            log.fields.NAME_ENG = NAME_ENG.Text
            log.fields.NAME_ENG_NEW = NAME_ENG_NEW.Text
            log.fields.NAME_ORTHER = NAME_OTHER.Text
            log.fields.NAME_ORTHER_NEW = NAME_OTHER_NEW.Text
            log.fields.EXPORTNAME_ENG = Txt_NameEXP_Eng.Text
            log.fields.EXPORTNAME_ENG_NEW = Txt_NameEXP_Eng_New.Text
            log.fields.EXPORTNAME_OTHER = Txt_NameEXP_Other.Text
            log.fields.EXPORTNAME_OTHER_NEW = Txt_NameEXP_Other_New.Text
            log.fields.FK_IDA = Request.QueryString("IDA")
            log.fields.IDENTIFY = _CLS.CITIZEN_ID
            log.Update()
        Else
            log.fields.NAME_ENG = NAME_ENG.Text
            log.fields.NAME_ENG_NEW = NAME_ENG_NEW.Text
            log.fields.NAME_ORTHER = NAME_OTHER.Text
            log.fields.NAME_ORTHER_NEW = NAME_OTHER_NEW.Text
            log.fields.EXPORTNAME_ENG = Txt_NameEXP_Eng.Text
            log.fields.EXPORTNAME_ENG_NEW = Txt_NameEXP_Eng_New.Text
            log.fields.EXPORTNAME_OTHER = Txt_NameEXP_Other.Text
            log.fields.EXPORTNAME_OTHER_NEW = Txt_NameEXP_Other_New.Text
            log.fields.FK_IDA = Request.QueryString("IDA")
            log.fields.IDENTIFY = _CLS.CITIZEN_ID
            log.insert()
        End If

        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(IDA)
        dao.fields.NAME_ENG = NAME_ENG_NEW.Text
        dao.fields.NAME_OTHER = NAME_OTHER_NEW.Text
        dao.fields.EXPORTNAME_ENG = Txt_NameEXP_Eng_New.Text
        dao.fields.EXPORTNAME_OTHER = Txt_NameEXP_Other_New.Text
        'dao.fields.cb_sub_name_1 = 1
        'dao.Update()

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        'Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If cb_sub_menu_1.Checked = True Then
                dao_cb.fields.NAME_PRODUCK_1 = 1
            Else
                dao_cb.fields.NAME_PRODUCK_1 = 0
            End If
            If cb_sub_menu_2.Checked = True Then
                dao.fields.SUPPORT_EDIT_ID = 1
                dao_cb.fields.NAME_PRODUCK_2 = 1
                dao_up_mas.GetdatabyID_TYPE(102)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = dao.fields.TR_ID_JJ
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.PROCESS_ID = dao.fields.DDHERB
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next
            Else
                dao_cb.fields.NAME_PRODUCK_2 = 0
            End If
            If cb_sub_menu_3.Checked = True Then
                dao_cb.fields.NAME_PRODUCK_3 = 1
            Else
                dao_cb.fields.NAME_PRODUCK_3 = 0
            End If
            If cb_sub_menu_4.Checked = True Then
                dao.fields.SUPPORT_EDIT_ID = 1
                dao_cb.fields.NAME_PRODUCK_4 = 1
                dao_up_mas.GetdatabyID_TYPE(104)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = dao.fields.TR_ID_JJ
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.PROCESS_ID = dao.fields.DDHERB
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next
            Else
                dao_cb.fields.NAME_PRODUCK_4 = 0
            End If
            'dao_up.insert()
            dao_cb.fields.Activefact = 1
            dao_cb.Update()
        Else
            dao_cb.fields.FK_IDA = IDA
            If cb_sub_menu_1.Checked = True Then
                dao_cb.fields.NAME_PRODUCK_1 = 1
            Else
                dao_cb.fields.NAME_PRODUCK_1 = 0
            End If
            If cb_sub_menu_2.Checked = True Then
                dao.fields.SUPPORT_EDIT_ID = 1
                dao_cb.fields.NAME_PRODUCK_2 = 1
                dao_up_mas.GetdatabyID_TYPE(102)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = dao.fields.TR_ID_JJ
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.PROCESS_ID = dao.fields.DDHERB
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next
            Else
                dao_cb.fields.NAME_PRODUCK_2 = 0
            End If
            If cb_sub_menu_3.Checked = True Then
                dao_cb.fields.NAME_PRODUCK_3 = 1
            Else
                dao_cb.fields.NAME_PRODUCK_3 = 0
            End If
            If cb_sub_menu_4.Checked = True Then
                dao.fields.SUPPORT_EDIT_ID = 1
                dao_cb.fields.NAME_PRODUCK_4 = 1
                dao_up_mas.GetdatabyID_TYPE(104)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = dao.fields.TR_ID_JJ
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    'dao_up.fields.PROCESS_ID = _PROCESS_JJ
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next
            Else
                dao_cb.fields.NAME_PRODUCK_4 = 0
            End If
            dao_cb.fields.Activefact = 1
            dao_cb.insert()
            'dao.Update()
        End If

        dao.Update()

    End Sub
    Sub Update_data(ByVal IDA As Integer)
        Dim log As New DAO_TABEAN_HERB.TB_LOG_EDIT_JJ
        Try
            log.Getdataby_FK_IDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If log.fields.IDA <> 0 Then
            log.fields.NAME_ENG = NAME_ENG.Text
            log.fields.NAME_ENG_NEW = NAME_ENG_NEW.Text
            log.fields.NAME_ORTHER = NAME_OTHER.Text
            log.fields.NAME_ORTHER_NEW = NAME_OTHER_NEW.Text
            log.fields.FK_IDA = Request.QueryString("IDA")
            log.fields.IDENTIFY = _CLS.CITIZEN_ID
            log.Update()
        Else
            log.fields.NAME_ENG = NAME_ENG.Text
            log.fields.NAME_ENG_NEW = NAME_ENG_NEW.Text
            log.fields.NAME_ORTHER = NAME_OTHER.Text
            log.fields.NAME_ORTHER_NEW = NAME_OTHER_NEW.Text
            log.fields.FK_IDA = Request.QueryString("IDA")
            log.fields.IDENTIFY = _CLS.CITIZEN_ID
            log.insert()
        End If

        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(IDA)
        dao.fields.NAME_ENG = NAME_ENG_NEW.Text
        dao.fields.NAME_OTHER = NAME_OTHER_NEW.Text
        'dao.fields.cb_sub_name_1 = 1
        dao.Update()

    End Sub
End Class
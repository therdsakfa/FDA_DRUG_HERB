Imports Telerik.Web.UI

Public Class UC_ADDRESS_PRODUTION_SITE
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
            Get_Data()
        End If
    End Sub

    Shared PLACE_IDA As Integer = 0
    Shared PLACE_NAME As String = ""
    Shared PLACE_ADDRESS As String = ""
    Shared TXT_MENUFACTRUE_DETAIL As String = ""
    Shared IDA_ADDRESS As Integer = 0

    Sub SET_SHOW()
        ID2.Visible = True
    End Sub

    Sub Get_Data()

        Dim dao_ed As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao_ed.GetdatabyID_IDA(_IDA)

        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(_IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If dao_cb.fields.NAME_ADDR1 = 1 Then
                cb_sub_menu_1.Checked = True
                CB1.Visible = True
            ElseIf dao_cb.fields.NAME_ADDR2 = 1 Then
                cb_sub_menu_2.Checked = True
                CB2.Visible = True
            ElseIf dao_cb.fields.NAME_ADDR3 = 1 Then
                cb_sub_menu_3.Checked = True
                CB3.Visible = True
            End If

        End If

        Dim bao As New BAO_MASTER
        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(IDA_JJ)
        Dim dt As New DataTable
        Try
            dt = bao.SP_ADDR_BY_IDA(dao_jj.fields.IDA_LCN)
        Catch ex As Exception

        End Try
        Dim addr As String = ""
        If dt.Rows.Count > 0 Then
            addr = dt(0)("fulladdr")
        End If
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(dao_jj.fields.IDA_LCN)
        Catch ex As Exception

        End Try
        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try
        Dim THANM As String = dao_lcn.fields.thanm
        If THANM = "" Or THANM Is Nothing Then
            THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
        Else
            THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        End If
        Txt_Thanm_Old.Text = dao_jj.fields.LCN_NAME
        Try
            dao.GetDataby_IDA(dao_jj.fields.IDA_LCT)
        Catch ex As Exception

        End Try

        Try
            txt_addr_Old.Text = addr
        Catch ex As Exception

        End Try
        Try
            txt_addrnm_Old.Text = dao.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            'If dao_lcn.fields.LCNNO_DISPLAY_NEW = "" Or dao_lcn.fields.LCNNO_DISPLAY_NEW = Nothing Then
            '    txt_lcnno_Old.Text = dao_lcn.fields.LCNNO_DISPLAY
            'Else
            '    txt_lcnno_Old.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
            'End If
            txt_lcnno_Old.Text = dao_jj.fields.LCNNO
        Catch ex As Exception

        End Try
        Try
            txt_address.Text = dao_jj.fields.FOREIGN_NAME_PLACE
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cb_sub_menu_1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_sub_menu_1.CheckedChanged
        If cb_sub_menu_1.Checked = True Then
            CB1.Visible = True
            LCN_Div.Visible = True
        Else
            CB1.Visible = False
            LCN_Div.Visible = False
        End If
    End Sub

    Protected Sub cb_sub_menu_2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_sub_menu_2.CheckedChanged
        If cb_sub_menu_2.Checked = True Then
            CB2.Visible = True
            LCN_Div.Visible = True
        Else
            CB2.Visible = False
            LCN_Div.Visible = False
        End If
    End Sub

    Protected Sub Btn_Search_Lcn_Click(sender As Object, e As EventArgs) Handles Btn_Search_Lcn.Click
        Dim LCN_NO As String = ""
        LCN_NO = Txt_search_Lcnno.Text
        Dim bao As New BAO_MASTER
        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(IDA_JJ)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_lcnno_new(LCN_NO)
        Catch ex As Exception
            alert("ไม่เจอใบอนุญาต")
        End Try

        Dim dt As New DataTable
        Try
            dt = bao.SP_ADDR_BY_IDA(dao_lcn.fields.IDA)
        Catch ex As Exception
            alert("ไม่เจอใบอนุญาต")
        End Try
        Dim addr As String = ""
        If dt.Rows.Count > 0 Then
            addr = dt(0)("fulladdr")
        End If

        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try
        Dim THANM As String = dao_lcn.fields.thanm
        If THANM = "" Or THANM Is Nothing Then
            THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
        Else
            THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        End If
        Txt_Thanm_New.Text = THANM
        Try
            dao.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        Catch ex As Exception
            alert("ไม่เจอใบอนุญาต")
        End Try

        Try
            Txt_Addr_New.Text = addr
        Catch ex As Exception

        End Try
        Try
            Txt_AddrNm_New.Text = dao.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            If dao_lcn.fields.LCNNO_DISPLAY_NEW = "" Or dao_lcn.fields.LCNNO_DISPLAY_NEW = Nothing Then
                Txt_LCNNO_New.Text = dao_lcn.fields.LCNNO_DISPLAY
            Else
                Txt_LCNNO_New.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Btn_ResetData_Click(sender As Object, e As EventArgs) Handles Btn_ResetData.Click
        Dim bao As New BAO_MASTER
        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(IDA_JJ)
        Dim dt As New DataTable
        Try
            dt = bao.SP_ADDR_BY_IDA(dao_jj.fields.IDA_LCN)
        Catch ex As Exception

        End Try
        Dim addr As String = ""
        If dt.Rows.Count > 0 Then
            addr = dt(0)("fulladdr")
        End If
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(dao_jj.fields.IDA_LCN)
        Catch ex As Exception

        End Try
        Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
        Try
            dao_customer.GetDataby_lcnsid(dao_lcn.fields.lcnsid)
        Catch ex As Exception

        End Try
        Dim THANM As String = dao_lcn.fields.thanm
        If THANM = "" Or THANM Is Nothing Then
            THANM = dao_customer.fields.prefixnm & " " & dao_customer.fields.thanm
        Else
            THANM = dao_lcn.fields.syslcnsnm_prefixnm & " " & dao_lcn.fields.thanm
        End If
        Txt_Thanm.Text = THANM

        dao.GetDataby_IDA(dao_jj.fields.IDA_LCT)
        Try
            Txt_Addr.Text = addr
        Catch ex As Exception

        End Try
        Try
            Txt_AddrNm.Text = dao.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            If dao_lcn.fields.LCNNO_DISPLAY_NEW = "" Or dao_lcn.fields.LCNNO_DISPLAY_NEW = Nothing Then
                Txt_LCNNO.Text = dao_lcn.fields.LCNNO_DISPLAY
            Else
                Txt_LCNNO.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Sub save_data(ByVal IDA As Integer)
        Dim log As New DAO_TABEAN_HERB.TB_LOG_EDIT_JJ
        Try
            log.Getdataby_FK_IDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If log.fields.IDA <> 0 Then
            If cb_sub_menu_1.Checked = True Then
                log.fields.ADDR_FULL = txt_addrnm_Old.Text
                log.fields.ADDR_FULL_NEW = Txt_Addr.Text
                log.fields.ADDR_NM = txt_addrnm_Old.Text
                log.fields.ADDR_NM_NEW = Txt_AddrNm_New.Text
            ElseIf cb_sub_menu_2.Checked = True Then
                log.fields.ADDR_FULL = txt_addr_Old.Text
                log.fields.ADDR_FULL_NEW = Txt_Addr_New.Text
                log.fields.ADDR_NM = txt_addrnm_Old.Text
                log.fields.ADDR_NM_NEW = Txt_AddrNm_New.Text
            ElseIf cb_sub_menu_3.Checked = True Then
                log.fields.FOREIGN_NAME_PLACE = txt_address.Text
                log.fields.FOREIGN_NAME_PLACE_NEW = txt_address_New.Text
                log.fields.IDENTIFY = _CLS.CITIZEN_ID
                log.fields.FK_IDA = Request.QueryString("IDA")
            End If

            log.Update()
        Else
            If cb_sub_menu_1.Checked = True Then
                log.fields.ADDR_FULL = txt_addrnm_Old.Text
                log.fields.ADDR_FULL_NEW = Txt_Addr.Text
                log.fields.ADDR_NM = txt_addrnm_Old.Text
                log.fields.ADDR_NM_NEW = Txt_AddrNm_New.Text
            ElseIf cb_sub_menu_2.Checked = True Then
                log.fields.ADDR_FULL = Txt_Addr.Text
                log.fields.ADDR_FULL_NEW = Txt_AddrNm_New.Text
                log.fields.ADDR_NM = txt_addrnm_Old.Text
                log.fields.ADDR_NM_NEW = Txt_Addr_New.Text
            ElseIf cb_sub_menu_3.Checked = True Then
                log.fields.FOREIGN_NAME_PLACE = txt_address.Text
                log.fields.FOREIGN_NAME_PLACE_NEW = txt_address_New.Text
                log.fields.IDENTIFY = _CLS.CITIZEN_ID
                log.fields.FK_IDA = Request.QueryString("IDA")
            End If
            log.insert()
        End If

        Dim LCN_NO As String = ""
        LCN_NO = Txt_search_Lcnno.Text
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_lcnno_new(LCN_NO)
        Catch ex As Exception
            alert("ไม่เจอใบอนุญาต")
        End Try
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(IDA)
        If cb_sub_menu_1.Checked = True Then
            dao.fields.LCN_NAME = Txt_Thanm.Text
        ElseIf cb_sub_menu_2.Checked = True Then
            dao.fields.IDA_LCN = dao_lcn.fields.IDA
            dao.fields.LCNNO = dao_lcn.fields.LCNNO_DISPLAY_NEW
            dao.fields.IDA_LCT = dao_lcn.fields.FK_IDA
            dao.fields.LCN_NAME = Txt_Thanm_New.Text
        End If
        dao.fields.SUPPORT_EDIT_ID = 1
        dao.fields.FOREIGN_TO_STAFF = Txt_Addr_to_Staff.Text
        dao.Update()

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If cb_sub_menu_1.Checked = True Then
                dao_cb.fields.NAME_ADDR1 = 1
                dao_up_mas.GetdatabyID_TYPE(106)
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
                dao_cb.fields.NAME_ADDR1 = 0
            End If
            If cb_sub_menu_2.Checked = True Then
                dao_cb.fields.NAME_ADDR2 = 1
                dao_up_mas.GetdatabyID_TYPE(107)
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
                dao_cb.fields.NAME_ADDR2 = 0
            End If
            If cb_sub_menu_3.Checked = True Then
                dao_cb.fields.NAME_ADDR3 = 1
                dao_up_mas.GetdatabyID_TYPE(108)
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
                dao_cb.fields.NAME_ADDR3 = 0
            End If
            dao_cb.Update()
        Else
            dao_cb.fields.FK_IDA = IDA
            If cb_sub_menu_1.Checked = True Then
                dao_cb.fields.NAME_ADDR1 = 1
                dao_up_mas.GetdatabyID_TYPE(106)
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
                dao_cb.fields.NAME_ADDR1 = 0
            End If
            If cb_sub_menu_2.Checked = True Then
                dao_cb.fields.NAME_ADDR2 = 1
                dao_up_mas.GetdatabyID_TYPE(107)
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
                dao_cb.fields.NAME_ADDR2 = 0
            End If
            If cb_sub_menu_3.Checked = True Then
                dao_cb.fields.NAME_ADDR3 = 1
                dao_up_mas.GetdatabyID_TYPE(108)
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
                dao_cb.fields.NAME_ADDR3 = 0
            End If
            dao_cb.insert()
        End If
    End Sub
    Sub Update_data(ByVal IDA As Integer)
        Dim log As New DAO_TABEAN_HERB.TB_LOG_EDIT_JJ
        Try
            log.Getdataby_FK_IDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If log.fields.IDA <> 0 Then
            If cb_sub_menu_1.Checked = True Then
                log.fields.ADDR_FULL = txt_addrnm_Old.Text
                log.fields.ADDR_FULL_NEW = Txt_Addr.Text
                log.fields.ADDR_NM = txt_addrnm_Old.Text
                log.fields.ADDR_NM_NEW = Txt_AddrNm_New.Text
            ElseIf cb_sub_menu_2.Checked = True Then
                log.fields.ADDR_FULL = txt_addr_Old.Text
                log.fields.ADDR_FULL_NEW = Txt_Addr_New.Text
                log.fields.ADDR_NM = txt_addrnm_Old.Text
                log.fields.ADDR_NM_NEW = Txt_AddrNm_New.Text
            ElseIf cb_sub_menu_3.Checked = True Then
                log.fields.FOREIGN_NAME_PLACE = txt_address.Text
                log.fields.FOREIGN_NAME_PLACE_NEW = txt_address_New.Text
                log.fields.IDENTIFY = _CLS.CITIZEN_ID
                log.fields.FK_IDA = Request.QueryString("IDA")
            End If

            log.Update()
        Else
            If cb_sub_menu_1.Checked = True Then
                log.fields.ADDR_FULL = txt_addrnm_Old.Text
                log.fields.ADDR_FULL_NEW = Txt_Addr.Text
                log.fields.ADDR_NM = txt_addrnm_Old.Text
                log.fields.ADDR_NM_NEW = Txt_AddrNm_New.Text
            ElseIf cb_sub_menu_2.Checked = True Then
                log.fields.ADDR_FULL = Txt_Addr.Text
                log.fields.ADDR_FULL_NEW = Txt_AddrNm_New.Text
                log.fields.ADDR_NM = txt_addrnm_Old.Text
                log.fields.ADDR_NM_NEW = Txt_Addr_New.Text
            ElseIf cb_sub_menu_3.Checked = True Then
                log.fields.FOREIGN_NAME_PLACE = txt_address.Text
                log.fields.FOREIGN_NAME_PLACE_NEW = txt_address_New.Text
                log.fields.IDENTIFY = _CLS.CITIZEN_ID
                log.fields.FK_IDA = Request.QueryString("IDA")
            End If
            log.insert()
        End If

        Dim LCN_NO As String = ""
        LCN_NO = Txt_search_Lcnno.Text
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_lcnno_new(LCN_NO)
        Catch ex As Exception
            alert("ไม่เจอใบอนุญาต")
        End Try
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(IDA)
        If cb_sub_menu_1.Checked = True Then
            dao.fields.LCN_NAME = Txt_Thanm.Text
        ElseIf cb_sub_menu_2.Checked = True Then
            dao.fields.IDA_LCN = dao_lcn.fields.IDA
            dao.fields.LCNNO = dao_lcn.fields.LCNNO_DISPLAY_NEW
            dao.fields.IDA_LCT = dao_lcn.fields.FK_IDA
            dao.fields.LCN_NAME = Txt_Thanm_New.Text
        End If
        dao.fields.FOREIGN_TO_STAFF = Txt_Addr_to_Staff.Text
        dao.Update()
    End Sub

    Protected Sub cb_sub_menu_3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_sub_menu_3.CheckedChanged
        If cb_sub_menu_3.Checked = True Then
            CB3.Visible = True
        Else
            CB3.Visible = False
        End If
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_frgn()
        'RadGrid1.Rebind()
    End Sub

    Sub Search_frgn()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_syspdcfrgn_SEARCH(txt_search.Text)

        RadGrid2.DataSource = dt
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        If txt_search.Text <> "" Then
            Search_frgn()
        End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim frgncd As Integer = 0
            Dim PLACE_NAME_THAI As String = ""
            Dim PLACE_NAME_ENG As String = ""

            PLACE_IDA = item("IDA").Text
            PLACE_NAME_THAI = item("thafrgnnm").Text
            PLACE_NAME_ENG = item("engfrgnnm").Text

            PLACE_NAME = PLACE_NAME_ENG & " " & PLACE_NAME_THAI
            txt_search.Text = PLACE_NAME
            txt_search_ida.Text = PLACE_IDA

            Try
                frgncd = item("frgncd").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dt As New DataTable
                Dim bao As New BAO_SHOW
                dt = bao.SP_drfrgnaddr_BY_frgncd(frgncd)
                HiddenField1.Value = frgncd
                RadGrid3.DataSource = dt

                RadGrid3.Rebind()

            End If

        End If
    End Sub

End Class
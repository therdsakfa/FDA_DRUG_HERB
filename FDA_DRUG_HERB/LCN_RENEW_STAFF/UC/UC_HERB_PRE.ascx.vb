Imports Telerik.Web.UI
Public Class UC_HERB_PRE
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _pvncd As Integer
    Private _ProcessID As Integer
    Private _TYPE_ID As Integer
    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            'setdata()
        End If
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Function CHECK_ID_TYPE(ByVal CITIZEN_ID_AUTHORIZE As String)
        Dim TYPE_PERSON As String = 0
        Dim thanm_fullname As String = 0
        Dim citizen_id As String = CITIZEN_ID_AUTHORIZE
        Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
        Dim obj As New XML_DATA
        'Dim cls As New CLS_COMMON.convert
        Dim result As String = ""
        'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
        result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
        obj = ConvertFromXml(Of XML_DATA)(result)
        Try
            TYPE_PERSON = obj.SYSLCNSIDs.type
            If TYPE_PERSON = 1 Then
                thanm_fullname = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            ElseIf TYPE_PERSON = 99 Then
                thanm_fullname = _CLS.THANM_CUSTOMER
                'thanm = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    thanm_fullname = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    thanm_fullname = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If
        Catch ex As Exception

        End Try
        Return TYPE_PERSON
    End Function
    Sub Set_Label(ByVal CITIZEN_ID_AUTHORIZE As String)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        dt_lcn = bao.SP_Lisense_Name_and_Addr(CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        '
        _TYPE_ID = CHECK_ID_TYPE(CITIZEN_ID_AUTHORIZE)
        For Each dr As DataRow In dt_lcn.Rows
            'Try
            '    txt_da_opentime.Text = dr("thaaddr")
            'Catch ex As Exception

            'End Try
            Try
                lbl_lcn_addr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_floor.Text = dr("floor")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_room.Text = dr("room")
            Catch ex As Exception

            End Try
            Try
                If _TYPE_ID = 1 Then
                    lbl_lcn_ages.Text = dr("age")
                Else
                    lbl_lcn_ages.Text = "-"
                End If
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_amphor.Text = dr("amphrnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_building.Text = dr("building")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_changwat.Text = dr("chngwtnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_email.Text = dr("email")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_fax.Text = dr("fax")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_iden2.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                lbl_lcn_mu.Text = dr("mu")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
            Try
                If _TYPE_ID = 1 Then
                    lbl_lcn_nation.Text = dr("nation")
                Else
                    lbl_lcn_nation.Text = "-"
                End If

            Catch ex As Exception

            End Try
            Try
                lbl_lcn_road.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_soi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_tambol.Text = dr("thmblnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next 'set ข้อ1


        'Dim dt_bsn As New DataTable
        'dt_bsn = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(Request.QueryString("bsn"))
        'For Each dr As DataRow In dt_bsn.Rows
        '    Try
        '        lbl_BSN_ADDR.Text = dr("BSN_ADDR")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_FLOOR.Text = dr("BSN_FLOOR")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_ROOM.Text = dr("BSN_ROOM")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_AGE.Text = dr("AGE")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_AMPHR_NAME.Text = dr("BSN_AMPHR_NAME")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_BUILDING.Text = dr("BSN_BUILDING")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_FAX.Text = dr("BSN_FAX")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_IDENTIFY.Text = dr("BSN_IDENTIFY")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_MOO.Text = dr("BSN_MOO")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_ROAD.Text = dr("BSN_ROAD")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_SOI.Text = dr("BSN_SOI")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_TEL.Text = dr("BSN_TEL")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_THAIFULLNAME.Text = dr("BSN_THAIFULLNAME")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_BSN_ZIPCODE.Text = dr("BSN_ZIPCODE")
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        lbl_thachngwtnm.Text = dr("thachngwtnm")
        '    Catch ex As Exception

        '    End Try
        'Next 'set ข้อ2

        Dim dt_lct As New DataTable
        dt_lct = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(Request.QueryString("lct_ida"))
        For Each dr As DataRow In dt_lct.Rows
            Try
                lbl_lct_HOUSENO.Text = dr("HOUSENO")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thanameplace.Text = dr("thanameplace")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thachngwtnm.Text = dr("thachngwtnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_fax.Text = dr("fax")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thaaddr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_floor.Text = dr("thafloor")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thaamphrnm.Text = dr("thaamphrnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thabuilding.Text = dr("thabuilding")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thamu.Text = dr("thamu")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_tharoad.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thasoi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_thathmblnm.Text = dr("thathmblnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lct_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try

        Next 'set ข้อ 3


        If Request.QueryString("ida") IsNot Nothing Then
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            dao_dal.GetDataby_IDA(Request.QueryString("ida"))
            txt_da_opentime.Text = dao_dal.fields.opentime

            Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
            dao_frgn.GetDataby_FK_IDA(Request.QueryString("ida"))
            If dao_frgn.fields.PERSONAL_TYPE_MENU = 1 Then
                rdl_sanchaat.SelectedValue = 1
                TB_Personal.Visible = False
                TB_Personal_Type1.Visible = False
                TB_Personal_Type2.Visible = False
            ElseIf dao_frgn.fields.PERSONAL_TYPE_MENU = 2 Then 'set ต่างด้าว
                rdl_sanchaat.SelectedValue = 2
                If dao_frgn.fields.PASSPORT_NO <> "" Then
                    cb_Personal_Type1.Checked = True
                    TB_Personal_Type2.Visible = False
                    txt_PASSPORT_NO.Text = dao_frgn.fields.PASSPORT_NO
                    RDP_PASSPORT_EXPDATE.SelectedDate = dao_frgn.fields.PASSPORT_EXPDATE
                    txt_DOC_NO.Text = dao_frgn.fields.DOC_NO
                    RDP_DOC_DATE.SelectedDate = dao_frgn.fields.DOC_DATE
                    txt_WORK_LICENSE_NO.Text = dao_frgn.fields.WORK_LICENSE_NO
                    RDP_WORK_LICENSE_EXPDATE.SelectedDate = dao_frgn.fields.WORK_LICENSE_EXPDATE
                    txt_BS_NO.Text = dao_frgn.fields.BS_NO
                    RDP_BS_DATE.SelectedDate = dao_frgn.fields.BS_DATE
                    txt_FRGN_NO.Text = dao_frgn.fields.FRGN_NO
                    RDP_FRGN_DATE.SelectedDate = dao_frgn.fields.FRGN_DATE
                ElseIf dao_frgn.fields.BS_NO1 <> "" Then
                    cb_Personal_Type2.Checked = True
                    TB_Personal_Type1.Visible = False
                    txt_BS_NO1.Text = dao_frgn.fields.BS_NO1
                    RDP_BS_DATE1.SelectedDate = dao_frgn.fields.BS_DATE1
                    RDP_FRGN_DATE1.SelectedDate = dao_frgn.fields.FRGN_DATE1
                End If
            End If
            'If dao_frgn.fields.addr_status = 1 Then 'set ที่อยู่ที่ติดต่อ
            '    Dim dao_curent As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
            '    dao_curent.GetData_By_FK_IDA(Request.QueryString("ida"))
            '    cb_addr.Checked = True
            '    ddl_amphor.SelectedValue = dao_curent.fields.amphrcd
            '    ddl_Province.SelectedValue = dao_curent.fields.chngwtcd
            '    txt_c_email.Text = dao_curent.fields.email
            '    txt_c_fax.Text = dao_curent.fields.fax
            '    '.FK_IDA = 
            '    txt_c_tel.Text = dao_curent.fields.tel
            '    txt_c_thaaddr.Text = dao_curent.fields.thaaddr
            '    txt_c_floor.Text = dao_curent.fields.thafloor
            '    txt_c_thabuilding.Text = dao_curent.fields.thabuilding
            '    txt_c_thamu.Text = dao_curent.fields.thamu
            '    '.thanameplace = ""
            '    txt_c_tharoad.Text = dao_curent.fields.tharoad
            '    txt_c_room.Text = dao_curent.fields.tharoom
            '    txt_c_thasoi.Text = dao_curent.fields.thasoi
            '    ddl_tambol.SelectedValue = dao_curent.fields.thmblcd
            '    txt_c_zipcode.Text = dao_curent.fields.zipcode
            'End If
        End If
    End Sub
    Private Function set_lcntpcd() As String
        Dim dao As New DAO_DRUG.ClsDBPROCESS_NAME
        dao.GetDataby_Process_ID(_ProcessID)
        Return dao.fields.PROCESS_NAME
    End Function
    Sub Set_data_New()
        Dim IDA_LCN As Integer = Request.QueryString("IDA_LCN")
        'dao.GetDataby_IDA(IDA_LCN)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA_APP(IDA_LCN)
        Dim dao_frg As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frg.GetDataby_FK_IDA(IDA_LCN)
        Dim dao_hb As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        dao_hb.GetDataby_LCN_IDA(IDA_LCN)
        Dim dao_lc As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        dao_lc.GetDataby_LCN_IDA(IDA_LCN)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        Dim CITIZEN_ID_AUTHORIZE As String = dao_lc.fields.CITIZEN_AUTHORIZE
        dt_lcn = bao.SP_Lisense_Name_and_Addr(CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

        Dim Process_lcn As Integer = dao.fields.PROCESS_ID
        Dim lc_person_age As Integer = 0
        If Process_lcn = "122" Then
            rdl_lcn_type.SelectedValue = "1"
        ElseIf Process_lcn = "121" Then
            rdl_lcn_type.SelectedValue = "2"
        ElseIf Process_lcn = "120" Then
            rdl_lcn_type.SelectedValue = "3"
        End If
        ''''''''''''''''''''''''''''''   ข้อมูลผู้รับอนุญาต   '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            If dao_frg.fields.PERSONAL_TYPE_MENU = "" Then
                rdl_sanchaat.SelectedValue = 1
            Else
                rdl_sanchaat.SelectedValue = dao_frg.fields.PERSONAL_TYPE_MENU
            End If
        Catch ex As Exception
            rdl_sanchaat.SelectedValue = 1
        End Try
        lbl_lcn_name.Text = dao_lc.fields.licen
        lbl_lcn_iden.Text = CITIZEN_ID_AUTHORIZE
        lbl_lcn_addr.Text = dao_hb.fields.thaaddr
        lbl_lcn_floor.Text = dao_hb.fields.thafloor
        lbl_lcn_room.Text = dao_hb.fields.tharoom
        lbl_lcn_building.Text = dao_hb.fields.thabuilding
        lbl_lcn_mu.Text = dao_hb.fields.thamu
        lbl_lcn_soi.Text = dao_hb.fields.thasoi
        lbl_lcn_road.Text = dao_hb.fields.tharoad
        lbl_lcn_tambol.Text = dao_hb.fields.thathmblnm
        lbl_lcn_amphor.Text = dao_hb.fields.thaamphrnm
        lbl_lcn_changwat.Text = dao_hb.fields.thachngwtnm
        lbl_lcn_zipcode.Text = dao_hb.fields.zipcode
        lbl_lcn_fax.Text = dao_hb.fields.fax
        lbl_lcn_tel.Text = dao_hb.fields.tel
        lbl_lcn_email.Text = dao.fields.Email
        txt_da_opentime.Text = dao.fields.opentime
        For Each dr As DataRow In dt_lcn.Rows
            Try
                lbl_lcn_ages.Text = dr("age")
            Catch ex As Exception
                ' lbl_lcn_ages.Text =  0
            End Try
            Try
                lbl_lcn_nation.Text = dr("nation")
            Catch ex As Exception

            End Try
        Next

        ''''''''''''''''''''''   ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        lbl_lct_thanameplace.Text = dao_hb.fields.thanm
        lbl_lct_thaaddr.Text = dao_hb.fields.thaaddr
        lbl_lct_thabuilding.Text = dao_hb.fields.thabuilding
        lbl_lct_floor.Text = dao_hb.fields.thafloor
        lbl_lct_thamu.Text = dao_hb.fields.thamu
        lbl_lct_thasoi.Text = dao_hb.fields.thasoi
        lbl_lct_tharoad.Text = dao_hb.fields.tharoad
        lbl_lct_thathmblnm.Text = dao_hb.fields.thathmblnm
        lbl_lct_thaamphrnm.Text = dao_hb.fields.thaamphrnm
        lbl_lct_thachngwtnm.Text = dao_hb.fields.thachngwtnm
        lbl_lct_zipcode.Text = dao_hb.fields.zipcode
        lbl_lct_tel.Text = dao_hb.fields.zipcode
        Dim dt_lct As New DataTable
        dt_lct = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
        For Each dr As DataRow In dt_lct.Rows
            Try
                lbl_lct_HOUSENO.Text = dr("HOUSENO")
            Catch ex As Exception

            End Try
        Next
    End Sub
    Sub setdata(ByRef dao As DAO_LCN.TB_DALCN_RENEW_PRE_E_DETAIL, ByVal TR_ID As Integer)
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim IDA_LCN As Integer = Request.QueryString("IDA_LCN")
        'dao.GetDataby_IDA(IDA_LCN)
        Dim dao_frg As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frg.GetDataby_FK_IDA(IDA_LCN)
        With dao.fields
            Try
                txt_da_opentime.Text = .OPENTIME
                If .PROCESS_ID = "122" Then
                    rdl_lcn_type.SelectedValue = "1"
                ElseIf .PROCESS_ID = "121" Then
                    rdl_lcn_type.SelectedValue = "2"
                ElseIf .PROCESS_ID = "120" Then
                    rdl_lcn_type.SelectedValue = "3"
                End If
            Catch ex As Exception

            End Try
            Try
                If dao_frg.fields.PERSONNAL_NATIONALITY = "ไทย" Then
                    rdl_sanchaat.SelectedValue = 1
                Else
                    rdl_sanchaat.SelectedValue = 2
                End If
            Catch ex As Exception

            End Try
            .lcntpcd = set_lcntpcd()
            Try
                .PVNCD = _pvncd
            Catch ex As Exception

            End Try
            Try
                .chngwtcd = _pvncd
            Catch ex As Exception

            End Try
            Try
                .OPENTIME = txt_da_opentime.Text
            Catch ex As Exception

            End Try
            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(_pvncd)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try
            .pvnabbr = chw
        End With
        Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm 'insert ข้อ2
        dao_syslcnsnm.GetDataby_identify(_CLS.CITIZEN_ID_AUTHORIZE)
        dao.fields.thanm = dao_syslcnsnm.fields.thanm
        dao.fields.syslcnsnm_ID = dao_syslcnsnm.fields.ID
        dao.fields.syslcnsnm_identify = dao_syslcnsnm.fields.identify
        dao.fields.syslcnsnm_lcnsid = dao_syslcnsnm.fields.lcnsid
        dao.fields.syslcnsnm_lcnscd = dao_syslcnsnm.fields.lcnscd
        dao.fields.syslcnsnm_prefixcd = dao_syslcnsnm.fields.prefixcd
        dao.fields.syslcnsnm_prefixnm = dao_syslcnsnm.fields.prefixnm
        dao.fields.syslcnsnm_thanm = dao_syslcnsnm.fields.thanm
        dao.fields.syslcnsnm_engnm = dao_syslcnsnm.fields.engnm
        dao.fields.syslcnsnm_lctcd = dao_syslcnsnm.fields.lctcd
        dao.fields.syslcnsnm_thalnm = dao_syslcnsnm.fields.thalnm
        dao.fields.syslcnsnm_englnm = dao_syslcnsnm.fields.englnm
        dao.fields.syslcnsnm_suffixcd = dao_syslcnsnm.fields.suffixcd
        dao.fields.syslcnsnm_lcnsst = dao_syslcnsnm.fields.lcnsst
        dao.fields.syslcnsnm_grplcnscd = dao_syslcnsnm.fields.grplcnscd
        dao.fields.syslcnsnm_bsncd = dao_syslcnsnm.fields.bsncd
        dao.fields.syslcnsnm_lstfcd = dao_syslcnsnm.fields.lstfcd
        dao.fields.syslcnsnm_lmdfdate = dao_syslcnsnm.fields.lmdfdate
        dao.fields.syslcnsnm_lcnsidst = dao_syslcnsnm.fields.lcnsidst
        dao.fields.syslcnsnm_validdate = dao_syslcnsnm.fields.validdate
        dao.fields.syslcnsnm_oldid = dao_syslcnsnm.fields.oldid
        dao.fields.syslcnsnm_type = dao_syslcnsnm.fields.type
        dao.fields.syslcnsnm_update_date = dao_syslcnsnm.fields.update_date
        dao.fields.syslcnsnm_create_date = dao_syslcnsnm.fields.create_date


        Dim dao_location_address As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS 'insert ข้อ3
        dao_location_address.GetDataby_IDA(Request.QueryString("lct_ida"))
        'dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thanameplace
        'dao.fields.LOCATION_ADDRESS_thaaddr = dao_location_address.fields.thaaddr
        'dao.fields.LOCATION_ADDRESS_thasoi = dao_location_address.fields.thasoi
        'dao.fields.LOCATION_ADDRESS_tharoad = dao_location_address.fields.tharoad
        'dao.fields.LOCATION_ADDRESS_thamu = dao_location_address.fields.thamu
        'dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thathmblnm
        'dao.fields.LOCATION_ADDRESS_thaamphrnm = dao_location_address.fields.thaamphrnm
        'dao.fields.LOCATION_ADDRESS_thachngwtnm = dao_location_address.fields.thachngwtnm
        'dao.fields.LOCATION_ADDRESS_tel = dao_location_address.fields.tel
        'dao.fields.LOCATION_ADDRESS_fax = dao_location_address.fields.fax
        dao.fields.LOCATION_ADDRESS_thanameplace = dao_location_address.fields.thanameplace
        dao.fields.LOCATION_ADDRESS_thaaddr = dao_location_address.fields.thaaddr
        dao.fields.LOCATION_ADDRESS_thasoi = dao_location_address.fields.thasoi
        dao.fields.LOCATION_ADDRESS_tharoad = dao_location_address.fields.tharoad
        dao.fields.LOCATION_ADDRESS_thamu = dao_location_address.fields.thamu
        dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thathmblnm
        dao.fields.LOCATION_ADDRESS_thaamphrnm = dao_location_address.fields.thaamphrnm
        dao.fields.LOCATION_ADDRESS_thachngwtnm = dao_location_address.fields.thachngwtnm
        dao.fields.LOCATION_ADDRESS_tel = dao_location_address.fields.tel
        dao.fields.LOCATION_ADDRESS_fax = dao_location_address.fields.fax
        dao.fields.LOCATION_ADDRESS_lcnsid = dao_location_address.fields.lcnsid
        dao.fields.LOCATION_ADDRESS_engaddr = dao_location_address.fields.engaddr
        dao.fields.LOCATION_ADDRESS_tharoom = dao_location_address.fields.tharoom
        dao.fields.LOCATION_ADDRESS_thabuilding = dao_location_address.fields.thabuilding
        dao.fields.LOCATION_ADDRESS_engsoi = dao_location_address.fields.engsoi
        dao.fields.LOCATION_ADDRESS_engroad = dao_location_address.fields.engroad
        dao.fields.LOCATION_ADDRESS_zipcode = dao_location_address.fields.zipcode
        dao.fields.LOCATION_ADDRESS_lstfcd = dao_location_address.fields.lstfcd
        dao.fields.LOCATION_ADDRESS_lmdfdate = dao_location_address.fields.lmdfdate
        dao.fields.LOCATION_ADDRESS_IDA = dao_location_address.fields.IDA
        dao.fields.LOCATION_ADDRESS_FK_IDA = dao_location_address.fields.FK_IDA
        dao.fields.LOCATION_ADDRESS_TR_ID = dao_location_address.fields.TR_ID
        dao.fields.LOCATION_ADDRESS_DOWN_ID = dao_location_address.fields.DOWN_ID
        dao.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_location_address.fields.CITIZEN_ID
        dao.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_location_address.fields.CITIZEN_ID_UPLOAD
        dao.fields.LOCATION_ADDRESS_XMLNAME = dao_location_address.fields.XMLNAME
        dao.fields.LOCATION_ADDRESS_engmu = dao_location_address.fields.engmu
        dao.fields.LOCATION_ADDRESS_engfloor = dao_location_address.fields.engfloor
        dao.fields.LOCATION_ADDRESS_engbuilding = dao_location_address.fields.engbuilding
        dao.fields.LOCATION_ADDRESS_rcvno = dao_location_address.fields.rcvno
        dao.fields.LOCATION_ADDRESS_rcvdate = dao_location_address.fields.rcvdate
        dao.fields.LOCATION_ADDRESS_lctcd = dao_location_address.fields.lctcd
        dao.fields.LOCATION_ADDRESS_engnameplace = dao_location_address.fields.engnameplace
        dao.fields.LOCATION_ADDRESS_STATUS_ID = dao_location_address.fields.STATUS_ID
        dao.fields.LOCATION_ADDRESS_HOUSENO = dao_location_address.fields.HOUSENO
        dao.fields.LOCATION_ADDRESS_Branch = dao_location_address.fields.Branch
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_location_address.fields.LOCATION_TYPE_NORMAL
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_location_address.fields.LOCATION_TYPE_OTHER
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_location_address.fields.LOCATION_TYPE_ID
        dao.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_location_address.fields.SYSTEM_NAME
        dao.fields.LOCATION_ADDRESS_thmblcd = dao_location_address.fields.thmblcd
        dao.fields.LOCATION_ADDRESS_chngwtcd = dao_location_address.fields.chngwtcd
        dao.fields.LOCATION_ADDRESS_engthmblnm = dao_location_address.fields.engthmblnm
        dao.fields.LOCATION_ADDRESS_engamphrnm = dao_location_address.fields.engamphrnm
        dao.fields.LOCATION_ADDRESS_engchngwtnm = dao_location_address.fields.engchngwtnm
        dao.fields.LOCATION_ADDRESS_IDENTIFY = dao_location_address.fields.IDENTIFY
        dao.fields.LOCATION_ADDRESS_REMARK = dao_location_address.fields.REMARK

    End Sub
    Sub setdata_frgn_data(ByRef dao As DAO_DRUG.TB_DALCN_FRGN_DATA) 'set บุคคลต่างด้าว
        With dao.fields
            Try
                .BS_DATE = CDate(RDP_BS_DATE.SelectedDate)
            Catch ex As Exception

            End Try
            Try
                .BS_DATE1 = CDate(RDP_BS_DATE1.SelectedDate)
            Catch ex As Exception

            End Try
            Try
                .BS_NO = txt_BS_NO.Text
            Catch ex As Exception

            End Try
            Try
                .BS_NO1 = txt_BS_NO1.Text
            Catch ex As Exception

            End Try
            Try
                If rdl_sanchaat.SelectedValue = 1 Then
                    .PERSONNAL_NATIONALITY = "ไทย"
                Else
                    .PERSONNAL_NATIONALITY = txt_nationality.Text
                End If
            Catch ex As Exception

            End Try
            Try
                .DOC_DATE = CDate(RDP_DOC_DATE.SelectedDate)
            Catch ex As Exception

            End Try
            .DOC_NO = txt_DOC_NO.Text
            Try
                .FRGN_DATE = CDate(RDP_FRGN_DATE.SelectedDate)
            Catch ex As Exception

            End Try
            .FRGN_NO = txt_FRGN_NO.Text
            Try
                .FRGN_DATE1 = RDP_FRGN_DATE1.SelectedDate
            Catch ex As Exception

            End Try

            Try
                .PASSPORT_EXPDATE = CDate(RDP_PASSPORT_EXPDATE.SelectedDate)
            Catch ex As Exception

            End Try
            .PASSPORT_NO = txt_PASSPORT_NO.Text
            Try
                If cb_Personal_Type1.Checked = True Then
                    .PERSONAL_TYPE = 1
                ElseIf cb_Personal_Type2.Checked = True Then
                    .PERSONAL_TYPE = 2
                End If
            Catch ex As Exception

            End Try
            Try
                If rdl_sanchaat.SelectedValue = 1 Then
                    .PERSONAL_TYPE_MENU = 1
                ElseIf rdl_sanchaat.SelectedValue = 2 Then
                    .PERSONAL_TYPE_MENU = 2
                End If
            Catch ex As Exception

            End Try
            Try
                .WORK_LICENSE_EXPDATE = CDate(RDP_WORK_LICENSE_EXPDATE.SelectedDate)
            Catch ex As Exception

            End Try
            .WORK_LICENSE_NO = txt_WORK_LICENSE_NO.Text
            Try
                .PASSPORT_EXPDATE = CDate(RDP_PASSPORT_EXPDATE.SelectedDate)
            Catch ex As Exception
            End Try
            'Try
            '    If cb_addr.Checked = True Then
            '        .addr_status = 1
            '    Else
            '        .addr_status = 0
            '    End If
            'Catch ex As Exception

            'End Try

            'cb_addr_CheckedChanged(1)
        End With
    End Sub

    Sub insert_bsn(ByVal FK_IDA As String)
        Dim bao_show11 As New BAO_SHOW
        Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(Request.QueryString("bsn"))
        For Each dr As DataRow In dt_bsn.Rows
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN 'insert ข้อสอง
            Try
                dao_bsn.fields.BSN_THAIFULLNAME = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_IDENTIFY = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ADDR = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_SOI = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ROAD = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_MOO = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THMBL_NAME = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_AMPHR_NAME = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_CHWNGNAME = dr("BSN_CHWNGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_TELEPHONE = dr("BSN_TELEPHONE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_FAX = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THAINAME = dr("BSN_THAINAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THAILASTNAME = dr("BSN_THAILASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_PREFIXENGCD = dr("BSN_PREFIXENGCD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGNAME = dr("BSN_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGLASTNAME = dr("BSN_ENGLASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGFULLNAME = dr("BSN_ENGFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CHANGWAT_ID = dr("CHANGWAT_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.AMPHR_ID = dr("AMPHR_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.TUMBON_ID = dr("TUMBON_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_FLOOR = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_BUILDING = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ZIPCODE = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CREATE_DATE = dr("CREATE_DATE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.DOWN_ID = dr("DOWN_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CITIZEN_ID = dr("CITIZEN_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.XMLNAME = dr("XMLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.NATIONALITY = dr("NATIONALITY")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_HOUSENO = dr("BSN_HOUSENO")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGADDR = dr("BSN_ENGADDR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGMU = dr("BSN_ENGMU")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGSOI = dr("BSN_ENGSOI")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGROAD = dr("BSN_ENGROAD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_CHWNG_ENGNAME = dr("BSN_CHWNG_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_AMPHR_ENGNAME = dr("BSN_AMPHR_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THMBL_ENGNAME = dr("BSN_THMBL_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_NATIONALITY_CD = dr("BSN_NATIONALITY_CD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.AGE = dr("AGE")
            Catch ex As Exception

            End Try
            dao_bsn.fields.LCN_IDA = FK_IDA
            dao_bsn.fields.FK_IDA = FK_IDA
            dao_bsn.insert()
        Next

    End Sub
    'Sub set_date_current_addr(ByRef dao As DAO_DRUG.TB_DALCN_CURRENT_ADDRESS) 'insert ที่อยู่ติดต่อได้

    '    With dao.fields
    '        Try
    '            .chngwtcd = ddl_Province.SelectedValue
    '            .amphrcd = ddl_amphor.SelectedValue
    '            .thmblcd = ddl_tambol.SelectedValue
    '        Catch ex As Exception

    '        End Try

    '        .email = txt_c_email.Text
    '        .fax = txt_c_fax.Text
    '        '.FK_IDA = 
    '        .tel = txt_c_tel.Text
    '        .thaaddr = txt_c_thaaddr.Text
    '        .thafloor = txt_c_floor.Text
    '        .thabuilding = txt_c_thabuilding.Text
    '        .thamu = txt_c_thamu.Text
    '        .thanameplace = ""
    '        .tharoad = txt_c_tharoad.Text
    '        .tharoom = txt_c_room.Text
    '        .thasoi = txt_c_thasoi.Text

    '        .zipcode = txt_c_zipcode.Text

    '    End With
    'End Sub
    'Public Sub load_ddl_chwt()
    '    Dim bao As New BAO_SHOW
    '    Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()
    '    ddl_Province.DataSource = dt

    '    ddl_Province.DataBind()
    'End Sub
    'Public Sub load_ddl_amp()

    '    Dim bao As New BAO_SHOW
    '    Dim dt As New DataTable
    '    dt = bao.SP_SYSAMPHR_BY_CHNGWTCD(ddl_Province.SelectedValue)

    '    ddl_amphor.DataSource = dt
    '    ddl_amphor.DataBind()
    'End Sub
    'Public Sub load_ddl_thambol()
    '    Dim bao As New BAO_SHOW
    '    Dim dt As New DataTable
    '    dt = bao.SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(ddl_Province.SelectedValue, ddl_amphor.SelectedValue)
    '    ddl_tambol.DataSource = dt
    '    ddl_tambol.DataBind()
    'End Sub

    'Private Sub ddl_Province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Province.SelectedIndexChanged
    '    load_ddl_amp()
    '    load_ddl_thambol()
    'End Sub

    'Private Sub ddl_amphor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphor.SelectedIndexChanged
    '    load_ddl_thambol()
    'End Sub

    'Protected Sub cb_addr_CheckedChanged(sender As Object, e As EventArgs) Handles cb_addr.CheckedChanged

    '    If cb_addr.Checked = True Then
    '        txt_c_thaaddr.Text = lbl_BSN_ADDR.Text
    '        txt_c_floor.Text = lbl_BSN_FLOOR.Text
    '        txt_c_room.Text = lbl_BSN_ROOM.Text
    '        txt_c_thabuilding.Text = lbl_BSN_BUILDING.Text
    '        txt_c_thamu.Text = lbl_BSN_MOO.Text
    '        txt_c_thasoi.Text = lbl_BSN_SOI.Text
    '        txt_c_tharoad.Text = lbl_BSN_ROAD.Text
    '        load_ddl_chwt()
    '        Try
    '            ddl_Province.Items.FindByText(lbl_thachngwtnm.Text).Selected = True
    '        Catch ex As Exception
    '        End Try
    '        'ddl_Province.SelectedItem.Text = lbl_thachngwtnm.Text
    '        Try
    '            load_ddl_amp()
    '            ddl_amphor.Items.FindByText(lbl_BSN_AMPHR_NAME.Text).Selected = True
    '        Catch ex As Exception
    '            ddl_amphor.DropDownInsertDataFirstRow("-", "")
    '            ddl_amphor.Items.FindByText("-").Selected = True
    '        End Try

    '        'ddl_amphor.SelectedItem.Text = lbl_BSN_AMPHR_NAME.Text
    '        Try
    '            load_ddl_thambol()
    '            ddl_tambol.Items.FindByText(lbl_BSN_THMBL_NAME.Text).Selected = True
    '        Catch ex As Exception
    '            ddl_tambol.DropDownInsertDataFirstRow("-", "")
    '            ddl_tambol.Items.FindByText("-").Selected = True

    '        End Try
    '        txt_c_zipcode.Text = lbl_BSN_ZIPCODE.Text
    '        txt_c_fax.Text = lbl_BSN_FAX.Text
    '        txt_c_tel.Text = lbl_BSN_TEL.Text
    '        txt_c_email.Text = Label33.Text
    '    Else
    '        txt_c_thaaddr.Text = Nothing
    '        txt_c_thabuilding.Text = Nothing
    '        txt_c_thamu.Text = Nothing
    '        txt_c_thasoi.Text = Nothing
    '        txt_c_tharoad.Text = Nothing
    '        load_ddl_chwt()
    '        load_ddl_amp()
    '        load_ddl_thambol()
    '        'ddl_tambol.SelectedItem.Text = "-"
    '        'ddl_tambol.SelectedItem.Text = Nothing
    '        txt_c_zipcode.Text = Nothing
    '        txt_c_fax.Text = Nothing
    '        txt_c_tel.Text = Nothing
    '        txt_c_email.Text = Nothing

    '    End If

    'End Sub

    Protected Sub rdl_sanchaat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_sanchaat.SelectedIndexChanged
        If rdl_sanchaat.SelectedValue = 2 Then
            TB_Personal.Visible = True
            TB_Personal_Type1.Visible = True
            TB_Personal_Type2.Visible = True
        Else
            TB_Personal.Visible = False
            TB_Personal_Type1.Visible = False
            TB_Personal_Type2.Visible = False
        End If
    End Sub

    Protected Sub cb_Personal_Type1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Personal_Type1.CheckedChanged
        If cb_Personal_Type1.Checked = True Then
            TB_Personal_Type2.Visible = False
        Else
            TB_Personal_Type2.Visible = True

        End If
    End Sub

    Protected Sub cb_Personal_Type2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Personal_Type2.CheckedChanged
        If cb_Personal_Type2.Checked = True Then
            TB_Personal_Type1.Visible = False
        Else
            TB_Personal_Type1.Visible = True

        End If
    End Sub
    Function check_infor() As Boolean
        If rdl_sanchaat.SelectedValue = "" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกสัญชาติ');</script> ")
            Return False
        ElseIf txt_da_opentime.Text = "" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูลเวลาทำการของร้าน');</script> ")
            Return False
        ElseIf rdl_sanchaat.SelectedValue = "2" Then
            If cb_Personal_Type1.Checked Then
                If txt_PASSPORT_NO.Text = "" Or txt_BS_NO.Text = "" Or txt_FRGN_NO.Text = "" Or txt_DOC_NO.Text = "" Or txt_WORK_LICENSE_NO.Text = "" Or RDP_PASSPORT_EXPDATE.IsEmpty Or RDP_DOC_DATE.IsEmpty Or RDP_WORK_LICENSE_EXPDATE.IsEmpty Or RDP_BS_DATE.IsEmpty Or RDP_FRGN_DATE.IsEmpty Then
                    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูลบุคคลให้ครบ');</script> ")
                    Return False
                End If
            ElseIf cb_Personal_Type2.Checked Then
                If txt_BS_NO1.Text = "" Or txt_FRGN_NO1.Text = "" Or RDP_BS_DATE1.IsEmpty Or RDP_FRGN_DATE1.IsEmpty Then
                    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูลบุคคลให้ครบ');</script> ")
                    Return False
                End If
            End If
            'ElseIf txt_c_zipcode.Text = "" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกรหัสไปรษณีย์');</script> ")
            '    Return False

            'ElseIf txt_c_thaaddr.Text = "" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูลเลขที่');</script> ")
            '    Return False

            'ElseIf ddl_Province.SelectedValue = "0" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกจังหวัด');</script> ")
            '    Return False

            'ElseIf txt_c_tel.Text = "" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูลเบอร์มือถือ');</script> ")
            '    Return False

            '    'ElseIf txt_c_email.Text = "" Then
            '    '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาระบุข้อมูล e-mail');</script> ")
            '    '    Return False

            'ElseIf ddl_amphor.SelectedValue = "0" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกอำเภอ');</script> ")
            '    Return False

            'ElseIf ddl_tambol.SelectedValue = "0" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกตำบล');</script> ")
            '    Return False
        End If
        Return True
    End Function
    Sub Chek_information()
        If cb_Personal_Type1.Checked Then
            Label63.Style.Add("display", "none")
            If txt_PASSPORT_NO.Text = "" Or txt_BS_NO.Text = "" Or txt_FRGN_NO.Text = "" Or txt_DOC_NO.Text = "" Or txt_WORK_LICENSE_NO.Text = "" Or RDP_PASSPORT_EXPDATE.IsEmpty Or RDP_DOC_DATE.IsEmpty Or RDP_WORK_LICENSE_EXPDATE.IsEmpty Or RDP_BS_DATE.IsEmpty Or RDP_FRGN_DATE.IsEmpty Then
                Label62.Style.Add("display", "initial")
            Else Label62.Style.Add("display", "none")
            End If
        ElseIf cb_Personal_Type2.Checked Then
            Label62.Style.Add("display", "none")
            If txt_BS_NO1.Text = "" Or txt_FRGN_NO1.Text = "" Or RDP_BS_DATE1.IsEmpty Or RDP_FRGN_DATE1.IsEmpty Then
                Label63.Style.Add("display", "initial")
            Else Label63.Style.Add("display", "none")
            End If
        End If
        If rdl_sanchaat.SelectedValue = "" Then
            Label60.Style.Add("display", "initial")
        Else Label60.Style.Add("display", "none")
        End If
        'If txt_c_zipcode.Text = "" Then
        '    lbl_zipcheck.Style.Add("display", "initial")
        'Else lbl_zipcheck.Style.Add("display", "none")
        'End If
        If txt_da_opentime.Text = "" Then
            Label61.Style.Add("display", "initial")
        Else Label61.Style.Add("display", "none")
        End If
        'If txt_c_thaaddr.Text = "" Then
        '    Label64.Style.Add("display", "initial")
        'Else Label64.Style.Add("display", "none")
        'End If

        'If ddl_Province.SelectedValue = "0" Then
        '    Label65.Style.Add("display", "initial")
        'Else Label65.Style.Add("display", "none")

        'End If
        'If txt_c_email.Text = "" Then
        '    lbl_chk_email.Style.Add("display", "initial")
        'Else
        '    lbl_chk_email.Style.Add("display", "none")
        'End If
        'If txt_c_tel.Text = "" Then
        '    lbl_chk_tel.Style.Add("display", "initial")
        'Else
        '    lbl_chk_tel.Style.Add("display", "none")
        'End If

    End Sub

    'Protected Sub btn_save_bsn_Click(sender As Object, e As EventArgs) Handles btn_save_bsn.Click
    '    Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
    '    If ddl_Province.Text = "0" Then
    '        Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกคำนำหน้า');</script> ")
    '    ElseIf ddl_amphor.SelectedValue = "0" Then
    '        Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาระบุคุณวุฒิ');</script> ")
    '    ElseIf ddl_tambol.Text = "" Then
    '        Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกเวลาทำการ');</script> ")
    '    Else
    '        set_data(dao)
    '        dao.fields.FK_IDA = Request.QueryString("ida")
    '        dao.insert()

    '        Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
    '        rg_bsn.Rebind()
    '    End If
    'End Sub

    'Shared DALCN_BSN As New DALCN_LOCATION_BSN
    'Shared list_bsn As New List(Of DALCN_LOCATION_BSN)
    'Public Function GET_DATA_LIST_DALCN() As Object
    '    Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
    '    dao.GetDataby_IDA(Convert.ToInt32(Request.QueryString("IDA")))
    '    Return dao.Details
    'End Function
    'Private Sub rg_bsn_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_bsn.NeedDataSource
    '    Dim bao As New BAO_MASTER
    '    Dim dt As New DataTable
    '    If Request.QueryString("ida") <> "" Then
    '        dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(Request.QueryString("ida"))
    '    End If

    '    If dt.Rows.Count > 0 Then
    '        rg_bsn.DataSource = dt
    '    End If
    'End Sub
    'Private Sub rg_bsn_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_bsn.ItemCommand
    '    If TypeOf e.Item Is GridDataItem Then
    '        Dim item As GridDataItem = e.Item
    '        Dim _ida As String = item("IDA").Text
    '        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
    '        If e.CommandName = "r_del" Then
    '            dao.GetDataby_IDA(_ida)
    '            dao.delete()
    '            rg_bsn.Rebind()
    '        End If
    '    End If
    'End Sub
End Class
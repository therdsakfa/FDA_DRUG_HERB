Public Class POPUP_LCN_TRANSFER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _pvncd As Integer
    Private _ProcessID As Integer
    Private _lcn_ida As Integer
    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _lcn_ida = Request.QueryString("lcn_ida")
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
        If Not IsPostBack Then
            bind_ddl_prefix()
            bind_ddl_prefixbsn()
            get_pvncd()
            Set_Label(_CLS.CITIZEN_ID_AUTHORIZE)
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
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub
    Public Sub bind_ddl_prefixbsn()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_prefix_bsn.DataSource = dt
        ddl_prefix_bsn.DataBind()
    End Sub
    Protected Sub btn_search_lcn_Click(sender As Object, e As EventArgs) Handles btn_search_lcn.Click
        Dim dao_lcn As New DAO_CPN.clsDBsyslcnsnm
        dao_lcn.GetDataby_identify(txt_ctzid_lcn.Text)

        Dim dao_lcnsid As New DAO_CPN.tb_lcnsid
        dao_lcnsid.GetData_ByIdentify(txt_ctzid_lcn.Text)
        Dim name As String = "0"
        Try
            name = dao_lcn.fields.ID
        Catch ex As Exception

        End Try
        If name = "0" Then
            Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script>")
        Else
            Try
                txt_transfer_to.Text = dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
            Catch ex As Exception

            End Try
            Try
                ddl_prefix.SelectedValue = dao_lcn.fields.prefixcd
            Catch ex As Exception

            End Try
            Try
                hf_lcn.Value = dao_lcnsid.fields.lcnsid
            Catch ex As Exception

            End Try
        End If

    End Sub
    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
        dao.fields.SUSTAIN_TYPE = "2"
        'For i As Integer = 0 To rdl_change.Items.Count - 1
        '    If rdl_change.Items(i).Selected = True Then
        '        If rdl_change.Items(i).Value = "1" Then
        Dim dao_bsnOld As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsnOld.Getdata_by_iden(txt_ctzid.Text)
        dao.fields.CHK_SUSTAIN1 = True
        dao.fields.lcnsid_old = dao2.fields.lcnsid
        dao.fields.lcnsid_new = hf_lcn.Value

        Dim dao_lcn As New DAO_CPN.clsDBsyslcnsnm
        dao_lcn.GetDataby_lcnsid(dao2.fields.lcnsid)

        Dim dao_pre As New DAO_CPN.TB_sysprefix

        Dim prefix1 As String = ""
        Dim prefix2 As String = ""
        Try
            dao_pre.Getdata_byid(dao_lcn.fields.prefixcd)
            prefix1 = dao_pre.fields.thanm
        Catch ex As Exception

        End Try

        Try
            dao.fields.BSN_THAIFULLNAME_OLD = prefix1 & dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
            'dao.fields.BSN_THAIFULLNAME_OLD = prefix1 & dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
        Catch ex As Exception

        End Try

        dao_lcn = New DAO_CPN.clsDBsyslcnsnm
        dao_lcn.GetDataby_lcnsid(hf_lcn.Value)

        dao_pre = New DAO_CPN.TB_sysprefix
        Try
            dao_pre.Getdata_byid(dao_lcn.fields.prefixcd)
            prefix2 = dao_pre.fields.thanm
        Catch ex As Exception

        End Try

        Try
            'dao.fields.BSN_THAIFULLNAME = prefix2 & dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
            dao.fields.BSN_THAIFULLNAME = dao_bsnOld.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try

        'ElseIf rdl_change.Items(i).Value = "2" Then
        '    dao.fields.CHK_SUSTAIN2 = True
        '    dao.fields.LCT_IDA_OLD = dao2.fields.FK_IDA
        '    Try
        '        dao.fields.LCT_IDA_NEW = hf_place.Value
        '    Catch ex As Exception

        '    End Try


        '    dao.fields.ADDR_OLD = lbl_location_old.Text
        '    dao.fields.ADDR_NEW = lbl_location_new.Text
        '    dao.fields.thanameplace_OLD = lbl_thanameplace_old.Text
        '    dao.fields.thanameplace = ddl_placename.SelectedItem.Text
        'ElseIf rdl_change.Items(i).Value = "3" Then
        'Try
        '    dao.fields.PASS_AWAY_DATE = CDate(txt_PASS_AWAY_DATE.Text)
        'Catch ex As Exception

        'End Try

        dao.fields.CHK_SUSTAIN3 = True
        ' dao.fields.BSN_IDENTIFY_OLD = dao2.fields.BSN_IDENTIFY
        dao.fields.BSN_IDENTIFY_OLD = dao_bsnOld.fields.BSN_IDENTIFY
        '  dao.fields.BSN_PREFIXTHAICD_OLD = dao2.fields.BSN_PREFIXTHAICD
        dao.fields.BSN_PREFIXTHAICD_OLD = dao_bsnOld.fields.BSN_PREFIXTHAICD
        ' dao.fields.BSN_THAINAME_OLD = dao2.fields.BSN_THAINAME
        dao.fields.BSN_THAINAME_OLD = dao_bsnOld.fields.BSN_THAINAME
        '  dao.fields.BSN_THAILASTNAME_OLD = dao2.fields.BSN_THAILASTNAME
        dao.fields.BSN_THAILASTNAME_OLD = dao_bsnOld.fields.BSN_THAILASTNAME
        '    dao.fields.BSN_ENGNAME_OLD = dao2.fields.BSN_ENGNAME
        dao.fields.BSN_ENGNAME_OLD = dao_bsnOld.fields.BSN_ENGNAME
        '   dao.fields.BSN_ENGLASTNAME_OLD = dao2.fields.BSN_ENGLASTNAME
        dao.fields.BSN_ENGLASTNAME_OLD = dao_bsnOld.fields.BSN_ENGLASTNAME
        '   dao.fields.BSN_ENGFULLNAME_OLD = dao2.fields.BSN_ENGFULLNAME
        dao.fields.BSN_ENGFULLNAME_OLD = dao_bsnOld.fields.BSN_ENGFULLNAME
        '   dao.fields.BSN_THAIFULLNAME_OLD = dao2.fields.BSN_THAIFULLNAME
        dao.fields.BSN_THAIFULLNAME_OLD = dao_bsnOld.fields.BSN_THAIFULLNAME
        '   dao.fields.BSN_HOUSENO_OLD = dao2.fields.BSN_HOUSENO
        dao.fields.BSN_HOUSENO_OLD = dao_bsnOld.fields.BSN_HOUSENO
        '   dao.fields.BSN_ADDR_OLD = dao2.fields.BSN_ENGADDR
        dao.fields.BSN_ADDR_OLD = dao_bsnOld.fields.BSN_ENGADDR
        '   dao.fields.BSN_MOO_OLD = dao2.fields.BSN_MOO
        dao.fields.BSN_MOO_OLD = dao_bsnOld.fields.BSN_MOO
        '    dao.fields.BSN_SOI_OLD = dao2.fields.BSN_SOI
        dao.fields.BSN_SOI_OLD = dao_bsnOld.fields.BSN_SOI
        '    dao.fields.BSN_ROAD_OLD = dao2.fields.BSN_ROAD
        dao.fields.BSN_ROAD_OLD = dao_bsnOld.fields.BSN_ROAD
        '   dao.fields.BSN_CHWNGNAME_OLD = dao2.fields.BSN_CHWNGNAME
        dao.fields.BSN_CHWNGNAME_OLD = dao_bsnOld.fields.BSN_CHWNGNAME
        '   dao.fields.CHANGWAT_ID_OLD = dao2.fields.CHANGWAT_ID
        dao.fields.CHANGWAT_ID_OLD = dao_bsnOld.fields.CHANGWAT_ID
        '     dao.fields.AMPHR_ID_OLD = dao2.fields.AMPHR_ID
        dao.fields.AMPHR_ID_OLD = dao_bsnOld.fields.AMPHR_ID
        '     dao.fields.BSN_AMPHR_NAME_OLD = dao2.fields.BSN_AMPHR_NAME
        dao.fields.BSN_AMPHR_NAME_OLD = dao_bsnOld.fields.BSN_AMPHR_NAME
        '    dao.fields.BSN_THMBL_NAME_OLD = dao2.fields.BSN_THMBL_NAME
        dao.fields.BSN_THMBL_NAME_OLD = dao_bsnOld.fields.BSN_THMBL_NAME
        '    dao.fields.TUMBON_ID_OLD = dao2.fields.TUMBON_ID
        dao.fields.TUMBON_ID_OLD = dao_bsnOld.fields.TUMBON_ID
        '    dao.fields.BSN_TELEPHONE_OLD = dao2.fields.BSN_TELEPHONE
        dao.fields.BSN_TELEPHONE_OLD = dao_bsnOld.fields.BSN_TELEPHONE
        '    dao.fields.BSN_FAX_OLD = dao2.fields.BSN_FAX
        dao.fields.BSN_FAX_OLD = dao_bsnOld.fields.BSN_FAX
        'dao.fields.BSN_THAILASTNAME = lbl_new_bsn.Text
        ''eng
        dao.fields.BSN_ENGADDR_OLD = dao2.fields.BSN_ENGADDR
        dao.fields.BSN_FLOOR_OLD = dao2.fields.BSN_ENGADDR
        dao.fields.BSN_ENGMU_OLD = dao2.fields.BSN_ENGMU
        dao.fields.BSN_ENGSOI_OLD = dao2.fields.BSN_ENGSOI
        dao.fields.BSN_ENGROAD_OLD = dao2.fields.BSN_ENGROAD
        dao.fields.BSN_CHWNG_ENGNAME_OLD = dao2.fields.BSN_CHWNG_ENGNAME
        dao.fields.BSN_AMPHR_ENGNAME_OLD = dao2.fields.BSN_AMPHR_ENGNAME
        dao.fields.BSN_THMBL_ENGNAME_OLD = dao2.fields.BSN_THMBL_ENGNAME


        Dim dao_bsn As New DAO_CPN.TB_LOCATION_BSN
        dao_bsn.Getdata_by_iden(txt_ctzid.Text)
        For Each dao_bsn.fields In dao_bsn.datas
            'dao.fields.BSN_IDENTIFY = txt_ctzid.Text
            'dao.fields.BSN_PREFIXTHAICD = dao_bsn.fields.BSN_PREFIXTHAICD
            'dao.fields.BSN_THAINAME = dao_bsn.fields.BSN_THAINAME
            'dao.fields.BSN_THAILASTNAME = dao_bsn.fields.BSN_THAILASTNAME
            'dao.fields.BSN_ENGNAME = dao_bsn.fields.BSN_ENGNAME
            'dao.fields.BSN_ENGLASTNAME = dao_bsn.fields.BSN_ENGLASTNAME
            'dao.fields.BSN_ENGFULLNAME = dao_bsn.fields.BSN_ENGFULLNAME
            'dao.fields.BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
            Dim CITIZEN_ID_AUTHORIZE As String = ""
            Try
                CITIZEN_ID_AUTHORIZE = txt_ctzid.Text
            Catch ex As Exception

            End Try

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
            Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

            Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
            dao_syslcnsnm.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
            'tha
            dao.fields.BSN_IDENTIFY = CITIZEN_ID_AUTHORIZE
            Try
                dao.fields.BSN_PREFIXTHAICD = dao_syslcnsnm.fields.prefixcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THAINAME = dao_syslcnsnm.fields.thanm
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THAILASTNAME = dao_syslcnsnm.fields.thalnm
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGNAME = dao_syslcnsnm.fields.engnm
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGLASTNAME = dao_syslcnsnm.fields.englnm
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGFULLNAME = dao_syslcnsnm.fields.engnm & " " & dao_syslcnsnm.fields.englnm
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THAIFULLNAME = dao_syslcnsnm.fields.thanm & " " & dao_syslcnsnm.fields.thalnm
            Catch ex As Exception

            End Try


            dao.fields.BSN_HOUSENO = dao_bsn.fields.BSN_HOUSENO
            dao.fields.BSN_ADDR = dao_bsn.fields.BSN_ENGADDR
            dao.fields.BSN_MOO = dao_bsn.fields.BSN_MOO
            dao.fields.BSN_SOI = dao_bsn.fields.BSN_SOI
            dao.fields.BSN_ROAD = dao_bsn.fields.BSN_ROAD
            dao.fields.BSN_CHWNGNAME = dao_bsn.fields.BSN_CHWNGNAME
            dao.fields.CHANGWAT_ID = dao_bsn.fields.CHANGWAT_ID
            dao.fields.AMPHR_ID = dao_bsn.fields.AMPHR_ID
            dao.fields.BSN_AMPHR_NAME = dao_bsn.fields.BSN_AMPHR_NAME
            dao.fields.BSN_THMBL_NAME = dao_bsn.fields.BSN_THMBL_NAME
            dao.fields.TUMBON_ID = dao_bsn.fields.TUMBON_ID
            dao.fields.BSN_TELEPHONE = dao_bsn.fields.BSN_TELEPHONE
            dao.fields.BSN_FAX = dao_bsn.fields.BSN_FAX

            ''eng
            dao.fields.BSN_ENGADDR = dao_bsn.fields.BSN_ENGADDR
            dao.fields.BSN_FLOOR = dao_bsn.fields.BSN_FLOOR
            dao.fields.BSN_ENGMU = dao_bsn.fields.BSN_ENGMU
            dao.fields.BSN_ENGSOI = dao_bsn.fields.BSN_ENGSOI
            dao.fields.BSN_ENGROAD = dao_bsn.fields.BSN_ENGROAD
            dao.fields.BSN_CHWNG_ENGNAME = dao_bsn.fields.BSN_CHWNG_ENGNAME
            dao.fields.BSN_AMPHR_ENGNAME = dao_bsn.fields.BSN_AMPHR_ENGNAME
            dao.fields.BSN_THMBL_ENGNAME = dao_bsn.fields.BSN_THMBL_ENGNAME
        Next
        'End If
        '    End If

        'Next

    End Sub
    Sub Set_Label(ByVal CITIZEN_ID_AUTHORIZE As String)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        'dt_lcn = bao.SP_Lisense_Name_and_Addr(CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        dt_lcn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_lcn_ida) 'ผู้ดำเนิน
        Dim dao As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        dao.GetDataby_LCN_IDA(_lcn_ida)
        Dim dao_l As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        dao_l.GetDataby_LCN_IDA(_lcn_ida)

        'For Each dr As DataRow In dt_lcn.Rows
        Try
                'If dr("thaaddr") = "" Then
                '    txt_location_trnf.Text = "-"
                'Else
                '    txt_location_trnf.Text = dr("thaaddr")
                'End If
                If dao.fields.thaaddr = "" Then
                    txt_location_trnf.Text = "-"
                Else
                    txt_location_trnf.Text = dao.fields.thaaddr
                End If

            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_floor.Text = dr("floor")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_lcn_room.Text = dr("room")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_lcn_ages.Text = dr("age")
            'Catch ex As Exception

            'End Try
            Try
                'If dr("amphrnm") = "" Then
                '    txt_trnf_amphor.Text = "-"
                'Else
                '    txt_trnf_amphor.Text = dr("amphrnm")
                'End If
            Catch ex As Exception

            End Try
            Try
                'If dr("building") = "" Then
                '    txt_trnf_building.Text = "-"
                'Else
                '    txt_trnf_building.Text = dr("building")
                'End If
                If dao.fields.thabuilding = "" Then
                    txt_trnf_building.Text = "-"
                Else
                    txt_trnf_building.Text = dao.fields.thabuilding
                End If
            Catch ex As Exception

            End Try
            Try
                'If dr("chngwtnm") = "" Then
                '    txt_trnf_changwat.Text = "-"
                'Else
                '    txt_trnf_changwat.Text = dr("chngwtnm")
                'End If
                If dao.fields.thachngwtnm = "" Then
                    txt_trnf_changwat.Text = "-"
                Else
                    txt_trnf_changwat.Text = dao.fields.thachngwtnm
                End If
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_email.Text = dr("email")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_lcn_fax.Text = dr("fax")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_lcn_iden.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                'If dr("identify") = "" Then
                '    txt_trnf_iden.Text = "-"
                'Else
                '    txt_trnf_iden.Text = dr("identify")
                'End If
                If dao.fields.Identify = "" Then
                    txt_trnf_iden.Text = "-"
                Else
                    txt_trnf_iden.Text = dao.fields.Identify
                End If
            Catch ex As Exception

            End Try
            Try
                'If dr("mu") = "" Then
                '    txt_trnf_mu.Text = ""
                'Else
                '    txt_trnf_mu.Text = dr("mu")
                'End If
                If dao.fields.thamu = "" Then
                    txt_trnf_mu.Text = ""
                Else
                    txt_trnf_mu.Text = dao.fields.thamu
                End If

            Catch ex As Exception

            End Try
            Try
                'If dr("tha_fullname") = "" Then
                '    txt_name.Text = "-"
                'Else
                '    txt_name.Text = dr("tha_fullname")
                'End If
                If dao_l.fields.licen = "" Then
                    txt_name.Text = "-"
                Else
                    txt_name.Text = dao_l.fields.licen
                End If
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_nation.Text = dr("nation")
            'Catch ex As Exception

            'End Try
            Try
                'If dr("tharoad") = "" Then
                '    txt_trnf_road.Text = "-"
                'Else
                '    txt_trnf_road.Text = dr("tharoad")
                'End If
                If dao.fields.tharoad = "" Then
                    txt_trnf_road.Text = "-"
                Else
                    txt_trnf_road.Text = dao.fields.tharoad
                End If
            Catch ex As Exception

            End Try
            Try
                If dao.fields.thasoi = "" Then
                    txt_trnf_soi.Text = "-"
                Else
                    txt_trnf_soi.Text = dao.fields.thasoi
                End If
            Catch ex As Exception

            End Try
            Try
                'If dr("thmblnm") = "" Then
                '    txt_trnf_tambol.Text = "-"
                'Else
                '    txt_trnf_tambol.Text = dr("thmblnm")
                'End If
                If dao.fields.thathmblnm = "" Then
                    txt_trnf_tambol.Text = "-"
                Else
                    txt_trnf_tambol.Text = dao.fields.thathmblnm
                End If

            Catch ex As Exception

            End Try
            Try
                'If dr("tel") = "" Then
                '    txt_lcn_tel.Text = "-"
                'Else
                '    txt_lcn_tel.Text = dr("tel")
                'End If
                If dao.fields.tel = "" Then
                    txt_lcn_tel.Text = "-"
                Else
                    txt_lcn_tel.Text = dao.fields.tel
                End If
            Catch ex As Exception

            End Try
            Try
                'If dr("zipcode") = "" Then
                '    txt_trnf_zipcode.Text = "-"
                'Else
                '    txt_trnf_zipcode.Text = dr("zipcode")
                'End If
                If dao.fields.zipcode = "" Then
                    txt_trnf_zipcode.Text = "-"
                Else
                    txt_trnf_zipcode.Text = dao.fields.zipcode
                End If
            Catch ex As Exception

            End Try

        'Next

        Dim dt_bsn As New DataTable
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(Request.QueryString("identify"))
        For Each dr As DataRow In dt_bsn.Rows

            'Try
            '    txt_operator_name.Text = dr("BSN_THAIFULLNAME")
            'Catch ex As Exception

            'End Try
        Next

        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao_bsn.GetDataby_LCN_IDA(_lcn_ida)
        Catch ex As Exception

        End Try
        txt_bsn_name.Text = dao_bsn.fields.BSN_THAIFULLNAME

        Dim dt_lcp As New DataTable
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(Request.QueryString("lcn_ida"))

        Dim lcnno As String = ""
        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        dao_dal.GetDataby_IDA(Request.QueryString("lcn_ida"))
        Try
            txt_lcnno.Text = dao_dal.fields.LCNNO_DISPLAY_NEW
        Catch ex As Exception

        End Try
        Try
            txt_time_work.Text = dao_dal.fields.opentime
        Catch ex As Exception

        End Try
        Try
            'txt_name_business.Text = dao_dal.fields.thanm
        Catch ex As Exception

        End Try
        Try
            If Right(Left(dao_dal.fields.lcnno, 3), 1) Then
                lcnno = dao_dal.fields.pvnabbr & " " & CInt(Right(dao_dal.fields.lcnno, 2)) & "/" & Left(dao_dal.fields.lcnno, 2)
            End If
        Catch ex As Exception

        End Try

        'Try
        '    If dao_dal.fields.lcnno IsNot Nothing Then
        '        Dim raw_lcn As String = dao_dal.fields.lcnno
        '        txt_lcnno.Text = lcnno 'CStr(CInt((Right(raw_lcn, 5))) & "/25" & Left(raw_lcn, 2))
        '    End If
        'Catch ex As Exception

        'End Try
        Dim _ProcessID As String = dao_dal.fields.PROCESS_ID
        If _ProcessID = "122" Then
            rdl_lcn_type.SelectedValue = "1"
        ElseIf _ProcessID = "121" Then
            rdl_lcn_type.SelectedValue = "2"
        ElseIf _ProcessID = "120" Then
            rdl_lcn_type.SelectedValue = "3"
        End If

        txt_Write_Date.Text = Date.Now

        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_dal.fields.FK_IDA)
        txt_name_business.Text = dao_addr.fields.thanameplace
    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_ctzid.Text
        Catch ex As Exception

        End Try

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
        If dao_syslcnsid.fields.IDA = 0 Then
            Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
        Else
            Try
                operator_name.Text = ws_taxno.SYSLCNSNMs.prefixnm & " " & ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            Catch ex As Exception

            End Try
            Try
                ddl_prefix_bsn.SelectedValue = ws_taxno.SYSLCNSNMs.prefixcd
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("ida"))
            Dim dao_bsn As New DAO_CPN.TB_LOCATION_BSN
            Try
                'dao_bsn.Getdata_by_fk_id2(dao.fields.FK_IDA)
                Dim bao As New BAO.ClsDBSqlcommand
                Dim dt As New DataTable
                dt = bao.SP_BSN_LOCATION_ADDRESS_BY_IDEN(CITIZEN_ID_AUTHORIZE)

                'For Each dr As DataRow In dt.Rows
                '    lbl_new_addr.Text = dr("fulladdr")
                'Next
            Catch ex As Exception

            End Try

        End If

    End Sub

    Protected Sub Confirm_Click(sender As Object, e As EventArgs) Handles btn_Confirm.Click
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        Dim TR_ID As String = ""
        Dim IDA As Integer = 0
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_lcn_ida)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao_lcn.fields.IDA)
        dao.fields.TRANSFER_NM = txt_name.Text
        dao.fields.TRANSFER_ID = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.than_name_old = txt_name.Text
        dao.fields.BSN_NAME_OLD = txt_bsn_name.Text
        dao.fields.LCNNO_NEW_DISPLAY = txt_lcnno.Text
        dao.fields.BUSINESS_PLACE_NAME = txt_name_business.Text
        dao.fields.PASSPORT_NO = txt_PASSPORT_NO.Text
        dao.fields.PASSPORT_EXPIRE = RDP_PASSPORT_EXPDATE.SelectedDate
        dao.fields.WRITE_AT = Txt_Write_At.Text
        dao.fields.WRITE_DATE = txt_Write_Date.Text
        dao.fields.WORK_PERMIT = txt_DOC_NO.Text
        dao.fields.WORK_PERMIT_EXPIRE = RDP_DOC_NO_EXPDATE.SelectedDate
        dao.fields.TRANSFER_TO = txt_transfer_to.Text
        dao.fields.TRANSFER_TO_ID = txt_ctzid_lcn.Text
        dao.fields.than_name_new = txt_transfer_to.Text
        'dao.fields.BSN_TRANSFER = txt_operator_name.Text
        dao.fields.BSN_NAME_NEW = operator_name.Text
        dao.fields.TRANSFER_DATE = RPD_start_trnf.SelectedDate
        dao.fields.REMARK_TRANSFER = txt_trnf_remark.Text
        dao.fields.EXPIRE_DATE = dao_lcn.fields.expdate
        dao.fields.process_lcn = dao_lcn.fields.PROCESS_ID
        dao.fields.pvncd = dao_lcn.fields.pvncd
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.lcnno = dao_lcn.fields.lcnno
        Try
            dao.fields.EXPIRE_YEAR = dao_lcn.fields.expyear
        Catch ex As Exception

        End Try
        Try
            dao.fields.TRF_PREFIX_CD = ddl_prefix.SelectedValue
            dao.fields.TRF_PREFIX_NM = ddl_prefix.SelectedItem.Text
        Catch ex As Exception

        End Try
        Try
            dao.fields.BSNN_PREFIX_CD = ddl_prefix_bsn.SelectedValue
            dao.fields.BSNN_PREFIX_NM = ddl_prefix_bsn.SelectedItem.Text
        Catch ex As Exception

        End Try
        dao.fields.thaaddr = txt_location_trnf.Text
        dao.fields.thabuilding = txt_trnf_building.Text
        dao.fields.thamu = txt_trnf_mu.Text
        dao.fields.thasoi = txt_trnf_soi.Text
        dao.fields.tharoad = txt_trnf_road.Text
        dao.fields.thathmblnm = txt_trnf_tambol.Text
        dao.fields.thaamphrnm = txt_trnf_amphor.Text
        dao.fields.thachngwtnm = txt_trnf_changwat.Text
        dao.fields.zipcode = txt_trnf_zipcode.Text
        dao.fields.TEL = txt_lcn_tel.Text
        'dao.fields.fax = txt_fax.Text
        dao.fields.OPENTIME = txt_time_work.Text
        dao.fields.STATUS_ID = 1
        dao.fields.ACTIVEFACT = 1
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CREATE_BY = _CLS.THANM
        If Request.QueryString("staff") = 1 Then
            dao.fields.CREATE_ID = 2
            dao.fields.INOFFICE_STAFF_ID = 1
            dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
        Else
            dao.fields.CREATE_ID = 1
        End If
        dao.fields.lcnsid = dao_lcn.fields.lcnsid
        dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
        dao.fields.FK_LCN = dao_lcn.fields.IDA
        dao.fields.FK_LCT = dao_lcn.fields.FK_IDA
        dao.fields.PROCESS_ID = _ProcessID
        dao.fields.YEAR = con_year(Date.Now().Year())
        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection(_ProcessID)
        Catch ex As Exception

        End Try
        dao.fields.TR_ID = TR_ID
        dao.insert()
        IDA = dao.fields.IDA
        Try
            Dim head_id As Integer = 0
            Dim id As Integer = 0
            Dim id2 As Integer = 0
            Dim type_p As String = ""
            Dim type_b As String = ""
            Dim type_l As String = ""
            Dim process As Integer = 0
            Dim dao_attgroup As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
            Dim dao_attgroup2 As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
            TR_ID = TR_ID

            process = _ProcessID
            Dim TYPE_ID As Integer = 1

            dao_attgroup.GetDataby_TYPE_ID_AND_PROCESS(1, process)

            Dim btn As Button = CType(sender, Button)

            For Each dao_attgroup.fields In dao_attgroup.datas
                Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                Dim dao_mas As New DAO_DRUG.TB_MAS_DOCUMENT_NAME_UPLOAD_DALCN
                dao_att.fields.DUCUMENT_NAME = dao_attgroup.fields.DUCUMENT_NAME
                dao_att.fields.TYPE_PERSON = head_id
                dao_att.fields.TYPE_LOCAL = id
                dao_att.fields.TYPE_BSN = id2
                dao_att.fields.TYPE = 1
                dao_att.fields.FK_IDA = IDA
                dao_att.fields.TR_ID = TR_ID
                dao_att.fields.PROCESS_ID = process
                dao_att.fields.TYPE_PERSON_NAME = type_p
                dao_att.fields.TYPE_LOCAL_NAME = type_l
                dao_att.fields.TYPE_BSN_NAME = type_b
                dao_att.insert()

            Next
        Catch ex As Exception

        End Try
        Try
            Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
            set_data_his(dao_h, dao_lcn)
            'UC_BSN_NAME2.set_data_dalcn(dao)


            dao_h.fields.FK_IDA = IDA
            dao_h.fields.EDIT_TYPE = "1"
            dao_h.fields.INSERT_DATE = Date.Now
            dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
            Try
                dao_h.fields.SELECT_EDIT_DATE = Date.Now
            Catch ex As Exception

            End Try
            dao_h.insert()
            'dao_lcn.update()
        Catch ex As Exception

        End Try

        alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", IDA)
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POP_UP_LCN_TRANSFER_UPLOAD_FILE.aspx?IDA=" & ida
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
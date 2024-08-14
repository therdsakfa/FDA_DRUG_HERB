Imports Telerik.Web.UI
Public Class POPUP_STAFF_LOCATION_MOCK_INSERT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _IDA_LCN As Integer
    Private _IDEN As String
    Private _IDA As String
    Private _pvncd As Integer
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")
        _IDA = Request.QueryString("IDA")
        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
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
            bind_mas_cancel()
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
        txt_date_confirm.Text = Date.Now
        'rdl_lcn_type.SelectedValue = 0
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
                    txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                ElseIf TYPE_PERSON = 99 Then
                    txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                Else
                    If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                        txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                    Else
                        txt_name_request.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                    End If
                End If
                Try
                    lbl_lcn_addr.Text = obj.SYSLCTADDRs.thaaddr
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_floor.Text = obj.SYSLCTADDRs.floor
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_room.Text = obj.SYSLCTADDRs.room
                Catch ex As Exception

                End Try
                'Try
                '    lbl_lcn_ages.Text = obj.SYSLCNSIDs.age
                'Catch ex As Exception

                'End Try
                Try
                    lbl_lcn_amphor.Text = obj.SYSLCTADDRs.amphrnm
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_building.Text = obj.SYSLCTADDRs.building
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_changwat.Text = obj.SYSLCTADDRs.chngwtnm
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_email.Text = obj.SYSLCNSIDs.email
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_fax.Text = obj.SYSLCTADDRs.fax
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_iden.Text = obj.SYSLCTADDRs.identify
                Catch ex As Exception

                End Try
                'Try
                '    lbl_lcn_iden2.Text = dr("identify")
                'Catch ex As Exception

                'End Try
                Try
                    lbl_lcn_mu.Text = obj.SYSLCTADDRs.mu
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_name.Text = txt_name_request.Text
                Catch ex As Exception

                End Try
                'Try
                '    lbl_lcn_nation.Text = obj.SYSLCNSIDs.
                'Catch ex As Exception

                'End Try
                Try
                    lbl_lcn_road.Text = obj.SYSLCTADDRs.tharoad
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_soi.Text = obj.SYSLCTADDRs.thasoi
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_tambol.Text = obj.SYSLCTADDRs.thmblnm
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_tel.Text = obj.SYSLCTADDRs.Mobile
                Catch ex As Exception

                End Try
                Try
                    lbl_lcn_zipcode.Text = obj.SYSLCTADDRs.zipcode
                Catch ex As Exception

                End Try
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End Try

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขบัตรประชาชน หรือเลขนิติ');", True)
        End If
    End Sub
    Public Sub bind_mas_cancel()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()
        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        If rdl_lcn_type.SelectedValue = 0 Then
            lbl_lcn_type.Visible = True
            alert_normal("กรูณาตรวจความถูกต้องของข้อมูล")
        ElseIf txt_name_request.Text = "" Then
            lbl_name_request.Visible = True
        Else
            Dim IDA As Integer = 0
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()
            Dim ProcessID As String = ""
            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            If rdl_lcn_type.SelectedValue = 1 Then
                _ProcessID = 19101
            ElseIf rdl_lcn_type.SelectedValue = 2 Then
                _ProcessID = 19102
            End If
            If _ProcessID = 19101 Then
                ProcessID = 122
            ElseIf _ProcessID = 19102 Then
                ProcessID = 121
            End If
            TR_ID = bao_tran.insert_transection(ProcessID)
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            dao_dal.fields.STATUS_ID = 1
            dao_dal.fields.PROCESS_ID = ProcessID
            dao_dal.fields.lcnno = 0
            dao_dal.fields.rcvno = 0
            dao_dal.fields.CREATE_DATE = Date.Now
            dao_dal.fields.frtappdate = Date.Now
            dao_dal.fields.appdate = Date.Now
            dao_dal.fields.STATUS_ID = 8
            'dao_dal.fields.
            dao_dal.fields.PROCESS_ID = ProcessID
            'dao_dal.fields.PROCESS_NEW = _ProcessID
            Try
                dao_dal.fields.lcnsid = _CLS.LCNSID_CUSTOMER
            Catch ex As Exception
                dao_dal.fields.lcnsid = 0
            End Try
            setdata(dao_dal, TR_ID)
            dao_dal.insert()
            _IDA = dao_dal.fields.IDA
            gen_lcnno(ProcessID)
            AddLogStatus(8, _ProcessID, _CLS.CITIZEN_ID, dao_dal.fields.IDA)
            alert("สร้างรายการใบอนุญาตจำลองแล้ว")
        End If
    End Sub
    Sub gen_lcnno(ByVal processID As String)
        Try
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_p.GetDataby_Process_ID(processID)
            Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID
            Dim _type_da As String = ""
            If dao.fields.PROCESS_ID = "120" Then
                _type_da = "3"
            ElseIf dao.fields.PROCESS_ID = "121" Then
                _type_da = "2"
            ElseIf dao.fields.PROCESS_ID = "122" Then
                _type_da = "1"
            End If

            '--------------------------------
            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(dao.fields.pvncd)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try
            Dim bao2 As New BAO.GenNumber
            Dim LCNNO As Integer
            Dim LCNNO_V2 As Integer
            LCNNO = bao2.GEN_LCNNO_NEW(con_year(Date.Now.Year), 99, GROUP_NUMBER, _ProcessID, 0, 0, _IDA, "")

            Dim _year As Integer = con_year(Date.Now.Year)
            If _year < 2500 Then
                _year += 543
            End If
            LCNNO_V2 = con_year(Date.Now.Year).Substring(2, 2) & LCNNO
            dao.fields.lcnno = LCNNO_V2
            dao.fields.LCNNO_DISPLAY_NEW = "HB " & 99 & "-" & _type_da & "-" & con_year(Date.Now.Year).Substring(2, 2) & "-" & LCNNO
            dao.update()
        Catch ex As Exception

        End Try
    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.ClsDBdalcn, ByVal TR_ID As Integer)
        With dao.fields
            .TR_ID = TR_ID
            .FK_IDA = Request.QueryString("lct_ida")
            .CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            .CITIZEN_ID = _CLS.CITIZEN_ID
            If Request.QueryString("staff") <> "" Then
                .OTHER = "1"
            End If
            .lcntpcd = set_lcntpcd()
            Try
                .pvncd = _pvncd
            Catch ex As Exception

            End Try
            Try
                .chngwtcd = _pvncd
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
        dao.fields.Mock_Location = dao_location_address.fields.MOCK_ID

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_normal(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub
    Private Function set_lcntpcd() As String
        Dim ProcessID As String = ""
        If _ProcessID = 19101 Then
            ProcessID = 122
        ElseIf _ProcessID = 19102 Then
            ProcessID = 121
        End If
        Dim dao As New DAO_DRUG.ClsDBPROCESS_NAME
        dao.GetDataby_Process_ID(ProcessID)
        Return dao.fields.PROCESS_NAME
    End Function
    Protected Sub rdl_lcn_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_lcn_type.SelectedIndexChanged
        If rdl_lcn_type.SelectedValue = 1 Then
            _ProcessID = 19101
        ElseIf rdl_lcn_type.SelectedValue = 2 Then
            _ProcessID = 19102
        End If
    End Sub
End Class
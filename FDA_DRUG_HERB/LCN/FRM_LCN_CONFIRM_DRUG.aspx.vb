﻿Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG_HERB.XML_CENTER

Public Class FRM_LCN_CONFIRM_DRUG
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _pvncd As Integer
    Private b64 As String
    Private _iden As String
    Private _lct_ida As String
    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _lct_ida = Request.QueryString("lct_ida")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _iden = Request.QueryString("identify")
            _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        'If Session("b64") IsNot Nothing Then
        '    b64 = Session("b64")
        'End If
        Set_Label(_iden)
        setdata_frgn_data()
        setdata_current_data()
        setdata_DALCN()
        If Not IsPostBack Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            If dao.fields.STATUS_ID >= 8 And dao.fields.STATUS_ID <> 11 Then
                BindData_PDF()
                Panel1.Style.Add("display", "none")
            Else
                Panel1.Style.Add("display", "block")
            End If

            show_btn(_IDA)
            UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv(_TR_ID)
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
            Try
                If Not IsPostBack Then
                    If _ProcessID = "122" Then
                        rdl_lcn_type.SelectedValue = "1"
                    ElseIf _ProcessID = "121" Then
                        rdl_lcn_type.SelectedValue = "2"
                    ElseIf _ProcessID = "120" Then
                        rdl_lcn_type.SelectedValue = "3"
                    End If
                End If
            Catch ex As Exception

            End Try
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
    Sub Set_Label(ByVal CITIZEN_ID_AUTHORIZE As String)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        dt_lcn = bao.SP_Lisense_Name_and_Addr(_iden) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

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
                lbl_lcn_ages.Text = dr("age")
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
                lbl_lcn_nation.Text = dr("nation")
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
        Next



        Dim dt_bsn As New DataTable
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
        For Each dr As DataRow In dt_bsn.Rows

            'Try
            '    lbl_BSN_ADDR.Text = dr("BSN_ADDR")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_FLOOR.Text = dr("BSN_FLOOR")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_ROOM.Text = dr("BSN_ROOM")
            'Catch ex As Exception

            'End Try
            Try
                lbl_BSN_AGE.Text = dr("AGE")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_BSN_AMPHR_NAME.Text = dr("BSN_AMPHR_NAME")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_BUILDING.Text = dr("BSN_BUILDING")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_FAX.Text = dr("BSN_FAX")
            'Catch ex As Exception

            'End Try
            Try
                lbl_BSN_IDENTIFY.Text = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_BSN_MOO.Text = dr("BSN_MOO")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_ROAD.Text = dr("BSN_ROAD")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_SOI.Text = dr("BSN_SOI")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_TEL.Text = dr("BSN_TEL")
            'Catch ex As Exception

            'End Try
            Try
                lbl_BSN_THAIFULLNAME.Text = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_BSN_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_BSN_ZIPCODE.Text = dr("BSN_ZIPCODE")
            'Catch ex As Exception

            'End Try
            'Try
            '    lbl_thachngwtnm.Text = dr("thachngwtnm")
            'Catch ex As Exception

            'End Try
        Next

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
        Next
        Dim dt_lcp As New DataTable
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(_IDA)
        Try
            lbl_PHR_NAME.Text = dao_phr.fields.PHR_NAME
        Catch ex As Exception

        End Try
        Try
            lbl_PHR_prefix.Text = dao_phr.fields.PHR_PREFIX_NAME
        Catch ex As Exception

        End Try
        Try
            lbl_PHR_TEXT_NUM.Text = dao_phr.fields.PHR_TEXT_NUM
        Catch ex As Exception

        End Try
        Try
            lbl_STUDY_LEVEL.Text = dao_phr.fields.STUDY_LEVEL
        Catch ex As Exception

        End Try
        Try
            lbl_PHR_VETERINARY_FIELD.Text = dao_phr.fields.PHR_VETERINARY_FIELD
        Catch ex As Exception

        End Try
        Try
            lbl_PHR_TEXT_WORK_TIME.Text = dao_phr.fields.PHR_TEXT_WORK_TIME
        Catch ex As Exception

        End Try
        Try
            lbl_NAME_SIMINAR.Text = dao_phr.fields.NAME_SIMINAR
        Catch ex As Exception

        End Try
        Try
            lbl_SIMINAR_DATE.Text = dao_phr.fields.SIMINAR_DATE
        Catch ex As Exception

        End Try
        Try
            rdl_mastra.SelectedValue = dao_phr.fields.PHR_LAW_SECTION
        Catch ex As Exception

        End Try



    End Sub
    Sub setdata_DALCN()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Try
            lbl_GIVE_PASSPORT_NO.Text = dao.fields.GIVE_PASSPORT_NO
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_PASSPORT_EXPDATE.Text = dao.fields.GIVE_PASSPORT_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_WORK_LICENSE_NO.Text = dao.fields.GIVE_WORK_LICENSE_NO
        Catch ex As Exception

        End Try
        Try
            lbl_GIVE_WORK_LICENSE_EXPDATE.Text = dao.fields.GIVE_WORK_LICENSE_EXPDATE
        Catch ex As Exception

        End Try
    End Sub
    Sub setdata_current_data()
        Dim dao As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
        dao.GetData_By_FK_IDA(_IDA)

        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_bsn As New DataTable
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA)
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)

        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        If dao_frgn.fields.addr_status Is Nothing Then
            dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            For Each dr As DataRow In dt_bsn.Rows

                Try
                    lbl_c_thaaddr.Text = dr("BSN_ADDR")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_floor.Text = dr("BSN_FLOOR")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_room.Text = dr("BSN_ROOM")
                Catch ex As Exception

                End Try
                Try
                    lbl_amphor.Text = dr("BSN_AMPHR_NAME")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thabuilding.Text = dr("BSN_BUILDING")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_fax.Text = dr("BSN_FAX")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thamu.Text = dr("BSN_MOO")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_tharoad.Text = dr("BSN_ROAD")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thasoi.Text = dr("BSN_SOI")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_tel.Text = dr("BSN_TEL")
                Catch ex As Exception

                End Try
                'Try
                '    lbl_c_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
                'Catch ex As Exception

                'End Try
                Try
                    lbl_tambol.Text = dr("BSN_THMBL_NAME")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_zipcode.Text = dr("BSN_ZIPCODE")
                Catch ex As Exception

                End Try
                Try
                    lbl_Province.Text = dr("BSN_CHWNGNAME")
                Catch ex As Exception

                End Try
            Next


        ElseIf dao_frgn.fields.addr_status IsNot Nothing Then
            dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            For Each dr As DataRow In dt_bsn.Rows

                Try
                    lbl_c_thaaddr.Text = dr("BSN_ADDR")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_floor.Text = dr("BSN_FLOOR")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_room.Text = dr("BSN_ROOM")
                Catch ex As Exception

                End Try
                Try
                    lbl_amphor.Text = dr("BSN_AMPHR_NAME")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thabuilding.Text = dr("BSN_BUILDING")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_fax.Text = dr("BSN_FAX")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thamu.Text = dr("BSN_MOO")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_tharoad.Text = dr("BSN_ROAD")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_thasoi.Text = dr("BSN_SOI")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_tel.Text = dr("BSN_TEL")
                Catch ex As Exception

                End Try
                'Try
                '    lbl_c_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
                'Catch ex As Exception

                'End Try
                Try
                    lbl_tambol.Text = dr("BSN_THMBL_NAME")
                Catch ex As Exception

                End Try
                Try
                    lbl_c_zipcode.Text = dr("BSN_ZIPCODE")
                Catch ex As Exception

                End Try
                Try
                    lbl_Province.Text = dr("BSN_CHWNGNAME")
                Catch ex As Exception

                End Try
            Next
            '    If dao.fields.thmblcd IsNot Nothing Then
            '        Dim dao_thambol As New DAO_CPN.clsDBsysthmbl
            '        dao_thambol.GetData_by_chngwtcd_amphrcd_thmblcd(dao.fields.chngwtcd, dao.fields.amphrcd, dao.fields.thmblcd)
            '        Try
            '            lbl_tambol.Text = dao_thambol.fields.thathmblnm
            '        Catch ex As Exception

            '        End Try
            '    ElseIf dao.fields.thmblcd Is Nothing Then
            '        For Each dr As DataRow In dt_bsn.Rows
            '            Try
            '                lbl_tambol.Text = dr("BSN_THMBL_NAME")
            '            Catch ex As Exception

            '            End Try
            '        Next

            '    End If

            '    If dao.fields.amphrcd IsNot Nothing Then
            '        Dim dao_amper As New DAO_CPN.clsDBsysamphr
            '        dao_amper.GetData_by_chngwtcd_amphrcd(dao.fields.chngwtcd, dao.fields.amphrcd)
            '        Try
            '            lbl_amphor.Text = dao_amper.fields.thaamphrnm

            '        Catch ex As Exception

            '        End Try
            '    ElseIf dao.fields.amphrcd Is Nothing Then
            '        For Each dr As DataRow In dt_bsn.Rows
            '            Try
            '                lbl_amphor.Text = dr("BSN_AMPHR_NAME")
            '            Catch ex As Exception

            '            End Try
            '        Next
            '    End If

            '    If dao.fields.chngwtcd IsNot Nothing Then
            '        Dim dao_province As New DAO_CPN.clsDBsyschngwt
            '        dao_province.GetData_by_chngwtcd(dao.fields.chngwtcd)
            '        Try
            '            lbl_Province.Text = dao_province.fields.thachngwtnm
            '        Catch ex As Exception

            '        End Try
            '    ElseIf dao.fields.chngwtcd Is Nothing Then
            '        For Each dr As DataRow In dt_bsn.Rows
            '            Try
            '                lbl_Province.Text = dr("thachngwtnm")
            '            Catch ex As Exception

            '            End Try
            '        Next
            '    End If
        End If





    End Sub

    'Sub setdata_systhmbl()
    '    Dim dao As New DAO_CPN.clsDBsyschngwt
    '    dao.GetData_by_chngwtcd()

    'End Sub
    Sub setdata_frgn_data()
        Dim dao As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao.GetDataby_FK_IDA(_IDA)
        Try
            lbl_PASSPORT_NO.Text = dao.fields.PASSPORT_NO
        Catch ex As Exception

        End Try
        Try
            lbl_PASSPORT_EXPDATE.Text = dao.fields.PASSPORT_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_DOC_NO.Text = dao.fields.DOC_NO
        Catch ex As Exception

        End Try
        Try
            lbl_DOC_DATE.Text = dao.fields.DOC_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_WORK_LICENSE_NO.Text = dao.fields.WORK_LICENSE_NO
        Catch ex As Exception

        End Try
        Try
            lbl_WORK_LICENSE_EXPDATE.Text = dao.fields.WORK_LICENSE_EXPDATE
        Catch ex As Exception

        End Try
        Try
            lbl_BS_NO1.Text = dao.fields.BS_NO1
        Catch ex As Exception

        End Try
        Try
            lbl_BS_DATE1.Text = dao.fields.BS_DATE1
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_NO1.Text = dao.fields.FRGN_NO1
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_DATE1.Text = dao.fields.FRGN_DATE1
        Catch ex As Exception

        End Try
        Try
            lbl_BS_NO.Text = dao.fields.BS_NO
        Catch ex As Exception


        End Try
        Try
            lbl_BS_DATE.Text = dao.fields.BS_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_DATE.Text = dao.fields.FRGN_DATE
        Catch ex As Exception

        End Try
        Try
            lbl_FRGN_NO.Text = dao.fields.FRGN_NO
        Catch ex As Exception

        End Try
        Try
            cb_Personal_Type1.TabIndex = dao.fields.PERSONAL_TYPE
        Catch ex As Exception

        End Try
        Try
            cb_Personal_Type2.TabIndex = dao.fields.PERSONAL_TYPE
        Catch ex As Exception

        End Try
        Try
            rdl_sanchaat.SelectedValue = dao.fields.PERSONAL_TYPE_MENU
            If rdl_sanchaat.SelectedValue = 1 Then
                TB_Personal_Type1.Visible = False
                TB_Personal_Type2.Visible = False
                TB_Personal.Visible = False
            ElseIf rdl_sanchaat.SelectedValue = 2 Then
                TB_Personal_Type1.Visible = True
                TB_Personal_Type2.Visible = True
            End If

        Catch ex As Exception

        End Try

        Try
            If cb_Personal_Type1.TabIndex = 1 Then
                cb_Personal_Type1.Checked = True
                TB_Personal_Type2.Visible = False
            ElseIf cb_Personal_Type2.TabIndex = 2 Then
                cb_Personal_Type2.Checked = True
                TB_Personal_Type1.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.cnccscd.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
            'ElseIf chk_pha() = True Then 'true คือเภสัชไม่ยืนยัน ,False คือเภสัชยืนยัน
            '    btn_confirm.Enabled = False
            '    btn_cancel.Enabled = False
            '    btn_confirm.CssClass = "btn-danger btn-lg"
            '    btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Private Function chk_pha() As Boolean
        Dim chk As Boolean = True
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_FK_IDA(_IDA)
        For Each row In dao.datas
            If row.PHR_STATUS_UPLOAD = "1" Then
                chk = False
            End If
        Next
        Return chk
    End Function
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dalcn")

        rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1

        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'Dim bao As New BAO.ClsDBSqlcommand
        'dao.GetDataby_IDA(Integer.Parse(_IDA))
        'If Request.QueryString("staff") <> "" Then
        '    dao.fields.STATUS_ID = 11
        'Else
        '    dao.fields.STATUS_ID = 2
        'End If
        'dao.update()

        'If b64 = Nothing Then
        '    b64 = Session("b64")
        'End If
        'Dim years As String = ""
        'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        'Try
        '    years = dao_tr.fields.YEAR

        'Catch ex As Exception

        'End Try
        'Dim tr_id As String = ""
        'tr_id = "DA-" & _ProcessID & "-" & years & "-" & _TR_ID

        'Dim cls_sop As New CLS_SOP
        'cls_sop.BLOCK_SOP(_CLS.CITIZEN_ID, _ProcessID, "2", "ยื่นคำขอ", tr_id, b64)
        'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "USER", _ProcessID, _CLS.PVCODE, 2, "ส่งเรื่องและรอพิจารณา", "SOP-DRUG-10-" & _ProcessID & "-1", "รับคำขอ", "รอเจ้าหน้าที่รับคำขอ", "STAFF", tr_id, SOP_STATUS:="ยื่นคำขอ")

        'AddLogStatus(2, _ProcessID, _CLS.CITIZEN_ID, _IDA)

        'Session("b64") = Nothing
        'alert("ยื่นเรื่องเรียบร้อยแล้ว")
        Response.Redirect("FRM_LCN_CONFIRM_DETAIL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&PROCESS_ID=" & _ProcessID)

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(Integer.Parse(_IDA))
        'dao.fields.STATUS_ID = 78
        'dao.update()
        'AddLogStatus(78, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        Dim Status_ID As String = 78
        Response.Redirect("FRM_LCN_DRUG_HERB_CANCEL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&PROCESS_ID=" & _ProcessID & "&STATUS_ID=" & Status_ID)

    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    End Sub

    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
    End Sub
    Function get_p2(ByVal FileName As String) As CLASS_DALCN
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Function
    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub


    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(_TR_ID)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP

        dao.GetDataby_IDA(_IDA)
        Dim FK_IDA As Integer = 0
        Try
            FK_IDA = dao.fields.FK_IDA
        Catch ex As Exception

        End Try
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim lcnno_format_new As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim CHK_SELL_TYPE As String = ""
        Try
            CHK_SELL_TYPE = dao.fields.CHK_SELL_TYPE
        Catch ex As Exception

        End Try
        Dim lcntpcd_da As String = ""
        Try
            lcntpcd_da = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        Dim lcnsid_da As Integer = 0
        Try
            lcnsid_da = dao.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim pvncd_da As Integer = 0
        Try
            pvncd_da = dao.fields.pvncd
        Catch ex As Exception

        End Try

        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, lcnsid_da, lcntpcd_da, pvncd_da, CHK_SELL_TYPE:=CHK_SELL_TYPE)


        Dim class_xml As New CLASS_DALCN
        ' class_xml = cls_dalcn.gen_xml()
        class_xml.dalcns = dao.fields
        'Try
        '    class_xml.dalcns.opentime = NumEng2Thai(class_xml.dalcns.opentime)
        'Catch ex As Exception

        'End Try
        If _ProcessID = "114" Then
            class_xml.dalcns.CHK_SELL_TYPE = "1"
        ElseIf _ProcessID = "116" Then
            class_xml.dalcns.CHK_SELL_TYPE = "2"
        ElseIf _ProcessID = "117" Then
            class_xml.dalcns.CHK_SELL_TYPE = "3"
        ElseIf _ProcessID = "115" Then
            class_xml.dalcns.CHK_SELL_TYPE = "4"
        ElseIf _ProcessID = "127" Or _ProcessID = "123" Or _ProcessID = "125" Or _ProcessID = "129" Or _ProcessID = "131" Or _ProcessID = "133" Then
            class_xml.dalcns.CHK_SELL_TYPE = "1"
        ElseIf _ProcessID = "128" Or _ProcessID = "124" Or _ProcessID = "126" Or _ProcessID = "130" Or _ProcessID = "132" Or _ProcessID = "134" Then
            class_xml.dalcns.CHK_SELL_TYPE = "2"
        End If
        Try
            class_xml.dalcns.CATEGORY_DRUG = NumEng2Thai(class_xml.dalcns.CATEGORY_DRUG)
        Catch ex As Exception

        End Try

        Try
            class_xml.dalcns.opentime = NumEng2Thai(dao.fields.opentime)
        Catch ex As Exception

        End Try
        Try
            class_xml.dalcns.WRITE_DATE = NumEng2Thai(CDate(dao.fields.WRITE_DATE).ToLongDateString())
        Catch ex As Exception

        End Try
        'p_lcn = class_xml

        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(FK_IDA) 'bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
        'If _ProcessID = 122 Then
        '    class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA2(_IDA)
        'ElseIf _ProcessID = 121 Then
        class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA(_IDA)
            'ElseIf _ProcessID = 123 Then
            '    class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA2(_IDA)
            'End If


            Dim tt As Integer = 0
        If dao.fields.lcntpcd.Contains("ผ") Then
            tt = 1
        Else
            tt = 2
        End If
        If tt = 1 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB(_IDA, tt)
        Else
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB2(_IDA, tt)
        End If



        Dim dt9 As New DataTable

        ' dt9 = class_xml.DT_SHOW.DT9
        For Each drr As DataRow In class_xml.DT_SHOW.DT9.Rows
            Try
                drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
            Catch ex As Exception

            End Try
            Try
                drr("HOUSENO") = NumEng2Thai(drr("HOUSENO"))
            Catch ex As Exception

            End Try
            Try
                drr("tharoom") = NumEng2Thai(drr("tharoom"))
            Catch ex As Exception

            End Try
            Try
                '
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                drr("thanameplace") = NumEng2Thai(drr("thanameplace"))
            Catch ex As Exception

            End Try
            Try
                drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
            Catch ex As Exception

            End Try
            Try
                drr("tel1") = NumEng2Thai(drr("tel1"))
            Catch ex As Exception

            End Try
            Try
                drr("thamu") = NumEng2Thai(drr("thamu"))
            Catch ex As Exception

            End Try
            Try
                drr("thafloor") = NumEng2Thai(drr("thafloor"))
            Catch ex As Exception

            End Try
            Try
                drr("thasoi") = NumEng2Thai(drr("thasoi"))
            Catch ex As Exception

            End Try
            Try
                drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
            Catch ex As Exception

            End Try
            Try
                drr("tharoad") = NumEng2Thai(drr("tharoad"))
            Catch ex As Exception

            End Try
            Try
                drr("zipcode") = NumEng2Thai(drr("zipcode"))
            Catch ex As Exception

            End Try
            Try
                drr("tel") = NumEng2Thai(drr("tel"))
            Catch ex As Exception

            End Try
            Try
                drr("fax") = NumEng2Thai(drr("fax"))
            Catch ex As Exception

            End Try
            Try
                drr("Mobile") = NumEng2Thai(drr("Mobile"))
            Catch ex As Exception

            End Try
            Try
                drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
            Catch ex As Exception

            End Try

        Next


        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Dim DT11 As New DataTable
        Try
            DT11 = class_xml.DT_SHOW.DT11
            For Each drr As DataRow In class_xml.DT_SHOW.DT11.Rows
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        Try
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            'For Each dr As DataRow In class_xml.DT_SHOW.DT12.Rows
            '    dr("HOUSENO") = NumEng2Thai(dr("HOUSENO"))
            'Next
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        Dim DT13 As New DataTable
        Try
            DT13 = class_xml.DT_SHOW.DT13
            For Each drr As DataRow In class_xml.DT_SHOW.DT13.Rows
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน


        Dim MAIN_LCN_IDA As Integer = 0
        'If IsNothing(dao.fields.MAIN_LCN_IDA) = False Then
        '    If (Integer.TryParse(dao.fields.MAIN_LCN_IDA, MAIN_LCN_IDA) = True) Then        'เปลี่ยน ร
        '        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        '    End If
        'End If
        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        Dim BSN_IDENTIFY As String = ""
        Dim BSN_IDENTIFY_yoi As String = ""
        Try
            'If MAIN_LCN_IDA <> 0 Then
            '    Dim dao_lcn2 As New DAO_DRUG.ClsDBdalcn
            '    dao_lcn2.GetDataby_IDA(MAIN_LCN_IDA)
            'End If
            BSN_IDENTIFY = NumEng2Thai(dao.fields.BSN_IDENTIFY)
        Catch ex As Exception

        End Try
        'If MAIN_LCN_IDA <> 0 Then
        '    'ใบย่อย
        '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(MAIN_LCN_IDA) 'ผู้ดำเนิน
        'Else
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        Dim dt14 As New DataTable
        Try

            For Each drr As DataRow In class_xml.DT_SHOW.DT14.Rows
                drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
                Try
                    drr("BSN_HOUSENO") = NumEng2Thai(drr("BSN_HOUSENO"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try

        'End If
        Dim bao_cpn As New BAO.ClsDBSqlcommand
        Try
            class_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao.fields.CITIZEN_ID_AUTHORIZE)
            class_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"
        Catch ex As Exception

        End Try

        Try
            class_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao.fields.CITIZEN_ID_AUTHORIZE)
            For Each dr As DataRow In class_xml.DT_SHOW.DT16.Rows
                dr("tel") = NumEng2Thai(dr("tel"))
            Next
            class_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"
        Catch ex As Exception

        End Try




        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA)
        'Dim DT18 As New DataTable
        '    DT18 = class_xml.DT_MASTER.DT18
        'For Each drr As DataRow In DT18.Rows
        '    Try
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Catch ex As Exception

        '    End Try

        'Next
        'class_xml.DT_MASTER.DT18 = DT18

        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(_IDA)

        Dim DT24 As New DataTable
        Try
            DT24 = class_xml.DT_MASTER.DT24
            For Each drr As DataRow In DT24.Rows
                Try
                    drr("thanameplace2") = NumEng2Thai(drr("thanameplace2"))
                Catch ex As Exception

                End Try
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next

            class_xml.DT_MASTER.DT24 = DT24
        Catch ex As Exception

        End Try


        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)

        Dim DT25 As New DataTable
        Try
            DT25 = class_xml.DT_MASTER.DT25
            For Each drr As DataRow In DT25.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
                '
            Next
        Catch ex As Exception

        End Try

        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        Dim DT26 As New DataTable
        Try
            DT26 = class_xml.DT_MASTER.DT26
            For Each drr As DataRow In DT26.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try

        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        Dim DT27 As New DataTable
        Try
            DT27 = class_xml.DT_MASTER.DT27
            For Each drr As DataRow In DT27.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 1)
        Dim DT28 As New DataTable
        Try
            DT28 = class_xml.DT_MASTER.DT28
            For Each drr As DataRow In DT28.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try

        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 2)
        Dim DT29 As New DataTable
        Try
            DT29 = class_xml.DT_MASTER.DT29
            For Each drr As DataRow In DT29.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"

        class_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(dao.fields.IDA)

        Dim DT31 As New DataTable

        DT31 = class_xml.DT_MASTER.DT31
        For Each drr As DataRow In DT31.Rows
            Try
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
            Catch ex As Exception

            End Try
            Try
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Catch ex As Exception

            End Try

        Next

        class_xml.DT_MASTER.DT34 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 3)
        Dim DT34 As New DataTable
        Try
            DT34 = class_xml.DT_MASTER.DT34
            For Each drr As DataRow In DT34.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
                drr("PHR_CERTIFICATE_TRAINING1") = NumEng2Thai(drr("PHR_CERTIFICATE_TRAINING1"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT34.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_3_1_ROW"

        Try
            Dim dao_phr_c As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr_c.GetDataby_FK_IDA(_IDA)
            Dim c_phr As Integer = 0
            For Each dao_phr_c.fields In dao_phr_c.datas
                c_phr += 1
            Next
            class_xml.PHR_COUNT = c_phr
        Catch ex As Exception

        End Try
        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        Try
            Dim _type_da As String = ""
            If dao.fields.PROCESS_ID = "120" Then
                _type_da = "3"
            ElseIf dao.fields.PROCESS_ID = "121" Then
                _type_da = "2"
            ElseIf dao.fields.PROCESS_ID = "122" Then
                _type_da = "1"
            End If
            If dao.fields.REVOCATION Is Nothing Or Trim(dao.fields.REVOCATION) = "" Then
                If Len(lcnno_auto) > 0 Then

                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    Else
                        lcnno_format = dao.fields.pvnabbr & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                    'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If

                lcnno_format_new = dao.fields.LCNNO_DISPLAY_NEW
                'lcnno_format_new = "HB " & dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)

            Else

                'Dim _type_da As String = ""
                'If dao.fields.PROCESS_ID = "120" Then
                '    _type_da = "3"
                'ElseIf dao.fields.PROCESS_ID = "121" Then
                '    _type_da = "2"
                'ElseIf dao.fields.PROCESS_ID = "122" Then
                '    _type_da = "1"
                'End If

                If Not dao.fields.LCNNO_DISPLAY_NEW Is Nothing Then
                    lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    'lcnno_format_new = "HB " & dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                Else
                    lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    lcnno_format_new = dao.fields.LCNNO_DISPLAY_NEW
                    ' lcnno_format_new = "HB " & dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                End If

            End If

        Catch ex As Exception

        End Try


        If MAIN_LCN_IDA <> 0 Then
            'Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            'dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

            'Try
            '    'lcnno_format = 
            '    'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

            '    If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
            '        class_xml.HEAD_LCNNO_NCT = dao_main2.fields.lcntpcd & " จ. " & CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
            '    Else
            '        class_xml.HEAD_LCNNO_NCT = dao_main2.fields.lcntpcd & " " & dao_main2.fields.pvnabbr & " " & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
            '    End If
            '    class_xml.HEAD_LCNNO_NCT = NumEng2Thai(class_xml.HEAD_LCNNO_NCT)
            'Catch ex As Exception

            'End Try
            If _ProcessID = "125" Or _ProcessID = "126" Then
                Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
                dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

                Try
                    'lcnno_format = 
                    'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                Catch ex As Exception
                End Try
                'Dim dao_main As New DAO_DRUG.ClsDBdalcn
                dao_main.GetDataby_IDA(MAIN_LCN_IDA)
                Try


                    class_xml.CHILD_LCNNO_NCT = NumEng2Thai(class_xml.CHILD_LCNNO_NCT)
                Catch ex As Exception

                End Try

                Try
                    Dim dao_main3 As New DAO_DRUG.ClsDBdalcn
                    dao_main3.GetDataby_IDA(dao_main2.fields.MAIN_LCN_IDA)

                    Try
                        'lcnno_format = 
                        'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                        If Right(Left(dao_main3.fields.lcnno, 3), 1) = "5" Then
                            class_xml.HEAD_LCNNO_NCT = CStr(CInt(Right(dao_main3.fields.lcnno, 4))) & "/25" & Left(dao_main3.fields.lcnno, 2)
                        Else
                            class_xml.HEAD_LCNNO_NCT = dao_main3.fields.pvnabbr & CStr(CInt(Right(dao_main3.fields.lcnno, 5))) & "/25" & Left(dao_main3.fields.lcnno, 2)
                        End If

                        class_xml.HEAD_LCNNO_NCT = NumEng2Thai(class_xml.HEAD_LCNNO_NCT)
                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                End Try
            Else
                Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
                dao_main2.GetDataby_IDA(MAIN_LCN_IDA)



                Try
                    'lcnno_format = 
                    'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                    If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                        class_xml.HEAD_LCNNO_NCT = CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                    Else
                        class_xml.HEAD_LCNNO_NCT = dao_main2.fields.pvnabbr & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                    End If

                    class_xml.HEAD_LCNNO_NCT = NumEng2Thai(class_xml.HEAD_LCNNO_NCT)
                Catch ex As Exception

                End Try
            End If
        End If



        class_xml.LCNNO_SHOW = (lcnno_format)
        class_xml.LCNNO_SHOW_NUMTHAI = NumEng2Thai(lcnno_format)
        class_xml.LCNNO_SHOW_NEW = (lcnno_format_new)
        class_xml.LCNNO_SHOW_NEW_NUMTHAI = NumEng2Thai(lcnno_format_new)
        class_xml.SHOW_LCNNO = (lcnno_text)
        class_xml.SHOW_LCNNO_NUMTHAI = NumEng2Thai(lcnno_text)
        'If MAIN_LCN_IDA = 0 Then
        'class_xml.LCNNO_SHOW = NumEng2Thai(lcnno_format)
        'class_xml.LCNNO_SHOW_NEW = NumEng2Thai(lcnno_format_new)
        'class_xml.SHOW_LCNNO = NumEng2Thai(lcnno_text)
        Try
            If dao.fields.lcntpcd = "ขสม" Then
                class_xml.LCN_TYPE = "ขาย"
                class_xml.LCN_TYPE_ID = "3"
            ElseIf dao.fields.lcntpcd = "ผสม" Then
                class_xml.LCN_TYPE = "ผลิต"
                class_xml.LCN_TYPE_ID = "1"
            ElseIf dao.fields.lcntpcd = "นสม" Then
                class_xml.LCN_TYPE = "นำเข้า"
                class_xml.LCN_TYPE_ID = "2"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_pph As New DAO_DRUG.ClsDBDALCN_PHR
            dao_pph.GetDataby_FK_IDA(_IDA)
            If dao_pph.fields.PHR_LAW_SECTION = "1" Then
                class_xml.MASTRA = "มาตรา 31"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๑"
                class_xml.MASTRA_NO = "31"
                class_xml.MASTRA_NO_NUMTHAI = "๓๑"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "2" Then
                class_xml.MASTRA = "มาตรา 32"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๒"
                class_xml.MASTRA_NO = "32"
                class_xml.MASTRA_NO_NUMTHAI = "๓๒"
            ElseIf dao_pph.fields.PHR_LAW_SECTION = "3" Then
                class_xml.MASTRA = "มาตรา 33"
                class_xml.MASTRA_NUMTHAI = "มาตรา ๓๓"
                class_xml.MASTRA_NO = "33"
                class_xml.MASTRA_NO_NUMTHAI = "๓๓"
            End If
        Catch ex As Exception

        End Try
        Try

            class_xml.COUNT_PHESAJ1 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 1)
        Catch ex As Exception

        End Try

        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ2 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 2)
        Catch ex As Exception

        End Try
        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ3 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 3)
        Catch ex As Exception

        End Try
        'Else

        '    class_xml.LCNNO_SHOW = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(dao_main.fields.lcnno, 5))) & "/25" & Left(dao_main.fields.lcnno, 2)
        '    class_xml.SHOW_LCNNO = dao_main.fields.LCNNO_MANUAL
        'End If

        class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = NumEng2Thai(appdate.Day)
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = NumEng2Thai(con_year(appdate.Year))

                If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then

                    class_xml.RCVDAY_NUMTHAI_NEW = NumEng2Thai(appdate.Day.ToString())
                    class_xml.RCVMONTH_NUMTHAI_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NUMTHAI_NEW = NumEng2Thai(con_year(appdate.Year))

                    class_xml.RCVDAY_NEW = appdate.Day.ToString()
                    class_xml.RCVMONTH_NEW = appdate.ToString("MMMM")
                    class_xml.RCVYEAR_NEW = con_year(appdate.Year)


                End If


                class_xml.RCVDAY_NUMTHAI = NumEng2Thai(appdate.Day.ToString())
                class_xml.RCVMONTH_NUMTHAI = appdate.ToString("MMMM")
                class_xml.RCVYEAR_NUMTHAI = NumEng2Thai(con_year(appdate.Year))

                class_xml.RCVDAY = appdate.Day.ToString()
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                'Try
                '    class_xml.EXP_YEAR = dao.fields.expyear 'con_year(appdate.Year)
                'Catch ex As Exception
                '    class_xml.EXP_YEAR = con_year(appdate.Year)
                'End Try
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(appdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)

            End If
        End If

        If IsNothing(dao.fields.expdate) = False Then
            Dim expdate As Date
            If Date.TryParse(dao.fields.expdate, expdate) = True Then
                class_xml.SHOW_EXPDATE_DAY = expdate.Day
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR = con_year(expdate.Year)

                class_xml.SHOW_EXPDATE_DAY_NUMTHAI = NumEng2Thai(expdate.Day)
                class_xml.SHOW_EXPDATE_MONTH = expdate.ToString("MMMM")
                class_xml.SHOW_EXPDATE_YEAR_NUMTHAI = NumEng2Thai(con_year(expdate.Year))


                class_xml.EXPDAY = NumEng2Thai(expdate.Day.ToString())
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXPYEAR = NumEng2Thai(con_year(expdate.Year))
                'Try
                '    class_xml.EXP_YEAR = dao.fields.expyear 'con_year(appdate.Year)
                'Catch ex As Exception
                '    class_xml.EXP_YEAR = con_year(appdate.Year)
                'End Try
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(expdate.Year)
                End If
                class_xml.EXP_YEAR = NumEng2Thai(expyear)

            End If
        End If



        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHR
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        Try
            For Each dao_PHR.fields In dao_PHR.Details
                Try
                    If dao_PHR.fields.PHR_TEXT_WORK_TIME <> "" Then
                        dao_PHR.fields.PHR_TEXT_WORK_TIME = NumEng2Thai(dao_PHR.fields.PHR_TEXT_WORK_TIME)
                    End If
                Catch ex As Exception

                End Try
                class_xml.DALCN_PHRs.Add(dao_PHR.fields)
            Next

        Catch ex As Exception

        End Try
        '-------------------------------------


        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
            Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
            cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields

            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile)
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = NumEng2Thai(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm)
            Catch ex As Exception

            End Try


            class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.dalcns = dao.fields



        Catch ex As Exception

        End Try

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try

        class_xml.syslctaddr_engaddr = dao.fields.syslctaddr_engaddr
        class_xml.syslctaddr_floor = dao.fields.syslctaddr_floor
        class_xml.syslctaddr_mu = dao.fields.syslctaddr_mu
        class_xml.syslctaddr_room = dao.fields.syslctaddr_room
        class_xml.syslctaddr_thaaddr = dao.fields.syslctaddr_thaaddr
        class_xml.syslctaddr_thasoi = dao.fields.syslctaddr_thasoi

        p_dalcn = class_xml
        Dim p_dalcn2 As New XML_CENTER.CLASS_DALCN
        p_dalcn2 = p_dalcn
        'p_dalcn2.DT_MASTER = Nothing

        Dim cls_sop1 As New CLS_SOP
        Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dalcn2)
        b64 = cls_sop1.CLASS_TO_BASE64(p_dalcn2)

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd
        Dim PROCESS_ID As String = dao_up.fields.PROCESS_ID
        Dim YEAR As String = dao_up.fields.YEAR

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'If statusId = 8 Then
        '    Dim bao_count As New BAO.ClsDBSqlcommand
        '    Dim count_num As Integer = 0
        '    count_num = bao_count.SC_CHECK_PAY(_IDA)
        '    Dim Group As Integer
        '    If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
        '        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(PROCESS_ID, lcntype, statusId, Group, 0)
        '    ElseIf count_num = 0 Then
        '        statusId = 6
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    Else
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    End If

        'Else
        Dim template_id As Integer = 0
        'If statusId = 8 Then
        '    If PROCESS_ID = "104" Then
        '        Try
        '            template_id = dao.fields.TEMPLATE_ID
        '        Catch ex As Exception
        '            template_id = 0
        '        End Try
        '        If template_id <> 0 Then
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
        '        Else
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=0)
        '        End If

        '    Else
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    End If
        'Else
        '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        'End If

        If statusId = 8 Then
            Dim Group As Integer
            If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then

                'If PROCESS_ID = "104" Then
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try

                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                Else
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 0, 0)
                End If
                'Else
                '    dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(PROCESS_ID, lcntype, statusId, Group, 0)
                'End If
            Else

                'If PROCESS_ID = "104" Then
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    If statusId = 6 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                    End If

                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=0)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                End If

                '    Else
                '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                'End If

            End If
        Else

            'If PROCESS_ID = "104" Then
            Try
                template_id = dao.fields.TEMPLATE_ID
            Catch ex As Exception
                template_id = 0
            End Try
            If template_id = 2 Then
                'If statusId = 6 Then
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(PROCESS_ID, lcntype, statusId, 0, _group:=0)
                'Else
                'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                'End If

            Else
                'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(PROCESS_ID, lcntype, statusId, PREVIEW:=0, _group:=0)
            End If
            '    Else
            '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
            'End If
        End If



        'End If

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)
        'load_PDF(filename)

        'Try
        Dim url As String = ""
        ' If Request.QueryString("status") = 8 Or Request.QueryString("status") = 14 Then
        url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
        'Else
        '    url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF_VIEW.aspx?filename=" & filename
        'End If

        'Dim url As String 
        class_xml.QR_CODE = QR_CODE_IMG(url)
        'Catch ex As Exception

        'End Try


        p_dalcn = class_xml

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
    Private Sub load_pdf(ByVal FilePath As String)


        '  Response.ContentType = "Application/pdf"

        Dim clsds As New ClassDataset

        Dim bb As Byte() = clsds.UpLoadImageByte(FilePath)

        Dim ws_F As New WS_FLATTEN.WS_FLATTEN

        Dim b_o As Byte() = ws_F.FlattenPDF_DIGITAL(bb)

        Response.ContentType = "application/pdf"
        Response.AddHeader("content-length", b_o.Length.ToString())
        Response.BinaryWrite(b_o)



        'Response.Clear()
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment;filename=abc.pdf")

        'Response.BinaryWrite(clsds.UpLoadImageByte(FilePath))

        'Response.Flush()

        Response.End()
    End Sub


    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        Try
            imgBin = reader.ReadBytes(stream.Length)
        Catch ex As Exception
        Finally
            stream.Close()
            reader.Close()
        End Try
        Return imgBin
    End Function

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
Imports FDA_DRUG_HERB.XML_CENTER
Public Class POP_UP_LCN_STAFF_TRANSFER_COMFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA_LCN As String
    Private _IDA_TF As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDA_TF = Request.QueryString("IDA")

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
        If Not IsPostBack Then
            HiddenField2.Value = 0
            bind_dd()
            bind_mas_staff()
            Blind_PDF()
        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        Dim bao As New BAO.GenNumber
        Dim RCVNO As String = ""
        Dim RCVNO_HERB_NEW As String = ""
        Dim STATUS_ID As Integer = DD_STATUS.SelectedValue
        Dim ddl_id As Integer = 0
        Dim ddl_name As String = ""
        dao.GET_DATA_BY_IDA(_IDA_TF)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.FK_LCN)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(dao.fields.FK_LCN)

        dao.fields.STATUS_ID = DD_STATUS.SelectedValue
        'dao.fields.DATE_COMFIRM = Date.Now
        If dao.fields.STATUS_ID = 8 Then
            dao.fields.appdate = DATE_REQ.Text
            dao.fields.app_staff_name = DD_OFF_REQ.SelectedItem.Text
            dao.update()
            Blind_PDF()
            Transfer_data()
            'Dim WS_DRUG As WS_DRUG.WS_DRUG
            'WS_DRUG.HERB_UPDATE_LICEN(dao.fields.FK_LCN, _CLS.CITIZEN_ID)
            Dim ws_drug As New WS_DRUG.WS_DRUG
            WS_DRUG.HERB_UPDATE_LICEN(dao.fields.FK_LCN, _CLS.CITIZEN_ID)
            'dao_bsn.fields.BSN_THAIFULLNAME = dao.fields.BSN_NAME_NEW
            'dao_bsn.update()
            'dao_lcn.fields.thanm = dao.fields.than_name_new
            'dao_lcn.update()
        ElseIf dao.fields.STATUS_ID = 6 Then
            dao.fields.cnsdate = DATE_REQ.Text
            dao.fields.cnsstaff_name = DD_OFF_REQ.SelectedItem.Text
            dao.update()
            Blind_PDF()
        ElseIf dao.fields.STATUS_ID = 3 Then
            'RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), dao.fields.pvncd, _ProcessID, _IDA_TF)
            'Dim TR_ID As String = dao.fields.TR_ID
            'Dim DATE_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)
            'RCVNO_HERB_NEW = bao.GEN_RCVNO_NO_NEW(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA_TF)
            'Dim RCVNO_FULL As String = "HB" & " " & dao.fields.pvncd & "-" & _ProcessID & "-" & DATE_YEAR & "-" & RCVNO_HERB_NEW
            'dao.fields.RCVNO_NEW = RCVNO_FULL
            'dao.fields.RCVNO = RCVNO
            dao.fields.rcvdate = DATE_REQ.Text
            dao.fields.rcv_staff_name = DD_OFF_REQ.SelectedItem.Text
            dao.update()
            Blind_PDF()
        End If
        AddLogStatus_lcn(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA_TF, ddl_id, ddl_name)
        alert("อัพเดทคำขอแล้ว")
    End Sub
    Sub Transfer_data()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA_TF)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_log As New DAO_LCN.TB_LOG_LOCATION_BSN
        Try
            With dao_log.fields
                .OLD_IDA = dao_bsn.fields.OLD_IDA
                .LCN_IDA = dao_bsn.fields.LCN_IDA
                .BSN_PREFIXTHAICD = dao_bsn.fields.BSN_PREFIXTHAICD
                .BSN_THAINAME = dao_bsn.fields.BSN_THAINAME
                .BSN_THAILASTNAME = dao_bsn.fields.BSN_THAILASTNAME
                .BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
                .BSN_PREFIXENGCD = dao_bsn.fields.BSN_PREFIXENGCD
                .BSN_ENGNAME = dao_bsn.fields.BSN_ENGNAME
                .BSN_ENGLASTNAME = dao_bsn.fields.BSN_ENGLASTNAME
                .BSN_ENGFULLNAME = dao_bsn.fields.BSN_ENGFULLNAME
                .BSN_IDENTIFY = dao_bsn.fields.BSN_IDENTIFY
                .CHANGWAT_ID = dao_bsn.fields.CHANGWAT_ID
                .AMPHR_ID = dao_bsn.fields.AMPHR_ID
                .TUMBON_ID = dao_bsn.fields.TUMBON_ID
                .BSN_ADDR = dao_bsn.fields.BSN_ADDR
                .BSN_MOO = dao_bsn.fields.BSN_MOO
                .BSN_SOI = dao_bsn.fields.BSN_SOI
                .BSN_ROAD = dao_bsn.fields.BSN_ROAD
                .BSN_FLOOR = dao_bsn.fields.BSN_FLOOR
                .BSN_BUILDING = dao_bsn.fields.BSN_BUILDING
                .BSN_TELEPHONE = dao_bsn.fields.BSN_TELEPHONE
                .BSN_ZIPCODE = dao_bsn.fields.BSN_ZIPCODE
                .BSN_FAX = dao_bsn.fields.BSN_FAX
                .CREATE_DATE = dao_bsn.fields.CREATE_DATE
                .FK_IDA = dao_bsn.fields.FK_IDA
                .TR_ID = dao_bsn.fields.TR_ID
                .DOWN_ID = dao_bsn.fields.DOWN_ID
                .CITIZEN_ID = dao_bsn.fields.CITIZEN_ID
                .CITIZEN_ID_UPLOAD = dao_bsn.fields.CITIZEN_ID_UPLOAD
                .XMLNAME = dao_bsn.fields.XMLNAME
                .AGE = dao_bsn.fields.AGE
                .NATIONALITY = dao_bsn.fields.NATIONALITY
                .BSN_HOUSENO = dao_bsn.fields.BSN_HOUSENO
                .BSN_ENGADDR = dao_bsn.fields.BSN_ENGADDR
                .BSN_ENGMU = dao_bsn.fields.BSN_ENGMU
                .BSN_ENGSOI = dao_bsn.fields.BSN_ENGSOI
                .BSN_ENGROAD = dao_bsn.fields.BSN_ENGROAD
                .BSN_CHWNGNAME = dao_bsn.fields.BSN_CHWNGNAME
                .BSN_AMPHR_NAME = dao_bsn.fields.BSN_AMPHR_NAME
                .BSN_THMBL_NAME = dao_bsn.fields.BSN_THMBL_NAME
                .BSN_CHWNG_ENGNAME = dao_bsn.fields.BSN_CHWNG_ENGNAME
                .BSN_AMPHR_ENGNAME = dao_bsn.fields.BSN_AMPHR_ENGNAME
                .BSN_THMBL_ENGNAME = dao_bsn.fields.BSN_THMBL_ENGNAME
                .BSN_NATIONALITY_CD = dao_bsn.fields.BSN_NATIONALITY_CD
                .BSN_Mobile = dao_bsn.fields.BSN_Mobile
                .BSNID = dao_bsn.fields.BSNID
                .BSNLCTCD = dao_bsn.fields.BSNLCTCD
                .lcnsid = dao_bsn.fields.lcnsid
                .lctcd = dao_bsn.fields.lctcd
                .BSNSCD = dao_bsn.fields.BSNSCD
                .lcnscd = dao_bsn.fields.lcnscd
                .BSN_TEL = dao_bsn.fields.BSN_TEL
                .thanm_FullName = dao.fields.TRANSFER_NM
                .thanm_Identify = dao.fields.TRANSFER_ID
                .DATE_INSERT = Date.Now
                .CITIZEN_ID_INSERT = _CLS.CITIZEN_ID
                .IDA_TRANSFER = dao.fields.FK_LCN
            End With
            dao_log.insert()
        Catch ex As Exception

        End Try
        Try
            Dim BSN_IDEN As String = ""
            BSN_IDEN = dao.fields.BSN_IDENTIFY
            Dim bao_show11 As New BAO_SHOW
            Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(BSN_IDEN)
            dao_bsn.GetDataby_LCN_IDA(_IDA_LCN)
            For Each dr As DataRow In dt_bsn.Rows

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
                    dao_bsn.fields.BSN_CHWNGNAME = dr("thachngwtnm")
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
                dao_bsn.update()
            Next
        Catch ex As Exception

        End Try
        Try
            With dao_lcn.fields
                .thanm = dao.fields.TRANSFER_NM
                .CITIZEN_ID_AUTHORIZE = dao.fields.TRANSFER_TO_ID
                .BSN_PREFIXTHAICD = dao_bsn.fields.BSN_PREFIXTHAICD
                .BSN_THAINAME = dao_bsn.fields.BSN_THAINAME
                .BSN_THAILASTNAME = dao_bsn.fields.BSN_THAILASTNAME
                .BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
                .BSN_PREFIXENGCD = dao_bsn.fields.BSN_PREFIXENGCD
                .BSN_ENGNAME = dao_bsn.fields.BSN_ENGNAME
                .BSN_ENGLASTNAME = dao_bsn.fields.BSN_ENGLASTNAME
                .BSN_ENGFULLNAME = dao_bsn.fields.BSN_ENGFULLNAME
                .BSN_IDENTIFY = dao_bsn.fields.BSN_IDENTIFY
                .BSN_ADDR = dao_bsn.fields.BSN_ADDR
                .BSN_MOO = dao_bsn.fields.BSN_MOO
                .BSN_SOI = dao_bsn.fields.BSN_SOI
                .BSN_ROAD = dao_bsn.fields.BSN_ROAD
                .BSN_FLOOR = dao_bsn.fields.BSN_FLOOR
                .BSN_BUILDING = dao_bsn.fields.BSN_BUILDING
                .BSN_TELEPHONE = dao_bsn.fields.BSN_TELEPHONE
                .BSN_ZIPCODE = dao_bsn.fields.BSN_ZIPCODE
                .BSN_FAX = dao_bsn.fields.BSN_FAX
                .BSN_HOUSENO = dao_bsn.fields.BSN_HOUSENO
                .BSN_ENGADDR = dao_bsn.fields.BSN_ENGADDR
                .BSN_ENGMU = dao_bsn.fields.BSN_ENGMU
                .BSN_ENGSOI = dao_bsn.fields.BSN_ENGSOI
                .BSN_ENGROAD = dao_bsn.fields.BSN_ENGROAD
                .BSN_CHWNGNAME = dao_bsn.fields.BSN_CHWNGNAME
                .BSN_AMPHR_NAME = dao_bsn.fields.BSN_AMPHR_NAME
                .BSN_THMBL_NAME = dao_bsn.fields.BSN_THMBL_NAME
                .BSN_CHWNG_ENGNAME = dao_bsn.fields.BSN_CHWNG_ENGNAME
                .BSN_AMPHR_ENGNAME = dao_bsn.fields.BSN_AMPHR_ENGNAME
                .BSN_THMBL_ENGNAME = dao_bsn.fields.BSN_THMBL_ENGNAME
                .BSN_NATIONALITY_CD = dao_bsn.fields.BSN_NATIONALITY_CD
                .bsnid = dao_bsn.fields.BSNID
                .bsnlctcd = dao_bsn.fields.BSNLCTCD
            End With
            dao_lcn.update()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim ss_id As Integer = 0
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA_TF)
        If dao.fields.STATUS_ID = 13 Or dao.fields.STATUS_ID = 12 Then
            ss_id = 2
        ElseIf dao.fields.STATUS_ID = 3 Then
            ss_id = 3
        ElseIf dao.fields.STATUS_ID = 6 Then
            ss_id = 4
            btn_preview.Visible = True
            btn_sormorpo1.Visible = True
        ElseIf dao.fields.STATUS_ID = 8 Then
            P12.Visible = False
            btn_sumit.Visible = False
            KEEP_PAY.Visible = False
            btn_preview.Visible = True
            btn_sormorpo1.Visible = True
        End If
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(107, ss_id)
        dt = bao.dt

        DD_STATUS.DataSource = dt
        DD_STATUS.DataValueField = "STATUS_ID"
        DD_STATUS.DataTextField = "STATUS_NAME"
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")
        'dt = bao.SP_DD_STATUS_JJ_EDIT(ss_id)

        'DD_STATUS.DataSource = dt
        'DD_STATUS.DataBind()
        'DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")
        DATE_REQ.Text = Date.Now

    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub Blind_PDF()
        Dim dao As New DAO_LCN.TB_DALCN_TRANSFER
        dao.GET_DATA_BY_IDA(_IDA_TF)
        'Dim _ProcessID As String = 10501
        Dim XML As New CLASS_GEN_XML.DALCN_TRANSFER
        LCN_TRANSFER = XML.Gen_XML_LCN_TRANSFER(_IDA_TF, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(_ProcessID, dao.fields.STATUS_ID, "สมพ7", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_TRANSFER") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_PHR("PDF", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA_TF)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_PHR("XML", _ProcessID, dao.fields.YEAR, dao.fields.TR_ID, _IDA_TF)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"
    End Sub
    'Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
    '    Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    'End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub alert_return(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_sormorpo1_Click(sender As Object, e As EventArgs) Handles btn_sormorpo1.Click
        Dim _group As Integer = 0
        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 2
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 3
        End If

        'BindData_PDF(_group:=1)
        BindData_PDF_SOMORPO1(_group:=0)
    End Sub

    Private Sub BindData_PDF_SOMORPO1(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao_tf As New DAO_LCN.TB_DALCN_TRANSFER
        dao_tf.GET_DATA_BY_IDA(_IDA_TF)
        Dim _IDA As Integer = dao_tf.fields.FK_LCN
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim lcnno_format_NEW As String = ""
        Dim pvncd As String = ""
        Dim _TR_ID As String = ""
        Dim _iden As String = ""
        Try
            _TR_ID = dao_up.fields.ID
            _iden = dao.fields.CITIZEN_ID
        Catch ex As Exception

        End Try
        Dim ProcessID As String = ""
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If PROCESS_ID = "" Then
            PROCESS_ID = dao.fields.PROCESS_ID
        End If
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception

        End Try
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntpcd = Chn_lcntpcd(lcntpcd)
        Dim lcnsid_da As Integer = 0
        Try
            lcnsid_da = dao.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, lcnsid_da, lcnno:=lcnno_auto, lcntpcd:=lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW

        'class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA(_IDA)
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao.fields.FK_IDA) ' 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)

        class_xml.DT_SHOW.DT10 = bao_show.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(_IDA)

        Dim tt As Integer = 0
        If dao.fields.lcntpcd.Contains("ผ") Then
            tt = 1
            'ElseIf dao.fields.lcntpcd.Contains("น") Then
            '   tt = 2
        Else
            tt = 3
        End If
        If tt = 1 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, 1)

        ElseIf tt = 2 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB_V3(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, 1)
        ElseIf tt = 3 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB2(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, 1)

        End If

        Dim DDL_DRUG_SMP_31 As String = ""
        Dim DDL_DRUG_SMP_32 As String = ""
        Dim DDL_DRUG_SMP_33 As String = ""
        Dim DDL_DRUG_SMP_34 As String = ""
        Dim DDL_DRUG_SMP_35 As String = ""
        Dim DDL_DRUG_SMP_36 As String = ""
        Dim DDL_DRUG_SMP_37 As String = ""
        Dim DDL_DRUG_SMP_38 As String = ""
        Dim DDL_DRUG_SMP_39 As String = ""
        Dim DDL_DRUG_SMP_310 As String = ""
        Dim DDL_DRUG_SMP_311 As String = ""
        Dim DDL_DRUG_SMP_312 As String = ""

        class_xml.DT_SHOW.DT23 = bao_show.SP_DRUG_GROUP_HERB_NO3(_IDA)
        For Each drr As DataRow In class_xml.DT_SHOW.DT23.Rows
            Try
                If drr("FK_IDA") = 27 Then
                    DDL_DRUG_SMP_31 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 28 Then
                    DDL_DRUG_SMP_32 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 29 Then
                    DDL_DRUG_SMP_33 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 30 Then
                    DDL_DRUG_SMP_34 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 31 Then
                    DDL_DRUG_SMP_35 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 32 Then
                    DDL_DRUG_SMP_36 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 33 Then
                    DDL_DRUG_SMP_37 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 34 Then
                    DDL_DRUG_SMP_38 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 35 Then
                    DDL_DRUG_SMP_39 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 36 Then
                    DDL_DRUG_SMP_310 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 37 Then
                    DDL_DRUG_SMP_311 = drr("GROUP_NAME")
                End If
                If drr("FK_IDA") = 38 Then
                    DDL_DRUG_SMP_312 = drr("GROUP_NAME")
                End If

            Catch ex As Exception

            End Try
        Next
        class_xml.DT_SHOW.DT22 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1_V2(_IDA)

        Dim chk_smp1 As String = "0"
        Dim chk_smp1_1 As String = "0"
        Dim chk_smp1_2 As String = "0"
        Dim chk_smp1_3 As String = "0"
        Dim chk_smp1_4 As String = "0"
        Dim chk_smp1_5 As String = "0"
        Dim chk_smp1_6 As String = "0"
        Dim chk_smp1_7 As String = "0"
        Dim chk_smp1_8 As String = "0"
        Dim chk_smp1_9 As String = "0"
        Dim chk_smp1_10 As String = ""
        Dim chk_smp1_11 As String = ""
        Dim chk_smp2 As String = "0"
        Dim chk_smp2_1 As String = "0"
        Dim chk_smp2_2 As String = "0"
        Dim chk_smp2_3 As String = "0"
        Dim chk_smp2_4 As String = "0"
        Dim chk_smp2_5 As String = "0"
        Dim chk_smp2_6 As String = "0"
        Dim chk_smp2_7 As String = "0"
        Dim chk_smp2_8 As String = "0"
        Dim chk_smp2_9 As String = "0"
        Dim chk_smp2_10 As String = "0"
        Dim chk_smp2_11 As String = ""
        Dim chk_smp2_12 As String = ""
        Dim chk_smp3 As String = "0"
        Dim chk_smp3_1 As String = "0"
        Dim chk_smp3_2 As String = "0"
        Dim chk_smp3_3 As String = "0"
        Dim chk_smp3_4 As String = "0"
        Dim chk_smp3_5 As String = "0"
        Dim chk_smp3_6 As String = "0"
        Dim chk_smp3_7 As String = "0"
        Dim chk_smp3_8 As String = "0"
        Dim chk_smp3_9 As String = "0"
        Dim chk_smp3_10 As String = "0"
        Dim chk_smp3_11 As String = ""
        Dim chk_smp3_12 As String = ""
        Dim chk_smp4 As String = "0"
        Dim chk_smp4_1 As String = "0"
        Dim chk_smp4_1_1 As String = ""
        Dim chk_smp4_1_2 As String = ""
        Dim chk_smp4_2 As String = "0"
        Dim chk_smp4_3 As String = ""
        Dim CHK_SMP1_MAIN_1 As String = "0"
        Dim CHK_SMP1_MAIN_2 As String = "0"
        Dim CHK_SMP1_MAIN_3 As String = "0"
        Dim CHK_SMP1_MAIN_4 As String = "0"

        For Each drr As DataRow In class_xml.DT_SHOW.DT22.Rows
            Try
                If dao.fields.PROCESS_ID = 122 Then
                    If drr("HEAD_NO") = 1 Then
                        chk_smp1 = 1
                    End If
                    If drr("HEAD_NO") = 2 Then
                        chk_smp1_1 = 1
                    End If
                    If drr("HEAD_NO") = 3 Then
                        chk_smp1_2 = 1
                    End If
                    If drr("HEAD_NO") = 4 Then
                        chk_smp1_3 = 1
                    End If
                    If drr("HEAD_NO") = 5 Then
                        chk_smp1_4 = 1
                    End If
                    If drr("HEAD_NO") = 6 Then
                        chk_smp1_5 = 1
                    End If
                    If drr("HEAD_NO") = 7 Then
                        chk_smp1_6 = 1
                    End If
                    If drr("HEAD_NO") = 8 Then
                        chk_smp1_7 = 1
                    End If
                    If drr("HEAD_NO") = 9 Then
                        chk_smp1_8 = 1
                    End If
                    If drr("HEAD_NO") = 10 Then
                        chk_smp1_9 = 1
                    End If
                    If drr("HEAD_NO") = 11 Then
                        chk_smp1_10 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 12 Then
                        chk_smp1_11 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 13 Then
                        chk_smp2 = 1
                    End If
                    If drr("HEAD_NO") = 14 Then
                        chk_smp2_1 = 1
                    End If
                    If drr("HEAD_NO") = 15 Then
                        chk_smp2_2 = 1
                    End If
                    If drr("HEAD_NO") = 16 Then
                        chk_smp2_3 = 1
                    End If
                    If drr("HEAD_NO") = 17 Then
                        chk_smp2_4 = 1
                    End If
                    If drr("HEAD_NO") = 18 Then
                        chk_smp2_5 = 1
                    End If
                    If drr("HEAD_NO") = 19 Then
                        chk_smp2_6 = 1
                    End If
                    If drr("HEAD_NO") = 20 Then
                        chk_smp2_7 = 1
                    End If
                    If drr("HEAD_NO") = 21 Then
                        chk_smp2_8 = 1
                    End If
                    If drr("HEAD_NO") = 22 Then
                        chk_smp2_9 = 1
                    End If
                    If drr("HEAD_NO") = 23 Then
                        chk_smp2_10 = 1
                    End If
                    If drr("HEAD_NO") = 24 Then
                        chk_smp2_11 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 25 Then
                        chk_smp2_12 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 26 Then
                        chk_smp3 = 1
                    End If
                    If drr("HEAD_NO") = 27 Then
                        chk_smp3_1 = 1
                    End If
                    If drr("HEAD_NO") = 28 Then
                        chk_smp3_2 = 1
                    End If
                    If drr("HEAD_NO") = 29 Then
                        chk_smp3_3 = 1
                    End If
                    If drr("HEAD_NO") = 30 Then
                        chk_smp3_4 = 1
                    End If
                    If drr("HEAD_NO") = 31 Then
                        chk_smp3_5 = 1
                    End If
                    If drr("HEAD_NO") = 32 Then
                        chk_smp3_6 = 1
                    End If
                    If drr("HEAD_NO") = 33 Then
                        chk_smp3_7 = 1
                    End If
                    If drr("HEAD_NO") = 34 Then
                        chk_smp3_8 = 1
                    End If
                    If drr("HEAD_NO") = 35 Then
                        chk_smp3_9 = 1
                    End If
                    If drr("HEAD_NO") = 36 Then
                        chk_smp3_10 = 1
                    End If
                    If drr("HEAD_NO") = 37 Then
                        chk_smp3_11 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 38 Then
                        chk_smp3_12 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 39 Then
                        chk_smp4 = 1
                    End If
                    If drr("HEAD_NO") = 40 Then
                        chk_smp4_1 = 1
                    End If
                    If drr("HEAD_NO") = 41 Then
                        chk_smp4_1_1 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 42 Then
                        chk_smp4_1_2 = drr("COL_ID1")
                    End If
                    If drr("HEAD_NO") = 43 Then
                        chk_smp4_2 = 1
                    End If
                    If drr("HEAD_NO") = 44 Then
                        chk_smp4_3 = drr("COL_ID1")
                    End If
                ElseIf dao.fields.PROCESS_ID = 121 Then
                    If drr("HEAD_NO") = 1 Then
                        chk_smp1 = 1
                    End If
                    If drr("HEAD_NO") = 13 Then
                        chk_smp2 = 1
                    End If
                    If drr("HEAD_NO") = 26 Then
                        chk_smp3 = 1
                    End If
                    If drr("HEAD_NO") = 39 Then
                        chk_smp4 = 1
                    End If
                ElseIf dao.fields.PROCESS_ID = 120 Then
                    If drr("HEAD_NO") = 1 Then
                        CHK_SMP1_MAIN_1 = 1
                    End If
                    If drr("HEAD_NO") = 13 Then
                        CHK_SMP1_MAIN_2 = 1
                    End If
                    If drr("HEAD_NO") = 26 Then
                        CHK_SMP1_MAIN_3 = 1
                    End If
                    If drr("HEAD_NO") = 39 Then
                        CHK_SMP1_MAIN_4 = 1
                    End If
                End If


            Catch ex As Exception

            End Try
        Next

        Dim dt9 As New DataTable

        'dt9 = class_xml.DT_SHOW.DT9
        For Each drr As DataRow In class_xml.DT_SHOW.DT9.Rows
            Try
                drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
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
                drr("tharoom") = NumEng2Thai(drr("tharoom"))
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
            '
            '
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
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        Catch ex As Exception

        End Try

        Try
            class_xml.DT_MASTER.DT38 = bao_show.SP_Lisense_Name_and_Addr(_iden) 'ผู้ขออนุญาต
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ



        Dim BSN_IDENTIFY As String = ""
        Try
            BSN_IDENTIFY = NumEng2Thai(dao.fields.BSN_IDENTIFY)
        Catch ex As Exception

        End Try
        Dim MAIN_LCN_IDA As Integer = 0

        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

        class_xml.DT_SHOW.DT15 = bao_show.SP_DALCN_CURRENT_ADDRESS(_IDA)
        'End If
        Dim dt14 As New DataTable
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        Try
            If dao_frgn.fields.addr_status = 0 Or dao_frgn.fields.addr_status = 1 Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_DALCN_CURRENT_ADDRESS(_IDA)
            ElseIf dao_frgn.fields.addr_status = Nothing Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            End If

        Catch ex As Exception

        End Try

        Try
            dt14 = class_xml.DT_SHOW.DT14
            For Each drr As DataRow In dt14.Rows
                drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA) 'ผู้มีหน้าที่ปฏิบัติการ

        class_xml.DT_SHOW.DT35 = bao_master.SP_DALCN_FRGN_DATA(_IDA)


        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        Dim DT25 As New DataTable
        Try
            DT25 = class_xml.DT_MASTER.DT25
            For Each drr As DataRow In DT25.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
            Next
        Catch ex As Exception

        End Try

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


        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try

        Try
            If dao.fields.REVOCATION Is Nothing Or Trim(dao.fields.REVOCATION) = "" Then
                If Len(lcnno_auto) > 0 Then

                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                        lcnno_format = dao.fields.pvnabbr & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                    'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)

                End If

                lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW

            Else

                Dim _type_da As String = ""
                If dao.fields.PROCESS_ID = "120" Then
                    _type_da = "3"
                ElseIf dao.fields.PROCESS_ID = "121" Then
                    _type_da = "2"
                ElseIf dao.fields.PROCESS_ID = "122" Then
                    _type_da = "1"
                End If

                If Not dao.fields.LCNNO_DISPLAY_NEW Is Nothing Then
                    lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    'Try
                    '    Dim App_Date As Date = dao.fields.appdate
                    '    If App_Date > #10/1/2019 12:00:00 AM# Then
                    '        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    '    Else
                    '        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then
                        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    End If
                    'lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                Else
                    lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

            Try
                'lcnno_format = 
                'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                    class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                Else
                    class_xml.HEAD_LCNNO = dao_main2.fields.pvnabbr & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                End If

                class_xml.HEAD_LCNNO = NumEng2Thai(class_xml.HEAD_LCNNO)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        Dim rcvno_format As String = ""
        Dim RCV_DATE As String = ""
        Try
            ' rcvno_format = dao.fields.RCVNO_NEW
        Catch ex As Exception

        End Try

        Dim rcvdate1 As Date
        Dim rcvdate2 As String = ""
        Try
            If dao.fields.rcvdate IsNot Nothing Then
                rcvdate1 = dao.fields.rcvdate
                rcvdate2 = CDate(rcvdate1).ToString("dd/MM/yyy")
            End If

        Catch ex As Exception

        End Try


        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        Dim op_time As String = ""
        op_time = dao.fields.opentime

        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.LCNNO_SHOW_NUMTHAI = NumEng2Thai(lcnno_format)
        class_xml.LCNNO_SHOW_NEW = lcnno_format_NEW
        class_xml.LCNNO_SHOW_NEW_NUMTHAI = NumEng2Thai(lcnno_format_NEW)
        class_xml.SHOW_LCNNO = lcnno_text
        class_xml.SHOW_LCNNO_NUMTHAI = NumEng2Thai(lcnno_text)
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.RCVDATE_DISPLAY = rcvdate2
        class_xml.OPEN_TIME = op_time
        class_xml.chk_smp1 = chk_smp1
        class_xml.chk_smp1_1 = chk_smp1_1
        class_xml.chk_smp1_2 = chk_smp1_2
        class_xml.chk_smp1_3 = chk_smp1_3
        class_xml.chk_smp1_4 = chk_smp1_4
        class_xml.chk_smp1_5 = chk_smp1_5
        class_xml.chk_smp1_6 = chk_smp1_6
        class_xml.chk_smp1_7 = chk_smp1_7
        class_xml.chk_smp1_8 = chk_smp1_8
        class_xml.chk_smp1_9 = chk_smp1_9
        class_xml.chk_smp1_10 = chk_smp1_10
        class_xml.chk_smp1_11 = chk_smp1_11
        class_xml.chk_smp2 = chk_smp2
        class_xml.chk_smp2_1 = chk_smp2_1
        class_xml.chk_smp2_2 = chk_smp2_2
        class_xml.chk_smp2_3 = chk_smp2_3
        class_xml.chk_smp2_4 = chk_smp2_4
        class_xml.chk_smp2_5 = chk_smp2_5
        class_xml.chk_smp2_6 = chk_smp2_6
        class_xml.chk_smp2_7 = chk_smp2_7
        class_xml.chk_smp2_8 = chk_smp2_8
        class_xml.chk_smp2_9 = chk_smp2_9
        class_xml.chk_smp2_10 = chk_smp2_10
        class_xml.chk_smp2_11 = chk_smp2_11
        class_xml.chk_smp2_12 = chk_smp2_12
        class_xml.chk_smp3 = chk_smp3
        class_xml.chk_smp3_1 = chk_smp3_1
        class_xml.chk_smp3_2 = chk_smp3_2
        class_xml.chk_smp3_3 = chk_smp3_3
        class_xml.chk_smp3_4 = chk_smp3_4
        class_xml.chk_smp3_5 = chk_smp3_8
        class_xml.chk_smp3_6 = chk_smp3_6
        class_xml.chk_smp3_7 = chk_smp3_7
        class_xml.chk_smp3_8 = chk_smp3_8
        class_xml.chk_smp3_9 = chk_smp3_9
        class_xml.chk_smp3_10 = chk_smp3_10
        class_xml.chk_smp3_11 = chk_smp3_11
        class_xml.chk_smp3_12 = chk_smp3_12
        class_xml.chk_smp4 = chk_smp4
        class_xml.chk_smp4_1 = chk_smp4_1
        class_xml.chk_smp4_1_1 = chk_smp4_1_1
        class_xml.chk_smp4_1_2 = chk_smp4_1_2
        class_xml.chk_smp4_2 = chk_smp4_2
        class_xml.chk_smp4_3 = chk_smp4_3

        class_xml.CHK_SMP1_SELL_1 = CHK_SMP1_MAIN_1
        class_xml.CHK_SMP1_SELL_2 = CHK_SMP1_MAIN_2
        class_xml.CHK_SMP1_SELL_3 = CHK_SMP1_MAIN_3
        class_xml.CHK_SMP1_SELL_4 = CHK_SMP1_MAIN_4

        class_xml.DDL_MENU_DRUG_GROUP_3_1 = DDL_DRUG_SMP_31
        class_xml.DDL_MENU_DRUG_GROUP_3_2 = DDL_DRUG_SMP_32
        class_xml.DDL_MENU_DRUG_GROUP_3_3 = DDL_DRUG_SMP_33
        class_xml.DDL_MENU_DRUG_GROUP_3_4 = DDL_DRUG_SMP_34
        class_xml.DDL_MENU_DRUG_GROUP_3_5 = DDL_DRUG_SMP_35
        class_xml.DDL_MENU_DRUG_GROUP_3_6 = DDL_DRUG_SMP_36
        class_xml.DDL_MENU_DRUG_GROUP_3_7 = DDL_DRUG_SMP_37
        class_xml.DDL_MENU_DRUG_GROUP_3_8 = DDL_DRUG_SMP_38
        class_xml.DDL_MENU_DRUG_GROUP_3_9 = DDL_DRUG_SMP_39
        class_xml.DDL_MENU_DRUG_GROUP_3_10 = DDL_DRUG_SMP_310
        class_xml.DDL_MENU_DRUG_GROUP_3_11 = DDL_DRUG_SMP_311
        class_xml.DDL_MENU_DRUG_GROUP_3_12 = DDL_DRUG_SMP_312


        class_xml.PROCESS_ID = PROCESS_ID

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
        Else
            If IsNothing(dao.fields.expyear) = False Then
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
        '    Dim cls_DALCN_PHR As New DALCN_PHRi
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        For Each dao_PHR.fields In dao_PHR.Details
            Try
                If dao_PHR.fields.PHR_TEXT_WORK_TIME <> "" Then
                    dao_PHR.fields.PHR_TEXT_WORK_TIME = NumEng2Thai(dao_PHR.fields.PHR_TEXT_WORK_TIME)
                End If
            Catch ex As Exception

            End Try
            class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)



        Catch ex As Exception

        End Try
        class_xml.dalcns = dao.fields
        Try
            class_xml.dalcns.CATEGORY_DRUG = NumEng2Thai(class_xml.dalcns.CATEGORY_DRUG)
        Catch ex As Exception

        End Try
        Try
            class_xml.dalcns.opentime = dao.fields.opentime
        Catch ex As Exception

        End Try

        class_xml.syslctaddr_engaddr = dao.fields.syslctaddr_engaddr
        class_xml.syslctaddr_floor = dao.fields.syslctaddr_floor
        class_xml.syslctaddr_mu = dao.fields.syslctaddr_mu
        class_xml.syslctaddr_room = dao.fields.syslctaddr_room
        class_xml.syslctaddr_thaaddr = dao.fields.syslctaddr_thaaddr
        class_xml.syslctaddr_thasoi = dao.fields.syslctaddr_thasoi

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

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = ""
        Try
            lcntype = dao.fields.lcntpcd
        Catch ex As Exception

        End Try

        lcntype = Chn_lcntpcd(lcntype)
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim template_id As Integer = 0
        If statusId = 8 Then
            Dim Group As Integer
            If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 1, 7)
                Else
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 1, 7)
                End If
            ElseIf _group = 2 Or _group = 3 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            Else

                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 1, 7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 1, 7)
                End If

            End If
        Else

            Try
                template_id = dao.fields.TEMPLATE_ID
            Catch ex As Exception
                template_id = 0
            End Try

            If _group = 1 Then
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                ElseIf template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            ElseIf _group = 2 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            ElseIf _group = 3 Then
                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If
            Else

                If template_id = 1 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=99)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 1, _group:=7)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
                End If



                'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
            End If

        End If
        Dim _PATH_FILE As String = ""
        Dim PDF_TEMPLATE As String = ""
        Dim Path_XML As String = ""
        Dim filename As String = ""
        Dim paths As String = bao._PATH_DEFAULT
        _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_TRANSFER") 'path
        If dao_tf.fields.STATUS_ID = 8 Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
        Else
            _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_TRANSFER") 'path
            PDF_TEMPLATE = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            filename = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
            Path_XML = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
        End If

        Dim url As String = ""
        url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
        class_xml.QR_CODE = QR_CODE_IMG(url)


        p_dalcn = class_xml

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
        _CLS.FILENAME_PDF = NAME_PDF2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
    End Sub
    'Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
    '    dao.fields.SUSTAIN_TYPE = "2"
    '    'For i As Integer = 0 To rdl_change.Items.Count - 1
    '    '    If rdl_change.Items(i).Selected = True Then
    '    '        If rdl_change.Items(i).Value = "1" Then
    '    dao.fields.CHK_SUSTAIN1 = True
    '                dao.fields.lcnsid_old = dao2.fields.lcnsid
    '                dao.fields.lcnsid_new = hf_lcn.Value

    '                Dim dao_lcn As New DAO_CPN.clsDBsyslcnsnm
    '                dao_lcn.GetDataby_lcnsid(dao2.fields.lcnsid)

    '                Dim dao_pre As New DAO_CPN.TB_sysprefix

    '                Dim prefix1 As String = ""
    '                Dim prefix2 As String = ""
    '                Try
    '                    dao_pre.Getdata_byid(dao_lcn.fields.prefixcd)
    '                    prefix1 = dao_pre.fields.thanm
    '                Catch ex As Exception

    '                End Try

    '                Try
    '                    dao.fields.BSN_THAIFULLNAME_OLD = prefix1 & dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
    '                Catch ex As Exception

    '                End Try

    '                dao_lcn = New DAO_CPN.clsDBsyslcnsnm
    '                dao_lcn.GetDataby_lcnsid(hf_lcn.Value)

    '                dao_pre = New DAO_CPN.TB_sysprefix
    '                Try
    '                    dao_pre.Getdata_byid(dao_lcn.fields.prefixcd)
    '                    prefix2 = dao_pre.fields.thanm
    '                Catch ex As Exception

    '                End Try

    '                Try
    '                    dao.fields.BSN_THAIFULLNAME = prefix2 & dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
    '                Catch ex As Exception

    '                End Try

    '    'ElseIf rdl_change.Items(i).Value = "2" Then
    '    '    dao.fields.CHK_SUSTAIN2 = True
    '    '    dao.fields.LCT_IDA_OLD = dao2.fields.FK_IDA
    '    '    Try
    '    '        dao.fields.LCT_IDA_NEW = hf_place.Value
    '    '    Catch ex As Exception

    '    '    End Try


    '    '    dao.fields.ADDR_OLD = lbl_location_old.Text
    '    '    dao.fields.ADDR_NEW = lbl_location_new.Text
    '    '    dao.fields.thanameplace_OLD = lbl_thanameplace_old.Text
    '    '    dao.fields.thanameplace = ddl_placename.SelectedItem.Text
    '    'ElseIf rdl_change.Items(i).Value = "3" Then
    '    '    Try
    '    '        dao.fields.PASS_AWAY_DATE = CDate(txt_PASS_AWAY_DATE.Text)
    '    '    Catch ex As Exception

    '    '    End Try

    '    '    dao.fields.CHK_SUSTAIN3 = True
    '    '    dao.fields.BSN_IDENTIFY_OLD = dao2.fields.BSN_IDENTIFY
    '    '    dao.fields.BSN_PREFIXTHAICD_OLD = dao2.fields.BSN_PREFIXTHAICD
    '    '    dao.fields.BSN_THAINAME_OLD = dao2.fields.BSN_THAINAME
    '    '    dao.fields.BSN_THAILASTNAME_OLD = dao2.fields.BSN_THAILASTNAME
    '    '    dao.fields.BSN_ENGNAME_OLD = dao2.fields.BSN_ENGNAME
    '    '    dao.fields.BSN_ENGLASTNAME_OLD = dao2.fields.BSN_ENGLASTNAME
    '    '    dao.fields.BSN_ENGFULLNAME_OLD = dao2.fields.BSN_ENGFULLNAME
    '    '    dao.fields.BSN_THAIFULLNAME_OLD = dao2.fields.BSN_THAIFULLNAME
    '    '    dao.fields.BSN_HOUSENO_OLD = dao2.fields.BSN_HOUSENO
    '    '    dao.fields.BSN_ADDR_OLD = dao2.fields.BSN_ENGADDR
    '    '    dao.fields.BSN_MOO_OLD = dao2.fields.BSN_MOO
    '    '    dao.fields.BSN_SOI_OLD = dao2.fields.BSN_SOI
    '    '    dao.fields.BSN_ROAD_OLD = dao2.fields.BSN_ROAD
    '    '    dao.fields.BSN_CHWNGNAME_OLD = dao2.fields.BSN_CHWNGNAME
    '    '    dao.fields.CHANGWAT_ID_OLD = dao2.fields.CHANGWAT_ID
    '    '    dao.fields.AMPHR_ID_OLD = dao2.fields.AMPHR_ID
    '    '    dao.fields.BSN_AMPHR_NAME_OLD = dao2.fields.BSN_AMPHR_NAME
    '    '    dao.fields.BSN_THMBL_NAME_OLD = dao2.fields.BSN_THMBL_NAME
    '    '    dao.fields.TUMBON_ID_OLD = dao2.fields.TUMBON_ID
    '    '    dao.fields.BSN_TELEPHONE_OLD = dao2.fields.BSN_TELEPHONE
    '    '    dao.fields.BSN_FAX_OLD = dao2.fields.BSN_FAX
    '    '    'dao.fields.BSN_THAILASTNAME = lbl_new_bsn.Text
    '    '    ''eng
    '    '    dao.fields.BSN_ENGADDR_OLD = dao2.fields.BSN_ENGADDR
    '    '    dao.fields.BSN_FLOOR_OLD = dao2.fields.BSN_ENGADDR
    '    '    dao.fields.BSN_ENGMU_OLD = dao2.fields.BSN_ENGMU
    '    '    dao.fields.BSN_ENGSOI_OLD = dao2.fields.BSN_ENGSOI
    '    '    dao.fields.BSN_ENGROAD_OLD = dao2.fields.BSN_ENGROAD
    '    '    dao.fields.BSN_CHWNG_ENGNAME_OLD = dao2.fields.BSN_CHWNG_ENGNAME
    '    '    dao.fields.BSN_AMPHR_ENGNAME_OLD = dao2.fields.BSN_AMPHR_ENGNAME
    '    '    dao.fields.BSN_THMBL_ENGNAME_OLD = dao2.fields.BSN_THMBL_ENGNAME


    '    '    Dim dao_bsn As New DAO_CPN.TB_LOCATION_BSN
    '    '    dao_bsn.Getdata_by_iden(txt_ctzid.Text)
    '    '    For Each dao_bsn.fields In dao_bsn.datas
    '    '        'dao.fields.BSN_IDENTIFY = txt_ctzid.Text
    '    '        'dao.fields.BSN_PREFIXTHAICD = dao_bsn.fields.BSN_PREFIXTHAICD
    '    '        'dao.fields.BSN_THAINAME = dao_bsn.fields.BSN_THAINAME
    '    '        'dao.fields.BSN_THAILASTNAME = dao_bsn.fields.BSN_THAILASTNAME
    '    '        'dao.fields.BSN_ENGNAME = dao_bsn.fields.BSN_ENGNAME
    '    '        'dao.fields.BSN_ENGLASTNAME = dao_bsn.fields.BSN_ENGLASTNAME
    '    '        'dao.fields.BSN_ENGFULLNAME = dao_bsn.fields.BSN_ENGFULLNAME
    '    '        'dao.fields.BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
    '    '        Dim CITIZEN_ID_AUTHORIZE As String = ""
    '    '        Try
    '    '            CITIZEN_ID_AUTHORIZE = txt_ctzid.Text
    '    '        Catch ex As Exception

    '    '        End Try

    '    '        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
    '    '        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

    '    '        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
    '    '        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

    '    '        Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
    '    '        dao_syslcnsnm.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
    '    '        'tha
    '    '        dao.fields.BSN_IDENTIFY = CITIZEN_ID_AUTHORIZE
    '    '        Try
    '    '            dao.fields.BSN_PREFIXTHAICD = dao_syslcnsnm.fields.prefixcd
    '    '        Catch ex As Exception

    '    '        End Try
    '    '        Try
    '    '            dao.fields.BSN_THAINAME = dao_syslcnsnm.fields.thanm
    '    '        Catch ex As Exception

    '    '        End Try
    '    '        Try
    '    '            dao.fields.BSN_THAILASTNAME = dao_syslcnsnm.fields.thalnm
    '    '        Catch ex As Exception

    '    '        End Try
    '    '        Try
    '    '            dao.fields.BSN_ENGNAME = dao_syslcnsnm.fields.engnm
    '    '        Catch ex As Exception

    '    '        End Try
    '    '        Try
    '    '            dao.fields.BSN_ENGLASTNAME = dao_syslcnsnm.fields.englnm
    '    '        Catch ex As Exception

    '    '        End Try
    '    '        Try
    '    '            dao.fields.BSN_ENGFULLNAME = dao_syslcnsnm.fields.engnm & " " & dao_syslcnsnm.fields.englnm
    '    '        Catch ex As Exception

    '    '        End Try
    '    '        Try
    '    '            dao.fields.BSN_THAIFULLNAME = dao_syslcnsnm.fields.thanm & " " & dao_syslcnsnm.fields.thalnm
    '    '        Catch ex As Exception

    '    '        End Try


    '    '        dao.fields.BSN_HOUSENO = dao_bsn.fields.BSN_HOUSENO
    '    '        dao.fields.BSN_ADDR = dao_bsn.fields.BSN_ENGADDR
    '    '        dao.fields.BSN_MOO = dao_bsn.fields.BSN_MOO
    '    '        dao.fields.BSN_SOI = dao_bsn.fields.BSN_SOI
    '    '        dao.fields.BSN_ROAD = dao_bsn.fields.BSN_ROAD
    '    '        dao.fields.BSN_CHWNGNAME = dao_bsn.fields.BSN_CHWNGNAME
    '    '        dao.fields.CHANGWAT_ID = dao_bsn.fields.CHANGWAT_ID
    '    '        dao.fields.AMPHR_ID = dao_bsn.fields.AMPHR_ID
    '    '        dao.fields.BSN_AMPHR_NAME = dao_bsn.fields.BSN_AMPHR_NAME
    '    '        dao.fields.BSN_THMBL_NAME = dao_bsn.fields.BSN_THMBL_NAME
    '    '        dao.fields.TUMBON_ID = dao_bsn.fields.TUMBON_ID
    '    '        dao.fields.BSN_TELEPHONE = dao_bsn.fields.BSN_TELEPHONE
    '    '        dao.fields.BSN_FAX = dao_bsn.fields.BSN_FAX

    '    '        ''eng
    '    '        dao.fields.BSN_ENGADDR = dao_bsn.fields.BSN_ENGADDR
    '    '        dao.fields.BSN_FLOOR = dao_bsn.fields.BSN_FLOOR
    '    '        dao.fields.BSN_ENGMU = dao_bsn.fields.BSN_ENGMU
    '    '        dao.fields.BSN_ENGSOI = dao_bsn.fields.BSN_ENGSOI
    '    '        dao.fields.BSN_ENGROAD = dao_bsn.fields.BSN_ENGROAD
    '    '        dao.fields.BSN_CHWNG_ENGNAME = dao_bsn.fields.BSN_CHWNG_ENGNAME
    '    '        dao.fields.BSN_AMPHR_ENGNAME = dao_bsn.fields.BSN_AMPHR_ENGNAME
    '    '        dao.fields.BSN_THMBL_ENGNAME = dao_bsn.fields.BSN_THMBL_ENGNAME
    '    '            '    Next
    '    '        End If
    '    '    End If

    '    'Next

    'End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim _group As Integer = 0
        HiddenField2.Value = 0
        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 1
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 0
        End If
        'show01.Visible = True
        BindData_PDF(_group:=_group)
    End Sub
    Private Sub BindData_PDF(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao_tf As New DAO_LCN.TB_DALCN_TRANSFER
        dao_tf.GET_DATA_BY_IDA(_IDA_TF)
        Dim _IDA As Integer = dao_tf.fields.FK_LCN
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim lcnno_format_NEW As String = ""
        Dim pvncd As String = ""
        Dim _TR_ID As String = ""
        Dim _iden As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)
        Try
            _TR_ID = dao_up.fields.ID
            _iden = dao.fields.CITIZEN_ID
        Catch ex As Exception

        End Try
        Dim ProcessID As String = ""
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If PROCESS_ID = "" Then
            PROCESS_ID = dao.fields.PROCESS_ID
        End If
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception

        End Try
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntpcd = Chn_lcntpcd(lcntpcd)
        Dim lcnsid_da As Integer = 0
        Try
            lcnsid_da = dao.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, lcnsid_da, lcnno:=lcnno_auto, lcntpcd:=lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()

        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(1, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        'class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA(_IDA)
        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao.fields.FK_IDA) ' 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)

        Dim tt As Integer = 0
        If dao.fields.lcntpcd.Contains("ผ") Then
            tt = 1
            'ElseIf dao.fields.lcntpcd.Contains("น") Then
            '   tt = 2
        Else
            tt = 3
        End If
        If tt = 1 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        ElseIf tt = 2 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB_V3(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        ElseIf tt = 3 Then
            class_xml.DT_SHOW.DT19 = bao_show.SP_DRUG_GROUP_LCN_HERB2(_IDA, tt)
            class_xml.DT_MASTER.DT40 = bao_show.SP_DRUG_GROUP_LCN_HERB_SMP1(_IDA, tt)
        End If

        Dim dt9 As New DataTable

        'dt9 = class_xml.DT_SHOW.DT9
        For Each drr As DataRow In class_xml.DT_SHOW.DT9.Rows
            Try
                drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
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
                drr("tharoom") = NumEng2Thai(drr("tharoom"))
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
            '
            '
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
        'class_xml.DT_SHOW.DT9 = dt9

        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Dim DT11 As New DataTable
        Try
            'DT11 = class_xml.DT_SHOW.DT11
            For Each drr As DataRow In class_xml.DT_SHOW.DT11.Rows
                Try
                    If drr("thaaddr") = "" Then
                        drr("thaaddr") = "-"
                    End If
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
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            ' class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            'SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
            Dim dt_thanm As New DataTable
            If dao_tf.fields.STATUS_ID = 8 Then
                dt_thanm = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
            Else
                Dim BSN_IDEN As String = ""
                BSN_IDEN = dao.fields.BSN_IDENTIFY
                Dim bao_show11 As New BAO_SHOW
                dt_thanm = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
                Dim dt_new As New DataTable
                For Each dr As DataRow In dt_thanm.Rows
                    Try
                        dr("thanm") = dao_tf.fields.TRF_PREFIX_NM & " " & dao_tf.fields.TRANSFER_TO
                    Catch ex As Exception

                    End Try
                Next
            End If
            class_xml.DT_SHOW.DT12 = dt_thanm
        Catch ex As Exception

        End Try

        'Dim bao_lisense_neme As New BAO.ClsDBSqlcommand
        Try
            class_xml.DT_MASTER.DT38 = bao_show.SP_Lisense_Name_and_Addr(_iden) 'ผู้ขออนุญาต
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        Dim DT13 As New DataTable
        Try
            DT13 = class_xml.DT_SHOW.DT13
            For Each drr As DataRow In DT13.Rows
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

        Dim BSN_IDENTIFY As String = ""
        Try
            'If MAIN_LCN_IDA <> 0 Then
            '    Dim dao_lcn2 As New DAO_DRUG.ClsDBdalcn
            '    dao_lcn2.GetDataby_IDA(MAIN_LCN_IDA)
            'End If
            BSN_IDENTIFY = NumEng2Thai(dao.fields.BSN_IDENTIFY)
        Catch ex As Exception

        End Try
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
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(BSN_IDENTIFY) 'ผู้ดำเนิน
        'If MAIN_LCN_IDA <> 0 Then
        '    'ใบย่อย
        '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(MAIN_LCN_IDA) 'ผู้ดำเนิน

        '    'Dim dao_mn As New DAO_DRUG.ClsDBdalcn
        '    'dao_mn.GetDataby_IDA(MAIN_LCN_IDA)
        '    'lcnno_auto = dao_mn.fields.lcnno
        'Else
        Dim dt_bsn As New DataTable
        If dao_tf.fields.STATUS_ID = 8 Then
            dt_bsn = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        Else
            Dim BSN_IDEN As String = ""
            BSN_IDEN = dao.fields.BSN_IDENTIFY
            Dim bao_show11 As New BAO_SHOW
            dt_bsn = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(BSN_IDEN)
            Dim dt_new As New DataTable
            For Each dr As DataRow In dt_bsn.Rows
                Try
                    dr("BSN_THAIFULLNAME") = dao_tf.fields.BSNN_PREFIX_NM & dao_tf.fields.BSN_NAME_NEW
                    dr("THAIFULLNAME") = dao_tf.fields.BSNN_PREFIX_NM & dao_tf.fields.BSN_NAME_NEW
                Catch ex As Exception

                End Try
            Next
        End If
        class_xml.DT_SHOW.DT14 = dt_bsn
        'End If
        Dim dt14 As New DataTable
        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(_IDA)
        Try
            If dao_frgn.fields.addr_status = 0 Or dao_frgn.fields.addr_status = 1 Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_DALCN_CURRENT_ADDRESS(_IDA)
            ElseIf dao_frgn.fields.addr_status = Nothing Then
                class_xml.DT_MASTER.DT39 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA)
            End If

        Catch ex As Exception

        End Try
        'Dim DT39 As New DataTable
        'Try
        '    DT39 = class_xml.DT_MASTER.DT39
        '    For Each drr As DataRow In DT39.Rows
        '        drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
        '        drr("CREATE_DATE") = NumEng2Thai(drr("CREATE_DATE"))
        '        drr("AGE") = NumEng2Thai(drr("AGE"))
        '        drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
        '        drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
        '        drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
        '        'fulladdr
        '    Next
        'Catch ex As Exception

        'End Try
        Try
            dt14 = class_xml.DT_SHOW.DT14
            For Each drr As DataRow In dt14.Rows
                If drr("BSN_THAIFULLNAME") Is Nothing Or drr("BSN_THAIFULLNAME") = "-" Or drr("BSN_THAIFULLNAME") = "" Then
                    drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
                    drr("BSN_THAIFULLNAME") = dao_tf.fields.BSNN_PREFIX_NM & " " & dao_tf.fields.BSN_NAME_NEW
                End If
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA) 'ผู้มีหน้าที่ปฏิบัติการ
        'Dim DT18 As New DataTable

        'DT18 = class_xml.DT_MASTER.DT18
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
        class_xml.DT_SHOW.DT35 = bao_master.SP_DALCN_FRGN_DATA(_IDA)

        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao.fields.IDA)
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
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
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


        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try
        'Try
        '    If Len(lcnno_auto) > 0 Then

        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
        '        Else
        '            lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
        Try
            If dao.fields.REVOCATION Is Nothing Or Trim(dao.fields.REVOCATION) = "" Then
                If Len(lcnno_auto) > 0 Then

                    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        'lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                        lcnno_format = dao.fields.pvnabbr & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                    'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)

                End If

                lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW

            Else

                Dim _type_da As String = ""
                If dao.fields.PROCESS_ID = "120" Then
                    _type_da = "3"
                ElseIf dao.fields.PROCESS_ID = "121" Then
                    _type_da = "2"
                ElseIf dao.fields.PROCESS_ID = "122" Then
                    _type_da = "1"
                End If

                If Not dao.fields.LCNNO_DISPLAY_NEW Is Nothing Then
                    lcnno_format_NEW = dao.fields.LCNNO_DISPLAY_NEW
                    'Try
                    '    Dim App_Date As Date = dao.fields.appdate
                    '    If App_Date > #10/1/2019 12:00:00 AM# Then
                    '        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    '    Else
                    '        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    If dao.fields.STATUS_ID = 8 And dao.fields.lcnno < 1000000 Then
                        lcnno_format = dao.fields.LCNNO_DISPLAY_NEW
                    Else
                        lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                    End If
                    'lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                Else
                    lcnno_format = dao.fields.pvncd & "-" & _type_da & "-" & Left(lcnno_auto, 2) & "-" & Right(lcnno_auto, Len(lcnno_auto) - 2)
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

            Try
                'lcnno_format = 
                'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                    class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                Else
                    class_xml.HEAD_LCNNO = dao_main2.fields.pvnabbr & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                End If

                class_xml.HEAD_LCNNO = NumEng2Thai(class_xml.HEAD_LCNNO)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT32 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT32.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"
        class_xml.DT_MASTER.DT33 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT33.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"

        class_xml.DT_MASTER.DT34 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 3)
        Dim DT34 As New DataTable
        Try
            DT34 = class_xml.DT_MASTER.DT34
            For Each drr As DataRow In DT34.Rows
                drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
                drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
                drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
                drr("PHR_CERTIFICATE_TRAINING1") = NumEng2Thai(drr("PHR_CERTIFICATE_TRAINING1"))
                '
            Next
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT34.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_3_1_ROW"

        Dim rcvno_format As String = ""
        Dim RCV_DATE As String = ""
        Try
            rcvno_format = dao.fields.RCVNO_DISPLAY
            'rcvno_format = dao.fields.RCVNO_NEW
        Catch ex As Exception

        End Try

        Dim rcvdate1 As Date
        Dim rcvdate2 As String = ""
        Try
            If dao.fields.rcvdate IsNot Nothing Then
                rcvdate1 = dao.fields.rcvdate
                rcvdate2 = CDate(rcvdate1).ToString("dd/MM/yyy")
            End If

        Catch ex As Exception

        End Try
        'class_xml.LCNNO_SHOW = lcnno_format
        'class_xml.SHOW_LCNNO = lcnno_text
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        ' If MAIN_LCN_IDA = 0 Then

        'class_xml.LCNNO_SHOW = NumEng2Thai(lcnno_format)  RCVNO_FORMAT
        'class_xml.LCNNO_SHOW_NEW = NumEng2Thai(lcnno_format_NEW)
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.RCVDATE_DISPLAY = rcvdate2
        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.LCNNO_SHOW_NUMTHAI = NumEng2Thai(lcnno_format)
        class_xml.LCNNO_SHOW_NEW = lcnno_format_NEW
        class_xml.LCNNO_SHOW_NEW_NUMTHAI = NumEng2Thai(lcnno_format_NEW)
        class_xml.SHOW_LCNNO = lcnno_text
        class_xml.SHOW_LCNNO_NUMTHAI = NumEng2Thai(lcnno_text)

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
        Else
            If IsNothing(dao.fields.expyear) = False Then
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
        '    Dim cls_DALCN_PHR As New DALCN_PHRi
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        For Each dao_PHR.fields In dao_PHR.Details
            Try
                If dao_PHR.fields.PHR_TEXT_WORK_TIME <> "" Then
                    dao_PHR.fields.PHR_TEXT_WORK_TIME = NumEng2Thai(dao_PHR.fields.PHR_TEXT_WORK_TIME)
                End If
            Catch ex As Exception

            End Try
            class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        Next
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



        Catch ex As Exception

        End Try
        class_xml.dalcns = dao.fields
        Try
            class_xml.dalcns.CATEGORY_DRUG = NumEng2Thai(class_xml.dalcns.CATEGORY_DRUG)
        Catch ex As Exception

        End Try
        Try
            class_xml.dalcns.opentime = dao.fields.opentime
        Catch ex As Exception

        End Try

        class_xml.syslctaddr_engaddr = dao.fields.syslctaddr_engaddr
        class_xml.syslctaddr_floor = dao.fields.syslctaddr_floor
        class_xml.syslctaddr_mu = dao.fields.syslctaddr_mu
        class_xml.syslctaddr_room = dao.fields.syslctaddr_room
        class_xml.syslctaddr_thaaddr = dao.fields.syslctaddr_thaaddr
        class_xml.syslctaddr_thasoi = dao.fields.syslctaddr_thasoi

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
            If dao_tf.fields.STATUS_ID = 8 Then
                class_xml.TRANSFER_DATE = date_to_thai(dao_tf.fields.appdate)
                class_xml.TRANSFER_NAME = dao_tf.fields.TRANSFER_NM
                'class_xml.BSN_THAIFULLNAME = dao_tf.fields.BSN_NAME_NEW
                class_xml.BSN_THAIFULLNAME = GetNameByIdentify(dao_tf.fields.BSN_IDENTIFY)
                'class_xml.TRANSFER_NAME_NEW = dao_tf.fields.TRANSFER_TO
                class_xml.TRANSFER_NAME_NEW = GetNameByIdentify(dao_tf.fields.TRANSFER_TO_ID)
            Else
                'class_xml.TRANSFER_DATE = date_to_thai(Date.Now)
                class_xml.TRANSFER_NAME = dao_tf.fields.TRANSFER_NM
                'class_xml.BSN_THAIFULLNAME = dao_tf.fields.BSN_NAME_NEW
                class_xml.BSN_THAIFULLNAME = GetNameByIdentify(dao_tf.fields.BSN_IDENTIFY)
                'class_xml.TRANSFER_NAME_NEW = dao_tf.fields.TRANSFER_TO
                class_xml.TRANSFER_NAME_NEW = GetNameByIdentify(dao_tf.fields.TRANSFER_TO_ID)
            End If
            If lcnno_format.Contains("HB") Then
                'class_xml.TRANSFER_NAME_NEW = lcnno_format
            Else
                class_xml.LCNNO_DISPAY_OLD = lcnno_format
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

        ' p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dalcn2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_dalcn2)

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = ""
        Try
            lcntype = dao.fields.lcntpcd
        Catch ex As Exception

        End Try

        'Dim url2 As String = "https://medicina.fda.moph.go.th/FDA_DRUG"
        'Dim Cls_qr As New QR_CODE.GEN_QR_CODE
        'Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2)


        lcntype = Chn_lcntpcd(lcntype)
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim template_id As Integer = 0
        If dao_tf.fields.STATUS_ID = 6 Then
            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, "สมพ2", statusId, HiddenField2.Value, _group:=0)
        Else
            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, "สมพ2", statusId, HiddenField2.Value, _group:=0)
        End If


        Dim _PATH_FILE As String = ""
        Dim PDF_TEMPLATE As String = ""
        Dim Path_XML As String = ""
        Dim filename As String = ""
        Dim paths As String = bao._PATH_DEFAULT
        _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_TRANSFER") 'path
        If dao_tf.fields.STATUS_ID = 8 Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
        Else
            _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_LCN_TRANSFER") 'path
            PDF_TEMPLATE = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            filename = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
            Path_XML = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML2("DA", PROCESS_ID, YEAR, _TR_ID, _IDA)
        End If

        Dim url As String = ""

        url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename

        class_xml.QR_CODE = QR_CODE_IMG(url)

        p_dalcn = class_xml


        'Dim p_dalcn2 As New XML_CENTER.CLASS_DALCN
        'p_dalcn2 = p_dalcn

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        'load_pdf(filename)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        'hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
        _CLS.FILENAME_PDF = NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
    End Sub
End Class

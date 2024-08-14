Imports System.Globalization
Imports Telerik.Web.UI
Public Class UC_LCN_EDIT
    Inherits System.Web.UI.UserControl
    Private _IDA As String
    Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _lcn_ida As String

    Shared _phr_ida As String
    Private _year As String
    Private _STATUS_ID As Integer
    Private _STAFF_ID As Integer
    Shared _TR_ID As String
    Shared _detial_type As Integer
    Shared _dd1_file As Integer
    Shared _SEE_DETAIL_LCN_IDA As Integer
    Shared _SEE_DETAIL_LCT_IDA As Integer
    Shared _SEE_DETAIL_ddl1 As Integer
    Shared _SEE_DETAIL_ddl2 As Integer

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

        _ProcessID = Request.QueryString("process")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        _IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("LCN_IDA")
        _STAFF_ID = Request.QueryString("staff")
        Dim date_full_now As DateTime
        date_full_now = System.DateTime.Now
        _year = date_full_now.Year

        _STATUS_ID = Request.QueryString("STATUS_ID")

        'เช็คว่าเป็น ดูข้อมูล หรือ แก้ไข ; 1=ดูข้อมูล 2=แก้ไข
        _detial_type = Request.QueryString("detail")
        _TR_ID = Request.QueryString("TR_ID_LCN_EDIT")
        _dd1_file = Request.QueryString("LCN_EDIT_REASON_TYPE")

        _SEE_DETAIL_LCN_IDA = Request.QueryString("SEE_DETAIL_LCN_IDA")
        _SEE_DETAIL_LCT_IDA = Request.QueryString("SEE_DETAIL_LCT_IDA")
        _SEE_DETAIL_ddl1 = Request.QueryString("ddl_up1")
        _SEE_DETAIL_ddl2 = Request.QueryString("ddl_up2")



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        Set_Label(_iden)
        '
        'Set_ddl_type()
        set_txt_label()

        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        'เจ้าหน้าที่ทำแทน ผปก
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        dao.GetDataBY_IDA_LCN_IDA_LCN_EDIT_REASON_TYPE(_IDA, _lcn_ida, _dd1_file, True)

        Dim ddl1 As Integer = 0
        Dim ddl2 As Integer = 0
        Dim note As String = ""

        Try
            ddl1 = dao.fields.LCN_EDIT_REASON_TYPE
        Catch ex As Exception
            ddl1 = 0
        End Try

        Try
            ddl2 = dao.fields.FK_SUB_REASON_TYPE
        Catch ex As Exception
            ddl2 = 0
        End Try
        Try
            note = dao.fields.NOTE_REASON
        Catch ex As Exception
            note = ""
        End Try


        'For Each dr As DataRow In dt.Rows

        '    ddl1 = dr("LCN_EDIT_REASON_TYPE")
        '    Try
        '        ddl2 = dr("FK_SUB_REASON_TYPE")
        '    Catch ex As Exception
        '        ddl2 = 0
        '    End Try
        '    note = dr("NOTE_REASON")
        'Next

        If Not IsPostBack Then
            bind_ddl_prefix()

            If _ProcessID = "122" Then
                rdl_lcn_type.SelectedValue = "1"
            ElseIf _ProcessID = "121" Then
                rdl_lcn_type.SelectedValue = "2"
            ElseIf _ProcessID = "120" Then
                rdl_lcn_type.SelectedValue = "3"
            End If

            dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_lcn_ida, 2)

            'If dt.Rows.Count <> 0 Then
            '    bind_detail(ddl1, ddl2, note)
            'Else
            '    bind_reason()
            'End If

            If _detial_type = 0 Then

                bind_reason()
                Dim ddl1_add As Integer = 0
                Dim ddl2_add As Integer = 0

                UC_LCN_EDIT_TOPIC_2_DDL3.load_ddl_chwt()

                'bind_reason()
                'lb1.Visible = True
                'DDL_EDIT_REASON.Visible = True
                'Try
                '    ddl1_add = DDL_EDIT_REASON.SelectedValue
                '    'DDL_EDIT_REASON.SelectedValue = ddl1
                'Catch ex As Exception

                'End Try

                'Try
                '    ddl2_add = DDL_EDIT_REASON.SelectedValue
                'Catch ex As Exception
                '    ddl2_add = 0
                'End Try
                'Try
                '    bind_detail(ddl1_add, ddl2_add, "")
                'Catch ex As Exception

                'End Try



                'If DDL_EDIT_REASON.SelectedValue <> "กรุณาเลือก" Then
                '    If DDL_EDIT_REASON_SUB.SelectedValue <> "กรุณาเลือก" Then
                '        BindTable(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
                '    Else
                '        BindTable(DDL_EDIT_REASON.SelectedValue, 0)
                '    End If
                'End If

            End If
            If ddl1 <> 0 Then
                bind_detail(ddl1, ddl2, note)
                'bind_reason()
            End If

            If _IDA <> 0 Then
                btn_save.Visible = False
            Else
                btn_save.Visible = True
            End If

        End If

        _CLS_CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        _CLS_CITIZEN_ID = _CLS.CITIZEN_ID
        _CLS_THANM = _CLS.THANM

        'ต้องใส่ตรงนี้ ไม่งั้นเซฟ table chk ไม่ได้
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5.bind_type(_lcn_ida)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5.bind_table_ddl5(_lcn_ida, ddl1, ddl2, _detial_type)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL10.bind_type(_lcn_ida)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL10.bind_table_ddl10(_lcn_ida, ddl1, ddl2, _detial_type)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11.bind_type(_lcn_ida)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11.bind_table_ddl11(_lcn_ida, ddl1, ddl2, _detial_type)


        'bind_type_CHK_BOX(_lcn_ida)
        'bind_table_CHK_BOX(_lcn_ida)

    End Sub





    Public Function bind_detail(ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal note_reason As String) 'ถ้าเคยยยื่นเรื่องคำขอแก้ไขแล้วให้ bind ข้อมูลขึ้นมา


        lb1.Visible = True
        DDL_EDIT_REASON_SUB.Visible = True

        'ส่งค่ามา bind dropdown ด้วย

        bind_reason()
        DDL_EDIT_REASON.SelectedValue = ddl1
        If ddl1 <> 0 Then
            bind_reason_sub(DDL_EDIT_REASON.SelectedValue)
        End If

        DDL_EDIT_REASON_SUB.SelectedValue = ddl2

        'p1.Visible = True 'เปิด upload-file
        'BindTable(ddl1, ddl2)

        GET_DDL_REASON_DETAIL(ddl1, ddl2)


        txt_reason_name.Text = note_reason
    End Function
    Public Sub bind_reason()
        Dim bao_show As New BAO_SHOW
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DDL_REASON()

        DDL_EDIT_REASON.DataSource = dt
        DDL_EDIT_REASON.DataBind()

        DDL_EDIT_REASON.Items.Insert(0, "กรุณาเลือก")

    End Sub
    Public Sub bind_reason_sub(ByVal IDA As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DDL_REASON_SUB(IDA)

        DDL_EDIT_REASON_SUB.DataSource = dt
        DDL_EDIT_REASON_SUB.DataBind()

        DDL_EDIT_REASON_SUB.Items.Insert(0, "กรุณาเลือก")




    End Sub

    'Public Sub Set_ddl_type()
    '    If ddl_sub_purpose.DataValueField = "1" Then
    '        Panel1.Style.Add("display", "block")
    '        Panel2.Style.Add("display", "none")
    '    ElseIf ddl_sub_purpose.SelectedValue = "2" Then
    '        Panel1.Style.Add("display", "none")
    '        Panel2.Style.Add("display", "block")
    '    Else
    '        Panel1.Style.Add("display", "none")
    '        Panel2.Style.Add("display", "none")
    '    End If
    'End Sub
    Public Sub set_txt_label()

        'uc102_3.get_label("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร")

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
                txt_sub_addr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_floor.Text = dr("floor")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_room.Text = dr("room")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_ages.Text = dr("age")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_amphor.Text = dr("amphrnm")
            Catch ex As Exception

            End Try
            Try
                txt_sub_building.Text = dr("building")
            Catch ex As Exception

            End Try
            Try
                txt_sub_changwat.Text = dr("chngwtnm")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_email.Text = dr("email")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_fax.Text = dr("fax")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_iden2.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_mu.Text = dr("mu")
            Catch ex As Exception

            End Try
            Try
                txt_sub_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
            'Try
            '    txt_sub_nation.Text = dr("nation")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_road.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                txt_sub_soi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                txt_sub_tambol.Text = dr("thmblnm")
            Catch ex As Exception

            End Try
            Try
                txt_sub_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                txt_sub_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next

        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(_lcn_ida)
        txt_sub_opentime.Text = dao_main.fields.opentime
        txt_sub_location.Text = dao_main.fields.LOCATION_ADDRESS_thanameplace
        txt_sub_lcnno.Text = dao_main.fields.LCNNO_DISPLAY_NEW

        '''เพิ่ม 20210831
        '_TR_ID = dao_main.fields.TR_ID

        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(_lcn_ida)
        If dao_phr.fields.PHR_NAME = Nothing Then
            txt_sub_phr_name.Text = "-"
        Else
            txt_sub_phr_name.Text = dao_phr.fields.PHR_NAME
        End If

        'Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        'dao_bsn.GetDataby_LCN_IDA(_lcn_ida)
        'If dao_bsn.fields.BSN_THAIFULLNAME = Nothing Then
        '    txt_bsn_name.Text = "-"
        'Else
        '    txt_bsn_name.Text = dao_bsn.fields.BSN_THAIFULLNAME
        'End If
    End Sub

    Public Function get_dt_edit()
        Dim bao_show As New BAO_SHOW
        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(_lcn_ida, 2)

        Return dt
    End Function


    Sub save_data(ByRef dao As DAO_LCN.TB_LCN_APPROVE_EDIT)


        Dim dao_log As New DAO_LCN.TB_LOG_STATUS_LCN_EDIT
        dao_log.fields.STATUS_ID = 0
        dao_log.fields.PROCESS_ID = 10201
        dao_log.fields.STATUS_DATE = System.DateTime.Now
        dao_log.fields.IDENTIFY = _CLS_CITIZEN_ID
        dao_log.fields.NAME = _CLS_THANM
        dao_log.fields.FK_IDA = _lcn_ida
        dao_log.insert()

        Dim get_reson_type As Integer = 0
        'เลขดำเนินการ รันใหม่
        Dim TR_ID As String = ""
        'Dim bao_tran As New BAO_LCN_TRANSECTION
        Dim bao_tran As New BAO_TRANSECTION
        Dim _YEAR As String = con_year(Date.Now().Year())
        'dao.GetDataBY_LCN_IDA_LCN_EDIT_REASON_TYPE_YEAR(_lcn_ida, DDL_EDIT_REASON.SelectedValue, _YEAR, True)
        dao.GetDataBY_IDA_LCN_IDA_LCN_EDIT_REASON_TYPE(_IDA, _lcn_ida, _dd1_file, True)
        Try
            get_reson_type = dao.fields.LCN_EDIT_REASON_TYPE
        Catch ex As Exception
            get_reson_type = 0
        End Try




        If get_reson_type = DDL_EDIT_REASON.SelectedValue Then

            TR_ID = bao_tran.insert_transection(_ProcessID)
            dao.fields.TR_ID = TR_ID
            dao.fields.NOTE_REASON = txt_reason_name.Text

            dao.fields.UPDATE_DATE = System.DateTime.Now
            dao.update()
        Else
            dao.fields.FK_LCN_IDA = _lcn_ida
            dao.fields.FK_LOCATION_IDA = _lct_ida
            dao.fields.STAFF_TYPE = _STAFF_ID
            'dao.fields.STAFF_NAME = _STAFF_NAME



            TR_ID = bao_tran.insert_transection(_ProcessID)
            dao.fields.TR_ID = TR_ID

            dao.fields.LCN_PROCESS_ID = 10201


            'dao.fields.TR_ID = _tr_id

            dao.fields.LCN_EDIT_REASON_TYPE = DDL_EDIT_REASON.SelectedValue
            dao.fields.LCN_EDIT_REASON_NAME = DDL_EDIT_REASON.SelectedItem.Text
            Try
                dao.fields.FK_SUB_REASON_TYPE = DDL_EDIT_REASON_SUB.SelectedValue
            Catch ex As Exception

            End Try
            Try
                dao.fields.FK_SUB_REASON_NAME = DDL_EDIT_REASON_SUB.SelectedItem.Text
            Catch ex As Exception

            End Try

            dao.fields.DATE_YEAR = con_year(Date.Now().Year())

            dao.fields.NOTE_REASON = txt_reason_name.Text

            Try
                dao.fields.LCN_TYPE_ID = rdl_lcn_type.SelectedValue
            Catch ex As Exception

            End Try

            Try
                dao.fields.LCN_TYPE_NAME = rdl_lcn_type.SelectedItem.Text
            Catch ex As Exception

            End Try
            dao.fields.LCN_NAME = txt_sub_name.Text
            dao.fields.LCN_NAME_SUB = txt_sub_phr_name.Text
            dao.fields.LCN_IDENTIFY = txt_sub_iden.Text
            dao.fields.LCNNO = txt_sub_lcnno.Text
            dao.fields.LCN_LOCATION = txt_sub_location.Text
            dao.fields.ADDR_NUM = txt_sub_addr.Text
            dao.fields.ADDR_BUILDING = txt_sub_building.Text
            dao.fields.ADDR_MOO = txt_sub_mu.Text
            dao.fields.ADDR_SOI = txt_sub_soi.Text
            dao.fields.ADDR_ROAD = txt_sub_road.Text
            dao.fields.ADDR_TAMBON = txt_sub_tambol.Text
            dao.fields.ADDR_AMPHOR = txt_sub_amphor.Text
            dao.fields.ADDR_CHANGWAT = txt_sub_changwat.Text
            dao.fields.ADDR_ZIPCODE = txt_sub_zipcode.Text
            dao.fields.ADDR_TEL = txt_sub_tel.Text
            dao.fields.LCN_OPENTIME = txt_sub_opentime.Text

            dao.fields.STATUS_ID = 0
            dao.fields.STATUS_NAME = "บันทึกคำขอรอส่งเรื่อง"

            dao.fields.ACTIVE = 1
            dao.fields.CREATE_DATE = System.DateTime.Now
            dao.fields.CREATE_BY = ""

            dao.insert()


        End If




    End Sub

    Sub GET_DDL_REASON_DETAIL(ByVal DDL_VALUE As Integer, ByVal DDL_SUB_VALUE As Integer)
        If _detial_type = 0 Then 'เพิ่มข้อมูล
            If DDL_VALUE = 1 Then
                SET_DATA_REASON_DDL1()
            ElseIf DDL_VALUE = 2 Or DDL_VALUE = 12 Then
                UC_LCN_EDIT_TOPIC_3_DDL2.SET_DATA_REASON_DDL2(_lct_ida, _lcn_ida)
            ElseIf DDL_VALUE = 3 Then
                If DDL_SUB_VALUE = 1 Then
                    UC_LCN_EDIT_TOPIC_2_DDL3.SET_DATA_REASON_TOPIC2(_lcn_ida)
                ElseIf DDL_SUB_VALUE = 2 Then
                    SET_DATA_REASON_DDL3_SUB2()
                End If
            ElseIf DDL_VALUE = 4 Then
                SET_DATA_REASON_DDL4()
            ElseIf DDL_VALUE = 5 Then
                SET_DATA_REASON_DDL5()
            ElseIf DDL_VALUE = 6 Then
                UC_LCN_EDIT_TOPIC_3_DDL6.SET_DATA_REASON_DDL2(_lct_ida, _lcn_ida)
            ElseIf DDL_VALUE = 7 Then
                SET_DATA_REASON_DDL7()
            ElseIf DDL_VALUE = 8 Then
                SET_DATA_REASON_DDL8()
            ElseIf DDL_VALUE = 9 Then
                If DDL_SUB_VALUE = 1 Then
                    SET_DATA_REASON_DDL9_SUB1()
                ElseIf DDL_SUB_VALUE = 2 Then
                    SET_DATA_REASON_DDL9_SUB2()
                ElseIf DDL_SUB_VALUE = 3 Then
                    UC_LCN_EDIT_TOPIC_2_DD9_SUB3.SET_DATA_REASON_TOPIC2(_lcn_ida)
                End If
            ElseIf DDL_VALUE = 10 Then
                'bind on PageLoad
            ElseIf DDL_VALUE = 11 Then
                'bind on PageLoad
            End If
        ElseIf _detial_type = 1 Then 'ดูข้อมูลที่มี
            If DDL_VALUE = 1 Then
                SET_DATA_REASON_DDL1()
                edit_dd1.Visible = True
            ElseIf DDL_VALUE = 2 Or DDL_VALUE = 12 Then
                UC_LCN_EDIT_TOPIC_3_DDL2.SET_DATA_SEE_DETAIL_DDL2(_lct_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
                edit_dd2.Visible = True
            ElseIf DDL_VALUE = 3 Then
                If DDL_SUB_VALUE = 1 Then
                    UC_LCN_EDIT_TOPIC_2_DDL3.SET_DATA_SEE_DETAIL_DDL3(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
                    edit_dd3_sub1.Visible = True
                ElseIf DDL_SUB_VALUE = 2 Then
                    SET_DATA_REASON_DDL3_SUB2()
                    edit_dd3_sub2.Visible = True
                End If
            ElseIf DDL_VALUE = 4 Then
                SET_DATA_REASON_DDL4()
                edit_dd4.Visible = True
            ElseIf DDL_VALUE = 5 Then
                SET_DATA_REASON_DDL5()
                edit_dd5.Visible = True
            ElseIf DDL_VALUE = 6 Then
                UC_LCN_EDIT_TOPIC_3_DDL6.SET_DATA_SEE_DETAIL_DDL6(_lct_ida)
                edit_dd6.Visible = True
            ElseIf DDL_VALUE = 7 Then
                SET_DATA_REASON_DDL7()
                edit_dd7.Visible = True
            ElseIf DDL_VALUE = 8 Then
                SET_DATA_REASON_DDL8()
                edit_dd8.Visible = True
            ElseIf DDL_VALUE = 9 Then
                If DDL_SUB_VALUE = 1 Then
                    SET_DATA_REASON_DDL9_SUB1()
                    edit_dd9_sub1.Visible = True
                ElseIf DDL_SUB_VALUE = 2 Then
                    SET_DATA_REASON_DDL9_SUB2()
                    edit_dd9_sub2.Visible = True
                ElseIf DDL_SUB_VALUE = 3 Then
                    UC_LCN_EDIT_TOPIC_2_DD9_SUB3.SET_DATA_REASON_TOPIC2(_lcn_ida)
                    edit_dd9_sub3.Visible = True
                End If
            ElseIf DDL_VALUE = 10 Then
                'SET_DATA_REASON_DDL10()
                edit_dd10.Visible = True
            ElseIf DDL_VALUE = 11 Then
                'SET_DATA_REASON_DDL11()
                edit_dd11.Visible = True
            End If
        End If

    End Sub
    Sub save_data_DDL()
        If DDL_EDIT_REASON.SelectedValue = 1 Then
            SET_DATA_INSERT_REASON1()
        ElseIf DDL_EDIT_REASON.SelectedValue = 2 Then
            UC_LCN_EDIT_TOPIC_3_DDL2.SET_DATA_INSERT_REASON_DDL2(_lct_ida, _lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue, _detial_type)
        ElseIf DDL_EDIT_REASON.SelectedValue = 3 Then
            If DDL_EDIT_REASON_SUB.SelectedValue = 1 Then
                UC_LCN_EDIT_TOPIC_2_DDL3.SET_DATA_INSERT_REASON_DDL3_SUB1(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue, _detial_type)
            ElseIf DDL_EDIT_REASON_SUB.SelectedValue = 2 Then
                SET_DATA_INSERT_REASON3_SUB2(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            End If
        ElseIf DDL_EDIT_REASON.SelectedValue = 4 Then
            SET_DATA_INSERT_REASON4()
        ElseIf DDL_EDIT_REASON.SelectedValue = 5 Then
            SET_DATA_INSERT_REASON5(DDL_EDIT_REASON.SelectedValue, 0)
            UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5.save_data_OLD_ddl5(_lcn_ida, DDL_EDIT_REASON.SelectedValue, 0)
            UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5.save_data_ddl5(_lcn_ida, DDL_EDIT_REASON.SelectedValue, 0)
        ElseIf DDL_EDIT_REASON.SelectedValue = 6 Then
            UC_LCN_EDIT_TOPIC_3_DDL6.SET_DATA_INSERT_REASON_DDL6(_detial_type, _lct_ida, _lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
        ElseIf DDL_EDIT_REASON.SelectedValue = 7 Then
            SET_DATA_INSERT_REASON7(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
        ElseIf DDL_EDIT_REASON.SelectedValue = 8 Then
            SET_DATA_INSERT_REASON8(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
        ElseIf DDL_EDIT_REASON.SelectedValue = 9 Then
            If DDL_EDIT_REASON_SUB.SelectedValue = 1 Then
                SET_DATA_INSERT_REASON_DDL9_SUB1(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            ElseIf DDL_EDIT_REASON_SUB.SelectedValue = 2 Then
                SET_DATA_INSERT_REASON_DDL9_SUB2(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            End If
        ElseIf DDL_EDIT_REASON.SelectedValue = 10 Then
            UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL10.save_data_OLD_ddl10(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL10.save_data_ddl10(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
        ElseIf DDL_EDIT_REASON.SelectedValue = 11 Then
            UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11.save_data_OLD_ddl11(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11.save_data_ddl11(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
        ElseIf DDL_EDIT_REASON.SelectedValue = 12 Then
            UC_LCN_EDIT_TOPIC_3_DDL2.SET_DATA_INSERT_REASON_DDL2(_lct_ida, _lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue, _detial_type)
        End If
    End Sub


    Sub SET_DATA_REASON_DDL1()

        If _detial_type = 0 Then
            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_FK_LCN_ACTIVE(_lcn_ida, True)

            text_edit_ddl1_PHR_TEXT_JOB.Text = dao_phr.fields.PHR_TEXT_JOB
            text_edit_ddl1_PHR_TEXT_NUM.Text = dao_phr.fields.PHR_TEXT_NUM
            text_edit_ddl1_STUDY_LEVEL.Text = dao_phr.fields.STUDY_LEVEL
            text_edit_ddl1_PHR_SAKHA.Text = dao_phr.fields.PHR_VETERINARY_FIELD
            'text_edit_ddl1_PHR_SAKHA.Text = dao_phr.fields.PHR_SAKHA
            text_edit_ddl1_NAME_SIMINAR.Text = dao_phr.fields.NAME_SIMINAR
            '12/10/2564
            Dim datefull_siminar As Date
            Dim SIMINAR_DATE As String = ""
            Try
                datefull_siminar = DateTime.ParseExact(dao_phr.fields.SIMINAR_DATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                SIMINAR_DATE = datefull_siminar.Day & "/" & datefull_siminar.Month & "/" & datefull_siminar.Year
                text_edit_ddl1_SIMINAR_DATE.Text = SIMINAR_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
        ElseIf _detial_type = 1 Then
            Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
            dao1.GET_DATA_BY_FK_LCN_IDA(_lcn_ida, True)
            text_edit_ddl1_PHR_TEXT_JOB.Text = dao1.fields.PHR_TEXT_JOB

            text_edit_ddl1_PHR_TEXT_NUM.Text = dao1.fields.PHR_TEXT_NUM
            text_edit_ddl1_STUDY_LEVEL.Text = dao1.fields.STUDY_LEVEL
            text_edit_ddl1_PHR_SAKHA.Text = dao1.fields.PHR_SAKHA
            text_edit_ddl1_NAME_SIMINAR.Text = dao1.fields.NAME_SIMINAR
            text_edit_ddl1_SIMINAR_DATE.Text = dao1.fields.SIMINAR_DATE

        End If




    End Sub

    Sub SET_DATA_REASON_DDL3_SUB2()
        If _detial_type = 0 Then
            Dim dao1 As New DAO_DRUG.ClsDBdalcn
            dao1.GetDataby_IDA(_lcn_ida)


            text_edit_ddl3_sub2_GIVE_PASSPORT_NO.Text = dao1.fields.GIVE_PASSPORT_NO

            Dim datefull_PASSPORT_EXPDATE As Date
            Dim PASSPORT_EXPDATE As String = ""

            Try
                datefull_PASSPORT_EXPDATE = DateTime.ParseExact(dao1.fields.GIVE_PASSPORT_EXPDATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                PASSPORT_EXPDATE = datefull_PASSPORT_EXPDATE.Day & "/" & datefull_PASSPORT_EXPDATE.Month & "/" & datefull_PASSPORT_EXPDATE.Year
                text_edit_ddl3_sub2_GIVE_PASSPORT_EXPDATE.Text = PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl3_sub2_GIVE_WORK_LICENSE_NO.Text = dao1.fields.GIVE_WORK_LICENSE_NO

            Dim datefull_GIVE_WORK_LICENSE_EXPDATE As Date
            Dim WORK_LICENSE_EXPDATE As String = ""

            Try
                datefull_GIVE_WORK_LICENSE_EXPDATE = DateTime.ParseExact(dao1.fields.GIVE_WORK_LICENSE_EXPDATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                WORK_LICENSE_EXPDATE = datefull_GIVE_WORK_LICENSE_EXPDATE.Day & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Month & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Year
                text_edit_ddl3_sub2_GIVE_WORK_LICENSE_EXPDATE.Text = WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
        ElseIf _detial_type = 1 Then
            Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
            dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue, True)

            text_edit_ddl3_sub2_GIVE_PASSPORT_NO.Text = dao1.fields.GIVE_PASSPORT_NO

            text_edit_ddl3_sub2_GIVE_PASSPORT_EXPDATE.Text = dao1.fields.GIVE_PASSPORT_EXPDATE
            text_edit_ddl3_sub2_GIVE_WORK_LICENSE_NO.Text = dao1.fields.GIVE_WORK_LICENSE_NO
            text_edit_ddl3_sub2_GIVE_WORK_LICENSE_EXPDATE.Text = dao1.fields.GIVE_WORK_LICENSE_EXPDATE


        End If

    End Sub
    Sub SET_DATA_REASON_DDL4()
        If _detial_type = 0 Then
            Dim dao_main As New DAO_DRUG.ClsDBdalcn
            dao_main.GetDataby_IDA(_lcn_ida)
            text_edit_ddl4_opentime.Text = dao_main.fields.opentime
        ElseIf _detial_type = 1 Then
            Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL4_REASON
            dao1.GET_DATA_BY_FK_LCN_IDA(_lcn_ida, True)
            text_edit_ddl4_opentime.Text = dao1.fields.opentime
        End If

    End Sub
    Sub SET_DATA_REASON_DDL5()
        If _detial_type = 0 Then
            Dim dao1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao1.GetDataby_IDA(_lct_ida)


            text_edit_ddl5_tel.Text = dao1.fields.tel
            text_edit_ddl5_email.Text = "" 'รอเพิ่มฟิว

            'สถานที่เก็บ
            Dim dao2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            dao2.GetData_by_LOCATION_ADDRESS_IDA_AND_LCN_IDA(_lct_ida, _lcn_ida)


            text_edit_ddl5_KEEP_tel.Text = dao2.fields.LOCATION_ADDRESS_tel
            text_edit_ddl5_KEEP_email.Text = "" 'รอเพิ่มฟิว
        ElseIf _detial_type = 1 Then
            Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON
            dao_get.GET_DATA_BY_FK_LCN_IDA(_lct_ida, True)

            text_edit_ddl5_tel.Text = dao_get.fields.tel
            text_edit_ddl5_email.Text = dao_get.fields.email
            text_edit_ddl5_KEEP_tel.Text = dao_get.fields.KEEP_tel
            text_edit_ddl5_KEEP_email.Text = dao_get.fields.KEEP_email

        End If






    End Sub

    Sub SET_DATA_REASON_DDL7()
        If _detial_type = 0 Then
            Dim dao_main As New DAO_DRUG.ClsDBdalcn
            dao_main.GetDataby_IDA(_lcn_ida)
            text_edit_ddl7_dalcn_BSN_THAIFULLNAME.Text = dao_main.fields.BSN_THAIFULLNAME

            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.GetDataby_LCN_IDA(_lcn_ida)
            text_edit_ddl7_BSN_THAIFULLNAME.Text = dao_bsn.fields.BSN_THAIFULLNAME

            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_FK_IDA(_lcn_ida)
            text_edit_ddl7_PHR_TEXT_JOB.Text = dao_phr.fields.PHR_TEXT_JOB
        ElseIf _detial_type = 1 Then
            Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL7_REASON
            dao_get.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue, True)

            text_edit_ddl7_dalcn_BSN_THAIFULLNAME.Text = dao_get.fields.DALCN_BSN_THAIFULLNAME
            text_edit_ddl7_BSN_THAIFULLNAME.Text = dao_get.fields.BSN_THAIFULLNAME
            text_edit_ddl7_PHR_TEXT_JOB.Text = dao_get.fields.PHR_TEXT_JOB
        End If

    End Sub
    Sub SET_DATA_REASON_DDL8()
        If _detial_type = 0 Then
            Dim dao1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao1.GetDataby_IDA(_lct_ida)
            text_edit_ddl8_thanameplace.Text = dao1.fields.thanameplace
            text_edit_ddl8_HOUSENO.Text = dao1.fields.HOUSENO
            text_edit_ddl8_thaaddr.Text = dao1.fields.thaaddr
            text_edit_ddl8_thabuilding.Text = dao1.fields.thabuilding
        ElseIf _detial_type = 1 Then
            Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL8_REASON
            dao_get.GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(_lct_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue, True)

            text_edit_ddl8_thanameplace.Text = dao_get.fields.thanameplace
            text_edit_ddl8_HOUSENO.Text = dao_get.fields.HOUSENO
            text_edit_ddl8_thaaddr.Text = dao_get.fields.thaaddr
            text_edit_ddl8_thabuilding.Text = dao_get.fields.thabuilding
        End If

    End Sub
    Sub SET_DATA_REASON_DDL9_SUB1()

        If _detial_type = 0 Then
            Dim dao1 As New DAO_DRUG.TB_DALCN_FRGN_DATA
            dao1.GetDataby_FK_IDA_AND_PERSON_TYPE(_lcn_ida, 1)
            text_edit_ddl9_sub1_PASSPORT_NO.Text = dao1.fields.PASSPORT_NO

            Dim datefull_PASSPORT_EXPDATE As Date
            Dim PASSPORT_EXPDATE As String = ""

            Try
                datefull_PASSPORT_EXPDATE = DateTime.ParseExact(dao1.fields.PASSPORT_EXPDATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                PASSPORT_EXPDATE = datefull_PASSPORT_EXPDATE.Day & "/" & datefull_PASSPORT_EXPDATE.Month & "/" & datefull_PASSPORT_EXPDATE.Year
                text_edit_ddl9_sub1_PASSPORT_EXPDATE.Text = PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub1_BS_NO.Text = dao1.fields.BS_NO
            Dim datefull_BS_DATE As Date
            Dim BS_DATE As String = ""

            Try
                datefull_BS_DATE = DateTime.ParseExact(dao1.fields.BS_DATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                BS_DATE = datefull_BS_DATE.Day & "/" & datefull_BS_DATE.Month & "/" & datefull_BS_DATE.Year
                text_edit_ddl9_sub1_BS_DATE.Text = BS_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub1_WORK_LICENSE_NO.Text = dao1.fields.WORK_LICENSE_NO
            Dim datefull_WORK_LICENSE_EXPDATE As Date
            Dim WORK_LICENSE_EXPDATE As String = ""

            Try
                datefull_WORK_LICENSE_EXPDATE = DateTime.ParseExact(dao1.fields.WORK_LICENSE_EXPDATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                WORK_LICENSE_EXPDATE = datefull_WORK_LICENSE_EXPDATE.Day & "/" & datefull_WORK_LICENSE_EXPDATE.Month & "/" & datefull_WORK_LICENSE_EXPDATE.Year
                text_edit_ddl9_sub1_WORK_LICENSE_EXPDATE.Text = WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub1_DOC_NO.Text = dao1.fields.DOC_NO
            Dim datefull_DOC_DATE As Date
            Dim DOC_DATE As String = ""

            Try
                datefull_DOC_DATE = DateTime.ParseExact(dao1.fields.DOC_DATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                DOC_DATE = datefull_DOC_DATE.Day & "/" & datefull_DOC_DATE.Month & "/" & datefull_DOC_DATE.Year
                text_edit_ddl9_sub1_DOC_DATE.Text = DOC_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub1_FRGN_NO.Text = dao1.fields.FRGN_NO
            Dim datefull_FRGN_DATE As Date
            Dim FRGN_DATE As String = ""

            Try
                datefull_FRGN_DATE = DateTime.ParseExact(dao1.fields.FRGN_DATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                FRGN_DATE = datefull_FRGN_DATE.Day & "/" & datefull_FRGN_DATE.Month & "/" & datefull_FRGN_DATE.Year
                text_edit_ddl9_sub1_FRGN_DATE.Text = FRGN_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
        ElseIf _detial_type = 1 Then
            Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
            dao_get.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue, True)

            text_edit_ddl9_sub1_PASSPORT_NO.Text = dao_get.fields.PASSPORT_NO
            text_edit_ddl9_sub1_PASSPORT_EXPDATE.Text = dao_get.fields.PASSPORT_EXPDATE
            text_edit_ddl9_sub1_BS_NO.Text = dao_get.fields.BS_NO
            text_edit_ddl9_sub1_BS_DATE.Text = dao_get.fields.BS_DATE
            text_edit_ddl9_sub1_WORK_LICENSE_NO.Text = dao_get.fields.WORK_LICENSE_NO
            text_edit_ddl9_sub1_WORK_LICENSE_EXPDATE.Text = dao_get.fields.WORK_LICENSE_EXPDATE
            text_edit_ddl9_sub1_DOC_NO.Text = dao_get.fields.DOC_NO
            text_edit_ddl9_sub1_DOC_DATE.Text = dao_get.fields.DOC_DATE
            text_edit_ddl9_sub1_FRGN_NO.Text = dao_get.fields.FRGN_NO
            text_edit_ddl9_sub1_FRGN_DATE.Text = dao_get.fields.FRGN_DATE

        End If


    End Sub
    Sub SET_DATA_REASON_DDL9_SUB2()
        If _detial_type = 0 Then
            Dim dao1 As New DAO_DRUG.TB_DALCN_FRGN_DATA
            dao1.GetDataby_FK_IDA_AND_PERSON_TYPE(_lcn_ida, 2)
            text_edit_ddl9_sub2_DOC_NO.Text = dao1.fields.DOC_NO
            Dim datefull_DOC_DATE As Date
            Dim DOC_DATE As String = ""

            Try
                datefull_DOC_DATE = DateTime.ParseExact(dao1.fields.DOC_DATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                DOC_DATE = datefull_DOC_DATE.Day & "/" & datefull_DOC_DATE.Month & "/" & datefull_DOC_DATE.Year
                text_edit_ddl9_sub2_DOC_DATE.Text = DOC_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
            text_edit_ddl9_sub2_FRGN_NO.Text = dao1.fields.FRGN_NO
            Dim datefull_FRGN_DATE As Date
            Dim FRGN_DATE As String = ""

            Try
                datefull_FRGN_DATE = DateTime.ParseExact(dao1.fields.FRGN_DATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                FRGN_DATE = datefull_FRGN_DATE.Day & "/" & datefull_FRGN_DATE.Month & "/" & datefull_FRGN_DATE.Year
                text_edit_ddl9_sub2_FRGN_DATE.Text = FRGN_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            Dim dao2 As New DAO_DRUG.ClsDBdalcn
            dao2.GetDataby_IDA(_lcn_ida)

            text_edit_ddl9_sub2_GIVE_PASSPORT_NO.Text = dao2.fields.GIVE_PASSPORT_NO
            Dim datefull_GIVE_PASSPORT_EXPDATE As Date
            Dim GIVE_PASSPORT_EXPDATE As String = ""

            Try
                datefull_GIVE_PASSPORT_EXPDATE = DateTime.ParseExact(dao2.fields.GIVE_PASSPORT_EXPDATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                GIVE_PASSPORT_EXPDATE = datefull_GIVE_PASSPORT_EXPDATE.Day & "/" & datefull_GIVE_PASSPORT_EXPDATE.Month & "/" & datefull_GIVE_PASSPORT_EXPDATE.Year
                text_edit_ddl9_sub2_GIVE_PASSPORT_EXPDATE.Text = GIVE_PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub2_GIVE_WORK_LICENSE_NO.Text = dao2.fields.GIVE_WORK_LICENSE_NO
            Dim datefull_GIVE_WORK_LICENSE_EXPDATE As Date
            Dim GIVE_WORK_LICENSE_EXPDATE As String = ""

            Try
                datefull_GIVE_WORK_LICENSE_EXPDATE = DateTime.ParseExact(dao2.fields.GIVE_WORK_LICENSE_EXPDATE, "dd/MM/yyyy", New CultureInfo("en-US").DateTimeFormat)
                GIVE_WORK_LICENSE_EXPDATE = datefull_GIVE_WORK_LICENSE_EXPDATE.Day & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Month & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Year
                text_edit_ddl9_sub2_GIVE_WORK_LICENSE_EXPDATE.Text = GIVE_WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
        Else _detial_type = 1
            Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
            dao_get.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue, True)

            text_edit_ddl9_sub2_DOC_NO.Text = dao_get.fields.DOC_NO
            text_edit_ddl9_sub2_DOC_DATE.Text = dao_get.fields.DOC_DATE
            text_edit_ddl9_sub2_FRGN_NO.Text = dao_get.fields.FRGN_NO
            text_edit_ddl9_sub2_FRGN_DATE.Text = dao_get.fields.FRGN_DATE
            text_edit_ddl9_sub2_GIVE_PASSPORT_NO.Text = dao_get.fields.GIVE_PASSPORT_NO
            text_edit_ddl9_sub2_GIVE_PASSPORT_EXPDATE.Text = dao_get.fields.GIVE_PASSPORT_EXPDATE
            text_edit_ddl9_sub2_GIVE_WORK_LICENSE_NO.Text = dao_get.fields.GIVE_WORK_LICENSE_NO
            text_edit_ddl9_sub2_GIVE_WORK_LICENSE_EXPDATE.Text = dao_get.fields.GIVE_WORK_LICENSE_EXPDATE
        End If


    End Sub

    Protected Sub DDL_EDIT_REASON_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_EDIT_REASON.SelectedIndexChanged

        lb_select_reason.Text = DDL_EDIT_REASON.SelectedItem.Text
        Dim ddl_select_main As Integer = 0
        Try
            ddl_select_main = DDL_EDIT_REASON.SelectedValue
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
        End Try

        bind_reason_sub(ddl_select_main)
        'p1.Visible = True 'เปิด upload-file
        Try
            If DDL_EDIT_REASON.SelectedValue = 1 Then
                'เพิ่มรายละเอียดการแก้ไข
                edit_dd1.Visible = True
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False
                If _ProcessID = "122" Then
                    rdl_mastra.SelectedValue = "1"
                ElseIf _ProcessID = "121" Then
                    rdl_mastra.SelectedValue = "2"
                ElseIf _ProcessID = "120" Then
                    rdl_mastra.SelectedValue = "3"
                End If

                'GET_DATA
                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, 0)
                insert_phr_old_data()
                DDL_EDIT_REASON_SUB.Visible = False 'ddl_ย่อย
                lb1.Visible = False
                'BindTable(DDL_EDIT_REASON.SelectedValue, 0)
                rgphr.Rebind()
            ElseIf DDL_EDIT_REASON.SelectedValue = 4 Then
                'เพิ่มรายละเอียดการแก้ไข *ปิด
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = True
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                'GET_DATA
                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, 0)

                DDL_EDIT_REASON_SUB.Visible = False 'ddl_ย่อย
                lb1.Visible = False
                'BindTable(DDL_EDIT_REASON.SelectedValue, 0)
            ElseIf DDL_EDIT_REASON.SelectedValue = 5 Then
                'เพิ่มรายละเอียดการแก้ไข *ปิด
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = True
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                'GET_DATA
                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, 0)

                'UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5.bind_type(_lcn_ida)
                'UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5.bind_table(_lcn_ida)


                DDL_EDIT_REASON_SUB.Visible = False 'ddl_ย่อย
                lb1.Visible = False
                'p1.Visible = True 'เปิด upload-file
                'BindTable(DDL_EDIT_REASON.SelectedValue, 0)
            Else
                'เพิ่มรายละเอียดการแก้ไข *ปิด
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                ''GET_DATA
                'GET_DDL_REASON_DETAIL(0, 0)

                lb1.Visible = True
                DDL_EDIT_REASON_SUB.Visible = True
            End If
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');parent.close_modal();", True)
        End Try
    End Sub
    Protected Sub DDL_EDIT_REASON_SUB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_EDIT_REASON_SUB.SelectedIndexChanged
        Try
            If DDL_EDIT_REASON.SelectedValue = 2 Or DDL_EDIT_REASON.SelectedValue = 12 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = True
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)

            ElseIf DDL_EDIT_REASON.SelectedValue = 3 And DDL_EDIT_REASON_SUB.SelectedValue = 1 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = True
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)

            ElseIf DDL_EDIT_REASON.SelectedValue = 3 And DDL_EDIT_REASON_SUB.SelectedValue = 2 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = True
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            ElseIf DDL_EDIT_REASON.SelectedValue = 6 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = True
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            ElseIf DDL_EDIT_REASON.SelectedValue = 7 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = True
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            ElseIf DDL_EDIT_REASON.SelectedValue = 8 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = True
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            ElseIf DDL_EDIT_REASON.SelectedValue = 9 And DDL_EDIT_REASON_SUB.SelectedValue = 1 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = True
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            ElseIf DDL_EDIT_REASON.SelectedValue = 9 And DDL_EDIT_REASON_SUB.SelectedValue = 2 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = True
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            ElseIf DDL_EDIT_REASON.SelectedValue = 9 And DDL_EDIT_REASON_SUB.SelectedValue = 3 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = True
                edit_dd10.Visible = False
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            ElseIf DDL_EDIT_REASON.SelectedValue = 10 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = True
                edit_dd11.Visible = False

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)

            ElseIf DDL_EDIT_REASON.SelectedValue = 11 Then
                edit_dd1.Visible = False
                edit_dd2.Visible = False
                edit_dd3_sub1.Visible = False
                edit_dd3_sub2.Visible = False
                edit_dd4.Visible = False
                edit_dd5.Visible = False
                edit_dd6.Visible = False
                edit_dd7.Visible = False
                edit_dd8.Visible = False
                edit_dd9_sub1.Visible = False
                edit_dd9_sub2.Visible = False
                edit_dd9_sub3.Visible = False
                edit_dd10.Visible = False
                edit_dd11.Visible = True

                'UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11.bind_type(_lcn_ida)
                'UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11.bind_table(_lcn_ida)

                GET_DDL_REASON_DETAIL(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
            End If



            'BindTable(DDL_EDIT_REASON.SelectedValue, DDL_EDIT_REASON_SUB.SelectedValue)
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
        End Try


    End Sub

    'Public Sub BindTable(ByVal ddl1 As Integer, ByVal ddl2 As Integer)


    '    Dim url_img As New BAO.AppSettings
    '    Dim dao_f As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE
    '    Dim dao_at As New DAO_LCN.TB_MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE
    '    Dim group As Integer = 0

    '    Dim Process As Integer = 10201


    '    Dim rows As Integer = 1

    '    'DDL_EDIT_REASON.SelectedValue = ddl1
    '    'bind_reason_sub(ddl1)
    '    'Try
    '    '    DDL_EDIT_REASON_SUB.SelectedValue = ddl2
    '    'Catch ex As Exception
    '    '    ddl2 = 0
    '    'End Try

    '    If _STATUS_ID = 9 And _detial_type = 2 Then 'ขอเอกสารเพิ่มเติม
    '        edit1.Visible = False 'ปิด DDL ขอแก้ไข ให้อัพไฟล์อย่างเดียว
    '        edit2.Visible = False 'ปิด DDL ปิดเหตุผลการแก้ไข ให้อัพไฟล์อย่างเดียว
    '        'cm1.Text = "*โปรดแนบไฟล์เอกสาร (เพิ่มเติม)"
    '        dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_AND_TYPE_EDIT(Process, ddl1, ddl2, 2, True)


    '        For Each dao_f.fields In dao_f.datas
    '            If dao_f.fields.FILE_NUMBER_NAME <> 69 Then
    '                Dim tr As New TableRow
    '                tr.CssClass = "rows"
    '                Dim tc As New TableCell
    '                'Dim tc1 As New TableCell
    '                Dim GET_UPLOAD_HEAD_ID As Integer = 0
    '                Dim GET_TITEL_ID As Integer = 0
    '                Dim GET_TITEL_ID2 As Integer = 0

    '                tc = New TableCell
    '                tc.Text = dao_f.fields.HEAD_ID
    '                tr.Cells.Add(tc)

    '                tc = New TableCell
    '                tc.Text = dao_f.fields.FILE_NUMBER_NAME
    '                tc.Style.Add("display", "none")
    '                tr.Cells.Add(tc)

    '                tc = New TableCell
    '                Try
    '                    tc.Text = Replace(dao_f.fields.SUB_DOCUMENT_NAME, "\n", "<br/>")
    '                Catch ex As Exception
    '                    tc.Text = dao_f.fields.SUB_DOCUMENT_NAME
    '                End Try
    '                tc.Width = 900
    '                tr.Cells.Add(tc)

    '                dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(Process, GET_UPLOAD_HEAD_ID, GET_TITEL_ID, GET_TITEL_ID2, _TR_ID, 1)

    '                If dao_f.fields.NAME_REAL <> "" Then
    '                    tc = New TableCell
    '                    tc.Text = dao_f.fields.NAME_REAL
    '                    tc.Width = 100
    '                    tr.Cells.Add(tc)

    '                    tc = New TableCell
    '                    Dim img As New Image
    '                    Dim AA As String = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/correct.png"
    '                    img.ImageUrl = AA
    '                    img.Width = 20
    '                    img.Height = 20
    '                    tc.Controls.Add(img)
    '                    tc.Width = 40
    '                    tr.Cells.Add(tc)

    '                    tc = New TableCell
    '                    Dim f As New FileUpload
    '                    f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
    '                    tc.Controls.Add(f)
    '                    'tc.Width = 100
    '                    tr.Cells.Add(tc)
    '                Else
    '                    tc = New TableCell
    '                    'tc.Text = dao_f.fields.NAME_REAL
    '                    tc.Width = 100
    '                    tr.Cells.Add(tc)

    '                    tc = New TableCell
    '                    Dim img As New Image
    '                    Dim AA As String = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/cancel.png"
    '                    img.ImageUrl = AA
    '                    img.Width = 20
    '                    img.Height = 20
    '                    tc.Controls.Add(img)
    '                    tc.Width = 40
    '                    tr.Cells.Add(tc)

    '                    tc = New TableCell
    '                    Dim f As New FileUpload
    '                    f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
    '                    tc.Controls.Add(f)
    '                    tr.Cells.Add(tc)
    '                End If

    '                'tb_type_menu.Rows.Add(tr)
    '                rows = rows + 1
    '            End If


    '        Next
    '    ElseIf _detial_type = 0 Or _detial_type = 1 Then
    '        dao_at.GetDataby_DDL(ddl1, ddl2, True)

    '        For Each dao_at.fields In dao_at.datas

    '            Dim tr As New TableRow
    '            tr.CssClass = "rows"
    '            Dim tc As New TableCell
    '            'Dim tc1 As New TableCell
    '            Dim GET_UPLOAD_HEAD_ID As Integer = 0
    '            Dim GET_TITEL_ID As Integer = 0
    '            Dim GET_TITEL_ID2 As Integer = 0
    '            'เช็คว่า HEAD_ID ตัวเดียวกันไหม
    '            GET_UPLOAD_HEAD_ID = dao_at.fields.HEAD_ID
    '            GET_TITEL_ID = dao_at.fields.TITEL_ID
    '            GET_TITEL_ID2 = dao_at.fields.TITLE_ID2

    '            tc = New TableCell
    '            tc.Text = rows
    '            tr.Cells.Add(tc)

    '            tc = New TableCell
    '            tc.Text = dao_at.fields.ID
    '            tc.Style.Add("display", "none")
    '            tr.Cells.Add(tc)

    '            tc = New TableCell
    '            Try
    '                tc.Text = Replace(dao_at.fields.DUCUMENT_NAME, "\n", "<br/>")
    '            Catch ex As Exception
    '                tc.Text = dao_at.fields.DUCUMENT_NAME
    '            End Try
    '            tc.Width = 900
    '            tr.Cells.Add(tc)

    '            dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(Process, GET_UPLOAD_HEAD_ID, GET_TITEL_ID, GET_TITEL_ID2, _TR_ID, 1)

    '            If dao_f.fields.HEAD_ID = GET_UPLOAD_HEAD_ID And dao_f.fields.FK_TITEL_ID = GET_TITEL_ID And dao_f.fields.FK_TITEL_ID2 = GET_TITEL_ID2 Then
    '                tc = New TableCell
    '                tc.Text = dao_f.fields.NAME_REAL
    '                tc.Width = 100
    '                tr.Cells.Add(tc)

    '                tc = New TableCell
    '                Dim img As New Image
    '                Dim AA As String = ""
    '                If dao_f.fields.NAME_REAL <> "" Then
    '                    AA = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/correct.png"
    '                Else
    '                    AA = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/cancel.png"
    '                End If

    '                img.ImageUrl = AA
    '                img.Width = 20
    '                img.Height = 20
    '                tc.Controls.Add(img)
    '                tc.Width = 40
    '                tr.Cells.Add(tc)

    '                tc = New TableCell
    '                Dim f As New FileUpload
    '                'If _STATUS_ID <> 0 Then
    '                '    f.Enabled = True
    '                '    tc = New TableCell
    '                '    tr.Cells.Add(tc)
    '                'Else
    '                '    f.ID = "F" & dao_at.fields.ID
    '                '    tc.Controls.Add(f)
    '                '    'tc.Width = 100
    '                '    tr.Cells.Add(tc)
    '                'End If
    '                f.ID = "F" & dao_at.fields.ID
    '                tc.Controls.Add(f)
    '                'tc.Width = 100
    '                tr.Cells.Add(tc)

    '            Else
    '                tc = New TableCell
    '                'tc.Text = dao_f.fields.NAME_REAL
    '                tc.Width = 100
    '                tr.Cells.Add(tc)

    '                tc = New TableCell
    '                Dim img As New Image
    '                Dim AA As String = "https://meshlog.fda.moph.go.th/HERB_DEMO_PPK/Images/cancel.png"
    '                img.ImageUrl = AA
    '                img.Width = 20
    '                img.Height = 20
    '                tc.Controls.Add(img)
    '                tc.Width = 40
    '                tr.Cells.Add(tc)

    '                tc = New TableCell
    '                Dim f As New FileUpload
    '                'If _STATUS_ID <> 0 Then
    '                '    f.Enabled = True
    '                '    tc = New TableCell
    '                '    tr.Cells.Add(tc)
    '                'Else
    '                '    f.ID = "F" & dao_at.fields.ID
    '                '    tc.Controls.Add(f)
    '                '    'tc.Width = 100
    '                '    tr.Cells.Add(tc)
    '                'End If
    '                f.ID = "F" & dao_at.fields.ID
    '                tc.Controls.Add(f)
    '                'tc.Width = 100
    '                tr.Cells.Add(tc)
    '            End If

    '            'tb_type_menu.Rows.Add(tr)
    '            rows = rows + 1
    '        Next
    '    End If






    'End Sub


    'Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click


    '    Try


    '        Dim lcn_edit_process As Integer = 0
    '        lcn_edit_process = 10201

    '        Dim ddl1 As Integer = 0
    '        Dim ddl2 As Integer = 0

    '        ddl1 = DDL_EDIT_REASON.SelectedValue

    '        Try
    '            ddl2 = DDL_EDIT_REASON_SUB.SelectedValue
    '        Catch ex As Exception
    '            ddl2 = 0
    '        End Try


    '        BindTable(ddl1, ddl2)


    '        'Dim tr As TableRow
    '        'tr = tb_type_menu.DataBind()
    '        For Each tr As TableRow In tb_type_menu.Rows
    '            Dim HEAD_ID As Integer = tr.Cells(0).Text 'เอาข้อมูลช่องแรกมา
    '            Dim IDA_FILE As Integer = tr.Cells(1).Text 'เอาข้อมูลช่องแรกมา
    '            Dim GET_SUB_DOC_NAME As String = tr.Cells(2).Text

    '            Dim f As New FileUpload

    '            f = tr.FindControl("F" & IDA_FILE)
    '            If f.HasFile Then
    '                Dim name_real As String = f.FileName
    '                Dim Array_NAME_REAL() As String = Split(name_real, ".")
    '                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
    '                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
    '                If exten.ToUpper = "PDF" Then
    '                    Dim bao As New BAO.AppSettings
    '                    Dim dao_f As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE

    '                    Dim Name_fake As String = "HB-" & lcn_edit_process & "-" & Date.Now.Year & "-" & IDA_FILE & ".pdf"
    '                    Dim GET_IDA_UPLOAD As Integer = 0
    '                    If _detial_type = 0 Then
    '                        dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(lcn_edit_process, HEAD_ID, ddl1, ddl2, _TR_ID, True)
    '                    ElseIf _detial_type = 2 Then
    '                        dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID_EDIT_FILE(lcn_edit_process, HEAD_ID, ddl1, ddl2, _TR_ID, _detial_type, True)
    '                    End If


    '                    Try
    '                        GET_IDA_UPLOAD = dao_f.fields.IDA
    '                    Catch ex As Exception
    '                        GET_IDA_UPLOAD = 0
    '                    End Try
    '                    If GET_IDA_UPLOAD = 0 Then

    '                        dao_f.fields.FILE_NUMBER_NAME = IDA_FILE
    '                        dao_f.fields.TR_ID = _TR_ID

    '                        dao_f.fields.DATE_YEAR = con_year(Date.Now().Year())
    '                        dao_f.fields.NAME_FAKE = Name_fake
    '                        dao_f.fields.NAME_REAL = f.FileName
    '                        dao_f.fields.CREATE_DATE = System.DateTime.Now

    '                        dao_f.fields.PROCESS_ID = lcn_edit_process
    '                        dao_f.fields.FK_IDA = _lcn_ida
    '                        'dao_f.fields.TYPE = TYPE 'ลำดับไฟล์เก็บไว้เรียกข้อมูล


    '                        dao_f.fields.TYPE_LOCAL_NAME = DDL_EDIT_REASON.SelectedItem.Text
    '                        If ddl2 <> 0 Then
    '                            dao_f.fields.DUCUMENT_NAME = DDL_EDIT_REASON_SUB.SelectedItem.Text
    '                        End If
    '                        dao_f.fields.SUB_DOCUMENT_NAME = GET_SUB_DOC_NAME
    '                        dao_f.fields.HEAD_ID = HEAD_ID
    '                        dao_f.fields.FK_TITEL_ID = ddl1
    '                        dao_f.fields.FK_TITEL_ID2 = ddl2
    '                        dao_f.fields.TYPE = 1

    '                        dao_f.fields.ACTIVE = 1

    '                        dao_f.insert()
    '                    Else
    '                        dao_f.fields.HEAD_ID = HEAD_ID
    '                        dao_f.fields.NAME_FAKE = Name_fake
    '                        dao_f.fields.NAME_REAL = f.FileName
    '                        dao_f.fields.UPDATE_DATE = System.DateTime.Now

    '                        dao_f.fields.TYPE = 1

    '                        dao_f.update()
    '                    End If


    '                    Dim paths As String = bao._PATH_DEFAULT
    '                    f.SaveAs(paths & "upload\" & "LCN_EDIT\" & Name_fake)
    '                Else
    '                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
    '                End If
    '            End If

    '        Next

    '        'เมื่ออัพไฟล์ (เพิ่มเติม) ให้ update status = 8  ;ยื่นเอกสาร (เพิ่มเติม)
    '        If _STATUS_ID = 9 Then

    '            Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT
    '            Dim _YEAR As String = con_year(Date.Now().Year())
    '            dao_update.GetDataby_LCN_IDA_AND_YEAR_TR_ID_AND_ACTIVE(_lcn_ida, _YEAR, _TR_ID, True)



    '            dao_update.fields.STATUS_ID = 11
    '            dao_update.fields.STATUS_NAME = "ยื่นเอกสาร (เพิ่มเติม)"
    '            dao_update.fields.UPDATE_DATE = System.DateTime.Now


    '            dao_update.update()

    '            bind_pdf_xml_11(dao_update.fields.IDA, _lcn_ida, dao_update.fields.LCN_PROCESS_ID, dao_update.fields.STATUS_ID, dao_update.fields.DATE_YEAR, dao_update.fields.TR_ID)

    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    '        Else
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดเรียบร้อยแล้ว');", True)
    '        End If




    '        'tb_type_menu.Rows.Clear() 'เคลียข้อมูล table 
    '        BindTable(ddl1, ddl2) 'Upload แล้ว bind tableใหม่
    '    Catch ex As Exception
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดไม่สำเร็จ');", True)
    '    End Try

    'End Sub

    Public Sub bind_pdf_xml_11(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, LCN_IDA, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Sub SET_DATA_OLD_INSERT_REASON1()

        If _detial_type = 0 Then
            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_FK_IDA(_lcn_ida)

            Dim GET_1 As String = ""
            Dim GET_2 As String = ""
            Dim GET_3 As String = ""
            Dim GET_4 As String = ""
            Dim GET_5 As String = ""
            Dim GET_6 As DateTime

            GET_1 = dao_phr.fields.PHR_TEXT_JOB
            GET_2 = dao_phr.fields.PHR_TEXT_NUM
            GET_3 = dao_phr.fields.STUDY_LEVEL
            GET_4 = dao_phr.fields.PHR_VETERINARY_FIELD
            'GET_4 = dao_phr.fields.PHR_SAKHA
            GET_5 = dao_phr.fields.NAME_SIMINAR
            '12/10/2564
            Dim datefull_siminar As Date
            Dim SIMINAR_DATE As String = ""
            Try
                'datefull_siminar = dao_phr.fields.SIMINAR_DATE
                'SIMINAR_DATE = datefull_siminar.Day & "/" & datefull_siminar.Month & "/" & datefull_siminar.Year
                GET_6 = dao_phr.fields.SIMINAR_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            'insert old detail
            Dim old_update As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL1_REASON
            old_update.GET_DATA_BY_FK_LCN_IDA(_lcn_ida, True)
            old_update.fields.UPDATE_BY = ""
            old_update.fields.UPDATE_DATE = System.DateTime.Now
            old_update.fields.ACTIVE = False
            old_update.update()

            Dim old_dao As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL1_REASON
            old_dao.fields.FK_LCN_IDA = _lcn_ida

            old_dao.fields.PHR_TEXT_JOB = GET_1
            old_dao.fields.PHR_TEXT_NUM = GET_2
            old_dao.fields.STUDY_LEVEL = GET_3
            old_dao.fields.PHR_SAKHA = GET_4
            old_dao.fields.NAME_SIMINAR = GET_5

            Try
                old_dao.fields.SIMINAR_DATE = DateTime.ParseExact(GET_6, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                'old_dao.fields.SIMINAR_DATE = System.DateTime.Now
            End Try
            old_dao.fields.CREATE_DATE = System.DateTime.Now
            old_dao.fields.ACTIVE = 1

            old_dao.insert()

        End If




    End Sub
    Sub SET_DATA_INSERT_REASON1()
        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON1()

        'Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
        'Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
        'Dim ROW_CHK As String = ""
        'Try
        '    dao_update.GET_DATA_BY_FK_LCN_IDA(_lcn_ida, True)
        '    ROW_CHK = "HAVE"
        'Catch ex As Exception
        '    ROW_CHK = "NULL"
        'End Try
        'If ROW_CHK = "HAVE" Then
        '    dao_update.fields.ACTIVE = 0
        '    dao_update.fields.UPDATE_DATE = System.DateTime.Now
        '    dao_update.update()
        'End If

        'dao.fields.FK_LCN_IDA = _lcn_ida
        'dao.fields.PHR_TEXT_JOB = text_edit_ddl1_PHR_TEXT_JOB.Text
        'dao.fields.PHR_TEXT_NUM = text_edit_ddl1_PHR_TEXT_NUM.Text
        'dao.fields.STUDY_LEVEL = text_edit_ddl1_STUDY_LEVEL.Text
        'dao.fields.PHR_SAKHA = text_edit_ddl1_PHR_SAKHA.Text
        'dao.fields.NAME_SIMINAR = text_edit_ddl1_NAME_SIMINAR.Text

        'Try
        '    dao.fields.SIMINAR_DATE = DateTime.ParseExact(text_edit_ddl1_SIMINAR_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        'Catch ex As Exception
        '    dao.fields.SIMINAR_DATE = System.DateTime.Now
        'End Try
        'dao.fields.CREATE_DATE = System.DateTime.Now
        'dao.fields.ACTIVE = 1

        'dao.insert()


    End Sub

    Sub SET_DATA_OLD_INSERT_REASON3_SUB2(ByVal ddl1 As Integer, ByVal ddl2 As Integer)

        'get ตัวเก่า
        If _detial_type = 0 Then
            Dim dao1 As New DAO_DRUG.ClsDBdalcn
            dao1.GetDataby_IDA(_lcn_ida)

            Dim GET_1 As String = ""
            Dim GET_2 As DateTime
            Dim GET_3 As String = ""
            Dim GET_4 As DateTime

            GET_1 = dao1.fields.GIVE_PASSPORT_NO

            Dim datefull_PASSPORT_EXPDATE As Date
            Dim PASSPORT_EXPDATE As String = ""

            Try
                'datefull_PASSPORT_EXPDATE =
                'PASSPORT_EXPDATE = datefull_PASSPORT_EXPDATE.Day & "/" & datefull_PASSPORT_EXPDATE.Month & "/" & datefull_PASSPORT_EXPDATE.Year
                GET_2 = dao1.fields.GIVE_PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            GET_3 = dao1.fields.GIVE_WORK_LICENSE_NO

            Dim datefull_GIVE_WORK_LICENSE_EXPDATE As Date
            Dim WORK_LICENSE_EXPDATE As String = ""

            Try
                'datefull_GIVE_WORK_LICENSE_EXPDATE =
                'WORK_LICENSE_EXPDATE = datefull_GIVE_WORK_LICENSE_EXPDATE.Day & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Month & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Year
                GET_4 = dao1.fields.GIVE_WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            'เซฟของเก่า
            Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL3_REASON
            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL3_REASON

            Dim ROW_CHK As String = ""
            Try
                dao_update_old.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
                ROW_CHK = "HAVE"
            Catch ex As Exception
                ROW_CHK = "NULL"
            End Try
            If ROW_CHK = "HAVE" Then
                dao_update_old.fields.ACTIVE = 0
                dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
                dao_update_old.update()
            End If

            dao_old.fields.FK_LCN_IDA = _lcn_ida
            dao_old.fields.ddl1 = ddl1
            dao_old.fields.ddl2 = ddl2

            dao_old.fields.GIVE_PASSPORT_NO = GET_1

            Try
                dao_old.fields.GIVE_PASSPORT_EXPDATE = DateTime.ParseExact(GET_2, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.GIVE_PASSPORT_EXPDATE = System.DateTime.Now
            End Try
            dao_old.fields.GIVE_WORK_LICENSE_NO = GET_3

            Try
                dao_old.fields.GIVE_WORK_LICENSE_EXPDATE = DateTime.ParseExact(GET_4, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.GIVE_WORK_LICENSE_EXPDATE = System.DateTime.Now
            End Try

            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.ACTIVE = 1

            dao_old.insert()

        End If




    End Sub
    Sub SET_DATA_INSERT_REASON3_SUB2(ByVal ddl1 As Integer, ByVal ddl2 As Integer)

        SET_DATA_OLD_INSERT_REASON3_SUB2(ddl1, ddl2)

        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON

        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update.fields.ACTIVE = 0
            dao_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_update.update()
        End If

        dao.fields.FK_LCN_IDA = _lcn_ida
        dao.fields.ddl1 = ddl1
        dao.fields.ddl2 = ddl2
        dao.fields.GIVE_PASSPORT_NO = text_edit_ddl3_sub2_GIVE_PASSPORT_NO.Text

        Try
            dao.fields.GIVE_PASSPORT_EXPDATE = DateTime.ParseExact(text_edit_ddl3_sub2_GIVE_PASSPORT_EXPDATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.GIVE_PASSPORT_EXPDATE = System.DateTime.Now
        End Try
        dao.fields.GIVE_WORK_LICENSE_NO = text_edit_ddl3_sub2_GIVE_WORK_LICENSE_NO.Text

        Try
            dao.fields.GIVE_WORK_LICENSE_EXPDATE = DateTime.ParseExact(text_edit_ddl3_sub2_GIVE_WORK_LICENSE_EXPDATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.GIVE_WORK_LICENSE_EXPDATE = System.DateTime.Now
        End Try

        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.ACTIVE = 1

        dao.insert()

    End Sub
    Sub SET_DATA_OLD_INSERT_REASON4()
        If _detial_type = 0 Then
            'get ตัวเก่า
            Dim dao_main As New DAO_DRUG.ClsDBdalcn
            dao_main.GetDataby_IDA(_lcn_ida)
            Dim GET_1 As String = ""
            GET_1 = dao_main.fields.opentime

            'เซฟตัวเก่า
            Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL4_REASON
            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL4_REASON
            Dim ROW_CHK As String = ""
            Try
                dao_update_old.GET_DATA_BY_FK_LCN_IDA(_lcn_ida, True)
                ROW_CHK = "HAVE"
            Catch ex As Exception
                ROW_CHK = "NULL"
            End Try
            If ROW_CHK = "HAVE" Then
                dao_update_old.fields.ACTIVE = 0
                dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
                dao_update_old.update()
            End If
            dao_old.fields.FK_LCN_IDA = _lcn_ida
            dao_old.fields.opentime = GET_1
            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.ACTIVE = 1

            dao_old.insert()
        End If
    End Sub
    Sub SET_DATA_INSERT_REASON4()
        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON4()

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL4_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL4_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCN_IDA(_lcn_ida, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update.fields.ACTIVE = 0
            dao_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_update.update()
        End If
        dao.fields.FK_LCN_IDA = _lcn_ida
        dao.fields.opentime = text_edit_ddl4_opentime.Text
        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.ACTIVE = 1

        dao.insert()

    End Sub
    Sub SET_DATA_OLD_INSERT_REASON5(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        If _detial_type = 0 Then
            'get ตัวเก่า
            Dim dao1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao1.GetDataby_IDA(_lct_ida)

            Dim GET_1 As String = ""
            Dim GET_2 As String = ""
            Dim GET_KEEP_1 As String = ""
            Dim GET_KEEP_2 As String = ""

            GET_1 = dao1.fields.tel
            GET_2 = "" 'รอเพิ่มฟิว email

            'สถานที่เก็บ
            Dim dao2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            dao2.GetData_by_LOCATION_ADDRESS_IDA_AND_LCN_IDA(_lct_ida, _lcn_ida)


            GET_KEEP_1 = dao2.fields.LOCATION_ADDRESS_tel
            GET_KEEP_2 = "" 'รอเพิ่มฟิว KEEP_email

            'เซฟตัวเก่า
            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL5_REASON
            Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL5_REASON
            Dim ROW_CHK As String = ""
            Try
                dao_update_old.GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(_lct_ida, ddl1, ddl2, True)
                ROW_CHK = "HAVE"
            Catch ex As Exception
                ROW_CHK = "NULL"
            End Try
            If ROW_CHK = "HAVE" Then
                dao_update_old.fields.ACTIVE = 0
                dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
                dao_update_old.update()
            End If

            dao_old.fields.ddl1 = ddl1
            dao_old.fields.ddl2 = ddl2
            dao_old.fields.FK_LCT_IDA = _lct_ida

            dao_old.fields.tel = GET_1
            dao_old.fields.email = GET_2

            'สถานที่เก็บ
            'Dim dao2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            'dao2.GetDataby_IDA(_lct_ida)
            dao_old.fields.KEEP_tel = GET_KEEP_1
            dao_old.fields.KEEP_email = GET_KEEP_2

            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.ACTIVE = 1

            dao_old.insert()
        End If
    End Sub
    Sub SET_DATA_INSERT_REASON5(ByVal ddl1 As Integer, ByVal ddl2 As Integer)

        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON5(ddl1, ddl2)

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(_lct_ida, ddl1, ddl2, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update.fields.ACTIVE = 0
            dao_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_update.update()
        End If
        dao.fields.ddl1 = ddl1
        dao.fields.ddl2 = ddl2
        dao.fields.FK_LCT_IDA = _lct_ida
        dao.fields.tel = text_edit_ddl5_tel.Text
        dao.fields.email = text_edit_ddl5_email.Text

        'สถานที่เก็บ
        'Dim dao2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        'dao2.GetDataby_IDA(_lct_ida)
        dao.fields.KEEP_tel = text_edit_ddl5_KEEP_tel.Text
        dao.fields.KEEP_email = text_edit_ddl5_KEEP_email.Text

        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.ACTIVE = 1

        dao.insert()

    End Sub


    Sub SET_DATA_OLD_INSERT_REASON7(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        If _detial_type = 0 Then
            'get ตัวเก่า
            Dim dao_main As New DAO_DRUG.ClsDBdalcn
            dao_main.GetDataby_IDA(_lcn_ida)

            Dim GET_1 As String = ""
            Dim GET_2 As String = ""
            Dim GET_3 As String = ""

            GET_1 = dao_main.fields.BSN_THAIFULLNAME

            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.GetDataby_LCN_IDA(_lcn_ida)
            GET_2 = dao_bsn.fields.BSN_THAIFULLNAME

            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_FK_IDA(_lcn_ida)
            GET_3 = dao_phr.fields.PHR_TEXT_JOB

            'เซฟตัวเก่า
            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL7_REASON
            Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL7_REASON
            Dim ROW_CHK As String = ""
            Try
                dao_update_old.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
                ROW_CHK = "HAVE"
            Catch ex As Exception
                ROW_CHK = "NULL"
            End Try
            If ROW_CHK = "HAVE" Then
                dao_update_old.fields.ACTIVE = 0
                dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
                dao_update_old.update()
            End If
            dao_old.fields.FK_LCN_IDA = _lcn_ida
            dao_old.fields.ddl1 = ddl1
            dao_old.fields.ddl2 = ddl2

            dao_old.fields.DALCN_BSN_THAIFULLNAME = GET_1
            dao_old.fields.BSN_THAIFULLNAME = GET_2
            dao_old.fields.PHR_TEXT_JOB = GET_3
            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.ACTIVE = 1

            dao_old.insert()
        End If
    End Sub
    Sub SET_DATA_INSERT_REASON7(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON7(ddl1, ddl2)

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL7_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL7_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update.fields.ACTIVE = 0
            dao_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_update.update()
        End If
        dao.fields.FK_LCN_IDA = _lcn_ida
        dao.fields.ddl1 = ddl1
        dao.fields.ddl2 = ddl2
        dao.fields.DALCN_BSN_THAIFULLNAME = text_edit_ddl7_dalcn_BSN_THAIFULLNAME.Text
        dao.fields.BSN_THAIFULLNAME = text_edit_ddl7_BSN_THAIFULLNAME.Text
        dao.fields.PHR_TEXT_JOB = text_edit_ddl7_PHR_TEXT_JOB.Text
        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.ACTIVE = 1

        dao.insert()


    End Sub
    Sub SET_DATA_OLD_INSERT_REASON8(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        'get ตัวเก่า
        Dim dao1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao1.GetDataby_IDA(_lct_ida)
        Dim GET_1 As String = ""
        Dim GET_2 As String = ""
        Dim GET_3 As String = ""
        Dim GET_4 As String = ""


        GET_1 = dao1.fields.thanameplace
        GET_2 = dao1.fields.HOUSENO
        GET_3 = dao1.fields.thaaddr
        GET_4 = dao1.fields.thabuilding

        'เซฟตัวเก่า
        Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL8_REASON
        Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL8_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_update_old.GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(_lct_ida, ddl1, ddl2, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update_old.fields.ACTIVE = 0
            dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
            dao_update_old.update()
        End If
        dao_old.fields.FK_LCT_IDA = _lct_ida
        dao_old.fields.ddl1 = ddl1
        dao_old.fields.ddl2 = ddl2

        dao_old.fields.thanameplace = GET_1
        dao_old.fields.HOUSENO = GET_2
        dao_old.fields.thaaddr = GET_3
        dao_old.fields.thabuilding = GET_4
        dao_old.fields.CREATE_DATE = System.DateTime.Now
        dao_old.fields.ACTIVE = 1

        dao_old.insert()
    End Sub
    Sub SET_DATA_INSERT_REASON8(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON8(ddl1, ddl2)

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL8_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL8_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(_lct_ida, ddl1, ddl2, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update.fields.ACTIVE = 0
            dao_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_update.update()
        End If
        dao.fields.FK_LCT_IDA = _lct_ida
        dao.fields.ddl1 = ddl1
        dao.fields.ddl2 = ddl2
        dao.fields.thanameplace = text_edit_ddl8_thanameplace.Text
        dao.fields.HOUSENO = text_edit_ddl8_HOUSENO.Text
        dao.fields.thaaddr = text_edit_ddl8_thaaddr.Text
        dao.fields.thabuilding = text_edit_ddl8_thabuilding.Text
        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.ACTIVE = 1

        dao.insert()
    End Sub

    Sub SET_DATA_OLD_INSERT_REASON_DDL9_SUB1(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        If _detial_type = 0 Then
            'getตัวเก่า
            Dim dao1 As New DAO_DRUG.TB_DALCN_FRGN_DATA
            dao1.GetDataby_FK_IDA_AND_PERSON_TYPE(_lcn_ida, 1)

            Dim GET_1 As String = ""
            Dim GET_2 As String = ""
            Dim GET_3 As String = ""
            Dim GET_4 As String = ""
            Dim GET_5 As String = ""
            Dim GET_6 As String = ""
            Dim GET_7 As String = ""
            Dim GET_8 As String = ""
            Dim GET_9 As String = ""
            Dim GET_10 As String = ""

            GET_1 = dao1.fields.PASSPORT_NO

            Dim datefull_PASSPORT_EXPDATE As Date
            Dim PASSPORT_EXPDATE As String = ""

            Try
                'datefull_PASSPORT_EXPDATE = dao1.fields.PASSPORT_EXPDATE
                'PASSPORT_EXPDATE = datefull_PASSPORT_EXPDATE.Day & "/" & datefull_PASSPORT_EXPDATE.Month & "/" & datefull_PASSPORT_EXPDATE.Year
                GET_2 = dao1.fields.PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            GET_3 = dao1.fields.BS_NO
            Dim datefull_BS_DATE As Date
            Dim BS_DATE As String = ""

            Try
                'datefull_BS_DATE = dao1.fields.BS_DATE
                'BS_DATE = datefull_BS_DATE.Day & "/" & datefull_BS_DATE.Month & "/" & datefull_BS_DATE.Year
                GET_4 = dao1.fields.BS_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            GET_5 = dao1.fields.WORK_LICENSE_NO
            Dim datefull_WORK_LICENSE_EXPDATE As Date
            Dim WORK_LICENSE_EXPDATE As String = ""

            Try
                'datefull_WORK_LICENSE_EXPDATE = dao1.fields.WORK_LICENSE_EXPDATE
                'WORK_LICENSE_EXPDATE = datefull_WORK_LICENSE_EXPDATE.Day & "/" & datefull_WORK_LICENSE_EXPDATE.Month & "/" & datefull_WORK_LICENSE_EXPDATE.Year
                GET_6 = dao1.fields.WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            GET_7 = dao1.fields.DOC_NO
            Dim datefull_DOC_DATE As Date
            Dim DOC_DATE As String = ""

            Try
                'datefull_DOC_DATE = dao1.fields.DOC_DATE
                'DOC_DATE = datefull_DOC_DATE.Day & "/" & datefull_DOC_DATE.Month & "/" & datefull_DOC_DATE.Year
                GET_8 = dao1.fields.DOC_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            GET_9 = dao1.fields.FRGN_NO
            Dim datefull_FRGN_DATE As Date
            Dim FRGN_DATE As String = ""

            Try
                'datefull_FRGN_DATE = dao1.fields.FRGN_DATE
                'FRGN_DATE = datefull_FRGN_DATE.Day & "/" & datefull_FRGN_DATE.Month & "/" & datefull_FRGN_DATE.Year
                GET_10 = dao1.fields.FRGN_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            'เซฟตัวเก่า
            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL9_REASON
            Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL9_REASON
            Dim ROW_CHK As String = ""
            Try
                dao_update_old.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
                ROW_CHK = "HAVE"
            Catch ex As Exception
                ROW_CHK = "NULL"
            End Try
            If ROW_CHK = "HAVE" Then
                dao_update_old.fields.ACTIVE = 0
                dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
                dao_update_old.update()
            End If

            dao_old.fields.FK_LCN_IDA = _lcn_ida
            dao_old.fields.ddl1 = ddl1
            dao_old.fields.ddl2 = ddl2
            dao_old.fields.PERSON_TYPE = 1

            dao_old.fields.PASSPORT_NO = GET_1
            Try
                dao_old.fields.PASSPORT_EXPDATE = DateTime.ParseExact(GET_2, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.PASSPORT_EXPDATE = System.DateTime.Now
            End Try

            dao_old.fields.BS_NO = GET_3
            Try
                dao_old.fields.BS_DATE = DateTime.ParseExact(GET_4, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.BS_DATE = System.DateTime.Now
            End Try

            dao_old.fields.WORK_LICENSE_NO = GET_5
            Try
                dao_old.fields.WORK_LICENSE_EXPDATE = DateTime.ParseExact(GET_6, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.WORK_LICENSE_EXPDATE = System.DateTime.Now
            End Try

            dao_old.fields.DOC_NO = GET_7
            Try
                dao_old.fields.DOC_DATE = DateTime.ParseExact(GET_8, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.DOC_DATE = System.DateTime.Now
            End Try

            dao_old.fields.FRGN_NO = GET_9
            Try
                dao_old.fields.FRGN_DATE = DateTime.ParseExact(GET_10, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.FRGN_DATE = System.DateTime.Now
            End Try


            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.ACTIVE = 1

            dao_old.insert()
        End If
    End Sub
    Sub SET_DATA_INSERT_REASON_DDL9_SUB1(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON_DDL9_SUB1(ddl1, ddl2)

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update.fields.ACTIVE = 0
            dao_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_update.update()
        End If
        dao.fields.FK_LCN_IDA = _lcn_ida
        dao.fields.ddl1 = ddl1
        dao.fields.ddl2 = ddl2
        dao.fields.PERSON_TYPE = 1
        dao.fields.PASSPORT_NO = text_edit_ddl9_sub1_PASSPORT_NO.Text
        Try
            dao.fields.PASSPORT_EXPDATE = DateTime.ParseExact(text_edit_ddl9_sub1_PASSPORT_EXPDATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.PASSPORT_EXPDATE = System.DateTime.Now
        End Try

        dao.fields.BS_NO = text_edit_ddl9_sub1_BS_NO.Text
        Try
            dao.fields.BS_DATE = DateTime.ParseExact(text_edit_ddl9_sub1_BS_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.BS_DATE = System.DateTime.Now
        End Try

        dao.fields.WORK_LICENSE_NO = text_edit_ddl9_sub1_WORK_LICENSE_NO.Text
        Try
            dao.fields.WORK_LICENSE_EXPDATE = DateTime.ParseExact(text_edit_ddl9_sub1_WORK_LICENSE_EXPDATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.WORK_LICENSE_EXPDATE = System.DateTime.Now
        End Try

        dao.fields.DOC_NO = text_edit_ddl9_sub1_DOC_NO.Text
        Try
            dao.fields.DOC_DATE = DateTime.ParseExact(text_edit_ddl9_sub1_DOC_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.DOC_DATE = System.DateTime.Now
        End Try

        dao.fields.FRGN_NO = text_edit_ddl9_sub1_FRGN_NO.Text
        Try
            dao.fields.FRGN_DATE = DateTime.ParseExact(text_edit_ddl9_sub1_FRGN_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.FRGN_DATE = System.DateTime.Now
        End Try


        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.ACTIVE = 1

        dao.insert()
    End Sub
    Sub SET_DATA_OLD_INSERT_REASON_DDL9_SUB2(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        If _detial_type = 0 Then
            'get ตัวเก่า
            Dim dao1 As New DAO_DRUG.TB_DALCN_FRGN_DATA
            dao1.GetDataby_FK_IDA_AND_PERSON_TYPE(_lcn_ida, 2)

            Dim GET_1 As String = ""
            Dim GET_2 As DateTime
            Dim GET_3 As String = ""
            Dim GET_4 As DateTime
            Dim GET_5 As String = ""
            Dim GET_6 As DateTime
            Dim GET_7 As String = ""
            Dim GET_8 As DateTime

            GET_1 = dao1.fields.DOC_NO
            Dim datefull_DOC_DATE As Date
            Dim DOC_DATE As String = ""

            Try
                'datefull_DOC_DATE = dao1.fields.DOC_DATE
                'DOC_DATE = datefull_DOC_DATE.Day & "/" & datefull_DOC_DATE.Month & "/" & datefull_DOC_DATE.Year
                GET_2 = dao1.fields.DOC_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
            GET_3 = dao1.fields.FRGN_NO
            Dim datefull_FRGN_DATE As Date
            Dim FRGN_DATE As String = ""

            Try
                'datefull_FRGN_DATE = dao1.fields.FRGN_DATE
                'FRGN_DATE = datefull_FRGN_DATE.Day & "/" & datefull_FRGN_DATE.Month & "/" & datefull_FRGN_DATE.Year
                GET_4 = dao1.fields.FRGN_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            Dim dao2 As New DAO_DRUG.ClsDBdalcn
            dao2.GetDataby_IDA(_lcn_ida)

            GET_5 = dao2.fields.GIVE_PASSPORT_NO
            Dim datefull_GIVE_PASSPORT_EXPDATE As Date
            Dim GIVE_PASSPORT_EXPDATE As String = ""

            Try
                'datefull_GIVE_PASSPORT_EXPDATE = dao2.fields.GIVE_PASSPORT_EXPDATE
                'GIVE_PASSPORT_EXPDATE = datefull_GIVE_PASSPORT_EXPDATE.Day & "/" & datefull_GIVE_PASSPORT_EXPDATE.Month & "/" & datefull_GIVE_PASSPORT_EXPDATE.Year
                GET_6 = dao2.fields.GIVE_PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            GET_7 = dao2.fields.GIVE_WORK_LICENSE_NO
            Dim datefull_GIVE_WORK_LICENSE_EXPDATE As Date
            Dim GIVE_WORK_LICENSE_EXPDATE As String = ""

            Try
                'datefull_GIVE_WORK_LICENSE_EXPDATE = dao2.fields.GIVE_WORK_LICENSE_EXPDATE
                'GIVE_WORK_LICENSE_EXPDATE = datefull_GIVE_WORK_LICENSE_EXPDATE.Day & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Month & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Year
                GET_8 = dao2.fields.GIVE_WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            'เซฟ ตัวเก่า
            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL9_REASON
            Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL9_REASON
            Dim ROW_CHK As String = ""
            Try
                dao_update_old.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
                ROW_CHK = "HAVE"
            Catch ex As Exception
                ROW_CHK = "NULL"
            End Try
            If ROW_CHK = "HAVE" Then
                dao_update_old.fields.ACTIVE = 0
                dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
                dao_update_old.update()
            End If
            dao_old.fields.FK_LCN_IDA = _lcn_ida
            dao_old.fields.ddl1 = ddl1
            dao_old.fields.ddl2 = ddl2
            dao_old.fields.PERSON_TYPE = 2

            dao_old.fields.DOC_NO = GET_1
            Try
                dao_old.fields.DOC_DATE = DateTime.ParseExact(GET_2, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.DOC_DATE = System.DateTime.Now
            End Try

            dao_old.fields.FRGN_NO = GET_3
            Try
                dao_old.fields.FRGN_DATE = DateTime.ParseExact(GET_4, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.FRGN_DATE = System.DateTime.Now
            End Try

            dao_old.fields.GIVE_PASSPORT_NO = GET_5
            Try
                dao_old.fields.GIVE_PASSPORT_EXPDATE = DateTime.ParseExact(GET_6, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.GIVE_PASSPORT_EXPDATE = System.DateTime.Now
            End Try

            dao_old.fields.GIVE_WORK_LICENSE_NO = GET_7
            Try
                dao_old.fields.GIVE_WORK_LICENSE_EXPDATE = DateTime.ParseExact(GET_8, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao_old.fields.GIVE_WORK_LICENSE_EXPDATE = System.DateTime.Now
            End Try

            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.ACTIVE = 1

            dao_old.insert()
        End If



    End Sub
    Sub SET_DATA_INSERT_REASON_DDL9_SUB2(ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON_DDL9_SUB2(ddl1, ddl2)

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update.fields.ACTIVE = 0
            dao_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_update.update()
        End If
        dao.fields.FK_LCN_IDA = _lcn_ida
        dao.fields.ddl1 = ddl1
        dao.fields.ddl2 = ddl2
        dao.fields.PERSON_TYPE = 2
        dao.fields.DOC_NO = text_edit_ddl9_sub2_DOC_NO.Text
        Try
            dao.fields.DOC_DATE = DateTime.ParseExact(text_edit_ddl9_sub2_DOC_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.DOC_DATE = System.DateTime.Now
        End Try

        dao.fields.FRGN_NO = text_edit_ddl9_sub2_FRGN_NO.Text
        Try
            dao.fields.FRGN_DATE = DateTime.ParseExact(text_edit_ddl9_sub2_FRGN_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.FRGN_DATE = System.DateTime.Now
        End Try

        dao.fields.GIVE_PASSPORT_NO = text_edit_ddl9_sub2_GIVE_PASSPORT_NO.Text
        Try
            dao.fields.GIVE_PASSPORT_EXPDATE = DateTime.ParseExact(text_edit_ddl9_sub2_GIVE_PASSPORT_EXPDATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.GIVE_PASSPORT_EXPDATE = System.DateTime.Now
        End Try

        dao.fields.GIVE_WORK_LICENSE_NO = text_edit_ddl9_sub2_GIVE_WORK_LICENSE_NO.Text
        Try
            dao.fields.GIVE_WORK_LICENSE_EXPDATE = DateTime.ParseExact(text_edit_ddl9_sub2_GIVE_WORK_LICENSE_EXPDATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
        Catch ex As Exception
            dao.fields.GIVE_WORK_LICENSE_EXPDATE = System.DateTime.Now
        End Try

        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.ACTIVE = 1

        dao.insert()
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
        'dao.GET_DATA_BY_FK_LCN_IDA(_lcn_ida, True)
        'dao.GET_DATA_BY_FK_LCN_IDA_AND_PHR_IDA(_lcn_ida, _phr_ida.Replace("&nbsp;", 0), True)
        If ddl_prefix.Text = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกคำนำหน้า');</script> ")
            'ElseIf ddl_phr_type.SelectedValue = "0" And txt_STUDY_LEVEL.Text = "" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาระบุคุณวุฒิ');</script> ")
            'ElseIf txt_PHR_TEXT_WORK_TIME.Text = "" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกเวลาทำการ');</script> ")
        Else
            'If dao.fields.IDA = 0 Then
            set_data(dao)
            dao.fields.FK_LCN_IDA = _lcn_ida
            dao.fields.FK_IDA = Request.QueryString("ida")
            dao.fields.ACTIVE = True
            dao.insert()
            'Else
            '    set_data(dao)
            '    dao.fields.FK_LCN_IDA = _lcn_ida
            '    dao.fields.FK_IDA = Request.QueryString("ida")
            '    dao.fields.ACTIVE = 1
            '    dao.update()
            'End If
            CLEAR_TEXT()
            rgphr.Rebind()
            'BindTable(DDL_EDIT_REASON.SelectedValue, 0)
            Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
        End If
        'Check_infor()

    End Sub
    Sub CLEAR_TEXT()
        Try
            ddl_prefix.SelectedValue = 0
        Catch ex As Exception

        End Try
        text_edit_ddl1_PHR_TEXT_JOB.Text = Nothing
        text_edit_ddl1_PHR_TEXT_NUM.Text = Nothing
        text_edit_ddl1_STUDY_LEVEL.Text = Nothing
        text_edit_ddl1_PHR_SAKHA.Text = Nothing
        text_edit_ddl1_NAME_SIMINAR.Text = Nothing
        txt_PHR_CTZNO.Text = Nothing
        text_edit_ddl1_SIMINAR_DATE.Text = Nothing
        text_edit_ddl1_TIME_WORK.Text = Nothing
        _phr_ida = Nothing
    End Sub
    Public Sub set_data(ByRef dao As DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON)
        With dao.fields
            .PHR_NAME = text_edit_ddl1_PHR_TEXT_JOB.Text
            '.PHR_LEVEL = txt_PHR_LEVEL.Text
            .PHR_PREFIX_ID = ddl_prefix.SelectedValue
            .PHR_PREFIX_NAME = ddl_prefix.SelectedItem.Text
            .PHR_CTZNO = txt_PHR_CTZNO.Text
            .PHR_TEXT_NUM = text_edit_ddl1_PHR_TEXT_NUM.Text
            '.PHR_TEXT_WORK_TIME = txt_PHR_TEXT_WORK_TIME.Text
            Try
                .PHR_VETERINARY_FIELD = text_edit_ddl1_PHR_SAKHA.Text
            Catch ex As Exception

            End Try
            Try
                .PHR_LAW_SECTION = rdl_mastra.SelectedValue
            Catch ex As Exception

            End Try
            dao.fields.FK_LCN_IDA = _lcn_ida
            dao.fields.PHR_TEXT_JOB = text_edit_ddl1_PHR_TEXT_JOB.Text
            dao.fields.PHR_TEXT_NUM = text_edit_ddl1_PHR_TEXT_NUM.Text
            dao.fields.STUDY_LEVEL = text_edit_ddl1_STUDY_LEVEL.Text
            dao.fields.PHR_SAKHA = text_edit_ddl1_PHR_SAKHA.Text
            dao.fields.NAME_SIMINAR = text_edit_ddl1_NAME_SIMINAR.Text
            dao.fields.PHR_TEXT_WORK_TIME = text_edit_ddl1_TIME_WORK.Text

            Try
                dao.fields.SIMINAR_DATE = DateTime.ParseExact(text_edit_ddl1_SIMINAR_DATE.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
            Catch ex As Exception
                dao.fields.SIMINAR_DATE = System.DateTime.Now
            End Try
            dao.fields.CREATE_DATE = System.DateTime.Now
            'Try
            '    .PHR_LAW_SECTION = rdl_mastra.SelectedValue
            'Catch ex As Exception

            'End Try
            'Try
            '    .SIMINAR_DATE = rdp_SIMINAR_DATE.SelectedDate
            'Catch ex As Exception

            'End Try
            'Try
            '    .NAME_SIMINAR = txt_NAME_SIMINAR.Text
            'Catch ex As Exception

            'End Try
            'Try
            '    .PHR_JOB_TYPE = ddl_job.SelectedValue
            'Catch ex As Exception

            'End Try
            'Try
            '    .PERSONAL_TYPE = ddl_phr_type.SelectedValue 'rdl_per_type.SelectedValue
            'Catch ex As Exception

            'End Try
            'Try
            '    If ddl_worker_type.SelectedValue = "12" Or ddl_worker_type.SelectedValue = "15" Then
            '        .PHR_MEDICAL_TYPE = 3
            '    End If
            'Catch ex As Exception

            'End Try
            'Try
            '    .PHR_TEXT_JOB = txt_PHR_TEXT_JOB.Text
            'Catch ex As Exception

            'End Try
            'Try
            '    .PHR_MEDICAL_TYPE = ddl_PHR_MEDICAL_TYPE.SelectedValue
            'Catch ex As Exception

            'End Try
        End With
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_PHR_CTZNO.Text
            'CITIZEN_ID_AUTHORIZE = text_edit_ddl1_PHR_TEXT_JOB.Text
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
                'txt_PHR_NAME.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
                text_edit_ddl1_PHR_TEXT_JOB.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            Catch ex As Exception

            End Try
            Try
                ddl_prefix.DropDownSelectData(ws_taxno.SYSLCNSNMs.prefixcd)
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub insert_phr_old_data()
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(_lcn_ida)
        Dim dao_ddl1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
        dao_ddl1.GET_DATA_BY_FK_LCN_IDA(_lcn_ida, True)
        If dao_ddl1.fields.IDA = 0 Then
            If dao_phr.fields.PHR_IDA <> 0 Then
                For Each dao_phr.fields In dao_phr.datas
                    Dim dao_ddl1_EDIT As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
                    dao_ddl1_EDIT.fields.FK_LCN_IDA = dao_phr.fields.FK_IDA
                    dao_ddl1_EDIT.fields.PHR_IDA = dao_phr.fields.PHR_IDA
                    dao_ddl1_EDIT.fields.PHR_TEXT_JOB = dao_phr.fields.PHR_TEXT_JOB
                    dao_ddl1_EDIT.fields.PHR_TEXT_NUM = dao_phr.fields.PHR_TEXT_NUM
                    dao_ddl1_EDIT.fields.STUDY_LEVEL = dao_phr.fields.STUDY_LEVEL
                    dao_ddl1_EDIT.fields.PHR_SAKHA = dao_phr.fields.PHR_VETERINARY_FIELD
                    dao_ddl1_EDIT.fields.NAME_SIMINAR = dao_phr.fields.NAME_SIMINAR
                    dao_ddl1_EDIT.fields.PHR_CTZNO = dao_phr.fields.PHR_CTZNO
                    dao_ddl1_EDIT.fields.PHR_PREFIX_ID = dao_phr.fields.PHR_PREFIX_ID
                    dao_ddl1_EDIT.fields.PHR_PREFIX_NAME = dao_phr.fields.PHR_PREFIX_NAME
                    dao_ddl1_EDIT.fields.PHR_NAME = dao_phr.fields.PHR_NAME
                    dao_ddl1_EDIT.fields.PHR_VETERINARY_FIELD = dao_phr.fields.PHR_VETERINARY_FIELD
                    dao_ddl1_EDIT.fields.PHR_TEXT_WORK_TIME = dao_phr.fields.PHR_TEXT_WORK_TIME
                    dao_ddl1_EDIT.fields.PHR_LAW_SECTION = dao_phr.fields.PHR_LAW_SECTION
                    dao_ddl1_EDIT.fields.FK_IDA = _IDA
                    dao_ddl1_EDIT.fields.ACTIVE = True
                    dao_ddl1_EDIT.insert()
                Next
                For Each dao_phr.fields In dao_phr.datas
                    Dim dao_ddl1_OLD As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL1_REASON
                    dao_ddl1_OLD.fields.FK_LCN_IDA = dao_phr.fields.FK_IDA
                    dao_ddl1_OLD.fields.PHR_IDA = dao_phr.fields.PHR_IDA
                    dao_ddl1_OLD.fields.PHR_TEXT_JOB = dao_phr.fields.PHR_TEXT_JOB
                    dao_ddl1_OLD.fields.PHR_TEXT_NUM = dao_phr.fields.PHR_TEXT_NUM
                    dao_ddl1_OLD.fields.STUDY_LEVEL = dao_phr.fields.STUDY_LEVEL
                    dao_ddl1_OLD.fields.PHR_SAKHA = dao_phr.fields.PHR_VETERINARY_FIELD
                    dao_ddl1_OLD.fields.NAME_SIMINAR = dao_phr.fields.NAME_SIMINAR
                    dao_ddl1_OLD.fields.PHR_CTZNO = dao_phr.fields.PHR_CTZNO
                    dao_ddl1_OLD.fields.PHR_PREFIX_ID = dao_phr.fields.PHR_PREFIX_ID
                    dao_ddl1_OLD.fields.PHR_PREFIX_NAME = dao_phr.fields.PHR_PREFIX_NAME
                    dao_ddl1_OLD.fields.PHR_NAME = dao_phr.fields.PHR_NAME
                    dao_ddl1_OLD.fields.PHR_VETERINARY_FIELD = dao_phr.fields.PHR_VETERINARY_FIELD
                    dao_ddl1_OLD.fields.PHR_TEXT_WORK_TIME = dao_phr.fields.PHR_TEXT_WORK_TIME
                    dao_ddl1_OLD.fields.PHR_LAW_SECTION = dao_phr.fields.PHR_LAW_SECTION
                    dao_ddl1_OLD.fields.FK_IDA = _IDA
                    dao_ddl1_OLD.fields.ACTIVE = True
                    dao_ddl1_OLD.insert()
                Next
            End If
        End If
    End Sub
    Private Sub rgphr_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgphr.NeedDataSource
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        If _lcn_ida <> "" Then
            dt = bao.SP_LCN_EDIT_PHR_BY_FK_IDA(_lcn_ida)
        End If

        If dt.Rows.Count > 0 Then
            rgphr.DataSource = dt
        End If
    End Sub
    Private Sub rgns_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgphr.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim _ida As String = item("IDA").Text
            Dim PHR_IDA As String = item("PHR_IDA").Text
            Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL1_REASON
            If e.CommandName = "r_del" Then
                dao.GET_DATA_BY_IDA(_ida, True)
                dao.fields.ACTIVE = False
                dao.update()
                'dao.delete()
                rgphr.Rebind()
                'ElseIf e.CommandName = "r_edit" Then
                '    dao.GET_DATA_BY_IDA(_ida, True)
                '    Try
                '        ddl_prefix.SelectedValue = dao.fields.PHR_PREFIX_ID
                '    Catch ex As Exception

                '    End Try
                '    text_edit_ddl1_PHR_TEXT_JOB.Text = dao.fields.PHR_TEXT_JOB
                '    text_edit_ddl1_PHR_TEXT_NUM.Text = dao.fields.PHR_TEXT_NUM
                '    text_edit_ddl1_STUDY_LEVEL.Text = dao.fields.STUDY_LEVEL
                '    text_edit_ddl1_PHR_SAKHA.Text = dao.fields.PHR_SAKHA
                '    text_edit_ddl1_NAME_SIMINAR.Text = dao.fields.NAME_SIMINAR
                '    text_edit_ddl1_TIME_WORK.Text = dao.fields.PHR_TEXT_WORK_TIME
                '    txt_PHR_CTZNO.Text = dao.fields.PHR_CTZNO
                '    If dao.fields.SIMINAR_DATE IsNot Nothing Then text_edit_ddl1_SIMINAR_DATE.Text = dao.fields.SIMINAR_DATE
                '    _phr_ida = PHR_IDA
                '    'rgphr.Rebind()S
            End If
            'BindTable(DDL_EDIT_REASON.SelectedValue, 0)
        End If
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgphr.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_del As LinkButton = DirectCast(item("r_del").Controls(0), LinkButton)
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(IDA)
            'btn_del.Style.Add("display", "none")
            Try
                If _IDA <> 0 Then
                    btn_del.Style.Add("display", "none")
                Else
                    btn_del.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    'Private Function serialgrid(ByVal R As RadGrid) As DataTable
    '    Dim DT As New DataTable
    '    DT = gridaddcolumn(R)
    '    grid_reindex(DT, "num")
    '    For Each g As GridDataItem In R.Items
    '        Dim dr As DataRow = DT.NewRow()
    '        For Each C As DataColumn In DT.Columns
    '            dr(C.ColumnName) = g(C.ColumnName).Text
    '        Next
    '        DT.Rows.Add(dr)
    '    Next
    '    Return DT
    'End Function

    'Private Overloads Function gridaddcolumn(ByVal R As RadGrid) As DataTable
    '    Dim DT As New DataTable
    '    For Each G As GridColumn In R.Columns
    '        DT.Columns.Add(G.UniqueName)
    '    Next
    '    Return DT
    'End Function

    'Private Sub grid_reindex(ByRef dt As DataTable, ByVal Cname As String)
    '    Dim i As Integer = 1
    '    For Each dr As DataRow In dt.Rows
    '        dr(Cname) = i
    '        i = i + 1
    '    Next
    'End Sub

    'Private Sub btn_add_cas_Click(sender As Object, e As EventArgs) Handles btn_add_cas.Click
    '    Dim dt As New DataTable
    '    dt = serialgrid(RG_CAS)
    '    Dim dr As DataRow = dt.NewRow
    '    dr("thnm_cas") = txt_thai_name_cas.Text
    '    dr("ennm_cas") = txt_eng_name_cas.Text
    '    dr("num_cas") = txt_number_cas.Text
    '    dr("duty_cas") = ddl_duty_cas.Text
    '    dr("duty_cas_id") = ddl_duty_cas.SelectedValue
    '    dr("amoun_cas") = txt_amount_cas.Text
    '    dr("uni_cas") = ddl_unit_cas.Text
    '    dr("uni_cas_id") = ddl_unit_cas.SelectedValue
    '    dt.Rows.Add(dr)
    '    'grid_reindex(dt, "num")
    '    rgphr.DataSource = dt
    '    rgphr.DataBind()
    '    Clear_Result()
    'End Sub

End Class
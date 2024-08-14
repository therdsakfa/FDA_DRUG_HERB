Public Class UC_LCN_EDIT_TOPIC_3
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub SET_DATA_REASON_DDL2(ByVal _lct_ida As Integer, ByVal _lcn_ida As Integer)
        Dim dao1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao1.GetDataby_IDA(_lct_ida)

        text_edit_topic3_thanameplace.Text = dao1.fields.thanameplace
        text_edit_topic3_HOUSENO.Text = dao1.fields.HOUSENO
        text_edit_topic3_thaaddr.Text = dao1.fields.thaaddr
        text_edit_topic3_thabuilding.Text = dao1.fields.thabuilding
        text_edit_topic3_thamu.Text = dao1.fields.thamu
        text_edit_topic3_thasoi.Text = dao1.fields.thasoi
        text_edit_topic3_tharoad.Text = dao1.fields.tharoad
        text_edit_topic3_thathmblnm.Text = dao1.fields.thathmblnm
        text_edit_topic3_thaamphrnm.Text = dao1.fields.thaamphrnm
        text_edit_topic3_thachngwtnm.Text = dao1.fields.thachngwtnm
        text_edit_topic3_zipcode.Text = dao1.fields.zipcode
        text_edit_topic3_fax.Text = dao1.fields.fax
        text_edit_topic3_tel.Text = dao1.fields.tel
        text_edit_topic3_email.Text = "" 'รอเพิ่มฟิว
        text_edit_topic3_opentime.Text = "" 'รอเพิ่มฟิว

        'สถานที่เก็บ
        Dim dao2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP


        dao2.GetData_by_LOCATION_ADDRESS_IDA_AND_LCN_IDA(_lct_ida, _lcn_ida)

        text_edit_topic3_KEEP_thanameplace.Text = dao2.fields.LOCATION_ADDRESS_thanameplace
        text_edit_topic3_KEEP_HOUSENO.Text = dao2.fields.LOCATION_ADDRESS_HOUSENO
        text_edit_topic3_KEEP_thaaddr.Text = dao2.fields.LOCATION_ADDRESS_thaaddr
        text_edit_topic3_KEEP_thabuilding.Text = dao2.fields.LOCATION_ADDRESS_thabuilding
        text_edit_topic3_KEEP_thamu.Text = dao2.fields.LOCATION_ADDRESS_thamu
        text_edit_topic3_KEEP_thasoi.Text = dao2.fields.LOCATION_ADDRESS_thasoi
        text_edit_topic3_KEEP_tharoad.Text = dao2.fields.LOCATION_ADDRESS_tharoad
        text_edit_topic3_KEEP_thathmblnm.Text = dao2.fields.LOCATION_ADDRESS_thathmblnm
        text_edit_topic3_KEEP_thaamphrnm.Text = dao2.fields.LOCATION_ADDRESS_thaamphrnm
        text_edit_topic3_KEEP_thachngwtnm.Text = dao2.fields.LOCATION_ADDRESS_thachngwtnm
        text_edit_topic3_KEEP_zipcode.Text = dao2.fields.LOCATION_ADDRESS_zipcode
        text_edit_topic3_KEEP_fax.Text = dao2.fields.LOCATION_ADDRESS_fax
        text_edit_topic3_KEEP_tel.Text = dao2.fields.LOCATION_ADDRESS_tel
        text_edit_topic3_KEEP_email.Text = "" 'รอเพิ่มฟิว

    End Sub
    Sub SET_DATA_SEE_DETAIL_DDL2(ByVal _lct_ida As Integer, ByVal dd1 As Integer, ByVal dd2 As Integer)
        'Dim dao1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        'dao1.GetDataby_IDA(_lct_ida)
        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL2_REASON
        dao.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lct_ida, dd1, dd2, True)


        text_edit_topic3_thanameplace.Text = dao.fields.thanameplace
        text_edit_topic3_HOUSENO.Text = dao.fields.HOUSENO
        text_edit_topic3_thaaddr.Text = dao.fields.thaaddr
        text_edit_topic3_thabuilding.Text = dao.fields.thabuilding
        text_edit_topic3_thamu.Text = dao.fields.thamu
        text_edit_topic3_thasoi.Text = dao.fields.thasoi
        text_edit_topic3_tharoad.Text = dao.fields.tharoad
        text_edit_topic3_thathmblnm.Text = dao.fields.thathmblnm
        text_edit_topic3_thaamphrnm.Text = dao.fields.thaamphrnm
        text_edit_topic3_thachngwtnm.Text = dao.fields.thachngwtnm
        text_edit_topic3_zipcode.Text = dao.fields.zipcode
        text_edit_topic3_fax.Text = dao.fields.fax
        text_edit_topic3_tel.Text = dao.fields.tel
        text_edit_topic3_email.Text = dao.fields.email
        text_edit_topic3_opentime.Text = dao.fields.opentime




        'สถานที่เก็บ

        text_edit_topic3_KEEP_thanameplace.Text = dao.fields.KEEP_thanameplace
        text_edit_topic3_KEEP_HOUSENO.Text = dao.fields.KEEP_HOUSENO
        text_edit_topic3_KEEP_thaaddr.Text = dao.fields.KEEP_thaaddr
        text_edit_topic3_KEEP_thabuilding.Text = dao.fields.KEEP_thabuilding
        text_edit_topic3_KEEP_thamu.Text = dao.fields.KEEP_thamu
        text_edit_topic3_KEEP_thasoi.Text = dao.fields.KEEP_thasoi
        text_edit_topic3_KEEP_tharoad.Text = dao.fields.KEEP_tharoad
        text_edit_topic3_KEEP_thathmblnm.Text = dao.fields.KEEP_thathmblnm
        text_edit_topic3_KEEP_thaamphrnm.Text = dao.fields.KEEP_thaamphrnm
        text_edit_topic3_KEEP_thachngwtnm.Text = dao.fields.KEEP_thachngwtnm
        text_edit_topic3_KEEP_zipcode.Text = dao.fields.KEEP_zipcode
        text_edit_topic3_KEEP_fax.Text = dao.fields.KEEP_fax
        text_edit_topic3_KEEP_tel.Text = dao.fields.KEEP_tel
        text_edit_topic3_KEEP_email.Text = dao.fields.KEEP_email


    End Sub

    Sub SET_DATA_OLD_INSERT_REASON2(ByVal _detial_type As Integer, ByVal _lct_ida As Integer, ByVal _lcn_ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        If _detial_type = 0 Then
            Dim dao1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao1.GetDataby_IDA(_lct_ida)

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
            Dim GET_11 As String = ""
            Dim GET_12 As String = ""
            Dim GET_13 As String = ""
            Dim GET_14 As String = ""
            Dim GET_15 As String = ""

            GET_1 = dao1.fields.thanameplace
            GET_2 = dao1.fields.HOUSENO
            GET_3 = dao1.fields.thaaddr
            GET_4 = dao1.fields.thabuilding
            GET_5 = dao1.fields.thamu
            GET_6 = dao1.fields.thasoi
            GET_7 = dao1.fields.tharoad
            GET_8 = dao1.fields.thathmblnm
            GET_9 = dao1.fields.thaamphrnm
            GET_10 = dao1.fields.thachngwtnm
            GET_11 = dao1.fields.zipcode
            GET_12 = dao1.fields.fax
            GET_13 = dao1.fields.tel
            GET_14 = "" 'รอเพิ่มฟิว email
            GET_15 = "" 'รอเพิ่มฟิว opentime

            'สถานที่เก็บ
            Dim dao2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            dao2.GetData_by_LOCATION_ADDRESS_IDA_AND_LCN_IDA(_lct_ida, _lcn_ida)

            Dim GET_KEEP_1 As String = ""
            Dim GET_KEEP_2 As String = ""
            Dim GET_KEEP_3 As String = ""
            Dim GET_KEEP_4 As String = ""
            Dim GET_KEEP_5 As String = ""
            Dim GET_KEEP_6 As String = ""
            Dim GET_KEEP_7 As String = ""
            Dim GET_KEEP_8 As String = ""
            Dim GET_KEEP_9 As String = ""
            Dim GET_KEEP_10 As String = ""
            Dim GET_KEEP_11 As String = ""
            Dim GET_KEEP_12 As String = ""
            Dim GET_KEEP_13 As String = ""
            Dim GET_KEEP_14 As String = ""

            GET_KEEP_1 = dao2.fields.LOCATION_ADDRESS_thanameplace
            GET_KEEP_2 = dao2.fields.LOCATION_ADDRESS_HOUSENO
            GET_KEEP_3 = dao2.fields.LOCATION_ADDRESS_thaaddr
            GET_KEEP_4 = dao2.fields.LOCATION_ADDRESS_thabuilding
            GET_KEEP_5 = dao2.fields.LOCATION_ADDRESS_thamu
            GET_KEEP_6 = dao2.fields.LOCATION_ADDRESS_thasoi
            GET_KEEP_7 = dao2.fields.LOCATION_ADDRESS_tharoad
            GET_KEEP_8 = dao2.fields.LOCATION_ADDRESS_thathmblnm
            GET_KEEP_9 = dao2.fields.LOCATION_ADDRESS_thaamphrnm
            GET_KEEP_10 = dao2.fields.LOCATION_ADDRESS_thachngwtnm
            GET_KEEP_11 = dao2.fields.LOCATION_ADDRESS_zipcode
            GET_KEEP_12 = dao2.fields.LOCATION_ADDRESS_fax
            GET_KEEP_13 = dao2.fields.LOCATION_ADDRESS_tel
            GET_KEEP_14 = "" 'รอเพิ่มฟิว KEEP_email

            'insert old detail

            Dim dao_old_update As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL2_REASON

            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL2_REASON


            Dim ROW_CHK As String = ""
            Try
                dao_old_update.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lct_ida, ddl1, ddl2, True)
                ROW_CHK = "HAVE"
            Catch ex As Exception
                ROW_CHK = "NULL"
            End Try
            If ROW_CHK = "HAVE" Then
                dao_old_update.fields.ACTIVE = 0
                dao_old_update.fields.UPDATE_DATE = System.DateTime.Now
                dao_old_update.update()
            End If


            dao_old.fields.FK_LCT_IDA = _lct_ida
            dao_old.fields.ddl1 = ddl1
            dao_old.fields.ddl2 = ddl2

            dao_old.fields.thanameplace = GET_1
            dao_old.fields.HOUSENO = GET_2
            dao_old.fields.thaaddr = GET_3
            dao_old.fields.thabuilding = GET_4
            dao_old.fields.thamu = GET_5
            dao_old.fields.thasoi = GET_6
            dao_old.fields.tharoad = GET_7
            dao_old.fields.thathmblnm = GET_8
            dao_old.fields.thaamphrnm = GET_9
            dao_old.fields.thachngwtnm = GET_10
            dao_old.fields.zipcode = GET_11
            dao_old.fields.fax = GET_12
            dao_old.fields.tel = GET_13
            dao_old.fields.email = GET_14
            dao_old.fields.opentime = GET_15




            'สถานที่เก็บ

            dao_old.fields.KEEP_thanameplace = GET_KEEP_1
            dao_old.fields.KEEP_HOUSENO = GET_KEEP_2
            dao_old.fields.KEEP_thaaddr = GET_KEEP_3
            dao_old.fields.KEEP_thabuilding = GET_KEEP_4
            dao_old.fields.KEEP_thamu = GET_KEEP_5
            dao_old.fields.KEEP_thasoi = GET_KEEP_6
            dao_old.fields.KEEP_tharoad = GET_KEEP_7
            dao_old.fields.KEEP_thathmblnm = GET_KEEP_8
            dao_old.fields.KEEP_thaamphrnm = GET_KEEP_9
            dao_old.fields.KEEP_thachngwtnm = GET_KEEP_10
            dao_old.fields.KEEP_zipcode = GET_KEEP_11
            dao_old.fields.KEEP_fax = GET_KEEP_12
            dao_old.fields.KEEP_tel = GET_KEEP_13
            dao_old.fields.KEEP_email = GET_KEEP_14

            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.ACTIVE = 1
            dao_old.insert()
        End If
    End Sub
    Sub SET_DATA_INSERT_REASON_DDL2(ByVal _lct_ida As Integer, ByVal _lcn_ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal _detial_type As Integer)

        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON2(_detial_type, _lct_ida, _lcn_ida, ddl1, ddl2)

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL2_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL2_REASON

        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lct_ida, ddl1, ddl2, True)
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

        dao.fields.thanameplace = text_edit_topic3_thanameplace.Text
        dao.fields.HOUSENO = text_edit_topic3_HOUSENO.Text
        dao.fields.thaaddr = text_edit_topic3_thaaddr.Text
        dao.fields.thabuilding = text_edit_topic3_thabuilding.Text
        dao.fields.thamu = text_edit_topic3_thamu.Text
        dao.fields.thasoi = text_edit_topic3_thasoi.Text
        dao.fields.tharoad = text_edit_topic3_tharoad.Text
        dao.fields.thathmblnm = text_edit_topic3_thathmblnm.Text
        dao.fields.thaamphrnm = text_edit_topic3_thaamphrnm.Text
        dao.fields.thachngwtnm = text_edit_topic3_thachngwtnm.Text
        dao.fields.zipcode = text_edit_topic3_zipcode.Text
        dao.fields.fax = text_edit_topic3_fax.Text
        dao.fields.tel = text_edit_topic3_tel.Text
        dao.fields.email = text_edit_topic3_email.Text
        dao.fields.opentime = text_edit_topic3_opentime.Text




        'สถานที่เก็บ

        dao.fields.KEEP_thanameplace = text_edit_topic3_KEEP_thanameplace.Text
        dao.fields.KEEP_HOUSENO = text_edit_topic3_KEEP_HOUSENO.Text
        dao.fields.KEEP_thaaddr = text_edit_topic3_KEEP_thaaddr.Text
        dao.fields.KEEP_thabuilding = text_edit_topic3_KEEP_thabuilding.Text
        dao.fields.KEEP_thamu = text_edit_topic3_KEEP_thamu.Text
        dao.fields.KEEP_thasoi = text_edit_topic3_KEEP_thasoi.Text
        dao.fields.KEEP_tharoad = text_edit_topic3_KEEP_tharoad.Text
        dao.fields.KEEP_thathmblnm = text_edit_topic3_KEEP_thathmblnm.Text
        dao.fields.KEEP_thaamphrnm = text_edit_topic3_KEEP_thaamphrnm.Text
        dao.fields.KEEP_thachngwtnm = text_edit_topic3_KEEP_thachngwtnm.Text
        dao.fields.KEEP_zipcode = text_edit_topic3_KEEP_zipcode.Text
        dao.fields.KEEP_fax = text_edit_topic3_KEEP_fax.Text
        dao.fields.KEEP_tel = text_edit_topic3_KEEP_tel.Text
        dao.fields.KEEP_email = text_edit_topic3_KEEP_email.Text

        dao.fields.CREATE_DATE = System.DateTime.Now
        dao.fields.ACTIVE = 1
        dao.insert()

    End Sub

    Sub SET_DATA_OLD_INSERT_REASON_DDL6(ByVal _detial_type As Integer, ByVal _lct_ida As Integer, ByVal _lcn_ida As Integer, ByVal dd1 As Integer, ByVal dd2 As Integer)
        If _detial_type = 0 Then
            'get ตัวเก่า
            Dim dao1 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao1.GetDataby_IDA(_lct_ida)
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
            Dim GET_11 As String = ""
            Dim GET_12 As String = ""
            Dim GET_13 As String = ""
            Dim GET_14 As String = ""
            Dim GET_15 As String = ""


            GET_1 = dao1.fields.thanameplace
            GET_2 = dao1.fields.HOUSENO
            GET_3 = dao1.fields.thaaddr
            GET_4 = dao1.fields.thabuilding
            GET_5 = dao1.fields.thamu
            GET_6 = dao1.fields.thasoi
            GET_7 = dao1.fields.tharoad
            GET_8 = dao1.fields.thathmblnm
            GET_9 = dao1.fields.thaamphrnm
            GET_10 = dao1.fields.thachngwtnm
            GET_11 = dao1.fields.zipcode
            GET_12 = dao1.fields.fax
            GET_13 = dao1.fields.tel
            GET_14 = "" 'รอเพิ่มฟิว email
            GET_15 = "" 'รอเพิ่มฟิว opentime

            'สถานที่เก็บ
            Dim dao2 As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            dao2.GetData_by_LOCATION_ADDRESS_IDA_AND_LCN_IDA(_lct_ida, _lcn_ida)

            Dim GET_KEEP_1 As String = ""
            Dim GET_KEEP_2 As String = ""
            Dim GET_KEEP_3 As String = ""
            Dim GET_KEEP_4 As String = ""
            Dim GET_KEEP_5 As String = ""
            Dim GET_KEEP_6 As String = ""
            Dim GET_KEEP_7 As String = ""
            Dim GET_KEEP_8 As String = ""
            Dim GET_KEEP_9 As String = ""
            Dim GET_KEEP_10 As String = ""
            Dim GET_KEEP_11 As String = ""
            Dim GET_KEEP_12 As String = ""
            Dim GET_KEEP_13 As String = ""
            Dim GET_KEEP_14 As String = ""

            GET_KEEP_1 = dao2.fields.LOCATION_ADDRESS_thanameplace
            GET_KEEP_2 = dao2.fields.LOCATION_ADDRESS_HOUSENO
            GET_KEEP_3 = dao2.fields.LOCATION_ADDRESS_thaaddr
            GET_KEEP_4 = dao2.fields.LOCATION_ADDRESS_thabuilding
            GET_KEEP_5 = dao2.fields.LOCATION_ADDRESS_thamu
            GET_KEEP_6 = dao2.fields.LOCATION_ADDRESS_thasoi
            GET_KEEP_7 = dao2.fields.LOCATION_ADDRESS_tharoad
            GET_KEEP_8 = dao2.fields.LOCATION_ADDRESS_thathmblnm
            GET_KEEP_9 = dao2.fields.LOCATION_ADDRESS_thaamphrnm
            GET_KEEP_10 = dao2.fields.LOCATION_ADDRESS_thachngwtnm
            GET_KEEP_11 = dao2.fields.LOCATION_ADDRESS_zipcode
            GET_KEEP_12 = dao2.fields.LOCATION_ADDRESS_fax
            GET_KEEP_13 = dao2.fields.LOCATION_ADDRESS_tel
            GET_KEEP_14 = "" 'รอเพิ่มฟิว KEEP_email

            'เซฟตัวเก่า
            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL6_REASON
            Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL6_REASON
            Dim ROW_CHK As String = ""
            Try
                dao_update_old.GET_DATA_BY_FK_LCT_IDA(_lct_ida, True)
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
            'dao1.fields.DDL1 = dd1
            'dao1.fields.DDL2 = dd2

            dao_old.fields.thanameplace = GET_1
            dao_old.fields.HOUSENO = GET_2
            dao_old.fields.thaaddr = GET_3
            dao_old.fields.thabuilding = GET_4
            dao_old.fields.thamu = GET_5
            dao_old.fields.thasoi = GET_6
            dao_old.fields.tharoad = GET_7
            dao_old.fields.thathmblnm = GET_8
            dao_old.fields.thaamphrnm = GET_9
            dao_old.fields.thachngwtnm = GET_10
            dao_old.fields.zipcode = GET_11
            dao_old.fields.fax = GET_12
            dao_old.fields.tel = GET_13
            dao_old.fields.email = GET_14
            dao_old.fields.opentime = GET_15




            'สถานที่เก็บ

            dao_old.fields.KEEP_thanameplace = GET_KEEP_1
            dao_old.fields.KEEP_HOUSENO = GET_KEEP_2
            dao_old.fields.KEEP_thaaddr = GET_KEEP_3
            dao_old.fields.KEEP_thabuilding = GET_KEEP_4
            dao_old.fields.KEEP_thamu = GET_KEEP_5
            dao_old.fields.KEEP_thasoi = GET_KEEP_6
            dao_old.fields.KEEP_tharoad = GET_KEEP_7
            dao_old.fields.KEEP_thathmblnm = GET_KEEP_8
            dao_old.fields.KEEP_thaamphrnm = GET_KEEP_9
            dao_old.fields.KEEP_thachngwtnm = GET_KEEP_10
            dao_old.fields.KEEP_zipcode = GET_KEEP_11
            dao_old.fields.KEEP_fax = GET_KEEP_12
            dao_old.fields.KEEP_tel = GET_KEEP_13
            dao_old.fields.KEEP_email = GET_KEEP_14

            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.ACTIVE = 1

            dao_old.insert()
        End If
    End Sub
    Sub SET_DATA_INSERT_REASON_DDL6(ByVal _detial_type As Integer, ByVal _lct_ida As Integer, ByVal _lcn_ida As Integer, ByVal dd1 As Integer, ByVal dd2 As Integer)
        'เซฟตัวเก่า 
        SET_DATA_OLD_INSERT_REASON_DDL6(_detial_type, _lct_ida, _lcn_ida, dd1, dd2)

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL6_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL6_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_update.GET_DATA_BY_FK_LCT_IDA(_lct_ida, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_update.fields.ACTIVE = 0
            dao_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_update.update()
        End If

        dao1.fields.FK_LCT_IDA = _lct_ida
        'dao1.fields.DDL1 = dd1
        'dao1.fields.DDL2 = dd2

        dao1.fields.thanameplace = text_edit_topic3_thanameplace.Text
        dao1.fields.HOUSENO = text_edit_topic3_HOUSENO.Text
        dao1.fields.thaaddr = text_edit_topic3_thaaddr.Text
        dao1.fields.thabuilding = text_edit_topic3_thabuilding.Text
        dao1.fields.thamu = text_edit_topic3_thamu.Text
        dao1.fields.thasoi = text_edit_topic3_thasoi.Text
        dao1.fields.tharoad = text_edit_topic3_tharoad.Text
        dao1.fields.thathmblnm = text_edit_topic3_thathmblnm.Text
        dao1.fields.thaamphrnm = text_edit_topic3_thaamphrnm.Text
        dao1.fields.thachngwtnm = text_edit_topic3_thachngwtnm.Text
        dao1.fields.zipcode = text_edit_topic3_zipcode.Text
        dao1.fields.fax = text_edit_topic3_fax.Text
        dao1.fields.tel = text_edit_topic3_tel.Text
        dao1.fields.email = text_edit_topic3_email.Text
        dao1.fields.opentime = text_edit_topic3_opentime.Text




        'สถานที่เก็บ

        dao1.fields.KEEP_thanameplace = text_edit_topic3_KEEP_thanameplace.Text
        dao1.fields.KEEP_HOUSENO = text_edit_topic3_KEEP_HOUSENO.Text
        dao1.fields.KEEP_thaaddr = text_edit_topic3_KEEP_thaaddr.Text
        dao1.fields.KEEP_thabuilding = text_edit_topic3_KEEP_thabuilding.Text
        dao1.fields.KEEP_thamu = text_edit_topic3_KEEP_thamu.Text
        dao1.fields.KEEP_thasoi = text_edit_topic3_KEEP_thasoi.Text
        dao1.fields.KEEP_tharoad = text_edit_topic3_KEEP_tharoad.Text
        dao1.fields.KEEP_thathmblnm = text_edit_topic3_KEEP_thathmblnm.Text
        dao1.fields.KEEP_thaamphrnm = text_edit_topic3_KEEP_thaamphrnm.Text
        dao1.fields.KEEP_thachngwtnm = text_edit_topic3_KEEP_thachngwtnm.Text
        dao1.fields.KEEP_zipcode = text_edit_topic3_KEEP_zipcode.Text
        dao1.fields.KEEP_fax = text_edit_topic3_KEEP_fax.Text
        dao1.fields.KEEP_tel = text_edit_topic3_KEEP_tel.Text
        dao1.fields.KEEP_email = text_edit_topic3_KEEP_email.Text

        dao1.fields.CREATE_DATE = System.DateTime.Now
        dao1.fields.ACTIVE = 1

        dao1.insert()

    End Sub
    Sub SET_DATA_SEE_DETAIL_DDL6(ByVal _lct_ida As Integer)
        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL6_REASON
        dao1.GET_DATA_BY_FK_LCT_IDA(_lct_ida, True)

        text_edit_topic3_thanameplace.Text = dao1.fields.thanameplace
        text_edit_topic3_HOUSENO.Text = dao1.fields.HOUSENO
        text_edit_topic3_thaaddr.Text = dao1.fields.thaaddr
        text_edit_topic3_thabuilding.Text = dao1.fields.thabuilding
        text_edit_topic3_thamu.Text = dao1.fields.thamu
        text_edit_topic3_thasoi.Text = dao1.fields.thasoi
        text_edit_topic3_tharoad.Text = dao1.fields.tharoad
        text_edit_topic3_thathmblnm.Text = dao1.fields.thathmblnm
        text_edit_topic3_thaamphrnm.Text = dao1.fields.thaamphrnm
        text_edit_topic3_thachngwtnm.Text = dao1.fields.thachngwtnm
        text_edit_topic3_zipcode.Text = dao1.fields.zipcode
        text_edit_topic3_fax.Text = dao1.fields.fax
        text_edit_topic3_tel.Text = dao1.fields.tel
        text_edit_topic3_email.Text = dao1.fields.email
        text_edit_topic3_opentime.Text = dao1.fields.opentime


        'สถานที่เก็บ
        text_edit_topic3_KEEP_thanameplace.Text = dao1.fields.KEEP_thanameplace
        text_edit_topic3_KEEP_HOUSENO.Text = dao1.fields.KEEP_HOUSENO
        text_edit_topic3_KEEP_thaaddr.Text = dao1.fields.KEEP_thaaddr
        text_edit_topic3_KEEP_thabuilding.Text = dao1.fields.KEEP_thabuilding
        text_edit_topic3_KEEP_thamu.Text = dao1.fields.KEEP_thamu
        text_edit_topic3_KEEP_thasoi.Text = dao1.fields.KEEP_thasoi
        text_edit_topic3_KEEP_tharoad.Text = dao1.fields.KEEP_tharoad
        text_edit_topic3_KEEP_thathmblnm.Text = dao1.fields.KEEP_thathmblnm
        text_edit_topic3_KEEP_thaamphrnm.Text = dao1.fields.KEEP_thaamphrnm
        text_edit_topic3_KEEP_thachngwtnm.Text = dao1.fields.KEEP_thachngwtnm
        text_edit_topic3_KEEP_zipcode.Text = dao1.fields.KEEP_zipcode
        text_edit_topic3_KEEP_fax.Text = dao1.fields.KEEP_fax
        text_edit_topic3_KEEP_tel.Text = dao1.fields.KEEP_tel
        text_edit_topic3_KEEP_email.Text = dao1.fields.KEEP_email

    End Sub
End Class
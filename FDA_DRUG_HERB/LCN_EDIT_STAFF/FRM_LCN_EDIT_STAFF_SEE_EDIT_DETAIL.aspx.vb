Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_LCN_EDIT_STAFF_SEE_EDIT_DETAIL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Shared _lcn_ida As Integer
    Shared _lct_ida As Integer
    Shared _ddl1 As Integer
    Shared _ddl2 As Integer
    Shared _detial_type As Integer


    Sub RunSession()
        _lcn_ida = Request.QueryString("SEE_DETAIL_LCN_IDA")
        _lct_ida = Request.QueryString("SEE_DETAIL_LCT_IDA")
        _ddl1 = Request.QueryString("ddl_up1")
        _ddl2 = Request.QueryString("ddl_up2")
        _detial_type = Request.QueryString("detail")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        GET_DDL_REASON_DETAIL(_ddl1, _ddl2)

        'ต้องใส่ตรงนี้ ไม่งั้นเซฟ table chk ไม่ได้
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5.bind_type(_lcn_ida)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5.bind_table_ddl5(_lcn_ida, _ddl1, _ddl2, _detial_type)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL10.bind_type(_lcn_ida)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL10.bind_table_ddl10(_lcn_ida, _ddl1, _ddl2, _detial_type)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11.bind_type(_lcn_ida)
        UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11.bind_table_ddl11(_lcn_ida, _ddl1, _ddl2, _detial_type)
    End Sub

    Sub GET_DDL_REASON_DETAIL(ByVal DDL_VALUE As Integer, ByVal DDL_SUB_VALUE As Integer)

        If _detial_type = 1 Then 'ดูข้อมูลที่มี
            If DDL_VALUE = 1 Then
                SET_DATA_REASON_DDL1()
                edit_dd1.Visible = True
            ElseIf DDL_VALUE = 2 Then
                UC_LCN_EDIT_TOPIC_3_DDL2.SET_DATA_SEE_DETAIL_DDL2(_lct_ida, _ddl1, _ddl2)
                edit_dd2.Visible = True
            ElseIf DDL_VALUE = 3 Then
                If DDL_SUB_VALUE = 1 Then
                    UC_LCN_EDIT_TOPIC_2_DDL3.SET_DATA_SEE_DETAIL_DDL3(_lcn_ida, _ddl1, _ddl2)
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


    Sub SET_DATA_REASON_DDL1()

        If _detial_type = 0 Then
            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_FK_IDA(_lcn_ida)

            text_edit_ddl1_PHR_TEXT_JOB.Text = dao_phr.fields.PHR_TEXT_JOB
            text_edit_ddl1_PHR_TEXT_NUM.Text = dao_phr.fields.PHR_TEXT_NUM
            text_edit_ddl1_STUDY_LEVEL.Text = dao_phr.fields.STUDY_LEVEL
            'text_edit_ddl1_PHR_SAKHA.Text = dao_phr.fields.PHR_SAKHA
            text_edit_ddl1_PHR_SAKHA.Text = dao_phr.fields.PHR_VETERINARY_FIELD
            text_edit_ddl1_NAME_SIMINAR.Text = dao_phr.fields.NAME_SIMINAR
            '12/10/2564
            Dim datefull_siminar As Date
            Dim SIMINAR_DATE As String = ""
            Try
                datefull_siminar = dao_phr.fields.SIMINAR_DATE
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
                datefull_PASSPORT_EXPDATE = dao1.fields.GIVE_PASSPORT_EXPDATE
                PASSPORT_EXPDATE = datefull_PASSPORT_EXPDATE.Day & "/" & datefull_PASSPORT_EXPDATE.Month & "/" & datefull_PASSPORT_EXPDATE.Year
                text_edit_ddl3_sub2_GIVE_PASSPORT_EXPDATE.Text = PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl3_sub2_GIVE_WORK_LICENSE_NO.Text = dao1.fields.GIVE_WORK_LICENSE_NO

            Dim datefull_GIVE_WORK_LICENSE_EXPDATE As Date
            Dim WORK_LICENSE_EXPDATE As String = ""

            Try
                datefull_GIVE_WORK_LICENSE_EXPDATE = dao1.fields.GIVE_WORK_LICENSE_EXPDATE
                WORK_LICENSE_EXPDATE = datefull_GIVE_WORK_LICENSE_EXPDATE.Day & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Month & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Year
                text_edit_ddl3_sub2_GIVE_WORK_LICENSE_EXPDATE.Text = WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
        ElseIf _detial_type = 1 Then
            Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
            dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, _ddl1, _ddl2, True)

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
            dao2.GetDataby_IDA(_lct_ida)


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
            dao_get.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, _ddl1, _ddl2, True)

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
            dao_get.GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(_lct_ida, _ddl1, _ddl2, True)

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
                datefull_PASSPORT_EXPDATE = dao1.fields.PASSPORT_EXPDATE
                PASSPORT_EXPDATE = datefull_PASSPORT_EXPDATE.Day & "/" & datefull_PASSPORT_EXPDATE.Month & "/" & datefull_PASSPORT_EXPDATE.Year
                text_edit_ddl9_sub1_PASSPORT_EXPDATE.Text = PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub1_BS_NO.Text = dao1.fields.BS_NO
            Dim datefull_BS_DATE As Date
            Dim BS_DATE As String = ""

            Try
                datefull_BS_DATE = dao1.fields.BS_DATE
                BS_DATE = datefull_BS_DATE.Day & "/" & datefull_BS_DATE.Month & "/" & datefull_BS_DATE.Year
                text_edit_ddl9_sub1_BS_DATE.Text = BS_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub1_WORK_LICENSE_NO.Text = dao1.fields.WORK_LICENSE_NO
            Dim datefull_WORK_LICENSE_EXPDATE As Date
            Dim WORK_LICENSE_EXPDATE As String = ""

            Try
                datefull_WORK_LICENSE_EXPDATE = dao1.fields.WORK_LICENSE_EXPDATE
                WORK_LICENSE_EXPDATE = datefull_WORK_LICENSE_EXPDATE.Day & "/" & datefull_WORK_LICENSE_EXPDATE.Month & "/" & datefull_WORK_LICENSE_EXPDATE.Year
                text_edit_ddl9_sub1_WORK_LICENSE_EXPDATE.Text = WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub1_DOC_NO.Text = dao1.fields.DOC_NO
            Dim datefull_DOC_DATE As Date
            Dim DOC_DATE As String = ""

            Try
                datefull_DOC_DATE = dao1.fields.DOC_DATE
                DOC_DATE = datefull_DOC_DATE.Day & "/" & datefull_DOC_DATE.Month & "/" & datefull_DOC_DATE.Year
                text_edit_ddl9_sub1_DOC_DATE.Text = DOC_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub1_FRGN_NO.Text = dao1.fields.FRGN_NO
            Dim datefull_FRGN_DATE As Date
            Dim FRGN_DATE As String = ""

            Try
                datefull_FRGN_DATE = dao1.fields.FRGN_DATE
                FRGN_DATE = datefull_FRGN_DATE.Day & "/" & datefull_FRGN_DATE.Month & "/" & datefull_FRGN_DATE.Year
                text_edit_ddl9_sub1_FRGN_DATE.Text = FRGN_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
        ElseIf _detial_type = 1 Then
            Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
            dao_get.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, _ddl1, _ddl2, True)

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
                datefull_DOC_DATE = dao1.fields.DOC_DATE
                DOC_DATE = datefull_DOC_DATE.Day & "/" & datefull_DOC_DATE.Month & "/" & datefull_DOC_DATE.Year
                text_edit_ddl9_sub2_DOC_DATE.Text = DOC_DATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
            text_edit_ddl9_sub2_FRGN_NO.Text = dao1.fields.FRGN_NO
            Dim datefull_FRGN_DATE As Date
            Dim FRGN_DATE As String = ""

            Try
                datefull_FRGN_DATE = dao1.fields.FRGN_DATE
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
                datefull_GIVE_PASSPORT_EXPDATE = dao2.fields.GIVE_PASSPORT_EXPDATE
                GIVE_PASSPORT_EXPDATE = datefull_GIVE_PASSPORT_EXPDATE.Day & "/" & datefull_GIVE_PASSPORT_EXPDATE.Month & "/" & datefull_GIVE_PASSPORT_EXPDATE.Year
                text_edit_ddl9_sub2_GIVE_PASSPORT_EXPDATE.Text = GIVE_PASSPORT_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try

            text_edit_ddl9_sub2_GIVE_WORK_LICENSE_NO.Text = dao2.fields.GIVE_WORK_LICENSE_NO
            Dim datefull_GIVE_WORK_LICENSE_EXPDATE As Date
            Dim GIVE_WORK_LICENSE_EXPDATE As String = ""

            Try
                datefull_GIVE_WORK_LICENSE_EXPDATE = dao2.fields.GIVE_WORK_LICENSE_EXPDATE
                GIVE_WORK_LICENSE_EXPDATE = datefull_GIVE_WORK_LICENSE_EXPDATE.Day & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Month & "/" & datefull_GIVE_WORK_LICENSE_EXPDATE.Year
                text_edit_ddl9_sub2_GIVE_WORK_LICENSE_EXPDATE.Text = GIVE_WORK_LICENSE_EXPDATE
            Catch ex As Exception
                'text_edit_ddl1_SIMINAR_DATE.Text = ""
            End Try
        Else _detial_type = 1
            Dim dao_get As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON
            dao_get.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, _ddl1, _ddl2, True)

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
    Private Sub rgphr_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgphr.NeedDataSource
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        'If _lcn_ida <> "" Then
        dt = bao.SP_LCN_EDIT_PHR_BY_FK_IDA(_lcn_ida)
        'End If

        If dt.Rows.Count > 0 Then
            rgphr.DataSource = dt
        End If
    End Sub
End Class
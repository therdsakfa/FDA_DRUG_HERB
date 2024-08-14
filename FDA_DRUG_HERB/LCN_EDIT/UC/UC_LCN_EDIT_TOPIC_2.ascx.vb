Public Class UC_LCN_EDIT_TOPIC_2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'load_ddl_chwt()

        End If
    End Sub


    Public Sub load_ddl_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()
        ddl_Province.DataSource = dt

        ddl_Province.DataBind()

    End Sub
    Public Sub load_ddl_amp()

        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_SYSAMPHR_BY_CHNGWTCD(ddl_Province.SelectedValue)

        ddl_amphor.DataSource = dt
        ddl_amphor.DataBind()
    End Sub
    Public Sub load_ddl_thambol()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(ddl_Province.SelectedValue, ddl_amphor.SelectedValue)
        ddl_tambol.DataSource = dt
        ddl_tambol.DataBind()
    End Sub

    Private Sub ddl_Province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Province.SelectedIndexChanged
        load_ddl_amp()
        load_ddl_thambol()
    End Sub

    Private Sub ddl_amphor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphor.SelectedIndexChanged
        load_ddl_thambol()
    End Sub
    Sub SET_DATA_REASON_TOPIC2(ByVal _lcn_ida As Integer)
        Dim dao1 As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS

        dao1.GetData_By_FK_IDA(_lcn_ida)

        text_edit_topic2_thaaddr.Text = dao1.fields.thaaddr
        text_edit_topic2_thabuilding.Text = dao1.fields.thabuilding
        text_edit_topic2_thamu.Text = dao1.fields.thamu
        text_edit_topic2_thasoi.Text = dao1.fields.thasoi
        text_edit_topic2_tharoad.Text = dao1.fields.tharoad


        Dim thmblcd As Integer = 0
        Dim amphrcd As Integer = 0
        Dim chngwtcd As Integer = 0

        Try
            chngwtcd = dao1.fields.chngwtcd
            ddl_Province.SelectedValue = chngwtcd
            'text_edit_topic2_chngwtcd.Text = chngwtcd.ToString
        Catch ex As Exception
            'text_edit_topic2_chngwtcd.Text = ""
        End Try

        load_ddl_amp()
        load_ddl_thambol()

        Try
            amphrcd = dao1.fields.amphrcd
            ddl_amphor.SelectedValue = amphrcd
        Catch ex As Exception

        End Try
        Try
            thmblcd = dao1.fields.thmblcd
            ddl_tambol.SelectedValue = thmblcd
        Catch ex As Exception

        End Try



        text_edit_topic2_zipcode.Text = dao1.fields.zipcode
        text_edit_topic2_tel.Text = dao1.fields.tel
        text_edit_topic2_fax.Text = dao1.fields.fax
        text_edit_topic2_email.Text = dao1.fields.email
    End Sub
    Sub SET_DATA_OLD_INSERT_REASON_DDL3_SUB1(ByVal _lcn_ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal _detial_type As Integer)

        Dim dao1 As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS

        dao1.GetData_By_FK_IDA(_lcn_ida)

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

        GET_1 = dao1.fields.thaaddr
        GET_2 = dao1.fields.thabuilding
        GET_3 = dao1.fields.thamu
        GET_4 = dao1.fields.thasoi
        GET_5 = dao1.fields.tharoad


        Dim thmblcd As Integer = 0
        Dim amphrcd As Integer = 0
        Dim chngwtcd As Integer = 0
        Try
            thmblcd = dao1.fields.thmblcd
            GET_6 = thmblcd
        Catch ex As Exception

        End Try
        Try
            amphrcd = dao1.fields.amphrcd
            GET_7 = amphrcd
        Catch ex As Exception

        End Try
        Try
            chngwtcd = dao1.fields.chngwtcd
            GET_8 = chngwtcd
        Catch ex As Exception
            GET_8 = ""
        End Try

        GET_9 = dao1.fields.zipcode
        GET_10 = dao1.fields.tel
        GET_11 = dao1.fields.fax
        GET_12 = dao1.fields.email

        'เซฟตัวเก่า
        Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL3_REASON
        Dim dao_old_update As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL3_REASON
        Dim ROW_CHK As String = ""
        Try
            dao_old_update.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)
            ROW_CHK = "HAVE"
        Catch ex As Exception
            ROW_CHK = "NULL"
        End Try
        If ROW_CHK = "HAVE" Then
            dao_old_update.fields.ACTIVE = 0
            dao_old_update.fields.UPDATE_DATE = System.DateTime.Now
            dao_old_update.update()
        End If
        dao_old.fields.FK_LCN_IDA = _lcn_ida
        dao_old.fields.ddl1 = ddl1
        dao_old.fields.ddl2 = ddl2

        dao_old.fields.thaaddr = GET_1
        dao_old.fields.thabuilding = GET_2
        dao_old.fields.thamu = GET_3
        dao_old.fields.thasoi = GET_4
        dao_old.fields.tharoad = GET_5

        Try
            dao_old.fields.thmblcd = GET_6
        Catch ex As Exception
            dao_old.fields.thmblcd = 0
        End Try

        Try
            dao_old.fields.amphrcd = GET_7
        Catch ex As Exception
            dao_old.fields.amphrcd = 0
        End Try
        Try
            dao_old.fields.chngwtcd = GET_8
        Catch ex As Exception
            dao_old.fields.chngwtcd = 0
        End Try

        dao_old.fields.zipcode = GET_9
        dao_old.fields.tel = GET_10
        dao_old.fields.fax = GET_11
        dao_old.fields.email = GET_12

        dao_old.fields.CREATE_DATE = System.DateTime.Now
        dao_old.fields.ACTIVE = 1

        dao_old.insert()
    End Sub
    Sub SET_DATA_INSERT_REASON_DDL3_SUB1(ByVal _lcn_ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal _detial_type As Integer)
        'เซฟตัวเก่า
        SET_DATA_OLD_INSERT_REASON_DDL3_SUB1(_lcn_ida, ddl1, ddl2, _detial_type)

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
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
        dao1.fields.FK_LCN_IDA = _lcn_ida
        dao1.fields.ddl1 = ddl1
        dao1.fields.ddl2 = ddl2

        dao1.fields.thaaddr = text_edit_topic2_thaaddr.Text
        dao1.fields.thabuilding = text_edit_topic2_thabuilding.Text
        dao1.fields.thamu = text_edit_topic2_thamu.Text
        dao1.fields.thasoi = text_edit_topic2_thasoi.Text
        dao1.fields.tharoad = text_edit_topic2_tharoad.Text

        dao1.fields.thmblcd = ddl_tambol.SelectedValue
        dao1.fields.amphrcd = ddl_amphor.SelectedValue
        dao1.fields.chngwtcd = ddl_Province.SelectedValue

        dao1.fields.zipcode = text_edit_topic2_zipcode.Text
        dao1.fields.tel = text_edit_topic2_tel.Text
        dao1.fields.fax = text_edit_topic2_fax.Text
        dao1.fields.email = text_edit_topic2_email.Text

        dao1.fields.CREATE_DATE = System.DateTime.Now
        dao1.fields.ACTIVE = 1

        dao1.insert()
    End Sub
    Sub SET_DATA_SEE_DETAIL_DDL3(ByVal _lcn_ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer)
        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL3_REASON
        dao1.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_lcn_ida, ddl1, ddl2, True)

        text_edit_topic2_thaaddr.Text = dao1.fields.thaaddr
        text_edit_topic2_thabuilding.Text = dao1.fields.thabuilding
        text_edit_topic2_thamu.Text = dao1.fields.thamu
        text_edit_topic2_thasoi.Text = dao1.fields.thasoi
        text_edit_topic2_tharoad.Text = dao1.fields.tharoad

        Dim thmblcd As Integer = 0
        Dim amphrcd As Integer = 0
        Dim chngwtcd As Integer = 0

        load_ddl_chwt()

        Try
            chngwtcd = dao1.fields.chngwtcd
            ddl_Province.SelectedValue = chngwtcd
            'text_edit_topic2_chngwtcd.Text = chngwtcd.ToString
        Catch ex As Exception
            'text_edit_topic2_chngwtcd.Text = ""
        End Try

        load_ddl_amp()
        load_ddl_thambol()

        Try
            amphrcd = dao1.fields.amphrcd
            ddl_amphor.SelectedValue = amphrcd
        Catch ex As Exception

        End Try
        Try
            thmblcd = dao1.fields.thmblcd
            ddl_tambol.SelectedValue = thmblcd
        Catch ex As Exception

        End Try


        text_edit_topic2_zipcode.Text = dao1.fields.zipcode
        text_edit_topic2_tel.Text = dao1.fields.tel
        text_edit_topic2_fax.Text = dao1.fields.fax
        text_edit_topic2_email.Text = dao1.fields.email


    End Sub

    'อาจจะมีเปลี่ยน การกรอก ยังไม่แน่ใจตอนนี้
    'Sub SET_DATA_INSERT_REASON_DDL9_SUB3(ByVal _lcn_ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer)
    '    Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL9_REASON

    '    dao1.fields.FK_LCT_IDA = _lcn_ida
    '    dao1.fields.ddl1 = ddl1
    '    dao1.fields.ddl2 = ddl2

    '    dao1.fields.thaaddr = text_edit_topic2_thaaddr.Text
    '    dao1.fields.thabuilding = text_edit_topic2_thabuilding.Text
    '    dao1.fields.thamu = text_edit_topic2_thamu.Text
    '    dao1.fields.thasoi = text_edit_topic2_thasoi.Text
    '    dao1.fields.tharoad = text_edit_topic2_tharoad.Text

    '    dao1.fields.thmblcd = text_edit_topic2_thmblcd.Text
    '    dao1.fields.amphrcd = text_edit_topic2_amphrcd.Text
    '    dao1.fields.chngwtcd = text_edit_topic2_chngwtcd.Text

    '    dao1.fields.zipcode = text_edit_topic2_zipcode.Text
    '    dao1.fields.tel = text_edit_topic2_tel.Text
    '    dao1.fields.fax = text_edit_topic2_fax.Text
    '    dao1.fields.email = text_edit_topic2_email.Text

    '    dao1.fields.CREATE_DATE = System.DateTime.Now
    '    dao1.fields.ACTIVE = 1

    '    dao1.insert()
    'End Sub
    Sub SET_DATA_SEE_DETAIL_DDL9_SUB3(ByVal _lcn_ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer)

    End Sub


End Class
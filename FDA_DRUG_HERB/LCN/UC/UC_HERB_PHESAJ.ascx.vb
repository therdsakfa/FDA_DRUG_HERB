Imports Telerik.Web.UI

Public Class UC_HERB_PHESAJ
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
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

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    RunSession()
    '    If Not IsPostBack Then
    '        If _ProcessID = "122" Then
    '            rdl_mastra.SelectedValue = "1"
    '        ElseIf _ProcessID = "121" Then
    '            rdl_mastra.SelectedValue = "2"
    '        ElseIf _ProcessID = "120" Then
    '            rdl_mastra.SelectedValue = "3"
    '        End If
    '    End If
    'End Sub
    'Sub bind_ddl_phr_type()
    '    Try
    '        Dim dao As New DAO_DRUG.TB_MAS_TYPE_PHR_HERB
    '        dao.GetDataAll()
    '        ddl_phr_type.DataSource = dao.datas
    '        ddl_phr_type.DataValueField = "TYPE_ID"
    '        ddl_phr_type.DataTextField = "TYPE_PHR_HERB"
    '        ddl_phr_type.DataBind()

    '        Dim item As New ListItem
    '        item.Text = "--กรุณาเลือก--"
    '        item.Value = "0"
    '        ddl_phr_type.Items.Insert(0, item)
    '    Catch ex As Exception

    '    End Try


    'End Sub
    'Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
    '    Dim CITIZEN_ID_AUTHORIZE As String = ""
    '    Try
    '        CITIZEN_ID_AUTHORIZE = txt_PHR_CTZNO.Text
    '    Catch ex As Exception

    '    End Try

    '    Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
    '    Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

    '    Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
    '    dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
    '    If dao_syslcnsid.fields.IDA = 0 Then
    '        Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
    '    Else
    '        Try
    '            txt_PHR_NAME.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
    '        Catch ex As Exception

    '        End Try
    '        'Try
    '        '    ddl_prefix.DropDownSelectData(ws_taxno.SYSLCNSNMs.prefixcd)
    '        'Catch ex As Exception

    '        'End Try
    '    End If
    'End Sub

    'Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
    '    Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
    '    set_data(dao)
    '    dao.fields.FK_IDA = Request.QueryString("ida")
    '    dao.insert()

    '    Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
    '    rgphr.Rebind()
    'End Sub
    'Public Sub bind_ddl_prefix()
    '    Dim bao As New BAO_SHOW
    '    Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

    '    ddl_prefix.DataSource = dt
    '    ddl_prefix.DataBind()
    'End Sub

    'Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBDALCN_PHR)
    '    With dao.fields
    '        .PHR_NAME = txt_PHR_NAME.Text
    '        '.PHR_LEVEL = txt_PHR_LEVEL.Text
    '        .PHR_PREFIX_ID = ddl_prefix.SelectedValue
    '        .PHR_PREFIX_NAME = ddl_prefix.SelectedItem.Text
    '        .PHR_CTZNO = txt_PHR_CTZNO.Text
    '        .PHR_TEXT_NUM = txt_PHR_TEXT_NUM.Text
    '        .PHR_TEXT_WORK_TIME = txt_PHR_TEXT_WORK_TIME.Text
    '        If ddl_phr_type.SelectedValue = "0" Then
    '            .STUDY_LEVEL = txt_STUDY_LEVEL.Text
    '        Else
    '            Try
    '                .STUDY_LEVEL = ddl_phr_type.SelectedItem.Text
    '                .PHR_JOB_TYPE = ddl_phr_type.SelectedValue
    '            Catch ex As Exception

    '            End Try

    '        End If
    '        Try
    '            .PHR_VETERINARY_FIELD = txt_PHR_VETERINARY_FIELD.Text
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            .PHR_LAW_SECTION = rdl_mastra.SelectedValue
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            .SIMINAR_DATE = rdp_SIMINAR_DATE.SelectedDate
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            .NAME_SIMINAR = txt_NAME_SIMINAR.Text
    '        Catch ex As Exception

    '        End Try
    '        'Try
    '        '    .PHR_JOB_TYPE = ddl_job.SelectedValue
    '        'Catch ex As Exception

    '        'End Try
    '        Try
    '            .PERSONAL_TYPE = ddl_phr_type.SelectedValue 'rdl_per_type.SelectedValue
    '        Catch ex As Exception

    '        End Try
    '        'Try
    '        '    If ddl_worker_type.SelectedValue = "12" Or ddl_worker_type.SelectedValue = "15" Then
    '        '        .PHR_MEDICAL_TYPE = 3
    '        '    End If
    '        'Catch ex As Exception

    '        'End Try
    '        'Try
    '        '    .PHR_TEXT_JOB = txt_PHR_TEXT_JOB.Text
    '        'Catch ex As Exception

    '        'End Try
    '        'Try
    '        '    .PHR_MEDICAL_TYPE = ddl_PHR_MEDICAL_TYPE.SelectedValue
    '        'Catch ex As Exception

    '        'End Try
    '    End With
    'End Sub

    'Private Sub rgphr_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgphr.NeedDataSource
    '    Dim bao As New BAO_MASTER
    '    Dim dt As New DataTable
    '    If Request.QueryString("ida") <> "" Then
    '        dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(Request.QueryString("ida"))
    '    End If


    '    If dt.Rows.Count > 0 Then
    '        rgphr.DataSource = dt
    '    End If
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_DDL_STUDY_LEVEL()
            bind_DDL_VETERINARY_FIELD()
            bind_ddl_training_phr()
            If _ProcessID = "122" Then
                rdl_mastra.SelectedValue = "1"
            ElseIf _ProcessID = "121" Then
                rdl_mastra.SelectedValue = "2"
            ElseIf _ProcessID = "120" Then
                rdl_mastra.SelectedValue = "3"
            End If
        End If
    End Sub
    Sub bind_ddl_phr_type()
        Try
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_PHR_HERB
            dao.GetDataAll()
            ddl_phr_type.DataSource = dao.datas
            ddl_phr_type.DataValueField = "TYPE_ID"
            ddl_phr_type.DataTextField = "TYPE_PHR_HERB"
            ddl_phr_type.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_phr_type.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_DDL_STUDY_LEVEL()
        Try
            Dim dao As New DAO_LCN.TB_MAS_TYPE_QUALIFICATION
            dao.GetDataAll()
            DDL_STUDY_LEVEL.DataSource = dao.datas
            DDL_STUDY_LEVEL.DataValueField = "ID"
            DDL_STUDY_LEVEL.DataTextField = "NAME"
            DDL_STUDY_LEVEL.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            DDL_STUDY_LEVEL.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_ddl_training_phr()
        Try
            Dim bao As New BAO_SHOW
            Dim dt As DataTable = bao.SP_MAS_DALCN_PHR_TRAINING()
            ddl_training_phr.DataSource = dt
            ddl_training_phr.DataValueField = "TRAINING_ID"
            ddl_training_phr.DataTextField = "TRAINING_DATE"
            ddl_training_phr.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_training_phr.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_DDL_VETERINARY_FIELD()
        Try
            Dim dao As New DAO_LCN.TB_MAS_TYPE_MAJOR
            dao.GetDataAll()
            DDL_VETERINARY_FIELD.DataSource = dao.datas
            DDL_VETERINARY_FIELD.DataValueField = "ID"
            DDL_VETERINARY_FIELD.DataTextField = "NAME"
            DDL_VETERINARY_FIELD.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            DDL_VETERINARY_FIELD.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_PHR_CTZNO.Text
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
                txt_PHR_NAME.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            Catch ex As Exception

            End Try
            'Try
            '    ddl_prefix.DropDownSelectData(ws_taxno.SYSLCNSNMs.prefixcd)
            'Catch ex As Exception

            'End Try
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        If ddl_prefix.Text = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกคำนำหน้า');</script> ")
        ElseIf ddl_phr_type.SelectedValue = "0" And ddl_STUDY_LEVEL.SelectedValue = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาระบุคุณวุฒิ');</script> ")
        ElseIf txt_PHR_TEXT_WORK_TIME.Text = "" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกเวลาทำการ');</script> ")
        Else
            set_data(dao)
            dao.fields.FK_IDA = Request.QueryString("ida")
            dao.insert()

            Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
            rgphr.Rebind()
        End If
        Check_infor()

    End Sub

    Public Sub Check_infor()
        If ddl_prefix.Text = "0" Then
            Label1.Style.Add("display", "initial")
        Else Label1.Style.Add("display", "none")
        End If
        If ddl_phr_type.SelectedValue = "0" And DDL_STUDY_LEVEL.SelectedValue = "0" Then
            Label2.Style.Add("display", "initial")
            Label3.Style.Add("display", "initial")
        Else Label2.Style.Add("display", "none")
            Label3.Style.Add("display", "none")
        End If
        If txt_PHR_TEXT_WORK_TIME.Text = "" Then
            Label4.Style.Add("display", "initial")
        Else Label4.Style.Add("display", "none")
        End If
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub

    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBDALCN_PHR)
        With dao.fields
            .PHR_NAME = txt_PHR_NAME.Text
            '.PHR_LEVEL = txt_PHR_LEVEL.Text
            .PHR_PREFIX_ID = ddl_prefix.SelectedValue
            .PHR_PREFIX_NAME = ddl_prefix.SelectedItem.Text
            .PHR_CTZNO = txt_PHR_CTZNO.Text
            .PHR_TEXT_NUM = txt_PHR_TEXT_NUM.Text
            .PHR_TEXT_WORK_TIME = txt_PHR_TEXT_WORK_TIME.Text
            If ddl_phr_type.SelectedValue = "0" Then
                .STUDY_LEVEL = DDL_STUDY_LEVEL.SelectedItem.Text
            Else
                Try
                    .STUDY_LEVEL = ddl_phr_type.SelectedItem.Text
                    .PHR_JOB_TYPE = ddl_phr_type.SelectedValue
                Catch ex As Exception

                End Try

            End If
            Try
                .PHR_VETERINARY_FIELD = DDL_VETERINARY_FIELD.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                .PHR_LAW_SECTION = rdl_mastra.SelectedValue
            Catch ex As Exception

            End Try
            Try
                .SIMINAR_DATE = rdp_SIMINAR_DATE.SelectedDate
            Catch ex As Exception

            End Try
            Try
                .SIMINAR_DATE_END = rdp_SIMINAR_DATE_END.SelectedDate
            Catch ex As Exception

            End Try
            Try
                '.NAME_SIMINAR = txt_NAME_SIMINAR.Text
            Catch ex As Exception

            End Try
            'Try
            '    .PHR_JOB_TYPE = ddl_job.SelectedValue
            'Catch ex As Exception

            'End Try
            Try
                .PERSONAL_TYPE = ddl_phr_type.SelectedValue 'rdl_per_type.SelectedValue
            Catch ex As Exception

            End Try
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

    Private Sub rgphr_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rgphr.NeedDataSource
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        If Request.QueryString("ida") <> "" Then
            dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(Request.QueryString("ida"))
        End If


        If dt.Rows.Count > 0 Then
            rgphr.DataSource = dt
        End If
    End Sub
    Private Sub rgns_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgphr.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim _ida As String = item("PHR_IDA").Text
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            If e.CommandName = "r_del" Then
                dao.GetDataby_IDA(_ida)
                dao.delete()
                rgphr.Rebind()
            End If
        End If
    End Sub

    Protected Sub ddl_phr_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_phr_type.SelectedIndexChanged
        If ddl_phr_type.SelectedValue = 32 Then
            Div_Major.Visible = True
            Div_Qualificate.Visible = True
            Div_Txt_num.Visible = False
        Else
            Div_Major.Visible = False
            Div_Qualificate.Visible = False
            Div_Txt_num.Visible = True
        End If
    End Sub

    Protected Sub ddl_training_phr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_training_phr.SelectedIndexChanged
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_MAS_DALCN_PHR_TRAINING()
        Dim dao As New DAO_LCN.TB_MAS_DALCN_PHR_TRAINING
        dao.GetDataby_TRAINING_ID(ddl_training_phr.SelectedValue)
        rdp_SIMINAR_DATE.SelectedDate = dao.fields.TRAINING_DATE_START
        rdp_SIMINAR_DATE_END.SelectedDate = dao.fields.TRAINING_DATE_END
    End Sub
End Class
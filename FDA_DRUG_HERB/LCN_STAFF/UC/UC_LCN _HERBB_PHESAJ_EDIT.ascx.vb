Imports Telerik.Web.UI
Public Class UC_LCN__HERBB_PHESAJ_EDIT
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Public PHR_NAME As String = ""
    Public PHR_IDA As String = ""
    Public IDA As String = ""
    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        PHR_IDA = Request.QueryString("PHR_IDA")
        IDA = Request.QueryString("IDA")
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
        'If Not IsPostBack Then
        '    If _ProcessID = "122" Then
        '        rdl_mastra.SelectedValue = "1"
        '    ElseIf _ProcessID = "121" Then
        '        rdl_mastra.SelectedValue = "2"
        '    ElseIf _ProcessID = "120" Then
        '        rdl_mastra.SelectedValue = "3"
        '    End If

        'End If
        'Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        'dao.GetDataby_IDA(Request.QueryString("PHR_IDA"))
        'Get_data(dao)
        'If Request.QueryString("phr_ida") <> "" Then
        '    Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        '    dao.GetDataby_IDA(Request.QueryString("phr_ida"))
        '    'Get_data(dao)
        '    Set_Hide()
        'End If
    End Sub
    Sub get_PHR_NAME()
        PHR_NAME = txt_PHR_NAME.Text
    End Sub
    Sub bind_lcn_type()
        Dim dao As New DAO_DRUG.TB_MAS_TYPE_PHR_HERB
        Try
            dao.GetData_by_TYPE_ID(ddl_phr_type.SelectedValue)
            'lbl_lcn_type.Text = dao.fields.lcndtlnm
        Catch ex As Exception

        End Try

    End Sub
    Sub select_mastra(ByVal _ProcessID As String)
        If Not IsPostBack Then
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
                .STUDY_LEVEL = txt_STUDY_LEVEL.Text
            Else
                Try
                    .STUDY_LEVEL = ddl_phr_type.SelectedItem.Text
                    .PHR_JOB_TYPE = ddl_phr_type.SelectedValue
                Catch ex As Exception

                End Try

            End If
            Try
                .PHR_VETERINARY_FIELD = txt_PHR_VETERINARY_FIELD.Text
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
                .NAME_SIMINAR = txt_NAME_SIMINAR.Text
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
    Public Sub Get_data(ByRef dao As DAO_DRUG.ClsDBDALCN_PHR)
        With dao.fields
            txt_PHR_NAME.Text = .PHR_NAME
            'txt_PHR_LEVEL.Text = .PHR_LEVEL
            Try
                ddl_prefix.DropDownSelectData(.PHR_PREFIX_ID)
            Catch ex As Exception

            End Try
            'Try
            '    ddl_job.DropDownSelectData(.PHR_JOB_TYPE)
            'Catch ex As Exception

            'End Try
            'Try
            '    ddl_law.DropDownSelectData(.PHR_LAW_SECTION)
            'Catch ex As Exception

            'End Try
            txt_PHR_VETERINARY_FIELD.Text = .PHR_VETERINARY_FIELD
            txt_PHR_CTZNO.Text = .PHR_CTZNO
            txt_PHR_TEXT_NUM.Text = .PHR_TEXT_NUM
            txt_PHR_TEXT_WORK_TIME.Text = .PHR_TEXT_WORK_TIME
            txt_STUDY_LEVEL.Text = .STUDY_LEVEL
            Try
                'rdl_per_type.SelectedValue = .PERSONAL_TYPE
                ddl_phr_type.DropDownSelectData(.PERSONAL_TYPE)
            Catch ex As Exception
                'rdl_per_type.SelectedValue = 1
            End Try
            'Try
            '    txt_PHR_TEXT_JOB.Text = .PHR_TEXT_JOB
            'Catch ex As Exception

            'End Try
            'Try
            '    ddl_PHR_MEDICAL_TYPE.DropDownSelectData(.PHR_MEDICAL_TYPE)
            'Catch ex As Exception

            'End Try
            'Try
            '    .SIMINAR_DATE = rdp_SIMINAR_DATE.SelectedDate
            'Catch ex As Exception

            'End Try

            'rgns.DataBind()

        End With
    End Sub
    Private Sub ddl_phr_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_phr_type.SelectedIndexChanged
        'bind_lcn_type()
        set_data_sakha()
    End Sub
    Sub set_data_sakha()
        Try
            txt_PHR_VETERINARY_FIELD.Text = ddl_phr_type.SelectedItem.Text
        Catch ex As Exception

        End Try

    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
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

    Private Sub rgphr_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgphr.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim _ida As String = item("PHR_IDA").Text
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            Dim name_del As String
            If e.CommandName = "r_del" Then
                dao.GetDataby_IDA(_ida)
                name_del = dao.fields.PHR_NAME
                dao.delete()
                rgphr.Rebind()

                KEEP_LOGS_EDIT(Request.QueryString("ida"), "ลบผู้มีหน้าที่ปฏิบัติการ " & name_del, _CLS.CITIZEN_ID)
            ElseIf e.CommandName = "edt" Then
                ' Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri & "&phr_ida=" & _ida)
                dao.GetDataby_IDA(_ida)
                Get_data(dao)
                'Set_Hide()
            End If
        End If
    End Sub
    Public Sub CLEAR_DATA()
        txt_PHR_NAME.Text = ""
        ' txt_PHR_LEVEL.Text = ""
        ddl_prefix.SelectedValue = Nothing
        'ddl_prefix.SelectedItem.Text = Noting
        txt_PHR_CTZNO.Text = ""
        txt_PHR_TEXT_NUM.Text = ""
        txt_PHR_TEXT_WORK_TIME.Text = ""
        ddl_phr_type.SelectedValue = Nothing
        txt_PHR_VETERINARY_FIELD.Text = ""
        'rdl_mastra.SelectedValue = Nothing
        rdp_SIMINAR_DATE.SelectedDate = Nothing
        txt_NAME_SIMINAR.Text = ""
        ddl_phr_type.SelectedValue = Nothing

    End Sub

    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(PHR_IDA)
        set_data(dao)
        If txt_PHR_TEXT_WORK_TIME.Text <> "" And txt_PHR_TEXT_NUM.Text <> "" Or txt_STUDY_LEVEL.Text <> "" Then
            set_data(dao)
            dao.update()
            Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
            rgphr.Rebind()
            'CLEAR_DATA()

            KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขผู้ปฏิบัติการจาก " & dao.fields.PHR_NAME & " เป็น " & PHR_NAME, _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
            Response.Redirect("../LCN_STAFF/POPUP_STAFF_LCN_INSERT.aspx?IDA=" & IDA & "&process_id=" & _ProcessID)
        Else
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูลให้ครบถ้วน');</script> ")
        End If

    End Sub
End Class
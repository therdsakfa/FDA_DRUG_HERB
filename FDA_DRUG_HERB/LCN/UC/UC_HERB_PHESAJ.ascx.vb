﻿Imports Telerik.Web.UI

Public Class UC_HERB_PHESAJ
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        set_data(dao)
        dao.insert()

        Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
        rgphr.Rebind()
    End Sub

    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBDALCN_PHR)
        With dao.fields
            .PHR_NAME = txt_PHR_NAME.Text
            '.PHR_LEVEL = txt_PHR_LEVEL.Text
            '.PHR_PREFIX_ID = ddl_prefix.SelectedValue
            '.PHR_PREFIX_NAME = ddl_prefix.SelectedItem.Text
            '.PHR_CTZNO = txt_PHR_CTZNO.Text
            '.PHR_TEXT_NUM = txt_PHR_TEXT_NUM.Text
            '.PHR_TEXT_WORK_TIME = txt_PHR_TEXT_WORK_TIME.Text
            '.PHR_VETERINARY_FIELD = txt_PHR_VETERINARY_FIELD.Text
            'Try
            '    .PHR_LAW_SECTION = ddl_law.SelectedValue
            'Catch ex As Exception

            'End Try

            'Try
            '    .PHR_JOB_TYPE = ddl_job.SelectedValue
            'Catch ex As Exception

            'End Try
            'Try
            '    .PERSONAL_TYPE = ddl_worker_type.SelectedValue 'rdl_per_type.SelectedValue
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
End Class
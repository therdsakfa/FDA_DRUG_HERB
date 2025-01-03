﻿Imports Telerik.Web.UI
Public Class FRM_LCN_SUBSTITUTE_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _pvncd As Integer
    Sub RunSession()
        Try
            '_rgt_ida = Request.QueryString("rgt_ida")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            '_process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            '_lct_ida = Request.QueryString("lct_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
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
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
            dao.Getdata_by_IDA(IDA)
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Dim tebean_ida As Integer = 0
            Try
                tebean_ida = dao.fields.FK_IDA
            Catch ex As Exception

            End Try
            Dim _process_id As Integer = 0

            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Try
                dao_tr.GetDataby_IDA(tr_id)
                _process_id = dao_tr.fields.PROCESS_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../LCN_SUBSTITUTE_STAFF/FRM_STAFF_LCN_SUBSTITUTE_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&Process=" & _process_id & "');", True)
            ElseIf e.CommandName = "print" Then
                Dim dao_rg As New DAO_DRUG.ClsDBdalcn
                dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
                Dim process_s As String = ""
                Try
                    _process_id = dao_rg.fields.PROCESS_ID
                Catch ex As Exception

                End Try
                Try
                    process_s = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../LCN_SUBSTITUTE_STAFF/FRM_STAFF_LCN_SUBSTITUTE_CONFIRM.aspx?IDA=" & dao_rg.fields.IDA & "&TR_ID=" & dao_rg.fields.TR_ID & "&Process=" & _process_id & "&Process_s=" & process_s & "&IDA_S=" & IDA & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            If _pvncd = 10 Then
                dt = bao.SP_DALCN_SUBSTITUTE_STAFF()
            Else
                dt = bao.SP_DALCN_SUBSTITUTE_STAFF_BY_PVNCD(_pvncd)
            End If
            'dt = bao.SP_DALCN_SUBSTITUTE_STAFF()
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class
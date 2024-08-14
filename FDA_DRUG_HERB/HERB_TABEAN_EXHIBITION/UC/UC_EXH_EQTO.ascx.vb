Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization
Public Class UC_EXH_EQTO
    Inherits System.Web.UI.UserControl

    Dim _IDA As String
    Dim STATUS_ID As Integer = 0
    Dim PROCESS_ID As String
    Dim PAGE_ID As String

    Private _MENU_GROUP As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _HERB_ID As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _IDA_DQ As String = ""
    Private _PROCESS_ID As String = ""
    Private TR_ID_DQ As String = ""
    Private _SID As String = ""
    Private _R_ID As String = ""
    Private _CLS As New CLS_SESSION
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
        PROCESS_ID = Request.QueryString("PROCESS_ID")
        PAGE_ID = Request.QueryString("PAGE_ID")
        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
            End If
            If Request.QueryString("HERB_ID") <> "" Then
                _HERB_ID = Request.QueryString("HERB_ID")
            End If
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            bind_unit()
            bind_unit_end()
        End If
    End Sub

    Protected Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        RunQuery()
        If ddl_unit.SelectedValue <> 0 And txt_QTY.Text <> "" Then
            'Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            'dao_rg.GetDataby_IDA(Request.QueryString("idr"))
            'dao_rg.fields.lmdfdate = Date.Now
            'dao_rg.update()
            For Each item As GridDataItem In rg_search_iowa.SelectedItems
                'Dim dao As New DAO_DRUG.TB_DRRQT_EQTO
                'Dim dao As New DAO_TABEAN_HERB.tb_mas_TABEAN_EXH_EQTO
                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EQTO
                dao.fields.IOWA = item("iowacd").Text
                dao.fields.QTY = txt_QTY.Text
                dao.fields.FK_IDA = _IDA
                'Dim dao_max As New DAO_DRUG.TB_DRRQT_EQTO
                Dim dao_max As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EQTO
                'dao_max.GET_MAX_ROWS_ID_SET(_IDA, Request.QueryString("fk_set"))
                dao_max.GET_MAX_ROWS_ID_SET(_IDA, Request.QueryString("fk_set"))
                Dim id_max As Integer = 0
                Try
                    id_max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                Try
                    dao.fields.MULTIPLY = txt_mulyiply.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.STR_VALUE = txt_str.Text
                Catch ex As Exception

                End Try
                dao.fields.aori = ddl_aori.SelectedItem.Text
                dao.fields.SUNITCD = ddl_unit.SelectedValue
                dao.fields.ROWS = id_max + 1
                dao.fields.FK_SET = Request.QueryString("fk_set")
                dao.fields.QTY_END = txt_QTY_END.Text
                dao.fields.SUNITCD_END = ddl_unit_end.SelectedValue
                dao.fields.REF = txt_ref.Text
                dao.fields.REMARK = txt_remark.Text
                dao.insert()
            Next
            KEEP_LOGS_TABEAN_EDIT(_IDA, "แก้ไขEQTO_JJ", _CLS.CITIZEN_ID)
            rg_chem.Rebind()
        Else
            alert("กรุณากรอกข้อมูลให้ครบ")
        End If
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Private Sub rg_chem_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_chem.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            If e.CommandName = "_del" Then
                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EQTO
                dao.GetDataby_IDA(IDA)
                dao.delete()

                rg_chem.Rebind()
            End If

        End If
    End Sub
    Public Sub bind_unit()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit.DataSource = dt
        ddl_unit.DataTextField = "sunitnmsht"
        ddl_unit.DataValueField = "sunitcd"
        ddl_unit.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit_end()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit_end.DataSource = dt
        ddl_unit_end.DataTextField = "sunitnmsht"
        ddl_unit_end.DataValueField = "sunitcd"
        ddl_unit_end.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit_end.Items.Insert(0, item)
    End Sub

    Private Sub rg_chem_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_chem.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim lbl_rows As Label = DirectCast(item("ROWS").FindControl("lbl_rows"), Label)
            Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EQTO
            dao.GetDataby_IDA(item("IDA").Text)
            Try
                txt_rows.Text = dao.fields.ROWS

            Catch ex As Exception

            End Try
            Try
                lbl_rows.Text = dao.fields.ROWS
            Catch ex As Exception

            End Try
        End If

        'End If
    End Sub
    Private Sub rg_chem_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_chem.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable

        'dt = bao.SP_DRRQT_EQTO_BY_FK_IDA(_IDA)
        'dt = bao.SP_TABEAN_EXH_EQTO_BY_FK_IDA(_IDA)
        dt = bao.SP_MAS_TABEAN_EXH_EQTO_BY_FK_IDA(_IDA)

        rg_chem.DataSource = dt
    End Sub
    Private Sub rg_search_iowa_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_search_iowa.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        If txt_search.Text <> "" Then
            dt = bao.SP_DRIOWA_SEARCH_RESULT(txt_search.Text)
        End If

        rg_search_iowa.DataSource = dt
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        rg_search_iowa.Rebind()
    End Sub

    Private Sub btn_rows_save_Click(sender As Object, e As EventArgs) Handles btn_rows_save.Click
        For Each item As GridDataItem In rg_chem.Items
            Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)
            Try
                'Dim dao As New DAO_DRUG.TB_DRRQT_EQTO
                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EQTO
                dao.GetDataby_IDA(item("IDA").Text)
                dao.fields.ROWS = Trim(txt_rows.Text)
                dao.update()
            Catch ex As Exception

            End Try
        Next
        rg_chem.Rebind()
    End Sub
End Class
Imports System.IO
Imports System.Xml.Serialization
Imports System.Globalization
Imports System.Xml
Imports Telerik.Web.UI
Public Class UC_EXH_DETAIL_CAS
    Inherits System.Web.UI.UserControl

    Dim _IDA As String
    Dim _PROCESS_ID As String
    Dim STATUS_ID As String = "0"
    Private _CLS As New CLS_SESSION
    Sub RunQuery()
        '_IDA = Request.QueryString("IDA")
        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_TabeanEXH_Status_by_trid(Request.QueryString("TR_ID"))
            End If
            If Request.QueryString("IDA") <> "" Then
                _IDA = Request.QueryString("IDA")
                'ElseIf Request.QueryString("HERB_ID") <> "" Then
                '    _HERB_ID = Request.QueryString("HERB_ID")
            Else
                _IDA = Request.QueryString("IDA_JJ")
            End If
            If Request.QueryString("PROCESS_ID") <> "" Then
                _PROCESS_ID = Request.QueryString("PROCESS_ID")
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
            set_hide()
            If Request.QueryString("tt") <> "" Then
                btn_rows_save.Enabled = False
                btn_select.Enabled = False
                btn_save.Enabled = False

            End If

            'If STATUS_ID = 8 Then
            '    btn_rows_save.Enabled = False
            '    btn_select.Enabled = False
            '    btn_save.Enabled = False

            'End If
        End If
    End Sub

    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Sub get_data_drgperunit()
        RunQuery()
        'If STATUS_ID = 8 Then
        '    Dim dao1 As New DAO_DRUG.ClsDBdrrgt
        '    dao1.GetDataby_FK_DRRQT(_IDA)
        '    Dim dao As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
        '    dao.GetDataby_FKIDA(dao1.fields.IDA)
        'Else

        'End If
    End Sub

    Private Sub rg_chem_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_chem.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                If Request.QueryString("tt") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                    'ElseIf STATUS_ID = 8 Then
                    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                Else

                    Dim FK_SET As Integer = 0
                    Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
                    dao.GetDataby_IDA(IDA)
                    FK_SET = dao.fields.FK_SET
                    dao.delete()

                    dao = New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
                    dao.GetDataby_FK_IDA_ORDER(_IDA, FK_SET)
                    Dim i As Integer = 1
                    For Each dao.fields In dao.datas
                        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
                        dao_up.GetDataby_IDA(dao.fields.IDA)
                        dao_up.fields.ROWS = i
                        dao_up.update()
                        i += 1
                    Next


                    rg_chem.Rebind()
                End If
            ElseIf e.CommandName = "_eqto" Then
                Dim url As String = "../HERB_TABEAN_EXHIBITION/FRM_TABEAN_EXH_EQTO.aspx?IDA=" & IDA & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&idr=" & _IDA & "&STATUS_ID=" & STATUS_ID & "&fk_set=" & item("FK_SET").Text
                If Request.QueryString("e") <> "" Then
                    url &= "&e=1"
                End If
                Response.Write("<script>window.open('" & url & "','_blank')</script>")
                'Response.Redirect(url)
            End If

        End If
    End Sub

    Private Sub rg_chem_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_chem.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim lbl_rows As Label = DirectCast(item("ROWS").FindControl("lbl_rows"), Label)
            Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
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
    End Sub


    Private Sub rg_chem_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_chem.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        RunQuery()

        'dt = bao.SP_DRRQT_DETAIL_CAS_BY_FK_IDAV2(_IDA)
        dt = bao.SP_TABEAN_EXH_DETAIL_CAS_BY_FK_IDA(_IDA, ddl_set.SelectedValue)


        rg_chem.DataSource = dt
    End Sub
    Public Sub get_data_head()
        'Dim dao As New DAO_DRUG.ClsDBdrrgt
        'dao.GetDataby_IDA(_IDA)
        Try
            'txt_quantity.Text = dao.fields.
        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_unit1()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit1.DataSource = dt
        'ddl_unit1.DataTextField = "sunitnmsht"
        'ddl_unit1.DataValueField = "sunitcd"
        'ddl_unit1.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit.Items.Insert(0, item)
    End Sub
    'Public Sub bind_unit2()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO_MASTER
    '    dt = bao.SP_MASTER_drsunit()

    '    ddl_unit2.DataSource = dt
    '    ddl_unit2.DataTextField = "sunitnmsht"
    '    ddl_unit2.DataValueField = "sunitcd"
    '    ddl_unit2.DataBind()

    '    Dim item As New ListItem
    '    item.Text = "--กรุณาเลือก--"
    '    item.Value = "0"
    '    ddl_unit2.Items.Insert(0, item)
    'End Sub
    'Public Sub bind_unit3()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO_MASTER
    '    dt = bao.SP_MASTER_drsunit()

    '    ddl_unit3.DataSource = dt
    '    ddl_unit3.DataTextField = "sunitnmsht"
    '    ddl_unit3.DataValueField = "sunitcd"
    '    ddl_unit3.DataBind()

    '    Dim item As New ListItem
    '    item.Text = "--กรุณาเลือก--"
    '    item.Value = "0"
    '    ddl_unit3.Items.Insert(0, item)
    'End Sub
    Public Sub bind_unit4()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit4.DataSource = dt
        ddl_unit4.DataTextField = "sunitnmsht"
        ddl_unit4.DataValueField = "sunitcd"
        ddl_unit4.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit4.Items.Insert(0, item)
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
    Public Sub bind_unit_head()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit_head.DataSource = dt
        'ddl_unit_head.DataTextField = "sunitnmsht"
        'ddl_unit_head.DataValueField = "sunitcd"
        'ddl_unit_head.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit_head.Items.Insert(0, item)
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

    Protected Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        'If ddl_unit.SelectedValue <> 0 And txt_QTY.Text <> "" Then
        For Each item As GridDataItem In rg_search_iowa.SelectedItems
            'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_DETAIL_CAS
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            dao.fields.IOWA = item("iowacd").Text
            Try
                dao.fields.IOWANM = item("iowanm").Text
            Catch ex As Exception

            End Try
            If Trim(txt_QTY.Text) = "" Then
                dao.fields.QTY = "0"
            Else
                Try
                    dao.fields.QTY = txt_QTY.Text.Replace(",", "")
                Catch ex As Exception
                    dao.fields.QTY = txt_QTY.Text
                End Try

            End If
            If Trim(txt_QTY2.Text) = "" Then
                dao.fields.QTY2 = "0"
            Else
                Try
                    dao.fields.QTY2 = txt_QTY2.Text.Replace(",", "")
                Catch ex As Exception
                    dao.fields.QTY2 = txt_QTY2.Text
                End Try

            End If
            dao.fields.AORI = ddl_aori.SelectedItem.Text

            Try
                dao.fields.FK_SET = ddl_set.SelectedValue
            Catch ex As Exception

            End Try
            'Try
            '    dao.fields.PROCESS_ID = _PROCESS_ID
            'Catch ex As Exception

            'End Try
            'If _HERB_ID = "" Then
            dao.fields.FK_IDA = _IDA
            'End If
            'Try
            '    dao.fields.FK_HERB_NAME_PRODUCT_ID = _HERB_ID
            'Catch ex As Exception

            'End Try
            'Try
            '    dao.fields.ebioqty = txt_ebioqty.Text
            'Catch ex As Exception

            'End Try
            'Try
            '    dao.fields.ebiosqno = txt_ebiosqno.Text
            'Catch ex As Exception

            'End Try
            'Try
            '    dao.fields.ebiounitcd = ddl_unit3.SelectedValue
            'Catch ex As Exception

            'End Try
            Try
                dao.fields.CAS_TYPE = ddl_CAS_TYPE.SelectedValue
            Catch ex As Exception

            End Try
            Try
                dao.fields.CONDITION = ddl_remark1.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.SUNITCD = ddl_unit.SelectedValue
            Catch ex As Exception

            End Try
            Try
                dao.fields.SUNITCD2 = ddl_unit4.SelectedValue
            Catch ex As Exception

            End Try
            'Try
            '    dao.fields.sbioqty = txt_sbioqty.Text
            'Catch ex As Exception

            'End Try
            'Try
            '    dao.fields.sbiosqno = txt_sbiosqno.Text
            'Catch ex As Exception

            'End Try
            'Try
            '    dao.fields.sbiounitcd = ddl_unit2.SelectedValue
            'Catch ex As Exception

            'End Try
            'Dim dao_max As New DAO_TABEAN_HERB.TB_TABEAN_JJ_DETAIL_CAS
            Dim dao_max As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            dao_max.GET_MAX_ROWS_ID_SET(_IDA, ddl_set.SelectedValue)
            Dim id_max As Integer = 0
            Try
                id_max = dao_max.fields.ROWS
            Catch ex As Exception

            End Try
            'Try
            '    dao.fields.REF = txt_ref.Text
            'Catch ex As Exception

            'End Try
            'Try
            '    dao.fields.REMARK = txt_remark.Text
            'Catch ex As Exception

            'End Try
            dao.fields.ROWS = txt_ROWS.Text 'id_max + 1
            dao.insert()
        Next

        rg_chem.Rebind()
        'Else
        '    alert("กรุณากรอกข้อมูลให้ครบ")
        'End If

    End Sub
    Private Sub ddl_CAS_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_CAS_TYPE.SelectedIndexChanged
        set_hide()
    End Sub

    Sub set_hide()
        Dim cas_type As Integer = ddl_CAS_TYPE.SelectedValue
        If cas_type = 1 Then
            txt_QTY.Enabled = True
            ddl_unit.Enabled = True
            ddl_remark1.Enabled = True

            'txt_sbioqty.Enabled = False
            'ddl_unit2.Enabled = False
            'txt_sbiosqno.Enabled = False
            'txt_ebioqty.Enabled = False
            'ddl_unit3.Enabled = False
            'txt_ebiosqno.Enabled = False
        Else
            txt_QTY.Enabled = False
            ddl_unit.Enabled = False
            ddl_remark1.Enabled = False

            'txt_sbioqty.Enabled = True
            'ddl_unit2.Enabled = True
            'txt_sbiosqno.Enabled = True
            'txt_ebioqty.Enabled = True
            'ddl_unit3.Enabled = True
            'txt_ebiosqno.Enabled = True
        End If
    End Sub


    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dao_count As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EACH
        Dim i As Integer = 0
        i = dao_count.CountDataby_FK_IDA(Request.QueryString("IDA"))
        If i = 0 Then
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EACH
            dao.fields.EACH_AMOUNT = txt_each.Text
            dao.fields.FK_IDA = Request.QueryString("IDA")
            dao.fields.sunitcd = ddl_unit_each.SelectedValue
            dao.fields.FK_SET = ddl_set_each.SelectedValue
            dao.fields.EACH_TXT = txt_each_txt.Text
            dao.insert()

        Else
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EACH
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            dao.fields.EACH_AMOUNT = txt_each.Text
            dao.fields.sunitcd = ddl_unit_each.SelectedValue
            dao.fields.FK_SET = ddl_set_each.SelectedValue
            dao.fields.EACH_TXT = txt_each_txt.Text
            dao.update()
        End If

        alert("บันทึกเรียบร้อย")
        bind_lbl()
    End Sub
    Sub bind_lbl()
        RunQuery()
        Try
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_EACH
            dao.GetDataby_FK_IDA_AND_SET(Request.QueryString("IDA"), ddl_set_each.SelectedValue)
            Dim dao_u As New DAO_DRUG.TB_drsunit
            Try
                dao_u.GetDataby_sunitcd(dao.fields.sunitcd)
                lbl_each.Text = "Each " & dao.fields.EACH_AMOUNT & " " & dao_u.fields.sunitengnm & " Contains;"
            Catch ex As Exception

            End Try
            Try
                If Len(Trim(lbl_each.Text)) = 0 Then
                    lbl_each.Text = dao.fields.EACH_TXT
                End If
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_unit_each()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit.DataSource = dt
        'ddl_unit.DataTextField = "sunitnmsht"
        'ddl_unit.DataValueField = "sunitcd"
        'ddl_unit.DataBind()


        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()
        ddl_unit_each.DataSource = dt
        ddl_unit_each.DataTextField = "unit_name"
        ddl_unit_each.DataValueField = "sunitcd"
        ddl_unit_each.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit.Items.Insert(0, item)
    End Sub

    Private Sub ddl_set_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_set.SelectedIndexChanged
        rg_chem.Rebind()
    End Sub

    Private Sub btn_up_Click(sender As Object, e As EventArgs) Handles btn_up.Click

        For Each item As GridDataItem In rg_chem.SelectedItems
            Dim dao_curr As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            Dim dao_max As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            Dim dao_min As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            Dim dao_rowup As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            Dim _max As Integer = 0
            Dim _min As Integer = 0
            Dim row_up As Integer = 0
            Dim row_current As Integer = 0
            Try
                dao_max.GET_MAX_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                _max = dao_max.fields.ROWS
            Catch ex As Exception

            End Try
            Try
                dao_min.GET_MIN_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                _min = dao_min.fields.ROWS
            Catch ex As Exception

            End Try

            dao_curr.GetDataby_IDA(item("IDA").Text)
            row_current = dao_curr.fields.ROWS
            If row_current > _min Then
                Try
                    'update แถวบนก่อน
                    dao_rowup.GetDataby_ROWs_AND_FK_SET(row_current - 1, item("FK_SET").Text)
                    dao_rowup.fields.ROWS = row_current
                    dao_rowup.update()

                    'update แถวล่างให้ค่า +1
                    dao_curr.fields.ROWS = row_current - 1
                    dao_curr.update()

                Catch ex As Exception

                End Try

            End If

        Next

        rg_chem.Rebind()
    End Sub

    Private Sub btn_down_Click(sender As Object, e As EventArgs) Handles btn_down.Click

        For Each item As GridDataItem In rg_chem.SelectedItems
            Dim dao_curr As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            Dim dao_max As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            Dim dao_min As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            Dim dao_rowup As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
            Dim _max As Integer = 0
            Dim _min As Integer = 0
            Dim row_up As Integer = 0
            Dim row_current As Integer = 0
            Try
                dao_max.GET_MAX_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                _max = dao_max.fields.ROWS
            Catch ex As Exception

            End Try
            Try
                dao_min.GET_MIN_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                _min = dao_min.fields.ROWS
            Catch ex As Exception

            End Try

            dao_curr.GetDataby_IDA(item("IDA").Text)
            row_current = dao_curr.fields.ROWS
            If row_current < _max Then
                Try
                    'update แถวบนก่อน
                    dao_rowup.GetDataby_ROWs_AND_FK_SET(row_current + 1, item("FK_SET").Text)
                    dao_rowup.fields.ROWS = row_current
                    dao_rowup.update()

                    'update แถวล่างให้ค่า +1
                    dao_curr.fields.ROWS = row_current + 1
                    dao_curr.update()

                Catch ex As Exception

                End Try

            End If

        Next

        rg_chem.Rebind()
    End Sub

    Protected Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click

        Dim i As Integer = 1
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
        dao.GetDataby_FK_IDA_ORDER(_IDA, ddl_set.SelectedValue)
        For Each dao.fields In dao.datas
            dao.fields.ROWS = i
            dao.update()
            i += 1
        Next


    End Sub

    Private Sub btn_rows_save_Click(sender As Object, e As EventArgs) Handles btn_rows_save.Click

        For Each item As GridDataItem In rg_chem.Items
            Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)
            Try
                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXH_DETAIL_CAS
                dao.GetDataby_IDA(item("IDA").Text)
                dao.fields.ROWS = Trim(txt_rows.Text)
                dao.update()
            Catch ex As Exception

            End Try
        Next

        rg_chem.Rebind()
    End Sub
End Class

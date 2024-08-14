Imports System.Globalization
Imports Telerik.Web.UI
Public Class UC_PACKING_SIZE1
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As String = ""
    Private _IDA As String = ""
    Private IDA_JJ As String = ""

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        _IDA_LCN = Request.QueryString("IDA_LCN")
        IDA_JJ = Request.QueryString("IDA_JJ")
        _IDA = Request.QueryString("IDA")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_data()
        End If
    End Sub

    Sub SET_SHOW()
        ID3.Visible = True
    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(IDA_JJ)
        Dim _PROCESS_JJ As Integer = 0
        If dao.fields.DDHERB IsNot Nothing Then
            _PROCESS_JJ = dao.fields.DDHERB
        End If

        Dim dao_ed As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao_ed.GetdatabyID_IDA(_IDA)

        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(_IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If dao_cb.fields.Size_Packet = 1 Then
                CB_Size_Packet.Checked = True
                CB1.Visible = True
                SIZE_PACK_NEW.Text = dao_ed.fields.SIZE_PACK
            End If

        End If

        Dim dao_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_NAME_DETAIL_JJ

        dao_mas.GetdatabyID_DD_HERB_NAME_ID(dao.fields.DD_HERB_NAME_ID, _PROCESS_JJ)
        SIZE_PACK_OLD.Text = dao_mas.fields.SIZE_PACK
        SIZE_PACK_NEW.Text = dao_mas.fields.SIZE_PACK
        'SIZE_PACK.Text = dao.fields.SIZE_PACK
        'SIZE_PACK_NEW.Text = dao.fields.SIZE_PACK

        'dt = bao.SP_TABEAN_JJ_SUB_PACKSIZE(IDA_JJ, _PROCESS_JJ)
        dt = bao.SP_TABEAN_JJ_SUB_PACKSIZE(dao.fields.DD_HERB_NAME_ID, _PROCESS_JJ)

        Return dt
    End Function
    Function bind_data2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(IDA_JJ)
        Dim _PROCESS_JJ As Integer = 0
        If dao.fields.DDHERB IsNot Nothing Then
            _PROCESS_JJ = dao.fields.DDHERB
        End If
        'SIZE_PACK.Text = dao.fields.SIZE_PACK
        'SIZE_PACK_NEW.Text = dao.fields.SIZE_PACK

        dt = bao.SP_TABEAN_JJ_EDIT_SUB_PACKSIZE(_IDA, _PROCESS_JJ)

        Return dt
    End Function
    Public Sub bind_dd_pack_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_PRIMARY()

        DD_PCAK_1.DataSource = dt
        DD_PCAK_1.DataBind()
        DD_PCAK_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Protected Sub btn_size_pack_Click(sender As Object, e As EventArgs) Handles btn_size_pack.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_SUBPACKAGE
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao_jj.GetdatabyID_IDA(IDA_JJ)
        Dim _PROCESS_JJ As Integer = 0
        If dao_jj.fields.DDHERB IsNot Nothing Then
            _PROCESS_JJ = dao_jj.fields.DDHERB
        End If
        dao.fields.FK_IDA = _IDA
        dao.fields.FK_IDA_JJ = IDA_JJ
        dao.fields.PROCESS_ID = _PROCESS_JJ

        If DD_PCAK_1.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_1.SelectedValue = "-- กรุณาเลือก --" Then '_
            'Or DD_PCAK_2.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_2.SelectedValue = "-- กรุณาเลือก --" Then ' _
            'Or DD_PCAK_3.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_3.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูล Primary Seceondary Tertiary Packaging');", True)
        Else
            dao.fields.PACK_FSIZE_ID = DD_PCAK_1.SelectedValue
            dao.fields.PACK_FSIZE_NAME = DD_PCAK_1.SelectedItem.Text
            dao.fields.PACK_FSIZE_VOLUME = NO_1.Text
            dao.fields.NO_1 = NO_1.Text
            dao.fields.PACK_FSIZE_UNIT_ID = DD_UNIT_1.SelectedValue
            dao.fields.PACK_FSIZE_UNIT_NAME = DD_UNIT_1.SelectedItem.Text
            Try
                dao.fields.PACK_SECSIZE_ID = DD_PCAK_2.SelectedValue
                dao.fields.PACK_SECSIZE_NAME = DD_PCAK_2.SelectedItem.Text
                dao.fields.PACK_SECSIZE_VOLUME = NO_2.Text
                dao.fields.NO_2 = NO_2.Text
                dao.fields.PACK_SECSIZE_UNIT_ID = DD_UNIT_2.SelectedValue
                dao.fields.PACK_SECSIZE_UNIT_NAME = DD_UNIT_2.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_SECSIZE_ID = 0
                dao.fields.PACK_SECSIZE_NAME = ""
                dao.fields.PACK_SECSIZE_VOLUME = Nothing
                dao.fields.NO_2 = ""
                dao.fields.PACK_SECSIZE_UNIT_ID = 0
                dao.fields.PACK_SECSIZE_UNIT_NAME = ""
            End Try


            Try
                dao.fields.PACK_THSIZE_ID = DD_PCAK_3.SelectedValue
                dao.fields.PACK_THSIZE_NAME = DD_PCAK_3.SelectedItem.Text
                dao.fields.PACK_THSSIZE_VOLUME = NO_3.Text
                dao.fields.NO_3 = NO_3.Text
                dao.fields.PACK_THSIZE_UNIT_ID = DD_UNIT_3.SelectedValue
                dao.fields.PACK_THSIZE_UNIT_NAME = DD_UNIT_3.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_THSIZE_ID = 0
                dao.fields.PACK_THSIZE_NAME = ""
                dao.fields.PACK_THSSIZE_VOLUME = Nothing
                dao.fields.NO_3 = ""
                dao.fields.PACK_THSIZE_UNIT_ID = 0
                dao.fields.PACK_THSIZE_UNIT_NAME = ""
            End Try


            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_BY = _CLS.THANM

            dao.insert()
        End If

        DD_PCAK_1.ClearSelection()
        DD_UNIT_1.ClearSelection()
        DD_PCAK_2.ClearSelection()
        DD_UNIT_2.ClearSelection()
        DD_PCAK_3.ClearSelection()
        DD_UNIT_3.ClearSelection()
        NO_1.Text = ""
        NO_2.Text = ""
        NO_3.Text = ""

        RadGrid2.Rebind()
    End Sub
    Public Sub bind_dd_pack_2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_SECONDARY()

        DD_PCAK_2.DataSource = dt
        DD_PCAK_2.DataBind()
        DD_PCAK_2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_pack_3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_TERTIRY()

        DD_PCAK_3.DataSource = dt
        DD_PCAK_3.DataBind()
        DD_PCAK_3.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_PRIMARY()

        DD_UNIT_1.DataSource = dt
        DD_UNIT_1.DataBind()
        DD_UNIT_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_SCONDARY()

        DD_UNIT_2.DataSource = dt
        DD_UNIT_2.DataBind()
        DD_UNIT_2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_TERTIARY()

        DD_UNIT_3.DataSource = dt
        DD_UNIT_3.DataBind()
        DD_UNIT_3.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Sub save_data(ByVal IDA As Integer)
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(IDA)
        dao.fields.SIZE_PACK = SIZE_PACK_NEW.Text
        dao.fields.SUPPORT_EDIT_ID = 1
        dao.Update()

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        Dim dao_cb As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        dao_cb.GetdatabyID_FK_IDA(IDA)
        If dao_cb.fields.IDA <> 0 Then
            'dao_cb.fields.FK_IDA = IDA
            If CB_Size_Packet.Checked = True Then
                dao_cb.fields.Size_Packet = 1
                dao_up_mas.GetdatabyID_TYPE(112)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = dao.fields.TR_ID_JJ
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.PROCESS_ID = dao.fields.DDHERB
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next
            Else
                dao_cb.fields.Size_Packet = 0
            End If
            dao_cb.Update()
        Else
            dao_cb.fields.FK_IDA = IDA
            If CB_Size_Packet.Checked = True Then
                dao_cb.fields.Size_Packet = 1
                dao_up_mas.GetdatabyID_TYPE(112)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = dao.fields.TR_ID_JJ
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.PROCESS_ID = dao.fields.DDHERB
                    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next
            Else
                dao_cb.fields.Size_Packet = 0
            End If
            dao_cb.insert()
        End If
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_SUBPACKAGE
                dao.GetData_ByIDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid2.Rebind()
            End If
        End If
    End Sub
    Sub Update_data(ByVal IDA As Integer)
        Dim bao As New BAO_TABEAN_HERB.tb_main
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
        dao.GetdatabyID_IDA(IDA)
        dao.fields.SIZE_PACK = SIZE_PACK_NEW.Text
        dao.Update()

    End Sub

    Protected Sub CB_Size_Packet_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Size_Packet.CheckedChanged
        If CB_Size_Packet.Checked = True Then
            CB1.Visible = True
            RadGrid1.Rebind()
            RadGrid2.Rebind()
        Else
            CB1.Visible = False
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data()
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data2()
    End Sub
End Class
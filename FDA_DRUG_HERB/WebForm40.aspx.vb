Imports Telerik.Web.UI
Public Class WebForm40
    Inherits System.Web.UI.Page
    Private _IDA_DR As String
    Shared _Newcode As String
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Bind_DDL_Kindnm()
                Bind_DDL_SLCHN()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub Bind_DDL_Kindnm()
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        Dim dao As New DAO_DRUG.TB_drkdofdrg
        dao.GETDATA_ACTIVE_Y()

        DDL_Kindnm.DataSource = dao.Details
        DDL_Kindnm.DataValueField = "kindcd"
        DDL_Kindnm.DataTextField = "thakindnm"
        DDL_Kindnm.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        DDL_Kindnm.Items.Insert(0, item)
    End Sub
    Public Sub Bind_DDL_SLCHN()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_SALE()

        DDL_SLCHN.DataSource = dt
        DDL_SLCHN.DataValueField = "SALE_CHANNEL_ID"
        DDL_SLCHN.DataTextField = "SALE_CHANNEL_NAME"
        DDL_SLCHN.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        DDL_SLCHN.Items.Insert(0, item)

    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If txt_search.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาระบุคำค้นหา');", True)
        Else
            If txt_search.Text.Length <= 3 Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาระบุคำค้นหามากกว่า 3 ตัวอักษร');", True)
            Else
                Dim d_start As Date = Date.Now
                Dim cc As Integer = RadGrid1.Items.Count
                Panel1.Style.Add("Display", "block")
                RadGrid1.Rebind()
                Bind_DDL_Kindnm()
                Bind_DDL_SLCHN()
                'Panel1.Style.Add("Display", "block")
            End If
        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        If txt_search.Text <> "" Then
            Try
                Dim d_start As Date = Date.Now
                Dim cc As Integer = 0
                cc = BindTable()
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Function BindTable() As Integer
        Dim clsds As New ClassDataset
        Dim db As New LINQ_FDA_XML_DRUG_HERBDataContext
        Dim conn As String = db.Connection.ConnectionString
        Dim sql As String = ""
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable

        Dim dt_temp As New DataTable
        Dim dt_drug As New DataTable
        Dim dt_cmt As New DataTable
        Dim dt_txc As New DataTable
        Dim dt_nct As New DataTable
        Dim dt_mdc As New DataTable
        Dim txt_ori As String = txt_search.Text
        Dim txt_sea As String = txt_search.Text.Replace("/", "_").Replace("""", "").Replace("\", "_").Replace("*", "").Replace("-", "")


        Dim txt_txc As String = txt_search.Text.Replace("/", "_").Replace("""", "").Replace("\", "").Replace("*", "").Replace("-", "")
        Dim txt_mcd As String = txt_search.Text.Replace("/", "_").Replace("""", "").Replace("\", "").Replace("*", "")
        Dim txt As String = """" & "*" & txt_sea & "*" & """"
        Dim txt_txc_s As String = """" & "*" & txt_txc & "*" & """"
        Dim txt_mdc_s As String = """" & "*" & txt_mcd & "*" & """"

        Dim msg As String = txt
        dt = bao.SP_SEARCH_CENTER_DRUG_HERB(txt_txc_s)
        dt_temp = clsds.MergeDatatable(dt_temp, dt)
        RadGrid1.DataSource = dt_temp
        Return dt_temp.Rows.Count
    End Function
    Public Function txt_alert() As String
        Dim msg As String = "หากพบความไม่ถูกต้องของข้อมูลโปรดแจ้งหน่วยงานดังนี้<br/>" &
              " - ข้อมูลผลิตภัณฑ์อาหาร               กรุณาแจ้งกองอาหารที่ e-mail : food@fda.moph.go.th <br/>" &
            " - ข้อมูลผลิตภัณฑ์ยาและสถานที่ด้านยา      กรุณาแจ้งกองยาที่ e-mail : Drug-SmartHelp@fda.moph.go.th <br/>" &
            " - ข้อมูลผลิตภัณฑ์วัตถุอันตราย         กรุณาแจ้งกลุ่มควบคุมวัตถุอันตรายที่ e-mail : toxic@fda.moph.go.th<br/>" &
            " - ข้อมูลผลิตภัณฑ์สมุนไพร        กรุณาแจ้งกองผลิตภัณฑ์สมุนไพรที่ e-mail : herbaldivision@fda.moph.go.th"
        Return msg
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            Dim NEWCODE As String = ""

            Dim dao As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
            If e.CommandName = "sel" Then
                NEWCODE = item("Newcode").Text
                _Newcode = NEWCODE
                dao.GetDataby_NEWCODE(NEWCODE)
                lbl_cncnm.Text = dao.fields.cncnm
                lbl_drthanm.Text = dao.fields.thadrgnm
                lbl_register.Text = dao.fields.register
                lbl_KindnmOld.Text = dao.fields.thakindnm
                If IsNothing(dao.fields.sale_channel) = False Then lbl_SaleChanel.Text = dao.fields.sale_channel Else lbl_SaleChanel.Text = "-"
                Panel2.Style.Add("Display", "block")
            End If
        End If
    End Sub

    Private Sub BTN_Submit_Click(sender As Object, e As EventArgs) Handles BTN_Submit.Click
        Dim pvncd As Integer
        Dim rgtpcd As String
        Dim rgtno As String
        Dim rgttpcd As String
        Dim remark As String
        Dim system As String
        Dim citizen_id As String = txt_identify.Text
        Dim ws_drug As New WS_DRUG.WS_DRUG
        Try
            If citizen_id = "" Then
                alert("กรุณากรอกเลขบัตรผู้แก้ไขข้อมูล")
            Else
                If citizen_id.Length = 13 Then
                    Dim dao As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
                    dao.GetDataby_u1(_Newcode)
                    For Each dao.fields In dao.datas
                        If DDL_Kindnm.SelectedValue <> 0 Then dao.fields.thakindnm = DDL_Kindnm.SelectedItem.Text
                        If DDL_SLCHN.SelectedValue <> 0 Then dao.fields.sale_channel = DDL_SLCHN.SelectedItem.Text
                        dao.update()
                    Next
                    pvncd = dao.fields.pvncd
                    rgtno = dao.fields.rgtno
                    rgtpcd = dao.fields.drgtpcd
                    rgttpcd = dao.fields.rgttpcd
                    remark = txt_remark.Text
                    system = "แก้ไข Admid(New)"
                    'citizen_id = _CLS.CITIZEN_ID
                    ws_drug.HERB_UPDATE_XML_PRODUCT(pvncd, rgttpcd, rgtpcd, rgtno, remark, citizen_id, system)
                    alert("อัพเดทข้อมูลทะเบียนแล้ว")
                Else
                    alert("กรุณากรอกเลขบัตรผู้แก้ไขข้อมูลให้ครบ 13 หลัก")
                End If
            End If
        Catch ex As Exception
            Dim txt_alert As String = "เกิดข้อผิดผลาดในการอัพเดทข้อมูลทะเบียน <br/>"
            txt_alert = txt_alert & ex.Message
            alert(txt_alert)
        End Try

    End Sub
End Class
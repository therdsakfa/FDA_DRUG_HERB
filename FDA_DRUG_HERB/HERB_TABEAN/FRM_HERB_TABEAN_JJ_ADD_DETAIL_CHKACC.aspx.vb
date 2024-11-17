Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_JJ_ADD_DETAIL_CHKACC
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _DD_HERB_NAME_ID As String = ""
    Private _PROCESS_JJ As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID_LCN As String = ""

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

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _DD_HERB_NAME_ID = Request.QueryString("DD_HERB_NAME_ID")
        _PROCESS_JJ = Request.QueryString("PROCESS_JJ")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_REPORT_RDLC.aspx?IDA=" & _IDA & "&rpt=1' ></iframe>"
            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/จจ๑.pdf'></iframe>"
            bind_rg()
        End If
    End Sub

    Public Sub bind_rg()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)
        If dao.fields.ACCEPT_FORMULA_ID <> 0 Then
            ACCEPT_FORMULA_TEXT.Visible = True
            ACCEPT_FORMULA.SelectedValue = dao.fields.ACCEPT_FORMULA_ID
            ACCEPT_FORMULA_NOTE.Text = dao.fields.ACCEPT_FORMULA_NOTE
        End If

    End Sub

    Function bind_data_file_recipe_production()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ(_DD_HERB_NAME_ID, _PROCESS_JJ)

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_file_recipe_production()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim DD_HERB_NAME_PRODUCT_ID As Integer = item("DD_HERB_NAME_PRODUCT_ID").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "FRM_HERB_TABEAN_JJ_RECIPE_PRODUCT_PREVIEW_FILE.aspx?IDA=" & IDA

        End If

    End Sub

    Protected Sub ACCEPT_FORMULA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ACCEPT_FORMULA.SelectedIndexChanged
        If ACCEPT_FORMULA.SelectedValue = 1 Then
            ACCEPT_FORMULA_TEXT.Visible = True
            ACCEPT_FORMULA_NOTE.Text = "ข้าพเจ้ารับทราบรายละเอียดสูตรตำรับ และ กรรมวิธีการผลิต ตามเอกสารแนบ โดยข้าพเจ้าจะปฏิบัติตามรายละเอียดดังกล่าวทุกประการ ทั้งนี้หากสำนักงานคณะกรรมการอาหารและยาตรวจพบว่าข้าพเจ้าไม่ปฏิบัติตามรายละเอียดดังกล่าว ข้าพเจ้ายินยอมให้เพิกถอนเลขจดแจ้งได้ตามกฎหมาย"
        Else
            ACCEPT_FORMULA_TEXT.Visible = True
            ACCEPT_FORMULA_NOTE.Text = "เนื่องด้วยคำขอนี้ เป็นคำขอจดแจ้งผลิตภัณฑ์สมุนไพร ซึ่งต้องมีรายละเอียดตามที่กำหนดไว้ จึงไม่สามารถแก้ไขรายละเอียดที่ถูกกำหนดไว้ได้ ในกรณีที่ท่านไม่ยอมรับการใช้สูตรและกรรมวิธีการผลิตตามที่ระบุ ท่านจะไม่สามารถยื่นคำขอได้ หากท่านต้องการใช้สูตร และ/หรือ กรรมวิธีการผลิต ที่ต่างไปจากที่กำหนดไว้ ขอให้ท่านยื่นคำขอในรูปแบบ การขึ้นทะเบียน หรือการแจ้งรายละเอียด (แล้วแต่กรณี)"
        End If
    End Sub

    Protected Sub btn_summit2_Click(sender As Object, e As EventArgs) Handles btn_summit2.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        dao.GetdatabyID_IDA(_IDA)

        If ACCEPT_FORMULA.SelectedValue = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ยินยอม หรือ ไม่ยินยอม');", True)
        ElseIf ACCEPT_FORMULA.SelectedValue = 1 Then

            dao.fields.ACCEPT_FORMULA_ID = ACCEPT_FORMULA.SelectedValue
            dao.fields.ACCEPT_FORMULA = ACCEPT_FORMULA.SelectedItem.Text
            dao.fields.ACCEPT_FORMULA_NOTE = ACCEPT_FORMULA_NOTE.Text
            dao.Update()
            alert_summit("กรุณาแนบไฟล์", dao.fields.IDA)
        Else
            dao.fields.ACCEPT_FORMULA_ID = ACCEPT_FORMULA.SelectedValue
            dao.fields.ACCEPT_FORMULA = ACCEPT_FORMULA.SelectedItem.Text
            If ACCEPT_FORMULA.SelectedValue = 2 Then
                dao.fields.ACCEPT_FORMULA_NOTE = ACCEPT_FORMULA_NOTE.Text
                ACCEPT_FORMULA_TEXT.Visible = True
            End If

            dao.fields.ACTIVEFACT = True

            dao.Update()
            alert_nosummit("เนื่องด้วยคำขอนี้ เป็นคำขอจดแจ้งผลิตภัณฑ์สมุนไพร ซึ่งต้องมีสูตรและกรรมวิธีการผลิต ตามที่กำหนดไว้ในประกาศกระทรวงสาธารณสุข เรื่อง ชื่อ ประเภท ชนิดหรือลักษณะของผลิตภัณฑ์สมุนไพร ซึ่งการผลิตหรือนำเข้าเพื่อขาย ต้องได้รับใบสำคัญการขึ้นทะเบียนตำรับ ใบรับแจ้งรายละเอียดหรือใบรับจดแจ้ง และชื่อ ปริมาณ และเงื่อนไขของวัตถุที่อาจใช้เป็นส่วนผสมในผลิตภัณฑ์สมุนไพร สำหรับผลิตภัณฑ์สมุนไพรที่ขอจดแจ้ง พ.ศ. ๒๕๖๔ ในกรณีที่ท่านไม่ยอมรับการใช้สูตรและกรรมวิธีการผลิตตามที่ระบุ ท่านจะไม่สามารถยื่นคำขอได้ หากท่านต้องการใช้สูตร และ/หรือ กรรมวิธีการผลิต ที่ต่างไปจากที่กำหนดไว้ ขอให้ท่านยื่นคำขอในรูปแบบ การขึ้นทะเบียน หรือการแจ้งรายละเอียด (แล้วแต่กรณี)", dao.fields.IDA)
        End If

        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.insert_transection_jj(_PROCESS_JJ, dao.fields.IDA, 2)

    End Sub

    Sub alert_summit(ByVal text As String, ByVal ida_jj As Integer)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & ida_jj & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&staff=" & Request.QueryString("staff") & "&SID=" & Request.QueryString("SID")
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Sub alert_nosummit(ByVal text As String, ByVal ida_jj As Integer)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_JJ.aspx?IDA_LCT=" & _IDA_LCT & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & _DD_HERB_NAME_ID & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & ida_jj & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&staff=" & Request.QueryString("staff") & "&SID=" & Request.QueryString("SID")
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

End Class
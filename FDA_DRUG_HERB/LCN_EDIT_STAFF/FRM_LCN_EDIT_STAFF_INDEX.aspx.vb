Imports Telerik.Web.UI

Public Class FRM_LCN_EDIT_STAFF_INDEX
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _STAFF As Integer = 0

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
        _LCNNO_DISPLAY = Request.QueryString("LCNNO_DISPLAY")

        '_IDA_LCN = 65254

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            RadGrid1.Rebind()
        End If
    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_LCN.TABLE_VIEW
        'Dim dao As New DAO_LCN
        dt = bao.SP_LCN_APPROVE_EDIT_GET_DATA(0, 1)

        'For Each dr As DataRow In dt.Rows
        '    Dim STATUS_ID As String = ""
        '    Dim STATUS_NAME As String = ""
        '    STATUS_ID = dr("STATUS_ID")
        '    If STATUS_ID = 2 Then
        '        dr("STATUS_NAME") = "ชำระค่าคำขอแล้วรอเจ้าหน้าที่รับเรื่อง"
        '    End If
        'Next

        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim bao_infor As New BAO.information
            Dim item As GridDataItem = e.Item

            Dim _LCN_IDA As String = item("FK_LCN_IDA").Text
            Dim _LCT_IDA As String = item("FK_LOCATION_IDA").Text
            Dim _IDA As String = item("IDA").Text
            'Dim _DDHERB As String = item("DDHERB").Text
            'Dim tr_id As String = item("TR_ID_JJ").Text
            Dim STATUS_GROUP As Integer = 0
            Try
                STATUS_GROUP = item("STATUS_GROUP").Text
            Catch ex As Exception
                STATUS_GROUP = 0
            End Try
            Dim ddl_up1 As Integer = 0
            ddl_up1 = item("LCN_EDIT_REASON_TYPE").Text
            Dim ddl_up2 As Integer = 0
            Try
                ddl_up2 = item("FK_SUB_REASON_TYPE").Text
            Catch ex As Exception
                ddl_up2 = 0
            End Try
            Dim _PROCESS As Integer = item("LCN_PROCESS_ID").Text
            Dim _TR_ID As Integer = item("TR_ID").Text


            Dim STATUS_ID As Integer = item("STATUS_ID").Text
            Dim LCN_EDIT_REASON_TYPE As String = item("LCN_EDIT_REASON_TYPE").Text
            'STATUS_ID = "3"
            If e.CommandName = "LCN_EDIT_DETAIL" Then
                If STATUS_ID = 2 Then
                    lbl_head1.Text = "ข้อมูลรับคำข้อ รับคำขอแก้ไขใบอนุญาต"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_LCN_EDIT_STAFF_INTAKE.aspx?LCN_IDA=" & _LCN_IDA & "&LCT_IDA=" & _LCT_IDA & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&STATUS_GROUP=" & STATUS_GROUP & "&STATUS_ID=" & STATUS_ID & "&ddl_up1=" & ddl_up1 & "&ddl_up2=" & ddl_up2 & "&detail=" & 1 & "&IDA=" & _IDA & "&TR_LCN_EDIT=" & _TR_ID & "');", True)
                ElseIf STATUS_ID = 3 Then
                    lbl_head1.Text = "ข้อมูลตรวจสอบเอกสาร ยื่นคำขอแก้ไขใบอนุญาต"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_LCN_EDIT_STAFF_CHEAK_PAPER.aspx?LCN_IDA=" & _LCN_IDA & "&LCT_IDA=" & _LCT_IDA & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&STATUS_GROUP=" & STATUS_GROUP & "&STATUS_ID=" & STATUS_ID & "&ddl_up1=" & ddl_up1 & "&ddl_up2=" & ddl_up2 & "&detail=" & 1 & "&IDA=" & _IDA & "&TR_LCN_EDIT=" & _TR_ID & "');", True)
                ElseIf STATUS_ID = 9 Then
                    lbl_head1.Text = "ข้อมูลขอเอกสาร (เพิ่มเติม) ยื่นคำขอแก้ไขใบอนุญาต"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_LCN_EDIT_STAFF_EDIT.aspx?LCN_IDA=" & _LCN_IDA & "&LCT_IDA=" & _LCT_IDA & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&STATUS_GROUP=" & STATUS_GROUP & "&STATUS_ID=" & STATUS_ID & "&ddl_up1=" & ddl_up1 & "&ddl_up2=" & ddl_up2 & "&detail=" & 1 & "&IDA=" & _IDA & "&TR_LCN_EDIT=" & _TR_ID & "');", True)
                ElseIf STATUS_ID = 11 Then
                    lbl_head1.Text = "ข้อมูลตรวจสอบเอกสาร ยื่นคำขอแก้ไขใบอนุญาต"
                    'bind_pdf_xml_2(568, 54708, 10201, 11, 2567, 256908)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_LCN_EDIT_STAFF_CHEAK_PAPER.aspx?LCN_IDA=" & _LCN_IDA & "&LCT_IDA=" & _LCT_IDA & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&STATUS_GROUP=" & STATUS_GROUP & "&STATUS_ID=" & STATUS_ID & "&ddl_up1=" & ddl_up1 & "&ddl_up2=" & ddl_up2 & "&detail=" & 1 & "&IDA=" & _IDA & "&TR_LCN_EDIT=" & _TR_ID & "');", True)
                ElseIf STATUS_ID = 4 Then 'ส่งไปอนุมัติลงนาม
                    lbl_head1.Text = "ข้อมูลยืนลงนาม ยื่นคำขอแก้ไขใบอนุญาต"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_LCN_EDIT_STAFF_SIGN.aspx?LCN_IDA=" & _LCN_IDA & "&LCT_IDA=" & _LCT_IDA & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&STATUS_GROUP=" & STATUS_GROUP & "&STATUS_ID=" & STATUS_ID & "&ddl_up1=" & ddl_up1 & "&ddl_up2=" & ddl_up2 & "&detail=" & 1 & "&IDA=" & _IDA & "&TR_LCN_EDIT=" & _TR_ID & "');", True)
                ElseIf STATUS_ID = 5 Then 'ส่งไปอนุมัติ
                    lbl_head1.Text = "ข้อมูลยืน ยื่นคำขอแก้ไขใบอนุญาต"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_LCN_EDIT_STAFF_APPROVE.aspx?LCN_IDA=" & _LCN_IDA & "&LCT_IDA=" & _LCT_IDA & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&STATUS_GROUP=" & STATUS_GROUP & "&STATUS_ID=" & STATUS_ID & "&ddl_up1=" & ddl_up1 & "&ddl_up2=" & ddl_up2 & "&detail=" & 1 & "&IDA=" & _IDA & "&TR_LCN_EDIT=" & _TR_ID & "');", True)
                ElseIf STATUS_ID = 8 Then 'เข้าไปดูข้อมูลที่ อนุุมัติไป
                    lbl_head1.Text = "ข้อมูลยืนอนุมัติ ยื่นคำขอแก้ไขใบอนุญาต"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_LCN_EDIT_STAFF_APPROVE.aspx?LCN_IDA=" & _LCN_IDA & "&LCT_IDA=" & _LCT_IDA & "&LCN_EDIT_REASON_TYPE=" & LCN_EDIT_REASON_TYPE & "&STATUS_GROUP=" & STATUS_GROUP & "&STATUS_ID=" & STATUS_ID & "&ddl_up1=" & ddl_up1 & "&ddl_up2=" & ddl_up2 & "&detail=" & 1 & "&IDA=" & _IDA & "&TR_LCN_EDIT=" & _TR_ID & "');", True)
                End If

            ElseIf e.CommandName = "SEE_DETAIL_SUB" Then
                lbl_head1.Text = "ข้อมูลรายละเอียดการข้อแก้ไข"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_LCN_EDIT_STAFF_SEE_EDIT_DETAIL.aspx?SEE_DETAIL_LCN_IDA=" & _LCN_IDA & "&SEE_DETAIL_LCT_IDA=" & _LCT_IDA & "&ddl_up1=" & ddl_up1 & "&ddl_up2=" & ddl_up2 & "&detail=" & 1 & "');", True)
            End If
        End If
    End Sub
    Public Sub bind_pdf_xml_2(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, LCN_IDA, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

End Class
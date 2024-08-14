Public Class FRM_HERB_WHO_ADD_DETAIT
    Inherits System.Web.UI.Page
    Private _IDA_LCT As String
    Private _IDA_LCN As String
    Private _TR_ID_LCN As String
    Private _MENU_GROUP As String
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try

        _IDA_LCT = Request.QueryString("IDA_LCT")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _MENU_GROUP = Request.QueryString("MENU_GROUP")

    End Sub

    Shared lcnsid As Integer
    Shared prefixcd As Integer
    Shared prefixnm As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btn_serach_iden_Click(sender As Object, e As EventArgs) Handles btn_serach_iden.Click
        Dim dao As New DAO_CPN.TB_syslcnsnm

        If IDENTIFY.Text IsNot Nothing Then
            Dim citizen_id As String = IDENTIFY.Text
            Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
            Dim obj As New XML_DATA
            'Dim cls As New CLS_COMMON.convert
            Dim result As String = ""
            'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
            result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
            obj = ConvertFromXml(Of XML_DATA)(result)

            Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON = 1 Then
                THANM_NAME.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            ElseIf TYPE_PERSON = 99 Then
                THANM_NAME.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    THANM_NAME.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    THANM_NAME.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If
            Try
                lcnsid = obj.SYSLCNSNMs.lcnsid
            Catch ex As Exception

            End Try

            prefixcd = obj.SYSLCNSNMs.prefixcd
            prefixnm = obj.SYSLCNSNMs.prefixnm

            ADDRESSPERSON.Text = obj.SYSLCTADDRs.Fulladdr
            TEL.Text = obj.TEL
            EMAIL.Text = obj.EMAIL

        End If

        'If IDENTIFY.Text IsNot Nothing Then
        '    dao.GetDataby_identify(IDENTIFY.Text)

        '    lcnsid = dao.fields.lcnsid
        '    prefixcd = dao.fields.prefixcd
        '    prefixnm = dao.fields.prefixnm

        '    prefixnm = dao.fields.prefixnm

        'End If

    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_WHO.TB_WHO_DALCN
        Try
            dao.fields.FK_LCT = _IDA_LCT
            dao.fields.FK_LCN = _IDA_LCN
            dao.fields.LCN_TR_ID = _TR_ID_LCN
            dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.IDENTIFY = IDENTIFY.Text

            dao.fields.LCNSID = lcnsid
            dao.fields.PREFIXCD = prefixcd
            dao.fields.PREFIXNM = prefixnm

            dao.fields.THANM_NAME = THANM_NAME.Text
            dao.fields.ADDRESSPERSON = ADDRESSPERSON.Text
            dao.fields.TEL = TEL.Text
            dao.fields.EMAIL = EMAIL.Text
            dao.fields.NOTE = NOTE.Text
            dao.fields.MENU_GROUP = _MENU_GROUP
            dao.fields.TYPEPERSON = 99
            dao.fields.STATUS_ID = 8
            dao.fields.ACTIVE = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_BY = _CLS.THANM

            dao.insert()
        Catch ex As Exception
            alert_normal("กรุณากรอกข้อมูล")
        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("FRM_HERB_WHO_ADD.aspx?lct_ida=" & _IDA_LCT & "&TR_ID=" & _TR_ID_LCN & "&lcn_ida=" & _IDA_LCN & "&MENU_GROUP=" & _MENU_GROUP)
    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_WHO_ADD.aspx?lct_ida=" & _IDA_LCT & "&TR_ID=" & _TR_ID_LCN & "&lcn_ida=" & _IDA_LCN & "&MENU_GROUP=" & _MENU_GROUP
        'Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

End Class
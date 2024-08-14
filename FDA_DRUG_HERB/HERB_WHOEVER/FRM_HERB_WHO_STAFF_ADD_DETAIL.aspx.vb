Public Class FRM_HERB_WHO_STAFF_ADD_DETAIL
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
    Shared thaaddr As String
    Shared tharoom As String
    Shared thamu As String
    Shared thafloor As String
    Shared thasoi As String
    Shared thabuilding As String
    Shared tharoad As String
    Shared zipcode As String
    Shared thathmblnm As String
    Shared thaamphrnm As String
    Shared thachngwtnm As String
    Shared fax As String

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
            Dim TYPE_PERSON As Integer
            Try
                TYPE_PERSON = obj.SYSLCNSIDs.type
            Catch ex As Exception
                TYPE_PERSON = obj.SYSLCNSNMs.type
            End Try

            If TYPE_PERSON = 1 Then
                THANM_NAME.Text = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            ElseIf TYPE_PERSON = 99 Or TYPE_PERSON = 3 Then
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
            Try
                prefixcd = obj.SYSLCNSNMs.prefixcd
                prefixnm = obj.SYSLCNSNMs.prefixnm
            Catch ex As Exception

            End Try


            ADDRESSPERSON.Text = obj.SYSLCTADDRs.Fulladdr
            TEL.Text = obj.TEL
            EMAIL.Text = obj.EMAIL
            thaaddr = obj.SYSLCTADDRs.thaaddr
            tharoom = obj.SYSLCTADDRs.room
            thamu = obj.SYSLCTADDRs.mu
            thafloor = obj.SYSLCTADDRs.floor
            thasoi = obj.SYSLCTADDRs.thasoi
            thabuilding = obj.SYSLCTADDRs.building
            tharoad = obj.SYSLCTADDRs.tharoad
            Try
                zipcode = obj.SYSLCTADDRs.zipcode
            Catch ex As Exception

            End Try
            thathmblnm = obj.SYSLCTADDRs.thmblnm
            thaamphrnm = obj.SYSLCTADDRs.amphrnm
            thachngwtnm = obj.SYSLCTADDRs.chngwtnm
            fax = obj.SYSLCTADDRs.fax

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
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Try
            dao.fields.FK_LCT = _IDA_LCT
            dao.fields.FK_LCN = _IDA_LCN
            Try
                dao.fields.LCN_TR_ID = _TR_ID_LCN
            Catch ex As Exception

            End Try
            dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.IDENTIFY = IDENTIFY.Text

            dao.fields.LCNSID = dao.fields.LCNSID
            dao.fields.LCNSID_WHO = lcnsid
            dao.fields.PREFIXCD = prefixcd
            dao.fields.PREFIXNM = prefixnm
            dao.fields.LOCATION_NAME = dao_lcn.fields.LOCATION_ADDRESS_thanameplace

            dao.fields.THANM_NAME = THANM_NAME.Text
            dao.fields.WHO_NAME = dao_lcn.fields.syslcnsnm_prefixnm & dao_lcn.fields.thanm
            dao.fields.ADDRESSPERSON = ADDRESSPERSON.Text
            dao.fields.TEL = TEL.Text
            dao.fields.EMAIL = EMAIL.Text
            dao.fields.NOTE = NOTE.Text
            dao.fields.MENU_GROUP = _MENU_GROUP
            dao.fields.TYPEPERSON = 999
            dao.fields.STATUS_ID = 8
            dao.fields.ACTIVE = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_BY = _CLS.THANM

            dao.fields.thaaddr = thaaddr
            dao.fields.thafloor = thafloor
            dao.fields.tharoad = tharoad
            dao.fields.thamu = thamu
            dao.fields.tharoad = tharoad
            dao.fields.tharoom = tharoom
            dao.fields.thasoi = thasoi
            dao.fields.thabuilding = thabuilding
            dao.fields.thathmblnm = thathmblnm
            dao.fields.thaamphrnm = thaamphrnm
            dao.fields.thachngwtnm = thachngwtnm
            dao.fields.zip_code = zipcode
            dao.fields.fax = fax

            dao.fields.CITIZEN_ID_ORIGIN = dao_lcn.fields.CITIZEN_ID
            dao.fields.CITIZEN_ID_AUTHORIZE_ORIGIN = dao_lcn.fields.CITIZEN_ID_AUTHORIZE

            dao.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        Catch ex As Exception
            alert_normal("กรุณากรอกข้อมูล")
        End Try
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("FRM_HERB_WHO_STAFF_ADD.aspx?lct_ida=" & _IDA_LCT & "&TR_ID=" & _TR_ID_LCN & "&lcn_ida=" & _IDA_LCN & "&MENU_GROUP=" & _MENU_GROUP)
    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        'url = "FRM_HERB_WHO_ADD.aspx?lct_ida=" & _IDA_LCT & "&TR_ID=" & _TR_ID_LCN & "&lcn_ida=" & _IDA_LCN & "&MENU_GROUP=" & _MENU_GROUP
        'Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

End Class
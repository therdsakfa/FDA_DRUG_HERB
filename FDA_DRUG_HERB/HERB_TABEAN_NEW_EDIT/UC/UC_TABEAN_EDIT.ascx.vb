Imports Telerik.Web.UI
Public Class UC_TABEAN_EDIT
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA_DQ As String = ""
    Private _Process_ID As String = ""

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
        _IDA = Request.QueryString("IDA")
        _IDA_DR = Request.QueryString("IDA_DR")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _Process_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            get_data_tabean()
        End If
    End Sub

    Public Sub get_data_tabean()
        'Dim dao As New DAO_DRUG.ClsDBdrrqt
        'dao.GetDataby_IDA(_IDA_DR)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Dim dao_Q As New DAO_DRUG.ClsDBdrrqt
        Try
            dao.GetDataby_IDA(_IDA_DR)
            _IDA_DQ = dao.fields.FK_DRRQT

            dao_Q.GetDataby_IDA(dao.fields.FK_DRRQT)
            dao_tn.GetdatabyID_FK_IDA_DQ(_IDA_DQ)
        Catch ex As Exception

        End Try
        Dim dao_h As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
        Try
            If dao.fields.rgtno IsNot Nothing Then
                dao_h.GetDataby_4Key(dao.fields.rgtno, dao.fields.rgttpcd, dao.fields.drgtpcd, dao.fields.pvncd)
            Else
                dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
            End If
        Catch ex As Exception
            dao_h.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
        End Try
        Dim citizen_id As String = ""
        If dao.fields.IDENTIFY = "" Then
            citizen_id = dao.fields.IDENTIFY
            txt_IDEN.Text = dao.fields.IDENTIFY
            'Txt_RgtNO_JJ.Text = dao.fields.RGTNO_NEW
            'Txt_Name_Thai.Text = dao.fields.thadrgnm
            'txt_Name_Eng.Text = dao.fields.engdrgnm
            Txt_Name_Thai.Text = dao_tn.fields.NAME_THAI
            txt_Name_Eng.Text = dao_tn.fields.NAME_ENG
        Else
            'citizen_id = dao.fields.CITIZEN_ID_AUTHORIZE
            citizen_id = dao.fields.IDENTIFY
            ' txt_IDEN.Text = dao.fields.CITIZEN_ID_AUTHORIZE
            txt_IDEN.Text = dao.fields.IDENTIFY
            'Txt_RgtNO_JJ.Text = dao.fields.RGTNO_NEW
            'Txt_Name_Thai.Text = dao_tn.fields.NAME_THAI
            'txt_Name_Eng.Text = dao_tn.fields.NAME_ENG
            Txt_Name_Thai.Text = dao.fields.thadrgnm
            txt_Name_Eng.Text = dao.fields.engdrgnm
        End If
        Txt_Name_Thai.Text = dao_h.fields.thadrgnm
        txt_Name_Eng.Text = dao_h.fields.engdrgnm
        Txt_RgtNO_JJ.Text = dao_h.fields.register
        NAME_JJ.Text = FULLNAME_CPN(_CLS.CITIZEN_ID_AUTHORIZE)
        NAME_JJ.Text = dao_tn.fields.NAME_JJ
        'Txt_thanm_JJ.Text = dao_tn.fields.NAME_JJ
        Txt_thanm_JJ.Text = dao_h.fields.holder_bsn_nm
        txt_Write_Date.SelectedDate = CDate(Date.Now).ToString("dd/MM/yyy")
        Txt_Write_At.Text = "อย"
        Dim NAME As String = ""
        Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
        Dim obj As New XML_DATA
        'Dim cls As New CLS_COMMON.convert
        Dim result As String = ""
        'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
        result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
        obj = ConvertFromXml(Of XML_DATA)(result)
        Try
            Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON = 1 Then
                NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End Try
        NAME_JJ.Text = NAME
        Txt_thanm_JJ.Text = NAME
        Dim NAME_BSN As String = ""
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        'Try
        '    dao_lcn.GetDataby_IDA(dao.fields.FK_LCN_IDA)
        '    dao_bsn.GetDataby_LCN_IDA(_IDA_LCN)
        '    NAME_JJ.Text = dao_bsn.fields.BSN_THAIFULLNAME
        '    Txt_thanm_JJ.Text = dao_bsn.fields.BSN_THAIFULLNAME
        'Catch ex As Exception

        'End Try
        Dim full_rgtno As String = ""
        'If dao_Q.fields.RGTNO_NEW = "" Then
        '    full_rgtno = dao.fields.rgttpcd & " " & Integer.Parse(Right(dao.fields.rgtno, 5)).ToString() & "/" & Left(dao.fields.rgtno, 2)

        '    Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        '    Try
        '        dao_ty.GetDataby_drgtpcd(dao.fields.drgtpcd)
        '        full_rgtno &= " " & dao_ty.fields.engdrgtpnm
        '    Catch ex As Exception

        '    End Try

        '    NAME_JJ.Text = FULLNAME_CPN(_CLS.CITIZEN_ID_AUTHORIZE)
        '    Txt_RgtNO_JJ.Text = full_rgtno
        'Else
        '    NAME_JJ.Text = FULLNAME_CPN(_CLS.CITIZEN_ID_AUTHORIZE)
        '    Txt_RgtNO_JJ.Text = dao_Q.fields.RGTNO_NEW
        'End If
    End Sub
    Public Function FULLNAME_CPN(ByVal citizen_id As String)
        Dim NAME As String = ""
        Dim ws_center As New WS_DATA_CENTER.WS_DATA_CENTER
        Dim obj As New XML_DATA
        'Dim cls As New CLS_COMMON.convert
        Dim result As String = ""
        'result = ws_center.GET_DATA_IDEM(citizen_id, citizen_id, "IDEM", "DPIS")
        result = ws_center.GET_DATA_IDENTIFY(citizen_id, citizen_id, "FUSION", "P@ssw0rdfusion440")
        obj = ConvertFromXml(Of XML_DATA)(result)
        Try
            Dim TYPE_PERSON As Integer = obj.SYSLCNSIDs.type
            If TYPE_PERSON = 1 Then
                NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
            Else
                If obj.SYSLCNSNMs.thalnm IsNot Nothing Then
                    NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm & " " & obj.SYSLCNSNMs.thalnm
                Else
                    NAME = obj.SYSLCNSNMs.prefixnm & obj.SYSLCNSNMs.thanm
                End If
            End If
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End Try

        Return NAME
    End Function
End Class
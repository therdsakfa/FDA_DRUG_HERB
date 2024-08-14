Public Class POP_UP_LCN_RENEW_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String = ""
    Private _IDA_LCN As Integer
    Private _IDEN As String
    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _IDEN = Request.QueryString("IDENTIFY")

        Try
            _IDA_LCN = Request.QueryString("IDA_LCN")
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Get_data()
        End If
    End Sub

    Sub Get_data()
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(_IDA_LCN)
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_lcn.fields.FK_IDA)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao_lcn.fields.IDA)
        txt_Rename_Name.Text = dao_lcn.fields.syslcnsnm_prefixnm & "" & dao_lcn.fields.thanm
        'txt_phr_name.Text = dao_phr.fields.PHR_NAME
        txt_phr_name.Text = dao_bsn.fields.BSN_THAIFULLNAME
        TxT_LCN_NUM.Text = dao_lcn.fields.LCNNO_DISPLAY_NEW
        TxT_Business_Name.Text = dao_addr.fields.thanameplace
        txt_addr.Text = dao_addr.fields.thaaddr
        txt_Building.Text = dao_addr.fields.thabuilding
        txt_mu.Text = dao_addr.fields.thamu
        txt_Soi.Text = dao_addr.fields.thasoi
        txt_road.Text = dao_addr.fields.tharoad
        txt_tambol.Text = dao_addr.fields.thathmblnm
        txt_ampher.Text = dao_addr.fields.thaamphrnm
        txt_changwat.Text = dao_addr.fields.thachngwtnm
        txt_zipcode.Text = dao_addr.fields.zipcode
        txt_tel.Text = dao_addr.fields.tel
        txt_Opentime.Text = dao_lcn.fields.opentime
        txt_Write_Date.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_LCN.TB_DALCN_RENEW
        Dim TR_ID As String = ""
        Dim IDA As Integer = 0
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao_lcn.fields.IDA)
        dao.fields.LCNNO_NEW_DISPLAY = TxT_LCN_NUM.Text
        dao.fields.RENREW_NAME = txt_Rename_Name.Text
        dao.fields.PHR_NAME = txt_phr_name.Text
        dao.fields.BUSINESS_PLACE_NAME = TxT_Business_Name.Text
        dao.fields.WRITE_AT = Txt_Write_At.Text
        dao.fields.WRITE_DATE = txt_Write_Date.Text
        dao.fields.EXPIRE_DATE = dao_lcn.fields.expdate
        dao.fields.process_lcn = dao_lcn.fields.PROCESS_ID
        dao.fields.pvncd = dao_lcn.fields.pvncd
        dao.fields.EXPIRE_YEAR = dao_lcn.fields.expyear
        dao.fields.thaaddr = txt_addr.Text
        dao.fields.thabuilding = txt_Building.Text
        dao.fields.thamu = txt_mu.Text
        dao.fields.thasoi = txt_Soi.Text
        dao.fields.tharoad = txt_road.Text
        dao.fields.thathmblnm = txt_tambol.Text
        dao.fields.thaamphrnm = txt_ampher.Text
        dao.fields.thachngwtnm = txt_changwat.Text
        dao.fields.zipcode = txt_zipcode.Text
        dao.fields.TEL = txt_tel.Text
        dao.fields.fax = txt_fax.Text
        dao.fields.OPENTIME = txt_Opentime.Text
        dao.fields.STATUS_ID = 1
        dao.fields.ACTIVEFACT = 1
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CREATE_BY = _CLS.THANM
        If Request.QueryString("staff") = 1 Then
            dao.fields.CREATE_ID = 1
            dao.fields.INOFFICE_STAFF_ID = 1
            dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
        End If
        dao.fields.lcnsid = dao_lcn.fields.lcnsid
        dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
        dao.fields.FK_LCN = dao_lcn.fields.IDA
        dao.fields.FK_LCT = dao_lcn.fields.FK_IDA
        dao.fields.PROCESS_ID = _ProcessID
        dao.fields.YEAR = con_year(Date.Now().Year())
        dao.fields.FK_PHR = dao_phr.fields.PHR_IDA
        Try
        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection(_ProcessID)
        Catch ex As Exception

        End Try
        dao.fields.TR_ID = TR_ID
        dao.insert()
        IDA = dao.fields.IDA
        Try
            Dim head_id As Integer = 0
            Dim id As Integer = 0
            Dim id2 As Integer = 0
            Dim type_p As String = ""
            Dim type_b As String = ""
            Dim type_l As String = ""
            Dim process As Integer = 0
            Dim dao_attgroup As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
            Dim dao_attgroup2 As New DAO_DRUG.TB_MAS_DALCN_UPLOAD_PROCESS_NAME
            TR_ID = TR_ID

            process = _ProcessID
            Dim TYPE_ID As Integer = 1

            dao_attgroup.GetDataby_TYPE_ID_AND_PROCESS(1, process)

            Dim btn As Button = CType(sender, Button)

            For Each dao_attgroup.fields In dao_attgroup.datas
                Dim dao_att As New DAO_DRUG.TB_DALCN_UPLOAD_FILE
                Dim dao_mas As New DAO_DRUG.TB_MAS_DOCUMENT_NAME_UPLOAD_DALCN
                dao_att.fields.DUCUMENT_NAME = dao_attgroup.fields.DUCUMENT_NAME
                dao_att.fields.TYPE_PERSON = head_id
                dao_att.fields.TYPE_LOCAL = id
                dao_att.fields.TYPE_BSN = id2
                dao_att.fields.TYPE = 1
                dao_att.fields.FK_IDA = IDA
                dao_att.fields.TR_ID = TR_ID
                dao_att.fields.PROCESS_ID = process
                dao_att.fields.TYPE_PERSON_NAME = type_p
                dao_att.fields.TYPE_LOCAL_NAME = type_l
                dao_att.fields.TYPE_BSN_NAME = type_b
                dao_att.insert()

            Next
        Catch ex As Exception

        End Try

        alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", IDA)
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POP_UP_LCN_RENEW_UPLOAD_FILE.aspx?IDA=" & ida & "&PROCESS_ID=" & _ProcessID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
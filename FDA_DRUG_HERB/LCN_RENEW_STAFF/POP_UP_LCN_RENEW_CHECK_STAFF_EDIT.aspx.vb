Public Class POP_UP_LCN_RENEW_CHECK_STAFF_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA_LCN As Integer
    Private _IDA As Integer
    Private _IDA_RENEW As Integer
    Private _IDEN As String
    Private _PROCESS_ID As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _IDEN = Request.QueryString("IDENTIFY")
            _PROCESS_ID = Request.QueryString("PROCESS_ID")
            _IDA = Request.QueryString("IDA_LCN")
            _IDA_RENEW = Request.QueryString("IDA_RENEW")
            _IDEN = Request.QueryString("IDENTIFY")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UC_HERB_PRE.Set_Label(_IDEN)
        UC_HERB_PRE.Set_data_New()
        UC_HERB_BSN_PRE.load_ddl_chwt()
        UC_HERB_BSN_PRE.load_ddl_amp()
        UC_HERB_BSN_PRE.load_ddl_thambol()
        UC_HERB_PHESAJ_PRE.bind_ddl_prefix()
        UC_HERB_PHESAJ_PRE.bind_ddl_phr_type()
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        If Request.QueryString("IDA_LCN") = "" Then
            'If Not UC_HERB_BSN.check_infor() Then
            '    UC_HERB_BSN.Chek_information()
            'Else
            Dim IDA As Integer = 0
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            'TR_ID = bao_tran.insert_transection(_ProcessID)
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            Dim dao As New DAO_LCN.TB_DALCN_RENEW_PRE_E_DETAIL
            Dim IDA_LCN As Integer = Request.QueryString("IDA_LCN")
            dao_dal.GetDataby_IDA(IDA_LCN)
            UC_HERB_PRE.setdata(dao, TR_ID)
            'dao_dal.insert()
            IDA = dao_dal.fields.IDA
            dao.fields.FK_IDA_RENEW = _IDA_RENEW
            If dao.fields.IDA = 0 Then
                dao.fields.CREATE_BY = _CLS.CITIZEN_ID
                dao.fields.CREATE_DATE = DateTime.Now
                dao.insert()
            Else
                dao.fields.UPDATE_BY = _CLS.CITIZEN_ID
                dao.fields.UPDATE_DATE = DateTime.Now
                dao.update()
            End If

            Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
            UC_HERB_PRE.setdata_frgn_data(dao_frgn)
            dao_frgn.fields.FK_IDA = dao_dal.fields.IDA
            'dao_frgn.insert()

            Dim dao_curent As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
            UC_HERB_BSN_PRE.set_date_current_addr(dao_curent)
            dao_curent.fields.FK_IDA = dao_dal.fields.IDA
            'dao_curent.insert()

            'UC_HERB.insert_bsn(IDA)

            Response.Write("<script type='text/javascript'>window.parent.alert('บันทึกเรียบร้อย');</script> ")
        End If
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
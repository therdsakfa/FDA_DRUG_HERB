Public Class POPUP_LCN_ADD
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _IDA As String = ""
    Private _ProcessID As Integer
    Private _pvncd As Integer
    Private _CLS As New CLS_SESSION
    Sub runQuery()
        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("ida")

    End Sub
    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()

        If Not IsPostBack Then
            UC_HERB.Set_Label(_CLS.CITIZEN_ID_AUTHORIZE)
            UC_HERB.load_ddl_chwt()
            UC_HERB.load_ddl_amp()
            UC_HERB.load_ddl_thambol()
            UC_HERB_PHESAJ.bind_ddl_prefix()
            UC_HERB_PHESAJ.bind_ddl_phr_type()
        End If
        If Request.QueryString("ida") <> "" Then
            Panel1.Style.Add("display", "block")
            UC_HERB.Visible = False
            Panel2.Style.Add("display", "block")
            btn_save.Style.Add("display", "none")
        Else
            Panel1.Style.Add("display", "none")
            Panel2.Style.Add("display", "none")
            btn_save.Style.Add("display", "block")
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Not UC_HERB.check_infor() Then
            UC_HERB.Chek_information()
        ElseIf Request.QueryString("ida") = "" Then
            Dim IDA As Integer = 0
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TR_ID As String = ""
            Dim PROESS As String = Request.QueryString("process")
            Dim PROESS_NEW As String = ""
            If PROESS = 120 Then
                PROESS_new = 10102
            ElseIf PROESS = 121 Then
                PROESS_new = 10103
            ElseIf PROESS = 122 Then
                PROESS_new = 10101
            End If
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection(_ProcessID)
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            UC_HERB.setdata(dao_dal, TR_ID)
            dao_dal.fields.STATUS_ID = 1
            dao_dal.fields.PROCESS_ID = Request.QueryString("process")
            dao_dal.fields.PROCESS_NEW = PROESS_new
            dao_dal.fields.REVOCATION = "999"
            dao_dal.fields.lcnno = 0
            dao_dal.fields.rcvno = 0
            dao_dal.fields.CREATE_DATE = Date.Now
            Try
                dao_dal.fields.lcnsid = _CLS.LCNSID_CUSTOMER
            Catch ex As Exception
                dao_dal.fields.lcnsid = 0
            End Try
            If Request.QueryString("staff") <> "" Then
                dao_dal.fields.STAFF_OFFER_ID = 1
                dao_dal.fields.STAFF_OFFER_IDEN = _CLS.CITIZEN_ID
            End If

            dao_dal.insert()
            IDA = dao_dal.fields.IDA

            Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
            UC_HERB.setdata_frgn_data(dao_frgn)
            dao_frgn.fields.FK_IDA = dao_dal.fields.IDA
            dao_frgn.insert()

            Dim dao_curent As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
            UC_HERB.set_date_current_addr(dao_curent)
            dao_curent.fields.FK_IDA = dao_dal.fields.IDA
            dao_curent.insert()

            UC_HERB.insert_bsn(IDA)
            'Response.Write("<script type='text/javascript'>window.parent.alert('บันทึกเรียบร้อย');</script> ")
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri & "&ida=" & IDA)
        End If

    End Sub
End Class
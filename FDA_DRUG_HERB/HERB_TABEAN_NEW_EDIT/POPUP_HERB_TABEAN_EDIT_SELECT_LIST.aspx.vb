Public Class POPUP_HERB_TABEAN_EDIT_SELECT_LIST
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
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
            Get_data()
        End If
    End Sub
    Sub Get_data()
        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        'dao.GetdatabyID_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        dao.GetdatabyID_FK_IDA(_IDA)
        'UC_TABEAN_EDIT_SELECT_LIST.get_data_tabean()
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim TR_ID As String = ""
        Dim IDA_DQ As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao.GetdatabyID_IDA(_IDA)
        Dim dao_d As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        dao_d.GetdatabyID_FK_IDA(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        Dim dao_g As New DAO_DRUG.ClsDBdrrgt
        Dim dao_q As New DAO_DRUG.ClsDBdrrqt
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao_g.GetDataby_IDA(_IDA_DR)
            IDA_DQ = dao_g.fields.FK_DRRQT
            dao_q.GetDataby_IDA(IDA_DQ)
            dao_tn.GetdatabyID_FK_IDA_DQ(IDA_DQ)
            dao.fields.FK_DRRQT = dao_g.fields.FK_DRRQT
        Catch ex As Exception

        End Try
        dao.fields.PAGE_ID = 2
        Try
            If IsNothing(TR_ID) = False Then
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection(_Process_ID)
                dao.fields.TR_ID = TR_ID
            End If
        Catch ex As Exception

        End Try
        dao.fields.pvncd = dao_g.fields.pvncd
        dao.fields.drgtpcd = dao_g.fields.drgtpcd
        dao.fields.rgttpcd = dao_g.fields.rgttpcd
        dao.fields.pvnabbr = dao_g.fields.pvnabbr
        dao.fields.thadrgnm = dao_g.fields.thadrgnm
        dao.fields.engdrgnm = dao_g.fields.engdrgnm
        'dao.fields.cnsdcd = dao_g.fields.cnsdcd
        'dao.fields.cnsddate = dao_g.fields.cnsddate
        'dao.fields.cscd = dao_g.fields.cscd
        'dao.fields.rqttpcd = dao_g.fields.rqttpcd
        'dao.fields.FK_REGIS = dao_g.fields.FK_REGIS
        dao.fields.rgtno = dao_g.fields.rgtno
        dao.fields.CTZNO = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        dao.Update()
        UC_TABEAN_EDIT_SELECT_LIST.SAVE_DATA()
        Get_data()
        If dao_d.fields.IDA = 0 Then
            dao_d.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao_d.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao_d.fields.ACTIVEFACT = 1
            dao_d.fields.TR_ID = TR_ID
            dao_d.fields.FK_IDA = _IDA
            dao_d.insert()
            'INSERT_OLD_DATA(dao_d.fields.IDA)
        Else
            dao_d.fields.CITIZEN_ID = _CLS.CITIZEN_ID
            dao_d.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao_d.fields.ACTIVEFACT = 1
            dao_d.fields.TR_ID = TR_ID
            dao_d.fields.FK_IDA = _IDA
            dao_d.Update()
        End If
        UC_TABEAN_EDIT_SELECT_LIST.INSERT_FILEUPLOAD(TR_ID)
        'alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", dao.fields.IDA)
        Response.Redirect("POPUP_HERB_TABEAN_EDIT_DETAIL.aspx?IDA=" & _IDA & "&PROCESS_ID=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & _IDA_DR)

    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD.aspx?IDA=" & ida & "&PROCESS_ID=" & _Process_ID & "&IDA_LCN=" & _IDA_LCN & "&IDA_DR=" & _IDA_DR
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
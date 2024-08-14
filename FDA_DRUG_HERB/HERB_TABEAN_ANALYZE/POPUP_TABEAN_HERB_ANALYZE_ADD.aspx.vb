Public Class POPUP_TABEAN_HERB_ANALYZE_ADD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCN As String = ""
    Private _IDA As String = ""
    Private _PROCESS_ID As String = ""

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
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _IDA = Request.QueryString("IDA")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_ANALYZE
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA_LCN)
        dao.GetdatabyID_IDA(_IDA)
        UC_ANALYZE_DETAIL.save_data(dao)
        dao.fields.FK_LCN = dao_lcn.fields.IDA
        dao.fields.FK_LCT = dao_lcn.fields.FK_IDA
        dao.fields.pvncd = dao_lcn.fields.pvncd
        'dao.fields.PROCESS_ID = 20910
        dao.fields.PROCESS_ID = _PROCESS_ID
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CREATE_BY = _CLS.THANM
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.YEAR = con_year(Date.Now().Year())
        dao.fields.STATUS_ID = 1
        dao.fields.ACTIVEFACT = 1
        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection(_PROCESS_ID)
            'TR_ID = bao_tran.insert_transection(_PROCESS_ID)
        Catch ex As Exception

        End Try
        dao.fields.FK_LCN = dao_lcn.fields.IDA
        dao.fields.pvncd = dao_lcn.fields.pvncd
        dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
        dao.fields.LCNNO = dao_lcn.fields.lcnno
        dao.fields.TR_ID = TR_ID
        dao.Update()

        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        dao_up_mas.GetdatabyID_TYPE(209)

        For Each dao_up_mas.fields In dao_up_mas.datas
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
            dao_up.fields.TR_ID = TR_ID
            dao_up.fields.FK_IDA = dao.fields.IDA
            dao_up.fields.PROCESS_ID = _PROCESS_ID
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.TYPE = 1
            dao_up.insert()
        Next

        alert_summit("บันทึกข้อมูลแล้ว กรุณาอัพโหลดเอกสารแนบ", dao.fields.IDA)
        'alert("บันทึกข้อมูลแล้ว")

    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida As Integer)
        Dim url As String = ""
        url = "POPUP_TABEAN_HERB_ANALYZE_UPLOAD.aspx?IDA=" & ida & "&PROCESS_ID=" & _PROCESS_ID & "&IDA_LCN=" & _IDA_LCN
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
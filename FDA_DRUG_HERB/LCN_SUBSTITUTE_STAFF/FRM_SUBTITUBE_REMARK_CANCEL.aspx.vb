Public Class FRM_SUBTITUBE_REMARK_CANCEL
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        dao.Getdata_by_IDA(_IDA)
        dao.fields.STATUS_ID = 7
        dao.fields.REMARK_CANCEL = TextBox1.Text
        dao.update()

        Dim cls_sop As New CLS_SOP
        cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", dao.fields.PROCESS_ID, _CLS.PVCODE, 8, "คืนคำขอ", "SOP-DRUG-10-" & dao.fields.PROCESS_ID & "-3", "คืนคำขอ", "เจ้าหน้าที่คืนคำขอ", "STAFF", _TR_ID, SOP_STATUS:="คืนคำขอ")

        alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_STAFF_LCN_SUBSTITUTE_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
End Class
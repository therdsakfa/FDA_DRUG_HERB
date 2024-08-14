Public Class WebForm13
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
        If Not IsPostBack Then
            txt_app_date.Text = Date.Now.ToShortDateString()
        End If
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub

    'Protected Sub txt_app_date_TextChanged(sender As Object, e As EventArgs) Handles txt_app_date.TextChanged


    'End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        Try
            'dao.fields.appdate = CDate(txt_app_date.Text)
            dao.fields.appdate = CDate(txt_app_date.Text)
            dao.fields.frtappdate = CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try
        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date = CDate(dao.fields.appdate)
            Dim expyear As Integer = 0
            Dim date_exp As Date
            Try
                expyear = Year(appdate)
                If expyear <> 0 Then
                    If expyear < 2500 Then
                        expyear += 543
                    End If
                    dao.fields.expyear = expyear
                End If
            Catch ex As Exception

            End Try

            Try
                If dao.fields.PROCESS_ID = "120" Or dao.fields.PROCESS_ID = "121" Or dao.fields.PROCESS_ID = "122" Then
                    dao.fields.expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 5, appdate))

                    date_exp = dao.fields.expdate
                    expyear = con_year(date_exp.year())
                    dao.fields.expyear = expyear
                End If

            Catch ex As Exception

            End Try
            dao.fields.STATUS_ID = 8
            dao.update()
        End If
        'End If
        'alert("บันทึกข้อมูลเรียบร้อย")
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.HERB_INSERT_LICEN(_IDA, _CLS.CITIZEN_ID)
        AddLogStatus(8, dao.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
        'dao.update()


        '-----------------ลิ้งไปหน้าคีย์มือ----------
        'Response.Redirect("FRM_STAFF_LCN_LCNNO_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        '--------------------------------
        Dim cls_sop As New CLS_SOP
        cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", dao.fields.PROCESS_ID, _CLS.PVCODE, 8, "อนุมัติ", "SOP-DRUG-10-" & dao.fields.PROCESS_ID & "-3", "อนุมัติ", "เจ้าหน้าที่อนุมัติคำขอแล้ว", "STAFF", _TR_ID, SOP_STATUS:="อนุมัติ")

        alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
    End Sub
End Class
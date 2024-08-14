Public Class POPUP_STAFF_LCN_SUBTITUTE_APP_DATE
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
            bind_mas_staff()
            RDP_APP_DATE.SelectedDate = Date.Now.ToShortDateString()
        End If
    End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_STAFF_LCN_SUBSTITUTE_MAIN.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_STAFF_LCN_SUBSTITUTE_MAIN.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If UC_ATTACH_LCN1.CHK_Extension = 0 Then
                If UC_ATTACH_LCN1.CHK_upload_file = 1 Then
                    Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
                    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                    Dim bao As New BAO.GenNumber

                    dao.Getdata_by_IDA(_IDA)
                    dao_up.GetDataby_IDA(dao.fields.TR_ID)

                    AddLogStatus(8, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)

                    dao.fields.STATUS_ID = 8
                    Try
                        dao.fields.appdate = CDate(RDP_APP_DATE.SelectedDate)
                    Catch ex As Exception

                    End Try
                    dao.fields.app_Staff_ID = DD_OFF_REQ.SelectedValue
                    dao.fields.app_Staff_Name = DD_OFF_REQ.SelectedItem.Text
                    dao.update()


                    Dim Year As String
                    Year = con_year(Date.Now.Year)
                    UC_ATTACH_LCN1.ATTACH1(dao.fields.TR_ID, dao.fields.PROCESS_ID, Year, "1")

                    alert("ดำเนินการอนุมัติแล้ว")
                Else
                    Response.Write("<script type='text/javascript'>alert('กรุแนบไฟล์ PDF');</script> ")
                End If
            Else
                Response.Write("<script type='text/javascript'>alert('กรุแนบไฟล์ PDF');</script> ")
            End If

        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try
    End Sub
End Class
Imports Telerik.Web.UI
Public Class FRM_STAFF_LCN_CONSIDER
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
            TextBox1.Text = Date.Now.ToShortDateString()
            'txt_app_date.Text = Date.Now.ToShortDateString()
            default_Remark()
            Bind_ddl_staff_offer()
        End If
    End Sub

    Private Sub default_Remark()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD

        dao.GetDataby_IDA(_IDA)
        dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
        Dim GROUP_TYPE As String = dao.fields.GROUP_TYPE
        If PROCESS_ID = 14200053 And GROUP_TYPE = "2" Then
            Txt_Remark.Text = ""
        End If



    End Sub
    Public Sub Bind_ddl_staff_offer()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao.SP_STAFF_OFFER_DDL()


        ddl_staff_offer.DataSource = bao.dt
        ddl_staff_offer.DataValueField = "IDA"
        ddl_staff_offer.DataTextField = "STAFF_OFFER_NAME"
        ddl_staff_offer.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-- กรุณาเลือก --"
        item.Value = "0"
        ddl_staff_offer.Items.Insert(0, item)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.ClsDBdalcn
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Dim bao As New BAO.GenNumber

            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)

            'AddLogStatus(6, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)

            Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID

            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_p.GetDataby_Process_ID(PROCESS_ID)
            Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

            Dim CONSIDER_DATE As Date = CDate(TextBox1.Text)
            Dim _type_da As String = ""
            If dao.fields.PROCESS_ID = "120" Then
                _type_da = "3"
            ElseIf dao.fields.PROCESS_ID = "121" Then
                _type_da = "2"
            ElseIf dao.fields.PROCESS_ID = "122" Then
                _type_da = "1"
            End If

            '--------------------------------
            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(dao.fields.pvncd)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try
            Dim bao2 As New BAO.GenNumber
            Dim LCNNO As Integer
            Dim LCNNO_V2 As Integer
            LCNNO = bao2.GEN_LCNNO_NEW(con_year(Date.Now.Year), _CLS.PVCODE, GROUP_NUMBER, PROCESS_ID, 0, 0, _IDA, "")

            Dim _year As Integer = con_year(Date.Now.Year)
            If _year < 2500 Then
                _year += 543
            End If

            LCNNO_V2 = con_year(Date.Now.Year).Substring(2, 2) & LCNNO
            'Convert.ToInt32(LCNNO_V2)
            dao.fields.lcnno = LCNNO_V2
            'Try
            '    If chw <> "" Then
            '        dao.fields.LCNNO_DISPLAY = _CLS.PVCODE & "-" & _type_da & "-" & Left(LCNNO, 2) & "-" & Right(LCNNO, Len(LCNNO) - 2)  'chw & " " & bao.FORMAT_NUMBER_YEAR_FULL(con_year(Date.Now.Year), LCNNO) ' & " (ขย." & GROUP_NUMBER & ")"
            '    Else
            '        dao.fields.LCNNO_DISPLAY = bao.FORMAT_NUMBER_YEAR_FULL(con_year(Date.Now.Year), LCNNO) ' & " (ขย." & GROUP_NUMBER & ")"
            '    End If
            'Catch ex As Exception

            'End Try
            dao.fields.LCNNO_DISPLAY_NEW = "HB " & _CLS.PVCODE & "-" & _type_da & "-" & con_year(Date.Now.Year).Substring(2, 2) & "-" & LCNNO
            '---------------------------------------

            dao.fields.remark = Txt_Remark.Text
            dao.fields.STATUS_ID = 6
            dao.fields.CONSIDER_DATE = CONSIDER_DATE

            dao.fields.FK_STAFF_OFFER_IDA = ddl_staff_offer.SelectedValue
            'Try
            '    dao.fields.appdate = CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try
            'If IsNothing(dao.fields.appdate) = False Then
            '    Dim appdate As Date = CDate(dao.fields.appdate)
            '    Dim expyear As Integer = 0
            '    Try
            '        expyear = Year(appdate)
            '        If expyear <> 0 Then
            '            If expyear < 2500 Then
            '                expyear += 543
            '            End If
            '            dao.fields.expyear = expyear
            '        End If
            '    Catch ex As Exception

            '    End Try

            '    Try
            '        If dao.fields.PROCESS_ID = "120" Or dao.fields.PROCESS_ID = "121" Or dao.fields.PROCESS_ID = "122" Then
            '            dao.fields.expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 5, appdate))
            '        End If

            '    Catch ex As Exception

            '    End Try
            'End If

            'Try
            '    send_mail_mini(dao.fields.CITIZEN_ID, "FDATH", "คำขอ เลขดำเนินการที่ " & dao.fields.TR_ID & " อยู่ระหว่างดำเนินการพิจารณา")
            'Catch ex As Exception

            'End Try

            dao.update()

            'Dim cls_sop As New CLS_SOP
            'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", PROCESS_ID, _CLS.PVCODE, 6, "เสนอลงนาม", "SOP-DRUG-10-" & PROCESS_ID & "-3", "อนุมัติ", "รอเจ้าหน้าที่อนุมัติคำขอ", "STAFF", _TR_ID, SOP_STATUS:="เสนอลงนาม")

            AddLogStatus(6, dao.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
            alert("บันทึกข้อมูลเรียบร้อย")
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try

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
End Class
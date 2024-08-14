Imports System.Globalization
Imports System.IO
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI
Public Class FRM_TABEANSTAFF_CHECK_RQT
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Dim STATUS_ID As Integer = 0
    Dim STATUS As Integer = 0
    Dim STAFF_ID As Integer = 0

    Sub RunQuery()
        Try
            STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
        Try
            _ProcessID = Request.QueryString("Process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            STATUS = Request.QueryString("STATUS")
            STAFF_ID = Request.QueryString("STAFF_ID")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'rtb_decrease.Text = 0
            Load_data()
            'bind_ddl_rqt()
            bind_ddl_rgttpcd()
            'bind_tabean_group()
            bind_mas_staff()
            DD_OFF_REQ.SelectedValue = STAFF_ID
            txt_rcvdate.Text = Date.Now.ToString("dd/MM/yyyy")
            Try
                If STATUS_ID = 8 Then
                    Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                    dao_rg.GetDataby_IDA(_IDA)
                    'ddl_req_type.SelectedValue = dao_rg.fields.TYPE_REQUEST_ID
                Else
                    Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                    dao_rg.GetDataby_IDA(_IDA)
                    'ddl_req_type.SelectedValue = dao_rg.fields.TYPE_REQUEST_ID
                    Try
                        ddl_rgttpcd.DropDownSelectData(dao_rg.fields.rgttpcd)
                    Catch ex As Exception

                    End Try
                    'Try
                    '    ddl_tabean_group.DropDownSelectData(dao_rg.fields.drgtpcd)
                    'Catch ex As Exception

                    'End Try

                    Try
                        'txt_rcvdate.SelectedDate = dao_rg.fields.rcvdate
                        'txt_rcvdate.SelectedDate = CDate(dao_rg.fields.rcvdate).ToShortDateString()
                    Catch ex As Exception

                    End Try
                End If

            Catch ex As Exception

            End Try
            Try
                bine_text_sum()
            Catch ex As Exception

            End Try

        End If
    End Sub
    'Sub bind_ddl_rqt()
    '    'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
    '    'dao.GetData_TABEAN_Only()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    dt = bao.SP_TYPE_REQUESTS_EDIT()
    '    ddl_req_type.DataSource = dt
    '    ddl_req_type.DataTextField = "TYPE_REQUESTS_NAME"
    '    ddl_req_type.DataValueField = "TYPE_REQUESTS_ID"
    '    ddl_req_type.DataBind()
    'End Sub
    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_REQ.DataSource = dt
        DD_OFF_REQ.DataBind()
        DD_OFF_REQ.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Sub Load_data()

        RunQuery()
        If STATUS_ID = 8 Then
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Try
                Dim dao_rqt As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                dao_rqt.GetDataby_CD(dao.fields.TYPE_REQUEST_ID)
                'lbl_type_request.Text = dao_rqt.fields.TYPE_REQUESTS_NAME

                'bind_ddl_money(dao.fields.TYPE_REQUEST_ID)
            Catch ex As Exception

            End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Try
                Dim dao_rqt As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                dao_rqt.GetDataby_CD(dao.fields.TYPE_REQUEST_ID)
                'lbl_type_request.Text = dao_rqt.fields.TYPE_REQUESTS_NAME

                'bind_ddl_money(dao.fields.TYPE_REQUEST_ID)
            Catch ex As Exception

            End Try
        End If

        Try
            'lbl_name_staff.Text = _CLS.THANM
        Catch ex As Exception

        End Try
    End Sub

    'Sub bind_ddl_money(ByVal type_req As Integer)
    '    'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUEST_AMOUNT
    '    'dao.GetDataby_TYPE_REQUESTS_ID(type_req)
    '    Dim bao_show As New BAO_SHOW
    '    Dim dt As New DataTable
    '    dt = bao_show.SP_TYPE_REQUESTS_ID_BY_TYPE(type_req)
    '    ddl_amount.DataSource = dt
    '    ddl_amount.DataTextField = "AMOUNT"
    '    ddl_amount.DataValueField = "AMOUNT"
    '    ddl_amount.DataBind()
    'End Sub
    Sub bine_text_sum()
        Dim raw_amount As Double = 0
        Dim persent As Double = 0
        Dim decrease_amount As Decimal = 0
        Dim summary_amount As Decimal = 0

        'raw_amount = ddl_amount.SelectedValue
        'persent = rtb_decrease.Text

        decrease_amount = (raw_amount * persent) / 100
        summary_amount = raw_amount - decrease_amount

        'rtb_summary.Text = summary_amount

    End Sub

    'Private Sub rtb_decrease_TextChanged(sender As Object, e As EventArgs) Handles rtb_decrease.TextChanged
    '    bine_text_sum()
    'End Sub
    'Sub bind_tabean_group()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    dt = bao.SP_drdrgtype_ALL()
    '    ddl_tabean_group.DataSource = dt
    '    ddl_tabean_group.DataTextField = "thadrgtpnm"
    '    ddl_tabean_group.DataValueField = "drgtpcd"
    '    ddl_tabean_group.DataBind()

    '    Dim item As New ListItem
    '    item.Text = "--กรุณาเลือก--"
    '    item.Value = ""
    '    ddl_tabean_group.Items.Insert(0, item)
    'End Sub
    Sub bind_ddl_rgttpcd()
        Dim sql As String = ""
        sql = "select * from dbo.DRRGT_DRUG_GROUP "
        Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
        dao_rqt.GetDataby_IDA(_IDA)
        Dim grptpcd As Integer = 0
        Dim subtpcd As Integer = 0
        Dim fk_lcn_ida As Integer = 0
        Try
            fk_lcn_ida = dao_rqt.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Dim dao_da As New DAO_DRUG.ClsDBdalcn
        dao_da.GetDataby_IDA(fk_lcn_ida)
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao_da.fields.lcntpcd
            If lcntpcd.Contains("บ") Or lcntpcd.Contains("สม") Then
                grptpcd = 2
            Else
                grptpcd = 1
            End If
            If lcntpcd.Contains("นย") Or lcntpcd.Contains("นส") Then
                subtpcd = 3
            End If
        Catch ex As Exception

        End Try

        Dim sql_where As String = ""
        sql_where = " where grptpcd=" & grptpcd
        If subtpcd = 3 Then
            sql_where &= " and subtpcd = 3"
        Else
            sql_where &= " and subtpcd <> 3"
        End If

        sql &= sql_where
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.Queryds(sql)

        ddl_rgttpcd.DataSource = dt
        ddl_rgttpcd.DataTextField = "rgttpcd"
        ddl_rgttpcd.DataValueField = "rgttpcd"
        ddl_rgttpcd.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        ddl_rgttpcd.Items.Insert(0, item)
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'If CHK_FORMAT_RCVNO(Txt_rcvno_no.Text) = True Then
        If DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
            alert_only("กรุณาเลือก จนท.ผู้รับผิดชอบคำขอ")
        Else
            If Chk_ddl() = 1 Then
                Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
                dao_rqt.GetDataby_IDA(_IDA)

                'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUEST_AMOUNT
                'Try
                '    dao.GetDataby_TYPE_REQUESTS_ID(dao_rqt.fields.TYPE_REQUEST_ID)
                'Catch ex As Exception

                'End Try
                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)

                Dim dao_tbn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
                dao_tbn.GetdatabyID_FK_IDA_DQ(_IDA)
                dao_tbn.fields.STATUS_ID = STATUS
                dao_tbn.Update()

                dao_rqt.fields.STATUS_ID = STATUS
                'dao_rqt.fields.AMOUNT = ddl_amount.SelectedValue
                'dao_rqt.fields.AMOUNT_CAL = rtb_summary.Text

                Dim RCVNO As Integer
                Dim bao2 As New BAO.GenNumber

                Dim bao_gen As New BAO.GenNumber
                RCVNO = bao_gen.GEN_NO_TBN(con_year(Date.Now.Year), dao.fields.pvncd, 1, _IDA, dao.fields.FK_LCN_IDA)
                'dao.fields.TR_ID = TR_ID
                'dao.update()

                'dao.fields.OFF_REQ_ID = DD_OFF_REQ.SelectedValue
                'dao.fields.OFF_REQ = DD_OFF_REQ.SelectedItem.Text

                ' Dim TR_ID As String = dao.fields.TR_ID_JJ
                Dim DATE_YEAR As String = con_year(Date.Now.Year).Substring(2, 2)
                Dim RCVNO_FULL As String = "HB" & " " & dao.fields.pvncd & "-" & _ProcessID & "-" & DATE_YEAR & "-" & RCVNO
                'RCVNO = GET_FORMAT_RCVNO(Txt_rcvno_no.Text)
                dao_rqt.fields.RCVNO_NEW = RCVNO_FULL 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

                Try
                    'dao_rqt.fields.rcvdate = CDate(txt_rcvdate.SelectedDate) 'Date.Now 'CDate(txt_app_date.Text)
                    dao.fields.rcvdate = DateTime.ParseExact(txt_rcvdate.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                Catch ex As Exception

                End Try
                Try
                    dao_rqt.fields.STAFF_RCV_NAME = DD_OFF_REQ.SelectedItem.Text
                Catch ex As Exception

                End Try
                'Try
                '    dao_rqt.fields.TYPE_REQUEST_ID = ddl_req_type.SelectedValue
                'Catch ex As Exception

                'End Try
                'Try
                '    dao_rqt.fields.A_NO = Txt_rcvno_temp.Text
                'Catch ex As Exception

                'End Try
                'Try
                '    dao_rqt.fields.rgtdrgtpcd = ddl_tabean_group.SelectedValue
                '    dao_rqt.fields.drgtpcd = ddl_tabean_group.SelectedValue
                'Catch ex As Exception

                'End Try
                Try
                    dao_rqt.fields.rgttpcd = ddl_rgttpcd.SelectedValue
                Catch ex As Exception

                End Try

                'If rdl_show_pvnabbr.SelectedValue <> "" Then
                '    If rdl_show_pvnabbr.SelectedValue = "1" Then
                dao_rqt.fields.pvnabbr2 = dao_rqt.fields.pvnabbr
                '    Else
                '        dao_rqt.fields.pvnabbr2 = "จ."
                '    End If
                '    dao_rqt.fields.USE_PVNABBR2 = rdl_show_pvnabbr.SelectedValue
                'End If

                Dim years As String = ""
                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tr.GetDataby_IDA(dao_rqt.fields.TR_ID)
                Try
                    years = dao_tr.fields.YEAR

                Catch ex As Exception

                End Try
                Dim tr_id As String = ""
                tr_id = "DA-" & _ProcessID & "-" & years & "-" & _TR_ID


                dao_rqt.update()
                AddLogStatus(STATUS, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)

                Dim cls_sop As New CLS_SOP
                cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", _ProcessID, _CLS.PVCODE, 2, "ตรวจรับคำขอ", "SOP-DRUG-10-" & _ProcessID & "-5", "ชำระเงินค่าประเมินคำขอ", "รอชำระเงินค่าประเมินคำขอ", "STAFF", tr_id, SOP_STATUS:="ตรวจรับคำขอ")

                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.insert_transection_jj(_ProcessID, _IDA, STATUS)

                alert("ตรวจรับคำขอแล้ว")
            Else
                alert_only("กรุณากรอกข้อมูลให้ครบถ้วน")
            End If
        End If
    End Sub
    Sub alert_only(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Function Chk_ddl() As Integer
        Dim i As Integer = 0
        If ddl_rgttpcd.SelectedValue <> "" Then
            i += 1
        End If
        'If ddl_tabean_group.SelectedValue <> "" Then
        '    i += 1
        'End If
        Return i
    End Function
    Function CHK_FORMAT_RCVNO(ByVal txt As String) As Boolean
        Dim bool As Boolean = True
        Try
            Dim split_text As String() = txt.Split("/")
            Dim len_1 As Integer = 0
            Dim len_2 As Integer = 0
            len_1 = Len(split_text(0))
            len_2 = Len(split_text(1))

            If len_2 < 2 Then
                Return False
            End If
            If len_2 > 2 Then
                Return False
            End If
            If len_1 < 1 Then
                Return False
            End If


        Catch ex As Exception
            bool = False
        End Try


        Return bool
    End Function
    Function GET_FORMAT_RCVNO(ByVal txt As String) As Integer
        Dim rcvno As String = ""
        Dim running As Integer = 0
        Dim year_short As String = ""
        Dim split_text As String() = txt.Split("/")

        Try
            running = CInt(split_text(0))
            year_short = split_text(1)
            rcvno = String.Format("{0:00000}", running.ToString("00000"))
            rcvno = year_short & rcvno
        Catch ex As Exception

        End Try

        Return rcvno
    End Function
    Function CHK_REPEAT(ByVal rcvno As Integer, ByVal rgttpcd As String, ByVal drgtpcd As String) As Boolean
        Dim bool As Boolean = True
        Try
            Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
            dao_rqt.GET_MAX_RCVNO(Left(rcvno, 2), rgttpcd, drgtpcd)
            Dim max_rcvno As Integer = dao_rqt.fields.rcvno
            If max_rcvno = rcvno Then
                bool = False
            End If
        Catch ex As Exception

        End Try

        Return bool
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_no_close(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "-"
        End Try

        Return fullname
    End Function

    'Private Sub ddl_req_type_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddl_req_type.SelectedIndexChanged
    '    Try
    '        bind_ddl_money(ddl_req_type.SelectedValue)
    '        bine_text_sum()
    '    Catch ex As Exception

    '    End Try

    'End Sub
    Private Sub DD_OFF_REQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OFF_REQ.SelectedIndexChanged
        If DD_OFF_REQ.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกเจ้าหน้าที่');", True)
        End If
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class
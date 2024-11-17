Imports Telerik.Web.UI
Public Class UC_HERB_BSN_PRE
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            GET_DATA()
            load_ddl_chwt()
            load_ddl_amp()
            load_ddl_thambol()
        End If
    End Sub
    Public Sub load_ddl_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()
        ddl_Province.DataSource = dt

        ddl_Province.DataBind()
    End Sub
    Public Sub load_ddl_amp()

        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_SYSAMPHR_BY_CHNGWTCD(ddl_Province.SelectedValue)

        ddl_amphor.DataSource = dt
        ddl_amphor.DataBind()
    End Sub
    Public Sub load_ddl_thambol()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(ddl_Province.SelectedValue, ddl_amphor.SelectedValue)
        ddl_tambol.DataSource = dt
        ddl_tambol.DataBind()
    End Sub

    Private Sub ddl_Province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Province.SelectedIndexChanged
        load_ddl_amp()
        load_ddl_thambol()
    End Sub

    Private Sub ddl_amphor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphor.SelectedIndexChanged
        load_ddl_thambol()
    End Sub
    Sub set_date_current_addr(ByRef dao As DAO_DRUG.TB_DALCN_CURRENT_ADDRESS) 'insert ที่อยู่ติดต่อได้

        With dao.fields
            Try
                .chngwtcd = ddl_Province.SelectedValue
                .amphrcd = ddl_amphor.SelectedValue
                .thmblcd = ddl_tambol.SelectedValue
            Catch ex As Exception

            End Try

            .email = txt_c_email.Text
            .fax = txt_c_fax.Text
            '.FK_IDA = 
            .tel = txt_c_tel.Text
            .thaaddr = txt_c_thaaddr.Text
            .thafloor = txt_c_floor.Text
            .thabuilding = txt_c_thabuilding.Text
            .thamu = txt_c_thamu.Text
            .thanameplace = ""
            .tharoad = txt_c_tharoad.Text
            .tharoom = txt_c_room.Text
            .thasoi = txt_c_thasoi.Text

            .zipcode = txt_c_zipcode.Text

        End With
    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim IDENTIFY As String = ""
        Try
            IDENTIFY = lbl_BSN_IDENTIFY.Text
        Catch ex As Exception

        End Try

        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_bsn As New DataTable
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(IDENTIFY)
        For Each dr As DataRow In dt_bsn.Rows
            Try
                lbl_BSN_ADDR.Text = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_FLOOR.Text = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_ROOM.Text = dr("BSN_ROOM")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_AGE.Text = dr("AGE")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_AMPHR_NAME.Text = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_BUILDING.Text = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_FAX.Text = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_IDENTIFY.Text = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_MOO.Text = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_ROAD.Text = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_SOI.Text = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_TEL.Text = dr("BSN_TEL")
            Catch ex As Exception

            End Try
            Try
                txt_BSN_THAIFULLNAME.Text = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_ZIPCODE.Text = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                lbl_thachngwtnm.Text = dr("thachngwtnm")
            Catch ex As Exception

            End Try
        Next 'set ข้อ2

        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(Request.QueryString("ida"))
        If dao_frgn.fields.addr_status = 1 Then 'set ที่อยู่ที่ติดต่อ
            Dim dao_curent As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
            dao_curent.GetData_By_FK_IDA(Request.QueryString("ida"))
            cb_addr.Checked = True
            ddl_amphor.SelectedValue = dao_curent.fields.amphrcd
            ddl_Province.SelectedValue = dao_curent.fields.chngwtcd
            txt_c_email.Text = dao_curent.fields.email
            txt_c_fax.Text = dao_curent.fields.fax
            '.FK_IDA = 
            txt_c_tel.Text = dao_curent.fields.tel
            txt_c_thaaddr.Text = dao_curent.fields.thaaddr
            txt_c_floor.Text = dao_curent.fields.thafloor
            txt_c_thabuilding.Text = dao_curent.fields.thabuilding
            txt_c_thamu.Text = dao_curent.fields.thamu
            '.thanameplace = ""
            txt_c_tharoad.Text = dao_curent.fields.tharoad
            txt_c_room.Text = dao_curent.fields.tharoom
            txt_c_thasoi.Text = dao_curent.fields.thasoi
            ddl_tambol.SelectedValue = dao_curent.fields.thmblcd
            txt_c_zipcode.Text = dao_curent.fields.zipcode
        End If
    End Sub
    Sub insert_bsn()
        Dim bao_show11 As New BAO_SHOW
        Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(lbl_BSN_IDENTIFY.Text)
        For Each dr As DataRow In dt_bsn.Rows
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN 'insert ข้อสอง
            Try
                dao_bsn.fields.BSN_THAIFULLNAME = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_IDENTIFY = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ADDR = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_SOI = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ROAD = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_MOO = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THMBL_NAME = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_AMPHR_NAME = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_CHWNGNAME = dr("BSN_CHWNGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_TELEPHONE = dr("BSN_TELEPHONE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_FAX = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THAINAME = dr("BSN_THAINAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THAILASTNAME = dr("BSN_THAILASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_PREFIXENGCD = dr("BSN_PREFIXENGCD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGNAME = dr("BSN_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGLASTNAME = dr("BSN_ENGLASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGFULLNAME = dr("BSN_ENGFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CHANGWAT_ID = dr("CHANGWAT_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.AMPHR_ID = dr("AMPHR_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.TUMBON_ID = dr("TUMBON_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_FLOOR = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_BUILDING = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ZIPCODE = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CREATE_DATE = dr("CREATE_DATE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.DOWN_ID = dr("DOWN_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CITIZEN_ID = dr("CITIZEN_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.XMLNAME = dr("XMLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.NATIONALITY = dr("NATIONALITY")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_HOUSENO = dr("BSN_HOUSENO")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGADDR = dr("BSN_ENGADDR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGMU = dr("BSN_ENGMU")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGSOI = dr("BSN_ENGSOI")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGROAD = dr("BSN_ENGROAD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_CHWNG_ENGNAME = dr("BSN_CHWNG_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_AMPHR_ENGNAME = dr("BSN_AMPHR_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THMBL_ENGNAME = dr("BSN_THMBL_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_NATIONALITY_CD = dr("BSN_NATIONALITY_CD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.AGE = dr("AGE")
            Catch ex As Exception

            End Try
            Try
                If txt_c_tel.Text = "" Then
                    dao_bsn.fields.BSN_TEL = dr("BSN_TEL")
                Else
                    dao_bsn.fields.BSN_TEL = txt_c_tel.Text
                End If
            Catch ex As Exception

            End Try
            dao_bsn.fields.LCN_IDA = Request.QueryString("ida")
            dao_bsn.fields.FK_IDA = Request.QueryString("ida")
            dao_bsn.insert()
        Next

    End Sub
    Function check_infor() As Boolean
        If txt_c_zipcode.Text = "" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกรหัสไปรษณีย์');</script> ")
            Return False

        ElseIf txt_c_thaaddr.Text = "" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูลเลขที่');</script> ")
            Return False

        ElseIf ddl_Province.SelectedValue = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกจังหวัด');</script> ")
            Return False

        ElseIf txt_c_tel.Text = "" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูลเบอร์มือถือ');</script> ")
            Return False

            'ElseIf txt_c_email.Text = "" Then
            '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาระบุข้อมูล e-mail');</script> ")
            '    Return False

        ElseIf ddl_amphor.SelectedValue = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกอำเภอ');</script> ")
            Return False

        ElseIf ddl_tambol.SelectedValue = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกตำบล');</script> ")
            Return False
        End If
        Return True
    End Function
    Sub Chek_information()
        If txt_c_zipcode.Text = "" Then
            lbl_zipcheck.Style.Add("display", "initial")
        Else lbl_zipcheck.Style.Add("display", "none")
        End If
        If txt_c_thaaddr.Text = "" Then
            Label64.Style.Add("display", "initial")
        Else Label64.Style.Add("display", "none")
        End If

        If ddl_Province.SelectedValue = "0" Then
            Label65.Style.Add("display", "initial")
        Else Label65.Style.Add("display", "none")

        End If
        'If txt_c_email.Text = "" Then
        '    lbl_chk_email.Style.Add("display", "initial")
        'Else
        '    lbl_chk_email.Style.Add("display", "none")
        'End If
        If txt_c_tel.Text = "" Then
            lbl_chk_tel.Style.Add("display", "initial")
        Else
            lbl_chk_tel.Style.Add("display", "none")
        End If

    End Sub
    Protected Sub btn_save_bsn_Click(sender As Object, e As EventArgs) Handles btn_save_bsn.Click
        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao.GetDataby_LCN_IDA(Request.QueryString("ida"))
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_LOCATION_BSN_BY_LCN_IDA(Request.QueryString("ida"))
        If ddl_Province.SelectedValue = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกจังหวัด');</script> ")
        ElseIf ddl_amphor.SelectedValue = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกอำเภอ');</script> ")
        ElseIf ddl_tambol.SelectedValue = "0" Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกตำบล');</script> ")
        Else
            If dt.Rows.Count >= 2 Then
                Response.Write("<script type='text/javascript'>window.parent.alert('ท่านเพิ่มผู้ดำเนินกิจการครบสองคนแล้ว');</script> ")
            Else
                If Not check_infor() Then
                    Chek_information()
                Else
                    insert_bsn()
                    Clear_text()
                    Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
                End If
            End If
            'set_data(dao)
            'dao.fields.FK_IDA = Request.QueryString("ida")
            'dao.insert()
            rg_bsn.Rebind()
        End If
    End Sub

    Public Sub GET_DATA()
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_bsn As New DataTable
        dt_bsn = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(Request.QueryString("bsn"))
        For Each dr As DataRow In dt_bsn.Rows
            Try
                lbl_BSN_ADDR.Text = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_FLOOR.Text = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_ROOM.Text = dr("BSN_ROOM")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_AGE.Text = dr("AGE")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_AMPHR_NAME.Text = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_BUILDING.Text = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_FAX.Text = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_IDENTIFY.Text = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_MOO.Text = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_ROAD.Text = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_SOI.Text = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_TEL.Text = dr("BSN_TEL")
            Catch ex As Exception

            End Try
            Try
                txt_BSN_THAIFULLNAME.Text = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_THMBL_NAME.Text = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                lbl_BSN_ZIPCODE.Text = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                lbl_thachngwtnm.Text = dr("thachngwtnm")
            Catch ex As Exception

            End Try
        Next 'set ข้อ2

        Dim dao_frgn As New DAO_DRUG.TB_DALCN_FRGN_DATA
        dao_frgn.GetDataby_FK_IDA(Request.QueryString("ida"))
        If dao_frgn.fields.addr_status = 1 Then 'set ที่อยู่ที่ติดต่อ
            Dim dao_curent As New DAO_DRUG.TB_DALCN_CURRENT_ADDRESS
            dao_curent.GetData_By_FK_IDA(Request.QueryString("ida"))
            cb_addr.Checked = True
            ddl_amphor.SelectedValue = dao_curent.fields.amphrcd
            ddl_Province.SelectedValue = dao_curent.fields.chngwtcd
            txt_c_email.Text = dao_curent.fields.email
            txt_c_fax.Text = dao_curent.fields.fax
            '.FK_IDA = 
            txt_c_tel.Text = dao_curent.fields.tel
            txt_c_thaaddr.Text = dao_curent.fields.thaaddr
            txt_c_floor.Text = dao_curent.fields.thafloor
            txt_c_thabuilding.Text = dao_curent.fields.thabuilding
            txt_c_thamu.Text = dao_curent.fields.thamu
            '.thanameplace = ""
            txt_c_tharoad.Text = dao_curent.fields.tharoad
            txt_c_room.Text = dao_curent.fields.tharoom
            txt_c_thasoi.Text = dao_curent.fields.thasoi
            ddl_tambol.SelectedValue = dao_curent.fields.thmblcd
            txt_c_zipcode.Text = dao_curent.fields.zipcode
        End If
    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.ClsDBdalcn, ByVal TR_ID As Integer)
        With dao.fields

            .GIVE_PASSPORT_NO = txt_GIVE_PASSPORT_NO.Text
            Try
                .GIVE_PASSPORT_EXPDATE = rdp_GIVE_PASSPORT_EXPDATE.SelectedDate
            Catch ex As Exception

            End Try
            Try
                .GIVE_WORK_LICENSE_NO = txt_GIVE_WORK_LICENSE_NO.Text
            Catch ex As Exception

            End Try
            Try
                .GIVE_WORK_LICENSE_EXPDATE = rdp_GIVE_WORK_LICENSE_EXPDATE.SelectedDate
            Catch ex As Exception

            End Try
        End With
    End Sub
    Sub Clear_text()
        lbl_BSN_ADDR.Text = ""
        lbl_BSN_FLOOR.Text = ""
        lbl_BSN_ROOM.Text = ""
        lbl_BSN_AGE.Text = ""
        lbl_BSN_AMPHR_NAME.Text = ""
        lbl_BSN_BUILDING.Text = ""
        lbl_BSN_FAX.Text = ""
        lbl_BSN_IDENTIFY.Text = ""
        lbl_BSN_MOO.Text = ""
        lbl_BSN_ROAD.Text = ""
        lbl_BSN_SOI.Text = ""
        lbl_BSN_TEL.Text = ""
        txt_BSN_THAIFULLNAME.Text = ""
        lbl_BSN_THMBL_NAME.Text = ""
        lbl_BSN_ZIPCODE.Text = ""
        lbl_thachngwtnm.Text = ""
        'ddl_Province.SelectedValue = 0
        'ddl_amphor.SelectedValue = 0
        'ddl_tambol.SelectedValue = 0
        txt_c_email.Text = ""
        txt_c_fax.Text = ""
        '.FK_IDA = 
        txt_c_tel.Text = ""
        txt_c_thaaddr.Text = ""
        txt_c_floor.Text = ""
        txt_c_thabuilding.Text = ""
        txt_c_thamu.Text = ""
        '.thanameplace = ""
        txt_c_tharoad.Text = ""
        txt_c_room.Text = ""
        txt_c_thasoi.Text = ""
        txt_c_zipcode.Text = ""
        cb_addr.Checked = False
    End Sub
    Private Sub rg_bsn_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_bsn.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        If Request.QueryString("ida") <> "" Then
            'dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(Request.QueryString("ida"))
            dt = bao.SP_LOCATION_BSN_BY_LCN_IDA(Request.QueryString("ida"))
        End If

        If dt.Rows.Count > 0 Then
            rg_bsn.DataSource = dt
        End If
    End Sub
    Private Sub rg_bsn_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_bsn.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim _ida As String = item("IDA").Text
            Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            If e.CommandName = "r_del" Then
                dao.GetDataby_IDA(_ida)
                dao.delete()
                rg_bsn.Rebind()
            End If
        End If
    End Sub
    Protected Sub cb_addr_CheckedChanged(sender As Object, e As EventArgs) Handles cb_addr.CheckedChanged
        If cb_addr.Checked = True Then
            txt_c_thaaddr.Text = lbl_BSN_ADDR.Text
            txt_c_floor.Text = lbl_BSN_FLOOR.Text
            txt_c_room.Text = lbl_BSN_ROOM.Text
            txt_c_thabuilding.Text = lbl_BSN_BUILDING.Text
            txt_c_thamu.Text = lbl_BSN_MOO.Text
            txt_c_thasoi.Text = lbl_BSN_SOI.Text
            txt_c_tharoad.Text = lbl_BSN_ROAD.Text
            load_ddl_chwt()
            Try
                ddl_Province.Items.FindByText(lbl_thachngwtnm.Text).Selected = True
            Catch ex As Exception
            End Try
            'ddl_Province.SelectedItem.Text = lbl_thachngwtnm.Text
            Try
                load_ddl_amp()
                ddl_amphor.Items.FindByText(lbl_BSN_AMPHR_NAME.Text).Selected = True
            Catch ex As Exception
                ddl_amphor.DropDownInsertDataFirstRow("-", "")
                ddl_amphor.Items.FindByText("-").Selected = True
            End Try

            'ddl_amphor.SelectedItem.Text = lbl_BSN_AMPHR_NAME.Text
            Try
                load_ddl_thambol()
                ddl_tambol.Items.FindByText(lbl_BSN_THMBL_NAME.Text).Selected = True
            Catch ex As Exception
                ddl_tambol.DropDownInsertDataFirstRow("-", "")
                ddl_tambol.Items.FindByText("-").Selected = True

            End Try
            txt_c_zipcode.Text = lbl_BSN_ZIPCODE.Text
            txt_c_fax.Text = lbl_BSN_FAX.Text
            txt_c_tel.Text = lbl_BSN_TEL.Text
            txt_c_email.Text = Label33.Text
        Else
            txt_c_thaaddr.Text = Nothing
            txt_c_thabuilding.Text = Nothing
            txt_c_thamu.Text = Nothing
            txt_c_thasoi.Text = Nothing
            txt_c_tharoad.Text = Nothing
            load_ddl_chwt()
            load_ddl_amp()
            load_ddl_thambol()
            'ddl_tambol.SelectedItem.Text = "-"
            'ddl_tambol.SelectedItem.Text = Nothing
            txt_c_zipcode.Text = Nothing
            txt_c_fax.Text = Nothing
            txt_c_tel.Text = Nothing
            txt_c_email.Text = Nothing

        End If

    End Sub
End Class
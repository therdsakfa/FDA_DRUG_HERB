Imports Telerik.Web.UI
Public Class UC_EXHIBITION_DETAIL
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
    Private _PROCESS_ID As String = ""
    Private _TR_ID As String = ""
    Private _IDA As String = ""

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
        _IDA_DR = Request.QueryString("IDA_DR")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")
        If Request.QueryString("IDA_LCN") <> "" Then
            _IDA_LCN = Request.QueryString("IDA_LCN")
        Else
            _IDA_LCN = 0
        End If
        _TR_ID = Request.QueryString("TR_ID")
        _IDA = Request.QueryString("IDA")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_dd_pack_1()
            bind_dd_pack_2()
            bind_dd_pack_3()
            bind_dd_unit_1()
            bind_dd_unit_2()
            bind_dd_unit_3()
            GET_DATA()

            UC_EXH_DETAIL_CAS.bind_unit1()
            'UC_EXH_DETAIL_CAS.bind_unit2()
            'UC_EXH_DETAIL_CAS.bind_unit3()
            UC_EXH_DETAIL_CAS.bind_unit4()
            UC_EXH_DETAIL_CAS.get_data_drgperunit()
            UC_EXH_DETAIL_CAS.bind_unit_each()
            UC_EXH_DETAIL_CAS.bind_lbl()
            ' UC_recipe.bind_ddl_atc()            UC_officer_che.bind_unit_head()
            UC_EXH_DETAIL_CAS.bind_unit()
        End If
    End Sub
    Sub GET_DATA()
        If _IDA_LCN <> 0 Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            Dim dao_ad As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao.GetDataby_IDA(_IDA_LCN)
            dao_ad.GetDataby_IDA(dao.fields.FK_IDA)
            txt_lcnno_new.Text = dao.fields.LCNNO_DISPLAY_NEW
            txt_lcn_name.Text = dao_ad.fields.thanameplace
            txt_addr.Text = dao_ad.fields.thaaddr
            txt_mu.Text = dao_ad.fields.thamu
            txt_soi.Text = dao_ad.fields.thasoi
            txt_road.Text = dao_ad.fields.tharoad
            txt_tambol.Text = dao_ad.fields.thathmblnm
            txt_ampher.Text = dao_ad.fields.thaamphrnm
            txt_changwhat.Text = dao_ad.fields.thachngwtnm
            txt_tel.Text = dao_ad.fields.tel
        Else
            Dim bao_show As New BAO_SHOW
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt_lcn As New DataTable
            dt_lcn = bao.SP_Lisense_Name_and_Addr(_CLS.CITIZEN_ID_AUTHORIZE) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

            For Each dr As DataRow In dt_lcn.Rows
                Try
                    'txt_lcn_name.Text = dr("thaaddr")
                Catch ex As Exception

                End Try
                txt_lcnno_new.Text = "-"
                Try
                    txt_addr.Text = dr("thaaddr")
                Catch ex As Exception

                End Try
                'Try
                '    lbl_lcn_floor.Text = dr("floor")
                'Catch ex As Exception

                'End Try
                'Try
                '    lbl_lcn_room.Text = dr("room")
                'Catch ex As Exception

                'End Try
                'Try
                '    If _TYPE_ID = 1 Then
                '        lbl_lcn_ages.Text = dr("age")
                '    Else
                '        lbl_lcn_ages.Text = "-"
                '    End If
                'Catch ex As Exception

                'End Try
                Try
                    txt_ampher.Text = dr("amphrnm")
                Catch ex As Exception

                End Try
                'Try
                '    lbl_lcn_building.Text = dr("building")
                'Catch ex As Exception

                'End Try
                Try
                    txt_changwhat.Text = dr("chngwtnm")
                Catch ex As Exception

                End Try
                'Try
                '    lbl_lcn_email.Text = dr("email")
                'Catch ex As Exception

                'End Try
                'Try
                '    lbl_lcn_fax.Text = dr("fax")
                'Catch ex As Exception

                'End Try
                'Try
                '    lbl_lcn_iden.Text = dr("identify")
                'Catch ex As Exception

                'End Try
                'Try
                '    lbl_lcn_iden2.Text = dr("identify")
                'Catch ex As Exception

                'End Try
                Try
                    txt_mu.Text = dr("mu")
                Catch ex As Exception

                End Try
                'Try
                '    lbl_lcn_name.Text = dr("tha_fullname")
                'Catch ex As Exception

                'End Try
                'Try
                '    If _TYPE_ID = 1 Then
                '        lbl_lcn_nation.Text = dr("nation")
                '    Else
                '        lbl_lcn_nation.Text = "-"
                '    End If

                'Catch ex As Exception

                'End Try
                Try
                    txt_road.Text = dr("tharoad")
                Catch ex As Exception

                End Try
                Try
                    txt_soi.Text = dr("thasoi")
                Catch ex As Exception

                End Try
                Try
                    txt_tambol.Text = dr("thmblnm")
                Catch ex As Exception

                End Try
                Try
                    txt_tel.Text = dr("tel")
                Catch ex As Exception

                End Try
                Try
                    txt_zipcode.Text = dr("zipcode")
                Catch ex As Exception

                End Try
            Next 'set ข้อ1

        End If
        RDP_Write_Date.SelectedDate = Date.Now
        RDP_date_Start.SelectedDate = Date.Now
        RDP_date_End.SelectedDate = Date.Now
    End Sub

    Public Sub bind_dd_pack_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_PRIMARY()

        DD_PCAK_1.DataSource = dt
        DD_PCAK_1.DataBind()
        DD_PCAK_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_pack_2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_SECONDARY()

        DD_PCAK_2.DataSource = dt
        DD_PCAK_2.DataBind()
        DD_PCAK_2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_pack_3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_PACK_TERTIRY()

        DD_PCAK_3.DataSource = dt
        DD_PCAK_3.DataBind()
        DD_PCAK_3.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_1()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_PRIMARY()

        DD_UNIT_1.DataSource = dt
        DD_UNIT_1.DataBind()
        DD_UNIT_1.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_SCONDARY()

        DD_UNIT_2.DataSource = dt
        DD_UNIT_2.DataBind()
        DD_UNIT_2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_dd_unit_3()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_UNIT_TERTIARY()

        DD_UNIT_3.DataSource = dt
        DD_UNIT_3.DataBind()
        DD_UNIT_3.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Sub save_data(ByVal dao As DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION)
        With dao.fields
            .EXHIBITION_NM = txt_NAME.Text
            .LCN_THANAMEPLACE = txt_lcn_name.Text
            .LCNNO_NEW = txt_lcnno_new.Text
            .PRODUCT_EXHIBITION_NM = txt_drug_name.Text
            .PRODUCT_EXHIBITION_NUMBER = txt_num.Text
            .RANK_EXHIBITION = txt_position.Text
            .EXHIBITION_FULLNAME = txt_position.Text & " " & txt_NAME.Text
            .WRITE_AT = Txt_Write_At.Text
            Try
                .EXHIBITION_NOUN_ID = rdl_behalf_in.SelectedValue
                .EXHIBITION_NOUN = rdl_behalf_in.SelectedItem.Text
            Catch ex As Exception

            End Try
            .EXHIBITION_NOUN_OTHER = txt_other.Text
            .EXHIBITION_LITLE = txt_exhibition.Text
            Try
                .CATEGORY_ID = rdl_process_exh.SelectedValue
                .CATEGORY_NM = rdl_process_exh.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                .PRODUCT_EXHIBITION_DATE = CDate(RDP_date_Start.SelectedDate)
                .START_DATE = CDate(RDP_date_Start.SelectedDate)
            Catch ex As Exception

            End Try
            Try
                .END_DATE = CDate(RDP_date_End.SelectedDate)
            Catch ex As Exception

            End Try
            .PRODUCT_EXHIBITION_LOCATIONS = txt_lo_exh.Text
            .WRITE_DATE = CDate(RDP_Write_Date.SelectedDate)
            .thanameplace = txt_lcn_name.Text
            .thaaddr = txt_addr.Text
            Try
                .thamu = txt_mu.Text
            Catch ex As Exception

            End Try
            .thasoi = txt_soi.Text
            .tharoad = txt_road.Text
            .thathmblnm = txt_tambol.Text
            .thaamphrnm = txt_ampher.Text
            .thachngwtnm = txt_changwhat.Text
            Try
                .zipcode = txt_zipcode.Text
            Catch ex As Exception

            End Try
            .tel = txt_tel.Text
        End With
    End Sub

    Protected Sub btn_size_pack_Click(sender As Object, e As EventArgs) Handles btn_size_pack.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION_PACKING_SIZE

        dao.fields.FK_IDA = _IDA

        If DD_PCAK_1.SelectedValue = "-- กรุณาเลือก --" Or DD_UNIT_1.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูล Primary Seceondary Tertiary Packaging');", True)
        Else
            dao.fields.PACK_F_ID = DD_PCAK_1.SelectedValue
            dao.fields.PACK_F_NAME = DD_PCAK_1.SelectedItem.Text
            dao.fields.NO_1 = NO_1.Text
            dao.fields.UNIT_F_ID = DD_UNIT_1.SelectedValue
            dao.fields.UNIT_F_NAME = DD_UNIT_1.SelectedItem.Text
            Try
                dao.fields.PACK_S_ID = DD_PCAK_2.SelectedValue
                dao.fields.PACK_S_NAME = DD_PCAK_2.SelectedItem.Text
                dao.fields.NO_2 = NO_2.Text
                dao.fields.UNIT_S_ID = DD_UNIT_2.SelectedValue
                dao.fields.UNIT_S_NAME = DD_UNIT_2.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_S_ID = 0
                dao.fields.PACK_S_NAME = ""
                dao.fields.NO_2 = ""
                dao.fields.UNIT_S_ID = 0
                dao.fields.UNIT_S_NAME = ""
            End Try


            Try
                dao.fields.PACK_T_ID = DD_PCAK_3.SelectedValue
                dao.fields.PACK_T_NAME = DD_PCAK_3.SelectedItem.Text
                dao.fields.NO_3 = NO_3.Text
                dao.fields.UNIT_T_ID = DD_UNIT_3.SelectedValue
                dao.fields.UNIT_T_NAME = DD_UNIT_3.SelectedItem.Text
            Catch ex As Exception
                dao.fields.PACK_T_ID = 0
                dao.fields.PACK_T_NAME = ""
                dao.fields.NO_3 = ""
                dao.fields.UNIT_T_ID = 0
                dao.fields.UNIT_T_NAME = ""
            End Try


            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_USER = _CLS.THANM

            dao.insert()
            insert_package_full(dao.fields.IDA)
            sum(dao.fields.IDA)
        End If

        DD_PCAK_1.ClearSelection()
        DD_UNIT_1.ClearSelection()
        DD_PCAK_2.ClearSelection()
        DD_UNIT_2.ClearSelection()
        DD_PCAK_3.ClearSelection()
        DD_UNIT_3.ClearSelection()
        NO_1.Text = ""
        NO_2.Text = ""
        NO_3.Text = ""

        RadGrid4.Rebind()
    End Sub
    Private Sub insert_package_full(ByVal IDA As Integer)
        Dim dao_package As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION_PACKING_SIZE
        dao_package.GetdatabyID_IDA(IDA)
        Dim sum As Integer = 0
        Dim NO_3_sum As Integer = 0
        Dim NO_sum As String = ""
        Dim NO_sum1 As String = ""
        Dim NO_sum2 As String = ""
        Try
            sum = CInt(dao_package.fields.NO_1) * CInt(dao_package.fields.NO_2) * CInt(dao_package.fields.NO_3)
            NO_sum = dao_package.fields.PACK_F_NAME & " " & Convert.ToString(dao_package.fields.NO_1) & " " & dao_package.fields.UNIT_F_NAME & " x " & dao_package.fields.PACK_S_NAME & " " & Convert.ToString(dao_package.fields.NO_2) & " " & dao_package.fields.UNIT_S_NAME & " x " & dao_package.fields.PACK_T_NAME & " " & Convert.ToString(dao_package.fields.NO_3) & " " & dao_package.fields.UNIT_T_NAME & " (" & sum & " " & dao_package.fields.UNIT_F_NAME & ")"
        Catch ex As Exception
            Try
                sum = CInt(dao_package.fields.NO_1) * CInt(dao_package.fields.NO_2)
                NO_sum = dao_package.fields.PACK_F_NAME & " " & dao_package.fields.NO_1 & " " & dao_package.fields.UNIT_F_NAME & " x " & dao_package.fields.PACK_F_NAME & " " & dao_package.fields.NO_2 & " " & dao_package.fields.UNIT_S_NAME & " (" & sum & " " & dao_package.fields.UNIT_F_NAME & ")"
            Catch ex2 As Exception
                sum = CInt(dao_package.fields.NO_1)
                NO_sum = dao_package.fields.NO_1 & " " & dao_package.fields.UNIT_F_NAME & " (" & sum & " " & dao_package.fields.UNIT_F_NAME & ")"
            End Try

        End Try
        dao_package.fields.PACKAGE_FULL = NO_sum
        dao_package.fields.SUM_PACKAGE_UNIT = sum
        dao_package.fields.UNIT_PACKAGE = dao_package.fields.UNIT_F_NAME
        dao_package.Update()
    End Sub
    Sub sum(ByVal IDA As Integer)
        Try
            Dim sum_pagkage As Integer = 0
            Dim dao_packsize As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION_PACKING_SIZE
            dao_packsize.GetdatabyID_IDA(IDA)
            For Each dao_packsize.fields In dao_packsize.datas
                sum_pagkage = sum_pagkage + CInt(dao_packsize.fields.SUM_PACKAGE_UNIT)
            Next

            txt_num.Text = sum_pagkage & " " & dao_packsize.fields.UNIT_PACKAGE
            'txt_unit.Text = dao_packsize.fields.UNIT_PACKAGE
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGrid4_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid4.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid4.Rebind()
            End If
        End If
    End Sub
    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_EXHIBITION_PACKING_SIZE
        dao_size.GetdatabyID_FK_IDA(_IDA)
        RadGrid4.DataSource = dao_size.datas
    End Sub
    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        bind_size()
    End Sub
    Protected Sub rdl_behalf_in_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_behalf_in.SelectedIndexChanged
        If rdl_behalf_in.SelectedValue = 4 Then
            div_behalf_in_other.Visible = True
            lbl_behalf_in.Text = "ชื่อสมาคม"
            Panel_lcnno.Visible = False
        ElseIf rdl_behalf_in.SelectedValue = 5 Then
            div_behalf_in_other.Visible = True
            lbl_behalf_in.Text = "ชื่อมูลนิธิ"
            Panel_lcnno.Visible = False
        ElseIf rdl_behalf_in.SelectedValue = 6 Then
            div_behalf_in_other.Visible = True
            lbl_behalf_in.Text = "ชื่อผู้แทนทางการค้าของประเทศ"
            Panel_lcnno.Visible = False
        ElseIf rdl_behalf_in.SelectedValue = 1 Then
            div_behalf_in_other.Visible = True
            lbl_behalf_in.Text = "ชื่อหน่วยงาน"
            Panel_lcnno.Visible = False
        ElseIf rdl_behalf_in.SelectedValue = 7 Or rdl_behalf_in.SelectedValue = 8 Then
            Panel_lcnno.Visible = True
        Else
            Panel_lcnno.Visible = False
            div_behalf_in_other.Visible = False
        End If
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim houseno As String = ""
        houseno = txt_house_no.Text

        If houseno = "" Then
            'alert_normal("กรุณาระบุรหัสประจำบ้าน")
            Response.Write("<script type='text/javascript'>alert('กรุณาระบุรหัสประจำบ้าน');</script> ")
            Response.Write("</script type >")
        Else
            Try
                Dim ws As New WS_Taxno_TaxnoAuthorize.WebService1
                Dim obj As New WS_Taxno_TaxnoAuthorize.HOUSENO
                obj = ws.getDetail_Houseno_by_addressID(houseno)

                'txt_houseno.Text = obj.AddressID
                txt_addr.Text = obj.Address_No
                'txt_thabuild.Text = ""
                'txt_thafloor.Text = ""
                txt_mu.Text = obj.Address_Moo
                txt_soi.Text = obj.Address_Soi
                txt_road.Text = obj.Address_Road
                txt_zipcode.Text = obj.PostCode
                txt_tel.Text = obj.Tel01
                'txt_fax_lo.Text = ""

                'ddl_chngwt.DropDownSelectText(obj.Address_Province)
                txt_tambol.Text = obj.Address_Tumbol
                'ddl_amphr.DropDownSelectText(obj.Address_Amphur)
                txt_ampher.Text = obj.Address_Amphur
                'ddl_thumbol.DropDownSelectText(obj.Address_Tumbol)
                txt_changwhat.Text = obj.Address_Province
            Catch ex As Exception
                Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
                Response.Write("</script type >")
            End Try

            'lb_ampr_ws.Text = obj.Address_Amphur
            'lb_thmbl_ws.Text = obj.Address_Tumbol
            'lb_chngwt_ws.Text = obj.Address_Province
        End If
    End Sub

    Protected Sub Search_FN()
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_SP_DALCN_SEARCH_EDIT "
        Dim str_where As String = ""
        Dim r_result As DataRow()
        Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_DALCN_STAFF_SEARCH()
        Dim dt As New DataTable
        If str_where = "" Then
            If str_where <> "" Then
                If txt_lcnno_SEACH.Text <> "" Then
                    str_where &= " and LCNNO_DISPLAY_NEW like '%" & txt_lcnno_SEACH.Text & "%' or lcnno_no like '%" & txt_lcnno_SEACH.Text & "%'"
                End If
            Else
                If txt_lcnno_SEACH.Text <> "" Then
                    str_where = "where LCNNO_DISPLAY_NEW like '%" & txt_lcnno_SEACH.Text & "%' or lcnno_no like '%" & txt_lcnno_SEACH.Text & "%'"

                End If
            End If
            'r_result = dt.Select(str_where)
            command &= str_where
        Else
            If txt_lcnno_SEACH.Text <> "" Then
                str_where = "where lcnno_no like '%" & txt_lcnno_SEACH.Text & "%' or lcnno_no like '%" & txt_lcnno_SEACH.Text & "%'"

            End If
            'r_result = dt.Select(str_where)
            command &= str_where
        End If

        dt = bao_aa.Queryds(command)
        RadGrid1.DataSource = dt
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(IDA)
                Dim tr_id As String = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                dao_addr.GetDataby_IDA(dao.fields.IDA)
                txt_lcnno_new.Text = dao.fields.LCNNO_DISPLAY_NEW
                txt_house_no.Text = dao_addr.fields.HOUSENO
                txt_road.Text = dao_addr.fields.tharoad
                txt_lcn_name.Text = dao_addr.fields.thanameplace
                txt_addr.Text = dao_addr.fields.thaaddr
                txt_mu.Text = dao_addr.fields.thamu
                If dao_addr.fields.latitude IsNot Nothing Then txt_latituie.Text = dao_addr.fields.latitude
                If dao_addr.fields.longitude IsNot Nothing Then txt_longtitute.Text = dao_addr.fields.longitude
                txt_ampher.Text = dao_addr.fields.thaamphrnm
                txt_tambol.Text = dao_addr.fields.thathmblnm
                txt_changwhat.Text = dao_addr.fields.thachngwtnm
                txt_zipcode.Text = dao_addr.fields.zipcode
                txt_tel.Text = dao_addr.fields.tel
                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao_pro.fields.PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    Private Sub BTN_SEARCH_LCNNO_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH_LCNNO.Click
        Panel_lcnno_search.Visible = True
        Search_FN()
        RadGrid1.Rebind()
    End Sub

End Class
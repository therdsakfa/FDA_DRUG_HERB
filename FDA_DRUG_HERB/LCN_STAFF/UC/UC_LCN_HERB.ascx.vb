Imports Telerik.Web.UI
Public Class UC_LCN_HERB
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _lct_ida As String = ""
    Private _YEARS As String


    Sub RunQuery()
        Try
            _CLS = Session("CLS")
            _lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()

        If Not IsPostBack Then
            set_data()
            set_ddl_place()
        End If
    End Sub
    Sub set_ddl_place()
        Dim iden As String = ""
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("ida"))
        Try
            iden = dao.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, iden)


        ddl_placename.DataSource = dt
        ddl_placename.DataValueField = "IDA"
        ddl_placename.DataTextField = "thanameplace"
        ddl_placename.DataBind()

        Dim item As New ListItem("", "")
        ddl_placename.Items.Insert(0, item)

    End Sub
    Sub set_data()
        hf_place.Value = ddl_placename.SelectedValue
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(ddl_placename.SelectedValue)
        Catch ex As Exception

        End Try
        Try
            For Each dr As DataRow In dt.Rows
                lbl_location_new.Text = dr("fulladdr")
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            'Dim dao_keep As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            'dao_keep.GetData_by_LCN_IDA(Request.QueryString("ida"))
            'If dao_keep.fields.IDA <> 0 Then
            '    dao_keep.delete()
            'End If

            Dim _IDA_lo As String = ""
            If ddl_placename.SelectedValue <> Nothing Then
                _IDA_lo = ddl_placename.SelectedValue
            Else
                _IDA_lo = _lct_ida
            End If


            If _IDA_lo = "0" Then
                _IDA_lo = "89791"
            ElseIf _IDA_lo = "" Then
                _IDA_lo = "0"
            End If
            If ddl_placename.Items.Count > 0 Then
                Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                Dim dao_LOCATION_ADDRESS_2 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                dao_LOCATION_ADDRESS_2.GetDataby_IDA(_IDA_lo)
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                Catch ex As Exception

                End Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = _CLS.CITIZEN_ID

                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.TR_ID = 0
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.FK_IDA = Request.QueryString("ida")
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LCN_IDA = Request.QueryString("ida")
                Catch ex As Exception

                End Try

                dao_DALCN_DETAIL_LOCATION_KEEP.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thanameplace
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                If _IDA_lo = "0" Or _IDA_lo = "" Then
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thanameplace = "ไม่มีสถานที่เก็บ"
                Else
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thanameplace = dao_LOCATION_ADDRESS_2.fields.thanameplace
                End If

                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lcnsid = dao_LOCATION_ADDRESS_2.fields.lcnsid
                Catch ex As Exception

                End Try

                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engaddr = dao_LOCATION_ADDRESS_2.fields.engaddr
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = dao_LOCATION_ADDRESS_2.fields.tharoom
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = dao_LOCATION_ADDRESS_2.fields.thabuilding
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engsoi = dao_LOCATION_ADDRESS_2.fields.engsoi
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engroad = dao_LOCATION_ADDRESS_2.fields.engroad
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = dao_LOCATION_ADDRESS_2.fields.zipcode
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lstfcd = dao_LOCATION_ADDRESS_2.fields.lstfcd
                Catch ex As Exception

                End Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lmdfdate = dao_LOCATION_ADDRESS_2.fields.lmdfdate
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDA = dao_LOCATION_ADDRESS_2.fields.IDA
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_FK_IDA = dao_LOCATION_ADDRESS_2.fields.FK_IDA
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_TR_ID = dao_LOCATION_ADDRESS_2.fields.TR_ID
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_DOWN_ID = dao_LOCATION_ADDRESS_2.fields.DOWN_ID
                Catch ex As Exception

                End Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID_UPLOAD
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_XMLNAME = dao_LOCATION_ADDRESS_2.fields.XMLNAME
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engmu = dao_LOCATION_ADDRESS_2.fields.engmu
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engfloor = dao_LOCATION_ADDRESS_2.fields.engfloor
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engbuilding = dao_LOCATION_ADDRESS_2.fields.engbuilding
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvno = dao_LOCATION_ADDRESS_2.fields.rcvno
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvdate = dao_LOCATION_ADDRESS_2.fields.rcvdate
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lctcd = dao_LOCATION_ADDRESS_2.fields.lctcd
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_STATUS_ID = dao_LOCATION_ADDRESS_2.fields.STATUS_ID
                Catch ex As Exception

                End Try


                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engnameplace = dao_LOCATION_ADDRESS_2.fields.engnameplace

                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_HOUSENO = dao_LOCATION_ADDRESS_2.fields.HOUSENO
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_NORMAL
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_OTHER
                Catch ex As Exception

                End Try

                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_ID
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thmblcd = dao_LOCATION_ADDRESS_2.fields.thmblcd
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                Catch ex As Exception

                End Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_LOCATION_ADDRESS_2.fields.SYSTEM_NAME
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engthmblnm = dao_LOCATION_ADDRESS_2.fields.engthmblnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engamphrnm = dao_LOCATION_ADDRESS_2.fields.engamphrnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engchngwtnm = dao_LOCATION_ADDRESS_2.fields.engchngwtnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDENTIFY = dao_LOCATION_ADDRESS_2.fields.IDENTIFY
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_REMARK = dao_LOCATION_ADDRESS_2.fields.REMARK
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = dao_LOCATION_ADDRESS_2.fields.Mobile
                dao_DALCN_DETAIL_LOCATION_KEEP.insert()


                RadGrid2.Rebind()
                Response.Write("<script type='text/javascript'>window.parent.alert('บันทึกข้อมูลเรียบร้อยแล้ว');</script> ")

                KEEP_LOCATION_LOGS_EDIT(Request.QueryString("ida"), "เพิ่มข้อมูลสถาที่ " & dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm, _CLS.CITIZEN_ID)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim _ida As String = item("IDA").Text
            Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            Dim name_del As String
            If e.CommandName = "_del" Then
                'Response.Write("<script type='text/javascript'>window.parent.alert('ยืนยันการลบ');</script> ")
                dao_DALCN_DETAIL_LOCATION_KEEP.GetDataby_IDA(_ida)
                name_del = dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm
                dao_DALCN_DETAIL_LOCATION_KEEP.delete()
                RadGrid2.Rebind()

                KEEP_LOCATION_LOGS_EDIT(Request.QueryString("ida"), "ลบข้อมูลสถาที่ " & name_del, _CLS.CITIZEN_ID)
            End If
        End If
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao_mas As New BAO_MASTER
        Dim dt As New DataTable
        Try
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(Request.QueryString("IDA"))
            dt = bao_mas.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            RadGrid2.DataSource = dt
        End If
    End Sub

    Private Sub ddl_placename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_placename.SelectedIndexChanged
        bind_addr()
    End Sub

    Sub bind_addr()
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        Try

            dt = bao.SP_CUSTOMER_LCT_BY_LCT_IDA(ddl_placename.SelectedValue)
            For Each dr As DataRow In dt.Rows
                lbl_location_new.Text = dr("fulladdr")
            Next
        Catch ex As Exception

        End Try
        cb_location.Checked = False
    End Sub

    Protected Sub cb_location_CheckedChanged(sender As Object, e As EventArgs) Handles cb_location.CheckedChanged
        Dim bao_show As New BAO_SHOW
        Dim dt As New DataTable
        If cb_location.Checked = True Then
            dt = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_lct_ida)
            For Each dr As DataRow In dt.Rows
                lbl_location_new.Text = dr("fulladdr")
            Next
        End If
        ddl_placename.SelectedValue = Nothing
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class
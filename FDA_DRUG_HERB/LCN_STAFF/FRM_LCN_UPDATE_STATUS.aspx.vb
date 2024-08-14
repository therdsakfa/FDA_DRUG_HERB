Imports Telerik.Web.UI
Public Class FRM_LCN_UPDATE_STATUS
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
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
    End Sub
    Sub Run_Service(ByVal IDA As Integer)
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.HERB_UPDATE_LICEN(IDA, _CLS.CITIZEN_ID)
    End Sub
    Sub Run_Service_Tabean(ByVal Newcode_Not As String)
        Dim ws_update As New WS_DRUG.WS_DRUG
        Dim dt As New DataTable
        Dim bao_show As New BAO.ClsDBSqlcommand
        dt = bao_show.SP_GET_DATA_DRUG_HERB_BY_NEWCODE_NOT(Newcode_Not)
        For Each dl As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If ddl_stat.SelectedValue = 170 Then
                        Dim dao As New DAO_XML_DRUG_HERB.TB_XML_DRUG_PRODUCT_HERB
                        dao.GetDataby_u1(dr("Newcode_U"))
                        dao.fields.cncnm = "ทะเบียนคงอยู่ แต่ผู้ผลิตยกเลิกกิจการ ทำให้ไม่สามารถผลิตได้"
                        dao.update()
                        ws_update.HERB_UPDATE_XML_PRODUCT(dr("pvncd"), dr("rgttpcd"), dr("drgtpcd"), dr("rgtno"), "ปรับสถานะเนื่องจากใบอนุญาตโดนยกเลิก", _CLS.CITIZEN_ID, "ปรับสถานะใบอนุญาต")
                    End If
                Next
            End If
        Next
        'ws_update.HERB_UPDATE_DR("pvncd", "rgttpcd", "drgtpcd", "rgtno", "remark", _CLS.CITIZEN_ID, "ปรับสถานะใบอนุญาต")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Try
            Shows(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If Not IsPostBack Then
            rdp_cncdate.SelectedDate = Date.Now

            Dim dao As New DAO_DRUG.ClsDBdalcn
            Dim lcntpcd As String = ""
            Dim process_id As String = ""
            Dim ccc As String = ""
            Try
                dao.GetDataby_IDA(Request.QueryString("IDA"))
            Catch ex As Exception

            End Try
            Try
                lcntpcd = dao.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                process_id = dao.fields.PROCESS_ID
            Catch ex As Exception

            End Try
            'Try
            '    ddl_template.DropDownSelectData(dao.fields.TEMPLATE_ID)
            'Catch ex As Exception

            'End Try
            Try
                rdp_cncdate.SelectedDate = CDate(dao.fields.cncdate)
            Catch ex As Exception

            End Try

            'Try
            '    txt_CATEGORY_DRUG.Text = dao.fields.CATEGORY_DRUG
            'Catch ex As Exception

            'End Try
            'If process_id = "109" Or process_id = "110" Or process_id = "122" Or process_id = "127" Or process_id = "128" Then
            '    Panel1.Style.Add("display", "block")
            'End If
            Try
                ccc = dao.fields.cnccscd
                'dao.fields.cnccscd = Nothing
                'lbl_statname.Text = dao.fields.
            Catch ex As Exception
                ccc = ""
            End Try
            Try
                ddl_stat_reason.SelectedValue = dao.fields.reason_update_id
            Catch ex As Exception

            End Try
            'Try
            '    txt_time.Text = dao.fields.opentime
            'Catch ex As Exception

            'End Try
            If ccc = "" Then
                lbl_statname.Text = "คงอยู่"
            Else
                Try
                    Dim dao_cnc As New DAO_DRUG.ClsDBdacscd
                    dao_cnc.GetData_by_cd(ccc)
                    lbl_statname.Text = dao_cnc.fields.csnm
                    If ccc = 170 Or ccc = 171 Or ccc = 172 Or ccc = 173 Then
                        ddl_stat.Enabled = False
                        ddl_stat_reason.Enabled = False
                        REASON_OTHER.ReadOnly = True
                        rdp_cncdate.Enabled = False
                        btn_c_stat.Enabled = False
                    End If
                Catch ex As Exception

                End Try

            End If
            'Try
            '    txt_appdate.Text = CDate(dao.fields.appdate).ToShortDateString()
            'Catch ex As Exception

            'End Try
            Dim expyear As Integer = 0
            Try
                expyear = dao.fields.expyear
            Catch ex As Exception

            End Try
            'If expyear <> 0 Then
            '    If expyear < 2500 Then
            '        expyear = expyear + 543
            '        txt_expyear.Text = expyear
            '    Else
            '        expyear = expyear
            '        txt_expyear.Text = expyear
            '    End If
            'End If
            'Try
            '    txt_expdate.Text = CDate(dao.fields.expdate).ToShortDateString
            'Catch ex As Exception

            'End Try
            bind_ddl_stat()
            bind_ddl_stat_reason()
            Try
                ddl_stat.DropDownSelectData(dao.fields.cnccscd)
            Catch ex As Exception

            End Try

            'rgphr.DataBind()

        End If
    End Sub
    Sub bind_ddl_stat()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
        Catch ex As Exception

        End Try
        Try
            Dim dao_stat As New DAO_DRUG.ClsDBdacscd
            dao_stat.GetDataAll()
            ddl_stat.DataSource = dao_stat.datas
            ddl_stat.DataTextField = "csnm"
            ddl_stat.DataValueField = "cscd"
            ddl_stat.DataBind()

            Dim item As New ListItem
            item.Text = "คงอยู่"
            item.Value = "0"
            ddl_stat.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub bind_ddl_stat_reason()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
        Catch ex As Exception

        End Try
        Try
            Dim dao_stat As New DAO_LCN.TB_MAS_REASON_UPDATE_STATUS
            dao_stat.GetDataAll()
            ddl_stat_reason.DataSource = dao_stat.datas
            ddl_stat_reason.DataTextField = "reason_name"
            ddl_stat_reason.DataValueField = "ID"
            ddl_stat_reason.DataBind()

            Dim item As New ListItem
            item.Text = "--กรูณาเลือก--"
            item.Value = "0"
            ddl_stat_reason.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub set_hide_show()
        'If hd_location.Value = "0" Then
        '    btn_location.Style.Add("display", "block")
        'Else
        '    btn_location.Style.Add("display", "none")
        'End If

        'If hdkeep.Value = "0" Then
        '    btn_add_keep.Style.Add("display", "block")
        'Else
        '    btn_add_keep.Style.Add("display", "none")
        'End If
    End Sub
    Public Sub Shows(ByVal IDA As Integer)
        Dim Tb As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS                               ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim TbNO As New DAO_DRUG.ClsDBdalcn                                     ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            TbNO.GetDataby_IDA(IDA)
            'การ where 
            Tb.GetDataby_IDA(TbNO.fields.FK_IDA)
        Catch ex As Exception

        End Try
        'การ where 
        Try
            tb_location.GetDataby_LCN_IDA(IDA)
        Catch ex As Exception

        End Try
        Dim lcnno As String = ""
        Dim rcvno As String = ""
        Try
            lcnno = TbNO.fields.lcntpcd & " " & CInt(Right(TbNO.fields.lcnno, 5)) & "/" & Left(TbNO.fields.lcnno, 2)
        Catch ex As Exception

        End Try

        Try
            If Right(Left(TbNO.fields.lcnno, 3), 1) = "5" Then
                lcnno = TbNO.fields.lcntpcd & " จ " & CInt(Right(TbNO.fields.lcnno, 4)) & "/" & Left(TbNO.fields.lcnno, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            rcvno = CInt(Right(TbNO.fields.rcvno, 5)) & "/" & Left(TbNO.fields.rcvno, 2)
        Catch ex As Exception

        End Try
        Try
            If TbNO.fields.lcnno IsNot Nothing Then
                Dim raw_lcn As String = TbNO.fields.lcnno
                lbl_lcnno.Text = lcnno 'CStr(CInt((Right(raw_lcn, 5))) & "/25" & Left(raw_lcn, 2))
            End If
        Catch ex As Exception

        End Try
        'Try
        '    lbl_lcnno.Text = TbNO.fields.LCNNO_DISPLAY
        'Catch ex As Exception
        '    lbl_lcnno.Text = "-"
        'End Try

        Try
            lbl_citizenid.Text = TbNO.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try

        Try
            lbl_thanameplace.Text = Tb.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            lbl_nameOperator.Text = tb_location.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_c_stat_Click(sender As Object, e As EventArgs) Handles btn_c_stat.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        Try
            If ddl_stat.SelectedValue = "0" Then
                dao.fields.cnccscd = Nothing
                dao.fields.cnccd = Nothing
                dao.update()
            Else
                dao.fields.cnccscd = ddl_stat.SelectedValue
                dao.fields.cnccd = 2
                dao.fields.cncdate = Date.Now
                dao.fields.effective_date = rdp_cncdate.SelectedDate
                dao.fields.reason_update_id = ddl_stat_reason.SelectedValue
                If ddl_stat_reason.SelectedValue = 6 Then
                    dao.fields.reason_update_nm = REASON_OTHER.Text
                Else
                    dao.fields.reason_update_nm = ddl_stat_reason.SelectedItem.Text
                End If

                dao.update()
            End If
        Catch ex As Exception

        End Try
        Dim dao_herb As New DAO_XML_DRUG_HERB.TB_XML_SEARCH_DRUG_LCN_HERB
        dao_herb.GetDataby_LCN_IDA(Request.QueryString("IDA"))
        Run_Service(Request.QueryString("IDA"))
        Run_Service_Tabean(dao_herb.fields.Newcode_not)
        Dim ccc As String = ""
        ccc = ddl_stat.SelectedValue
        If ccc = "170" Or ccc = "171" Or ccc = "172" Or ccc = "173" Then
            ddl_stat.Enabled = False
            ddl_stat_reason.Enabled = False
            REASON_OTHER.ReadOnly = True
            rdp_cncdate.Enabled = False
            btn_c_stat.Enabled = False
        End If
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)

        KEEP_LOGS_EDIT(Request.QueryString("IDA"), "แก้ไขสถานะใบอนุญาต", _CLS.CITIZEN_ID)
    End Sub

    Protected Sub ddl_stat_reason_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_stat_reason.SelectedIndexChanged
        If ddl_stat_reason.SelectedValue = 6 Then
            REASON_OTHER.Visible = True
        Else
            REASON_OTHER.Visible = False
        End If
    End Sub
End Class
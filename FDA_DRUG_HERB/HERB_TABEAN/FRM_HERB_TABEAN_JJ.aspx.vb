Imports Telerik.Web.UI
Public Class FRM_HERB_TABEAN_JJ
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA_LCT As String = ""
    Private _TR_ID_LCN As String = ""
    Private _IDA_LCN As String = ""
    Private _LCNNO_DISPLAY As String = ""
    Private _PROCESS_ID_LCN As String = ""
    Private _SID As String = ""

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
        _IDA_LCT = Request.QueryString("IDA_LCT")
        _TR_ID_LCN = Request.QueryString("TR_ID_LCN")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _LCNNO_DISPLAY = Request.QueryString("LCNNO_DISPLAY")
        _PROCESS_ID_LCN = Request.QueryString("PROCESS_ID_LCN")
        _SID = Request.QueryString("SID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'bind_dd()
            RadGrid1.Rebind()
            load_HL()
        End If
    End Sub

    Protected Sub DD_HERB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_HERB.SelectedIndexChanged
        bind_dd(DD_HERB.SelectedValue)

        If DD_HERB.SelectedValue = 20301 Then
            DD_HERB_NAME_PRODUCT.Visible = True
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = True
            herb_ya.Visible = True
        ElseIf DD_HERB.SelectedValue = 20302 Then
            DD_HERB_NAME_PRODUCT.Visible = False
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = False
            herb_ya.Visible = False
        ElseIf DD_HERB.SelectedValue = 20303 Then
            DD_HERB_NAME_PRODUCT.Visible = True
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = True
            herb_ya.Visible = True
        ElseIf DD_HERB.SelectedValue = 20304 Then
            If Request.QueryString("staff") = 1 Then
                bind_dd_health(DD_HERB.SelectedValue)
                DD_HERB_NAME_PRODUCT.Visible = False
                DD_HERB_NAME_PRODUCT_HEALTH.Visible = True
                btn_jj_herb.Visible = True
                herb_ya.Visible = True

            Else
                bind_dd_health(DD_HERB.SelectedValue)
                DD_HERB_NAME_PRODUCT.Visible = False
                DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
                btn_jj_herb.Visible = False
                herb_ya.Visible = False
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ระบบปิดปรับปรุง ไม่สามารถสร้างคำขอจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพได้ในขณะนี้ กรุณายื่นคำขออนุญาตผ่านทางระบบปกติไปพลางก่อน หากมีข้อสงสัยติดต่อ เจ้าหน้าที่ เบอร์ 02-5907479');", True)
            End If
        ElseIf DD_HERB.SelectedValue = 20306 Then
            DD_HERB_NAME_PRODUCT.Visible = True
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = True
            herb_ya.Visible = True
        Else
            DD_HERB_NAME_PRODUCT.Visible = False
            DD_HERB_NAME_PRODUCT_HEALTH.Visible = False
            btn_jj_herb.Visible = False
            herb_ya.Visible = False
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
        End If
    End Sub
    Public Sub bind_dd_health(ByVal dd_herb As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd

        dt = bao.SP_DD_MAS_TABEAN_HERB_HEALTH_NAME_JJ()

        DD_HERB_NAME_PRODUCT_HEALTH.DataSource = dt
        DD_HERB_NAME_PRODUCT_HEALTH.DataBind()
        'DD_HERB_NAME_PRODUCT_HEALTH.Items.Insert(0, "-- กรุณาเลือก --")
        Dim item As New RadComboBoxItem
        item.Text = "---กรุณาเลือก---"
        item.Value = "0"
        DD_HERB_NAME_PRODUCT.Items.Insert(0, item)
    End Sub
    Public Sub bind_dd(ByVal dd_herb As Integer)
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        If dd_herb = 20306 Then dd_herb = 20303
        dt = bao.SP_DD_MAS_TABEAN_HERB_NAME_JJ(dd_herb)

        DD_HERB_NAME_PRODUCT.DataSource = dt
        DD_HERB_NAME_PRODUCT.DataBind()
        'DD_HERB_NAME_PRODUCT.Items.Insert(0, "-- กรุณาเลือก --")

        Dim item As New RadComboBoxItem
        item.Text = "---กรุณาเลือก---"
        item.Value = "0"
        DD_HERB_NAME_PRODUCT.Items.Insert(0, item)
    End Sub
    Protected Sub btn_jj_herb_Click(sender As Object, e As EventArgs) Handles btn_jj_herb.Click
        Dim DD_HERB_NAME_PRODUCT_1 As Integer = 0
        Dim DD_HERB_NAME_PRODUCT_HEALTH_2 As Integer = 0
        Dim PROCESS_JJ As Integer = 0
        PROCESS_JJ = DD_HERB.SelectedValue
        If DD_HERB_NAME_PRODUCT.SelectedValue <> "-- กรุณาเลือก --" Then
            If PROCESS_JJ = 20306 Then PROCESS_JJ = 20303
            If Request.QueryString("staff") = 1 Then
                _MENU_GROUP = 1
                If DD_HERB_NAME_PRODUCT.SelectedValue <> 0 Then
                    DD_HERB_NAME_PRODUCT_1 = DD_HERB_NAME_PRODUCT.SelectedValue

                    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_1 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&staff=" & Request.QueryString("staff") & "&SID=" & _SID)
                    'ElseIf DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue <> 0 Then
                    '    DD_HERB_NAME_PRODUCT_HEALTH_2 = DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue
                    '    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_HEALTH_2 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&staff=" & Request.QueryString("staff"))

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
                End If
            Else
                If DD_HERB_NAME_PRODUCT.SelectedValue <> 0 Then
                    DD_HERB_NAME_PRODUCT_1 = DD_HERB_NAME_PRODUCT.SelectedValue
                    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_1 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&SID=" & _SID)
                    'ElseIf DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue <> 0 Then
                    '    DD_HERB_NAME_PRODUCT_HEALTH_2 = DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue
                    '    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_HEALTH_2 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&staff=" & Request.QueryString("staff"))

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
                End If
            End If
        ElseIf DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue <> "-- กรุณาเลือก --" Then
            'If Request.QueryString("staff") = 1 Then
            _MENU_GROUP = 1
            If DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue <> 0 Then
                DD_HERB_NAME_PRODUCT_1 = DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue
                Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                dao_lcn.GetDataby_IDA(_IDA_LCN)
                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
                Dim dao_m As New DAO_TABEAN_HERB.TB_MAS_PRODUCT_NAME_JJ_HERB_FOR_HEALTH
                dao_m.Getdataby_ID(DD_HERB_NAME_PRODUCT_1)
                'dao.GetdatabyID_DD_HERB_NAME_ID(_DD_HERB_NAME_ID, _PROCESS_JJ)
                'dao.fields.PRODUCT_JJ = PROCESS_JJ
                dao.fields.NAME_THAI = dao_m.fields.PRODUCT_NAME
                Try
                    'If _SID = "2" Then
                    '    dao.fields.WHO_ID = 1
                    '    'DAO_WHO.fields.FK_IDA = dao.fields.IDA
                    '    'DAO_WHO.Update()
                    'Else
                    '    dao.fields.WHO_ID = 0
                    'End If
                Catch ex As Exception

                End Try
                dao.fields.DDHERB = PROCESS_JJ
                dao.fields.DD_HERB_NAME_ID = DD_HERB_NAME_PRODUCT_1
                dao.fields.STATUS_ID = 1
                dao.fields.ACTIVEFACT = 1
                dao.fields.TYPE_SUB_ID = 4
                dao.fields.TYPE_SUB_NAME = "ผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ"
                dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
                dao.fields.CREATE_DATE = Date.Now
                If _CLS.AUTHORIZE_NAME = Nothing Then
                    dao.fields.CREATE_BY = _CLS.THANM
                Else
                    dao.fields.CREATE_BY = _CLS.AUTHORIZE_NAME
                End If
                dao.fields.MENU_GROUP = _MENU_GROUP
                Try
                    dao.fields.IDA_LCN = _IDA_LCN
                    dao.fields.LCN_ID = _IDA_LCN
                    dao.fields.IDA_LCT = _IDA_LCT
                    dao.fields.LCNNO = dao_lcn.fields.LCNNO_DISPLAY_NEW
                    dao.fields.LCN_NAME = dao_lcn.fields.thanm
                    dao.fields.LCN_THANAMEPLACE = dao_lcn.fields.thanameplace
                    dao.fields.PVNCD = dao_lcn.fields.pvncd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.TR_ID_LCN = _TR_ID_LCN
                Catch ex As Exception

                End Try
                If Request.QueryString("staff") = 1 Then
                    dao.fields.INOFFICE_STAFF_ID = 1
                    dao.fields.INOFFICE_STAFF_CITIZEN_ID = _CLS.CITIZEN_ID
                End If
                dao.insert()
                Dim IDA As Integer = dao.fields.IDA
                Dim dao2 As New DAO_TABEAN_HERB.TB_TABEAN_JJ
                dao2.GetdatabyID_IDA(IDA)
                Dim TR_ID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.insert_transection_jj(PROCESS_JJ, dao2.fields.IDA, dao2.fields.STATUS_ID)
                'เลขดำเนินการ รันใหม่
                Dim bao_gen As New BAO.GenNumber
                TR_ID = bao_gen.GEN_NO_JJ(con_year(Date.Now.Year), 10, PROCESS_JJ, dao2.fields.IDA, _IDA_LCN)
                dao2.fields.TR_ID_JJ = TR_ID
                dao2.Update()

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกคำขอแล้ว');", True)


                'Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
                'dao_up_mas.GetdatabyID_TYPE(1)
                'For Each dao_up_mas.fields In dao_up_mas.datas
                '    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                '    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                '    dao_up.fields.TR_ID = TR_ID
                '    dao_up.fields.FK_IDA = dao.fields.IDA
                '    dao_up.fields.PROCESS_ID = PROCESS_JJ
                '    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                '    dao_up.fields.TYPE = 1
                '    dao_up.insert()
                'Next
                'dao_up_mas.GetdatabyID_TYPE_AND_HEAD_ID(11, 4)
                'For Each dao_up_mas.fields In dao_up_mas.datas
                '    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                '    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                '    dao_up.fields.TR_ID = TR_ID
                '    dao_up.fields.FK_IDA = dao.fields.IDA
                '    dao_up.fields.PROCESS_ID = PROCESS_JJ
                '    dao_up.fields.FK_IDA_LCN = _IDA_LCN
                '    dao_up.fields.TYPE = 1
                '    dao_up.insert()
                'Next

                'alert_summit("กรุณาแนบไฟล์", dao.fields.IDA, PROCESS_JJ, dao.fields.DD_HERB_NAME_ID)
                Response.Redirect("FRM_HERB_TABEAN_JJ_ADD2_DETAIL.aspx?IDA=" & IDA & "&IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_1 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&staff=" & Request.QueryString("staff") & "&identify=" & Request.QueryString("identify") & "&SID=" & _SID)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
            End If
            '    Else

            '    If DD_HERB_NAME_PRODUCT.SelectedValue <> 0 Then
            '        DD_HERB_NAME_PRODUCT_1 = DD_HERB_NAME_PRODUCT.SelectedValue
            '        Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_1 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
            '        'Response.Redirect("FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_1 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
            '        'ElseIf DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue <> 0 Then
            '        '    DD_HERB_NAME_PRODUCT_HEALTH_2 = DD_HERB_NAME_PRODUCT_HEALTH.SelectedValue
            '        '    Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_PRODUCT_HEALTH_2 & "&PROCESS_JJ=" & PROCESS_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
            '        '
            '    Else
            '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกข้อมูล');", True)
            '    End If
            'End If

        Else
            alert_normal("กรุณาเลือกรายการ")
        End If

    End Sub
    Sub alert_summit(ByVal text As String, ByVal ida_jj As Integer, ByVal process_jj As Integer, ByVal DD_HERB_NAME_ID As Integer)
        Dim url As String = ""
        url = "FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD_HERB_NAME_ID & "&PROCESS_JJ=" & process_jj & "&IDA=" & ida_jj & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&SID=" & _SID
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Function bind_data()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        'Dim C_ID As String = _CLS.CITIZEN_ID_AUTHORIZE
        'dt = bao.SP_TABEAN_JJ(C_ID)       
        If Request.QueryString("SID") = "2" Then
            dt = bao.SP_TABEAN_JJ_BY_IDEN_WHO(_IDA_LCN, _CLS.CITIZEN_ID_AUTHORIZE)
        Else
            dt = bao.SP_TABEAN_JJ(_IDA_LCN)
        End If
        Return dt
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        RadGrid1.DataSource = bind_data()

    End Sub

    'Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound

    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA_LCN As Integer = item("IDA_LCN").Text
    '        Dim TR_ID_LCN As String = item("TR_ID_LCN").Text
    '        Dim FK_IDA_LCT As String = ""
    '        Try
    '            FK_IDA_LCT = item("FK_IDA_LCT").Text
    '        Catch ex As Exception

    '        End Try
    '        Dim DD As Integer = item("DD_HERB_NAME_ID").Text
    '        Dim DD_H As Integer = item("DDHERB").Text
    '        Dim IDA As Integer = item("IDA").Text
    '        Dim TR_ID_JJ As Integer = item("TR_ID_JJ").Text
    '        Dim STATUS_ID As Integer = item("STATUS_ID").Text

    '        Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
    '        If H.Text = "ดูรายละเอียด" And STATUS_ID = 4 Then
    '            lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&process=" & DD_H & "');", True)
    '        ElseIf H.Text = "ดูรายละเอียด" Then
    '            H.NavigateUrl = "FRM_HERB_TABEAN_JJ_DETAIL.aspx?IDA_LCT=" & FK_IDA_LCT & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&DDHERB=" & DD_H & "&IDA=" & IDA & "&TR_ID_JJ=" & TR_ID_JJ 'URL หน้า ยืนยัน
    '        End If

    '    End If
    'End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA_LCN As Integer = item("IDA_LCN").Text
            Dim TR_ID_LCN As String = item("TR_ID_LCN").Text
            Dim FK_IDA_LCT As String = ""
            Try
                FK_IDA_LCT = item("FK_IDA_LCT").Text
            Catch ex As Exception

            End Try
            Dim DD As Integer = item("DD_HERB_NAME_ID").Text
            Dim _PROCESS_JJ As Integer = item("DDHERB").Text
            Dim IDA As Integer = item("IDA").Text
            Dim TR_ID_JJ As Integer = item("TR_ID_JJ").Text
            Dim STATUS_ID As Integer = item("STATUS_ID").Text

            If e.CommandName = "HL_SELECT" Then

                If STATUS_ID = 4 Or STATUS_ID = 24 Then
                    lbl_head1.Text = "แก้ไขข้อมูลและอัพโหลเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_EDIT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA_LCN=" & _IDA_LCN & "');", True)
                ElseIf STATUS_ID = 1 Then
                    ' Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_CHKACC.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                    'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_CHKACC.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ & "');", True)
                ElseIf STATUS_ID = 2 Then
                    'Response.Redirect("FRM_HERB_TABEAN_JJ_ADD_DETAIL_UPLOAD_FILE.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ & "');", True)
                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ & "');", True)
                ElseIf STATUS_ID = 9 Or STATUS_ID = 14 Then
                    lbl_head1.Text = "รายละเอียดคำขอ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../HERB_TABEAN_STAFF/FRM_HERB_TABEAN_STAFF_JJ_DETAIL.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&process=" & _PROCESS_JJ & "&IDA_LCN=" & _IDA_LCN & "');", True)

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../HERB_TABEAN/FRM_HERB_TABEAN_JJ_CONFIRM.aspx?IDA_LCT=" & _IDA_LCT & "&TR_ID_LCN=" & _TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & _IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN & "&TR_ID=" & TR_ID_JJ & "');", True)
                    ' Response.Redirect("FRM_HERB_TABEAN_JJ_DETAIL.aspx?IDA_LCT=" & FK_IDA_LCT & "&TR_ID_LCN=" & TR_ID_LCN & "&MENU_GROUP=" & _MENU_GROUP & "&IDA_LCN=" & IDA_LCN & "&DD_HERB_NAME_ID=" & DD & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA=" & IDA & "&TR_ID_JJ=" & TR_ID_JJ & "&PROCESS_ID_LCN=" & _PROCESS_ID_LCN)
                End If

            ElseIf e.CommandName = "HL1_SELECT" Then
                lbl_head1.Text = "คำขอจดแจ้งผลิตภัณฑ์สมุนไพร แบบ จจ.1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_PREVIEW_JJ1.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "&DD_HERB_NAME_ID=" & DD & "');", True)
            ElseIf e.CommandName = "HL2_SELECT" Then
                lbl_head1.Text = "ใบรับจดแจ้งผลิตภัณฑ์สมุนไพร แบบ จจ.2"
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_PREVIEW_JJ2.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "&DD_HERB_NAME_ID=" & DD & "');", True)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_TABEAN_JJ_PREVIEW_JJ2_UPLOAD.aspx?ida=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "');", True)
            ElseIf e.CommandName = "HL3_SELECT" Then
                lbl_head1.Text = "ใบนัดหมาย"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('FRM_HERB_APPOINMENT.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID_JJ & "&PROCESS_JJ=" & _PROCESS_JJ & "&IDA_LCN=" & IDA_LCN & "');", True)
            ElseIf e.CommandName = "HL4_SELECT" Then
                'Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
                'If Request.QueryString("staff") <> "" Then
                '    urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffherb"
                'Else
                '    urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=herb"
                'End If

                'Dim H As HyperLink = e.Item.FindControl("HL4_SELECT")
                'H.NavigateUrl = urls
            End If

        End If
    End Sub
    Private Sub load_HL()
        Dim dao_jj As New DAO_TABEAN_HERB.TB_TABEAN_JJ
        Dim _IDEN As String = ""
        Try
            _IDEN = _CLS.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception
            _IDEN = _CLS.CITIZEN_ID
        End Try

        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
        ' Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=HERB&acc_type=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=staffherb"
        Else
            urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=herb"
        End If

        hl_pay.NavigateUrl = urls


        'hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & _lct_ida
        'If Request.QueryString("staff") <> "" Then
        '    hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
        'End If
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim TR_ID_JJ As String = item("TR_ID_JJ").Text
            Dim IDA As String = item("IDA").Text
            Dim DDHERB As String = item("DDHERB").Text
            'Dim RGT_NO As  = item("RGTNO_FULL").Text
            Dim dao_JJ As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao_JJ.GetdatabyID_IDA(IDA)
            Dim HL_SELECT As LinkButton = DirectCast(item("HL_SELECT").Controls(0), LinkButton)
            Dim HL1_SELECT As LinkButton = DirectCast(item("HL1_SELECT").Controls(0), LinkButton)
            Dim HL2_SELECT As LinkButton = DirectCast(item("HL2_SELECT").Controls(0), LinkButton)
            Dim HL3_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            Dim HL4_SELECT As LinkButton = DirectCast(item("HL3_SELECT").Controls(0), LinkButton)
            HL1_SELECT.Style.Add("display", "none")
            HL2_SELECT.Style.Add("display", "none")
            HL3_SELECT.Style.Add("display", "none")
            HL4_SELECT.Style.Add("display", "none")

            Dim _IDEN As String = ""
            'If _CLS.CITIZEN_ID_AUTHORIZE Then
            '    _IDEN = _CLS.CITIZEN_ID_AUTHORIZE
            'Else
            '    _IDEN = _CLS.CITIZEN_ID
            'End If
            Try
                _IDEN = dao_JJ.fields.CITIZEN_ID
            Catch ex As Exception
                _IDEN = dao_JJ.fields.CITIZEN_ID_AUTHORIZE
            End Try

            Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
            ' Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=HERB&acc_type=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            If Request.QueryString("staff") <> "" Then
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=staffherb"
            Else
                urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=herb"
            End If
            Dim H As HyperLink = e.Item.FindControl("HL4_SELECT")
            H.Style.Add("display", "none")
            H.Target = "_blank"
            H.NavigateUrl = urls

            If STATUS_ID = 1 Then
                HL_SELECT.Text = "ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
            ElseIf STATUS_ID > 1 Then
                HL_SELECT.Text = "ดูข้อมูล"
            Else
                HL_SELECT.Text = "ดูข้อมูล"
            End If
            If STATUS_ID = 24 Then
                HL_SELECT.Text = "แก้ไขรายละเอียด"
            End If
            If STATUS_ID = 8 Then
                HL1_SELECT.Style.Add("display", "block")
                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao.GetdatabyID_TR_ID_FK_IDA_PROCESS_ORDER_ID(TR_ID_JJ, IDA, DDHERB)
                Dim status_upload13 As Integer = dao.fields.TYPE
                If status_upload13 = 13 Then
                    HL2_SELECT.Style.Add("display", "block")
                End If
                'RGT_NO.Style.Add("display", "block")
            ElseIf STATUS_ID >= 1 Then
                HL1_SELECT.Style.Add("display", "block")
            End If
            'If STATUS_ID = 6 Or STATUS_ID = 8 Or STATUS_ID = 13 Then
            '    HL4_SELECT.Style.Add("display", "block")
            '    H.Style.Add("display", "block")
            'End If
            If STATUS_ID = 3 Or STATUS_ID = 6 Or STATUS_ID = 11 Or STATUS_ID = 12 Or STATUS_ID = 13 Or STATUS_ID = 16 Then
                HL3_SELECT.Style.Add("display", "block")
            End If
        End If
    End Sub
End Class
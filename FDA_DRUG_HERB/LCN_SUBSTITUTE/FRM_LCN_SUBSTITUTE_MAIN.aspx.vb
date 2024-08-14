Imports Telerik.Web.UI
Public Class FRM_LCN_SUBSTITUTE_MAIN1
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    'Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _IDA As String = ""
    Private _iden As String
    Sub RunSession()

        _IDA = Request.QueryString("lcn_ida")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        '_process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_ddl()
            TEXT_LOAD()
            load_HL()
        End If

    End Sub
    Private Sub TEXT_LOAD()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        TXT_LCNNO.Text = dao.fields.LCNNO_DISPLAY_NEW
        TXT_LCB_NAME.Text = dao.fields.LOCATION_ADDRESS_thanameplace
    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffherb"
        Else
            urls &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&system=herb"
        End If

        hl_pay.NavigateUrl = urls

    End Sub
    Private Sub load_ddl()

        'Dim dt As New DataTable
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim _process As String = ""
        'Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        'dao_lcn.GetDataby_IDA(_IDA)
        '_process = dao_lcn.fields.PROCESS_ID

        'dt = bao.SP_DDL_LCN_SUBSTITUTE_by_PROCESS_ID(_process, _CLS.CITIZEN_ID_AUTHORIZE)

        'rcb_search.DataSource = dt 'dao.datas
        'rcb_search.DataTextField = "LCNNO_DISPLAY_NEW"
        'rcb_search.DataValueField = "IDA"
        'rcb_search.DataBind()
        'Dim item As New RadComboBoxItem
        'item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        'item.Value = "0"
        'rcb_search.Items.Insert(0, item)
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
    Protected Sub SUB_ADD_Click(sender As Object, e As EventArgs) Handles SUB_ADD.Click
        Dim _process As String = ""
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA)
        _process = dao_lcn.fields.PROCESS_ID
        If Request.QueryString("lcn_ida") = "" Then
            'If rcb_search.SelectedValue = "" Then
            '    alert("กรุณาเลือกเลขที่ใบอนุญาต")
            'Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_SUBSTITUTE_ADD.aspx?process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&IDA=" & _IDA & "');", True)
            'End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_SUBSTITUTE_ADD.aspx?process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&LCN_IDA=" & _IDA & "');", True)
        End If
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.TB_DALCN_SUBSTITUTE
            dao.Getdata_by_IDA(IDA)
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Dim _process_id As Integer = 0
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Try
                dao_tr.GetDataby_IDA(tr_id)
                _process_id = dao_tr.fields.PROCESS_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                'Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                'dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../LCN_SUBSTITUTE/POPUP_SUBSTITUTE_CONFIRM.aspx?LCN_IDA=" & dao.fields.FK_IDA & "&IDA=" & IDA & "&TR_ID=" & tr_id & "&Process=" & _process_id & "&identify=" & _iden & "');", True)
            ElseIf e.CommandName = "HL_SELECT" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../LCN_SUBSTITUTE/FRM_LCN_SUBSTITUTE_APPOINMENT.aspx?LCN_IDA=" & dao.fields.FK_IDA & "&IDA=" & IDA & "&TR_ID=" & tr_id & "&PROCESS_ID=" & _process_id & "&identify=" & _iden & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            'If Request.QueryString("lcn_ida") = "" Then
            '    dt = bao.SP_DALCN_SUBSTITUTE_BY_FK_IDA(rcb_search.SelectedValue)
            'Else
            dt = bao.SP_DALCN_SUBSTITUTE_BY_FK_IDA(_IDA)
            ' End If

        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim STATUS_ID As String = item("STATUS_ID").Text
            Dim HL1_SELECT As LinkButton = DirectCast(item("HL_SELECT").Controls(0), LinkButton)
            HL1_SELECT.Style.Add("display", "none")
            Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            If STATUS_ID >= 2 Then
                HL1_SELECT.Style.Add("display", "block")
            End If

        End If
    End Sub
End Class
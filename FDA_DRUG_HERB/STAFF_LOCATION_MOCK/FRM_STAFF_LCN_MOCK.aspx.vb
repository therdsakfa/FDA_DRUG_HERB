
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Public Class FRM_STAFF_LCN_MOCK
        Inherits System.Web.UI.Page

        Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
        Private _process As String                  'ประกาศชื่อตัวแปร _process
        Private _lcn_ida As String = ""
        Private _lct_ida As String = ""
        Private _type As String
        Private _process_for As String
        Private _pvncd As Integer
        Private _iden As String
        ''' <summary>
        ''' ฟังก์ชันเรียกใช้ Session
        ''' </summary>
        ''' <remarks></remarks>
        Sub RunSession()
            Try
                _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
                _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
                _lct_ida = Request.QueryString("lct_ida")
                _type = Request.QueryString("type")
                _process_for = Request.QueryString("process_for")
                _iden = Request.QueryString("identify")
            Catch ex As Exception
                Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
            End Try
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
            get_pvncd()
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                'AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ระบบตรวจพบว่าท่านเปิดการใช้งานหลายหน้าจอ จะทำการออกจากระบบโดยอัตโนมัติ');window.location.href = 'https://privus.fda.moph.go.th';", True)
            End If
            End If
        If Not IsPostBack Then
            load_GV_lcnno()         'ให้รันฟังก์ชั่นลำดับที่ 3
            load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
            Try
                rdl_lcn_type.SelectedValue = 1
            Catch ex As Exception

            End Try
        End If
        UC_INFMT.Shows(_lct_ida)
        End Sub
    Private Sub Open_PopUP()
        Dim TR_ID As String = Request.QueryString("TR_ID").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_TR_ID(TR_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & TR_ID & "&Process=" & dao.fields.PROCESS_ID & "&lct_ida=" & dao.fields.FK_IDA & "&identify=" & _iden & "');", True)
    End Sub
    Private Sub load_lbl_name()

            Dim dao_menu As New DAO_DRUG.ClsDBMAS_MENU
            dao_menu.GetDataby_Process2(_process)

            Dim dao_menu2 As New DAO_DRUG.ClsDBMAS_MENU
            dao_menu2.GetDataby_Process2(_process_for)
        If String.IsNullOrEmpty(_process_for) = False Then
            lbl_name_2.Text = " (" & dao_menu2.fields.NAME & ") > "
        End If
        lbl_name.Text = " (" & dao_menu.fields.NAME & ")" 'ดึงชื่อเมนูมาแสดง

        End Sub

        Sub OpenPopupName(ByVal url As String)
            Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
        End Sub
        Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
            Dim bao As New BAO.ClsDBSqlcommand          'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
            Dim dao As New DAO_DRUG.ClsDBMAS_MENU       'ประกาศชื่อตัวแปร DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_Process(_process)             'ดึง dao.GetDataby_Process เพื่อมาโชว์ที่ Gridview ที่เป็นค่า String
        Dim process As String = _process
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_pro.GetDataby_Process_ID(process)
        bao.SP_CUSTOMER_LCN_BY_FK_IDA(Request.QueryString("lct_ida"), dao_pro.fields.PROCESS_NAME, _CLS.CITIZEN_ID_AUTHORIZE)

        GV_lcnno.DataSource = bao.dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
            GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
        End Sub
        Sub get_pvncd()
            '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
            Try
                _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
                If _pvncd = 0 Then
                    _pvncd = _CLS.PVCODE
                End If
            Catch ex As Exception
                _pvncd = 10
            End Try
        End Sub

#Region "GRIDVIEW"
    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound


    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
            Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&Process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "');", True)
        End If
    End Sub


        Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
            GV_lcnno.PageIndex = e.NewPageIndex
            load_GV_lcnno()
        End Sub
#End Region

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()                             'เรียกฟังก์ชั่น  load_GV_lcnno   มาใช้งาน
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_LOCATION_MOCK_INSERT.aspx?type_id=" & _process & "&process=" & _process & "&lct_ida=" & _lct_ida & "&staff=1');", True)
    End Sub

    Protected Sub rdl_lcn_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_lcn_type.SelectedIndexChanged
        If rdl_lcn_type.SelectedValue = 1 Then
            _process = 122
        ElseIf rdl_lcn_type.SelectedValue = 2 Then
            _process = 121
        End If
        load_GV_lcnno()
    End Sub
End Class
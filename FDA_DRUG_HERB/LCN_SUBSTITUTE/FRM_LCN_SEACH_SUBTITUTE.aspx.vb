Imports Telerik.Web.UI
Public Class FRM_LCN_SEACH_SUBTITUTE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String = ""                'ประกาศชื่อตัวแปร _process
    Private _lct_ida As String = ""
    Private _IDA As String = ""
    Private _iden As String
    Sub RunSession()

        Try
            _CLS = Session("CLS")
            ''นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _IDA = Request.QueryString("lcn_ida")
            _iden = Request.QueryString("identify")
            _lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2

            load_ddl()
            'load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
            'load_HL()

        End If

    End Sub
    Private Sub load_ddl()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim _process As String = ""
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_IDA)
        _process = dao_lcn.fields.PROCESS_ID

        dt = bao.SP_DDL_LCN_SUBSTITUTE_by_PROCESS_ID(_process, _CLS.CITIZEN_ID_AUTHORIZE)

        rcb_search.DataSource = dt 'dao.datas
        rcb_search.DataTextField = "LCNNO_DISPLAY_NEW"
        rcb_search.DataValueField = "IDA"
        rcb_search.DataBind()
        Dim item As New RadComboBoxItem
        item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        item.Value = "0"
        rcb_search.Items.Insert(0, item)
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim _process As String = ""
        Dim LCN_IDA As Integer = rcb_search.SelectedValue
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(LCN_IDA)
        _process = dao_lcn.fields.PROCESS_ID
        If Request.QueryString("lcn_ida") = "" Then
            If rcb_search.SelectedValue = "" Then
                alert("กรุณาเลือกเลขที่ใบอนุญาต")
            Else
                Response.Redirect("FRM_LCN_SUBSTITUTE_MAIN.aspx?PROCESS_ID=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&lcn_ida=" & dao_lcn.fields.IDA & "&LCN_DISPLAY=" & rcb_search.SelectedItem.Text)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_SUBSTITUTE_MAIN.aspx?process=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&IDA=" & _IDA & "&LCN_DISPLAY=" & rcb_search.DataTextField & "');", True)
            End If
        Else
            Response.Redirect("FRM_LCN_SUBSTITUTE_MAIN.aspx?PROCESS_ID=" & _process & "&lct_ida=" & _lct_ida & "&identify=" & _iden & "&lcn_ida=" & dao_lcn.fields.IDA & "&LCN_DISPLAY=" & rcb_search.SelectedItem.Text)
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
End Class
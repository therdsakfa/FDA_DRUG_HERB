Public Class UC_LCN_SUB
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _lcn_ida As String

    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _ProcessID = Request.QueryString("PROCESS_ID")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        _IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("LCN_IDA")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        Set_Label(_iden)
        'Set_ddl_type()
        set_txt_label()
        If Not IsPostBack Then
            If _ProcessID = "122" Then
                rdl_lcn_type.SelectedValue = "1"
            ElseIf _ProcessID = "121" Then
                rdl_lcn_type.SelectedValue = "2"
            ElseIf _ProcessID = "120" Then
                rdl_lcn_type.SelectedValue = "3"
            End If

        End If
    End Sub
    'Public Sub Set_ddl_type()
    '    If ddl_sub_purpose.DataValueField = "1" Then
    '        Panel1.Style.Add("display", "block")
    '        Panel2.Style.Add("display", "none")
    '    ElseIf ddl_sub_purpose.SelectedValue = "2" Then
    '        Panel1.Style.Add("display", "none")
    '        Panel2.Style.Add("display", "block")
    '    Else
    '        Panel1.Style.Add("display", "none")
    '        Panel2.Style.Add("display", "none")
    '    End If
    'End Sub
    Public Sub set_txt_label()
        uc102_1.get_label("แนบใบอนุญาตถูกทำลาย หรือ ลบเลือนในสาระสำคัญ")
        uc102_2.get_label("ใบรับแจ้งความของสถานีตำรวจท้องที่ที่ใบอนุญาตนั้นสูญหาย")
        'uc102_3.get_label("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร")

    End Sub
    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)

        uc102_1.ATTACH1(TR_ID, PROCESS_ID, YEAR, "1")
        uc102_2.ATTACH1(TR_ID, PROCESS_ID, YEAR, "2")
        'uc102_3.ATTACH1(TR_ID, PROCESS_ID, YEAR, "3")

    End Sub
    Function CHK_ATTACH_PDF() As Integer
        Dim i As Integer = 0
        i += uc102_1.CHK_Extension()
        i += uc102_2.CHK_Extension()
        Return i
    End Function

    Function CHK_upload_file() As Integer
        Dim i As Integer = 0
        i += uc102_1.CHK_upload_file()
        i += uc102_2.CHK_upload_file()
        Return i
    End Function
    Sub Set_Label(ByVal CITIZEN_ID_AUTHORIZE As String)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt_lcn As New DataTable
        dt_lcn = bao.SP_Lisense_Name_and_Addr(_iden) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน

        For Each dr As DataRow In dt_lcn.Rows
            'Try
            '    txt_da_opentime.Text = dr("thaaddr")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_addr.Text = dr("thaaddr")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_floor.Text = dr("floor")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_room.Text = dr("room")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_ages.Text = dr("age")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_amphor.Text = dr("amphrnm")
            Catch ex As Exception

            End Try
            Try
                txt_sub_building.Text = dr("building")
            Catch ex As Exception

            End Try
            Try
                txt_sub_changwat.Text = dr("chngwtnm")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_email.Text = dr("email")
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_sub_fax.Text = dr("fax")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            'Try
            '    lbl_lcn_iden2.Text = dr("identify")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_mu.Text = dr("mu")
            Catch ex As Exception

            End Try
            Try
                txt_sub_name.Text = dr("tha_fullname")
            Catch ex As Exception

            End Try
            'Try
            '    txt_sub_nation.Text = dr("nation")
            'Catch ex As Exception

            'End Try
            Try
                txt_sub_road.Text = dr("tharoad")
            Catch ex As Exception

            End Try
            Try
                txt_sub_soi.Text = dr("thasoi")
            Catch ex As Exception

            End Try
            Try
                txt_sub_tambol.Text = dr("thmblnm")
            Catch ex As Exception

            End Try
            Try
                txt_sub_tel.Text = dr("tel")
            Catch ex As Exception

            End Try
            Try
                txt_sub_zipcode.Text = dr("zipcode")
            Catch ex As Exception

            End Try
        Next

        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(_lcn_ida)
        txt_sub_opentime.Text = dao_main.fields.opentime
        txt_sub_location.Text = dao_main.fields.LOCATION_ADDRESS_thanameplace
        txt_sub_lcnno.Text = dao_main.fields.LCNNO_DISPLAY_NEW

        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(_lcn_ida)

        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(_lcn_ida)
        If dao_bsn.fields.BSN_THAIFULLNAME = Nothing Then
            txt_sub_bsn_name.Text = "-"
        Else
            txt_sub_bsn_name.Text = dao_bsn.fields.BSN_THAIFULLNAME
        End If

        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao_main.fields.FK_IDA)
        txt_sub_location.Text = dao_addr.fields.thanameplace
    End Sub

    Sub set_data(ByRef dao_sub As DAO_DRUG.TB_DALCN_SUBSTITUTE)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)
        Dim Process_TB As String = "10401"
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        TR_ID = bao_tran.insert_transection(Process_TB)

        Dim Process_sub As Integer
        If dao.fields.PROCESS_ID = 120 Then
            Process_sub = 3
        ElseIf dao.fields.PROCESS_ID = 121 Then
            Process_sub = 2
        ElseIf dao.fields.PROCESS_ID = 122 Then
            Process_sub = 1
        End If

        Dim bsn_nmae As String = ""
        Try
            dao_sub.fields.lcntpcd = dao.fields.lcntpcd
            dao_sub.fields.lcnno = dao.fields.lcnno
            dao_sub.fields.LCNNO_DISPLAY_NEW = dao.fields.LCNNO_DISPLAY_NEW
            dao_sub.fields.IDENTIFY = _iden
            dao_sub.fields.TR_ID = TR_ID
            dao_sub.fields.WTIRE_DATE = Date.Now
            dao_sub.fields.PROCESS_ID = "10401"
            dao_sub.fields.CITIZEN_ID = _CLS.CITIZEN_ID

            dao_sub.fields.FK_IDA = dao.fields.IDA
            'dao_sub.fields.PURPOSE = txt_sub_PURPOSE.Text
            dao_sub.fields.LCN_TYPE = Process_sub
            dao_sub.fields.CITIZEN_ID_AUTHORIZE = dao.fields.CITIZEN_ID_AUTHORIZE

            Try
                dao_sub.fields.PURPOSE_ID = ddl_sub_purpose.SelectedValue
                dao_sub.fields.PURPOSE = ddl_sub_purpose.SelectedItem.Text
                dao_sub.fields.pvncd = dao.fields.pvncd
                dao_sub.fields.activefact = 1
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    'Shared Sub chk_rdl_click()
    '    Dim ddl_purpose As String = ""
    '    ddl_purpose = ddl_sub_purpose.DataValueField
    '    ID = ddl_purpose
    '    'Return id
    'End Sub
    Public Sub load_ddl_sub_purpose()
        Try
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_UPLOAD_SUBTITUTE
            dao.GetDataAll()
            ddl_sub_purpose.DataSource = dao.datas
            ddl_sub_purpose.DataValueField = "TYPE_ID"
            ddl_sub_purpose.DataTextField = "TYPE_NAME"
            ddl_sub_purpose.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_sub_purpose.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddl_sub_purpose_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_sub_purpose.SelectedIndexChanged
        If ddl_sub_purpose.SelectedValue = "1" Then
            Panel1.Style.Add("display", "block")
            Panel2.Style.Add("display", "none")
            Panel2_1.Style.Add("display", "none")
            Panel3.Style.Add("display", "block")
        ElseIf ddl_sub_purpose.SelectedValue = "2" Then
            Panel1.Style.Add("display", "none")
            Panel2.Style.Add("display", "block")
            Panel2_1.Style.Add("display", "block")
            Panel3.Style.Add("display", "block")
        Else
            Panel1.Style.Add("display", "none")
            Panel2_1.Style.Add("display", "none")
            Panel2.Style.Add("display", "none")
        End If
    End Sub
End Class
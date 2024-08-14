Imports System.IO
Imports System.Xml.Serialization
Public Class POPUP_LCN_SUBSTITUTE_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    ' Private _ProcessID As String
    Private _iden As String
    Private _lct_ida As String
    Private _lcn_ida As String
    Private _PROCESS_ID As String

    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        ''_la_IDA = Request.QueryString("la_IDA")
        _iden = Request.QueryString("identify")
        _lct_ida = Request.QueryString("lct_ida")
        _IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("LCN_IDA")
        _PROCESS_ID = Request.QueryString("PROCESS_ID")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'set_txt_label()
            UC_LCN_SUB.load_ddl_sub_purpose()
        End If
    End Sub
    'Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)

    '    uc102_1.ATTACH1(TR_ID, PROCESS_ID, YEAR, "1")
    '    uc102_2.ATTACH1(TR_ID, PROCESS_ID, YEAR, "2")
    '    uc102_3.ATTACH1(TR_ID, PROCESS_ID, YEAR, "3")

    'End Sub
    'Public Sub set_txt_label()

    '    If Session("DDL_TYPE") = 1 Then
    '        uc102_1.get_label("1.สำเนาใบรับแจ้งความ")
    '        uc102_2.get_label("2.ใบสำคัญการขึ้นทะเบียนตำรับยาที่ถูกทำลาย")
    '    Else
    '        uc102_1.get_label("1.สำเนาใบรับแจ้งความ")
    '        uc102_2.get_label("2.ใบสำคัญการขึ้นทะเบียนตำรับยาที่ถูกทำลาย")
    '        uc102_3.get_label("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร")
    '    End If
    'End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        Dim dao_sub As New DAO_DRUG.TB_DALCN_SUBSTITUTE
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)

        UC_LCN_SUB.set_data(dao_sub)
        dao_sub.fields.STATUS_ID = "1"
        If dao_sub.fields.PURPOSE_ID = 0 Or dao_sub.fields.PURPOSE_ID Is Nothing Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเหตุที่ขอรับใบแทน');", True)
            'alert("กรุณาอัพโหลดเอกสาร")
        Else
            Try
                If UC_LCN_SUB.CHK_ATTACH_PDF() = 0 Then
                    If UC_LCN_SUB.CHK_upload_file() = 1 Then
                        UC_LCN_SUB.SET_ATTACH(dao_sub.fields.TR_ID, dao_sub.fields.PROCESS_ID, con_year(Date.Now.Year))
                        dao_sub.insert()

                        Dim bao As New BAO.AppSettings
                        bao.RunAppSettings()

                        Dim TR_ID As String = ""
                        Dim bao_tran As New BAO_TRANSECTION
                        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                        bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

                        'alert("รหัสการดำเนินการ คือ DA-" & dao_sub.fields.PROCESS_ID & "-" & con_year(Date.Now.Date().Year()) & "-" + dao_sub.fields.TR_ID)

                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
                    Else
                        alert("กรุณาแนบไฟล์ PDF")
                    End If

                Else
                    alert("กรุณาแนบไฟล์ PDF")
                End If




                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

                'Response.Redirect("FRM_LCN_SUBTITUTE_UPLOAD.aspx?IDA=" & dao_sub.fields.IDA & "&TR_ID=" & dao_sub.fields.TR_ID & "&process=" & dao_sub.fields.PROCESS_ID & "&LCN_IDA=" & dao_sub.fields.FK_IDA)

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
End Class
Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_LCN_EDIT_STAFF_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _LCN_IDA As Integer
    Private _TR_ID As String
    Private _ProcessID As String
    Private _REASON_TYPE As String
    Private _STATUS_GROUP As Integer
    Private _STATUS_ID As Integer
    Private _dd1_file As Integer
    Private _dd2_file As Integer
    Private _IDA As Integer


    Sub RunSession()

        _LCN_IDA = Request.QueryString("LCN_IDA")
        _REASON_TYPE = Request.QueryString("LCN_EDIT_REASON_TYPE")
        _STATUS_GROUP = Request.QueryString("STATUS_GROUP")
        _STATUS_ID = Request.QueryString("STATUS_ID")
        _IDA = Request.QueryString("IDA")
        _dd1_file = Request.QueryString("ddl_up1")
        _dd2_file = Request.QueryString("ddl_up2")

        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then


            'DD_STATUS.SelectedValue = _STATUS_ID

        End If
        BindTable(_dd1_file, _dd2_file)
    End Sub



    Function bind_reason_mas_upload(ByVal dd1 As Integer, ByVal dd2 As Integer)
        Dim bao_show As New BAO_SHOW
        Dim dt As DataTable
        Dim bao As New BAO_LCN.Dropdown
        dt = bao.SP_LCN_APPROVE_EDIT_GET_MAS_UPLOAD_FILE(dd1, dd2)

        Return dt
    End Function


    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_reason_mas_upload(_dd1_file, _dd2_file)
    End Sub

    Private Sub BindTable(ByVal ddl1 As Integer, ByVal ddl2 As Integer)


        Dim url_img As New BAO.AppSettings
        Dim dao_f As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE
        Dim dao_at As New DAO_LCN.TB_MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE
        Dim group As Integer = 0

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        'dao.GetDataby_LCN_IDA_AND_YEAR_AND_ACTIVE(_LCN_IDA, _YEAR, True)
        dao.GetDataby_IDA(_IDA)
        Dim tr_id As String = ""
        Dim lcn_edit_process As Integer = 0
        tr_id = dao.fields.TR_ID
        lcn_edit_process = dao.fields.LCN_PROCESS_ID

        Dim HEAD_ID As Integer = 0

        dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_AND_TYPE_EDIT(lcn_edit_process, ddl1, ddl2, 2, True)



        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas
            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell
            'Dim tc1 As New TableCell
            Dim GET_UPLOAD_HEAD_ID As Integer = 0
            Dim GET_TITEL_ID As Integer = 0
            Dim GET_TITEL_ID2 As Integer = 0

            TXT_EDIT_NOTE.Text = dao_f.fields.NOTE_FILE_EDIT

            tc = New TableCell
            tc.Text = rows
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.HEAD_ID
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.SUB_DOCUMENT_NAME, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.SUB_DOCUMENT_NAME
            End Try
            tc.Width = 900
            tr.Cells.Add(tc)


            If dao_f.fields.NAME_REAL <> "" And dao_f.fields.HEAD_ID = 0 Then
                tc = New TableCell
                tc.Text = dao_f.fields.NAME_REAL
                tc.Width = 100
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim img As New Image
                Dim AA As String = "https://meshlog.fda.moph.go.th/FDA_DRUG_HERB_DEMO/Images/correct.png"
                img.ImageUrl = AA
                img.Width = 20
                img.Height = 20
                tc.Controls.Add(img)
                tc.Width = 65
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim f As New FileUpload
                f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
                tc.Controls.Add(f)
                'tc.Width = 100
                tr.Cells.Add(tc)
            ElseIf dao_f.fields.NAME_REAL = "" And dao_f.fields.HEAD_ID = 0 Then
                tc = New TableCell
                'tc.Text = dao_f.fields.NAME_REAL
                tc.Width = 100
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim img As New Image
                Dim AA As String = "https://meshlog.fda.moph.go.th/FDA_DRUG_HERB_DEMO/Images/cancel.png"
                img.ImageUrl = AA
                img.Width = 20
                img.Height = 20
                tc.Controls.Add(img)
                tc.Width = 65
                tr.Cells.Add(tc)

                tc = New TableCell
                Dim f As New FileUpload
                f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
                tc.Controls.Add(f)
                tr.Cells.Add(tc)
            Else
                tc = New TableCell
                'tc.Text = dao_f.fields.NAME_REAL
                tc.Width = 100
                tr.Cells.Add(tc)

                tc = New TableCell

                tc.Width = 65
                tr.Cells.Add(tc)

                tc = New TableCell
                'Dim f As New FileUpload
                'f.ID = "F" & dao_f.fields.FILE_NUMBER_NAME
                'tc.Controls.Add(f)
                tr.Cells.Add(tc)
            End If

            tc = New TableCell
            tc.Text = dao_f.fields.FILE_NUMBER_NAME
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)
            tc = New TableCell
            tc.Text = dao_f.fields.HEAD_ID
            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tb_type_menu.Rows.Add(tr)
            rows = rows + 1

        Next

    End Sub



    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_add_upload_Click(sender As Object, e As EventArgs) Handles btn_add_upload.Click

        Dim NAME_FILE As String = ""
        Dim HEAD_ID As Integer = 0

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        'dao.GetDataBY_LCN_IDA_LCN_EDIT_REASON_TYPE_YEAR(_LCN_IDA, _dd1_file, _YEAR, True)
        dao.GetDataBY_IDA_LCN_IDA_LCN_EDIT_REASON_TYPE(_IDA, _LCN_IDA, _dd1_file, True)
        Dim tr_id As String = ""
        Dim lcn_edit_process As Integer = 0
        tr_id = dao.fields.TR_ID
        lcn_edit_process = dao.fields.LCN_PROCESS_ID



        For Each item As GridDataItem In RadGrid1.SelectedItems
            NAME_FILE = item("DUCUMENT_NAME").Text
            HEAD_ID = item("HEAD_ID").Text
            ID = item("ID").Text

            Dim dao_up As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE
            Dim dao_dd1 As New DAO_LCN.TB_MAS_LCN_APPROVE_EDIT_REASON
            Dim dao_dd2 As New DAO_LCN.TB_MAS_LCN_APPROVE_EDIT_REASON_SUB

            Dim dd1_name As String = ""
            Dim dd2_name As String = ""

            Dim GET_IDA_UPLOAD As Integer = 0
            dao_up.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(lcn_edit_process, HEAD_ID, _dd1_file, _dd2_file, _TR_ID, 1)

            Try
                GET_IDA_UPLOAD = dao_up.fields.IDA
            Catch ex As Exception
                GET_IDA_UPLOAD = 0
            End Try

            If GET_IDA_UPLOAD = 0 Then
                dao_up.fields.FK_IDA = _LCN_IDA

                dao_up.fields.DATE_YEAR = con_year(Date.Now().Year())

                dao_up.fields.PROCESS_ID = lcn_edit_process
                dao_up.fields.TR_ID = tr_id

                dao_up.fields.FILE_NUMBER_NAME = ID

                dao_dd1.GetDataby_DDL1(_dd1_file, True)
                dao_dd2.GetDataby_DDL2(_dd2_file, True)
                dd1_name = dao_dd1.fields.LCN_REASON_NAME
                dd2_name = dao_dd2.fields.SUB_REASON_NAME

                dao_up.fields.TYPE_LOCAL_NAME = dd1_name
                dao_up.fields.DUCUMENT_NAME = dd2_name
                dao_up.fields.SUB_DOCUMENT_NAME = NAME_FILE

                dao_up.fields.HEAD_ID = HEAD_ID
                dao_up.fields.FK_TITEL_ID = _dd1_file
                dao_up.fields.FK_TITEL_ID2 = _dd2_file



                dao_up.fields.CREATE_DATE = System.DateTime.Now

                dao_up.fields.NOTE_FILE_EDIT = TXT_EDIT_NOTE.Text

                dao_up.fields.TYPE = 2 'ส่งรายการให้ ผปก แก้ไข

                dao_up.fields.ACTIVE = 1

                dao_up.insert()
            Else
                dao_up.fields.UPDATE_DATE = System.DateTime.Now
                dao_up.fields.TYPE = 2 'ส่งรายการให้ ผปก แก้ไข
                dao_up.fields.NOTE_FILE_EDIT = TXT_EDIT_NOTE.Text

                dao_up.update()
            End If



        Next


        tb_type_menu.Rows.Clear() 'เคลียข้อมูล table 

        BindTable(_dd1_file, _dd2_file) 'Upload แล้ว bind tableใหม่



        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Sub alert_normal(ByVal text As String)
        Dim url As String = ""
        url = Request.Url.AbsoluteUri
        Response.Write("<script type='text/javascript'>alert('" + text + "');window.location='" & url & "';</script> ")
    End Sub

    Protected Sub btn_upload_edit_Click(sender As Object, e As EventArgs) Handles btn_upload_edit.Click

        Dim NAME_FILE As String = ""
        Dim HEAD_ID As Integer = 0

        Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim _YEAR As String = con_year(Date.Now().Year())
        'dao.GetDataBY_LCN_IDA_LCN_EDIT_REASON_TYPE_YEAR(_LCN_IDA, _dd1_file, _YEAR, True)
        dao.GetDataBY_IDA_LCN_IDA_LCN_EDIT_REASON_TYPE(_IDA, _LCN_IDA, _dd1_file, True)
        Dim tr_id As String = ""
        Dim lcn_edit_process As Integer = 0
        tr_id = dao.fields.TR_ID
        lcn_edit_process = dao.fields.LCN_PROCESS_ID
        dao.update()

        For Each tr As TableRow In tb_type_menu.Rows


            Dim GET_SUB_DOC_NAME As String = tr.Cells(2).Text
            Dim IDA_FILE As Integer = tr.Cells(6).Text 'เอาข้อมูลช่องแรกมา
            HEAD_ID = tr.Cells(7).Text 'เอาช่องสุดท้ายมาใช้ ปิด display ไว้อยู่

            Dim f As New FileUpload
            Try
                f = tr.FindControl("F" & IDA_FILE)
            Catch ex As Exception

            End Try

            If IDA_FILE = 69 Then
                Dim name_real As String = f.FileName
                Dim Array_NAME_REAL() As String = Split(name_real, ".")
                Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                If exten.ToUpper = "PDF" Then
                    Dim bao As New BAO.AppSettings

                    Dim Name_fake As String = "HB-" & lcn_edit_process & "-" & Date.Now.Year & "-" & IDA_FILE & ".pdf"

                    Dim dao_f As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE



                    Dim GET_IDA_UPLOAD As Integer = 0

                    dao_f.GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(lcn_edit_process, HEAD_ID, _dd1_file, _dd2_file, tr_id, 1)

                    dao_f.fields.DATE_YEAR = con_year(Date.Now().Year())
                    dao_f.fields.NAME_FAKE = Name_fake
                    dao_f.fields.NAME_REAL = f.FileName

                    dao_f.update()

                    Dim paths As String = bao._PATH_DEFAULT
                    f.SaveAs(paths & "upload\" & "LCN_EDIT\" & Name_fake)
                Else
                    alert_normal(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                End If
            End If

        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพโหลดเรียบร้อยแล้ว');", True)
        tb_type_menu.Rows.Clear() 'เคลียข้อมูล table 
        BindTable(_dd1_file, _dd2_file) 'Upload แล้ว bind tableใหม่
    End Sub
End Class
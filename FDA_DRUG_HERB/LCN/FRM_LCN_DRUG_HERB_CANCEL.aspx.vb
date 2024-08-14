Imports Telerik.Web.UI
Public Class FRM_LCN_DRUG_HERB_CANCEL
        Inherits System.Web.UI.Page
        Private _CLS As New CLS_SESSION
        Private _IDA As String
        Private _TR_ID As String
        Private _ProcessID As String
        Private _STATUS_ID As String


    Sub RunSession()
        _ProcessID = Request.QueryString("PROCESS_ID")
        _STATUS_ID = Request.QueryString("STATUS_ID")
            _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        Try
                _CLS = Session("CLS")
            Catch ex As Exception
                Response.Redirect("http://privus.fda.moph.go.th/")
            End Try
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            RunSession()
            If Not IsPostBack Then
                'Run_Pdf_Tabean_Herb()
                set_txt()
                bind_mas_cancel()
            End If
        End Sub
    Sub set_txt()
        txt_cancel_date.Text = Date.Now.ToString("dd'/'MM'/'yyyy")
    End Sub
    Public Sub bind_mas_cancel()
            Dim dt As DataTable
            Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STATUS_CANCEL_LCN_HERB(3)
        'dt = bao.SP_MAS_DDL_SECTION_CANCEL()

        DD_CANCEL.DataSource = dt
            DD_CANCEL.DataValueField = "ID"
            DD_CANCEL.DataTextField = "STATUS_CAUSE"
            DD_CANCEL.DataBind()
            'DD_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")

            Dim item As New RadComboBoxItem
            item.Text = "--กรุณาเลือกรายการ--"
            item.Value = "0"
            DD_CANCEL.Items.Insert(0, item)
        End Sub
        Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
            Dim url As String = ""
            If Request.QueryString("OPF") = "1" Then
                url = "http://202.139.212.70/ONE-PLATFORM/?Token=" & _CLS.TOKEN
                Response.Redirect(url)
            Else
                Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
            End If
        End Sub
        Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
            Dim message As String = "กรุณากรอกข้อมูลให้ครบ"
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        If DD_CANCEL.SelectedValue = 0 Then
                message = "โปรดเลือกเหตุผลในการยกเลิก"
                ClientScript.RegisterOnSubmitStatement(Me.GetType(), "confirm", "return confirm('" & message & "');")
            Else
                dao.fields.STATUS_ID = _STATUS_ID
                dao.fields.cancel_by = _CLS.THANM
                dao.fields.cancel_date = Date.Now
                dao.fields.cancel_iden = _CLS.CITIZEN_ID
                dao.fields.DD_CANCEL_ID = DD_CANCEL.SelectedValue
                dao.fields.DD_CANCEL_NM = DD_CANCEL.SelectedItem.Text
                dao.fields.NOTE_CANCEL = txt_cencel_note.Text
            dao.update()

            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            Dim url As String = ""
            'If Request.QueryString("OPF") = "1" Then
            '    url = "http://202.139.212.70/ONE-PLATFORM/?Token=" & _CLS.TOKEN
            '    Response.Redirect(url)
            'Else
            Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
            'End If
        End If


        End Sub
    End Class
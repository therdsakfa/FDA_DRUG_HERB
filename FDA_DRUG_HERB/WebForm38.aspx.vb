Public Class WebForm38
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub insert_dr_Click(sender As Object, e As EventArgs) Handles insert_dr.Click
        Dim pvncd As String = txt_pvncd.Text
        Dim rgttpcd As String = txt_rgttpcd.Text
        Dim drgtpcd As String = txt_drgtpcd.Text
        Dim rgtno As String = txt_rgtno.Text
        Dim remark As String = txt_why.Text
        Dim iden_edit As String = txt_iden_edit.Text
        Dim system As String = "HERB"

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_INSERT_DR(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)
    End Sub
    Protected Sub insert_all_dr_Click(sender As Object, e As EventArgs) Handles btn_insert_tabean124.Click
        Dim dt As New DataTable
        Dim ws_drug As New WS_DRUG.WS_DRUG
        Dim bao_show As New BAO.ClsDBSqlcommand
        Dim pvncd As String = ""
        Dim rgttpcd As String = ""
        Dim drgtpcd As String = ""
        Dim rgtno As String = ""
        Dim remark As String = ""
        Dim iden_edit As String = Identify_txt.Text
        Dim system As String = "HERB"
        dt = bao_show.SP_GETDATA_HERB_TO_124()
        For Each dl As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    ws_drug.HERB_INSERT_DR(dr("pvncd"), dr("rgttpcd"), dr("drgtpcd"), dr("rgtno"), "", iden_edit, "ดึงข้อมูลทะเบียนตกค้าง")
                Next
            End If
        Next
    End Sub

    Protected Sub update_dr_Click(sender As Object, e As EventArgs) Handles update_dr.Click
        Dim pvncd As String = txt_pvncd.Text
        Dim rgttpcd As String = txt_rgttpcd.Text
        Dim drgtpcd As String = txt_drgtpcd.Text
        Dim rgtno As String = txt_rgtno.Text
        Dim remark As String = txt_why.Text
        Dim iden_edit As String = txt_iden_edit.Text
        Dim system As String = "HERB"

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_UPDATE_DR(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)
    End Sub

    Protected Sub delete_dr_Click(sender As Object, e As EventArgs) Handles delete_dr.Click
        Dim pvncd As String = txt_pvncd.Text
        Dim rgttpcd As String = txt_rgttpcd.Text
        Dim drgtpcd As String = txt_drgtpcd.Text
        Dim rgtno As String = txt_rgtno.Text
        Dim remark As String = txt_why.Text
        Dim iden_edit As String = txt_iden_edit.Text
        Dim system As String = "HERB"

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_DELETE_DR(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)
    End Sub

    Protected Sub insert0_Click(sender As Object, e As EventArgs) Handles insert0.Click
        Dim IDA_DH15 As String = txt_dr15.Text
        Dim iden_edit As String = iden_dh15.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_INSERT_DR15(IDA_DH15, iden_edit)
    End Sub

    Protected Sub update_dh15_Click(sender As Object, e As EventArgs) Handles update_dh15.Click
        Dim IDA_DH15 As String = txt_dr15.Text
        Dim iden_edit As String = iden_dh15.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_UPDATE_DH15(IDA_DH15, iden_edit)
    End Sub

    Protected Sub update_xml_Click(sender As Object, e As EventArgs) Handles update_xml.Click
        Dim newcode As String = txt_newcode_xml_update.Text
        Dim iden_edit As String = txt_iden_update_xml.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.XML_DRUG_BC_UPDATE_TB(newcode, iden_edit)
    End Sub

    Protected Sub insert_xml_BC_Click(sender As Object, e As EventArgs) Handles insert_xml_BC.Click
        Dim newcode As String = txt_insert_xml.Text
        Dim iden_edit As String = txt_iden_insert_xml.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.XML_DRUG_FORMULA(newcode, iden_edit)
    End Sub

    Protected Sub insert_LCN_Click(sender As Object, e As EventArgs) Handles insert_LCN.Click
        Dim IDA As String = txt_IDA_LCN.Text
        Dim iden_edit As String = txt_iden_licen.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_INSERT_LICEN(IDA, iden_edit)
    End Sub

    Protected Sub update_LCN_Click(sender As Object, e As EventArgs) Handles update_LCN.Click
        Dim IDA As String = txt_IDA_LCN.Text
        Dim iden_edit As String = txt_iden_licen.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.HERB_UPDATE_LICEN(IDA, iden_edit)
    End Sub

    Protected Sub btn_gen_xml_pro_Click(sender As Object, e As EventArgs) Handles btn_gen_xml_pro.Click
        Dim iden_edit As String = txt_iden_licen.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        'ws_drug.HERB_INSERT_XML_PRODUCT_ALL(iden_edit)
    End Sub

    Protected Sub BTN_CONFIRM_IST_Click(sender As Object, e As EventArgs) Handles BTN_CONFIRM_IST.Click
        Dim IDEN As String = TXT_IDEN_ISTTB.Text
        Dim REMARK As String = TXT_REMARK_ISTTB.Text

        Dim ws_drug As New WS_DRUG.WS_DRUG
        ws_drug.UPDATE_DR_HERB_FOR(REMARK, IDEN, "ทะเบียน")
    End Sub

    Protected Sub BTN_GEN_TRANSACTION_Click(sender As Object, e As EventArgs) Handles BTN_GEN_TRANSACTION.Click
        Dim IDEN As String = IDENTIFY_GEN.Text
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_TR_ID_RESIDUE_DRR()
        For Each dr In dt.Rows
            Dim int_no As Integer
            Dim dao_TR As New DAO_TABEAN_HERB.TB_TTRANSACTION_NO_RESIDUE
            dao_TR.GetdatabyID_PROCESS_ID(dr("PROCESS_ID"))
            If IsNothing(dao_TR.fields.GEN_NO) = True Then
                int_no = 0
            Else
                int_no = dao_TR.fields.GEN_NO
            End If
            int_no = int_no + 1

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            Dim TRANSACTION_NO As String = "S" & str_no
            Dim dao As New DAO_TABEAN_HERB.TB_TTRANSACTION_NO_RESIDUE
            Try
                dao.fields.REF_NO = dr("IDA")
            Catch ex As Exception

            End Try
            Try
                dao.fields.CITIEZEN_ID = IDEN
            Catch ex As Exception

            End Try
            Try
                dao.fields.CITIEZEN_ID_AUTHORIZE = dr("IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                dao.fields.CREATE_DATE = DateTime.Now
            Catch ex As Exception

            End Try
            Try
                dao.fields.STATUS = dr("STATUS_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.DESCRIPTION = "เจนรหัสใหม่ เนื่องจากไม่ได้ขอผ่านระบบ"
            Catch ex As Exception

            End Try
            Try
                dao.fields.PROCESS_ID = dr("PROCESS_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.GEN_NO = int_no
            Catch ex As Exception

            End Try
            Try
                dao.fields.YEAR = con_year(Date.Now().Year())
            Catch ex As Exception

            End Try
            Try
                dao.fields.TRANSACTION_NO = TRANSACTION_NO
            Catch ex As Exception

            End Try
            dao.insert()

            Dim dao_g As New DAO_DRUG.ClsDBdrrgt
            Try
                dao_g.GetDataby_IDA(dr("IDA"))
                dao_g.fields.TR_ID_OLD = TRANSACTION_NO
                dao_g.update()
            Catch ex As Exception

            End Try

        Next
    End Sub
End Class
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
End Class
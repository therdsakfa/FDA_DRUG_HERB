<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_MASTER_JJ_NAME.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_MASTER_JJ_NAME" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>เพิ่มชื่อยา:</label>
        </div>
        <div class="col-lg-8">
            <asp:TextBox ID="HERB_NAME" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" />
        </div>
    </div>

</asp:Content>

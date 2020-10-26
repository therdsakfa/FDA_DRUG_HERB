<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_DRUG_GROUP_HERB.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_DRUG_GROUP_HERB" %>

<%@ Register Src="~/LCN/UC/UC_TABLE_DRUG_GROUP_CHANGE_HERB.ascx" TagPrefix="uc1" TagName="UC_TABLE_DRUG_GROUP_CHANGE_HERB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_TABLE_DRUG_GROUP_CHANGE_HERB runat="server" ID="UC_TABLE_DRUG_GROUP_CHANGE_HERB" />
    <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  </div>
</asp:Content>

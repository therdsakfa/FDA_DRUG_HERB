<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_LCN_INSERT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_STAFF_LCN_INSERT" %>

<%@ Register Src="~/LCN_STAFF/UC/UC_LCN_HERB.ascx" TagPrefix="uc1" TagName="UC_LCN_HERB" %>
<%@ Register Src="~/LCN_STAFF/UC/UC_LCN_HERB_PHESAJ.ascx" TagPrefix="uc1" TagName="UC_LCN_HERB_PHESAJ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div></div>
    <div></div>
    <div>
        <uc1:UC_LCN_HERB runat="server" id="UC_LCN_HERB" />
        <uc1:UC_LCN_HERB_PHESAJ runat="server" id="UC_LCN_HERB_PHESAJ" />
    </div>
</asp:Content>

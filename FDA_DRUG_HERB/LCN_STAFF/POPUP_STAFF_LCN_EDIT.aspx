﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_LCN_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_STAFF_LCN_EDIT" %>

<%@ Register Src="~/LCN_STAFF/UC/UC_LCN_HERB.ascx" TagPrefix="uc1" TagName="UC_LCN_HERB" %>
<%@ Register Src="~/LCN_STAFF/UC/UC_LCN_HERB_PHESAJ.ascx" TagPrefix="uc1" TagName="UC_LCN_HERB_PHESAJ" %>
<%@ Register Src="~/LCN/UC/UC_TABLE_DRUG_GROUP_CHANGE_HERB.ascx" TagPrefix="uc1" TagName="UC_TABLE_DRUG_GROUP_CHANGE_HERB" %>







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
        <asp:Panel ID="Panel1" runat="server" style="display:none;">
            <uc1:UC_TABLE_DRUG_GROUP_CHANGE_HERB runat="server" ID="UC_TABLE_DRUG_GROUP_CHANGE_HERB" />
        </asp:Panel>

    </div>
</asp:Content>
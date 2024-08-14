<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_TABEAN_EXH_EQTO.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_EXH_EQTO" %>
<%@ Register Src="~/HERB_TABEAN_EXHIBITION/UC/UC_EXH_EQTO.ascx" TagPrefix="uc1" TagName="UC_EXH_EQTO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--    <uc1:UC_EQTO runat="server" ID="UC_EQTO" />--%>
    <uc1:UC_EXH_EQTO runat="server" ID="UC_EXH_EQTO" />
</asp:Content>

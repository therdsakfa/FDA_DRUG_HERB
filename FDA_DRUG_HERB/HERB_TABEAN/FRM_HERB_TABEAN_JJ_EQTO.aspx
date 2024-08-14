<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_JJ_EQTO.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_EQTO" %>
<%--<%@ Register Src="~/TABEAN_YA/UC/UC_EQTO.ascx" TagPrefix="uc1" TagName="UC_EQTO" %>--%>
<%@ Register Src="~/HERB_TABEAN/UC/UC_TABEAN_JJ_EQTO.ascx" TagPrefix="uc1" TagName="UC_TABEAN_JJ_EQTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--    <uc1:UC_EQTO runat="server" ID="UC_EQTO" />--%>
    <uc1:UC_TABEAN_JJ_EQTO runat="server" ID="UC_TABEAN_JJ_EQTO" />
</asp:Content>

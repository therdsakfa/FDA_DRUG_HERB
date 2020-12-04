<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_ADD" %>

<%@ Register Src="~/LCN/UC/UC_HERB.ascx" TagPrefix="uc1" TagName="UC_HERB" %>
<%@ Register Src="~/LCN/UC/UC_HERB_KEEP.ascx" TagPrefix="uc1" TagName="UC_HERB_KEEP" %>
<%@ Register Src="~/LCN/UC/UC_HERB_PHESAJ.ascx" TagPrefix="uc1" TagName="UC_HERB_PHESAJ" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:UC_HERB runat="server" ID="UC_HERB" /> 
                                               <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูลส่วนที่ 1" CssClass="btn-lg" OnClientClick="confirm('ต้องการบันทึกหรือไม่');" /> 
                                               <br />
    <br />
    <br />

    <asp:Panel ID="Panel1" runat="server" style="display:none;">
        <uc1:UC_HERB_KEEP runat="server" ID="UC_HERB_KEEP" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" style="display:none;">
        <uc1:UC_HERB_PHESAJ runat="server" ID="UC_HERB_PHESAJ" />
    </asp:Panel>
</asp:Content>

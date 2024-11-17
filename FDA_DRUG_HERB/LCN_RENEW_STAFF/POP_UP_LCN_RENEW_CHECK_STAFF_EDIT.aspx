<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POP_UP_LCN_RENEW_CHECK_STAFF_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.POP_UP_LCN_RENEW_CHECK_STAFF_EDIT" %>

<%@ Register Src="~/LCN_RENEW_STAFF/UC/UC_HERB_PRE.ascx" TagPrefix="uc1" TagName="UC_HERB_PRE" %>
<%@ Register Src="~/LCN_RENEW_STAFF/UC/UC_HERB_BSN_PRE.ascx" TagPrefix="uc1" TagName="UC_HERB_BSN_PRE" %>
<%@ Register Src="~/LCN_RENEW_STAFF/UC/UC_HERB_KEEP_PRE.ascx" TagPrefix="uc1" TagName="UC_HERB_KEEP_PRE" %>
<%@ Register Src="~/LCN_RENEW_STAFF/UC/UC_HERB_PHESAJ_PRE.ascx" TagPrefix="uc1" TagName="UC_HERB_PHESAJ_PRE" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%; padding-left: 5%; padding-right: 5%; padding-top: 0.1%; background-color: gray;">
        <div class="panel panel-body" style="width: auto; padding-left: 5%; padding-right: 5%; background-color: white;">
            <asp:Panel ID="Panel4" runat="server" Style="display: block;">
                <uc1:UC_HERB_PRE runat="server" ID="UC_HERB_PRE" />
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel1" runat="server" Style="display: block;">
                <uc1:UC_HERB_BSN_PRE runat="server" ID="UC_HERB_BSN_PRE" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Style="display: block;">
                <div class="row">
                    <uc1:UC_HERB_KEEP_PRE runat="server" ID="UC_HERB_KEEP_PRE" />
                </div>
                <div class="row">
                </div>
                <hr />
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Style="display: block;">
                <hr />
                <uc1:UC_HERB_PHESAJ_PRE runat="server" ID="UC_HERB_PHESAJ_PRE" />
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="text-align: center">
                        <asp:Button ID="btn_cancel" runat="server" Text="ปิด" CssClass="btn-lg" Width="15%" />
                        <asp:Button ID="btn_sumit" runat="server" Text="อัพเดทข้อมูล" CssClass="btn-lg" Width="15%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>


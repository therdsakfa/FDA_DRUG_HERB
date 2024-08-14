<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_STAFF_ADD_CONTAINS.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_STAFF_ADD_CONTAINS" %>

<%@ Register Src="~/TABEAN_YA/UC/UC_officer_che.ascx" TagPrefix="uc1" TagName="UC_officer_che" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel-heading" style="text-align:center">
        <h2>สูตรสาร</h2>        
    </div>
    <div class="panel-body" >
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                 <uc1:UC_officer_che runat="server" ID="UC_officer_che" />
            </div>
            <div class="col-lg-1"></div>
        </div>
          <div style="height:20px"></div> 
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="text-align:center">
                <asp:Button ID="btn_cancel" runat="server" Text="ปิด" Height="45px" Width="130px" />&ensp;
                 <asp:Button ID="btn_save" runat="server" Text="กลับไปหน้าอนุมัติ" Height="45px" Width="130px" />           
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>
   
</asp:Content>

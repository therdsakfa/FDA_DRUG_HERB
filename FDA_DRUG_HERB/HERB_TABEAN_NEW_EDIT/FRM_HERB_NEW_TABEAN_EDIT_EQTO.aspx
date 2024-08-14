<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_NEW_TABEAN_EDIT_EQTO.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_NEW_TABEAN_EDIT_EQTO" %>

<%@ Register Src="~/HERB_TABEAN_NEW_EDIT/UC/UC_TABEAN_EDIT_EQTO.ascx" TagPrefix="uc1" TagName="UC_TABEAN_EDIT_EQTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div class="row" style="height: 30px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
              <h3>EQTO</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
              <uc1:UC_TABEAN_EDIT_EQTO runat="server" id="UC_TABEAN_EDIT_EQTO" />
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>

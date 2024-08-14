<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_STAFF_REPLACEMENT_TABEAN_PANEL_CHOOSE.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_STAFF_REPLACEMENT_TABEAN_PANEL_CHOOSE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .btn_new {
            border-radius: 12px;
        }

        .btn_other {
            border-radius: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="form-group text-center">
            <asp:Button ID="btn_new" runat="server" Text="คำขอใหม่" class="btn btn-green" Style="color: DarkBlue; width: 350px; height: 210px; border-radius: 12px; border: solid; border-width: thin; border-color: lightgreen;" BackColor="White" />
            <asp:Button ID="btn_other" runat="server" Text="คำขออื่นๆ" class="btn btn-green" Style="color: DarkBlue; width: 350px; height: 210px; border-radius: 12px; border: solid; border-width: thin; border-color: lightgreen;" BackColor="White" />
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="FRM_HERB_TABEAN_SELECT_SID.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_SELECT_SID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12" style="text-align:center">
            <h3>กรุณาเลือกสิทธ์ในการขออนุญาต</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-5" style="text-align:center">
            <asp:Button ID="btn_new" runat="server" Text="ขอภายใต้สิทธ์ใบอนุญาตของท่าน" class="btn btn-green" style="color:DarkBlue;width:350px;height:210px;border-radius: 12px; border:solid; border-width:thin; border-color:lightgreen;" BackColor="White" />
        </div>
        <div class="col-lg-5" style="text-align:center">
            <asp:Button ID="btn_other" runat="server" Text="ขอภายใต้สิทธ์ใบอนุญาตที่ได้รับมอบ" class="btn btn-green" style="color:DarkBlue;width:350px;height:210px;border-radius: 12px; border:solid; border-width:thin; border-color:lightgreen;" BackColor="White" />
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>
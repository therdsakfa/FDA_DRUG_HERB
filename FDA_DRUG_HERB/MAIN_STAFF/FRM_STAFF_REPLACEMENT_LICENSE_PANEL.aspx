﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_STAFF_REPLACEMENT_LICENSE_PANEL.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_STAFF_REPLACEMENT_LICENSE_PANEL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            border-collapse: collapse;
            width: 100%;
            max-width: 100%;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <center>

        <div class="panel panel-default">
            <div class="panel-heading">รับเรื่องแทนผู้ประกอบการ </div>
            <asp:Panel ID="pn_1" runat="server">
                <div class="panel-body">
                    <asp:Button ID="btn_LCN" runat="server" Text="ระบบการขออนุญาตสถานที่ด้านผลิตภัณฑ์สมุนไพร" />
                    <asp:Button ID="btn_dh" runat="server" Text="ระบบการขออนุญาตเภสัชเคมีภัณฑ์" Enabled="false" />
                    <asp:Button ID="btn_dr" runat="server" Text="ระบบการขออนุญาตผลิตภัณฑ์สมุนไพร" />
                </div>
            </asp:Panel>
        </div>

    </center>

</asp:Content>

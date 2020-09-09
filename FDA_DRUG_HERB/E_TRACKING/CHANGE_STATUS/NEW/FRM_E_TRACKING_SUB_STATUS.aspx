﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_E_TRACKING_SUB_STATUS.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_E_TRACKING_SUB_STATUS" %>

<%@ Register src="UC/UC_INFORMATION_HEAD.ascx" tagname="UC_INFORMATION_HEAD" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table">
        <tr>
            <td>
                <uc1:UC_INFORMATION_HEAD ID="UC_INFORMATION_HEAD1" runat="server" />
            </td>
           
        </tr>
      
    </table>


    <table width="100%" class="table">
        <tr>
            <td align="right" style="width:20%;">ช่วงสถานะ :</td>
            <td >
                <asp:Label ID="lbl_head_status" runat="server" Text="-"></asp:Label>
            </td>
 
        </tr>
        <tr>
            <td align="right" style="width:20%;">สถานะ :</td>
            <td >
                <asp:DropDownList ID="ddl_cnsdcd" runat="server" DataTextField="STAFF_STATUS" DataValueField="STATUS_ID" CssClass="btn-sm" Width="200px" AutoPostBack="True">
                         </asp:DropDownList>
            </td>
 
        </tr>
        <tr>
            <td align="right" style="width:20%;">
                <asp:Label ID="lbl_date_name" runat="server" Text="วันที่"></asp:Label>&nbsp;
                :</td>
            <td >
                <asp:TextBox ID="txt_stat_date" runat="server"></asp:TextBox>
            </td>
 
        </tr>
        <tr>
            <td align="right" style="width:20%;">ส่ง email :</td>
            <td>
                <asp:TextBox ID="txt_email" runat="server" TextMode="MultiLine" Width="500px" Height="90px"></asp:TextBox> <br />
                            <asp:Button ID="btn_confirm0" runat="server" Text="ส่ง E-mail" CssClass="btn-lg" Width="150px" />
            </td>

        </tr>
        <tr>
            <td colspan="2" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_add_expert" runat="server" Text="เพิ่มผู้เชี่ยมชาญ" CssClass="btn-lg" Width="150px" Style="display: none;" />
                        </td>
                        <td>
                            <asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg" Width="150px" />
                        </td>
                    </tr>
                </table>
                

                

            </td>
        </tr>
    </table>
</asp:Content>
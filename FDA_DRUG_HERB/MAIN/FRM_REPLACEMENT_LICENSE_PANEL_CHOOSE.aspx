<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_REPLACEMENT_LICENSE_PANEL_CHOOSE.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_REPLACEMENT_LICENSE_PANEL_CHOOSE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        /*.button {
  background-color: #4CAF50;
  border: none;
  color: white;
  padding: 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
}*/

        .btn_new {
            border-radius: 12px;
        }

        .btn_other {
            border-radius: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%-- <table width="100%">
        <tr class="row">
            <td align="center">
                <asp:Button ID="btn_new" runat="server" Text="คำขอใหม่" class="btn btn-green" Style="color: DarkBlue; width: 350px; height: 210px; border-radius: 12px; border: solid; border-width: thin; border-color: #63320e;" BackColor="White" />
            </td>

        </tr>
        <tr>
            <td></td>
        </tr>
        <tr class="row">
            <td align="center">
                <asp:Button ID="btn_other" runat="server" Text="คำขออื่นๆ" class="btn btn-green" Style="color: DarkBlue; width: 350px; height: 210px; border-radius: 12px; border: solid; border-width: thin; border-color: #63320e;" BackColor="White" />
            </td>
        </tr>
    </table>--%>
    <hr />
    <div class="col-md-10 col-md-offset-1">
        <table id="ContentPlaceHolder1_Table1" class="auto-style1" align="Center">
            <tr class="row">
                <td align="Center" style="padding-top: 10px;">
                    <asp:Button ID="btn_new" runat="server" Text="คำขอใหม่" class="btn btn-green" Style="color: DarkBlue; width: 350px; height: 210px; border-radius: 12px; border: solid; border-width: 3px; border-color: #63320e;" BackColor="White" />
                </td>
            </tr>
           <tr class="row">
                <td align="Center" style="padding-top: 10px;">
                    <asp:Button ID="btn_other" runat="server" Text="คำขออื่นๆ" class="btn btn-green" Style="color: DarkBlue; width: 350px; height: 210px; border-radius: 12px; border: solid; border-width: 3px; border-color: #63320e;" BackColor="White" />
                </td>
            </tr>

        </table>
    </div>
</asp:Content>

<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_TABLE_DRUG_GROUP_CHANGE_HERB.ascx.vb" Inherits="FDA_DRUG_HERB.UC_TABLE_DRUG_GROUP_CHANGE_HERB" %>
<asp:Panel ID="Panel1" runat="server">
<table class="table" style="width:100%;">
        <tr>
            <td align="center">
                <b>
                รายการผลิตภัณฑ์สมุนไพรที่ขออนุญาต ผลิต นำเข้า หรือขาย</b>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>คำขออนุญาต ประเภท
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdl_drug_type" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                <asp:ListItem Value="3">ผลิต</asp:ListItem>
                                <asp:ListItem Value="2">นำเข้า</asp:ListItem>
                                <asp:ListItem Value="1">ขาย</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>

                
                
                
            </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <b>รายการของผลิตภัณฑ์สมุนไพรที่ขออนุญาต</b>
            </td>
        </tr>
    </table>

<asp:Table ID="Table1" runat="server" Width="100%" CssClass="table" CellSpacing="0" ></asp:Table>
</asp:Panel>
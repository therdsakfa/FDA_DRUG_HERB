<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_DRUG_GROUP.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_DRUG_GROUP" %>
<style>
    #rdl_drug_type label {
        background-color: transparent;
        pointer-events: none;
    }
</style>
<asp:Panel ID="Panel1" runat="server">
    <table class="table" style="width: 100%;">
        <tr>
            <td align="left">
                <%--   <b></b>--%>
                <%--<h3>ข้อมูลรายการผลิตภัณฑ์สมุนไพรที่ไดรับอนุญาต ผลิต นำเข้า หรือขาย</h3>--%>
                <h3>รายการผลิตภัณฑ์สมุนไพรที่ได้รับอนุญาต (รูปแบบผลิตภัณฑ์สมุนไพร)</h3>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>คำขออนุญาต ประเภท
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdl_drug_type" runat="server" Enabled="false"  RepeatColumns="3" RepeatDirection="Horizontal" style="cursor: not-allowed" >
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <b>รายการของผลิตภัณฑ์สมุนไพรที่ขออนุญาต</b>
            </td>
        </tr>
    </table>

    <asp:Table ID="Table1" runat="server" Width="100%" CssClass="table" CellSpacing="0" Enabled="false"></asp:Table>
</asp:Panel>

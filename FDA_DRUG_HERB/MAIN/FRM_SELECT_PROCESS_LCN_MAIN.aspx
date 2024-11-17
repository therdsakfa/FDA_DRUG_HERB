<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_SELECT_PROCESS_LCN_MAIN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_SELECT_PROCESS_LCN_MAIN" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("rcb_Process.ClientID");
            combo.set_text(node.get_text());
            combo.set_value(node.get_value());
            cancelDropDownClosing = false;
            combo.hideDropDown();


            //}
        }

        function StopPropagation(e) {
            //cancel bubbling
            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }
        }
    </script>
    <style>
        .disabledNode {
            color: gray; /* Change text color to gray */
            cursor: not-allowed; /* Change cursor to indicate the node is not clickable */
            pointer-events: none; /* Disable clicking */
            opacity: 0.6; /* Make the node appear slightly transparent */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <p class="h3" style="text-align: center;">เลือกกระบวนงานที่ท่านต้องการดำเนินการ</p>
    <hr />
    <table style="width: 100%; height: 50px; font-size: 18px;">
        <tr>
            <td style="text-align: center; vertical-align: middle;">
                <telerik:RadComboBox ID="rcb_Process" runat="server" Width="50%" Height="400px"
                    EmptyMessage="กรุณาเลือก" AllowCustomText="False" AccessibilityMode="False">
                    <Items>
                        <telerik:RadComboBoxItem Text="" Selected="False" />
                    </Items>
                    <ItemTemplate>
                        <div id="div1" onclick="StopPropagation(event)">
                            <telerik:RadTreeView ID="rtv_Process" runat="server" Font-Size="18px"
                                OnClientNodeClicking="OnClientNodeClickingHandler">
                            </telerik:RadTreeView>
                        </div>
                    </ItemTemplate>
                </telerik:RadComboBox>

            </td>
        </tr>
    </table>
</asp:Content>

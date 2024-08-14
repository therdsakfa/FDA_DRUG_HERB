<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="FRM_HERB_TABEAN_JJ_EDIT_MAIN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_EDIT_MAIN" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_DD_HERB_1").searchable();
        });

        function Popups(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }

        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div class="row" id="T1" runat="server">

        <p class="h3">ข้อมูลการจดแจ้ง</p>
        <hr />
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="25">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>

                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>

                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                        HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="IDA_LCN" DataType="System.Int32" FilterControlAltText="Filter IDA_LCN column"
                        HeaderText="IDA_LCN" ReadOnly="True" SortExpression="IDA_LCN" UniqueName="IDA_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID_LCN" DataType="System.Int32" FilterControlAltText="Filter TR_ID_LCN column"
                        HeaderText="TR_ID_LCN" ReadOnly="True" SortExpression="TR_ID_LCN" UniqueName="TR_ID_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_IDA_LCT" DataType="System.Int32" FilterControlAltText="Filter FK_IDA_LCT column"
                        HeaderText="FK_IDA_LCT" ReadOnly="True" SortExpression="FK_IDA_LCT" UniqueName="FK_IDA_LCT" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DD_HERB_NAME_ID" DataType="System.Int32" FilterControlAltText="Filter DD_HERB_NAME_ID column"
                        HeaderText="DD_HERB_NAME_ID" ReadOnly="True" SortExpression="DD_HERB_NAME_ID" UniqueName="DD_HERB_NAME_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DDHERB" DataType="System.Int32" FilterControlAltText="Filter DDHERB column"
                        HeaderText="DDHERB" ReadOnly="True" SortExpression="DDHERB" UniqueName="DDHERB" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID_JJ" DataType="System.Int32" FilterControlAltText="Filter TR_ID_JJ column"
                        HeaderText="TR_ID_JJ" ReadOnly="True" SortExpression="TR_ID_JJ" UniqueName="TR_ID_JJ" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                    </telerik:GridBoundColumn>
                     <%--    <telerik:GridBoundColumn DataField="CREATE_BY" FilterControlAltText="Filter CREATE_BY column"
                        HeaderText="ชื่อผู้ยื่น" ReadOnly="True" SortExpression="CREATE_BY" UniqueName="CREATE_BY">
                    </telerik:GridBoundColumn>--%>
                    <telerik:GridBoundColumn DataField="LCNNO" FilterControlAltText="Filter LCNNO column"
                        HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO" UniqueName="LCNNO">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RCVNO_FULL" FilterControlAltText="Filter RCVNO_FULL column"
                        HeaderText="เลขใบรับจดแจ้ง" ReadOnly="True" SortExpression="RCVNO_FULL" UniqueName="RCVNO_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                        HeaderText="เลขทะเบียน" ReadOnly="True" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="DATE_APP" DataType="System.DateTime" FilterControlAltText="Filter DATE_APP column"
                        HeaderText="วันที่อนุมัติ" SortExpression="DATE_APP" UniqueName="DATE_APP" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCN_NAME" FilterControlAltText="Filter LCN_NAME column"
                        HeaderText="ชื่อผู้รับ" ReadOnly="True" SortExpression="LCN_NAME" UniqueName="LCN_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NAME_THAI" FilterControlAltText="Filter fulladdr column"
                        HeaderText="ชื่อไทย" SortExpression="NAME_THAI" UniqueName="NAME_THAI">
                    </telerik:GridBoundColumn>

                    <telerik:GridTemplateColumn>
                        <HeaderStyle Width="20px"></HeaderStyle>
                        <ItemTemplate>
                            <asp:Button ID="HL_SELECT" runat="server" Text="เลือกข้อมูล" CommandName="sel" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <%--<telerik:GridButtonColumn ButtonType="LinkButton" Text="ดูรายละเอียด"
                        CommandName="HL_SELECT" UniqueName="HL_SELECT">
                    </telerik:GridButtonColumn>--%>
                </Columns>

                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>

                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>

            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

            <FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>

    </div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_HERB_TABEAN_EX_LCN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_EX_LCN" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
    <div class="row">
        <div class="col-lg-12" style="text-align:center">ผู้ประกอบการ</div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <p class="h3">ใบอนุญาต</p>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <telerik:RadGrid ID="RadGrid1" runat="server">
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
                    <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                        HeaderText="TR_ID" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                        HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                    </telerik:GridBoundColumn> 
                    <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                        HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCNNO_DISPLAY_NEW" FilterControlAltText="Filter LCNNO_DISPLAY_NEW column"
                        HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_DISPLAY_NEW" UniqueName="LCNNO_DISPLAY_NEW">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column" HeaderText="ชื่อสถานที่" ReadOnly="True" SortExpression="thanameplace" UniqueName="thanameplace">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" SortExpression="fulladdr" UniqueName="fulladdr">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="HL_SELECT" runat="server">เลือกข้อมูล</asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
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
    </div>
</asp:Content>

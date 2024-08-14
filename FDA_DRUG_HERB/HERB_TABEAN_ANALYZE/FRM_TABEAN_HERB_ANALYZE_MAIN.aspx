<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_PPK.Master" CodeBehind="FRM_TABEAN_HERB_ANALYZE_MAIN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_HERB_ANALYZE_MAIN" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 70px">
            <p class="h3" style="text-align: left;">แบบแจ้งการนาเข้าผลิตภัณฑ์สมุนไพรเพื่อการวิเคราะห์</p>
        </div>
    </div>

    <div class="panel panel-body" style="width: 100%; padding-left: 1em">
        <div class="row">
            <div class="col-lg-12" style="text-align: center">รายการทะเบียน</div>
        </div>


        <div class="row" runat="server" id="TB1" visible="false">
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
                        <telerik:GridBoundColumn DataField="FK_LCN_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_LCN_IDA column"
                            HeaderText="FK_LCN_IDA" ReadOnly="True" SortExpression="FK_LCN_IDA" UniqueName="FK_LCN_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                            HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                            HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                            HeaderText="เลขที่รับคำขอ" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RGTNO_DISPLAY" FilterControlAltText="Filter RGTNO_DISPLAY column"
                            HeaderText="เลขที่ทะเบียน" SortExpression="RGTNO_DISPLAY" UniqueName="RGTNO_DISPLAY">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column" HeaderText="ชื่อยา" ReadOnly="True" SortExpression="thadrgnm" UniqueName="thadrgnm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column" HeaderText="ชื่อยา อังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
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

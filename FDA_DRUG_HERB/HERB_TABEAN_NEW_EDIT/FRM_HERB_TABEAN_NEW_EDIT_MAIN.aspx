<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_PPK.Master" CodeBehind="FRM_HERB_TABEAN_NEW_EDIT_MAIN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_NEW_EDIT_MAIN" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 160px">
            <div class="row">
                <div class="col-lg-10">
                    <h3>ค้นหาจากเลขทะเบียน</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_rgt_no" runat="server" CssClass="input-lg" Width="100%"></asp:TextBox><br />
                    <p>(ตัวอย่าง G 1/26)</p>
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg" />
                </div>
            </div>
        </div>
    </div>
    <div style="padding-top: 15px"></div>
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel panel-body" style="width: 100%; padding-left: 1%;">
            <div class="row">
                <div class="col-lg-12">
                    <h3>รายการทะเบียนทั้งหมด</h3>
                </div>
            </div>
            <div class="row" runat="server" id="TB1" style="padding-left: 2em; padding-right: 2em">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowFilteringByColumn="True" PageSize="25">
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
                            <telerik:GridBoundColumn DataField="FK_LCN_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_LCN_IDA column"
                                HeaderText="FK_LCN_IDA" ReadOnly="True" SortExpression="FK_LCN_IDA" UniqueName="FK_LCN_IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                                HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                                HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                                HeaderText="เลขที่รับคำขอ" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RGTNO_DISPLAY" FilterControlAltText="Filter RGTNO_DISPLAY column"
                                HeaderText="เลขที่ทะเบียน" SortExpression="RGTNO_DISPLAY" UniqueName="RGTNO_DISPLAY">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column" 
                                HeaderText="ชื่อยา" ReadOnly="True" SortExpression="thadrgnm" UniqueName="thadrgnm">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column" 
                                HeaderText="ชื่อยา อังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                            </telerik:GridBoundColumn>                            
                            <telerik:GridBoundColumn DataField="cncnm" FilterControlAltText="Filter cncnm column"
                                HeaderText="สถานะทะเบียน" SortExpression="cncnm" UniqueName="cncnm">
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
    </div>
</asp:Content>

<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LABELS_AND DUCQUMENT.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LABELS_AND_DUCQUMENT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div id="ID4" runat="server" visible="false">
    <%--  <div class="row">
        <div class="col=lg-1"></div>
        <div class="col=lg-10">
        </div>
        <div class="col=lg-1"></div>
    </div>--%>

    <div class="row">
        <div class="col-lg-5">
            <h4>ฉลากและเอกสารกำกับผลิตภัณฑ์ </h4>
            <hr />
        </div>
    </div>
    <div class="row" style="height: 5px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-8">
            <asp:CheckBox ID="CB1" Text=" &nbsp; 1. แก้ไขฉลากและเอกสารกำกับผลิตภัณฑ์  " runat="server" AutoPostBack="True" />
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div id="Sub_CB1" runat="server" visible="false">

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-5">
                <h4>ข้อมูลเดิม</h4>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
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
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                                    SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                                    HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                                    HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
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
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8" style="color: red">
                <%--<div style="text-align: center">
                    <asp:Table ID="tb_Ducqu ment_Old" runat="server" CssClass="table" Width="100%"></asp:Table>
                </div>--%>
                *กรุณากดบันทึกเพื่อแก้ไขเอกสารแนบ ตามฉลากและเอกสารกำกับผลิตภัณฑ์ในหน้าถัดไป
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>

    <hr />

</div>


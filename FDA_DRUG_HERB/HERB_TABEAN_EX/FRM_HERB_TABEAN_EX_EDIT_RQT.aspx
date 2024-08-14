<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="FRM_HERB_TABEAN_EX_EDIT_RQT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_EX_EDIT_RQT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Src="~/HERB_TABEAN_EX/UC/UC_TABEAN_EDIT_EX1.ascx" TagPrefix="uc1" TagName="UC_TABEAN_EDIT_EX1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="row" style="text-align: center">
                <h3>รายการเอกสารแนบที่ต้องแก้ไข</h3>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <telerik:RadGrid ID="RadGrid2" runat="server">
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
            <div id="EDIT_UPLOAD_SHOW" runat="server">

                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-3" style="text-align: center">หมายเหตุการแก้ไขเอกสารแนบ</div>
                    <div class="col-lg-6" style="text-align: left">
                        <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 115px; width: 600px;"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบประกอบการแก้ไขคำขอ</h3>
                    </div>
                </div>
                <div class="row">
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
                </div>
            </div>
        </div>
        <div class="col-lg-1"></div>
        </div>
        <hr />
        <div class="row" style="text-align: center">
            <h3>แนบเอกสารที่แก้ไข</h3>
        </div>
        <div class="row">
            <div style="overflow-x: scroll; height: 200px; text-align: center">
                <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
                <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร" />
            </div>
        </div>
        <hr />
        

    <div id="EDIT_EX1_SHOW" runat="server" visible="false">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>หมายเหตุการแก้ไขข้อมูลทะเบียน</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12" style="text-align: center;">
                        <asp:TextBox ID="TXT_EDIT_NOTE_TB1" TextMode="MultiLine" runat="server" Style="height: 50%; width: 75%; border-radius: 5px;" ForeColor="#FF3300"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <uc1:UC_TABEAN_EDIT_EX1 runat="server" id="UC_TABEAN_EDIT_EX2" />
        <hr />
    </div>

    <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="text-align: center">
                <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="10%" />
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="10%" />
            </div>
            <div class="col-lg-1"></div>
        </div>

</asp:Content>
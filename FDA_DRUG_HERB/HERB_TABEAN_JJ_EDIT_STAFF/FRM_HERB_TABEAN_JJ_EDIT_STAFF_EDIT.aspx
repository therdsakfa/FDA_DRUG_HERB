<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_JJ_EDIT_STAFF_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_EDIT_STAFF_EDIT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h2>เอกสารแนบแก้ไขคำขอ</h2>
        </div>
    </div>
    <div class="row" id="set_show" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div style="text-align: left">
                <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
                <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร" Height="44px" Width="212px" />
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <%--<div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-8">
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
                        <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                            HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn>
                            <ItemTemplate>
                                <asp:HyperLink ID="PV_ST" runat="server">ดูเอกสาร</asp:HyperLink>
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
        <div class="col-lg-2"></div>
    </div>--%>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-5">
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบคำขอ</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="width: 100%">
                    <telerik:RadGrid ID="RadGrid3" runat="server">
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
        <div class="col-lg-5" >
            <div class="row" style="text-align: center">
                <h3 style ="color:red">รายการเอกสารที่แก้ไข</h3>
            </div>
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-8" style="width: 80%">
                    <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="40"
                        PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="SelectColumn" />
                                <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID"
                                    SortExpression="ID" UniqueName="ID" Display="false" AllowFiltering="true">
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
                        <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
      <%-----------------------------------------------------------TYPE3-----------------------------------------------------------------------------------------%>
                    <telerik:RadGrid ID="RadGrid4" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="40"
                        PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                          <%--      <telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID"
                                    SortExpression="ID" UniqueName="ID" Display="false" AllowFiltering="true">
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
                        <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                </div>
                <div class="col-lg-2"></div>
            </div>
        </div>
    </div>

    <div class="row" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="color:red"><h3>รายละเอียดการแก้ไข</h3></div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" runat="server">
        <div class="col-lg-1"></div>
<%--        <div class="col-lg-3" style="text-align: center;color:red"><h3>รายละเอียดการแก้ไข</h3></div>--%>
        <div class="col-lg-6" style="text-align: left">
            <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 120px; width: 100%;border-radius:5px"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="width: 70%">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-6">
                    <asp:Label ID="Label3" runat="server" Text="ส่งเรื่องแก้ไขโดย:" Font-Size="Large"></asp:Label>
                    <asp:Label ID="lbl_edit_by" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label2" runat="server" Text="ส่งเรื่องแก้ไขเมื่อ:" Font-Size="Large"></asp:Label>
                    <asp:Label ID="lbl_edit_date" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
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


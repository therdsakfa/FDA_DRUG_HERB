<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_HERB_EXHIBITION_STAFF_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_HERB_EXHIBITION_STAFF_EDIT" %>

<%@ Register Src="~/UC/UC_ATTACH_LCN.ascx" TagPrefix="uc1" TagName="UC_ATTACH_LCN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>รายละเอียดการแก้ไข</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-2" style="text-align: left">
            <h3>กรุณาเลือกรายละเอียดแก้ไข</h3>
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-5" style="padding-left: 4em">
            <asp:CheckBox ID="CHK_TB1_EDIT" runat="server" AutoPostBack="True" />
            <asp:Label ID="lbl_tb1_edit" runat="server" Text="แก้ไขข้อมูล"></asp:Label>
        </div>
    </div>
    <div class="row" runat="server" id="DIV_SHOW_TXT_EDIT_TB1" visible="false">
        <div class="row" runat="server">
            <div class="col-lg-2"></div>
            <div class="col-lg-2" style="text-align: left; padding-left: 5em">หมายเหตุการแก้ไขข้อมูล</div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-6" style="text-align: left; padding-left: 6em">
                <asp:TextBox ID="TXT_EDIT_NOTE_TB1" TextMode="MultiLine" runat="server" Style="height: 120px; width: 1140px;"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-5" style="padding-left: 4em">
            <asp:CheckBox ID="CHK_UPLOAD_EDIT" runat="server" AutoPostBack="True" />
            <asp:Label ID="lbl_upload_edit" runat="server" Text="แก้ไขเอกสารแนบ"></asp:Label>
        </div>
    </div>
    <div class="row" runat="server" id="DIV_EDIT_UPLOAD1" visible="false">
        <div class="row" runat="server">
            <div class="col-lg-2"></div>
            <div class="col-lg-2" style="text-align: left; padding-left: 5em">หมายเหตุการแก้ไขเอกสาร</div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-6" style="text-align: left; padding-left: 6em">
                <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 120px; width: 1140px;"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>
    <div class="row">
        <div style="text-align: center">
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-2">
                    <p>เอกสารเเนบประกอบการแก้ไข</p>
                </div>
                <div class="col-lg-2">
                    <div class="col-lg-8">
                        <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN" />
                    </div>
                    <div class="col-lg-4" style="text-align: right">
                        <div runat="server" id="img_not">
                            <img class="auto-style3"
                                src="../Images/cancel.png"
                                alt=""
                                runat="server" />
                        </div>
                        <div runat="server" id="img_cf" visible="False">
                            <img class="auto-style3"
                                src="../Images/correct.png"
                                alt=""
                                runat="server" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:Label ID="lbl_upload_file" runat="server" Text="กรุณาแนบไฟล์"></asp:Label>
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:HyperLink ID="ST_AT" runat="server" Visible="false" Target="_blank"> ดูข้อมูล</asp:HyperLink>
                </div>

            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-10" style="text-align: left; padding-left: 4em">
            <asp:Button ID="btn_add_upload" Width="200px" Height="40px" runat="server" Text="อัพโหลดเอกสาร" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <hr />
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
    </div>
    <div class="row" runat="server" id="DIV_EDIT_UPLOAD2" visible="false">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-4">
                <div class="col-lg-12" style="width: 100%">
                    <div class="row">
                        <div class="col-lg-2"></div>
                        <div class="col-lg-10" style="text-align: left">
                            <h3>เอกสารแนบเดิม</h3>
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
            </div>
            <div class="col-lg-5">
                <div class="col-lg-2"></div>
                <div class="col-lg-10">
                    <div class="row" style="text-align: center">
                        <h3>รายการเอกสารที่ส่งแก้ไข</h3>
                    </div>
                    <div class="row">
                        <div class="col-lg-12" style="width: 100%">
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
                        <div class="col-lg-1"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="width: 70%">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
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

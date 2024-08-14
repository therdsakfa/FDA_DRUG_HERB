<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_HERB_EXHIBITION_EDIT_REQUEST.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_HERB_EXHIBITION_EDIT_REQUEST" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/HERB_TABEAN_EXHIBITION/UC/UC_EXHIBITION_DETAIL.ascx" TagPrefix="uc1" TagName="UC_EXHIBITION_DETAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/css_rg_herb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row" style="background-color: whitesmoke">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="row" runat="server" id="Div1" style="border-block-color: slategray; border-style: initial; background-color: white">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10" style="text-align: center">
                            <h2>รายละเอียดที่ต้องแก้ไข</h2>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>

                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10">
                            <telerik:RadGrid ID="RG_StaffFile" runat="server">
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

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="row" runat="server" id="Check_Edit" visible="false" style="border-block-color: slategray; border-style: initial; background-color: white">
                    <div class="row">
                        <%--<div class="col-lg-1"></div>--%>
                        <div class="col-lg-10" style="text-align: left; padding-left: 5em">
                            <h2 style="color: red">รายละเอียดที่ต้องแก้ไข</h2>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server" id="DIV_SHOW_TXT_EDIT_TB1">
                        <div class="row" runat="server">
                            <div class="col-lg-2" style="text-align: left; padding-left: 5em; color: red">หมายเหตุการแก้ไขข้อมูล</div>
                            <div class="col-lg-1"></div>
                        </div>
                        <div class="row">
                            <%--<div class="col-lg-1"></div>--%>
                            <div class="col-lg-6" style="text-align: left; padding-left: 6em">
                                <asp:TextBox ID="TXT_EDIT_NOTE" TextMode="MultiLine" runat="server" Style="height: 120px; width: 1360px;" ReadOnly="true" ForeColor="Red"></asp:TextBox>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>
                    </div>
                    <div class="row">
                        <%--            <div class="col-lg-1"></div>--%>
                        <div class="col-lg-10">
                            <uc1:UC_EXHIBITION_DETAIL runat="server" ID="UC_EXHIBITION_DETAIL" />
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="row" runat="server" id="Check_Edit_Uplaod" visible="false" style="border-block-color: slategray; border-style: initial; background-color: white">
                    <div id="panel_edit_up" style="border-radius: 10px">
                        <div class="row">           
                            <div class="col-lg-10">
                                <div class="row">
                                    <%--<div class="col-lg-1"></div>--%>
                                    <div class="col-lg-10" style="text-align: left; padding-left: 5em" >
                                        <h2 style="color: red">เอกสารแนบที่ต้องแก้ไข</h2>
                                    </div>
                                    <div class="col-lg-1"></div>
                                </div>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row" runat="server" id="DIV_EDIT_UPLOAD1">
                                    <div class="row" runat="server">
                                        <div class="col-lg-5" style="text-align: left; padding-left: 5em; color: red">หมายเหตุการแก้ไขเอกสาร</div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6" style="text-align: left; padding-left: 6em">
                                            <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 150px; width: 700px;" ReadOnly="true" ForeColor="Red"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="row" runat="server">
                                    <div class="col-lg-5" style="text-align: left; padding-left: 5em; color: red">เอกสารแนบเดิม</div>
                                    <div class="col-lg-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <telerik:RadGrid ID="RG_Edit" runat="server">
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

                    <div class="row">
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10" style="text-align: left">
                                <h2>เอกสารที่ต้องแนบใหม่</h2>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div style="text-align: left; padding-left: 2em; padding-right: 2em">
                                <asp:Table ID="tb_upload_file" runat="server" CssClass="table" Width="100%"></asp:Table>
                            </div>
                            </div>
                           
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div style="text-align: left; padding-left: 2em; padding-right: 2em">
                                    <asp:Button ID="btn_add_no" runat="server" Text="อัพโหลดเอกสารแนบ" Height="35px" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
            </div>
        </div>
    </footer>
</asp:Content>


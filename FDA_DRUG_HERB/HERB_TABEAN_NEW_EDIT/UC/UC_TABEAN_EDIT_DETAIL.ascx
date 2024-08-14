<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_TABEAN_EDIT_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_TABEAN_EDIT_DETAIL" %>

<%@ Register Src="~/TABEAN_YA/UC/UC_officer_che.ascx" TagPrefix="uc1" TagName="UC_officer_che" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="row">
    <div class="col-lg-12" style="padding-left: 2em; padding-right: 2em">
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
            <div class="row">
                <div class="col-lg-3" style="text-align: left">
                    <h4>ชื่อของผลิตภัณฑ์สมุนไพร</h4>
                    <hr />
                </div>
            </div>
            <div class="row" style="height: 5px"></div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <h4>ข้อมูลเดิม</h4>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row" runat="server" id="DIV_NAME_THAI" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาไทย:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="NAME_THAI" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาไทย:</label>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="NAME_THAI_NEW" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row" runat="server" id="DIV_NAME_ENG" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาอังกฤษ:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="NAME_ENG" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาอังกฤษ:</label>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="NAME_ENG_NEW" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row" runat="server" id="DIV_NAME_OTHER" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาต่างประเทศอื่น:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="NAME_OTHER" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ชื่อภาษาต่างประเทศอื่น:</label>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="NAME_OTHER_NEW" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <hr />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>ชื่อหรือที่อยู่ของสถานที่ผลิต/ นำเข้ำ</h4>
                    <hr />
                </div>
            </div>

            <div runat="server" id="Div_check1_2" visible="false">
                <div class="row">
                    <div class="col-lg-6" style="text-align: left;padding-left:2em">
                        <h5>เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนุญาต</h5>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-10" style="padding-left: 3em">
                        ที่อยู่เดิม
                <table class="auto-style1">
                    <tr>
                        <td style="width: 20%;">
                            <asp:Label ID="lbl_thanm_Old" runat="server" Text="Label">ชื่อผู้รับ</asp:Label>
                            :</td>
                        <td>
                            <asp:Label ID="Txt_Thanm_Old" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;">

                            <asp:Label ID="Label2" runat="server">ชื่อสถานที่ </asp:Label>
                            :</td>
                        <td>
                            <asp:Label ID="txt_addrnm_Old" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Label">ที่อยู่ </asp:Label>
                            :</td>
                        <td>
                            <asp:Label ID="txt_addr_Old" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Label">เลขใบอณุญาต </asp:Label>
                            :</td>
                        <td>
                            <asp:Label ID="txt_lcnno_Old" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-3"></div>
                    <div class="col-lg-2">
                        <asp:Button ID="Btn_ResetData" runat="server" Text="ดึงข้อมูลใบอนุญาตใหม่" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-10" style="padding-left: 3em">
                        ที่อยู่ใหม่
                <table class="auto-style1">
                    <tr>
                        <td style="width: 20%;">
                            <asp:Label ID="Label4" runat="server" Text="Label">ชื่อผู้รับ</asp:Label>
                            :</td>
                        <td>
                            <asp:Label ID="Txt_Thanm" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;">

                            <asp:Label ID="Label6" runat="server">ชื่อสถานที่ </asp:Label>
                            :</td>
                        <td>
                            <asp:Label ID="Txt_AddrNm" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Label">ที่อยู่ </asp:Label>
                            :</td>
                        <td>
                            <asp:Label ID="Txt_Addr" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Label">เลขใบอณุญาต </asp:Label>
                            :</td>
                        <td>
                            <asp:Label ID="Txt_LCNNO" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                    </div>
                </div>
                <hr />

            </div>
           <%-----------------------------  เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนญาตผลิตต่างประเทศ  -------------------------------------------------------------------------%>
             <div class="row">
                    <div class="col-lg-6" style="text-align: left;padding-left:2em">
                        <h5>เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนญาตผลิตต่างประเทศ</h5>
                        <hr />
                    </div>
                </div>
            <div runat="server" id="div_check_3" visible="false">
                ข้อมูลเดิม
         <div class="row">
             <div class="col-lg-1"></div>
             <div class="col-lg-2">
                 <label>ที่อยู่ ผู้ผลิตต่างประเทศ:</label>
             </div>
             <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                 <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None"></asp:TextBox>
                 <%--<asp:TextBox ID="txt_address_ida" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None" Visible="false"></asp:TextBox>--%>
             </div>
             <div class="col-lg-1"></div>
         </div>

                 ข้อมูลที่ต้องแก้ไข
         <div class="row">
             <div class="col-lg-1"></div>
             <div class="col-lg-2">
                 <label>ผู้ผลิตต่างประเทศ:</label>
             </div>
             <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                 <asp:TextBox ID="txt_search" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
                 <asp:TextBox ID="txt_search_ida" runat="server" Width="100%" BorderStyle="None" Visible="false"></asp:TextBox>
                 <asp:HiddenField ID="HiddenField1" runat="server" />
             </div>
             <div class="col-lg-2">
                 <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
             </div>
             <div class="col-lg-1"></div>
         </div>
                <div class="row">
                    <div class="col-lg-3"></div>
                    <div class="col-lg-6" style="width: 60%">
                        <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
                            PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <%--<telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                        SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="frgncd" DataType="System.Int32" FilterControlAltText="Filter frgncd column" HeaderText="frgncd"
                                        SortExpression="frgncd" UniqueName="frgncd" Display="false" AllowFiltering="true">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="engfrgnnm" FilterControlAltText="Filter engfrgnnm column"
                                        HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาอังกฤษ)" SortExpression="engfrgnnm" UniqueName="engfrgnnm">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="thafrgnnm" FilterControlAltText="Filter thafrgnnm column"
                                        HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาไทย)" SortExpression="thafrgnnm" UniqueName="thafrgnnm">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                        CommandName="sel" Text="เลือก">
                                        <HeaderStyle Width="70px" />
                                    </telerik:GridButtonColumn>
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
                    <div class="col-lg-3"></div>
                </div>
                <div class="row">
                    <div class="col-lg-3"></div>
                    <div class="col-lg-6" style="width: 60%">
                        <telerik:RadGrid ID="RadGrid4" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
                            PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <%--<telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                        SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="fulladdr2" FilterControlAltText="Filter fulladdr2 column"
                                        HeaderText="ที่อยู่" SortExpression="fulladdr2" UniqueName="fulladdr2">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                        CommandName="sel" Text="เลือก">
                                        <HeaderStyle Width="70px" />
                                    </telerik:GridButtonColumn>
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
                    <div class="col-lg-3"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ที่อยู่ ผู้ผลิตต่างประเทศ:</label>
                    </div>
                    <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="txt_address_New" runat="server" TextMode="MultiLine" Height="60px" Width="100%" ></asp:TextBox>
                        <asp:TextBox ID="txt_address_ida" runat="server" TextMode="MultiLine" Height="60px" Width="100%"  Visible="false"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

            <%--    <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">
                        <label>กรณีไม่มีผู้ผลิตต่างประเทศกรุณากรอก:</label>
                    </div>
                    <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="Txt_Addr_to_Staff" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>--%>
            </div>

        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>ตำรับผลิตภัณฑ์สมุนไพร</h4>
                    <hr />
                </div>
            </div>
            <uc1:UC_officer_che runat="server" ID="UC_officer_che" />
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>กรรมวิธีการผลิต</h4>
                    <hr />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <telerik:RadGrid ID="RadGrid7" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
                        PagerStyle-Mode="NextPrevNumericAndAdvanced" Skin="Hay">
                        <MasterTableView DataKeyNames="IDA">
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA" HeaderText="IDA" DataType="System.Int32" Display="false"
                                    FilterControlAltText="Filter IDA column" ReadOnly="True" SortExpression="IDA">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_IDA_DQ" UniqueName="FK_IDA_DQ" HeaderText="FK_IDA_DQ" FilterControlAltText="Filter FK_IDA_DQ column"
                                    SortExpression="FK_IDA_DQ" Display="false">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="PACK_F_NAME " UniqueName="PACK_F_NAME" HeaderText="Primary Packaging:" FilterControlAltText="Filter PACK_F_NAME column"
                                    SortExpression="PACK_F_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NO_1" UniqueName="NO_1" HeaderText="ขนาด" FilterControlAltText="Filter NO_1 column"
                                    SortExpression="NO_1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UNIT_F_NAME " UniqueName="UNIT_F_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_F_NAME column"
                                    SortExpression="UNIT_F_NAME">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="PACK_S_NAME " UniqueName="PACK_S_NAME" HeaderText="Seceondary Packaging:" FilterControlAltText="Filter PACK_S_NAME column"
                                    SortExpression="PACK_S_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NO_2" UniqueName="NO_2" HeaderText="ขนาด" FilterControlAltText="Filter NO_2 column"
                                    SortExpression="NO_2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UNIT_S_NAME " UniqueName="UNIT_S_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_S_NAME column"
                                    SortExpression="UNIT_S_NAME">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="PACK_T_NAME " UniqueName="PACK_T_NAME" HeaderText="Tertiary Packaging:" FilterControlAltText="Filter PACK_T_NAME column"
                                    SortExpression="PACK_T_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NO_3" UniqueName="NO_3" HeaderText="ขนาด" FilterControlAltText="Filter NO_3 column"
                                    SortExpression="NO_3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UNIT_T_NAME " UniqueName="UNIT_T_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_T_NAME column"
                                    SortExpression="UNIT_T_NAME">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>กรรมวิธีการผลิต:</label>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">ลำดับกระบวนการ</div>
                <div class="col-lg-3">
                    <asp:TextBox ID="NO_ID" runat="server" Width="100%" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-lg-2">ประเภทกระบวนการ:</div>
                <div class="col-lg-3">
                    <asp:DropDownList ID="DD_MANUFAC_ID" runat="server" DataValueField="MANUFAC_ID" DataTextField="MANUFAC_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button ID="btn_add_muc_add" runat="server" Text="เพิ่ม" />
                </div>
            </div>
            <%--   <div class="row">
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
                </div>
                *กรุณากดบันทึกเพื่อแก้ไขเอกสารแนบ ตามฉลากและเอกสารกำกับผลิตภัณฑ์ในหน้าถัดไป
                </div>
                <div class="col-lg-1"></div>
            </div>--%>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" Style="display: none;">
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>สรรพคุณ/ข้อบ่งใช้/ข้อความกล่าวอ้างทางสุขภาพ</h4>
                    <hr />
                </div>
            </div>
            <div class="row" style="height: 5px"></div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <h4>ข้อมูลเดิม</h4>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>สรรพคุณ:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_PROPERTIES" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>สรรพคุณ:</label>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="txt_PROPERTIES_NEW" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />
        </asp:Panel>
        <asp:Panel ID="Panel6" runat="server" Style="display: none;">
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>ขนาดและวิธีการใช้</h4>
                    <hr />
                </div>
            </div>
            <div class="row" style="height: 5px"></div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <h4>ข้อมูลเดิม</h4>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ขนาดและวิธีการใช้:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_SizePack" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ขนาดและวิธีการใช้:</label>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="txt_SizePack_New" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />
        </asp:Panel>
        <asp:Panel ID="Panel7" runat="server" Style="display: none;">
            <div class="row">
                <div class="col-lg-3" style="text-align: left">
                    <h4>วิธีเตรียมก่อนรับประทาน</h4>
                    <hr />
                </div>
            </div>
            <div class="row" style="height: 5px"></div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <h4>ข้อมูลเดิม</h4>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>วิธีเตรียมก่อนรับประทาน:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_EATTING" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>วิธีเตรียมก่อนรับประทาน:</label>
                </div>
                <div class="col-lg-3">
                    <asp:DropDownList ID="DD_EATTING_ID" runat="server" DataValueField="EATTING_ID" DataTextField="EATTING_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />
        </asp:Panel>
        <asp:Panel ID="Panel8" runat="server" Style="display: none;">
            <div class="row">
                <div class="col-lg-3" style="text-align: left">
                    <h4>เงื่อนไขการรับประทาน</h4>
                    <hr />
                </div>
            </div>
            <div class="row" style="height: 5px"></div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <h4>ข้อมูลเดิม</h4>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>เงื่อนไขการรับประทาน:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_EATING_CONDITION" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>เงื่อนไขการรับประทาน:</label>
                </div>
                <div class="col-lg-3">
                    <asp:DropDownList ID="DD_EATING_CONDITION_ID" runat="server" DataValueField="PRO_CON_ID" DataTextField="PRO_CON_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="true">
                    </asp:DropDownList>

                </div>
                <div class="col-lg-2" id="R_EATING_CONDITION_TEXT" runat="server" visible="false">
                    <asp:TextBox ID="EATING_CONDITION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />
        </asp:Panel>
        <asp:Panel ID="Panel9" runat="server" Style="display: none;">
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>การเก็บรักษา/อายุการเก็บรักษา</h4>
                    <hr />
                </div>
            </div>
            <div class="row" style="height: 5px"></div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <h4>ข้อมูลเดิม</h4>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>การเก็บรักษา:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_STORAGE" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>การเก็บรักษา:</label>
                </div>
                <div class="col-lg-3">
                    <asp:DropDownList ID="DD_STORAGE_ID" runat="server" DataValueField="PRO_MT_ID" DataTextField="PRO_MT_NAME" Style="width: 100%">
                    </asp:DropDownList>

                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>อายุการเก็บรักษา:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_TREATMENT_AGE" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>อายุการเก็บรักษา:</label>
                </div>
                <div class="col-lg-1">
                    <asp:DropDownList ID="TREATMENT_AGE_YEAR" runat="server" Width="50%" AutoPostBack="true">
                        <asp:ListItem Value="0">-</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                    <label>&nbsp;&nbsp;&nbsp;ปี</label><label style="color: red">*</label>
                </div>

                <div class="col-lg-1" id="div_hide" runat="server">
                    <asp:DropDownList ID="TREATMENT_AGE_MONTH_SUB" runat="server" Width="80%">
                        <asp:ListItem Value="0">-</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1" id="div_hide2" runat="server">
                    <label>เดือน</label>
                </div>
            </div>
            <hr />
        </asp:Panel>
        <asp:Panel ID="Panel10" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>ภาชนะและขนาดบรรจุ</h4>
                    <hr />
                    <div class="row" style="height: 1px"></div>
                    <div visible="false" id="ID3" runat="server">
                        <div class="row">
                            <div class="col-lg-3" style="text-align: center">
                                <h4>ขนาดบรรจุ</h4>
                                <hr />
                            </div>
                        </div>
                        <div class="row" style="height: 5px"></div>
                        <%-- <div visible="false" id="CB1" runat="server">
                          <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">
                                    <h4>ข้อมูลเดิม</h4>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>

                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2">
                                    <label>รายละเอียดขนาด:</label>
                                </div>
                                <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                    <asp:TextBox ID="SIZE_PACK_OLD" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>--%>

                        <%--                            <div class="row">
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

                                                <telerik:GridBoundColumn DataField="PACK_FSIZE_NAME" FilterControlAltText="Filter PACK_FSIZE_NAME column"
                                                    HeaderText="primary packaging" SortExpression="PACK_FSIZE_NAME" UniqueName="PACK_FSIZE_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PACK_FSIZE_VOLUME" FilterControlAltText="Filter PACK_FSIZE_VOLUME column"
                                                    HeaderText="ขนาด" SortExpression="PACK_FSIZE_VOLUME" UniqueName="PACK_FSIZE_VOLUME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PACK_FSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_FSIZE_UNIT_NAME column"
                                                    HeaderText="หน่วย" SortExpression="PACK_FSIZE_UNIT_NAME" UniqueName="PACK_FSIZE_UNIT_NAME">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="PACK_SECSIZE_NAME" FilterControlAltText="Filter PACK_SECSIZE_NAME column"
                                                    HeaderText="secondary packaging" SortExpression="PACK_SECSIZE_NAME" UniqueName="PACK_SECSIZE_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PACK_SECSIZE_VOLUME" FilterControlAltText="Filter PACK_SECSIZE_VOLUME column"
                                                    HeaderText="ขนาด" SortExpression="PACK_SECSIZE_VOLUME" UniqueName="PACK_SECSIZE_VOLUME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PACK_SECSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_SECSIZE_UNIT_NAME column"
                                                    HeaderText="หน่วย" SortExpression="PACK_SECSIZE_UNIT_NAME" UniqueName="PACK_SECSIZE_UNIT_NAME">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="PACK_THSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_THSIZE_UNIT_NAME column"
                                                    HeaderText="tertiary packaging" SortExpression="PACK_THSIZE_UNIT_NAME" UniqueName="PACK_THSIZE_UNIT_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PACK_THSSIZE_VOLUME" FilterControlAltText="Filter PACK_THSSIZE_VOLUME column"
                                                    HeaderText="ขนาด" SortExpression="PACK_THSSIZE_VOLUME" UniqueName="PACK_THSSIZE_VOLUME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PACK_THSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_THSIZE_UNIT_NAME column"
                                                    HeaderText="หน่วย" SortExpression="PACK_THSIZE_UNIT_NAME" UniqueName="PACK_THSIZE_UNIT_NAME">
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
                            </div>--%>
                        <%--   <div class="row" style="height: 5px"></div>
                            <hr />
                            <div class="row">
                                <div class="col-lg-1"></div>
                                <div class="col-lg-4">
                                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                                </div>
                                <div class="col-lg-1"></div>
                            </div>--%>

                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                <label>รายละเอียดขนาด:</label>
                            </div>
                            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                <asp:TextBox ID="SIZE_PACK_NEW" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>

                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div class="row">
                                    <div class="col-lg-2">Primary Packaging:</div>
                                    <div class="col-lg-2">
                                        <asp:DropDownList ID="DD_PCAK_1" runat="server" DataValueField="PACK_PRIMARY_ID" DataTextField="PACK_PRIMARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2" style="text-align: right">จำนวน:</div>
                                    <div class="col-lg-2" style="text-align: right">
                                        <asp:TextBox ID="NO_1" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2" style="text-align: right">หน่วย:</div>
                                    <div class="col-lg-2">
                                        <asp:DropDownList ID="DD_UNIT_1" runat="server" DataValueField="UNIT_PRIMARY_ID" DataTextField="UNIT_PRIMARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">Seceondary Packaging:</div>
                                    <div class="col-lg-2">
                                        <asp:DropDownList ID="DD_PCAK_2" runat="server" DataValueField="PACK_SEC_ID" DataTextField="PACK_SEC_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2" style="text-align: right">จำนวน:</div>
                                    <div class="col-lg-2">
                                        <asp:TextBox ID="NO_2" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2" style="text-align: right">หน่วย:</div>
                                    <div class="col-lg-2">
                                        <asp:DropDownList ID="DD_UNIT_2" runat="server" DataValueField="UNIT_SECONDARY_ID" DataTextField="UNIT_SECONDARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">Tertiary Packaging:</div>
                                    <div class="col-lg-2">
                                        <asp:DropDownList ID="DD_PCAK_3" runat="server" DataValueField="PACK_TER_ID" DataTextField="PACK_TER_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2" style="text-align: right">จำนวน:</div>
                                    <div class="col-lg-2">
                                        <asp:TextBox ID="NO_3" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2" style="text-align: right">หน่วย:</div>
                                    <div class="col-lg-2">
                                        <asp:DropDownList ID="DD_UNIT_3" runat="server" DataValueField="UNIT_TERTIARY_ID" DataTextField="UNIT_TERTIARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12" style="text-align: center">
                                        <asp:Button ID="btn_size_pack" runat="server" Text="เพิ่ม" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
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

                                                    <telerik:GridBoundColumn DataField="PACK_FSIZE_NAME" FilterControlAltText="Filter PACK_FSIZE_NAME column"
                                                        HeaderText="primary packaging" SortExpression="PACK_FSIZE_NAME" UniqueName="PACK_FSIZE_NAME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PACK_FSIZE_VOLUME" FilterControlAltText="Filter PACK_FSIZE_VOLUME column"
                                                        HeaderText="ขนาด" SortExpression="PACK_FSIZE_VOLUME" UniqueName="PACK_FSIZE_VOLUME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PACK_FSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_FSIZE_UNIT_NAME column"
                                                        HeaderText="หน่วย" SortExpression="PACK_FSIZE_UNIT_NAME" UniqueName="PACK_FSIZE_UNIT_NAME">
                                                    </telerik:GridBoundColumn>

                                                    <telerik:GridBoundColumn DataField="PACK_SECSIZE_NAME" FilterControlAltText="Filter PACK_SECSIZE_NAME column"
                                                        HeaderText="secondary packaging" SortExpression="PACK_SECSIZE_NAME" UniqueName="PACK_SECSIZE_NAME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PACK_SECSIZE_VOLUME" FilterControlAltText="Filter PACK_SECSIZE_VOLUME column"
                                                        HeaderText="ขนาด" SortExpression="PACK_SECSIZE_VOLUME" UniqueName="PACK_SECSIZE_VOLUME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PACK_SECSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_SECSIZE_UNIT_NAME column"
                                                        HeaderText="หน่วย" SortExpression="PACK_SECSIZE_UNIT_NAME" UniqueName="PACK_SECSIZE_UNIT_NAME">
                                                    </telerik:GridBoundColumn>

                                                    <telerik:GridBoundColumn DataField="PACK_THSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_THSIZE_UNIT_NAME column"
                                                        HeaderText="tertiary packaging" SortExpression="PACK_THSIZE_UNIT_NAME" UniqueName="PACK_THSIZE_UNIT_NAME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PACK_THSSIZE_VOLUME" FilterControlAltText="Filter PACK_THSSIZE_VOLUME column"
                                                        HeaderText="ขนาด" SortExpression="PACK_THSSIZE_VOLUME" UniqueName="PACK_THSSIZE_VOLUME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PACK_THSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_THSIZE_UNIT_NAME column"
                                                        HeaderText="หน่วย" SortExpression="PACK_THSIZE_UNIT_NAME" UniqueName="PACK_THSIZE_UNIT_NAME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                                                        CommandName="result_delete" UniqueName="result_delete">
                                                    </telerik:GridButtonColumn>
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
                        </div>
                        <div class="col-lg-1"></div>

                    </div>

                    <hr />

                </div>



            </div>
            <%--     </div>--%>
        </asp:Panel>
        <asp:Panel ID="Panel11" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>วิธีควบคุมคุณภาพและข้อกำหนดเฉพาะของผลิตภัณฑ์สมุนไพร</h4>
                    <hr />
                      <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8" style="color: red">
                    <%--<div style="text-align: center">
                    <asp:Table ID="tb_Ducqu ment_Old" runat="server" CssClass="table" Width="100%"></asp:Table>
                </div>--%>
                *กรุณากดบันทึกเพื่อแก้ไขเอกสารแนบ วิธีควบคุมคุณภาพและข้อกำหนดเฉพาะของผลิตภัณฑ์สมุนไพร
                </div>
                <div class="col-lg-1"></div>
            </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel12" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>หนังสือรับรองการอนุญาตให้ขายหรือการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร เฉพาะกรณีที่เป็นการนำเข้ำ</h4>
                    <hr />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel13" runat="server" Style="display: none;">
            <hr />
            <div class="row">
                <div class="col-lg-6" style="text-align: left">
                    <h4>ฉลาก และเอกสารกำกับผลิตภัณฑ์สมุนไพร</h4>
                    <hr />
                </div>
            </div>

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
        </asp:Panel>
        <asp:Panel ID="Panel14" runat="server" Style="display: none;">
            <hr />
        </asp:Panel>
        <asp:Panel ID="Panel15" runat="server" Style="display: none;">
            <div class="row">
                <div class="col-lg-3" style="text-align: left">
                    <h4>ช่องทางการขาย</h4>
                    <hr />
                </div>
            </div>
            <div class="row" style="height: 5px"></div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">
                    <h4>ข้อมูลเดิม</h4>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ช่องทางการขาย:</label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                    <asp:TextBox ID="txt_SALE_CHANNEL" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <label>ช่องทางการขาย:</label>
                </div>
                <div class="col-lg-3">
                    <asp:DropDownList ID="DD_SALE_CHANNEL" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap">
                        <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                        <asp:ListItem Value="1">ผลิตภัณฑ์สมุนไพรขายทั่วไป</asp:ListItem>
                        <asp:ListItem Value="2">ผลิตภัณฑ์ขายในสถานที่มีใบอนุญาต</asp:ListItem>
                        <asp:ListItem Value="3">ผลิตภัณฑ์ใช้เฉพาะสถานพยาบาล</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />
        </asp:Panel>
    </div>
</div>

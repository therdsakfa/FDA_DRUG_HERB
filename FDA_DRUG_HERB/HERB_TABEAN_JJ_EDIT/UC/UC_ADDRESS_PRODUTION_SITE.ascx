<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_ADDRESS_PRODUTION_SITE.ascx.vb" Inherits="FDA_DRUG_HERB.UC_ADDRESS_PRODUTION_SITE" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div visible="false" id="ID2" runat="server">
    <div class="row">
        <div class="col-lg-3" style="text-align: center">
            <h4>ชื่อหรือที่อยู่ของสถานที่ผลิต </h4>
            <hr />
        </div>
    </div>

    <div class="row" style="height: 5px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-9">
            <asp:CheckBox ID="cb_sub_menu_1" Text=" &nbsp; เปลี่ยนแปลงชื่อ หรือที่อยู่ของผู้รับอนุญาตผลิต/นำเข้า (ผู้รับอนุญาตผลิต/นำเข้าเดิม แต่สถานที่มีการย้ายจากที่หนึ่งไปยังอีกที่หนึ่ง) " runat="server" AutoPostBack="True" />
            <br />
            <asp:CheckBox ID="cb_sub_menu_2" Text=" &nbsp; เปลี่ยนแปลงชื่อ หรือที่อยู่ของผู้รับอนุญาตผลิต/นำเข้า (ผู้รับอนุญาตผลิต/นำเข้ารายใหม่ )" runat="server" AutoPostBack="True" />
            <br />
            <asp:CheckBox ID="cb_sub_menu_3" Text="  &nbsp; เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้ผลิตต่างประเทศ" runat="server" AutoPostBack="True" />
            <br />
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div id="LCN_Div" runat="server" visible="false">
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
                        <td colspan="3">
                            <asp:Label ID="txt_addr_Old" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Label">เลขใบอณุญาต </asp:Label>
                            :</td>
                        <td colspan="3">
                            <asp:Label ID="txt_lcnno_Old" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="CB1" runat="server" visible="false">
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
                        <td colspan="3">
                            <asp:Label ID="Txt_Addr" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Label">เลขใบอณุญาต </asp:Label>
                            :</td>
                        <td colspan="3">
                            <asp:Label ID="Txt_LCNNO" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <hr />
    </div>

    <div id="CB2" runat="server" visible="false">
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-3">
                <asp:TextBox ID="Txt_search_Lcnno" runat="server"></asp:TextBox>
                <asp:Button ID="Btn_Search_Lcn" runat="server" Text="ค้นหา" />
            </div>
        </div>


        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-10" style="padding-left: 3em">
                ที่อยู่ใหม่
            <table class="auto-style1">
                <tr>
                    <td style="width: 20%;">
                        <asp:Label ID="Label12" runat="server" Text="Label">ชื่อผู้รับ</asp:Label>
                        :</td>
                    <td>
                        <asp:Label ID="Txt_Thanm_New" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%;">

                        <asp:Label ID="Label14" runat="server">ชื่อสถานที่ </asp:Label>
                        :</td>
                    <td>
                        <asp:Label ID="Txt_AddrNm_New" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Label">ที่อยู่ </asp:Label>
                        :</td>
                    <td colspan="3">
                        <asp:Label ID="Txt_Addr_New" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18" runat="server" Text="Label">เลขใบอณุญาต </asp:Label>
                        :</td>
                    <td colspan="3">
                        <asp:Label ID="Txt_LCNNO_New" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </div>
        </div>
        <hr />
    </div>

    <div id="CB3" runat="server" visible="false">
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

        เปลี่ยนที่อยู่
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
                <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
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
                <telerik:RadGrid ID="RadGrid3" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
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
                <asp:TextBox ID="txt_address_New" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None"></asp:TextBox>
                <asp:TextBox ID="txt_address_ida" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None" Visible="false"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
        
           <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4">
                <label>กรณีไม่มีผู้ผลิตต่างประเทศกรุณากรอก:</label>
            </div>
            <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="Txt_Addr_to_Staff" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>
</div>

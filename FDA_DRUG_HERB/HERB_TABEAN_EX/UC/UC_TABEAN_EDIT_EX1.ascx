<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_TABEAN_EDIT_EX1.ascx.vb" Inherits="FDA_DRUG_HERB.UC_TABEAN_EDIT_EX1" %>


<%@ Register Src="../../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="row">
    <div class="col-lg-12" style="text-align: center">แบบแจ้งผลิตหรือนำเข้าผลิตภัณฑ์สมุนไพรเพื่อเป็นตัวอย่าง สาหรับการขึ้นทะเบียน การแจ้งรายละเอียด หรือการจดแจ้ง</div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-2">
        <asp:Label ID="Label1" runat="server" Text="ข้าพเจ้า"></asp:Label>
    </div>
    <div class="col-lg-3">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label2" runat="server" Text="ซึ่งมีผู้ดำเนินกิจการชื่อ"></asp:Label>
    </div>
    <div class="col-lg-3">
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-2">
        <asp:Label ID="Label3" runat="server" Text="ชื่อผู้ได้รับอนุญาต"></asp:Label>
    </div>
    <div class="col-lg-6">
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-2">
        <asp:Label ID="Label4" runat="server" Text="ได้รับอนุญาตให้"></asp:Label>
    </div>
    <div class="col-lg-3">
        <asp:DropDownList ID="DD_CATEGORY_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
            <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
            <asp:ListItem Value="122">ผลิต ผลิตภัณฑ์สมุนไพร</asp:ListItem>
            <asp:ListItem Value="121">นำเข้า ผลิตภัณฑ์สมุนไพร</asp:ListItem>
            <%--<asp:ListItem Value="120">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>--%>
        </asp:DropDownList>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label5" runat="server" Text="ตามใบอนุญาตที่"></asp:Label>
    </div>
    <div class="col-lg-3">
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-2">
        <asp:Label ID="Label6" runat="server" Text="ณ สถานที่"></asp:Label>
    </div>
    <div class="col-lg-3">
        <asp:DropDownList ID="DD_CATEGORY_ID_SUB" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
            <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
            <asp:ListItem Value="122">ผลิต </asp:ListItem>
            <asp:ListItem Value="121">นำเข้า ผลิตภัณฑ์สมุนไพร</asp:ListItem>
            <%--<asp:ListItem Value="120">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>--%>
        </asp:DropDownList>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label7" runat="server" Text="ชื่อบริษัท/ห้างหุ้นส่วนจำกัด"></asp:Label>
    </div>
    <div class="col-lg-3">
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>
<hr />
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        <asp:Label ID="Label8" runat="server" Text="อยู่เลขที่"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label9" runat="server" Text="หมู่ที่"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label10" runat="server" Text="ตรอก/ซอย"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        <asp:Label ID="Label11" runat="server" Text="ถนน"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label12" runat="server" Text="ตำบล/แขวง"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label13" runat="server" Text="อำเภอ/เขต"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        <asp:Label ID="Label14" runat="server" Text="จังหวัด"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-2">
        <asp:Label ID="Label15" runat="server" Text="โทรศัพท์"></asp:Label>
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
    </div>
</div>
<hr />
<div class="row">
    <div class="col-lg-12" style="text-align: center">รายการละเอียดของผลิตภัณฑ์สมุนไพร</div>
</div>
<div class="row">
    <div class="col-lg-3">
        <asp:Label ID="Label16" runat="server" Text="ชื่อผลิตภัณฑ์"></asp:Label>
    </div>
    <div class="col-lg-9">
        <asp:TextBox ID="EX_NAME_PRODUCT" Width="80%" runat="server"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-3">
        <asp:Label ID="Label17" runat="server" Text="รูปแบบผลิตภัณฑ์"></asp:Label>
    </div>
    <div class="col-lg-9">
        <asp:DropDownList ID="DD_TYPE_PRODUCK" runat="server" BackColor="White" DataTextField="TYPE_PRODUCK_NAME" DataValueField="TYPE_PRODUCK_ID" Height="25px" SkinID="bootstrap" Width="200px">
        </asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-lg-3">
        <asp:Label ID="Label19" runat="server" Text="ลักษณะและสี"></asp:Label>
    </div>
    <div class="col-lg-9">
        <asp:TextBox ID="style_color" TextMode="MultiLine" Width="80%" Height="150px" runat="server"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-12"></div>
</div>

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
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <telerik:RadGrid ID="RadGrid4" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
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
                    <telerik:GridBoundColumn DataField="PACKAGE_FULL" UniqueName="PACKAGE_FULL" HeaderText="" FilterControlAltText="Filter PACKAGE_FULL column"
                        SortExpression="PACKAGE_FULL">
                    </telerik:GridBoundColumn>

                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                        CommandName="result_delete" UniqueName="result_delete">
                    </telerik:GridButtonColumn>
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
<div class="row">
    <div class="col-lg-3" style="text-align: left">จำนวนหรือปริมาณที่จะผลิต/นำเข้า</div>
    <div class="col-lg-9" style="border-bottom: #999999 1px dotted">
    </div>
</div>
<div class="row">
    <div class="col-lg-3" style="text-align: left"></div>
    <div class="col-lg-9" style="border-bottom: #999999 1px dotted">
        <asp:TextBox ID="txt_quantity_produced" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-12"></div>
</div>
<div class="row">
    <div class="col-lg-3" style="text-align: left">ขนาดบรรจุ (รายละเอียดภาชนะบรรจุ)</div>
    <div class="col-lg-9">
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
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

                    <telerik:GridBoundColumn DataField="PACKAGE_FULL" UniqueName="PACKAGE_FULL" HeaderText="ขนาดบรรจุ (รายละเอียดภาชนะบรรจุ)" FilterControlAltText="Filter PACKAGE_FULL column"
                        SortExpression="PACKAGE_FULL">
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                            CommandName="result_delete" UniqueName="result_delete">
                        </telerik:GridButtonColumn>--%>
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
<div class="row">
    <div class="col-lg-12" style="text-align: center">
        <%--<asp:Button ID="btn_save" runat="server" Text="บันทึกส่วนที่ 1" />--%>
        <%-- <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" />--%>
    </div>
</div>

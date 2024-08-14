<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_EDIT_REQUEST.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_HERB_EDIT_REQUEST" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">คำขอทะเบียนตำรับผลิตภัณฑ์สมุนไพร</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ผู้ขอทะเบียน:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_TB" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>ชื่อสถานที่:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_PLACE_TB" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชนิด:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_TYPE_NAME" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ยาจากสมุนไพร</asp:ListItem>
                <asp:ListItem Value="2">ยาจากสมุนไพรเพื่อสุขภาพ</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <label>ชนิดจากสมุนไพร:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_TYPE_SUB_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ยาแผนไทย</asp:ListItem>
                <asp:ListItem Value="2">ยาตามองค์ความรู้การแพทย์แผนทางเลือก</asp:ListItem>
                <asp:ListItem Value="3">ยาพัฒนาจากสมุนไพร</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ประเภท:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_CATEGORY_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="122">ผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="121">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <%--<asp:ListItem Value="120">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <label>ประเภทส่งออก:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_CATEGORY_OUT_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1200">เพื่อส่งออกเท่านั้น</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" id="foreign" runat="server" visible="false">
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <label>ผู้ผลิตต่างประเทศ:</label>
            </div>
            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="txt_search" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                <asp:TextBox ID="txt_search_ida" runat="server" Width="100%" Visible="false"></asp:TextBox>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <label>ที่อยู่ ผู้ผลิตต่างประเทศ:</label>
            </div>
            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                <asp:TextBox ID="txt_address_ida" runat="server" TextMode="MultiLine" Height="60px" Width="100%" Visible="false"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">รายละเอียดของตำรับผลิตภัณฑ์สมุนไพร</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชื่อภาษาไทย:</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_THAI" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>ชื่อภาษาอังกฤษ(ถ้ามี):</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_ENG" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชื่อภาษาต่างประเทศอื่น(ถ้ามี):</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_OTHER" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>รูปแบบ:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_STYPE_ID" runat="server" DataValueField="STYPE_ID" DataTextField="STYPE_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <label>ชื่อสมุนไพร (พืช/สัตว์/จุลชีพ/แร่)  /  กรณีเป็นสารสกัด  /  ชื่อสารช่วย:</label>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <%--<div class="row">
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
    </div>--%>
    <%--<div class="row">
        <div class="col-lg-12" style="text-align:center">
            <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
        </div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ขนาดบรรจุ:</label>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>รายละเอียดขนาด:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="SIZE_PACK" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ขนาดบรรจุ:</label>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <%--<div class="row">
        <div class="col-lg-2">Primary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_1" runat="server" DataValueField="PACK_PRIMARY_ID" DataTextField="PACK_PRIMARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2">จำนวน:</div>
        <div class="col-lg-2">
            <asp:TextBox ID="NO_1" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2">หน่วย:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_UNIT_1" runat="server" DataValueField="UNIT_PRIMARY_ID" DataTextField="UNIT_PRIMARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2">Seceondary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_2" runat="server" DataValueField="PACK_SEC_ID" DataTextField="PACK_SEC_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2">จำนวน:</div>
        <div class="col-lg-2">
            <asp:TextBox ID="NO_2" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2">หน่วย:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_UNIT_2" runat="server" DataValueField="UNIT_SECONDARY_ID" DataTextField="UNIT_SECONDARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2">Tertiary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_3" runat="server" DataValueField="PACK_TER_ID" DataTextField="PACK_TER_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2">จำนวน:</div>
        <div class="col-lg-2">
            <asp:TextBox ID="NO_3" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2">หน่วย:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_UNIT_3" runat="server" DataValueField="UNIT_TERTIARY_ID" DataTextField="UNIT_TERTIARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align:center">
            <asp:Button ID="btn_size_pack" runat="server" Text="เพิ่ม" />
        </div>
    </div>--%>
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
                            FilterControlAltText="Filter IDA column" SortExpression="IDA">
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
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ลักษณะผลิตภัณฑ์:</label><label style="color: red">*</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NATURE" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <%--<div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>กรรมวิธีการผลิต:</label>
        </div>
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <uc1:UC_ATTACH ID="UC_ATTACH2" runat="server" />
            </div>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="PRODUCT_PROCESS" runat="server" Width="100%"  ></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <telerik:RadGrid ID="RadGrid5" runat="server">
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
                                <asp:HyperLink ID="HyperLink1" runat="server">ดูเอกสาร</asp:HyperLink>
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
        <div class="col-lg-10">
            <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
                PagerStyle-Mode="NextPrevNumericAndAdvanced" Skin="Hay">
                <MasterTableView DataKeyNames="IDA">
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA" HeaderText="IDA" DataType="System.Int32" Display="false"
                            FilterControlAltText="Filter IDA column"  SortExpression="IDA">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FK_IDA_DQ" UniqueName="FK_IDA_DQ" HeaderText="FK_IDA_DQ" FilterControlAltText="Filter FK_IDA_DQ column"
                            SortExpression="FK_IDA_DQ" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NO_ID " UniqueName="NO_ID" HeaderText="ประเภทกระบวนการ" FilterControlAltText="Filter NO_ID column"
                            SortExpression="NO_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MENUFAC_NAME " UniqueName="MENUFAC_NAME" HeaderText="MENUFAC_NAME" FilterControlAltText="Filter MENUFAC_NAME column"
                            SortExpression="MENUFAC_NAME">
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
    </div>--%>
  <%--  <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>กลุ่มอาการ:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_SYNDROME_ID" runat="server" DataValueField="SYNDROME_ID" DataTextField="SYNDROME_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false">
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>สรรพคุณ:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="PROPERTIES" runat="server"  TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ขนาดและวิธีการใช้:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="SIZE_USE" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>วิธีการใช้:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="HOW_USE" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>วิธีเตรียมก่อนรับประทาน:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_EATTING_ID" runat="server" DataValueField="EATTING_ID" DataTextField="EATTING_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <div class="col-lg-6" id="R_EATTING_TEXT" runat="server" visible="false">
            <asp:TextBox ID="EATTING_TEXT" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>เงื่อนไขการรับประทาน:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:DropDownList ID="DD_EATING_CONDITION_ID" runat="server" DataValueField="PRO_CON_ID" DataTextField="PRO_CON_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-lg-6" id="R_EATING_CONDITION_TEXT" runat="server" visible="false">
            <asp:TextBox ID="EATING_CONDITION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>การเก็บรักษา:</label>
        </div>
        <%--<div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="TREATMENT" runat="server" BorderStyle="None" Width="200px"></asp:TextBox>
        </div>--%>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_STORAGE_ID" runat="server" DataValueField="PRO_MT_ID" DataTextField="PRO_MT_NAME" Style="width: 100%" Enabled="false"></asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <label>อายุการเก็บรักษา:</label>
        </div>
        <div class="col-lg-1" style="border-bottom: #999999 1px dotted">
            <asp:DropDownList ID="TREATMENT_AGE_YEAR" runat="server" Width="80%" AutoPostBack="true">
                <asp:ListItem Value="0">-</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1" style="text-align: center">
            <label>ปี</label><label style="color: red">*</label>
        </div>
        <div class="col-lg-1" id="div_hide" runat="server" style="border-bottom: #999999 1px dotted">
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
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ข้อห้ามใช้:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="R_CONTRAINDICATION" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" id="R_CONTRAINDICATION_TEXT" runat="server" visible="false">
            <asp:TextBox ID="CONTRAINDICATION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>คำเตือน:</label>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:RadioButtonList ID="R_WARNING" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:DropDownList ID="DD_WARNING" runat="server" DataValueField="PRO_WARNING_MAIN_ID" DataTextField="PRO_WARNING_MAIN_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="false" Enabled="false"></asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_WARNING_SUB" runat="server" DataValueField="PRO_WARNING_ID" DataTextField="PRO_WARNING_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Visible="false" Enabled="false"></asp:DropDownList>
        </div>
        <div class="col-lg-4" id="R_WARNING_TEXT" runat="server" visible="false">
            <asp:TextBox ID="WARNING_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ข้อควรระวัง:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="R_CAUTION" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" id="R_CAUTION_TEXT" runat="server" visible="false">
            <asp:TextBox ID="CAUTION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>อาการไม่พึงประสงค์:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="R_ADV_REACTIVETION" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" runat="server" id="R_ADV_REACTIVETION_TEXT" visible="false">
            <asp:TextBox ID="ADV_REACTIVETION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <%--<div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ช่องทางการขาย:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_SALE_CHANNEL" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ผลิตภัณฑ์สมุนไพรขายทั่วไป</asp:ListItem>
                <asp:ListItem Value="2">ผลิตภัณฑ์ขายในสถานที่มีใบอนุญาต</asp:ListItem>
                <asp:ListItem Value="3">ผลิตภัณฑ์ใช้เฉพาะสถานพยาบาล</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-4">
            <label>บทสรุป ด้านคุณภาพ ความปลอดภัย และประสิทธิภาพ:</label>
        </div>
        <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NOTE" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

  <%--  <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบคำขอทะเบียนผลิตภัณฑ์</h3>
        </div>
    </div>--%>
    <%--<div class="row">
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
                        <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                            HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink2" runat="server">ดูเอกสาร</asp:HyperLink>
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
    </div>--%>
        <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
            <asp:Button ID="btn_cancel" runat="server" Text="ย้อนกลับ" />
        </div>
    </div>
</asp:Content>

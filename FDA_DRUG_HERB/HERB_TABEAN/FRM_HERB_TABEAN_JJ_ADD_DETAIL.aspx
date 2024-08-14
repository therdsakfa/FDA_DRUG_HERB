<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_HERB_TABEAN_JJ_ADD_DETAIL.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_ADD_DETAIL" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">คำขอจดแจ้งผลิตภัณฑ์สมุนไพร</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ผู้ขอจดแจ้ง:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_JJ" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>ชื่อสถานที่:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_PLACE_JJ" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
     <div class="row" id="data_show3" runat="server" visible="false">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ผู้แทนนิติบุคคล:</label>
        </div>
        <div class="col-lg-4" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="txt_agent99" runat="server" Width="90%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="text-align: left">
            <label>อายุ:</label>
        </div>
        <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_person_age" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align: center">
            <label>ปี</label>
        </div>
        <div class="col-lg-1" style="text-align: center">
            <label>สัญชาติ:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:DropDownList ID="DDL_NATION" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="true">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ไทย</asp:ListItem>
                <asp:ListItem Value="2">อื่นๆ</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1" style="text-align: center" runat="server" visible="false" id="data_show1">
            <label>กรุณาระบุ:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted" id="data_show2" runat="server" visible="false">
            <asp:TextBox ID="txt_nation_person" runat="server"></asp:TextBox>
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
            <asp:DropDownList ID="DD_TYPE_SUB_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ยาจากสมุนไพร (ยาแผนไทย)</asp:ListItem>
                <asp:ListItem Value="2">ยาจากสมุนไพร (ยาแผนจีน)</asp:ListItem>
                <asp:ListItem Value="3">ยาจากสมุนไพร (ยาพัฒนาจากสมุนไพร)</asp:ListItem>
                <asp:ListItem Value="4">ผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ</asp:ListItem>
                <%--<asp:ListItem Value="5">ยาพัฒนาจากสมุนไพร</asp:ListItem>--%>
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
            <asp:DropDownList ID="DD_CATEGORY_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="true">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="122">ผลิต</asp:ListItem>
                <asp:ListItem Value="121">นำเข้า</asp:ListItem>
                <asp:ListItem Value="1220">ผลิตเพื่อส่งออกเท่านั้น</asp:ListItem>
                <asp:ListItem Value="1210">นำเข้าเพื่อส่งออกเท่านั้น</asp:ListItem>
                <%--<asp:ListItem Value="120">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>--%>
            </asp:DropDownList>
             <%--<asp:DropDownList ID="DD_CATEGORY_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="true">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="122">ผลิต ผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="121">นำเข้า ผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="1220">ผลิตเพื่อส่งออกเท่านั้น</asp:ListItem>
                <asp:ListItem Value="1210">นำเข้าเพื่อส่งออกเท่านั้น</asp:ListItem>
            </asp:DropDownList>--%>
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
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <label>ที่อยู่ ผู้ผลิตต่างประเทศ:</label>
            </div>
            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None"></asp:TextBox>
                <asp:TextBox ID="txt_address_ida" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None" Visible="false"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
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
        <%--<div class="row" style="text-align:center">
            <asp:Button ID="btn_choose" runat="server" Text="เลือก" />
        </div>--%>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">รายละเอียดของตำรับผลิตภัณฑ์สมุนไพร</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <%--<div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชื่อภาษาไทย:</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_THAI" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>ชื่อภาษาอังกฤษ(ถ้ามี):</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_ENG" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชื่อภาษาไทย:</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_THAI" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-2"> <asp:Label ID="Label1" runat="server" Text="*เพิ่มเติมเครื่องหมายการค้า (ถ้ามี)" ForeColor="Red"></asp:Label></div>
        <div class="col-lg-3">
            <asp:TextBox ID="NAME_THAI_R" runat="server" Width="100%" ></asp:TextBox>
           
        </div>
        
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชื่อภาษาอังกฤษ(ถ้ามี):</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_ENG" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชื่อภาษาต่างประเทศอื่น(ถ้ามี):</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_OTHER" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>รูปแบบ:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_STYPE_ID" runat="server" DataValueField="STYPE_ID" DataTextField="STYPE_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false">
                <%--<asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">แคปซูลแข็ง (hard capsule)</asp:ListItem>
                <asp:ListItem Value="2">ผง (powder)</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ขื่อตำรับ:</label>
        </div>
        <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="RECIPE_NAME" runat="server" Width="600px" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ตามบัญชี:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="ACCOUNT_NO" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align: right;">
            <label>ข้อ:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="ARTICLE_NO" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>สำหรับผลิตภัณฑ์สมุนไพรที่ขอจดแจ้ง:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="PRODUCT_JJ" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
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
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>รายละเอียดขนาด:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="SIZE_PACK" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
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
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ลักษณะยา:</label><label style="color: red">*</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NATURE" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <%--<div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="PRODUCT_PROCESS" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>--%>
    <%--<asp:DropDownList ID="DD_MANUFAC_ID" runat="server" DataValueField="MANUFAC_ID" DataTextField="MANUFAC_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false"></asp:DropDownList>--%>
    <%-- <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>กรรมวิธีการผลิต:</label>
        </div>
        
        <div class="col-lg-3">
            <asp:TextBox ID="TXT_MENUFACTRUE_DETAIL" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>--%>
    <%--<div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>น้ำหนักส่วนประกอบสำคัญต่อเม็ด / แคปซูล:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="WEIGHT_TABLE_CAP" runat="server" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-2">หน่วย</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_WEIGHT_TABLE_CAP_UNIT_ID" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">มิลลิกรัม</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>กลุ่มอาการ:</label>
        </div>
        <div class="col-lg-8">
            <%--<asp:DropDownList ID="DD_SYNDROME_ID" runat="server"  DataValueField="SYNDROME_ID" DataTextField="SYNDROME_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false"></asp:DropDownList>--%>
            <asp:TextBox ID="TXT_SYNDROME_DETAIL" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>สรรพคุณ:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="PROPERTIES" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ขนาดและวิธีการใช้:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="SIZE_USE" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>วิธีการใช้:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="HOW_USE" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>วิธีเตรียมก่อนรับประทาน:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_EATTING_ID" runat="server" DataValueField="EATTING_ID" DataTextField="EATTING_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" Enabled="false">
                <%--<asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ละลายน้ำต้มสุก</asp:ListItem>
                <asp:ListItem Value="2">ละลายน้ำ</asp:ListItem>
                <asp:ListItem Value="3">ไม่มี</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>เงื่อนไขการรับประทาน:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="R_EATING_CONDITION" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true" Enabled="false">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" id="R_EATING_CONDITION_TEXT" runat="server" visible="false">
            <asp:TextBox ID="EATING_CONDITION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
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
            <%-- <asp:TextBox ID="TREATMENT_AGE" runat="server" BorderStyle="None" Width="200px" AutoPostBack="True" TextMode="Number"></asp:TextBox>--%>
            <asp:DropDownList ID="TREATMENT_AGE_YEAR" runat="server" Width="80%" AutoPostBack="true">
                <asp:ListItem Value="0">-</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--  <div class="col-lg-1">
           <label>ปี</label><label style="color: red">*</label>
        <label>หน่วย:</label><label style="color: red">*</label>
        </div>--%>
        <div class="col-lg-1" style="text-align: center">
            <label>ปี</label><label style="color: red">*</label>
            <%--<asp:DropDownList ID="DD_PRO_AGE" runat="server" DataValueField="PRO_AGE_ID" DataTextField="PRO_AGE_NAME"  AutoPostBack="true"></asp:DropDownList>--%>
        </div>
        <%-- <div class="col-lg-1" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="TREATMENT_AGE_MONTH" runat="server" BorderStyle="None" Width="200px" AutoPostBack="True"></asp:TextBox>
        </div>--%>
        <div class="col-lg-1" id="div_hide" runat="server" style="border-bottom: #999999 1px dotted">
            <%--<label>หน่วย:</label><label style="color: red">*</label>--%>

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
                <%-- <asp:ListItem Value="12">12</asp:ListItem>--%>
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
            <asp:RadioButtonList ID="R_CONTRAINDICATION" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true" Enabled="false">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" id="R_CONTRAINDICATION_TEXT" runat="server" visible="false">
            <asp:TextBox ID="CONTRAINDICATION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>คำเตือน:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="R_WARNING" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true" Enabled="false">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" id="R_WARNING_TEXT" runat="server" visible="false">
            <asp:TextBox ID="WARNING_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ข้อควรระวัง:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="R_CAUTION" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true" Enabled="false">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" id="R_CAUTION_TEXT" runat="server" visible="false">
            <asp:TextBox ID="CAUTION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>อาการไม่พึงประสงค์:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="R_ADV_REACTIVETION" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true" Enabled="false">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" runat="server" id="R_ADV_REACTIVETION_TEXT" visible="false">
            <asp:TextBox ID="ADV_REACTIVETION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ช่องทางการขาย:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_SALE_CHANNEL" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" AutoPostBack="True" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ผลิตภัณฑ์สมุนไพรขายทั่วไป</asp:ListItem>
                <asp:ListItem Value="2">ผลิตภัณฑ์ขายในสถานที่มีใบอนุญาต</asp:ListItem>
                <asp:ListItem Value="3">ผลิตภัณฑ์ใช้เฉพาะสถานพยาบาล</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-4">
            <label>บทสรุป ด้านคุณภาพ ความปลอดภัย และประสิทธิภาพ:</label>
        </div>
        <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NOTE" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึกส่วนที่ 1" />
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" />
        </div>
    </div>

</asp:Content>

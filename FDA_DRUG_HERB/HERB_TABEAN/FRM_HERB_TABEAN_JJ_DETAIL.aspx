<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_HERB_TABEAN_JJ_DETAIL.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_DETAIL" %>

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
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชนิด:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_TYPE_NAME" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ยาจากสมุนไพร</asp:ListItem>
                <asp:ListItem Value="2">ยาจากสมุนไพรเพื่อสุขภาพ</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <label>ชนิดจากสมุนไพร:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_TYPE_SUB_ID" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false">
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
            <asp:DropDownList ID="DD_CATEGORY_ID" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="122">ผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="121">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="120">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>
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
            <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="txt_search" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <label>ที่อยู่ ผู้ผลิตต่างประเทศ:</label>
            </div>
            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                 <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None"></asp:TextBox>
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
            <asp:TextBox ID="NAME_THAI" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>ชื่อภาษาอังกฤษ(ถ้ามี):</label>
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_ENG" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
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
        <div class="col-lg-3">
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
                        <telerik:GridBoundColumn DataField="PACK_FSIZE_VOLUME" FilterControlAltText="Filter PACK_FSIZE_VOLUME column"
                            HeaderText="primary packaging" SortExpression="PACK_FSIZE_VOLUME" UniqueName="PACK_FSIZE_VOLUME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PACK_FSIZE_NAME" FilterControlAltText="Filter PACK_FSIZE_NAME column"
                            HeaderText="ขนาด" SortExpression="PACK_FSIZE_NAME" UniqueName="PACK_FSIZE_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PACK_FSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_FSIZE_UNIT_NAME column"
                            HeaderText="หน่วย" SortExpression="PACK_FSIZE_UNIT_NAME" UniqueName="PACK_FSIZE_UNIT_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PACK_SECSIZE_VOLUME" FilterControlAltText="Filter PACK_SECSIZE_VOLUME column"
                            HeaderText="secondary packaging" SortExpression="PACK_SECSIZE_VOLUME" UniqueName="PACK_SECSIZE_VOLUME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PACK_SECSIZE_NAME" FilterControlAltText="Filter PACK_SECSIZE_NAME column"
                            HeaderText="ขนาด" SortExpression="PACK_SECSIZE_NAME" UniqueName="PACK_SECSIZE_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PACK_SECSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_SECSIZE_UNIT_NAME column"
                            HeaderText="หน่วย" SortExpression="PACK_SECSIZE_UNIT_NAME" UniqueName="PACK_SECSIZE_UNIT_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PACK_THSSIZE_VOLUME" FilterControlAltText="Filter PACK_THSSIZE_VOLUME column"
                            HeaderText="tertiary packaging" SortExpression="PACK_THSSIZE_VOLUME" UniqueName="PACK_THSSIZE_VOLUME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PACK_THSIZE_NAME" FilterControlAltText="Filter PACK_THSIZE_NAME column"
                            HeaderText="ขนาด" SortExpression="PACK_THSIZE_NAME" UniqueName="PACK_THSIZE_NAME">
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
            <label>ลักษณะ:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NATURE" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <%--<div class="col-lg-3" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="PRODUCT_PROCESS" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>--%>
   <%-- <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>กรรมวิธีการผลิต:</label>
        </div>
        <div class="col-lg-3">
            <asp:DropDownList ID="DD_MANUFAC_ID" runat="server" DataValueField="MANUFAC_ID" DataTextField="MANUFAC_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false"></asp:DropDownList>
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
            <asp:TextBox ID="WEIGHT_TABLE_CAP" runat="server" Style="border-bottom: #999999 1px dotted" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-2">หน่วย</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_WEIGHT_TABLE_CAP_UNIT_ID" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">มิลลิกรัม</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ขนาดบรรจุ:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="SIZE_PACK" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>กลุ่มอาการ:</label>
        </div>
        <div class="col-lg-2">
            <%--<asp:DropDownList ID="DD_SYNDROME_ID" runat="server" DataValueField="SYNDROME_ID" DataTextField="SYNDROME_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false">            </asp:DropDownList>--%>
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
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="HOW_USE" runat="server" BorderStyle="None" ReadOnly="true">รับประทาน</asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>วิธีเตรียมก่อนระบประทาน:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_EATTING_ID" runat="server" DataValueField="EATTING_ID" DataTextField="EATTING_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" Enabled="false">
               <%-- <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
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
            <asp:DropDownList ID="TREATMENT_AGE_YEAR" runat="server" Width="80%" AutoPostBack="true" Enabled="false">
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

            <asp:DropDownList ID="TREATMENT_AGE_MONTH_SUB" runat="server" Width="80%" Enabled="false">
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
            <h3>เอกสารแนบคำขอจดแจ้ง</h3>
        </div>
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
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารยินยอมการใช้สูตร</h3>
        </div>
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
                        <telerik:GridBoundColumn DataField="DD_HERB_NAME_PRODUCT_ID" DataType="System.Int32" FilterControlAltText="Filter DD_HERB_NAME_PRODUCT_ID column" HeaderText="DD_HERB_NAME_PRODUCT_ID"
                            SortExpression="DD_HERB_NAME_PRODUCT_ID" UniqueName="DD_HERB_NAME_PRODUCT_ID" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                            HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_FAKE" FilterControlAltText="Filter NAME_FAKE column"
                            HeaderText="ชื่อเอกสาร" SortExpression="NAME_FAKE" UniqueName="NAME_FAKE">
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
    <div class="row" style="text-align: center">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <%--<asp:Button ID="btn_download_jj1" runat="server" Text="Download จจ.1" CssClass="btn-lg" Width="20%" />--%>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_cancel" runat="server" Text="ย้อนกลับ" />
        </div>
    </div>
</asp:Content>

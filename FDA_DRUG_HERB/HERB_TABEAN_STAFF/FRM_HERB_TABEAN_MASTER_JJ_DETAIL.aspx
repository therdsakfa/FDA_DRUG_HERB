<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_MASTER_JJ_DETAIL.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_MASTER_JJ_DETAIL" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Src="~/HERB_TABEAN/UC/UC_TABEAN_JJ_DETAIL_CAS.ascx" TagPrefix="uc1" TagName="UC_TABEAN_JJ_DETAIL_CAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <br />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">รายละเอียดจดแจ้งผลิตภัณฑ์สมุนไพร</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชนิด:</label>
        </div>
        <div class="col-lg-3">
            <asp:DropDownList ID="DD_TYPE_NAME" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ยาจากสมุนไพร</asp:ListItem>
                <asp:ListItem Value="2">ยาจากสมุนไพรเพื่อสุขภาพ</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <label>ชนิดจากสมุนไพร:</label>
        </div>
        <div class="col-lg-3">
            <asp:DropDownList ID="DD_TYPE_SUB_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap">
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
        <div class="col-lg-2">
            <label>ขื่อตำรับ:</label>
        </div>
        <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="RECIPE_NAME" runat="server" Width="600px"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ตามบัญชี:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="ACCOUNT_NO" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align: right;">
            <label>ข้อ:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="ARTICLE_NO" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>สำหรับผลิตภัณฑ์สมุนไพรที่ขอจดแจ้ง:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="PRODUCT_JJ" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
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
        <div class="col-lg-12" style="text-align: center">
            <h3>รายละเอียด ขั้นตอนของบรรจุ</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">Primary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_1" runat="server" DataValueField="PACK_PRIMARY_ID" DataTextField="PACK_PRIMARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="text-align: right">จำนวน:</div>
        <div class="col-lg-2" style="text-align: right">
            <asp:TextBox ID="NO_1" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2" style="text-align: right">หน่วย:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_UNIT_1" runat="server" DataValueField="UNIT_PRIMARY_ID" DataTextField="UNIT_PRIMARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">Secondary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_2" runat="server" DataValueField="PACK_SEC_ID" DataTextField="PACK_SEC_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="text-align: right">จำนวน:</div>
        <div class="col-lg-2">
            <asp:TextBox ID="NO_2" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2" style="text-align: right">หน่วย:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_UNIT_2" runat="server" DataValueField="UNIT_SECONDARY_ID" DataTextField="UNIT_SECONDARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">Tertiary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_3" runat="server" DataValueField="PACK_TER_ID" DataTextField="PACK_TER_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="text-align: right">จำนวน:</div>
        <div class="col-lg-2">
            <asp:TextBox ID="NO_3" runat="server" Width="100%"></asp:TextBox>
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
                        <telerik:GridBoundColumn DataField="FK_IDA" UniqueName="FK_IDA" HeaderText="FK_IDA" FilterControlAltText="Filter FK_IDA column"
                            SortExpression="FK_IDA" Display="false">
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

                        <telerik:GridBoundColumn DataField="PACK_THSIZE_NAME" FilterControlAltText="Filter PACK_THSIZE_NAME column"
                            HeaderText="tertiary packaging" SortExpression="PACK_THSIZE_NAME" UniqueName="PACK_THSIZE_NAME">
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
                </MasterTableView>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>กลุ่มอาการ:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:DropDownList ID="DD_SYNDROME_ID" runat="server" DataValueField="SYNDROME_ID" DataTextField="SYNDROME_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
            <asp:Button ID="BTN_ADD_SYNDROME" runat="server" Text="เพิ่มกลุ่มอาการ" />
            <br />
            <asp:TextBox ID="TXT_SYNDROME_DETAIL" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>สรรพคุณ:</label>
        </div>
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="PROPERTIES" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
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
        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="HOW_USE" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>วิธีเตรียมก่อนรับประทาน:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_EATTING_ID" runat="server" DataValueField="EATTING_ID" DataTextField="EATTING_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap">
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
            <asp:RadioButtonList ID="R_EATING_CONDITION" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
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
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_STORAGE_ID" runat="server" DataValueField="PRO_MT_ID" DataTextField="PRO_MT_NAME" Style="width: 100%"></asp:DropDownList>
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
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="R_WARNING" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true">
                <asp:ListItem Value="1">มี</asp:ListItem>
                <asp:ListItem Value="2">ไม่มี</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-6" id="R_WARNING_TEXT" runat="server" visible="false">
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
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ช่องทางการขาย:</label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_SALE_CHANNEL" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap" AutoPostBack="True">
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
            <asp:TextBox ID="NOTE" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <uc1:UC_TABEAN_JJ_DETAIL_CAS runat="server" ID="UC_TABEAN_JJ_DETAIL_CAS" />
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div id="STAFF_HIDE_SET" runat="server" visible="true">
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <label>กรุณาแนบไฟล์ สูตรตำรับ และ กรรมวิธีการผลิต</label>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3">
                <label>สูตรตำรับ:</label>
            </div>
            <div class="col-lg-7" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="name_recipe" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
                <%--<asp:Label ID="chk_file1" runat="server"></asp:Label>--%>
                <br />

            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3"></div>
            <div class="col-lg-7">
                <telerik:RadGrid ID="RG_ATTACH1" runat="server">
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
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3">
                <label>กรรมวิธีการผลิต:</label>
            </div>
            <div class="col-lg-7" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="name_production_process" runat="server" Width="100%"></asp:TextBox>
                <br />

            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <uc1:UC_ATTACH ID="UC_ATTACH2" runat="server" />
                <%--<asp:Label ID="chk_file2" runat="server" Text="lbl_2"></asp:Label>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3">
            </div>
            <div class="col-lg-7" style="border-bottom: #999999 1px dotted">
                <telerik:RadGrid ID="RG_ATTACH2" runat="server">
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
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึกส่วนที่ 1" />
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" />
        </div>
    </div>

</asp:Content>

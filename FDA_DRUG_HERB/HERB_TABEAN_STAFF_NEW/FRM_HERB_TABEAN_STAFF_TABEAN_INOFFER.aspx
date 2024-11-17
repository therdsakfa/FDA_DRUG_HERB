<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_HERB_TABEAN_STAFF_TABEAN_INOFFER.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_STAFF_TABEAN_INOFFER" %>

<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Src="~/TABEAN_YA/UC/UC_officer_che.ascx" TagPrefix="uc1" TagName="UC_officer_che" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_OFFER"));
            $("#ContentPlaceHolder1_DD_OFF_OFFER").searchable();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row" style="background-color: whitesmoke; padding-left: 1em">
        <div class="col-lg-8" style="width: 70%; border-radius: 5px; background-color: white;">
            <div id="STAFF_KEY_SET" runat="server" style="background-color: antiquewhite">
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <h3>รายระเอียดของ</h3>
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
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <telerik:RadGrid ID="RadGrid6" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
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
                                    <telerik:GridBoundColumn DataField="NO_ID " UniqueName="NO_ID" HeaderText="ประเภทกระบวนการ" FilterControlAltText="Filter NO_ID column"
                                        SortExpression="NO_ID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="MENUFAC_NAME " UniqueName="MENUFAC_NAME" HeaderText="MENUFAC_NAME" FilterControlAltText="Filter MENUFAC_NAME column"
                                        SortExpression="MENUFAC_NAME">
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
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>กลุ่มอาการ:</label>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="DD_SYNDROME_ID" runat="server" DataValueField="SYNDROME_ID" DataTextField="SYNDROME_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <label>กลุ่มอาการที่ 2:</label>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="DD_SYNDROME_ID2" runat="server" DataValueField="SYNDROME_ID" DataTextField="SYNDROME_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" id="SALE_CHANNEL_SET" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ช่องทางการขาย:</label>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="DD_SALE_CHANNEL" runat="server" DataValueField="SALE_CHANNEL_ID" DataTextField="SALE_CHANNEL_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                        <%--   <asp:DropDownList ID="DD_SALE_CHANNEL" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap">
                            <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                            <asp:ListItem Value="1">ผลิตภัณฑ์สมุนไพรขายทั่วไป</asp:ListItem>
                            <asp:ListItem Value="2">ผลิตภัณฑ์ขายในสถานที่มีใบอนุญาต</asp:ListItem>
                            <asp:ListItem Value="3">ผลิตภัณฑ์ใช้เฉพาะสถานพยาบาล</asp:ListItem>
                        </asp:DropDownList>--%>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <h3>สูตรสาร</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <uc1:UC_officer_che runat="server" ID="UC_officer_che" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4"></div>
                    <div class="col-lg-5" style="text-align: center">
                        <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" CssClass="btn-sm" OnClientClick="confirm('ต้องการบันทึกหรือไม่');" Height="45px" Width="320px" />

                    </div>
                </div>
            </div>
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-6">
                    <asp:Label ID="Label3" runat="server" Text="สร้างคำขอโดย:" Font-Size="Large"></asp:Label>
                    <asp:Label ID="lbl_create_by" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label2" runat="server" Text="สร้างคำขอเมื่อ:" Font-Size="Large"></asp:Label>
                    <asp:Label ID="lbl_create_date" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div runat="server" id="Submit_BG" style="border-radius: 5px; padding: 2em; background-color: white;">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เลือกสถานะ</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="DD_STATUS" runat="server" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" Style="width: 100%" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server" id="P12" visible="false">
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เลขรับ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="RCVNO_FULL" runat="server" Style="width: 100%" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เลขทะเบียน</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="RGTNO_FULL" runat="server" Style="width: 100%" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">วันที่ลงนาม</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="DATE_OFFER" runat="server" Style="width: 90%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">ประเภทค่าธรรเนียม</div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="DD_ML_ID" runat="server" DataValueField="ML_ID" DataTextField="ML_NAME" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">จำนวนเงิน</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="TXT_BATH" runat="server" Style="width: 100%" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">ส่วนลด %</div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="DDL_DISCOUNT" runat="server" DataValueField="DISCOUNT_ID" DataTextField="DISCOUNT" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4" style="color: red">ยอดสุทธิ**</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="TXT_SUM" runat="server" Style="width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">หมายเหตุ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="NOTE_OFFER" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เจ้าหน้าที่เสนอลงนาม</div>
                        <div class="col-lg-6">
                            <%--<asp:TextBox ID="OFF_OFFER" runat="server" Style="width: 100%"></asp:TextBox>--%>
                            <asp:DropDownList ID="DD_OFF_OFFER" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
                <div class="row" runat="server" id="p2" visible="false">
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เนื่องจาก</div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="DDL_CANCLE_REMARK" runat="server" AutoPostBack="true" DataTextField="STATUS_CAUSE" DataValueField="ID"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">รายละเอียดการยกเลิก</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="NOTE_CANCLE" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">วันที่ดำเนินการ</div>
                        <div class="col-lg-6">
                            <%--<asp:TextBox ID="CANCEL_DATE" runat="server" Style="width: 90%"></asp:TextBox>--%>
                            <telerik:RadDatePicker ID="RDP_CANCEL_DATE" runat="server"></telerik:RadDatePicker>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: center">
                            <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row" style="text-align: center">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg bg-success" Width="100%" />
                        <br />
                        <div class="row">
                            <div class="col-lg-5">
                                <label>รูปแบบเอกสาร ทบ2.:</label>
                            </div>
                            <div class="col-lg-2">
                                <asp:DropDownList ID="DDL_TB2_SELECT" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap">
                                    <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                                    <asp:ListItem Value="1">แบบสั้น</asp:ListItem>
                                    <asp:ListItem Value="2">แบบยาว</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-1"></div>
                        <asp:Button ID="btn_preview_tb2" runat="server" Text="Preview ทบ.2" CssClass="btn-lg bg-info" Width="100%" />
                        <div style="padding-top: 10px"></div>
                        <asp:Button ID="btn_dbd" runat="server" Text="ข้อมูล DBD" CssClass="btn-lg bg-primary" Width="100%" />
                        <div style="padding-top: 10px"></div>
                        <asp:Button ID="btn_Closed" runat="server" Text="ปิด" CssClass="btn-lg bg-danger" Width="100%" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>

            <hr />
            <div style="border-radius: 5px; padding: 2em; background-color: white;">
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบคำขอทะเบียน</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="width: 100%">
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
                <hr />
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบคำขอทะเบียน(ผปก. แก้ไขข้อมูลเอกสาร)ครั้งที่2</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="width: 100%">
                        <telerik:RadGrid ID="RadGrid4" runat="server">
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
                        <h3>เอกสารแนบคำขอทะเบียน(แก้ไขตามบันทึกข้อบกพร่อง)</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="width: 100%">
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
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <label>เอกสารแนบ ชื่อสมุนไพร (พืช/สัตว์/จุลชีพ/แร่)  /  กรณีเป็นสารสกัด  /  ชื่อสารช่วย:</label>
                    </div>
                    <div class="col-lg-1"></div>
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
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารสูตรตำรับและกรรมวิธีการผลิต</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="width: 100%">
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
</asp:Content>

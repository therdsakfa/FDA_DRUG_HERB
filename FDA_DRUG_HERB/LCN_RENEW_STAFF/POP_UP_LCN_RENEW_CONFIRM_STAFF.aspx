<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POP_UP_LCN_RENEW_CONFIRM_STAFF.aspx.vb" Inherits="FDA_DRUG_HERB.POP_UP_LCN_RENEW_CONFIRM_STAFF" %>

<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_REQ"));
            $("#ContentPlaceHolder1_DD_OFF_REQ").searchable();
        });
        function Popups(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }

        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function spin_space() { // คำสั่งสั่งปิด PopUp
            $('#spinner').toggle('slow');
        }

        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();
        }
        function disableButton(button) {
            button.disabled = true; // ปิดการใช้งานปุ่มทันที
            return true; // อนุญาตให้การ submit ดำเนินการต่อ
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control">
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
        </asp:HyperLink>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
    </div>
    <div class="row">
        <div class="col-lg-8" style="width: 70%">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
                 <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <h3 style="color: black; border-bottom: #999999 1px solid;">ข้อมูลการสร้างคำขอ</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <asp:Label ID="Label3" runat="server" Text="สร้างคำขอโดย:" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dashed">
                    <asp:Label ID="lbl_create_by" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="Label2" runat="server" Text="สร้างคำขอเมื่อ:" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dashed">
                    <asp:Label ID="lbl_create_date" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <h3 style="color: black; border-bottom: #999999 1px solid;">ชื่อผู้ติดต่อฉุกเฉิน</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <asp:Label ID="Label4" runat="server" Text="ชื่อ-สกุล:" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dashed">
                    <asp:Label ID="lbl_emc_name" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="Label5" runat="server" Text="โทรศัพท์:" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dashed">
                    <asp:Label ID="lbl_emc_tel" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <asp:Label ID="Label1" runat="server" Text="E-mail:" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-3" style="border-bottom: #999999 1px dashed">
                    <asp:Label ID="lbl_emc_email" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <h3 style="color: black; border-bottom: #999999 1px solid;">รายละเอียดเพิ่มเติมคำขอ</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <asp:Label ID="Label10" runat="server" Text="การจดทะเบียนวิสาหกิจ:" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-8" style="border-bottom: #999999 1px dashed">
                    <asp:RadioButtonList ID="rdl_enterprise" runat="server" RepeatDirection="Vertical" Width="100%">
                        <asp:ListItem Value="1">&ensp;1.จดทะเบียนวิสาหกิจชุมชน</asp:ListItem>
                        <asp:ListItem Value="2">&ensp;2.จดทะเบียนวิสาหกิจขนาดย่อม (รายย่อย) [small (micro) enterprise]</asp:ListItem>
                        <asp:ListItem Value="3">&ensp;3.จดทะเบียนวิสาหกิจขนาดย่อม [small enterprise]</asp:ListItem>
                        <asp:ListItem Value="4">&ensp;4.จดทะเบียนวิสาหกิจขนาดกลาง  [medium enterprise]</asp:ListItem>
                        <asp:ListItem Value="5">&ensp;5.ไม่ได้จดทะเบียนเป็นวิสาหกิจ</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    <asp:Label ID="Label11" runat="server" Text="กาารรับรองมาตรฐานสถานที่:" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-8" style="border-bottom: #999999 1px dashed">
                    <asp:RadioButtonList ID="rdl_CerSD" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">&ensp;1.ได้รับการรับรอง &ensp;</asp:ListItem>
                        <asp:ListItem Value="2">&ensp;2.ยังไม่ได้รับการรับรอง</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <%--  <div class="col-lg-2">
                    <asp:Label ID="Label12" runat="server" Text="กาารรับรองมาตรฐานสถานที่:" Font-Size="Large"></asp:Label>
                </div>--%>
            </div>
            <div class="row" id="Div_Sub_Cer" runat="server" style="display: none">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                </div>
                <div class="col-lg-8" style="border-bottom: #999999 1px dashed">
                    <div id="chk_rad1" runat="server">
                        <asp:RadioButtonList ID="rdl_cer" runat="server" Visible="true" RepeatDirection="Vertical">
                            <asp:ListItem Value="1">&ensp;PIC/S GMP</asp:ListItem>
                            <asp:ListItem Value="2">&ensp;ASEAN GMP</asp:ListItem>
                            <asp:ListItem Value="3">&ensp;เกียรติบัตรระดับเหรียญทอง</asp:ListItem>
                            <asp:ListItem Value="4">&ensp;เกียรติบัตรระดับเหรียญเงิน</asp:ListItem>
                            <asp:ListItem Value="5">&ensp;เกียรติบัตรระดับเหรียญทองแดง</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row" runat="server" id="status_update" visible="true">
                <div runat="server" visible="false" id="DIV_FEE_DISCOUNT">
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เงื่อนไขส่วนลด</div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddl_fee_discount" runat="server" DataValueField="ID" DataTextField="DiscountName" Style="width: 100%" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">จำนวนเงิน</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txt_price_fee" runat="server" ReadOnly="true" BorderStyle="none" Style="width: 100%; border-bottom: double"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">รายละเอียดเพิ่มเติม</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txt_Fee_discount_Note" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
                <div class="row" runat="server" id="P12" visible="true">
                    <div class="row" runat="server" id="DIV_STATUS_DDL">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เลือกสถานะ</div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="DD_STATUS" runat="server" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" Style="width: 100%" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>

                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">วันที่ตรวจรับคำขอ</div>
                        <div class="col-lg-6">
                            <%-- <asp:TextBox ID="DATE_REQ" runat="server" Style="width: 90%"></asp:TextBox>--%>
                            <telerik:RadDatePicker ID="RDP_DATE_REQ" runat="server" Width="100%"></telerik:RadDatePicker>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">จนท. ที่รับผิดชอบ</div>
                        <div class="col-lg-6">
                            <%--<asp:TextBox ID="OFF_REQ" runat="server" Style="width: 100%"></asp:TextBox>--%>
                            <asp:DropDownList ID="DD_OFF_REQ" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME" Style="width: 100%"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <hr />
                    <asp:Panel runat="server" ID="panel_file_upload" Visible="false">
                        <div class="row">
                            <div class="col-lg-12" style="text-align: center">
                                <h3>สำหรับการเสนอลงนามแบบกระดาษ ให้อัพโหลดใบอนุญาตฯ (สมพ2) ที่ลงนามแล้ว</h3>
                            </div>
                        </div>
                        <div class="row" runat="server" id="uc_upload1" visible="true">
                            <div class="col-lg-1" style="text-align: center"></div>
                            <div class="col-lg-10" style="text-align: center">
                                <uc1:UC_ATTACH ID="UC_ATTACH2" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row" runat="server" id="p2" visible="false">
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เนื่องจาก</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="DDL_CANCLE_REMARK" runat="server" DataValueField="remark_cancle_id" DataTextField="remark_cancle_name" AutoPostBack="true"></asp:DropDownList>
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
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
                        <%--<asp:Label ID="chk_file2" runat="server" Text="lbl_2"></asp:Label>--%>
                    </div>
                </div>
            </div>
            <asp:Panel runat="server" ID="panel_file_att" Visible="false">
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสาร สมพ 2 ที่อนุมัติแล้ว</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
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
                                    <telerik:GridBoundColumn DataField="DOCUMENT_NAME" FilterControlAltText="Filter DOCUMENT_NAME column"
                                        HeaderText="รายการเอกสาร" SortExpression="DOCUMENT_NAME" UniqueName="DOCUMENT_NAME">
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
            </asp:Panel>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="80%"
                        OnClick="btn_sumit_Click" />
                    <br />
                    <%--<asp:Button ID="btn_keep_pay" runat="server" Text="ข้ามสถานะ" CssClass="btn-lg" Width="80%" Visible="false" />--%>
                    <%--<asp:Button ID="btn_priview" runat="server" Text="Priview ใบสำคัญ" CssClass="btn-lg" Width="80%" />--%>
                </div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_cancel" runat="server" Text="ปิด" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>

            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_lcn_edit" runat="server" Text="แก้ไขข้อมูลใบอนุญาต" CssClass="btn-lg" Width="80%" Visible="false" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_drug_group_edit" runat="server" Text="แก้ไขข้อมูลหมวดยา" CssClass="btn-lg" Width="80%" Visible="false" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_preview" runat="server" Text="Preview ใบอนุญาต(สมพ2)" CssClass="btn-lg" Width="80%" Visible="false" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />

            <div runat="server" id="AT_FILE">
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบคำขอ</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="width: 100%">
                        <telerik:RadGrid ID="rgat" runat="server">
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
                                    <telerik:GridBoundColumn DataField="DOCUMENT_NAME" FilterControlAltText="Filter DOCUMENT_NAME column"
                                        HeaderText="รายการเอกสาร" SortExpression="DOCUMENT_NAME" UniqueName="DOCUMENT_NAME">
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
                    <div class="row">
                        <div class="col-lg-12" style="text-align: center">
                            <h3>เอกสารแนบเจ้าหน้าที่สั่งแก้ไข</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10" style="width: 100%">
                            <telerik:RadGrid ID="rgat_edit" runat="server">
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn AllowFiltering="true" DataField="IDA" DataType="System.Int32" Display="false" FilterControlAltText="Filter IDA column" HeaderText="IDA" SortExpression="IDA" UniqueName="IDA">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn AllowFiltering="true" DataField="FK_IDA" DataType="System.Int32" Display="false" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DOCUMENT_NAME" FilterControlAltText="Filter DOCUMENT_NAME column" HeaderText="รายการเอกสาร" SortExpression="DOCUMENT_NAME" UniqueName="DOCUMENT_NAME">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column" HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="PV_ST" runat="server">ดูเอกสาร</asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <PagerStyle PageSizeControlType="RadComboBox" />
                                </MasterTableView>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <hr />
                </div>
            </div>
        </div>
    </div>
    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_head1" runat="server" Text="-"></asp:Label></h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f1" style="width: 100%; height: 550px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />

</asp:Content>


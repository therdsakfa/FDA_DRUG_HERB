<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_HERB_TEMPOLARY_CONFIRM.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_HERB_TEMPOLARY_CONFIRM" %>




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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row" style="padding-left: 1em">
        <div class="col-lg-8" style="width: 70%; border: groove; height: 750px; padding-left: 2em">
            <div>
                <div class="row">
                    <div class="col-lg-12" style="text-align: center;">
                        <h3>การยื่นคำขออื่นๆ ตามการจัดเก็บเงินค่าคำขอ ผลิตภัณฑ์สมุนไพร</h3>
                    </div>
                </div>

                <div style="padding-top: 15px"></div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        ผู้ยื่นคำขอ  
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txt_name_request" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lbl_name_request" runat="server" Text="*กรุณากรอกชื่อผู้ยื่นคำขอ " ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="TXT_SEARCH_TN" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label3" runat="server" Text="มีความประสงค์จะขอ " Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-lg-4">
                        <telerik:RadComboBox ID="DD_PRICE_REQUEST" runat="server" Filter="Contains" Width="100%" AutoPostBack="true"></telerik:RadComboBox>
                        <asp:Label ID="lbl_PRICE_REQUEST" runat="server" Text="*กรุณาเลือกความประสงค์" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <p style="color: red" runat="server" id="P1" visible="false">&nbsp;</p>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row" runat="server" id="NumberPage" visible="false">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label6" runat="server" Text="จำนวนหน้า" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txt_numbre_page" runat="server" Width="100%" TextMode="Number" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label1" runat="server" Text="โดยมีค่าใช้จ่ายในการจัดเก็บจากผู้ยื่นคำขอ จำนวน " Font-Size="Small"></asp:Label>
                    </div>
                    <div class="col-lg-1">
                        <asp:TextBox ID="txt_ML_PAY" ReadOnly="true" runat="server" TextMode="Number" Width="80%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1">
                        <asp:Label ID="Label2" runat="server" Text="บาท" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label4" runat="server" Text="ยื่นคำขอวันที่" Font-Size="Medium" ReadOnly="true"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txt_date_confirm" runat="server" Width="90%" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lbl_date_confirm" runat="server" Text="*กรุณากรอกวันที่ยื่นคำขอ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label7" runat="server" Text="ผู้มาติดต่อ" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txt_name_contact" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lbl_name_contact" runat="server" Text="*กรุณากรอกข้อมูลผู้มาติดต่อ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="TXT_SEARCH_TN2" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <%--    <div class="col-lg-1">
                        <asp:Button ID="BTN_SEARCH_TN2" runat="server" Text="ค้นหา" />
                    </div>--%>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label5" runat="server" Text="Email" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txt_email" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lbl_email" runat="server" Text="*กรุณากรอกข้อมูล e-mail" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label8" runat="server" Text="เบอร์โทร" Font-Size="Medium" ReadOnly="true"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txt_phone" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lbl_phone" runat="server" Text="*กรุณากรอกข้อมูล เบอร์โทร" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

            </div>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row" runat="server" id="KEEP_PAY" visible="true">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เลือกสถานะ</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="DD_STATUS" runat="server" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" AutoPostBack="true" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server" id="P12" visible="true">
                    <div class="row" runat="server" id="P14" visible="true">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เลขรับ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="ROVNO_FULL" runat="server" Style="width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">วันที่ตรวจรับคำขอ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="DATE_REQ" runat="server" Style="width: 90%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">จนท. ที่รับผิดชอบ</div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="DD_OFF_REQ" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>


                <div class="row" runat="server" id="p2" visible="false">
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เนื่องจาก</div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="DDL_CANCLE_REMARK" runat="server" Width="100%"></asp:DropDownList>
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
                        </div>
                    </div>
                </div>
                <div class="row" style="text-align: center">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="80%" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <hr />
            </div>

            <%--     <div class="row" id="ADDR_FOREIGN_CHK" runat="server" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:TextBox ID="Txt_Txt_Addr_to_Staff" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
           <hr />--%>
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>อัพโหลดเอกสาร </h3>
                </div>
            </div>
            <div class="row" runat="server" id="uc_upload1" visible="true">
                <div class="col-lg-12" style="text-align: center">
                    <uc1:UC_ATTACH ID="UC_ATTACH2" runat="server" />
                </div>
            </div>
            <div class="row" runat="server" id="uc_upload1_btn" visible="true">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="text-align: center">
                    <asp:Button ID="btn_savefileApprove_2" runat="server" Text="บันทึกแบบไฟล์" CssClass="btn-lg" Width="80%" />
                </div>
            </div>
            <div class="row" runat="server" id="uc_upload1_radgrid" visible="false">
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
        </div>
    </div>
</asp:Content>

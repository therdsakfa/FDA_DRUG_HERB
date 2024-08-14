<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_JJ_EDIT_COMFIRM.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_EDIT_COMFIRM" %>




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
        function Popups2(url) { // สำหรับทำ Div Popup
            $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
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
    <div class="row">
        <div class="col-lg-8" style="width: 70%">
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
            <div class="row" style="text-align: center" runat="server" id="dv_btn" visible="true">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_confirm" runat="server" Text="ยื่นคำขอ" CausesValidation="true" ValidationGroup="valGroup1" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการยื่นคำขอหรือไม่');" />
                    <div style="height: 5px"></div>
                    <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิกคำขอ" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการยกเลิกคำขอหรือไม่');" Visible="false" />
                    <div style="height: 5px"></div>
                    <asp:Button ID="btn_cancle_request" runat="server" Text="ยกเลิกการสร้างคำขอ" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการยกเลิกคำขอหรือไม่');" Visible="false" />
                    <div style="height: 5px"></div>
                    <asp:Button ID="btn_edit" runat="server" Text="แก้ไขข้อมูล" CssClass="btn-lg" Width="80%" />
                    <div style="height: 5px"></div>
                    <asp:Button ID="btn_editUpload" runat="server" Text="แก้ไขเอกสารแนบ" CssClass="btn-lg" Width="80%" />
                    <div style="height: 5px"></div>
                    <asp:Button ID="btn_close" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row" runat="server" id="dv_cancel" visible="false">
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เนื่องจาก</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txt_cancel_remark" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">รายละเอียด</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="NOTE_CANCLE" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div runat="server" id="uc_upload1_radgrid">
                    <%--<div class="row">
                        <div class="col-lg-12" style="text-align: center">
                            <h3>เอกสารแนบ</h3>
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4"></div>
                        <div class="col-lg-6" style="width: 100%">
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
            <hr />
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบคำขอ</h3>
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
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        </div>
    </div>



</asp:Content>


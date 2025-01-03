﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_CONFIRM.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_CONFIRM" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_txt_date_confirm"));
            $("#ContentPlaceHolder1_txt_date_confirm").searchable();
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
                <div class="col-lg-10">
                     <asp:Label ID="Label3" runat="server" Text="สร้างคำขอโดย:"></asp:Label>
                     <asp:Label ID="lbl_create_by" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="Label1" runat="server" Text="กรุณากรอกเลขหนังสือมอบอำนาจ (หากเป็นการยื่นด้วยตนเอง ให้กรอกเลข 000000)"></asp:Label><label style="color: red">*</label>
                </div>
                <div class="col-lg-5">
                    <asp:TextBox ID="txt_ref_no" runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="validate1" ControlToValidate="txt_ref_no" ValidationGroup="valGroup1" ErrorMessage="*กรุณากรอกเลขหนังสือมอบอำนาจ" runat="server" ForeColor="Red" />--%>
                </div>

            </div>
            <div id="set_show" runat="server" visible="False">
                <div class="row">
                    <div class="col-lg-6" style="text-align:right">
                        <asp:Label ID="lbl_rcvno_old" runat="server" Text="กรุณากรอกเลขรับ"></asp:Label>
                    </div>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txt_rcvno_old" runat="server"></asp:TextBox>
                        <label style="color: red">*หากมีเลขรับเก่า กรูณากรอกเลขรับก่อนกดยืนยัน</label>
                    </div>

                </div>
                <div class="row">
                    <div class="col-lg-6" style="text-align:right">
                        <asp:Label ID="Label2" runat="server" Text="วันที่ยื่นคำขอ"></asp:Label>
                    </div>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txt_date_confirm" runat="server" Style="width: 90%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_confirm" runat="server" Text="ยื่นคำขอ" CausesValidation="true" ValidationGroup="valGroup1" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการยื่นคำขอหรือไม่');" />
                    <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิกคำขอ" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการยกเลิกคำขอหรือไม่');" />
                    <asp:Button ID="btn_cancle_request" runat="server" Text="ยกเลิกการสร้างคำขอ"  CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการยกเลิกคำขอหรือไม่');" Visible="false"/>
                    <asp:Button ID="btn_edit" runat="server" Text="แก้ไขข้อมูล" CssClass="btn-lg" Width="80%" />
                    <asp:Button ID="btn_close" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />    
            <asp:Panel ID="Panel1" runat="server">
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
            </asp:Panel>
        </div>
    </div>



</asp:Content>

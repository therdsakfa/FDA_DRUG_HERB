<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_TABEAN_SEARCH_MAIN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_SEARCH_MAIN" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(window).load(function () {
                $.ajax({
                    type: 'POST',
                    data: { submit: true },
                    success: function (result) {
                        // $('#spinner').fadeOut('slow');
                    }
                });
            });


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
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 160px">
            <div class="row">
                <div class="col-lg-10">
                    <h3>ค้นหาจากเลขทะเบียน</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_rgt_no" runat="server" CssClass="input-lg" Width="100%"></asp:TextBox><br />
                    <p>(ตัวอย่าง G 1/26)</p>
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg" />
                </div>
            </div>
        </div>
    </div>
    <div style="padding-top: 15px"></div>
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel panel-body" style="width: 100%; padding-left: 1%;">
            <div class="row">
                <div class="col-lg-12">
                    <h3>รายการทะเบียน</h3>
                </div>
            </div>
            <div class="row" runat="server" id="TB1" style="padding-left: 2em; padding-right: 2em">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" AllowFilteringByColumn="True" PageSize="25">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                                HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IDA_G" DataType="System.Int32" FilterControlAltText="Filter IDA_G column"
                                HeaderText="IDA_G" ReadOnly="True" SortExpression="IDA_G" UniqueName="IDA_G" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FK_LCN_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_LCN_IDA column"
                                HeaderText="FK_LCN_IDA" ReadOnly="True" SortExpression="FK_LCN_IDA" UniqueName="FK_LCN_IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                                HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Newcode" DataType="System.Int32" FilterControlAltText="Filter Newcode column"
                                HeaderText="Newcode" ReadOnly="True" SortExpression="Newcode" UniqueName="Newcode" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                                HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RGTNO_DISPLAY" FilterControlAltText="Filter RGTNO_DISPLAY column"
                                HeaderText="เลขที่ทะเบียน" SortExpression="RGTNO_DISPLAY" UniqueName="RGTNO_DISPLAY">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                                HeaderText="เลขที่รับคำขอ" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                                HeaderText="ชื่อยา" ReadOnly="True" SortExpression="thadrgnm" UniqueName="thadrgnm">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                                HeaderText="ชื่อยา อังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="cncnm" FilterControlAltText="Filter cncnm column"
                                HeaderText="สถานะทะเบียน" SortExpression="cncnm" UniqueName="cncnm">
                            </telerik:GridBoundColumn>
                            <%--       <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HL_SELECT" runat="server">เลือกข้อมูล</asp:HyperLink>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                                CommandName="sel" Text="ดูรายละเอียด">
                                <HeaderStyle Width="70px" />
                            </telerik:GridButtonColumn>
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
    </div>

    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_head1" runat="server" Text="-"></asp:Label></h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f1" style="width: 100%; height: 800px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
</asp:Content>

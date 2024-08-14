<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_LCN_STAFF_DRUG_TRANSFER.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_STAFF_DRUG_TRANSFER" %>




<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_DD_HERB_1").searchable();
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
        function Popups2(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }
        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h3>คําขอโอนใบอนุญาต ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h3>
        </div>
    </div>

    <div class="row" id="T1" runat="server">

        <div style="height: 10px"></div>

        <div class="row">
            <div class="col-lg-12">
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
                    <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                        HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                    </telerik:GridBoundColumn>           
                    <telerik:GridBoundColumn DataField="FK_LCN" DataType="System.Int32" FilterControlAltText="Filter FK_LCN column"
                        HeaderText="FK_LCN" ReadOnly="True" SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PROCESS_ID" FilterControlAltText="Filter PROCESS_ID column"
                        HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="TRANSFER_NM" FilterControlAltText="Filter TRANSFER_NM column"
                                HeaderText="ผู้รับอนุญาต/ผู้โอน" ReadOnly="True" SortExpression="TRANSFER_NM" UniqueName="TRANSFER_NM">
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="TRANSFER_TO" FilterControlAltText="Filter TRANSFER_TO column"
                                HeaderText="ผู้รับโอน" ReadOnly="True" SortExpression="TRANSFER_TO" UniqueName="TRANSFER_TO">
                            </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="RCVNO_NEW" FilterControlAltText="Filter RCVNO_NEW column"
                        HeaderText="เลขรับที่" ReadOnly="True" SortExpression="RCVNO_NEW" UniqueName="RCVNO_NEW">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                           HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCNNO_NEW_DISPLAY" FilterControlAltText="Filter LCNNO_NEW_DISPLAY column"
                        HeaderText="เลขใบอนุญาต" ReadOnly="True" SortExpression="LCNNO_NEW_DISPLAY" UniqueName="LCNNO_NEW_DISPLAY" >
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="BUSINESS_PLACE_NAME" FilterControlAltText="Filter BUSINESS_PLACE_NAME column"
                        HeaderText="ชื่อสถานที่ประกอบธุรกิจ" ReadOnly="True" SortExpression="BUSINESS_PLACE_NAME" UniqueName="BUSINESS_PLACE_NAME" >
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_NAME_STAFF" FilterControlAltText="Filter STATUS_NAME_STAFF column"
                        HeaderText="สถานะ" ReadOnly="True" SortExpression="STATUS_NAME_STAFF" UniqueName="STATUS_NAME_STAFF" >
                    </telerik:GridBoundColumn>
                      <telerik:GridButtonColumn ButtonType="LinkButton" Text="ดูข้อมูล"
                                CommandName="HL_SELECT" UniqueName="HL_SELECT">
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

    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด คำขอ
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 800px;"></iframe>

                </div>
            </div>
        </div>
    </div>

    <div class=" modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_head1" runat="server" Text="รายละเอียด คำรับรอง"></asp:Label></h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f2" style="width: 100%; height: 800px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />

</asp:Content>


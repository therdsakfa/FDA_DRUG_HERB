<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_HERB_TABEAN_STAFF_TABEAN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_STAFF_TABEAN" %>

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

    <div class="row" style="text-align: center">
        <h3>รายการข้อมูลยื่นคำขอทะเบียน</h3>
    </div>
    <div class="panel panel-body" style="width: 100%; padding-left: 2%; padding-right: 2%;">
        <div class="row">
            <telerik:RadGrid ID="RadGrid1" runat="server"  AllowPaging="true" PageSize="25" Width="100%" AllowFilteringByColumn="True" >
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
                        <telerik:GridBoundColumn DataField="PROCESS_ID" FilterControlAltText="Filter PROCESS_ID column"
                            HeaderText="เลขกระบวนการ" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS_ID" FilterControlAltText="Filter STATUS_ID column"
                            HeaderText="สถานะเลข" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column" 
                            HeaderText="วันที่ยื่นคำขอ" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                            HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="rcvdate" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" 
                            HeaderText="วันที่รับคำขอ" SortExpression="rcvdate" UniqueName="rcvdate" DataFormatString="{0:dd/MM/yyyy}">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RCVNO_NEW" FilterControlAltText="Filter RCVNO_NEW column"
                            HeaderText="เลขรับ" SortExpression="RCVNO_NEW" UniqueName="RCVNO_FULL">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RGTNO_NEW" FilterControlAltText="Filter RGTNO_NEW column"
                            HeaderText="เลขทะเบียน" SortExpression="RGTNO_NEW" UniqueName="RGTNO_FULL">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LCN_ID" FilterControlAltText="Filter LCN_ID column"
                            HeaderText="เลขIDAของใบอนุญาต" SortExpression="LCN_ID" UniqueName="LCN_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LCNNO_NEW" FilterControlAltText="Filter LCNNO_NEW column"
                            HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_NEW" UniqueName="LCNNO_NEW">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LCN_NAME" FilterControlAltText="Filter LCN_NAME column"
                            HeaderText="ชื่อผู้รับอนุญาต" SortExpression="LCN_NAME" UniqueName="LCN_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                            HeaderText="ชื่อไทย" SortExpression="thadrgnm" UniqueName="NAME_THAI">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                            HeaderText="ชื่ออังกฤษ" SortExpression="engdrgnm" UniqueName="NAME_ENG">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                            HeaderText="สถานนะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="JJ_SELECT" 
                            CommandName="JJ_SELECT" Text="ดูข้อมูล">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                          <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="JJ_ADD_SELECT" 
                            CommandName="JJ_ADD_SELECT" Text="เพิ่มข้อมูล ทบ.๑">
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
    <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
</asp:Content>

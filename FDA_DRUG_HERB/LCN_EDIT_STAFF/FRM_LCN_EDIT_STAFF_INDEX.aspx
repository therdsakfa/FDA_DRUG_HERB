<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_LCN_EDIT_STAFF_INDEX.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_EDIT_STAFF_INDEX" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/css_rg_herb.css" rel="stylesheet" />
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
      <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <div class="row" style="text-align: center">
        <h3>รายการข้อมูลยื่นคำขอแก้ไขข้อมูลใบอนุญาต</h3>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Silk" HeaderStyle-Font-Size="Small" AllowFilteringByColumn="True">
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
                   <telerik:GridBoundColumn DataField="FK_LCN_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_LCN_IDA column" HeaderText="FK_LCN_IDA"
                           SortExpression="FK_LCN_IDA" UniqueName="FK_LCN_IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_LOCATION_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_LOCATION_IDA column" HeaderText="FK_LOCATION_IDA"
                           SortExpression="FK_LOCATION_IDA" UniqueName="FK_LOCATION_IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="LCNNO" FilterControlAltText="Filter LCNNO column"
                           HeaderText="เลขใบอนุญาต" SortExpression="LCNNO" UniqueName="LCNNO" HeaderStyle-Width="100px">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                           HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true" HeaderStyle-Width="100px">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="LCN_PROCESS_ID" FilterControlAltText="Filter LCN_PROCESS_ID column"
                           HeaderText="process_id" SortExpression="LCN_PROCESS_ID" UniqueName="LCN_PROCESS_ID" Display="false" AllowFiltering="true" HeaderStyle-Width="100px">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="LCN_NAME" FilterControlAltText="Filter LCN_NAME column"
                           HeaderText="ชื่อสถานที่" SortExpression="LCN_NAME" UniqueName="LCN_NAME" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="LCN_EDIT_REASON_TYPE" FilterControlAltText="Filter LCN_EDIT_REASON_TYPE column"
                           HeaderText="รหัสเหตุผลการขอแก้ไขใบอนุญาต" SortExpression="LCN_EDIT_REASON_TYPE" UniqueName="LCN_EDIT_REASON_TYPE" Display="false">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="LCN_EDIT_REASON_NAME" FilterControlAltText="Filter LCN_EDIT_REASON_NAME column"
                           HeaderText="เหตุผลการขอแก้ไขใบอนุญาต" SortExpression="LCN_EDIT_REASON_NAME" UniqueName="LCN_EDIT_REASON_NAME">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="FK_SUB_REASON_TYPE" FilterControlAltText="Filter FK_SUB_REASON_TYPE column"
                           HeaderText="รหัสupload_sub" SortExpression="FK_SUB_REASON_TYPE" UniqueName="FK_SUB_REASON_TYPE" Display="false">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="STATUS_GROUP" FilterControlAltText="Filter STATUS_GROUP column"
                           HeaderText="กลุ่มสถานะ" SortExpression="STATUS_GROUP" UniqueName="STATUS_GROUP" Display="false">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="STATUS_ID" FilterControlAltText="Filter STATUS_ID column"
                           HeaderText="รหัสสถานะ" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                       </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME" HeaderStyle-Width="100px">
                       </telerik:GridBoundColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="LCN_EDIT_DETAIL" HeaderText="ดูข้อมูล"
                        CommandName="LCN_EDIT_DETAIL" Text="ดูข้อมูล" ImageUrl="">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="SEE_DETAIL_SUB" HeaderText="ดูข้อมูล"
                        CommandName="SEE_DETAIL_SUB" Text="ดูรายละเอียดการแก้ไข" ImageUrl="">
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
                <iframe id="f1" style="width: 100%; height: 750px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
</asp:Content>

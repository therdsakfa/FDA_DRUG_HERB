<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_TABEAN_HERB_TEMPOLARY_STAFF.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_HERB_TEMPOLARY_STAFF" %>




<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link href="../css/css_radgrid.css" rel="stylesheet" />--%>
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //$(window).load(function () {
            //    $.ajax({
            //        type: 'POST',
            //        data: { submit: true },
            //        success: function (result) {
            //            $('#spinner').fadeOut(1);

            //        }
            //    });
            //});

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ContentPlaceHolder1_btn_upload').click(function () {
                Popups('POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx');
                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
        });

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f2'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function close_modal2() { // คำสั่งสั่งปิด PopUp
            $('#myModal2').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }
    </script>
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>


    <div class="h3" style="padding-left: 5%;">
        <asp:Label ID="lbl_name" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 70px">

            <div class="col-lg-10">
                <h4>การยื่นคำขออื่นๆ ตามการจัดเก็บเงินค่าคำขอ ผลิตภัณฑ์สมุนไพร</h4>
            </div>
        </div>
    </div>

    <div class="panel panel-body" style="width: 100%; padding-left: 1%;">
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="25" AllowFilteringByColumn="True" Width="100%">
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
                    <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                        HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="Name_Confirm" FilterControlAltText="Filter Name_Confirm column"
                        HeaderText="ผู้ยื่นคำขอ" ReadOnly="True" SortExpression="Name_Confirm" UniqueName="Name_Confirm">
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="RCVNO_FULL" FilterControlAltText="Filter RCVNO_FULL column"
                        HeaderText="เลขรับที่" ReadOnly="True" SortExpression="RCVNO_FULL" UniqueName="RCVNO_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Date_Confirm" FilterControlAltText="Filter Date_Confirm column"
                        HeaderText="ยื่นคำขอวันที่" ReadOnly="True" SortExpression="Date_Confirm" UniqueName="Date_Confirm" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                        HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID" >
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="Contact_Person" FilterControlAltText="Filter Contact_Person column"
                        HeaderText="ผู้มาติดต่อ" ReadOnly="True" SortExpression="Contact_Person" UniqueName="Contact_Person" >
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_NAME1" FilterControlAltText="Filter STATUS_NAME1 column"
                        HeaderText="สถานะ" ReadOnly="True" SortExpression="STATUS_NAME1" UniqueName="STATUS_NAME1" >
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                        CommandName="sel" Text="ดูข้อมูล">
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

    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียดคำขอ
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 800px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade " id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    เสนอลงนาม
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 800px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />

    &nbsp;
</asp:Content>


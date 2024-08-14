<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Auto_Menu.Master" CodeBehind="FRM_LCN_DRUG_TRANSFER.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_DRUG_TRANSFER" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font-size: 18px;
            line-height: 1.33;
            border-radius: 6px;
            padding: 10px 16px;
        }

        .auto-style2 {
            left: -118px;
            top: -313px;
        }
    </style>
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

            //$('#ContentPlaceHolder1_btn_upload').click(function () {
            //    var IDA = getQuerystring("IDA");
            //    var process = getQuerystring("process");
            //    Popups('POPUP_LCN_UPLOAD_ATTACH.aspx?IDA=' & IDA  & '&process=' & process & '');
            //    return false;
            //});

            //$('#ContentPlaceHolder1_btn_download').click(function () {
            //    Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
            //    return false;
            //});

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }




            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');

            });

        });
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f3'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function Popups4(url) { // สำหรับทำ Div Popup

            $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f4'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }
        function closespinner() {
            alert('Download เสร็จสิ้น');
            $('#spinner').fadeOut('slow');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>

    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>

    <div class="h3" style="padding-left: 5%;"></div>

    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 80px">

            <div class="col-lg-6 col-md-3">
                <h3>คำขอโอนใบอนุญาต </h3>
                <h4>ใบอนุญาต<asp:Label ID="lbl_name" runat="server" Text=""></asp:Label><asp:Label ID="lbl_name_2" runat="server" Text="">
                </asp:Label>
                </h4>
            </div>

            <div class="col-lg-3 col-md-6" style="margin-top: 10px">
            </div>
            <div class="col-lg-3 col-md-3">
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มคำขอ" CssClass="auto-style1" Height="45px" Width="200px" />
                <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />
                <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" />
            </div>
        </div>

    </div>

    <div class="panel panel-body" style="width: 100%; padding-left: 5%;">
        <table style="width: 100%;">
            <tr>
                <td align="right">
                    <asp:Label ID="lbl_remark" runat="server" Text="*หมายเหตุ เมื่ออัพโหลดคำขออนุญาตผลิตยาแผนปัจจุบันแล้ว ให้ทำการเพิ่มหมวดยาจึงจะสามารถส่งคำขอได้" Style="display: none;"></asp:Label>
                </td>
            </tr>
        </table>

        <div style="height: 3px"></div>
        <div class="row">
            <div class="col-lg-2">
                <p class="h4">ข้อมุล</p>
            </div>
            <div class="col-lg-8">
            </div>
            <%--   <div class="col-lg-2">
                <asp:Button ID="Button2" runat="server" Text="เพิ่มคำขอ" CssClass="auto-style1" Height="45px" Width="200px" />
            </div>--%>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15">
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
                            <telerik:GridBoundColumn DataField="STATUS_ID" FilterControlAltText="Filter STATUS_ID column"
                                HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PROCESS_ID" FilterControlAltText="Filter PROCESS_ID column"
                                HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FK_LCN" FilterControlAltText="Filter FK_LCN column"
                                HeaderText="FK_LCN" ReadOnly="True" SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TRANSFER_NM" FilterControlAltText="Filter TRANSFER_NM column"
                                HeaderText="ผู้รับอนุญาต/ผู้โอน" ReadOnly="True" SortExpression="TRANSFER_NM" UniqueName="TRANSFER_NM">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TRANSFER_TO" FilterControlAltText="Filter TRANSFER_TO column"
                                HeaderText="ผู้รับโอน" ReadOnly="True" SortExpression="TRANSFER_TO" UniqueName="TRANSFER_TO">
                            </telerik:GridBoundColumn>
                            <%--     <telerik:GridBoundColumn DataField="PHR_NAME" FilterControlAltText="Filter PHR_NAME column"
                                HeaderText="ชื่อผู้มีหน้าที่ปฏิบัติการ" ReadOnly="True" SortExpression="PHR_NAME" UniqueName="PHR_NAME">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="LCNNO_NEW_DISPLAY" FilterControlAltText="Filter LCNNO_NEW_DISPLAY column"
                                HeaderText="เลขใบอนุญาต" ReadOnly="True" SortExpression="LCNNO_NEW_DISPLAY" UniqueName="LCNNO_NEW_DISPLAY">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BUSINESS_PLACE_NAME" FilterControlAltText="Filter BUSINESS_PLACE_NAME column"
                                HeaderText="ชื่อสถานที่ประกอบธุรกิจ" ReadOnly="True" SortExpression="BUSINESS_PLACE_NAME" UniqueName="BUSINESS_PLACE_NAME">
                            </telerik:GridBoundColumn>
                            <%--       <telerik:GridBoundColumn DataField="OPENTIME" FilterControlAltText="Filter OPENTIME column"
                                HeaderText="เวลาทำการ" ReadOnly="True" SortExpression="OPENTIME" UniqueName="OPENTIME">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                                HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                                HeaderText="สถานะ" ReadOnly="True" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" Text="ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
                                CommandName="HL_SELECT" UniqueName="HL_SELECT">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย"
                                CommandName="HL3_SELECT" UniqueName="HL3_SELECT">
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
    <div class="h5" style="padding-left: 87%;">
        <asp:HyperLink ID="hl_pay" runat="server" Target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
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
    <asp:Button ID="Button2" runat="server" Text="reload" Style="display: none" />


</asp:Content>

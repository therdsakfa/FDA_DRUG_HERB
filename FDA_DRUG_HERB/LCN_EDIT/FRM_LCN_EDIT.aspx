<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_LCN_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_EDIT" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            //$('#ContentPlaceHolder1_btn_upload').click(function () {
            //    var IDA = getQuerystring("rgt_ida");
            //    //var FK_IDA = getQuerystring("FK_IDA");
            //    var lcn_ida = getQuerystring("lcn_ida");
            //    var process = getQuerystring("process");
            //    //  $('#spinner').toggle('slow');
            //    //Popups('POPUP_DH_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
            //    Popups('FRM_SUBSTITUTE_UPLOAD.aspx?rgt_ida=' + IDA + '&process=' + process + '&lcn_ida=' + lcn_ida);
            //    return false;
            //});

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');

            });

            function Popups(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }


        });
        function getQuerystring(key, default_) {
            if (default_ == null) default_ = "";
            key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
            var qs = regex.exec(window.location.href);
            if (qs == null)
                return default_;
            else
                return qs[1];
        }
        function Popups2(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
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
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>


    <div class="h3" style="padding-left: 5%;">
        <asp:Label ID="lbl_name" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div class="panel" style="text-align: left; width: 100%">
        <div style="height: 110px">
            <%-- <div class="row">
                 <div  class="col-lg-1"><h4> คำขอใบแทน </h4></div>
                 <div  class="col-lg-1">
                     <asp:Label ID="Label2" runat="server" Text="-"></asp:Label></div>
                <div  class="col-lg-10"></div>
            </div>--%>
            <%-- <div  class="col-lg-4-1"><h4> คำขอใบแทน 
                 <asp:Label ID="lbl_rgtno" runat="server" Text="-"></asp:Label>
                 </h4> </div>--%>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <h3>คำขอแก้ไขใบอนุญาต </h3>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-2"></div>
                <div class="col-lg-2" style="text-align: right">
                    <%-- <asp:Label ID="Label1" runat="server" Text="เลขที่ใบอนุญาต" CssClass="btn-lg"></asp:Label>--%>
                </div>
                <div class="col-lg-2">
                    <%-- <telerik:RadComboBox ID="rcb_search" Runat="server" Filter="Contains"></telerik:RadComboBox>--%>
                </div>

                <div class="col-lg-1"></div>
                <asp:Button ID="Button4" runat="server" Text="" Style="display: none;" />
                <asp:Button ID="Button5" runat="server" Text="" Style="display: none;" />
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">ใบอนุญาตเลขที่:</div>
                <div class="col-lg-2">
                    <asp:Label ID="TXT_LCNNO" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-1">ชื่อสถานที่:</div>
                <div class="col-lg-3">
                    <asp:Label ID="TXT_LCB_NAME" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-1">
                    <asp:Button ID="SUB_ADD" runat="server" Text="ขอแก้ไขใบอนุญาต" CssClass="btn-lg" />
                </div>
            </div>

        </div>

    </div>

    <div class="panel panel-body" style="width: 100%; padding-left: 5%;">
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
            <MasterTableView AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                        SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCNNO" FilterControlAltText="Filter LCNNO column"
                        HeaderText="เลขใบอนุญาต" SortExpression="LCNNO" UniqueName="LCNNO">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCN_PROCESS_ID" FilterControlAltText="Filter LCN_PROCESS_ID column"
                        HeaderText="เลขกระบวนการ" SortExpression="LCN_PROCESS_ID" UniqueName="LCN_PROCESS_ID" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                        HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCN_EDIT_REASON_TYPE" FilterControlAltText="Filter LCN_EDIT_REASON_TYPE column"
                        HeaderText="รหัสเหตุผลการขอแก้ไขใบอนุญาต" SortExpression="LCN_EDIT_REASON_TYPE" UniqueName="LCN_EDIT_REASON_TYPE" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCN_EDIT_REASON_NAME" FilterControlAltText="Filter LCN_EDIT_REASON_NAME column"
                        HeaderText="เหตุผล" SortExpression="LCN_EDIT_REASON_NAME" UniqueName="LCN_EDIT_REASON_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column" HeaderText="STATUS_ID"
                        SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                        HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ตรวจสอบรายละเอียด และกดยื่นคำขอ"
                        CommandName="HL_SELECT" UniqueName="HL_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="DETAIL" HeaderText=""
                        CommandName="DETAIL" Text="ดูข้อมูล" ImageUrl="">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="LCN_EDIT_DETAIL" HeaderText=""
                        CommandName="LCN_EDIT_DETAIL" Text="แก้ไขเอกสาร อัพโหลด" ImageUrl="">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย"
                        CommandName="HL3_SELECT" UniqueName="HL3_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="PV_SELECT" runat="server" Font-Underline="true" ForeColor="Blue">ตัวอย่างเอกสารแก้ไข</asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <div class="h5" style="padding-left: 87%;">
            <asp:HyperLink ID="hl_pay" runat="server" Target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
        </div>
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

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />

</asp:Content>

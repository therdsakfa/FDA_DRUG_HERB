<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_TABEAN_HERB_DONATE_STAFF.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_HERB_DONATE_STAFF" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link href="../css/css_radgrid.css" rel="stylesheet" />--%>
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

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

            <div class="col-lg-4 col-md-4">
                <h4>คำขอผลิตภัณฑ์สมุนไพรเพื่อบริจาค</h4>
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
                    <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                        HeaderText="PROCESS_ID" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="IDA_DR" DataType="System.Int32" FilterControlAltText="Filter IDA_DR column"
                        HeaderText="IDA_DR" SortExpression="IDA_DR" UniqueName="IDA_DR" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_LCN" DataType="System.Int32" FilterControlAltText="Filter FK_LCN column"
                        HeaderText="FK_LCN" SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                        HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RCVNO_NEW" FilterControlAltText="Filter RCVNO_NEW column"
                        HeaderText="เลขรับที่" SortExpression="RCVNO_NEW" UniqueName="RCVNO_NEW">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column"
                        HeaderText="วันที่ยื่นคำขอ" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="rcvdate" FilterControlAltText="Filter rcvdate column"
                        HeaderText="วันที่รับคำขอ" ReadOnly="True" SortExpression="rcvdate" UniqueName="rcvdate" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                        HeaderText="เลขที่รับแจ้ง" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DONATE_FULLNAME" FilterControlAltText="Filter DONATE_FULLNAME column"
                        HeaderText="ชื่อผู้นำเข้า" ReadOnly="True" SortExpression="DONATE_FULLNAME" UniqueName="DONATE_FULLNAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PRODUCT_DONATE_NM" FilterControlAltText="Filter PRODUCT_DONATE_NM column"
                        HeaderText="ชื่อผลิตภัณฑ์" ReadOnly="True" SortExpression="PRODUCT_DONATE_NM" UniqueName="PRODUCT_DONATE_NM">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                        HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                        CommandName="sel" Text="ดูข้อมูล">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                </Columns>
            </MasterTableView>
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

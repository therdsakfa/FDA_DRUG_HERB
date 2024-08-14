<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="FRM_HERB_TABEAN_EX.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_EX" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UC/UC_Information.ascx" TagPrefix="uc1" TagName="UC_Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <br />
    <br />
    <br />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h2 style="color: #2A2A2A">แบบแจ้งผลิตหรือนาเข้าผลิตภัณฑ์สมุนไพรเพื่อเป็นตัวอย่าง สาหรับการขึ้นทะเบียน การแจ้งรายละเอียด หรือการจดแจ้ง</h2>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="text-align: right; padding-left: 2em">
            <uc1:UC_Information runat="server" ID="UC_Information" />
            <div class="col-lg-1"></div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12" style="text-align: right">
            <asp:Button ID="btn_ex_add" runat="server" Text="เพิ่มคำขอตัวอย่าง" Visible="true" Height="40px" Width="202px" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-11">
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
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                            HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LCN_IDA" DataType="System.Int32" FilterControlAltText="Filter LCN_IDA column"
                            HeaderText="LCN_IDA" ReadOnly="True" SortExpression="LCN_IDA" UniqueName="LCN_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                            HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                            HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                            HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EX_DATE_CONFIRM" DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter EX_DATE_CONFIRM column"
                            HeaderText="วันที่ส่งเรื่อง" SortExpression="EX_DATE_CONFIRM" UniqueName="EX_DATE_CONFIRM">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="rcvno" FilterControlAltText="Filter rcvno column"
                            HeaderText="เลขที่รับที่" SortExpression="rcvno" UniqueName="rcvno">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EX_NAME_PRODUCT" FilterControlAltText="Filter EX_NAME_PRODUCT column" HeaderText="ชื่อผลิตภัณฑ์" ReadOnly="True" SortExpression="EX_NAME_PRODUCT" UniqueName="EX_NAME_PRODUCT">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                            HeaderText="รหัสดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="ดูรายละเอียด"
                            CommandName="HL_SELECT" UniqueName="HL_SELECT">
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="แก้ไข"
                            CommandName="HL_EDIT" UniqueName="HL_EDIT">
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย 1 "
                            CommandName="HL3_SELECT" UniqueName="HL3_SELECT">
                        </telerik:GridButtonColumn>
                        <%--  <telerik:GridTemplateColumn>
                            <ItemTemplate>
                                <asp:HyperLink ID="HL_SELECT2" runat="server">เลือกข้อมูล</asp:HyperLink>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>

               <%-- <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>--%>

                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
            <div class="h5" style="padding-left: 87%;">
                <asp:HyperLink ID="hl_pay" runat="server" Target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
            </div>
        </div>
    </div>

    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_head1" runat="server" Text="รายละเอียด คำขอ"></asp:Label></h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f1" style="width: 100%; height: 800px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />
</asp:Content>

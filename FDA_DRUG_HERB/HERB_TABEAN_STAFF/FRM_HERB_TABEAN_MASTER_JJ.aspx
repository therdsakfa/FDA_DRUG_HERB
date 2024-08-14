<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_HERB_TABEAN_MASTER_JJ.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_MASTER_JJ" %>

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
        };

        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        };

        function Popups2(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div class="row" style="text-align: center">
        <h3>ฐานข้อมูลจดแจ้ง</h3>
    </div>

    <div class="row" style="text-align: center">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="width: 20%; text-align: right">เลือกประเภท</div>
        <div class="col-lg-6" style="width: 40%; text-align: center">
            <asp:DropDownList ID="DD_HERB" runat="server" AutoPostBack="true">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="20301">การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาแผนไทย</asp:ListItem>
                <asp:ListItem Value="20302">การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาตามองค์ความรู้การแพทย์ทางเลือก</asp:ListItem>
                <asp:ListItem Value="20303">การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร</asp:ListItem>
                <asp:ListItem Value="20304">การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ</asp:ListItem>
                <asp:ListItem Value="20306">การจดแจ้งผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร (มีสารช่วย)</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" runat="server" style="text-align: right">
        <div class="col-lg-9"></div>
        <div class="col-lg-2">
            <asp:Button ID="btn_add_name_jj" runat="server" Text="เพิ่มชื่อยา" />
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="panel panel-body" style="width: 100%; padding-left: 2%;">
        <div class="row" style="text-align: center">
            <h3>รายการข้อมูลจดแจ้ง</h3>
        </div>

        <div class="row">
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="20" AllowFilteringByColumn="True" Width="100%">
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
                        <telerik:GridBoundColumn DataField="HERB_ID" DataType="System.Int32" FilterControlAltText="Filter HERB_ID column"
                            HeaderText="HERB_ID" ReadOnly="True" SortExpression="HERB_ID" UniqueName="HERB_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                            HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HERB_NAME" FilterControlAltText="Filter HERB_NAME column"
                            HeaderText="ชื่อผลิตภัณฑ์" SortExpression="HERB_NAME" UniqueName="HERB_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_THAI" FilterControlAltText="Filter NAME_THAI column"
                            HeaderText="ชื่อตามประกาศจดแจ้ง" SortExpression="NAME_THAI" UniqueName="NAME_THAI">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PROCESS_NAME" FilterControlAltText="Filter PROCESS_NAME column"
                            HeaderText="ประเภท" SortExpression="PROCESS_NAME" UniqueName="PROCESS_NAME">
                        </telerik:GridBoundColumn>

                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="JJ_SELECT"
                            CommandName="JJ_EDIT" Text="แก้ไขชื่อ">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="JJ_SELECT"
                            CommandName="JJ_SELECT" Text="เลือกข้อมูล">
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
    <hr />

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

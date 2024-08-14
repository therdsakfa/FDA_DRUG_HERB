<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_HERB_TABEAN_JJ.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ" %>

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
    <div class="row" runat="server" style="text-align: center">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="width: 20%; text-align: right">
            <label id="herb_ya" runat="server" visible="false">เลือกชื่อยา</label>
        </div>
        <div class="col-lg-6" style="width: 40%; text-align: center">
            <asp:DropDownList ID="DD_HERB_NAME_PRODUCT" runat="server" DataValueField="HERB_ID" DataTextField="HERB_NAME_DD" Visible="false"></asp:DropDownList>
            <asp:DropDownList ID="DD_HERB_NAME_PRODUCT_HEALTH" runat="server" DataValueField="ID" DataTextField="PRODUCT_NAME" Visible="false"></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="width: 20%; text-align: left">
            <asp:Button ID="btn_jj_herb" runat="server" Text="เพิ่มคำขอจดแจ้ง" Visible="false" />
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
    <div class="row" id="T1" runat="server">

        <p class="h3">ข้อมุล</p>
        <hr />
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
                    <telerik:GridBoundColumn DataField="IDA_LCN" DataType="System.Int32" FilterControlAltText="Filter IDA_LCN column"
                        HeaderText="IDA_LCN" ReadOnly="True" SortExpression="IDA_LCN" UniqueName="IDA_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID_LCN" DataType="System.Int32" FilterControlAltText="Filter TR_ID_LCN column"
                        HeaderText="TR_ID_LCN" ReadOnly="True" SortExpression="TR_ID_LCN" UniqueName="TR_ID_LCN" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_IDA_LCT" DataType="System.Int32" FilterControlAltText="Filter FK_IDA_LCT column"
                        HeaderText="FK_IDA_LCT" ReadOnly="True" SortExpression="FK_IDA_LCT" UniqueName="FK_IDA_LCT" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DD_HERB_NAME_ID" DataType="System.Int32" FilterControlAltText="Filter DD_HERB_NAME_ID column"
                        HeaderText="DD_HERB_NAME_ID" ReadOnly="True" SortExpression="DD_HERB_NAME_ID" UniqueName="DD_HERB_NAME_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DDHERB" DataType="System.Int32" FilterControlAltText="Filter DDHERB column"
                        HeaderText="DDHERB" ReadOnly="True" SortExpression="DDHERB" UniqueName="DDHERB" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID_JJ" DataType="System.Int32" FilterControlAltText="Filter TR_ID_JJ column"
                        HeaderText="เลขที่ดำเนินการ" ReadOnly="True" SortExpression="TR_ID_JJ" UniqueName="TR_ID_JJ">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCNNO" FilterControlAltText="Filter LCNNO column"
                        HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO" UniqueName="LCNNO">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RCVNO_FULL" FilterControlAltText="Filter RCVNO_FULL column"
                        HeaderText="เลขรับ" ReadOnly="True" SortExpression="RCVNO_FULL" UniqueName="RCVNO_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                        HeaderText="เลขทะเบียน" ReadOnly="True" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL" Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column"
                        HeaderText="วันที่ส่งเรื่อง" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LCN_NAME" FilterControlAltText="Filter LCN_NAME column"
                        HeaderText="ชื่อผู้รับ" ReadOnly="True" SortExpression="LCN_NAME" UniqueName="LCN_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JJ_NAME_FULL" FilterControlAltText="Filter JJ_NAME_FULL column"
                        HeaderText="ชื่อไทย" SortExpression="JJ_NAME_FULL" UniqueName="JJ_NAME_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                        HeaderText="สถานนะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="HL_SELECT" runat="server">ดูรายละเอียด</asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>--%>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ดูข้อมูล"
                        CommandName="HL_SELECT" UniqueName="HL_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="จจ.1"
                        CommandName="HL1_SELECT" UniqueName="HL1_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="จจ.2"
                        CommandName="HL2_SELECT" UniqueName="HL2_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย"
                        CommandName="HL3_SELECT" UniqueName="HL3_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="HL4_SELECT" runat="server">ชำระเงิน</asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <%-- <telerik:GridButtonColumn ButtonType="LinkButton" Text="ชำระเงิน"
                        CommandName="HL4_SELECT" UniqueName="HL4_SELECT">
                    </telerik:GridButtonColumn>--%>
                    <%--<telerik:GridButtonColumn ButtonType="LinkButton" Text="จจ.1"
                        CommandName="JJ1_SELECT" UniqueName="HL_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="จจ.2"
                        CommandName="JJ2_SELECT" UniqueName="HL_SELECT">
                    </telerik:GridButtonColumn>--%>
                </Columns>

                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>

                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>

            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

            <FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
        <div class="h5" style="padding-left: 87%;">
            <asp:HyperLink ID="hl_pay" runat="server" Target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
        </div>
    </div>

    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_head1" runat="server" Text="รายละเอียด คำขอจดแจ้ง"></asp:Label></h1>
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

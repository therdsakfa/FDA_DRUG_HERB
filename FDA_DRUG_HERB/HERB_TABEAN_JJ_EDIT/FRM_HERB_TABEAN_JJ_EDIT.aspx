<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="FRM_HERB_TABEAN_JJ_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_EDIT1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <script type="text/javascript">

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
            //    alert('123456');
            $('#spinner').toggle('slow');

        }

        function closespinner() {
            alert('Download เสร็จสิ้น');
            $('#spinner').fadeOut('slow');
            $('#ContentPlaceHolder1_Button1').click();
        }

        function CloseSpin() {
            $('#spinner').toggle('slow');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 70px">

            <div class="col-lg-3 col-md-3">
                <h4>แก้ไขเปลี่ยนแปลงจดแจ้ง<asp:Label ID="lbl_name_2" runat="server" Text=""></asp:Label><asp:Label ID="lbl_name" runat="server" Text="">
                </asp:Label>
                </h4>
            </div>
            <div class="col-lg-3 col-md-3" style="margin-top: 10px">
                <p style="text-align: right; padding-right: 3%;">
                    <%--   เลขบัตรผู้ดำเนินฯ--%>
                </p>
            </div>
            <div class="col-lg-3 col-md-3" style="margin-top: 10px">
                <%-- <asp:TextBox ID="txt_bsn" runat="server"></asp:TextBox>--%>
            </div>
            <div class="col-lg-3 col-md-3">
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มคำขอแก้ไขจดแจ้ง" CssClass="auto-style1" Height="45px" Width="200px" />
                <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />
                <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" />
            </div>
        </div>
    </div>

    <div style="width: 100%; padding-left: 1%;">
        <div class="row">
            <div class="col-lg-11">
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
                            <telerik:GridBoundColumn DataField="IDA_LCT" DataType="System.Int32" FilterControlAltText="Filter IDA_LCT column"
                                HeaderText="IDA_LCT" ReadOnly="True" SortExpression="IDA_LCT" UniqueName="IDA_LCT" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter F  K_IDA column"
                                HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DD_HERB_NAME_ID" DataType="System.Int32" FilterControlAltText="Filter DD_HERB_NAME_ID column"
                                HeaderText="DD_HERB_NAME_ID" ReadOnly="True" SortExpression="DD_HERB_NAME_ID" UniqueName="DD_HERB_NAME_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DDHERB" DataType="System.Int32" FilterControlAltText="Filter DDHERB column"
                                HeaderText="DDHERB" ReadOnly="True" SortExpression="DDHERB" UniqueName="DDHERB" Display="false">
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
                            <telerik:GridBoundColumn DataField="TR_ID_JJ" DataType="System.Int32" FilterControlAltText="Filter TR_ID_JJ column"
                                HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID_JJ" UniqueName="TR_ID_JJ">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                                HeaderText="เลขทะเบียน" ReadOnly="True" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column"
                                HeaderText="วันที่ยื่นคำขอ" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LCN_NAME" FilterControlAltText="Filter LCN_NAME column"
                                HeaderText="ชื่อผู้รับ" ReadOnly="True" SortExpression="LCN_NAME" UniqueName="LCN_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NAME_THAI" FilterControlAltText="Filter fulladdr column"
                                HeaderText="ชื่อไทย" SortExpression="NAME_THAI" UniqueName="NAME_THAI">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                                HeaderText="สถานนะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" Text="ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
                                CommandName="HL_SELECT" UniqueName="HL_SELECT">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย"
                                CommandName="HL3_SELECT" UniqueName="HL3_SELECT">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย 2"
                                CommandName="HL4_SELECT" UniqueName="HL4_SELECT">
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
            <div class="col-lg-1"></div>
        </div>


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
</asp:Content>

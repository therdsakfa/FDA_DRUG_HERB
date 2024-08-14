<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_HERB_TABEAN.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <div class="row" style="text-align: center">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="text-align: right">
            เลือกคำขอ
        </div>
        <div class="col-lg-8" style="text-align: center">
            <asp:RadioButtonList ID="R_DD_HERB" runat="server" RepeatDirection="horizontal" Width="100%" AutoPostBack="true">
                <asp:ListItem Value="1">คำขอขึ้นทะเบียน</asp:ListItem>
                <asp:ListItem Value="2">คำขอขึ้นทะเบียน เพื่อส่งออก</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="text-align: center">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="width: 20%; text-align: right" id="dd_type" runat="server" visible="false">เลือกประเภท</div>
        <div class="col-lg-6" style="width: 40%; text-align: center">
            <asp:DropDownList ID="DD_HERB" runat="server" DataValueField="ID" DataTextField="DD_HERB_NAME" BackColor="White" SkinID="bootstrap" Visible="false" AutoPostBack="true"></asp:DropDownList>

            <%--           <asp:DropDownList ID="DD_HERB" runat="server" AutoPostBack="true" Visible="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="20101">การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาแผนไทย</asp:ListItem>
                <asp:ListItem Value="20102">การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาตามองค์ความรู้การแพทย์ทางเลือก</asp:ListItem>
                <asp:ListItem Value="20103">การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร</asp:ListItem>
                <asp:ListItem Value="20104">การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DD_HERB_OUT" runat="server" AutoPostBack="true" Visible="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="20901">การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาแผนไทย  เพื่อส่งออก</asp:ListItem>
                <asp:ListItem Value="20902">การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาตามองค์ความรู้การแพทย์ทางเลือก  เพื่อส่งออก</asp:ListItem>
                <asp:ListItem Value="20903">การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทยาพัฒนาจากสมุนไพร  เพื่อส่งออก</asp:ListItem>
                <asp:ListItem Value="20904">การขึ้นทะเบียนผลิตภัณฑ์สมุนไพร ประเภทผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ  เพื่อส่งออก</asp:ListItem>
            </asp:DropDownList>--%>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" runat="server" id="TH1">
        <div class="col-lg-6" style="width: 40%">
        </div>
        <div class="col-lg-5" style="width: 20%; text-align: left">
            <asp:Button ID="btn_tb_herb" runat="server" Text="เพิ่มคำขอทะเบียน" Visible="false" />
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
    <div class="row" id="T1" runat="server">

        <p class="h3">ข้อมูลทะเบียน</p>
        <hr />
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="25">
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
                    <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                        HeaderText="TR_ID" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FK_LCN_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_LCN_IDA column"
                        HeaderText="FK_LCN_IDA" ReadOnly="True" SortExpression="FK_LCN_IDA" UniqueName="FK_LCN_IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column"
                        HeaderText="PROCESS_ID" ReadOnly="True" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                        HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DATE_CONFIRM" DataType="System.DateTime" FilterControlAltText="Filter DATE_CONFIRM column"
                        HeaderText="วันที่ส่งเรื่อง" SortExpression="DATE_CONFIRM" UniqueName="DATE_CONFIRM" DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RCVNO_FULL" FilterControlAltText="Filter RCVNO_FULL column"
                        HeaderText="เลขรับ" ReadOnly="True" SortExpression="RCVNO_FULL" UniqueName="RCVNO_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                        HeaderText="เลขทะเบียน" ReadOnly="True" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                        HeaderText="ชื่อไทย" SortExpression="thadrgnm" UniqueName="thadrgnm">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                        HeaderText="ชื่ออังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                        HeaderText="สถานนะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ดูรายละเอียด"
                        CommandName="HL_SELECT" UniqueName="HL_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ทบ1"
                        CommandName="HL1_SELECT" UniqueName="HL1_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ทบ2"
                        CommandName="HL2_SELECT" UniqueName="HL2_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย 1 "
                        CommandName="HL3_SELECT" UniqueName="HL3_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย 2 "
                        CommandName="HL4_SELECT" UniqueName="HL4_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="HL5_SELECT" runat="server">ใบสั่งชำระ</asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

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

    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>
                    <asp:Label ID="lbl_head1" runat="server" Text="รายละเอียดทะเบียน"></asp:Label></h1>
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

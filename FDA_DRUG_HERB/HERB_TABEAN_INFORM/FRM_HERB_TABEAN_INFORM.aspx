<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="FRM_HERB_TABEAN_INFORM.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_INFORM" %>



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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<%--    <div class="row" style="text-align: center">
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
    </div>--%>
    <div class="row" style="text-align: center">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="width: 20%; text-align: right" ID="dd_type" runat="server" >เลือกประเภท</div>
        <div class="col-lg-6" style="width: 40%; text-align: center">
            <asp:DropDownList ID="DD_HERB" runat="server" DataValueField="ID" DataTextField="DD_HERB_NAME" BackColor="White"  SkinID="bootstrap" AutoPostBack="true"></asp:DropDownList>
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
          <%--        <asp:DropDownList ID="DD_HERB_NAME_PRODUCT_HEALTH" runat="server" AutoPostBack="true"  Visible="false">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <asp:ListItem Value="1">ชื่อยา1</asp:ListItem>
                <asp:ListItem Value="2">ชื่อยา2</asp:ListItem>
            </asp:DropDownList>--%>
        </div>
        <div class="col-lg-2" style="width: 20%; text-align: left">
            <%--<asp:Button ID="btn_jj_herb" runat="server" Text="เพิ่มคำขอจดแจ้ง" Visible="false" />--%>
             <asp:Button ID="btn_tb_herb" runat="server" Text="เพิ่มคำขอทะเบียนรับแจ้ง" Visible="false" />
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
  <%--  <div class="row" runat="server" id="TH1">
        <div class="col-lg-6" style="width: 40%">
        </div>
        <div class="col-lg-5" style="width: 20%; text-align: left" >        
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />--%>
    <div class="row" id="T1" runat="server">

        <p class="h3">ข้อมูลทะเบียนแจ้งรายละเอียด</p>
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
                    <telerik:GridBoundColumn DataField="FK_LCN" DataType="System.Int32" FilterControlAltText="Filter FK_LCN column"
                        HeaderText="FK_LCN" ReadOnly="True" SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false">
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
                    <telerik:GridBoundColumn DataField="RCVNO_NEW" FilterControlAltText="Filter RCVNO_NEW column"
                        HeaderText="เลขรับ" ReadOnly="True" SortExpression="RCVNO_NEW" UniqueName="RCVNO_NEW">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Register_No" FilterControlAltText="Filter Register_No column"
                        HeaderText="เลขทะเบียน" ReadOnly="True" SortExpression="Register_No" UniqueName="Register_No">
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
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="จร1"
                        CommandName="HL1_SELECT" UniqueName="HL1_SELECT">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" Text="จร2"
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
                            <asp:HyperLink ID="HL5_SELECT" runat="server">ชำระเงิน</asp:HyperLink>
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
          <div class="h5" style="padding-left: 87%;">
            <asp:HyperLink ID="hl_pay" runat="server" Target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
        </div>
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


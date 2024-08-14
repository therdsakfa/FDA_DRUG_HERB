<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_ppk.Master" CodeBehind="FRM_TABEAN_HERB_EXHIBITION.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_TABEAN_HERB_EXHIBITION" %>


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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="panel panel-body" style="width: 100%;height: 780px; padding-left: 2%;">
         <div class="panel-heading panel-title" style="height: 70px">
            <p class="h3" style="text-align: left; border-bottom: 3px solid gray;"><span style="color: rgb(102, 102, 102); font-family: SUKHUMVIT; font-size: 30px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 500; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">แบบแจ้งการผลิตหรือนำเข้าผลิตภัณฑ์สมุนไพรเพื่อการแสดงนิทรรศการ</span></p>
         </div>
         <div style="padding-top: 30px"></div>
<%--    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>แบบแจ้งการผลิตหรือนำเข้าผลิตภัณฑ์สมุนไพรเพื่อการแสดงนิทรรศการ</h3>
        </div>
    </div>--%>

    <div class="row">
        <div class="col-lg-12" style="text-align: right;padding-left:2em;padding-right:2em"">
            <asp:Button ID="btn_add_tabean" runat="server" Text="เพิ่มคำขอผลิตภัณฑ์"  Height="40px" Width="155px" />
            <asp:Button ID="Button1" runat="server" Text="reload" Style="display: none" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12" style="padding-left:2em;padding-right:2em">
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="12">
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
                            HeaderText="เลขดำเนินการ" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column"
                            HeaderText="STATUS_ID" ReadOnly="True" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RCVNO_NEW"  FilterControlAltText="Filter RCVNO_NEW column"
                            HeaderText="เลขที่รับคำขอ" ReadOnly="True" SortExpression="RCVNO_NEW" UniqueName="RCVNO_NEW">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RGTNO_FULL" FilterControlAltText="Filter RGTNO_FULL column"
                            HeaderText="เลขที่ทะเบียน" SortExpression="RGTNO_FULL" UniqueName="RGTNO_FULL">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EXHIBITION_FULLNAME" FilterControlAltText="Filter EXHIBITION_FULLNAME column" 
                            HeaderText="ชื่อผู้นำเข้า" ReadOnly="True" SortExpression="EXHIBITION_FULLNAME" UniqueName="EXHIBITION_FULLNAME">
                        </telerik:GridBoundColumn> 
                        <telerik:GridBoundColumn DataField="EXHIBITION_NOUN" FilterControlAltText="Filter EXHIBITION_NOUN column" 
                            HeaderText="นำเข้าในนาม" ReadOnly="True" SortExpression="EXHIBITION_NOUN" UniqueName="EXHIBITION_NOUN">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PRODUCT_EXHIBITION_NM" FilterControlAltText="Filter PRODUCT_EXHIBITION_NM column" 
                            HeaderText="ชื่อผลิตภัณฑ์" ReadOnly="True" SortExpression="PRODUCT_EXHIBITION_NM" UniqueName="PRODUCT_EXHIBITION_NM">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column" 
                            HeaderText="สะถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="ตรวจสอบ/แก้ไขรายละเอียด และกดยื่นคำขอ"
                            CommandName="HL_SELECT" UniqueName="HL_SELECT">
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="ใบนัดหมาย"
                            CommandName="HL2_SELECT" UniqueName="HL2_SELECT">
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
                    <asp:Label ID="lbl_head1" runat="server" Text="รายละเอียด คำขอ"></asp:Label></h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f2" style="width: 100%; height: 800px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />    
</asp:Content>

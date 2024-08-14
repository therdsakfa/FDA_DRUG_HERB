<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_HERB_WHO_STAFF_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_WHO_STAFF_ADD" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UC/UC_INFMT.ascx" TagPrefix="uc1" TagName="UC_INFMT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        function spin_space() { // คำสั่งสั่งปิด PopUp
            $('#spinner').toggle('slow');
        }

        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 180px">
            <div class="row">
                <div class="col-lg-4">
                    <h4>ระบบการรับจ้างผลิต</h4>
                    <div class="h3" style="padding-left: 2%;"></div>
                    <br />

                    <%--  Test     <uc1: UC_INFMT runat="server" id="UC_INFMT" />  --%>
                </div>
            </div>  
            <div class="row">
                <div class="col-lg-12" style="padding-left:3em">
                    <table class="auto-style1">
                        <tr>
                            <%--   <td style="width: 20%;">

                        <asp:Label ID="Label1" runat="server" Text="Label">วันที่รับ </asp:Label>


                        :</td>--%>
                            <%--      <td>

                        <asp:Label ID="txt_date" runat="server"></asp:Label>

                    </td>--%>
                            <td style="width: 20%;">

                                <asp:Label ID="Label2" runat="server">ชื่อสถานที่ </asp:Label>
                                :</td>
                            <td>
                                <asp:Label ID="txt_addrnm" runat="server"></asp:Label>
                            </td>


                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Label">ที่อยู่ </asp:Label>


                                :</td>
                            <td colspan="3">
                                <asp:Label ID="txt_addr" runat="server"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Label">เลขใบอณุญาต </asp:Label>


                                :</td>
                            <td colspan="3">
                                <asp:Label ID="txt_lcnno" runat="server"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>
            </div>

        </div>
    </div>

    <div class="panel panel-body" style="width: 100%; padding-left: 1%;">
        <div class="row">
            <div class="col-lg-10">
                <h4>ข้อมูลผู้ว่าจ้าง</h4>
            </div>
            <div class="4">
                <div class="col-lg-2" style="text-align: right; padding-right: 1em">
                    <asp:Button ID="btn_add" runat="server" Text="เพิ่มผู้ว่าจ้างผลิต/นำเข้า" />
                </div>
            </div>
        </div>
   
        <div class="row" style="text-align: center">
            <div class="col-lg-12">
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
                            <telerik:GridBoundColumn DataField="LCN_TR_ID" DataType="System.Int32" FilterControlAltText="Filter LCN_TR_ID column"
                                HeaderText="LCN_TR_ID" ReadOnly="True" SortExpression="LCN_TR_ID" UniqueName="LCN_TR_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FK_LCN" DataType="System.Int32" FilterControlAltText="Filter FK_LCN column"
                                HeaderText="FK_LCN" ReadOnly="True" SortExpression="FK_LCN" UniqueName="FK_LCN" Display="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="THANM_NAME" FilterControlAltText="Filter THANM_NAME column"
                                HeaderText="ผู้ว่าจ้างผลิต/นำเข้า" ReadOnly="True" SortExpression="THANM_NAME" UniqueName="THANM_NAME">
                                   <HeaderStyle Width="150px"></HeaderStyle>
                            </telerik:GridBoundColumn>

                            <%--<telerik:GridBoundColumn DataField="LOCATION_NAME" FilterControlAltText="Filter LOCATION_NAME column"
                                HeaderText="ชื่อสถานที่ผลิต/นำเข้า" ReadOnly="True" SortExpression="LOCATION_NAME" UniqueName="LOCATION_NAME">
                            </telerik:GridBoundColumn>--%>

                            <telerik:GridBoundColumn DataField="ADDRESSPERSON" FilterControlAltText="Filter ADDRESSPERSON column"
                                HeaderText="ที่อยู่ผลิต/นำเข้า" SortExpression="ADDRESSPERSON" UniqueName="ADDRESSPERSON">
                                 <HeaderStyle Width="320px"></HeaderStyle>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="TEL" FilterControlAltText="Filter TEL column"
                                HeaderText="โทร" SortExpression="TEL" UniqueName="TEL">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="EMAIL" FilterControlAltText="Filter EMAIL column"
                                HeaderText="E-MAIL" SortExpression="EMAIL" UniqueName="EMAIL">
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HL_SELECT" runat="server">ดูข้อมูล</asp:HyperLink>
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
            <%--   <div class="col-lg-1"></div>--%>
        </div>
    </div>

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

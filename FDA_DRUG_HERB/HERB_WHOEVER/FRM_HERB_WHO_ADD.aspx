<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_HERB_WHO_ADD.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="FDA_DRUG_HERB.FRM_HERB_WHO_ADD" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
    <div class="row" style="text-align: right">
         <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูล" />
    </div>
    <div class="row" style="text-align: center">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
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
                            HeaderText="ชื่อสถานที่" ReadOnly="True" SortExpression="THANM_NAME" UniqueName="THANM_NAME">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="ADDRESSPERSON" FilterControlAltText="Filter ADDRESSPERSON column" 
                            HeaderText="ที่อยู่" SortExpression="ADDRESSPERSON" UniqueName="ADDRESSPERSON">
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
        <div class="col-lg-1"></div>
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

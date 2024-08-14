<%@ page title="" language="vb" autoeventwireup="false" masterpagefile="~/MasterPage/MAIN_STAFF.Master" codebehind="FRM_STAFF_LCN_MOCK.aspx.vb" inherits="FDA_DRUG_HERB.FRM_STAFF_LCN_MOCK" %>

<%@ register src="../UC/UC_INFMT.ascx" tagname="UC_INFMT" tagprefix="uc4" %>
<%@ register src="~/UC/UC_INFMT.ascx" tagprefix="uc1" tagname="UC_INFMT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: 18px;
            line-height: 1.33;
            border-radius: 6px;
            padding: 10px 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            //$(window).load(function () {
            //    $.ajax({
            //        type: 'POST',
            //        data: { submit: true },
            //        success: function (result) {
            //            $('#spinner').fadeOut(1);

            //        }
            //    });
            //});

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            //$('#ContentPlaceHolder1_btn_upload').click(function () {
            //    var IDA = getQuerystring("IDA");
            //    var process = getQuerystring("process");
            //    Popups('POPUP_LCN_UPLOAD_ATTACH.aspx?IDA=' & IDA  & '&process=' & process & '');
            //    return false;
            //});

            //$('#ContentPlaceHolder1_btn_download').click(function () {
            //    Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
            //    return false;
            //});

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');

            });

        });
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f3'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function Popups4(url) { // สำหรับทำ Div Popup

            $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f4'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }
        function closespinner() {
            alert('Download เสร็จสิ้น');
            $('#spinner').fadeOut('slow');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div> 
    <div class="h3" style="padding-left: 2%;"></div>
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 110px">
              <uc1:uc_infmt runat="server" id="UC_INFMT" />
            <div class="col-lg-9 col-md-9">
                <h4>ใบอนุญาต(จำลอง)<asp:Label ID="lbl_name_2" runat="server" Text=""></asp:Label><asp:Label ID="lbl_name" runat="server" Text="">
                </asp:Label>
                </h4>
            </div>
            <div class="col-lg-3 col-md-3">
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มคำขอใบอนุญาต(จำลอง)" CssClass="auto-style1" Height="45px" Width="240px" />
                <asp:Button ID="btn_reload" runat="server" Text="" Style="display: none;" />
                <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" />
            </div>
        </div>
    </div>
        <div class="row">
            <div class="col-lg-1">ประใบอนุญาต</div>
                    <div class="col-lg-8" style="text-align: right" >
                            <asp:RadioButtonList ID="rdl_lcn_type" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                <asp:ListItem Value="1">ใบอนุญาตผลิตผลิตภัณฑ์สมุนไพร&ensp;&ensp;</asp:ListItem>
                                <asp:ListItem Value="2">ใบอนุญาตนำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>
                </div>
    <div class="panel panel-body" style="width: 100%; padding-left: 1%;">
        <table style="width: 100%;">
            <tr>
                <td align="right">
                    <asp:Label ID="lbl_remark" runat="server" Text="*หมายเหตุ เมื่ออัพโหลดคำขออนุญาตผลิตยาแผนปัจจุบันแล้ว ให้ทำการเพิ่มหมวดยาจึงจะสามารถส่งคำขอได้" Style="display: none;"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GV_lcnno" runat="server" Width="100%" DataKeyNames="IDA" CellPadding="4" CssClass="table"
            ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
            <alternatingrowstyle backcolor="White" />
            <columns>
                <asp:BoundField DataField="LCNNO_DISPLAY_NEW" HeaderText="เลขที่ใบอนุญาต" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                    <itemstyle horizontalalign="Left" width="10%"></itemstyle>
                </asp:BoundField>
                <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="10%">
                    <itemstyle width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="thanameplace" HeaderText="ชื่อสถานที่" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                    <itemstyle horizontalalign="Left" width="10%"></itemstyle>
                </asp:BoundField>
                <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width="30%">
                    <itemstyle width="30%"></itemstyle>
                </asp:BoundField>
                <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width="10%" Visible="false">
                    <itemstyle width="10%"></itemstyle>
                </asp:BoundField>
                <asp:BoundField DataField="HOUSENO" HeaderText="เลขสถานที่" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                    <itemstyle horizontalalign="Left" width="10%"></itemstyle>
                </asp:BoundField>
                <asp:BoundField DataField="TRANSECTION_ID_UPLOAD" HeaderText="เลขดำเนินการ" ItemStyle-Width="10%">
                    <itemstyle width="10%"></itemstyle>
                </asp:BoundField>
<%--                <asp:BoundField DataField="REMARK" HeaderText="เหตุผลการคืนคำขอ" ItemStyle-Width="10%">
                    <itemstyle width="10%"></itemstyle>
                </asp:BoundField>--%>
                <%-- <asp:CheckBoxField DataField="pay_stat_chk" HeaderText="การชำระเงิน" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                       <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                   </asp:CheckBoxField>--%>
                <asp:TemplateField ItemStyle-Width="10%">
                    <itemtemplate>
                        <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        &nbsp; &nbsp; &nbsp;                        
                    </itemtemplate>
                    <itemstyle width="10%"></itemstyle>
                </asp:TemplateField>
                <%-- <asp:TemplateField ItemStyle-Width="10%">
                    <ItemTemplate>
                       <asp:Button ID="btn_drug_group" runat="server" Text="รายละเอียดหมวดยา" CommandName="drug_group" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        &nbsp; &nbsp; &nbsp;                        
                    </ItemTemplate>
                    <ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Button ID="btn_drug_edit" runat="server" Text="แก้ไข" CommandName="drug_edit" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        &nbsp; &nbsp; &nbsp;                      
                    </ItemTemplate>
                    <ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>--%>
                <%--         <asp:TemplateField ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Button ID="btn_leaves" runat="server" Text="ใบย่อย" CommandName="leaves" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        &nbsp; &nbsp; &nbsp;
                    </ItemTemplate>
                    <ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Button ID="btn_apm" runat="server" Text="ใบนัดหมาย" CommandName="drug_amp" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        &nbsp; &nbsp; &nbsp;                     
                    </ItemTemplate>
                    <ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>--%>
            </columns>
            <emptydatatemplate>
                <center>ไม่พบข้อมูล</center>
            </emptydatatemplate>
            <editrowstyle backcolor="#2461BF" />
            <footerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
            <headerstyle backcolor="#8CB340 " font-bold="True" forecolor="White" cssclass="row" />
            <pagerstyle backcolor="#2461BF" forecolor="White" horizontalalign="Center" />
            <rowstyle backcolor="#EFF3FB" cssclass="row" />
            <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
            <sortedascendingcellstyle backcolor="#F5F7FB" />
            <sortedascendingheaderstyle backcolor="#6D95E1" />
            <sorteddescendingcellstyle backcolor="#E9EBEF" />
            <sorteddescendingheaderstyle backcolor="#4870BE" />
        </asp:GridView>
        <%--        <div class="h5" style="padding-left: 87%;">
            <asp:HyperLink ID="hl_pay" runat="server" Target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
        </div>--%>
    </div>
    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด ใบอนุญาต<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">
                    <iframe id="f1" style="width: 100%; height: 800px;"></iframe>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade " id="myModal3">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด หมวดยา
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">
                    <iframe id="f3" style="width: 100%; height: 800px;"></iframe>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade " id="myModal4">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    ประเภทขายส่ง
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">
                    <iframe id="f4" style="width: 100%; height: 800px;"></iframe>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


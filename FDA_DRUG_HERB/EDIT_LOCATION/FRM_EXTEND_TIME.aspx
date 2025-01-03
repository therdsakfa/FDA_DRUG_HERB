﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Auto_Menu.Master" CodeBehind="FRM_EXTEND_TIME.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_EXTEND_TIME" %>
<%@ Register Src="~/UC/UC_HEADER.ascx" TagPrefix="uc1" TagName="UC_HEADER" %>
<%@ Register Src="~/UC/UC_FILTER.ascx" TagPrefix="uc1" TagName="UC_FILTER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" >
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

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ContentPlaceHolder1_btn_upload').click(function () {
                var lcn_ida = getQuerystring("lcn_ida");
                var lct_ida = getQuerystring("lct_ida");
                var process = getQuerystring("process");
                //  $('#spinner').toggle('slow');
                Popups('POPUP_NORYORMOR_2_to_5_UPLOAD.aspx?process=' + process + '&lcn_ida=' + lcn_ida.toString + '&lct_ida=' + lct_ida.toString);
                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');

            });

            function Popups(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }


        });

        function getQuerystring(key, default_) {
            if (default_ == null) default_ = "";
            key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
            var qs = regex.exec(window.location.href);
            if (qs == null)
                return default_;
            else
                return qs[1];
        }
        function Popups2(url) { // สำหรับทำ Div Popup
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

    
     <div id="spinner" style=" background-color:transparent; display:none;" >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>

    <div >
         
        <uc1:UC_HEADER runat="server" id="UC_HEADER" />
      
            <table style="width:100%; display:none;" class=" table">
        <tr>
            <td >
                <uc1:UC_FILTER runat="server" id="UC_FILTER" />
            </td>
             <td style="width:15%;">
                 <asp:Button ID="btn_filter" runat="server" Text="ค้นหา" Width="100px" CssClass="btn-lg"  />
            </td>
        </tr>
    </table>
    </div>
    &nbsp;<div>

           <fieldset>
               <div class="panel-info" style="text-align:right ;width:100%">
     <div  style="text-align:right;padding-left:5%;height:60px;">
          &nbsp;&nbsp;
       <asp:Button ID="btn_Add" runat="server" Text="เพิ่มคำขอ" Width="170px"  CssClass="btn-lg "  />
         <asp:Button ID="btn_reload" runat="server" Text="reload" Width="170px"  CssClass="btn-lg "  Style="display:none;" />
         &nbsp;
         <asp:Button ID="btn_load" runat="server" Text="อัพโหลดคำขอ" Width="170px"  CssClass="btn-lg " />
         <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
            </div>
    </div>
           <table style="width: 100%;">
               <tr>
                   <td>
                       <asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>

                               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="1%" Visible="false">
                                   <ItemStyle Width="1%"></ItemStyle>
                               </asp:BoundField>
               
                               <asp:BoundField DataField="rcvno" HeaderText="เลขที่รับคำขอ" ItemStyle-Width="10%">
                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="20%">
                                  
                               </asp:BoundField>
                              <asp:BoundField DataField="YEAR_EXTEXD" HeaderText="เพื่อใช้ในปี" ItemStyle-Width="30%">
                                   
                               </asp:BoundField>
                               <asp:TemplateField>
                                   <ItemTemplate>

                                       <asp:Button ID="btn_Select" runat="server" Text="แก้ไข/ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                   </ItemTemplate>

                               </asp:TemplateField>
                               <asp:TemplateField>
                                   <ItemTemplate>
                                       <asp:Button ID="btn_send" runat="server" Text="ยืนยันการส่งข้อมูล" OnClientClick="return confirm('ต้องการส่งคำขอหรือไม่');" CommandName="send" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField>
                                   <ItemTemplate>
                                       <asp:Button ID="btn_view" runat="server" Text="ดูใบอนุญาต" CommandName="view" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                   </ItemTemplate>
                               </asp:TemplateField>
                           </Columns>
                           <EditRowStyle BackColor="#2461BF" />
                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
                           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="#EFF3FB" />
                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                           <SortedAscendingCellStyle BackColor="#F5F7FB" />
                           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                           <SortedDescendingCellStyle BackColor="#E9EBEF" />
                           <SortedDescendingHeaderStyle BackColor="#4870BE" />
                       </asp:GridView>
                   </td>
               </tr>
           </table>
      </fieldset>
   
    

              <br />

              <div style="text-align:center;"> 
                  </div>  
        </div>
     &nbsp;<div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>

</asp:Content>
﻿<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_CER_FOREIGN_CONFIRM.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_CER_FOREIGN_CONFIRM" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../UC/UC_GRID_ATTACH.ascx" tagname="UC_GRID_ATTACH" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
       <script type="text/javascript" >
           $(document).ready(function () {
               $(window).load(function () {
                   $.ajax({
                       type: 'POST',
                       data: { submit: true },
                       success: function (result) {
                           //     $('#spinner').fadeOut('slow');
                       }
                   });
               });

               function CloseSpin() {
                   $('#spinner').toggle('slow');
               }

               $('#ContentPlaceHolder1_btn_upload').click(function () {

                   $('#spinner').toggle('slow');
                   Popups('POPUP_LCN_UPLOAD.aspx');
                   return false;
               });


               $('#ContentPlaceHolder1_btn_load0').click(function () {
                   parent.close_modal();

                   return false;
               });
               $('#ContentPlaceHolder1_btn_download').click(function () {
                   $('#spinner').fadeIn('slow');
                   Popups('POPUP_LCN_DOWNLOAD.aspx');
                   return false;
               });

               function Popups(url) { // สำหรับทำ Div Popup
                   $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                   var i = $('#f1'); // ID ของ iframe   
                   i.attr("src", url); //  url ของ form ที่จะเปิด
               }


           });
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
        </script> 
  <div id="spinner" style=" background-color:transparent; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;display:none" />
                 <asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control" >
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
                       </asp:HyperLink>
</div>
    <table style="width:100%;height:500px;">
        <tr>
            <td rowspan="2" style="width:70%; vertical-align:top;">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div style="vertical-align:top;" >
                     <asp:Literal ID="lr_preview" runat="server" ></asp:Literal>
    </div>
            </td>
             <td style="padding-left:10%;height:50%;" class="auto-style1">

                 <table class="table" style="width:90%"> 
                     
                     <tr><td>สถานะ</td></tr>
                     
                     <tr><td>
                         <asp:DropDownList ID="ddl_status" runat="server" CssClass="form-control">
                         </asp:DropDownList>
                         </td></tr>
                     <tr><td> <asp:Button ID="btn_confirm" runat="server" Text="บันทึก" CssClass="btn-lg"   Width="80%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load" runat="server" Text="Download PDF" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                 </table>
                 
             </td>
        </tr>
        <tr>
             <td style="padding-left:5px; vertical-align:top;">
                
                  
           
                 <uc1:UC_GRID_ATTACH ID="UC_GRID_ATTACH1" runat="server" />

                   <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>

                 <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
           


                 <br />
           


                 <table class="table" style="width:100%;">
                    <tr>
                        <td style="width:40%;">
                            ชื่อบริษัท
                        </td>
                        <td>

                            <asp:Label ID="lbl_office" runat="server" Text="-"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td style="width:40%;">
                            ชื่อผู้ยื่น</td>
                        <td>

                            <asp:Label ID="lbl_person" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:40%;">
                            เบอร์โทรศัพท์</td>
                        <td>

                            <asp:Label ID="lbl_mobile" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:40%;">
                            เลขดำเนินการเก่า</td>
                        <td>

                            <asp:Label ID="lbl_old_tr_id" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>



             </td>
        </tr>
       
        </table>
</asp:Content>
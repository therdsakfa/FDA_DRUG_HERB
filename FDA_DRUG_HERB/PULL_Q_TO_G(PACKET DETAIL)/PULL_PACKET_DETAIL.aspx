<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="PULL_PACKET_DETAIL.aspx.vb" Inherits="FDA_DRUG_HERB.PULL_PACKET_DETAIL" %>
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
                       //    $('#spinner').fadeOut('slow');
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
           function Popups2(url) { // สำหรับทำ Div Popup
               $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
               var i = $('#f1'); // ID ของ iframe   
               i.attr("src", url); //  url ของ form ที่จะเปิด
           }
           function close_modal() { // คำสั่งสั่งปิด PopUp
               $('#myModal').modal('hide');
               $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
           }
       });

       function spin_space() { // คำสั่งสั่งปิด PopUp
           //    alert('123456');
           $('#spinner').toggle('slow');
           //$('#myModal').modal('hide');
           //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

       }
       function closespinner() {
           $('#spinner').fadeOut('slow');
           alert('Download Success');
           Loaddata();
       }
    </script>
    <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-1">
            <asp:Label ID="text" runat="server" Text="IDA Q"></asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-4">
            <asp:Button ID="Button1" runat="server" Text="ดึงขนาดบรรจุ" />
        </div>

    </div>
    <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-1">
             <asp:Label ID="Label1" runat="server" Text="IDA Q"></asp:Label>   
        </div>
        <div class="col-lg-3">
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  
        </div>
        <div class="col-lg-3">
               <asp:Button ID="Button2" runat="server" Text="ดึงสรรพคุณ" /> 
        </div>
    </div>
        
</asp:Content>



<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_HERB_TEMPOLARY_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_HERB_TEMPOLARY_ADD" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_txt_date_confirm"));
            $("#ContentPlaceHolder1_txt_date_confirm").searchable();
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        function spin_space() { // คำสั่งสั่งปิด PopUp
            $('#spinner').toggle('slow');
        }

        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
    <div>
        <div class="row">
            <div class="col-lg-12" style="text-align: center;">
                <h3>การยื่นคำขออื่นๆ ตามการจัดเก็บเงินค่าคำขอ ผลิตภัณฑ์สมุนไพร</h3>
            </div>
        </div>

        <div style="padding-top: 15px"></div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                ผู้ยื่นคำขอ  
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_name_request" runat="server" Width="100%"></asp:TextBox>
                <asp:Label ID="lbl_name_request" runat="server" Text="*กรุณากรอกชื่อผู้ยื่นคำขอ " ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:Label ID="Label10" runat="server" Text="เลขนิติบุคคล/เลขบัตรประชาชน" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="TXT_SEARCH_TN" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                <asp:Button ID="BTN_SEARCH_TN" runat="server" Text="ค้นหา" />
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label3" runat="server" Text="มีความประสงค์จะขอ " Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-4">
                <telerik:RadComboBox ID="DD_PRICE_REQUEST" runat="server" Filter="Contains" Width="100%" AutoPostBack="true"></telerik:RadComboBox>
                <asp:Label ID="lbl_PRICE_REQUEST" runat="server" Text="*กรุณาเลือกความประสงค์" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
            <div class="col-lg-2">
                <p style="color: red" runat="server" id="P1" visible="false">&nbsp;</p>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row" runat="server" id="NumberPage" visible="false">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label6" runat="server" Text="จำนวนหน้า" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_numbre_page" runat="server" Width="100%" TextMode="Number" AutoPostBack="true" Height="30px"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label1" runat="server" Text="โดยมีค่าใช้จ่ายในการจัดเก็บจากผู้ยื่นคำขอ จำนวน " Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-1">
                <asp:TextBox ID="txt_ML_PAY" ReadOnly="true" runat="server" TextMode="Number" Width="80%"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                <asp:Label ID="Label2" runat="server" Text="บาท" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label4" runat="server" Text="ยื่นคำขอวันที่" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_date_confirm" runat="server" Width="90%"></asp:TextBox>
                <asp:Label ID="lbl_date_confirm" runat="server" Text="*กรุณากรอกวันที่ยื่นคำขอ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label7" runat="server" Text="ผู้มาติดต่อ" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_name_contact" runat="server" Width="100%"></asp:TextBox>
                <asp:Label ID="lbl_name_contact" runat="server" Text="*กรุณากรอกข้อมูลผู้มาติดต่อ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:Label ID="Label9" runat="server" Text="เลขนิติบุคคล/เลขบัตรประชาชน" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="TXT_SEARCH_TN2" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                <asp:Button ID="BTN_SEARCH_TN2" runat="server" Text="ค้นหา" />
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label5" runat="server" Text="Email" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_email" runat="server" Width="100%"></asp:TextBox>
                <asp:Label ID="lbl_email" runat="server" Text="*กรุณากรอกข้อมูล e-mail" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label8" runat="server" Text="เบอร์โทร" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_phone" runat="server" Width="100%"></asp:TextBox>
                <asp:Label ID="lbl_phone" runat="server" Text="*กรุณากรอกข้อมูล เบอร์โทร" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
            <div class="col-lg-1"></div>
        </div>

         <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label11" runat="server" Text="เลขที่รับเรื่องกองผลิตภัณฑ์สมุนไพร" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_rcvno_herb" runat="server" Width="100%"></asp:TextBox>
                <asp:Label ID="lbl_rcvno_herb" runat="server" Text="*กรุณากรอกข้อมูล เลขที่รับเรื่อง" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>

    <div style="padding-top: 250px"></div>
    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูลและยืนคำขอ" Height="40px" Width="175px" />
                <asp:Button ID="btn_edit" runat="server" Text="แก้ไขข้อมูลคำขอ" Height="40px" Width="175px" Visible="false" />
            </div>
        </div>
    </footer>


</asp:Content>

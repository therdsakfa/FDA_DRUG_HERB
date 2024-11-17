<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POP_UP_LCN_RENEW_CHECK_UPLOAD.aspx.vb" Inherits="FDA_DRUG_HERB.POP_UP_LCN_RENEW_CHECK_UPLOAD" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <link href="../../css/style.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <script type="text/javascript">
        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();
        }

        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        window.document.onkeydown = function (e) {
            if (!e) {
                e = event;
            }
            if (e.keyCode == 27) {
                lightbox_close();
            }
        }

        function lightbox_open() {
            var lightBoxVideo = document.getElementById("VisaChipCardVideo");
            window.scrollTo(0, 0);
            document.getElementById('light').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
            lightBoxVideo.play();
        }

        function lightbox_close() {
            var lightBoxVideo = document.getElementById("VisaChipCardVideo");
            document.getElementById('light').style.display = 'none';
            document.getElementById('fade').style.display = 'none';
            lightBoxVideo.pause();
        }
        //function validateLatitude(txtBox) {
        //    var value = parseFloat(txtBox.value);
        //    if (isNaN(value) || value < 5.0 || value > 21.0) {
        //        alert("กรุณากรอกค่าระหว่าง 5.0 ถึง 21.0");
        //        txtBox.value = "";
        //        txtBox.focus();
        //    }
        //}

        //function validateLongitude(txtBox) {
        //    var value = parseFloat(txtBox.value);
        //    if (isNaN(value) || value < 97.0 || value > 106.0) {
        //        alert("กรุณากรอกค่าระหว่าง 97.0 ถึง 106.0");
        //        txtBox.value = "";
        //        txtBox.focus();
        //    }
        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h1>ระบบตรวจสอบข้อมูล และเตรียมการต่ออายุ ใบอนุญาตสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h1>
        </div>
    </div>
    <panel id="Panel_Upload">
        <div style="padding-top: 1em"></div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="text-align: left">
                <h2>เอกสารหลักฐานประกอบการเตรียมการต่ออายุใบอนุญาต</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="text-align: left">
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label"> ***การแนบกรุณาแนบครั้งละ 2-3 ไฟล์ และ ขนาดไฟล์ต้องไม่เกิน 8 Mb (เอกสารแนบต้องเป็นไฟล์ PDF เท่านั้น)>>> </asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="padding-left: 2em; padding-right: 2em">
                <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-11" style="text-align: right">
                <asp:Button ID="btn_att" runat="server" Text="อัพโหลดเอกสารแนบ" Height="35px" />&ensp;
            </div>
        </div>
    </panel>
    <panel id="Panel_Edit_data">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10" style="text-align: left;">
                <h2>ข้อมูลพิกัดสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h2>
                <hr />
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <div id="light">
                            <a class="boxclose" id="boxclose" onclick="lightbox_close();"></a>
                            <video id="VisaChipCardVideo" width="1000" controls>
                                <source src="https://meshlog.fda.moph.go.th/FDA_DRUG_HERB_DEMO/Video/SEARCH_EX1080.mp4" controls="controls" type="video/mp4">
                            </video>
                        </div>
                        <div id="fade" onclick="lightbox_close();"></div>

                        <div style="padding-left: 0.5em">
                            <span>ตัวอย่างการหาละติจูด/ลองจิจูต<a href="#" onclick="lightbox_open();" style="color: #0033CC;"> คลิ๊ก</a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">พิกัด ละติจูด(latitude)</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_latitude" runat="server" Width="100%" onblur="validateLatitude(this);" AutoPostBack="true"></asp:TextBox>
                <small style="color: red">ตั้งแต่ 5.0-21.0</small>
            </div>
            <div class="col-lg-1">
                ลองจิจูด(longitude)
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_longitude" runat="server" Width="100%" onblur="validateLongitude(this);"></asp:TextBox>
                <small style="color: red">ตั้งแต่ 97.0-106.0</small>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <h4 style="color: red">ข้อมูลผู้ที่สามารถติดต่อสอบถามเพิ่มเติมได้</h4>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">คำนำหน้า</div>
            <div class="col-lg-2">
                <asp:DropDownList ID="ddl_prefix" runat="server" DataTextField="thanm" DataValueField="prefixcd" Width="100%"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">ชื่อ</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_emc_name" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                นามสกุล
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_emc_lname" runat="server" Width="100%"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-1">โทรศัพท์</div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_emc_tel" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                E-mail
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txt_emc_email" runat="server" Width="100%"></asp:TextBox>
            </div>
        </div>
    </panel>
    <panel id="Panel_Sent_Mail" runat="server" style="display: none; text-align: center" class="w3-container w3-center w3-animate-bottom">
        <div class="row">
            <div class="col-lg-11" style="text-align: right">
                <h3 style="color: red">หากท่านพบข้อมูลไม่ถูกต้อง ขอให้ท่านแจ้งรายละเอียดที่ต้องแก้ไข พร้อมส่งหลักฐาน มายัง email : herbaldivision@fda.moph.go.th ระบุชื่อเรื่อง ขอแก้ไขข้อมูลใบอนุญาตสถานที่</h3>
            </div>
        </div>
        <%--    <button id="close-image" style="border:none" >
            <img src="../Images/gmail_new_logo_icon.png" width="40" height="40" style="width: 40px"/>
        </button>--%>
        &ensp;
        <a id="gmail" href="https://mail.google.com/mail/u/0/#inbox?compose=new" target="_blank" class="closing" onclick="close_modal()">
            <img src="../Images/gmail_new_logo_icon.png" width="40" height="40" style="width: 40px" /></a>
        <%--        <button id="close-image2" style="border:none">
            <img src="../Images/microsoft_office_outlook_logo_icon.png" width="40" height="40"/>
        </button>--%>
        &ensp;
        <a id="outlook" href="https://outlook.live.com/mail/0/" target="_blank" class="closing" onclick="close_modal()">
            <img src="../Images/microsoft_office_outlook_logo_icon.png" width="40" height="40" /></a>
        <%-- <button id="close-image3" style="border:none">
                    <img src="../Images/yahoo.png"  width="40" height="40"/>
                </button>--%>
           &ensp;
        <a id="yahoo" href="https://login.yahoo.com/?" target="_blank" class="closing" onclick="close_modal()">
            <img src="../Images/yahoo.png" width="40" height="40" /></a>
    </panel>
    <div style="padding-top: 30px"></div>
    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <%--   <asp:Button ID="btn_cancel" runat="server" Text="ปิด" Height="40px" Width="135px" />&ensp;--%>
                <asp:Button ID="btn_save" runat="server" Text="ยืนยันการเพิ่มข้อมูลส่วนที่ 2" Height="40px" Width="235px" />&ensp;
                <asp:Button ID="btn_save2" runat="server" Text="ยืนยันการเพิ่มข้อมูล และแจ้งแก้ไขข้อมูลส่วนที่ 1" Height="40px" Width="296px" />
                <%--<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>--%>
                <asp:Button ID="btn_close" runat="server" Text="ปิด" Height="40px" Width="296px" Visible="false" />
            </div>
        </div>
    </footer>
</asp:Content>

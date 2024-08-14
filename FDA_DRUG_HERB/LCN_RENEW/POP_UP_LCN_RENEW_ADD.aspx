<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POP_UP_LCN_RENEW_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POP_UP_LCN_RENEW_ADD" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
        showdate($("#ContentPlaceHolder1_txt_Write_Date"));
        $("#ContentPlaceHolder1_UC_txt_Write_Date").searchable();

    });
    //$(document).ready(function () {
    //    showdate($("ContentPlaceHolder1_UC_PHR_DETAIL_phr_date_num"));
    //    $("ContentPlaceHolder1_UC_PHR_DETAIL_Siminar_Date").searchable();
    //});

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h1>คำขอต่ออายุใบอนุญาต</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-9"></div>
        <div class="col-lg-1" style="text-align: right;">
            เขียนที่              
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="Txt_Write_At" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-9"></div>
        <div class="col-lg-1" style="text-align: right;">
            วันที่
        </div>
        <div class="col-lg-1">
               <asp:TextBox ID="txt_Write_Date" runat="server"  Style="width: 80%"></asp:TextBox>     
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div style="padding-top: 30px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ข้าพเจ้า</div>
        <div class="col-lg-9">
            <asp:TextBox ID="txt_Rename_Name" runat="server" Width="50%" ReadOnly="true"></asp:TextBox>
            &ensp;  (ชื่อผู้รับอนุญาต)
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ซึ่งมีผู้ดำเนินกิจการชื่อ</div>
        <div class="col-lg-9">
            <asp:TextBox ID="txt_phr_name" runat="server" Width="50%" ReadOnly="true"></asp:TextBox>
            &ensp;  (เฉพาะกรณีนิติบุคคล)
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ตามใบอนุญาตเลขที่</div>
        <div class="col-lg-2">
            <asp:TextBox ID="TxT_LCN_NUM" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">ณ สถานประกอบธุรกิจชื่อ</div>
        <div class="col-lg-4">
            <asp:TextBox ID="TxT_Business_Name" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>



    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">อยู่เลขที่</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_addr" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            หมู่บ้าน/อาคาร
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="txt_Building" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>


    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">หมู่ที่</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_mu" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">ตรอก/ซอย </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_Soi" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-3">
          ถนน  &emsp;&emsp;
                 <asp:TextBox ID="txt_road" runat="server" ReadOnly="true" ></asp:TextBox>
        </div>
        <div class="col-lg-1">
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ตำบล/แขวง</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_tambol" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            อำเภอ/แขวง
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="txt_ampher" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">จังหวัด</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_changwat" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            รหัสไปรณษณีย์
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_zipcode" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-3">
            โทรสาร &ensp;
                <asp:TextBox ID="txt_fax" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">โทรศัพท์</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_tel" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
         <div class="col-lg-1">
            เวลาทำการ
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="txt_Opentime" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>

    <div style="padding-top:6em"></div>
    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
            </div>
        </div>
    </footer>
</asp:Content>

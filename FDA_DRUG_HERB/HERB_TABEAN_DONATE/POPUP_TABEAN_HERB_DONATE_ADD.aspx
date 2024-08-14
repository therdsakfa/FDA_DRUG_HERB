<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_HERB_DONATE_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_HERB_DONATE_ADD" %>



<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/HERB_TABEAN_DONATE/UC/UC_DONATE_DETAIL.ascx" TagPrefix="uc1" TagName="UC_DONATE_DETAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
 <script type="text/javascript">
    $(document).ready(function () {
        showdate($("#ContentPlaceHolder1_UC_DONATE_DETAIL_txt_Write_Date"));
        $("#ContentPlaceHolder1_UC_DONATE_DETAIL_txt_Write_Date").searchable();

        showdate($("#ContentPlaceHolder1_UC_DONATE_DETAIL_txt_date_DNStart"));
        $("#ContentPlaceHolder1_UC_DONATE_DETAIL_txt_date_DNStart").searchable();

        showdate($("#ContentPlaceHolder1_UC_DONATE_DETAIL_txt_date_DNEnd"));
        $("#ContentPlaceHolder1_UC_DONATE_DETAIL_txt_date_DNEnd").searchable();

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc1:UC_DONATE_DETAIL runat="server" ID="UC_DONATE_DETAIL" />

    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูลส่วนที่หนึ่ง" Height="40px" Width="148px" />
            </div>
        </div>
    </footer>
</asp:Content>


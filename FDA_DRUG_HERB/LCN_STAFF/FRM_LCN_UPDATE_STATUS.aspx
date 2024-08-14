<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_LCN_UPDATE_STATUS.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_UPDATE_STATUS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }
            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }
            $('#ContentPlaceHolder1_btn_download_2').click(function () {
                $('#spinner').fadeIn('slow');

            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');

            });

        });
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reset').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
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
    <h2>รายละเอียดใบอนุญาต
    </h2>
    <asp:Button ID="btn_reset" runat="server" Text="reset" CssClass="btn-lg" Style="display: none;" />
    <table class="table">
        <tr>
            <td>เลขอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label></td>
            <td>เลขนิติฯ/เลขบัตรปชช.ผู้รับอนุญาต</td>
            <td>
                <asp:Label ID="lbl_citizenid" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>ชื่อสถานที่ :</td>
            <td>
                <asp:Label ID="lbl_thanameplace" runat="server"></asp:Label></td>
            <td>ชื่อผู้ดำเนินกิจการ :</td>
            <td>
                <asp:Label ID="lbl_nameOperator" runat="server"></asp:Label></td>
        </tr>
    </table>

    <br />
    <h2>สถานะใบอนุญาต
    </h2>
    <table class="table">
        <tr>
            <td>สถานะปัจจุบัน :</td>
            <td>
                <asp:Label ID="lbl_statname" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <h2>การขอเปลี่ยนแปลงสถานะ&nbsp;</h2>
            </td>
        </tr>
        <tr>
            <td>เลือกสถานะใหม่ :</td>
            <td>
                <asp:DropDownList ID="ddl_stat" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>เหตุผลในการปรับสถานะ :</td>
            <td>
                <asp:DropDownList ID="ddl_stat_reason" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                <br />
                <asp:TextBox ID="REASON_OTHER" runat="server" TextMode="MultiLine" Height="60px" Width="70%" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>วันที่มีผล :</td>
            <td>
                <telerik:RadDatePicker ID="rdp_cncdate" runat="server">
                </telerik:RadDatePicker>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btn_c_stat" runat="server" Text="เปลี่ยนสถานะ" CssClass="btn-lg" /></td>
        </tr>
    </table>
</asp:Content>

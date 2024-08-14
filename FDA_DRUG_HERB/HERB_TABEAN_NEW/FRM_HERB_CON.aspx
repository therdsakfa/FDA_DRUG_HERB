<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_CON.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_CON" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_REQ"));
            $("#ContentPlaceHolder1_DD_OFF_REQ").searchable();
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
    <div class="row">
        <div class="col-lg-8" style="width: 70%">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="Label1" runat="server" Text="กรุณากรอกเลขหนังสือมอบอำนาจ (หากเป็นการยื่นด้วยตนเอง ให้กรอกเลข 000000)"></asp:Label><label style="color: red">*</label>
                </div>
                <div class="col-lg-5">
                    <asp:TextBox ID="txt_ref_no" runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="validate1" ControlToValidate="txt_ref_no" ValidationGroup="valGroup1" ErrorMessage="*กรุณากรอกเลขหนังสือมอบอำนาจ" runat="server" ForeColor="Red" />--%>
                </div>

            </div>

            <div class="row">
                <div class="col-lg-6" style="text-align: right">
                    <asp:Label ID="lbl_rcvno_old" runat="server" Text="กรุณากรอกเลขรับ"></asp:Label>
                </div>
                <div class="col-lg-5">
                    <asp:TextBox ID="txt_rcvno_old" runat="server"></asp:TextBox>
                </div>

            </div>
            <div class="row" runat="server">
                <div class="col-lg-1"></div>
                <div class="col-lg-4">วันที่ตรวจรับคำขอ</div>
                <div class="col-lg-6">
                    <asp:TextBox ID="DATE_REQ" runat="server" Style="width: 90%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>

        </div>
    </div>
</asp:Content>

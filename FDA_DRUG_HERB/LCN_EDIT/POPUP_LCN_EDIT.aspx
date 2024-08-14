<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_EDIT1" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="~/LCN_EDIT/UC/UC_LCN_EDIT.ascx" TagPrefix="uc1" TagName="UC_LCN_EDIT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            border-collapse: collapse;
            width: 100%;
            max-width: 100%;
            margin-bottom: 20px;
        }
    </style>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl1_SIMINAR_DATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl3_sub2_GIVE_PASSPORT_EXPDATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl3_sub2_GIVE_WORK_LICENSE_EXPDATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub1_PASSPORT_EXPDATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub1_BS_DATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub1_WORK_LICENSE_EXPDATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub1_DOC_DATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub1_FRGN_DATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub2_DOC_DATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub2_FRGN_DATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub2_GIVE_PASSPORT_EXPDATE"));
            showdate($("#ContentPlaceHolder1_UC_LCN_EDIT1_text_edit_ddl9_sub2_GIVE_WORK_LICENSE_EXPDATE"));
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc1:UC_LCN_EDIT runat="server" ID="UC_LCN_EDIT1" />
    <%--<uc1:uc_lcn_sub runat="server" ID="UC_LCN_SUB" />--%>
    
    <script type="text/javascript">
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
    </script>
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div style="width: 100%; text-align: left">
        <div style="width: auto; float: left; text-align: center; display: none">
            <h4>ยื่นข้อมูลที่&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbtn_bangkok" runat="server" Checked="True" GroupName="pvn" Text="ศูนย์ อย." />
                &nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:RadioButton ID="rbtn_other" runat="server" GroupName="pvn" Text="ต่างจังหวัด" />
            </h4>
        </div>
        
    </div>

    <div class="panel-footer " style="text-align: center;">
        <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="120px" />&nbsp;&nbsp;
        <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px" />
    </div>
</asp:Content>

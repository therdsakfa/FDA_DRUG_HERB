<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POP_UP_LCN_RENEW_UPLOAD_FILE.aspx.vb" Inherits="FDA_DRUG_HERB.POP_UP_LCN_RENEW_UPLOAD_FILE" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showCustomDialog() {
            $('#customDialog').modal('show');
        }
        function handleSelection() {
            var radioOption1Modal = document.getElementById('<%= RDO_YES.ClientID %>');
            var radioOption2Modal = document.getElementById('<%= RDO_NO.ClientID %>');

            if (radioOption1Modal.checked) {
                // Option 1 is selected, perform your action
                /*   alert("กรุณาตรวจสอบข้อมูลก่อนยื่นคำขอ");*/
            } else if (radioOption2Modal.checked) {
                // Option 2 is selected, perform your action
                /*    alert("ตัวเลือก 2 ถูกเลือก");*/
                /*           $('#btn_add_no').click*/
            } else {
                // No option is selected, handle as needed
                alert("กรุณาเลือกตัวเลือก");
            }
            $('#customDialog').modal('hide');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบคำขอ</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4" style="text-align: right"></div>
        <div class="col-lg-4" style="text-align: center">
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label"> ***การแนบกรุณาแนบครั้งละ 2-3 ไฟล์ และ ขนาดไฟล์ต้องไม่เกิน 8 Mb (เอกสารแนบต้องเป็นไฟล์ PDF เท่านั้น)>>> </asp:Label>

        </div>
        <div class="col-lg-2" style="text-align: left">
        </div>
    </div>
    <div class="row">
        <div style="padding-left: 2em; padding-right: 2em">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
        </div>
    </div>
    <div class="row" style="height: 15px"></div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">

            <hr />
        </div>
    </div>
    <footer>
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_add_no" runat="server" Text="อัพโหลดเอกสารแนบ" Height="35px" />&ensp;
            <asp:Button ID="btn_add_upload" runat="server" Text="บันทึกข้อมูล" Height="35px" />
                <%--" OnClientClick="showCustomDialog();return false;" UseSubmitBehavior="true"--%>
                <%--<asp:Button  ID="btn_add_upload" class="btn btn-primary" runat="server" onclick="showCustomDialog();return false;" UseSubmitBehavior="true" text="บันทึกข้อมูล"/>--%>
            </div>
        </div>
    </footer>

    <div id="customDialog" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">เลือกตัวเลือก</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>สถานที่ผลิต หรือนําเข้า หรือขาย และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร ตามที่ยื่นขอต่ออายุใบอนุญาตนี้ มีลักษณะเป็นไปตามประกาศกระทรวงสาธารณสุข เรื่อง หลักเกณฑ์ วิธีการ และเงื่อนไขเกี่ยวกับการผลิตผลิตภัณฑ์สมุนไพร ตามพระราชบัญญัติผลิตภัณฑ์สมุนไพร พ.ศ. ๒๕๖๒ หรือไม่</p>
                    <asp:RadioButton ID="RDO_YES" runat="server" GroupName="OptionsModal" Text="สถานที่ฯ เป็นไปตามประกาศฯ" />
                    <asp:RadioButton ID="RDO_NO" runat="server" GroupName="OptionsModal" Text="สถานที่ฯ ไม่เป็นไปตามประกาศฯ" />
                    <%--    <%--<asp:CheckBox ID="checkboxOption" runat="server" />  <label for="checkboxOption">สถานที่ฯ เป็นไปตามประกาศฯ</label>
                    <asp:CheckBox ID="checkboxOption2" runat="server" />  <label for="checkboxOption2">สถานที่ฯ ไม่เป็นไปตามประกาศฯ </label>--%>
                </div>
                <div class="modal-footer">
                    <%--          <button type="button" class="btn btn-primary" onclick="handleSelection()">ตกลง</button>--%>
                    <asp:Button ID="BTN_SUBMIT" class="btn btn-primary" runat="server" Text="ตกลง" Height="35px" OnClientClick="return handleSelection();" UseSubmitBehavior="true" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">ยกเลิก</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POP_UP_LCN_RENEW_CHECK_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.POP_UP_LCN_RENEW_CHECK_EDIT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h1>การแจ้งแก้ไขข้อมูล</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <fieldset>
                <legend>กรุณาเลือกรายการที่ข้อมูลไม่ถูกต้อง</legend>
                <div>
                    <asp:CheckBox ID="CheckBox_lcn" runat="server" Text="&ensp;ข้อมูลทั่วไป" AutoPostBack="true" />
                    <%--         <input type="checkbox" id="Lcn" name="interest" runat="server" value="1" />
                    <label for="Lcn">ข้อมูลทั่วไป</label>--%>
                </div>
                <div>
                    <asp:CheckBox ID="CheckBox_Bsn" runat="server" Text="&ensp;ข้อมูลผู้ดำเนินกิจการ" AutoPostBack="true" />
                    <%--<input type="checkbox" id="Bsn" name="interest" runat="server" value="1" />
                    <label for="Bsn">ข้อมูลผู้ดำเนินกิจการ</label>--%>
                </div>
                <div>
                    <asp:CheckBox ID="CheckBox_Phr" runat="server" Text="&ensp;ข้อมูลผู้มีหน้าที่ปฏิบัติการ" AutoPostBack="true" />
                    <%--<input type="checkbox" id="Phr" name="interest" runat="server" value="1" />
                    <label for="Phr">ข้อมูลผู้มีหน้าที่ปฏิบัติการ</label>--%>
                </div>
                <div>
                    <asp:CheckBox ID="CheckBox_Location" runat="server" Text="&ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร" AutoPostBack="true" />
                    <%-- <input type="checkbox" id="Location" name="interest" runat="server" value="1" />
                    <label for="Location">ข้อมูลสถานที่ผลิต นาเข้า หรือขายผลิตภัณฑ์สมุนไพร</label>--%>
                </div>
                <div>
                    <asp:CheckBox ID="CheckBox_Keep" runat="server" Text="&ensp;ข้อมูลสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร" AutoPostBack="true" />
                    <%--   <input type="checkbox" id="Keep" name="interest" runat="server" value="1" />
                    <label for="Keep">ข้อมูลสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร</label>--%>
                </div>
                <div>
                    <asp:CheckBox ID="CheckBox_Drug_Group" runat="server" Text="&ensp;รายการผลิตภัณฑ์สมุนไพรที่ได้รับอนุญาต (รูปแบบผลิตภัณฑ์สมุนไพร)" AutoPostBack="true" />
                    <%--                    <input type="checkbox" id="Drug_Group" name="interest" runat="server" value="1" />
                    <label for="Drug_Group">รายการผลิตภัณฑ์สมุนไพรที่ได้รับอนุญาต (รูปแบบผลิตภัณฑ์สมุนไพร)</label>--%>
                </div>
                <div>
                    <strong><p style="color:red">รายละเอียดการแก้ไข</p></strong>
                    <asp:TextBox ID="txt_note_edit" TextMode="MultiLine" runat="server" Height="100px" Width="700px"></asp:TextBox>
                </div>
            </fieldset>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="text-align: left; padding-left: 2em">
            <h3>หลักฐานประกอบการแจ้งแก้ไข</h3>
        </div>
    </div>
    <div class="row" id="set_show" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div style="text-align: left">
                <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
                <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร" Height="30px" Width="212px" />
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <%--   <asp:Button ID="btn_cancel" runat="server" Text="ปิด" Height="40px" Width="135px" />&ensp;--%>
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" Height="40px" Width="234px" CssClass="auto-style1" />&ensp;
            </div>
        </div>
    </footer>
</asp:Content>

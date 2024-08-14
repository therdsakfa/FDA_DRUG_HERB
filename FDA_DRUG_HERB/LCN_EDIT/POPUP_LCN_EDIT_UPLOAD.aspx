<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_EDIT_UPLOAD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_EDIT_UPLOAD1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 100%; padding-left: 5%; padding-right: 5%; padding-top: 0.1%; background-color: gray;">
        <div class="panel panel-body" style="width: auto; height: 100%; padding-left: 5%; padding-right: 5%; background-color: white;">
            <%--   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบคำขอ</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <span style="font-size: 16px; color: red;">
                        <asp:Label ID="cm1" runat="server">*ในขั้นตอนการแนบไฟล์นี้ ท่านสามารถแนบไฟล์และอัพโหลดไฟล์แนบไปทีละหัวข้อได้โดยไม่จำเป็นต้องแนบไฟล์ทั้งหมด แล้วกดยืนยันไฟล์แนบทีเดียว ทั้งนี้ หากทั้งไม่สามารถแนบไฟล์ทั้งหมดให้ครบในครั้งเดียวได้ ท่านสามารถยืนยันไฟล์แนบเฉพาะหัวข้อที่ท่านแนบไฟล์แล้ว และสามารถมาแนบไฟล์เพิ่มต่อในภายหลัง</asp:Label>
                    </span>
                </div>
            </div>
            <div class="row">
                <div style="padding-left: 4em; padding-right: 4em">
                    <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
                </div>
            </div>
            <footer>
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <asp:Button ID="btn_add_no" runat="server" Text="อัพโหลดเอกสารแนบ" Height="35px" />&ensp;
            <asp:Button ID="btn_add_upload" runat="server" Text="บันทึกข้อมูล" Height="35px" />
                    </div>
                </div>
            </footer>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD_STAFF.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_TABEAN_NEW_EDIT_UPLOAD_STAFF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 100%; padding-left: 5%; padding-right: 5%; padding-top: 0.1%; background-color: gray;">
        <div class="panel panel-body" style="width: auto; height: 100%; padding-left: 5%; padding-right: 5%; background-color: white;">
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบคำขอ</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4" style="text-align: right"></div>
                <div class="col-lg-4" style="text-align: center">
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label"> ***การแนบกรุณาแนบครั้งละ 2-3 ไฟล์ และ ขนาดไฟล์ต้องไม่เกิน 8 Mb >>> </asp:Label>

                </div>
                <div class="col-lg-2" style="text-align: left">
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




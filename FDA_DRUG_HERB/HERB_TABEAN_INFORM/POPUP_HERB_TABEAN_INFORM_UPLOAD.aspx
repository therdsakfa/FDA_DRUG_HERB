<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_TABEAN_INFORM_UPLOAD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_HERB_TABEAN_INFORM_UPLOAD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบคำขอขึ้นทะเบียน</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"> **คำแนะนำในการแนบเอกสาร >>> </asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../PDF/คำแนะนำการยื่นคำขอจดแจ้งผลิตภัณฑ์สมุนไพร.pdf" Target="_Blank"  ForeColor="Red"> DOWNLOAD</asp:HyperLink>
        </div>
    </div>
    <hr />
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label"> ***การแนบกรุณาแนบครั้งละ 5 ไฟล์ และ ขนาดไฟล์ต้องไม่เกิน 8 Mb >>> </asp:Label>
            </div>
        </div>
    <div class="row">
        <div style="overflow-x: scroll; height: 600px; text-align: left;padding-left:2em;padding-right:2em">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align:center">
                            <asp:Button ID="btn_add_no" runat="server" Text="แนบเอกสาร" />
            
            <asp:Button ID="btn_add_upload" runat="server" Text="บันทึกส่วนที่2" />
        </div>
    </div>
</asp:Content>

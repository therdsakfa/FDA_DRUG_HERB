<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="FRM_HERB_TABEAN_EX_UPLOAD_FILE.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_EX_UPLOAD_FILE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%> 
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบคำขอยายตัวอย่าง</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
        </div>
    </div>
    <div class="row">
        <div style="overflow-x: scroll; height: 600px; text-align: center">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
            <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร ยืนยันการยื่นคำขอ" />
        </div>
    </div>
</asp:Content>

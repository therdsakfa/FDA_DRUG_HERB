<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_HERB_ANALYZE_UPLOAD.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_HERB_ANALYZE_UPLOAD" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%--   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบคำขอ</h3>
        </div>
    </div>
  <%--   <div class="row">
       <div class="col-lg-12" style="text-align: center">
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"> **โปรดศึกษาคำแนะนำในการแนบเอกสาร >>> </asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../PDF/คำแนะนำการอัพโลหดเอกสารหลักฐานและฉลาก.pdf" Target="_Blank" ForeColor="Red"> DOWNLOAD</asp:HyperLink>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-lg-4" style="text-align: right"></div>
        <div class="col-lg-4" style="text-align: center">
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label"> ***การแนบกรุณาแนบครั้งละ 2-3 ไฟล์ และ ขนาดไฟล์ต้องไม่เกิน 8 Mb >>> </asp:Label>

        </div>
        <div class="col-lg-2" style="text-align: left">
            
        </div>
    </div>
    <div class="row">
        <div style="overflow-x: scroll;text-align: center">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="90%"></asp:Table>
        </div>
    </div>
    <div class="row" style="height: 15px"></div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
                      
        <hr />
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

</asp:Content>


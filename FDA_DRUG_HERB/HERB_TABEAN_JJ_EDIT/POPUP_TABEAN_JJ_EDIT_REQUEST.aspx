<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_JJ_EDIT_REQUEST.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_JJ_EDIT_REQUEST" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_EDIT_NAME_PRODUCT.ascx" TagPrefix="uc1" TagName="UC_EDIT_NAME_PRODUCT" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_ADDRESS_PRODUTION_SITE.ascx" TagPrefix="uc1" TagName="UC_ADDRESS_PRODUTION_SITE" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_PACKING_SIZE.ascx" TagPrefix="uc1" TagName="UC_PACKING_SIZE" %>
<%@ Register Src="~/HERB_TABEAN_JJ_EDIT/UC/UC_LABELS_AND DUCQUMENT.ascx" TagPrefix="uc1" TagName="UC_LABELS_ANDDUCQUMENT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
            padding: 5px 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">คำขอแก้ไขเปลี่ยนแปลงรายการในใบรับจดแจ้งผลิตภัณฑ์สมุนไพร</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="height: 30px"></div>
    
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            <label>ข้าพเจ้า:</label>
        </div>
        <div class="col-lg-4" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="NAME_JJ" runat="server" BorderStyle="None" ReadOnly="true" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-3">
            <label>ผู้รับใบรับจดแจ้งผลิตภัณฑ์สมุนไพร </label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="T1" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-4">
            <label>เลขประจำตัวประชาชน/เลขทะเบียนนิติบุคคล/หนังสือเดินทางเลขที่:</label>
        </div>
        <div class="col-lg-4" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="txt_IDEN" runat="server" Width="90%" BorderStyle="None"  ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" style="height: 5px"></div>
    <div class="row" id="T2" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-5">
            <label>ขอแก้ไขเปลี่ยนแปลงรายการในใบรับจดแจ้งผลิตภัณฑ์สมุนไพร:</label>
        </div>
       <%-- <div class="col-lg-4" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="TextBox1" runat="server" Width="90%" BorderStyle="None"  ReadOnly="true"></asp:TextBox>
        </div>--%>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="T3" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-7">
            <label>ชื่อ (ภาษาไทย) </label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="T4" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="Txt_Name_Thai" runat="server" Width="90%" BorderStyle="None"  ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="T5" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-7">
            <label>ชื่อ (ภาษาอังกฤษ) </label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="T6" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="txt_Name_Eng" runat="server" Width="90%" BorderStyle="None"  ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="T7" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>จดแจ้งผลิตภัณฑ์สมุนไพร เลขที่  </label>
        </div>
        <div class="col-lg-7" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="Txt_RgtNO_JJ" runat="server" Width="90%" BorderStyle="None"  ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="T8" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ช่องทางการจำหน่าย</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="Txt_SALE_CHANNEL_NAME" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-4">
            <label>รายการที่ขอแก้ไขเปลี่ยนแปลง (ระบุรายละเอียดในหน้าที่ ๒)</label>
        </div>
    </div>

    <div class="row" style="height: 50px"></div>
    <div class="row" id="T9" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <label>
                ข้าพเจ้าได้แนบเอกสารหรือหลักฐานตามที่สำนักงานคณะกรรมการอาหารและยาประกาศ
                กำหนดมาพร้อมนี้ และขอรับรองว่าข้อความอื่นใดที่ไม่ได้ระบุไว้ในคำขอฉบับนี้เหมือนเดิมทุกประการและขอ
                ยกเลิกรายการเดิมในใบรับจดแจ้งผลิตภัณฑ์สมุนไพร ตั้งแต่วันที่ได้รับอนุญาตให้แก้ไขเปลี่ยนแปลงรายการ
                ดังกล่าวในใบรับ จดแจ้งผลิตภัณฑ์สมุนไพร เว้นแต่ผู้อนุญาตจะมีคำสั่งเป็นอย่างอื่น
            </label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" style="height: 50px"></div>
    <div class="row" id="T10" runat="server">
        <div class="col-lg-5" style="text-align: right">
            <label>ผู้รับใบรับจดแจ้งผลิตภัณฑ์สมุนไพร</label>
        </div>
        <div class="col-lg-2">
            <div style="border-bottom: #999999 1px dotted; text-align: center">
                <asp:TextBox ID="Txt_thanm_JJ" runat="server" Width="90%" BorderStyle="None"></asp:TextBox>
            </div>
        </div>
        <%--<div class="col-lg-4">
            <label>รายการที่ขอแก้ไขเปลี่ยนแปลง (ระบุรายละเอียดในหน้าที่ ๒)</label>
        </div>--%>
        <div class="col-lg-1"></div>
    </div>

    <hr />

    <div class="row" style="height: 50px"></div>
    <div class="row" id="P1" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">รายละเอียดการแก้ไขเปลี่ยนแปลงรายการในใบรับจดแจ้งผลิตภัณฑ์สมุนไพร</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="height: 30px"></div>

    <div class="row" id="P2" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>จดแจ้งผลิตภัณฑ์สมุนไพร เลขที่  </label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="P3" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>เลขจดแจ้งที่  </label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="Txt_jj_no" runat="server" Width="90%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="P4" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>รายการที่ขอแก้ไขเปลี่ยนแปลง   </label>
        </div>
      <%--  <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="TextBox3" runat="server" Width="90%" BorderStyle="None"></asp:TextBox>
        </div>--%>
        <div class="col-lg-1"></div>
    </div>

 <%--   <div class="row" id="P5" runat="server">
          <div class="col-lg-1"></div>
          <div class="col-lg-4">
            <asp:DropDownList ID="ddl_editname" DataValueField="ID" DataTextField="NAME" runat="server" Width="100%"></asp:DropDownList>
        </div>
          <div class="col-lg-2">
              <asp:Button ID="btn_select_edit" runat="server" Text="เลือก" CssClass="auto-style1" Width="68px" />
          </div>
        <div class="col-lg-1"></div>
    </div>--%>
     
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
           
        </div>
        <div class="col-lg-1"></div>
    </div> 
    
    <div class="row">
        <div class="col-lg-10">
              <uc1:UC_EDIT_NAME_PRODUCT runat="server" id="UC_EDIT_NAME_PRODUCT" />
            <uc1:UC_ADDRESS_PRODUTION_SITE runat="server" id="UC_ADDRESS_PRODUTION_SITE" />
            <uc1:UC_PACKING_SIZE runat="server" id="UC_PACKING_SIZE" />
            <uc1:UC_LABELS_ANDDUCQUMENT runat="server" id="UC_LABELS_ANDDUCQUMENT" />
        </div>
        <div class="col-lg-1"></div>
    </div>

  <%--  <hr />--%>
    <div class="row" id="E1" runat="server">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" />&ensp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
        </div>
    </div>
</asp:Content>

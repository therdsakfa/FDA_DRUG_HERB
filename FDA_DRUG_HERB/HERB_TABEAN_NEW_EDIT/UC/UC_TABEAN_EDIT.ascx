<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_TABEAN_EDIT.ascx.vb" Inherits="FDA_DRUG_HERB.UC_TABEAN_EDIT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <h3 style="text-align: center">คำขอแก้ไขเปลี่ยนแปลงรายการในใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</h3>
    </div>
    <div class="col-lg-1"></div>
</div>
<br />
<div class="row">
    <%--<div class="col-lg-1"></div>--%>
    <div class="col-lg-1" style="text-align: right;">
        เขียนที่              
    </div>
    <div class="col-lg-1">
        <asp:TextBox ID="Txt_Write_At" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>
<div class="row">
    <%-- <div class="col-lg-1"></div>--%>
    <div class="col-lg-1" style="text-align: right;">
        วันที่
    </div>
    <div class="col-lg-2">
        <telerik:RadDatePicker ID="txt_Write_Date" runat="server">
        </telerik:RadDatePicker>
        <%--<asp:TextBox ID="txt_Write_Date" runat="server" Width="87%"></asp:TextBox>--%>
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
    <div class="col-lg-5">
        <label>ผู้รับใบสำคัญกำรขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</label>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T1" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-4">
        <label>เลขประจำตัวประชาชน/เลขทะเบียนนิติบุคคล/หนังสือเดินทางเลขที่:</label>
    </div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted; text-align: center">
        <asp:TextBox ID="txt_IDEN" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<%--<div class="row" style="height: 5px"></div>--%>
<div class="row" id="T2" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <label>ขอแก้ไขเปลี่ยนแปลงรายการในใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</label>
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
        <asp:TextBox ID="Txt_Name_Thai" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
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
        <asp:TextBox ID="txt_Name_Eng" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T7" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-4">
        <label>ทะเบียนตำรับผลิตภัณฑ์สมุนไพร เลขที่ </label>
    </div>
    <div class="col-lg-3" style="border-bottom: #999999 1px dotted; text-align: center">
        <asp:TextBox ID="Txt_RgtNO_JJ" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" id="T8" runat="server">
    <div class="col-lg-1"></div>
    <%-- <div class="col-lg-2">
            <label>ช่องทางการจำหน่าย</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="Txt_SALE_CHANNEL_NAME" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>--%>
    <div class="col-lg-8">
        <label>รายการที่ขอแก้ไขเปลี่ยนแปลง (ระบุรายละเอียดในหน้าที่ ๒)</label>
    </div>
</div>

<div class="row" style="height: 50px"></div>
<div class="row" id="T9" runat="server">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <label>
            ข้าพเจ้าได้แนบเอกสารหรือหลักฐานตามที่สำนักงานคณะกรรมการอาหารและยาประกาศกำหนดมาพร้อม
            นี้ และขอรับรองว่าข้อความอื่นใดที่ไม่ได้ระบุไว้ในคำขอฉบับนี้เหมือนเดิมทุกประการและขอยกเลิกรายการเดิมใน
            ใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร ตั้งแต่วันที่ได้รับอนุญาตให้แก้ไขเปลี่ยนแปลงรายการดังกล่าวใน
            ใบสำคัญการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร เว้นแต่ผู้อนุญาตจะมีคำสั่งเป็นอย่างอื่น
        </label>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row" style="height: 50px"></div>
<div class="row" id="T10" runat="server">
    <div class="col-lg-5" style="text-align: right">
        <label>ผู้รับใบสำคัญกำรขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</label>
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

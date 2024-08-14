<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_EDIT_TOPIC_3.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_EDIT_TOPIC_3" %>

<%--topic3--%>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-8">
        <h4>ข้อมูลกรณีย้ายสถานที่/เพิ่มสถานที่/ลดขยายสถานที่
                    <span style="font-size: 16px; color: red;">*เพิ่มข้อมูล หรือแก้ไขข้อมูล</span>
        </h4>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        สถานที่ประกอบธุรกิจชื่อ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_thanameplace" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        เลขรหัสประจำบ้าน :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_HOUSENO" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        อยู่เลขที่ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_thaaddr" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        หมู่บ้าน/อาคาร :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_thabuilding" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        หมู่ที่ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_thamu" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        ตรอก/ซอย :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_thasoi" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        ถนน :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_tharoad" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">ตำบล/แขวง :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_thathmblnm" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">อำเภอ/เขต :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_thaamphrnm" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">จังหวัด :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_thachngwtnm" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">รหัสไปรษณีย์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_zipcode" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">โทรสาร :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_fax" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">โทรศัพท์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_tel" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">อีเมล์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_email" runat="server">GET_DATA</asp:TextBox>
    </div>
   <%-- <div class="col-lg-1" style="text-align: right"></div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_ddl2_opentime" runat="server">GET_DATA</asp:TextBox>
    </div>--%>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">เวลาทำการ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_opentime" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">สถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร (ถ้ามี) ชื่อ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_thanameplace" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">เลขรหัสประจำบ้าน :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_HOUSENO" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">อยู่เลขที่ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_thaaddr" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">หมู่บ้าน/อาคาร :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_thabuilding" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">หมู่ที่ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_thamu" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">ตรอก/ซอย :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_thasoi" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">ถนน :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_tharoad" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">ตำบล/แขวง :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_thathmblnm" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">อำเภอ/เขต :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_thaamphrnm" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">จังหวัด :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_thachngwtnm" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">รหัสไปรษณีย์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_zipcode" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">โทรสาร :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_fax" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">โทรศัพท์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_tel" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">อีเมล์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic3_KEEP_email" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>

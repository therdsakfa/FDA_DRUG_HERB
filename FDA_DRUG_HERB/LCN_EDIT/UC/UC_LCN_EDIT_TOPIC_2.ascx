<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_EDIT_TOPIC_2.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_EDIT_TOPIC_2" %>

<%--<%--(นิติบุคคล)--%>
<%--<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-8">
        <h4>ข้อมูลกรณีเปลี่ยนผู้ดำเนินกิจการ (นิติบุคคล)
                    <span style="font-size: 16px; color: red;">*เพิ่มข้อมูล หรือแก้ไขข้อมูล</span>
        </h4>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        ชื่อผู้ดำเนินกิจการ :
    </div>
    <div class="col-lg-2" style="text-align: left">

        <asp:TextBox ID="text_edit_dd3_sub1_NAME" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        อายุ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_dd3_sub1_AGE" runat="server">GET_DATA</asp:TextBox>
        ปี
    </div>
    <div class="col-lg-1" style="text-align: right">
        สัญชาติ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_dd3_sub1_NATION" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        เลขประจำตัวประชาชน :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_dd3_sub1_IDEN" runat="server">GET_DATA</asp:TextBox>
    </div>

</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        ที่อยู่เลขที่ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_dd3_sub1_addr_num" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        หมู่บ้าน/อาคาร :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_dd3_sub1_addr_name_building" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        หมู่ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox1" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        ตรอก/ซอย :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox2" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        ถนน :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox4" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        ตำบล/แขวง :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox3" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        อำเภอ/เขต :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox5" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        จังหวัด :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox6" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        รหัสไปรษณีย์ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox7" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        โทรสาร :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox8" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">
        โทรศัพท์ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox9" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">
        อีเมล์ :
    </div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="TextBox10" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>--%>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-8">
        <span style="font-size: 16px; color: red;">*ที่อยู่ที่สามารถติดต่อได้ (เฉพาะกรณีที่อยู่ไม่ใช่ที่อยู่เดียวกันกับทะเบียนบ้าน)</span>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">อยู่เลขที่ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_thaaddr" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">หมู่บ้าน/อาคาร :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_thabuilding" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">หมู่ที่ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_thamu" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">ตรอก/ซอย :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_thasoi" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">ถนน :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_tharoad" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">จังหวัด :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:DropDownList ID="ddl_Province" runat="server" DataValueField="chngwtcd" DataTextField="thachngwtnm" AutoPostBack="true"></asp:DropDownList>
        <%--<asp:TextBox ID="text_edit_topic2_chngwtcd" runat="server">GET_DATA</asp:TextBox>--%>
    </div>
    <div class="col-lg-1" style="text-align: right">อำเภอ/เขต :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:DropDownList ID="ddl_amphor" runat="server" DataValueField="amphrcd" DataTextField="thaamphrnm" AutoPostBack="true"></asp:DropDownList>
       <%-- <asp:TextBox ID="text_edit_topic2_amphrcd" runat="server">GET_DATA</asp:TextBox>--%>
    </div>
    <div class="col-lg-1" style="text-align: right">ตำบล/แขวง :</div>
    <div class="col-lg-2" style="text-align: left">
        <%--<asp:TextBox ID="text_edit_topic2_thmblcd" runat="server">GET_DATA</asp:TextBox>--%>
        <asp:DropDownList id="ddl_tambol" runat="server" DataValueField="thmblcd" DataTextField="thathmblnm" AutoPostBack="true"></asp:DropDownList>
    </div>
    
</div>
<div class="row">
    
    <div class="col-lg-2" style="text-align: right">รหัสไปรษณีย์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_zipcode" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">โทรสาร:</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_fax" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-2" style="text-align: right">โทรศัพท์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_tel" runat="server">GET_DATA</asp:TextBox>
    </div>
    <div class="col-lg-1" style="text-align: right">อีเมล์ :</div>
    <div class="col-lg-2" style="text-align: left">
        <asp:TextBox ID="text_edit_topic2_email" runat="server">GET_DATA</asp:TextBox>
    </div>
</div>

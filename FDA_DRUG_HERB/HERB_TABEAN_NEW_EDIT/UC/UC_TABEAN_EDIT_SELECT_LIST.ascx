<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_TABEAN_EDIT_SELECT_LIST.ascx.vb" Inherits="FDA_DRUG_HERB.UC_TABEAN_EDIT_SELECT_LIST" %>

<div class="row">
    <div class="row" id="P1" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">รายละเอียดการแก้ไขเปลี่ยนแปลงรายการในใบสำคัญกำรขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="height: 30px"></div>

    <div class="row" id="P2" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ทะเบียนตำรับผลิตภัณฑ์สมุนไพร</label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="P3" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            <label>เลขทะเบียนที่ </label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
            <asp:TextBox ID="txt_rgtno" runat="server" Width="90%" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="Div1" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>รายการที่ขอแก้ไขเปลี่ยนแปลง</label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="padding-left: 2em">
            <asp:CheckBox ID="CB_NAME_PRODUCT_ID" Text="&nbsp;ชื่อของผลิตภัณฑ์สมุนไพร" runat="server" AutoPostBack="True" /><br />
            <div id="DV_NAME_SL" runat="server" style="padding-left: 2em" visible="false">
                <asp:CheckBox ID="CB_NAME_ENG" Text="&nbsp;1. เพิ่มชื่อผลิตภัณฑ์ภาษาอังกฤษ " runat="server" /><br />
                <asp:CheckBox ID="CB_NAME_OTHER" Text="&nbsp;2. เพิ่มชื่อผลิตภัณฑ์ภาษาอื่น " runat="server" /><br />
                <asp:CheckBox ID="CB_NAME_EXPORT" Text="&nbsp;3. เพิ่มชื่อผลิตภัณฑ์เพื่อการส่งออก" runat="server" /><br />
            </div>
            <asp:CheckBox ID="CB_NAME_LOCATION_ID" Text="&nbsp;ชื่อหรือที่อยู่ของสถานที่ผลิต/ นำเข้ำ" runat="server" AutoPostBack="True" /><br />
            <div id="Div_NAME_LOCATION" runat="server" style="padding-left: 2em" visible="false">
                <asp:CheckBox ID="CheckBox1" Text="&nbsp;1.เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนุญาตผลิตให้ตรงตามใบอนุญาตผลิตผลิตภัณฑ์สมุนไพร" runat="server" /><br />
                <asp:CheckBox ID="CheckBox2" Text="&nbsp;2.เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนุญาตนำหรือสั่งให้ตรงตามใบอนุญาตนำ หรือสั่ง ผลิตภัณฑ์สมุนไพร " runat="server" /><br />
                <asp:CheckBox ID="CheckBox3" Text="&nbsp;3.เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนญาตผลิตต่างประเทศ " runat="server" /><br />
            </div>
            <asp:CheckBox ID="CB_PRODUCT_RECIPE_ID" Text="&nbsp;ตำรับผลิตภัณฑ์สมุนไพร " runat="server" AutoPostBack="True" /><br />
            <div id="Div_SubProductRecipe" runat="server" style="padding-left: 2em" visible="false">
                <asp:CheckBox ID="CheckBox_SubRecipe1" Text="&nbsp;1. เพิ่ม/แก้ไขชื่อวิทยาศาสตร์/ชื่อภาษาอังกฤษในสูตรตำรับ " runat="server" /><br />
                <div id="Div2" runat="server" style="padding-left: 3em">
                    <asp:CheckBox ID="CheckBox_SubRecipe1_1" Text="&nbsp;1.1 เพิ่มชื่อวิทยาศาสตร์/ชื่อภาษาอังกฤษในสูตรตำรับ" runat="server" /><br />
                    <asp:CheckBox ID="CheckBox_SubRecipe1_2" Text="&nbsp;1.2 แก้ไขชื่อวิทยาศาสตร์/ชื่อภาษาอังกฤษในสูตรตำรับ" runat="server" /><br />
                </div>
                <asp:CheckBox ID="CheckBox_SubRecipe2" Text="&nbsp;2. แก้ไขตัวยาไม่สำคัญในสูตรตำรับผลิตภัณฑ์ (Excipients) " runat="server" /><br />
                <div id="Div3" runat="server" style="padding-left: 3em">
                    <asp:CheckBox ID="CheckBox_SubRecipe2_1" Text="&nbsp;2.1 แก้ไขสารช่วย (ซึ่งต้องเป็นไปตามประกาศกระทรวงฯ)" runat="server" /><br />
                </div>
            </div>
            <asp:CheckBox ID="CB_PRODUCTION_PROCESS_ID" Text="&nbsp;กรรมวิธีการผลิต " runat="server" AutoPostBack="True" /><br />
            <asp:CheckBox ID="CB_PROPERTIES_ID" Text="&nbsp;สรรพคุณ/ข้อบ่งใช้/ ข้อความกล่าวอ้างทางสุขภาพ" runat="server" AutoPostBack="True" /><br />
            <asp:CheckBox ID="CB_SIZE_USE_ID" Text="&nbsp;ขนาดและวิธีการใช้ " runat="server" AutoPostBack="True" /><br />
            <asp:CheckBox ID="CB_PREPARE_EAT_ID" Text="&nbsp;วิธีเตรียมก่อนรับประทำน " runat="server" AutoPostBack="True" /><br />
            <asp:CheckBox ID="CB_EAT_CONDITION_ID" Text="&nbsp;เงื่อนไขการรับประทาน " runat="server" AutoPostBack="True" /><br />
            <asp:CheckBox ID="CB_STORAGE_ID" Text="&nbsp;การเก็บรักษา / อายุการเก็บรักษา " runat="server" AutoPostBack="True" /><br />
            <asp:CheckBox ID="CB_CONTAINER_PACKING_ID" Text="&nbsp;ภาชนะและขนาดบรรจุ " runat="server" AutoPostBack="True" /><br />
            <asp:CheckBox ID="CB_QUALITY_CONTROL_ID" Text="&nbsp;วิธีควบคุมคุณภาพและข้อกำหนดเฉพาะของผลิตภัณฑ์สมุนไพร " runat="server" AutoPostBack="True" /><br />
               <div id="Div_SubQuality_Control" runat="server" style="padding-left: 2em" visible="false">
                <asp:CheckBox ID="CheckBox_SubQuality1" Text="&nbsp;1. วิธีควบคุมคุณภาพและข้อกําหนดของตำรับยาองค์ความรู้ดั้งเดิม" runat="server" /><br />
                <asp:CheckBox ID="CheckBox_SubQuality2" Text="&nbsp;2. วิธีควบคุมคุณภาพและข้อกําหนดของตำรับยาพัฒนาจากสมุนไพร" runat="server" /><br />
            </div>
            <asp:CheckBox ID="CB_CER_LCN_ID" Text="&nbsp;หนังสือรับรองการอนุญาตให้ขายหรือการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร เฉพาะกรณีที่เป็นการนำเข้ำ " runat="server" AutoPostBack="True" Enabled="false" /><br />
            <asp:CheckBox ID="CB_ETIQUETQ_ID" Text="&nbsp;ฉลาก และเอกสารกำกับผลิตภัณฑ์สมุนไพร" runat="server" AutoPostBack="True" /><br />
            <%-- <asp:CheckBox ID="CB_PRODUCT_DOCUMENT_ID" Text="&nbsp;เอกสารกำกับผลิตภัณฑ์สมุนไพร " runat="server" AutoPostBack="True" /><br />--%>
            <asp:CheckBox ID="CB_CHANNEL_SALE_ID" Text="&nbsp;ช่องทางการจำหน่าย " runat="server" AutoPostBack="True" /><br />
            <%-- <asp:CheckBox ID="cb_list_id_16" Text="&nbsp;อื่น ๆ " runat="server" AutoPostBack="True" Enabled="false"/><br />--%>
        </div>
    </div>


</div>

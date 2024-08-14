<%@ Page Title="" Language="vb" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_TRANSFER.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_LCN_TRANSFER" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <style type="text/css">
        .auto-style2 {
            font-size: 18px;
            line-height: 1.33;
            border-radius: 6px;
            padding: 10px 16px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_txt_Write_Date"));
            $("#ContentPlaceHolder1_txt_Write_Date").searchable();
        });

        function spin_space() { // คำสั่งสั่งปิด PopUp
            $('#spinner').toggle('slow');
        }

        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="row">
        <div class="col-lg-5"></div>
        <div class="col-lg-7">
            <h2>คำขอโอนใบอนุญาต</h2>
        </div>

    </div>
    <div class="row">
        <div class="col-lg-5"></div>
        <div class="col-lg-7 ">
            <asp:RadioButtonList ID="rdl_lcn_type" runat="server" Enabled="true">
                <asp:ListItem Value="1">ผลิตผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="2">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="3">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-9"></div>
        <div class="col-lg-1" style="text-align: right;">
            เขียนที่              
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="Txt_Write_At" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-9"></div>
        <div class="col-lg-1" style="text-align: right;">
            วันที่
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="txt_Write_Date" runat="server" Width="80%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div style="padding-top: 5px"></div>
    <br />
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_name" runat="server" Text="ข้าพเจ้า"></asp:Label>
        </div>
        <div class="col-lg-5" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_name" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_name_lcn" runat="server" Text="(ชื่อผู้รับอนุญาต)"></asp:Label>
        </div>
        <div class="col-lg-2"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <%--<asp:Label ID="lbl_bsn_name" runat="server" Text="ซึ่งมีผู้มีหน้าที่ปฏิบัติการชื่อ"></asp:Label>--%>
            <asp:Label ID="lbl_bsn_name" runat="server" Text="ซึ่งมีผู้ดำเนินกิจการชื่อ"></asp:Label>
        </div>
        <div class="col-lg-2" style="text-align: left; border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_bsn_name" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_niti" runat="server" Text="(เฉพาะกรณีนิติบุคคล)"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_lcnno" runat="server" Text="ตามใบอนุญาตเลขที่"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_lcnno" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_name_business" runat="server" Text="ณ สถานที่ประกอบธุรกิจชื่อ"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_name_business" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-4"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_location_trnf" runat="server" Text="อยู่เลขที่"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_location_trnf" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_trnf_building" runat="server" Text="หมู่บ้าน/อาคาร"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_building" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-6"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_mu" runat="server" Text="หมู่ที่"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_mu" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_trnf_soi" runat="server" Text="ตรอก/ซอย"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_soi" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-4"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_road" runat="server" Text="ถนน"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_road" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-8"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_tambol" runat="server" Text="ตำบลแขวง"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_tambol" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_trnf_amphor" runat="server" Text="อำเภอเขต"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_amphor" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-4"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_changwat" runat="server" Text="จังหวัด"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_changwat" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_trnf_zipcode" runat="server" Text="รหัสไปรษณีย์"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_zipcode" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_lcn_tel" runat="server" Text="โทรศัพท์"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_lcn_tel" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_time_work" runat="server" Text="เวลาทำการ"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <%-- <telerik:RadTimePicker ID="RadTimePicker1" runat="server"></telerik:RadTimePicker>--%>
            <asp:TextBox ID="txt_time_work" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_iden" runat="server" Text="เลขประจำตัวประชาชน"></asp:Label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_trnf_iden" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-7"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="text-align: right">
            <h3>กรณีบุคคลต่างด่าว ระบุ</h3>
            <%--<asp:Label ID="lbl_personal_type" runat="server" Text="กรณีบุคคลต่างด่าว ระบุ"></asp:Label>--%>
        </div>
        <div class="col-lg-8"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_PASSPORT_NO" runat="server" Text="หนังสือเดินทางเลขที่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_PASSPORT_NO" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_PASSPORT_EXPDATE" runat="server" Text="วันหมดอายุ"></asp:Label>
        </div>
        <div class="col-lg-2">
            <telerik:RadDatePicker ID="RDP_PASSPORT_EXPDATE" runat="server">
            </telerik:RadDatePicker>
        </div>
        <div class="col-lg-7"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_DOC_NO" runat="server" Text="ใบอนุญาตทำงานหรือใบสำคัญถิ่นที่อยู่เลขที่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_DOC_NO" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_DOC_NO_EXPDATE" runat="server" Text="วันหมดอายุ"></asp:Label>
        </div>
        <div class="col-lg-2">
            <telerik:RadDatePicker ID="RDP_DOC_NO_EXPDATE" runat="server">
            </telerik:RadDatePicker>
        </div>
        <div class="col-lg-3"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2" style="text-align: right">
            <asp:Label ID="lbl_transfer_to" runat="server" Text="มีความประสงค์ขอโอนใบอนุญาตฯ ให้แก่"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_ctzid_lcn" runat="server"></asp:TextBox>
            <asp:Button ID="btn_search_lcn" runat="server" Text="ค้นหา" />
            <asp:HiddenField ID="hf_lcn" runat="server" />
            <br />
            <%-- <asp:TextBox ID="txt_transfer_to" runat="server"></asp:TextBox>--%>
        </div>
          <div class="col-lg-1">
            <asp:DropDownList ID="ddl_prefix" runat="server" DataTextField="thanm" DataValueField="prefixcd" Width="100%" ></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:Label ID="txt_transfer_to" runat="server" Text="-"></asp:Label>
        </div>
        <div class="col-lg-1" style="text-align: left">
            <asp:Label ID="lbl_trnf_name" runat="server" Text="(ผู้รับโอน)"></asp:Label>
        </div>
        <div class="col-lg-3"></div>
    </div>


    <%--            หากยังไม่ได้เพิ่มผู้ดำเนินรายใหม่กรุณา
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/EDIT_LOCATION_STAFF/FRM_ADD_NEW_BSN.aspx" Target="_blank">คลิกที่นี่</asp:HyperLink>
 
 
            กรอกเลข 13 หลัก เพื่อดึงข้อมูลผู้ดำเนิน :--%>

    <%--   <asp:TextBox ID="txt_ctzid" runat="server"></asp:TextBox>--%>
    <%-- <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />--%>
    <%--<asp:HiddenField ID="hf_bsn" runat="server" />--%>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_operator_name" runat="server" Text="โดยมีผู้ดำเนินกิจการชื่อ"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_ctzid" runat="server"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
            <asp:HiddenField ID="hf_bsn" runat="server" />
            <br />
            <%-- <asp:TextBox ID="txt_transfer_to" runat="server"></asp:TextBox>--%>
        </div>
        <div class="col-lg-1">
            <asp:DropDownList ID="ddl_prefix_bsn" runat="server" DataTextField="thanm" DataValueField="prefixcd" Width="100%"></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:Label ID="operator_name" runat="server" Text="-"></asp:Label>
        </div>
        <%--   <div class="col-lg-1" style="text-align: left">
            <asp:Label ID="Label2" runat="server" Text="(ผู้รับโอน)"></asp:Label>
        </div>--%>
        <%--  <div class="col-lg-4">
            <asp:TextBox ID="txt_operator_name" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>--%>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_start_trnf" runat="server" Text="ตั้งแต่วันที่"></asp:Label>
        </div>
        <div class="col-lg-1">
            <telerik:RadDatePicker ID="RPD_start_trnf" runat="server">
            </telerik:RadDatePicker>
            <%--<asp:TextBox ID="txt_start_trnf" runat="server"></asp:TextBox>--%>
        </div>
        <div class="col-lg-8"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:Label ID="lbl_trnf_remark" runat="server" Text="เนื่องจาก"></asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_trnf_remark" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <asp:Label ID="Label3" runat="server" Text="และข้าพเจ้า (ผู้โอน) ขอส่งคืนใบอนุญาตและขอยกเลิกใบอนุญาตฯ ของข้าพเจ้า นับตั้งแต่ผู้รับโอนได้รับอนุญาตจากผู้รับอนุญาต"></asp:Label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-3">
            <asp:Label ID="Label4" runat="server" Text="พร้อมนี้ผู้รับโอนได้แนบหลักฐานมาด้วยคือ"></asp:Label>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <asp:Label ID="Label5" runat="server" Text="๑. คำขอรับใบอนุญาตผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร (สมพ.๑) และเอกสารที่เกี่ยวข้องตามแบบ สมพ.๑"></asp:Label>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-5">
            <asp:Label ID="Label6" runat="server" Text="๒. เอกสารหลักฐานอื่น ๆ (ถ้ามี)"></asp:Label>
        </div>
        <div class="col-lg-6"></div>
    </div>
    <br />
    <br />

    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-2">
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="auto-style2" Width="165px" />
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btn_Confirm" runat="server" Text="ยืนยัน" CssClass="auto-style2" Width="165px" />
        </div>
        <div class="col-lg-1"></div>
    </div>

</asp:Content>

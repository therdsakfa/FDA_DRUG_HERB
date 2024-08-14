<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_COMTACT_APPOINMENT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_COMTACT_APPOINMENT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.blockUI.js"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">

        $(function () {
            $('#<%= Button1.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="panel" style="width: 100%">
        <div class="panel-heading panel-title">
            <div class="row">
                <div class="col-lg-2">
                </div>
                <div class="col-lg-8">
                    <h1>กรุณากรอกข้อมูล รายละเอียดประกอบการนัดหมาย</h1>
                </div>

            </div>

        </div>

        <div class="panel-body">
            <div class="row">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-1">
                    <asp:Label ID="lbl_app_date" runat="server" Text="ชื่อผู้ติดต่อ :" Font-Size="Medium"></asp:Label>
                    <%--<p>วันที่อนุมัติ</p>--%>
                </div>
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_name_appoinment" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <p style="color: red" runat="server" id="Check_1" visible="false">*กรุณากรอกข้อมูล</p>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-1">
                    <asp:Label ID="Label1" runat="server" Text="E-mail :" Font-Size="Medium"></asp:Label>
                    <%--<p>วันที่อนุมัติ</p>--%>
                </div>
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_email_Appoinment" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <p style="color: red" runat="server" id="Check_2" visible="false">*กรุณากรอกข้อมูล</p>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-1">
                    <asp:Label ID="Label2" runat="server" Text="หมายเลขโทรศัพท์ติดต่อกลับ : " Font-Size="Medium"></asp:Label>
                    <%--<p>วันที่อนุมัติ</p>--%>
                </div>
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_Phone_Appoinment" runat="server" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <p style="color: red" runat="server" id="Check_3" visible="false">*กรุณากรอกข้อมูล</p>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>

        <br />
        <div class="row">
            <div class="col-lg-5">
            </div>
            <div class="col-lg-3">
                <h1>ส่วนลดค่าคำขอ (ถ้ามี)</h1>
            </div>
            <hr />
        </div>

        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label3" runat="server" Text="โปรดเลือกเงื่อนไขส่วนลดค่าคำขอ : " Font-Size="Medium"></asp:Label>
                <%--<p>วันที่อนุมัติ</p>--%>
            </div>
            <div class="col-lg-4">
                <%--<asp:DropDownList ID="DD_DISCOUNT" runat="server" BackColor="White" Width="100%" SkinID="bootstrap" AutoPostBack="true"></asp:DropDownList>--%>
                <telerik:RadComboBox ID="DD_DISCOUNT" runat="server" Filter="Contains" Width="100%"></telerik:RadComboBox>
            </div>
            <div class="col-lg-2">
                <p style="color: red" runat="server" id="P1" visible="false">&nbsp;</p>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label4" runat="server" Text="รายละเอียดส่วนลดค่าคำขอ : " Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_Discount_Detail" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <br />

        <div class="panel-footer " style="text-align: center;">

            <asp:Button ID="Button2" runat="server" Text="ยกเลิก" CssClass="btn-lg" />
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_LCN_SUBTITUTE_APP_DATE.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_STAFF_LCN_SUBTITUTE_APP_DATE" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UC/UC_ATTACH_LCN.ascx" TagPrefix="uc1" TagName="UC_ATTACH_LCN" %>

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
                <div class="col-lg-5">
                </div>
                <div class="col-lg-3">
                    <h1>วันที่อนุมัติคำขอ</h1>
                </div>

            </div>

        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-1">
                    <asp:Label ID="lbl_app_date" runat="server" Text="วันที่อนุมัติ" Font-Size="Medium"></asp:Label>
                    <%--<p>วันที่อนุมัติ</p>--%>
                </div>
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    <telerik:RadDatePicker ID="RDP_APP_DATE" runat="server">
                    </telerik:RadDatePicker>
                </div>
                <div class="col-lg-2">
                    <p style="color: red">*(วัน/เดือน/ปี พ.ศ. => 1/10/2563)</p>
                </div>
                <div class="col-lg-5"></div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-1">
                    <asp:Label ID="Label1" runat="server" Text="จนท.ที่รับผิดชอบ:" Font-Size="Medium"></asp:Label>
                    <%--<p>วันที่อนุมัติ</p>--%>
                </div>
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2">
                    <asp:DropDownList ID="DD_OFF_REQ" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME" Width="100%"></asp:DropDownList>
                </div>
                <div class="col-lg-5"></div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-4" style="text-align: right">
                    <p>แนบเอกสารใบแทน</p>
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <uc1:UC_ATTACH_LCN runat="server" ID="UC_ATTACH_LCN1" />
                </div>
            </div>
        </div>
        <div class="panel-footer " style="text-align: center;">
            <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
            &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก" CssClass="btn-lg" />
        </div>
    </div>

</asp:Content>

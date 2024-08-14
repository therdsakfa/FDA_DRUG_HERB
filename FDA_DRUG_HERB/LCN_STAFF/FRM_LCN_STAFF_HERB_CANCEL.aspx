<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_LCN_STAFF_HERB_CANCEL.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_STAFF_HERB_CANCEL" %>

<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.blockUI.js"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">

 <%--       $(function () {
            $('#<%= Button1.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });--%>

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="panel" style="width: 100%">
        <div class="panel-heading panel-title">
            <div class="row">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-8">
                    <h1>กรุณากรอกรายละเอียด</h1>
                </div>

            </div>

        </div>

        <div class="panel-body">
            <br />
           <%-- <div class="row">
                <div class="col-lg-5">
                </div>
                <div class="col-lg-3">
                    <h1>รายละเอียดการ </h1>
                </div>
                <hr />
            </div>--%>

            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-2">
                    <asp:Label ID="Label3" runat="server" Text="โปรดเลือกเหตุผล : " Font-Size="Medium"></asp:Label>
                    <%--<p>วันที่อนุมัติ</p>--%>
                </div>
                <div class="col-lg-4">
                    <%--<asp:DropDownList ID="DD_DISCOUNT" runat="server" BackColor="White" Width="100%" SkinID="bootstrap" AutoPostBack="true"></asp:DropDownList>--%>
                    <telerik:RadComboBox ID="DD_CANCEL" runat="server" Filter="Contains" Width="100%"></telerik:RadComboBox>
                </div>
                <div class="col-lg-2">
                    <p style="color: red" runat="server" id="P1" visible="false">&nbsp;</p>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-2">
                    <asp:Label ID="Label4" runat="server" Text="รายละเอียด(ถ้ามี) : " Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-lg-4">
                    <asp:TextBox ID="txt_cencel_note" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
             <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-2">
                    <asp:Label ID="Label1" runat="server" Text="วันที่ยกเลิก : " Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-lg-4">
                    <asp:TextBox ID="txt_cancel_date" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
                 <div class="row">
                      <div class="col-lg-4"></div>
                      <div class="col-lg-6" style="text-align: center">
                          <uc1:uc_attach id="UC_ATTACH1" runat="server" />
                          <%--<asp:Label ID="chk_file2" runat="server" Text="lbl_2"></asp:Label>--%>
                      </div>
                  </div>
            <br />

            <div class="panel-footer " style="text-align: center;">

                <asp:Button ID="btn_close" runat="server" Text="ยกเลิก" CssClass="btn-lg" />
                &nbsp;&nbsp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการยกเลิกคำขอหรือไม่');"/>
            </div>
        </div>
    </div>
</asp:Content>


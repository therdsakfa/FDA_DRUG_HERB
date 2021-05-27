<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_LCN_APPDATE.aspx.vb" Inherits="FDA_DRUG_HERB.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.blockUI.js"></script>
 <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript" >
 
        $(function () {
            $('#<%= Button1.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });

    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
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
                        <asp:TextBox ID="txt_app_date" runat="server" CssClass="input-lg" Width="95%"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <p style="color:red">*(วัน/เดือน/ปี พ.ศ. => 1/10/2563)</p>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--<table class="table">
                    <tr ><td>วันที่อนุมัติ</td><td>
                        <asp:TextBox ID="txt_app_date" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>            --%>

                    <%--<tr ><td>วันที่คาดว่าจะอนุมัติ</td><td>
                        <asp:TextBox ID="txt_app_date" runat="server" class="input-lg"></asp:TextBox></td></tr>--%>

<%--                </table>--%>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>

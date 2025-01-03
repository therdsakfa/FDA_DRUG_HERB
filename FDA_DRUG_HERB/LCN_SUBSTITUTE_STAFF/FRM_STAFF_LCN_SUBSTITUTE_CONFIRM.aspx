﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_SUBSTITUTE_CONFIRM.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_SUBSTITUTE_CONFIRM" %>

<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UC/UC_GRID_PHARMACIST.ascx" TagName="UC_GRID_PHARMACIST" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<script type="text/javascript">
              $(document).ready(function () {
                  $(window).load(function () {
                      $.ajax({
                          type: 'POST',
                          data: { submit: true },
                          success: function (result) {
                              //    $('#spinner').fadeOut('slow');
                          }
                      });
                  });

                  function CloseSpin() {
                      $('#spinner').toggle('slow');
                  }

                  $('#ContentPlaceHolder1_btn_upload').click(function () {

                      $('#spinner').toggle('slow');
                      Popups('POPUP_LCN_UPLOAD.aspx');
                      return false;
                  });

                  $('#ContentPlaceHolder1_btn_download').click(function () {
                      $('#spinner').fadeIn('slow');
                      Popups('POPUP_LCN_DOWNLOAD.aspx');
                      return false;
                  });

                  function Popups(url) { // สำหรับทำ Div Popup
                      $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                      var i = $('#f1'); // ID ของ iframe   
                      i.attr("src", url); //  url ของ form ที่จะเปิด
                  }

                  function close_modal() { // คำสั่งสั่งปิด PopUp
                      $('#myModal').modal('hide');
                      $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                  }
              });

              function spin_space() { // คำสั่งสั่งปิด PopUp
                  //    alert('123456');
                  $('#spinner').toggle('slow');
                  //$('#myModal').modal('hide');
                  //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

              }
              function closespinner() {
                  $('#spinner').fadeOut('slow');
                  alert('Download Success');
                  Loaddata();
              }
    </script><div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />

    </div>

    <div>

        <asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control">
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
        </asp:HyperLink>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <table style="width: 100%; height: 500px;">
        <tr>
            <td rowspan="2" style="width: 70%;">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div>
                    <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
                </div>
            </td>
            <td style="padding-left: 10%; height: 50%;">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                <table class="table" style="width: 90%">
                    <%--<tr>
                         <td>
                             <asp:Label ID="lbl_rqt" runat="server" Text="โปรดเลือกกระบวนงานที่ท่านต้องการยื่น"></asp:Label>
                             <telerik:radcombobox ID="ddl_req_type" Runat="server" Width="80%" Filter="Contains">
                             </telerik:radcombobox>
                         </td>
                     </tr>--%>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server">
                                <asp:Label ID="Label2" runat="server" Text="แบบฟอร์ม PDF:"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:DropDownList ID="ddl_template" runat="server" Width="80%" AutoPostBack="True">
                                    <asp:ListItem Value="0">---เลือกแบบ pdf---</asp:ListItem>
                                    <asp:ListItem Value="1">pdf แบบปกติ</asp:ListItem>
                                    <asp:ListItem Value="2">pdf แบบบ้านเลขที่ยาว</asp:ListItem>
                                </asp:DropDownList>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel2" runat="server">
                                <asp:Label ID="Label1" runat="server" Text="กรุณาเลือกสถานะ:"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddl_cnsdcd" runat="server" Width="80%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                            </asp:DropDownList>

                        </td>
                    </tr>
                       <tr>
                        <td>
                            <asp:Panel ID="Panel4" runat="server">
                                <asp:Label ID="Label3" runat="server" Text="จนท. ที่รับผิดชอบ:"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DDL_STAFF_NAME" runat="server" Width="80%" DataTextField="STAFF_NAME" DataValueField="IDA">
                            </asp:DropDownList>

                        </td>
                    </tr>
                       <tr>
                        <td>
                            <asp:Panel ID="Panel5" runat="server">
                                <asp:Label ID="Label4" runat="server" Text="วันที่ตรวจรับคำขอ:"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                      <tr>
                        <td>
                           <asp:TextBox ID="DATE_REQ" runat="server" Style="width: 90%"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
                         <td>
                         <asp:Panel ID="Panel4" runat="server">
                             <asp:Label ID="Label3" runat="server" Text="กรุณาเลือกสถานะ:"></asp:Label></asp:Panel>
                             </td>
                     </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txt_appdate" runat="server" Width="80%"></asp:TextBox>

                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg" Width="100%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="100%" OnClientClick="return confirm('คุณต้องการยกเลิกข้อคำขอหรือไม่');" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_preview" runat="server" Text="Preview สมพ.๒(ใบแทน)" CssClass="btn-lg" Width="100%" /></td>
                    </tr>
                    <%-- <tr>
                        <td>
                            <asp:Button ID="btn_load" runat="server" Text="ดาวน์โหลด สมพ.๒(ใบแทน)" CssClass="btn-lg" Width="100%" /></td>
                    </tr>--%>
                    <tr>
                        <td>
                            <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="100%" /></td>
                    </tr>

                </table>



            </td>
        </tr>
        <tr>
            <td style="width: 30%; height: 50%; padding-left: 10%">

                <uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" />

                <br />

            </td>
        </tr>
    </table>

</asp:Content>

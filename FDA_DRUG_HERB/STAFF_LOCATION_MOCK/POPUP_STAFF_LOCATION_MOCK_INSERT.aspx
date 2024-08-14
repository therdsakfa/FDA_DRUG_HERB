<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_LOCATION_MOCK_INSERT.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_STAFF_LOCATION_MOCK_INSERT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_REQ"));
            $("#ContentPlaceHolder1_DD_OFF_REQ").searchable();
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row" style="padding-left: 1em">
        <div class="col-lg-8" style="width: 70%; border: groove; height: 750px; padding-left: 2em">
            <div>
                <div class="row">
                    <div class="col-lg-12" style="text-align: center;">
                        <h3>เพิ่มข้อมูลใบอนุญาตสถานที่จำลอง</h3>
                    </div>
                </div>

                <div style="padding-top: 15px"></div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        ชื่อ-นามสกุล
                    </div>
                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="txt_name_request" runat="server" Width="100%"  BorderStyle="None"  ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lbl_name_request" runat="server" Text="*กรุณากรอกชื่อ-นามสกุล" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="TXT_SEARCH_TN" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1">
                        <asp:Button ID="BTN_SEARCH_TN" runat="server" Text="ค้นหา" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div>
                     <div class="row">
                         <div class="col-lg-1"></div>
                         <div class="col-lg-5">
                              <h4>ข้อมูลผู้ขออนุญาต</h4>
                         </div>
                     </div>
                   
                    <div class="row">
                        <div class="col-lg-1">
                        </div>
                        <div class="col-lg-2" style="text-align: left">
                            ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                        </div>
                        <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_name" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            <%--<asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2"></div>
                    </div>
             <%--       <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            อายุ 
                        </div>
                        <div class="col-lg-1" style="border-bottom: #999999 1px dotted; text-align: center">
                            <asp:TextBox ID="lbl_lcn_ages" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-lg-2" style="text-align: center">ปี</div>
                        <div class="col-lg-1" style="text-align: center">สัญชาติ</div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted; text-align: center">
                            <asp:TextBox ID="lbl_lcn_nation" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-lg-2"></div>
                    </div>--%>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-3">
                            เลขประจำตัวประชาชน หรือเลขทะเบียนนิติบุคคล
                        </div>
                        <div class="col-lg-5
                                        "
                            style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_iden" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_iden" runat="server" EnableTheming="True" Width="80%"></asp:Label>--%>
                        </div>
                        <div class="col-lg-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            ที่อยู่เลขที่
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_addr" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%--<asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2" style="text-align: center">
                            ชั้นที่
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_floor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_floor" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-1">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            ห้องเลขที่
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_room" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%--<asp:Label ID="lbl_lcn_room" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2" style="text-align: center">
                            หมู่บ้าน/อาคาร
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_building" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-1">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            หมู่ที่
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_mu" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%--   <asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2" style="text-align: center">
                            ตรอก/ซอย
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_soi" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-1">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            ถนน
                        </div>
                        <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_road" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            ตำบล/แขวง
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_tambol" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%--<asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2" style="text-align: center">
                            อำเภอ/เขต
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_amphor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            จังหวัด
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_changwat" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%--<asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2" style="text-align: center">
                            รหัสไปรษณีย์
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_zipcode" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%--  <asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            โทรสาร
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_fax" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%--<asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2" style="text-align: center">
                            โทรศัพท์
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_tel" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <div class="col-lg-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            E-mail
                        </div>
                        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                            <asp:TextBox ID="lbl_lcn_email" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
                            <%-- <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>--%>
                        </div>
                        <%-- <div class="col-lg-2" style="text-align: center">
                            เวลาทำการรวมของร้าน
                        </div>
                        <div class="col-lg-2">
                            <asp:TextBox ID="txt_da_opentime" runat="server"></asp:TextBox>
                            <asp:Label ID="Label61" runat="server" Text="" Style="display: none">
                                <p style="color: red">*กรุณาระบุเวลาทำการ</p>
                            </asp:Label>
                        </div>--%>
                        <div class="col-lg-2">
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">ประเภทใบอนุญาต</div>
                    <div class="col-lg-8" style="text-align: right">
                            <asp:RadioButtonList ID="rdl_lcn_type" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                <asp:ListItem Value="1">ผลิตผลิตภัณฑ์สมุนไพร&ensp;&ensp;</asp:ListItem>
                                <asp:ListItem Value="2">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                            </asp:RadioButtonList>
                        <asp:Label ID="lbl_lcn_type" runat="server" Text="*กรุณาเลือกประการขออนุญาต" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label4" runat="server" Text="ยื่นคำขอวันที่" Font-Size="Medium" ReadOnly="true"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txt_date_confirm" runat="server" Width="90%" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lbl_date_confirm" runat="server" Text="*กรุณากรอกวันที่ยื่นคำขอ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <%--                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <asp:Label ID="Label7" runat="server" Text="ผู้มาติดต่อ" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txt_name_contact" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lbl_name_contact" runat="server" Text="*กรุณากรอกข้อมูลผู้มาติดต่อ" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="TXT_SEARCH_TN2" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>--%>
            </div>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row" runat="server" id="KEEP_PAY" visible="true">
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">จนท. ที่รับผิดชอบ</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="DD_OFF_REQ" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>

            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องของข้อมูล');" />
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />
        </div>
    </div>
</asp:Content>

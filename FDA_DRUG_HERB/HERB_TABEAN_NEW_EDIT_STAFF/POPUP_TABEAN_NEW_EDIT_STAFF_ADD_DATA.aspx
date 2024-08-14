<%@ Page Title="" Language="vb" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_NEW_EDIT_STAFF_ADD_DATA.aspx.vb" Inherits="FDA_DRUG_HERB.POPUP_TABEAN_NEW_EDIT_STAFF_ADD_DATA" %>

<%--<%@ Register Src="~/HERB_TABEAN_NEW_EDIT/UC/UC_TABEAN_EDIT_SELECT_LIST.ascx" TagPrefix="uc1" TagName="UC_TABEAN_EDIT_SELECT_LIST" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/HERB_TABEAN_NEW_EDIT/UC/UC_TABEAN_EDIT_DETAIL_CAS.ascx" TagPrefix="uc1" TagName="UC_TABEAN_EDIT_DETAIL_CAS" %>
<%@ Register Src="~/HERB_TABEAN_NEW_EDIT/UC/UC_TABEAN_EDIT_EQTO.ascx" TagPrefix="uc1" TagName="UC_TABEAN_EDIT_EQTO" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_UC_TABEAN_EDIT_txt_Write_Date"));
            $("#ContentPlaceHolder1_UC_TABEAN_EDIT_txt_Write_Date").searchable();

            showdate($("ContentPlaceHolder1_UC_EXHIBITION_DETAIL_txt_date_exh"));
            $("ContentPlaceHolder1_UC_EXHIBITION_DETAIL_txt_date_exh").searchable();
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="width: 100%; padding-left: 5%; padding-right: 5%; padding-top: 0.1%; background-color: gray;">
        <div class="panel panel-body" style="width: auto; height: 100%; padding-left: 5%; padding-right: 5%; background-color: white;">
            <div class="row">
                <%--           <div class="col-lg-1"></div>--%>
                <div class="col-lg-10">
                    <%--   <asp:Panel ID="Panel1" runat="server">--%>
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
                            <div class="col-lg-4">
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
                                <asp:TextBox ID="txt_rgtno" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
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
                                <asp:CheckBox ID="CB_NAME_PRODUCT_ID" Text="&nbsp;ชื่อของผลิตภัณฑ์สมุนไพร" runat="server" AutoPostBack="True" />
                                <br />

                                <div id="DV_NAME_SL" runat="server" style="padding-left: 2em" visible="false" aria-disabled="false">
                                    <asp:CheckBox ID="CB_NAME_ENG" Text="&nbsp;1. เพิ่มชื่อผลิตภัณฑ์ภาษาอังกฤษ " runat="server" AutoPostBack="true" />
                                    <asp:Panel ID="Panel_Name_Eng" runat="server" Style="display: none;">
                                        <div runat="server" id="DIV_NAME_ENG">
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-5">
                                                    <h3>ข้อมูลเดิม</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-3" style="color: red">
                                                    <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อภาษาอังกฤษ:</label>
                                                </div>
                                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                    <asp:TextBox ID="NAME_ENG" runat="server" TextMode="MultiLine" Width="337px" Height="50px" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อภาษาอังกฤษ:</label>
                                                </div>
                                                <div class="col-lg-3">
                                                    <asp:TextBox ID="NAME_ENG_NEW" runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <asp:CheckBox ID="CB_NAME_OTHER" Text="&nbsp;2. เพิ่มชื่อผลิตภัณฑ์ภาษาอื่น " runat="server" AutoPostBack="true" />
                                    <asp:Panel ID="Panel_Name_Other" runat="server" Style="display: none;">
                                        <div runat="server" id="DIV_NAME_OTHER">
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-5">
                                                    <h3>ข้อมูลเดิม</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-3" style="color: red">
                                                    <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อผลิตภัณฑ์ภาษาอื่น:</label>
                                                </div>
                                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                    <asp:TextBox ID="NAME_OTHER" runat="server" TextMode="MultiLine" Width="337px" Height="50px" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อผลิตภัณฑ์ภาษาอื่น:</label>
                                                </div>
                                                <div class="col-lg-3">
                                                    <asp:TextBox ID="NAME_OTHER_NEW" runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <asp:CheckBox ID="CB_NAME_EXPORT" Text="&nbsp;3. เพิ่มชื่อผลิตภัณฑ์เพื่อการส่งออก" runat="server" AutoPostBack="true" />
                                    <asp:Panel ID="Panel_Name_Export" runat="server" Style="display: none;">
                                        <div runat="server" id="DIV_NAME_EXPORT">
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-5">
                                                    <h3>ข้อมูลเดิม</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-3" style="color: red">
                                                    <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อผลิตภัณฑ์เพื่อการส่งออก:</label>
                                                </div>
                                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                    <asp:TextBox ID="NAME_EXPORT" runat="server" TextMode="MultiLine" Width="337px" Height="50px" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อผลิตภัณฑ์เพื่อการส่งออก:</label>
                                                </div>
                                                <div class="col-lg-3">
                                                    <asp:TextBox ID="NAME_EXPORT_NEW" runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <asp:CheckBox ID="CB_NAME_THAI" Text="&nbsp;4. เพิ่มชื่อผลิตภัณฑ์ภาษาไทย " runat="server" AutoPostBack="true" />
                                    <asp:Panel ID="Panel_Name_Thai" runat="server" Style="display: none;">
                                        <div runat="server" id="DIV_NAME_THAI">
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-5">
                                                    <h3>ข้อมูลเดิม</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-3" style="color: red">
                                                    <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อภาษาไทย:</label>
                                                </div>
                                                <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                    <asp:TextBox ID="NAME_THAI_OLD" runat="server" TextMode="MultiLine" Width="337px" Height="50px" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อภาษาไทย:</label>
                                                </div>
                                                <div class="col-lg-3">
                                                    <asp:TextBox ID="NAME_THAI_NEW" runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                </div>

                                <%--------------------------------------------------------------" CB_NAME_LOCATION_ID "---------------------------------------------------------------------------------%>

                                <asp:CheckBox ID="CB_NAME_LOCATION_ID" Text="&nbsp;ชื่อหรือที่อยู่ของสถานที่ผลิต/ นำเข้ำ" runat="server" AutoPostBack="True" />
                                <br />
                                <div id="Div_NAME_LOCATION" runat="server" style="padding-left: 2em" visible="false">
                                    <asp:CheckBox ID="CheckBox1" Text="&nbsp;1.เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนุญาตผลิตให้ตรงตามใบอนุญาตผลิตผลิตภัณฑ์สมุนไพร" runat="server" AutoPostBack="true" />
                                    <asp:Panel ID="Panel_cheng_Location" runat="server" Style="display: none;">
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-5">
                                                <h3>ข้อมูลเดิม</h3>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                เลขที่ใบอนุญาต
                                            </div>
                                            <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_lcnno_display" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ประเภทใบอนุญาต
                                            </div>
                                            <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_lcntpcd" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-5" style="color: red">
                                                <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                จังหวัด (Province Code)
                                            </div>
                                            <div class="col-lg-2">
                                                <%--                       <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3"></div>
                                            <div class="col-lg-2">
                                                <asp:TextBox ID="txt_lcnno" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Button ID="BTN_SEARCH_LCN" runat="server" Text="ค้นหา" />
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-10" style="color: red">
                                                หากค้นหาใบอนุญาต กรุณากรอกคำค้นในรูปแบบ yyxxxx (ตัวอย่างเช่น : 1/2528 กรอกคำค้นเป็น 2850001)
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                เลขที่ใบอนุญาต
                                            </div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_lcnno_display_new" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ประเภทใบอนุญาต
                                            </div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_lcntpcd_new" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ชื่อผู้รับอนุญาต
                                            </div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_name_thanm" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ชื่อสถานที่
                                            </div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_name_location" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ที่อยู่
                                            </div>
                                            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_Full_addr" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <asp:CheckBox ID="CheckBox2" Text="&nbsp;2.เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนุญาตนำหรือสั่งให้ตรงตามใบอนุญาตนำ หรือสั่ง ผลิตภัณฑ์สมุนไพร " runat="server" AutoPostBack="true" />
                                    <asp:Panel ID="Panel_cheng_Location2" runat="server" Style="display: none;">
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-5">
                                                <h3>ข้อมูลเดิม</h3>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                เลขที่ใบอนุญาต
                                            </div>
                                            <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_lcnno_display2" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ประเภทใบอนุญาต
                                            </div>
                                            <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_lcntpcd2" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-5" style="color: red">
                                                <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                จังหวัด (Province Code)
                                            </div>
                                            <div class="col-lg-2">
                                                <%--                       <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddl_Province2" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3"></div>
                                            <div class="col-lg-2">
                                                <asp:TextBox ID="txt_lcnno2" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Button ID="BTN_SEARCH_LCN2" runat="server" Text="ค้นหา" />
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-10" style="color: red">
                                                <%--หากค้นหาใบอนุญาตที่มี จ. เป็นเลขที่ใบอนุญาต กรุณากรอกคำค้นในรูปแบบ yy5xxxx (ตัวอย่างเช่น : จ. 1/2528 กรอกคำค้นเป็น 2850001)--%>
                                                หากค้นหาใบอนุญาต กรุณากรอกคำค้นในรูปแบบ yyxxxx (ตัวอย่างเช่น : 1/2528 กรอกคำค้นเป็น 2850001)
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                เลขที่ใบอนุญาต
                                            </div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_lcnno_display_new2" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ประเภทใบอนุญาต
                                            </div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_lcntpcd_new2" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ชื่อผู้รับอนุญาต
                                            </div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_name_thanm2" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ชื่อสถานที่
                                            </div>
                                            <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_name_location2" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-2">
                                                ที่อยู่
                                            </div>
                                            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                                <asp:Label ID="lbl_Full_addr2" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <asp:CheckBox ID="CheckBox3" Text="&nbsp;3.เปลี่ยนแปลงชื่อหรือที่อยู่ ของผู้รับอนญาตผลิตต่างประเทศ " runat="server" AutoPostBack="true" />
                                    <asp:Panel ID="Panel_cheng_Location3" runat="server" Style="display: none;">
                                        <div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-5">
                                                    <h3>ข้อมูลเดิม</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อผู้ผลิตต่างประเทศ:</label>
                                                </div>
                                                <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                                    <asp:TextBox ID="txt_name_producer" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ที่อยู่ ผู้ผลิตต่างประเทศ:</label>
                                                </div>
                                                <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                                    <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="60px" Width="100%" BorderStyle="None"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-5" style="color: red">
                                                    <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ผู้ผลิตต่างประเทศ:</label>
                                                </div>
                                                <div class="col-lg-6" style="border-bottom: #999999 1px dotted">
                                                    <asp:TextBox ID="txt_search" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
                                                    <asp:TextBox ID="txt_search_ida" runat="server" Width="100%" BorderStyle="None" Visible="false"></asp:TextBox>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-3"></div>
                                                <div class="col-lg-6" style="width: 60%">
                                                    <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
                                                        PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                            </RowIndicatorColumn>
                                                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                            </ExpandCollapseColumn>
                                                            <Columns>
                                                                <%--<telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="frgncd" DataType="System.Int32" FilterControlAltText="Filter frgncd column" HeaderText="frgncd"
                                                                    SortExpression="frgncd" UniqueName="frgncd" Display="false" AllowFiltering="true">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="engfrgnnm" FilterControlAltText="Filter engfrgnnm column"
                                                                    HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาอังกฤษ)" SortExpression="engfrgnnm" UniqueName="engfrgnnm">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="thafrgnnm" FilterControlAltText="Filter thafrgnnm column"
                                                                    HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาไทย)" SortExpression="thafrgnnm" UniqueName="thafrgnnm">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                                                    CommandName="sel" Text="เลือก">
                                                                    <HeaderStyle Width="70px" />
                                                                </telerik:GridButtonColumn>
                                                            </Columns>
                                                            <EditFormSettings>
                                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                            </EditFormSettings>
                                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        </MasterTableView>
                                                        <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                                                            <Selecting AllowRowSelect="true" />
                                                        </ClientSettings>
                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                                                    </telerik:RadGrid>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-3"></div>
                                                <div class="col-lg-6" style="width: 60%">
                                                    <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="10"
                                                        PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                            </RowIndicatorColumn>
                                                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                            </ExpandCollapseColumn>
                                                            <Columns>
                                                                <%--<telerik:GridClientSelectColumn UniqueName="SelectColumn" />--%>
                                                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="fulladdr2" FilterControlAltText="Filter fulladdr2 column"
                                                                    HeaderText="ที่อยู่" SortExpression="fulladdr2" UniqueName="fulladdr2">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                                                    CommandName="sel" Text="เลือก">
                                                                    <HeaderStyle Width="70px" />
                                                                </telerik:GridButtonColumn>
                                                            </Columns>
                                                            <EditFormSettings>
                                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                            </EditFormSettings>
                                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        </MasterTableView>
                                                        <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                                                            <Selecting AllowRowSelect="true" />
                                                        </ClientSettings>
                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                                                    </telerik:RadGrid>
                                                </div>
                                                <div class="col-lg-3"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ที่อยู่ ผู้ผลิตต่างประเทศ:</label>
                                                </div>
                                                <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                                    <asp:TextBox ID="txt_address_New" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                                                    <asp:TextBox ID="txt_address_ida" runat="server" TextMode="MultiLine" Height="60px" Width="100%" Visible="false"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                </div>

                                <%------------------------------------------------------------" CB_PRODUCT_RECIPE_ID "------------------------------------------------------------------------%>

                                <asp:CheckBox ID="CB_PRODUCT_RECIPE_ID" Text="&nbsp;ตำรับผลิตภัณฑ์สมุนไพร " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="PANEL_PRODUCT_RECIPE" runat="server" Style="display: none;">
                                    <div id="Div_SubProductRecipe" runat="server" style="padding-left: 2em">
                                        <asp:CheckBox ID="CheckBox_SubRecipe1" Text="&nbsp;1. เพิ่ม/แก้ไขชื่อวิทยาศาสตร์/ชื่อภาษาอังกฤษในสูตรตำรับ " runat="server" />
                                        <br />
                                        <div id="Div2" runat="server" style="padding-left: 3em">
                                            <asp:CheckBox ID="CheckBox_SubRecipe1_1" Text="&nbsp;1.1 เพิ่มชื่อวิทยาศาสตร์/ชื่อภาษาอังกฤษในสูตรตำรับ" runat="server" />
                                            <br />
                                            <asp:CheckBox ID="CheckBox_SubRecipe1_2" Text="&nbsp;1.2 แก้ไขชื่อวิทยาศาสตร์/ชื่อภาษาอังกฤษในสูตรตำรับ" runat="server" />
                                            <br />
                                        </div>
                                        <asp:CheckBox ID="CheckBox_SubRecipe2" Text="&nbsp;2. แก้ไขตัวยาไม่สำคัญในสูตรตำรับผลิตภัณฑ์ (Excipients) " runat="server" />
                                        <br />
                                        <div id="Div3" runat="server" style="padding-left: 3em">
                                            <asp:CheckBox ID="CheckBox_SubRecipe2_1" Text="&nbsp;2.1 แก้ไขสารช่วย (ซึ่งต้องเป็นไปตามประกาศกระทรวงฯ)" runat="server" />
                                            <br />
                                        </div>
                                    </div>

                                    <div id="DIV_RPRODUCT_RECIPE" runat="server" style="padding-left: 2em">
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-5">
                                                <h3>ข้อมูลเดิม</h3>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>

                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-10">
                                                <telerik:RadGrid ID="rg_chem" runat="server" Width="100%">
                                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                                                        <Columns>
                                                            <%--<telerik:GridClientSelectColumn UniqueName="chk" HeaderText="เลือก">
                                                            </telerik:GridClientSelectColumn>--%>
                                                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                                                SortExpression="IDA" UniqueName="IDA" Display="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="flineno" FilterControlAltText="Filter flineno column" HeaderText="สูตรที่"
                                                                SortExpression="flineno" UniqueName="flineno">
                                                            </telerik:GridBoundColumn>
                                                            <%--<telerik:GridTemplateColumn UniqueName="ROWS" HeaderText="ลำดับ">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txt_rows" runat="server" Width="20px"></asp:TextBox>
                                                                    <asp:Label ID="lbl_rows" runat="server" Text="" Style="display: none;"></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>--%>

                                                            <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column"
                                                                HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="qtytxt_all" FilterControlAltText="Filter qtytxt_all column" HeaderText="ปริมาณ/หน่วย" SortExpression="qtytxt_all" UniqueName="QTY">
                                                            </telerik:GridBoundColumn>
                                                            <%--<telerik:GridBoundColumn DataField="sunitthanm" FilterControlAltText="Filter sunitthanm column" HeaderText="หน่วย" SortExpression="sunitthanm" UniqueName="sunitthanm">
                                                            </telerik:GridBoundColumn>--%>
                                                            <%--   <telerik:GridBoundColumn DataField="REF" FilterControlAltText="Filter REF column" HeaderText="เอกสารอ้างอิง" SortExpression="REF" UniqueName="REF">
                                                            </telerik:GridBoundColumn>--%>
                                                            <telerik:GridBoundColumn DataField="AORI" FilterControlAltText="Filter AORI column" HeaderText="A/I" SortExpression="AORI" UniqueName="AORI">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column" HeaderText="หมายเหตุ" SortExpression="REMARK" UniqueName="REMARK">
                                                            </telerik:GridBoundColumn>
                                                            <%--                                                         <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_del" HeaderText="ลบรายการ" ConfirmText="ต้องการลบหรือไม่?"
                                                                CommandName="_del" Text="ลบ">
                                                                <HeaderStyle Width="70px" />
                                                            </telerik:GridButtonColumn>--%>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <ClientSettings EnableRowHoverStyle="true">
                                                        <Selecting AllowRowSelect="true" />
                                                    </ClientSettings>
                                                </telerik:RadGrid>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-5" style="color: red">
                                                <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                            </div>
                                            <div class="col-lg-1"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-10">
                                                <uc1:UC_TABEAN_EDIT_DETAIL_CAS runat="server" ID="UC_TABEAN_EDIT_DETAIL_CAS" />
                                            </div>
                                        </div>

                                        <%--        <div class="row">
                                            <div class="col-lg-12" style="text-align: center">
                                                <asp:Button ID="BTN_EQTO_EDIT" runat="server" Text="EQTO" />
                                            </div>
                                        </div>
                                        <panel runat="server" style="display: none;" id="Panel_EQTO_EDIT">
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-10">
                                                    <uc1:UC_TABEAN_EDIT_EQTO runat="server" ID="UC_TABEAN_EDIT_EQTO" />
                                                </div>
                                            </div>
                                        </panel>--%>
                                    </div>
                                </asp:Panel>
                                <br />

                                <%-------------------------------------------------" CB_PRODUCTION_PROCESS_ID "-----------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_PRODUCTION_PROCESS_ID" Text="&nbsp;กรรมวิธีการผลิต " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_Production_Process" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-6" style="text-align: left">
                                            <h3>กรรมวิธีการผลิตเดิม</h3>
                                            <hr />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <telerik:RadGrid ID="RG_PRODUCTION_PROCESS" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
                                                PagerStyle-Mode="NextPrevNumericAndAdvanced" Skin="Hay">
                                                <MasterTableView DataKeyNames="IDA">
                                                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA" HeaderText="IDA" DataType="System.Int32" Display="false"
                                                            FilterControlAltText="Filter IDA column" ReadOnly="True" SortExpression="IDA">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FK_IDA_DQ" UniqueName="FK_IDA_DQ" HeaderText="FK_IDA_DQ" FilterControlAltText="Filter FK_IDA_DQ column"
                                                            SortExpression="FK_IDA_DQ" Display="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NO_ID " UniqueName="NO_ID" HeaderText="ประเภทกระบวนการ" FilterControlAltText="Filter NO_ID column"
                                                            SortExpression="NO_ID">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MENUFAC_NAME " UniqueName="MENUFAC_NAME" HeaderText="MENUFAC_NAME" FilterControlAltText="Filter MENUFAC_NAME column"
                                                            SortExpression="MENUFAC_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                                                            CommandName="result_delete" UniqueName="result_delete">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                    </EditFormSettings>
                                                </MasterTableView>
                                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            </telerik:RadGrid>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <%-- </div>--%>
                                    <div class="row">
                                        <div class="col-lg-6" style="text-align: left; color: red">
                                            <h3>กรรมวิธีการผลิตที่ต้องแก้ไข</h3>
                                            <hr />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <telerik:RadGrid ID="RG_PRODUCTION_PROCESS_NEW" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
                                                PagerStyle-Mode="NextPrevNumericAndAdvanced" Skin="Hay">
                                                <MasterTableView DataKeyNames="IDA">
                                                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA" HeaderText="IDA" DataType="System.Int32" Display="false"
                                                            FilterControlAltText="Filter IDA column" ReadOnly="True" SortExpression="IDA">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FK_IDA_DQ" UniqueName="FK_IDA_DQ" HeaderText="FK_IDA_DQ" FilterControlAltText="Filter FK_IDA_DQ column"
                                                            SortExpression="FK_IDA_DQ" Display="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NO_ID " UniqueName="NO_ID" HeaderText="ประเภทกระบวนการ" FilterControlAltText="Filter NO_ID column"
                                                            SortExpression="NO_ID">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MENUFAC_NAME " UniqueName="MENUFAC_NAME" HeaderText="MENUFAC_NAME" FilterControlAltText="Filter MENUFAC_NAME column"
                                                            SortExpression="MENUFAC_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                                                            CommandName="result_delete" UniqueName="result_delete">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                    </EditFormSettings>
                                                </MasterTableView>
                                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            </telerik:RadGrid>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>กรรมวิธีการผลิต:</label>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">ลำดับกระบวนการ</div>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="NO_ID" runat="server" Width="100%" TextMode="Number"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">ประเภทกระบวนการ:</div>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="DD_MANUFAC_ID" runat="server" DataValueField="MANUFAC_ID" DataTextField="MANUFAC_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12" style="text-align: center">
                                            <asp:Button ID="btn_add_muc_add" runat="server" Text="เพิ่ม" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <br />

                                <%-------------------------------------------------" CB_PROPERTIES_ID "-------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_PROPERTIES_ID" Text="&nbsp;สรรพคุณ/ข้อบ่งใช้/ ข้อความกล่าวอ้างทางสุขภาพ" runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_Properties" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h3>ข้อมูลเดิม</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-3" style="color: red">
                                            <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>สรรพคุณ:</label>
                                        </div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="txt_PROPERTIES" runat="server" TextMode="MultiLine" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>สรรพคุณใหม่:</label>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_PROPERTIES_NEW" runat="server" TextMode="MultiLine" Style="width: 440px; height: 60px;" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <%--   <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>ข้อบ่งใช้:</label>
                                        </div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="txt_Indication" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>ข้อบ่งใช้ใหม่:</label>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_Indication_NEW" runat="server" TextMode="MultiLine" Style="width: 440px; height: 60px;" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>--%>
                                </asp:Panel>
                                <br />

                                <%---------------------------------------------------" CB_SIZE_PACK_ID "-----------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_SIZE_USE_ID" Text="&nbsp;ขนาดและวิธีการใช้ " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_Size_Use" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h3>ข้อมูลเดิม</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-3" style="color: red">
                                            <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>ขนาดและวิธีการใช้:</label>
                                        </div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="txt_Size_Use" runat="server" TextMode="MultiLine" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>ขนาดและวิธีการใช้:</label>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_Size_Use_New" TextMode="MultiLine" Style="width: 440px; height: 60px;" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                </asp:Panel>
                                <br />

                                <%---------------------------------------------------" CB_PREPARE_EAT_ID "---------------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_PREPARE_EAT_ID" Text="&nbsp;วิธีเตรียมก่อนรับประทาน " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_Prepare_Eat" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h3>ข้อมูลเดิม</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-3" style="color: red">
                                            <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>วิธีเตรียมก่อนรับประทาน:</label>
                                        </div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="txt_EATTING" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>วิธีเตรียมก่อนรับประทาน:</label>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="DD_EATTING_ID" runat="server" DataValueField="EATTING_ID" DataTextField="EATTING_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                </asp:Panel>
                                <br />

                                <%---------------------------------------------------" CB_EAT_CONDITION_ID "---------------------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_EAT_CONDITION_ID" Text="&nbsp;เงื่อนไขการรับประทาน " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_EatCondition" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h3>ข้อมูลเดิม</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-3" style="color: red">
                                            <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>เงื่อนไขการรับประทาน:</label>
                                        </div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="txt_EATING_CONDITION" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>เงื่อนไขการรับประทาน:</label>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="DD_EATING_CONDITION_ID" runat="server" DataValueField="PRO_CON_ID" DataTextField="PRO_CON_NAME" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="true">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-lg-2" id="R_EATING_CONDITION_TEXT" runat="server" visible="false">
                                            <asp:TextBox ID="EATING_CONDITION_NAME" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                </asp:Panel>
                                <br />

                                <%------------------------------------------------" CB_STORAGE_ID "-----------------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_STORAGE_ID" Text="&nbsp;การเก็บรักษา / อายุการเก็บรักษา " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_Storage" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h3>ข้อมูลเดิม</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-3" style="color: red">
                                            <h3>ข้อมูลที่ต้องการแก้ไข</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>การเก็บรักษา:</label>
                                        </div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="txt_STORAGE" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>การเก็บรักษา:</label>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="DD_STORAGE_ID" runat="server" DataValueField="PRO_MT_ID" DataTextField="PRO_MT_NAME" Style="width: 100%">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>อายุการเก็บรักษา:</label>
                                        </div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="txt_TREATMENT_AGE" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>อายุการเก็บรักษา:</label>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:DropDownList ID="TREATMENT_AGE_YEAR" runat="server" Width="50%" AutoPostBack="true">
                                                <asp:ListItem Value="0">-</asp:ListItem>
                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                <asp:ListItem Value="5">5</asp:ListItem>
                                            </asp:DropDownList>
                                            <label>&nbsp;&nbsp;&nbsp;ปี</label><label style="color: red">*</label>
                                        </div>

                                        <div class="col-lg-1" id="div_hide" runat="server">
                                            <asp:DropDownList ID="TREATMENT_AGE_MONTH_SUB" runat="server" Width="80%">
                                                <asp:ListItem Value="0">-</asp:ListItem>
                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                <asp:ListItem Value="6">6</asp:ListItem>
                                                <asp:ListItem Value="7">7</asp:ListItem>
                                                <asp:ListItem Value="8">8</asp:ListItem>
                                                <asp:ListItem Value="9">9</asp:ListItem>
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="11">11</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1" id="div_hide2" runat="server">
                                            <label>เดือน</label>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <br />

                                <%-----------------------------------------------" CB_CONTAINER_PACKING_ID "--------------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_CONTAINER_PACKING_ID" Text="&nbsp;ภาชนะและขนาดบรรจุ " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_Container_Packing" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h3>ข้อมูลเดิม</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>รายละเอียดขนาด:</label>
                                        </div>
                                        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="SIZE_PACK_OLD" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <telerik:RadGrid ID="RG_SIZE_PACK" runat="server">
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </RowIndicatorColumn>

                                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                                                            SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="PACK_FSIZE_NAME" FilterControlAltText="Filter PACK_FSIZE_NAME column"
                                                            HeaderText="primary packaging" SortExpression="PACK_FSIZE_NAME" UniqueName="PACK_FSIZE_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PACK_FSIZE_VOLUME" FilterControlAltText="Filter PACK_FSIZE_VOLUME column"
                                                            HeaderText="ขนาด" SortExpression="PACK_FSIZE_VOLUME" UniqueName="PACK_FSIZE_VOLUME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PACK_FSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_FSIZE_UNIT_NAME column"
                                                            HeaderText="หน่วย" SortExpression="PACK_FSIZE_UNIT_NAME" UniqueName="PACK_FSIZE_UNIT_NAME">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="PACK_SECSIZE_NAME" FilterControlAltText="Filter PACK_SECSIZE_NAME column"
                                                            HeaderText="secondary packaging" SortExpression="PACK_SECSIZE_NAME" UniqueName="PACK_SECSIZE_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PACK_SECSIZE_VOLUME" FilterControlAltText="Filter PACK_SECSIZE_VOLUME column"
                                                            HeaderText="ขนาด" SortExpression="PACK_SECSIZE_VOLUME" UniqueName="PACK_SECSIZE_VOLUME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PACK_SECSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_SECSIZE_UNIT_NAME column"
                                                            HeaderText="หน่วย" SortExpression="PACK_SECSIZE_UNIT_NAME" UniqueName="PACK_SECSIZE_UNIT_NAME">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="PACK_THSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_THSIZE_UNIT_NAME column"
                                                            HeaderText="tertiary packaging" SortExpression="PACK_THSIZE_UNIT_NAME" UniqueName="PACK_THSIZE_UNIT_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PACK_THSSIZE_VOLUME" FilterControlAltText="Filter PACK_THSSIZE_VOLUME column"
                                                            HeaderText="ขนาด" SortExpression="PACK_THSSIZE_VOLUME" UniqueName="PACK_THSSIZE_VOLUME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PACK_THSIZE_UNIT_NAME" FilterControlAltText="Filter PACK_THSIZE_UNIT_NAME column"
                                                            HeaderText="หน่วย" SortExpression="PACK_THSIZE_UNIT_NAME" UniqueName="PACK_THSIZE_UNIT_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                                                            CommandName="result_delete" UniqueName="result_delete">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                    </EditFormSettings>

                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                </MasterTableView>

                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            </telerik:RadGrid>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-6" style="text-align: left; color: red">
                                            <h3>ภาชนะและขนาดบรรจุที่ต้องแก้ไข</h3>
                                            <hr />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>รายละเอียดขนาด:</label>
                                        </div>
                                        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="SIZE_PACK_NEW" runat="server" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <div class="row">
                                                <div class="col-lg-2">Primary Packaging:</div>
                                                <div class="col-lg-2">
                                                    <asp:DropDownList ID="DD_PCAK_1" runat="server" DataValueField="PACK_PRIMARY_ID" DataTextField="PACK_PRIMARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2" style="text-align: right">จำนวน:</div>
                                                <div class="col-lg-2" style="text-align: right">
                                                    <asp:TextBox ID="NO_1" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2" style="text-align: right">หน่วย:</div>
                                                <div class="col-lg-2">
                                                    <asp:DropDownList ID="DD_UNIT_1" runat="server" DataValueField="UNIT_PRIMARY_ID" DataTextField="UNIT_PRIMARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">Seceondary Packaging:</div>
                                                <div class="col-lg-2">
                                                    <asp:DropDownList ID="DD_PCAK_2" runat="server" DataValueField="PACK_SEC_ID" DataTextField="PACK_SEC_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2" style="text-align: right">จำนวน:</div>
                                                <div class="col-lg-2">
                                                    <asp:TextBox ID="NO_2" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2" style="text-align: right">หน่วย:</div>
                                                <div class="col-lg-2">
                                                    <asp:DropDownList ID="DD_UNIT_2" runat="server" DataValueField="UNIT_SECONDARY_ID" DataTextField="UNIT_SECONDARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">Tertiary Packaging:</div>
                                                <div class="col-lg-2">
                                                    <asp:DropDownList ID="DD_PCAK_3" runat="server" DataValueField="PACK_TER_ID" DataTextField="PACK_TER_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2" style="text-align: right">จำนวน:</div>
                                                <div class="col-lg-2">
                                                    <asp:TextBox ID="NO_3" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2" style="text-align: right">หน่วย:</div>
                                                <div class="col-lg-2">
                                                    <asp:DropDownList ID="DD_UNIT_3" runat="server" DataValueField="UNIT_TERTIARY_ID" DataTextField="UNIT_TERTIARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12" style="text-align: center">
                                                    <asp:Button ID="btn_size_pack" runat="server" Text="เพิ่ม" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <telerik:RadGrid ID="RG_SIZE_PACK_NEW" runat="server">
                                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                            </RowIndicatorColumn>

                                                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                            </ExpandCollapseColumn>
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                                                    SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                                                                    SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                                                                </telerik:GridBoundColumn>

                                                                <telerik:GridBoundColumn DataField="PACK_F_NAME" FilterControlAltText="Filter PACK_F_NAME column"
                                                                    HeaderText="primary packaging" SortExpression="PACK_F_NAME" UniqueName="PACK_F_NAME">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="NO_1" FilterControlAltText="Filter NO_1 column"
                                                                    HeaderText="ขนาด" SortExpression="NO_1" UniqueName="NO_1">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="UNIT_F_NAME" FilterControlAltText="Filter UNIT_F_NAME column"
                                                                    HeaderText="หน่วย" SortExpression="UNIT_F_NAME" UniqueName="UNIT_F_NAME">
                                                                </telerik:GridBoundColumn>

                                                                <telerik:GridBoundColumn DataField="PACK_S_NAME" FilterControlAltText="Filter PACK_S_NAME column"
                                                                    HeaderText="secondary packaging" SortExpression="PACK_S_NAME" UniqueName="PACK_S_NAME">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="NO_2" FilterControlAltText="Filter NO_2 column"
                                                                    HeaderText="ขนาด" SortExpression="NO_2" UniqueName="NO_2">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="UNIT_S_NAME" FilterControlAltText="Filter UNIT_S_NAME column"
                                                                    HeaderText="หน่วย" SortExpression="UNIT_S_NAME" UniqueName="UNIT_S_NAME">
                                                                </telerik:GridBoundColumn>

                                                                <telerik:GridBoundColumn DataField="PACK_T_NAME" FilterControlAltText="Filter PACK_T_NAME column"
                                                                    HeaderText="tertiary packaging" SortExpression="PACK_T_NAME" UniqueName="PACK_T_NAME">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="NO_3" FilterControlAltText="Filter NO_3 column"
                                                                    HeaderText="ขนาด" SortExpression="NO_3" UniqueName="NO_3">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="UNIT_T_NAME" FilterControlAltText="Filter UNIT_T_NAME column"
                                                                    HeaderText="หน่วย" SortExpression="UNIT_T_NAME" UniqueName="UNIT_T_NAME">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                                                                    CommandName="result_delete" UniqueName="result_delete">
                                                                </telerik:GridButtonColumn>
                                                            </Columns>
                                                            <EditFormSettings>
                                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                            </EditFormSettings>

                                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        </MasterTableView>

                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                                                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                                                    </telerik:RadGrid>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <br />

                                <%----------------------------------------------" CB_QUALITY_CONTROL_ID "-------------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_QUALITY_CONTROL_ID" Text="&nbsp;วิธีควบคุมคุณภาพและข้อกำหนดเฉพาะของผลิตภัณฑ์สมุนไพร " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_Quality_Control" runat="server" Style="display: none;">
                                    <div id="Div_SubQuality_Control" runat="server" style="padding-left: 2em" visible="false">
                                        <asp:CheckBox ID="CheckBox_SubQuality1" Text="&nbsp;1. วิธีควบคุมคุณภาพและข้อกําหนดของตำรับยาองค์ความรู้ดั้งเดิม" runat="server" />
                                        <br />
                                        <asp:CheckBox ID="CheckBox_SubQuality2" Text="&nbsp;2. วิธีควบคุมคุณภาพและข้อกําหนดของตำรับยาพัฒนาจากสมุนไพร" runat="server" />
                                        <br />
                                    </div>
                                </asp:Panel>
                                <br />

                                <%--   -----------------------------------------------" CB_CER_LCN_ID "-----------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_CER_LCN_ID" Text="&nbsp;หนังสือรับรองการอนุญาตให้ขายหรือการขึ้นทะเบียนตำรับผลิตภัณฑ์สมุนไพร เฉพาะกรณีที่เป็นการนำเข้ำ " runat="server" AutoPostBack="True" Enabled="false" />
                                <br />

                                <%--------------------------------------------------" CB_ETIQUETQ_ID "---------------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_ETIQUETQ_ID" Text="&nbsp;ฉลาก และเอกสารกำกับผลิตภัณฑ์สมุนไพร" runat="server" AutoPostBack="True" />
                                <asp:Panel ID="PANEL_ETIQUETQ" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h3>ข้อมูลเดิม</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <telerik:RadGrid ID="RG_ETIQUETQ" runat="server">
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </RowIndicatorColumn>

                                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                                                            SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                                                            HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                                                            HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                    </EditFormSettings>

                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                </MasterTableView>

                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            </telerik:RadGrid>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-3" style="color: red">
                                            <h4>ข้อมูลใหม่ที่แก้ไข</h4>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <telerik:RadGrid ID="RG_ETIQUETQ_NEW" runat="server">
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </RowIndicatorColumn>

                                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                                                            SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                                                            HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                                                            HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                    </EditFormSettings>

                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                </MasterTableView>

                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            </telerik:RadGrid>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-3" style="color: red">
                                            <h4>แนบเอกสารใหม่</h4>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="text-align: center">
                                        <asp:Button ID="btn_save_at" runat="server" Text="อัพโหลดเอกสารแนบใหม่" Height="35px" />&ensp;
                                    </div>

                                </asp:Panel>
                                <br />
                                <%-- <asp:CheckBox ID="CB_PRODUCT_DOCUMENT_ID" Text="&nbsp;เอกสารกำกับผลิตภัณฑ์สมุนไพร " runat="server" AutoPostBack="True" /><br />--%>

                                <%-------------------------------------------------" CB_CHANNEL_SALE_ID "------------------------------------------------------------------------------------------%>
                                <asp:CheckBox ID="CB_CHANNEL_SALE_ID" Text="&nbsp;ช่องทางการจำหน่าย " runat="server" AutoPostBack="True" />
                                <asp:Panel ID="PANEL_CHANNEL_SALE" runat="server" Style="display: none;">
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h4>ข้อมูลเดิม</h4>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-3" style="color: red">
                                            <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>ช่องทางการขาย:</label>
                                        </div>
                                        <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                                            <asp:TextBox ID="txt_SALE_CHANNEL" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-2">
                                            <label>ช่องทางการขาย:</label>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="DD_SALE_CHANNEL" runat="server" DataValueField="SALE_CHANNEL_ID" DataTextField="SALE_CHANNEL_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                </asp:Panel>
                                <br />
                                <%-- <asp:CheckBox ID="cb_list_id_16" Text="&nbsp;อื่น ๆ " runat="server" AutoPostBack="True" Enabled="false"/><br />--%>

                                <asp:CheckBox ID="CB_OTHER" Text="&nbsp;อื่นๆ" runat="server" AutoPostBack="True" />
                                <asp:Panel ID="Panel_OTHER" runat="server" Style="display: none; padding-left: 3em">
                                    <asp:Panel runat="server" ID="Panel_Other_CC_Thanm">
                                        <asp:CheckBox ID="Sub_Other_licen" Text="&nbsp;เปลี่ยนผู้รับอนุญาต" runat="server" AutoPostBack="True" />
                                        <div runat="server" visible="false" id="dv_Other_licen">
                                          <%--  <h2>ข้อมูลผู้รับอนุญาต/ผู้รับใบสำคัญ</h2>--%>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อผู้รับอนุญาต:</label>
                                                </div>
                                                <div class="col-lg-4" style="text-align: left">
                                                    <asp:TextBox ID="NAME_LicenLoca_O" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label>เลขบัตรผู้รับอนุญาต:</label>
                                                </div>

                                                <div class="col-lg-3">
                                                    <asp:TextBox ID="IDEN_LICEN_O" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                                                    <%--<asp:TextBox ID="IDEN_LICEN_O" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>--%>
                                                </div>
                                            </div>
                                            <div class="row" runat="server" visible="true">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>เลขใบอนุญาต:</label>
                                                </div>
                                                <div class="col-lg-9">
                                                    <asp:TextBox ID="LCNNO_LICEN_O" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row" runat="server" visible="true">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ที่อยู่ผู้รับอนุญาต:</label>
                                                </div>
                                                <div class="col-lg-9">
                                                    <asp:TextBox ID="ADDR_LicenLoca_O" TextMode="MultiLine" Width="100%" Height="70" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>เลขใบอนุญาต</label><br />
                                                    <label style="color: red; font-size: smaller;">*ตัวอย่าง HB 10-1-65-99</label>
                                                </div>
                                                <%--<div class="col-lg-2">
                                                เลขบัตร<label style="color: red"> (ใหม่):</label>
                                            </div>--%>
                                                <div class="col-lg-3">
                                                    <asp:TextBox ID="TXT_LICEN_NO" runat="server" Width="100%"></asp:TextBox>
                                                    <asp:TextBox ID="LICENLOCA_IDEN_N" runat="server" Width="100%" Visible="false"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2" style="text-align: left">
                                                    <asp:Button ID="btn_serach_licen" runat="server" Text="ค้นหา" />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    ชื่อ<label style="color: red"> (ใหม่):</label>
                                                </div>
                                                <div class="col-lg-9">
                                                    <asp:TextBox ID="LICENLOCA_NAME_N" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row" runat="server" visible="true">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    ที่อยู่<label style="color: red"> (ใหม่):</label>
                                                </div>
                                                <div class="col-lg-9">
                                                    <asp:TextBox ID="LICENLOCA_ADDR_N" TextMode="MultiLine" Width="100%" Height="70" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                        </div>
                                        <br />
                                        <asp:CheckBox ID="Sub_Other_thanm" Text="&nbsp;เปลี่ยนผู้รับใบสำคัญ" runat="server" AutoPostBack="True" />
                                        <div runat="server" visible="false" id="dv_Other_thanm">
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ชื่อผู้รับใบสำคัญ:</label>
                                                </div>
                                                <div class="col-lg-4" style="text-align: left">
                                                    <asp:TextBox ID="NAME_HOLDER_O" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label>เลขบัตรผู้รับใบสำคัญ:</label>
                                                </div>
                                                <div class="col-lg-3">
                                                    <asp:TextBox ID="IDEN_HOLDER_O" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row" runat="server" visible="false">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>ที่อยู่ผู้รับใบสำคัญ:</label>
                                                </div>
                                                <div class="col-lg-9">
                                                    <asp:TextBox ID="ADDR_HOLDER_O" TextMode="MultiLine" Width="100%" Height="70" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <label>เลขบัตรผู้รับใบสำคัญ</label>
                                                </div>
                                                <div class="col-lg-3">
                                                    <asp:TextBox ID="HOLDER_IDEN_N" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2" style="text-align: left">
                                                    <asp:Button ID="btn_serach_iden_Holder" runat="server" Text="ค้นหา" />
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    ชื่อ(<label style="color: red">ใหม่</label>)
                                                </div>
                                                <div class="col-lg-9">
                                                    <asp:TextBox ID="HOLDER_NAME_N" runat="server" Width="100%"></asp:TextBox>
                                                </div>

                                                <div class="col-lg-1"></div>
                                            </div>

                                            <div class="row" runat="server" visible="false">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    ที่อยู่(<label style="color: red"> ใหม่</label>) :
                                                </div>
                                                <div class="col-lg-9">
                                                    <asp:TextBox ID="HOLDER_ADDR_N" TextMode="MultiLine" Width="100%" Height="70" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-1"></div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <hr />

                                    <div class="row">
                                        <div class="col-lg-2" style="text-align: right">ชื่อเอกสารแนบ</div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="txt_upload_name" runat="server" Width="100%"></asp:TextBox>
                                            <p style="color: red">*กรุณากรอกชื่อเอกสารแนบ</p>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2" style="text-align: right"></div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="BTN_SAVE_FILE_NAME" runat="server" Text="บันทึก" Height="35px" />&ensp;
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-5">
                                            <h3>เอกสารแนบ</h3>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <telerik:RadGrid ID="RG_OTHER" runat="server">
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </RowIndicatorColumn>

                                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                                                            SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false" AllowFiltering="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                                                            HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NAME_REAL" FilterControlAltText="Filter NAME_REAL column"
                                                            HeaderText="ชื่อเอกสารที่อัพโหลด" SortExpression="NAME_REAL" UniqueName="NAME_REAL">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                    </EditFormSettings>

                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                </MasterTableView>

                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            </telerik:RadGrid>
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-1"></div>
                                        <div class="col-lg-10">
                                            <asp:Table ID="tb_type_menu_other" runat="server" CssClass="table" Width="100%"></asp:Table>
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="text-align: center">
                                        <asp:Button ID="BTN_SAVE_FILE_UP" runat="server" Text="อัพโหลดเอกสารแนบใหม่" Height="35px" />&ensp;
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- </asp:Panel>--%>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" id="E1" runat="server">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" />
            &ensp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" Height="40px" Width="135px" OnClientClick="กรุนาตรวจความถูกต้องของข้อมูลก่อนบันทึก" />
        </div>
    </div>
    <%--</div>
    </div>--%>
</asp:Content>

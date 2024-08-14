<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm40.aspx.vb" Inherits="FDA_DRUG_HERB.WebForm40" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>แก้ไข ADMIN</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0,initial-scale=1.0, maximum-scale=1, minimum-scale=1" />

    <link href="../Design/css/font.css" rel="stylesheet" type="text/css" />
    <link href="../Design/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Design/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap-reboot.css" rel="stylesheet" />
    <link href="../Content/bootstrap-grid.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.js"></script>
    <script src="../Scripts/popper.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div class="wrapper two">
                <header class="header" style="background: #63320e">
                    <div class="inner">
                        <a class="logo">
                            <img src="../imgs/logo@2x.png" alt="Logo" />
                        </a>
                        <div class="title-header">
                            <!-- For Mobile -->
                            <a class="logo">
                                <img src="../imgs/logo@2x.png" alt="Logo" />
                            </a>
                            <!-- For Mobile -->
                            <span class="circle" style="background: #63320e"></span>
                            <div class="media-body">
                                <h1>ตรวจสอบและแก้ไขผลิตภัณฑ์สมุนไพร</h1>
                                <span style="font-size: 12pt;">สำนักงานคณะกรรมการอาหารและยา กระทรวงสาธารณสุข</span>
                            </div>
                        </div>
                    </div>
                </header>
                <nav class="nav-top">
                    <div class="inner">
                        <div class="collapse navbar-collapse">
                            <!-- For Mobile -->
                            <a href="#" class="nav-toggle">
                                <i class="fa fa-bars"></i>เมนู
                            </a>
                            <!-- For Mobile -->
                            <ul class="nav-menu">
                                <li>
                                    <a href="https://meshlog.fda.moph.go.th/FDA_DRUG_HERB/MAIN_STAFF/FRM_PROCESS.aspx"><i class="fa fa-search"></i>หน้าแรก<span></span></a>
                                </li>
                                <li>
                                    <a href="http://privus.fda.moph.go.th/"><i class="fa fa-power-off"></i>ออกจากระบบ<span></span></a>
                                </li>
                                <li class="navbar-nav navbar-right" style="margin: 10px;">
                                    <asp:Label ID="lb_login" runat="server"></asp:Label>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>
                <div class="nav-catagory" style="background: #63320e">
                </div>
                <div style="width: 100%; margin-left: 0px; top: 0px; left: 0px;">
                    &nbsp;<div class="content" style="width: 100%; vertical-align: top; margin-left: 0px; margin-right: 0px">
                        <div class="row" style="width: 100%">
                            <div style="width: 5%;" class="col-lg-2">
                            </div>
                            <div style="width: 100%;">
                                <div class="col-lg-8 col-md-8" style="text-align: left;">
                                    <table class="table" style="width: 100%;">
                                        <tr>
                                            <td rowspan="3"></td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label1" runat="server" Text="สืบค้นข้อมูลผลิตภัณฑ์" Font-Size="Large"></asp:Label>
                                                <hr />
                                                <asp:TextBox ID="txt_search" runat="server" Width="100%" CssClass="input-lg"></asp:TextBox>
                                            </td>
                                            <td style="padding-left: 2em">
                                                <div style="padding-top: 4em">
                                                    <asp:Button ID="btn_search" runat="server" Height="80%" Text="ค้นหา" CssClass="btn-lg btn-info" />
                                                </div>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div>
                                    <asp:Panel ID="Panel1" runat="server" Width="100%" Style="padding-left: 10%; display: none;">
                                        <div class="col-lg-12 col-md-12">
                                            <h3>รายการทะเบียน</h3>
                                            <center>
                                                <hr />
                                                <telerik:RadGrid ID="RadGrid1" runat="server" Style="margin-bottom: 0px" AllowPaging="True" Width="100%"
                                                    CellSpacing="0" GridLines="None" Skin="Windows7">
                                                    <ClientSettings>
                                                        <%--     <ClientEvents OnRowClick="RadGrid1_OnRowClick" />--%>
                                                    </ClientSettings>
                                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA,typepro,lcnno" ClientDataKeyNames="IDA,typepro,lcnno">
                                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                                            <HeaderStyle Width="20px" />
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                                            <HeaderStyle Width="20px" />
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" Display="false" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid" SortExpression="lcnsid" UniqueName="lcnsid">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Newcode" DataType="System.Int32" Display="false" FilterControlAltText="Filter Newcode column" HeaderText="Newcode" SortExpression="Newcode" UniqueName="Newcode">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="typepro" FilterControlAltText="Filter typepro column" HeaderText="ประเภทผลิตภัณฑ์" SortExpression="typepro" UniqueName="typepro">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="CAT_NO" Display="false" FilterControlAltText="Filter CAT_NO column" HeaderText="CAT_NO" SortExpression="CAT_NO" UniqueName="CAT_NO">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridBoundColumn DataField="typeallow" Display="false" FilterControlAltText="Filter typeallow column" HeaderText="ประเภทใบอนุญาต" SortExpression="typeallow" UniqueName="typeallow">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="lcnno" FilterControlAltText="Filter lcnno column" HeaderText="ใบสำคัญ/ใบอนุญาต" SortExpression="lcnno" UniqueName="lcnno">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="productha" FilterControlAltText="Filter productha column" HeaderText="ชื่อผลิตภัณฑ์ไทย - อังกฤษ" SortExpression="productha" UniqueName="productha">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridBoundColumn DataField="productnm" FilterControlAltText="Filter productnm column" HeaderText="ชื่อทางการค้า"
                                                                SortExpression="productnm" UniqueName="productnm" Display="false">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>


                                                            <telerik:GridBoundColumn DataField="produceng" Display="false" FilterControlAltText="Filter produceng column" HeaderText="ชื่อผลิตภัณฑ์อังกฤษ" SortExpression="produceng" UniqueName="produceng">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="licen" FilterControlAltText="Filter licen column" HeaderText="ชื่อผู้รับอนุญาต" SortExpression="licen" UniqueName="licen">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="des" Display="false" FilterControlAltText="Filter des column" HeaderText="รายละเอียดสินค้า" SortExpression="des" UniqueName="des">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>


                                                            <telerik:GridBoundColumn DataField="Newcode" FilterControlAltText="Filter Newcode column" HeaderText="Newcode" SortExpression="Newcode" UniqueName="Newcode">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" Display="false" FilterControlAltText="Filter IDA column" HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="CITIZEN_ID" Display="false" FilterControlAltText="Filter CITIZEN_ID column" HeaderText="CITIZEN_ID" SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="STATUS" Display="false" FilterControlAltText="Filter STATUS column" HeaderText="STATUS" SortExpression="STATUS" UniqueName="STATUS">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="cncnm" FilterControlAltText="Filter cncnm column" HeaderText="สถานะ" SortExpression="cncnm" UniqueName="cncnm">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" Display="false" FilterControlAltText="Filter lctcd column" HeaderText="lctcd" SortExpression="lctcd" UniqueName="lctcd">
                                                                <ColumnValidationSettings>
                                                                </ColumnValidationSettings>
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                                                                CommandName="sel" Text="เลือก">
                                                                <HeaderStyle Width="70px" />
                                                            </telerik:GridButtonColumn>
                                                        </Columns>
                                                        <EditFormSettings>
                                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                            </EditColumn>
                                                        </EditFormSettings>
                                                        <PagerStyle PageSizeControlType="RadComboBox" />
                                                    </MasterTableView>
                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                                </telerik:RadGrid>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server" Width="100%" Style="padding-left: 10%; display: none;">
                                        <div style="padding-top: 15px"></div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <h3>ข้อมูลทะเบียน</h3>
                                                <hr />
                                                <%--   <span style="color: red; padding-left: 2em">*เฉพาะกรณีที่ต้องปรับชนิดผลิตภัณฑ์และช่องทางการจำหน่าย</span>--%>
                                                <br />
                                                <div class="row" runat="server">
                                                    <div class="col-md-4">เลขที่ใบสำคัญการขึ้นทะเบียน</div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lbl_register" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row" runat="server">
                                                    <div class="col-md-4">สถานะทะเบียน</div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lbl_cncnm" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row" runat="server">
                                                    <div class="col-md-4">ชื่อทางการค้า</div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lbl_drthanm" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                </div>
                                                <%--          <h4 style="color: red">*รายการที่แก้ไขได้</h4>--%>
                                                <div class="row" runat="server">
                                                    <div class="col-md-4"><strong>ชนิดยา (Category by legislation class)</strong></div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lbl_KindnmOld" runat="server" Text="Label" ForeColor="OrangeRed"></asp:Label>
                                                        <br />
                                                        <telerik:RadComboBox ID="DDL_Kindnm" runat="server" Filter="Contains" Width="100%"></telerik:RadComboBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4"><strong>ช่องทางการจำหน่าย</strong></div>
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lbl_SaleChanel" runat="server" Text="Label" ForeColor="OrangeRed"></asp:Label>
                                                        <br />
                                                        <telerik:RadComboBox ID="DDL_SLCHN" runat="server" Filter="Contains" Width="100%"></telerik:RadComboBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-4"><strong>เลขบัตรผู้แก้ไข</strong></div>
                                                    <div class="col-md-6">
                                                        <asp:TextBox ID="txt_identify" runat="server" Width="50%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-4"><strong>รายละเอียดการแก้ไข</strong></div>
                                                    <div class="col-md-6">
                                                        <asp:TextBox ID="txt_remark" TextMode="MultiLine" runat="server" style="width: 840px; height: 90px;"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12" style="text-align:center">
                                                        <br />
                                                        <asp:Button ID="BTN_Submit" runat="server" CssClass="btn-lg btn-success" Text="อัพเดทข้อมูลทะเบียน" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องก่อนทำการอัพเดทข้อมูล');"/>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <footer class="footer">
                <div class="inner">
                    <strong>สำนักงานคณะกรรมการอาหารและยา :</strong> 88/24 ถนนติวานนท์ อำเภอเมือง จังหวัดนนทบุรี 11000 โทรศัพท์ 0-2590-7000
                </div>
            </footer>

            <script type="/text/javascript" src="/js/jquery.js"></script>
            <script type="/text/javascript" src="/js/bootstrap.min.js"></script>
            <script type="/text/javascript" src="/js/custom.js"></script>

        </div>

    </form>
</body>
</html>

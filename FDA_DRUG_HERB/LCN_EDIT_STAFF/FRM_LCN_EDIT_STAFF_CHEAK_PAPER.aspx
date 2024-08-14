<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_LCN_EDIT_STAFF_CHEAK_PAPER.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_EDIT_STAFF_CHEAK_PAPER" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_rg_herb.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_TXT_CHECK_DATE"));
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-8" style="width: 70%">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
        </div>
        <div class="col-lg-4" style="width: 30%">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    เลือกสถานะ:
                </div>
                <div class="col-lg-7">
                    <asp:DropDownList ID="DD_STATUS" runat="server" DataValueField="STATUS_ID" DataTextField="STATUS_NAME_STAFF" Width="200px" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div id="txt1" visible="false" runat="server">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">
                        เลขรับ:
                    </div>
                    <div class="col-lg-6" runat="server">
                        <asp:TextBox ID="TXT_RQ_NUM" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">
                        วันที่ตรวจเอกสาร:
                    </div>
                    <div class="col-lg-6" runat="server">
                        <asp:TextBox ID="TXT_CHECK_DATE" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">
                        เจ้าหน้าที่ตรวจเอกสาร:
                    </div>
                    <div class="col-lg-4">
                        <asp:DropDownList ID="DDL_CHECK_STAFF" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME" Width="200px" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>




            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="width: 100%">
                    <telerik:RadGrid ID="RadGrid1" runat="server">
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
                                <telerik:GridBoundColumn DataField="FILE_NUMBER_NAME" FilterControlAltText="Filter FILE_NUMBER_NAME column"
                                    HeaderText="file_id" SortExpression="FILE_NUMBER_NAME" UniqueName="FILE_NUMBER_NAME" Display="false">
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
            <div class="row" style="text-align: left">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="80%" />
                    <div style="padding-top: 10px"></div>
                    <asp:Button ID="btn_dbd" runat="server" Text="ข้อมูล DBD" CssClass="btn-lg bg-primary" Width="80%" />
                    <div style="padding-top: 10px"></div>
                    <asp:Button ID="btn_Closed" runat="server" Text="ปิด" CssClass="btn-lg bg-danger" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
    </div>



</asp:Content>

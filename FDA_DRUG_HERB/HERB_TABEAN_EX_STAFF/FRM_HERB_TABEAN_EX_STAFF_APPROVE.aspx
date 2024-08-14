<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_EX_STAFF_APPROVE.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_EX_STAFF_APPROVE" %>


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
<%--    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_APP"));
            $("#ContentPlaceHolder1_DD_OFF_APP").searchable();
        });

    </script>--%>

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
                <div class="col-lg-4">เลือกรูปแบบ PDF</div>
                <div class="col-lg-6">
                      <asp:DropDownList ID="DD_PDF_ID" runat="server" BackColor="White" Height="25px" Width="100%" SkinID="bootstrap" AutoPostBack="True">
                <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                <%--<asp:ListItem Value="1">ตย1</asp:ListItem>--%>
                <asp:ListItem Value="2">ยบ8</asp:ListItem>
            </asp:DropDownList>
                </div>
                <div class="col-lg-1"></div>
            </div>
                <%-- <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เลขรับ</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="RCVNO_FULL" runat="server" Style="width: 100%" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>--%>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">วันที่อนุมัติ</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="DATE_APP"  runat="server" ReadOnly="true" Style="width: 90%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">หมายเหตุ</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="NOTE_APP" TextMode="MultiLine" ReadOnly="true" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">ผู้อนุมัติ</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="OFF_APP" ReadOnly="true" runat="server" Style="width: 100%"></asp:TextBox>
                        <%--<asp:DropDownList ID="DD_OFF_APP" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME"></asp:DropDownList>--%>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

            <div class="row" style="text-align: center">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <br />
                    <%--<asp:Button ID="btn_download_jj2" runat="server" Text="Preview จจ.2" CssClass="btn-lg" Width="80%" />--%>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบยาตัวอย่าง</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="width: 100%">
                    <telerik:radgrid id="RadGrid1" runat="server">
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
                    </telerik:radgrid>
                </div>
                <div class="col-lg-1"></div>
            </div>

        </div>
    </div>

</asp:Content>

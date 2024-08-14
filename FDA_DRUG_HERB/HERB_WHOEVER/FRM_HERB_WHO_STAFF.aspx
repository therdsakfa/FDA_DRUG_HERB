<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_HERB_WHO_STAFF.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_WHO_STAFF" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="text-align: left; width: 100%">
        <div class="panel-heading panel-title" style="height: 70px">
            <div class="col-lg-4 col-md-4">
                <h4>มอบสิทธิ์ผู้ใดแทนผู้ประกอบการ</h4>
            </div>
            <div class="col-lg-8 col-md-8">
                <p style="text-align: right; padding-right: 5%;"></p>
            </div>
        </div>
    </div>


    <div class="panel panel-body" style="width: 95%; padding-left: 1%;">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4">ชื่อผู้ประกอบการ</div>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_SEARCH" runat="server" CssClass="input-lg"></asp:TextBox></div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" style="height: 15px"></div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4">เลขนิติบุคคล/เลขบัตรประชาชน</div>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_NUM" runat="server" CssClass="input-lg"></asp:TextBox></div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" style="height: 15px"></div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-10" style="text-align: center">
                <asp:Button ID="btn_SEARCH" runat="server" Text="ค้นหา" CssClass="input-lg" />
            </div>
        </div>
        <div class="row" style="height: 15px"></div>
        <div class="row">
            <div class="col-12" style="text-align: center">
                <p class="h3">ชื่อผู้ประกอบการ</p>
            </div>
        </div>
        <div class="row" style="height: 15px"></div>
        <div class="row">
           <%-- <div class="col-lg-1"></div>--%>
            <div class="col-lg-12">
                <telerik:RadGrid ID="rg_name" runat="server" AllowPaging="true" PageSize="15">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>

                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>

                        <Columns>
                            <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid"
                                SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
                                <ColumnValidationSettings>
                                    <%--<ModelErrorMessage Text="" />--%>
                                </ColumnValidationSettings>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="fullname" FilterControlAltText="Filter fullname column" HeaderText="ชื่อผู้ประกอบการ" ReadOnly="True" SortExpression="fullname" UniqueName="fullname">
                                <ColumnValidationSettings>
                                    <%--<ModelErrorMessage Text="" />--%>
                                </ColumnValidationSettings>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column"
                                HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID" Display="false">
                                <ColumnValidationSettings>
                                    <%--<ModelErrorMessage Text="" />--%>
                                </ColumnValidationSettings>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="IDENTIFY" FilterControlAltText="Filter IDENTIFY column"
                                HeaderText="IDENTIFY" SortExpression="IDENTIFY" UniqueName="IDENTIFY" Display="true">
                                <ColumnValidationSettings>
                                    <%--<ModelErrorMessage Text="" />--%>
                                </ColumnValidationSettings>
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:Button ID="HL_SELECT" runat="server" Text="เลือกข้อมูล" CommandName="sel" />
                                    <%--<asp:HyperLink ID="HL_SELECT"  runat="server">เลือกข้อมูล</asp:HyperLink>--%>
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
           <%-- <div class="col-1"></div>--%>
        </div>
        <div class="row" style="height: 15px"></div>
        <div class="row">
            <div class="col-12" style="text-align: center">
                <p class="h3">ใบอนุญาต</p>
            </div>
        </div>
        <div class="row" style="height: 15px"></div>
        <div class="row">
            <%--<div class="col-1"></div>--%>
            <div class="col-lg-12">
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
                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                                HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                                HeaderText="TR_ID" ReadOnly="True" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                                HeaderText="FK_IDA" ReadOnly="True" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="LCNNO_DISPLAY" FilterControlAltText="Filter LCNNO_DISPLAY column"
                                HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_DISPLAY" UniqueName="LCNNO_DISPLAY">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                                HeaderText="ชื่อสถานที่" ReadOnly="True" SortExpression="thanameplace" UniqueName="thanameplace">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column"
                                HeaderText="ที่อยู่" SortExpression="fulladdr" UniqueName="fulladdr">
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HL_SELECT" runat="server">เลือกข้อมูล</asp:HyperLink>
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
            <%--<div class="col-1"></div>--%>
        </div>
        <div class="row" style="height: 15px"></div>
    </div>

</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_STAFF_JJ_DETAIL.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_STAFF_JJ_DETAIL" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-8" style="width: 70%">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-6">
                    <asp:Label ID="Label3" runat="server" Text="สร้างคำขอโดย:" Font-Size="Large"></asp:Label>
                    <asp:Label ID="lbl_create_by" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label2" runat="server" Text="สร้างคำขอเมื่อ:" Font-Size="Large"></asp:Label>
                    <asp:Label ID="lbl_create_date" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
        <div class="col-lg-4" style="width: 30%">


            <div class="row" runat="server" id="p2" visible="false">
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เนื่องจาก</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txt_CANCLE_REMARK" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%" ReadOnly="true"></asp:TextBox>
                        <%-- <asp:DropDownList ID="DDL_CANCLE_REMARK" runat="server" DataValueField="DDL_ID" DataTextField="DDL_NAME" SkinID="bootstrap" Enabled="false"></asp:DropDownList>--%>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">รายละเอียดการยกเลิก</div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="NOTE_CANCLE" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">
                        <asp:Label ID="Label1" runat="server" Text="เจ้าหน้าที่" Font-Size="small"></asp:Label><asp:Label ID="NAME_ST" runat="server" Text="" Font-Size="small"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="STAFF_NAME" TextMode="SingleLine" runat="server" Style="height: 20%; width: 100%" ReadOnly="true" ></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <%--  <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
                    </div>
                </div>--%>
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบประกอบการยกเลิก</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10" style="width: 100%">
                        <telerik:RadGrid ID="RadGrid5" runat="server">
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
            </div>
            <div class="row" runat="server" id="uc_upload1_radgrid" visible="false">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="width: 100%">
                    <telerik:RadGrid ID="RadGrid4" runat="server">
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
            <hr />
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบคำขอจดแจ้ง</h3>
                </div>
            </div>
            <hr />
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
            <hr />
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแนบคำขอจดแจ้ง (แก้ไขตามบันทึกข้อบกพร่อง)</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="width: 100%">
                    <telerik:RadGrid ID="RadGrid2" runat="server">
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
            <hr />
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <h3>เอกสารแสดงสูตรและกรรมวิธีการผลิต</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <telerik:RadGrid ID="RadGrid3" runat="server">
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
                                <telerik:GridBoundColumn DataField="DD_HERB_NAME_PRODUCT_ID" DataType="System.Int32" FilterControlAltText="Filter DD_HERB_NAME_PRODUCT_ID column" HeaderText="DD_HERB_NAME_PRODUCT_ID"
                                    SortExpression="DD_HERB_NAME_PRODUCT_ID" UniqueName="DD_HERB_NAME_PRODUCT_ID" Display="false" AllowFiltering="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                                    HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NAME_FAKE" FilterControlAltText="Filter NAME_FAKE column"
                                    HeaderText="ชื่อเอกสาร" SortExpression="NAME_FAKE" UniqueName="NAME_FAKE">
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
        </div>
    </div>

</asp:Content>

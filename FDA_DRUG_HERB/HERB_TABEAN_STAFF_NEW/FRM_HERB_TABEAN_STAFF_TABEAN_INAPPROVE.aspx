<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_STAFF_TABEAN_INAPPROVE.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_STAFF_TABEAN_INAPPROVE" %>

<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_APP"));
            $("#ContentPlaceHolder1_DD_OFF_APP").searchable();
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row" style="background-color: whitesmoke; padding-left: 1em">
        <div class="col-lg-8" style="width: 70%; border-radius: 5px; background-color: white;">
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
            <div runat="server" id="Submit_BG" style="border-radius: 5px; padding: 2em; background-color: white;">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">เลือกสถานะ</div>
                    <div class="col-lg-6">
                        <asp:DropDownList ID="DD_STATUS" runat="server" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" Style="width: 100%" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row" runat="server" id="P12" visible="false">
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เลขรับ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="RCVNO_FULL" runat="server" Style="width: 100%" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เลขทะเบียน</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="RGTNO_FULL" runat="server" Style="width: 100%" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">วันที่อนุมัติ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="DATE_APP" runat="server" Style="width: 90%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">หมายเหตุ</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="NOTE_APP" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">ผู้อนุมัติ</div>
                        <div class="col-lg-6">
                            <%--<asp:TextBox ID="OFF_APP" runat="server" Style="width: 100%"></asp:TextBox>--%>
                            <asp:DropDownList ID="DD_OFF_APP" runat="server" DataValueField="IDA" DataTextField="STAFF_NAME"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>

                </div>
                <div class="row" runat="server" id="p2" visible="false">
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">เนื่องจาก</div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="DDL_CANCLE_REMARK" runat="server" AutoPostBack="true" DataTextField="STATUS_CAUSE" DataValueField="ID"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row" runat="server">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">รายละเอียดการยกเลิก</div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="NOTE_CANCLE" TextMode="MultiLine" runat="server" Style="height: 20%; width: 100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: center">
                            <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row" style="text-align: center">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg bg-success" Width="100%" />
                        <br />
                        <div class="row">
                            <div class="col-lg-5">
                                <label>รูปแบบเอกสาร ทบ2.:</label>
                            </div>
                            <div class="col-lg-2">
                                <asp:DropDownList ID="DDL_TB2_SELECT" runat="server" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap">
                                    <asp:ListItem Value="0">-- กรุณาเลือก --</asp:ListItem>
                                    <asp:ListItem Value="1">แบบสั้น</asp:ListItem>
                                    <asp:ListItem Value="2">แบบยาว</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="height: 10px"></div>
                        <asp:Button ID="btn_preview_tb2" runat="server" Text="Preview ทบ.2" CssClass="btn-lg bg-info" Width="100%" />
                        <div style="height: 10px"></div>
                        <asp:Button ID="BTN_Add_Contains" runat="server" Text="เพิ่มสูตรสาร" CssClass="btn-lg bg-warning" Width="100%" />
                        <div style="padding-top: 10px"></div>
                        <asp:Button ID="btn_dbd" runat="server" Text="ข้อมูล DBD" CssClass="btn-lg bg-primary" Width="100%" />
                        <div style="padding-top: 10px"></div>
                        <asp:Button ID="btn_Closed" runat="server" Text="ปิด" CssClass="btn-lg bg-danger" Width="100%" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
            <hr />
            <div style="border-radius: 5px; padding: 2em; background-color: white;">
                <div class="row">
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารแนบคำขอทะเบียน</h3>
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
                        <h3>เอกสารแนบคำขอทะเบียน(แก้ไขตามบันทึกข้อบกพร่อง)ครั้งที่2</h3>
                    </div>
                </div>
                <div class="row">
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
                        <h3>เอกสารแนบคำขอทะเบียน(แก้ไขตามบันทึกข้อบกพร่อง)</h3>
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
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <label>เอกสารแนบ ชื่อสมุนไพร (พืช/สัตว์/จุลชีพ/แร่)  /  กรณีเป็นสารสกัด  /  ชื่อสารช่วย:</label>
                    </div>
                    <div class="col-lg-1"></div>
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
                    <div class="col-lg-12" style="text-align: center">
                        <h3>เอกสารสูตรตำรับและกรรมวิธีการผลิต</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
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
        </div>
    </div>
</asp:Content>

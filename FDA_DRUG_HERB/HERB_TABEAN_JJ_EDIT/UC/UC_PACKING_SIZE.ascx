<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_PACKING_SIZE.ascx.vb" Inherits="FDA_DRUG_HERB.UC_PACKING_SIZE1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div class="row" style="height: 1px"></div>
<div visible="false" id="ID3" runat="server">
    <div class="row">
        <div class="col-lg-3" style="text-align: center">
            <h4>ขนาดบรรจุ</h4>
            <hr />
        </div>
    </div>
    <div class="row" style="height: 5px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-9">
            <asp:CheckBox ID="CB_Size_Packet" Text=" &nbsp; 1. แก้ไขขนาดบรรจุ" runat="server" AutoPostBack="True" />
            <br />
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div visible="false" id="CB1" runat="server">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <h4>ข้อมูลเดิม</h4>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <label>รายละเอียดขนาด:</label>
            </div>
            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="SIZE_PACK_OLD" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <%--        <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="SIZE_PACK" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
              </div>--%>
            <div class="col-lg-10">
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

        <div class="row" style="height: 5px"></div>
        <hr />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4">
                <h4>ข้อมูลที่ต้องการแก้ไข</h4>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-2">
                <label>รายละเอียดขนาด:</label>
            </div>
            <div class="col-lg-8" style="border-bottom: #999999 1px dotted">
                <asp:TextBox ID="SIZE_PACK_NEW" runat="server" BorderStyle="None" TextMode="MultiLine" Height="60px" Width="100%"></asp:TextBox>
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
                        <asp:TextBox ID="NO_1" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
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
                        <asp:TextBox ID="NO_2" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-2" style="text-align: right">หน่วย:</div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="DD_UNIT_2" runat="server" DataValueField="UNIT_SECONDARY_ID" DataTextField="UNIT_SECONDARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2">Tertiary Packaging:</div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="DD_PCAK_3" runat="server" DataValueField="PACK_TER_ID" DataTextField="PACK_TER_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
                    </div>
                    <div class="col-lg-2" style="text-align: right">จำนวน:</div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="NO_3" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
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
            </div>
        </div>
        <div class="col-lg-1"></div>

    </div>

    <hr />

</div>


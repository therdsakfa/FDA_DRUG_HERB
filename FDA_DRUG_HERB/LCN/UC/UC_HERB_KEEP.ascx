<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB_KEEP.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB_KEEP" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div>
    <%--  <div class="row">
        <div class="col-lg-12" style="padding-left: 8em">
            <span>
                <strong>สถานที่เก็บรักษาผลิตภัณฆ์สมุนไพร (ถ้ามี) ชื่อ &ensp;</strong>
            </span>
            <asp:DropDownList ID="ddl_placename" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList>
            <div>
                <span>
                    <asp:CheckBox ID="cb_location" runat="server" AutoPostBack="True" />
                    <strong>ใช้ที่สถานที่เก็บเดียวกันกับสถานที่ตั้ง</strong>
                </span>

                <br />
                <span><strong>ที่อยู่ :</strong></span>&ensp;
                <span>
                    <asp:Label ID="lbl_location_new" runat="server" Text="-"></asp:Label></span>
            </div>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3>โปรดเลือกสถานที่สถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">- ใช้ที่สถานที่เก็บเดียวกันกับสถานที่ตั้ง &ensp;<asp:CheckBox ID="cb_location" runat="server" AutoPostBack="True" />&ensp;<label style="color: red">(กรุณาคลิก)</label></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">- กรณีมีสถานที่เก็บฯอื่นนอกเหนือจากสถานที่ผลิต/นำเข้า/ขายโปรดเลือก</div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1" style="padding-left: 1em">สถานที่เก็บอื่นๆ :</div>
        <div class="col-lg-6">
            <asp:DropDownList ID="ddl_placename" runat="server" Width="100%" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            ที่อยู่ :
        </div>
        <div class="col-lg-8">
            <asp:Label ID="lbl_location_new" runat="server" Text="-"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-10">
            <asp:Label ID="Label1" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณากรอกที่อยู่</p>
            </asp:Label>
        </div>
    </div>
    <asp:HiddenField ID="hf_place" runat="server"/>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <asp:Button ID="btn_save" runat="server" Text="เพิ่มสถานที่เก็บ" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
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
                        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid"
                            SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="rcvno" DataType="System.Int32" FilterControlAltText="Filter rcvno column"
                            HeaderText="เลขรับ" SortExpression="rcvno" UniqueName="rcvno" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="rcvdate" DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" HeaderText="วันที่รับ" SortExpression="rcvdate" UniqueName="rcvdate" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                            HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="TranscestionID" SortExpression="XMLNAME" UniqueName="XMLNAME" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                            HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                            HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                            HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column"
                            HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column" HeaderText="CITIZEN_ID"
                            SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CITIZEN_ID_UPLOAD" FilterControlAltText="Filter CITIZEN_ID_UPLOAD column"
                            HeaderText="CITIZEN_ID_UPLOAD" SortExpression="CITIZEN_ID_UPLOAD" UniqueName="CITIZEN_ID_UPLOAD" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" FilterControlAltText="Filter lctcd column" HeaderText="lctcd"
                            SortExpression="lctcd" UniqueName="lctcd" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_del"
                            CommandName="_del" Text="ลบ" ConfirmText="ยืนยันการลบข้อมูล">
                            <HeaderStyle Width="70px" />
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

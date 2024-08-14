<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_TABEAN_STAFF_TABEAN_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_STAFF_TABEAN_EDIT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแนบแก้ไขคำขอทะเบียน</h3>
        </div>
    </div>
    <div class="row">
        <div style="overflow-x: scroll; height: 200px; text-align: center">
            <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>
            <asp:Button ID="btn_add_upload" runat="server" Text="อัพโหลดเอกสาร" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>กรุณาเลือกรายละเอียดแก้ไข</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5"></div>
        <div class="col-lg-5" style="padding-left: 4em">
            <asp:CheckBox ID="CHK_TB1_EDIT" runat="server" AutoPostBack="True" />
            <asp:Label ID="lbl_tb1_edit" runat="server" Text="แก้ไข ทบ.1"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5"></div>
        <div class="col-lg-5" style="padding-left: 4em">
            <asp:CheckBox ID="CHK_UPLOAD_EDIT" runat="server" AutoPostBack="True" />
            <asp:Label ID="lbl_upload_edit" runat="server" Text="แก้ไข อัพโหลดเอกสาร"></asp:Label>
        </div>
    </div>
    <div class="row" runat="server" id="DIV_SHOW_TXT_EDIT_TB1" visible="false">
        <%--<div class="row">
            <div class="col-lg-12" style="text-align: center">
                <h3>หมายเหตุการแก้ไข ทบ.1</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12" style="text-align:center">
                <asp:TextBox ID="TXT_EDIT_NOTE_TB1" TextMode="MultiLine" runat="server" Style="height: 50%; width: 50%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>--%>
        <div class="col-lg-1"></div>
        <div class="col-lg-3" style="text-align: center">หมายเหตุการแก้ไข ทบ.1</div>
        <div class="col-lg-6" style="text-align: left">
            <asp:TextBox ID="TXT_EDIT_NOTE_TB1" TextMode="MultiLine" runat="server" Style="height: 50%; width: 100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" runat="server" id="DIV_EDIT_UPLOAD1" visible="false">
        <div class="row" runat="server">
            <div class="col-lg-1"></div>
            <div class="col-lg-3" style="text-align: center">หมายเหตุการแก้ไขเอกสาร</div>
            <div class="col-lg-6" style="text-align: left">
                <asp:TextBox ID="NOTE_EDIT" TextMode="MultiLine" runat="server" Style="height: 50%; width: 100%"></asp:TextBox>
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
    </div>
    <div class="row" runat="server" id="DIV_EDIT_UPLOAD2" visible="false">
        <div class="row" style="text-align: center">
            <h3>รายการเอกสารที่แก้ไข</h3>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6" style="width: 60%">
                <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="40"
                    PagerStyle-Mode="NextPrevNumericAndAdvanced" AllowMultiRowSelection="true">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="SelectColumn" />
                            <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID"
                                SortExpression="ID" UniqueName="ID" Display="false" AllowFiltering="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DUCUMENT_NAME" FilterControlAltText="Filter DUCUMENT_NAME column"
                                HeaderText="รายการเอกสาร" SortExpression="DUCUMENT_NAME" UniqueName="DUCUMENT_NAME">
                            </telerik:GridBoundColumn>
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
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" style="text-align: center">
            <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="10%" />
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="10%" />
        </div>
        <div class="col-lg-1"></div>
    </div>
</asp:Content>

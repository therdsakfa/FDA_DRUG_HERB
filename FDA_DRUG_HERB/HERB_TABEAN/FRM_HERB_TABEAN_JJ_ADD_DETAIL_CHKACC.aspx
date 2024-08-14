<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_HERB_TABEAN_JJ_ADD_DETAIL_CHKACC.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_TABEAN_JJ_ADD_DETAIL_CHKACC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3>เอกสารแสดงสูตรและกรรมวิธีการผลิต</h3>
        </div>
    </div> 
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <h3 style="color:red">โปรดกดดูเอกสารสูตรตำรับและกรรมวิธีการผลิต ก่อนยอมรับการใช้สูตรตำรับและกรรมวิธีการผลิต</h3>
        </div>
    </div>
    <div class="row">
        <%--<div class="col-lg-12" style="text-align: center">
            <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
        </div>--%>
        <div class="col-lg-1"></div>
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
     <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-4">
            <label>การยอมรับการใช้สูตรตำรับและกรรมวิธีการผลิต:</label>
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:RadioButtonList ID="ACCEPT_FORMULA" runat="server" RepeatDirection="horizontal" Width="200px" AutoPostBack="true">
                <asp:ListItem Value="1">ยอมรับ</asp:ListItem>
                <asp:ListItem Value="2">ไม่ยอมรับ</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10" id="ACCEPT_FORMULA_TEXT" runat="server" visible="false">
            <asp:TextBox ID="ACCEPT_FORMULA_NOTE" runat="server" TextMode="MultiLine" Height="60px" Width="100%" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div style="text-align: center">
            <asp:Button ID="btn_summit2" runat="server" Text="บันทึกส่วนที่2" />
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" MaintainScrollPositionOnPostback="true" CodeBehind="FRM_LCN_EDIT_STAFF_EDIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_EDIT_STAFF_EDIT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_REQ"));
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class ="col-lg-2"></div>
        <div class="col-lg-10">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-12" style="text-align: left">
                    <h4>เอกสารแนบ (แก้ไข):</h4> 
                </div>
            </div>
            <div class="row">
                <div class="col-lg-10">
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
                        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" 
                            HeaderText="เลขรันไฟล์" SortExpression="ID" UniqueName="ID" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HEAD_ID" DataType="System.Int32" FilterControlAltText="Filter HEAD_ID column" 
                            HeaderText="เลขรันรายการ" SortExpression="HEAD_ID" UniqueName="HEAD_ID" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TITLE_ID2" DataType="System.Int32" FilterControlAltText="Filter TITLE_ID2 column" 
                            HeaderText="เลข Reason" SortExpression="TITLE_ID2" UniqueName="TITLE_ID2" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HEAD_ID" DataType="System.Int32" FilterControlAltText="Filter HEAD_ID column" 
                            HeaderText="เลข ReasonSub" SortExpression="HEAD_ID" UniqueName="HEAD_ID" Display="false" AllowFiltering="true">
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
            </div>
            <div class="row">
                <div class="col-lg-10">
                    <h4>หมายเหตุ (การแก้ไข):</h4> 
                    </div>
            </div>
            <div class="row">
                <div class="col-lg-10">
                    <asp:TextBox ID="TXT_EDIT_NOTE" runat="server" TextMode="MultiLine" Width="582px" Height="100px"></asp:TextBox>
                    </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Button ID="btn_add_upload" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-sm" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องของเอกสารก่อนกด ยืนยัน');" />&nbsp;&nbsp;
                    <asp:Button ID="btn_upload_edit" runat="server" Text="อัพโหลดไฟล์" CssClass="btn-sm" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องของเอกสารก่อนกด ยืนยัน');" />&nbsp;&nbsp;
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-12" style="text-align: left">
                    <h4>รายการเอกสารแนบ (แก้ไข):</h4> 
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div>
                    <div style="overflow-x: scroll; height: 200px">
                        
                        <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="800px"></asp:Table>
                        
                    </div>
                </div>

            </div>
            
            <div class="row" style="text-align: left">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <asp:Button ID="btn_sumit" runat="server" Text="บันทึก" CssClass="btn-lg" Width="80%" />
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
    </div>



</asp:Content>

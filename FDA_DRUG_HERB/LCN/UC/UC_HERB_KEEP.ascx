﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB_KEEP.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB_KEEP" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div>
     สถานที่เก็บรักษาผลิตภัณฆ์สมุนไพร (ถ้ามี) ชื่อ 
    <asp:DropDownList ID="ddl_placename" runat="server" Width="300px" AutoPostBack="True">
                </asp:DropDownList>
     <br />&ensp;
    ที่อยู่  <asp:Label ID="lbl_location_new" runat="server" Text="-"></asp:Label>

           <%--เลขรหัสประจำบ้าน<asp:Label ID="Label61" runat="server" Text=".............."></asp:Label>
           อยู่เลขที่<asp:Label ID="Label62" runat="server" Text=".............."></asp:Label>
           หมู่บ้าน/อาคาร<asp:Label ID="Label63" runat="server" Text="............"></asp:Label><br />&ensp;
           หมู่ที่<asp:Label ID="Label64" runat="server" Text="............"></asp:Label>
           ตรอก/ซอย<asp:Label ID="Label65" runat="server" Text="............."></asp:Label>
           ถนน<asp:Label ID="Label66" runat="server" Text="..........."></asp:Label><br />&ensp;
           ตำบล/แขวง<asp:Label ID="Label67" runat="server" Text="..........."></asp:Label>
           อำเภอ/เขต<asp:Label ID="Label68" runat="server" Text="............."></asp:Label><br />&ensp;
           จังหวัด<asp:Label ID="Label69" runat="server" Text="..............."></asp:Label>
           รหัสไปรษณีย์<asp:Label ID="Label70" runat="server" Text="............."></asp:Label>
           โทรสาร<asp:Label ID="Label71" runat="server" Text=".............."></asp:Label><br />&ensp;
           โทรศัพท์<asp:Label ID="Label72" runat="server" Text="............."></asp:Label>
           E-mail<asp:Label ID="Label73" runat="server" Text="..............."></asp:Label>--%>
     <asp:HiddenField ID="hf_place" runat="server" />
     <br />&ensp;
     <br />
     <asp:Button ID="btn_save" runat="server" Text="เพิ่มสถานที่เก็บ" />
     <br />
     <telerik:RadGrid ID="RadGrid2" runat="server">
<MasterTableView autogeneratecolumns="False" datakeynames="IDA">
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
                          HeaderText="เลขรับ" SortExpression="rcvno" UniqueName="rcvno">
   
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="rcvdate"  DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" HeaderText="วันที่รับ" SortExpression="rcvdate" UniqueName="rcvdate">
      
        </telerik:GridBoundColumn>
        
                 <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                      HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
        
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
        
        </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="TranscestionID" SortExpression="XMLNAME" UniqueName="XMLNAME">
          
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
            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME" >
    
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" FilterControlAltText="Filter lctcd column" HeaderText="lctcd" 
            SortExpression="lctcd" UniqueName="lctcd" Display="false">
      
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
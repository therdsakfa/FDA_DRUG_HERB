<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_PHR_ADD.ascx.vb" Inherits="FDA_DRUG_HERB.UC_PHR_ADD" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table class="table">
    <tr>
        <td align="right">เลขที่บัตรประชาชน :</td>
        <td>
            <asp:TextBox ID="txt_PHR_CTZNO" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox> <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
            

        </td>
    </tr>
    <tr>
        <td align="right">ประเภทผู้มีหน้าที่ปฏิบัติการ :</td>
        <td>
            <%--<asp:RadioButtonList ID="rdl_per_type" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">เภสัชกร</asp:ListItem>
                <asp:ListItem Value="2">สัตวแพทย์</asp:ListItem>
                <asp:ListItem Value="3">ผู้ผ่านการอบรม</asp:ListItem>
            </asp:RadioButtonList>--%>

            <asp:DropDownList ID="ddl_worker_type" runat="server" AutoPostBack="True"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เภสัชกรชั้น(ถ้ามี) :</td>
        <td>
            <asp:TextBox ID="txt_PHR_LEVEL" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ :</td>
        <td>
           <asp:DropDownList ID="ddl_prefix" runat="server" AutoPostBack="True" DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้มีหน้าที่ปฏิบัติการ :</td>
        <td>
            <asp:TextBox ID="txt_PHR_NAME" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td align="right">
            เลขที่ใบอนุญาตประกอบวิชาชีพฯ/โรคศิลปะฯ/เลขอ้างอิงการอบรม :
        </td>
        <td>
            <asp:TextBox ID="txt_PHR_TEXT_NUM" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
             กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ
        </td>
        <td>
             <asp:TextBox ID="txt_STUDY_LEVEL" runat="server"></asp:TextBox>
        </td>
    </tr>
    <%--<tr>
        <td align="right">
            <asp:Label ID="lbl_lcn_type" runat="server" Text=""></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>--%>
    <tr>
        <td align="right">
            สาขา : </td>
        <td>
            <asp:TextBox ID="txt_PHR_VETERINARY_FIELD" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            คำอธิบายผู้ประกอบวิชาชีพ :</td>
        <td>
            <asp:TextBox ID="txt_PHR_TEXT_JOB" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <%--<tr>
        <td align="right">
            ช่องติ๊กที่ปรากฎในใบอนุญาต(กรณีขย.2 และ ขย.3)</td>
        <td>
            <asp:DropDownList ID="ddl_PHR_MEDICAL_TYPE" runat="server">
                <asp:ListItem Value="1">เภสัชกร</asp:ListItem>
                <asp:ListItem Value="2">ผู้ประกอบวิชาชีะ</asp:ListItem>
                <asp:ListItem Value="3">ผู้ได้รับมอบหมายการอบรมมาตรา 48</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>--%>
    <tr>
        <td align="right">เวลาปฏิบัติการ :</td>
        <td >
            <asp:TextBox ID="txt_PHR_TEXT_WORK_TIME" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">หน้าที่ (ถ้ามี) :</td>
        <td >
            <asp:DropDownList ID="ddl_job" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">ตามมาตรา (ถ้ามี) :</td>
        <td >
            <asp:DropDownList ID="ddl_law" runat="server">
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem Value="1">มาตรา 31</asp:ListItem>
                <asp:ListItem Value="2">มาตรา 32</asp:ListItem>
                <asp:ListItem Value="3">มาตรา 33</asp:ListItem>
                <asp:ListItem Value="4">มาตรา 68</asp:ListItem>
                <asp:ListItem Value="5">มาตรา 69</asp:ListItem>
                <asp:ListItem Value="6">มาตรา 70</asp:ListItem>
            </asp:DropDownList>
        </td>
        
    </tr>
    <tr>      
        <td align="right">
            ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร
        </td>
        <td>
           <asp:TextBox ID="txt_NAME_SIMINAR" runat="server"></asp:TextBox>
        </td>     
    </tr>
    <tr>
        <td align="right">
                วันที่อบรม
        </td>
         <td>
            <telerik:RadDatePicker ID="rdp_SIMINAR_DATE" Runat="server"> </telerik:RadDatePicker>
              <asp:Button ID="btn_save" runat="server" Text="เพิ่มหลักสูตรอบรม" />
        </td>
        
        </tr>
  
            
<%--    <tr>
         <td align="right">
            เวลาทำการ
         </td>
        <td>
              <asp:TextBox ID="txt_PHR_TEXT_WORK_TIME1" runat="server"></asp:TextBox>
        </td>
    </tr>--%>
    
    
   
</table>
 <telerik:RadGrid ID="rgns" runat="server" Width ="60%" >
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="NAME_SIMINAR" FilterControlAltText="Filter NAME_SIMINAR column"
                                   HeaderText="ชื่อหลักสูตร" SortExpression="NAME_SIMINAR" UniqueName="NAME_SIMINAR" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="SIMINAR_DATE" FilterControlAltText="Filter SIMINAR_DATE column"
                                   HeaderText="วันที่อบรม" SortExpression="SIMINAR_DATE" UniqueName="SIMINAR_DATE" >
                               </telerik:GridBoundColumn>
                               <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                                   CommandName="edt" Text="แก้ไข">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                   CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบหลักสูตรการอบรมหรือไม่">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                           </Columns>
                       </MasterTableView>
 </telerik:RadGrid>
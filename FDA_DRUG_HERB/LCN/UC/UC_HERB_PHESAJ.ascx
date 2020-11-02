<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB_PHESAJ.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB_PHESAJ" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div>
            <h4> ๔. &ensp;ข้อมูลผุ้มีหน้าที่ปฎิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h4>
            บัตรประชาชน
            <asp:TextBox ID="txt_PHR_CTZNO" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
            <br />
           &ensp;&ensp;&ensp;๔.๑ กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ<asp:TextBox ID="txt_PHR_NAME" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddl_phr_type"  runat="server">
            </asp:DropDownList><br />&ensp;
            ใบอนุญาตประกออนบการวิชาชีพ/โรคศิลปะเลขที่<asp:TextBox ID="txt_PHR_TEXT_NUM" runat="server"></asp:TextBox>หรือ<br />&ensp;
           กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ<asp:TextBox ID="txt_STUDY_LEVEL" runat="server"></asp:TextBox><br />&ensp;
           สาขา<asp:TextBox ID="txt_PHR_VETERINARY_FIELD" runat="server"></asp:TextBox><br />&ensp;
           &ensp;&ensp;๔.๒  ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร<br />&ensp;
           <asp:TextBox ID="txt_NAME_SIMINAR" runat="server"></asp:TextBox>
           วันที่อบรม<telerik:RadDatePicker ID="rdp_SIMINAR_DATE" Runat="server">
            </telerik:RadDatePicker>
            <br />
            เวลาทำการ
            <asp:TextBox ID="txt_PHR_TEXT_WORK_TIME" runat="server"></asp:TextBox>
            <br />&ensp;
    <table>
        <tr>
            <td>
 เป็นผู้ที่มีหน้าที่ปฎิยบัติการตาม
            </td>
            <td>
<asp:RadioButtonList ID="rdl_mastra" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">มาตรา ๓๑</asp:ListItem>
                <asp:ListItem Value="2">มาตรา ๓๒</asp:ListItem>
                <asp:ListItem Value="3">มาตรา ๓๓</asp:ListItem>
            </asp:RadioButtonList>
            </td>
            <td>
แห่ง พ.ร.บ.ผลิตภัณฆ์สมุนไพร พ.ศ.๒๕๖๒
            </td>
        </tr>
    </table>

             <br />

    <asp:Button ID="btn_save" runat="server" Text="เพิ่มผุ้มีหน้าที่ปฎิบัติการ" />
    <telerik:RadGrid ID="rgphr" runat="server">
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="PHR_IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                           <Columns>
                        
                               <telerik:GridBoundColumn DataField="PHR_IDA" FilterControlAltText="Filter PHR_IDA column"
                                   HeaderText="PHR_IDA" SortExpression="PHR_IDA" UniqueName="PHR_IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PHR_CTZNO" FilterControlAltText="Filter PHR_CTZNO column"
                                   HeaderText="เลขบัตรปชช." SortExpression="PHR_CTZNO" UniqueName="PHR_CTZNO" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PHR_FULLNAME" FilterControlAltText="Filter PHR_FULLNAME column"
                                   HeaderText="ชื่อผู้มีหน้าที่ปฏิบัติการ" SortExpression="PHR_FULLNAME" UniqueName="PHR_FULLNAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PHR_TEXT_WORK_TIME" FilterControlAltText="Filter PHR_TEXT_WORK_TIME column"
                                   HeaderText="เวลาทำการ" SortExpression="PHR_TEXT_WORK_TIME" UniqueName="PHR_TEXT_WORK_TIME" >
                               </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="functnm" FilterControlAltText="Filter functnm column"
                                   HeaderText="หน้าที่" SortExpression="functnm" UniqueName="functnm" >
                               </telerik:GridBoundColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                                   CommandName="edt" Text="แก้ไข">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                   CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ปฏิบัติการหรือไม่">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>
       </div>
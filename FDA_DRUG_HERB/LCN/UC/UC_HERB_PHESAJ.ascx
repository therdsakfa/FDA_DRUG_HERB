<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB_PHESAJ.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB_PHESAJ" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style2 {
        width: 85px;
    }
</style>
<div>
            <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                ๔. &ensp;ข้อมูลผุ้มีหน้าที่ปฎิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร
            </h4>
            
            <table>
                <tr>
                    <td class="auto-style2"></td>
                    <td>
                        บัตรประชาชน
                    </td>
                    <td>
                        <asp:TextBox ID="txt_PHR_CTZNO" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:Button ID="btn_search" runat="server" Text="ค้นหา" /> 
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td>
                        คำนำหน้าชื่อ 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_prefix" runat="server"  DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td>&nbsp;
                        ๔.๑ กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ
                    </td>
                    <td>
                        <asp:TextBox ID="txt_PHR_NAME" runat="server"></asp:TextBox>
                    </td> 
                    <td>
                        <asp:DropDownList ID="ddl_phr_type"  runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                      <td>
                        ใบอนุญาตประกออนบการวิชาชีพ/โรคศิลปะเลขที่
                    </td>
                    <td>
                        <asp:TextBox ID="txt_PHR_TEXT_NUM" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        หรือ
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                      <td>
                        กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ
                    </td>
                    <td>
                         <asp:TextBox ID="txt_STUDY_LEVEL" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                      <td>
                        สาขา
                    </td>
                    <td>
                        <asp:TextBox ID="txt_PHR_VETERINARY_FIELD" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                      <td colspan="3">&nbsp;
                            ๔.๒  ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร
                    </td>                  
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td>
                        <asp:TextBox ID="txt_NAME_SIMINAR" runat="server"></asp:TextBox>
                    </td>
                      <td>
                        วันที่อบรม
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdp_SIMINAR_DATE" Runat="server"> </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                      <td>
                        เวลาทำการ
                    </td>
                    <td>
                        <asp:TextBox ID="txt_PHR_TEXT_WORK_TIME" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
    <table>
        <tr>
            <td class="auto-style2"></td>
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
    <telerik:RadGrid ID="rgphr" runat="server" Width ="90%">
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
                                <telerik:GridBoundColumn DataField="STUDY_LEVEL" FilterControlAltText="Filter STUDY_LEVEL column"
                                   HeaderText="คุณวุฒิ" SortExpression="STUDY_LEVEL" UniqueName="STUDY_LEVEL" >
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
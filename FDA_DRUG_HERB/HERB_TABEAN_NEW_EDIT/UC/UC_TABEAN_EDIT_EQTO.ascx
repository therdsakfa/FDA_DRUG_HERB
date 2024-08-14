<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_TABEAN_EDIT_EQTO.ascx.vb" Inherits="FDA_DRUG_HERB.UC_TABEAN_EDIT_EQTO" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div class="row">
    <div class="col-lg-10" >
        <h3>ข้อมูลเดิม</h3>
         <hr />
    </div>
    <div class="col-lg-1"></div>
</div>
<table width="70%">   
    <tr>
        <td>
            <telerik:RadGrid ID="rg_chem_OLD" runat="server" Width="100%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ROWS" FilterControlAltText="Filter ROWS column" HeaderText="ลำดับ"
                            SortExpression="ROWS" UniqueName="ROWS" Display="false">
                        </telerik:GridBoundColumn>
                      <%--  <telerik:GridTemplateColumn UniqueName="ROWS" HeaderText="ลำดับ">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_rows" runat="server" Width="20px"></asp:TextBox>
                                <asp:Label ID="lbl_rows" runat="server" Text="" Style="display: none;"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column"
                            HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column" HeaderText="ปริมาณ" DataType="System.Decimal" SortExpression="QTY" UniqueName="QTY">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REF" FilterControlAltText="Filter REF column" HeaderText="เอกสารอ้างอิง" SortExpression="REF" UniqueName="REF">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="AORI" FilterControlAltText="Filter AORI column" HeaderText="A/I" SortExpression="AORI" UniqueName="AORI">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column" HeaderText="หมายเหตุ" SortExpression="REMARK" UniqueName="REMARK">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sunitengnm" FilterControlAltText="Filter sunitengnm column" HeaderText="หน่วย" SortExpression="sunitengnm" UniqueName="AORI">
                        </telerik:GridBoundColumn>
      <%--                  <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_del" HeaderText="ลบรายการ" ConfirmText="ต้องการลบหรือไม่?"
                            CommandName="_del" Text="ลบ">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>--%>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
   <div class="row" style="height: 25px"></div>
<div class="row">
    <div class="col-lg-10" style="color:red">
        <h3>รายการที่ต้องแก้ไข</h3>
        <hr />
    </div>
    <div class="col-lg-1"></div>
</div>
<%--    <div class="row" style="height: 5px"></div>--%>
<table width="70%">
    <tr>
        <td>สูตร :
            <asp:Label ID="lbl_cas" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txt_search" runat="server"></asp:TextBox><asp:Button ID="btn_search" runat="server" Text="ค้นหาสาร" />
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="rg_search_iowa" runat="server" AllowPaging="true" PageSize="10">
                <MasterTableView AutoGenerateColumns="False">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="chk" HeaderText="เลือก">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="iowacd" FilterControlAltText="Filter iowacd column" HeaderText="iowacd" SortExpression="iowacd" UniqueName="iowacd">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column" HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                        </telerik:GridBoundColumn>
                        <%--                        <telerik:GridBoundColumn DataField="aori" FilterControlAltText="Filter aori column" HeaderText="aori" SortExpression="aori" UniqueName="aori">
                        </telerik:GridBoundColumn>--%>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
            </telerik:RadGrid>

        </td>
    </tr>

    <tr>
        <td align="center">
            <table width="800px">
                <tr>
                    <td align="left" colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" colspan="4">กรุณาเลือกสารจากตารางด้านบนก่อนคลิกปุ่มเพิ่มสาร</td>
                </tr>
                <tr>
                    <td>ปริมาณยา: </td>
                    <td>
                        <asp:TextBox ID="txt_QTY" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>หน่วย :</td>
                    <td>
                        <asp:DropDownList ID="ddl_unit" runat="server"></asp:DropDownList>
                    </td>


                </tr>
                <tr>
                    <td>ปริมาณสุดท้าย :</td>
                    <td>
                        <asp:TextBox ID="txt_QTY_END" runat="server"></asp:TextBox>
                    </td>
                    <td>หน่วย :</td>
                    <td>
                        <asp:DropDownList ID="ddl_unit_end" runat="server"></asp:DropDownList>
                    </td>


                </tr>
                <tr>
                    <td>ตัวคูณ :
                    </td>
                    <td>
                        <asp:TextBox ID="txt_mulyiply" runat="server"></asp:TextBox>
                    </td>
                    <td>ค่าความแรง :</td>
                    <td>

                        <asp:TextBox ID="txt_str" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>เอกสารอ้างอิง</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txt_ref" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>หมายเหตุ</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txt_remark" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>ประเภทสาร A/I :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_aori" runat="server">
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>I</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btn_select" runat="server" Text="เพิ่มสาร" CssClass="input-lg" />
                    </td>
                </tr>
            </table>



        </td>
    </tr>

    <tr>
        <td>
            <telerik:RadGrid ID="rg_chem" runat="server" Width="100%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ROWS" FilterControlAltText="Filter ROWS column" HeaderText="ลำดับ"
                            SortExpression="ROWS" UniqueName="ROWS" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="ROWS" HeaderText="ลำดับ">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_rows" runat="server" Width="20px"></asp:TextBox>
                                <asp:Label ID="lbl_rows" runat="server" Text="" Style="display: none;"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column"
                            HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column" HeaderText="ปริมาณ" DataType="System.Decimal" SortExpression="QTY" UniqueName="QTY">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REF" FilterControlAltText="Filter REF column" HeaderText="เอกสารอ้างอิง" SortExpression="REF" UniqueName="REF">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="AORI" FilterControlAltText="Filter AORI column" HeaderText="A/I" SortExpression="AORI" UniqueName="AORI">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column" HeaderText="หมายเหตุ" SortExpression="REMARK" UniqueName="REMARK">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sunitengnm" FilterControlAltText="Filter sunitengnm column" HeaderText="หน่วย" SortExpression="sunitengnm" UniqueName="AORI">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_del" HeaderText="ลบรายการ" ConfirmText="ต้องการลบหรือไม่?"
                            CommandName="_del" Text="ลบ">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>
    <tr>
        <td align="center" style="border-top:2em">
            <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" />
            <asp:Button ID="btn_rows_save" runat="server" Text="บันทึกลำดับ" />
        </td>
    </tr>
</table>

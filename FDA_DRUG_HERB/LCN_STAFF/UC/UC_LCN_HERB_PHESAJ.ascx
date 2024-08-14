<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_HERB_PHESAJ.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_HERB_PHESAJ" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style2 {
        width: 85px;
    }
</style>
<br />
<br />
<div>
    <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                 &ensp;เพิ่มข้อมูลผุ้มีหน้าที่ปฏิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร
    </h4>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            บัตรประชาชน
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_PHR_CTZNO" runat="server" Height="20px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align: left;">
            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
        </div>
        <div class="col-lg-7"></div>
    </div>
     <div class="row">
        <div class="col-lg-1"></div>
         <div class="col-lg-1">
            คำนำหน้า
        </div>
         <div class="col-lg-3">
            <asp:DropDownList ID="ddl_prefix" runat="server" AutoPostBack="True" DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList>
        </div>       
        <div class="col-lg-9"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>      
        <div class="col-lg-3">
            กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_PHR_NAME" runat="server" Height="20px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="ddl_phr_type" runat="server" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="col-lg-4"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-3">
            ใบอนุญาตประกออนบการวิชาชีพ/โรคศิลปะเลขที่
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_PHR_TEXT_NUM" runat="server" Height="20px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            หรือ
        </div>
        <div class="col-lg-5"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-3">
            กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ
        </div>
        <div class="col-lg-2" >
            <asp:TextBox ID="txt_STUDY_LEVEL" runat="server" Height="20px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align:center">
            สาขา
        </div>
        <div class="col-lg-3">
            <asp:TextBox ID="txt_PHR_VETERINARY_FIELD" runat="server" Height="20px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-4">
             ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร
        </div>
        <div class="col-lg-3">
            <asp:TextBox ID="txt_NAME_SIMINAR" runat="server" Height="20px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-4"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            วันที่อบรม
        </div>
        <div class="col-lg-2">
            <telerik:RadDatePicker ID="rdp_SIMINAR_DATE" runat="server" Height="20px" Width="100%">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="d/M/yyyy" DateFormat="d/M/yyyy" LabelWidth="40%" Height="20px">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
</DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </div>
        <div class="col-lg-1" style="text-align:center">
            เวลาทำการ
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_PHR_TEXT_WORK_TIME" runat="server" Height="20px" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-5">&nbsp;</div>
    </div>

     <div class="row">
         <div class="col-lg-1"></div>
        <div class="col-lg-2">
            เป็นผู้ที่มีหน้าที่ปฏิบัติการตาม 
          </div>  
         <div class="col-lg-3">
             <asp:RadioButtonList ID="rdl_mastra" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">&nbsp;มาตรา ๓๑ &nbsp;</asp:ListItem>
                    <asp:ListItem Value="2">&nbsp;มาตรา ๓๒ &nbsp;</asp:ListItem>
                    <asp:ListItem Value="3">&nbsp;มาตรา ๓๓ &nbsp;</asp:ListItem>
                </asp:RadioButtonList>
         </div>
         <div class="col-lg-3">แห่ง พ.ร.บ.ผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๒</div>
        <div class="col-lg-3"></div>
    </div>

     <div class="row">
         <div class="col-lg-1"></div>
        <div class="col-lg-3">
            <asp:Button ID="btn_save" runat="server" Text="เพิ่มผุ้มีหน้าที่ปฏิบัติการ" />
            <asp:Button ID="btn_edit" runat="server" Text="ยืนยันการแก้ไข"/>
        </div>       
        <div class="col-lg-8"></div>
    </div>
    
    
    <br />

    <telerik:RadGrid ID="rgphr" runat="server" Width="90%">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="PHR_IDA" NoMasterRecordsText="ไม่พบข้อมูล">
            <Columns>

                <telerik:GridBoundColumn DataField="PHR_IDA" FilterControlAltText="Filter PHR_IDA column"
                    HeaderText="PHR_IDA" SortExpression="PHR_IDA" UniqueName="PHR_IDA" Display="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PHR_CTZNO" FilterControlAltText="Filter PHR_CTZNO column"
                    HeaderText="เลขบัตรปชช." SortExpression="PHR_CTZNO" UniqueName="PHR_CTZNO">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PHR_FULLNAME" FilterControlAltText="Filter PHR_FULLNAME column"
                    HeaderText="ชื่อผู้มีหน้าที่ปฏิบัติการ" SortExpression="PHR_FULLNAME" UniqueName="PHR_FULLNAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PHR_TEXT_WORK_TIME" FilterControlAltText="Filter PHR_TEXT_WORK_TIME column"
                    HeaderText="เวลาทำการ" SortExpression="PHR_TEXT_WORK_TIME" UniqueName="PHR_TEXT_WORK_TIME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="STUDY_LEVEL" FilterControlAltText="Filter STUDY_LEVEL column"
                    HeaderText="คุณวุฒิ" SortExpression="STUDY_LEVEL" UniqueName="STUDY_LEVEL">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                    CommandName="edt" Text="แก้ไข">
                    <HeaderStyle Width="70px" />
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                    CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="ยืนยันการลบ">
                    <HeaderStyle Width="70px" />
                </telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>

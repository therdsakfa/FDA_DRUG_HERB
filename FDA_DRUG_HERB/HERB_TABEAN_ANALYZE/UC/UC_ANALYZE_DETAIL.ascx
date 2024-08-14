<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_ANALYZE_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_ANALYZE_DETAIL" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div>
    <div class="row">
        <div class="col-md-12" style="text-align: center;">
            <h2>แบบแจ้งขออนุญาตผลิตหรือนำเข้าผลิตภัณฑ์สมุนไพรเพื่อการวิเคราะห์</h2>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-9"></div>
        <div class="col-lg-1" style="text-align: right;">
            เขียนที่              
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="Txt_Write_At" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row">
        <div class="col-lg-9"></div>
        <div class="col-lg-1" style="text-align: right;">
            วันที่
        </div>
        <div class="col-lg-1">
            <asp:TextBox ID="txt_Write_Date" runat="server" Width="87%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div style="padding-top: 15px"></div>


    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-1">
            ข้าพเจ้า
        </div>
        <div class="col-lg-3">
            <asp:TextBox ID="txt_NAME" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align:left">(ชื่อผู้นำเข้า)</div>
        <div class="col-lg-1" style="text-align:center">ตำแหน่ง</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_position" runat="server" Width="100%"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-1">
            ในนามของ
        </div>
        <div class="col-lg-9">
            <asp:RadioButtonList ID="rdl_behalf_in" runat="server" >
                <asp:ListItem Value="1">&nbsp;กระทรวง ทบวง กรม หน่วยงานอื่นของรัฐ ที่มีภารกิจด้านการป้องกันหรือบำบัดโรค</asp:ListItem>
                <asp:ListItem Value="2">&nbsp;สถาบันอุดมศึกษาของรัฐเพื่อการศึกษาด้านวิทยาศาสตร์ ด้านวิทยาศาสตร์สุขภาพ ด้านการแพทย์แผนไทยหรือแผนไทยประยุกต์</asp:ListItem>
                <asp:ListItem Value="3">&nbsp;สภากาชาดไทย</asp:ListItem>
                <asp:ListItem Value="4">&nbsp;ผู้รับอนุญาตผลิต</asp:ListItem>
                <asp:ListItem Value="5">&nbsp;ผู้รับอนุญาตนำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-1">
            ณ สถานที่ชื่อ
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_lcn_name" runat="server" Width="100%"  ReadOnly="true" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="padding-left:2em">
            ใบอนุญาตเลขที่
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_lcnno_new" runat="server" BorderStyle="None" ReadOnly="true" Width="100%"></asp:TextBox>
        </div>

    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-1">
            อยู่เลขที่
        </div>
        <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_addr" runat="server" Width="100%"  BorderStyle="None" ReadOnly="true" ></asp:TextBox>
        </div>
        <div class="col-lg-1" style="padding-left:2em">ตรอก/ซอย</div>
        <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_soi" runat="server" Width="100%"  BorderStyle="None" ReadOnly="true" ></asp:TextBox>
        </div>
        <div class="col-lg-1" style="padding-left:2em">ถนน</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_road" runat="server" Width="100%"  BorderStyle="None" ReadOnly="true" ></asp:TextBox>
        </div>
    </div>


    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-1">
            หมู่ที่
        </div>
        <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_mu" runat="server" Width="100%"  BorderStyle="None" ReadOnly="true" ></asp:TextBox>
        </div>
        <div class="col-lg-1" style="padding-left:2em">ตำบล/แขวง</div>
        <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_tambol" runat="server" Width="100%"  BorderStyle="None" ReadOnly="true" ></asp:TextBox>
        </div>
        <div class="col-lg-1"  style="padding-left:2em">อำเภอ/เขต</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_ampher" runat="server" Width="100%"  BorderStyle="None" ReadOnly="true" ></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-1">
            จังหวัด
        </div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_changwhat" runat="server" Width="100%"  BorderStyle="None" ReadOnly="true" ></asp:TextBox>
        </div>
        <div class="col-lg-1" style="padding-left:2em">โทรศัพท์</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_tel" runat="server" Width="100%"  BorderStyle="None" ReadOnly="true" ></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-3">
            มีความประสงค์จะแจ้งการนำเข้าผลิตภัณฑ์สมุนไพรชื่อ
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_drug_name" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align:center">จำนวน</div>
        <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_num" runat="server" Width="100%"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10">
            เพื่อการวิเคราะห์และขอรับรองว่าจะไม่นำผลิตภัณฑ์สมุนไพรทั้งหมดหรือแต่บางส่วนออกขายโดยเด็ดขาด
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10" style="text-align: center">
            <h4>รายละเอียดของผลิตภัณฑ์สมุนไพรที่นำเข้ามาในราชอาณาจักร</h4>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10" style="text-align: center">
            ปริมาณของวัตถุส่วนประกอบของผลิตภัณฑ์สมุนไพรต้องแจ้งเป็นมาตราเมตริกหรือเป็นร้อยละใน ๑ หน่วย
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10" style="text-align: center">
            -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10" style="text-align: center">
            <h4>ขนาดบรรจุ</h4>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10" style="text-align: center">
            (รายละเอียดของการบรรจุ)
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
             <div class="row">
        <div class="col-lg-2">Primary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_1" runat="server" DataValueField="PACK_PRIMARY_ID" DataTextField="PACK_PRIMARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="text-align: right">จำนวน:</div>
        <div class="col-lg-2" style="text-align: right">
            <asp:TextBox ID="NO_1" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2" style="text-align: right">หน่วย:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_UNIT_1" runat="server" DataValueField="UNIT_PRIMARY_ID" DataTextField="UNIT_PRIMARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2">Seceondary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_2" runat="server" DataValueField="PACK_SEC_ID" DataTextField="PACK_SEC_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="text-align: right">จำนวน:</div>
        <div class="col-lg-2">
            <asp:TextBox ID="NO_2" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2" style="text-align: right">หน่วย:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_UNIT_2" runat="server" DataValueField="UNIT_SECONDARY_ID" DataTextField="UNIT_SECONDARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2">Tertiary Packaging:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_PCAK_3" runat="server" DataValueField="PACK_TER_ID" DataTextField="PACK_TER_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
        </div>
        <div class="col-lg-2" style="text-align: right">จำนวน:</div>
        <div class="col-lg-2">
            <asp:TextBox ID="NO_3" runat="server" TextMode="Number" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-2" style="text-align: right">หน่วย:</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DD_UNIT_3" runat="server" DataValueField="UNIT_TERTIARY_ID" DataTextField="UNIT_TERTIARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_size_pack" runat="server" Text="เพิ่ม" Height="33px" Width="134px" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <telerik:RadGrid ID="RadGrid4" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
                PagerStyle-Mode="NextPrevNumericAndAdvanced" Skin="Hay">
                <MasterTableView DataKeyNames="IDA">
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA" HeaderText="IDA" DataType="System.Int32" Display="false"
                            FilterControlAltText="Filter IDA column" ReadOnly="True" SortExpression="IDA">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FK_IDA_DQ" UniqueName="FK_IDA_DQ" HeaderText="FK_IDA_DQ" FilterControlAltText="Filter FK_IDA_DQ column"
                            SortExpression="FK_IDA_DQ" Display="false">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="PACK_F_NAME " UniqueName="PACK_F_NAME" HeaderText="Primary Packaging:" FilterControlAltText="Filter PACK_F_NAME column"
                            SortExpression="PACK_F_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NO_1" UniqueName="NO_1" HeaderText="ขนาด" FilterControlAltText="Filter NO_1 column"
                            SortExpression="NO_1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UNIT_F_NAME " UniqueName="UNIT_F_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_F_NAME column"
                            SortExpression="UNIT_F_NAME">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="PACK_S_NAME " UniqueName="PACK_S_NAME" HeaderText="Seceondary Packaging:" FilterControlAltText="Filter PACK_S_NAME column"
                            SortExpression="PACK_S_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NO_2" UniqueName="NO_2" HeaderText="ขนาด" FilterControlAltText="Filter NO_2 column"
                            SortExpression="NO_2">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UNIT_S_NAME " UniqueName="UNIT_S_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_S_NAME column"
                            SortExpression="UNIT_S_NAME">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="PACK_T_NAME " UniqueName="PACK_T_NAME" HeaderText="Tertiary Packaging:" FilterControlAltText="Filter PACK_T_NAME column"
                            SortExpression="PACK_T_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NO_3" UniqueName="NO_3" HeaderText="ขนาด" FilterControlAltText="Filter NO_3 column"
                            SortExpression="NO_3">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UNIT_T_NAME " UniqueName="UNIT_T_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_T_NAME column"
                            SortExpression="UNIT_T_NAME">
                        </telerik:GridBoundColumn>

                        <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                            CommandName="result_delete" UniqueName="result_delete">
                        </telerik:GridButtonColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10"  style="text-align: center">
            -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        </div>
    </div>

</div>


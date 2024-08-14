<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_EDIT.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_EDIT" %>
<%@ Register Src="~/LCN_EDIT/UC/UC_LCN_EDIT_TOPIC_1.ascx" TagPrefix="uc1" TagName="UC_LCN_EDIT_TOPIC_1" %>
<%@ Register Src="~/LCN_EDIT/UC/UC_LCN_EDIT_TOPIC_2.ascx" TagPrefix="uc2" TagName="UC_LCN_EDIT_TOPIC_2" %>
<%@ Register Src="~/LCN_EDIT/UC/UC_LCN_EDIT_TOPIC_3.ascx" TagPrefix="uc3" TagName="UC_LCN_EDIT_TOPIC_3" %>
<%@ Register Src="~/LCN_EDIT/UC/UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB.ascx" TagPrefix="uc4" TagName="UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div>
    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-3">
            <h2>คำขอแก้ไขรายการในใบอนุญาตฯ</h2>
        </div>
        <div class="col-lg-5"></div>
    </div>

    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-3">
            <asp:RadioButtonList ID="rdl_lcn_type" runat="server" BorderStyle="None" Enabled="False">
                <asp:ListItem Value="1">ผลิตผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="2">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                <asp:ListItem Value="3">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-5"></div>
    </div>
    <div>
        <br />
    </div>
    <div>
        <br />
    </div>
    <div></div>

    <div class="row">
        <div class="col-lg-1" style="text-align: right;"></div>
        <div class="col-lg-2">ข้าพเจ้า :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_name" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">(ชื่อผู้รับอนุญาต)</div>
        <div class="col-lg-5"></div>
    </div>
<%--    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ซึ้งมีผู้มีดำเนินกิจการชื่อ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_bsn_name" runat="server" BorderColor="Lime" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-5"></div>
    </div>--%>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ซึ้งมีผู้มีหน้าที่ปฏิบัติการชื่อ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_phr_name" runat="server" BorderColor="Lime" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">(เฉพาะกรณีนิติบุคคล)</div>
        <div class="col-lg-5"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">เลขประจำตัวประชาชน/ใบอนุญาตทำงานเลขที่ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_iden" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-7"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ตามใบอนุญาตเลขที่ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_lcnno" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">ณ สถานที่ประกอบธุรกิจชื่อ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_location" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">อยู่เลขที่ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_addr" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">หมู่บ้าน/อาคาร :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_building" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">หมู่ที่ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_mu" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">ตรอก/ซอย :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_soi" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ถนน :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_road" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">ตำบลแขวง :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_tambol" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">อำเภอเขต :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_amphor" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">จังหวัด :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_changwat" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">รหัสไปรษณีย์ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_zipcode" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">โทรศัพท์ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_tel" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">เวลาทำการ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_opentime" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-7"></div>
    </div>
    <div id="edit1" runat="server">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                <h4>ขอเปลี่ยนแปลงรายการในใบอนุญาตดังต่อไปนี้
                    <span style="font-size: 16px; color: red;">*กรุณาเลือกรายการ</span>
                </h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-3">

                <asp:DropDownList ID="DDL_EDIT_REASON" runat="server" DataValueField="LCN_REASON_TYPE" DataTextField="LCN_REASON_NAME" BackColor="White" Height="25px" Width="400px" SkinID="bootstrap" AutoPostBack="True">
                </asp:DropDownList>


            </div>

        </div>
        <div class="row" id="lb1" runat="server" visible="false">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                <h4>
                    <asp:Label ID="lb_select_reason" runat="server"></asp:Label>
                    <span style="font-size: 16px; color: red;">*กรุณาเลือกรายการ
                    </span>
                </h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-4" runat="server">
                <asp:DropDownList ID="DDL_EDIT_REASON_SUB" runat="server" DataValueField="SUB_REASON_TYPE" DataTextField="SUB_REASON_NAME" BackColor="White" Height="25px" Width="400px" SkinID="bootstrap" AutoPostBack="True" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div id="edit_dd1" runat="server" visible="false">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <h4>ข้อมูลกรณีเปลี่ยน/เพิ่ม/ถอน/แจ้งเปลี่ยนหน้าที่ ผู้มีหน้าที่ปฏิบัติการ
                    <span style="font-size: 16px; color: red;">*เพิ่มข้อมูล หรือแก้ไขข้อมูล</span>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4" style="text-align: right">เลขที่บัตรประชาชน :</div>
                <div class="col-lg-2">
                    <asp:TextBox ID="txt_PHR_CTZNO" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-4" style="text-align: right">
                    คำนำหน้าชื่อ : 
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:DropDownList ID="ddl_prefix" runat="server" DataTextField="thanm" DataValueField="prefixcd"></asp:DropDownList>
                </div>
                <%--     <div class="col-lg-2" style="text-align: right">
                    ชื่อผู้มีหน้าที่ปฏิบัติการ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="txt_PHR_NAME" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
                </div>--%>
            </div>
            <div class="row">
                <div class="col-lg-4" style="text-align: right">
                    กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลป ชื่อ:  
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl1_PHR_TEXT_JOB" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-2" style="text-align: right">
                    ใบอนุญาตประกอบวิชาชีพ/โรคศิลปะเลขที่ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl1_PHR_TEXT_NUM" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4" style="text-align: right">
                    หรือ กรณีที่ไม่ใช่ผู้ประกอบวิชาชีพหรือผู้ประกอบโรคศิลปะ ให้ระบุคุณวุฒิ :  
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl1_STUDY_LEVEL" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-2" style="text-align: right">
                    สาขา :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl1_PHR_SAKHA" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4" style="text-align: right">
                    ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl1_NAME_SIMINAR" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-2" style="text-align: right">
                    วันที่อบรม :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl1_SIMINAR_DATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4" style="text-align: right">
                    เวลาทำการ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl1_TIME_WORK" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-2" style="text-align: right">เป็นผู้ที่มีหน้าที่ปฏิบัติการตาม :</div>
                <div class="col-lg-4">
                     <div class="col-lg-5" style="text-align: center">
                             <asp:RadioButtonList ID="rdl_mastra" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">มาตรา ๓๑&nbsp;</asp:ListItem>
                        <asp:ListItem Value="2">มาตรา ๓๒&nbsp;</asp:ListItem>
                        <asp:ListItem Value="3">มาตรา ๓๓&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                     </div>
                     <div class="col-lg-5" style="text-align: left">                               
                   แห่ง พ.ร.บ.ผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๒
                     </div>
      
                </div>
               <%-- <div class="col-lg-4"> </div>--%>
            </div>
            <div class="row">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button ID="btn_save" runat="server" Text="เพิ่มผุ้มีหน้าที่ปฏิบัติการ" Height="45px" Width="320px" />
                </div>
            </div>
            <div class="row" style="height: 15px"></div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <telerik:RadGrid ID="rgphr" runat="server" Width="90%">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                    HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
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
                                <%-- <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                    CommandName="edt" Text="แก้ไข">
                    <HeaderStyle Width="70px" />
                </telerik:GridButtonColumn>--%>
                                <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_edit" ItemStyle-Width="15%"
                                    CommandName="r_edit" Text="แก้ไขข้อมูล" ConfirmText="คุณต้องการแก้ไขผู้ปฏิบัติการหรือไม่">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridButtonColumn>--%>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                    CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ปฏิบัติการหรือไม่">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>

            </div>
        </div>
        <div id="edit_dd2" runat="server" visible="false">
            <%--topic3--%>
            <uc3:UC_LCN_EDIT_TOPIC_3 ID="UC_LCN_EDIT_TOPIC_3_DDL2" runat="server" />
        </div>
        <div id="edit_dd3_sub1" runat="server" visible="false">
            <%--topic2--%>
            <uc2:UC_LCN_EDIT_TOPIC_2 ID="UC_LCN_EDIT_TOPIC_2_DDL3" runat="server" />
        </div>
        <div id="edit_dd3_sub2" runat="server" visible="false">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <h4>ข้อมูลกรณีได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินการเป็นบุคคลต่างด้าวระบุ
                    <span style="font-size: 16px; color: red;">*เพิ่มข้อมูล หรือแก้ไขข้อมูล</span>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">หนังสือเดืนทางเลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl3_sub2_GIVE_PASSPORT_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">วันหมดอายุ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl3_sub2_GIVE_PASSPORT_EXPDATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">ใบอนุญาตทำงานเลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl3_sub2_GIVE_WORK_LICENSE_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">วันหมดอายุ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl3_sub2_GIVE_WORK_LICENSE_EXPDATE" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="edit_dd4" runat="server" visible="false">
            <%--topic3--%>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <h4>ข้อมูลกรณีเปลี่ยนเวลาทำการ
                    <span style="font-size: 16px; color: red;">*เพิ่มข้อมูล หรือแก้ไขข้อมูล</span>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">
                    เวลาทำการ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl4_opentime" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
        </div>
        <div id="edit_dd5" runat="server" visible="false">
            <%--topic3--%>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <h4>ข้อมูลกรณีกรณีเปลี่ยนเบอร์โทรศัพท์/ยกเลิกหมวดผลิตภัณฑ์สมุนไพร
                    <span style="font-size: 16px; color: red;">*เพิ่มข้อมูล หรือแก้ไขข้อมูล</span>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*สถานที่ประกอบธุรกิจ</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">
                    โทรศัพท์ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl5_tel" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">
                    อีเมล์ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl5_email" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*สถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">
                    โทรศัพท์ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl5_KEEP_tel" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">
                    อีเมล์ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl5_KEEP_email" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <uc4:UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB ID="UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL5" runat="server" />
            <%--UC ยกเลิกหมวดผลิตภัณฑ์สมุนไพร--%> <%--ผลิต, นำเข้า, ขาย--%>
            <%--bind ข้อมูลจาก base--%>
        </div>
        <div id="edit_dd6" runat="server" visible="false">
            <uc3:UC_LCN_EDIT_TOPIC_3 ID="UC_LCN_EDIT_TOPIC_3_DDL6" runat="server" />
        </div>
        <div id="edit_dd7" runat="server" visible="false">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <h4>ข้อมูลกรณีเปลี่ยนคำนำหน้า/ชื่อตัว/ชื่อสกุล/ ของผู้รับอนุญาต ผู้มีหน้าที่ปฏิบัติการ ผู้ดำเนินกิจการ
                    <span style="font-size: 16px; color: red;">*เพิ่มข้อมูล หรือแก้ไขข้อมูล</span>
                    </h4>
                </div>
            </div>
            <%--topic1--%>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*ข้อมูลผู้ขออนุญาต</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">
                    ข้าพเจ้า(ชื่อบุคคล/นิติบุคคล) :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl7_dalcn_BSN_THAIFULLNAME" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <%--topic2--%>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*ข้อมูลผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจกาเกี่ยวกับใบอนุญาต</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">
                    ชื่อผู้ดำเนินกิจการ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl7_BSN_THAIFULLNAME" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <%--topic4--%>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*ข้อมูลผู้มีหน้าที่ปฏิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">
                    กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl7_PHR_TEXT_JOB" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
        </div>
        <div id="edit_dd8" runat="server" visible="false">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <h4>ข้อมูลกรณีเปลี่ยนชื่อร้าน/ชื่อสถานที่ขายฯ/นำสั่ง/ผลิตฯ (บุคคลธรรมดา/นิติบุคคล/แปรสภาพ)
                    <span style="font-size: 16px; color: red;">*เพิ่มข้อมูล หรือแก้ไขข้อมูล</span>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">
                    สถานที่ประกอบธุรกิจชื่อ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl8_thanameplace" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">
                    เลขรหัสประจำบ้าน :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl8_HOUSENO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">
                    อยู่เลขที่ :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl8_thaaddr" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">
                    หมู่บ้าน/อาคาร :
                </div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl8_thabuilding" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
        </div>
        <%--ddl9_sub1--%>
        <div id="edit_dd9_sub1" runat="server" visible="false">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*กรณีผู้ข้ออนุญาตเป็นบุคคลต่างด้าว ระบุ</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">หนังสือเดินทางเลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_PASSPORT_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">วันหมดอายุ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_PASSPORT_EXPDATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">ใบสำคัญถิ่นที่อยู่เลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_BS_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">ออกให้ ณ วันที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_BS_DATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">ใบอนุญาตทำงานเลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_WORK_LICENSE_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">วันหมดอายุ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_WORK_LICENSE_EXPDATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*หรือใบอนุญาตประกอบธุรกิจตามบัญชีสาม (๑๔)หรือ(๑๕) ตามกฏหมายว่าด้วยการประกอบธุรกิจของคนต่างดาว</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">เลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_DOC_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">ออกให้ ณ วันที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_DOC_DATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">หรือหนังสือรับรองตามกฏหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_FRGN_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">ออกให้ ณ วันที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub1_FRGN_DATE" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <%--ddl9_sub2--%>
        <div id="edit_dd9_sub2" runat="server" visible="false">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*กรณีผู้ข้ออนุญาตเป็นบุคคลต่างด้าว ระบุ ใบอนุญาตประกอบธุรกิจตามบัญชีสาม (๑๔)หรือ(๑๕) ตามกฏหมายว่าด้วยการประกอบธุรกิจของคนต่างดาว</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">เลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub2_DOC_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">ออกให้ ณ วันที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub2_DOC_DATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">หรือหนังสือรับรองตามกฏหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub2_FRGN_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">ออกให้ ณ วันที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub2_FRGN_DATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <span style="font-size: 16px; color: red;">*กรณีผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการเป็นบุคคลต่างด้าว ระบุ</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">หนังสือเดืนทางเลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub2_GIVE_PASSPORT_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">วันหมดอายุ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub2_GIVE_PASSPORT_EXPDATE" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2" style="text-align: right">ใบอนุญาตทำงานเลขที่ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub2_GIVE_WORK_LICENSE_NO" runat="server">GET_DATA</asp:TextBox>
                </div>
                <div class="col-lg-1" style="text-align: right">วันหมดอายุ :</div>
                <div class="col-lg-2" style="text-align: left">
                    <asp:TextBox ID="text_edit_ddl9_sub2_GIVE_WORK_LICENSE_EXPDATE" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="edit_dd9_sub3" runat="server" visible="false">
            <uc2:UC_LCN_EDIT_TOPIC_2 ID="UC_LCN_EDIT_TOPIC_2_DD9_SUB3" runat="server" />
        </div>
        <div id="edit_dd10" runat="server" visible="false">
            <div class="row">
                <uc4:UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB ID="UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL10" runat="server" />
            </div>

        </div>
        <div id="edit_dd11" runat="server" visible="false">
            <div class="row">
                <uc4:UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB ID="UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB_DDL11" runat="server" />
            </div>
        </div>
        <div id="edit_dd12" runat="server" visible="false">
            <%--topic3--%>
            <uc3:UC_LCN_EDIT_TOPIC_3 ID="UC_LCN_EDIT_TOPIC_3_DDL" runat="server" />
        </div>
    </div>
    <div>
        <%--<asp:Panel ID="p1" runat="server" Visible="false">
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-8">
                    <h3>รายการเอกสารแนบ</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10">
                    <span style="font-size: 16px; color: red;">
                        <asp:Label ID="cm1" runat="server">*ในขั้นตอนการแนบไฟล์นี้ ท่านสามารถแนบไฟล์และอัพโหลดไฟล์แนบไปทีละหัวข้อได้โดยไม่จำเป็นต้องแนบไฟล์ทั้งหมด แล้วกดยืนยันไฟล์แนบทีเดียว ทั้งนี้ หากทั้งไม่สามารถแนบไฟล์ทั้งหมดให้ครบในครั้งเดียวได้ ท่านสามารถยืนยันไฟล์แนบเฉพาะหัวข้อที่ท่านแนบไฟล์แล้ว และสามารถมาแนบไฟล์เพิ่มต่อในภายหลัง</asp:Label>
                    </span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-log4">
                    <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดเอกสาร" CssClass="btn-sm" OnClientClick="return confirm('กรุณาตรวจสอบความถูกต้องของเอกสารก่อนกด ยืนยัน');" />&nbsp;&nbsp;
                </div>
            </div>

            <div class="row">
                <div class="col-lg-1"></div>
                <div>
                    <div style="overflow-x: scroll; height: 300px">

                        <asp:Table ID="tb_type_menu" runat="server" CssClass="table" Width="100%"></asp:Table>

                    </div>
                </div>

            </div>
        </asp:Panel>--%>
    </div>
    <div id="edit2" runat="server">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-11">
                <h4>เหตุผลการขอแก้ไขใบอนุญาต :</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_reason_name" runat="server" TextMode="MultiLine" BackColor="White" Height="100px" Width="600px" SkinID="bootstrap"></asp:TextBox>
            </div>

        </div>
    </div>





</div>

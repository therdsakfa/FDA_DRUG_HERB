<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_SUB.ascx.vb" Inherits="FDA_DRUG_HERB.UC_LCN_SUB" %>
<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>

<style type="text/css">
    .auto-style3 {
        width: 1099px;
        height: 124px;
    }
</style>

<div>

    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-3">
            <h2>คำขอใบแทนใบอนุญาต</h2>
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
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ข้าพเจ้า :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_name" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="col-lg-2">(ชื่อผู้รับอนุญาต)</div>
        <div class="col-lg-5"></div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">ซึ่งมีผู้ดำเนินกิจการชื่อ :</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted">
            <asp:TextBox ID="txt_sub_bsn_name" runat="server" BorderColor="Lime" BorderStyle="None" ReadOnly="True"></asp:TextBox>
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

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-3">
            <h4>มีความประสงค์ขอใบแทนใบอนุญาตฯ</h4>
        </div>
        <div class="col-lg-8"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            <h4>เนื่องจาก</h4>
        </div>
        <div class="col-lg-4" style="text-align: center;">
            <%--<asp:TextBox ID="txt_sub_PURPOSE" runat="server" Width="100%"></asp:TextBox>--%>
            <asp:DropDownList ID="ddl_sub_purpose" runat="server" DataTextField="TYPE_NAME" DataValueField="TYPE_ID" BackColor="White" Height="25px" Width="400px" SkinID="bootstrap" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="col-lg-2">(เหตุที่ขอรับใบแทน)</div>
        <div class="col-lg-2"></div>
    </div>
    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-3">
            <%--<asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />--%>
        </div>
        <div class="col-lg-5"></div>
    </div>
    <div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <asp:Panel ID="Panel2_1" runat="server" Style="display: none; color: red">
                    <p style="color: red">
                        *หมายเหตุภายหลังจากที่การดำเนินการแล้วเสร็จขอให้ท่านส่งเอกสารใบอนุญาตฉบับจริงมายังกลุ่มสถานที่ กองผลิตภัณฑ์สมุนไพร สำนักงานคณะกรรมการอาหารและยา เลขที่ 88/24 ถนนติวานนท์ ตำบลตลาดขวัญ อำเภอเมืองนนทบุรี จังหวัดนนทบุรี 11000 เพื่อประกอบการดำเนินการต่อไป
                    </p>
                </asp:Panel>
            </div>
            <div class="col-lg-8"></div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                <asp:Panel ID="Panel3" runat="server" Style="display: none;">
                    <h3>กรุณาแนบไฟล์ดังต่อไปนี้</h3>
                </asp:Panel>
                <table class="auto-style3">
                    <%--<tr><td style="width:15%;">   ใบคำขอ</td><td>   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>--%>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server" Style="display: none;">
                                <%--  <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <p style="color: red">
                                            *หมายเหตุภายหลังจากที่การดำเนินการแล้วเสร็จขอให้ท่านส่งเอกสารใบอนุญาตฉบับจริงมายังกลุ่มสถานที่ กองผลิตภัณฑ์สมุนไพร สำนักงานคณะกรรมการอาหารและยา เลขที่ 88/24 ถนนติวานนท์ ตำบลตลาดขวัญ อำเภอเมืองนนทบุรี จังหวัดนนทบุรี 11000 เพื่อประกอบการดำเนินการต่อไป
                                        </p>
                                    </div>
                                    <div class="col-lg-8"></div>
                                </div>--%>

                                <uc1:UC_ATTACH_DRUG ID="uc102_1" runat="server" />
                                <%-- <uc1:UC_ATTACH_DRUG ID="uc102_2" runat="server" />
                                    <uc1:UC_ATTACH_DRUG ID="uc102_3" runat="server" />--%>
                            </asp:Panel>
                            <asp:Panel ID="Panel2" runat="server" Style="display: none;">
                                <uc1:UC_ATTACH_DRUG ID="uc102_2" runat="server" />
                                <%--    <uc1:UC_ATTACH_DRUG ID="UC_ATTACH_DRUG2" runat="server" />
                                    <uc1:UC_ATTACH_DRUG ID="UC_ATTACH_DRUG3" runat="server" />--%>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <%-- <td colspan="2">หมายเหตุ : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว</td>--%>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</div>

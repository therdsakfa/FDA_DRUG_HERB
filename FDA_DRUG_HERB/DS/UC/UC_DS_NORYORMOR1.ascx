﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_NORYORMOR1.ascx.vb" Inherits="FDA_DRUG_HERB.UC_DS_NORYORMOR1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">

    .auto-style1 {
        height: 21px;
    }
    .auto-style3 {
        width: 417px;
    }
    .auto-style4 {
        height: 21px;
        width: 417px;
    }
    .auto-style6 {
        width: 417px;
        height: 26px;
    }
    .auto-style7 {
        height: 26px;
    }
    .auto-style8 {
        width: 417px;
        height: 24px;
    }
    .auto-style9 {
        height: 24px;
    }
    .auto-style10 {
        width: 417px;
        height: 54px;
    }
    .auto-style11 {
        height: 54px;
    }
</style>

<table class="table" style="width:100%;">
    <tr>
        <td align="right" class="auto-style3">
            เขียนที่ :</td>
        <td>
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style3">
           วันที่ :</td>
        <td>
            <asp:TextBox ID="txt_WRITE_DATE" runat="server"></asp:TextBox>
            <asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style3">
                Product ID :</td>
            <td>
                <asp:TextBox ID="txt_secrch" runat="server"></asp:TextBox>
                <asp:button ID="btn_search" runat="server" Text="ดึงข้อมูล"></asp:button>
            </td>
        </tr>
          <tr>
            <td align="right" class="auto-style3">
                คำขออนุญาตินำหรือสั่งยา :</td>
            <td>
                <asp:RadioButton  ID="chk_for1" runat="server" GroupName="for" Text="แผนปัจจุบัน เข้ามาในราชอาณาจักรเพื่อการวิเคราะห์"></asp:RadioButton>
                <br />
                <asp:RadioButton ID="chk_for2" runat="server" GroupName="for"  Text="แผนโบราณ เข้ามาในราชอาณาจักรเพื่อการวิเคราะห์" AutoPostBack="True"></asp:RadioButton> 
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ชื่อผู้รับอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style10">
                ในนามของ :</td>
            <td class="auto-style11">
                <asp:Radiobutton ID="CheckBox1" Text="กระทรวง" runat="server" GroupName="in_name" AutoPostBack="True" /><asp:TextBox ID="txt_krathrwng" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                <asp:Radiobutton ID="CheckBox2" Text="ทบวง" runat="server" GroupName="in_name" AutoPostBack="True"/><asp:TextBox ID="txt_thabuang" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                <asp:Radiobutton ID="CheckBox3" Text="กรม" runat="server" GroupName="in_name" AutoPostBack="True"/><asp:TextBox ID="txt_kom" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                <br />
                <asp:Radiobutton ID="CheckBox4" Text="สภากาชาดไทย" runat="server" GroupName="in_name" AutoPostBack="True"/>
                &nbsp;
                <asp:Radiobutton ID="CheckBox5" Text="องค์การเภสัชกรรม" runat="server" GroupName="in_name" AutoPostBack="True"/>
                <br />

            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                เลขที่ใบอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                คำขออนุญาตินำหรือสั่งยาฯ ณ สถานที่ชื่อ : :</td>
            <td>
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
         <tr>
        <td align="right" class="auto-style3">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td>
            <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
        <tr>
            <td align="right" class="auto-style4">
               ที่อยู่ :</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ซอย :</td>
            <td>
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
               ถนน :</td>
            <td>
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
               หมู่ :</td>
            <td>
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ตำบล :</td>
            <td>
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                อำเภอ :</td>
            <td>
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                จังหวัด :</td>
            <td>
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style8">
             โทรศัพท์ :</td>
            <td class="auto-style9">
                <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
            <tr>
            <td align="right" class="auto-style3">
             ชื่อยา :</td>
            <td>
                <asp:Label ID="lbl_drugthanm" runat="server" Text="-"></asp:Label>
                &nbsp;
                <asp:Label ID="lbl_drugengnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ลักษณะและสีของยา :</td>
            <td>
                <asp:Label ID="lbl_nature" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ชื่อโครงการวิจัย :</td>
            <td>
                ภาษาอังกฤษ<br />
                <asp:textbox ID="pjengnm" runat="server" Height="50px" Width="400px"></asp:textbox>
                <br />
                <br />
                ภาษาไทย (ถ้ามี)<br />
                <asp:textbox ID="pjthanm" runat="server" Height="50px" Width="400px"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                รหัสโครงการวิจัย (ถ้ามี) :</td>
            <td>
                <asp:textbox ID="pj_number" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                สถาณที่ศึกษาวิจัย :</td>
            <td>
                <asp:textbox ID="pj_lo" runat="server" Height="50px" Width="400px"></asp:textbox>
            </td>
        </tr>
        
    <%-- <tr>
            <td class="auto-style3">
                <asp:button ID="btn_add" runat="server" Text="เพิ่มตัวยาสำคัญ"></asp:button>
            </td>
            </tr>--%>
         <tr>
              <td class="auto-style3">

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="จำนวน" DataField="DOSAGE" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="sunitengnm" HeaderText="หน่วย" DataField="sunitengnm" >
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    <br />

                                    </td>
                                </tr>
    <tr>
        <td align="right" class="auto-style3">
            หน่วยนับตามรูปแบบยา</td>
        <td>
            <asp:label ID="lbl_unitnm" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True">
            </asp:label>
            <asp:label ID="lbl_unite_ida" runat="server" DataTextField="lbl_unite_ida" DataValueField="lbl_unite_ida" AutoPostBack="True" Visible="False"></asp:label>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style6">
                ปริมาณที่จะผลิต/นำสั่ง :</td>
            <td class="auto-style7">
                <asp:label ID="lbl_DOSAGE" runat="server" Text=""></asp:label>
                <asp:Label ID="lbl_unit" runat="server" AutoPostBack="True"> </asp:Label>
            </td>
        </tr>
         <tr>
            <td align="right" class="auto-style3">
                <%--<asp:CheckBox ID="chk_size" runat="server" Text="เพิ่มขนาดบรรจุ :" AutoPostBack="true"></asp:CheckBox>--%>

            <td align="center" class="auto-style3">
                บรรจุ&nbsp;
                <asp:TextBox ID="txt_size1" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lbl_size_5" runat="server" AutoPostBack="true"></asp:Label>
                &nbsp; ใน&nbsp;
                <asp:DropDownList ID="ddl_size6" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
 
                <br />
 
                บรรจุ&nbsp;
 
                <asp:TextBox ID="txt_size3" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lbl_size_m" runat="server" AutoPostBack="True"></asp:Label>
                &nbsp; ใน&nbsp;
                <asp:DropDownList ID="ddl_size4" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm"></asp:DropDownList>
                <br />
                <br />
                หมายเลขบาร์โค้ด :
                <asp:TextBox ID="txt_barcode" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:button ID="btn_add" runat="server" Text="เพิ่มขนาดบรรจุ"></asp:button>
            </td>
        </tr>
           <tr>
              <td class="auto-style3">

                   <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="SMALL_AMOUNT" HeaderText="จำนวน" DataField="SMALL_AMOUNT" >
                            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn UniqueName="SMALL_UNIT" HeaderText="ชื่อบรรจุ" DataField="SMALL_UNIT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="MEDIUM_AMOUNT" HeaderText="จำนวน" DataField="MEDIUM_AMOUNT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="MEDIUM_UNIT" HeaderText="ชื่อบรรจุ" DataField="MEDIUM_UNIT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BIG_UNIT" HeaderText="ชื่อบรรจุ" DataField="BIG_UNIT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BARCODE" HeaderText="บาร์โค้ด" DataField="BARCODE" >
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>
                                </tr>

        <tr>
            <td colspan="2">
                แนบเอกสารเพิ่มเติม </td>
        </tr>
        <tr>
            <td class="auto-style3">
                (1) ฉลากทุกขนาดบรรจุ (ภาษาไทย หรือ ภาษาอังกฤษ)</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:HyperLink ID="hp_file_name1" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                (2) เอกสารกำกับยา 
                (สำหรับยาที่ขึ้นทะเบียนตำรับยาแล้ว)</td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:HyperLink ID="hp_file_name2" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
         <tr>
            <td class="auto-style3">
                (3) เอกสารคู่มือผู้วิจัย (Investigator&#39;s Brochure)(สำหรับยาที่ยังไม่ได้ขึ้นทะเบียน)</td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:HyperLink ID="hp_file_name3" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
    <tr>
            <td class="auto-style3">
                (4) เอกสารแนะนำอาสาสมัคร (Patient Information Sheet)(ภาษาไทย)</td>
            <td>
                <asp:FileUpload ID="FileUpload4" runat="server" />
                <asp:HyperLink ID="hp_file_name4" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
    <tr>
            <td class="auto-style3">
                (5) สรุปย่อโครงการวิจัย (ภาษาไทย)</td>
            <td>
                <asp:FileUpload ID="FileUpload5" runat="server" />
                <asp:HyperLink ID="hp_file_name5" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
    <tr>
            <td class="auto-style3">
                (6) รายละเอียดโครงการวิจัย ฉบับสมบูรณ์ (ภาษาไทย หรือ ภาษาอังกฤษ)</td>
            <td>
                <asp:FileUpload ID="FileUpload6" runat="server" />
                <asp:HyperLink ID="hp_file_name6" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
    <tr>
            <td class="auto-style3">
                (7) 
                เอกสารควบคุมคุณภาพและการผลิตยา</td>
            <td>
                <asp:FileUpload ID="FileUpload7" runat="server" />
                <asp:HyperLink ID="hp_file_name7" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
    <tr>
            <td class="auto-style3">
                (8) เอกสารอนุมัติให้ทำการวิจัยจากคณะกรรมการพิจารณาจริยธรรมการวิจัยในคน (Institutional Review Board: IRB หรือ Independent Ethics Committee: IEC) ที่สำนักงานตณะกรรมการอาหารและยา ยอมรับ</td>
            <td>
                <asp:FileUpload ID="FileUpload8" runat="server" />
                <asp:HyperLink ID="hp_file_name8" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
              </td>
            <td>
                <br />
                <asp:Button ID="btn_save" runat="server" Text="บันทึก"></asp:Button>
                <%--<asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก"></asp:Button>--%>
            </td>
        </tr>
    </table>


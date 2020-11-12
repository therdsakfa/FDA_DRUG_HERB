<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<style type="text/css">
    .auto-style3 {
        width: 85px;
    }
    .auto-style4 {
        width: 261px;
    }
    .auto-style5 {
        width: 185px;
}
    .auto-style6 {
        width: 85px;
        height: 35px;
    }
    .auto-style7 {
        width: 261px;
        height: 35px;
    }
    .auto-style8 {
        height: 35px;
    }
    .auto-style9 {
        width: 185px;
        height: 35px;
    }
</style>

<div>
   <form name="form" method="post" align="center;">

         <div>
            <h3 style="text-align:center;">คำขอรับใบอนูญาต<br />
             ผลิต นำเข้า หรือขายผลิตภัณฆ์สมุนไพร<br /></h3>
            <h4 style="text-align:center;"> คำขอใบอนุญาต
               <center>
                <asp:RadioButtonList ID="rdl_lcn_type" runat="server">
                    <asp:ListItem Value="1">ผลิตผลิตภัณฆ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="2">นำเข้าผลิตภัณฆ์สมุนไพร</asp:ListItem>
                    <asp:ListItem Value="3">ขายผลิตภัณฆ์สมุนไพร</asp:ListItem>
                </asp:RadioButtonList>
                </center>
            </h4>
        </div>
   
        <div>
            <center>
                <table>
                    <td>
                        เลือก &ensp;
                    </td>
                    <td>
                    <asp:RadioButtonList ID="rdl_sanchaat" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">&ensp;ไทย&ensp;</asp:ListItem>
                        <asp:ListItem Value="2">&ensp;ต่างด้าว&ensp;</asp:ListItem>
                    </asp:RadioButtonList> 
                    </td>
                </table>                               
             </center>                   
            
        </div>
       <div></div>
        <div>
             <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                 ๑. &ensp;ข้อมูลผู้ขออนุญาต</h4>
            <table>
                <tr>
                    <td class="auto-style6">
                    </td>
                    <td class="auto-style7">
                        ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style9"></td>
                    <td class="auto-style8">
                    
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        อายุ </td>
                    <td>
                        <asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label> ปี
                    </td>
                    <td class="auto-style5">สัญชาติ&ensp;</td>
                    <td><asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        เลขประจำตัวประชาชน </td>
                    <td>
                        <asp:Label ID="lbl_lcn_iden" runat="server" EnableTheming="True" Width="80%"></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        หรือเลขทะเบียนนิติบุคคล</td>
                    <td>
                        <asp:Label ID="lbl_lcn_iden2" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        ที่อยู่เลขที่</td>
                    <td>
                        <asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        หมู่บ้าน/อาคาร</td>
                    <td>
                        <asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style5">หมู่ที่</td>
                    <td><asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                         ตรอก/ซอย</td>
                    <td>
                        <asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style5">ถนน </td>
                    <td><asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        ตำบล/แขวง </td>
                    <td>
                        <asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style5">อำเภอ/เขต</td>
                    <td><asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        จังหวัด</td>
                    <td>
                        <asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style5">รหัสไปรษณีย์</td>
                    <td><asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        โทรสาร</td>
                    <td>
                        <asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;โทรศัพท์ </td>
                    <td><asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        E-mail </td>
                    <td>
                        <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style5">เวลาทำการรวมของร้าน&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txt_da_opentime" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            &ensp;&ensp;</div>
       <div>
           <h4>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;
               กรณีผู้ขออนนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>
           <table>
               <tr>
                   <td class="auto-style3"></td>
                   <td><asp:CheckBox ID="cb_Personal_Type1" text ="บุคคลธรรมดา " runat="server" /></td>
                   <td></td>
                   <td></td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>หนังสือเดินทางเลขที่</td>
                   <td><asp:TextBox ID="txt_PASSPORT_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>วันหมดอายุ</td>
                   <td>
                       <telerik:RadDatePicker ID="RDP_PASSPORT_EXPDATE" Runat="server">
                       </telerik:RadDatePicker>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>ใบสำคัญที่อยู่เลขที่</td>
                   <td><asp:TextBox ID="txt_DOC_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>ออกให้ ณ วันที่</td>
                   <td>
                       <telerik:RadDatePicker ID="RDP_DOC_DATE" Runat="server">
                       </telerik:RadDatePicker>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>ใบอนุญาตทำงานเลขที่</td>
                   <td><asp:TextBox ID="txt_WORK_LICENSE_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>วันหมดอายุ</td>
                   <td>
                       <telerik:RadDatePicker ID="RDP_WORK_LICENSE_EXPDATE" Runat="server">
                       </telerik:RadDatePicker>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td colspan="4">หรือใบอนุญาาตประกอบธุรกิจตามบัญชีสาม(๑๖)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>เลขที่</td>
                   <td><asp:TextBox ID="txt_BS_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>ออกให้ ณ วันที่</td>
                   <td><%--<asp:TextBox ID="txt" runat="server"></asp:TextBox>--%>
                       <telerik:RadDatePicker ID="RDP_BS_DATE" Runat="server">
                       </telerik:RadDatePicker>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td colspan="2">หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</td>
                   <td><asp:TextBox ID="txt_FRGN_NO" runat="server"></asp:TextBox></td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>ออกให้ ณ วันที่</td>
                   <td><%--<asp:TextBox ID="txt_FRGN_DATE" runat="server"></asp:TextBox>--%>
                       <telerik:RadDatePicker ID="RDP_FRGN_DATE" Runat="server">
                       </telerik:RadDatePicker>
                   </td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>
           <asp:CheckBox ID="cb_Personal_Type2" text ="นิติบุคคลต่างด้าว " runat="server" /></td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td colspan="4">ใบอนุญาตประกอบธุรกิจตามบัญชีสาม(๑๔)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>เลขที่</td>
                   <td><asp:TextBox ID="txt_BS_NO1" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                   </td>
                   <td>ออกให้ ณ วันที่</td>
                   <td><%--<asp:TextBox ID="txt_BS_DATE1" runat="server"></asp:TextBox>--%>
                       <telerik:RadDatePicker ID="RDP_BS_DATE1" Runat="server">
                       </telerik:RadDatePicker>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td colspan="2">หนังสือรับรองตาามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</td>
                   <td><asp:TextBox ID="txt_FRGN_NO1" runat="server"></asp:TextBox></td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>ออกให้ ณ วันที่</td>
                   <td><%--<asp:TextBox ID="txt_FRGN_NO1" runat="server"></asp:TextBox>--%>
                       <telerik:RadDatePicker ID="RDP_FRGN_DATE1" Runat="server">
                       </telerik:RadDatePicker>
                   </td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
           </table>

       </div>
       <div>
           <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
               ๒. &ensp;ข้อมูลผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการหรือดำเนนินกิจการเกี่ยวกับใบอนุญาต</h4>
           <table>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       ชื่อผู้ดำเนินการ</td>
                   <td>

                       <asp:Label ID="lbl_BSN_THAIFULLNAME" runat="server" Text=""></asp:Label>

                   </td>
                   <td>

                   </td>
                   <td>

                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       อายุ</td>
                   <td>

                       <asp:Label ID="lbl_BSN_AGE" runat="server" Text=""></asp:Label>
                       ปี </td>
                    <td>

                        สัญชาติ</td>
                   <td>

                       <asp:Label ID="Label20" runat="server" Text=""></asp:Label>

                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           เลขประจำตัวประชาชน</td>
                   <td>

                       <asp:Label ID="lbl_BSN_IDENTIFY" runat="server" Text=""></asp:Label></td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       ที่อยู่ตามทะเบียนบ้าน อยู่เลขที่</td>
                   <td>

                       <asp:Label ID="lbl_BSN_ADDR" runat="server" Text=""></asp:Label>
                   </td>
                    <td>

           หมู่บ้าน/อาคาร</td>
                   <td>

                       <asp:Label ID="lbl_BSN_BUILDING" runat="server" Text=""></asp:Label>

                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       หมู่ที่</td>
                   <td>

                       <asp:Label ID="lbl_BSN_MOO" runat="server" Text=""></asp:Label>
                   </td>
                    <td>

           ตรอก/ซอย</td>
                   <td>

                       <asp:Label ID="lbl_BSN_SOI" runat="server" Text=""></asp:Label>

                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           ถนน</td>
                   <td>

                       <asp:Label ID="lbl_BSN_ROAD" runat="server" Text=""></asp:Label></td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       ตำบล/แขวง</td>
                   <td>

                       <asp:Label ID="lbl_BSN_THMBL_NAME" runat="server" Text=""></asp:Label>
                   </td>
                    <td>

           อำเภอ/เขต</td>
                   <td>

                       <asp:Label ID="lbl_BSN_AMPHR_NAME" runat="server" Text=""></asp:Label>

                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       จังหวัด</td>
                   <td>

                       <asp:Label ID="lbl_thachngwtnm" runat="server" Text=""></asp:Label>
                   </td>
                    <td>

           รหัสไปรษณีย์</td>
                   <td>

                       <asp:Label ID="lbl_BSN_ZIPCODE" runat="server" Text=""></asp:Label>

                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           โทรสาร</td>
                   <td>

                       <asp:Label ID="lbl_BSN_FAX" runat="server" Text=""></asp:Label></td>
                    <td>

                        โทรศัพท์</td>
                   <td>

                       <asp:Label ID="lbl_BSN_TEL" runat="server" Text=""></asp:Label>

                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           E-mail</td>
                   <td>

                       <asp:Label ID="Label33" runat="server" Text=""></asp:Label></td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       &nbsp;ที่อยู่ที่สามารถติดต่อได้<asp:CheckBox ID="cb_addr" runat="server" /><%--<input type="checkbox" id="" name="vehicle1" value="Bike">--%>
           <label for="vehicle1"> </label></td>
                   <td>

                       (ใช้ที่อยู่เดียวกันกับที่อยู่ตามทะเบียนบ้าน)</td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td colspan="4">

                       (เฉพาะที่อยู่ไม่ใช้ที่อยู่เดียวกันกับทะเบียนบ้าน)</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       อยู่เลขที่</td>
                   <td>

                       <asp:TextBox ID="txt_c_thaaddr" runat="server" AutoPostBack="True"></asp:TextBox>
                   </td>
                    <td>

           หมู่บ้าน/อาคาร</td>
                   <td>

                       <asp:TextBox ID="txt_c_thabuilding" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       หมู่ที่</td>
                   <td>

                       <asp:TextBox ID="txt_c_thamu" runat="server"></asp:TextBox>
                   </td>
                    <td>

           ตรอก/ซอย</td>
                   <td>

                       <asp:TextBox ID="txt_c_thasoi" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           ถนน</td>
                   <td>

                       <asp:TextBox ID="txt_c_tharoad" runat="server"></asp:TextBox>
                   </td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       ตำบล/แขวง</td>
                   <td>

            <asp:DropDownList ID="ddl_tambol" runat="server" AutoPostBack="True" DataTextField="thathmblnm" DataValueField="thmblcd">
            </asp:DropDownList>
                   </td>
                    <td>

           อำเภอ/เขต</td>
                   <td>

            <asp:DropDownList ID="ddl_amphor" runat="server" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
            </asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

                       จังหวัด</td>
                   <td>

            <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
                   </td>
                    <td>

           รหัสไปรษณีย์</td>
                   <td>

                       <asp:TextBox ID="txt_c_zipcode" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           โทรสาร</td>
                   <td>

                       <asp:TextBox ID="txt_c_fax" runat="server"></asp:TextBox>
                   </td>
                    <td>

                        โทรศัพท์</td>
                   <td>

                       <asp:TextBox ID="txt_c_tel" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>

           E-mail</td>
                   <td>

                       <asp:TextBox ID="txt_c_email" runat="server"></asp:TextBox>
                   </td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
           </table>


       </div>
       <div>
           <h4>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;
               กรณีผู้ได้รับมอบหมายหรือแต่งตั้งให้กำหนดกิจการเป็นบุคคลต่างด้าว ระบุ</h4>&ensp;
           <table>
               <tr>
                   <td class="auto-style3"></td>
                   <td>
                       หนังสือเดินทางเลขที่
                   </td>
                   <td>
                        <asp:TextBox ID="txt_GIVE_PASSPORT_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>
                        วันหมดอายุ
                   </td>
                   <td>
                        <telerik:RadDatePicker ID="rdp_GIVE_PASSPORT_EXPDATE" Runat="server"></telerik:RadDatePicker>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>
                       ใบอนุญาตทำงานเลขที่
                   </td>
                   <td>
                         <asp:TextBox ID="txt_GIVE_WORK_LICENSE_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>
                        วันหมดอายุ
                   </td>
                   <td>
                       <telerik:RadDatePicker ID="rdp_GIVE_WORK_LICENSE_EXPDATE" Runat="server"></telerik:RadDatePicker>
                   </td>
               </tr>
           </table>
           
           
           <br />&ensp;
          
           
       </div>
       <div>
           <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
               ๓. &ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฆ์สมุนไพร</h4>&ensp;

           <table>
               <tr>
                   <td class="auto-style3"></td>
                   <td>
               <b>สถานที่ประกอบธุรกิจชื่อ</b></td>
                   <td><asp:Label ID="lbl_lct_thanameplace" runat="server" Text=""></asp:Label></td>
                   <td></td><td></td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>เลขรหัสประจำบ้าน</td>
                   <td><asp:Label ID="lbl_lct_HOUSENO" runat="server" Text=""></asp:Label>
                   </td><td></td><td></td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>อยู่เลขที่</td>
                   <td><asp:Label ID="lbl_lct_thaaddr" runat="server" Text=""></asp:Label>
                   </td><td>หมู่บ้าน/อาคาร</td><td><asp:Label ID="lbl_lct_thabuilding" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>หมู่ที่</td>
                   <td><asp:Label ID="lbl_lct_thamu" runat="server" Text=""></asp:Label>
                   </td><td>ตรอก/ซอย</td><td><asp:Label ID="lbl_lct_thasoi" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td></td>
                   <td>&nbsp;ถนน</td>
                   <td><asp:Label ID="lbl_lct_tharoad" runat="server" Text=""></asp:Label>
                   </td><td>&nbsp;</td><td>&nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>ตำบล/แขวง</td>
                   <td><asp:Label ID="lbl_lct_thathmblnm" runat="server" Text=""></asp:Label>
                   </td><td>&nbsp;อำเภอ/เขต</td><td><asp:Label ID="lbl_lct_thaamphrnm" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>จังหวัด</td>
                   <td><asp:Label ID="lbl_lct_thachngwtnm" runat="server" Text=""></asp:Label>
                   </td><td>รหัสไปรษณีย์</td><td><asp:Label ID="lbl_lct_zipcode" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>โทรสาร</td>
                   <td><asp:Label ID="lbl_lct_fax" runat="server" Text=""></asp:Label>
                   </td><td>โทรศัพท์</td><td><asp:Label ID="lbl_lct_tel" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>E-mail</td>
                   <td><asp:Label ID="Label59" runat="server" Text=""></asp:Label>
                   </td><td>&nbsp;</td><td>&nbsp;</td>
               </tr>
           </table>
           <div></div>         
       </div>

       
       
    </form>
</div>
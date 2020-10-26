<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB" %>

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
                
            </div>
        <div>
            <h4 style="text-align:center;">เลือก
                <asp:CheckBox ID="checkbox5" text ="ไทย " runat="server" />
                <asp:CheckBox ID="checkbox6" text ="ต่างด้าว " runat="server" /><br>
            </h4>
        </div>
        <div>
             <h4>๑. &ensp;ข้อมูลผู้ขออนุญาต</h4>
            <table>
                <tr>
                    <td>
                        ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                    </td>
                    <td>
<asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        อายุ </td>
                    <td>
                        <asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label> ปี
                    </td>
                    <td>สัญชาติ&ensp;</td>
                    <td><asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        เลขประจำตัวประชาชน </td>
                    <td>
                        <asp:Label ID="lbl_lcn_iden" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        หรือเลขทะเบียนนิติบุคคล</td>
                    <td>
                        <asp:Label ID="lbl_lcn_iden2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        ที่อยู่เลขที่</td>
                    <td>
                        <asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        หมู่บ้าน/อาคาร</td>
                    <td>
                        <asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>
                    </td>
                    <td>หมู่ที่</td>
                    <td><asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                         ตรอก/ซอย</td>
                    <td>
                        <asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>
                    </td>
                    <td>ถนน </td>
                    <td><asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        ตำบล/แขวง </td>
                    <td>
                        <asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>
                    </td>
                    <td>อำเภอ/เขต</td>
                    <td><asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        จังหวัด</td>
                    <td>
                        <asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>
                    </td>
                    <td>รหัสไปรษณีย์</td>
                    <td><asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        โทรสาร</td>
                    <td>
                        <asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;โทรศัพท์ </td>
                    <td><asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        E-mail </td>
                    <td>
                        <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            &ensp;&ensp;</div>
       <div>
           <h4> กรณีผู้ขออนนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>
           <table>
               <tr>
                   <td><asp:CheckBox ID="cb_Personal_Type1" text ="บุคคลธรรมดา " runat="server" /></td>
                   <td></td>
                   <td></td>
                   <td></td>
               </tr>
               <tr>
                   <td>หนังสือเดินทางเลขที่</td>
                   <td><asp:TextBox ID="txt_PASSPORT_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>วันหมดอายุ</td>
                   <td><asp:TextBox ID="txt_PASSPORT_EXPDATE" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                   <td>ใบสำคัญที่อยู่เลขที่</td>
                   <td><asp:TextBox ID="txt_DOC_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>ออกให้ ณ วันที่</td>
                   <td><asp:TextBox ID="txt_DOC_DATE" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                   <td>ใบอนุญาตทำงานเลขที่</td>
                   <td><asp:TextBox ID="txt_WORK_LICENSE_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>วันหมดอายุ</td>
                   <td><asp:TextBox ID="txt_WORK_LICENSE_EXPDATE" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                   <td colspan="4">หรือใบอนุญาาตประกอบธุรกิจตามบัญชีสาม(๑๖)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</td>
               </tr>
               <tr>
                   <td>เลขที่</td>
                   <td><asp:TextBox ID="txt_BS_NO" runat="server"></asp:TextBox>
                   </td>
                   <td>ออกให้ ณ วันที่</td>
                   <td><asp:TextBox ID="txt_BS_DATE" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                   <td colspan="2">หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</td>
                   <td><asp:TextBox ID="txt_FRGN_NO" runat="server"></asp:TextBox></td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td>ออกให้ ณ วันที่</td>
                   <td><asp:TextBox ID="txt_FRGN_DATE" runat="server"></asp:TextBox></td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td>
           <asp:CheckBox ID="cb_Personal_Type2" text ="นิติบุคคลต่างด้าว " runat="server" /></td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td colspan="4">ใบอนุญาตประกอบธุรกิจตามบัญชีสาม(๑๔)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</td>
               </tr>
               <tr>
                   <td>เลขที่</td>
                   <td><asp:TextBox ID="txt_BS_NO1" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                   </td>
                   <td>ออกให้ ณ วันที่</td>
                   <td><asp:TextBox ID="txt_BS_DATE1" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                   <td colspan="2">หนังสือรับรองตาามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</td>
                   <td><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td>ออกให้ ณ วันที่</td>
                   <td><asp:TextBox ID="txt_FRGN_NO1" runat="server"></asp:TextBox>
                   </td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
           </table>

       </div>
       <div>
           <h4>๒. &ensp;ข้อมูลผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการหรือดำเนนินกิจการเกี่ยวกับใบอนุญาต</h4>
           <table>
               <tr>
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
                   <td>

                       &nbsp;ที่อยู่ที่สามารถติดต่อได้<input type="checkbox" id="vehicle8" name="vehicle1" value="Bike">
           <label for="vehicle1"> </label></td>
                   <td>

                       (ใช้ที่อยู่เดียวกันกับที่อยู่ตามทะเบียนบ้าน)</td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td colspan="4">

                       (เฉพาะที่อยู่ไม่ใช้ที่อยู่เดียวกันกับทะเบียนบ้าน)</td>
               </tr>
               <tr>
                   <td>

                       อยู่เลขที่</td>
                   <td>

                       <asp:Label ID="Label34" runat="server" Text=""></asp:Label>
                   </td>
                    <td>

           หมู่บ้าน/อาคาร</td>
                   <td>

                       <asp:Label ID="Label35" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td>

                       หมู่ที่</td>
                   <td>

                       <asp:Label ID="Label36" runat="server" Text=""></asp:Label>
                   </td>
                    <td>

           ตรอก/ซอย</td>
                   <td>

                       <asp:Label ID="Label37" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>

           ถนน</td>
                   <td>

                       <asp:Label ID="Label38" runat="server" Text=""></asp:Label></td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
               <tr>
                   <td>

                       ตำบล/แขวง</td>
                   <td>

                       <asp:Label ID="Label39" runat="server" Text=""></asp:Label>
                   </td>
                    <td>

           อำเภอ/เขต</td>
                   <td>

                       <asp:Label ID="Label40" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td>

                       จังหวัด</td>
                   <td>

                       <asp:Label ID="Label41" runat="server" Text=""></asp:Label>
                   </td>
                    <td>

           รหัสไปรษณีย์</td>
                   <td>

                       <asp:Label ID="Label42" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>

           โทรสาร</td>
                   <td>

                       <asp:Label ID="Label43" runat="server" Text=""></asp:Label></td>
                    <td>

                        โทรศัพท์</td>
                   <td>

                       <asp:Label ID="Label44" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>

           E-mail</td>
                   <td>

                       <asp:Label ID="Label45" runat="server" Text=""></asp:Label></td>
                    <td>

                        &nbsp;</td>
                   <td>

                       &nbsp;</td>
               </tr>
           </table>


       </div>
       <div>
           <h4>กรณีผู้ไดด้รับมอบหมายหรือแต่งตั้งให้กำหนดกิจการเป็นบุคคลต่างด้าว ระบุ</h4>&ensp;
           หนังสือเดินทางเลขที่<asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
           วันหมดอายุ<asp:TextBox ID="TextBox16" runat="server"></asp:TextBox><br />&ensp;
           ใบอนุญาตทำงานเลขที่<asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
           วันหมดอายุ<asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
       </div>
       <div>
           <h4>๓. &ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฆ์สมุนไพร</h4>&ensp;

           <table>
               <tr>
                   <td>
               <b>สถานที่ประกอบธุรกิจชื่อ</b></td>
                   <td><asp:Label ID="lbl_lct_thanameplace" runat="server" Text=""></asp:Label></td>
                   <td></td><td></td>
               </tr>
               <tr>
                   <td>เลขรหัสประจำบ้าน</td>
                   <td><asp:Label ID="lbl_lct_HOUSENO" runat="server" Text=""></asp:Label>
                   </td><td></td><td></td>
               </tr>
               <tr>
                   <td>อยู่เลขที่</td>
                   <td><asp:Label ID="lbl_lct_thaaddr" runat="server" Text=""></asp:Label>
                   </td><td>หมู่บ้าน/อาคาร</td><td><asp:Label ID="lbl_lct_thabuilding" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td>หมู่ที่</td>
                   <td><asp:Label ID="lbl_lct_thamu" runat="server" Text=""></asp:Label>
                   </td><td>ตรอก/ซอย</td><td><asp:Label ID="lbl_lct_thasoi" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>&nbsp;ถนน</td>
                   <td><asp:Label ID="lbl_lct_tharoad" runat="server" Text=""></asp:Label>
                   </td><td>&nbsp;</td><td>&nbsp;</td>
               </tr>
               <tr>
                   <td>ตำบล/แขวง</td>
                   <td><asp:Label ID="lbl_lct_thathmblnm" runat="server" Text=""></asp:Label>
                   </td><td>&nbsp;อำเภอ/เขต</td><td><asp:Label ID="lbl_lct_thaamphrnm" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td>จังหวัด</td>
                   <td><asp:Label ID="lbl_lct_thachngwtnm" runat="server" Text=""></asp:Label>
                   </td><td>รหัสไปรษณีย์</td><td><asp:Label ID="lbl_lct_zipcode" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>โทรสาร</td>
                   <td><asp:Label ID="lbl_lct_fax" runat="server" Text=""></asp:Label>
                   </td><td>โทรศัพท์</td><td><asp:Label ID="lbl_lct_tel" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>E-mail</td>
                   <td><asp:Label ID="Label59" runat="server" Text=""></asp:Label>
                   </td><td>&nbsp;</td><td>&nbsp;</td>
               </tr>
           </table>

          
       </div>

       
       
    </form>
</div>
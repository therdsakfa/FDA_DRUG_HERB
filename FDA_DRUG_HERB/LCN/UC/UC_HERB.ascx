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
            &ensp;<b>ข้าพเจ้า</b>(ชื่อบุคคล/นิติบุคคล)&ensp;<asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label><br />&ensp;
            อายุ&ensp;<asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label>&ensp;ปี สัญชาติ&ensp;<asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label><br />&ensp;
            เลขประจำตัวประชาชน&ensp;<asp:Label ID="lbl_lcn_iden" runat="server" Text=""></asp:Label><br />&ensp;
            หรือเลขทะเบียนนิติบุคคล&ensp;<asp:Label ID="lbl_lcn_iden2" runat="server" Text=""></asp:Label><br />&ensp;
            ที่อยู่เลขที่&ensp;<asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label><br />&ensp;
            หมู่บ้าน/อาคาร&ensp;<asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>
            หมู่ที่&ensp;<asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>
              ตรอก/ซอย&ensp;<asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>
              ถนน&ensp;<asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label><br />&ensp;
            ตำบล/แขวง&ensp;<asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>
              อำเภอ/เขต&ensp;<asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label><br />&ensp;
            จังหวัด&ensp;<asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>
              รหัสไปรษณีย์&ensp;<asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>
            โทรสาร&ensp;<asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label><br />&ensp;
            โทรศัพท์&ensp;<asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>
              E-mail&ensp;<asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>
        </div>
       <div>
           <h4> กรณีผู้ขออนนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>
           &ensp;<asp:CheckBox ID="checkbox7" text ="บุคคลธรรมดา " runat="server" /><br />&ensp;
           หนังสือเดินทางเลขที่<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           วันหมดอายุ<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />&ensp;
           ใบสำคัญที่อยู่เลขที่<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
           ออกให้ ณ วันที่<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />&ensp;
           ใบอนุญาตทำงานเลขที่<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
           วันหมดอายุ<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />&ensp;
           หรือใบอนุญาาตประกอบธุรกิจตามบัญชีสาม(๑๖)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว<br />&ensp;
           เลขที่<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
           ออกให้ ณ วันที่<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox><br />&ensp;
           หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox><br />&ensp;
           ออกให้ ณ วันที่<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox><br />&ensp;
           <asp:CheckBox ID="checkbox8" text ="นิติบุคคลต่างด้าว " runat="server" /><br />&ensp;
           ใบอนุญาตประกอบธุรกิจตามบัญชีสาม(๑๔)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว<br />&ensp;
           เลขที่<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
           ออกให้ ณ วันที่<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox><br />&ensp;
           หนังสือรับรองตาามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่<asp:TextBox ID="TextBox13" runat="server"></asp:TextBox><br />&ensp;
           ออกให้ ณ วันที่<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
       </div>
       <div>
           <h4>๒. &ensp;ข้อมูลผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการหรือดำเนนินกิจการเกี่ยวกับใบอนุญาต</h4>
           &ensp;ชื่อผู้ดำเนินการ<asp:Label ID="lbl_BSN_THAIFULLNAME" runat="server" Text=""></asp:Label><br />&ensp;
           อายุ<asp:Label ID="lbl_BSN_AGE" runat="server" Text=""></asp:Label>
           ปี สัญชาติ<asp:Label ID="Label20" runat="server" Text=""></asp:Label>
           เลขประจำตัวประชาชน<asp:Label ID="lbl_BSN_IDENTIFY" runat="server" Text=""></asp:Label><br />&ensp;
           ที่อยู่ตามทะเบียนบ้าน อยู่เลขที่<asp:Label ID="lbl_BSN_ADDR" runat="server" Text=""></asp:Label>
           หมู่บ้าน/อาคาร<asp:Label ID="lbl_BSN_BUILDING" runat="server" Text=""></asp:Label><br />&ensp;
           หมู่ที่<asp:Label ID="lbl_BSN_MOO" runat="server" Text=""></asp:Label>
           ตรอก/ซอย<asp:Label ID="lbl_BSN_SOI" runat="server" Text=""></asp:Label>
           ถนน<asp:Label ID="lbl_BSN_ROAD" runat="server" Text=""></asp:Label><br />&ensp;
           ตำบล/แขวง<asp:Label ID="lbl_BSN_THMBL_NAME" runat="server" Text=""></asp:Label>
           อำเภอ/เขต<asp:Label ID="lbl_BSN_AMPHR_NAME" runat="server" Text=""></asp:Label><br />&ensp;
           จังหวัด<asp:Label ID="lbl_thachngwtnm" runat="server" Text=""></asp:Label>
           รหัสไปรษณีย์<asp:Label ID="lbl_BSN_ZIPCODE" runat="server" Text=""></asp:Label>
           โทรสาร<asp:Label ID="lbl_BSN_FAX" runat="server" Text=""></asp:Label><br />&ensp;
           โทรศัพท์<asp:Label ID="lbl_BSN_TEL" runat="server" Text=""></asp:Label>
           E-mail<asp:Label ID="Label33" runat="server" Text=""></asp:Label><br />&ensp;
           ที่อยู่ที่สามารถติดต่อได้<input type="checkbox" id="vehicle8" name="vehicle1" value="Bike">
           <label for="vehicle1"> (ใช้ที่อยู่เดียวกันกับที่อยู่ตามทะเบียนบ้าน)</label><br />&ensp;
           (เฉพาะที่อยู่ไม่ใช้ที่อยู่เดียวกันกับทะเบียนบ้าน)<br />&ensp;
           อยู่เลขที่<asp:Label ID="Label34" runat="server" Text=""></asp:Label>
           หมู่บ้าน/อาคาร<asp:Label ID="Label35" runat="server" Text=""></asp:Label><br />&ensp;
           หมู่ที่<asp:Label ID="Label36" runat="server" Text=""></asp:Label>
           ตรอก/ซอย<asp:Label ID="Label37" runat="server" Text=""></asp:Label>
           ถนน<asp:Label ID="Label38" runat="server" Text=""></asp:Label><br />&ensp;
           ตำบล/แขวง<asp:Label ID="Label39" runat="server" Text=""></asp:Label>
           อำเภอ/เขต<asp:Label ID="Label40" runat="server" Text=""></asp:Label><br />&ensp;
           จังหวัด<asp:Label ID="Label41" runat="server" Text=""></asp:Label>
           รหัสไปรษณีย์<asp:Label ID="Label42" runat="server" Text=""></asp:Label>
           โทรสาร<asp:Label ID="Label43" runat="server" Text=""></asp:Label><br />&ensp;
           โทรศัพท์<asp:Label ID="Label44" runat="server" Text=""></asp:Label>
           E-mail<asp:Label ID="Label45" runat="server" Text=""></asp:Label><br />&ensp;
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
               <b>สถานที่ประกอบธุรกิจชื่อ</b><asp:Label ID="lbl_lct_thanameplace" runat="server" Text=""></asp:Label><br />&ensp;          
           เลขรหัสประจำบ้าน
           &nbsp;<asp:Label ID="lbl_lct_HOUSENO" runat="server" Text=""></asp:Label>
&nbsp;อยู่เลขที่<asp:Label ID="lbl_lct_thaaddr" runat="server" Text=""></asp:Label>
           หมู่บ้าน/อาคาร<asp:Label ID="lbl_lct_thabuilding" runat="server" Text=""></asp:Label><br />&ensp;
           หมู่ที่<asp:Label ID="lbl_lct_thamu" runat="server" Text=""></asp:Label>
           ตรอก/ซอย<asp:Label ID="lbl_lct_thasoi" runat="server" Text=""></asp:Label>
           ถนน<asp:Label ID="lbl_lct_tharoad" runat="server" Text=""></asp:Label><br />&ensp;
           ตำบล/แขวง<asp:Label ID="lbl_lct_thathmblnm" runat="server" Text=""></asp:Label>
           อำเภอ/เขต<asp:Label ID="lbl_lct_thaamphrnm" runat="server" Text=""></asp:Label><br />&ensp;
           จังหวัด<asp:Label ID="lbl_lct_thachngwtnm" runat="server" Text=""></asp:Label>
           รหัสไปรษณีย์<asp:Label ID="lbl_lct_zipcode" runat="server" Text=""></asp:Label>
           โทรสาร<asp:Label ID="lbl_lct_fax" runat="server" Text=""></asp:Label><br />&ensp;
           โทรศัพท์<asp:Label ID="lbl_lct_tel" runat="server" Text=""></asp:Label>
           E-mail<asp:Label ID="Label59" runat="server" Text=""></asp:Label><br />&ensp;

          
       </div>

       
       
    </form>
</div>
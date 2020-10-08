<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB" %>

<div>
   <form name="form" method="post" align="center;">

         <div>
            <h3 style="text-align:center;">คำขอรับใบอนูญาต<br />
             ผลิต นำเข้า หรือขายผลิตภัณฆ์สมุนไพร<br /></h3>
            <h4 style="text-align:center;"> คำขอใบอนุญาติ
                <asp:CheckBox ID="checkbox2" text ="ผลิตผลิตภัณฆ์สมุนไพร " runat="server" />
                <br>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;
                <asp:CheckBox ID="checkbox3" text ="นำเข้าผลิตภัณฆ์สมุนไพร " runat="server" />
                <br>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;
                <asp:CheckBox ID="checkbox4" text ="ขายผลิตภัณฆ์สมุนไพร " runat="server" /></h4>
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
            &ensp;<b>ข้าพเจ้า</b>(ชื่อบุคคล/นิติบุคคล)<asp:Label ID="Label1" runat="server" Text=".........................."></asp:Label><br />&ensp;
            อายุ<asp:Label ID="Label2" runat="server" Text="........................"></asp:Label>ปี สัญชาติ<asp:Label ID="Label3" runat="server" Text="........................."></asp:Label><br />&ensp;
            เลขประจำตัวประชาชน<asp:Label ID="Label4" runat="server" Text="................"></asp:Label><br />&ensp;
            หรือเลขทะเบียนนิติบุคคล<asp:Label ID="Label5" runat="server" Text="....................."></asp:Label><br />&ensp;
            ที่อยู่เลขที่<asp:Label ID="Label6" runat="server" Text="......................"></asp:Label><br />&ensp;
            หมู่บ้าน/อาคาร<asp:Label ID="Label7" runat="server" Text="..................."></asp:Label>
            หมู่ที่<asp:Label ID="Label8" runat="server" Text=".................."></asp:Label>
            ตรอก/ซอย<asp:Label ID="Label9" runat="server" Text="..............."></asp:Label>
            ถนน<asp:Label ID="Label10" runat="server" Text="....................."></asp:Label><br />&ensp;
            ตำบล/แขวง<asp:Label ID="Label11" runat="server" Text=".................."></asp:Label>
            อำเภอ/เขต<asp:Label ID="Label12" runat="server" Text="...................."></asp:Label><br />&ensp;
            จังหวัด<asp:Label ID="Label13" runat="server" Text="........................."></asp:Label>
            รหัสไปรษณีย์<asp:Label ID="Label14" runat="server" Text="......................"></asp:Label>
            โทรสาร<asp:Label ID="Label15" runat="server" Text="........................"></asp:Label><br />&ensp;
            โทรศัพท์<asp:Label ID="Label16" runat="server" Text="........................."></asp:Label>
            E-mail<asp:Label ID="Label17" runat="server" Text="........................."></asp:Label>
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
           &ensp;ชื่อผู้ดำเนินการ<asp:Label ID="Label18" runat="server" Text=".................."></asp:Label><br />&ensp;
           อายุ<asp:Label ID="Label19" runat="server" Text="............."></asp:Label>
           ปี สัญชาติ<asp:Label ID="Label20" runat="server" Text="............"></asp:Label>
           เลขประจำตัวประชาชน<asp:Label ID="Label21" runat="server" Text=".............."></asp:Label><br />&ensp;
           ที่อยู่ตามทะเบียนบ้าน อยู่เลขที่<asp:Label ID="Label22" runat="server" Text="............."></asp:Label>
           หมู่บ้าน/อาคาร<asp:Label ID="Label23" runat="server" Text=".............."></asp:Label><br />&ensp;
           หมู่ที่<asp:Label ID="Label24" runat="server" Text="............."></asp:Label>
           ตรอก/ซอย<asp:Label ID="Label25" runat="server" Text="............"></asp:Label>
           ถนน<asp:Label ID="Label26" runat="server" Text="..............."></asp:Label><br />&ensp;
           ตำบล/แขวง<asp:Label ID="Label27" runat="server" Text="............"></asp:Label>
           อำเภอ/เขต<asp:Label ID="Label28" runat="server" Text="..............."></asp:Label><br />&ensp;
           จังหวัด<asp:Label ID="Label29" runat="server" Text="............."></asp:Label>
           รหัสไปรษณีย์<asp:Label ID="Label30" runat="server" Text="............."></asp:Label>
           โทรสาร<asp:Label ID="Label31" runat="server" Text="................"></asp:Label><br />&ensp;
           โทรศัพท์<asp:Label ID="Label32" runat="server" Text="..............."></asp:Label>
           E-mail<asp:Label ID="Label33" runat="server" Text=".............."></asp:Label><br />&ensp;
           ที่อยู่ที่สามารถติดต่อได้<input type="checkbox" id="vehicle8" name="vehicle1" value="Bike">
           <label for="vehicle1"> (ใช้ที่อยู่เดียวกันกับที่อยู่ตามทะเบียนบ้าน)</label><br />&ensp;
           (เฉพาะที่อยู่ไม่ใช้ที่อยู่เดียวกันกับทะเบียนบ้าน)<br />&ensp;
           อยู่เลขที่<asp:Label ID="Label34" runat="server" Text="............."></asp:Label>
           หมู่บ้าน/อาคาร<asp:Label ID="Label35" runat="server" Text="............"></asp:Label><br />&ensp;
           หมู่ที่<asp:Label ID="Label36" runat="server" Text="............."></asp:Label>
           ตรอก/ซอย<asp:Label ID="Label37" runat="server" Text="............"></asp:Label>
           ถนน<asp:Label ID="Label38" runat="server" Text="................."></asp:Label><br />&ensp;
           ตำบล/แขวง<asp:Label ID="Label39" runat="server" Text="................"></asp:Label>
           อำเภอ/เขต<asp:Label ID="Label40" runat="server" Text="................"></asp:Label><br />&ensp;
           จังหวัด<asp:Label ID="Label41" runat="server" Text="................"></asp:Label>
           รหัสไปรษณีย์<asp:Label ID="Label42" runat="server" Text="................"></asp:Label>
           โทรสาร<asp:Label ID="Label43" runat="server" Text="................."></asp:Label><br />&ensp;
           โทรศัพท์<asp:Label ID="Label44" runat="server" Text="...................."></asp:Label>
           E-mail<asp:Label ID="Label45" runat="server" Text=".................."></asp:Label><br />&ensp;
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
               <b>สถานที่ประกอบธุรกิจชื่อ</b><asp:Label ID="Label46" runat="server" Text="................"></asp:Label><br />&ensp;          
           เลขรหัสประจำบ้าน<asp:Label ID="Label47" runat="server" Text=".............."></asp:Label>
           อยู่เลขที่<asp:Label ID="Label48" runat="server" Text="..............."></asp:Label>
           หมู่บ้าน/อาคาร<asp:Label ID="Label49" runat="server" Text="..........."></asp:Label><br />&ensp;
           หมู่ที่<asp:Label ID="Label50" runat="server" Text="............."></asp:Label>
           ตรอก/ซอย<asp:Label ID="Label51" runat="server" Text="..............."></asp:Label>
           ถนน<asp:Label ID="Label52" runat="server" Text="............"></asp:Label><br />&ensp;
           ตำบล/แขวง<asp:Label ID="Label53" runat="server" Text="............"></asp:Label>
           อำเภอ/เขต<asp:Label ID="Label54" runat="server" Text="..............."></asp:Label><br />&ensp;
           จังหวัด<asp:Label ID="Label55" runat="server" Text=".............."></asp:Label>
           รหัสไปรษณีย์<asp:Label ID="Label56" runat="server" Text="..............."></asp:Label>
           โทรสาร<asp:Label ID="Label57" runat="server" Text="...................."></asp:Label><br />&ensp;
           โทรศัพท์<asp:Label ID="Label58" runat="server" Text="............."></asp:Label>
           E-mail<asp:Label ID="Label59" runat="server" Text="..............."></asp:Label><br />&ensp;
           สถานที่เก็บรักษาผลิตภัณฆ์สมุนไพร (ถ้ามี) ชื่อ <asp:Label ID="Label60" runat="server" Text="............."></asp:Label><br />&ensp;
           เลขรหัสประจำบ้าน<asp:Label ID="Label61" runat="server" Text=".............."></asp:Label>
           อยู่เลขที่<asp:Label ID="Label62" runat="server" Text=".............."></asp:Label>
           หมู่บ้าน/อาคาร<asp:Label ID="Label63" runat="server" Text="............"></asp:Label><br />&ensp;
           หมู่ที่<asp:Label ID="Label64" runat="server" Text="............"></asp:Label>
           ตรอก/ซอย<asp:Label ID="Label65" runat="server" Text="............."></asp:Label>
           ถนน<asp:Label ID="Label66" runat="server" Text="..........."></asp:Label><br />&ensp;
           ตำบล/แขวง<asp:Label ID="Label67" runat="server" Text="..........."></asp:Label>
           อำเภอ/เขต<asp:Label ID="Label68" runat="server" Text="............."></asp:Label><br />&ensp;
           จังหวัด<asp:Label ID="Label69" runat="server" Text="..............."></asp:Label>
           รหัสไปรษณีย์<asp:Label ID="Label70" runat="server" Text="............."></asp:Label>
           โทรสาร<asp:Label ID="Label71" runat="server" Text=".............."></asp:Label><br />&ensp;
           โทรศัพท์<asp:Label ID="Label72" runat="server" Text="............."></asp:Label>
           E-mail<asp:Label ID="Label73" runat="server" Text="..............."></asp:Label><br />&ensp;
       </div>
       <div>
            <h4> ๔. &ensp;ข้อมูลผุ้มีหน้าที่ปฎิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h4>
           &ensp;&ensp;&ensp;๔.๑ กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ<asp:DropDownList ID="DropDownList1"  runat="server">
            </asp:DropDownList><br />&ensp;
            ใบอนุญาตประกออนบการวิชาชีพ/โรคศิลปะเลขที่<asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>หรือ<br />&ensp;
           กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ<asp:TextBox ID="TextBox21" runat="server"></asp:TextBox><br />&ensp;
           สาขา<asp:TextBox ID="TextBox22" runat="server"></asp:TextBox><br />&ensp;
           &ensp;&ensp;๔.๒  ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร<br />&ensp;
           <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
           วันที่อบรม<asp:TextBox ID="TextBox24" runat="server"></asp:TextBox><br />&ensp;
           เป็นผู้ที่มีหน้าที่ปฎิยบัติการตาม
           <asp:CheckBox ID="checkbox9" text ="มาตรา ๓๑ " runat="server" />&ensp;
           <asp:CheckBox ID="checkbox10" text ="มาตรา ๓๒ " runat="server" />&ensp;
           <asp:CheckBox ID="checkbox11" text ="มาตรา ๓๓ " runat="server" />&ensp;
           แห่ง พ.ร.บ.ผลิตภัณฆ์สมุนไพร พ.ศ.๒๕๖๒
       </div>
       
    </form>
</div>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm39.aspx.vb" Inherits="FDA_DRUG_HERB.WebForm39" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                &nbsp;
            </p>
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">เจน XML จดแจ้ง</h3>
            <p>
                <asp:TextBox ID="txt_iden_jj" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
            <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">เลขบัตรคนกด&nbsp;
            <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none">

                <br />
                <asp:TextBox ID="txt_tr_id_jj" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label1" runat="server" Text="เลขดำเนินการ"></asp:Label>
                <br />

                <asp:TextBox ID="txt_IDA_jj" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="เลข IDA ทะเบียน"></asp:Label>
                <br />

                <asp:TextBox ID="txt_IDA_LCN_JJ" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label3" runat="server" Text="เลข IDA ใบอนุญาต"></asp:Label>
                <br />
                <asp:TextBox ID="txt_PROCESS_ID_JJ" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:Label ID="Label4" runat="server" Text="เลข PROCESS_ID ทะเบียน"></asp:Label>
                <br />
                <asp:TextBox ID="txt_detail_jj" runat="server" Height="18px" TextMode="MultiLine" Width="159px"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:Label ID="lbl_jj_des" runat="server" Text="รายละเอียด"></asp:Label>
            </span></span>
            </p>
            <asp:Button ID="BTN_GEN_XML_JJ1" runat="server" Text="สร้าง xml จจ1" Height="45px" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_JJ2" runat="server" Height="45px" Text="สร้าง xml จจ2(สั้น)" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_JJ2_L" runat="server" Height="45px" Text="สร้าง xml จจ2(ยาว)" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_JJ3" runat="server" Height="45px" Text="สร้าง xml จจ3" Width="170px" />
            <br />
            <br />
            <hr />
            <br />
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">เจน XML ทะเบียน</h3>
            <p>
                <asp:TextBox ID="txt_iden_TBN" runat="server"></asp:TextBox>
                &nbsp;&nbsp; <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">เลขบัตรคนกด&nbsp; <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none">
                    <br />
                    <asp:TextBox ID="txt_tr_id_TBN" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="เลขดำเนินการ"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_IDA_TBN" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="เลข IDA ทะเบียน(drrqt)"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_IDA_LCN_TBN" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="เลข IDA ใบอนุญาต"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_PROCESS_ID_TBN" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="เลข PROCESS_ID ทะเบียน"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_detail_TBN" runat="server" Height="50px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                    &nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Text="รายละเอียด"></asp:Label>
                </span></span>
            </p>
            <asp:Button ID="BTN_GEN_XML_TBN1" runat="server" Height="45px" Text="สร้าง xml ทบ1" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_TBN2" runat="server" Height="45px" Text="สร้าง xml ทบ2(สั้น)" Width="170px" />
            <asp:Button ID="BTN_GEN_XML_TBN2_L" runat="server" Height="45px" Text="สร้าง xml ทบ2(ยาว)" Width="170px" />
            <br />
            <hr />

            <br />
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">เจน XML สมพ3</h3>
            <p>
                <asp:TextBox ID="SMP3_IDEN_TXT" runat="server"></asp:TextBox>
                &nbsp;&nbsp; <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">เลขบัตรคนกด&nbsp; <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none">
                    <br />
                    <br />
                    <asp:TextBox ID="SMP3_TR_ID" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                <asp:Label ID="Label_smp1" runat="server" Text="เลขดำเนินการ(TR_ID)"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="SMP3_REMARK_TXT" runat="server" Height="50px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                    &nbsp;&nbsp;
                    <br />
                    <br />
                    <asp:Label ID="SMP3_Label2" runat="server" Text="รายละเอียด"></asp:Label>

                </span></span>
            </p>
            <asp:Button ID="BTN_GEN_XMLSMP3" runat="server" Height="45px" Text="สร้าง xml สมพ 3" Width="170px" />
            <br />
            <hr />
            <p>
                &nbsp;
            </p>
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">ย้ำสถานะจ่ายเงิน(ระบบใหม่)</h3>

            <asp:TextBox ID="SWPM_IDEN" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">เลขบัตรคนกด&nbsp;
            <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none">
                <br />

                <br />
                <asp:TextBox ID="SWPM_IDA" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label10" runat="server" Text="เลข IDA"></asp:Label>
                <br />


                <br />
                <asp:TextBox ID="SWPM_PROCESS" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label11" runat="server" Text="เลข PROCESS"></asp:Label>
                <br />

                <br />
                <asp:TextBox ID="SWPM_REF01" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label12" runat="server" Text="เลข REF01"></asp:Label>
                <br />

                <br />
                <asp:TextBox ID="SWPM_REF02" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label13" runat="server" Text="เลข REF02"></asp:Label>
                <br />

                <br />
                <asp:TextBox ID="SWPM_DETAIL" runat="server" Height="50px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:Label ID="Label14" runat="server" Text="รายละเอียด"></asp:Label>
                <br />

            </span></span>
            <asp:Button ID="BTN_SWPM_CF" runat="server" Text="ยืนยัน" Height="45px" Width="170px" />
            <br />
            <hr />

            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">ดึงเลข IDA ด้วย TR_ID</h3>
            <br />
            <asp:TextBox ID="S_Process" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label27" runat="server" Text="เลข PROCESS"></asp:Label>
            <br />

            <br />
            <asp:TextBox ID="S_TR_ID" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label28" runat="server" Text="เลขดำเนินการ"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btn_search_tr_id" runat="server" Text="ยืนยัน" Height="45px" Width="170px" />
            <br />
            <br />
                <asp:Label ID="Label244" runat="server" Text="เลข IDA:"></asp:Label>
            <asp:Label ID="lbl_IDA" runat="server" Text="เลข IDA" Visible="false"></asp:Label>
            <br />
                <asp:Label ID="Label29" runat="server" Text="เลขนิติ:"></asp:Label>
            <asp:Label ID="lbl_IDEN" runat="server" Text="เลข " Visible="false"></asp:Label>
            <br />

            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">เพิ่มใบสั่งชำระ(ม44)</h3>

            <asp:TextBox ID="l44_IDA" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label24" runat="server" Text="เลข IDA"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="l44_PROCESS" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label25" runat="server" Text="เลข PROCESS"></asp:Label>
            <br />

            <br />
            <asp:TextBox ID="l44_IDENTIFY" runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Label ID="Label26" runat="server" Text="เลขนิติ"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btn_Insert_Payment" runat="server" Text="ยืนยัน" Height="45px" Width="170px" />
            <br />
            <hr />

            <p>
                &nbsp;
            </p>
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">ดึง Q ไป G (ทะเบียนใใหม่)</h3>
            <br />
            <p>
                <asp:TextBox ID="Txt_IDA_QT" runat="server"></asp:TextBox>
                <asp:Button ID="BTN_Q_To_G" runat="server" Text="ดึง RQ ไป RG" />
            </p>

            <br />
            <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">ดึง JJ ไป 124</h3>
            <p>
                <asp:TextBox ID="txt_IDA_JJ_To_124" runat="server"></asp:TextBox>
                <asp:Button ID="BTN_JJ_TO_124" runat="server" Text="ดึง JJ ไป 124" />
            </p>
        </div>
        <br />
        <hr />

        <br />
        <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">เจน XML ทะเบียน(124)</h3>
        <p>
            <asp:TextBox ID="IDEN_TXT" runat="server"></asp:TextBox>
            &nbsp;&nbsp; <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">เลขบัตรคนกด&nbsp; <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none">
                <br />
                <asp:TextBox ID="PVN_CD" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label15" runat="server" Text="รหัสจังหวัด PVN"></asp:Label>
                <br />
                <asp:TextBox ID="DRGTP_CD" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label16" runat="server" Text="เลข DRGTP"></asp:Label>
                <br />
                <asp:TextBox ID="RGTTP_CD" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label17" runat="server" Text="เลข RGTTP"></asp:Label>
                <br />
                <asp:TextBox ID="RGT_NO" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label18" runat="server" Text="เลข RGTNO"></asp:Label>
                <br />
                <asp:TextBox ID="REMARK_TXT" runat="server" Height="50px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label19" runat="server" Text="รายละเอียด"></asp:Label>
            </span></span>
        </p>
        <asp:Button ID="BTN_GEN_XML124" runat="server" Height="45px" Text="สร้าง xml(124)" Width="170px" />
        <br />
        <hr />

        <br />
        <h3 class="auto-style1" style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; text-align: start; text-indent: 0px; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">สร้างไฟล์แนบ ระบบจดแจ้ง</h3>
        <p>

            <asp:Label ID="Label23" runat="server" Text="เลขบัตรคนกด" Width="120px"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="IDEN_JJ" runat="server"></asp:TextBox>
            <br />
            <%-- <asp:Label ID="Label20" runat="server" Text="รหัสดำเนินการ" Width="120px"></asp:Label>
            &nbsp;&nbsp;
             <asp:TextBox ID="TR_ID_JJ" runat="server"></asp:TextBox>
            <br />--%>
            <asp:Label ID="Label21" runat="server" Text="เลข IDA" Width="120px"></asp:Label>
            &nbsp;&nbsp;             
                        <asp:TextBox ID="IDA_JJ" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label22" runat="server" Text="เลข Process" Width="120px"></asp:Label>
            &nbsp;&nbsp;
                    <asp:TextBox ID="PROCESS_JJ" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label20" runat="server" Text="รายละเอียด" Width="120px"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="REMARK_JJ" runat="server" Height="50px" TextMode="MultiLine" Width="173px"></asp:TextBox>
        </p>
        <asp:Button ID="BTN_CREATE_FILE_JJ" runat="server" Height="45px" Text="สร้างไฟล์แนบ" Width="170px" />
        <asp:Button ID="BTN_CREATE_FILE_JJ_ALL" runat="server" Height="45px" Text="สร้างไฟล์แนบทั้งหมด" Width="170px" />
    </form>
</body>
</html>

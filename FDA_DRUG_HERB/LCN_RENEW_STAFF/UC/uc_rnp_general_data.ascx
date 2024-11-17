<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="uc_rnp_general_data.ascx.vb" Inherits="FDA_DRUG_HERB.uc_rnp_general_data" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/LCN_RENEW/UC_RENEW/UC_LCN_DRUG_GROUP.ascx" TagPrefix="uc1" TagName="UC_LCN_DRUG_GROUP" %>
<link href="../css/css_rg_herb.css" rel="stylesheet" />
<link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
<link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
<script src="../Jsdate/ui.datepicker-th.js"></script>
<script src="../Jsdate/ui.datepicker.js"></script>
<script src="../Jsdate/jsdatemain_mol3.js"></script>
<script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
<link href="../../css/style.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        showdate($("#ContentPlaceHolder1_txt_Write_Date"));
        $("#ContentPlaceHolder1_UC_txt_Write_Date").searchable();

    });

    function spin_space() { // คำสั่งสั่งปิด PopUp
        $('#spinner').toggle('slow');
    }

    function closespinner() {
        $('#spinner').fadeOut('slow');
        alert('Download Success');
        $('#ContentPlaceHolder1_Button1').click();
    }

    window.document.onkeydown = function (e) {
        if (!e) {
            e = event;
        }
        if (e.keyCode == 27) {
            lightbox_close();
        }
    }

    function lightbox_open() {
        var lightBoxVideo = document.getElementById("VisaChipCardVideo");
        window.scrollTo(0, 0);
        document.getElementById('light').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
        lightBoxVideo.play();
    }

    function lightbox_close() {
        var lightBoxVideo = document.getElementById("VisaChipCardVideo");
        document.getElementById('light').style.display = 'none';
        document.getElementById('fade').style.display = 'none';
        lightBoxVideo.pause();
    }
    function myFunction() {
        let text = "สถานที่ผลิต หรือนําเข้า หรือขาย (แล้วแต่กรณี) และสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร ตามที่ยื่นขอต่ออายุใบอนุญาตนี้ มีลักษณะเป็นไปตามประกาศกระทรวงสาธารณสุข เรื่อง หลักเกณฑ์ วิธีการ และเงื่อนไขเกี่ยวกับการผลิตผลิตภัณฑ์สมุนไพร ตามพระราชบัญญัติผลิตภัณฑ์สมุนไพร พ.ศ. ๒๕๖๒ หรือไม่";

        if (confirm(text) == true) {
            text = "You pressed OK!";
        } else {
            text = "You canceled!";
        }
        document.getElementById("demo").innerHTML = text;
    }
</script>
<style>
    div2 {
        /* background-color: yellow;*/
        padding: 60px;
        display: none;
    }

    span:hover + div2 {
        display: block;
    }

    .fa {
        padding: 20px;
        font-size: 30px;
        width: 50px;
        text-align: center;
        text-decoration: none;
        margin: 5px 2px;
    }

        .fa:hover {
            opacity: 0.7;
        }

    .auto-style1 {
        margin-left: 0;
    }
</style>
<div class="row">
    <div class="col-lg-12" style="text-align: center;">
        <h1>ระบบตรวจสอบข้อมูล และเตรียมการต่ออายุ ใบอนุญาตสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h1>
    </div>
</div>
<div style="padding-top: 30px"></div>
<div class="row" runat="server" id="incorrect_id" visible="false">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <fieldset>
            <legend>รายการที่ข้อมูลไม่ถูกต้อง</legend>
            <div>
                <asp:CheckBox ID="CheckBox_lcn" runat="server" Text="&ensp;ข้อมูลทั่วไป" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBox_Bsn" runat="server" Text="&ensp;ข้อมูลผู้ดำเนินกิจการ" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBox_Phr" runat="server" Text="&ensp;ข้อมูลผู้มีหน้าที่ปฏิบัติการ" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBox_Location" runat="server" Text="&ensp;ข้อมูลสถานที่ผลิต นาเข้า หรือขายผลิตภัณฑ์สมุนไพร" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBox_Keep" runat="server" Text="&ensp;ข้อมูลสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร" />
            </div>
            <div>
                <asp:CheckBox ID="CheckBox_Drug_Group" runat="server" Text="&ensp;รายการผลิตภัณฑ์สมุนไพรที่ได้รับอนุญาต (รูปแบบผลิตภัณฑ์สมุนไพร)" ViewStateMode="Enabled" />
            </div>
            <div>
                <strong>
                    <p style="color: red">รายละเอียดการแก้ไข</p>
                </strong>
                <asp:TextBox ID="txt_note_edit" TextMode="MultiLine" runat="server" Height="100px" Width="700px" ReadOnly="true"></asp:TextBox>
            </div>
        </fieldset>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <h3>ข้อมูลทั่วไป</h3>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ข้าพเจ้า</div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_Rename_Name" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        (ชื่อผู้รับอนุญาต)
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ซึ่งมีผู้ดำเนินกิจการชื่อ</div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_phr_name" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        (เฉพาะกรณีนิติบุคคล)
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ณ สถานประกอบธุรกิจชื่อ</div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TxT_Business_Name" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ตามใบอนุญาตเลขที่</div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="TxT_LCN_NUM" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <%--        <div class="col-lg-1">ณ สถานประกอบธุรกิจชื่อ</div>
        <div class="col-lg-5" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="TxT_Business_Name" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
        </div>--%>
</div>



<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">อยู่เลขที่</div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_addr" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        หมู่บ้าน/อาคาร
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_Building" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
</div>


<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">หมู่ที่</div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_mu" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">ตรอก/ซอย </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_Soi" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1" style="padding-left: 5em">
        ถนน 
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_road" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ตำบล/แขวง</div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_tambol" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        อำเภอ/แขวง
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_ampher" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">จังหวัด</div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_changwat" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        รหัสไปรณษณีย์
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_zipcode" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1" style="padding-left: 5em">
        โทรสาร
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_fax" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">โทรศัพท์</div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_tel" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        เวลาทำการ
    </div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_Opentime" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <h3>ข้อมูลผู้ดำเนินกิจการ</h3>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <telerik:RadGrid ID="rg_bsn" runat="server" Width="100%">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                        HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="BSN_IDENTIFY" FilterControlAltText="Filter BSN_IDENTIFY column"
                        HeaderText="เลขบัตรปชช." SortExpression="BSN_IDENTIFY" UniqueName="BSN_IDENTIFY">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="BSN_THAIFULLNAME" FilterControlAltText="Filter BSN_THAIFULLNAME column"
                        HeaderText="ชื่อผู้ดำเนินนกิจการ" SortExpression="BSN_THAIFULLNAME" UniqueName="BSN_THAIFULLNAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column"
                        HeaderText="ที่อยู่" SortExpression="fulladdr" UniqueName="fulladdr">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="BSN_TEL" FilterControlAltText="Filter BSN_TEL column"
                        HeaderText="โทรศัพท์" SortExpression="BSN_TEL" UniqueName="BSN_TEL">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <h3>ข้อมูลผู้มีหน้าที่ปฏิบัติการ</h3>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <telerik:RadGrid ID="rgphr" runat="server">
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
                    <telerik:GridBoundColumn DataField="PHR_TEXT_NUM" FilterControlAltText="Filter PHR_TEXT_NUM column"
                        HeaderText="เลขที่ใบอนุญาตประกอบวิชาชีพ/โรคศิลปะ" SortExpression="PHR_TEXT_NUM" UniqueName="PHR_TEXT_NUM">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NAME_SIMINAR" FilterControlAltText="Filter NAME_SIMINAR column"
                        HeaderText="หลักสูตรที่ผ่านการอบรม" SortExpression="NAME_SIMINAR" UniqueName="NAME_SIMINAR">
                    </telerik:GridBoundColumn>
                    <%--            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sel"
                                   CommandName="sel" Text="ดูข้อมูล">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                    <%-- <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                   CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ปฏิบัติการหรือไม่">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <h3>ข้อมูลสถานประกอบธุรกิจ</h3>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <telerik:RadGrid ID="rglocation" runat="server">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                <Columns>
                    <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                        SortExpression="IDA" UniqueName="IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                        HeaderText="ชื่อสถานที่ประกอบธุรกิจ" SortExpression="thanameplace" UniqueName="thanameplace">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่ตั้ง" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridButtonColumn ButtonType="LinkButt8on" UniqueName="_sel" HeaderText=""  Display="false"
                           CommandName="_sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>--%>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    <div class="col-lg-1"></div>
</div>
<div id="dv_lckeep" runat="server">
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3>ข้อมูลสถานที่เก็บรักษาผลิตภัณฑ์สมุนไพร</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <telerik:RadGrid ID="rgkeep" runat="server">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                            HeaderText="ชื่อสถานที่เก็บรักษา" SortExpression="thanameplace" UniqueName="thanameplace">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่ตั้งสถานที่เก็บรักษา" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
        <div class="col-lg-1"></div>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <h4 style="color: red">เงื่อนไขเพิ่มเติม</h4>
        <div>
            <asp:RadioButtonList ID="rdl_enterprise" runat="server">
                <asp:ListItem Value="1">&ensp;1.จดทะเบียนวิสาหกิจชุมชน</asp:ListItem>
                <asp:ListItem Value="2">&ensp;2.จดทะเบียนวิสาหกิจขนาดย่อม (รายย่อย) [small (micro) enterprise]</asp:ListItem>
                <asp:ListItem Value="3">&ensp;3.จดทะเบียนวิสาหกิจขนาดย่อม [small enterprise]</asp:ListItem>
                <asp:ListItem Value="4">&ensp;4.จดทะเบียนวิสาหกิจขนาดกลาง  [medium enterprise]</asp:ListItem>
                <asp:ListItem Value="5">&ensp;5.ไม่ได้จดทะเบียนเป็นวิสาหกิจ</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <strong>
                <p>ได้รับกาารรับรองมาตรฐานสถานที่ผลิตภัณฑ์สมุนไพรจากอย. หรือหน่วยงานที่อย.เห็นชอบ</p>
            </strong>
        </div>
        <div class="row">
            <div class="col-lg-3">
                <asp:RadioButtonList ID="rdl_CerSD" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="1">&ensp;1.ได้รับการรับรอง</asp:ListItem>
                    <asp:ListItem Value="2">&ensp;2.ยังไม่ได้รับการรับรอง</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-lg-9">
                <div id="chk_rad1" runat="server">
                    <asp:RadioButtonList ID="rdl_cer" runat="server">
                        <asp:ListItem Value="1">&ensp;PIC/S GMP</asp:ListItem>
                        <asp:ListItem Value="2">&ensp;ASEAN GMP</asp:ListItem>
                        <asp:ListItem Value="3">&ensp;เกียรติบัตรระดับเหรียญทอง</asp:ListItem>
                        <asp:ListItem Value="4">&ensp;เกียรติบัตรระดับเหรียญเงิน</asp:ListItem>
                        <asp:ListItem Value="5">&ensp;เกียรติบัตรระดับเหรียญทองแดง</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <uc1:UC_LCN_DRUG_GROUP runat="server" ID="UC_LCN_DRUG_GROUP" />
    </div>
</div>


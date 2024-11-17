<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POP_UP_LCN_RENEW_ADD.aspx.vb" Inherits="FDA_DRUG_HERB.POP_UP_LCN_RENEW_ADD" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UC/UC_ATTACH.ascx" TagName="UC_ATTACH" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        //$(document).ready(function () {
        //    showdate($("ContentPlaceHolder1_UC_PHR_DETAIL_phr_date_num"));
        //    $("ContentPlaceHolder1_UC_PHR_DETAIL_Siminar_Date").searchable();
        //});

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

        //function validateLatitude(txtBox) {
        //    var value = parseFloat(txtBox.value);
        //    if (isNaN(value) || value < 5.0 || value > 21.0) {
        //        alert("กรุณากรอกค่าระหว่าง 5.0 ถึง 21.0");
        //        txtBox.value = "";
        //        txtBox.focus();
        //    }
        //}

        //function validateLongitude(txtBox) {
        //    var value = parseFloat(txtBox.value);
        //    if (isNaN(value) || value < 97.0 || value > 106.0) {
        //        alert("กรุณากรอกค่าระหว่าง 97.0 ถึง 106.0");
        //        txtBox.value = "";
        //        txtBox.focus();
        //    }
        //}
        //var modal = document.getElementById("myModal");
        //var btn = document.getElementById("btn_save");
        //var span = document.getElementsByClassName("close")[0];
        //btn.onclick = function () {
        //    modal.style.display = "block";
        //}
        //span.onclick = function () {
        //    modal.style.display = "none";
        //}
        //window.onclick = function (event) {
        //    if (event.target == modal) {
        //        modal.style.display = "none";
        //    }
        //}


<%--        function showCustomDialog() {
            $('#customDialog').modal('show');
        }

        function handleSelection() {
            var isChecked = document.getElementById("<%= checkboxOption.ClientID %>").checked;
            var isChecked2 = document.getElementById("<%= checkboxOption2.ClientID %>").checked;

            if (isChecked) {
                // Checkbox is checked, perform your action
                parent.close_modal();
                alert("ตัวเลือกถูกเลือก");
            } else if (isChecked2) {
                parent.close_modal();
                // Checkbox is not checked, handle as needed
               
            } else {
                alert("ตัวเลือกไม่ถูกเลือก");
            }

            $('#customDialog').modal('hide');
        }--%>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12" style="text-align: center;">
            <h1>คำขอต่ออายุใบอนุญาต</h1>
        </div>
    </div>
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
            <asp:TextBox ID="txt_Write_Date" runat="server" Style="width: 80%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div style="padding-top: 30px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ข้าพเจ้า</div>
        <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_Rename_Name" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            &ensp;  
        </div>
        <div class="col-lg-2">
            <p>(ชื่อผู้รับอนุญาต)</p>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ซึ่งมีผู้ดำเนินกิจการชื่อ</div>
        <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_phr_name" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <p>(เฉพาะกรณีนิติบุคคล)</p>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ตามใบอนุญาตเลขที่</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="TxT_LCN_NUM" runat="server" ReadOnly="true" BorderStyle="None"></asp:TextBox>
        </div>
        <div class="col-lg-1">ณ สถานประกอบธุรกิจชื่อ</div>
        <div class="col-lg-3" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="TxT_Business_Name" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
        </div>
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
        <div class="col-lg-1">ชั้น</div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_floor" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            ห้อง
        </div>
        <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_room" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"></asp:TextBox>
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
        <div class="col-lg-1">พิกัด ละติจูด(latitude)</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_latitude" runat="server" Width="100%" AutoPostBack="true"></asp:TextBox>
            <small style="color: red">ตั้งแต่ 5.0-21.0</small>
        </div>
        <div class="col-lg-1">
            ลองจิจูด(longitude)
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_longitude" runat="server" Width="100%" AutoPostBack="true"></asp:TextBox>
            <small style="color: red">ตั้งแต่ 97.0-106.0</small>
        </div>
        <%--    <div class="col-lg-2">
            <label>แผนที่ตั้งและสถานที่ประกอบการ:</label>
        </div>
        <div class="col-lg-5" style="text-align: center">
            <uc1:UC_ATTACH ID="UC_ATTACH1" runat="server" />
        </div>--%>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div id="light">
                <a class="boxclose" id="boxclose" onclick="lightbox_close();"></a>
                <video id="VisaChipCardVideo" width="1000" controls>
                    <source src="https://meshlog.fda.moph.go.th/FDA_DRUG_HERB_DEMO/Video/SEARCH_EX1080.mp4" controls="controls" type="video/mp4">
                </video>
            </div>
            <div id="fade" onclick="lightbox_close();"></div>

            <div <%--style="padding-left: 0.5em"--%>>
                <p>ตัวอย่างการหาละติจูด/ลองจิจูต<a href="#" onclick="lightbox_open();" style="color: #0033CC;"> คลิ๊ก</a></p>
            </div>
        </div>
    </div>
    <panel id="panel_phr" runat="server" style="display: none;">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <p>ต้องการยื่นเอกสารผู้มีหน้าที่ปฏิบัติการแบบ</p>
                <s></s>
                <asp:RadioButton ID="RDO_PHR_YES" runat="server" GroupName="OptionsModal" Text="ยื่นแบบออนไลน์" AutoPostBack="true" Enabled="false" />
                <asp:RadioButton ID="RDO_PHR_NO" runat="server" GroupName="OptionsModal" Text="ยืนแบบเอกสาร" AutoPostBack="true" Checked="true" />
            </div>
        </div>

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <h4>ผู้มีหน้าที่ปฏิบัติการ</h4>
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
                            <telerik:GridBoundColumn DataField="functnm" FilterControlAltText="Filter functnm column"
                                HeaderText="หน้าที่" SortExpression="functnm" UniqueName="functnm">
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sel"
                                CommandName="sel" Text="ดูข้อมูล">
                                <HeaderStyle Width="70px" />
                            </telerik:GridButtonColumn>--%>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:HyperLink ID="PV_SELECT" runat="server">ดูเอกสาร</asp:HyperLink>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <%-- <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                   CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ปฏิบัติการหรือไม่">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
    </panel>
    <%--<div class="row">
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
                     <div id="chk_rad1" runat="server" style="display:none">
                        <asp:RadioButtonList ID="rdl_cer" runat="server" Visible="true">
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
    </div>--%>
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
                    <div id="chk_rad1" runat="server" style="display: none">
                        <asp:RadioButtonList ID="rdl_cer" runat="server" Visible="true">
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
            <h4 style="color: red">ชื่อผู้ติดต่อฉุกเฉิน</h4>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">คำนำหน้า</div>
        <div class="col-lg-2">
            <asp:DropDownList ID="ddl_emc_prefix" runat="server" DataTextField="thanm" DataValueField="prefixcd" Width="100%"></asp:DropDownList>
        </div>
        <%--      <div class="col-lg-1">ชื่อ</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_emc_name" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            นามสกุล
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_emc_lname" runat="server" Width="100%"></asp:TextBox>
        </div>--%>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">ชื่อ</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_emc_name" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            นามสกุล
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_emc_lname" runat="server" Width="100%"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">โทรศัพท์</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_emc_tel" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            E-mail
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_emc_email" runat="server" Width="100%"></asp:TextBox>
        </div>
    </div>
    <%--    <asp:Button ID="btnConfirm" runat="server" Text="ยืนยัน" OnClientClick="showCustomDialog(); return false;" />--%>

    <div style="padding-top: 6em"></div>
    <footer>
        <div class="row" id="E1" runat="server">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" Height="40px" Width="135px" OnClientClick="return confirm('คุณต้องการออกจากหน้านี้หรือไม่');" />&ensp;
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="40px" Width="135px" />
            </div>
        </div>
    </footer>

</asp:Content>

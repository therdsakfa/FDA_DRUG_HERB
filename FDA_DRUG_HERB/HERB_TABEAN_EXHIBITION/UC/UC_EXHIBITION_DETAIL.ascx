<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_EXHIBITION_DETAIL.ascx.vb" Inherits="FDA_DRUG_HERB.UC_EXHIBITION_DETAIL" %>
<link href="../../css/style.css" rel="stylesheet" />
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/HERB_TABEAN_EXHIBITION/UC/UC_EXH_DETAIL_CAS.ascx" TagPrefix="uc1" TagName="UC_EXH_DETAIL_CAS" %>

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
<script type="text/javascript">
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
</script>

<div>
    <div class="row">
        <div class="col-md-12" style="text-align: center;">
            <h2>แบบแจ้งการผลิตหรือนำเข้าผลิตภัณฑ์สมุนไพรเพื่อการแสดงนิทรรศการ</h2>
        </div>
    </div>
    <br />
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
            <telerik:RadDatePicker ID="RDP_Write_Date" runat="server" Width="100%"></telerik:RadDatePicker>
            <%--    <asp:TextBox ID="txt_Write_Date" runat="server" Width="87%"></asp:TextBox>--%>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div style="padding-top: 15px"></div>


    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            ข้าพเจ้า
        </div>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_NAME" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="text-align: left">(ชื่อผู้ผลิตหรือผู้นำเข้า)</div>
        <div class="col-lg-1" style="text-align: center">ตำแหน่ง</div>
        <div class="col-lg-3">
            <asp:TextBox ID="txt_position" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-1">
            ในนามของ
        </div>
        <div class="col-lg-9">
            <asp:RadioButtonList ID="rdl_behalf_in" runat="server" AutoPostBack="true">
                <asp:ListItem Value="1">&nbsp;กระทรวง ทบวง กรม หน่วยงานอื่นของรัฐ ที่มีภารกิจด้านการป้องกันหรือบำบัดโรค</asp:ListItem>
                <asp:ListItem Value="2">&nbsp;สถาบันอุดมศึกษาของรัฐเพื่อการศึกษาด้านเภสัชศาสตร์ ด้านการแพทย์แผนไทยหรือแผนไทยประยุกต์</asp:ListItem>
                <asp:ListItem Value="3">&nbsp;สภากาชาดไทย</asp:ListItem>
                <asp:ListItem Value="4">&nbsp;สมาคม</asp:ListItem>
                <asp:ListItem Value="5">&nbsp;มูลนิธิ</asp:ListItem>
                <asp:ListItem Value="6">&nbsp;ผู้แทนทางการค้าของประเทศ</asp:ListItem>
                <asp:ListItem Value="7">&nbsp;ผู้รับอนุญาตผลิต</asp:ListItem>
                <asp:ListItem Value="8">&nbsp;ผู้รับอนุญาตนำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row" id="div_behalf_in_other" runat="server" visible="false">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            <asp:Label ID="lbl_behalf_in" runat="server" Text="ขื่อมูลนิธิ/ผู้แทนทางการค้าของประเทศ/สมาคม"></asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_other" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            ณ สถานที่ชื่อ
        </div>
        <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_lcn_name" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-1">
            ใบอนุญาตเลขที่
        </div>
        <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
            <asp:TextBox ID="txt_lcnno_new" runat="server" BorderStyle="None" ReadOnly="true" Width="100%"></asp:TextBox>
        </div>
        <div id="Panel_lcnno" runat="server" visible="false"></div>
        <div class="col-lg-1">ค้นหาจากเลขใบอนุญาต</div>
        <div class="col-lg-2">
            <asp:TextBox ID="txt_lcnno_SEACH" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-1">
            <asp:Button ID="BTN_SEARCH_LCNNO" runat="server" Text="ค้นหา" CssClass="btn-sm" />
        </div>
    </div>
</div>
<div id="Panel_lcnno_search" runat="server" visible="false">
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            รายการใบอนุญาตที่ค้นหา
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
                <MasterTableView AutoGenerateColumns="False">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LCNNO_DISPLAY_NEW" FilterControlAltText="Filter LCNNO_DISPLAY_NEW column"
                            HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_DISPLAY_NEW" UniqueName="LCNNO_DISPLAY_NEW">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column"
                            HeaderText="ประเภท" SortExpression="lcntpcd" UniqueName="lcntpcd">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thanm_addr" FilterControlAltText="Filter thanm_addr column"
                            HeaderText="ที่อยู่" SortExpression="thanm_addr" UniqueName="thanm_addr">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="lcnsid" FilterControlAltText="Filter lcnsid column"
                            HeaderText="รหัสผู้ประกอบการ" SortExpression="lcnsid" UniqueName="lcnsid">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HOUSENO" FilterControlAltText="Filter HOUSENO column"
                            HeaderText="เลขสถานที่" SortExpression="HOUSENO" UniqueName="HOUSENO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                            HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                            CommandName="sel" Text="เลือก">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                        <%--          <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_edit"
                                CommandName="_edit" Text="แก้ไขการเสนอลงนาม">
                                <HeaderStyle Width="70px" />
                            </telerik:GridButtonColumn>--%>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>

</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        รหัสประจำบ้าน
    </div>
    <div class="col-lg-2">
        <asp:TextBox ID="txt_house_no" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1">
        <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-sm" />
    </div>
</div>


<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        อยู่เลขที่
    </div>
    <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_addr" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1" style="padding-left: 2em">ตรอก/ซอย</div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_soi" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1" <%--style="padding-left: 2em"--%>>ถนน</div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_road" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
</div>


<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        หมู่ที่
    </div>
    <div class="col-lg-1" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_mu" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1" style="padding-left: 2em">ตำบล/แขวง</div>
    <div class="col-lg-2" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_tambol" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1" <%--style="padding-left: 2em"--%>>อำเภอ/เขต</div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_ampher" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        จังหวัด
    </div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_changwhat" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="col-lg-1" <%--style="padding-left: 2em"--%>>รหัสไปรษณีย์</div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_zipcode" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
</div>

<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-1">
        โทรศัพท์
    </div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_tel" runat="server" Width="100%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
    </div>
</div>

<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-1">
        ละติจูด 
    </div>
    <div class="col-lg-4">
        <asp:TextBox ID="txt_longtitute" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1" <%--style="padding-left: 2em"--%>>
        ลองจิจูด
    </div>
    <div class="col-lg-4">
        <asp:TextBox ID="txt_latituie" runat="server" Width="100%"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <%--<span style="color: red">*ตัวอย่างการหาละติจูด/ลองจิจูต</span>
            <div2 style="text-align: left">
                <%--    <img src="ex_search.gif" class="w3-border w3-padding" alt="Alps">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ex_search.gif" Width="40%" />
            </div2>--%>
        <%--         <p style="color: red">*ตัวอย่างการหาละติจูด/ลองจิจูต</p>--%>
        <div id="light">
            <a class="boxclose" id="boxclose" onclick="lightbox_close();"></a>
            <video id="VisaChipCardVideo" width="1000" controls>
                <source src="https://meshlog.fda.moph.go.th/FDA_DRUG_HERB_DEMO/Video/SEARCH_EX1080.mp4" controls="controls" type="video/mp4">
                <%--<source src="../../Video/SEARCH_EX720.mp4" controls="controls" type="video/mp4">--%>
                <!--Browser does not support <video> tag -->
            </video>
        </div>
        <div id="fade" onclick="lightbox_close();"></div>

        <div style="padding-left: 0.5em">
            <p>*ตัวอย่างการหาละติจูด/ลองจิจูต<a href="#" onclick="lightbox_open();" style="color: #0033CC;"> คลิ๊ก</a></p>
        </div>
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        มีความประสงค์จะแจ้ง
    </div>
    <div class="col-lg-3" style="text-align: center">
        <asp:RadioButtonList ID="rdl_process_exh" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="1">&nbsp;ผลิต&nbsp;&nbsp;</asp:ListItem>
            <asp:ListItem Value="2">&nbsp;นำเข้า</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div class="col-lg-1"></div>
    <div class="col-lg-1">
        ผลิตภัณฑ์สมุนไพรชื่อ
    </div>
    <div class="col-lg-4">
        <asp:TextBox ID="txt_drug_name" runat="server" Width="100%"></asp:TextBox>
    </div>

</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">จำนวน</div>
    <div class="col-lg-4" style="border-bottom: #999999 1px dotted;">
        <asp:TextBox ID="txt_num" runat="server" Width="100%" ReadOnly="true" BorderStyle="None"></asp:TextBox>
    </div>
    <%-- <div class="col-lg-1"></div>--%>
    <div class="col-lg-1">เพื่อการจัดนิทรรศการชื่อ</div>
    <div class="col-lg-4">
        <asp:TextBox ID="txt_exhibition" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-1">ระหว่างวันที่</div>
    <div class="col-lg-2">
        <telerik:RadDatePicker ID="RDP_date_Start" runat="server" Width="100%"></telerik:RadDatePicker>
        <%--<asp:TextBox ID="txt_" runat="server" Width="80%"></asp:TextBox>--%>
    </div>
    <div class="col-lg-2"></div>
    <div class="col-lg-1">ถึงวันที่</div>
    <div class="col-lg-2">
        <telerik:RadDatePicker ID="RDP_date_End" runat="server" Width="100%"></telerik:RadDatePicker>
        <%--<asp:TextBox ID="txt_date_End" runat="server" Width="80%"></asp:TextBox>--%>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <%--     <div class="col-lg-1">ระหว่างวันที่</div>
        <div class="col-lg-1" >
            <asp:TextBox ID="txt_date_exh" runat="server" Width="100%"></asp:TextBox>
        </div>--%>
    <div class="col-lg-1">ณ สถานที่</div>
    <div class="col-lg-9">
        <asp:TextBox ID="txt_lo_exh" TextMode="MultiLine" runat="server" Width="100%"></asp:TextBox>
    </div>
    <div class="col-lg-1"></div>
</div>

<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10">
        <p>
            และขอรับรองว่าจะไม่นำผลิตภัณฑ์สมุนไพรทั้งหมดหรือแต่บางส่วนออกขายโดยเด็ดขาด พร้อมกับจะส่ง
หนังสือแสดงการนำเข้าหรือส่งกลับคืนหรือทำลายให้ สำนักงานคณะกรรมการอาหารและยาทราบ แล้วแต่กรณี
ทั้งนี้ภายใน ๑ เดือน นับแต่วันแสดงนิทรรศการสิ้นสุดลง
        </p>
        <%--และขอรับรองว่าจะไม่นาผลิตภัณฑ์สมุนไพรทั้งหมดหรือแต่บางส่วนออกขายโดยเด็ดขาด พร้อมกับจะส่ง --%>
    </div>
</div>
<%--  <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10">
           หนังสือแสดงการนาหรือส่งกลับคืนหรือทาลายให้ สานักงานคณะกรรมการอาหารและยาทราบ แล้วแต่กรณี
        </div>
    </div>
    <div class="row">
        <div class="col-lg-1">
        </div>
        <div class="col-lg-10">
           ทั้งนี้ภายใน ๑ เดือน นับแต่วันแสดงนิทรรศการสิ้นสุดลง
        </div>
    </div>--%>

<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10" style="text-align: center">
        <h4>รายละเอียดของผลิตภัณฑ์สมุนไพรที่ผลิตหรือนำเข้ามาในราชอาณาจักร</h4>
    </div>
</div>

<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10" style="text-align: center">
        ปริมาณของวัตถุส่วนประกอบของผลิตภัณฑ์สมุนไพรต้องแจ้งเป็นมาตราเมตริกหรือเป็นร้อยละใน ๑ หน่วย
    </div>
</div>

<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10">
             -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    </div>
</div>
<div class="row">
    <div class="col-lg-2">
    </div>
    <div class="col-lg-9">
        <uc1:UC_EXH_DETAIL_CAS runat="server" id="UC_EXH_DETAIL_CAS" />
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10">
             -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    </div>
</div>
<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10" style="text-align: center">
        <h4>ขนาดบรรจุ</h4>
    </div>
</div>

<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10" style="text-align: center">
        (รายละเอียดของการบรรจุ)
    </div>
</div>

<div class="row">
    <div class="col-lg-1"></div>
    <div class="col-lg-10">
        <div class="row">
            <div class="col-lg-2">Primary Packaging:</div>
            <div class="col-lg-2">
                <asp:DropDownList ID="DD_PCAK_1" runat="server" DataValueField="PACK_PRIMARY_ID" DataTextField="PACK_PRIMARY_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
            </div>
            <div class="col-lg-2" style="text-align: right">จำนวน:</div>
            <div class="col-lg-2" style="text-align: right">
                <asp:TextBox ID="NO_1" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-2" style="text-align: right">หน่วย:</div>
            <div class="col-lg-2">
                <asp:DropDownList ID="DD_UNIT_1" runat="server" DataValueField="UNIT_PRIMARY_ID" DataTextField="UNIT_PRIMARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">Secondary Packaging:</div>
            <div class="col-lg-2">
                <asp:DropDownList ID="DD_PCAK_2" runat="server" DataValueField="PACK_SEC_ID" DataTextField="PACK_SEC_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
            </div>
            <div class="col-lg-2" style="text-align: right">จำนวน:</div>
            <div class="col-lg-2">
                <asp:TextBox ID="NO_2" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-2" style="text-align: right">หน่วย:</div>
            <div class="col-lg-2">
                <asp:DropDownList ID="DD_UNIT_2" runat="server" DataValueField="UNIT_SECONDARY_ID" DataTextField="UNIT_SECONDARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">Tertiary Packaging:</div>
            <div class="col-lg-2">
                <asp:DropDownList ID="DD_PCAK_3" runat="server" DataValueField="PACK_TER_ID" DataTextField="PACK_TER_NAME" BackColor="White" Height="25px" Width="180px" SkinID="bootstrap"></asp:DropDownList>
            </div>
            <div class="col-lg-2" style="text-align: right">จำนวน:</div>
            <div class="col-lg-2">
                <asp:TextBox ID="NO_3" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-lg-2" style="text-align: right">หน่วย:</div>
            <div class="col-lg-2">
                <asp:DropDownList ID="DD_UNIT_3" runat="server" DataValueField="UNIT_TERTIARY_ID" DataTextField="UNIT_TERTIARY_NAME" BackColor="White" Height="25px" Width="200px" SkinID="bootstrap"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button ID="btn_size_pack" runat="server" Text="เพิ่ม" Height="33px" Width="134px" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <telerik:RadGrid ID="RadGrid4" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
                    PagerStyle-Mode="NextPrevNumericAndAdvanced" Skin="Hay">
                    <MasterTableView DataKeyNames="IDA">
                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA" HeaderText="IDA" DataType="System.Int32" Display="false"
                                FilterControlAltText="Filter IDA column" ReadOnly="True" SortExpression="IDA">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FK_IDA_DQ" UniqueName="FK_IDA_DQ" HeaderText="FK_IDA_DQ" FilterControlAltText="Filter FK_IDA_DQ column"
                                SortExpression="FK_IDA_DQ" Display="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="PACK_F_NAME " UniqueName="PACK_F_NAME" HeaderText="Primary Packaging:" FilterControlAltText="Filter PACK_F_NAME column"
                                SortExpression="PACK_F_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NO_1" UniqueName="NO_1" HeaderText="ขนาด" FilterControlAltText="Filter NO_1 column"
                                SortExpression="NO_1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UNIT_F_NAME " UniqueName="UNIT_F_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_F_NAME column"
                                SortExpression="UNIT_F_NAME">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="PACK_S_NAME " UniqueName="PACK_S_NAME" HeaderText="Secondary Packaging:" FilterControlAltText="Filter PACK_S_NAME column"
                                SortExpression="PACK_S_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NO_2" UniqueName="NO_2" HeaderText="ขนาด" FilterControlAltText="Filter NO_2 column"
                                SortExpression="NO_2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UNIT_S_NAME " UniqueName="UNIT_S_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_S_NAME column"
                                SortExpression="UNIT_S_NAME">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="PACK_T_NAME " UniqueName="PACK_T_NAME" HeaderText="Tertiary Packaging:" FilterControlAltText="Filter PACK_T_NAME column"
                                SortExpression="PACK_T_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NO_3" UniqueName="NO_3" HeaderText="ขนาด" FilterControlAltText="Filter NO_3 column"
                                SortExpression="NO_3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UNIT_T_NAME " UniqueName="UNIT_T_NAME" HeaderText="หน่วย" FilterControlAltText="Filter UNIT_T_NAME column"
                                SortExpression="UNIT_T_NAME">
                            </telerik:GridBoundColumn>

                            <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูลใช่หรือไม่"
                                CommandName="result_delete" UniqueName="result_delete">
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <hr />
    </div>
</div>

<div class="row">
    <div class="col-lg-1">
    </div>
    <div class="col-lg-10" style="text-align: center">
        -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    </div>
</div>

</div>

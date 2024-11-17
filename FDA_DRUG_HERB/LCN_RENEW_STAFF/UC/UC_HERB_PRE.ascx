<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB_PRE.ascx.vb" Inherits="FDA_DRUG_HERB.UC_HERB_PRE" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<style type="text/css">
    .auto-style3 {
        width: 85px;
    }

    .auto-style12 {
        width: 85px;
        height: 30px;
    }

    .auto-style13 {
        height: 30px;
    }

    .auto-style18 {
        width: 228px;
    }

    .auto-style19 {
        width: 235px;
    }

    .auto-style20 {
        width: 351px;
    }
</style>

<div>
    <form name="form" method="post" align="center;">
        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <h1>คำขอรับใบอนุญาต
                </h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <label>
                    ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร                     
                </label>
            </div>

        </div>

        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <label>
                    คำขอใบอนุญาต                    
                </label>
            </div>

        </div>

        <div class="row">
            <div class="col-md-12" style="text-align: left">
                <center>
                    <asp:RadioButtonList ID="rdl_lcn_type" runat="server">
                        <asp:ListItem Value="1">ผลิตผลิตภัณฑ์สมุนไพร</asp:ListItem>
                        <asp:ListItem Value="2">นำเข้าผลิตภัณฑ์สมุนไพร</asp:ListItem>
                        <asp:ListItem Value="3">ขายผลิตภัณฑ์สมุนไพร</asp:ListItem>
                    </asp:RadioButtonList></center>
            </div>

        </div>
        <br />
        <div>
            <center>
                <table>
                    <tr>
                        <td>เลือก &ensp;&ensp;
                        </td>
                        <td>

                            <asp:RadioButtonList ID="rdl_sanchaat" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                <asp:ListItem Value="1">&ensp;ไทย&ensp;</asp:ListItem>
                                <asp:ListItem Value="2">&ensp;ต่างด้าว&ensp;</asp:ListItem>
                            </asp:RadioButtonList>


                            <asp:Label ID="Label60" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาเลือกสัญชาติ</p></asp:Label>


                        </td>
                    </tr>
                </table>
            </center>

        </div>
        <br />
        <br />

        <div>
            <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                 ๑. &ensp;ข้อมูลผู้ขออนุญาต</h4>
            <br />
            <div class="row">
                <div class="col-lg-1">
                </div>
                <div class="col-lg-2" style="text-align: left">
                    ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                </div>
                <div class="col-lg-8">
                    <asp:TextBox ID="lbl_lcn_name" runat="server" Width="100%" TextMode="MultiLine" ReadOnly="true" Height="30px"></asp:TextBox>
                    <%--<asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2"></div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    อายุ 
                </div>
                <div class="col-lg-3" >
                    <asp:TextBox ID="lbl_lcn_ages" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label>--%>
                </div>
                <%--<div class="col-lg-2" >ปี</div>--%>
                <div class="col-lg-2" >สัญชาติ</div>
                <div class="col-lg-3" >
                    <asp:TextBox ID="lbl_lcn_nation" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label>--%>
                </div>
                <%--<div class="col-lg-2"></div>--%>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    เลขประจำตัวประชาชน หรือเลขทะเบียนนิติบุคคล
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_iden" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_iden" runat="server" EnableTheming="True" Width="80%"></asp:Label>--%>
                </div>
                <div class="col-lg-2">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    ที่อยู่เลขที่
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_addr" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%--<asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2" >
                    ชั้นที่
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_floor" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_floor" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    ห้องเลขที่
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_room" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%--<asp:Label ID="lbl_lcn_room" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2" >
                    หมู่บ้าน/อาคาร
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_building" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    หมู่ที่
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_mu" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%--   <asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2" >
                    ตรอก/ซอย
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_soi" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    ถนน
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_road" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    ตำบล/แขวง
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_tambol" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%--<asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2" >
                    อำเภอ/เขต
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_amphor" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    จังหวัด
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_changwat" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%--<asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2" >
                    รหัสไปรษณีย์
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_zipcode" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%--  <asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    โทรสาร
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_fax" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%--<asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2" >
                    โทรศัพท์
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_tel" runat="server"  Width="100%"  ReadOnly="true"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-2">
                    E-mail
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="lbl_lcn_email" runat="server"  Width="100%"></asp:TextBox>
                    <%-- <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="col-lg-2" >
                    เวลาทำการรวมของร้าน
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="txt_da_opentime" runat="server"  Width="100%"></asp:TextBox>
                    <asp:Label ID="Label61" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาระบุเวลาทำการ</p></asp:Label>
                </div>
                <div class="col-lg-2">
                </div>
            </div>
            &ensp;&ensp;
        </div>
        <div>
            <table id="TB_Personal" runat="server" visible="false">
                <tr>
                    <td class="auto-style3"></td>
                    <td colspan="8">
                        <h4>กรณีผู้ขออนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>
                    </td>
                    <td>&ensp;&ensp;
                       สัญชาติ&ensp;<asp:TextBox ID="txt_nationality" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="TB_Personal_Type1" runat="server"  visible="false">
                <table runat="server">
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td>
                            <asp:CheckBox ID="cb_Personal_Type1" Text="บุคคลธรรมดา " runat="server" AutoPostBack="True" /></td>
                        <td>
                            <asp:Label ID="Label62" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณากรอกข้อมูลให้ครบทุกช่อง</p></asp:Label>
                        </td>
                        <td></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td>หนังสือเดินทางเลขที่</td>
                        <td>
                            <asp:TextBox ID="txt_PASSPORT_NO" runat="server"></asp:TextBox>
                        </td>
                        <td>วันหมดอายุ</td>
                        <td>
                            <telerik:RadDatePicker ID="RDP_PASSPORT_EXPDATE" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td>ใบสำคัญที่อยู่เลขที่</td>
                        <td>
                            <asp:TextBox ID="txt_DOC_NO" runat="server"></asp:TextBox>
                        </td>
                        <td>ออกให้ ณ วันที่</td>
                        <td>
                            <telerik:RadDatePicker ID="RDP_DOC_DATE" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td>ใบอนุญาตทำงานเลขที่</td>
                        <td>
                            <asp:TextBox ID="txt_WORK_LICENSE_NO" runat="server"></asp:TextBox>
                        </td>
                        <td>วันหมดอายุ</td>
                        <td>
                            <telerik:RadDatePicker ID="RDP_WORK_LICENSE_EXPDATE" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td colspan="4">หรือใบอนุญาตประกอบธุรกิจตามบัญชีสาม(๑๖)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td>เลขที่</td>
                        <td>
                            <asp:TextBox ID="txt_BS_NO" runat="server"></asp:TextBox>
                        </td>
                        <td>ออกให้ ณ วันที่</td>
                        <td>
                            <telerik:RadDatePicker ID="RDP_BS_DATE" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td colspan="2">หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</td>
                        <td>
                            <asp:TextBox ID="txt_FRGN_NO" runat="server"></asp:TextBox></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td>ออกให้ ณ วันที่</td>
                        <td>
                            <telerik:RadDatePicker ID="RDP_FRGN_DATE" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="TB_Personal_Type2" runat="server"  visible="false">
                <table runat="server">
                    <tr>
                        <td class="auto-style3"></td>
                        <td>
                            <asp:CheckBox ID="cb_Personal_Type2" Text="นิติบุคคลต่างด้าว " runat="server" AutoPostBack="True" /></td>
                        <td>
                            <asp:Label ID="Label63" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณากรอกข้อมูลให้ครบทุกช่อง</p></asp:Label>
                        </td>
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
                        <td>
                            <asp:TextBox ID="txt_BS_NO1" runat="server" Style="margin-bottom: 0px"></asp:TextBox>
                        </td>
                        <td>ออกให้ ณ วันที่</td>
                        <td>
                            <telerik:RadDatePicker ID="RDP_BS_DATE1" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td colspan="2">หนังสือรับรองตาามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</td>
                        <td>
                            <asp:TextBox ID="txt_FRGN_NO1" runat="server"></asp:TextBox></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td>ออกให้ ณ วันที่</td>
                        <td>
                            <telerik:RadDatePicker ID="RDP_FRGN_DATE1" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>

        </div>
        <div>
            <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
               ๒. &ensp;ข้อมูลผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการเกี่ยวกับใบอนุญาต</h4>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-10" style="color: red">*ท่านสามารถกรอกข้อมูลผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินการหรือดำเนินกิจการในส่วนที่2</div>
                <div class="col-lg-6"></div>
            </div>
            <%--    <div id="main_menu2">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">ชื่อผู้ดำเนินการ</div>
                    <div class="col-lg-3" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_THAIFULLNAME" runat="server"  Width="100%"></asp:TextBox>

                    </div>
                    <div class="col-lg-6"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-1">อายุ</div>
                    <div class="col-lg-1" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_AGE" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1" style="text-align: center">ปี</div>
                    <div class="col-lg-1" style="text-align: center"></div>
                    <div class="col-lg-1">สัญชาติ</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="Label20" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">เลขประจำตัวประชาชน</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_IDENTIFY" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">&nbsp;</div>

                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">ที่อยู่ตามทะเบียนบ้าน อยู่เลขที่</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_ADDR" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">ชั้นที่</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_FLOOR" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">ห้องเลขที่</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_ROOM" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">หมู่บ้าน/อาคาร</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_BUILDING" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">หมู่ที่</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_MOO" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">ตรอก/ซอย</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_SOI" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">ถนน</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_ROAD" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">&nbsp;</div>

                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">ตำบล/แขวง</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_THMBL_NAME" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">อำเภอ/เขต</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_AMPHR_NAME" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">จังหวัด</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_thachngwtnm" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">รหัสไปรษณีย์</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_ZIPCODE" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">โทรสาร</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_FAX" runat="server"  Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">โทรศัพท์</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="lbl_BSN_TEL" runat="server"  Width="100%"></asp:TextBox>

                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">E-mail</div>
                    <div class="col-lg-2" style="; text-align: center">
                        <asp:TextBox ID="Label33" runat="server"  Width="100%"></asp:TextBox>

                    </div>
                    <div class="col-lg-6">&nbsp;</div>
                </div>
            </div>
            <table>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style18">&nbsp;ที่อยู่ที่สามารถติดต่อได้ &nbsp;<asp:CheckBox ID="cb_addr" runat="server" AutoPostBack="True" />
                        <label for="vehicle1"></label>
                    </td>
                    <td class="auto-style20">(ใช้ที่อยู่เดียวกันกับที่อยู่ตามทะเบียนบ้าน)</td>
                    <td>&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td colspan="4">(เฉพาะที่อยู่ไม่ใช้ที่อยู่เดียวกันกับทะเบียนบ้าน)</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style18">อยู่เลขที่</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txt_c_thaaddr" runat="server"></asp:TextBox>
                        <asp:Label ID="Label64" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาใส่เลขที่</p></asp:Label>
                    </td>
                    <td>ชั้นที่</td>
                    <td class="auto-style19">
                        <asp:TextBox ID="txt_c_floor" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style18">ห้องเลขที่</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txt_c_room" runat="server"></asp:TextBox>
                    </td>
                    <td>หมู่บ้าน/อาคาร</td>
                    <td class="auto-style19">

                        <asp:TextBox ID="txt_c_thabuilding" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>

                    <td class="auto-style18">หมู่ที่</td>
                    <td class="auto-style20">

                        <asp:TextBox ID="txt_c_thamu" runat="server"></asp:TextBox>
                    </td>
                    <td>ตรอก/ซอย</td>
                    <td class="auto-style19">

                        <asp:TextBox ID="txt_c_thasoi" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>

                    <td class="auto-style18">ถนน</td>
                    <td class="auto-style20">

                        <asp:TextBox ID="txt_c_tharoad" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style18">ตำบล/แขวง</td>
                    <td class="auto-style20">

                        <asp:DropDownList ID="ddl_tambol" runat="server" AutoPostBack="True" DataTextField="thathmblnm" DataValueField="thmblcd">
                        </asp:DropDownList>
                    </td>
                    <td>อำเภอ/เขต</td>
                    <td class="auto-style19">

                        <asp:DropDownList ID="ddl_amphor" runat="server" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style18">จังหวัด</td>
                    <td class="auto-style20">

                        <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
                        <asp:Label ID="Label65" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาเลือกจังหวัด</p></asp:Label>
                    </td>
                    <td>รหัสไปรษณีย์</td>
                    <td class="auto-style19">

                        <asp:TextBox ID="txt_c_zipcode" runat="server"></asp:TextBox>
                        <asp:Label ID="lbl_zipcheck" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาระบุ รหัสไปรษณีย์</p></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style18">โทรสาร</td>
                    <td class="auto-style20">

                        <asp:TextBox ID="txt_c_fax" runat="server"></asp:TextBox>
                    </td>
                    <td>โทรศัพท์</td>
                    <td class="auto-style19">
                        <asp:TextBox ID="txt_c_tel" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:Label ID="lbl_chk_tel" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาระบุเบอร์โทรศัพท์</p></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style18">E-mail</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txt_c_email" runat="server" TextMode="Email"></asp:TextBox>
                       <asp:Label ID="lbl_chk_email" runat="server" Text="" Style="display: none"><p style="color:red">*กรุณาระบุ e-mail</p></asp:Label>
                    </td>
                    <td>&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            </tr>
            </table>

            <div class="row">
                <div classs="col-lg-1"></div>
                <div classs="col-lg-10" style="text-align: center">
                    <asp:Button ID="btn_save_bsn" runat="server" Text="เพิ่มผู้ดำเนินกิจการ" Height="45px" Width="320px" />
                </div>
                <div classs="col-lg-1"></div>
            </div>
            <div class="row">
                <div classs="col-lg-1"></div>
                <div classs="col-lg-10">
                    <telerik:RadGrid ID="rg_bsn" runat="server" Width="90%">
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
                                <telerik:GridBoundColumn DataField="BSN_TEL" FilterControlAltText="Filter BSN_TEL column"
                                    HeaderText="โทรศัพท์" SortExpression="BSN_TEL" UniqueName="BSN_TEL">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                    CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ดำเนินการหรือไม่">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                <div classs="col-lg-1"></div>
            </div>
            --%>
        </div>
        <%--     <div>
            <h4>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;
               กรณีผู้ได้รับมอบหมายหรือแต่งตั้งให้กำหนดกิจการเป็นบุคคลต่างด้าว ระบุ</h4>
            &ensp;
           <table>
               <tr>
                   <td class="auto-style12"></td>
                   <td class="auto-style13">หนังสือเดินทางเลขที่
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">
                       <asp:TextBox ID="txt_GIVE_PASSPORT_NO" runat="server"></asp:TextBox>
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">วันหมดอายุ
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">
                       <telerik:RadDatePicker ID="rdp_GIVE_PASSPORT_EXPDATE" runat="server"></telerik:RadDatePicker>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style12"></td>
                   <td class="auto-style13">ใบอนุญาตทำงานเลขที่
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">
                       <asp:TextBox ID="txt_GIVE_WORK_LICENSE_NO" runat="server"></asp:TextBox>
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">วันหมดอายุ
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">
                       <telerik:RadDatePicker ID="rdp_GIVE_WORK_LICENSE_EXPDATE" runat="server"></telerik:RadDatePicker>
                   </td>
               </tr>
           </table>
            <br />
            &ensp;              
        </div>--%>
        <h4>&ensp;&ensp;&ensp;&ensp;&ensp;๓. &ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h4>
        &ensp;
           <div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2"><b>สถานที่ประกอบธุรกิจชื่อ :</b></div>
                   <div class="col-lg-8">
                       <%--  <asp:Label ID="lbl_lct_thanameplace" runat="server" Text=""></asp:Label>--%>
                       <asp:TextBox ID="lbl_lct_thanameplace" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                   </div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">เลขรหัสประจำบ้าน :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_HOUSENO" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_HOUSENO" runat="server" Text=""></asp:Label>--%>
                   </div>
                   <div class="col-lg-6"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">อยู่เลขที่ :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_thaaddr" runat="server" Width="100%"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_thaaddr" runat="server" Text=""></asp:Label>--%>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">หมู่บ้าน/อาคาร :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_thabuilding" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_thabuilding" runat="server" Text=""></asp:Label>--%>
                   </div>
                   <div class="col-lg-2">ชั้น :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_floor" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_thasoi" runat="server" Text=""></asp:Label>--%>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">หมู่ที่ :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_thamu" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                   </div>
                   <div class="col-lg-2">ตรอก/ซอย :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_thasoi" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_thasoi" runat="server" Text=""></asp:Label>--%>
                   </div>
                   <div class="col-lg-1"></div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">ถนน :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_tharoad" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                       <%--  <asp:Label ID="lbl_lct_tharoad" runat="server" Text=""></asp:Label>--%>
                   </div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">ตำบล/แขวง :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_thathmblnm" runat="server" Width="100%"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_thathmblnm" runat="server" Text=""></asp:Label>--%>
                   </div>
                   <div class="col-lg-2">อำเภอ/เขต :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_thaamphrnm" runat="server" Width="100%"></asp:TextBox>
                       <%--  <asp:Label ID="lbl_lct_thaamphrnm" runat="server" Text=""></asp:Label></div>--%>
                   </div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">จังหวัด :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_thachngwtnm" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                   </div>
                   <div class="col-lg-2">รหัสไปรษณีย์ :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_zipcode" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_zipcode" runat="server" Text=""></asp:Label>--%>
                   </div>
               </div>
               <div class="row">
                   <div class="col-lg-1 "></div>
                   <div class="col-lg-2">โทรสาร :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_fax" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_fax" runat="server" Text=""></asp:Label>--%>
                   </div>
                   <div class="col-lg-2">โทรศัพท์ :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="lbl_lct_tel" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
                       <%-- <asp:Label ID="lbl_lct_tel" runat="server" Text=""></asp:Label>--%>
                   </div>
               </div>
               <div class="row">
                   <div class="col-lg-1"></div>
                   <div class="col-lg-2">E-mail :</div>
                   <div class="col-lg-3">
                       <asp:TextBox ID="Label59" runat="server" Width="100%"></asp:TextBox>
                   </div>
               </div>
           </div>
    </form>
</div>

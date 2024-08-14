<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_LCN_CONFIRM_DRUG.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_LCN_CONFIRM_DRUG" %>

<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

<%@ Register Src="../UC/UC_GRID_PHARMACIST.ascx" TagName="UC_GRID_PHARMACIST" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(window).load(function () {
                $.ajax({
                    type: 'POST',
                    data: { submit: true },
                    success: function (result) {
                        //    $('#spinner').fadeOut('slow');
                    }
                });
            });

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ContentPlaceHolder1_btn_upload').click(function () {

                $('#spinner').toggle('slow');
                Popups('POPUP_LCN_UPLOAD.aspx');
                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');
                Popups('POPUP_LCN_DOWNLOAD.aspx');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }

            function close_modal() { // คำสั่งสั่งปิด PopUp
                $('#myModal').modal('hide');
                $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
            }
        });

        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }
        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            Loaddata();
        }
    </script>
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />

    </div>

    <div>

        <asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control">
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
        </asp:HyperLink>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <table style="width: 100%; height: 500px;">
        <tr>
            <td rowspan="2" style="width: 70%;">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>

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

                    .auto-style9 {
                        width: 185px;
                        height: 35px;
                    }

                    .auto-style12 {
                        width: 85px;
                        height: 30px;
                    }

                    .auto-style13 {
                        height: 30px;
                    }

                    .auto-style14 {
                        width: 85px;
                        height: 30px;
                    }

                    .auto-style16 {
                        width: 260px;
                        height: 30px;
                    }

                    .auto-style2 {
                        width: 41px;
                        height: 30px;
                    }

                    .auto-style3 {
                        height: 30px;
                    }
                </style>

                <div style="border: groove; border-color: gainsboro;">
                    <asp:Panel ID="Panel1" runat="server">
                        <form name="form" method="post" align="center;" id="smp1">

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
                   <asp:RadioButtonList ID="rdl_lcn_type" runat="server" Enabled="False">
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
                <td>
                    เลือก &ensp;&ensp;
                </td>
                <td>
                
               <asp:RadioButtonList ID="rdl_sanchaat" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Enabled="False" >
                        <asp:ListItem Value="1">&ensp;ไทย&ensp;</asp:ListItem>
                        <asp:ListItem Value="2">&ensp;ต่างด้าว&ensp;</asp:ListItem>
                    </asp:RadioButtonList> 
               
              
                </td>
             </tr>
            </table>                                       
            </center>

                            </div>
                            <br />
                            <div>
                                <div class="row">
                                    <div class="col-lg-1 col-mg-1"></div>
                                    <div class="col-lg-3 col-mg-3">
                                        ๑. &ensp;ข้อมูลผู้ขออนุญาต
                                    </div>
                                    <div class="col-lg-8 col-mg-8">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1">
                                    </div>
                                    <div class="col-lg-3" style="text-align: left">
                                        ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                                    </div>
                                    <div class="col-lg-6" style="text-align: left">
                                         <asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2" style="text-align: left">
                                        อายุ 
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label>
                                        ปี
                                    </div>
                                    <div class="col-lg-2">สัญชาติ</div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-3">
                                        เลขประจำตัวประชาชน หรือเลขทะเบียนนิติบุคคล
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lbl_lcn_iden" runat="server" EnableTheming="True" Width="80%"></asp:Label>
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
                                        <asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        ชั้นที่
                                    </div>
                                    <div class="col-lg-3">
                                       <asp:Label ID="lbl_lcn_floor" runat="server" Text=""></asp:Label>
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
                                        <asp:Label ID="lbl_lcn_room" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        หมู่บ้าน/อาคาร
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>
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
                                        <asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        ตรอก/ซอย
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                        ถนน
                                    </div>
                                    <div class="col-lg-7" style="text-align: left">
                                        <asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label>
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
                                        <asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        อำเภอ/เขต
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label>
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
                                        <asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        รหัสไปรษณีย์
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>
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
                                        <asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        โทรศัพท์
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>
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
                                        <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        เวลาทำการรวมของร้าน
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lbl_da_opentime" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-3">
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                </div>
                           </div>
                           <br />
    
                         <div>
                                  <%-- <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                 ๑. &ensp;ข้อมูลผู้ขออนุญาต</h4>
                                <table>
                                    <tr>
                                        <td class="auto-style6"></td>
                                        <td class="auto-style7">ข้าพเจ้า (ชื่อบุคคล/นิติบุคคล)
                                        </td>
                                        <td class="auto-style18">
                                            <asp:Label ID="lbl_lcn_name" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style9"></td>
                                        <td class="auto-style18">
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">อายุ </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_ages" runat="server" Text=""></asp:Label>
                                            ปี
                                        </td>
                                        <td class="auto-style5">สัญชาติ&ensp;</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_nation" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">เลขประจำตัวประชาชน </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_iden" runat="server" EnableTheming="True" Width="80%"></asp:Label>
                                        </td>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style19">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">หรือเลขทะเบียนนิติบุคคล</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_iden2" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style19">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">ที่อยู่เลขที่</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_addr" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">ชั้นที่</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_floor" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style14"></td>
                                        <td class="auto-style16">ห้องเลขที่
                                        </td>
                                        <td class="auto-style20">
                                            <asp:Label ID="lbl_lcn_room" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style16">หมู่บ้าน/อาคาร</td>
                                        <td class="auto-style20">
                                            <asp:Label ID="lbl_lcn_building" runat="server" Text=""></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td class="auto-style16">หมู่ที่</td>
                                        <td class="auto-style20">
                                            <asp:Label ID="lbl_lcn_mu" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style4">ตรอก/ซอย</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_soi" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">ถนน </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_road" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">ตำบล/แขวง </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_tambol" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">อำเภอ/เขต</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_amphor" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">จังหวัด</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_changwat" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">รหัสไปรษณีย์</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_zipcode" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">โทรสาร</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_fax" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">&nbsp;โทรศัพท์ </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_tel" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style4">E-mail </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_lcn_email" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style5">เวลาทำการรวมของร้าน&nbsp;</td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lbl_da_opentime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                &ensp;&ensp;--%>
                         </div>
                            <div>
                                <table id="TB_Personal" runat="server">
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td colspan="8">
                                            <h4>กรณีผู้ขออนนุญาตเป็นบุคคลต่างด้าว ระบุ</h4>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="TB_Personal_Type1" runat="server">
                                    <table runat="server">

                                        <tr>
                                            <td colspan="5"></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td class="auto-style21">
                                                <asp:CheckBox ID="cb_Personal_Type1" Text="บุคคลธรรมดา " runat="server" Enabled="False" /></td>
                                            <td></td>
                                            <td class="auto-style22"></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td class="auto-style21">หนังสือเดินทางเลขที่</td>
                                            <td>
                                                <asp:Label ID="lbl_PASSPORT_NO" runat="server"></asp:Label>
                                            </td>
                                            <td class="auto-style22">วันหมดอายุ</td>
                                            <td>
                                                <asp:Label ID="lbl_PASSPORT_EXPDATE" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td class="auto-style21">ใบสำคัญที่อยู่เลขที่</td>
                                            <td>
                                                <asp:Label ID="lbl_DOC_NO" runat="server"></asp:Label>
                                            </td>
                                            <td class="auto-style22">ออกให้ ณ วันที่</td>
                                            <td>
                                                <asp:Label ID="lbl_DOC_DATE" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td class="auto-style21">ใบอนุญาตทำงานเลขที่</td>
                                            <td>
                                                <asp:Label ID="lbl_WORK_LICENSE_NO" runat="server"></asp:Label>
                                            </td>
                                            <td class="auto-style22">วันหมดอายุ</td>
                                            <td>
                                                <asp:Label ID="lbl_WORK_LICENSE_EXPDATE" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td colspan="4">หรือใบอนุญาาตประกอบธุรกิจตามบัญชีสาม(๑๖)หรือ(๑๕)ตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าว</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td class="auto-style21">เลขที่</td>
                                            <td>
                                                <asp:Label ID="lbl_BS_NO" runat="server"></asp:Label>
                                            </td>
                                            <td class="auto-style22">ออกให้ ณ วันที่</td>
                                            <td>
                                                <asp:Label ID="lbl_BS_DATE" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td colspan="2">หรือหนังสือรับรองตามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</td>
                                            <td class="auto-style22">
                                                <asp:Label ID="lbl_FRGN_NO" runat="server"></asp:Label></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td class="auto-style21">ออกให้ ณ วันที่</td>
                                            <td>
                                                <asp:Label ID="lbl_FRGN_DATE" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td class="auto-style22">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="TB_Personal_Type2" runat="server">
                                    <table runat="server">
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td>
                                                <asp:CheckBox ID="cb_Personal_Type2" Text="นิติบุคคลต่างด้าว " runat="server" Enabled="False" /></td>
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
                                            <td>
                                                <asp:Label ID="lbl_BS_NO1" runat="server" Style="margin-bottom: 0px"></asp:Label>
                                            </td>
                                            <td>ออกให้ ณ วันที่</td>
                                            <td>
                                                <asp:Label ID="lbl_BS_DATE1" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td colspan="2">หนังสือรับรองตาามกฎหมายว่าด้วยการประกอบธุรกิจของคนต่างด้าวเลขที่</td>
                                            <td>
                                                <asp:Label ID="lbl_FRGN_NO1" runat="server"></asp:Label></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3"></td>
                                            <td>ออกให้ ณ วันที่</td>
                                            <td>
                                                <asp:Label ID="lbl_FRGN_DATE1" runat="server" Text=""></asp:Label>
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
                                <table>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td>ชื่อผู้ดำเนินการ</td>
                                        <td>

                                            <asp:Label ID="lbl_BSN_THAIFULLNAME" runat="server" Text=""></asp:Label>

                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td>อายุ</td>
                                        <td>

                                            <asp:Label ID="lbl_BSN_AGE" runat="server" Text=""></asp:Label>
                                            ปี </td>
                                        <td>สัญชาติ</td>
                                        <td>

                                            <asp:Label ID="Label20" runat="server" Text=""></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td>เลขประจำตัวประชาชน</td>
                                        <td>

                                            <asp:Label ID="lbl_BSN_IDENTIFY" runat="server" Text=""></asp:Label></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td>ที่อยู่ตามทะเบียนบ้าน อยู่เลขที่</td>
                                        <td>
                                            <asp:Label ID="lbl_c_thaaddr" runat="server" AutoPostBack="True"></asp:Label>
                                        </td>
                                        <td>ชั้นที่</td>
                                        <td>
                                            <asp:Label ID="lbl_c_floor" runat="server" AutoPostBack="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>ห้องเลขที่</td>
                                        <td>
                                            <asp:Label ID="lbl_c_room" runat="server" AutoPostBack="True"></asp:Label>
                                        </td>
                                        <td>หมู่บ้าน/อาคาร</td>
                                        <td>

                                            <asp:Label ID="lbl_c_thabuilding" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>

                                        <td>หมู่ที่</td>
                                        <td>

                                            <asp:Label ID="lbl_c_thamu" runat="server"></asp:Label>
                                        </td>
                                        <td>ตรอก/ซอย</td>
                                        <td>

                                            <asp:Label ID="lbl_c_thasoi" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>

                                        <td>ถนน</td>
                                        <td>

                                            <asp:Label ID="lbl_c_tharoad" runat="server"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td>ตำบล/แขวง</td>
                                        <td>
                                            <asp:Label ID="lbl_tambol" runat="server"></asp:Label>
                                        </td>
                                        <td>อำเภอ/เขต</td>
                                        <td>
                                            <asp:Label ID="lbl_amphor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td>จังหวัด</td>
                                        <td>
                                            <asp:Label ID="lbl_Province" runat="server"></asp:Label>
                                        </td>
                                        <td>รหัสไปรษณีย์</td>
                                        <td>

                                            <asp:Label ID="lbl_c_zipcode" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td>โทรสาร</td>
                                        <td>

                                            <asp:Label ID="lbl_c_fax" runat="server"></asp:Label>
                                        </td>
                                        <td>โทรศัพท์</td>
                                        <td>

                                            <asp:Label ID="lbl_c_tel" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td>E-mail</td>
                                        <td>

                                            <asp:Label ID="lbl_c_email" runat="server"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <%-- <tr>
                   <td class="auto-style3"></td>
                   <td>

                       &nbsp;ที่อยู่ที่สามารถติดต่อได้ &nbsp;<asp:CheckBox ID="cb_addr" runat="server" AutoPostBack="True" />
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
                   <td>ชั้นที่</td>
                   <td>
                       <asp:TextBox ID="txt_c_floor" runat="server" AutoPostBack="True"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td></td>
                   <td>ห้องเลขที่</td>
                    <td>
                       <asp:TextBox ID="txt_c_room" runat="server" AutoPostBack="True"></asp:TextBox>
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
               </tr>--%>
                                </table>


                            </div>
                            <div>
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
                       <asp:Label ID="lbl_GIVE_PASSPORT_NO" runat="server"></asp:Label>
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">วันหมดอายุ
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">
                       <asp:Label ID="lbl_GIVE_PASSPORT_EXPDATE" runat="server"></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style12"></td>
                   <td class="auto-style13">ใบอนุญาตทำงานเลขที่
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">
                       <asp:Label ID="lbl_GIVE_WORK_LICENSE_NO" runat="server"></asp:Label>
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">วันหมดอายุ
                   </td>
                   <td class="auto-style13">&ensp;</td>
                   <td class="auto-style13">
                       <asp:Label ID="lbl_GIVE_WORK_LICENSE_EXPDATE" runat="server"></asp:Label>
                   </td>
               </tr>
           </table>


                                <br />
                                &ensp;
          
           
                            </div>
                            <div>
                                <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
               ๓. &ensp;ข้อมูลสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร</h4>
                                &ensp;

           <table>
               <tr>
                   <td class="auto-style3"></td>
                   <td>
                       <b>สถานที่ประกอบธุรกิจชื่อ</b></td>
                   <td>
                       <asp:Label ID="lbl_lct_thanameplace" runat="server" Text=""></asp:Label></td>
                   <td></td>
                   <td></td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>เลขรหัสประจำบ้าน</td>
                   <td>
                       <asp:Label ID="lbl_lct_HOUSENO" runat="server" Text=""></asp:Label>
                   </td>
                   <td></td>
                   <td></td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>อยู่เลขที่</td>
                   <td>
                       <asp:Label ID="lbl_lct_thaaddr" runat="server" Text=""></asp:Label>
                   </td>
                   <td>หมู่บ้าน/อาคาร</td>
                   <td>
                       <asp:Label ID="lbl_lct_thabuilding" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>หมู่ที่</td>
                   <td>
                       <asp:Label ID="lbl_lct_thamu" runat="server" Text=""></asp:Label>
                   </td>
                   <td>ตรอก/ซอย</td>
                   <td>
                       <asp:Label ID="lbl_lct_thasoi" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td></td>
                   <td>&nbsp;ถนน</td>
                   <td>
                       <asp:Label ID="lbl_lct_tharoad" runat="server" Text=""></asp:Label>
                   </td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>ตำบล/แขวง</td>
                   <td>
                       <asp:Label ID="lbl_lct_thathmblnm" runat="server" Text=""></asp:Label>
                   </td>
                   <td>&nbsp;อำเภอ/เขต</td>
                   <td>
                       <asp:Label ID="lbl_lct_thaamphrnm" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>จังหวัด</td>
                   <td>
                       <asp:Label ID="lbl_lct_thachngwtnm" runat="server" Text=""></asp:Label>
                   </td>
                   <td>รหัสไปรษณีย์</td>
                   <td>
                       <asp:Label ID="lbl_lct_zipcode" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>โทรสาร</td>
                   <td>
                       <asp:Label ID="lbl_lct_fax" runat="server" Text=""></asp:Label>
                   </td>
                   <td>โทรศัพท์</td>
                   <td>
                       <asp:Label ID="lbl_lct_tel" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3"></td>
                   <td>E-mail</td>
                   <td>
                       <asp:Label ID="Label59" runat="server" Text=""></asp:Label>
                   </td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
           </table>
                                <div>
                                    <h4>&ensp;&ensp;&ensp;&ensp;&ensp;
                ๔. &ensp;ข้อมูลผุ้มีหน้าที่ปฏิบัติการในสถานที่ผลิต นำเข้า หรือขายผลิตภัณฑ์สมุนไพร
                                    </h4>

                                    <table>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td>
                                                <%--บัตรประชาชน--%>
                                            </td>
                                            <td>
                                                <%--<asp:Label ID="lbl_PHR_CTZNO" runat="server"></asp:Label>--%>
                                            </td>
                                            <td>
                                                <%--<asp:Button ID="btn_search" runat="server" Text="ค้นหา" /> --%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td>&nbsp;
                        ๔.๑ กรณีผู้ประกอบวิชาชีพ/ผู้ประกอบโรคศิลปะ ชื่อ
                                            </td>                                           
                                            <td>
                                                <asp:Label ID="lbl_PHR_prefix" runat="server"></asp:Label><asp:Label ID="lbl_PHR_NAME" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_phr_type" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td>ใบอนุญาตประกออนบการวิชาชีพ/โรคศิลปะเลขที่
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_PHR_TEXT_NUM" runat="server"></asp:Label>
                                            </td>
                                            <td>หรือ
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td>กรณีที่ไม่ไช้ผู้ประกอบวิชาชีพหรือผู้ปรกอบโรคคิลปะ ให้ระบุคุณวุฒิ
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_STUDY_LEVEL" runat="server"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td>สาขา
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_PHR_VETERINARY_FIELD" runat="server"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td colspan="3">&nbsp;
                            ๔.๒  ผ่านการอบรมหลักสูตรจากสำนักงานคณะกรรมการอาหารและยา โปรดระบุชื่อหลักสูตร
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td>
                                                <asp:Label ID="lbl_NAME_SIMINAR" runat="server"></asp:Label>
                                            </td>
                                            <td>วันที่อบรม
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_SIMINAR_DATE" runat="server"></asp:Label>
                                                <%--<telerik:raddatepicker ID="rdp_SIMINAR_DATE" Runat="server"> </telerik:raddatepicker>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td>เวลาทำการ
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_PHR_TEXT_WORK_TIME" runat="server"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td class="auto-style2"></td>
                                            <td>เป็นผู้ที่มีหน้าที่ปฏิบัติการตาม
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rdl_mastra" runat="server" RepeatDirection="Horizontal" Enabled="False">
                                                    <asp:ListItem Value="1">มาตรา ๓๑</asp:ListItem>
                                                    <asp:ListItem Value="2">มาตรา ๓๒</asp:ListItem>
                                                    <asp:ListItem Value="3">มาตรา ๓๓</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>แห่ง พ.ร.บ.ผลิตภัณฑ์สมุนไพร พ.ศ.๒๕๖๒
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </form>
                    </asp:Panel>

                    <asp:Literal ID="lr_preview" runat="server"></asp:Literal>
                </div>
            </td>
            <td style="padding-left: 10%; height: 50%;">

                <table class="table" style="width: 90%">

                    <tr>
                        <td>
                            <asp:Button ID="btn_confirm" runat="server" Text="ยื่นคำขอ" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="80%" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_load" runat="server" Text="Download PDF" CssClass="btn-lg" Width="80%" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="80%" /></td>
                    </tr>

                </table>



            </td>
        </tr>
        <tr>
            <td style="width: 30%; height: 50%; padding-left: 10%">

                <uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" />

                <br />
                <uc2:UC_GRID_PHARMACIST ID="UC_GRID_PHARMACIST" runat="server" />

            </td>
        </tr>
    </table>

</asp:Content>


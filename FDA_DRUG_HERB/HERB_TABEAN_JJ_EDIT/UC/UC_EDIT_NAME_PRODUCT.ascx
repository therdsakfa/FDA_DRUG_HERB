<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_EDIT_NAME_PRODUCT.ascx.vb" Inherits="FDA_DRUG_HERB.UC_EDIT_NAME_PRODUCT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div visible="false" id="ID1" runat="server">
    <div class="row">
        <div class="col-lg-3" style="text-align: center">
            <h4>ชื่อของผลิตภัณฑ์สมุนไพร</h4>
            <hr />
        </div>
    </div>

    <div class="row" style="height: 5px"></div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-9">
            <asp:CheckBox ID="cb_sub_menu_1" Text=" &nbsp; 1. เพิ่ม/แก้ไขชื่อผลิตภัณฑ์ภาษาอังกฤษ  " runat="server" AutoPostBack="True" />
            <br />
            <div id="CB1" runat="server" visible="false">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-5">
                        <h4>ข้อมูลเดิม</h4>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-3">
                        <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อภาษาอังกฤษ:</label>
                    </div>
                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="NAME_ENG" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อภาษาอังกฤษ:</label>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="NAME_ENG_NEW" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <%--<div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อภาษาอังกฤษ:</label>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="NAME_ENG_NEW" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>--%>
                <hr />
            </div>
            <asp:CheckBox ID="cb_sub_menu_2" Text=" &nbsp; 2. เพิ่ม/แก้ไขชื่อผลิตภัณฑ์ภาษาอื่น  " runat="server" AutoPostBack="True" />
            <br />
            <div id="CB2" runat="server" visible="false">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-5">
                        <h4>ข้อมูลเดิม</h4>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-3">
                        <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อภาษาต่างประเทศอื่น:</label>
                    </div>
                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="NAME_OTHER" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อภาษาต่างประเทศอื่น:</label>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="NAME_OTHER_NEW" runat="server" Width="90%"></asp:TextBox>
                    </div>

                </div>


                <%-- <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อภาษาต่างประเทศอื่น:</label>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="NAME_OTHER_NEW" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <hr />--%>
                <hr />
            </div>
            <asp:CheckBox ID="cb_sub_menu_3" Text=" &nbsp; 3. เพิ่ม/แก้ไขชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอังกฤษ " runat="server" AutoPostBack="True" />
            <br />
            <div id="CB3" runat="server" visible="false">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-5">
                        <h4>ข้อมูลเดิม</h4>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-3">
                        <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอังกฤษ</label>
                    </div>
                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="Txt_NameEXP_Eng" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอังกฤษ:</label>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="Txt_NameEXP_Eng_New" runat="server" Width="90%"></asp:TextBox>

                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <%--     <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                    </div>
                    <div class="col-lg-1"></div>
                </div>--%>

                <%--  <div class="row">
                    <div class="col-lg-1"></div>
                     <div class="col-lg-2">
                        <label>ชื่อภาษาต่างประเทศอื่น:</label>
                    </div>
                    <div class="col-lg-5">
                        <asp:TextBox ID="Txt_NameProduct_Eng_New" runat="server" Width="100%"></asp:TextBox>

                    </div>
                    <div class="col-lg-1"></div>
                </div>
                <hr />--%>
                <hr />
            </div>
            <asp:CheckBox ID="cb_sub_menu_4" Text=" &nbsp; 4. เพิ่ม/แก้ไขชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอื่น  " runat="server" AutoPostBack="True" />
            <div id="CB4" runat="server" visible="false">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-5">
                        <h4>ข้อมูลเดิม</h4>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-3">
                        <h4>ข้อมูลที่ต้องการแก้ไข</h4>
                    </div>
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอื่น</label>
                    </div>
                    <div class="col-lg-3" style="border-bottom: #999999 1px dotted">
                        <asp:TextBox ID="Txt_NameEXP_Other" runat="server" Width="90%" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-2">
                        <label>ชื่อผลิตภัณฑ์เพื่อการส่งออกภาษาอื่น:</label>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="Txt_NameEXP_Other_New" runat="server" Width="90%"></asp:TextBox>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <div class="row" style="height: 10px"></div>

    <div class="row" id="CB_All" runat="server">
        <div class="col-lg-1"></div>
        <div class="col-lg-11">
        </div>
    </div>
    <hr />

</div>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HERB_WHO_ADD_DETAIT.aspx.vb" Inherits="FDA_DRUG_HERB.FRM_HERB_WHO_ADD_DETAIT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../css/css_radgrid.css" rel="stylesheet" />
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_DATE_APP"));
             $("#ContentPlaceHolder1_DD_OFF_APP").searchable();
        });

    </script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <h3 style="text-align: center">เพิ่มข้อมูลผู้ใด</h3>
        </div>
        <div class="col-lg-1"></div>
    </div>
    <hr />

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>เลขบัตร:</label>
        </div>
        <div class="col-lg-3">
            <asp:TextBox ID="IDENTIFY" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-2" style="text-align:left">
            <asp:Button ID="btn_serach_iden" runat="server" Text="ค้นหา" />
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ชื่อ:</label>
        </div>
        <div class="col-lg-8">
            <asp:TextBox ID="THANM_NAME" runat="server"></asp:TextBox>
        </div>

        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>ที่อยู่:</label>
        </div>
        <div class="col-lg-8">
            <asp:TextBox ID="ADDRESSPERSON" TextMode="MultiLine" Width="100%" Height="150" runat="server" ></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>เบอร์โทร:</label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="TEL" runat="server" ></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <label>E-MAIL:</label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="EMAIL" runat="server" ></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <label>NOTE:</label>
        </div>
        <div class="col-lg-8">
            <asp:TextBox ID="NOTE" TextMode="MultiLine" Width="100%" Height="150" runat="server" ></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
    </div>

    <hr />
    <div class="row">
        <div class="col-lg-12" style="text-align: center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" />
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" />
        </div>
    </div>
</asp:Content>

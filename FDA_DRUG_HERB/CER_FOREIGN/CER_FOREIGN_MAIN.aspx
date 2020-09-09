﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_GXP.Master" CodeBehind="CER_FOREIGN_MAIN.aspx.vb" Inherits="FDA_DRUG_HERB.CER_FOREIGN_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../UC/UC_Information.ascx" tagname="UC_Information" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" >
        $(document).ready(function () {
            $(window).load(function () {
                $.ajax({
                    type: 'POST',
                    data: { submit: true },
                    success: function (result) {
                        // $('#spinner').fadeOut('slow');
                    }
                });
            });

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ContentPlaceHolder1_btn_upload').click(function () {
                var lct_ida = getQuerystring("lct_ida");
                var lcn_ida = getQuerystring("lcn_ida");
                var process = getQuerystring("process");
                //  $('#spinner').toggle('slow');
                Popups('POPUP_CER_FOREIGN_UPLOAD.aspx?lct_ida=' + lct_ida + '&lcn_ida=' + lcn_ida + '&process=' + process);
                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');

            });

            function Popups(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }


        });
        function getQuerystring(key, default_) {
            if (default_ == null) default_ = "";
            key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
            var qs = regex.exec(window.location.href);
            if (qs == null)
                return default_;
            else
                return qs[1];
        }
        function Popups2(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function getQuerystring(key, default_) {
            if (default_ == null) default_ = "";
            key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
            var qs = regex.exec(window.location.href);
            if (qs == null)
                return default_;
            else
                return qs[1];
        }
        </script> 
     <script type="text/javascript" >
         function closespinner() {
             $('#spinner').fadeOut('slow');
             alert('Download Success');
             $('#ContentPlaceHolder1_Button1').click();

         }
         </script>
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> ลงทะเบียน GMP Clearance</h2>
           
            
            <uc1:UC_Information ID="UC_Information1" runat="server" />
           
            
            <br />

 <table>
       </table>

            <br />
        </div>


    </div>
    
    <div class="panel-info" style="text-align: right; width: 100%">
        <div style="text-align: right; padding-left: 5%; height: 60px;">
            <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg " />
            &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" Width="170px" CssClass="btn-lg " />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
        </div>
    </div>
  
   <hr />
   <div>
       <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15">
           <MasterTableView AutoGenerateColumns="False">
               <Columns>
                   <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                       SortExpression="IDA" UniqueName="IDA" Display="false">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="thacntnm" FilterControlAltText="Filter thacntnm column"
                       HeaderText="ประเทศ" SortExpression="thacntnm" UniqueName="thacntnm">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="CER_NUMBER" FilterControlAltText="Filter CER_NUMBER column"
                       HeaderText="เลขที่ CER" SortExpression="CER_NUMBER" UniqueName="CER_NUMBER">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter REQUEST_DATE column"
                       HeaderText="วันที่ยื่นคำขอ" SortExpression="REQUEST_DATE" UniqueName="REQUEST_DATE" DataFormatString="{0:dd/MM/yyyy}">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                       HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                       HeaderText="รหัสการดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="EXP_DATE_EXTEND" FilterControlAltText="Filter EXP_DATE_EXTEND column"
                       HeaderText="วันหมดอายุ" SortExpression="EXP_DATE_EXTEND" UniqueName="EXP_DATE_EXTEND" DataFormatString="{0:dd/MM/yyyy}">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="FOREIGN_LOCATION_NAME" FilterControlAltText="Filter FOREIGN_LOCATION_NAME column"
                       HeaderText="ชื่อผู้ผลิตต่างประเทศ" SortExpression="FOREIGN_LOCATION_NAME" UniqueName="FOREIGN_LOCATION_NAME">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column"
                       HeaderText="เหตุผลการคืนคำขอ" SortExpression="REMARK" UniqueName="REMARK">
                   </telerik:GridBoundColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                       CommandName="sel" Text="ดูข้อมูล">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>
               </Columns>
           </MasterTableView>
       </telerik:RadGrid>

     <%--<asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
           <Columns>

               <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="0%" Visible="false">
                   <ItemStyle Width="0%"></ItemStyle>
               </asp:BoundField>
       
               <asp:BoundField HeaderText="ประเทศ" DataField="thacntnm" ItemStyle-Width="10%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>
       
               <asp:BoundField DataField="CER_NUMBER" HeaderText="เลขที่ CER" ItemStyle-Width="10%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>
                  
               <asp:BoundField DataField="REQUEST_DATE" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
        
                  <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
      
                <asp:BoundField DataField="TR_ID" HeaderText="รหัสการดำเนินการ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="EXP_DATE_EXTEND" DataFormatString="{0:d}" HeaderText="วันหมดอายุ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField HeaderText="ชื่อผู้ผลิตต่างประเทศ" DataField="FOREIGN_LOCATION_NAME" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="REMARK" HeaderText="เหตุผลการคืนคำขอ" ItemStyle-Width ="20%" /> 
               <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>

                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>

                   <ItemStyle Width="20%"></ItemStyle>
               </asp:TemplateField>
           </Columns>
           <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#EFF3FB" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#F5F7FB" />
           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
           <SortedDescendingCellStyle BackColor="#E9EBEF" />
           <SortedDescendingHeaderStyle BackColor="#4870BE" />
       </asp:GridView>--%>

              <br />

              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด GMP Clearance</div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>

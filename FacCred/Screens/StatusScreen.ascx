<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusScreen.ascx.cs" Inherits="FacCred.Screens.StatusScreen" %>
<%@ Register Assembly="Jenzabar.Common" Namespace="Jenzabar.Common.Web.UI.Controls" TagPrefix="common" %>
<%@ Register src="MainMenu.ascx" TagName="MainMenu" TagPrefix="mom"  %>


<style type="text/css" >
.globalizedbutton
{
    width:105px;
    height: 30px;
    background-color:#265B8C;
    line-height: 30px;
    padding-bottom: 2px;
    vertical-align: middle;
    font-family: "Lucida Grande", Geneva, Verdana, Arial, Helvetica, sans-serif;
    font-size: 16px;
    text-transform: none;
    border:1px solid transparent;
    color:white;
}
.globalizedbutton:hover
{
    background-color:gainsboro;
    color:#265B8C;
}
.buttonBar{
    background-color:#265B8C;
}
.loader {
	position: fixed;
	left: 0px;
	top: 0px;
	width: 100%;
	height: 100%;
	z-index: 9999;
	background: url("UI/Common/Images/PortletImages/Lightbox/loading.gif") 50% 50% no-repeat rgb(249,249,249);
}
</style>

<%--<div class="loader"></div>--%>

<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css">
<script src="https://code.jquery.com/jquery-1.11.1.min.js"></script> 
<script src="https://cdn.datatables.net/1.10.4/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/jqueryui/dataTables.jqueryui.js"></script>
<link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<link rel="stylesheet" href="https://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/jqueryui/dataTables.jqueryui.css">


<div>
    <mom:MainMenu id="mainMenu" runat="server"></mom:MainMenu>
</div>

<table>
    <tr>
        <td style="color:tomato;width:500px;">
            <common:subheader id="Subheader3" runat="server" text="STATUS"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <asp:Button ID="btn_Back" runat="server" Text="<-BACK"  
                        onclick="btn_Back_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  />
        </td>
    </tr>    
    <tr>
        <td>
            <common:subheader id="Subheader2" runat="server" text="Faculty Approvals "></common:subheader>
        </td>
    </tr>
</table>

<asp:Panel ScrollBars="Vertical" Height="300px" Width="1100px" runat="server">
    <div id="rowDiv"  style="width:1050px" >
        <asp:GridView ID="gv_Faculty_Approvals" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false" 
            OnPreRender="gv_Faculty_Approvals_PreRender" 
            DataKeyNames="FACidnum,FACappid"
            onrowcommand="gv_Faculty_Approvals_RowCommand" >
            <Columns>
<%--            <asp:BoundField DataField="moddate" HeaderText="Modified Date" ItemStyle-ForeColor="Blue" />  --%>
                <asp:ButtonField  CommandName="gv_FacultyApprovals_Approve" Text="OPEN" ItemStyle-HorizontalAlign="Center"  ItemStyle-ForeColor="Blue"   />
                <asp:BoundField DataField="FAClastname" HeaderText="FacLastName" />
                <asp:BoundField DataField="FACfirstname" HeaderText="FacFirstName" /> 
                <asp:BoundField DataField="FACtype" HeaderText="TYPE"  /> 
                <asp:BoundField DataField="divcode" HeaderText="DIV"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                <asp:BoundField DataField="instdiv" HeaderText="InstDIV"   ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Blue" />
                <asp:BoundField DataField="schoolcode" HeaderText="SC"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Blue"  /> 

                <asp:BoundField DataField="approvalDate" HeaderText="ApprovalDate"   />
                <asp:BoundField DataField="expirationDate" HeaderText="ExpirationDate" />                
                <asp:BoundField DataField="approver1" HeaderText="Aprv1" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="approver2" HeaderText="Aprv2" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="approver3" HeaderText="Aprv3" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />                                                         
            </Columns>
        </asp:GridView>
    </div>
</asp:Panel>

<table>
    <tr>
        <td>
            <common:subheader id="CourseApprovalsHeadr" runat="server" text="Course Approvals "></common:subheader>
        </td>
    </tr>
</table>

<asp:Panel ScrollBars="Vertical" Height="300px" Width="1100px" runat="server">
    <div id="courseRowDiv"  style="width:1050px" >
        <asp:GridView ID="gv_Course_Approvals" runat="server" CssClass="gv2datatable" AutoGenerateColumns="false" 
            OnPreRender="gv_Course_Approvals_PreRender" 
            DataKeyNames="FACidnum,FACappid,SM_appid"
            onrowcommand="gv_Course_Approvals_RowCommand"   >
            <Columns>
                <asp:ButtonField  CommandName="gv_Approvals_Course_Approve" Text="OPEN"   ItemStyle-HorizontalAlign="Center"  ItemStyle-ForeColor="Blue"  />  
                <asp:BoundField DataField="FAClastname" HeaderText="FacLastName" />
                <asp:BoundField DataField="FACfirstname" HeaderText="FacFirstName" /> 
                <asp:BoundField DataField="FACtype" HeaderText="TYPE"  />            
                <asp:BoundField DataField="divcode" HeaderText="DIV"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="instdiv" HeaderText="InstDIV"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Blue" />
                <asp:BoundField DataField="schoolcode" HeaderText="SC"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Blue"/>

                <asp:BoundField DataField="yearcode" HeaderText="YEAR" />
                <asp:BoundField DataField="termcode" HeaderText="TERM" />
                <asp:BoundField DataField="crscde" HeaderText="COURSE" />
                <asp:BoundField DataField="crstitle" HeaderText="TITLE" />                        
                <asp:BoundField DataField="approver1" HeaderText="Aprv1" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="approver2" HeaderText="Aprv2" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="approver3" HeaderText="Aprv3" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />                                                         
            </Columns>
        </asp:GridView>
    </div>
</asp:Panel>

<script type="text/javascript">
    $(window).load(function () {
        $(".loader").fadeOut("slow");
    })

     $(document).ready(function () {
         //$(".gvdatatable").attr("width", "500");
     });
</script>

  <script>
      $(function () {          
          
          $(".gvdatatable").dataTable({
              //"iDisplayLength": 25
              'rowCallback': function (row, data, index)
              {
                  if (data[9].toUpperCase() == 'A') {
                      $(row).find('td:eq(9)').css('color', '#3dc902');
                  }
                  if (data[9].toUpperCase() == 'R') {
                      $(row).find('td:eq(9)').css('color', 'red');
                  }
                  if (data[10].toUpperCase() == 'A') {
                      $(row).find('td:eq(10)').css('color', '#3dc902');
                  }
                  if (data[10].toUpperCase() == 'R') {
                      $(row).find('td:eq(10)').css('color', 'red');
                  }
                  if (data[11].toUpperCase() == 'A') {
                      $(row).find('td:eq(11)').css('color', '#3dc902');
                  }
                  if (data[11].toUpperCase() == 'R') {
                      $(row).find('td:eq(11)').css('color', 'red');
                  }

                  
              }
              
          });

          var table = $(".gvdatatable").dataTable();

         // $(".gvdatatable tr:nth-child(even)").addClass("striped");
          

          $('.gvdatatable tbody').on("click", "tr", function () {
              
              if ($(this).hasClass("selected")) {
                  $(this).removeClass("selected");                   
              }
              else {
                  table.$("tr.selected").removeClass("selected");
                  $(this).addClass("selected");
              }



          });

          // these are to stop the flashing of the screen by hiding the loading of the table
          $("#rowDiv").removeAttr("hidden");
          $("#workingDiv").attr("hidden", "true");

      })
    </script>

  <script>
      $(function () {

          $(".gv2datatable").dataTable({
              //"iDisplayLength": 25
              'rowCallback': function (row, data, index) {

                  if (data[11].toUpperCase() == 'A') {
                      $(row).find('td:eq(11)').css('color', '#3dc902');
                  }
                  if (data[11].toUpperCase() == 'R') {
                      $(row).find('td:eq(11)').css('color', 'red');
                  }
                  if (data[12].toUpperCase() == 'A') {
                      $(row).find('td:eq(12)').css('color', '#3dc902');
                  }
                  if (data[12].toUpperCase() == 'R') {
                      $(row).find('td:eq(12)').css('color', 'red');
                  }
                  if (data[13].toUpperCase() == 'A') {
                      $(row).find('td:eq(13)').css('color', '#3dc902');
                  }
                  if (data[13].toUpperCase() == 'R') {
                      $(row).find('td:eq(13)').css('color', 'red');
                  }

              }

          });

          var table = $(".gv2datatable").dataTable();

          // $(".gvdatatable tr:nth-child(even)").addClass("striped");


          $('.gv2datatable tbody').on("click", "tr", function () {

              if ($(this).hasClass("selected")) {
                  $(this).removeClass("selected");
              }
              else {
                  table.$("tr.selected").removeClass("selected");
                  $(this).addClass("selected");
              }

          });

      })
    </script>
  


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacultyScreen.ascx.cs" Inherits="FacCred.Screens.FacultyScreen" %>
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

<div class="loader"></div>

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
        <td style="color:tomato;width:300px;">
            <common:subheader id="mainTitle" runat="server" text="FACULTY"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Button ID="btn_Faculty_Refresh" runat="server" Text="Faculty Refresh"   
                        onclick="btn_Faculty_Refresh_Click"  ControlStyle-CssClass="globalizedbutton" Width="200px"  />
        </td>
    </tr>
    <tr style="height:20px"></tr>
</table>
 
<asp:Panel ScrollBars="Vertical" Height="482px" runat="server">
    <div id="rowDiv"  style="width:1000px" >
        <asp:GridView ID="gv_Faculty" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false" 
            OnPreRender="gv_Faculty_PreRender" 
            onrowcommand="gv_Faculty_RowCommand"  
            OnSelectedIndexChanging="gv_Faculty_IndexChanging"
            DataKeyNames="FACappid,FACidnum">
            <Columns>
                <%--<asp:ButtonField  CommandName="gv_Faculty_Approvals" Text="Approvals"  ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"  />     ItemStyle-ForeColor="Blue"    --%>             
                <asp:BoundField DataField="FAClastname" HeaderText="LastName" />
                <asp:BoundField DataField="FACfirstname" HeaderText="FirstName" />
                <asp:BoundField DataField="FACinsttype" HeaderText="InstructorType" /> 
                <asp:BoundField DataField="FACdivcode" HeaderText="Division" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="FACinstdiv" HeaderText="InstDIV" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  ItemStyle-ForeColor="blue" /> 
                <asp:BoundField DataField="FACschoolcode" HeaderText="SchoolCode" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="blue"/>
                <asp:BoundField DataField="notes" HeaderText="Notes" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="pending" HeaderText="Pending" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="Aexpir60" HeaderText="AX60" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
               
                <asp:ButtonField  CommandName="gv_Faculty_Discipline" Text="XREF" HeaderText="XREF" ControlStyle-Font-Size="13px"  ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"  />
                <asp:ButtonField  CommandName="gv_Faculty_Degree" Text="Degrees" HeaderText="Degree" ControlStyle-Font-Size="13px" ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center" />
                <asp:ButtonField  CommandName="gv_Faculty_Note" Text="Notes" HeaderText="Note" ControlStyle-Font-Size="13px" ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center" />                                                
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
              "iDisplayLength": 25,
              "fixedHeader": true,
              "rowCallback": function (row, data, index)
              {
                  if (data[6] == '0') {
                      $(row).find('td:eq(6)').css('color', 'white');
                  } else {
                      $(row).find('td:eq(6)').css('color', 'green');
                  }
                  if (data[7] == '0') {
                      $(row).find('td:eq(7)').css('color', 'white');
                  } else {
                      $(row).find('td:eq(7)').css('color', 'blue');
                  }
                  if (data[8] == '0') {
                      $(row).find('td:eq(8)').css('color', 'white');
                  } else {
                      $(row).find('td:eq(8)').css('color', 'red');
                  }

                  
              }
          });
          var table = $(".gvdatatable").dataTable();

          $(".gvdatatable tr:nth-child(even)").addClass("striped");
          

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
    
      })
    </script>
  
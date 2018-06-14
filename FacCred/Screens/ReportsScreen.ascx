<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportsScreen.ascx.cs" Inherits="FacCred.Screens.ReportsScreen" %>
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
            <common:subheader id="Subheader1" runat="server" text="REPORTS"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="rptDesc" runat="server">Use these Buttons to Select and Run Reports</asp:Label>
        </td>
    </tr>
</table>

<asp:Panel ScrollBars="Vertical" Height="482px" runat="server">
    <div id="reportButtonsDiv"  style="width:1000px" >
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="width:300px;height:100px;" ></td>
                            <td style="width:300px;height:100px;">
                                 <common:Globalizedbutton id="Globalizedbutton3"  runat="server" text="FCS Roster" class="globalizedbutton"   style="width:300px;height:150px;" onclick="FCS_Roster_click"   ></common:Globalizedbutton>
                            </td>
                            <td style="width:300px;height:100px;">
                                 <common:Globalizedbutton id="Globalizedbutton2"  runat="server" text="CREDIT Report" class="globalizedbutton" style="width:300px;height:150px;"      ></common:Globalizedbutton>
                            </td>
                            <td style="width:300px;height:100px;">
                                 <common:Globalizedbutton id="Globalizedbutton5"  runat="server" text="OTHER-QUAL Report" class="globalizedbutton"  style="width:300px;height:150px;"     ></common:Globalizedbutton>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:300px;height:100px;" ></td>
                            <td style="width:300PX;height:150px;">
                                 <common:Globalizedbutton id="coursesBtn"  runat="server" text="PX-COURSES Report" class="globalizedbutton" style="width:300px;height:150px;"      ></common:Globalizedbutton>
                            </td>
                            <td style="width:300px;height:100px;">
                                 <common:Globalizedbutton id="Globalizedbutton1"  runat="server" text="PX-CODES Report" class="globalizedbutton"  style="width:300px;height:150px;"     ></common:Globalizedbutton>
                            </td>
                            <td style="width:300px;height:100px;">
                                 <common:Globalizedbutton id="Globalizedbutton4"  runat="server" text="ACAD-CRED Report" class="globalizedbutton"  style="width:300px;height:150px;"     ></common:Globalizedbutton>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:300px;height:100px;" ></td>
                            <td style="width:300px;height:100px;">
                                 <common:Globalizedbutton id="Globalizedbutton6"  runat="server" text="COPY-OL Report" class="globalizedbutton"  style="width:300px;height:150px;"     ></common:Globalizedbutton>
                            </td>
                            <td style="width:300px;height:100px;">
                                 <common:Globalizedbutton id="Globalizedbutton7"  runat="server" text="Notes Report" class="globalizedbutton"  style="width:300px;height:150px;"    ></common:Globalizedbutton>
                            </td>
                            <td style="width:300px;height:100px;">
                                 <common:Globalizedbutton id="Globalizedbutton8"  runat="server" text="EX-Creds Report" class="globalizedbutton"  style="width:300px;height:150px;"    ></common:Globalizedbutton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:75px;"></td>
                <td style="text-align:start;">

                </td>
            </tr>
        </table>
   
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
              "iDisplayLength": 100   
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

              var selected_idnum = $('tr.selected').children().find().prevObject[0].childNodes["0"].data;
              var selected_lastname = $('tr.selected').children().find().prevObject[1].childNodes["0"].data;
              var selected_firstname = $('tr.selected').children().find().prevObject[2].childNodes["0"].data;


              
              $('.txtBox1:text').val(selected_idnum);
              $('.lbl_idnum').text(selected_idnum);

              console.log('the found id: ' + selected_idnum.toString());
              console.log('the found lastname: ' + selected_lastname.toString());
              console.log('the found firstname: ' + selected_firstname.toString());

          });

          // these are to stop the flashing of the screen by hiding the loading of the table
          $("#rowDiv").removeAttr("hidden");
          $("#workingDiv").attr("hidden", "true");

      })
    </script>
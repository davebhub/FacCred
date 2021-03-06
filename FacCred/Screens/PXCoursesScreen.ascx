﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PXCoursesScreen.ascx.cs" Inherits="FacCred.Screens.PXCoursesScreen" %>
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


#divLoading
{
display : none;
}
#divLoading.show
{
display : block;
position : fixed;
z-index: 100;
background-image : url('http://loadinggif.com/images/image-selection/3.gif');
background-color:#666;
opacity : 0.4;
background-repeat : no-repeat;
background-position : center;
left : 0;
bottom : 0;
right : 0;
top : 0;
}
#loadinggif.show
{
left : 50%;
top : 50%;
position : fixed;
z-index : 101;
width : 32px;
height : 32px;
margin-left : -16px;
margin-top : -16px;
}
#divLoading.hide
{
display : none;
}
div.content {
width : 1200px;
height : 1200px;
}
</style>



<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css">
<script src="https://code.jquery.com/jquery-1.11.1.min.js"></script> 
<script src="https://cdn.datatables.net/1.10.4/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/jqueryui/dataTables.jqueryui.js"></script>
<link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<link rel="stylesheet" href="https://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/jqueryui/dataTables.jqueryui.css">


<div>
    <mom:MainMenu id="mainMenu" runat="server"></mom:MainMenu>
</div>


<div id="divLoading"> 
</div>


<%--<div id="workingDiv">
    <br />
    <string style="color:red">loading, please wait  . . .  </string>
    <asp:Image ID="Image1" runat="server" Width="400px" Height="400px"  ImageUrl="~/UI/Common/Images/PortletImages/Lightbox/loading.gif" />
</div>--%>


<table>
    <tr></tr>
    <tr>
        <td style="color:tomato;width:500px;">
            <common:subheader id="Subheader3" runat="server" text="CREDENTIALS - PX COURSES"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
    <tr>
        <td style="width:250px;">
            <common:subheader id="Subheader2" runat="server" text="All PX Courses "></common:subheader>
        </td>
        <td>
            <asp:Label ID="searchFacName" runat="server"></asp:Label>
        </td>
    </tr>
</table>

<asp:Panel ScrollBars="Vertical" Height="482px" runat="server">
    <div id="rowDiv" hidden="hidden" style="width:1050px" >
        <asp:GridView ID="gv_PX_Courses" runat="server" CssClass="gvdatatable" AutoGenerateColumns="true" 
             OnPreRender="gv_PX_Courses_PreRender" 
            DataKeyNames="revnumber"
            onrowcommand="gv_PX_Courses_RowCommand"  
            OnSelectedIndexChanging="gv_PX_Courses_IndexChanging" >

        </asp:GridView>
    </div>
</asp:Panel>



<script type="text/javascript">
    //$("div#divLoading").addClass('hide');

    $(window).load(function () {
       
        $(".loader").fadeOut("slow");
        
    })

     $(document).ready(function () {
         // $("div#divLoading").attr("hidden", "true");
         //$("div#divLoading").addClass('hide');
         $("#workingDiv").attr("hidden", "true");
     });
</script>

  <script>
      $(function showLoading() {
   //      $("div#divLoading").addClass('show');
      })

      $(function hideLoading() {
          $("div#divLoading").addClass('hide');
      })


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

  


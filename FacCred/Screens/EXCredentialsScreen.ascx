﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EXCredentialsScreen.ascx.cs" Inherits="FacCred.Screens.EXCredentialsScreen" %>
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
        <td style="color:tomato;width:500px;">
            <common:subheader id="Subheader3" runat="server" text="CREDENTIALS - EX Credentials"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
    <tr>
<%--        <td style="width:250px;">
            <common:subheader id="Subheader2" runat="server" text="All Credit Records "></common:subheader>
        </td>--%>
        <td>
            <asp:Label ID="facMember" runat="server" Font-Underline="true" >Faculty Member: </asp:Label>
            <strong><asp:Label ID="searchFacName" runat="server" Font-Underline="true"></asp:Label></strong>
        </td>
    </tr>
</table>

<asp:Panel ScrollBars="Vertical" Height="500px" runat="server">

    <div id="gv_EXCredentialsRowDiv" style="width:1000px" >
        <asp:GridView ID="gv_EXCredentials" runat="server" CssClass="gvdatatable" AutoGenerateColumns="true" 
            OnPreRender="gv_EXCredentials_PreRender" 
            DataKeyNames="idnum"
            onrowcommand="gv_EXCredentials_RowCommand"  
            OnSelectedIndexChanging="gv_EXCredentials_IndexChanging" >
<%--            <Columns>
                <asp:BoundField DataField="facqualno" HeaderText="FACQUAL_NO" Visible="false" />
                <asp:BoundField DataField="lastname" HeaderText="LastName" />
                <asp:BoundField DataField="firstname" HeaderText="FirstName" />
                <asp:BoundField DataField="degree" HeaderText="DEGREE" />
      
                <asp:BoundField DataField="received" HeaderText="RECEIVED" />
    
                <asp:BoundField DataField="idnum" HeaderText="IDNUM"  />
                <asp:BoundField DataField="qualtxt" HeaderText="QUAL_TXT" />
                <asp:BoundField DataField="highest" HeaderText="Highest" />
     
                
            </Columns>--%>
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
              "iDisplayLength": 10
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
   

      })
    </script>




<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateScreen.ascx.cs" Inherits="FacCred.Screens.UpdateScreen" %>
<%@ Register Assembly="Jenzabar.Common" Namespace="Jenzabar.Common.Web.UI.Controls" TagPrefix="common" %>
<%@ Register src="MainMenu.ascx" TagName="MainMenu" TagPrefix="mom"  %>
<%@ Register src="CredentialsPartial.ascx" TagName="Credentials" TagPrefix="cred"  %>


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
            <common:subheader id="mainTitle" runat="server" text="APPROVAL - UPDATE"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
</table>

<asp:Panel ScrollBars="Vertical" Height="500px" runat="server">
<div id="approvalDiv" style="width:1000px;border:double;" >   
    <table style="width:993px;">
        <tr style="background-color:#265B8C; color:white; ">
            <%--<td style="width:50px;"></td>--%>
            <td style="font-family:'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;font-size:16px;">
                <asp:Label runat="server">Selected</asp:Label>
            </td>
        </tr>
    </table>
    

    <div id="approveTableDiv" style="width:993px">
        <table style="background-color: gray;color:white; width:inherit" runat="server">  
            <tr>  
                <td style="height: 30px;"></td>  
            </tr>  
            <tr>
                <td></td>
                <td><asp:Label ID="lblFirstName" >FirstName</asp:Label></td>
                <td><asp:Label ID="lblLastName" >LastName</asp:Label></td>
                <td><asp:Label ID="lblInstType" >InstructorType</asp:Label></td>
                <td><asp:Label ID="lblIDNUM" >FacultyID</asp:Label></td>
            </tr>
            <tr >
                <td >FACULTY: </td>  
                <td style="color:black;"><asp:TextBox ID="txt_FirstName" runat="server"  ReadOnly="true"/></td>
                <td style="color:black;"><asp:TextBox ID="txt_LastName" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:TextBox ID="txt_instType" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:TextBox ID="txt_idnum" runat="server" ReadOnly="true"  /></td> 
            </tr>
            <tr style="height:20px;"></tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblCourseDesc" >CourseDescription</asp:Label></td>
                <td><asp:Label ID="lblInstDiv" >InstDivision</asp:Label></td>
                <td><asp:Label ID="lblCourseYear" >CourseYear</asp:Label></td>
                <td><asp:Label ID="lblCourseTerm" >CourseTerm</asp:Label></td>
            </tr>
            <tr >
                <td>COURSE: </td>  
                <td style="color:black;"><asp:TextBox ID="txt_CourseDesc" runat="server" ReadOnly="true" /></td>
                <td style="color:black;"><asp:TextBox ID="txt_InstDiv" runat="server" ReadOnly="true" /></td>
                <td style="color:black;"><asp:TextBox ID="txt_CourseYear" runat="server"  ReadOnly="true" /></td> 
                <td style="color:black;"><asp:TextBox ID="txt_CourseTerm" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:TextBox ID="txt_CourseAppid" runat="server" ReadOnly="true"  Visible="false"/></td>                  
            </tr>
       </table>
    </div>
<%--</div>


<div id="as_updateDiv" style="width:1000px">--%>
        <table style="background-color:gray;color:white; width:993px; ">  
        <tr>  
            <td style="height: 10px;"></td>  
        </tr>  
        <tr style="height:25px;"></tr>
        <tr>    
            <td></td>         
            <td> </td>
            <td>
                <label style="text-align:right;" ><Strong>APPROVAL STATUS: </Strong></label>&nbsp;
                <asp:DropDownList ID="DropDownList_approval" runat="server"  AutoPostBack="false" Width="125px" 
                    OnLoad="DropDownList_approval_OnLoad"  ForeColor="Black" 
                    OnSelectedIndexChanged="ddl_approval_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" >
                </asp:DropDownList>
            </td>
          
            <td>
                 <strong> <asp:Button ID="btn_CourseSave" runat="server" Text="Course SAVE"  
                     onclick="CourseSave_Click" Enabled="false" ControlStyle-CssClass="globalizedbutton" Width="225px"  /></strong>
            </td>
         </tr>
            <tr style="height:20px;"></tr>
         <tr>
            <td>
                <%--<label style="width:155px;text-align:right;"><Strong>INSTITUTION DIVISION: </Strong></label>--%>
             </td>
             <td>
<%--                <asp:DropDownList ID="DropDownList_divisions" runat="server"  AutoPostBack="false" Width="300px" 
                    OnLoad="DropDownList_divisions_OnLoad"  
                    OnSelectedIndexChanged="ddl_divisions_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" >
                </asp:DropDownList>--%>
            </td>
        
            <td></td>
            <td>
                <strong> <asp:Button ID="btn_DivisionSave" runat="server" Text="Division SAVE"   BorderStyle="Solid"
                    onclick="DivisionSave_Click"  Enabled="false"  ControlStyle-CssClass="globalizedbutton" Width="225px"  
                    ToolTip="Save the selected Approval Status for all Courses of the selected Division, for the selected Faculty" /></strong>
            </td>
        </tr> 
        <tr>  
            <td style="height: 10px;"></td>  
        </tr>  
        <tr style="height:50px;"></tr>
    </table>
    <table style="background-color:gray; width:993px; >
        <tr>
            <td style="width:200px;">
            </td>
            <td style="color:blue;width:400px;">
                <asp:Label ID="lbl_updateErrMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    
</div>

<br /><br />
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
              "iDisplayLength":10
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

  


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApprovalNoteScreen.ascx.cs" Inherits="FacCred.Screens.ApprovalNoteScreen" %>
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

  <script src='https://cloud.tinymce.com/stable/tinymce.min.js'></script>
<%--  <script>
  tinymce.init({
      selector: '#mytextarea',
      file_browser_callback: function (field_name, url, type, win) {
          win.document.getElementById(field_name).value = 'noteText';
      }
  });
  </script>--%>

<div>
    <mom:MainMenu id="mainMenu" runat="server"></mom:MainMenu>
</div>

<table>
    <tr>
        <td style="color:tomato;width:500px;">
            <common:subheader id="mainTitle" runat="server" text="APPROVAL NOTE"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
</table>

<asp:Panel ScrollBars="Vertical" Height="600px" runat="server">
<div id="approvalDiv" style="width:1000px;border:double;" >   
    <table style="width:995px;">
        <tr style="background-color:#265B8C; color:white; ">
            <%--<td style="width:50px;"></td>--%>
            <td style="font-family:'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;font-size:16px;">
                <asp:Label runat="server">Selected</asp:Label>
            </td>
        </tr>
    </table>
    

    <div id="approveTableDiv" style="width:995px">

<%--        Data that will be used to create the note--%>
        <table style="background-color: gray;color:white; width:inherit" runat="server">    
            <tr style="height:20px;"></tr>
            <tr><td style="width:100px;" >FACULTY: </td>                
                <td><asp:Label ID="lblFirstName" runat="server" >FirstName</asp:Label></td>
                <td><asp:Label ID="lblLastName" runat="server" >LastName</asp:Label></td>
                <td><asp:Label ID="lblInstType" runat="server" >InstructorType</asp:Label></td>
                <td><asp:Label ID="lblIDNUM" runat="server" >FacultyID</asp:Label></td>
            </tr>
            <tr >
                 <td></td>
                <td style="color:black;"><asp:Label ID="lbl_FirstName" runat="server"  ReadOnly="true"/></td>
                <td style="color:black;"><asp:Label ID="lbl_LastName" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_instType" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_idnum" runat="server" ReadOnly="true"  /></td> 
            </tr>
            <tr><td style="width:100px;">COURSE: </td>                  
                <td><asp:Label ID="lblCourseDesc" runat="server" >CourseDescription</asp:Label></td>
                <td><asp:Label ID="lblInstDiv" runat="server" >InstDivision</asp:Label></td>
                <td><asp:Label ID="lblCourseYear" runat="server" >CourseYear</asp:Label></td>
                <td><asp:Label ID="lblCourseTerm" runat="server">CourseTerm</asp:Label></td>
            </tr>
            <tr >
                <td></td>
                <td style="color:black;"><asp:Label ID="lbl_CourseDesc" runat="server" ReadOnly="true" /></td>
                <td style="color:black;"><asp:Label ID="lbl_InstDiv" runat="server" ReadOnly="true" /></td>
                <td style="color:black;"><asp:Label ID="lbl_CourseYear" runat="server"  ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_CourseTerm" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_CourseAppid" runat="server" ReadOnly="true"  Visible="false"/></td>                  
            </tr>
            <tr style="height:50px;"></tr>
       </table>

<%--        Editor Section--%>


        <table style="background-color:gray;color:white; width:995px;"> 
             <tr>    
                <td style="width:100px;"></td>                 
                 <td style="text-align:right;"><asp:Label >Subject:</asp:Label></td>
                 <td style="color:black;"><asp:TextBox ID="txt_Subject" runat="server" Width="250" MaxLength="25" ></asp:TextBox></td>
                 <td style="text-align:right;"><asp:Label >Note Status:</asp:Label></td>
                 <td style="color:black;"> 
                      <asp:DropDownList ID="ddl_Status_codes" runat="server"  AutoPostBack="false" Width="125px" 
                    OnLoad="ddl_Status_codes_OnLoad"  ForeColor="Black" 
                    OnSelectedIndexChanged="ddl_Status_codes_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" />
                </td> 
                <td></td> 
            </tr>
        </table>
        <table style="background-color:gray;color:white; width:995px;"> 
            <tr style="width:900px;">               
                <td style="width:100px;text-align:right"><label>NOTE:</label></td>  
                <td style="color:black;">
                    <textarea id="mytextarea" runat="server" style="color:black;width:825px;height:75px;"  maxlength="180"  ></textarea>
                </td>
                <td></td>
             </tr>
             <tr style="height:20px;">
             </tr>
        </table>

       <table style="background-color:gray;color:white; width:995px;">         
             <tr >
                 <%--<td style="width:100px;"></td>--%>
                 <td style="text-align:right;"><asp:Label >Approval Date:</asp:Label></td>
                 <td style="color:black;">
                     <common:datepicker runat="server" id="dp_Approval_Date" ></common:datepicker>
                 </td> 
             </tr>
             <tr>
                 <td style="text-align:right;"><asp:Label >Expiration Date:</asp:Label></td>               
                 <td style="color:black;">
                     <common:datepicker runat="server" id="dp_Expiration_Date"  ></common:datepicker>
                 </td>
             </tr> 
             <tr></tr>
        </table>

<%--        Buttons Table--%>
        <table style="background-color:gray;color:white; width:995px; ">  
            <tr style="height:25px;"></tr>
            <tr>
                <td style="width:100px;"></td>
                <td>
                        <strong> <asp:Button ID="btn_FacultySave" runat="server" Text="Faculty SAVE"  
                            onclick="FacultySave_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="225px"  /></strong>
                </td>
                <td></td> 
                <td>
                     <strong> <asp:Button ID="btn_CourseSave" runat="server" Text="Course SAVE"  
                         onclick="CourseSave_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="225px"  /></strong>
                </td>
                <td></td> 
                <td>
                    <strong> <asp:Button ID="btn_DivisionSave" runat="server" Text="Division SAVE"   BorderStyle="Solid"
                        onclick="DivisionSave_Click"  Enabled="true"  ControlStyle-CssClass="globalizedbutton" Width="225px" /></strong>
                </td>
            </tr>       
            <tr style="height:50px;"></tr>
        </table>

<%--        Filler at the bottom--%>
        <table style="background-color:gray;width:995px;" >
            <tr>
                <td style="width:200px;">
                </td>
                <td style="color:blue;width:400px;">
                    <asp:Label ID="lbl_updateErrMsg" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
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

 <%-- <script>
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
    </script>--%>
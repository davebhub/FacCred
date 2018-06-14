<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesUpdateScreen.ascx.cs" Inherits="FacCred.Screens.NotesUpdateScreen" %>
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
            <common:subheader id="mainTitle" runat="server" text="CREDENTIALS - NOTES - UPDATE"></common:subheader>
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
                <td><asp:Label runat="server"  >FirstName</asp:Label></td>
                <td><asp:Label runat="server"  >LastName</asp:Label></td>
                <td><asp:Label runat="server"  >InstructorType</asp:Label></td>
                <td><asp:Label runat="server"  >FacultyID</asp:Label></td>
                <td></td>
            </tr>
            <tr >
                 <td></td>
                <td style="color:black;"><asp:Label ID="lbl_firstName" runat="server"  ReadOnly="true"/></td>
                <td style="color:black;"><asp:Label ID="lbl_lastName" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_instType" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_idnum" runat="server" ReadOnly="true"  /></td> 
                <td></td>
            </tr>
                <tr><td style="width:100px;" >DISCIPLINE: </td>                
                <td><asp:Label runat="server"  >Division</asp:Label></td>
                <td><asp:Label runat="server"  >Institution_Division</asp:Label></td>
                <td><asp:Label runat="server"  >School_Code</asp:Label></td>
                <td></td>
                <td></td>
            </tr>
            <tr >
                <td></td>
                <td style="color:black;"><asp:Label ID="lbl_CATdiv" runat="server"  ReadOnly="true" /></td>
                <td style="color:black;"><asp:Label ID="lbl_CATinstdiv" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_CATschoolcde" runat="server" ReadOnly="true" /></td> 
                <td></td> 
                <td></td>
            </tr>
<%--            <tr><td style="width:100px;">COURSE: </td>                  
                <td><asp:Label  runat="server" >CourseDescription</asp:Label></td>
                <td><asp:Label  runat="server" >InstDivision</asp:Label></td>
                <td><asp:Label  runat="server" >CourseYear</asp:Label></td>
                <td><asp:Label  runat="server">CourseTerm</asp:Label></td>
                <td><asp:Label  runat="server">CourseAppid</asp:Label></td>
            </tr>
            <tr >
                <td></td>
                <td style="color:black;"><asp:Label ID="lbl_courseDesc" runat="server" ReadOnly="true" /></td>
                <td style="color:black;"><asp:Label ID="lbl_instDiv" runat="server" ReadOnly="true" /></td>
                <td style="color:black;"><asp:Label ID="lbl_courseYear" runat="server"  ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_courseTerm" runat="server" ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_courseAppid" runat="server" ReadOnly="true" /></td>                  
            </tr>--%>
                
<%--            <tr><td style="width:100px;">PX DATA: </td>                  
                <td><asp:Label  runat="server" >PX_SSN</asp:Label></td>
                <td><asp:Label  runat="server">PX_Division</asp:Label></td>
                <td></td>
                <td></td>   
                <td></td> 
            </tr>
            <tr >
                <td></td>
                <td style="color:black;"><asp:Label ID="lbl_PXssn" runat="server"  ReadOnly="true" /></td> 
                <td style="color:black;"><asp:Label ID="lbl_PXdivCode" runat="server" ReadOnly="true" /></td>
                <td></td>  
                <td></td>   
                <td></td>                             
            </tr>--%>
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
                    <textarea id="mytextarea" runat="server" style="color:black;width:825px;height:75px;"   maxlength="180"  ></textarea>
                </td>
                <td></td>
             </tr>
             <tr style="height:20px;">
             </tr>
        </table>

       <table style="background-color:gray;color:white; width:995px;">         
             <tr >
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
        </table>


        <%--        Buttons Table--%>
        <table style="background-color:gray;color:white; width:995px; ">  
            <tr style="height:25px;"></tr>
            <tr>
                <td style="width:650px;"></td>
                <td>
                        <strong> <asp:Button ID="btn_Cancel" runat="server" Text="CANCEL"  
                            onclick="btn_Cancel_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  /></strong>
                </td>
                <td>
                        <strong> <asp:Button ID="btn_Save" runat="server" Text="SAVE"  
                            onclick="btn_Save_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  /></strong>
                </td>
                 <td>
                    <strong> <asp:Button ID="btn_Archive" runat="server" Text="Archive"   BorderStyle="Solid"
                        onclick="btn_Archive_Click"  Enabled="true"  ControlStyle-CssClass="globalizedbutton" Width="125px" /></strong>
                </td>
                <td style="width:50px;"></td> 
            </tr>       
            <tr style="height:50px;"></tr>
        </table>

<%--        Filler at the bottom--%>
        <table style="background-color:gray;width:995px;" >
            <tr>
                <td style="width:200px;">
                </td>
                <td style="color:blue;width:400px;">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>

<%--        Error Messages --%>
        <table style="background-color:gray; width:995px;" >
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

  


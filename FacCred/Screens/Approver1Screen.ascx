<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Approver1Screen.ascx.cs" Inherits="FacCred.Screens.Approver1Screen" %>
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


<%--<div id="workingDiv">
    <br />
    <string style="color:red">loading, please wait  . . .  </string>
    <asp:Image ID="Image1" runat="server"  ImageUrl="~/UI/Common/Images/PortletImages/Lightbox/loading.gif" />
</div>--%>

<br /><br />
<common:subheader id="mainTitle" runat="server" text="APPROVER1"></common:subheader>
<br />
<common:Globalizedbutton id="btn_newSearch" runat="server" text="New Search" style="width:200px" class="globalizedbutton" OnClick="btn_newSearch_command" ></common:Globalizedbutton>
<br /><br />

<asp:Panel ScrollBars="Vertical" Height="500px" runat="server">
    <br />
    <common:subheader id="Subheader2" runat="server" text="ALL APPROVALS"></common:subheader>
    <div id="rowDiv" hidden="hidden" style="width:1000px" >
        <asp:GridView ID="gv_Approvals" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false" 
            OnPreRender="gv_Approvals_PreRender" 
            DataKeyNames="idnum"
            onrowcommand="gv_Approvals_RowCommand"  
            OnSelectedIndexChanging="gv_Approvals_IndexChanging" >
            <Columns>
                <asp:BoundField DataField="moddate" HeaderText="Modified Date" ItemStyle-ForeColor="Red"  /> 
                <asp:BoundField DataField="crscde" HeaderText="COURSE" />
                <asp:BoundField DataField="instdiv" HeaderText="DIV" />
                <asp:BoundField DataField="yrcde" HeaderText="YEAR" />
                <asp:BoundField DataField="trmcde" HeaderText="TERM" />
                <asp:BoundField DataField="lastname" HeaderText="FacLastName" />
                <asp:BoundField DataField="firstname" HeaderText="FacFirstName" />    
                <asp:BoundField DataField="insttype" HeaderText="TYPE"  />                    
                <asp:BoundField DataField="idnum" HeaderText="ID_NUM" Visible="false"  /> 
                <asp:BoundField DataField="appid" HeaderText="APPID"  Visible="false" />                  
                <asp:BoundField DataField="approver1" HeaderText="APPROVER1" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="approver2" HeaderText="APPROVER2" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="approver3" HeaderText="APPROVER3" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center" /> 
                                                          
            </Columns>
        </asp:GridView>
    </div>

    <br /><br />
    <common:subheader id="Subheader1" runat="server" text="YOUR PENDING APPROVALS"></common:subheader>

    <div id="yourDiv" hidden="hidden" style="width:1000px" >
        <asp:GridView ID="gv_Your_Approvals" runat="server" CssClass="gvyourdatatable" AutoGenerateColumns="false" 
            OnPreRender="gv_Your_Approvals_PreRender" 
            DataKeyNames="idnum"
            onrowcommand="gv_Your_Approvals_RowCommand"  
            OnSelectedIndexChanging="gv_Your_Approvals_IndexChanging" >
            <Columns>
                <asp:ButtonField  CommandName="gv_Your_Approvals_Approve" Text="SELECT"   />
                <asp:BoundField DataField="crscde" HeaderText="COURSE" />
                <asp:BoundField DataField="instdiv" HeaderText="DIV" />
                <asp:BoundField DataField="yrcde" HeaderText="YEAR" />
                <asp:BoundField DataField="trmcde" HeaderText="TERM" />
                <asp:BoundField DataField="lastname" HeaderText="FacLastName" />
                <asp:BoundField DataField="firstname" HeaderText="FacFirstName" />  
                <asp:BoundField DataField="insttype" HeaderText="TYPE"   />       
                <asp:BoundField DataField="idnum" HeaderText="ID_NUM"   /> 
                <asp:BoundField DataField="appid" HeaderText="APPID"   />  
                <asp:BoundField DataField="approver" HeaderText="A1" />                                  
                <asp:ButtonField  CommandName="gv_Your_Approvals_Remarks" Text="REMARKS"  />                                   
            </Columns>
        </asp:GridView>
    </div>


    <div id="as_approvalDiv">
    <br /><br />
    <common:subheader id="Subheader3" runat="server" text="SELECTED"></common:subheader>
    <div id="as_approveTableDiv" style="width:1000px">
        <table style="background-color:  azure; width:inherit" runat="server">  
            <tr>  
                <td style="height: 10px;"></td>  
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
                <td><asp:TextBox ID="txt_FirstName_as" runat="server"  ReadOnly="true"/></td>
                <td><asp:TextBox ID="txt_LastName_as" runat="server" ReadOnly="true" /></td> 
                <td><asp:TextBox ID="txt_instType_as" runat="server" ReadOnly="true" /></td> 
                <td><asp:TextBox ID="txt_idnum_as" runat="server" ReadOnly="true"  /></td> 
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblCourseDesc" >CourseDescription</asp:Label></td>
                <td><asp:Label ID="lblInstDiv" >InstDivision</asp:Label></td>
                <td><asp:Label ID="lblCourseYear" >CourseYear</asp:Label></td>
                <td><asp:Label ID="lblCourseTerm" >CourseTerm</asp:Label></td>
            </tr>
            <tr >
                <td>COURSE: </td>  
                <td><asp:TextBox ID="txt_CourseDesc_as" runat="server" ReadOnly="true" /></td>
                <td><asp:TextBox ID="txt_InstDiv_as" runat="server" ReadOnly="true" /></td>
                <td><asp:TextBox ID="txt_CourseYear_as" runat="server"  ReadOnly="true" /></td> 
                <td><asp:TextBox ID="txt_CourseTerm_as" runat="server" ReadOnly="true" /></td> 
                <td><asp:TextBox ID="txt_CourseAppid_as" runat="server" ReadOnly="true"  Visible="false"/></td>                  
            </tr>
       </table>
    </div>
</div>



<div id="as_updateDiv" style="width:1000px">
        <table style="background-color: azure; width:inherit ">  
        <tr>  
            <td style="height: 10px;"></td>  
        </tr>  
        <tr style="height:25px;"></tr>
        <tr>             
            <td>
                <label style="width:155px;text-align:right;" ><Strong>APPROVAL STATUS: </Strong></label>
                <asp:DropDownList ID="as_DropDownList_approval" runat="server"  AutoPostBack="false" Width="125px" 
                    OnLoad="as_DropDownList_approval_OnLoad"  
                    OnSelectedIndexChanged="as_ddl_approval_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" >
                </asp:DropDownList>
            </td>
           <td></td>
            <td>
                <label ><Strong>DIVISION: </Strong></label>
                <asp:DropDownList ID="as_DropDownList_divisions" runat="server"  AutoPostBack="false" Width="300px" 
                    OnLoad="as_DropDownList_divisions_OnLoad"  
                    OnSelectedIndexChanged="as_ddl_divisions_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" >
                </asp:DropDownList>
            </td>
        </tr> 
        <tr>  
            <td style="height: 10px;"></td>  
        </tr>  
        <tr style="height:25px;"></tr>
        <tr>
            <td> <strong> <asp:Button ID="btn_CourseSave_as" runat="server" Text="Save Course Only"  onclick="as_CourseSave_Click" Enabled="false" /></strong></td> 
            <td></td>
            <td></td>
            <td></td>
            <td><strong> <asp:Button ID="btn_DivisionSave_as" runat="server" Text="Save Courses of Selected Division"  onclick="as_DivisionSave_Click"  Enabled="false"  /></strong></td>
        </tr>
        <tr style="height:25px;"></tr>
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
  <script>
      $(function () {          
          
          $(".gvyourdatatable").dataTable({
              "iDisplayLength":10
          });
          var table = $(".gvyourdatatable").dataTable();

          $(".gvyourdatatable tr:nth-child(even)").addClass("striped");
          

          $('.gvyourdatatable tbody').on("click", "tr", function () {
              
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
          $("#yourDiv").removeAttr("hidden");
          $("#workingDiv").attr("hidden", "true");

      })
    </script>
  


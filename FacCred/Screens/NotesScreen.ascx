<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesScreen.ascx.cs" Inherits="FacCred.Screens.NotesScreen" %>
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
            <common:subheader id="Subheader3" runat="server" text="CREDENTIALS - NOTES"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
        <tr>
        <td>
            <asp:LinkButton ID="lb_NewNote" OnClick="lb_NewNote_click" Text="New Note" CssClass="globalizedbutton"  Font-Underline="false" BorderStyle="None" runat="server" Width="150" ></asp:LinkButton>           
        </td>
    </tr>
    <tr>
        <td style="color:tomato">
            <asp:Label ID="searchFacName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="color:tomato">
            <asp:Label ID="searchDiscipline" runat="server"></asp:Label>
        </td>
    </tr>
</table>

<asp:Panel ScrollBars="Vertical" Height="482px" runat="server">
    <div id="rowDiv" hidden="hidden"  >
        <asp:GridView ID="gv_Notes" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false" 
            OnPreRender="gv_Notes_PreRender" 
            onrowcommand="gv_Notes_RowCommand"  
            OnSelectedIndexChanging="gv_Notes_IndexChanging" >
            <Columns>
                <asp:ButtonField  CommandName="gv_Notes_select" Text="Select"  ControlStyle-CssClass="globalizedbutton" ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"  />                                  
                <asp:BoundField DataField="FACfirstname" HeaderText="FirstName" />
                <asp:BoundField DataField="FAClastname" HeaderText="LastName" />                 
                <asp:BoundField DataField="NOTEsubject" HeaderText="SUBJECT" />
                <asp:BoundField DataField="NOTEnote" HeaderText="NOTE" />
                <asp:BoundField DataField="NOTEcreatedate" HeaderText="CREATED" />
                <asp:BoundField DataField="NOTEstatus" HeaderText="STATUS" />
                <asp:BoundField DataField="NOTEapprovaldate" HeaderText="APR_DATE" />
                <asp:BoundField DataField="NOTEexpirationdate" HeaderText="EXP_DATE" />               
                <asp:BoundField DataField="NOTEupdatedate" HeaderText="UPD_DATE" />
                <asp:BoundField DataField="NOTEupdateby" HeaderText="UPD_BY" />
                <asp:BoundField DataField="CRSinstdiv" HeaderText="INST_DIV" />
                <asp:BoundField DataField="NOTEyearcode" HeaderText="YEAR" />
                <asp:BoundField DataField="NOTEtermcode" HeaderText="TERM" />
                <asp:BoundField DataField="CRSappid" HeaderText="CRS_APPID" />
                <asp:BoundField DataField="CRSdesc" HeaderText="COURSE" />
                <asp:BoundField DataField="FACidnum" HeaderText="FAC_IDNUM" />
                <asp:BoundField DataField="FACappid" HeaderText="FAC_APPID" />
                <asp:BoundField DataField="FACinsttype" HeaderText="FAC_TYPE" />                
                <asp:BoundField DataField="NOTEusername" HeaderText="USERNAME" />
                <asp:BoundField DataField="FACssn" HeaderText="SSN" />
                <asp:BoundField DataField="PXolddivcode" HeaderText="OldDivCode"  />    
                <asp:BoundField DataField="NOTEid" HeaderText="NOTEid"  />                                                        
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

  


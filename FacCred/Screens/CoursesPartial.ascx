<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoursesPartial.ascx.cs" Inherits="FacCred.Screens.CoursesPartial" %>
<%@ Register Assembly="Jenzabar.Common" Namespace="Jenzabar.Common.Web.UI.Controls" TagPrefix="common" %>


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
</style>

<br /><br />
<common:subheader id="mainTitle" runat="server" text="COURSES"></common:subheader>


<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css">
<script src="https://code.jquery.com/jquery-1.11.1.min.js"></script> 
<script src="https://cdn.datatables.net/1.10.4/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/jqueryui/dataTables.jqueryui.js"></script>
<link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<link rel="stylesheet" href="https://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/jqueryui/dataTables.jqueryui.css">


<div id="gv_cp_rowDiv" hidden="hidden"  style="width:800px" >
    <asp:GridView ID="gv_coursesPartial" runat="server" CssClass="gv_coursesPartial" AutoGenerateColumns="false" 
        OnPreRender="gv_coursesPartial_PreRender" 
        DataKeyNames="idnum"
        onrowcommand="gv_coursesPartial_RowCommand"  
        OnSelectedIndexChanging="gv_coursesPartial_IndexChanging" >
        <Columns>
        <asp:BoundField DataField="crscde" HeaderText="COURSE" />
        <asp:BoundField DataField="yrcde" HeaderText="YEAR" />
        <asp:BoundField DataField="trmcde" HeaderText="TERM" />
        
        <asp:BoundField DataField="lastname" HeaderText="Last Name" />
        <asp:BoundField DataField="firstname" HeaderText="First Name" />
        <asp:BoundField DataField="idnum" HeaderText="ID_NUM"  />
        
        <asp:BoundField DataField="load" HeaderText="LOAD" />
        <asp:BoundField DataField="lead" HeaderText="LEAD" />
        </Columns>
    </asp:GridView>
</div>


<script type="text/javascript">
     $(document).ready(function () {
         //$(".gvdatatable").attr("width", "500");
     });
</script>

  <script>
      $(function () {          
          
          $(".gv_coursesPartial").dataTable();
          var table = $(".gv_coursesPartial").dataTable();

          $(".gv_coursesPartial tr:nth-child(even)").addClass("striped");
          

          $('.gv_coursesPartial tbody').on("click", "tr", function () {
              
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
          $("#gv_cp_rowDiv").removeAttr("hidden");


      })
    </script>

  


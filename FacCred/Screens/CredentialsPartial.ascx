<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CredentialsPartial.ascx.cs" Inherits="FacCred.Screens.CredentialsPartial" %>
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

<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css">
<script src="https://code.jquery.com/jquery-1.11.1.min.js"></script> 
<script src="https://cdn.datatables.net/1.10.4/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/jqueryui/dataTables.jqueryui.js"></script>
<link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<link rel="stylesheet" href="https://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/jqueryui/dataTables.jqueryui.css">




<table>
    <tr>
        <td style="color:tomato;">
            <common:subheader id="mainTitle" runat="server" text="CREDENTIALS"></common:subheader>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="searchFacName" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<br />

<%--<div id="gv_CredPartialRowDiv" hidden="hidden" style="width:800px" >
    <asp:GridView ID="gv_CredPartial" runat="server" CssClass="gv_CredPartial" AutoGenerateColumns="false" 
        OnPreRender="gv_CredPartial_PreRender" 
        DataKeyNames="idnum"
        onrowcommand="gv_CredPartial_RowCommand"  
        OnSelectedIndexChanging="gv_CredPartial_IndexChanging" >
        <Columns>
        <asp:BoundField DataField="degree" HeaderText="DEGREE" />
        <asp:BoundField DataField="institution" HeaderText="INSTITUTION" />
        <asp:BoundField DataField="received" HeaderText="RECEIVED" />
        <asp:BoundField DataField="discipline" HeaderText="DISCIPLINE" />
        <asp:BoundField DataField="idnum" HeaderText="IDNUM" />
        </Columns>
    </asp:GridView>
</div>--%>

<asp:Panel ScrollBars="Vertical" Height="500px" runat="server">

    <div id="gv_CredPartialRowDiv" hidden="hidden" style="width:1000px" >
        <asp:GridView ID="gv_CredPartial" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false" 
            OnPreRender="gv_CredPartial_PreRender" 
            DataKeyNames="idnum"
            onrowcommand="gv_CredPartial_RowCommand"  
            OnSelectedIndexChanging="gv_CredPartial_IndexChanging" >
            <Columns>
                <asp:BoundField DataField="facqualno" HeaderText="FACQUAL_NO" Visible="false" />
                <asp:BoundField DataField="lastname" HeaderText="LastName" />
                <asp:BoundField DataField="firstname" HeaderText="FirstName" />
                <asp:BoundField DataField="degree" HeaderText="DEGREE" />
             <%--   <asp:BoundField DataField="institute" HeaderText="INSTITUTE" />--%>
                <asp:BoundField DataField="received" HeaderText="RECEIVED" />
              <%--  <asp:BoundField DataField="discipline" HeaderText="DISCIPLINE" />--%>
                <asp:BoundField DataField="idnum" HeaderText="IDNUM"  />
                <asp:BoundField DataField="qualtxt" HeaderText="QUAL_TXT" />
                <asp:BoundField DataField="highest" HeaderText="Highest" />
              <%--  <asp:BoundField DataField="completeyr" HeaderText="Complete_YR" />--%>
                
            </Columns>
        </asp:GridView>
    </div>

<%--        <div id="rowDiv" hidden="hidden" style="width:1000px" >
        <asp:GridView ID="GridView2" runat="server" CssClass="viewstatedatatable" AutoGenerateColumns="true" 
            OnPreRender="GridView2_PreRender" >
        </asp:GridView>
    </div>--%>

</asp:Panel>

<script type="text/javascript">
     $(document).ready(function () {
         //$(".gvdatatable").attr("width", "500");
     });
</script>

  <script>
      $(function () {          
          
          $(".gv_CredPartial").dataTable();
          var table = $(".gv_CredPartial").dataTable();

          $(".gv_CredPartial tr:nth-child(even)").addClass("striped");
          

          $('.gv_CredPartial tbody').on("click", "tr", function () {
              
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
          $("#gv_CredPartialRowDiv").removeAttr("hidden");


      })
    </script>

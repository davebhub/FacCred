<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacultyNoteArchiveScreen.ascx.cs" Inherits="FacCred.Screens.FacultyNoteArchiveScreen" %>
<%@ Register Assembly="Jenzabar.Portal.Framework.Web" Namespace="Jenzabar.Portal.Framework.Web.UI.Controls" TagPrefix="JENZABAR" %>
<%@ Register src="MainMenu.ascx" TagName="MainMenu" TagPrefix="mom"  %>
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


<div>
<table>
    <tr>
        <td style="color:tomato;width:500px;">
            <common:subheader id="mainTitle" runat="server" text="FACULTY NOTE ARCHIVES"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
        <tr>
        <td >
           <%-- <asp:Label ID="searchFacName" runat="server"></asp:Label>--%>
           <strong> <asp:Label ID="facNoteName" runat="server"></asp:Label></strong>
            <asp:Label ID="lblDiscipline" runat="server"></asp:Label>
        </td>
    </tr>
</table>  
</div>

<div>
    <table>
        <tr>
            <td style="width:600px;">  
                <common:Subheader ID="ArchivedNotes" runat="server" Text="ARCHIVED NOTES"></common:Subheader>
                <asp:Panel ScrollBars="Vertical" Height="400px" Width="1100px" runat="server">                  
                   <%-- <div class="pSection">--%>
                    <div id="rowDiv"  style="width:950px" >                       
                        <asp:GridView ID="gv_ArchivedNotes" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false"  
                                      OnPreRender="gv_ArchivedNotes_PreRender" DataKeyNames="NOTE_ID"   
                                      onrowcommand="gv_ArchivedNotes_RowCommand"                                        
                                      OnSelectedIndexChanging="gv_ArchivedNotes_IndexChanging" >

                            <Columns>                                
                                <asp:ButtonField  CommandName="gv_Restore" Text="Restore" HeaderText="Restore"  ControlStyle-Font-Size="12px" ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"  />                                
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <div style="width: 165px; ">
                                            <%# Eval("SUBJECT") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:BoundField DataField="NOTE" HeaderText="Note" ItemStyle-Width="400px"  /> --%>
                                <asp:TemplateField HeaderText="Note">
                                    <ItemTemplate>
                                        <div style="width: 300px; ">
                                            <%# Eval("NOTE") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:BoundField DataField="NOTE_TYPE" HeaderText="Type" ReadOnly="True" /> --%>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("NOTE_TYPE") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NOTE_LEVEL" HeaderText="Level" ReadOnly="True"/> 
                                <asp:BoundField DataField="DIV_CDE" HeaderText="DIV" ReadOnly="True" />
                                <asp:BoundField DataField="INSTIT_DIV_CDE" HeaderText="InstDiv" ReadOnly="True" />
                                <asp:BoundField DataField="SCHOOL_CDE" HeaderText="SC" ReadOnly="True" />
                                <asp:BoundField DataField="YEARCODE" HeaderText="Year" ReadOnly="True" />
                                <asp:BoundField DataField="TERMCODE" HeaderText="Term" ReadOnly="True" /> 
                                <asp:BoundField DataField="STATUS" HeaderText="Status" ReadOnly="True" />  
                               <%-- <asp:BoundField DataField="APPROVAL_DATE" HeaderText="AprDate" ReadOnly="True" />  --%>
                                <asp:TemplateField HeaderText="AprDate">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("APPROVAL_DATE") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:BoundField DataField="EXPIRATION_DATE" HeaderText="ExpDate" ReadOnly="True" />  --%>
                                <asp:TemplateField HeaderText="ExpDate">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("EXPIRATION_DATE") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="CREATE_DATE" HeaderText="Created" ReadOnly="True" />  --%>
                                <asp:TemplateField HeaderText="Created">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("CREATE_DATE") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:BoundField DataField="CREATE_BY" HeaderText="CreateBy" ReadOnly="True" /> --%> 
                                <asp:TemplateField HeaderText="CreateBy">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("CREATE_BY") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:BoundField DataField="UPDATE_DATE" HeaderText="Updated" ReadOnly="True" /> --%> 
                                <asp:TemplateField HeaderText="Updated">
                                    <ItemTemplate>
                                        <div style="width: 200px; ">
                                            <%# Eval("UPDATE_DATE") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:BoundField DataField="UPDATE_BY" HeaderText="UpdatedBy" ReadOnly="True" />  --%>
                                <asp:TemplateField HeaderText="UpdatedBy">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("UPDATE_BY") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField  CommandName="gv_ArchivedNotes_Delete" Text="Delete" HeaderText="Delete"  ControlStyle-Font-Size="12px" ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"   /> 
                            </Columns>
                        </asp:GridView>                       
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <div>
        <%--        Buttons Table--%>
        <table >  
            <tr>   
                <td>
                    <asp:Button ID="btn_Return" runat="server" Text="Return to Faculty Notes"  
                        onclick="btn_Return_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="400px"  />
                </td>

            </tr>       
        </table>
    </div>

</div>


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
            "iDisplayLength": 100,
            "fixedHeader": true
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

        });

        // these are to stop the flashing of the screen by hiding the loading of the table
        $("#rowDiv").removeAttr("hidden");
    })
</script>
  
<script>
    function myconfirmfunction() {
        var x = '';
        var r = confirm('OK to Delete this Note?');

        if (r) {
            
            return true;
        }
        else {
            return false;
        }
    }
</script>



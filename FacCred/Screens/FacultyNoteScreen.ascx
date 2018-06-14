<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacultyNoteScreen.ascx.cs" Inherits="FacCred.Screens.FacultyNoteScreen" %>
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
            <common:subheader id="mainTitle" runat="server" text="FACULTY NOTE"></common:subheader>
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
            <td style="width:400px;">
                 <table>
                     <tr>
                         <td style="width:5px;"></td>  
                         <td style="text-align:right;"><asp:Label >Note Type:</asp:Label></td>
                         <td style="color:black;"> 
                              <asp:DropDownList ID="ddl_Note_Types" runat="server"  AutoPostBack="false" Width="125px" 
                            OnLoad="ddl_Note_Types_OnLoad"  ForeColor="Black" 
                            OnSelectedIndexChanged="ddl_Note_Types_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" />
                        </td> 
                     </tr>
                     <tr >
                         <td style="width:5px;"></td>  
                         <td style="text-align:right;"><asp:Label >Note Level:</asp:Label></td>
                         <td style="color:black;"> 
                             <asp:DropDownList ID="ddl_Note_levels" runat="server"  AutoPostBack="false" Width="125px" 
                                               OnLoad="ddl_Note_levels_OnLoad"  ForeColor="Black"   
                                               OnSelectedIndexChanged="ddl_Note_levels_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" />
                         </td>
                     </tr>
                     <tr>    
                        <td style="width:5px;"></td>                 
                         <td style="text-align:right;"><asp:Label >Subject:</asp:Label></td>
                         <td style="color:black;"><asp:TextBox ID="txt_Subject" runat="server" Width="250" MaxLength="25" ></asp:TextBox></td>
                        <td></td> 
                    </tr>
                    <tr>
                        <td style="width:5px;"></td>                 
                         <td style="text-align:right;"><asp:Label >Note:</asp:Label></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
                <table >    <%--NOTE EDITOR--%>
                    <tr style="width:400px;">                                        
                        <td style="color:black;">
                            <%--<common:textboxeditor id="txtNote" runat="server" height="225" width="155"  ></common:textboxeditor>--%>
                            <textarea id="txtNote" runat="server" cols="50" rows="8"></textarea>
                            <jenzabar:portletfeedback id="pfFeedBack" runat="server"></jenzabar:portletfeedback>
                        </td>
                        <td></td>
                     </tr>
                     <tr style="height:20px;">
                     </tr>
                </table>
               <table >   

                     <tr >
                         <td style="width:5px;"></td>  
                         <td style="text-align:right;"><asp:Label >Note Status:</asp:Label></td>
                         <td style="color:black;"> 
                              <asp:DropDownList ID="ddl_Status_codes" runat="server"  AutoPostBack="false" Width="125px" 
                            OnLoad="ddl_Status_codes_OnLoad"  ForeColor="Black" 
                            OnSelectedIndexChanged="ddl_Status_codes_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" />
                         </td>
                     </tr>
                     <tr>
                         <td style="width:40px;"></td>  
                         <td style="text-align:right;"><asp:Label >Approval Date:</asp:Label></td>
                         <td style="color:black;">
                             <common:datepicker runat="server" id="dp_Approval_Date" ></common:datepicker>
                         </td> 
                     </tr>
                     <tr>
                         <td style="width:40px;"></td>  
                         <td style="text-align:right;"><asp:Label >Expiration Date:</asp:Label></td>               
                         <td style="color:black;">
                             <common:datepicker runat="server" id="dp_Expiration_Date"  ></common:datepicker>
                         </td>
                     </tr> 
                     <tr></tr>
                </table>
            </td>
            <td style="width:600px;">  
                <common:Subheader ID="Notes" runat="server" Text="NOTES"></common:Subheader>
                <asp:Panel ScrollBars="Vertical" Height="400px" Width="700px" runat="server">                  
                   <%-- <div class="pSection">--%>
                    <div id="rowDiv"  style="width:650px" >                       
                        <asp:GridView ID="gv_Notes" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false"  
                                      OnPreRender="gv_Notes_PreRender" DataKeyNames="NOTE_ID"   
                                      onrowcommand="gv_Notes_RowCommand"                                        
                                      OnSelectedIndexChanging="gv_Notes_IndexChanging" >
                            <Columns>                                
                                <asp:ButtonField  CommandName="gv_Notes_Edit" Text="Edit" HeaderText="Edit" ControlStyle-Font-Size="12px" ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"  />                                
<%--                                <asp:BoundField DataField="SUBJECT" HeaderText="Subject"  /> --%>
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
                                <asp:BoundField DataField="DIV_CDE" HeaderText="DIV" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="INSTIT_DIV_CDE" HeaderText="InstDiv" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="SCHOOL_CDE" HeaderText="SC" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="YEARCODE" HeaderText="Year" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="TERMCODE" HeaderText="Term" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" /> 
                                <asp:BoundField DataField="STATUS" HeaderText="Status" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />  
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
                              <%--  <asp:BoundField DataField="CREATE_BY" HeaderText="CreateBy" ReadOnly="True" /> --%>                   
                                  <asp:TemplateField HeaderText="CreateBy">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("CREATE_BY") %>
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
                              <%--  <asp:BoundField DataField="UPDATE_BY" HeaderText="UpdatedBy" ReadOnly="True" />  --%>
                                <asp:TemplateField HeaderText="UpdatedBy">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("UPDATE_BY") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:BoundField DataField="UPDATE_DATE" HeaderText="Updated" ReadOnly="True" /> --%> 
                                <asp:TemplateField HeaderText="Updated">
                                    <ItemTemplate>
                                        <div style="width: 100px; ">
                                            <%# Eval("UPDATE_DATE") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EXPIRES" HeaderText="EXPIRES" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />  

                                <asp:ButtonField  CommandName="gv_Notes_Archive" Text="Archive" HeaderText="Archive" ControlStyle-Font-Size="12px" ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"  /> 
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
                    <asp:Button ID="btn_Back" runat="server" Text="<-BACK"  
                        onclick="btn_Back_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  />
                </td>
                <td>
                    <asp:Button ID="btn_Save" runat="server" Text="SAVE"  
                        onclick="btn_Save_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  />
                </td>
                <td>
                    <asp:Button ID="btn_Archive" runat="server" Text="Archives"  onclick="btn_Archive_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  />
                </td>
                 <td>
                    <asp:Button ID="btn_Degrees" runat="server" Text="Degrees"  onclick="btn_Degrees_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  />
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
            "fixedHeader": true,
            "rowCallback": function (row, data, index)
            {
                if (data[17] == 'Y') {
                    $(row).css('color','red');
                } 

                if (data[10] == 'P') {
                    $(row).css('color','blue');
                } 

                  
            }
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



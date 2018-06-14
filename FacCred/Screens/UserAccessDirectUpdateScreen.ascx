<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAccessDirectUpdateScreen.ascx.cs" Inherits="FacCred.Screens.UserAccessDirectUpdateScreen" %>
<%@ Register Assembly="Jenzabar.Portal.Framework.Web" Namespace="Jenzabar.Portal.Framework.Web.UI.Controls.Secured" TagPrefix="cc1" %>
<%@ Register Assembly="Jenzabar.Portal.Framework.Web" Namespace="Jenzabar.Portal.Framework.Web.UI.Controls" TagPrefix="JENZABAR" %>
<%--%@ Register Assemble="Jenzabar.Portal.Framework.Web" Namespace="Jenzabar.Portal.Framework.Web.TextEditor"  TagPrefix="jics"  %>  --%>
<%@ Import Namespace="Jenzabar.Common.Globalization" %>
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



<div>
    <mom:MainMenu id="mainMenu" runat="server"></mom:MainMenu>
</div>


<div>
<table>
    <tr>
        <td style="color:tomato;width:500px;">
            <common:subheader id="mainTitle" runat="server" text="USER ACCESS UPDATE"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
        <tr>
        <td >
           <strong> <asp:Label ID="userName" runat="server"></asp:Label> </strong>
        </td>
    </tr>
</table>  
</div>

<div>
    <table>
        <tr>
            <div>
            <td style="width: 400px ">           
                <table>
                <tr>
                    <td>
                        <common:Subheader ID="SelectSchoolCode" runat="server" Text="School Code"  ></common:Subheader> 
                        <asp:DropDownList ID="ddl_SchoolCodes" runat="server"  AutoPostBack="false" Width="225px" 
                                            DataTextField="data" DataValueField="value" />
                    </td>  
                </tr>
                </table>
           </td>   
            </div> 
            
            <div> 
            <td style="width:600px;">  
                <common:Subheader ID="InstDivision" runat="server" Text="SCHOOL CODE ACCESS"></common:Subheader>
                <asp:Panel ScrollBars="Vertical" Height="482px" runat="server">
                    <div id="rowDiv"  style="width:500px" >
                        <asp:GridView ID="gv_DirectAccess" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false" 
                            OnPreRender="gv_DirectAccess_PreRender" 
                            onrowcommand="gv_DirectAccess_RowCommand"  
                            OnSelectedIndexChanging="gv_DirectAccess_IndexChanging"
                            DataKeyNames="USER_ID, ID">
                            <Columns>           
                                <asp:BoundField DataField="LAST_NAME" HeaderText="LastName" />
                                <asp:BoundField DataField="FIRST_NAME" HeaderText="FirstName" />
                                <asp:BoundField DataField="SCHOOL_CDE" HeaderText="SchoolCode" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="blue"/>               
                                <asp:ButtonField  CommandName="gv_DirectAccess_Remove" Text="REMOVE"  ControlStyle-Font-Size="13px"  ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"  />                                               
                            </Columns>
                        </asp:GridView>   
                    </div>
                </asp:Panel>
            </td>
            </div>
        </tr>
    </table>

    <div>
        <%-- Buttons Table --%>
        <table >  
            <tr>   
                <td>
                    <asp:Button ID="btn_Back" runat="server" Text="<-BACK"  
                        onclick="btn_Back_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  />
                </td>
                <td>
                    <asp:Button ID="btn_ADD" runat="server" Text="ADD"  
                        onclick="btn_ADD_Click" Enabled="true" ControlStyle-CssClass="globalizedbutton" Width="125px"  />
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
            "iDisplayLength": 10,
            "fixedHeader" : true
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

        });

        // these are to stop the flashing of the screen by hiding the loading of the table
        $("#rowDiv").removeAttr("hidden");
    
    })
</script>

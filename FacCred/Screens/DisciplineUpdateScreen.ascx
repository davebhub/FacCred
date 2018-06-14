<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DisciplineUpdateScreen.ascx.cs" Inherits="FacCred.Screens.DisciplineUpdateScreen" %>
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
            <common:subheader id="mainTitle" runat="server" text="FACULTY XREF UPDATE"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
        <tr>
        <td >
           <strong> <asp:Label ID="facName" runat="server"></asp:Label></strong>
        </td>
    </tr>
</table>  
</div>

<div>
    <table>
        <tr>
        <td style="width: 400px">           
            <table>
            <tr>
                <td>
                    <common:Subheader ID="SelectDivision" runat="server" Text="Division"></common:Subheader> 
                    <asp:DropDownList ID="ddl_Divisions" runat="server"  AutoPostBack="false" Width="225px" 
                                       DataTextField="data" DataValueField="value" />
                </td>  
            </tr>
            <tr>
                <td>
                        <common:Subheader ID="SelectInstDiv" runat="server" Text="InstDiv"></common:Subheader> 
                        <asp:DropDownList ID="ddl_InstDiv" runat="server"  AutoPostBack="false" Width="225px" 
                            OnLoad="ddl_InstDiv_OnLoad"   
                            OnSelectedIndexChanged="ddl_InstDiv_OnSelectedIndexChanged"  DataTextField="data" DataValueField="value" />
                </td>  
            </tr>
            <tr>
                <td>
                    <common:Subheader ID="SelectSchoolCode" runat="server" Text="School Code"></common:Subheader> 
                    <asp:DropDownList ID="ddl_SchoolCodes" runat="server"  AutoPostBack="false" Width="225px" 
                                        DataTextField="data" DataValueField="value" />
                </td>  
            </tr>               

            </table>
       </td>        
            <td style="width:600px;">  
                <common:Subheader ID="Disciplines" runat="server" Text="CURRENT DISCIPLINES"></common:Subheader>
                <asp:Panel ScrollBars="Vertical" Height="300px"  runat="server">                  
                    <div class="pSection">
	                    <common:GroupedGrid ID="ggDisciplines" runat="server" DataKeyField="ID" RenderGroupHeaders="True">
		                    <EmptyTableTemplate>
    			                <%= Globalizer.GetGlobalizedString("FACCRED_NO_DISCIPLINES_FOUND") %>
		                    </EmptyTableTemplate>
		                    <Columns>
                                <asp:TemplateColumn HeaderText="DIV_CDE">
				                    <ItemTemplate>
					                    <%# DataBinder.Eval(Container.DataItem, "DIV_CDE") %>  
				                    </ItemTemplate>
			                    </asp:TemplateColumn>                            
                                <asp:TemplateColumn HeaderText="INST_DIV">
				                    <ItemTemplate>
					                    <%# DataBinder.Eval(Container.DataItem, "INSTIT_DIV_CDE") %>  
				                    </ItemTemplate>
			                    </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="SCHOOL_CDE">
				                    <ItemTemplate>
					                    <%# DataBinder.Eval(Container.DataItem, "SCHOOL_CDE") %>  
				                    </ItemTemplate>
			                    </asp:TemplateColumn>


			                    <common:DeleteButtonColumn  />           
		                    </Columns>
	                    </common:GroupedGrid>
                    </div>
                </asp:Panel>
            </td>
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
</script>


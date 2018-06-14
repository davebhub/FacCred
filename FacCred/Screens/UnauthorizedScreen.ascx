<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UnauthorizedScreen.ascx.cs" Inherits="FacCred.Screens.UnauthorizedScreen" %>
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

<script src="scripts/css/style.css" type="css" ></script>

<link href="https://code.jquery.com/ui/1.12.0/themes/overcast/jquery-ui.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css">

<div>
    <mom:MainMenu id="mainMenu" runat="server"></mom:MainMenu>
</div>

<table>
    <tr>
        <td style="color:tomato;width:500px;">
            <common:subheader id="Subheader3" runat="server" text="UNAUTHORIZED "></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
</table>


<div id="JUIdiv"  >
<button id="open"  >open dialog box</button>
    <input id="button2" type="submit" value="a submit button" />
    <button id="button3" runat="server" CssClass="gvdatatable">three</button>
        <button id="button4" runat="server" CssClass="globalizedbutton">three</button>
        <button id="button6" runat="server" >three</button>

    <div id="button5">
        <input type="checkbox" id="check1" />
        <label for="check1">Left</label>
        <input type="checkbox" id="check2" />
        <label for="check2">Middle</label>
        <input type="checkbox" id="check3" />
        <label for="check3">Right</label>
    </div>



</div>
        
<div id="dialog" title="Loading . . ."  >
    <asp:Image ImageUrl="~/UI/Common/Images/PortletImages/Lightbox/loading.gif" runat="server" ImageAlign="Middle" />     
</div>

<script>
    $(document).ready(function () {
        $(function () {
            console.log('false');
            $("#dialog").dialog({
                autoOpen: false,
                title: 'Loading . . .'
            });
        });

        $("button").click(function () {
            console.log("click");
            $(this).hide();
            $("#dialog").dialog('open');
        });
    });
</script>

<script type="text/javascript">
    $(window).load(function () {
        $(".loader").fadeOut("slow");
    })
</script>





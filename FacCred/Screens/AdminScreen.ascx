<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminScreen.ascx.cs" Inherits="FacCred.Screens.AdminScreen" %>
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
#divLoading
{
display : none;
}
#divLoading.show
{
display : block;
position : fixed;
z-index: 100;
background-image : url('http://loadinggif.com/images/image-selection/3.gif');
background-color:#666;
opacity : 0.4;
background-repeat : no-repeat;
background-position : center;
left : 0;
bottom : 0;
right : 0;
top : 0;
}
#loadinggif.show
{
left : 50%;
top : 50%;
position : fixed;
z-index : 101;
width : 32px;
height : 32px;
margin-left : -16px;
margin-top : -16px;
}
div.content {
width : 1000px;
height : 1000px;
}
</style>

<div id="divLoading"> 
</div>

<%--<div id="workingDiv">
    <br />
    <string style="color:red">loading, please wait  . . .  </string>
    <asp:Image ID="Image1" runat="server"  ImageUrl="~/UI/Common/Images/PortletImages/Lightbox/loading.gif" />
</div>--%>

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

<table>
    <tr></tr>
    <tr>
        <td style="color:tomato;width:500px;">
            <common:subheader id="Subheader1" runat="server" text="CREDENTIALS"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>

</table>

<asp:Panel ScrollBars="Vertical" Height="482px" runat="server">
<div id="credButtonsDiv"  style="width:1000px" >
    <table>
        <tr>

            <td>
                <table>
                    <tr>
                        <%--<td style="width:150px;height:150px;" ></td>--%>
                        <td >
                             <common:Globalizedbutton id="notes_btn"  runat="server" text="NOTE TYPES" class="globalizedbutton"  OnClick="LoadNotesScreen" style="width:150px;height:150px;"    ></common:Globalizedbutton>
                        </td>
                        <td style="width:150px;height:150px;">
                             <common:Globalizedbutton id="archive_btn"  runat="server" text="" class="globalizedbutton" style="width:150px;height:150px;"  ></common:Globalizedbutton>
                        </td>
                        <td style="width:150px;height:150px;">
                             <common:Globalizedbutton id="Globalizedbutton5"  runat="server" text="" class="globalizedbutton"  style="width:150px;height:150px;"    ></common:Globalizedbutton>
                        </td>
                    </tr>
                    <tr>
                        <%--<td style="width:150px;height:150px;" ></td>--%>
                        <td style="width:150px;height:150px;">
                             <common:Globalizedbutton id="coursesBtn"  runat="server" text="" class="globalizedbutton" style="width:150px;height:150px;"      ></common:Globalizedbutton>
                        </td>
                        <td style="width:150px;height:150px;">
                             <common:Globalizedbutton id="Globalizedbutton1"  runat="server" text="" class="globalizedbutton"  style="width:150px;height:150px;"    ></common:Globalizedbutton>
                        </td>
                        <td style="width:150px;height:150px;">
                             <common:Globalizedbutton id="Globalizedbutton4"  runat="server" text="" class="globalizedbutton"  style="width:150px;height:150px;"     ></common:Globalizedbutton>
                        </td>
                    </tr>
                    <tr>
                       <%-- <td style="width:150px;height:150px;" ></td>--%>
                        <td style="width:150px;height:150px;">
                             <common:Globalizedbutton id="Globalizedbutton6"  runat="server" text="" class="globalizedbutton"  style="width:150px;height:150px;"     ></common:Globalizedbutton>
                        </td>
                        <td style="width:150px;height:150px;">
                             <common:Globalizedbutton id="Globalizedbutton7"  runat="server" text="" class="globalizedbutton"  style="width:150px;height:150px;"    ></common:Globalizedbutton>
                        </td>
                        <td style="width:150px;height:150px;">
                             <common:Globalizedbutton id="Globalizedbutton8"  runat="server" text="" class="globalizedbutton"  style="width:150px;height:150px;"   ></common:Globalizedbutton>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width:75px;"></td>
            <td style="text-align:start;">
                <table>
                    <tr>
                        <td> 
                            <strong>FacCred Administration</strong> 
                            <br /><br />
                                Use this page to administer <br />
                                the system by selecting an area <br />
                                from the buttons on the left                           
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
   
</div>
</asp:Panel>


<script type="text/javascript">
    $(window).load(function () {
        //$("div#divLoading").addClass('show');
        $(".loader").fadeOut("slow");
    })

    $(document).ready(function () {
        //$("#workingDiv").attr("hidden", "true");
    });


    $(function showLoading() {
        //      $("div#divLoading").addClass('show');
    })

    $(function hideLoading() {
        $("div#divLoading").addClass('hide');
    })
</script>


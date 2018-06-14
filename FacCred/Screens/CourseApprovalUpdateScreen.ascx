<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseApprovalUpdateScreen.ascx.cs" Inherits="FacCred.Screens.CourseApprovalUpdateScreen" %>
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
            <common:subheader id="mainTitle" runat="server" text="COURSE APPROVAL UPDATE"></common:subheader>
        </td>
        <td>
            <p>
                You are currently logged in as : <strong><asp:Label ID="txt_sessionUserLevel" runat="server" BorderStyle="None"/></strong>
            </p>
        </td>
    </tr>
        <tr>
        <td >
           <strong> <asp:Label ID="facNoteName" runat="server"></asp:Label></strong>
        </td>
    </tr>
    <tr style="height: 20px"></tr>
</table>  
</div>

<div  style="width:300px;">
    <table style="width:300px;">
        <tr>
            
            <td style="height:10px;"></td>
            <td style="width:300px;">
                 <table style="width:300px;">
                     <tr>
                        <td ><asp:Button ID="btn_Division_Save" runat="server" Text="Division Save"  ControlStyle-CssClass="globalizedbutton" Width="200px" OnClick="btn_Division_Save_Click" /></td>
                    </tr>  
                     <tr>
                         <td ><asp:Button ID="btn_InstDiv_Save" runat="server" Text="InstDiv Save"  ControlStyle-CssClass="globalizedbutton" Width="200px" OnClick="btn_InstDiv_Save_Click" /></td>
                     </tr> 
                     <tr>
                         <td ><asp:Button ID="btn_SchoolCode_Save" runat="server" Text="SchoolCode Save"  ControlStyle-CssClass="globalizedbutton" Width="200px" OnClick="btn_SchoolCode_Save_Click" /></td>
                     </tr> 

                </table>
                <table style="width:300px;">
                     <tr style="height: 30px"></tr>
                    <tr style="width:300px;">
                        <td style="text-align:right; width: 100px;"><asp:Label runat="server" ><Strong>DIVISION:</Strong></asp:Label></td>
                        <td style="text-align:left; width: 200px;"> 
                            <asp:TextBox runat="server" id="txt_Division" ReadOnly="True" Width="50"></asp:TextBox>
                        </td> 
                    </tr> 
                    <tr style="width:300px;">
                         <td style="text-align:right; width: 100px;"><asp:Label runat="server" ><Strong>INST_DIV:</Strong></asp:Label></td>
                         <td style="text-align:left; width: 200px;"> 
                              <asp:TextBox runat="server" id="txt_InstDiv" ReadOnly="True" Width="50"></asp:TextBox>
                        </td> 
                     </tr>   
                    <tr style="width:300px;">
                        <td style="text-align:right; width: 100px;"><asp:Label runat="server" ><Strong>SCHOOL_CODE:</Strong></asp:Label></td>
                        <td style="text-align:left; width: 200px;"> 
                            <asp:TextBox runat="server" id="txt_SchoolCode" ReadOnly="True" Width="50"></asp:TextBox>
                        </td> 
                    </tr>

                </table>
                <%-- CRS and TITLE  --%>
                <table>
                    <tr style="height: 30px"></tr>
                    <tr style="width:300px;">
                        <td style="text-align:right; width: 40px;"><asp:Label runat="server" ><Strong>CRS:</Strong></asp:Label></td>
                        <td style="text-align:left; width: 230px;"> 
                            <asp:TextBox runat="server" id="txt_CRS" ReadOnly="True" Width="230"></asp:TextBox>
                        </td> 
                    </tr>
                    <tr style="width:300px;">
                        <td style="text-align:right; width: 40px;"><asp:Label runat="server" ><Strong>TITLE:</Strong></asp:Label></td>
                        <td style="text-align:left; width: 230px;"> 
                            <asp:TextBox runat="server" id="txt_TITLE" ReadOnly="True" Width="230"></asp:TextBox>
                        </td> 
                    </tr>
                </table>  
                <table>
                    <tr style="height: 25px"></tr>
                </table>

                <table>
                    <tr style="height: 25px"></tr>
                     <tr >
                         <td>
                             <label style="text-align:left;" ><Strong>Approval Status: </Strong></label>
                             <asp:DropDownList ID="ddl_Approval_Status" runat="server"  AutoPostBack="false" Width="200px" 
                                               OnLoad="ddl_Approval_Status_OnLoad"  ForeColor="Black" 
                                               OnSelectedIndexChanged="ddl_Approval_Status_OnSelectedIndexChanged"  
                                               DataTextField="data" DataValueField="value" >
                             </asp:DropDownList>
                         </td>                   
                     </tr>                
                 </table>
            </td>

            <td style="width:600px;">  
                <common:Subheader ID="Approvals" runat="server" Text="Approvals"></common:Subheader>
                <asp:Panel ScrollBars="Vertical" Height="400px" Width="700px" runat="server">                  
                    <div id="rowDiv"  style="width:650px" >                       
                        <asp:GridView ID="gv_Your_Approvals" runat="server" CssClass="gvdatatable" AutoGenerateColumns="false"  
                                      DataKeyNames="FACidnum,FACappid,SM_appid"                                        
                                      OnPreRender="gv_Your_Approvals_PreRender"   
                                      onrowcommand="gv_Your_Approvals_RowCommand"                                 
                                      EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True">
                            <Columns>                                
                                <asp:ButtonField  CommandName="gv_Your_Approvals_Edit" Text="Edit" HeaderText="Edit" ControlStyle-Font-Size="12px" ControlStyle-CssClass="globalizedbutton"  ControlStyle-Font-Underline="false" ItemStyle-HorizontalAlign="Center"  />                                
                                <asp:BoundField DataField="Approver" HeaderText="Approval" ReadOnly="True" ItemStyle-ForeColor="Blue"  ItemStyle-HorizontalAlign="Center"  /> 
                                <asp:BoundField DataField="crscde" HeaderText="CRS" ReadOnly="True"/> 
                                <asp:BoundField DataField="CRStitle" HeaderText="Title" ReadOnly="True"/> 
                                <asp:BoundField DataField="yearcode" HeaderText="Year" ReadOnly="True"/> 
                                <asp:BoundField DataField="termcode" HeaderText="Term" ReadOnly="True" />
                                <asp:BoundField DataField="divcode" HeaderText="DIV" ReadOnly="True"  ItemStyle-HorizontalAlign="Center" />   
                                <asp:BoundField DataField="instdiv" HeaderText="InstDIV" ReadOnly="True"   ItemStyle-HorizontalAlign="Center"  />
                                <asp:BoundField DataField="schoolcode" HeaderText="SC" ReadOnly="True"  ItemStyle-HorizontalAlign="Center" />
                            </Columns>
                        </asp:GridView>                       
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <div>
        <%-- Buttons Table--%>
        <table >  
            <tr style="height: 20px"></tr>
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
                    <asp:Button ID="btn_Faculty_Notes" runat="server" Text="Faculty Notes"  onclick="btn_Faculty_Notes_Click" Visible="False" ControlStyle-CssClass="globalizedbutton" Width="125px"  />
                </td>
                <td style="width:300px">
                    <common:ErrorDisplay ID="errMsg" runat="server" Visible="False" ></common:ErrorDisplay>
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

            'rowCallback': function (row, data, index) {
                if (data[1].toUpperCase() == 'A') {
                    $(row).find('td:eq(1)').css('color', '#3dc902');
                }
                if (data[1].toUpperCase() == 'R') {
                    $(row).find('td:eq(1)').css('color', 'red');
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



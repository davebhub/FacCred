<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="FacCred.Screens.MainMenu" %>
<%@ Register Assembly="Jenzabar.Common" Namespace="Jenzabar.Common.Web.UI.Controls" TagPrefix="common" %>

<%--background-color:#036534  green;
background-color:#265B8C  blue  ;--%>


<style type="text/css" >
.globalizedbutton
{
    width:105px;
    height: 30px;
    background-color:#036534;
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
    background-color:#036534;
}
</style>


<div class="buttonBar">
<common:Globalizedbutton id="facultyBtn"  runat="server" text="FACULTY" class="globalizedbutton"    OnClick="LoadFacultyScreen" width="125px"  ></common:Globalizedbutton>
<common:Globalizedbutton id="facultyApprovalBtn"  runat="server" text="ApproveFaculty" class="globalizedbutton"    OnClick="LoadFacultyApprovalScreen" width="150px" Visible="True"  ></common:Globalizedbutton>    
<%-- <common:Globalizedbutton id="eduEarnHistBtn"  runat="server" text="EDU_EARN_HIST"  class="globalizedbutton"   OnClick="LoadEduEarnHistScreen" width="125px"  ></common:Globalizedbutton> --%>   
<%-- <common:Globalizedbutton id="coursesBtn"  runat="server" text="COURSES"  class="globalizedbutton"   OnClick="LoadCoursesScreen" width="125px"  ></common:Globalizedbutton> --%>  
<common:Globalizedbutton id="courseApprovalBtn"  runat="server" text="ApproveCourses" class="globalizedbutton"    OnClick="LoadCourseApprovalScreen" width="150px" Visible="True" ></common:Globalizedbutton>
<common:Globalizedbutton id="statusBtn"  runat="server" text="STATUS" class="globalizedbutton"    OnClick="LoadStatusScreen" width="100px" ></common:Globalizedbutton>   
 <common:Globalizedbutton id="userAccessBtn"  runat="server" text="USER ACCESS"  class="globalizedbutton"   OnClick="LoadUserAccessScreen" width="150px" ></common:Globalizedbutton>
<%-- <common:Globalizedbutton id="junkBtn"  runat="server" text="Junk"  class="globalizedbutton"   OnClick="LoadUnautorizedScreen"  ></common:Globalizedbutton>--%>
<%-- <common:Globalizedbutton id="catalogBtn"  runat="server" text="CATALOG"  class="globalizedbutton"   OnClick="LoadCatalogScreen" ></common:Globalizedbutton>--%>
<%-- <common:Globalizedbutton id="approvalsBtn"  runat="server" text="APPROVALS" class="globalizedbutton"    OnClick="LoadApprovalsScreen" width="150px"  ></common:Globalizedbutton>--%>
<%-- <common:Globalizedbutton id="credentialsBtn"  runat="server" text="CREDENTIALS" class="globalizedbutton"    OnClick="LoadCredentialsScreen" width="150px" ></common:Globalizedbutton>--%>
<%-- <common:Globalizedbutton id="updateBtn"  runat="server" text="UPDATE" class="globalizedbutton"    OnClick="LoadUpdateScreen"  ></common:Globalizedbutton>--%>
<%-- <common:Globalizedbutton id="reportsBtn"  runat="server" text="REPORTS" class="globalizedbutton"    OnClick="LoadReportsScreen" width="100px" Visible="True" ></common:Globalizedbutton> --%>
<%-- <common:Globalizedbutton id="adminBtn"  runat="server" text="ADMIN"  class="globalizedbutton"   OnClick="LoadAdminScreen" ></common:Globalizedbutton>--%>

    

    <%--the following line is used as a spacer between the menu items and the drop down lists.--%>
    <asp:Label ID="Label1" runat="server" Text="" Width="100px" BorderStyle="None"/>

    <label  style="width:auto;color:white" >YEAR:</label>
    <asp:DropDownList ID="DropDownList_year" runat="server"  AutoPostBack="true" Width="75px" 
        OnLoad="DropDownList_year_OnLoad"  
        OnSelectedIndexChanged="ddl_year_OnSelectedIndexChanged"   DataTextField="data" DataValueField="value" >
    </asp:DropDownList>

    <label  style="width:auto;color:white" >TERM:</label>
    <asp:DropDownList ID="DropDownList_term" runat="server"  AutoPostBack="true" Width="75px"  
        OnLoad="DropDownList_term_OnLoad"  
        OnSelectedIndexChanged="ddl_term_OnSelectedIndexChanged"   DataTextField="data" DataValueField="value" >
    </asp:DropDownList>
</div>

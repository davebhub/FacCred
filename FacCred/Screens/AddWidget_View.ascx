<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddWidget_View.ascx.cs" Inherits="FacCred.Screens.AddWidget_View" %>
<%@ Register Assembly="Jenzabar.Common" Namespace="Jenzabar.Common.Web.UI.Controls" TagPrefix="common" %>

<style type="text/css">
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



<common:subheader id="Add_WidgetView" runat="server" text="Add_WidgetView"></common:subheader>
<div class="buttonBar"  >
    <common:Globalizedbutton id="homeBtn"     runat="server" text="HOME"   class="globalizedbutton"     OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="facultyBtn"  runat="server" text="FACULTY"  class="globalizedbutton"   OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="coursesBtn"  runat="server" text="COURSES"  class="globalizedbutton"   OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="widgetsBtn"  runat="server" text="WIDGETS"  class="globalizedbutton"   OnClick="LoadNextView" ></common:Globalizedbutton>
</div>

<br />
<strong>Hello from the Add_WidgetView</strong>
<br />
<div class="fieldset">
    <asp:TextBox ID="IDtxt" runat="server">ID</asp:TextBox><br />
    <asp:TextBox ID="NAMEtxt" runat="server">NAME</asp:TextBox><br />
    <asp:TextBox ID="DESCtxt" runat="server">Description</asp:TextBox><br /><br />
    <common:globalizedbutton id="btnSave" runat="server" text="Save"     onClick="btnSave_clicked"  ></common:globalizedbutton>
    <common:globalizedbutton id="btnFetch" runat="server" text="Fetch"   onClick="btnFetch_clicked"  ></common:globalizedbutton><br />
</div>
<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="WidgetID" onrowcommand="GridView3_RowCommand"  >
        <Columns>
        <asp:BoundField  DataField="WidgetID" HeaderText="WidgetID" />
        <asp:BoundField  DataField="Name" HeaderText="Name" />
        <asp:BoundField  DataField="Description" HeaderText="Description"/>
        <asp:BoundField  DataField="PortletID" HeaderText="PortletID"/>
        <asp:BoundField  DataField="UserID" HeaderText="UserID"/> 
        <asp:ButtonField CommandName="View" HeaderText="Details" ShowHeader="true" Text="View" />
        <asp:ButtonField CommandName="EditRow" Text="Edit"  />
        <asp:ButtonField CommandName="DeleteRow" Text="Delete"  />
    </Columns>
    <HeaderStyle BackColor="LightGray" />
    <AlternatingRowStyle BackColor="#E0E0E0" />
</asp:GridView>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataTableTest.ascx.cs" Inherits="FacCred.Screens.DataTableTest" %>
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



<common:subheader id="DataTbl" runat="server" text="Data Table Test"></common:subheader>
<div class="buttonBar"  >
    <common:Globalizedbutton id="homeBtn"     runat="server" text="HOME"   class="globalizedbutton"     OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="facultyBtn"  runat="server" text="FACULTY" class="globalizedbutton"    OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="coursesBtn"  runat="server" text="COURSES"  class="globalizedbutton"   OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="widgetsBtn"  runat="server" text="WIDGETS" class="globalizedbutton"    OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="eduHistBtn"  runat="server" text="EDUEarnHist"  class="globalizedbutton"   OnClick="LoadNextView" ></common:Globalizedbutton>
</div>
<br /><br />
<strong>Hello World! from DataTableTest</strong>
<br />
 <asp:GridView ID="grdDegrees" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="facqual_no">
    <Columns>
 

        <asp:BoundField DataField="facqual_no" HeaderText="facqual_no" Visible="False" />
        <asp:BoundField DataField="idnum" HeaderText="ID_NUM" />
        <asp:BoundField DataField="degree" HeaderText="Degree" />
        <asp:BoundField DataField="institution" HeaderText="Granting Institution" />
        <asp:BoundField DataField="received" HeaderText="Received" />
        <asp:BoundField DataField="discipline" HeaderText="Discipline" />   
   
        <asp:ButtonField CommandName="View" HeaderText="Details" ShowHeader="True" Text="View" />
        <asp:ButtonField CommandName="Edit" Text="Edit" />
        <asp:ButtonField CommandName="Delete" Text="Delete" />
    </Columns>
    <HeaderStyle BackColor="LightGray" />
    <AlternatingRowStyle BackColor="#E0E0E0" />
</asp:GridView>


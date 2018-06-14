<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Widget.ascx.cs" Inherits="FacCred.Screens.Widget" %>
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
    <common:Globalizedbutton id="homeBtn"     runat="server" text="HOME"    class="globalizedbutton"    OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="facultyBtn"  runat="server" text="FACULTY"  class="globalizedbutton"   OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="coursesBtn"  runat="server" text="COURSES"  class="globalizedbutton"   OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="studentsBtn" runat="server" text="STUDENTS"  class="globalizedbutton"  OnClick="LoadNextView" ></common:Globalizedbutton>
    <common:Globalizedbutton id="widgetsBtn"  runat="server" text="WIDGETS"  class="globalizedbutton"   OnClick="LoadNextView" ></common:Globalizedbutton>
</div>


<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="APPID" >
        <Columns>
        <asp:BoundField  DataField="APPID" HeaderText="APPID" />
        <asp:ButtonField CommandName="View" HeaderText="Details" ShowHeader="true" Text="View" />
        <asp:ButtonField CommandName="EditRow" Text="Edit"  />
        <asp:ButtonField CommandName="DeleteRow" Text="Delete"  />
    </Columns>
    <HeaderStyle BackColor="LightGray" />
    <AlternatingRowStyle BackColor="#E0E0E0" />
</asp:GridView>


<div class="pSection">
    <fieldset>
        <table>
            <tr>
                <th>
                    Name:
                </th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Description:
                </th>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="200" Columns="20" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>              
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_clicked" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>             
            </tr>
            
        </table>
    </fieldset>

</div>
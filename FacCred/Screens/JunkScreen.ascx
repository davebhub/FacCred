<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JunkScreen.ascx.cs" Inherits="FacCred.Screens.JunkScreen" %>
<%@ Import Namespace="Jenzabar.Common.Globalization" %>
<%@ Register Assembly="Jenzabar.Common" Namespace="Jenzabar.Common.Web.UI.Controls" TagPrefix="common" %>
<%@ Register src="MainMenu.ascx" TagName="MainMenu" TagPrefix="mom"  %>

<cc1:Subheader ID="Subheader1" runat="server" RenderGroupHeaders="True" ></cc1:Subheader>
<div class="pSection">
    <cc1:GroupedGrid ID=" ggNotes" runat="server" RenderGroupHeaders="True" >
        <Columns>
            <common:EditButtonColumn />
            <common:DeleteButtonColumn />
            <asp:TemplateColumn>
                <ItemTemplate>
                    <asp:Label>stuff</asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </cc1:GroupedGrid>
</div>

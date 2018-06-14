<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FACCRED_SSRS_Faculty.aspx.cs" Inherits="FacCred.Reports.FACCRED_SSRS_Faculty" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Import Namespace="GCUserLookupService.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import namespace="GCUserLookupService.Security" %>  
  <script type="text/javascript" src="/ics/Portlets/CUS/ICS/GCUserLookupService/GCUserLookup.js"></script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/ics/ClientConfig/styles/jquery-ui/1.9.2/jquery-ui-1.9.2.custom.min.css" />
</head>
<script type="text/javascript">
    jQuery(function ($) {
        resizeReport(jQuery('#<%= ReportViewer1.ClientID %>'));
        var lookupField = jQuery('#<%= ReportViewer1.ClientID %>').find('input[value^="LookupQuery-"]').first();
        if (lookupField.val() != undefined) {
            var indx = lookupField.val().indexOf('-', 0) + 1;
            var lookup = lookupField.val().substr(indx, lookupField.val().length - indx);

            jQuery('#reportInfo').data('parameterid', jQuery(lookupField).attr('id'));
            jQuery('#reportInfo').data('parameterlookup', jQuery(lookupField).attr('id'));
            setupLookupParameter(lookup);
            setInterval(function () {
                setupLookupParameter(lookup);
                
            }, 1000);
        }
    });

    function setupLookupParameter(lookup) {
        var cntrlId = jQuery('#reportInfo').data('parameterid');
        var cntrl = jQuery('#' + cntrlId);
        if (jQuery(cntrl).data("lookupenabled") != 'true') {
            GCUserLookup(cntrl, cntrl, lookup, '<%= ClientEncryption.Encrypt(PortletGuid) %>');
            jQuery(cntrl).data("lookupenabled", "true");
            console.log(jQuery(cntrl).val());
            if (jQuery(cntrl).val().indexOf("LookupQuery", 0) > -1) {
                jQuery(cntrl).val("");
            }
            var spanCntrl = jQuery('#<%= ReportViewer1.ClientID %>').find('span:contains("NoAutoRun")');
            if (spanCntrl != undefined) {
                spanCntrl.parent().next().find('input').hide();
                spanCntrl.hide();
            }
        }
    }

    function resizeReport(element) {
		if(navigator.userAgent.toLowerCase().indexOf('webkit') > -1)
		{
			var reportViewerCntrl = element;
			if(reportViewerCntrl.height() == 100){
				reportViewerCntrl.height("122px");
			}
			var reportHeight = jQuery('#ReportViewer1_ctl10').height();
			var scrollHeight =jQuery('#ReportViewer1_ctl10')[0].scrollHeight;
			if(scrollHeight > reportHeight)
			{
				jQuery('#ReportViewer1_ctl10').height(scrollHeight);
				reportViewerCntrl.height(scrollHeight + 100);
			}
			setTimeout(function() { resizeReport(element) }, 1000);
		}
	}
</script>

<body style="margin: 0px">
    <form id="form1" runat="server">
    <div id="reportInfo"></div>        
    <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
    	<asp:Panel ID="pnlMessage" runat="server" Visible="false">
        <div style="background-color: #FFC2C2; 
                background-image: url('/ics/ui/common/images/portletimages/icons/32/error.png'); 
                background-repeat: no-repeat;
                border: 2px solid red;
                margin: 20px;
                padding: 10px 10px 10px 35px;">
		    <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </div>
		<br />
	</asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" ProcessingMode="Remote"  
                Width="100%" Height="100%" Enabled="true">
            </rsweb:ReportViewer>
        </div>
    </asp:Panel>
    </form>
</body>
</html>

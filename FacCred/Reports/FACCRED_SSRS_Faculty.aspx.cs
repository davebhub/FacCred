using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Microsoft.Reporting.WebForms;
using Jenzabar.Common;
using Jenzabar.ICS.Web.Portlets.Common;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Framework.Security;
using Jenzabar.Portal.Framework.Configuration;
using Jenzabar.Portal.Framework.Facade;
using Jenzabar.Portal.Framework.Services;
using Jenzabar.Portal.Framework.Web.UI;
using LiteralStringReplacer.Facade;

namespace FacCred.Reports
{
    public partial class FACCRED_SSRS_Faculty : System.Web.UI.Page
    {
        public string PortletGuid { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            IPortalContextFacade contextFacade = ObjectFactoryWrapper.GetInstance<IPortalContextFacade>();
            IPortletFacade portletFacade = ObjectFactoryWrapper.GetInstance<IPortletFacade>();



            if (Request.QueryString["DN"] != null)
            {
                String dn = HttpUtility.UrlDecode(Request.QueryString["DN"].ToString());

                Portlet p = portletFacade.FindByDN(dn);

                PortletGuid = p.PortletTemplate.Guid.ToString();

                if (p.ParentPage.CanView(PortalUser.Current))
                {
                    Panel1.Visible = true;
                    if (!IsPostBack)
                    {
                        loadControlOptions(p);
                        loadCredentials();
               //--DRB         //setParameters(p);
                    }
                }
                else
                {
                    //Response.Write("You do not have access to this page");
                    litMessage.Text = "You do not have access to this page";
                    Panel1.Visible = false;
                    pnlMessage.Visible = true;
                }
            }
            else
            {
                litMessage.Text = "DN Not Defined";
                Panel1.Visible = false;
                pnlMessage.Visible = true;
            }
        }

        private void loadCredentials()
        {
            MyReportServerCredentials rvc = new MyReportServerCredentials();
            ReportViewer1.ServerReport.ReportServerCredentials = rvc;
        }


        private void loadControlOptions(Portlet portlet)
        {
            string server = PortletUtilities.GetSettingValue(portlet, "SSRSReportServer");
            string location = PortletUtilities.GetSettingValue(portlet, "SSRSReportLocation");
            string height = PortletUtilities.GetSettingValue(portlet, "SSRSMaxFrameHeight");
            string tmp_displayControls = PortletUtilities.GetSettingValue(portlet, "SSRShideControls");
            string[] displayControls;
            if (tmp_displayControls != null && tmp_displayControls != "")
            {
                displayControls = tmp_displayControls.Split(';');

                // If set in admin settings, show/hide controls.
                if (displayControls.Count() >= 12)
                {
                    foreach (string control in displayControls)
                    {
                        string[] tmp = control.Split(',');
                        tmp[0] = tmp[0].TrimStart('[');
                        tmp[1] = tmp[1].TrimEnd(']');
                        bool visibility = Boolean.Parse(tmp[1]);
                        switch (tmp[0])
                        {
                            case "ShowBackButton":
                                if (visibility)
                                    ReportViewer1.ShowBackButton = true;
                                else
                                    ReportViewer1.ShowBackButton = false;
                                break;
                            case "ShowCredentialPrompts":
                                if (visibility)
                                    ReportViewer1.ShowCredentialPrompts = true;
                                else
                                    ReportViewer1.ShowCredentialPrompts = false;
                                break;
                            case "ShowDocumentMapButton":
                                if (visibility)
                                    ReportViewer1.ShowDocumentMapButton = true;
                                else
                                    ReportViewer1.ShowDocumentMapButton = false;
                                break;
                            case "ShowExportControls":
                                if (visibility)
                                    ReportViewer1.ShowExportControls = true;
                                else
                                    ReportViewer1.ShowExportControls = false;
                                break;
                            case "ShowFindControls":
                                if (visibility)
                                    ReportViewer1.ShowFindControls = true;
                                else
                                    ReportViewer1.ShowFindControls = false;
                                break;
                            case "ShowPageNavigationControls":
                                if (visibility)
                                    ReportViewer1.ShowPageNavigationControls = true;
                                else
                                    ReportViewer1.ShowPageNavigationControls = false;
                                break;
                            case "ShowParameterPrompts":
                                if (visibility)
                                    ReportViewer1.ShowParameterPrompts = true;
                                else
                                    ReportViewer1.ShowParameterPrompts = false;
                                break;
                            case "ShowPrintButton":
                                if (visibility)
                                    ReportViewer1.ShowPrintButton = true;
                                else
                                    ReportViewer1.ShowPrintButton = false;
                                break;
                            case "ShowPromptAreaButton":
                                if (visibility)
                                    ReportViewer1.ShowPromptAreaButton = true;
                                else
                                    ReportViewer1.ShowPromptAreaButton = false;
                                break;
                            case "ShowRefreshButton":
                                if (visibility)
                                    ReportViewer1.ShowRefreshButton = true;
                                else
                                    ReportViewer1.ShowRefreshButton = false;
                                break;
                            case "ShowToolBar":
                                if (visibility)
                                    ReportViewer1.ShowToolBar = true;
                                else
                                    ReportViewer1.ShowToolBar = false;
                                break;
                            case "ShowZoomControl":
                                if (visibility)
                                    ReportViewer1.ShowZoomControl = true;
                                else
                                    ReportViewer1.ShowZoomControl = false;
                                break;
                        }
                    }
                }
            }

            if (server != "" && location != "")
            {
                if (Uri.IsWellFormedUriString(server, UriKind.RelativeOrAbsolute))
                {
                    UriBuilder uri = new UriBuilder(server);
                    ReportViewer1.ServerReport.ReportServerUrl = uri.Uri;
                    ReportViewer1.ServerReport.ReportPath = location;
                    try
                    {
                        if (height != "")
                            ReportViewer1.Height = Unit.Pixel(Convert.ToInt32(height));
                    }
                    catch (Exception ex)
                    {

                        litMessage.Text = "The static portlet height is defined incorrectly.  Please make sure that the value is an integer.";
                        Panel1.Visible = false;
                        pnlMessage.Visible = true;
                    }

                }
                else
                {
                    ReportViewer1.Visible = false;
                    litMessage.Text = "Malformed Report Server URL in portlet settings.";
                    Panel1.Visible = false;
                    pnlMessage.Visible = true;
                }
            }
            else
            {
                litMessage.Text = "This portlet has not yet been configured by an administrator.";
                Panel1.Visible = false;
                pnlMessage.Visible = true;
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="portlet"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// 

        //--DRB

        //private void setParameters(Portlet portlet)
        //{
        //    try
        //    {
        //        string parameters = PortletUtilities.GetSettingValue(portlet, "SSRSParameters"); //viewerconfig.ParameterList;

        //        if (parameters != null && parameters != "")
        //        {
        //            parameters = insertReplacementParameters(portlet, parameters);

        //            List<GCReportParameter> defaultParameters = GCReportParameter.buildParameterList(parameters);
                    

        //            //Parameter list to be populated
        //            List<ReportParameter> lstParams = new List<ReportParameter>();

        //            //Parameter list from the report
        //            ReportParameterInfoCollection rptParams = ReportViewer1.ServerReport.GetParameters();

        //            foreach (ReportParameterInfo rptparam in rptParams)
        //            {
        //                string val = String.Empty;

        //                int indx = defaultParameters.FindIndex(x => x.Name == rptparam.Name);
        //                if (indx >= 0)
        //                {
        //                    ReportParameter p = new ReportParameter(rptparam.Name, defaultParameters[indx].Value);
        //                    lstParams.Add(p);
        //                }
        //                else
        //                {
        //                    ReportParameter p = new ReportParameter(rptparam.Name, rptparam.Values.ToArray());
        //                    lstParams.Add(p);
        //                }
        //            }
        //            ReportViewer1.ServerReport.SetParameters(lstParams.ToArray());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        litMessage.Text = ex.Message;
        //        Panel1.Visible = false;
        //        pnlMessage.Visible = true;
        //    }

        //}

        private string insertReplacementParameters(Portlet portlet, string parameters)
        {
            // Replace @@ placeholders with correct values with actual content.
            var literalStringReplacer = ObjectFactoryWrapper.GetInstance<ILiteralStringReplacer>();
            parameters = literalStringReplacer.Process(parameters, portlet.Portlet);

            StringBuilder sbParameters = new StringBuilder(parameters);

            //Replace Fields from URL Parameters
            Regex r1 = new Regex("@@URL_(\\w|\\$)*&?");
            MatchCollection mc = r1.Matches(parameters);

            foreach (Match m in mc)
            {
                try
                {
                    Regex r2 = new Regex(m.Value + "=(\\w)+(&|$)");
                    var val = r2.Match(HttpUtility.UrlDecode(Request.QueryString.ToString())).Value;
                    val = val.Substring(val.IndexOf("=") + 1).TrimEnd('&');
                    if (val != "" && val != null)
                    {
                        string fieldValue = val;
                        sbParameters.Replace(m.Value, fieldValue);
                    }
                    else
                    {
                        sbParameters.Replace(m.Value, String.Empty);
                    }
                }
                catch (Exception ex)
                {
                    string erMsg = PortalUser.Current.IsSiteAdmin ? "Unable to perform field replacement from querystring.  " + ex.Message : "Unable to perform field replacement from querystring";
                    Panel1.Visible = false;
                    litMessage.Text = erMsg;
                    pnlMessage.Visible = true;
                }
            }

            return sbParameters.ToString();
        }


    }
}
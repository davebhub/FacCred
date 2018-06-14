using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Principal;
using Microsoft.Reporting.WebForms;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Framework.Configuration;

namespace FacCred.Reports
{
    [Serializable]
    public sealed class MyReportServerCredentials :
        IReportServerCredentials
    {
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }
        }

        public ICredentials NetworkCredentials
        {
            get
            {
                // User name
                string userName = Settings.GetConfigValue("C_Security", "SSRS_User");

                if (string.IsNullOrEmpty(userName))
                    throw new Exception(
                        "Missing user name from fwk_configsettings table");

                // Password
                string password = Settings.GetConfigValue("C_Security", "SSRS_PWD");
                //ConfigurationManager.AppSettings
                //    ["MyReportViewerPassword"];

                if (string.IsNullOrEmpty(password))
                    throw new Exception(
                        "Missing password from fwk_configsettings table");

                // Domain
                string domain = Settings.GetConfigValue("C_Security", "SSRS_Domain");
                //ConfigurationManager.AppSettings
                //    ["MyReportViewerDomain"];

                if (string.IsNullOrEmpty(domain))
                    throw new Exception(
                        "Missing domain from fwk_configsettings table");

                return new NetworkCredential(userName, password, domain);
            }
        }

        public bool GetFormsCredentials(out Cookie authCookie,
                    out string userName, out string password,
                    out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;

            // Not using form credentials
            return false;
        }
    }
}
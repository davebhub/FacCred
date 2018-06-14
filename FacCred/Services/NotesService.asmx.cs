using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Services;
using CUS.OdbcConnectionClass3;
using FacCred.Entities;
using Jenzabar.Common.Configuration;
using Jenzabar.Portal.Framework;

namespace FacCred.Services
{
    /// <summary>
    /// Summary description for NotesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class NotesService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string GetNote()
        {
            var note = new NotesNHibernate();




            return "Hello World";
        }
    }
}

using System;
using Jenzabar.Portal.Framework.Web.UI;
using FacCred.Views;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using FacCred.Models.Interfaces;
using FacCred.Models;
using System.Data;
using FacCred.Views.Interfaces;
using FacCred.Presenters;
using System.Web;
using Jenzabar.Portal.Framework;

namespace FacCred.Screens
{
    public partial class ACADCREDScreen : PortletViewBase
    {
        static CredentialsView credentialsview = new CredentialsView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            if (Session["newSearch"].ToString() == "false")
            {
                searchFacName.Text = "Faculty Member: " + Session["firstname"].ToString() + " " + Session["lastname"].ToString();
            }
            else
            {
                searchFacName.Text = "";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_PX_Courses_PreRender(object sender, EventArgs e)
        {
            //if (Session["yearcode"].ToString().Length > 1 & Session["termcode"].ToString().Length > 1)
            //{
            //    gv_Notes.DataSource = credentialsview.getApprovalsByYT();
            //    gv_Notes.DataBind();
            //}
            //else
            //{
            gv_PX_Courses.DataSource = credentialsview.getACAD_CRED_SQLDataSet();
            gv_PX_Courses.DataBind();
            //}


            if (gv_PX_Courses.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_PX_Courses.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_PX_Courses.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_PX_Courses.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void gv_PX_Courses_RowCommand(object sender, EventArgs e)
        {

        }

        protected void gv_PX_Courses_IndexChanging(object sender, EventArgs e)
        {

        }








    }
}
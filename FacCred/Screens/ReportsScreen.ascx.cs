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
    public partial class ReportsScreen : PortletViewBase
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

            //if (Session["newSearch"].ToString() == "false")
            //{
            //   // searchFacName.Text = "Faculty Member: " + Session["firstname"].ToString() + " " + Session["lastname"].ToString();
            //}
            //else
            //{
            //  //  searchFacName.Text = "";
            //}
        }

        protected void FCS_Roster_click(object sender, EventArgs e)
        {
           
                //Server.Transfer("FacCred.Screens.LoadingScreen.ascx", true);
            //Response.Redirect("LoadingHTML.html");
            //Response.Redirect("LoadingJS.js");
        }

        //protected void startLoad()
        //{
        //    txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;Session["userLevel"].ToString();

        //    if (Session["newSearch"].ToString() == "false")
        //    {
        //        facMember.Visible = true;
        //        searchFacName.Text = Session["firstname"].ToString() + " " + Session["lastname"].ToString();
        //    }
        //    else
        //    {
        //        facMember.Visible = false;
        //        searchFacName.Text = "All Credit Records";
        //    }

        //}

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_Credit_PreRender(object sender, EventArgs e)
        {
            //if (Session["yearcode"].ToString().Length > 1 & Session["termcode"].ToString().Length > 1)
            //{
            //    gv_Notes.DataSource = credentialsview.getApprovalsByYT();
            //    gv_Notes.DataBind();
            //}
            //else
            //{
            //gv_Credit.DataSource = credentialsview.getCREDITSQLDataSet();
            //gv_Credit.DataBind();
            ////}


            //if (gv_Credit.Rows.Count > 0)
            //{
            //    //Replace the <td> with <th> and adds the scope attribute
            //    gv_Credit.UseAccessibleHeader = true;

            //    //Adds the <thead> and <tbody> elements required for DataTables to work
            //    gv_Credit.HeaderRow.TableSection = TableRowSection.TableHeader;

            //    //Adds the <tfoot> element required for DataTables to work
            //    gv_Credit.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        //protected void gv_Credit_RowCommand(object sender, EventArgs e)
        //{

        //}

        //protected void gv_Credit_IndexChanging(object sender, EventArgs e)
        //{

        //}


    
}
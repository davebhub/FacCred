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
    public partial class UnauthorizedScreen : PortletViewBase
    {
        //static ApprovalsView approveview = new ApprovalsView();
        //static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;
           // startLoad();
        }

        //protected void startLoad()
        //{
        //    

        //    if (Session["newSearch"].ToString() == "false")
        //    {
        //        searchFacName.Text = "Faculty Member: " + Session["firstname"].ToString() + " " + Session["lastname"].ToString();
        //    }
        //    else
        //    {
        //        searchFacName.Text = "";
        //    }

        //}
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void gv_Approvals_PreRender(object sender, EventArgs e)
        //{
        //    if (Session["yearcode"].ToString().Length > 1 & Session["termcode"].ToString().Length > 1)
        //    {
        //        gv_Approvals.DataSource = approveview.getApprovalsByYT(Session["yearcode"].ToString(), Session["termcode"].ToString());
        //        gv_Approvals.DataBind();
        //    }
        //    else
        //    {
        //        gv_Approvals.DataSource = approveview.getAllApprovals();
        //        gv_Approvals.DataBind();
        //    }


        //    if (gv_Approvals.Rows.Count > 0)
        //    {
        //        //Replace the <td> with <th> and adds the scope attribute
        //        gv_Approvals.UseAccessibleHeader = true;

        //        //Adds the <thead> and <tbody> elements required for DataTables to work
        //        gv_Approvals.HeaderRow.TableSection = TableRowSection.TableHeader;

        //        //Adds the <tfoot> element required for DataTables to work
        //        gv_Approvals.FooterRow.TableSection = TableRowSection.TableFooter;
        //    }

        //    //loadDropDowns();
        //}







        protected void gv_Approvals_IndexChanging(object sender, EventArgs e)
        {

        }

        protected void gv_Approvals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();
            string id_num = String.Empty;

            //switch (cmdName)
            //{
            //    case "gv_Approvals_Approver1":
            //        {
            //            id_num = gv_Approvals.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();


            //            //ParentPortlet.NextScreen("CredentialsScreen");
            //        }
            //        break;
            //    case "gv_Approvals_Approver2":
            //        {
            //            id_num = gv_Approvals.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();


            //            //ParentPortlet.NextScreen("CoursesScreen");
            //        }
            //        break;
            //}
        }




        //gv_Your_Approvals    ----------------------------------------------------------------------------

        //protected void gv_Your_Approvals_PreRender(object sender, EventArgs e)
        //{
        //    gv_Your_Approvals.DataSource = approveview.getYourApprovals(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
        //    gv_Your_Approvals.DataBind();



        //    if (gv_Your_Approvals.Rows.Count > 0)
        //    {
        //        //Replace the <td> with <th> and adds the scope attribute
        //        gv_Your_Approvals.UseAccessibleHeader = true;

        //        //Adds the <thead> and <tbody> elements required for DataTables to work
        //        gv_Your_Approvals.HeaderRow.TableSection = TableRowSection.TableHeader;

        //        //Adds the <tfoot> element required for DataTables to work
        //        gv_Your_Approvals.FooterRow.TableSection = TableRowSection.TableFooter;
        //    }

        //}

        protected void gv_Your_Approvals_IndexChanging(object sender, EventArgs e)
        {

        }










    }
}
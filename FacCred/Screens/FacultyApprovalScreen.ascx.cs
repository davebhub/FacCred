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
    public partial class FacultyApprovalScreen : PortletViewBase
    {
        static FacultyApprovalsView facultyApprovalsView = new FacultyApprovalsView();


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            if (Session["userLevel"].ToString() == "FacCredUser")
            {
                mainTitle.Text = "FacCredUser - Selection Screen";
            }
            else
            {
                mainTitle.Text = "FACULTY APPROVAL";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //word
        }

        protected void lb_newSearch_click(object sender, EventArgs e)
        {
            // Session["newSearch"] = "true";           
            //searchFacName.Text = "";
        }

        protected void lb_Back_click(object sender, EventArgs e)
        {
            ParentPortlet.PreviousScreen();

        }



        //gv_FacultyApprovals    ----------------------------------------------------------------------------
        protected void gv_FacApprovals_PreRender(object sender, EventArgs e)
        {

            if (Session["userLevel"].ToString() == "Approver1")
            {
                gv_FacApprovals.DataSource = facultyApprovalsView.getYourApprover1Faculty(Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
                gv_FacApprovals.DataBind();
            }
            else if (Session["userLevel"].ToString() == "Approver2")
            {
                gv_FacApprovals.DataSource = facultyApprovalsView.getYourApprover2Faculty(Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
                gv_FacApprovals.DataBind();
            }
            else if (Session["userLevel"].ToString() == "Approver3")
            {
                gv_FacApprovals.DataSource = facultyApprovalsView.getYourApprover3Faculty(Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
                gv_FacApprovals.DataBind();
            }


            if (gv_FacApprovals.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_FacApprovals.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_FacApprovals.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_FacApprovals.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            startLoad();
        }



        protected void gv_FacApprovals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_FacApprovals.Rows[rowIndex];

            if (row.Cells[0].Text == "&nbsp;")
            {
                ParentPortlet.ShowFeedback("nothing to approve, silly person :)");
                return;
            }

            Session["FACappid"] = (string)gv_FacApprovals.DataKeys[rowIndex]["FACappid"];
            Session["FACidnum"] = (string)gv_FacApprovals.DataKeys[rowIndex]["FACidnum"];

            // setting these here to properly load the next screen on select
            Session["FAClastname"] = row.Cells[0].Text;
            Session["FACfirstname"] = row.Cells[1].Text;
            Session["FACinstructorType"] = row.Cells[2].Text;


                switch (cmdName)
                {
                    case "gv_FacultyApprovals_Approve":
                        {

                                if (Session["userLevel"].ToString() == "Approver1" ||
                                    Session["userLevel"].ToString() == "Approver2" ||
                                    Session["userLevel"].ToString() == "Approver3")
                                {
                                    ParentPortlet.NextScreen("FacultyApprovalUpdateScreen");
                                }
                            
                        }
                        break;
                    case "gv_FacultyApprovals_Note":
                        {
                            //Session["noteText"] = "";
                            //ParentPortlet.NextScreen("ApprovalUpdateScreen");
                        }
                        break;
                }
        }


    }
}
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
    public partial class StatusScreen : PortletViewBase
    {
        //static ApprovalsView approveview = new ApprovalsView();
        static FacultyApprovalsView facultyApprovalsView = new FacultyApprovalsView();
        static CourseApprovalsView courseApprovalsView = new CourseApprovalsView();
        static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;


        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_Faculty_Approvals_PreRender(object sender, EventArgs e)
        {

            gv_Faculty_Approvals.DataSource = facultyApprovalsView.getAllFacultyApprovalsLIU(Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
            gv_Faculty_Approvals.DataBind();


            if (gv_Faculty_Approvals.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Faculty_Approvals.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Faculty_Approvals.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Faculty_Approvals.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            //loadDropDowns();
        }
        protected void gv_Course_Approvals_PreRender(object sender, EventArgs e)
        {

            gv_Course_Approvals.DataSource = courseApprovalsView.getAllCourseApprovalsYT(Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
            gv_Course_Approvals.DataBind();


            if (gv_Course_Approvals.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Course_Approvals.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Course_Approvals.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Course_Approvals.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            //loadDropDowns();
        }


        protected void gv_Faculty_Approvals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Faculty_Approvals.Rows[rowIndex];

            if (row.Cells[0].Text == "&nbsp;")
            {
                ParentPortlet.ShowFeedback("nothing to approve, silly person :)");
                return;
            }

            Session["FACappid"] = (string)gv_Faculty_Approvals.DataKeys[rowIndex]["FACappid"];
            Session["FACidnum"] = (string)gv_Faculty_Approvals.DataKeys[rowIndex]["FACidnum"];

            // setting these here to properly load the next screen on select
            Session["FAClastname"] = row.Cells[1].Text;
            Session["FACfirstname"] = row.Cells[2].Text;
            if (row.Cells[3].Text == "&nbsp;")
            {
                Session["FACinstructorType"] = " ";
            }
            else { 
                Session["FACinstructorType"] = row.Cells[3].Text;
            }

            switch (cmdName)
            {
                case "gv_FacultyApprovals_Approve":
                {

                    if (Session["userLevel"].ToString() == "Approver1" ||
                        Session["userLevel"].ToString() == "Approver2" ||
                        Session["userLevel"].ToString() == "Approver3")
                    {
                        if (Session["FACidnum"].ToString().Length > 1)
                        {
                            ParentPortlet.NextScreen("FacultyApprovalUpdateScreen");
                        }
                        else
                        {
                            ParentPortlet.ShowFeedback(FeedbackType.Error, "Are you trying to break the system?  shame shame shame :)");
                        }
                        
                    }
                    else
                    {
                        ParentPortlet.ShowFeedback(FeedbackType.Message, "Only for Approvers");
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


        protected void gv_Course_Approvals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Course_Approvals.Rows[rowIndex];

            if (row.Cells[0].Text == "&nbsp;")
            {
                ParentPortlet.ShowFeedback("nothing to approve, silly person :)");
                return;
            }


            Session["FACappid"] = (string)gv_Course_Approvals.DataKeys[rowIndex]["FACappid"];
            Session["FACidnum"] = (string)gv_Course_Approvals.DataKeys[rowIndex]["FACidnum"];

            // setting these here to properly load the next screen on select
            Session["FAClastname"] = row.Cells[1].Text;
            Session["FACfirstname"] = row.Cells[2].Text;
            //Session["FACinstructorType"] = row.Cells[3].Text;
            if (row.Cells[3].Text == "&nbsp;")
            {
                Session["FACinstructorType"] = " ";
            }
            else
            {
                Session["FACinstructorType"] = row.Cells[3].Text;
            }
            Session["FACdivcode"] = row.Cells[4].Text;
            Session["FACinstdiv"] = row.Cells[5].Text;
            Session["FACschoolcode"] = row.Cells[6].Text;
 

            if (Session["FACdivcode"].ToString().Length < 2 || Session["FACdivcode"].ToString().Length > 2)
            {
                Session["FACdivcode"] = "";
            }

            if (Session["FACinstdiv"].ToString().Length < 2 || Session["FACinstdiv"].ToString().Length > 2)
            {
                Session["FACinstdiv"] = "";
            }

            if (Session["FACschoolcode"].ToString().Length < 2 || Session["FACschoolcode"].ToString().Length > 2)
            {
                Session["FACschoolcode"] = "";
            }



            if (Session["FACinstdiv"].ToString() == "&nbsp;")
            {
                ParentPortlet.ShowFeedback("Cannot process a blank INST_DIV");
            }
            else
            {
                switch (cmdName)
                {
                    case "gv_Approvals_Course_Approve":
                        {

                            if (Session["userLevel"].ToString() == "Approver1" ||
                                Session["userLevel"].ToString() == "Approver2" ||
                                Session["userLevel"].ToString() == "Approver3")
                            {
                                if (Session["FACidnum"].ToString().Length > 1)
                                {
                                    ParentPortlet.NextScreen("CourseApprovalUpdateScreen");
                                }
                                else
                                {
                                    ParentPortlet.ShowFeedback(FeedbackType.Error, "Are you trying to break the system?  shame shame shame :)");
                                }

                            }
                            else
                            {
                                ParentPortlet.ShowFeedback(FeedbackType.Message,"Only for Approvers");
                            }

                        }
                        break;
                    case "gv_Approvals_Note":
                        {
                            //Session["noteText"] = "";
                            //ParentPortlet.NextScreen("ApprovalUpdateScreen");
                        }
                        break;
                }
            }


        }


        protected void btn_Back_Click(object sender, EventArgs e)
        {
            ParentPortlet.PreviousScreen();
        }



    }
}
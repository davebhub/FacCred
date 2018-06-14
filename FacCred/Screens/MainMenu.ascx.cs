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


namespace FacCred.Screens
{
    public partial class MainMenu : PortletViewBase
    {
        static MainMenuView view = new MainMenuView();
        static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!Page.IsPostBack)
            {

            }

            if (Session["userLevel"].ToString() == "FacCredAdmin")
            {
                userAccessBtn.Visible = true;
            }
            else
            {
                userAccessBtn.Visible = false;
            }


            if (Session["userLevel"].ToString() == "Approver1" || Session["userLevel"].ToString() == "Approver2" || Session["userLevel"].ToString() == "Approver3" )
            {
                facultyApprovalBtn.Visible = true;
                courseApprovalBtn.Visible = true;
            }
            else
            {
                facultyApprovalBtn.Visible = false;
                courseApprovalBtn.Visible = false;
            }

            DropDownList_year.DataSource = ddview.getYears();
            DropDownList_year.DataBind();

            DropDownList_term.DataSource = ddview.getTerms();
            DropDownList_term.DataBind();


        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList_year_OnLoad(Object sender, EventArgs e)
        {
            if (Session["yearcode"].ToString() == "YR")
            {
                Session["yearcode"] = DropDownList_year.SelectedValue.ToString();
            }

            DropDownList_year.SelectedValue = Session["yearcode"].ToString() ;

        }


        protected void DropDownList_term_OnLoad(Object sender, EventArgs e)
        {
            if (Session["termcode"].ToString() == "TR")
            {
                Session["termcode"] = DropDownList_term.SelectedValue.ToString();
            }


            DropDownList_term.SelectedValue = Session["termcode"].ToString();
        }


        protected void ddl_year_OnSelectedIndexChanged(object sender,  EventArgs e)
        {

            Session["yearcode"] = DropDownList_year.SelectedValue.ToString();
        }


        protected void ddl_term_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["termcode"] = DropDownList_term.SelectedValue.ToString();
        }



        // menu screen changes -----------------------------------



        public void LoadFacultyScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("FacultyScreen");
        }

        public void LoadFacultyApprovalScreen(object sender, EventArgs e)
        {

            if (Session["userLevel"].ToString() == "FacCredUser")
            {
                ParentPortlet.ShowFeedback(FeedbackType.Error,"Not Authorized");
            }
            else
            {
                ParentPortlet.NextScreen("FacultyApprovalScreen");
            }
           
        }

        public void LoadDefaultView(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("DefaultView");
        }

        public void LoadNextView(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("DefaultView");
        }

        public void LoadJunkScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("JunkScreen");
        }

        public void LoadCoursesScreen(object sender, EventArgs e)
        {
            if (Session["yearcode"].ToString() == "YR" | Session["termcode"].ToString() == "TRM")
            {
                ParentPortlet.ShowFeedback(FeedbackType.Error, "Please select a Year and Term first :)");
            }
            else
            {
                ParentPortlet.NextScreen("CoursesScreen");
            }
        }

        public void LoadCourseApprovalScreen(object sender, EventArgs e)
        {
            if (DropDownList_term.SelectedValue == "TRM" || DropDownList_year.SelectedValue == "YR")
            {
                ParentPortlet.ShowFeedback(FeedbackType.Error, "Please select a Year and Term first :)");
            }
            else
            {
                if (Session["userLevel"].ToString() == "FacCredUser")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Error, "Not Authorized");
                }
                else
                {
                    ParentPortlet.NextScreen("CourseApprovalScreen");
                }

            }
        }

        public void LoadCredentialsScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("CredentialsScreen");
        }

        public void LoadApprovalsScreen(object sender, EventArgs e)
        {
            //if (Session["userLevel"].ToString() == "FacCredUser")
            //{
            //    ParentPortlet.NextScreen("UnauthorizedScreen");
            //}
            //else if (Session["userLevel"].ToString() == "Approver1" || Session["userLevel"].ToString() == "Approver2" || Session["userLevel"].ToString() == "Approver3"  ) 
            //{
                ParentPortlet.NextScreen("ApprovalsScreen");
            //}
            
        }

        public void LoadApprover1Screen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("Approver1Screen");
        }
        public void LoadUpdateScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("UpdateScreen");
        }
        public void LoadStatusScreen(object sender, EventArgs e)
        {
            if (Session["yearcode"].ToString() == "YR" || Session["termcode"].ToString() == "TRM")
            {
                ParentPortlet.ShowFeedback("Please select a Year and Term first :)");
            }
            else
            {
                ParentPortlet.NextScreen("StatusScreen");
            }
        }
        public void LoadReportsScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("ReportsScreen");
        }
        public void LoadCatalogScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("CatalogScreen");
        }

        public void LoadAdminScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("AdminScreen");
        }

        public void LoadDisciplineScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("DisciplineScreen");
        }
        public void LoadUnauthorizedScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("UnauthorizedScreen");
        }

        public void LoadNoteArchiveScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("FacultyNoteArchiveScreen");
        }

        public void LoadEduEarnHistScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("EDUEarnHistScreen");
        }

        public void LoadUserAccessScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("UserAccessScreen");
        }

    }
}
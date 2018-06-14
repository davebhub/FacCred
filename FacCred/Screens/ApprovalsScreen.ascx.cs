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
    public partial class ApprovalsScreen : PortletViewBase
    {
        static ApprovalsView approveview = new ApprovalsView();
        static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            if (Session["userLevel"].ToString() == "FacCredUser" )
            {
                mainTitle.Text = "FacCredUser - Selection Screen";
            }   
            else
            {
                mainTitle.Text = "APPROVAL - Your Pending Approvals";
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

        protected void gv_Approvals_IndexChanging(object sender, EventArgs e)
        {
            //word
        }

        //gv_Approvals    ----------------------------------------------------------------------------
        protected void gv_Approvals_PreRender(object sender, EventArgs e)
        {

            //if (Session["userLevel"].ToString() == "Approver1")
            //{
            //    // gv_Approvals.DataSource = approveview.getYourApproval1RecordsFaculty(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACidnum"].ToString());
            //    gv_Approvals.DataSource = approveview.getYourApprover1FacultyDiscipline(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Approvals.DataBind();
            //}
            //else if (Session["userLevel"].ToString() == "Approver2")
            //{
            //    // gv_Approvals.DataSource = approveview.getYourApproval2RecordsFaculty(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACidnum"].ToString());
            //    gv_Approvals.DataSource = approveview.getYourApprover2FacultyDiscipline(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Approvals.DataBind();
            //}
            //else if (Session["userLevel"].ToString() == "Approver3")
            //{
            //    //gv_Approvals.DataSource = approveview.getYourApproval3RecordsFaculty(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACidnum"].ToString());
            //    gv_Approvals.DataSource = approveview.getYourApprover3FacultyDiscipline(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Approvals.DataBind();
            //}
            //else if (Session["userLevel"].ToString() == "FacCredUser")
            //{
            //    //gv_Approvals.DataSource = approveview.getYourFacCredUserRecordsFaculty(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACidnum"].ToString());
            //    gv_Approvals.DataSource = approveview.getYourFacCredUserFacultyDiscipline(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Approvals.DataBind();
            //}


            //if (gv_Approvals.Rows.Count > 0)
            //{
            //    //Replace the <td> with <th> and adds the scope attribute
            //    gv_Approvals.UseAccessibleHeader = true;

            //    //Adds the <thead> and <tbody> elements required for DataTables to work
            //    gv_Approvals.HeaderRow.TableSection = TableRowSection.TableHeader;

            //    //Adds the <tfoot> element required for DataTables to work
            //    gv_Approvals.FooterRow.TableSection = TableRowSection.TableFooter;
            //}

            startLoad();
        }



        protected void gv_Approvals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();
            
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Approvals.Rows[rowIndex];

            Session["FACappid"] = (string)gv_Approvals.DataKeys[rowIndex]["FACappid"];
            Session["FACidnum"] = (string)gv_Approvals.DataKeys[rowIndex]["FACidnum"];

            // setting these here to properly load the next screen on select
            Session["FAClastname"] = row.Cells[1].Text;
            Session["FACfirstname"] = row.Cells[2].Text;
            Session["FACinstructorType"] = row.Cells[3].Text;
            Session["FACinstdiv"] = row.Cells[4].Text;
            //Session["FACappid"] = row.Cells[7].Text;
            //Session["FACidnum"] = row.Cells[8].Text;
            //Session["CRSappid"] = row.Cells[9].Text;
            //Session["CRSdesc"] = row.Cells[1].Text;

            if (Session["FACinstdiv"].ToString() == "&nbsp;")
            {

                ParentPortlet.ShowFeedback("Cannot process a blank INST_DIV");
                return;
            }
            else
            {
                switch (cmdName)
                {
                    case "gv_Approvals_Approve":
                    {

                        if (Session["userLevel"].ToString() == "Approver1" ||
                            Session["userLevel"].ToString() == "Approver2" ||
                            Session["userLevel"].ToString() == "Approver3")
                        {
                            ParentPortlet.NextScreen("ApprovalUpdateScreen");
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


    }
}
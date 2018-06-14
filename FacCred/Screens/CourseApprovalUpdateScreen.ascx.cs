using System;
using Jenzabar.Portal.Framework.Web.UI;
using Jenzabar.Portal.Framework.Web;
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
using FacCred.Entities;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using EX.Data.Services.Interfaces;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using Jenzabar.Portal.Framework;



namespace FacCred.Screens
{
    public partial class CourseApprovalUpdateScreen : PortletViewBase
    {
        static DropDownView ddview = new DropDownView();
        static CourseApprovalsView courseApprovalsView = new CourseApprovalsView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;Session["userLevel"].ToString();
            facNoteName.Text = Session["FACinstructorType"].ToString() + "   " + Session["FACfirstname"].ToString() + ' ' + Session["FAClastname"].ToString();           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsFirstLoad)
            {
                LoadDropDowns();
            }

            LoadTextFields();
        }


        private void LoadDropDowns()
        {
            ddl_Approval_Status.DataSource = ddview.getApprovalCodes();
            ddl_Approval_Status.DataBind();

            
        }


        private void LoadTextFields()
        {
            if (Session["returningFromNotes"].ToString() == "true")
            {
                Session["returningFromNotes"] = "false";
                txt_Division.Text = Session["FACdivcode"].ToString();
                txt_InstDiv.Text = Session["FACinstdiv"].ToString();
                txt_SchoolCode.Text = Session["FACschoolcode"].ToString();

                txt_CRS.Text = Session["approvalCourse"].ToString();
                txt_TITLE.Text = Session["approvalCourseTitle"].ToString();

                ddl_Approval_Status.SelectedValue = Session["approvalStatus"].ToString();
            }
        }

        protected void gv_Your_Approvals_PreRender(object sender, EventArgs e)
        {
            LoadYourApprovals();

            if (gv_Your_Approvals.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Your_Approvals.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Your_Approvals.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Your_Approvals.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void LoadYourApprovals()
        {
            if (Session["userLevel"].ToString() == "Approver1")
            {
                gv_Your_Approvals.DataSource = courseApprovalsView.getYourApprover1Courses(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(),Session["FACinstdiv"].ToString(), Session["FACidnum"].ToString(), Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
                gv_Your_Approvals.DataBind();
            }
            else if (Session["userLevel"].ToString() == "Approver2")
            {
                gv_Your_Approvals.DataSource = courseApprovalsView.getYourApprover2Courses(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACinstdiv"].ToString(), Session["FACidnum"].ToString(), Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
                gv_Your_Approvals.DataBind();
            }
            else if (Session["userLevel"].ToString() == "Approver3")
            {
                gv_Your_Approvals.DataSource = courseApprovalsView.getYourApprover3Courses(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACinstdiv"].ToString(), Session["FACidnum"].ToString(), Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
                gv_Your_Approvals.DataBind();
            }
        }


        protected void gv_Your_Approvals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Your_Approvals.Rows[rowIndex];


            ParentPortlet.Session["EditId"] = gv_Your_Approvals.DataKeys[rowIndex].Value.ToString();
            Session["FACappid"] = (string)this.gv_Your_Approvals.DataKeys[rowIndex]["FACappid"];
            Session["FACidnum"] = (string)this.gv_Your_Approvals.DataKeys[rowIndex]["FACidnum"];
            Session["SM_appid"] = (string)this.gv_Your_Approvals.DataKeys[rowIndex]["SM_appid"];

            Session["approvalStatus"] = row.Cells[1].Text;
            Session["approvalCourse"] = row.Cells[2].Text;
            txt_CRS.Text = row.Cells[2].Text;
            Session["approvalCourseTitle"] = row.Cells[3].Text;
            txt_TITLE.Text = row.Cells[3].Text;
            Session["approvalYear"] = row.Cells[4].Text;
            Session["approvalTerm"] = row.Cells[5].Text;

            if (row.Cells[6].Text.Length < 2 || row.Cells[6].Text.Length > 3)
            {
                Session["approvalDivCode"] = " ";
                txt_Division.Text = " ";
            }
            else
            {
                Session["approvalDivCode"] = row.Cells[6].Text;
                txt_Division.Text = row.Cells[6].Text;
            }

            if (row.Cells[7].Text.Length < 2 || row.Cells[7].Text.Length > 3)
            {
                Session["approvalInstDiv"] = " ";
                txt_InstDiv.Text = " ";
            }
            else
            {
                Session["approvalInstDiv"] = row.Cells[7].Text;
                txt_InstDiv.Text = row.Cells[7].Text;
            }

            if (row.Cells[8].Text.Length < 2 || row.Cells[8].Text.Length > 3)
            {
                Session["approvalSchoolCode"] = " ";
                txt_SchoolCode.Text = " ";
            }
            else
            {
                Session["approvalSchoolCode"] = row.Cells[8].Text;
                txt_SchoolCode.Text = row.Cells[8].Text;
            }




            switch (cmdName)
            {

                case "gv_Your_Approvals_Edit":
                    {
                        btn_Faculty_Notes.Visible = true;

                        if (Session["approvalStatus"].ToString() == "&nbsp;")
                        {
                            ddl_Approval_Status.SelectedValue = "0";
                        }
                        else
                        {
                            ddl_Approval_Status.SelectedValue = Session["approvalStatus"].ToString();
                        }

                    }
                    break;
                case "gv_Approvals_Archive":
                    {
                        //word

                    }
                    break;
                default:
                    break;
            }
        }


        protected void btn_Faculty_Notes_Click(object sender, EventArgs e)
        {
            Session["returningFromNotes"] = "true";
            ParentPortlet.NextScreen("FacultyNoteScreen");
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            ParentPortlet.Session.Remove("EditId");
            ParentPortlet.PreviousScreen();
        }




        protected void btn_Save_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please select an Approval Status before saving");
                }
                else if (txt_Division.Text.Length < 2 && txt_InstDiv.Text.Length < 2 && txt_SchoolCode.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please click on Edit of the row you want to make changes to, before saving");
                }
                else
                {
                    rtn = courseApprovalsView.InsertUpdateCourseApproval(
                            ddl_Approval_Status.SelectedValue.ToString(),
                            Session["FACappid"].ToString(),
                            Session["FACidnum"].ToString(),
                            Session["SM_appid"].ToString(),
                            Session["approvalYear"].ToString(),
                            Session["approvalTerm"].ToString(),
                            Session["approvalDivCode"].ToString(),
                            Session["approvalInstDiv"].ToString(),
                            Session["approvalSchoolCode"].ToString(),
                            Session["approvalCourse"].ToString(),
                            Session["approvalCourseTitle"].ToString(),
                            Session["FAClastname"].ToString(),
                            Session["FACfirstname"].ToString(),
                            Session["FACinstructorType"].ToString(),
                            Session["userLevel"].ToString(),
                            rightNow                        
                            );

                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "Success");
                        //clear out text fields
                        Session["approvalCourse"] = "";
                        Session["approvalCourseTitle"] = "";
                        Session["approvalYear"] = "";
                        Session["approvalTerm"] = "";
                        Session["approvalStatus"] = "";
                        Session["approvalDivCode"] = "";
                        Session["approvalInstDiv"] = "";
                        Session["approvalSchoolCode"] = "";

                        txt_CRS.Text = "";
                        txt_TITLE.Text = "";
                        txt_InstDiv.Text = "";
                        txt_Division.Text = "";
                        txt_SchoolCode.Text = "";



                        ddl_Approval_Status.SelectedValue = "0";

                        ParentPortlet.Session.Remove("EditId");
                    }
                    else
                    {
                        ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }
        }

        //-------- DIVISION UPDATE  -----------------------------------------------

        protected void btn_Division_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please select an Approval Status before saving");
                    return;
                }
                else if (txt_Division.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Cannot process a Blank DIVISION");
                    return;
                }

                if (Session["userLevel"].ToString() == "Approver1")
                {
                    InsertCourseDivisionRecs();
                }

                UpdateCourseDivisionRecs();

            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }
            finally
            {

            }
        }


        protected bool InsertCourseDivisionRecs()
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please select an Approval Status before saving");
                }
                else if (txt_Division.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Cannot process a Blank DIVISION_CDE");
                }
                else
                {
                    rtn = courseApprovalsView.InsertCourseDivisionRecords(
                            ddl_Approval_Status.SelectedValue.ToString(),
                            Session["FACappid"].ToString(),
                            Session["FACidnum"].ToString(),
                            Session["userlevel"].ToString(),
                            Session["yearcode"].ToString(),
                            Session["termcode"].ToString(),
                            Session["FACfirstname"].ToString(),
                            Session["FAClastname"].ToString(),
                            rightNow,
                            txt_Division.Text
                         );


                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "Success");

                    }
                    else
                    {
                        //failure - do not change screens
                        ParentPortlet.ShowFeedback(FeedbackType.Error, "Failure");
                    }

                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }
            finally
            {

            }

            return rtn;
        }

        protected bool UpdateCourseDivisionRecs()
        {

            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please select an Approval Status before saving");
                }
                else if (txt_Division.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Cannot process a Blank DIVISION_CDE");
                }
                else
                {

                    rtn = courseApprovalsView.UpdateCourseDivisionRecords(
                        ddl_Approval_Status.SelectedValue.ToString(),
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        Session["userlevel"].ToString(),
                        Session["yearcode"].ToString(),
                        Session["termcode"].ToString(),
                        Session["FACfirstname"].ToString(),
                        Session["FAClastname"].ToString(),
                        rightNow,
                        txt_Division.Text
                        );

                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "Success");
                    }
                    else
                    {
                        //failure
                        ParentPortlet.ShowFeedback(FeedbackType.Error, "failed");
                    }

                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }

            return rtn;
        }


        // --- INST_DIV  UPDATE  ---------------------------------------------------------------

        protected void btn_InstDiv_Save_Click(object sender, EventArgs e)
        {
            bool insertRtn = false;
            bool updateRtn = false;

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please select an Approval Status before saving");
                    return;
                }
                else if (txt_Division.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Cannot process a Blank INST_DIV");
                    return;
                }

                if (Session["userLevel"].ToString() == "Approver1")
                {
                    insertRtn = InsertCourseInstDivRecs();
                }

                updateRtn = UpdateCourseInstDivRecs();
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }
            finally
            {

            }
        }


        protected bool InsertCourseInstDivRecs()
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please select an Approval Status before saving");
                }
                else
                {
                    rtn = courseApprovalsView.InsertCourseInstDivRecords(
                            ddl_Approval_Status.SelectedValue.ToString(),
                            Session["FACappid"].ToString(),
                            Session["FACidnum"].ToString(),
                            Session["userlevel"].ToString(),
                            Session["yearcode"].ToString(),
                            Session["termcode"].ToString(),
                            Session["FACfirstname"].ToString(),
                            Session["FAClastname"].ToString(),
                            rightNow,
                            txt_InstDiv.Text );
                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Insert Failed");
            }
            finally
            {

            }

            return rtn;
        }

        protected bool UpdateCourseInstDivRecs()
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please select an Approval Status before saving");
                }
                else
                {
                    rtn = courseApprovalsView.UpdateCourseInstDivRecords(
                        ddl_Approval_Status.SelectedValue.ToString(),
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        Session["userlevel"].ToString(),
                        Session["yearcode"].ToString(),
                        Session["termcode"].ToString(),
                        Session["FACfirstname"].ToString(),
                        Session["FAClastname"].ToString(),
                        rightNow,
                        txt_InstDiv.Text);

                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "Success");
                    }
                    else
                    {
                        //failure
                        ParentPortlet.ShowFeedback(FeedbackType.Error, "failed");
                    }

                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }

            return rtn;
        }


        //-------- SCHOOL CODE UPDATE  -----------------------------------------------

        protected void btn_SchoolCode_Save_Click(object sender, EventArgs e)
        {
            bool insertRtn = false;
            bool updateRtn = false;

            try
            {
                if (txt_SchoolCode.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Cannot process a Blank SCHOOL_CDE");
                }
                else if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please select an Approval Status before saving");
                }
                else
                {              
                    if (Session["userLevel"].ToString() == "Approver1")
                    {
                        insertRtn = InsertCourseSchoolCodeRecs();
                    }

                    updateRtn = UpdateCourseSchoolCodeRecs();
                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }
            finally
            {

            }
        }


        protected bool InsertCourseSchoolCodeRecs()
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {

                    rtn = courseApprovalsView.InsertCourseSchoolCodeRecords(
                            ddl_Approval_Status.SelectedValue.ToString(),
                            Session["FACappid"].ToString(),
                            Session["FACidnum"].ToString(),
                            Session["userlevel"].ToString(),
                            Session["yearcode"].ToString(),
                            Session["termcode"].ToString(),
                            Session["FACfirstname"].ToString(),
                            Session["FAClastname"].ToString(),
                            rightNow,
                            txt_SchoolCode.Text

                         );


                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "Success");

                    }
                    else
                    {
                        //failure - do not change screens
                        ParentPortlet.ShowFeedback(FeedbackType.Error, "Failure");
                    }

                
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }
            finally
            {

            }

            return rtn;
        }

        protected bool UpdateCourseSchoolCodeRecs()
        {

            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                    rtn = courseApprovalsView.UpdateCourseSchoolCodeRecords(
                        ddl_Approval_Status.SelectedValue.ToString(),
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        Session["userlevel"].ToString(),
                        Session["yearcode"].ToString(),
                        Session["termcode"].ToString(),
                        Session["FACfirstname"].ToString(),
                        Session["FAClastname"].ToString(),
                        rightNow,
                        txt_SchoolCode.Text
                        );

                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "Success");
                    }
                    else
                    {
                        //failure
                        ParentPortlet.ShowFeedback(FeedbackType.Error, "failed");
                    }

                
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Error, "Update Failed");
            }

            return rtn;
        }


 

        //----------------------- drop downs --------------------------------


        protected void ddl_Approval_Status_OnLoad(object sender, EventArgs e)
        {
           // Session["approvalCode"] = "0";
          //  ddl_Approval_Status.SelectedValue = "0";
        }

        protected void ddl_Approval_Status_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           // Session["approvalCode"] = ddl_Approval_Status.SelectedValue.ToString();
        }



    }
}
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
    public partial class ApprovalUpdateScreen : PortletViewBase
    {
        static DropDownView ddview = new DropDownView();
       // static ApprovalsView approvalsView = new ApprovalsView();
        static CourseApprovalsView courseApprovalsView = new CourseApprovalsView();
        static FacultyApprovalsView facultyApprovalsView =  new FacultyApprovalsView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;Session["userLevel"].ToString();
            facNoteName.Text = Session["FACinstructorType"].ToString() + " : " + Session["FACfirstname"].ToString() + ' ' + Session["FAClastname"].ToString();
            lblDiscipline.Text = "  INST_DIV_CDE: " + Session["FACinstdiv"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsFirstLoad)
            {
                InitScreen();
            }

        }

        private void InitScreen()
        {
           

            // set the date pickers to today and a year from now for new documents
            string DateFormat = "MM-dd-yyyy";
            string rightNow = DateTime.Now.ToString(DateFormat);

            DateTime theDate = DateTime.Now;
            DateTime yearLater = theDate.AddYears(1);

            //dp_Approval_Date.SelectedDate = DateTime.Now;
            //dp_Expiration_Date.SelectedDate = yearLater;

            LoadDropDowns();

        }

        private void LoadDropDowns()
        {
            ddl_Approval_Status.DataSource = ddview.getApprovalCodes();
            ddl_Approval_Status.DataBind();

            loadTextFields();

         

        }

        private void loadTextFields()
        {
            if (Session["FACidnum"].ToString().Length > 1)
            {
                //txt_idnum.Text = Session["FACidnum"].ToString();
                //txt_FirstName.Text = Session["FACfirstname"].ToString();
                //txt_LastName.Text = Session["FAClastname"].ToString();
                //btn_CourseSave.Enabled = true;
            }

            if (Session["CRSappid"].ToString().Length > 1)
            {
                //txt_CourseAppid.Text = Session["CRSappid"].ToString();
                //txt_CourseDesc.Text = Session["CRSdesc"].ToString();
                //txt_CourseTerm.Text = Session["termcode"].ToString();
                //txt_CourseYear.Text = Session["yearcode"].ToString();
                //txt_instType.Text = Session["FACinstructorType"].ToString();
                //txt_InstDiv.Text = Session["CRSinstdiv"].ToString();
                //if (txt_InstDiv.Text == "&nbsp;")
                //{
                //    txt_InstDiv.Text = "0";
                //    Session["instdiv"] = "0";
                //}

                //btn_DivisionSave.Enabled = true;
            }

        }



        protected void btnMsg_Click(object sender, EventArgs e)
        {
            var notesService = new NotesMapperService();
            Guid noteId = new Guid(ParentPortlet.Session["EditId"].ToString());

            try
            {
                notesService.DeleteNote(noteId);
            }
            catch (Exception exception)
            {
                var msg = PortalUser.Current.IsSiteAdmin
                    ? "This note was not Deleted. " + exception.Message
                    : "This note was not Deleted.";

                this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

                ExceptionManager.Publish(exception);

            }

        }



        protected void gv_Your_Approvals_IndexChanging(object sender, EventArgs e)
        {
            //word
        }


        protected void gv_Your_Approvals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Your_Approvals.Rows[rowIndex];


            ParentPortlet.Session["EditId"] = gv_Your_Approvals.DataKeys[rowIndex].Value.ToString();
            string localFACappid = (string)this.gv_Your_Approvals.DataKeys[rowIndex]["FACappid"];
            string localFACidnum = (string)this.gv_Your_Approvals.DataKeys[rowIndex]["FACidnum"];
            string localSM_idnum = (string)this.gv_Your_Approvals.DataKeys[rowIndex]["SM_appid"];

            Session["approvalStatus"] = row.Cells[1].Text;
            Session["approvalCourse"] = row.Cells[2].Text;
            Session["approvalCoursetitle"] = row.Cells[3].Text;
            Session["approvalYear"] = row.Cells[4].Text;
            Session["approvalTerm"] = row.Cells[5].Text;
            Session["FACinstdiv"] = row.Cells[6].Text;

            Session["SM_appid"] = localSM_idnum;
            Session["FACappid"] = localFACappid;
            Session["FACidnum"] = localFACidnum;


            switch (cmdName)
            {

                case "gv_Your_Approvals_Edit":
                    {
                        txt_CRS.Text = Session["approvalCourse"].ToString();
                        txt_Title.Text = Session["approvalCoursetitle"].ToString();
                        txt_YTD.Text = Session["approvalYear"].ToString() + " : " + Session["approvalTerm"].ToString() + " : " + Session["FACinstdiv"].ToString();
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
                        //var notesService = new NotesMapperService();
                        ////var notesArchiveService = new NotesArchiveMapperService();
                        //Guid noteId = new Guid(ParentPortlet.Session["EditId"].ToString());

                        //try
                        //{
                        //    ArchiveNote(notesService.GetNote(noteId));

                        //    notesService.DeleteNote(noteId);
                        //}
                        //catch (Exception exception)
                        //{
                        //    var msg = PortalUser.Current.IsSiteAdmin
                        //        ? "This note was not Archived. " + exception.Message
                        //        : "This note was not Archived. ";

                        //    this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

                        //    ExceptionManager.Publish(exception);

                        //}

                        //ParentPortlet.Session.Remove("EditId");

                    }
                    break;
                default:
                    break;
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
            if (Session["FACinstdiv"].ToString().Length < 2)
            {
                ParentPortlet.ShowFeedback("Cannot process a blank INST_DIV");
                return;
            }


            //if (Session["userLevel"].ToString() == "Approver1")
            //{
            //    gv_Your_Approvals.DataSource = facultyApprovalsView.getYourApprover1RecordsFaculty(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACidnum"].ToString(),Session["FACinstdiv"].ToString());
            //    //gv_Your_Approvals.DataSource = approvalsView.getYourApprover1FacultyDiscipline(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Your_Approvals.DataBind();
            //}
            //else if (Session["userLevel"].ToString() == "Approver2")
            //{
            //    gv_Your_Approvals.DataSource = facultyApprovalsView.getYourApprover2RecordsFaculty(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACidnum"].ToString());
            //    //gv_Your_Approvals.DataSource = approvalsView.getYourApprover2FacultyDiscipline(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Your_Approvals.DataBind();
            //}
            //else if (Session["userLevel"].ToString() == "Approver3")
            //{
            //    gv_Your_Approvals.DataSource = facultyApprovalsView.getYourApprover3RecordsFaculty(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACidnum"].ToString());
            //    //gv_Your_Approvals.DataSource = approvalsView.getYourApprover3FacultyDiscipline(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Your_Approvals.DataBind();
            //}
            //else if (Session["userLevel"].ToString() == "FacCredUser")
            //{
            //    gv_Your_Approvals.DataSource = facultyApprovalsView.getYourFacCredUserRecordsFaculty(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["FACidnum"].ToString());
            //    //gv_Your_Approvals.DataSource = approvalsView.getYourFacCredUserFacultyDiscipline(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Your_Approvals.DataBind();
            //}

        }

        protected void btn_Faculty_Notes_Click(object sender, EventArgs e)
        {
            // clear out the edit screen for the next record
            //ParentPortlet.Session.Remove("EditId");
            ParentPortlet.NextScreen("FacultyNoteScreen");
        }
       
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            // clear out the edit screen for the next record
            ParentPortlet.Session.Remove("EditId");
            ParentPortlet.NextScreen("ApprovalsScreen");
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
                    ParentPortlet.ShowFeedback("Please select an Approval Status before saving");
                }
                else
                {
                    //rtn = approvalsView.InsertUpdateApproval(
                    //        ddl_Approval_Status.SelectedValue.ToString(),
                    //        Session["FACappid"].ToString(),
                    //        Session["FACidnum"].ToString(),
                    //        Session["SM_appid"].ToString(),
                    //        Session["approvalYear"].ToString(),
                    //        Session["approvalTerm"].ToString(),
                    //        Session["userLevel"].ToString(),
                    //        Session["approvalCourse"].ToString(),
                    //        Session["FACfirstname"].ToString(),
                    //        Session["FAClastname"].ToString(),
                    //        Session["FACinstructorType"].ToString(),
                    //        rightNow,
                    //        Session["FACinstdiv"].ToString()
                    //        );

                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback("Success");
                    }
                    else
                    {
                        //failure
                        ParentPortlet.ShowFeedback("Failed");
                    }
                }
            }
            catch
            {
                ParentPortlet.ShowFeedback("Trouble!");
            }


        }



        protected void DisciplineSave_Click(object sender, EventArgs e)
        {
            bool insertRtn = false;
            bool updateRtn = false;

            updateRtn = UpdateDisciplineRecs();

            if (Session["userLevel"].ToString() == "Approver1")
            {
                insertRtn = InsertDisciplineRecs();
            }
        }


        protected bool InsertDisciplineRecs()
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback("Please select an Approval Status before saving");
                }
                else
                {
                    //rtn = approvalsView.InsertDisciplineRecords(
                    //        //Session["approvalCode"].ToString(),
                    //        ddl_Approval_Status.SelectedValue.ToString(),
                    //        Session["FACappid"].ToString(),
                    //        Session["FACidnum"].ToString(),
                    //        Session["yearcode"].ToString(),
                    //        Session["termcode"].ToString(),
                    //        Session["SM_appid"].ToString(),
                    //        Session["userLevel"].ToString(),
                    //        Session["CRSdesc"].ToString(),
                    //        Session["FACfirstname"].ToString(),
                    //        Session["FAClastname"].ToString(),
                    //        Session["FACinstructorType"].ToString(),
                    //        rightNow,
                    //        Session["FACinstdiv"].ToString()                         
                    //     );


                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback("Success");

                    }
                    else
                    {
                        //failure - do not change screens
                        ParentPortlet.ShowFeedback("Failure");
                    }

                }
            }
            catch (Exception e)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = e.Message;
                ExceptionManager.Publish(e);
            }
            finally
            {
               
            }

            return rtn;
        }

        protected bool UpdateDisciplineRecs()
        {

            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0")
                {
                    ParentPortlet.ShowFeedback("Please select an Approval Status before saving");
                }
                else
                {

                    //rtn = approvalsView.UpdateDisciplineRecords(
                    //    ddl_Approval_Status.SelectedValue.ToString(),
                    //    Session["FACappid"].ToString(),
                    //    Session["FACidnum"].ToString(),
                    //    Session["yearcode"].ToString(),
                    //    Session["termcode"].ToString(),
                    //    Session["SM_appid"].ToString(),
                    //    Session["userLevel"].ToString(),
                    //    Session["CRSdesc"].ToString(),
                    //    Session["FACfirstname"].ToString(),
                    //    Session["FAClastname"].ToString(),
                    //    Session["FACinstructorType"].ToString(),
                    //    rightNow,
                    //    Session["FACinstdiv"].ToString()
                    
                    //    );


                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback("Success");
                    }
                    else
                    {
                        //failure
                        ParentPortlet.ShowFeedback("it failed");
                    }

                }
            }
            catch
            {
                ParentPortlet.ShowFeedback("Trouble!");
            }

            return rtn;
        }



        //----------------------- drop downs --------------------------------

        protected void ddl_Status_codes_OnLoad(object sender, EventArgs e)
        {
            // ddl_Status_codes.SelectedValue = "A";
        }

        //protected void ddl_Status_codes_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //view.setYear(DropDownList_year.SelectedValue);
        //    string approvalCode = ddl_Approval_Status.SelectedValue.ToString();
        //    Session["approvalCode"] = approvalCode;
        //}


        protected void ddl_Approval_Status_OnLoad(object sender, EventArgs e)
        {
            //  DropDownList_approval.SelectedValue = Session["approvalCode"].ToString();
            Session["approvalCode"] = "0";
        }

        protected void ddl_Approval_Status_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["approvalCode"]  = ddl_Approval_Status.SelectedValue.ToString();
        }



    }
}
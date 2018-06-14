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
using System.Web.SessionState;
using EX.Data.Services.Interfaces;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using Jenzabar.Portal.Framework;
using NHibernate.Linq.Functions;


namespace FacCred.Screens
{
    public partial class FacultyApprovalUpdateScreen : PortletViewBase
    {
        static DropDownView ddview = new DropDownView();
        static FacultyApprovalsView facultyApprovalsView = new FacultyApprovalsView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;Session["userLevel"].ToString();
            facNoteName.Text = Session["FACinstructorType"].ToString() + " : " + Session["FACfirstname"].ToString() + ' ' + Session["FAClastname"].ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsFirstLoad)
            {
                InitScreen();
            }

            loadTextFields();
        }

        private void InitScreen()
        {
            // set the date pickers to today and a year from now for new documents
            string DateFormat = "MM/dd/yyyy";
            string rightNow = DateTime.Now.ToString(DateFormat);

            DateTime theDate = DateTime.Now.Date;
            DateTime yearLater = theDate.AddYears(1);

            LoadDropDowns();

        }

        private void LoadDropDowns()
        {
            ddl_Approval_Status.DataSource = ddview.getApprovalCodes();
            ddl_Approval_Status.DataBind();           
        }

        private void loadTextFields()
        {
            if (Session["returningFromNotes"].ToString() == "true")
            {
                Session["returningFromNotes"] = "false";
                txt_Division.Text = Session["FACdivcode"].ToString();
                txt_InstDiv.Text = Session["FACinstdiv"].ToString();
                txt_SchoolCode.Text = Session["FACschoolcode"].ToString();
                if (Session["approvalApprovalDate"].ToString().Length > 6)
                    dp_Approval_Date.SelectedDate = DateTime.Parse(Session["approvalApprovalDate"].ToString());
                if (Session["approvalExpirationDate"].ToString().Length > 6)
                    dp_Expiration_Date.SelectedDate = DateTime.Parse(Session["approvalExpirationDate"].ToString());

                ddl_Approval_Status.SelectedValue = Session["approvalStatus"].ToString();
            }

        }


        private void LoadYourApprovals()
        {
            if (Session["userLevel"].ToString() == "Approver1")
            {
                gv_FacultyApprovalUpdate.DataSource = facultyApprovalsView.getYourApprover1RecordsFaculty(Session["FACidnum"].ToString(), Session["LIUuserID"].ToString(), Session["LIUfirstName"].ToString(), Session["LIUlastName"].ToString() );
                gv_FacultyApprovalUpdate.DataBind();
            }
            else if (Session["userLevel"].ToString() == "Approver2")
            {
                gv_FacultyApprovalUpdate.DataSource = facultyApprovalsView.getYourApprover2RecordsFaculty(Session["FACidnum"].ToString(), Session["LIUuserID"].ToString(), Session["LIUfirstName"].ToString(), Session["LIUlastName"].ToString());
                gv_FacultyApprovalUpdate.DataBind();
            }
            else if (Session["userLevel"].ToString() == "Approver3")
            {
                gv_FacultyApprovalUpdate.DataSource = facultyApprovalsView.getYourApprover3RecordsFaculty(Session["FACidnum"].ToString(), Session["LIUuserID"].ToString(), Session["LIUfirstName"].ToString(), Session["LIUlastName"].ToString());
                gv_FacultyApprovalUpdate.DataBind();
            }
        }


        protected void gv_FacultyApprovalUpdate_PreRender(object sender, EventArgs e)
        {
            LoadYourApprovals();

            if (gv_FacultyApprovalUpdate.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_FacultyApprovalUpdate.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_FacultyApprovalUpdate.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_FacultyApprovalUpdate.FooterRow.TableSection = TableRowSection.TableFooter;
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

        protected void gv_FacultyApprovalUpdate_IndexChanging(object sender, EventArgs e)
        {
            //word
        }


        protected void gv_FacultyApprovalUpdate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_FacultyApprovalUpdate.Rows[rowIndex];

           // if (rowIndex == 0) return;

            ParentPortlet.Session["EditId"] = gv_FacultyApprovalUpdate.DataKeys[rowIndex].Value.ToString();
            Session["FACappid"] = (string)this.gv_FacultyApprovalUpdate.DataKeys[rowIndex]["FACappid"];
            Session["FACidnum"] = (string)this.gv_FacultyApprovalUpdate.DataKeys[rowIndex]["FACidnum"];

            Session["approvalStatus"] = row.Cells[1].Text;
            Session["FAClastname"] = row.Cells[2].Text;
            Session["FACfirstname"] = row.Cells[3].Text;
            Session["FACtype"] = row.Cells[4].Text;

            if (row.Cells[5].Text.Length < 2 || row.Cells[5].Text.Length > 3)
            {
                Session["FACdivcode"] = " ";
                txt_Division.Text = " ";
            }
            else
            {
                Session["FACdivcode"] = row.Cells[5].Text;
                txt_Division.Text = row.Cells[5].Text;
            }

            if (row.Cells[6].Text.Length < 2 || row.Cells[6].Text.Length > 3)
            {
                Session["FACinstdiv"] = " ";
                txt_InstDiv.Text = " ";
            }
            else
            {
                Session["FACinstdiv"] = row.Cells[6].Text;
                txt_InstDiv.Text = row.Cells[6].Text;
            }

            if (row.Cells[7].Text.Length < 2 || row.Cells[7].Text.Length > 3)
            {
                Session["FACschoolcode"] = " ";
                txt_SchoolCode.Text = " ";
            }
            else
            {
                Session["FACschoolcode"] = row.Cells[7].Text;
                txt_SchoolCode.Text = row.Cells[7].Text;
            }



            Session["approvalApprovalDate"] = row.Cells[8].Text;
            Session["approvalExpirationDate"] = row.Cells[9].Text;


            if (row.Cells[8].Text.Length > 6)
            {
                dp_Approval_Date.SelectedDate = DateTime.Parse(row.Cells[8].Text);
            }
            else
            {
                dp_Approval_Date.SelectedDate = DateTime.Now;
            }
            if (row.Cells[9].Text.Length > 6)
            {
                dp_Expiration_Date.SelectedDate = DateTime.Parse(row.Cells[9].Text);
            }
            else
            {
               // dp_Expiration_Date.SelectedDate = DateTime.MaxValue;
            }


            switch (cmdName)
            {

                case "gv_FacultyApprovalUpdate_Edit":
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

                default:
                break;
            }
        }


        protected void btn_Faculty_Notes_Click(object sender, EventArgs e)
        {
            // clear out the edit screen for the next record
            //ParentPortlet.Session.Remove("EditId");
            Session["returningFromNotes"] = "true";
            ParentPortlet.NextScreen("FacultyNoteScreen");
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            // clear out the edit screen for the next record

            //ddl_Approval_Status.SelectedValue = Session["approvalStatus"].ToString();
            ParentPortlet.Session.Remove("EditId");
            ParentPortlet.PreviousScreen();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);
            //DateTime rightNow = DateTime.Now;

            string et;

            if (dp_Expiration_Date.DateIsEmpty)
            {
                et = DateTime.MaxValue.ToString(DateFormat);
            }
            else
            {
                et = dp_Expiration_Date.SelectedDate.ToString(DateFormat);
                Session["approvalExpirationDate"] = et;
            }

            if (Session["FACinstdiv"].ToString().Length < 2 || Session["FACinstdiv"].ToString().Length > 2)
            {
                ParentPortlet.ShowFeedback(FeedbackType.Error, "Cannot Approve a blank InstDiv");
                return;
            }

            try
            {
                if (ddl_Approval_Status.SelectedValue.ToString() == "0"  || dp_Approval_Date.DateIsEmpty || txt_InstDiv.Text.Length < 1)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "Please Edit a record, then select a value in each of the three fields before saving");
                }
                else
                {
                    rtn = facultyApprovalsView.InsertUpdateFacultyApproval( ddl_Approval_Status.SelectedValue.ToString(),
                                                                            Session["FACappid"].ToString(),
                                                                            Session["FACidnum"].ToString(),
                                                                            Session["FACdivcode"].ToString(),
                                                                            Session["FACinstdiv"].ToString(),
                                                                            Session["FACschoolcode"].ToString(),
                                                                            Session["FAClastname"].ToString(),
                                                                            Session["FACfirstname"].ToString(),
                                                                            Session["FACinstructorType"].ToString(), 
                                                                            dp_Approval_Date.SelectedDate.ToString(DateFormat),
                                                                            et,
                                                                            rightNow,
                                                                            Session["userLevel"].ToString()   );
                        
                    if (rtn)
                    {
                        //success
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "Faculty Approval Status Saved");

                    }
                    else
                    {
                        //failure
                        ParentPortlet.ShowFeedback(FeedbackType.Error, "No Love :(");
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

        protected void btn_Division_Save_Click(object sender, EventArgs e)
        {

            bool updateRtn = false;

            updateRtn = UpdateFacultyDivisionRecs();

            if (Session["userLevel"].ToString() == "Approver1")
            {
                if (updateRtn)
                {

                    InsertFacultyDivisionRecs();

                }

            }
        }
        protected void btn_InstDiv_Save_Click(object sender, EventArgs e)
        {
 
            bool updateRtn = false;

               updateRtn = UpdateFacultyInstDivRecs();

            if (Session["userLevel"].ToString() == "Approver1")
            {
                if (updateRtn)
                {

                    InsertFacultyInstDivRecs();

                }

            }
        }
        protected void btn_SchoolCode_Save_Click(object sender, EventArgs e)
        {

            bool updateRtn = false;

            updateRtn = UpdateFacultySchoolCodeRecs();

            if (Session["userLevel"].ToString() == "Approver1")
            {
                if (updateRtn)
                {

                    InsertFacultySchoolCodeRecs();

                }

            }
        }

        //protected void btn_Discipline_Save_Click(object sender, EventArgs e)
        //{

        //    bool updateRtn = false;

        //    updateRtn = UpdateFacultyDisciplineRecs();

        //    if (Session["userLevel"].ToString() == "Approver1")
        //    {
        //        if (updateRtn)
        //        {

        //            InsertFacultyDisciplineRecs();

        //        }

        //    }
        //}


        protected bool InsertFacultyInstDivRecs()
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
                else if (txt_InstDiv.Text.Length < 2 )
                {
                    ParentPortlet.ShowFeedback("Cannot process a blank InstDiv");
                }
                else
                {
                    rtn = facultyApprovalsView.InsertFacultyInstDivRecords(
                            ddl_Approval_Status.SelectedValue.ToString(),
                            Session["FACappid"].ToString(),
                            Session["FACidnum"].ToString(),
                            Session["userLevel"].ToString(),
                            Session["FACfirstname"].ToString(),
                            Session["FAClastname"].ToString(),
                            Session["FACinstructorType"].ToString(),
                            dp_Approval_Date.SelectedDate.ToString(DateFormat),
                            dp_Expiration_Date.SelectedDate.ToString(DateFormat),
                            rightNow,
                           // Session["FACinstdiv"].ToString()
                            txt_InstDiv.Text
                         );

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
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized("Update Failed");
            }

            return rtn;
        }

        protected bool UpdateFacultyInstDivRecs()
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
                    rtn = facultyApprovalsView.UpdateFacultyInstDivRecords(
                        ddl_Approval_Status.SelectedValue.ToString(),
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        Session["userLevel"].ToString(),
                        Session["FACfirstname"].ToString(),
                        Session["FAClastname"].ToString(),
                        Session["FACinstructorType"].ToString(),
                        dp_Approval_Date.SelectedDate.ToString(DateFormat),
                        dp_Expiration_Date.SelectedDate.ToString(DateFormat),
                        rightNow,
                        txt_InstDiv.Text

                        );


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
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized("Update Failed");
            }

            return rtn;
        }


        //---------------------  DIVISION -----------------------------------
        protected bool InsertFacultyDivisionRecs()
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
                    rtn = facultyApprovalsView.InsertFacultyDivisionRecords(
                            ddl_Approval_Status.SelectedValue.ToString(),
                            Session["FACappid"].ToString(),
                            Session["FACidnum"].ToString(),
                            Session["userLevel"].ToString(),
                            Session["FACfirstname"].ToString(),
                            Session["FAClastname"].ToString(),
                            Session["FACinstructorType"].ToString(),
                            dp_Approval_Date.SelectedDate.ToString(DateFormat),
                            dp_Expiration_Date.SelectedDate.ToString(DateFormat),
                            rightNow,
                            txt_Division.Text
                         );

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
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized("Update Failed");
            }
            finally
            {

            }

            return rtn;
        }

        protected bool UpdateFacultyDivisionRecs()
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
                else if (txt_Division.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback("Cannot process a blank Division");
                }
                else
                {
                    rtn = facultyApprovalsView.UpdateFacultyDivisionRecords(
                        ddl_Approval_Status.SelectedValue.ToString(),
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        Session["userLevel"].ToString(),
                        Session["FACfirstname"].ToString(),
                        Session["FAClastname"].ToString(),
                        Session["FACinstructorType"].ToString(),
                        dp_Approval_Date.SelectedDate.ToString(DateFormat),
                        dp_Expiration_Date.SelectedDate.ToString(DateFormat),
                        rightNow,
                        txt_Division.Text
                        );


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
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized("Update Failed");
            }

            return rtn;
        }


        //------------------   SCHOOL CODE  ---------------------------------
        protected bool InsertFacultySchoolCodeRecs()
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
                    rtn = facultyApprovalsView.InsertFacultySchoolCodeRecords(
                            ddl_Approval_Status.SelectedValue.ToString(),
                            Session["FACappid"].ToString(),
                            Session["FACidnum"].ToString(),
                            Session["userLevel"].ToString(),
                            Session["FACfirstname"].ToString(),
                            Session["FAClastname"].ToString(),
                            Session["FACinstructorType"].ToString(),
                            dp_Approval_Date.SelectedDate.ToString(DateFormat),
                            dp_Expiration_Date.SelectedDate.ToString(DateFormat),
                            rightNow,
                            txt_SchoolCode.Text
                         );

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
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized("Update Failed");
            }

            return rtn;
        }

        protected bool UpdateFacultySchoolCodeRecs()
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
                else if (txt_SchoolCode.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback("Cannot process a blank SchoolCode");
                }
                else
                {
                    rtn = facultyApprovalsView.UpdateFacultySchoolCodeRecords(
                        ddl_Approval_Status.SelectedValue.ToString(),
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        Session["userLevel"].ToString(),
                        Session["FACfirstname"].ToString(),
                        Session["FAClastname"].ToString(),
                        Session["FACinstructorType"].ToString(),
                        dp_Approval_Date.SelectedDate.ToString(DateFormat),
                        dp_Expiration_Date.SelectedDate.ToString(DateFormat),
                        rightNow,
                        txt_SchoolCode.Text
                        );

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
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized("Update Failed");
            }

            return rtn;
        }


        //  ---------  DISCIPLINE  ---------------------------------------

        protected bool InsertFacultyDisciplineRecs()
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
                    rtn = facultyApprovalsView.InsertFacultyDisciplineRecords(
                            ddl_Approval_Status.SelectedValue.ToString(),
                            Session["FACappid"].ToString(),
                            Session["FACidnum"].ToString(),
                            Session["userLevel"].ToString(),
                            Session["FACfirstname"].ToString(),
                            Session["FAClastname"].ToString(),
                            Session["FACinstructorType"].ToString(),
                            dp_Approval_Date.SelectedDate.ToString(DateFormat),
                            dp_Expiration_Date.SelectedDate.ToString(DateFormat),
                            rightNow,
                            txt_InstDiv.Text
                         );

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
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized("Update Failed");
            }

            return rtn;
        }

        protected bool UpdateFacultyDisciplineRecs()
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
                else if (txt_InstDiv.Text.Length < 2)
                {
                    ParentPortlet.ShowFeedback("Cannot process a blank INST_DIV");
                }
                else
                {
                    rtn = facultyApprovalsView.UpdateFacultyDisciplineRecords(
                        ddl_Approval_Status.SelectedValue.ToString(),
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        Session["userLevel"].ToString(),
                        Session["FACfirstname"].ToString(),
                        Session["FAClastname"].ToString(),
                        Session["FACinstructorType"].ToString(),
                        dp_Approval_Date.SelectedDate.ToString(DateFormat),
                        dp_Expiration_Date.SelectedDate.ToString(DateFormat),
                        rightNow,
                        txt_InstDiv.Text
                        );

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
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.ErrorMessage = ex.Message;
                ExceptionManager.Publish(ex);
                ParentPortlet.ShowFeedbackGlobalized("Update Failed");
            }

            return rtn;
        }



        //----------------------- drop downs --------------------------------

        protected void ddl_Status_codes_OnLoad(object sender, EventArgs e)
        {
            // ddl_Status_codes.SelectedValue = "A";
        }


        protected void ddl_Approval_Status_OnLoad(object sender, EventArgs e)
        {
            //  DropDownList_approval.SelectedValue = Session["approvalCode"].ToString();
            Session["approvalCode"] = "0";
        }

        protected void ddl_Approval_Status_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["approvalCode"] = ddl_Approval_Status.SelectedValue.ToString();
        }



    }
}
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
    public partial class FacultyNoteScreen : PortletViewBase
    {
        static DropDownView ddview = new DropDownView();
        //static FacultyView facultyView = new FacultyView();
        private static NoteView noteView = new NoteView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;Session["userLevel"].ToString();
            facNoteName.Text =    Session["FACinstructorType"].ToString() + " : " +  Session["FACfirstname"].ToString() + ' ' + Session["FAClastname"].ToString() ;
            lblDiscipline.Text =  "  SCHOOL_CODE: " + Session["FACschoolcode"].ToString()    +    " INST_DIV: " + Session["FACinstdiv"].ToString() ;
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

            dp_Approval_Date.SelectedDate = DateTime.Now;
            dp_Expiration_Date.SelectedDate = yearLater;

            LoadDropDowns();
         
        }

        private void LoadDropDowns()
        {
            ddl_Status_codes.DataSource = ddview.getStatusCodes();
            ddl_Status_codes.DataBind();

            ddl_Note_Types.DataSource = ddview.getNoteTypes();
            ddl_Note_Types.DataBind();

            ddl_Note_levels.DataSource = ddview.getNoteLevels();
            ddl_Note_levels.DataBind();
  
        }


        protected void gv_Notes_PreRender(object sender, EventArgs e)
        {
            LoadNotes();

            if (gv_Notes.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Notes.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Notes.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Notes.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }

        private void LoadNotes()
        {
            //NotesMapperService noteService = new NotesMapperService();
            //IList<NotesNHibernate> notes = new List<NotesNHibernate>();
            //notes = noteService.GetFacultyYTDDFNotes(Session["FACidnum"].ToString(), Session["termcode"].ToString(), Session["yearcode"].ToString(), Session["FACschoolcode"].ToString(), Session["FACinstdiv"].ToString());
            //gv_Notes.DataSource = notes;
            //gv_Notes.DataBind();

            //REMOVING NHIBERNATE, but leaving the code behind . . . just in case :)

            gv_Notes.DataSource = noteView.getFacultyNotes(Session["FACidnum"].ToString(), Session["termcode"].ToString(), Session["yearcode"].ToString(), Session["FACschoolcode"].ToString(), Session["FACinstdiv"].ToString());
            gv_Notes.DataBind();

            
        }


        protected void gv_Notes_IndexChanging(object sender, EventArgs e)
        {
            //word
        }


        protected void gv_Notes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Notes.Rows[rowIndex];


            ParentPortlet.Session["EditId"] = gv_Notes.DataKeys[rowIndex].Value.ToString();


            switch (cmdName)
            {

                case "gv_Notes_Edit":
                    {
                        //var notesService = new NotesMapperService();

                        Guid noteId = new Guid(ParentPortlet.Session["EditId"].ToString());

                        //var note = notesService.GetNote(noteId);
                        DataTable dt = noteView.getOneFacultyNote(noteId);

                        foreach (DataRow onerow in dt.Rows )
                        {
                            txt_Subject.Text = onerow["SUBJECT"].ToString().Trim();
                            txtNote.InnerText = onerow["NOTE"].ToString().Trim();
                            ddl_Note_Types.SelectedValue = onerow["NOTE_TYPE"].ToString();
                            ddl_Status_codes.SelectedValue = onerow["STATUS"].ToString();
                            ddl_Note_levels.SelectedValue = onerow["NOTE_LEVEL"].ToString();
                            dp_Approval_Date.SelectedDate = Convert.ToDateTime(onerow["APPROVAL_DATE"]);
                            dp_Expiration_Date.SelectedDate = Convert.ToDateTime(onerow["EXPIRATION_DATE"]);
                        }

                        //gv_OneNote.DataSource = noteView.getOneFacultyNote(noteId);
                        //gv_OneNote.DataBind();

                        //txt_Subject.Text = oneSUBJECT.ToString();
                        //txtNote.InnerText = oneNOTE.ToString();
                        //ddl_Note_Types.SelectedValue = oneNOTE_TYPE.ToString();  
                        //ddl_Status_codes.SelectedValue = oneSTATUS.ToString();
                        //ddl_Note_levels.SelectedValue = oneNOTE_LEVEL.ToString();
                        //dp_Approval_Date.SelectedDate = Convert.ToDateTime(oneAPPROVAL_DATE);
                        //dp_Expiration_Date.SelectedDate = Convert.ToDateTime(oneEXPIRATION_DATE);


                        //if (note == null)
                        //{
                        //    ParentPortlet.ShowFeedback(FeedbackType.Error, "Note could not be loaded");
                        //    return;
                        //}
                        //txt_Subject.Text = note.SUBJECT;
                        //txtNote.InnerText = note.NOTE;
                        //ddl_Note_Types.SelectedValue = note.NOTE_TYPE;
                        //ddl_Status_codes.SelectedValue = note.STATUS;
                        //ddl_Note_levels.SelectedValue = note.NOTE_LEVEL;
                        //dp_Approval_Date.SelectedDate = Convert.ToDateTime(note.APPROVAL_DATE);
                        //dp_Expiration_Date.SelectedDate = Convert.ToDateTime(note.EXPIRATION_DATE);


                    }
                    break;
                case "gv_Notes_Archive":
                    {
                        //var notesService = new NotesMapperService();
                        ////var notesArchiveService = new NotesArchiveMapperService();
                        Guid noteId = new Guid(ParentPortlet.Session["EditId"].ToString());
                        bool rtn = false;

                        try
                        {
                            rtn = noteView.moveNoteToArchive(noteId);

                            if (rtn)
                            {
                                ParentPortlet.ShowFeedback(FeedbackType.Success, "Note Successfully Archived!");
                            }
                            else
                            {
                                ParentPortlet.ShowFeedback(FeedbackType.Error, "Note was not Archived!");
                            }

                        }
                        catch (Exception exception)
                        {
                            var msg = PortalUser.Current.IsSiteAdmin
                                ? "This note was not Archived. " + exception.Message
                                : "This note was not Archived. ";

                            this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

                            ExceptionManager.Publish(exception);

                        }

                        // NHIBERNATE CODE . . . LEAVING FOR NOW
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

                        ParentPortlet.Session.Remove("EditId");
                        
                    }
                    break;
            }
        }


        protected void btn_Archive_Click(object sender, EventArgs e)
        {
           ParentPortlet.NextScreen("FacultyNoteArchiveScreen");
        }

        protected void btn_Degrees_Click(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("EDUEarnHistScreen");
        }


        //protected void btn_New_Click(object sender, EventArgs e)
        //{
        //    string DateFormat = "MM-dd-yyyy";
        //    string rightNow = DateTime.Now.ToString(DateFormat);

        //    DateTime theDate = DateTime.Now;
        //    DateTime yearLater = theDate.AddYears(1);

        //    ParentPortlet.Session["EditId"] = null;

        //    ddl_Note_Types.SelectedValue = "0";
        //    ddl_Note_levels.SelectedValue = "0";
        //    txt_Subject.Text = "";
        //    txtNote.InnerText = "";
        //    ddl_Status_codes.SelectedValue = "A";

        //    dp_Approval_Date.SelectedDate = DateTime.Now;
        //    dp_Expiration_Date.SelectedDate = yearLater;

        //    ParentPortlet.Session.Remove("EditId");
        //}

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            //NotesMapperService notesService = new NotesMapperService();
            //NotesNHibernate note = new NotesNHibernate();
            //var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();

            string DateFormat = "yyyy-MM-dd";
            string updateFormat = "yyyy-MM-dd hh:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);
            string updateRightNow = DateTime.Now.ToString(updateFormat);
            bool rtn = false;



            if (ddl_Note_Types.SelectedValue == "0")
            {
                ParentPortlet.ShowFeedback(FeedbackType.Error, "Please Select a Note Type");
                return;
            }
            if (ddl_Note_levels.SelectedValue == "0")
            {
                ParentPortlet.ShowFeedback(FeedbackType.Error, "Please Select a Note Level");
                return;
            }

            if (ddl_Note_levels.SelectedValue == "YEARTERM")
            {
                if (Session["yearcode"].ToString() == "YR" || Session["termcode"].ToString() == "TRM")
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Error, " Don't forget to select a YEAR and TERM first :) ");
                    return;
                }
            }


            if (ddl_Note_levels.SelectedValue == "FACULTY")
            {
                // faculty notes do not need DISCIPLINE ,INST_DIV , DIVISION OR SCHOOL_CDE
            }
            else
            {
                if (Session["FACdivcode"].ToString().Length > 2 || Session["FACdivcode"].ToString().Length < 2)
                {
                    Session["FACdivcode"] = "UG";
                }

                if (Session["FACinstdiv"].ToString().Length > 2 || Session["FACinstdiv"].ToString().Length < 2)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Error, "Cannot create a Note for a Blank InstDivision");
                    return;
                }

                if (Session["FACschoolcode"].ToString().Length > 2 || Session["FACschoolcode"].ToString().Length < 2)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Error, "Cannot create a Note for a Blank SchoolCode");
                    return;
                }

            }



            if (ParentPortlet.Session["EditId"].ToString().Length  > 20  && ParentPortlet.Session["EditId"].ToString() != "00000000-0000-0000-0000-000000000000")
            {
                //EDIT A SELECTED NOTE
                Guid noteId = new Guid(ParentPortlet.Session["EditId"].ToString());
                rtn = false;

                rtn = noteView.updateOneFacultyNote(noteId, txt_Subject.Text, ddl_Status_codes.SelectedValue,  txtNote.InnerText,
                    ddl_Note_Types.SelectedValue, ddl_Note_levels.SelectedValue, 
                    dp_Approval_Date.SelectedDate, dp_Expiration_Date.SelectedDate, PortalUser.Current.Username, updateRightNow);

                if (rtn)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Success, "Note Successfully Updated!");
                }
                else
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Error, "Note was not Updated!");
                }

            }
            else
            {
                if (ParentPortlet.Session["noteLevel"].ToString() == "FACULTY")
                {
                    //CREATE A FACULTY SPECIFIC NOTE WITH NO YEAR AND TERM DATA
                    Guid noteId = Guid.NewGuid();
                    rtn = false;
                    //note = new NotesNHibernate

                    rtn = noteView.insertOneFacultyNote(noteId,
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        txt_Subject.Text,
                        ddl_Status_codes.SelectedValue.ToString(),
                        txtNote.InnerText,
                        ddl_Note_Types.SelectedValue.ToString(),
                        ddl_Note_levels.SelectedValue.ToString(),
                        Session["FACinstructorType"].ToString(),
                        dp_Approval_Date.SelectedDate,
                        dp_Expiration_Date.SelectedDate,
                        PortalUser.Current.Username,
                        DateTime.Now,
                        PortalUser.Current.Username,
                        updateRightNow);

                    if (rtn)
                    {
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "Faculty Note Successfully Created!");
                    }
                    else
                    {
                        ParentPortlet.ShowFeedback(FeedbackType.Error, "Faculty Note was not Created!");
                    }

                    // NHIBERNATE SETTINGS
                    //{
                    //    NOTE_ID = noteId,
                    //    FAC_APPID = Session["FACappid"].ToString(),
                    //    FAC_ID_NUM = Session["FACidnum"].ToString(),
                    //    SM_APPID = "",
                    //    CRS_CDE = "",
                    //    CRS_TITLE = "",
                    //    DIV_CDE = "",
                    //    INSTIT_DIV_CDE = "",
                    //    SCHOOL_CDE = "",
                    //    YEARCODE = "",
                    //    TERMCODE = "",
                    //    SUBJECT = txt_Subject.Text,
                    //    STATUS = ddl_Status_codes.SelectedValue.ToString(),
                    //    NOTE = txtNote.InnerText,
                    //    NOTE_TYPE = ddl_Note_Types.SelectedValue.ToString(),
                    //    NOTE_LEVEL = ddl_Note_levels.SelectedValue.ToString(),
                    //    FAC_TYPE = Session["FACinstructorType"].ToString(),
                    //    APPROVAL_DATE = dp_Approval_Date.SelectedDate,
                    //    EXPIRATION_DATE = dp_Expiration_Date.SelectedDate,
                    //    CREATE_BY = PortalUser.Current.Username,
                    //    CREATE_DATE = DateTime.Now,
                    //    UPDATE_BY = PortalUser.Current.Username,
                    //    UPDATE_DATE = updateRightNow
                    //};

                }
                else
                {
                    //CREATE A NEW NOTE
                    Guid noteId = Guid.NewGuid();
                    rtn = false;
                    //note = new NotesNHibernate

                    rtn = noteView.insertOneFacultyNote(noteId,
                        Session["FACappid"].ToString(),
                        Session["FACidnum"].ToString(),
                        "",
                        "",
                        "",
                        Session["FACdivcode"].ToString(),
                        Session["FACinstdiv"].ToString(),
                        Session["FACschoolcode"].ToString(),
                        Session["yearcode"].ToString(),
                        Session["termcode"].ToString(),
                        txt_Subject.Text,
                        ddl_Status_codes.SelectedValue.ToString(),
                        txtNote.InnerText,
                        ddl_Note_Types.SelectedValue.ToString(),
                        ddl_Note_levels.SelectedValue.ToString(),
                        Session["FACinstructorType"].ToString(),
                        dp_Approval_Date.SelectedDate,
                        dp_Expiration_Date.SelectedDate,
                        PortalUser.Current.Username,
                        DateTime.Now,
                        PortalUser.Current.Username,
                        updateRightNow);

                    if (rtn)
                    {
                        ParentPortlet.ShowFeedback(FeedbackType.Success, "YEARTERM Note Successfully Created!");
                    }
                    else
                    {
                        ParentPortlet.ShowFeedback(FeedbackType.Error, "YEARTERM Note was not Created!");
                    }


                    // NHIBERNATE SETTINGS
                    //{
                    //    NOTE_ID = noteId,
                    //    FAC_APPID = Session["FACappid"].ToString(),
                    //    FAC_ID_NUM = Session["FACidnum"].ToString(),
                    //    SM_APPID = "",
                    //    CRS_CDE = "",
                    //    CRS_TITLE = "",
                    //    DIV_CDE = Session["FACdivcode"].ToString(),
                    //    INSTIT_DIV_CDE = Session["FACinstdiv"].ToString(),
                    //    SCHOOL_CDE = Session["FACschoolcode"].ToString(),
                    //    YEARCODE = Session["yearcode"].ToString(),
                    //    TERMCODE = Session["termcode"].ToString(),
                    //    SUBJECT = txt_Subject.Text,
                    //    STATUS = ddl_Status_codes.SelectedValue.ToString(),
                    //    NOTE = txtNote.InnerText,
                    //    NOTE_TYPE = ddl_Note_Types.SelectedValue.ToString(),
                    //    NOTE_LEVEL = ddl_Note_levels.SelectedValue.ToString(),
                    //    FAC_TYPE = Session["FACinstructorType"].ToString(),
                    //    APPROVAL_DATE = dp_Approval_Date.SelectedDate,
                    //    EXPIRATION_DATE = dp_Expiration_Date.SelectedDate,
                    //    CREATE_BY = PortalUser.Current.Username,
                    //    CREATE_DATE = DateTime.Now,
                    //    UPDATE_BY = PortalUser.Current.Username,
                    //    UPDATE_DATE = updateRightNow
                    //};
                }

            }


            try
            {
                // clear out the edit screen for the next record
                DateTime theDate = DateTime.Now;
                DateTime yearLater = theDate.AddYears(1);

                ParentPortlet.Session["EditId"] = null;

                ddl_Note_Types.SelectedValue = "0";
                ddl_Note_levels.SelectedValue = "0";
                txt_Subject.Text = "";
                txtNote.InnerText = "";
                ddl_Status_codes.SelectedValue = "A";

                dp_Approval_Date.SelectedDate = DateTime.Now;
                dp_Expiration_Date.SelectedDate = yearLater;

                ParentPortlet.Session.Remove("EditId");

                LoadNotes();

            }
            catch (Exception exception)
            {
                var msg = PortalUser.Current.IsSiteAdmin
                    ? "This note was not created! Error: " + exception.Message
                    : "This note was not created! Sorry!";

                this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);
                ExceptionManager.Publish(exception);
                return;
            }
            finally
            {
               // nHibernateSession.Close();
            }

        }


        protected void ArchiveNote(NotesNHibernate originalNote)
        {
            //    var notesArchiveService = new NotesArchiveMapperService();
            //    var note = new NotesArchiveNHibernate();
            //    var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();

            //    note = new NotesArchiveNHibernate
            //    {
            //        NOTE_ID = originalNote.NOTE_ID,
            //        FAC_APPID = originalNote.FAC_APPID,
            //        FAC_ID_NUM = originalNote.FAC_ID_NUM,
            //        SM_APPID = originalNote.SM_APPID,
            //        CRS_CDE = originalNote.CRS_CDE,
            //        CRS_TITLE = originalNote.CRS_TITLE,
            //        DIV_CDE = originalNote.DIV_CDE,
            //        INSTIT_DIV_CDE = originalNote.INSTIT_DIV_CDE,
            //        SCHOOL_CDE = originalNote.SCHOOL_CDE,
            //        YEARCODE = originalNote.YEARCODE,
            //        TERMCODE = originalNote.TERMCODE ,
            //        SUBJECT = originalNote.SUBJECT,
            //        STATUS = originalNote.STATUS,
            //        NOTE = originalNote.NOTE,
            //        NOTE_TYPE = originalNote.NOTE_TYPE,
            //        NOTE_LEVEL = originalNote.NOTE_LEVEL,
            //        FAC_TYPE = originalNote.FAC_TYPE,
            //        APPROVAL_DATE = originalNote.APPROVAL_DATE,
            //        EXPIRATION_DATE = originalNote.EXPIRATION_DATE,
            //        CREATE_BY = originalNote.CREATE_BY,
            //        CREATE_DATE = originalNote.CREATE_DATE,
            //        UPDATE_BY = originalNote.UPDATE_BY,
            //        UPDATE_DATE = originalNote.UPDATE_DATE
            //    };

            //    try
            //    {
            //        using (var transaction = nHibernateSession.BeginTransaction())
            //        {
            //            nHibernateSession.SaveOrUpdate(note);
            //            transaction.Commit();

            //            ParentPortlet.ShowFeedback(FeedbackType.Success, "Note  Successfully Archived!");                    
            //        }




            // clear out the edit screen for the next record
            DateTime theDate = DateTime.Now;
            DateTime yearLater = theDate.AddYears(1);

            ParentPortlet.Session["EditId"] = null;

            ddl_Note_Types.SelectedValue = "0";
            ddl_Note_levels.SelectedValue = "0";
            txt_Subject.Text = "";
            txtNote.InnerText = "";
            ddl_Status_codes.SelectedValue = "A";

            dp_Approval_Date.SelectedDate = DateTime.Now;
            dp_Expiration_Date.SelectedDate = yearLater;

            ParentPortlet.Session.Remove("EditId");

            LoadNotes();

            //    }
            //    catch (Exception exception)
            //    {
            //        var msg = PortalUser.Current.IsSiteAdmin
            //            ? "This note was not Archived! Error: " + exception.Message
            //            : "This note was not Archived! Sorry!";

            //        this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);
            //        ExceptionManager.Publish(exception);
            //        return;
            //    }
            //    finally
            //    {
            //        nHibernateSession.Close();
            //    }

        }




        protected void btn_Back_Click(object sender, EventArgs e)
        {
            // clear out the edit screen for the next record
            ParentPortlet.Session.Remove("EditId");
            ParentPortlet.PreviousScreen();
        }

        //----------------------- drop downs --------------------------------

        protected void ddl_Status_codes_OnLoad(object sender, EventArgs e)
        {
           // ddl_Status_codes.SelectedValue = "A";
        }

        protected void ddl_Status_codes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
            // string approvalCode = DropDownList_approval.SelectedValue.ToString();
            // Session["approvalCode"] = approvalCode;
        }

        protected void ddl_Note_Types_OnLoad(object sender, EventArgs e)
        {
            
        }

        protected void ddl_Note_Types_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
            // string approvalCode = DropDownList_approval.SelectedValue.ToString();
            // Session["approvalCode"] = approvalCode;
        }

        protected void ddl_Note_levels_OnLoad(object sender, EventArgs e)
        {
          //  ParentPortlet.Session["noteLevel"] = ddl_Note_levels.SelectedValue.ToString();           
        }


        protected void ddl_Note_levels_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ParentPortlet.Session["noteLevel"] = ddl_Note_levels.SelectedValue.ToString();
        }


        protected void ddl_noteLevel_filter_OnLoad(object sender, EventArgs e)
        {
            if (ParentPortlet.Session["noteLevelFilter"] == null)
            {
                ParentPortlet.Session["noteLevelFilter"] = "ALL";
            }
        }
        protected void ddl_noteLevel_filter_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           
            //ParentPortlet.Session["noteLevelFilter"] = ddl_noteLevel_filter.SelectedItem.ToString();
            //LoadNotes();
        }



    }
}
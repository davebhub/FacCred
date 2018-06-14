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
    public partial class FacultyNoteArchiveScreen : PortletViewBase
    {
        NoteArchiveView noteArchiveView = new NoteArchiveView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;Session["userLevel"].ToString();
            facNoteName.Text = Session["FACinstructorType"].ToString() + " : " + Session["FACfirstname"].ToString() + ' ' + Session["FAClastname"].ToString();
            lblDiscipline.Text = "  SCHOOL_CODE: " + Session["FACschoolcode"].ToString() + "  INST_DIV: " + Session["FACinstdiv"].ToString();
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

            LoadNotes();
        }


        private void LoadNotes()
        {
            //NotesArchiveMapperService noteService = new NotesArchiveMapperService();
            //IList<NotesArchiveNHibernate> notes = new List<NotesArchiveNHibernate>();
            //notes = noteService.GetFacultyYTDDFNotes(Session["FACidnum"].ToString(), Session["termcode"].ToString(), Session["yearcode"].ToString(), Session["FACschoolcode"].ToString(), Session["FACinstdiv"].ToString());
            //gv_ArchivedNotes.DataSource = notes;
            //gv_ArchivedNotes.DataBind();

            gv_ArchivedNotes.DataSource = noteArchiveView.getFacultyArchiveNotes(Session["FACidnum"].ToString(), Session["termcode"].ToString(), Session["yearcode"].ToString(), Session["FACschoolcode"].ToString(), Session["FACinstdiv"].ToString());
            gv_ArchivedNotes.DataBind();
        }

        protected void gv_ArchivedNotes_PreRender(object sender, EventArgs e)
        {
           // LoadNotes();

            if (gv_ArchivedNotes.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_ArchivedNotes.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_ArchivedNotes.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_ArchivedNotes.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }

        protected void gv_ArchivedNotes_IndexChanging(object sender, EventArgs e)
        {
            //word
        }


        protected void gv_ArchivedNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //NotesArchiveMapperService notesService = new NotesArchiveMapperService();
            //NotesArchiveNHibernate note = new NotesArchiveNHibernate();
            //var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();

            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();


            int rowIndexArch = Convert.ToInt32(e.CommandArgument);
            if (rowIndexArch >= 0)
            {
                var rowArch = gv_ArchivedNotes.Rows[rowIndexArch];


                if (rowArch != null)
                {
                    ParentPortlet.Session["EditId"] = gv_ArchivedNotes.DataKeys[rowIndexArch].Value.ToString();
                }
                else
                {
                    return;
                }
            }

            
            //var notesArchiveService = new NotesArchiveMapperService();
            Guid noteId = new Guid(ParentPortlet.Session["EditId"].ToString());
            bool rtn = false;

            switch (cmdName)
            {
                case "gv_Restore":
                    {

                        try
                        {
                            rtn = noteArchiveView.moveArchiveToNote(noteId);

                            if (rtn)
                            {
                                ParentPortlet.ShowFeedback(FeedbackType.Success, "Note Successfully Restored!");
                            }
                            else
                            {
                                ParentPortlet.ShowFeedback(FeedbackType.Error, "Note was not Restored!");
                            }

                        }
                        catch (Exception exception)
                        {
                            var msg = PortalUser.Current.IsSiteAdmin
                                ? "This note was not Restored. " + exception.Message
                                : "This note was not Restored. ";

                            this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

                            ExceptionManager.Publish(exception);

                        }

                        //try
                        //{                          
                        //   // RestoreNote(notesArchiveService.GetNote(noteId));
                        //   // notesArchiveService.DeleteNote(noteId);
                        //    LoadNotes();
                        //}
                        //catch (Exception exception)
                        //{
                        //    var msg = PortalUser.Current.IsSiteAdmin
                        //        ? "This note was not Restored. " + exception.Message
                        //        : "This note was not Restored. ";

                        //    this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

                        //    ExceptionManager.Publish(exception);

                        //}


                        ParentPortlet.Session.Remove("EditId");
                        LoadNotes();

                    }
                    break;

                case "gv_ArchivedNotes_Delete":
                    {
                        try
                        {
                            //notesArchiveService.DeleteNote(noteId);
                            rtn = noteArchiveView.deleteOneArchiveNote(noteId);

                            if (rtn)
                            {
                                ParentPortlet.ShowFeedback(FeedbackType.Success, "Note Successfully Deleted!");
                            }
                            else
                            {
                                ParentPortlet.ShowFeedback(FeedbackType.Error, "Note was not Deleted!");
                            }

                        }
                        catch (Exception exception)
                        {
                            var msg = PortalUser.Current.IsSiteAdmin
                                ? "This note was not Deleted. " + exception.Message
                                : "This note was not Deleted. ";

                            this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

                            ExceptionManager.Publish(exception);

                        }

                        ParentPortlet.Session.Remove("EditId");
                        LoadNotes();
                    }
                    break;
            }
        }




        //protected void RestoreNote(NotesArchiveNHibernate archivedNote)
        //{
        //    var note = new NotesNHibernate();
        //    var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();

        //    note = new NotesNHibernate
        //    {
        //        NOTE_ID = archivedNote.NOTE_ID,
        //        FAC_APPID = archivedNote.FAC_APPID,
        //        FAC_ID_NUM = archivedNote.FAC_ID_NUM,
        //        SM_APPID = archivedNote.SM_APPID,
        //        CRS_CDE = archivedNote.CRS_CDE,
        //        CRS_TITLE = archivedNote.CRS_TITLE,
        //        DIV_CDE = archivedNote.DIV_CDE,
        //        INSTIT_DIV_CDE = archivedNote.INSTIT_DIV_CDE,
        //        SCHOOL_CDE = archivedNote.SCHOOL_CDE,
        //        YEARCODE = archivedNote.YEARCODE,
        //        TERMCODE = archivedNote.TERMCODE,
        //        SUBJECT = archivedNote.SUBJECT,
        //        STATUS = archivedNote.STATUS,
        //        NOTE = archivedNote.NOTE,
        //        NOTE_TYPE = archivedNote.NOTE_TYPE,
        //        NOTE_LEVEL = archivedNote.NOTE_LEVEL,
        //        FAC_TYPE = archivedNote.FAC_TYPE,
        //        APPROVAL_DATE = archivedNote.APPROVAL_DATE,
        //        EXPIRATION_DATE = archivedNote.EXPIRATION_DATE,
        //        CREATE_BY = archivedNote.CREATE_BY,
        //        CREATE_DATE = archivedNote.CREATE_DATE,
        //        UPDATE_BY = archivedNote.UPDATE_BY,
        //        UPDATE_DATE = archivedNote.UPDATE_DATE
        //    };

        //    try
        //    {
        //        using (var transaction = nHibernateSession.BeginTransaction())
        //        {
        //            nHibernateSession.SaveOrUpdate(note);
        //            transaction.Commit();

        //            ParentPortlet.ShowFeedback(FeedbackType.Success, "Note  Successfully Restored!");
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        var msg = PortalUser.Current.IsSiteAdmin
        //            ? "This note was not Restored! Error: " + exception.Message
        //            : "This note was not Restored!";

        //        this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);
        //        ExceptionManager.Publish(exception);
        //        return;
        //    }
        //    finally
        //    {
        //        nHibernateSession.Close();
        //    }

        //}

        protected void btn_Return_Click(object sender, EventArgs e)
        {
            // clear out the edit screen for the next record
            ParentPortlet.Session.Remove("EditId");
            ParentPortlet.PreviousScreen(); 
        }


    }
}
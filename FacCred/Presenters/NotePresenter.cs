using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.Data;
using Jenzabar.Portal.Framework.Web.UI;
using FacCred.Views;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace FacCred.Presenters
{
    public class NotePresenter
    {
        static NoteModel model = new NoteModel();

        public DataTable getFacultyNotes(string FACidnum, string termcode, string yearcode, string schoolcde,
            string instdiv)
        {
            return model.getFacultyNotes(FACidnum, termcode, yearcode, schoolcde, instdiv);
        }

        public DataTable getOneFacultyNote(Guid noteid)
        {
            return model.getOneFacultyNote(noteid);
        }

        public bool updateOneFacultyNote(Guid noteid, string subject, string status, string note, string notetype,
            string notelevel, DateTime approvaldate, DateTime expirationdate, string updateby, string updatedate)
        {
            return model.updateOneFacultyNote(noteid, subject, status, note, notetype, notelevel, approvaldate,
                expirationdate, updateby, updatedate);
        }


        public bool insertOneFacultyNote(Guid noteid,
                                        string facappid,
                                        string facidnum,
                                        string smappid,
                                        string crscde,
                                        string crstitle,
                                        string divcde,
                                        string institdivcde,
                                        string schoolcde,
                                        string yearcode,
                                        string termcode,
                                        string subject,
                                        string status,
                                        string note,
                                        string notetype,
                                        string notelevel,
                                        string factype,
                                        DateTime approvaldate,
                                        DateTime expirationdate,
                                        string createdby,
                                        DateTime createdate,
                                        string updateby,
                                        string updatedate)
        {
            return model.insertOneFacultyNote(noteid,
                                                facappid,
                                                facidnum,
                                                smappid,
                                                crscde,
                                                crstitle,
                                                divcde,
                                                institdivcde,
                                                schoolcde,
                                                yearcode,
                                                termcode,
                                                subject,
                                                status,
                                                note,
                                                notetype,
                                                notelevel,
                                                factype,
                                                approvaldate,
                                                expirationdate,
                                                createdby,
                                                createdate,
                                                updateby,
                                                updatedate);
        }




        public bool moveNoteToArchive(Guid noteid)
        {
            return model.moveNoteToArchive(noteid);
        }










    }
}


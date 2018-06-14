using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Presenters;
using FacCred.Views.Interfaces;
using System.Data;

namespace FacCred.Views
{
    public class NoteArchiveView
    {
        static NoteArchivePresenter presenter = new NoteArchivePresenter();

        public DataTable getFacultyArchiveNotes(string FACidnum, string termcode, string yearcode, string schoolcde,
            string instdiv)
        {
            return presenter.getFacultyArchiveNotes(FACidnum, termcode, yearcode, schoolcde, instdiv);
        }

        public bool moveArchiveToNote(Guid noteid)
        {
            return presenter.moveArchiveToNote(noteid);
        }

        public bool deleteOneArchiveNote(Guid noteid)
        {
            return presenter.deleteOneArchiveNote(noteid);
        }
    }
}
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
    public class NoteArchivePresenter
    {
        static NoteArchiveModel model = new NoteArchiveModel();

        public DataTable getFacultyArchiveNotes(string FACidnum, string termcode, string yearcode, string schoolcde,
            string instdiv)
        {
            return model.getFacultyArchiveNotes(FACidnum, termcode, yearcode, schoolcde, instdiv);
        }

        public bool moveArchiveToNote(Guid noteid)
        {
            return model.moveArchiveToNote(noteid);
        }


        public bool deleteOneArchiveNote(Guid noteid)
        {
            return model.deleteOneArchiveNote(noteid);
        }
    }
}
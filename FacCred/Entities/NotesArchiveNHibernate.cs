using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using Jenzabar.Portal.Framework.NHibernateFWK;
using Jenzabar.Portal.Framework.NHibernateFWK.Base;
using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace FacCred.Entities
{
    public class NotesArchiveNHibernate
    {
        public virtual Guid NOTE_ID { get; set; }
        public virtual string FAC_APPID { get; set; }
        public virtual string FAC_ID_NUM { get; set; }
        public virtual string SM_APPID { get; set; }
        public virtual string CRS_CDE { get; set; }
        public virtual string CRS_TITLE { get; set; }
        public virtual string DIV_CDE { get; set; }
        public virtual string INSTIT_DIV_CDE { get; set; }
        public virtual string SCHOOL_CDE { get; set; }
        public virtual string YEARCODE { get; set; }
        public virtual string TERMCODE { get; set; }
        public virtual string SUBJECT { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string NOTE { get; set; }
        public virtual string NOTE_TYPE { get; set; }
        public virtual string NOTE_LEVEL { get; set; }
        public virtual string FAC_TYPE { get; set; }
        public virtual DateTime APPROVAL_DATE { get; set; }
        public virtual DateTime EXPIRATION_DATE { get; set; }
        public virtual string CREATE_BY { get; set; }
        public virtual DateTime CREATE_DATE { get; set; }
        public virtual string UPDATE_BY { get; set; }
        public virtual string UPDATE_DATE { get; set; }
    }

    public class NotesArchiveEntityMapping : ClassMapping<NotesArchiveNHibernate>
    {
        public NotesArchiveEntityMapping()
        {
            Table("FACCRED_NOTES_ARCHIVE");
            Id(p => p.NOTE_ID);
            Property(p => p.FAC_APPID);
            Property(p => p.FAC_ID_NUM);
            Property(p => p.SM_APPID);
            Property(p => p.CRS_CDE);
            Property(p => p.CRS_TITLE);
            Property(p => p.DIV_CDE);
            Property(p => p.INSTIT_DIV_CDE);
            Property(p => p.SCHOOL_CDE);
            Property(p => p.YEARCODE);
            Property(p => p.TERMCODE);
            Property(p => p.SUBJECT);
            Property(p => p.STATUS);
            Property(p => p.NOTE);
            Property(p => p.NOTE_TYPE);
            Property(p => p.NOTE_LEVEL);
            Property(p => p.FAC_TYPE);
            Property(p => p.APPROVAL_DATE);
            Property(p => p.EXPIRATION_DATE);
            Property(p => p.CREATE_BY);
            Property(p => p.CREATE_DATE);
            Property(p => p.UPDATE_BY);
            Property(p => p.UPDATE_DATE);
        }
    }


    public class NotesArchiveMapperService
    {
        public NotesArchiveNHibernate GetNote(Guid NOTE_ID)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            NotesArchiveNHibernate Note = new NotesArchiveNHibernate();

            try
            {
                Note = nHibernateSession.Query<NotesArchiveNHibernate>().FirstOrDefault(x => x.NOTE_ID == NOTE_ID);
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }
            return Note;
        }

        public IList<NotesArchiveNHibernate> GetAllNotes()
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<NotesArchiveNHibernate> NoteList = new List<NotesArchiveNHibernate>();

            try
            {
                //NoteList = nHibernateSession.Query<NotesArchiveNHibernate>()
                //    .Where(x => x.PortletID == portletId && x.UserID == userId)
                //    .OrderBy(x => x.Name).ToList();

                NoteList = nHibernateSession.Query<NotesArchiveNHibernate>()
                .OrderBy(x => x.CREATE_DATE).ToList().OrderBy(x => x.NOTE_TYPE).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return NoteList;
        }


        public IList<NotesArchiveNHibernate> GetFacultyNotes(string FAC_NUM_ID)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<NotesArchiveNHibernate> NoteList = new List<NotesArchiveNHibernate>();

            try
            {
                //NoteList = nHibernateSession.Query<NotesArchiveNHibernate>()
                //    .Where(x => x.PortletID == portletId && x.UserID == userId)
                //    .OrderBy(x => x.Name).ToList();

                NoteList = nHibernateSession.Query<NotesArchiveNHibernate>()
                .Where(x => x.FAC_ID_NUM == FAC_NUM_ID && x.NOTE_LEVEL == "FACULTY")
                    .OrderBy(x => x.NOTE_TYPE).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return NoteList;
        }

        public IList<NotesArchiveNHibernate> GetFacultyYTDNotes(string FACidnum, string termcode, string yearcode, string schoolcde)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<NotesArchiveNHibernate> noteList = new List<NotesArchiveNHibernate>();

            try
            {
                noteList = nHibernateSession.Query<NotesArchiveNHibernate>()
                      .Where(x => x.FAC_ID_NUM == FACidnum && x.TERMCODE == termcode && x.YEARCODE == yearcode && x.SCHOOL_CDE == schoolcde && x.NOTE_LEVEL == "YEARTERM")
                    .OrderBy(x => x.NOTE_TYPE).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return noteList;
        }

        public IList<NotesArchiveNHibernate> GetFacultyYTDFNotes(string FACidnum, string termcode, string yearcode, string schoolcde)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<NotesArchiveNHibernate> noteList = new List<NotesArchiveNHibernate>();

            try
            {
                noteList = nHibernateSession.Query<NotesArchiveNHibernate>()
                    .Where(x => x.FAC_ID_NUM == FACidnum && (x.TERMCODE == termcode || x.TERMCODE == "") && (x.YEARCODE == yearcode || x.YEARCODE == "") && (x.SCHOOL_CDE == schoolcde || x.SCHOOL_CDE == ""))
                    .OrderByDescending(x => x.UPDATE_DATE).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return noteList;
        }

        public IList<NotesArchiveNHibernate> GetFacultyYTDDFNotes(string FACidnum, string termcode, string yearcode, string schoolcde, string instdiv)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<NotesArchiveNHibernate> noteList = new List<NotesArchiveNHibernate>();

            try
            {
                noteList = nHibernateSession.Query<NotesArchiveNHibernate>()
                    .Where(x => x.FAC_ID_NUM == FACidnum && (x.TERMCODE == termcode || x.TERMCODE == "")
                                && (x.YEARCODE == yearcode || x.YEARCODE == "")
                                && (x.SCHOOL_CDE == schoolcde || x.SCHOOL_CDE == "")
                                && (x.INSTIT_DIV_CDE == instdiv || x.INSTIT_DIV_CDE == ""))
                    .OrderByDescending(x => x.UPDATE_DATE).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return noteList;
        }


        public IList<NotesArchiveNHibernate> GetFacultyYTNotes(string FACidnum, string termcode, string yearcode, string schoolcde)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<NotesArchiveNHibernate> noteList = new List<NotesArchiveNHibernate>();

            try
            {
                noteList = nHibernateSession.Query<NotesArchiveNHibernate>()
                      .Where(x => x.FAC_ID_NUM == FACidnum && x.TERMCODE == termcode && x.YEARCODE == yearcode && x.SCHOOL_CDE == schoolcde)
                    .OrderBy(x => x.NOTE_TYPE).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return noteList;
        }

        public int UpdateNote(Guid id)
        {
            NotesArchiveNHibernate Note = GetNote(id);
            int status = 1;

            if (Note == null)
                return 0;

            //Note.Name = name;
            //Note.Description = description;

            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            try
            {
                using (var transaction = nHibernateSession.BeginTransaction())
                {
                    nHibernateSession.SaveOrUpdate(Note);
                    transaction.Commit();
                }
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
                status = 0;
            }
            finally
            {
                nHibernateSession.Close();
            }

            return status;
        }

        public void DeleteNote(Guid NOTE_ID)
        {
            NotesArchiveNHibernate Note = GetNote(NOTE_ID);

            if (Note == null)
                return;
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            try
            {
                using (var transaction = nHibernateSession.BeginTransaction())
                {
                    nHibernateSession.Delete(Note);
                    transaction.Commit();
                }
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using Jenzabar.Portal.Framework.NHibernateFWK;
using Jenzabar.Portal.Framework.NHibernateFWK.Base;
using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace FacCred.Entities
{
    public class DisciplinesNHibernate
    {
        public virtual Guid ID { get; set; }
        public virtual string FAC_APPID { get; set; }
        public virtual string FAC_ID_NUM { get; set; }
        public virtual string DIV_CDE { get; set; }
        public virtual string INSTIT_DIV_CDE { get; set; }
        public virtual string SCHOOL_CDE { get; set; }


    }

    public class DisciplinesEntityMapping : ClassMapping<DisciplinesNHibernate>
    {
        public DisciplinesEntityMapping()
        {
            Table("FACCRED_FAC_DIS_XREF");
            Id(p => p.ID);
            Property(p => p.FAC_APPID);
            Property(p => p.FAC_ID_NUM);
            Property(p => p.DIV_CDE);
            Property(p => p.INSTIT_DIV_CDE);
            Property(p => p.SCHOOL_CDE);


        }
    }

    public class DisciplinesMapperService
    {
        public DisciplinesNHibernate GetDiscipline(Guid ID)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            DisciplinesNHibernate Discipline = new DisciplinesNHibernate();

            try
            {
                Discipline = nHibernateSession.Query<DisciplinesNHibernate>().FirstOrDefault(x => x.ID == ID);
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }
            return Discipline;
        }

        public IList<DisciplinesNHibernate> GetAllDisciplines()
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<DisciplinesNHibernate> DisciplineList = new List<DisciplinesNHibernate>();

            try
            {
                //DisciplineList = nHibernateSession.Query<DisciplinesNHibernate>()
                //    .Where(x => x.PortletID == portletId && x.UserID == userId)
                //    .OrderBy(x => x.Name).ToList();

                DisciplineList = nHibernateSession.Query<DisciplinesNHibernate>()
                    .OrderBy(x => x.SCHOOL_CDE).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return DisciplineList;
        }

        public IList<DisciplinesNHibernate> GetOneDiscipline(string facappid, string facidnum, string discipline)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<DisciplinesNHibernate> DisciplineList = new List<DisciplinesNHibernate>();

            try
            {
                //DisciplineList = nHibernateSession.Query<DisciplinesNHibernate>()
                //    .Where(x => x.PortletID == portletId && x.UserID == userId)
                //    .OrderBy(x => x.Name).ToList();

                DisciplineList = nHibernateSession.Query<DisciplinesNHibernate>()
                    .Where(x => x.FAC_APPID == facappid && x.FAC_ID_NUM == facidnum && x.SCHOOL_CDE == discipline)
                    .OrderBy(x => x.INSTIT_DIV_CDE).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return DisciplineList;
        }

        public IList<DisciplinesNHibernate> GetFacultyDisciplines(string facappid, string facidnum)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<DisciplinesNHibernate> DisciplineList = new List<DisciplinesNHibernate>();

            try
            {
                DisciplineList = nHibernateSession.Query<DisciplinesNHibernate>()

                .Where(x => x.FAC_ID_NUM == facidnum)
         //           .Select(x => x.INSTIT_DIV_CDE).Distinct().ToList()
                .OrderBy(x => x.SCHOOL_CDE).Distinct().ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return DisciplineList;
        }

        public void DeleteDiscipline(Guid ID)
        {
            DisciplinesNHibernate disc = GetDiscipline(ID);

            if (disc == null)
                return;
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            try
            {
                using (var transaction = nHibernateSession.BeginTransaction())
                {
                    nHibernateSession.Delete(disc);
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

        public void RemoveDiscipline(string facappid, string facidnum, string discipline)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<DisciplinesNHibernate> DisciplineList = new List<DisciplinesNHibernate>();

            try
            {
                DisciplineList = nHibernateSession.Query<DisciplinesNHibernate>()
                    .Where(x => x.FAC_APPID == facappid && x.FAC_ID_NUM == facidnum && x.SCHOOL_CDE == discipline).ToList();

                using (var transaction = nHibernateSession.BeginTransaction())
                {
                    foreach (DisciplinesNHibernate dspln in DisciplineList)
                    {
                        nHibernateSession.Delete(dspln);
                    }
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
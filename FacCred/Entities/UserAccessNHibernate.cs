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
    public class UserAccessNHibernate
    {
        public virtual Guid ID { get; set; }
        public virtual string USER_ID { get; set; }
        public virtual string FIRST_NAME { get; set; }
        public virtual string LAST_NAME { get; set; }
        public virtual string SCHOOL_CDE { get; set; }


    }

    public class UserAccessEntityMapping : ClassMapping<UserAccessNHibernate>
    {
        public UserAccessEntityMapping()
        {
            Table("FACCRED_USER_ACCESS_XREF");
            Id(p => p.ID);
            Property(p => p.USER_ID);
            Property(p => p.FIRST_NAME);
            Property(p => p.LAST_NAME);
            Property(p => p.SCHOOL_CDE);
        }
    }

    public class UserAccessMapperService
    {
        public UserAccessNHibernate GetUserAccessID(Guid ID)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            UserAccessNHibernate userAccess = new UserAccessNHibernate();

            try
            {
                userAccess = nHibernateSession.Query<UserAccessNHibernate>().FirstOrDefault(x => x.ID == ID);
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }
            return userAccess;
        }

        public IList<UserAccessNHibernate> GetAllUserAccess()
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<UserAccessNHibernate> UserAccessList = new List<UserAccessNHibernate>();

            try
            {
                UserAccessList = nHibernateSession.Query<UserAccessNHibernate>()
                    .OrderBy(x => x.LAST_NAME).ToList();
            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return UserAccessList;
        }

        public IList<UserAccessNHibernate> GetOneUserAccess(string userId, string firstName, string lastName)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<UserAccessNHibernate> UserAccessList = new List<UserAccessNHibernate>();

            try
            {

                UserAccessList = nHibernateSession.Query<UserAccessNHibernate>()
                    .Where(x => x.FIRST_NAME == firstName && x.LAST_NAME == lastName && x.USER_ID == userId ).ToList();

            }
            catch (Exception e)
            {
                ExceptionManager.Publish(e);
            }
            finally
            {
                nHibernateSession.Close();
            }

            return UserAccessList;
        }


        public void DeleteUserAccess(Guid ID)
        {
            UserAccessNHibernate disc = GetUserAccessID(ID);

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

        public void RemoveUserAccess(string userId, string firstName, string lastName,  string schoolcde)
        {
            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();
            IList<UserAccessNHibernate> UserAccessList = new List<UserAccessNHibernate>();

            try
            {
                UserAccessList = nHibernateSession.Query<UserAccessNHibernate>()
                    .Where(x => x.USER_ID == userId && x.FIRST_NAME == firstName && x.LAST_NAME == lastName && x.SCHOOL_CDE == schoolcde ).ToList();

                using (var transaction = nHibernateSession.BeginTransaction())
                {
                    foreach (UserAccessNHibernate dspln in UserAccessList)
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using Jenzabar.Common.Configuration;
using Jenzabar.ERP.EX.DAL;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Framework.NHibernateFWK;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;



namespace FacCred.Entities
{
    public class NHibernateFactory : System.Web.UI.UserControl //ICustomSessionFactory
    {
        public ISessionFactory GetSessionFactory()
        {
            Configuration cfg = new Configuration()
                .DataBaseIntegration(db =>
                //{
                //    DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();

                //});


                {
                    //db.ConnectionString = ConfigSettings.Current.DatabaseConnectionInfo.ConnectionString;
                    db.ConnectionString = "Data Source=TUL-DRBREASHEAR\\MSSQLSERVER01;Initial Catalog=DEV_700;Persist Security Info=True;User ID=sa;Password=Dave22sa!";
                    //db.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EXConnectionString"].ConnectionString;
                    //db.ConnectionString = "Data Source=JenzDB01;Initial Catalog=TmsEPrd;Persist Security Info=True;User ID=sa;Password=SASQLmidlandcollege!";
                    //db.ConnectionString = "Data Source=JenzDB01;Initial Catalog=TmsEUpgradeTest;Persist Security Info=True;User ID=sa;Password=SASQLmidlandcollege!";
                    db.Dialect<MsSql2005Dialect>();
                    db.IsolationLevel = IsolationLevel.ReadUncommitted;
                    db.Driver<SqlClientDriver>();
                });

            cfg.Proxy(pr =>
            {
                pr.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>();
            });

            cfg.AddAssembly("FacCred");

            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            cfg.AddMapping(mapping);

            return cfg.BuildSessionFactory();

        }
    }
}
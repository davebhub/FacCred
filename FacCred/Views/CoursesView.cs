using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Presenters;
using FacCred.Views.Interfaces;
using System.Data;

namespace FacCred.Views
{
    public partial class CoursesView : ICoursesView
    {

        static CoursesPresenter presenter = new CoursesPresenter();


        public DataSet getDataSQLByID(string FACidnum)
        {
            DataSet ds = presenter.getDataSQLByID(FACidnum);
            return ds;
        }

        public DataSet getDataSQLByCIDYT(string CRSappid, string FACidnum, string yrcode, string trmCode)
        {
            DataSet ds = presenter.getDataSQLByCIDYT(CRSappid,FACidnum, yrcode, trmCode);
            return ds;
        }


        public DataSet getDataSQLByIDYT(string FACidnum, string yrcode, string trmCode)
        {
            DataSet ds = presenter.getDataSQLByIDYT(FACidnum, yrcode, trmCode);
            return ds;
        }

        public DataSet getDataSQLByYT( string yrcode, string trmCode)
        {
            DataSet ds = presenter.getDataSQLByYT(yrcode, trmCode);
            return ds;
        }

        public DataSet getDataSQLByAppid(string CRSappid)
        {
            DataSet ds = presenter.getDataSQLByAppid(CRSappid);
            return ds;
        }


        public DataSet getDataSQLDataSet()
        {
            DataSet ds = presenter.getDataSQLDataSet();
            return ds;
        }
    }
}
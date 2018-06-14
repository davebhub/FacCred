using System.Collections.Generic;
using System.Linq;
using System.Data;
using FacCred.Presenters;
using FacCred.Views.Interfaces;

namespace FacCred.Views
{
    public partial class UserAccessView : IUserAccessView
    {

        static UserAccessPresenter presenter = new UserAccessPresenter();


        public DataSet AllUserAccessSQL()
        {
            DataSet ds = presenter.AllUserAccessSQL();
            return ds;
        }


        public DataSet getDataSQLByDIS(string CATdiv, string CATinstdiv, string CATschoolcde)
        {
            DataSet ds = presenter.getDataSQLByDIS(CATdiv, CATinstdiv, CATschoolcde);
            return ds;
        }

        public DataSet getDataSQLByDI(string CATdiv, string CATinstdiv)
        {
            DataSet ds = presenter.getDataSQLByDI(CATdiv, CATinstdiv);
            return ds;
        }

        public DataSet getDataSQLByD(string CATdiv)
        {
            DataSet ds = presenter.getDataSQLByD(CATdiv);
            return ds;
        }

        public DataSet getDataSQLDataSet()
        {
            DataSet ds = presenter.getDataSQLDataSet();
            return ds;
        }
    }
}
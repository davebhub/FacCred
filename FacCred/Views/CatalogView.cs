using System.Collections.Generic;
using System.Linq;
using System.Data;
using FacCred.Presenters;
using FacCred.Views.Interfaces;

namespace FacCred.Views
{
    public partial class CatalogView : ICatalogView
    {

        static CatalogPresenter presenter = new CatalogPresenter();


        public DataTable getDataSQLByID()
        {
            DataTable dt = presenter.getDataSQLByID();
            return dt;
        }

        public DataSet getDataSQLDataSet()
        {
            DataSet ds = presenter.getDataSQLDataSet();
            return ds;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Data;
using FacCred.Presenters;
using FacCred.Views.Interfaces;

namespace FacCred.Views
{
    public partial class EDUEarnHistView : IEDUEarnHistView
    {

        static EDUEarnHistPresenter presenter = new EDUEarnHistPresenter();


        public DataSet getDataSQLByID(string FACappid, string FACidnum)
        {
            DataSet ds = presenter.getDataSQLByID(FACappid,FACidnum);
            return ds;
        }

        public DataSet getDataSQLDataSet ()
        {
            DataSet ds = presenter.getDataSQLDataSet();
            return ds;
        }
    }
}
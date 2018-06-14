using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Presenters;
using FacCred.Views.Interfaces;
using System.Data;

namespace FacCred.Views
{
    public class MainMenuView
    {
        static MainMenuPresenter presenter = new MainMenuPresenter();

        public DataSet getDataSQLDataSetTerm()
        {
            DataSet ds = presenter.getDataSQLDataSetTerm();
            return ds;
        }

        public void setTerm(string term)
        {
            presenter.setTerm(term);
        }

        public string getTerm()
        {
            return presenter.getTerm();
        }

        public void setYear(string year)
        {
            presenter.setYear(year);
        }

        public string getYear()
        {
            return presenter.getYear();
        }
    }
}
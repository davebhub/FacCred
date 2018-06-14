using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.Data;

namespace FacCred.Presenters
{
    public class MainMenuPresenter
    {
        static MainMenuModel model = new MainMenuModel();

        public DataSet getDataSQLDataSetTerm()
        {            
            DataSet ds = model.getDataSQLTerm();

            return ds;
        }



        public string getTerm()
        {
            return model.getTerm();
        }

        public string getYear()
        {
            return model.getYear();
        }

        public void setTerm(string trm)
        {
            model.setTerm(trm);
        }

        public void setYear(string yr)
        {
            model.setYear(yr);
        }

    }
}
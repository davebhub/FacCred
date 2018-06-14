using FacCred.Presenters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacCred.Views.Interfaces
{
    interface IMainMenuView
    {
        MainMenuPresenter MainMenuPresenter();
        DataSet getDataSQLDataSetTerm();

        void setTerm(string s);

        string getTerm();

        void setYear(string s);

        string getYear();
    }
}

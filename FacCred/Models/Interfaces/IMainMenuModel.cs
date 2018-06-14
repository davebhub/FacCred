using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacCred.Models.Interfaces
{
    interface IMainMenuModel
    {
        string getYear();
        void setYear(string s);
        string getTerm();
        void setTerm(string s);

        DataSet getDataSQLYear();
        DataSet getDataSQLTerm();

    }
}

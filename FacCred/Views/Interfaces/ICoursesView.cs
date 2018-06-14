using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacCred.Views.Interfaces
{
    public interface ICoursesView
    {
        DataSet getDataSQLDataSet();
        DataSet getDataSQLByID(string s);

        DataSet getDataSQLByIDYT(string a, string b, string c);

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacCred.Views.Interfaces
{
    interface ICredentialsView
    {
        DataSet getDataSQLDataSet();
        DataSet getDataSQLByID(string s);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacCred.Views.Interfaces
{
    public interface IFacultyView
    {
        DataSet getDataSQLDataSet(string year, string term);
      

    }
}

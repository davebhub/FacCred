using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FacCred.Models;

namespace FacCred.Presenters
{
    public class CatalogPresenter
    {
        static CatalogModel model = new CatalogModel();

        public DataTable getDataSQLByID()
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("facidnum") == "498");
            DataTable boundTable = dataRow.CopyToDataTable<DataRow>();

            return boundTable;
        }

        public DataSet getDataSQLDataSet()
        {
            // same model call but returning the full dataset
            DataTable dt = model.getDataSQL();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }
    }
}
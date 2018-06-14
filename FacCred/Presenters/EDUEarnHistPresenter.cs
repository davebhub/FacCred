using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FacCred.Models;

namespace FacCred.Presenters
{
    public class EDUEarnHistPresenter
    {
        static EDUEarnHistModel model = new EDUEarnHistModel();

        public DataSet getDataSQLByID(string FACappid, string FACidnum)
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("FACappid") == FACappid)
                .Where(x => x.Field<string>("FACidnum") == FACidnum);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoRecordsFound();
        }

            public DataSet getDataSQLDataSet()
        {
            // same model call but returning the full dataset
            DataTable dt = model.getDataSQL();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet rtnNoRecordsFound()
        {
            DataTable table1 = new DataTable();


            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("description");
            table1.Columns.Add("MajorDisp");
            table1.Columns.Add("institution");
            table1.Columns.Add("honors");
            table1.Columns.Add("completedyear");


            table1.Rows.Add("","","no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }
    }
}
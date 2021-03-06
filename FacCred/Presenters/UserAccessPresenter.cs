﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FacCred.Models;

namespace FacCred.Presenters
{
    public class UserAccessPresenter
    {
        static UserAccessModel model = new UserAccessModel();


        public DataSet AllUserAccessSQL()
        {
            //same model call but using LINQ to filter
            DataTable dt = model.AllUserAccessSQL();

            var dataRow = dt.AsEnumerable();
            // DataTable boundTable = dataRow.CopyToDataTable<DataRow>();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoUserAccessFound();
        }



        public DataSet getDataSQLByDIS(string CATdiv, string CATinstdiv, string CATschoolcde)
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("CATdiv") == CATdiv).Where(x => x.Field<string>("CATinstdiv") == CATinstdiv).Where(x => x.Field<string>("CATschoolcde") == CATschoolcde);
            // DataTable boundTable = dataRow.CopyToDataTable<DataRow>();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoDisciplinesFound();
        }

        public DataSet getDataSQLByDI(string CATdiv, string CATinstdiv)
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("CATdiv") == CATdiv).Where(x => x.Field<string>("CATinstdiv") == CATinstdiv);
            //DataTable boundTable = dataRow.CopyToDataTable<DataRow>();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoDisciplinesFound();
        }

        public DataSet getDataSQLByD(string CATdiv)
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("CATdiv") == CATdiv);
            //DataTable boundTable = dataRow.CopyToDataTable<DataRow>();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoDisciplinesFound();
        }

        public DataSet getDataSQLDataSet()
        {
            // same model call but returning the full dataset
            DataTable dt = model.getDataSQL();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet rtnNoDisciplinesFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("CATdiv");
            table1.Columns.Add("CATdivdesc");
            table1.Columns.Add("CATinstdiv");
            table1.Columns.Add("CATinstdivdesc");
            table1.Columns.Add("CATschoolcde");

            table1.Rows.Add("no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }


        public DataSet rtnNoUserAccessFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACcertification");
            table1.Columns.Add("FACinsttype");
            table1.Columns.Add("FACcapacity");
            table1.Columns.Add("FACconflict");
            table1.Columns.Add("FACrequisite");
            table1.Columns.Add("FACdivcode");
            table1.Columns.Add("FACinstdiv");

            table1.Rows.Add("no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }
    }
}
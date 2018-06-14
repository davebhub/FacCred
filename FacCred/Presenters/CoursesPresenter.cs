using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.Data;
using System.IO;

namespace FacCred.Presenters
{
    public class CoursesPresenter
    {
        static CoursesModel model = new CoursesModel();


        public DataSet getDataSQLByID(string FACidnum)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("FACidnum") == FACidnum);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCoursesFound();
        }

        public DataSet getDataSQLByYT( string yrcode, string trmcode)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("CRSyearcode") == yrcode).Where(x => x.Field<string>("CRStermcode") == trmcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCoursesFound();
        }

        public DataSet getDataSQLByCIDYT(string CRSappid, string FACidnum, string yrcode, string trmcode)
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("FACidnum") == FACidnum).Where(x => x.Field<string>("CRSyearcode") == yrcode).Where(x => x.Field<string>("CRStermcode") == trmcode).Where(x => x.Field<string>("CRSappid") == CRSappid);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCoursesFound();
        }


        public DataSet getDataSQLByIDYT(string idnum, string yrcode, string trmcode)
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("FACidnum") == idnum).Where(x => x.Field<string>("CRSyearcode") == yrcode).Where(x => x.Field<string>("CRStermcode") == trmcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCoursesFound();
        }

        public DataSet getDataSQLDataSet()
        {
            //same model call but returning the full dataset
            DataTable dt = model.getDataSQL();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getDataSQLByAppid(string CRSappid)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getDataSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("CRSappid") == CRSappid);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCoursesFound();
        }

        public DataSet rtnNoCoursesFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FLTappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("CRSinstdiv");
            table1.Columns.Add("CRSyearcode");
            table1.Columns.Add("CRStermcode");
            table1.Columns.Add("CRScde");
            table1.Columns.Add("FACload");
            table1.Columns.Add("FAClead");
            table1.Columns.Add("CRSschoolcde");
            table1.Columns.Add("CRSappid");
            table1.Columns.Add("CRStitle");
            table1.Columns.Add("CRSdiv");

            table1.Rows.Add( "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }

    }
}
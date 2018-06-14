using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.Data;
using Jenzabar.Portal.Framework.Web.UI;
using FacCred.Views;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace FacCred.Presenters
{
    public class FacultyPresenter
    {
        static FacultyModel model = new FacultyModel();

        public DataTable getDataSQLByID(string FACidnum, string year, string term)
        {
            //same model call but using LINQ to filter by ID
            DataTable dt = model.getDataSQL(year, term);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("FACidnum") == FACidnum);
            //DataTable boundTable = dataRow.CopyToDataTable<DataRow>();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return boundTable;
            }
            else
            {
                return model.getDataSQL(year, term);
            }

           // return rtnNoFacultyFound();

        }

        public DataTable getUserAccessFaculty(string userID, string firstName, string lastName, string year, string term)
        {
            DataTable dt = model.getUserAccessFaculty(userID, firstName, lastName, year, term);

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return boundTable;
            }
            else
            {
                return rtnNoFacultyFound();
            }
        }

        public void ExecuteFacultyRefresh()
        {
            //same model call but returning the full dataset
            model.ExecuteFacultyRefresh();
            //DataSet ds = new DataSet();

            //ds.Tables.Add(dt);

            //return ds;
        }
        

        public DataSet getDataSQLDataSet(string year, string term)
        {
            //same model call but returning the full dataset
            DataTable dt = model.getDataSQL(year, term);
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataTable getFacultyXREF(string FACappid, string FACidnum)
        {
            DataTable dt = model.getFacultyXREF(FACappid, FACidnum);

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return boundTable;
            }
            else
            {
                return rtnNoFacultyXREFFound();
            }
        }


        public bool insertOneFacultyXREF(Guid xref_id, string FACappid, string FACidnum, string divcode, string instdiv,string schoolcode)
        {
            return model.insertOneFacultyXREF(xref_id, FACappid, FACidnum, divcode, instdiv, schoolcode);
        }


        public bool deleteOneFacultyXREF(Guid id)
        {
            return model.deleteOneFacultyXREF(id);
        }















        public DataTable rtnNoFacultyFound()
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
            table1.Columns.Add("FACschoolcode");

            table1.Rows.Add("", "", "no records found");

            //DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            return table1;
        }

        public DataTable rtnNoFacultyXREFFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("ID");
            table1.Columns.Add("FAC_APPID");
            table1.Columns.Add("FAC_ID_NUM");
            table1.Columns.Add("DIV_CDE");
            table1.Columns.Add("INSTIT_DIV_CDE");
            table1.Columns.Add("SCHOOL_CDE");

            table1.Rows.Add("", "", "no records found");

            //DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            return table1;
        }

    }
}
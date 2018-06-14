using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.Data;
using System.IO;


namespace FacCred.Presenters
{
    public class ApprovalsPresenter 
    {
        static  ApprovalsModel model = new ApprovalsModel();


        public string  approverLevelSQL(string firstName, string lastName)
        {
            string rtn = "";

            rtn = model.approverLevelSQL(firstName, lastName);

            return rtn;
        }


        public DataSet getAllCourseApprovals()
        {
            //same model call but returning the full dataset
            DataTable dt = model.getAllCourseApprovals();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoRecordsFound();

        }

        public DataSet getAllFacultyApprovals()
        {
            //same model call but returning the full dataset
            DataTable dt = model.getAllFacultyApprovals();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoRecordsFound();

        }



        public DataSet getFacultyApprovalsByYT(string yrcode, string trmcode)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getAllFacultyApprovals();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yrcde") == yrcode).Where(x => x.Field<string>("trmcde") == trmcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoRecordsFound();
        }




        public DataSet rtnNoApproverFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("crscde");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("yrcde");
            table1.Columns.Add("trmcde");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("approver");

            table1.Rows.Add("no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }


        public DataSet rtnNoRecordsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("crscde");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("yrcde");
            table1.Columns.Add("trmcde");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("approver");
            table1.Columns.Add("approver1");
            table1.Columns.Add("approver2");
            table1.Columns.Add("approver3");
            table1.Columns.Add("moddate");


            table1.Rows.Add("no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }

        public DataSet rtnNoApprovalRecordsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("crscde");
            table1.Columns.Add("CRStitle");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("yrcde");
            table1.Columns.Add("trmcde");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("approver");
            table1.Columns.Add("approver1");
            table1.Columns.Add("approver2");
            table1.Columns.Add("approver3");
            table1.Columns.Add("moddate");


            table1.Rows.Add("no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }

    }


}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.IO;

namespace FacCred.Presenters
{
    public class DropDownPresenter
    {
        static DropDownModel model = new DropDownModel();

        public DataSet getYears()
        {
          
            DataTable dt = model.getYears();
            DataSet ds = new DataSet();
            List<string> ddlist = new List<string>();

            ds.Tables.Add(dt);

            return ds;
        }
        public DataSet getTerms()
        {
            DataTable dt = model.getTerms();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getApprovalCodes()
        {
            DataTable dt = model.getApprovalCodes();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getStatusCodes()
        {
            DataTable dt = model.getStatusCodes();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }


        public DataSet getNoteTypes()
        {
            DataTable dt = model.getNoteTypes();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getNoteTypes_filter()
        {
            DataTable dt = model.getNoteTypes_filter();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getNoteLevels()
        {
            DataTable dt = model.getNoteLevels();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getNoteLevels_filter()
        {
            DataTable dt = model.getNoteLevels_filter();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }


        public DataSet getInstDivisionsUserAccess(string userID)
        {
            DataTable dt = model.getInstDivisionsUserAccess(userID);
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getSchoolCodeUserAccess(string userID)
        {
            DataTable dt = model.getSchoolCodeUserAccess(userID);
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getInstDivisions()
        {
            DataTable dt = model.getInstDivisions();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getDivisions()
        {
            DataTable dt = model.getDivisions();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet getSchoolCodes()
        {
            DataTable dt = model.getSchoolCodes();
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }




        public DataSet getSpecificDivisions(string idnum, string yrcode, string trmcode)
        {
            DataTable dt = model.getSpecificDivisions(idnum, yrcode, trmcode);
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return ds;
        }

        public DataSet rtnNoDivisionsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("crscde");
            table1.Columns.Add("yrcde");
            table1.Columns.Add("trmcde");
            table1.Columns.Add("institut_div");
            table1.Columns.Add("lastname");
            table1.Columns.Add("firstname");
            table1.Columns.Add("load");
            table1.Columns.Add("lead");
            table1.Columns.Add("idnum");
            table1.Columns.Add("appid");

            table1.Rows.Add("no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }
    }
}
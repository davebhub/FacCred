using FacCred.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FacCred.Presenters
{
    public class UserAccessDirectPresenter
    {

        static UserAccessDirectModel model = new UserAccessDirectModel();


        public DataSet AllUserAccessSQL()
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getAllUsersDirectAccess();

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


        public DataSet GetOneUserDirectAccess(string userid)
        {
            //same model call but using LINQ to filter
            DataTable dt = model.getOneUserDirectAccess(userid);

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



        public bool DeleteOneUserDirectAccess(string id)
        {
            bool rtn = model.DeleteOneUserDirectAccess(id);

            return rtn;
        }


        public bool InsertOneRecordDirectAccess(Guid id, string userid, string firstname, string lastname,
            string schoolcode)
        {
            bool rtn = model.InsertOneRecordDirectAccess(id, userid, firstname, lastname, schoolcode);

            return rtn;
        }










        public DataSet rtnNoUserAccessFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("ID");
            table1.Columns.Add("USER_ID");
            table1.Columns.Add("FIRST_NAME");
            table1.Columns.Add("LAST_NAME");
            table1.Columns.Add("SCHOOL_CDE");


            table1.Rows.Add("no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }

    }
}
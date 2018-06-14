using Jenzabar.ERP.EX.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;

namespace FacCred.Models
{
    public class UserAccessDirectModel
    {
        public DataTable getAllUsersDirectAccess()
        {
            string STMT = @"
					select DISTINCT
					ID, USER_ID, FIRST_NAME, LAST_NAME, SCHOOL_CDE
					 from FACCRED_USER_ACCESS_XREF";

            DataTable dt = new DataTable();

            DataColumn dc0 = new DataColumn("ID");
            DataColumn dc1 = new DataColumn("USER_ID");
            DataColumn dc2 = new DataColumn("FIRST_NAME");
            DataColumn dc3 = new DataColumn("LAST_NAME");
            DataColumn dc4 = new DataColumn("SCHOOL_CDE");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("CATdiv", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["ID"] = dr["ID"].ToString();
                        mydr["USER_ID"] = dr["USER_ID"].ToString().Trim();
                        mydr["FIRST_NAME"] = dr["FIRST_NAME"].ToString().Trim();
                        mydr["LAST_NAME"] = dr["LAST_NAME"].ToString().Trim();
                        mydr["SCHOOL_CDE"] = dr["SCHOOL_CDE"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {
                // errMsg.Visible = true;
                //  errMsg.ErrorMessage = ex.Message.ToString();
                ExceptionManager.Publish(ex);
                return dt;
            }

        }

        public DataTable getOneUserDirectAccess(string userid)
        {
            string STMT = @"
					select DISTINCT
					ID, USER_ID, FIRST_NAME, LAST_NAME, SCHOOL_CDE
					 from FACCRED_USER_ACCESS_XREF where USER_ID = @userid";

            DataTable dt = new DataTable();

            DataColumn dc0 = new DataColumn("ID");
            DataColumn dc1 = new DataColumn("USER_ID");
            DataColumn dc2 = new DataColumn("FIRST_NAME");
            DataColumn dc3 = new DataColumn("LAST_NAME");
            DataColumn dc4 = new DataColumn("SCHOOL_CDE");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userid", userid, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["ID"] = dr["ID"].ToString();
                        mydr["USER_ID"] = dr["USER_ID"].ToString().Trim();
                        mydr["FIRST_NAME"] = dr["FIRST_NAME"].ToString().Trim();
                        mydr["LAST_NAME"] = dr["LAST_NAME"].ToString().Trim();
                        mydr["SCHOOL_CDE"] = dr["SCHOOL_CDE"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {
                // errMsg.Visible = true;
                //  errMsg.ErrorMessage = ex.Message.ToString();
                ExceptionManager.Publish(ex);
                return dt;
            }

        }



        public bool DeleteOneUserDirectAccess(string id)
        {
            string STMT = @"
					DELETE FROM FACCRED_USER_ACCESS_XREF where ID = @id";

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("id", id, DbType.String, ParameterDirection.Input)
                                            });

                return true;
            }

            catch (Exception ex)
            {
                // errMsg.Visible = true;
                //  errMsg.ErrorMessage = ex.Message.ToString();
                ExceptionManager.Publish(ex);
                return false;
            }

        }


        public bool InsertOneRecordDirectAccess(Guid id, string userid, string firstname, string lastname, string schoolcode)
        {
            string STMT = @" IF (SELECT count(*) from FACCRED_USER_ACCESS_XREF  where USER_ID=@userid AND SCHOOL_CDE=@schoolcode ) = 0
                               INSERT INTO FACCRED_USER_ACCESS_XREF VALUES(@id, @userid, @firstname, @lastname, @schoolcode)";

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]{
                        new ParamStruct("id", id, DbType.Guid, ParameterDirection.Input),
                        new ParamStruct("userid", userid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("schoolcode", schoolcode, DbType.String, ParameterDirection.Input)
                    });

                return true;
            }

            catch (Exception ex)
            {
                // errMsg.Visible = true;
                //  errMsg.ErrorMessage = ex.Message.ToString();
                ExceptionManager.Publish(ex);
                return false;
            }


        }




    }
}
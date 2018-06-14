using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FacCred.Models.Interfaces;
using Jenzabar.ERP.EX.DAL;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using System.Data.SqlClient;
using System.IO;

namespace FacCred.Models
{
    public class DropDownModel :  System.Web.UI.UserControl
    {
        public DataTable getTerms()
        {
            string STMT = @"select
                            trm_cde as data,
                            trm_cde as value
                            from term_def order by TRM_SORT_ORDER";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });
                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "TRM";
                dtr["value"] = "TRM";
                dt.Rows.Add(dtr);


                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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

        public DataTable getYears()
        {
            string STMT = @"select
                            yr_cde as data,
                            yr_cde as value
                            from year_def order by YR_SORT_ORDER DESC";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "YR";
                dtr["value"] = "YR";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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



        public DataTable getApprovalCodes()
        {

            string STMT = @"select
                            data as data,
                            value as value
                            from FACCRED_APPROVAL_STATUS_DDL";           
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "SELECT";
                dtr["value"] = "0";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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


        public DataTable getStatusCodes()
        {

            string STMT = @"select
                            value + '-' + data as data,
                            value as value
                            from FACCRED_STATUS_CODES order by value asc";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "SELECT";
                dtr["value"] = "0";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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


        public DataTable getNoteTypes()
        {

            string STMT = @"select
                            data as data,
                            value as value
                            from FACCRED_NOTE_TYPES order by value asc";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "SELECT";
                dtr["value"] = "0";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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

        public DataTable getNoteTypes_filter()
        {

            string STMT = @"select
                            data as data,
                            value as value
                            from FACCRED_NOTE_TYPES order by value asc";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "";
                dtr["value"] = "";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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


        public DataTable getNoteLevels()
        {

            string STMT = @"select
                            data as data,
                            value as value
                            from FACCRED_NOTE_LEVELS order by value asc";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "SELECT";
                dtr["value"] = "0";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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


        public DataTable getNoteLevels_filter()
        {

            string STMT = @"select
                            data as data,
                            value as value
                            from FACCRED_NOTE_LEVELS order by value asc";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "";
                dtr["value"] = "";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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

        //public DataTable getInstDivisions()
        //{
        //    string STMT = @"select
        //                    INSTITUT_DIV_CDE as value,
        //                    INSTITUT_DIV_CDE + ' - ' + INSTITUT_DIV_DESC as data
        //                    from INSTIT_DIVISN_DEF order by INSTITUT_DIV_CDE";
        //    DataTable dt = new DataTable();
        //    DataColumn dc0 = new DataColumn("data");
        //    DataColumn dc1 = new DataColumn("value");

        //    dt.Columns.Add(dc0);
        //    dt.Columns.Add(dc1);


        //    try
        //    {
        //        DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
        //        DataSet ds = da.execDataSet(STMT,
        //            CommandType.Text,
        //            new ParamStruct[]{
        //                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
        //            });
        //        //add a blank row to force the user to select a value
        //        DataRow dtr = dt.NewRow();
        //        dtr["data"] = "";
        //        dtr["value"] = "";
        //        dt.Rows.Add(dtr);


        //        if (ds.Tables.Count > 0)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                DataRow mydr = dt.NewRow();
        //                mydr["data"] = dr["data"].ToString();
        //                mydr["value"] = dr["value"].ToString().Trim();

        //                dt.Rows.Add(mydr);
        //            }
        //        }

        //        return dt;
        //    }

        //    catch (Exception ex)
        //    {
        //        // errMsg.Visible = true;
        //        //  errMsg.ErrorMessage = ex.Message.ToString();
        //        ExceptionManager.Publish(ex);
        //        return dt;
        //    }
        //}


        public DataTable getInstDivisions()
        {

            string STMT = @"select distinct 
                            sm.INSTITUT_DIV_CDE as value , 
                            sm.INSTITUT_DIV_CDE + ' - ' + idd.INSTITUT_DIV_DESC as data
                            from FACULTY_LOAD_TABLE  flt
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                            join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE
                            where 
                             sm.INSTITUT_DIV_CDE is not null
                            order by sm.INSTITUT_DIV_CDE";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "";
                dtr["value"] = "";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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

        public DataTable getInstDivisionsUserAccess(string userID)
        {

            string STMT = @"select distinct 
                            sm.INSTITUT_DIV_CDE as value , 
                            sm.INSTITUT_DIV_CDE + ' - ' + idd.INSTITUT_DIV_DESC as data
                            from FACULTY_LOAD_TABLE  flt
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                            join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE
                            where 
                             sm.INSTITUT_DIV_CDE is not null
                            and sm.INSTITUT_DIV_CDE in (select INST_DIV from FACCRED_USER_ACCESS_XREF WHERE  USER_ID = @userID ) 
                            order by sm.INSTITUT_DIV_CDE";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "";
                dtr["value"] = "";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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

        public DataTable getSchoolCodeUserAccess(string userID)
        {

            string STMT = @"select distinct 
                            sm.SCHOOL_CDE as value , 
                            sm.SCHOOL_CDE + ' - ' + tscv.DESCRIPTION as data
                            from FACULTY_LOAD_TABLE  flt
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
							join TD_SCHOOL_CDE_VIEW tscv on tscv.value = sm.SCHOOL_CDE
                            where 
                             sm.SCHOOL_CDE is not null
                            and sm.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE  USER_ID = @userID ) 
                            order by sm.SCHOOL_CDE";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "";
                dtr["value"] = "";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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

        public DataTable getSpecificDivisions(string idnum, string yearcode, string termcode)
        {

            string STMT = @"select distinct 
                            sm.INSTITUT_DIV_CDE as value , 
                            sm.INSTITUT_DIV_CDE + ' - ' + idd.INSTITUT_DIV_DESC as data
                            from FACULTY_LOAD_TABLE  flt
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                            join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE
                            where 
                             sm.INSTITUT_DIV_CDE is not null
                             and flt.YR_CDE = @yearcode
							 and flt.TRM_CDE = @termcode
							 and flt.INSTRCTR_ID_NUM = @idnum                            
                            order by sm.INSTITUT_DIV_CDE";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("idnum", idnum, DbType.String, ParameterDirection.Input)
                                            });

                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "SELECT";
                dtr["value"] = "0";
                dt.Rows.Add(dtr);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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



        public DataTable getDivisions()
        {
            string STMT = @"SELECT 
                            DIV_CDE as value, 
                            DIV_CDE + ' - ' + DIV_DESC as data
                            FROM DIVISION_DEF ORDER BY DIV_CDE";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]{
                        new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                    });
                //add a blank row to force the user to select a value

                //COMMENTED OUT FOR MIDLAND BECAUSE THEY ONLY HAVE ONE DIVISION:  UG
                //DataRow dtr = dt.NewRow();
                //dtr["data"] = "";
                //dtr["value"] = "";
                //dt.Rows.Add(dtr);


                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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

        public DataTable getSchoolCodes()
        {
            string STMT = @"select RTRIM(VALUE) as value, RTRIM(VALUE) + ' - ' + DESCRIPTION as data from TD_SCHOOL_CDE_VIEW";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("data");
            DataColumn dc1 = new DataColumn("value");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]{
                        new ParamStruct("data", "1", DbType.String, ParameterDirection.Input)
                    });
                //add a blank row to force the user to select a value
                DataRow dtr = dt.NewRow();
                dtr["data"] = "";
                dtr["value"] = "";
                dt.Rows.Add(dtr);


                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["data"] = dr["data"].ToString();
                        mydr["value"] = dr["value"].ToString().Trim();

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

 


    }
}
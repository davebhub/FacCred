using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models.Interfaces;
using System.Data;
using System.IO;
using Jenzabar.ERP.EX.DAL;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;

namespace FacCred.Models
{
    public class MainMenuModel : System.Web.UI.UserControl
    {
        public string year = "2016";
        public string term = "FL";

        public string getTerm()
        {
            return term;
        }

        public string getYear()
        {
            return year;
        }

        public void setTerm(string trm)
        {
            this.term = trm;
        }

        public void setYear(string yr)
        {
            this.year = yr;
        }

        public DataSet getDataSQLYear()
        {


            string STMT = @"select
                            fm.ID_NUM as idnum,
                            nm.LAST_NAME as lastname,
                            nm.FIRST_NAME as firstname,
                            itv.DESCRIPTION as insttype                           
                            from FACULTY_MASTER fm
                            join name_master nm on nm.ID_NUM = fm.ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            where 
                            fm.ACTIVE = 'Y'
                            order by LAST_NAME;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("idnum");
            DataColumn dc1 = new DataColumn("lastname");
            DataColumn dc2 = new DataColumn("firstname");
            DataColumn dc3 = new DataColumn("insttype");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("idnum", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["idnum"] = dr["idnum"].ToString();
                        mydr["lastname"] = dr["lastname"].ToString().Trim();
                        mydr["firstname"] = dr["firstname"].ToString().Trim();
                        mydr["insttype"] = dr["insttype"].ToString().Trim();
                        dt.Rows.Add(mydr);
                    }
                }

                return ds;
            }

            catch (Exception ex)
            {
                // errMsg.Visible = true;
                //  errMsg.ErrorMessage = ex.Message.ToString();
                ExceptionManager.Publish(ex);
                return null;
            }
        }




        public DataSet getDataSQLTerm()
        {


            string STMT = @"select trm_cde as termid,
                            trm_cde as termcode
                            from TERM_DEF
                            order by TRM_SORT_ORDER
                            ;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("termid");
            DataColumn dc1 = new DataColumn("termcode");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("termid", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["termid"] = dr["termid"].ToString();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        dt.Rows.Add(mydr);
                    }
                }

                //return dt;
                return ds;
            }

            catch (Exception ex)
            {
                // errMsg.Visible = true;
                //  errMsg.ErrorMessage = ex.Message.ToString();
                ExceptionManager.Publish(ex);
                return null;

            }
        }
    }
}
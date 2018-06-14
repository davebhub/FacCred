using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models.Interfaces;
using System.Data;
using Jenzabar.ERP.EX.DAL;

using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;

namespace FacCred.Models
{
    public class EDUEarnHistModel : System.Web.UI.UserControl
    {
        public DataTable getDataSQL()
        {
            string STMT = @"select 
                            fm.APPID as FACappid,
                            e.ID_NUM as FACidnum,						
							nm.LAST_NAME as FAClastname,
							nm.FIRST_NAME as FACfirstname,
							itv.description  AS FACtype,
                            q.DESCR as description,
                            iif(e.earned_major is null,'',e.earned_major) as MajorDisp ,
                            iif(e.school_name is null,'',e.school_name) as institution,
                            iif(e.honors is null, '', e.honors) as honors,
                            iif(e.yrs_completed is null, '' , e.yrs_completed) as completedyear
                            from
                            edu_earn_hist e
                            join ed_offering_def q on q.id = e.ED_OFFERING_DEF_ID
                            join faculty_master fm on fm.id_num = e.id_num
							join NAME_MASTER nm on nm.ID_NUM = fm.ID_NUM
							left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            order by facidnum;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACtype");
            DataColumn dc5 = new DataColumn("description");
            DataColumn dc6 = new DataColumn("MajorDisp");
            DataColumn dc7 = new DataColumn("institution");
            DataColumn dc8 = new DataColumn("honors");
            DataColumn dc9 = new DataColumn("completedyear");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);
            dt.Columns.Add(dc9);
            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("FACidnum", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString();
                        mydr["FACidnum"] = dr["FACidnum"].ToString().Trim();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["description"] = dr["description"].ToString().Trim();
                        mydr["MajorDisp"] = dr["MajorDisp"].ToString().Trim();
                        mydr["institution"] = dr["institution"].ToString().Trim();
                        mydr["honors"] = dr["honors"].ToString().Trim();
                        mydr["completedyear"] = dr["completedyear"].ToString().Trim();
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
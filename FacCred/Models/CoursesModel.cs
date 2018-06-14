using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models.Interfaces;
using System.Data;
using Jenzabar.ERP.EX.DAL;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using System.IO;

namespace FacCred.Models
{
    public class CoursesModel : System.Web.UI.UserControl
    {
        protected string id_num;

        public DataTable getDataSQL()
        {
            string STMT = @"select
                            flt.APPID as FLTappid,
                            flt.INSTRCTR_ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,
                            sm.INSTITUT_DIV_CDE as CRSinstdiv,
                            sm.YR_CDE as CRSyearcode,
                            sm.TRM_CDE as CRStermcode,
                            flt.CRS_CDE as CRScde,
                            flt.LOAD_PERCENTAGE as FACload,
                            flt.LEAD_INSTRCTR_FLG as FAClead,
                            sm.school_cde as CRSschoolcde,
                            sm.APPID as	CRSappid,
                            sm.CRS_TITLE as CRStitle,
                            sm.DIVISION_CDE as CRSdiv
                            from FACULTY_LOAD_TABLE  flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                            left outer join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE							 
                            where 
                            fm.ACTIVE = 'Y'
                            order by flt.INSTRCTR_ID_NUM";

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FLTappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("CRSinstdiv");
            DataColumn dc5 = new DataColumn("CRSyearcode");
            DataColumn dc6 = new DataColumn("CRStermcode");
            DataColumn dc7 = new DataColumn("CRScde");
            DataColumn dc8 = new DataColumn("FACload");
            DataColumn dc9 = new DataColumn("FAClead");
            DataColumn dc10 = new DataColumn("CRSschoolcde");
            DataColumn dc11 = new DataColumn("CRSappid");
            DataColumn dc12 = new DataColumn("CRStitle");
            DataColumn dc13 = new DataColumn("CRSdiv");
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
            dt.Columns.Add(dc10);
            dt.Columns.Add(dc11);
            dt.Columns.Add(dc12);
            dt.Columns.Add(dc13);

            //DataColumn dc0 = new DataColumn("CRScde");
            //DataColumn dc1 = new DataColumn("CRSyearcode");
            //DataColumn dc2 = new DataColumn("CRStermcode");
            //DataColumn dc3 = new DataColumn("FAClastname");
            //DataColumn dc4 = new DataColumn("FACfirstname");
            //DataColumn dc5 = new DataColumn("CRSinstdiv");
            //DataColumn dc6 = new DataColumn("CRSschoolcde");
            //DataColumn dc7 = new DataColumn("FACload");
            //DataColumn dc8 = new DataColumn("FAClead");
            //DataColumn dc9 = new DataColumn("FACidnum");

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
                        mydr["FLTappid"] = dr["FLTappid"].ToString();
                        mydr["FACidnum"] = dr["FACidnum"].ToString().Trim();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["CRSinstdiv"] = dr["CRSinstdiv"].ToString().Trim();
                        mydr["CRSyearcode"] = dr["CRSyearcode"].ToString().Trim();
                        mydr["CRStermcode"] = dr["CRStermcode"].ToString().Trim();
                        mydr["CRScde"] = dr["CRScde"].ToString().Trim();
                        mydr["FACload"] = dr["FACload"].ToString().Trim();
                        mydr["FAClead"] = dr["FAClead"].ToString().Trim();
                        mydr["CRSschoolcde"] = dr["CRSschoolcde"].ToString().Trim();
                        mydr["CRSappid"] = dr["CRSappid"].ToString().Trim();
                        mydr["CRStitle"] = dr["CRStitle"].ToString().Trim();
                        mydr["CRSdiv"] = dr["CRSdiv"].ToString().Trim();

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


        public void setIdNum(string idnum)
        {
            this.id_num = idnum;
        }

        public string getIdNum()
        {
            return this.id_num;
        }

    }

}
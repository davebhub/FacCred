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
    public class CatalogModel : System.Web.UI.UserControl
    {
        protected string id_num;

        public DataTable getDataSQL()
        {
            string STMT = @"select
                            iif (appid is null, '', appid) as catappid,
                            iif(org_cde is null,'',org_cde) as orgcde,
                            iif(crs_cde is null,'',crs_cde) as crscde,
                            iif(div_cde is null,'',div_cde) as divcde,
                            iif(instit_div_cde is null,'',instit_div_cde) as instdiv,
                            iif(crs_title is null,'',crs_title) as crstitle,
                            iif(school_cde is null, '', school_cde) as schoolcde,
                            iif(UDEF_1A_1 is null, '', udef_1a_1) as yourDivision
                            from CATALOG_MASTER";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("catappid");
            DataColumn dc1 = new DataColumn("orgcde");
            DataColumn dc2 = new DataColumn("crscde");
            DataColumn dc3 = new DataColumn("divcde");
            DataColumn dc4 = new DataColumn("instdiv");
            DataColumn dc5 = new DataColumn("crstitle");
            DataColumn dc6 = new DataColumn("schoolcde");
            DataColumn dc7 = new DataColumn("yourDivision");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("facidnum", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["catappid"] = dr["catappid"].ToString();
                        mydr["orgcde"] = dr["orgcde"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString().Trim();
                        mydr["divcde"] = dr["divcde"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["crstitle"] = dr["crstitle"].ToString().Trim();
                        mydr["schoolcde"] = dr["schoolcde"].ToString().Trim();
                        mydr["yourDivision"] = dr["yourDivision"].ToString().Trim();

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
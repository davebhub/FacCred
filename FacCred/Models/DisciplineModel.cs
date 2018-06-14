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
    public class DisciplineModel : System.Web.UI.UserControl
    {
        protected string id_num;

        public DataTable getDataSQL()
        {
            string STMT = @"select DISTINCT 
                            iif(cm.DIVISION_CDE is null,'',cm.DIVISION_CDE) as CATdiv, 
                            iif(dd.DIV_DESC is null,'',dd.DIV_DESC) as CATdivdesc, 
                            iif(cm.INSTITUT_DIV_CDE is null, '',cm.INSTITUT_DIV_CDE) as CATinstdiv   , 
                            iif(idd.INSTITUT_DIV_DESC is null, '', idd.INSTITUT_DIV_DESC) as CATinstdivdesc  , 
                            iif(cm.SCHOOL_CDE is null, '', cm.SCHOOL_CDE) as CATschoolcde,
                            iif(tscv.DESCRIPTION is null, '', tscv.description) as CATschoolcdedesc
                            FROM SECTION_MASTER cm
                            JOIN DIVISION_DEF dd on dd.DIV_CDE = cm.DIVISION_CDE
                            join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = cm.INSTITUT_DIV_CDE
                            left outer join TD_SCHOOL_CDE_VIEW tscv on tscv.VALUE = cm.SCHOOL_CDE
                            ORDER BY CATinstdiv, CATinstdivdesc, CATdiv, CATdivdesc,  CATschoolcde";

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("CATdiv");
            DataColumn dc1 = new DataColumn("CATdivdesc");
            DataColumn dc2 = new DataColumn("CATinstdiv");
            DataColumn dc3 = new DataColumn("CATinstdivdesc");
            DataColumn dc4 = new DataColumn("CATschoolcde");
            DataColumn dc5 = new DataColumn("CATschoolcdedesc");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);

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
                        mydr["CATdiv"] = dr["CATdiv"].ToString();
                        mydr["CATdivdesc"] = dr["CATdivdesc"].ToString().Trim();
                        mydr["CATinstdiv"] = dr["CATinstdiv"].ToString().Trim();
                        mydr["CATinstdivdesc"] = dr["CATinstdivdesc"].ToString().Trim();
                        mydr["CATschoolcde"] = dr["CATschoolcde"].ToString().Trim();
                        mydr["CATschoolcdedesc"] = dr["CATschoolcdedesc"].ToString().Trim();

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
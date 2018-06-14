using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models.Interfaces;
using System.Data;
using Jenzabar.ERP.EX.DAL;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using System.IO;
using NHibernate.Linq.Functions;

namespace FacCred.Models
{
    public class FacultyModel : System.Web.UI.UserControl
    {
        protected string id_num;


        public DataTable getDataSQL(string year, string term)
        {

            string STMT = @"select distinct
                            fm.appid as FACappid,
                            fm.id_num as FACidnum,
                            nm.last_name as FAClastname,
                            nm.first_name as FACfirstname,
                            fm.certification as FACcertification,
                            itv.description  AS FACinsttype,
                            fm.authorize_capacity as FACcapacity, 
                            fm.authorize_sched_conflict as FACconflict,
                            fm.authorize_requisite as FACrequisite,
							fdx.DIV_CDE as FACdivcode,
                            fdx.INSTIT_DIV_CDE as FACinstdiv,
							fdx.SCHOOL_CDE as FACschoolcode
						,(select count(*) from FACCRED_NOTES fn where fn.FAC_ID_NUM = fm.id_num and fn.YEARCODE = @year and fn.TERMCODE = @term and fn.SCHOOL_CDE = fdx.SCHOOL_CDE and fn.INSTIT_DIV_CDE = fdx.INSTIT_DIV_CDE  ) as notes
                        ,(select count(*) from FACCRED_NOTES fn where fn.FAC_ID_NUM = fm.id_num and fn.YEARCODE = @year and fn.TERMCODE = @term and fn.SCHOOL_CDE = fdx.SCHOOL_CDE and fn.INSTIT_DIV_CDE = fdx.INSTIT_DIV_CDE and fn.STATUS = 'P'  ) as pending
						,(select count(*) from FACCRED_NOTES fn where fn.FAC_ID_NUM = fm.id_num and fn.YEARCODE = @year and fn.TERMCODE = @term and fn.STATUS = 'A' and fn.SCHOOL_CDE = fdx.SCHOOL_CDE and fn.INSTIT_DIV_CDE = fdx.INSTIT_DIV_CDE  AND (fn.EXPIRATION_DATE < GETDATE() + 60  )) as Aexpir60

                            from FACULTY_MASTER fm
                            join name_master nm on nm.id_num = fm.ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            left outer join FACCRED_FAC_DIS_XREF fdx on fdx.FAC_APPID = fm.appid and fdx.FAC_ID_NUM = fm.id_num
                            left outer join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = fdx.INSTIT_DIV_CDE
                            where
                            fm.ACTIVE = 'Y'
                            order by nm.LAST_NAME";

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACcertification");
            DataColumn dc5 = new DataColumn("FACinsttype");
            DataColumn dc6 = new DataColumn("FACcapacity");
            DataColumn dc7 = new DataColumn("FACconflict");
            DataColumn dc8 = new DataColumn("FACrequisite");
            DataColumn dc9 = new DataColumn("FACdivcode");
            DataColumn dc10 = new DataColumn("FACinstdiv");
            DataColumn dc11 = new DataColumn("FACschoolcode");
            DataColumn dc12 = new DataColumn("notes");
            DataColumn dc13 = new DataColumn("pending");
            DataColumn dc14 = new DataColumn("Aexpir60");



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
            dt.Columns.Add(dc14);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("year", year, DbType.String, ParameterDirection.Input),
                        new ParamStruct("term", term, DbType.String, ParameterDirection.Input)
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
                        mydr["FACcertification"] = dr["FACcertification"].ToString().Trim();
                        mydr["FACinsttype"] = dr["FACinsttype"].ToString().Trim();
                        mydr["FACcapacity"] = dr["FACcapacity"].ToString().Trim();
                        mydr["FACconflict"] = dr["FACconflict"].ToString().Trim();
                        mydr["FACrequisite"] = dr["FACrequisite"].ToString().Trim();
                        mydr["FACdivcode"] = dr["FACdivcode"].ToString().Trim();
                        mydr["FACinstdiv"] = dr["FACinstdiv"].ToString().Trim();
                        mydr["FACschoolcode"] = dr["FACschoolcode"].ToString().Trim();
                        mydr["notes"] = dr["notes"].ToString().Trim();
                        mydr["pending"] = dr["pending"].ToString().Trim();
                        mydr["Aexpir60"] = dr["Aexpir60"].ToString().Trim();

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


        public DataTable getUserAccessFaculty(string userID, string firstName, string lastName, string year, string term)
        {

            string STMT =
                        @"
                        select distinct
                        fm.appid as FACappid,
                        fm.id_num as FACidnum,
                        nm.last_name as FAClastname,
                        nm.first_name as FACfirstname,
                        fm.certification as FACcertification,
                        itv.description  AS FACinsttype,
                        fm.authorize_capacity as FACcapacity, 
                        fm.authorize_sched_conflict as FACconflict,
                        fm.authorize_requisite as FACrequisite,
		                fdx.DIV_CDE as FACdivcode,
                        fdx.INSTIT_DIV_CDE as FACinstdiv,
		                fdx.SCHOOL_CDE as FACschoolcode
						,(select count(*) from FACCRED_NOTES fn where fn.FAC_ID_NUM = fm.id_num and fn.YEARCODE = @year and fn.TERMCODE = @term and fn.SCHOOL_CDE = fdx.SCHOOL_CDE and fn.INSTIT_DIV_CDE = fdx.INSTIT_DIV_CDE  ) as notes
                        ,(select count(*) from FACCRED_NOTES fn where fn.FAC_ID_NUM = fm.id_num and fn.YEARCODE = @year and fn.TERMCODE = @term and fn.SCHOOL_CDE = fdx.SCHOOL_CDE and fn.INSTIT_DIV_CDE = fdx.INSTIT_DIV_CDE and fn.STATUS = 'P'  ) as pending
						,(select count(*) from FACCRED_NOTES fn where fn.FAC_ID_NUM = fm.id_num and fn.YEARCODE = @year and fn.TERMCODE = @term and fn.STATUS = 'A' and fn.SCHOOL_CDE = fdx.SCHOOL_CDE and fn.INSTIT_DIV_CDE = fdx.INSTIT_DIV_CDE  AND (fn.EXPIRATION_DATE < GETDATE() + 60  )) as Aexpir60
                        from FACULTY_MASTER fm
                        join name_master nm on nm.id_num = fm.ID_NUM
                        left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                        left outer join FACCRED_FAC_DIS_XREF fdx on fdx.FAC_APPID = fm.appid and fdx.FAC_ID_NUM = fm.id_num
                        where
                        fm.ACTIVE = 'Y'
                        and fdx.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID ) 
                        order by nm.LAST_NAME";


            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACcertification");
            DataColumn dc5 = new DataColumn("FACinsttype");
            DataColumn dc6 = new DataColumn("FACcapacity");
            DataColumn dc7 = new DataColumn("FACconflict");
            DataColumn dc8 = new DataColumn("FACrequisite");
            DataColumn dc9 = new DataColumn("FACdivcode");
            DataColumn dc10 = new DataColumn("FACinstdiv");
            DataColumn dc11 = new DataColumn("FACschoolcode");
            DataColumn dc12 = new DataColumn("notes");
            DataColumn dc13 = new DataColumn("pending");
            DataColumn dc14 = new DataColumn("Aexpir60");


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
            dt.Columns.Add(dc14);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input),
                        new ParamStruct("year", year, DbType.String, ParameterDirection.Input),
                        new ParamStruct("term", term, DbType.String, ParameterDirection.Input)
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
                        mydr["FACcertification"] = dr["FACcertification"].ToString().Trim();
                        mydr["FACinsttype"] = dr["FACinsttype"].ToString().Trim();
                        mydr["FACcapacity"] = dr["FACcapacity"].ToString().Trim();
                        mydr["FACconflict"] = dr["FACconflict"].ToString().Trim();
                        mydr["FACrequisite"] = dr["FACrequisite"].ToString().Trim();
                        mydr["FACdivcode"] = dr["FACdivcode"].ToString().Trim();
                        mydr["FACinstdiv"] = dr["FACinstdiv"].ToString().Trim();
                        mydr["FACschoolcode"] = dr["FACschoolcode"].ToString().Trim();
                        mydr["notes"] = dr["notes"].ToString().Trim();
                        mydr["pending"] = dr["pending"].ToString().Trim();
                        mydr["Aexpir60"] = dr["Aexpir60"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                // errMsg.Visible = true;
                //  errMsg.ErrorMessage = ex.Message.ToString();
                //ExceptionManager.Publish(ex);
                //return dt;
                return rtnNoRecordsFound();
            }
        }



        public DataTable getFacultyXREF(string FACappid, string FACidnum)
        {

            string STMT =
                        @"SELECT 
                          ID,
                          FAC_APPID,
                          FAC_ID_NUM,
                          DIV_CDE,
                          INSTIT_DIV_CDE,
                          SCHOOL_CDE
                          FROM FACCRED_FAC_DIS_XREF
                          WHERE FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum ";


            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("ID");
            DataColumn dc1 = new DataColumn("FAC_APPID");
            DataColumn dc2 = new DataColumn("FAC_ID_NUM");
            DataColumn dc3 = new DataColumn("DIV_CDE");
            DataColumn dc4 = new DataColumn("INSTIT_DIV_CDE");
            DataColumn dc5 = new DataColumn("SCHOOL_CDE");


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
                    new ParamStruct[]
                    {
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input)
                    });
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["ID"] = dr["ID"].ToString().Trim();
                        mydr["FAC_APPID"] = dr["FAC_APPID"].ToString().Trim();
                        mydr["FAC_ID_NUM"] = dr["FAC_ID_NUM"].ToString().Trim();
                        mydr["DIV_CDE"] = dr["DIV_CDE"].ToString().Trim();
                        mydr["INSTIT_DIV_CDE"] = dr["INSTIT_DIV_CDE"].ToString().Trim();
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
                //ExceptionManager.Publish(ex);
                //return dt;
                return rtnNoXREFRecordsFound();
            }
        }




        public bool insertOneFacultyXREF(Guid xref_id, string FACappid, string FACidnum, string divcode, string instdiv, string schoolcode)
        {

            string STMT =
                @"INSERT INTO FACCRED_FAC_DIS_XREF
                       (ID
                       ,FAC_APPID
                       ,FAC_ID_NUM
                       ,DIV_CDE
                       ,INSTIT_DIV_CDE
                       ,SCHOOL_CDE)
                 VALUES
                       (@xref_id
                       ,@FACappid
                       ,@FACidnum
                       ,@divcode
                       ,@instdiv
                       ,@schoolcode );";

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("xref_id", xref_id, DbType.Guid, ParameterDirection.Input),
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("divcode", divcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("instdiv", instdiv, DbType.String, ParameterDirection.Input),
                        new ParamStruct("schoolcode", schoolcode, DbType.String, ParameterDirection.Input)
                    });

                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }

        }


        public bool deleteOneFacultyXREF(Guid id)
        {

            string STMT =
                @"DELETE FROM FACCRED_FAC_DIS_XREF
              WHERE ID = @id;";

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("id", id, DbType.Guid, ParameterDirection.Input)
                    });

                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }

        }









        public DataTable ExecuteFacultyRefresh()
        {
            string STMT = @"DECLARE	@return_value int
                            EXEC	@return_value = [dbo].[FACCRED_XREF_UPDATE]
                            SELECT	'ReturnValue' = @return_value ";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            dt.Columns.Add(dc0);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("ReturnValue", "1", DbType.String, ParameterDirection.Output)
                    });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["ReturnValue"] = dr["ReturnValue"].ToString();
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


        public DataTable rtnNoRecordsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACcertification");
            table1.Columns.Add("FACinsttype");
            table1.Columns.Add("FACcapacity");
            table1.Columns.Add("FACconflict");
            table1.Columns.Add("FACrequisite");
            table1.Columns.Add("FACdivcode");
            table1.Columns.Add("FACinstdiv");
            table1.Columns.Add("FACschoolcode");


            table1.Rows.Add("","","no records found");

            //DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            return table1;
        }

        public DataTable rtnNoXREFRecordsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("ID");
            table1.Columns.Add("FAC_APPID");
            table1.Columns.Add("FAC_ID_NUM");
            table1.Columns.Add("DIV_CDE");
            table1.Columns.Add("INSTIT_DIV_CDE");
            table1.Columns.Add("SCHOOL_CDE");

            table1.Rows.Add("", "", "no records found");

            //DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            return table1;
        }




        //public void setIdNum(string idnum)
        //{
        //    this.id_num = idnum;
        //}

        //public string getIdNum()
        //{
        //    return this.id_num;
        //}

    }

}
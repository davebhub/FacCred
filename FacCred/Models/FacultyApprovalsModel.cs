using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FacCred.Models.Interfaces;
using System.Data.SqlClient;
using System.IO;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using Jenzabar.ERP.EX.DAL;

namespace FacCred.Models
{
    public class FacultyApprovalsModel : System.Web.UI.UserControl
    {

        public DataTable getAllFacultyApprovals()
        {
            string STMT = @"select
                            FAC_APPID as FACappid,
                            FAC_ID_NUM as FACidnum,
                            DIV_CDE as divcode,
							INSTIT_DIV_CDE as instdiv,
                            SCHOOL_CDE as schoolcode,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            FAC_TYPE as FACtype,                    
                            APPROVER1 as approver1,
                            APPROVER2 as approver2,
                            APPROVER3 as approver3,                           
                            APPROVAL_DATE as approvalDate,
                            EXPIRATION_DATE as expirationDate,
                            MODIFIED_DATE as moddate
                            from FACCRED_FACULTY_APPROVALS
                                order by MODIFIED_DATE DESC;";

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");            
            DataColumn dc2 = new DataColumn("divcode");
            DataColumn dc3 = new DataColumn("instdiv");
            DataColumn dc4 = new DataColumn("schoolcode");
            DataColumn dc5 = new DataColumn("FAClastname");
            DataColumn dc6 = new DataColumn("FACfirstname");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver1");
            DataColumn dc9 = new DataColumn("approver2");
            DataColumn dc10 = new DataColumn("approver3");
            DataColumn dc11 = new DataColumn("approvalDate");
            DataColumn dc12 = new DataColumn("expirationDate");
            DataColumn dc13 = new DataColumn("moddate");


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
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver1"] = dr["approver1"].ToString().Trim();
                        mydr["approver2"] = dr["approver2"].ToString().Trim();
                        mydr["approver3"] = dr["approver3"].ToString().Trim();
                        mydr["approvalDate"] = dr["approvalDate"].ToString().Trim();
                        mydr["expirationDate"] = dr["expirationDate"].ToString().Trim();
                        mydr["moddate"] = dr["moddate"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }

        public DataTable getAllFacultyApprovalsLIU(string userID, string firstName, string lastName)
        {
            string STMT = @"select
                            FAC_APPID as FACappid,
                            FAC_ID_NUM as FACidnum,
                            DIV_CDE as divcode,
							INSTIT_DIV_CDE as instdiv,
                            SCHOOL_CDE as schoolcode,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            FAC_TYPE as FACtype,                    
                            APPROVER1 as approver1,
                            APPROVER2 as approver2,
                            APPROVER3 as approver3,                           
                            APPROVAL_DATE as approvalDate,
                            EXPIRATION_DATE as expirationDate,
                            MODIFIED_DATE as moddate
                            from FACCRED_FACULTY_APPROVALS
                            where  
                                SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                                order by MODIFIED_DATE DESC;";

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("divcode");
            DataColumn dc3 = new DataColumn("instdiv");
            DataColumn dc4 = new DataColumn("schoolcode");
            DataColumn dc5 = new DataColumn("FAClastname");
            DataColumn dc6 = new DataColumn("FACfirstname");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver1");
            DataColumn dc9 = new DataColumn("approver2");
            DataColumn dc10 = new DataColumn("approver3");
            DataColumn dc11 = new DataColumn("approvalDate");
            DataColumn dc12 = new DataColumn("expirationDate");
            DataColumn dc13 = new DataColumn("moddate");


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




            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver1"] = dr["approver1"].ToString().Trim();
                        mydr["approver2"] = dr["approver2"].ToString().Trim();
                        mydr["approver3"] = dr["approver3"].ToString().Trim();
                        mydr["approvalDate"] = dr["approvalDate"].ToString().Trim();
                        mydr["expirationDate"] = dr["expirationDate"].ToString().Trim();
                        mydr["moddate"] = dr["moddate"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }


        //GENERAL ----------------------------------------------------------------------------------------------------


        public bool InsertUpdateFacultyApproval(string approvalCode,
                                               string FACappid,
                                               string FACidnum,
                                               string div_cde,
                                               string instit_div_cde,
                                               string school_cde,
                                               string lastname,
                                               string firstname,
                                               string FACtype,                                              
                                               string approvalDate,
                                               string expirationDate,
                                               string modDate,
                                               string userlevel
                                               )
        {
            string STMT = String.Empty;



            if (userlevel == "Approver1")
            {
                STMT = @" IF (SELECT count(*) from FACCRED_FACULTY_APPROVALS  where FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND DIV_CDE = @div_cde AND INSTIT_DIV_CDE = @instit_div_cde AND SCHOOL_CDE = @school_cde ) = 0
                               INSERT INTO FACCRED_FACULTY_APPROVALS 
                                    VALUES(@FACappid, @FACidnum, @div_cde, @instit_div_cde, @school_cde, @lastname,  @firstname, @FACtype, @approvalCode, '', '', @approvalDate, @expirationDate, @modDate)
                               ELSE UPDATE FACCRED_FACULTY_APPROVALS 
                                    SET Approver1 = @approvalCode , MODIFIED_DATE = @modDate,  APPROVAL_DATE = @approvalDate , EXPIRATION_DATE = @expirationDate 
                                        where FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND DIV_CDE = @div_cde AND INSTIT_DIV_CDE = @instit_div_cde AND SCHOOL_CDE = @school_cde ";
            }
            else if (userlevel == "Approver2")
            {
                STMT = @"UPDATE FACCRED_FACULTY_APPROVALS SET Approver2 = @approvalCode , MODIFIED_DATE = @modDate 
                            where FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND DIV_CDE = @div_cde AND INSTIT_DIV_CDE = @instit_div_cde AND SCHOOL_CDE = @school_cde ";
            }
            else if (userlevel == "Approver3")
            {
                STMT = @"UPDATE FACCRED_FACULTY_APPROVALS SET Approver3 = @approvalCode , MODIFIED_DATE = @modDate 
                                where FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND DIV_CDE = @div_cde AND INSTIT_DIV_CDE = @instit_div_cde AND SCHOOL_CDE = @school_cde ";
            }


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{ 
                                    new ParamStruct("approvalCode", approvalCode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("div_cde", div_cde, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("instit_div_cde", instit_div_cde, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("school_cde", school_cde, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("approvalDate", approvalDate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("expirationDate", expirationDate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("modDate", modDate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input)
                               });

                return true;
            }
            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return false;
            }

        }




        //APPROVER 1 -------------------------------------------------------------------------------------

        public DataTable getApprover1Faculty(string userID, string firstName, string lastName)
        {
            string STMT = @"select distinct
                            fm.appid as FACappid,
                            flt.INSTRCTR_ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,               
                            itv.DESCRIPTION as FACtype
                            from FACULTY_LOAD_TABLE  flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE		
                            left outer join FACCRED_FAC_DIS_XREF fdx on fdx.FAC_APPID = fm.appid and fdx.FAC_ID_NUM = fm.id_num
                            where  
                                fdx.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                            and
                                fm.ACTIVE = 'Y'
                            order by nm.LAST_NAME;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACtype");
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
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return dt;
            }
        }




        public DataTable getApprover1FacultyDiscipline()
        {
            string STMT = @"select distinct
                            fm.appid as FACappid,
                            flt.INSTRCTR_ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,               
                            itv.DESCRIPTION as FACtype, 
                            ffdx.DIV_CDE as FACdivcode,
                            ffdx.SCHOOL_CDE as FACschoolcode,
							ffdx.INSTIT_DIV_CDE as FACinstdiv,
                            fac.APPROVER1 as approver,
                            fac.APPROVAL_DATE AS approvalDate,
                            fac.EXPIRATION_DATE AS expirationDate
                            from FACULTY_LOAD_TABLE  flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            left outer join FACCRED_FAC_DIS_XREF ffdx on ffdx.FAC_ID_NUM = fm.ID_NUM	
                            left outer join FACCRED_FACULTY_APPROVALS  fac on fac.FAC_ID_NUM = flt.INSTRCTR_ID_NUM  and fac.FAC_APPID = fm.APPID and fac.INSTIT_DIV_CDE = ffdx.INSTIT_DIV_CDE		 
                            where 
                            fm.ACTIVE = 'Y'
                            order by flt.INSTRCTR_ID_NUM;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACtype");
            DataColumn dc5 = new DataColumn("FACdivcode");
            DataColumn dc6 = new DataColumn("FACinstdiv");
            DataColumn dc7 = new DataColumn("FACschoolcode");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("approvalDate");
            DataColumn dc10 = new DataColumn("expirationDate");
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
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["FACdivcode"] = dr["FACdivcode"].ToString().Trim();
                        mydr["FACinstdiv"] = dr["FACinstdiv"].ToString().Trim();
                        mydr["FACschoolcode"] = dr["FACschoolcode"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["approvalDate"] = dr["approvalDate"].ToString().Trim();
                        mydr["expirationDate"] = dr["expirationDate"].ToString().Trim();


                        dt.Rows.Add(mydr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return dt;
            }
        }




        public DataTable getApprover1Records(string userID , string firstName, string lastName )
        {
            string STMT = @"select 
                            fm.APPID as FACappid,
                            fm.ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,
                            flt.CRS_CDE as crscde,
                            sm.CRS_TITLE as CRStitle,
                            sm.APPID as SM_appid,
                            flt.YR_CDE as yrcde,
                            flt.TRM_CDE as trmcde,
                            itv.DESCRIPTION as FACtype, 
                            fac.APPROVER1 as approver,
                            sm.DIVISION_CDE as FACdivcode,
                            sm.INSTITUT_DIV_CDE as FACinstdiv,
                            sm.SCHOOL_CDE as FACschoolcode
                            from FACULTY_LOAD_TABLE  flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE	
                            left outer  join FACCRED_FACULTY_APPROVALS fac on fac.FAC_APPID = fm.APPID and fac.FAC_ID_NUM = fm.ID_NUM and fac.SM_APPID = sm.APPID  and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 
                            left outer join FACCRED_FAC_DIS_XREF fdx on fdx.FAC_APPID = fm.appid and fdx.FAC_ID_NUM = fm.id_num
                            where  
                                fdx.INSTIT_DIV_CDE in (select INST_DIV from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                            order by fm.ID_NUM";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("yrcde");
            DataColumn dc6 = new DataColumn("trmcde");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("FACdivcode");
            DataColumn dc10 = new DataColumn("FACinstdiv");
            DataColumn dc11 = new DataColumn("FACschoolcode");
            DataColumn dc12 = new DataColumn("CRStitle");
            DataColumn dc13 = new DataColumn("SM_appid");

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


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["FACdivcode"] = dr["FACdivcode"].ToString().Trim();
                        mydr["FACinstdiv"] = dr["FACinstdiv"].ToString().Trim();
                        mydr["FACschoolcode"] = dr["FACschoolcode"].ToString().Trim();
                        mydr["CRStitle"] = dr["CRStitle"].ToString().Trim();
                        mydr["SM_appid"] = dr["SM_appid"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }


        public DataTable getApprover1RecordsFaculty(string userID, string firstName, string lastName)
        {
            string STMT = @"select distinct
                            fm.appid as FACappid,
                            flt.INSTRCTR_ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,               
                            itv.DESCRIPTION as FACtype, 
                            iif(ffdx.DIV_CDE is null,' ',ffdx.DIV_CDE) as FACdivcode,
                            iif(ffdx.INSTIT_DIV_CDE is null,' ',ffdx.INSTIT_DIV_CDE) as FACinstdiv,
                            iif(ffdx.SCHOOL_CDE is null, ' ' , ffdx.SCHOOL_CDE) as FACschoolcode,
                            fac.APPROVER1 as approver,
                            CAST(fac.APPROVAL_DATE as varchar(10)) AS approvalDate,
                            CAST(fac.EXPIRATION_DATE as varchar(10)) AS expirationDate
                            from FACULTY_LOAD_TABLE  flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            left outer join FACCRED_FAC_DIS_XREF ffdx on ffdx.FAC_ID_NUM = fm.ID_NUM	
                            left outer join FACCRED_FACULTY_APPROVALS  fac on fac.FAC_ID_NUM = flt.INSTRCTR_ID_NUM  and fac.FAC_APPID = fm.APPID 
                                and fac.DIV_CDE = ffdx.DIV_CDE   and fac.INSTIT_DIV_CDE = ffdx.INSTIT_DIV_CDE	 and fac.SCHOOL_CDE = ffdx.SCHOOL_CDE	 
                            left outer join FACCRED_FAC_DIS_XREF fdx on fdx.FAC_APPID = fm.appid and fdx.FAC_ID_NUM = fm.id_num
                            where  
                                ffdx.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                            and fm.ACTIVE = 'Y'
                            order by flt.INSTRCTR_ID_NUM;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACtype");
            DataColumn dc5 = new DataColumn("FACdivcode");
            DataColumn dc6 = new DataColumn("FACinstdiv");
            DataColumn dc7 = new DataColumn("FACschoolcode");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("approvalDate");
            DataColumn dc10 = new DataColumn("expirationDate");

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



            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]{
                        new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                    });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["FACdivcode"] = dr["FACdivcode"].ToString().Trim();
                        mydr["FACinstdiv"] = dr["FACinstdiv"].ToString().Trim();
                        mydr["FACschoolcode"] = dr["FACschoolcode"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["approvalDate"] = dr["approvalDate"].ToString().Trim();
                        mydr["expirationDate"] = dr["expirationDate"].ToString().Trim();


                        dt.Rows.Add(mydr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return dt;
            }
        }



        //APPROVER 2 -------------------------------------------------------------------------------------

        public DataTable getApprover2Faculty(string userID, string firstName, string lastName)
        {
            string STMT = @"select DISTINCT
                            ffa.FAC_APPID as FACappid,
                            ffa.FAC_ID_NUM as FACidnum,
                            ffa.LASTNAME as FAClastname,
                            ffa.FIRSTNAME as FACfirstname,               
                            ffa.FAC_TYPE as FACtype
                            from FACCRED_FACULTY_APPROVALS ffa 
                            left outer join FACCRED_FAC_DIS_XREF fdx on ffa.FAC_APPID = fdx.FAC_APPID and fdx.FAC_ID_NUM = fDX.FAC_ID_NUM
                            where  
                                ffa.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                            and  APPROVER1 = 'A'
                            order by LASTNAME;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACtype");
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
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return dt;
            }
        }



        public DataTable getApprover2RecordsFaculty(string userID, string firstName, string lastName)
        {
            string STMT = @"SELECT 
                                FAC_APPID as FACappid,
                                FAC_ID_NUM as FACidnum,
                                LASTNAME as FAClastname,
                                FIRSTNAME as FACfirstname,
                                FAC_TYPE as FACtype,
                                DIV_CDE as FACdivcode,
                                INSTIT_DIV_CDE as FACinstdiv,
                                SCHOOL_CDE as FACschoolcode,
                                approver2 as approver,
                                APPROVAL_DATE as approvalDate,
                                EXPIRATION_DATE as expirationDate
                                FROM FACCRED_FACULTY_APPROVALS ffa
                                where 
                                ffa.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                                and ffa.APPROVER1 = 'A'
                                order by FAC_ID_NUM; ";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACtype");
            DataColumn dc5 = new DataColumn("FACdivcode");
            DataColumn dc6 = new DataColumn("FACinstdiv");
            DataColumn dc7 = new DataColumn("FACschoolcode");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("approvalDate");
            DataColumn dc10 = new DataColumn("expirationDate");

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

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]{
                        new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                    });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["FACdivcode"] = dr["FACdivcode"].ToString().Trim();
                        mydr["FACinstdiv"] = dr["FACinstdiv"].ToString().Trim();
                        mydr["FACschoolcode"] = dr["FACschoolcode"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["approvalDate"] = dr["approvalDate"].ToString().Trim();
                        mydr["expirationDate"] = dr["expirationDate"].ToString().Trim();


                        dt.Rows.Add(mydr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return dt;
            }
        }



        public DataTable getApprover2FacultyDiscipline(string userID, string firstName, string lastName)
        {
            string STMT = @"select distinct
                            APPID as FACappid,
                            ID_NUM as FACidnum,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            YEARCODE as yrcde,
                            TERMCODE as trmcde, 
                            INST_TYPE as FACtype,                           
                            APPROVER2 as approver,
                            INSTITUT_DIV as instdiv
                             from FACCRED_FACULTY_APPROVALS 
                            WHERE APPROVER1 = 'A'  ;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("yrcde");
            DataColumn dc5 = new DataColumn("trmcde");
            DataColumn dc6 = new DataColumn("FACtype");
            DataColumn dc7 = new DataColumn("approver");
            DataColumn dc8 = new DataColumn("instdiv");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }



        public DataTable getApprover2Records(string userID, string firstName, string lastName)
        {
            string STMT = @"select
                            APPID as FACappid,
                            ID_NUM as FACidnum,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            COURSE as crscde,
                            YEARCODE as yrcde,
                            TERMCODE as trmcde, 
                            INST_TYPE as FACtype,                           
                            APPROVER2 as approver,
                            INSTITUT_DIV as instdiv
                             from FACCRED_FACULTY_APPROVALS 
                            WHERE APPROVER1 = 'A'  ;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("yrcde");
            DataColumn dc6 = new DataColumn("trmcde");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("instdiv");

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
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }






        //APPROVER 3 -------------------------------------------------------------------------------------

        public DataTable getApprover3Faculty(string userID, string firstName, string lastName)
        {
            string STMT = @"select DISTINCT
                            FAC_APPID as FACappid,
                            FAC_ID_NUM as FACidnum,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,               
                            FAC_TYPE as FACtype
                            from FACCRED_FACULTY_APPROVALS 	 
                            where 
                                APPROVER1 = 'A'
                            AND APPROVER2 = 'A'
                            order by LASTNAME;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACtype");
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
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return dt;
            }
        }



        public DataTable getApprover3RecordsFaculty(string userID, string firstName, string lastName)
        {
            string STMT = @"SELECT 
                                FAC_APPID as FACappid,
                                FAC_ID_NUM as FACidnum,
                                LASTNAME as FAClastname,
                                FIRSTNAME as FACfirstname,
                                FAC_TYPE as FACtype,
                                DIV_CDE as FACdivcode,
                                INSTIT_DIV_CDE as FACinstdiv,
                                SCHOOL_CDE as FACschoolcode,
                                approver3 as approver,
                                APPROVAL_DATE as approvalDate,
                                EXPIRATION_DATE as expirationDate
                                FROM FACCRED_FACULTY_APPROVALS ffa
                                where 
                                ffa.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                                and ffa.APPROVER1 = 'A'
                                and ffa.APPROVER2 = 'A'
                                order by FAC_ID_NUM; ";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("FACtype");
            DataColumn dc5 = new DataColumn("FACdivcode");
            DataColumn dc6 = new DataColumn("FACinstdiv");
            DataColumn dc7 = new DataColumn("FACschoolcode");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("approvalDate");
            DataColumn dc10 = new DataColumn("expirationDate");

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

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]{
                        new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                    });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["FACdivcode"] = dr["FACdivcode"].ToString().Trim();
                        mydr["FACinstdiv"] = dr["FACinstdiv"].ToString().Trim();
                        mydr["FACschoolcode"] = dr["FACschoolcode"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["approvalDate"] = dr["approvalDate"].ToString().Trim();
                        mydr["expirationDate"] = dr["expirationDate"].ToString().Trim();


                        dt.Rows.Add(mydr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return dt;
            }
        }

        public DataTable getApprover3FacultyDiscipline(string userID, string firstName, string lastName)
        {
            string STMT = @"select distinct
                            APPID as FACappid,
                            ID_NUM as FACidnum,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            YEARCODE as yrcde,
                            TERMCODE as trmcde, 
                            INST_TYPE as FACtype,                           
                            APPROVER3 as approver,
                            INSTITUT_DIV as instdiv
                             from FACCRED_FACULTY_APPROVALS 
                            where APPROVER1 = 'A' and APPROVER2 = 'A' ";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("yrcde");
            DataColumn dc5 = new DataColumn("trmcde");
            DataColumn dc6 = new DataColumn("FACtype");
            DataColumn dc7 = new DataColumn("approver");
            DataColumn dc8 = new DataColumn("instdiv");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }


        public DataTable getApprover3Records(string userID, string firstName, string lastName)
        {
            string STMT = @"select
                            APPID as FACappid,
                            ID_NUM as FACidnum,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            COURSE as crscde,
                            YEARCODE as yrcde,
                            TERMCODE as trmcde, 
                            INST_TYPE as FACtype,                           
                            APPROVER3 as approver,
                            INSTITUT_DIV as instdiv
                             from FACCRED_FACULTY_APPROVALS 
                            where APPROVER1 = 'A' and APPROVER2 = 'A' ";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("yrcde");
            DataColumn dc6 = new DataColumn("trmcde");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("instdiv");

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
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }


        //FACCRED USER -----------------------------------------------------------------------------------



        public DataTable getFacCredUserFacultyDiscipline(string userID, string firstName, string lastName)
        {
            string STMT = @"select
                flt.APPID as FACappid,
                flt.INSTRCTR_ID_NUM as FACidnum,
                nm.LAST_NAME as FAClastname,
                nm.FIRST_NAME as FACfirstname,
                flt.YR_CDE as yrcde,
                flt.TRM_CDE as trmcde,
                itv.DESCRIPTION as FACtype, 
                'F' as approver,
                sm.INSTITUT_DIV_CDE as instdiv
                from FACULTY_LOAD_TABLE  flt
                join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                left outer join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE		
                left outer join FACCRED_FACULTY_APPROVALS  fac on fac.FAC_APPID = flt.APPID and fac.FAC_ID_NUM = flt.INSTRCTR_ID_NUM and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 				 
                where 
                fm.ACTIVE = 'Y'
                order by flt.INSTRCTR_ID_NUM;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("yrcde");
            DataColumn dc5 = new DataColumn("trmcde");
            DataColumn dc6 = new DataColumn("FACtype");
            DataColumn dc7 = new DataColumn("approver");
            DataColumn dc8 = new DataColumn("instdiv");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }


        public DataTable getFacCredUserRecords(string userID, string firstName, string lastName)
        {
            string STMT = @"select
                flt.APPID as FACappid,
                flt.INSTRCTR_ID_NUM as FACidnum,
                nm.LAST_NAME as FAClastname,
                nm.FIRST_NAME as FACfirstname,
                flt.CRS_CDE as crscde,
                flt.YR_CDE as yrcde,
                flt.TRM_CDE as trmcde,
                itv.DESCRIPTION as FACtype, 
                'F' as approver,
                sm.INSTITUT_DIV_CDE as instdiv,
                sm.appid as SM_appid
                from FACULTY_LOAD_TABLE  flt
                join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                left outer join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE		
                left outer join FACCRED_FACULTY_APPROVALS  fac on fac.APPID = flt.APPID and fac.ID_NUM = flt.INSTRCTR_ID_NUM and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 				 
                where 
                fm.ACTIVE = 'Y'
                order by flt.INSTRCTR_ID_NUM;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("yrcde");
            DataColumn dc6 = new DataColumn("trmcde");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("instdiv");
            DataColumn dc10 = new DataColumn("SM_appid");

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

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("userID", userID, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("firstName", firstName, DbType.String, ParameterDirection.Input),
                                                new ParamStruct("lastName", lastName, DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["SM_appid"] = dr["SM_appid"].ToString().Trim();

                        dt.Rows.Add(mydr);
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return dt;
            }
        }


        //----------------- INST DIV  ------------------------------------------------------------------------------------

        public bool InsertFacultyInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel,  string firstname, string lastname,
                                                             string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv )
        {
            // note: only approver1 can insert new records.
            string STMT = @"
                            WITH RECS AS
                            (
                            select 
                            ffdx.FAC_APPID,
                            ffdx.FAC_ID_NUM,
                            iif(ffdx.DIV_CDE is null,' ',ffdx.DIV_CDE) AS divcode,
                            iif(ffdx.INSTIT_DIV_CDE is null,' ',ffdx.INSTIT_DIV_CDE) as instit_div_cde,
                            iif(ffdx.SCHOOL_CDE is null,' ',ffdx.SCHOOL_CDE) as school_cde
                            from FACCRED_FAC_DIS_XREF ffdx
                            WHERE 
                            ffdx.FAC_APPID = @FACappid
                            and ffdx.FAC_ID_NUM = @FACidnum
                            and ffdx.INSTIT_DIV_CDE = @instdiv
                            and ffdx.DIV_CDE + ffdx.INSTIT_DIV_CDE + ffdx.SCHOOL_CDE not in 
	                            (select DIV_CDE + INSTIT_DIV_CDE + SCHOOL_CDE  as codes from FACCRED_FACULTY_APPROVALS where ffdx.FAC_APPID = @FACappid and ffdx.FAC_ID_NUM = @FACidnum  )
                            )

                            insert into FACCRED_FACULTY_APPROVALS
                            (FAC_APPID, FAC_ID_NUM, DIV_CDE,  INSTIT_DIV_CDE,  SCHOOL_CDE,  LASTNAME, FIRSTNAME, FAC_TYPE, APPROVER1, APPROVER2, APPROVER3,APPROVAL_DATE, EXPIRATION_DATE, MODIFIED_DATE )
                            SELECT FAC_APPID, FAC_ID_NUM,  divcode, instit_div_cde, school_cde,  @lastname, @firstname, @FACtype, @approve,'','', @approvaldate, @expirationdate, @moddate
                            from recs;";
            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                   new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                                   new ParamStruct("instdiv", instdiv, DbType.String, ParameterDirection.Input)
                               });

                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }
        }

        public bool UpdateFacultyInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel,  string firstname, string lastname, 
                                                   string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)

        {
            string STMT = @"WITH RECS AS(
                            select
                            fac.FAC_APPID as FACappid,
                            fac.FAC_ID_NUM as FACidnum,
                            fac.LASTNAME as lastname,
                            fac.FIRSTNAME as firstname,
							fac.DIV_CDE,
							fac.INSTIT_DIV_CDE,
							fac.SCHOOL_CDE,
                            fac.APPROVER1 as approver1,
                            fac.APPROVER2 as approver2,
                            fac.APPROVER3 as approver3,
                            fac.MODIFIED_DATE as mod_date,
							fac.APPROVAL_DATE as approval_date,
							fac.EXPIRATION_DATE as expiration_date,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as rightNow
                            from FACCRED_FACULTY_APPROVALS fac";

            if (userlevel == "Approver1")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.INSTIT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 is not null
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver1 = @approve ";
            }
            else if (userlevel == "Approver2")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.INSTIT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 = 'A' 
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver2 = @approve ";
            }
            else if (userlevel == "Approver3")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.INSTIT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 = 'A' 
                                        and fac.APPROVER2 = 'A'
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver3 = @approve ";
            }

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                    new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                                    new ParamStruct("instdiv", instdiv, DbType.String, ParameterDirection.Input)
                               });


                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }
        }

        //-----------------  DIVISION  ------------------------------------------------------------------------------------


        public bool InsertFacultyDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                             string FACtype, string approvaldate, string expirationdate, string moddate, string divcde)
        {
            // note: only approver1 can insert new records.
            string STMT = @"
                            WITH RECS AS
                            (
                            select 
                            ffdx.FAC_APPID,
                            ffdx.FAC_ID_NUM,
                            iif(ffdx.DIV_CDE is null,' ',ffdx.DIV_CDE) AS divcode,
                            iif(ffdx.INSTIT_DIV_CDE is null,' ',ffdx.INSTIT_DIV_CDE) as instit_div_cde,
                            iif(ffdx.SCHOOL_CDE is null,' ',ffdx.SCHOOL_CDE) as school_cde
                            from FACCRED_FAC_DIS_XREF ffdx
                            WHERE 
                            ffdx.FAC_APPID = @FACappid
                            and ffdx.FAC_ID_NUM = @FACidnum
                            and ffdx.DIV_CDE = @divcde
                            and ffdx.DIV_CDE + ffdx.INSTIT_DIV_CDE + ffdx.SCHOOL_CDE not in 
	                            (select div_cde + instit_div_cde + school_cde  as codes from FACCRED_FACULTY_APPROVALS where ffdx.FAC_APPID = @FACappid and ffdx.FAC_ID_NUM = @FACidnum  )
                            )

                            insert into FACCRED_FACULTY_APPROVALS
                            (FAC_APPID, FAC_ID_NUM, DIV_CDE,  INSTIT_DIV_CDE,  SCHOOL_CDE, LASTNAME, FIRSTNAME, FAC_TYPE, APPROVER1, APPROVER2, APPROVER3,APPROVAL_DATE, EXPIRATION_DATE, MODIFIED_DATE )
                            SELECT FAC_APPID, FAC_ID_NUM,  divcode, instit_div_cde, school_cde, @lastname, @firstname, @FACtype, @approve,'','', @approvaldate, @expirationdate, @moddate
                            from recs;";
            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                   new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                                   new ParamStruct("divcde", divcde, DbType.String, ParameterDirection.Input)
                               });

                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }
        }

        public bool UpdateFacultyDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                   string FACtype, string approvaldate, string expirationdate, string moddate, string divcde)

        {
            string STMT = @"WITH RECS AS(
                            select
                            fac.FAC_APPID as FACappid,
                            fac.FAC_ID_NUM as FACidnum,
                            fac.LASTNAME as lastname,
                            fac.FIRSTNAME as firstname,
							fac.DIV_CDE,
							fac.INSTIT_DIV_CDE,
							fac.SCHOOL_CDE,
                            fac.APPROVER1 as approver1,
                            fac.APPROVER2 as approver2,
                            fac.APPROVER3 as approver3,
                            fac.MODIFIED_DATE as mod_date,
							fac.APPROVAL_DATE as approval_date,
							fac.EXPIRATION_DATE as expiration_date,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as rightNow
                            from FACCRED_FACULTY_APPROVALS fac";

            if (userlevel == "Approver1")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.DIV_CDE = @divcde
                                        and fac.APPROVER1 is not null
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver1 = @approve ";
            }
            else if (userlevel == "Approver2")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.DIV_CDE = @divcde
                                        and fac.APPROVER1 = 'A' 
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver2 = @approve ";
            }
            else if (userlevel == "Approver3")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.DIV_CDE = @divcde
                                        and fac.APPROVER1 = 'A' 
                                        and fac.APPROVER2 = 'A'
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver3 = @approve ";
            }

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                    new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                                    new ParamStruct("divcde", divcde, DbType.String, ParameterDirection.Input)
                               });


                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }
        }

        //----------------- SCHOOL CODE -----------------------------------------------------------------------------------


        public bool InsertFacultySchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                             string FACtype, string approvaldate, string expirationdate, string moddate, string schoolcde)
        {
            // note: only approver1 can insert new records.
            string STMT = @"
                            WITH RECS AS
                            (
                            select 
                            ffdx.FAC_APPID,
                            ffdx.FAC_ID_NUM,
                            iif(ffdx.DIV_CDE is null,' ',ffdx.DIV_CDE) AS divcode,
                            iif(ffdx.INSTIT_DIV_CDE is null,' ',ffdx.INSTIT_DIV_CDE) as instit_div_cde,
                            iif(ffdx.SCHOOL_CDE is null,' ',ffdx.SCHOOL_CDE) as school_cde
                            from FACCRED_FAC_DIS_XREF ffdx
                            WHERE 
                            ffdx.FAC_APPID = @FACappid
                            and ffdx.FAC_ID_NUM = @FACidnum
                            and ffdx.SCHOOL_CDE = @schoolcde
                            and ffdx.DIV_CDE + ffdx.INSTIT_DIV_CDE + ffdx.SCHOOL_CDE not in 
	                            (select div_cde + instit_div_cde + school_cde  as codes from FACCRED_FACULTY_APPROVALS where ffdx.FAC_APPID = @FACappid and ffdx.FAC_ID_NUM = @FACidnum  )
                            )

                            insert into FACCRED_FACULTY_APPROVALS
                            (FAC_APPID, FAC_ID_NUM, DIV_CDE,  INSTIT_DIV_CDE,  SCHOOL_CDE, LASTNAME, FIRSTNAME, FAC_TYPE, APPROVER1, APPROVER2, APPROVER3,APPROVAL_DATE, EXPIRATION_DATE, MODIFIED_DATE )
                            SELECT FAC_APPID, FAC_ID_NUM,  divcode, instit_div_cde, school_cde,  @lastname, @firstname, @FACtype, @approve,'','', @approvaldate, @expirationdate, @moddate
                            from recs;";
            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                   new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                                   new ParamStruct("schoolcde", schoolcde, DbType.String, ParameterDirection.Input)
                               });

                return true;
            }
            catch (Exception ex)
            {
                //ExceptionManager.Publish(ex);
                // because,  it might try and insert a record that is already there, but can't isolate each record with it's a group of records insert
                return true;
            }
        }

        public bool UpdateFacultySchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                   string FACtype, string approvaldate, string expirationdate, string moddate, string schoolcde)

        {
            string STMT = @"WITH RECS AS(
                            select
                            fac.FAC_APPID as FACappid,
                            fac.FAC_ID_NUM as FACidnum,
                            fac.LASTNAME as lastname,
                            fac.FIRSTNAME as firstname,
							fac.DIV_CDE,
							fac.INSTIT_DIV_CDE,
							fac.SCHOOL_CDE,
                            fac.APPROVER1 as approver1,
                            fac.APPROVER2 as approver2,
                            fac.APPROVER3 as approver3,
                            fac.MODIFIED_DATE as mod_date,
							fac.APPROVAL_DATE as approval_date,
							fac.EXPIRATION_DATE as expiration_date,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as rightNow
                            from FACCRED_FACULTY_APPROVALS fac";

            if (userlevel == "Approver1")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.SCHOOL_CDE = @schoolcde
                                        and fac.APPROVER1 is not null
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver1 = @approve ";
            }
            else if (userlevel == "Approver2")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.SCHOOL_CDE = @schoolcde
                                        and fac.APPROVER1 = 'A' 
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver2 = @approve ";
            }
            else if (userlevel == "Approver3")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.SCHOOL_CDE = @schoolcde
                                        and fac.APPROVER1 = 'A' 
                                        and fac.APPROVER2 = 'A'
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver3 = @approve ";
            }

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                    new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                                    new ParamStruct("schoolcde", schoolcde, DbType.String, ParameterDirection.Input)
                               });


                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }
        }


        //----------------- DISCIPLINE ( INST_DIV_CDE )-----------------------------------------------------------------------------------


        public bool InsertFacultyDisciplineRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                             string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            // note: only approver1 can insert new records.
            string STMT = @"
                            WITH RECS AS
                            (
                            select 
                            ffdx.FAC_APPID,
                            ffdx.FAC_ID_NUM,
                            iif(ffdx.DIV_CDE is null,' ',ffdx.DIV_CDE) AS divcode,
                            iif(ffdx.INSTIT_DIV_CDE is null,' ',ffdx.INSTIT_DIV_CDE) as instit_div_cde,
                            iif(ffdx.SCHOOL_CDE is null,' ',ffdx.SCHOOL_CDE) as school_cde
                            from FACCRED_FAC_DIS_XREF ffdx
                            WHERE 
                            ffdx.FAC_APPID = @FACappid
                            and ffdx.FAC_ID_NUM = @FACidnum
                            and ffdx.INST_DIV_CDE = @instdiv
                            and ffdx.DIV_CDE + ffdx.INSTIT_DIV_CDE + ffdx.SCHOOL_CDE  not in 
	                            (select DIV_CDE + INSTIT_DIV_CDE + SCHOOL_CDE + PROG_CATEGORY as codes from FACCRED_FACULTY_APPROVALS where ffdx.FAC_APPID = @FACappid and ffdx.FAC_ID_NUM = @FACidnum  )
                            )

                            insert into FACCRED_FACULTY_APPROVALS
                            (FAC_APPID, FAC_ID_NUM, DIV_CDE,  INSTIT_DIV_CDE,  SCHOOL_CDE, LASTNAME, FIRSTNAME, FAC_TYPE, APPROVER1, APPROVER2, APPROVER3,APPROVAL_DATE, EXPIRATION_DATE, MODIFIED_DATE )
                            SELECT FAC_APPID, FAC_ID_NUM,  divcode, instit_div_cde, school_cde,  @lastname, @firstname, @FACtype, @approve,'','', @approvaldate, @expirationdate, @moddate
                            from recs;";
            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                   new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                   new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                                   new ParamStruct("instdiv", instdiv, DbType.String, ParameterDirection.Input)
                               });

                return true;
            }
            catch (Exception ex)
            {
                //ExceptionManager.Publish(ex);
                //because some inserts fail, duplicates
                return true;
            }
        }

        public bool UpdateFacultyDisciplineRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                   string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)

        {
            string STMT = @"WITH RECS AS(
                            select
                            fac.FAC_APPID as FACappid,
                            fac.FAC_ID_NUM as FACidnum,
                            fac.LASTNAME as lastname,
                            fac.FIRSTNAME as firstname,
							fac.DIV_CDE,
							fac.INSTIT_DIV_CDE,
							fac.SCHOOL_CDE,
                            fac.APPROVER1 as approver1,
                            fac.APPROVER2 as approver2,
                            fac.APPROVER3 as approver3,
                            fac.MODIFIED_DATE as mod_date,
							fac.APPROVAL_DATE as approval_date,
							fac.EXPIRATION_DATE as expiration_date,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as rightNow
                            from FACCRED_FACULTY_APPROVALS fac";

            if (userlevel == "Approver1")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.INSTIT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 is not null
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver1 = @approve ";
            }
            else if (userlevel == "Approver2")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.INSTIT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 = 'A' 
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver2 = @approve ";
            }
            else if (userlevel == "Approver3")
            {
                STMT += @" where
                                        fac.FAC_ID_NUM = @FACidnum
                                        and fac.FAC_APPID  = @FACappid
                                        and fac.INSTIT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 = 'A' 
                                        and fac.APPROVER2 = 'A'
                                        )
                                        update recs
                                        set 
                                            approval_date = @approvaldate,
                                            expiration_date = @expirationdate,
                                            mod_date = rightNow, 
                                            approver3 = @approve ";
            }

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                    new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                                    new ParamStruct("instdiv", instdiv, DbType.String, ParameterDirection.Input)
                               });


                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }
        }

    }
}
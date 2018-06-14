using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FacCred.Models.Interfaces;
using System.Data.SqlClient;
using System.IO;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using Jenzabar.CRM.Constituent.Web.Portlets.ConstituentSearchPortlet;
using Jenzabar.ERP.EX.DAL;
using Jenzabar.Portal.Web.WebApiControllers;

namespace FacCred.Models
{
    public class CourseApprovalsModel : System.Web.UI.UserControl
    {

        public DataTable getAllCourseApprovals()
        {
            string STMT = @"select
                            FAC_APPID as FACappid,
                            FAC_ID_NUM as FACidnum,
							SM_APPID as SM_appid,
							YEARCODE as yearcode,
							TERMCODE as termcode,                            
                            DIV_CDE as divcode,
							INSTIT_DIV_CDE  as instdiv,
                            SCHOOL_CDE as schoolcde,
							CRS_CDE as crscde,
							CRS_TITLE as crstitle,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            FAC_TYPE as FACtype,                    
                            APPROVER1 as approver1,
                            APPROVER2 as approver2,
                            APPROVER3 as approver3,
                            MODIFIED_DATE as moddate
                            from FACCRED_COURSE_APPROVALS
                                order by MODIFIED_DATE DESC;";

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("SM_appid");
            DataColumn dc3 = new DataColumn("yearcode");
            DataColumn dc4 = new DataColumn("termcode");
            DataColumn dc5 = new DataColumn("divcode");
            DataColumn dc6 = new DataColumn("instdiv");
            DataColumn dc7 = new DataColumn("schoolcde");
            DataColumn dc8 = new DataColumn("crscde");
            DataColumn dc9 = new DataColumn("crstitle");
            DataColumn dc10 = new DataColumn("FAClastname");
            DataColumn dc11 = new DataColumn("FACfirstname");
            DataColumn dc12 = new DataColumn("FACtype");
            DataColumn dc13 = new DataColumn("approver1");
            DataColumn dc14 = new DataColumn("approver2");
            DataColumn dc15 = new DataColumn("approver3");
            DataColumn dc16 = new DataColumn("moddate");

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc9);
            dt.Columns.Add(dc10);
            dt.Columns.Add(dc11);
            dt.Columns.Add(dc12);
            dt.Columns.Add(dc13);
            dt.Columns.Add(dc14);
            dt.Columns.Add(dc15);
            dt.Columns.Add(dc16);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("FACidnum", "1", DbType.String, ParameterDirection.Input)
                    });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["SM_appid"] = dr["SM_appid"].ToString();
                        mydr["yearcode"] = dr["yearcode"].ToString();
                        mydr["termcode"] = dr["termcode"].ToString();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcde"] = dr["schoolcde"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString();
                        mydr["crstitle"] = dr["crstitle"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver1"] = dr["approver1"].ToString().Trim();
                        mydr["approver2"] = dr["approver2"].ToString().Trim();
                        mydr["approver3"] = dr["approver3"].ToString().Trim();
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

        public DataTable getAllCourseApprovalsLIU(string userID, string firstName, string lastName)
        {
            string STMT = @"select distinct
                            fca.FAC_APPID as FACappid ,
                            fca.FAC_ID_NUM as FACidnum ,
                            fca.SM_APPID as SM_appid,
                            fca.YEARCODE as yearcode ,
                            fca.TERMCODE as termcode ,
                            fca.DIV_CDE as divcode ,
                            fca.INSTIT_DIV_CDE as instdiv ,
                            fca.SCHOOL_CDE as schoolcode ,
                            fca.CRS_CDE as crscde ,
                            fca.CRS_TITLE as crstitle ,
                            fca.LASTNAME as FAClastname ,
                            fca.FIRSTNAME as FACfirstname ,
                            fca.FAC_TYPE as FACtype ,
                            fca.APPROVER1 as approver1,
                            fca.APPROVER2 as approver2, 
                            fca.APPROVER3 as approver3,
                            fca.MODIFIED_DATE as moddate
                            from FACCRED_COURSE_APPROVALS fca
                            where  
                                fca.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )						   
                            order by fca.FAC_ID_NUM;";

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("SM_appid");
            DataColumn dc3 = new DataColumn("yearcode");
            DataColumn dc4 = new DataColumn("termcode");
            DataColumn dc5 = new DataColumn("divcode");
            DataColumn dc6 = new DataColumn("instdiv");
            DataColumn dc7 = new DataColumn("schoolcode");
            DataColumn dc8 = new DataColumn("crscde");
            DataColumn dc9 = new DataColumn("crstitle");
            DataColumn dc10 = new DataColumn("FAClastname");
            DataColumn dc11 = new DataColumn("FACfirstname");
            DataColumn dc12 = new DataColumn("FACtype");
            DataColumn dc13 = new DataColumn("approver1");
            DataColumn dc14 = new DataColumn("approver2");
            DataColumn dc15 = new DataColumn("approver3");
            DataColumn dc16 = new DataColumn("moddate");

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
            dt.Columns.Add(dc15);
            dt.Columns.Add(dc16);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
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
                        mydr["SM_appid"] = dr["SM_appid"].ToString();
                        mydr["yearcode"] = dr["yearcode"].ToString();
                        mydr["termcode"] = dr["termcode"].ToString();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString();
                        mydr["crstitle"] = dr["crstitle"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver1"] = dr["approver1"].ToString().Trim();
                        mydr["approver2"] = dr["approver2"].ToString().Trim();
                        mydr["approver3"] = dr["approver3"].ToString().Trim();
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


        public bool InsertUpdateCourseApproval(string approvalCode,
            string FACappid,
            string FACidnum,
            string SM_appid,
            string yearcode,
            string termcode,
            string div_cde,
            string instit_div_cde,
            string school_cde,
            string crs_cde,
            string crs_title,
            string lastname,
            string firstname,
            string FACinstructorType,
            string userlevel,
            string moddate)
        {
            string STMT = String.Empty;

            if (yearcode.Length < 4 || termcode.Length < 1)
            {
                return false;
            }

            if (userlevel == "Approver1")
            {
                STMT =
                    @" IF (SELECT count(*) from FACCRED_COURSE_APPROVALS  where FAC_APPID=@FACappid AND FAC_ID_NUM=@FACidnum AND SM_appid=@SM_appid AND YEARCODE=@yearcode AND TERMCODE=@termcode) = 0
                               INSERT INTO FACCRED_COURSE_APPROVALS 
                                    VALUES(@FACappid, @FACidnum, @SM_appid, @yearcode, @termcode, @div_cde, @instit_div_cde, @school_cde,   @crs_cde, @crs_title, @lastname,  @firstname, @FACinstructorType, @approvalCode, '', '', @moddate)
                               ELSE UPDATE FACCRED_COURSE_APPROVALS 
                                    SET Approver1 = @approvalCode , MODIFIED_DATE = @moddate WHERE FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND SM_appid = @SM_appid AND YEARCODE = @yearcode AND TERMCODE = @termcode;";
            }
            else if (userlevel == "Approver2")
            {
                STMT =
                    @"UPDATE FACCRED_COURSE_APPROVALS SET Approver2 = @approvalCode , MODIFIED_DATE = @moddate WHERE FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND SM_appid = @SM_appid AND YEARCODE = @yearcode AND TERMCODE = @termcode;";
            }
            else if (userlevel == "Approver3")
            {
                STMT =
                    @"UPDATE FACCRED_COURSE_APPROVALS SET Approver3 = @approvalCode , MODIFIED_DATE = @moddate WHERE FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND SM_appid = @SM_appid AND YEARCODE = @yearcode AND TERMCODE = @termcode;";
            }


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("approvalCode", approvalCode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("SM_appid", SM_appid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("div_cde", div_cde, DbType.String, ParameterDirection.Input),
                        new ParamStruct("instit_div_cde", instit_div_cde, DbType.String, ParameterDirection.Input),
                        new ParamStruct("school_cde", school_cde, DbType.String, ParameterDirection.Input),
                        new ParamStruct("crs_cde", crs_cde, DbType.String, ParameterDirection.Input),
                        new ParamStruct("crs_title", crs_title, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACinstructorType", FACinstructorType, DbType.String,ParameterDirection.Input),
                        new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                        new ParamStruct("moddate", moddate, DbType.String, ParameterDirection.Input)

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


        public DataTable getApprover1CoursesSM(string yearcode, string termcode, string userID, string firstName, string lastName)
        {
            string STMT = @"select distinct
                            fm.APPID as FACappid,
                            fm.ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,
                            sm.YR_CDE as yearcode,
                            sm.TRM_CDE as termcode,
                            itv.DESCRIPTION as FACtype,                      
                            sm.INSTITUT_DIV_CDE as instdiv,
                            sm.DIVISION_CDE as divcode,
                            sm.SCHOOL_CDE as schoolcode							
                            from FACULTY_MASTER fm
                            join name_master nm on nm.ID_NUM = fm.ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on  SM.LEAD_INSTRUCTR_ID = fm.ID_NUM --sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE                       				 
                            where  
                                sm.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                            and fm.ACTIVE = 'Y'
                            and sm.YR_CDE = @yearcode 
                            and sm.TRM_CDE = @termcode
                            order by fm.ID_NUM;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("yearcode");
            DataColumn dc5 = new DataColumn("termcode");
            DataColumn dc6 = new DataColumn("FACtype");
            DataColumn dc7 = new DataColumn("divcode");
            DataColumn dc8 = new DataColumn("instdiv");
            DataColumn dc9 = new DataColumn("schoolcode");



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
                    new ParamStruct[]
                    {
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
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
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();


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



        public DataTable getApprover1Courses(string yearcode, string termcode, string userID, string firstName, string lastName)
        {
            string STMT = @"select DISTINCT
                            fm.APPID as FACappid,
                            fm.ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,
							sm.CRS_CDE as crscde,
                            sm.CRS_TITLE as CRStitle,
                            sm.APPID as SM_appid,
                            sm.YR_CDE as yearcode,
                            sm.TRM_CDE as termcode,
                            itv.DESCRIPTION as FACtype, 
                            iif(fac.APPROVER1 is null,' ',fac.APPROVER1) as approver,
                            iif(sm.DIVISION_CDE is null, ' ', sm.DIVISION_CDE) as divcode,
                            iif(sm.INSTITUT_DIV_CDE is null, ' ', sm.INSTITUT_DIV_CDE) as instdiv,
                            iif(sm.SCHOOL_CDE is null,' ',sm.SCHOOL_CDE) as schoolcode
                            from FACULTY_MASTER fm 
                            join name_master nm on nm.ID_NUM = fm.ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on sm.LEAD_INSTRUCTR_ID = fm.ID_NUM -- sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE	
                            left outer  join FACCRED_COURSE_APPROVALS fac on fac.FAC_APPID = fm.APPID and fac.FAC_ID_NUM = fm.ID_NUM and fac.SM_APPID = sm.APPID  and fac.TERMCODE = sm.TRM_CDE and fac.YEARCODE = sm.YR_CDE 		
                            where  
                                sm.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                            and fm.ACTIVE = 'Y'
                            and sm.YR_CDE = @yearcode 
                            and sm.TRM_CDE = @termcode
                            order by fm.ID_NUM";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("yearcode");
            DataColumn dc6 = new DataColumn("termcode");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("divcode");
            DataColumn dc10 = new DataColumn("instdiv");
            DataColumn dc11 = new DataColumn("schoolcode");
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
                    new ParamStruct[]
                    {
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
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
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();
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





        //APPROVER 2 -------------------------------------------------------------------------------------



        public DataTable getApprover2CoursesSM(string userID, string firstName, string lastName)
        {
            string STMT = @"SELECT DISTINCT
                            fca.FAC_APPID as FACappid,
                            fca.FAC_ID_NUM as FACidnum,
                            fca.LASTNAME as FAClastname,
                            fca.FIRSTNAME as FACfirstname,
                            fca.YEARCODE as yearcode,
                            fca.TERMCODE as termcode,
                            fca.FAC_TYPE as FACtype,
                            fca.DIV_CDE as divcode,
                            fca.INSTIT_DIV_CDE as instdiv,
                            fca.SCHOOL_CDE as schoolcode
                            FROM FACCRED_COURSE_APPROVALS fca
                            where  
                                fca.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                            AND APPROVER1 = 'A' ";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("yearcode");
            DataColumn dc5 = new DataColumn("termcode");
            DataColumn dc6 = new DataColumn("FACtype");
            DataColumn dc7 = new DataColumn("divcode");
            DataColumn dc8 = new DataColumn("instdiv");
            DataColumn dc9 = new DataColumn("schoolcode");



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
                    new ParamStruct[]
                    {
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
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();


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



        public DataTable getApprover2Courses(string userID, string firstName, string lastName)
        {
            string STMT = @"select distinct
                            fca.FAC_APPID as FACappid ,
                            fca.FAC_ID_NUM as FACidnum ,
                            fca.SM_APPID as SM_appid,
                            fca.YEARCODE as yearcode ,
                            fca.TERMCODE as termcode ,
                            fca.DIV_CDE as divcode ,
                            fca.INSTIT_DIV_CDE as instdiv ,
                            fca.SCHOOL_CDE as schoolcode ,
                            fca.CRS_CDE as crscde ,
                            fca.CRS_TITLE as CRStitle ,
                            fca.LASTNAME as FAClastname ,
                            fca.FIRSTNAME as FACfirstname ,
                            fca.FAC_TYPE as FACtype ,
                            fca.APPROVER2 as approver
                            from FACCRED_COURSE_APPROVALS fca
                            where  
                                fca.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )					   
                            and fca.APPROVER1 = 'A'
                            order by fca.FAC_ID_NUM";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("yearcode");
            DataColumn dc6 = new DataColumn("termcode");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("divcode");
            DataColumn dc10 = new DataColumn("instdiv");
            DataColumn dc11 = new DataColumn("schoolcode");
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
                    new ParamStruct[]
                    {
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
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();
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


        //APPROVER 3 -------------------------------------------------------------------------------------


     

        public DataTable getApprover3CoursesSM(string userID, string firstName, string lastName)
        {
            string STMT = @"SELECT DISTINCT
                            fca.FAC_APPID as FACappid,
                            fca.FAC_ID_NUM as FACidnum,
                            fca.LASTNAME as FAClastname,
                            fca.FIRSTNAME as FACfirstname,
                            fca.YEARCODE as yearcode,
                            fca.TERMCODE as termcode,
                            fca.FAC_TYPE as FACtype,
                            fca.DIV_CDE as divcode,
                            fca.INSTIT_DIV_CDE as instdiv,
                            fca.SCHOOL_CDE as schoolcode
                            FROM FACCRED_COURSE_APPROVALS fca
                            where  
                                fca.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )
                              and fca.APPROVER1 = 'A'
                              and fca.APPROVER2 = 'A'
                            order by fca.FAC_ID_NUM ;";

            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("yearcode");
            DataColumn dc5 = new DataColumn("termcode");
            DataColumn dc6 = new DataColumn("FACtype");
            DataColumn dc7 = new DataColumn("divcode");
            DataColumn dc8 = new DataColumn("instdiv");
            DataColumn dc9 = new DataColumn("schoolcode");


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
                    new ParamStruct[]
                    {
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
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();


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



        public DataTable getApprover3Courses(string userID, string firstName, string lastName)
        {
            string STMT = @"select distinct
                            fca.FAC_APPID as FACappid ,
                            fca.FAC_ID_NUM as FACidnum ,
                            fca.SM_APPID as SM_appid,
                            fca.YEARCODE as yearcode ,
                            fca.TERMCODE as termcode ,
                            fca.DIV_CDE as divcode ,
                            fca.INSTIT_DIV_CDE as instdiv ,
                            fca.SCHOOL_CDE as schoolcode ,
                            fca.CRS_CDE as crscde ,
                            fca.CRS_TITLE as crstitle ,
                            fca.LASTNAME as FAClastname ,
                            fca.FIRSTNAME as FACfirstname ,
                            fca.FAC_TYPE as FACtype ,
                            fca.APPROVER3 as approver
                            from FACCRED_COURSE_APPROVALS fca
                            where  
                                fca.SCHOOL_CDE in (select SCHOOL_CDE from FACCRED_USER_ACCESS_XREF WHERE FIRST_NAME = @firstName AND LAST_NAME = @lastName AND USER_ID = @userID )					   
                            and fca.APPROVER1 = 'A'
                            and fca.APPROVER2 = 'A'
                            order by fca.FAC_ID_NUM";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("yearcode");
            DataColumn dc6 = new DataColumn("termcode");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver");
            DataColumn dc9 = new DataColumn("divcode");
            DataColumn dc10 = new DataColumn("instdiv");
            DataColumn dc11 = new DataColumn("schoolcode");
            DataColumn dc12 = new DataColumn("crstitle");
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
                    new ParamStruct[]
                    {
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
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();
                        mydr["crstitle"] = dr["crstitle"].ToString().Trim();
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


  

        //-----------------  DIVISION  ------------------------------------------------------------------------------------


        public bool InsertCourseDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel,string yearcode, string termcode, string firstname, string lastname, string moddate, string divcode)
        {
            // note: only approver1 can insert new records.
            string STMT = @"
                            WITH RECS AS
                            (
                                select 
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
                                iif(sm.DIVISION_CDE is null,'',sm.DIVISION_CDE) as divcde,
                                iif(sm.INSTITUT_DIV_CDE is null, '', sm.INSTITUT_DIV_CDE) as instdiv,
                                iif(sm.SCHOOL_CDE is null,'',sm.SCHOOL_CDE) as schoolcde
                                from FACULTY_LOAD_TABLE  flt
                                join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                                join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                                left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                                join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE	
                                left outer  join FACCRED_COURSE_APPROVALS fac on fac.FAC_APPID = fm.APPID and fac.FAC_ID_NUM = fm.ID_NUM 
								                                                and fac.SM_APPID = sm.APPID  and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 		
							    where  sm.APPID  not in ( select  SM_APPID  FROM FACCRED_COURSE_APPROVALS)
                                    and fm.APPID = @FACappid
                                    and fm.ID_NUM = @FACidnum
                                    and flt.YR_CDE = @yearcode
                                    and flt.TRM_CDE = @termcode
                                    and sm.DIVISION_CDE = @divcode
                                    and LEN(sm.INSTITUT_DIV_CDE) > 1
                            )

                            insert into FACCRED_COURSE_APPROVALS
                                  (FAC_APPID, FAC_ID_NUM, SM_APPID, YEARCODE, TERMCODE, DIV_CDE,  INSTIT_DIV_CDE,  SCHOOL_CDE,  CRS_CDE, CRS_TITLE, LASTNAME, FIRSTNAME, FAC_TYPE, APPROVER1, APPROVER2, APPROVER3, MODIFIED_DATE )
                            SELECT FACappid, FACidnum, SM_appid, yrcde, trmcde,  divcde, instdiv, schoolcde,  crscde, CRStitle, FAClastname, FACfirstname, FACtype, @approve,'','', @moddate
                                from recs";
            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                        new ParamStruct("divcode", divcode, DbType.String, ParameterDirection.Input)
                    });

                return true;
            }
            catch (Exception ex)
            {
                //ExceptionManager.Publish(ex);
                //false messages
                return true;
            }
        }

        public bool UpdateCourseDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode,
                                             string firstname, string lastname, string moddate, string divcode)

        {
            string STMT = @"WITH RECS AS(
                            select
                            FAC_APPID,
                            FAC_ID_NUM,
							SM_APPID,
							YEARCODE,
							TERMCODE,
							DIV_CDE,
							INSTIT_DIV_CDE,
							SCHOOL_CDE,
                            CRS_CDE,
							CRS_TITLE,
                            LASTNAME as lastname,
                            FIRSTNAME as firstname,
							FAC_TYPE,
                            APPROVER1 as approver1,
                            APPROVER2 as approver2,
                            APPROVER3 as approver3,
                            MODIFIED_DATE as mod_date,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as rightNow
                            from FACCRED_COURSE_APPROVALS";

            if (userlevel == "Approver1")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and DIV_CDE = @divcode
                                        and APPROVER1 is not null
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver1 = @approve ";
            }
            else if (userlevel == "Approver2")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and DIV_CDE = @divcode
                                        and APPROVER1 = 'A' 
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver2 = @approve ";
            }
            else if (userlevel == "Approver3")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and DIV_CDE = @divcode
                                        and APPROVER1 = 'A' 
                                        and APPROVER2 = 'A'
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver3 = @approve ";
            }

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                        new ParamStruct("divcode", divcode, DbType.String, ParameterDirection.Input)
                    });


                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }
        }




        //--------------- INST DIV  ---------------------------------------------------------------------

        public bool InsertCourseInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname, string moddate, string instdiv)
        {
            // note: only approver1 can insert new records.
            string STMT = @"
                            WITH RECS AS
                            (
                                select 
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
                                iif(sm.DIVISION_CDE is null,'',sm.DIVISION_CDE) as divcde,
                                iif(sm.INSTITUT_DIV_CDE is null, '', sm.INSTITUT_DIV_CDE) as instdiv,
                                iif(sm.SCHOOL_CDE is null,'',sm.SCHOOL_CDE) as schoolcde
                                from FACULTY_LOAD_TABLE  flt
                                join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                                join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                                left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                                join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE	
                                left outer  join FACCRED_COURSE_APPROVALS fac on fac.FAC_APPID = fm.APPID and fac.FAC_ID_NUM = fm.ID_NUM 
								                                                and fac.SM_APPID = sm.APPID  and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 		
							    where  sm.APPID  not in ( select  SM_APPID  FROM FACCRED_COURSE_APPROVALS)
                                    and fm.APPID = @FACappid
                                    and fm.ID_NUM = @FACidnum
                                    and flt.YR_CDE = @yearcode
                                    and flt.TRM_CDE = @termcode
                                    and sm.INSTITUT_DIV_CDE = @instdiv
                            )

                            insert into FACCRED_COURSE_APPROVALS
                                  (FAC_APPID, FAC_ID_NUM, SM_APPID, YEARCODE, TERMCODE, DIV_CDE,  INSTIT_DIV_CDE,  SCHOOL_CDE,  CRS_CDE, CRS_TITLE, LASTNAME, FIRSTNAME, FAC_TYPE, APPROVER1, APPROVER2, APPROVER3, MODIFIED_DATE )
                            SELECT FACappid, FACidnum, SM_appid, yrcde, trmcde,  divcde, instdiv, schoolcde,  crscde, CRStitle, FAClastname, FACfirstname, FACtype, @approve,'','', @moddate
                                from recs";
            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                        new ParamStruct("instdiv", instdiv, DbType.String, ParameterDirection.Input)
                    });

                return true;
            }
            catch (Exception ex)
            {
                //ExceptionManager.Publish(ex);
                // false insert messages
                return true;
            }
        }

        public bool UpdateCourseInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode,
                                                    string firstname, string lastname, string moddate, string instdiv)

        {
            string STMT = @"WITH RECS AS(
                            select
                            FAC_APPID,
                            FAC_ID_NUM,
							SM_APPID,
							YEARCODE,
							TERMCODE,
							DIV_CDE,
							INSTIT_DIV_CDE,
							SCHOOL_CDE,
                            CRS_CDE,
							CRS_TITLE,
                            LASTNAME as lastname,
                            FIRSTNAME as firstname,
							FAC_TYPE,
                            APPROVER1 as approver1,
                            APPROVER2 as approver2,
                            APPROVER3 as approver3,
                            MODIFIED_DATE as mod_date,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as rightNow
                            from FACCRED_COURSE_APPROVALS";

            if (userlevel == "Approver1")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and INSTIT_DIV_CDE = @instdiv
                                        and APPROVER1 is not null
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver1 = @approve ";
            }
            else if (userlevel == "Approver2")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and INSTIT_DIV_CDE = @instdiv
                                        and APPROVER1 = 'A' 
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver2 = @approve ";
            }
            else if (userlevel == "Approver3")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and INSTIT_DIV_CDE = @instdiv
                                        and APPROVER1 = 'A' 
                                        and APPROVER2 = 'A'
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver3 = @approve ";
            }

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
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





        //----------------- SCHOOL CODE -----------------------------------------------------------------------------------


        public bool InsertCourseSchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname, string moddate, string schoolcode)
        {
            // note: only approver1 can insert new records.
            string STMT = @"
                            WITH RECS AS
                            (
                                select 
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
                                iif(sm.DIVISION_CDE is null,'',sm.DIVISION_CDE) as divcde,
                                iif(sm.INSTITUT_DIV_CDE is null, '', sm.INSTITUT_DIV_CDE) as instdiv,
                                iif(sm.SCHOOL_CDE is null,'',sm.SCHOOL_CDE) as schoolcde
                                from FACULTY_LOAD_TABLE  flt
                                join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                                join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                                left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                                join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE	
                                left outer  join FACCRED_COURSE_APPROVALS fac on fac.FAC_APPID = fm.APPID and fac.FAC_ID_NUM = fm.ID_NUM 
								                                                and fac.SM_APPID = sm.APPID  and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 		
							    where  sm.APPID  not in ( select  SM_APPID  FROM FACCRED_COURSE_APPROVALS)
                                    and fm.APPID = @FACappid
                                    and fm.ID_NUM = @FACidnum
                                    and flt.YR_CDE = @yearcode
                                    and flt.TRM_CDE = @termcode
                                    and sm.SCHOOL_CDE = @schoolcode
                                    and LEN(sm.INSTITUT_DIV_CDE) > 1
                            )

                            insert into FACCRED_COURSE_APPROVALS
                                  (FAC_APPID, FAC_ID_NUM, SM_APPID, YEARCODE, TERMCODE, DIV_CDE,  INSTIT_DIV_CDE,  SCHOOL_CDE, CRS_CDE, CRS_TITLE, LASTNAME, FIRSTNAME, FAC_TYPE, APPROVER1, APPROVER2, APPROVER3, MODIFIED_DATE )
                            SELECT FACappid, FACidnum, SM_appid, yrcde, trmcde,  divcde, instdiv, schoolcde,  crscde, CRStitle, FAClastname, FACfirstname, FACtype, @approve,'','', @moddate
                                from recs";
            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
                        new ParamStruct("schoolcode", schoolcode, DbType.String, ParameterDirection.Input)
                    });

                return true;
            }
            catch (Exception ex)
            {
                //ExceptionManager.Publish(ex);
                //false messages
                return true;
            }
        }

        public bool UpdateCourseSchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode,
                                             string firstname, string lastname, string moddate, string schoolcode)

        {
            string STMT = @"WITH RECS AS(
                            select
                            FAC_APPID,
                            FAC_ID_NUM,
							SM_APPID,
							YEARCODE,
							TERMCODE,
							DIV_CDE,
							INSTIT_DIV_CDE,
							SCHOOL_CDE,
                            CRS_CDE,
							CRS_TITLE,
                            LASTNAME as lastname,
                            FIRSTNAME as firstname,
							FAC_TYPE,
                            APPROVER1 as approver1,
                            APPROVER2 as approver2,
                            APPROVER3 as approver3,
                            MODIFIED_DATE as mod_date,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as rightNow
                            from FACCRED_COURSE_APPROVALS";

            if (userlevel == "Approver1")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and SCHOOL_CDE = @schoolcode
                                        and APPROVER1 is not null
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver1 = @approve ";
            }
            else if (userlevel == "Approver2")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and SCHOOL_CDE = @schoolcode
                                        and APPROVER1 = 'A' 
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver2 = @approve ";
            }
            else if (userlevel == "Approver3")
            {
                STMT += @" where
                                        FAC_ID_NUM = @FACidnum
                                        and FAC_APPID  = @FACappid
                                        and SCHOOL_CDE = @schoolcode
                                        and APPROVER1 = 'A' 
                                        and APPROVER2 = 'A'
                                        )
                                        update recs
                                        set 
                                            mod_date = rightNow, 
                                            approver3 = @approve ";
            }

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("approve", approve, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACappid", FACappid, DbType.String, ParameterDirection.Input),
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                        new ParamStruct("moddate", moddate, DbType.DateTime, ParameterDirection.Input),
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



    

    }
}
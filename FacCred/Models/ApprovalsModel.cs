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
    public class ApprovalsModel : System.Web.UI.UserControl
    {       
        
        string facultyIdnum = String.Empty;
        string facultyFirstName = String.Empty;
        string facultyLastName = String.Empty;
        string courseAppid = String.Empty;
        string courseDesc = String.Empty;
        string courseYear = String.Empty;
        string courseTerm = String.Empty;
        string approverLevel = String.Empty;

        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["ICSConnectionString"].ConnectionString;


        public string approverLevelSQL(string firstName, string lastName)
        {
            string rtn = String.Empty;

            using (SqlConnection connection = new SqlConnection(conn))
            {

                // to get the highest level of security, use this:                 
                string query =
                @"select top 1  sg.displayname 
                from fwk_user usr 
                Join fwk_GroupMembership gm on gm.MemberPrincipalID = usr.id  
                join fwk_securitygroup sg on sg.id = gm.parentprincipalID 
                where FirstName = @firstName and LastName = @lastName and (sg.DisplayName like 'Approver%' or sg.DisplayName = 'FacCredUser'  or sg.DisplayName = 'FacCredAdmin' ) 
                order by sg.DisplayName desc ";


                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.Add("@rtn", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    rtn = command.ExecuteScalar().ToString();

                return rtn;
                }
                catch (Exception ex)
                {
                    ExceptionManager.Publish(ex);
                    return "error: " + ex.Data.ToString();
                }
                finally
                {
                    connection.Close();
                }
            }
        }





        public DataTable getAllFacultyApprovals()
        {
            string STMT = @"select
                            FAC_APPID as FACappid,
                            FAC_ID_NUM as FACidnum,
                            SM_APPID as SM_appid,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            COURSE as crscde,
                            YEARCODE as yrcde,
                            TERMCODE as trmcde,  
                            INST_TYPE as FACtype,                          
                            APPROVER1 as approver1,
                            APPROVER2 as approver2,
                            APPROVER3 as approver3,
                            MODIFIED_DATE as moddate,
                            INSTITUT_DIV  as instdiv
                            from FACCRED_FACULTY_APPROVALS
                                order by MODIFIED_DATE DESC;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("yrcde");
            DataColumn dc6 = new DataColumn("trmcde");
            DataColumn dc7 = new DataColumn("FACtype");
            DataColumn dc8 = new DataColumn("approver1");
            DataColumn dc9 = new DataColumn("approver2");
            DataColumn dc10 = new DataColumn("approver3");
            DataColumn dc11 = new DataColumn("moddate");
            DataColumn dc12 = new DataColumn("instdiv");
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
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim(); 
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();                      
                        mydr["approver1"] = dr["approver1"].ToString().Trim();
                        mydr["approver2"] = dr["approver2"].ToString().Trim();
                        mydr["approver3"] = dr["approver3"].ToString().Trim();
                        mydr["moddate"] = dr["moddate"].ToString().Trim();
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




        public DataTable getAllCourseApprovals()
        {
            string STMT = @"select
                            FAC_APPID as FACappid,
                            FAC_ID_NUM as FACidnum,
                            SM_APPID as SM_appid,
                            LASTNAME as FAClastname,
                            FIRSTNAME as FACfirstname,
                            CRS_CDE as crscde,
							CRS_TITLE as crstitle,
                            YEARCODE as yrcde,
                            TERMCODE as trmcde,  
							DIV_CDE AS divcode,
							INSTIT_DIV_CDE as instdiv,
							SCHOOL_CDE as schoolcode,
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
            DataColumn dc3 = new DataColumn("FAClastname");
            DataColumn dc4 = new DataColumn("FACfirstname");
            DataColumn dc5 = new DataColumn("crscde");
            DataColumn dc6 = new DataColumn("crstitle");
            DataColumn dc7 = new DataColumn("yrcde");
            DataColumn dc8 = new DataColumn("trmcde");
            DataColumn dc9 = new DataColumn("divcode");
            DataColumn dc10 = new DataColumn("instdiv");
            DataColumn dc11 = new DataColumn("schoolcode");
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
                        mydr["SM_appid"] = dr["SM_appid"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString().Trim();
                        mydr["crstitle"] = dr["crstitle"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["schoolcode"] = dr["schoolcode"].ToString().Trim();
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





        public DataTable getFacCredUserFacultyDiscipline()
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
                left outer join FACCRED_APPROVALS  fac on fac.FAC_APPID = flt.APPID and fac.FAC_ID_NUM = flt.INSTRCTR_ID_NUM and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 				 
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

        public DataTable getFacCredUserRecords()
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
                left outer join FACCRED_APPROVALS  fac on fac.APPID = flt.APPID and fac.ID_NUM = flt.INSTRCTR_ID_NUM and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 				 
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

        public DataTable getApprover1FacultyDisciplineSM()
        {
            string STMT = @"select distinct
                            fm.appid as FACappid,
                            flt.INSTRCTR_ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,
                            flt.YR_CDE as yrcde,
                            flt.TRM_CDE as trmcde,
                            itv.DESCRIPTION as FACtype, 
                            fac.APPROVER1 as approver,                      
                            sm.INSTITUT_DIV_CDE as instdiv,                   
                            sm.APPID AS SM_appid
                            from FACULTY_LOAD_TABLE  flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                            left outer join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE		
                            left outer join FACCRED_APPROVALS  fac on fac.FAC_ID_NUM = flt.INSTRCTR_ID_NUM and fac.FAC_APPID = nm.APPID  and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 				 
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
            DataColumn dc9 = new DataColumn("SM_appid");

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
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
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

        public DataTable getApprover1FacultyDiscipline()
        {
            string STMT = @"select distinct
                            fm.appid as FACappid,
                            flt.INSTRCTR_ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,
                            flt.YR_CDE as yrcde,
                            flt.TRM_CDE as trmcde,
                            itv.DESCRIPTION as FACtype, 
                            fac.APPROVER1 as approver,                      
                            sm.INSTITUT_DIV_CDE as instdiv
                            from FACULTY_LOAD_TABLE  flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                            left outer join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE		
                            left outer join FACCRED_APPROVALS  fac on fac.FAC_ID_NUM = flt.INSTRCTR_ID_NUM and fac.FAC_APPID = nm.APPID  and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 				 
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

        public DataTable getApprover1Records()
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
                            sm.INSTITUT_DIV_CDE as instdiv,
                            sm.SCHOOL_CDE as FACschoolcode
                            from FACULTY_LOAD_TABLE  flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE	
                            left outer  join FACCRED_APPROVALS fac on fac.FAC_APPID = fm.APPID and fac.FAC_ID_NUM = fm.ID_NUM and fac.SM_APPID = sm.APPID  and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE 				 
                            order by fm.ID_NUM";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("FAClastname");
            DataColumn dc3 = new DataColumn("FACfirstname");
            DataColumn dc4 = new DataColumn("crscde");
            DataColumn dc5 = new DataColumn("CRStitle");
            DataColumn dc6 = new DataColumn("SM_appid");
            DataColumn dc7 = new DataColumn("yrcde");
            DataColumn dc8 = new DataColumn("trmcde");
            DataColumn dc9 = new DataColumn("FACtype");
            DataColumn dc10 = new DataColumn("approver");
            DataColumn dc11 = new DataColumn("FACdivcode");
            DataColumn dc12 = new DataColumn("instdiv");
            DataColumn dc13 = new DataColumn("FACschoolcode");

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
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["crscde"] = dr["crscde"].ToString().Trim();
                        mydr["CRStitle"] = dr["CRStitle"].ToString().Trim();
                        mydr["SM_appid"] = dr["SM_appid"].ToString().Trim();
                        mydr["yrcde"] = dr["yrcde"].ToString().Trim();
                        mydr["trmcde"] = dr["trmcde"].ToString().Trim();
                        mydr["FACtype"] = dr["FACtype"].ToString().Trim();
                        mydr["approver"] = dr["approver"].ToString().Trim(); 
                        mydr["FACdivcode"] = dr["FACdivcode"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["FACschoolcode"] = dr["FACschoolcode"].ToString().Trim();
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


        public DataTable getApprover2FacultyDiscipline()
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
                             from FACCRED_APPROVALS 
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




        public DataTable getApprover2Records()
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
                             from FACCRED_APPROVALS 
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



        public DataTable getApprover3FacultyDiscipline()
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
                             from FACCRED_APPROVALS 
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


        public DataTable getApprover3Records()
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
                             from FACCRED_APPROVALS 
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


        public bool InsertUpdateApproval(string approve, string FACappid, string FACidnum, string SM_appid, string yearcode, string termcode, string userlevel, string crsdesc, string firstname, string lastname, string FACtype, string moddate, string instdiv)
        {
            string STMT = String.Empty;

            if (userlevel == "Approver1")
            {
                STMT = @" IF (SELECT count(*) from FACCRED_APPROVALS  where FAC_APPID=@FACappid AND FAC_ID_NUM=@FACidnum AND SM_appid=@SM_appid AND YEARCODE=@yearcode AND TERMCODE=@termcode) = 0
                               INSERT INTO FACCRED_APPROVALS VALUES(@FACappid, @FACidnum, @SM_appid, @yearcode, @termcode,  @instdiv,  @crsdesc, @lastname,  @firstname, @FACtype, @approve, '', '', @moddate)
                          ELSE UPDATE FACCRED_APPROVALS SET Approver1 = @approve , MODIFIED_DATE = @moddate WHERE FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND SM_appid = @SM_appid AND YEARCODE = @yearcode AND TERMCODE = @termcode;";
            }
            else if (userlevel == "Approver2")
            {
                STMT = @"UPDATE FACCRED_APPROVALS SET Approver2 = @approve , MODIFIED_DATE = @moddate WHERE FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND SM_appid = @SM_appid AND YEARCODE = @yearcode AND TERMCODE = @termcode;";
            }
            else if (userlevel == "Approver3")
            {
                STMT = @"UPDATE FACCRED_APPROVALS SET Approver3 = @approve , MODIFIED_DATE = @moddate WHERE FAC_APPID = @FACappid AND FAC_ID_NUM = @FACidnum AND SM_appid = @SM_appid AND YEARCODE = @yearcode AND TERMCODE = @termcode;";
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
                                    new ParamStruct("SM_appid", SM_appid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("crsdesc", crsdesc, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),                              
                                    new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("moddate", moddate, DbType.String, ParameterDirection.Input),
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


        public bool InsertDisciplineRecords(string approve, string FACappid, string FACidnum, string yearcode, string termcode, string SM_appid, string userlevel, string crsdesc, string firstname, string lastname, string FACtype, string moddate, string instdiv)
        {

            string STMT = @"
                            WITH RECS AS
                            (
                            select
                            fm.APPID as FACappid,
                            fm.ID_NUM as FACidnum,
                            nm.LAST_NAME as FAClastname,
                            nm.FIRST_NAME as FACfirstname,
                            flt.CRS_CDE as crscde,
                            flt.YR_CDE as yrcde,
                            flt.TRM_CDE as trmcde,
                            itv.DESCRIPTION as FACtype,
                            fac.APPROVER1 as approver,
                            sm.INSTITUT_DIV_CDE as instdiv,
                            sm.APPID as SM_appid,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as moddate
                            from FACULTY_LOAD_TABLE flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                            left outer join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE
                            left outer join FACCRED_APPROVALS  fac on fac.FAC_APPID = fm.APPID and fac.FAC_ID_NUM = fm.ID_NUM and fac.SM_APPID = sm.APPID   and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE
                            where
                            fm.ACTIVE = 'Y'
                            and flt.YR_CDE = @yearcode
                            and flt.TRM_CDE = @termcode
                            and flt.INSTRCTR_ID_NUM = @idnum
                            and SM.INSTITUT_DIV_CDE = @instdiv
                            and fac.Approver1 is null
                            )

                            insert into FACCRED_APPROVALS
                            (FAC_APPID, FAC_ID_NUM, SM_appid,  YEARCODE, TERMCODE, INSTITUT_DIV,  COURSE, LASTNAME, FIRSTNAME, INST_TYPE, APPROVER1, APPROVER2, APPROVER3, MODIFIED_DATE )
                            SELECT FACappid, FACidnum, SM_appid, yrcde, trmcde,  instdiv, crscde, lastname, firstname, FACtype, @approve,'','', moddate
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
                                    new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("SM_appid", SM_appid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("crsdesc", crsdesc, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("moddate", moddate, DbType.String, ParameterDirection.Input),
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

        public bool UpdateDisciplineRecords(string approve, string FACappid, string FACidnum, string yearcode, string termcode, string SM_appid, string userlevel, string crsdesc, string firstname, string lastname, string FACtype, string moddate, string instdiv)

        {
            string STMT = @"WITH RECS AS
                            (
                            select
                            fm.APPID as FACappid,
                            fm.ID_NUM as FACidnum,
                            nm.LAST_NAME as lastname,
                            nm.FIRST_NAME as firstname,
                            flt.CRS_CDE as crscde,
                            flt.YR_CDE as yrcde,
                            flt.TRM_CDE as trmcde,
                            itv.DESCRIPTION as FACtype,
                            fac.APPROVER1 as approver1,
                            fac.APPROVER2 as approver2,
                            fac.APPROVER3 as approver3,
                            sm.INSTITUT_DIV_CDE as instdiv,
                            sm.APPID as SM_appid,
                            fac.MODIFIED_DATE as mod_date,
                            FORMAT(GetDate(), 'yyyy-MM-dd hh:mm:ss') as rightNow
                            from FACULTY_LOAD_TABLE flt
                            join name_master nm on nm.ID_NUM = flt.INSTRCTR_ID_NUM
                            join FACULTY_MASTER fm on fm.ID_NUM = flt.INSTRCTR_ID_NUM
                            left outer join TD_INSTRCTR_TYPE_VIEW itv on itv.value = fm.INSTRCTR_TYPE
                            join section_master sm on sm.YR_CDE = flt.YR_CDE and sm.TRM_CDE = flt.TRM_CDE and sm.CRS_CDE = flt.CRS_CDE
                            left outer join INSTIT_DIVISN_DEF idd on idd.INSTITUT_DIV_CDE = sm.INSTITUT_DIV_CDE
                            left outer join FACCRED_APPROVALS  fac on fac.FAC_APPID = fm.APPID and fac.FAC_ID_NUM = fm.ID_NUM and fac.SM_appid = sm.APPID  and fac.TERMCODE = flt.TRM_CDE and fac.YEARCODE = flt.YR_CDE ";

                            if ( userlevel == "Approver1")
                            {
                                STMT += @" where
                                        fm.ACTIVE = 'Y'
                                        and flt.YR_CDE = @yearcode
                                        and flt.TRM_CDE = @termcode
                                        and fm.ID_NUM = @FACidnum
                                        and SM.INSTITUT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 is not null
                                        )
                                        update recs
                                        set mod_date = rightNow, approver1 = @approve ";
                            }
                            else if ( userlevel == "Approver2")
                            {
                                 STMT += @" where
                                        fm.ACTIVE = 'Y'
                                        and flt.YR_CDE = @yearcode
                                        and flt.TRM_CDE = @termcode
                                        and fm.ID_NUM = @FACidnum
                                        and SM.INSTITUT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 = 'A' 
                                        )
                                        update recs
                                        set mod_date = rightNow, approver2 = @approve ";
                            }
                            else if (userlevel == "Approver3")
                            {
                                  STMT += @" where
                                        fm.ACTIVE = 'Y'
                                        and flt.YR_CDE = @yearcode
                                        and flt.TRM_CDE = @termcode
                                        and fm.ID_NUM = @FACidnum
                                        and SM.INSTITUT_DIV_CDE = @instdiv
                                        and fac.APPROVER1 = 'A' 
                                        and fac.APPROVER2 = 'A'
                                        )
                                        update recs
                                        set mod_date = rightNow, approver3 = @approve ";
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
                                    new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("SM_appid", SM_appid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("userlevel", userlevel, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("crsdesc", crsdesc, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("firstname", firstname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("lastname", lastname, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("FACtype", FACtype, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("moddate", moddate, DbType.String, ParameterDirection.Input),
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



        public DataTable getApprovalsByLevel(string s)
        {
            throw new NotImplementedException();
        }

        public void saveApproval()
        {
            throw new NotImplementedException();
        }

        public void deleteApproval()
        {
            throw new NotImplementedException();
        }

        public void updateApproval()
        {
            throw new NotImplementedException();
        }





        public string getFacultyIdnum()
        {
            return this.facultyIdnum;
        }

        public void setFacultyIdnum(string s)
        {
            this.facultyIdnum = s;
        }

        public string getFacultyFirstName()
        {
            return this.facultyFirstName;
        }

        public void setFacultyFirstName(string s)
        {
            this.facultyFirstName = s;
        }

        public string getFacultyLastName()
        {
            return this.facultyLastName;
        }

        public void setFacultyLastName(string s)
        {
            this.facultyLastName = s;
        }

        public string getCourseAppid()
        {
            return this.courseAppid;
        }

        public void setCourseAppid(string s)
        {
            this.courseAppid = s;
        }

        public string getCourseDesc()
        {
            return this.courseDesc;
        }

        public void setCourseDesc(string s)
        {
            this.courseDesc = s;
        }

        public string getCourseYear()
        {
            return this.courseYear;
        }

        public void setCourseYear(string s)
        {
            this.courseYear = s;
        }

        public string getCourseTerm()
        {
            return this.courseTerm;
        }

        public void setCourseTerm(string s)
        {
            this.courseTerm = s;
        }




        public string getApproverLevel()
        {
            return this.approverLevel;
        }

        public void setApproverLevel(string s)
        {
            this.approverLevel = s;
        }




    }
}
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
    public class CredentialsModel : System.Web.UI.UserControl
    {
        protected string id_num;

        public string getIDNum()
        {
            return id_num;
        }

        public void setIDNum(string idnum)
        {
            id_num = idnum;
        }

        public DataTable getDataSQL() //deprecated
        {
            string STMT = @"select 
                            e.ed_seq as facqualno,
                            e.ID_NUM as idnum,
                            e.earned_major as degree,
                            e.ed_received as received,
							q.descr as qualtxt,		                 		                    		                    
		                    e.earned_major as discipline,
		                    e.school_name as institute,
		                    e.honors as highest,
		                    e.yrs_completed as completeyr, 
							nm.LAST_NAME as lastname,
							nm.FIRST_NAME as firstname
	                    from
		                    edu_earn_hist e
						        join ed_offering_def q ON q.id = e.ed_offering_def_id
					            join name_master nm on nm.ID_NUM = e.ID_NUM
	                            order by e.id_num desc, completeyr desc;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("facqualno");
            DataColumn dc1 = new DataColumn("degree");
       //     DataColumn dc2 = new DataColumn("institute");
            DataColumn dc2 = new DataColumn("received");
       //     DataColumn dc4 = new DataColumn("discipline");
            DataColumn dc3 = new DataColumn("idnum");
            DataColumn dc4 = new DataColumn("lastname");
            DataColumn dc5 = new DataColumn("firstname");
            DataColumn dc6 = new DataColumn("qualtxt");
            DataColumn dc7 = new DataColumn("highest");
       //     DataColumn dc10 = new DataColumn("completeyr");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
      //      dt.Columns.Add(dc2);
            dt.Columns.Add(dc2);
      //      dt.Columns.Add(dc4);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
      //      dt.Columns.Add(dc10);



            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("facqualno", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["facqualno"] = dr["facqualno"].ToString().Trim();
                        mydr["degree"] = dr["degree"].ToString().Trim();
                        //  mydr["institute"] = dr["institute"].ToString().Trim();
                        mydr["received"] = dr["received"].ToString().Trim();
                        // mydr["discipline"] = dr["discipline"].ToString().Trim();
                        mydr["idnum"] = dr["idnum"].ToString().Trim();
                        mydr["lastname"] = dr["lastname"].ToString().Trim();
                        mydr["firstname"] = dr["firstname"].ToString().Trim();
                        mydr["qualtxt"] = dr["qualtxt"].ToString().Trim();
                        mydr["highest"] = dr["highest"].ToString().Trim();
                        //     mydr["completeyr"] = dr["completeyr"].ToString().Trim();

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

        //-----------------------
        public DataTable getNotesSQL()
        {
            string STMT = @"select 
                            iif(FAC_APPID is null, '', FAC_APPID) as FACappid,
                            iif(FAC_ID_NUM is null, '', FAC_ID_NUM) as FACidnum,
                            iif(CREATE_DATE is null, '', CREATE_DATE) as NOTEcreatedate,
                            iif(COURSE_APPID is null, '', COURSE_APPID) as CRSappid,
                            iif(COURSE_DESC is null,'',COURSE_DESC) as CRSdesc,		                 		                    		                    
                            iif(INST_DIV_CODE is null,'', INST_DIV_CODE) as CRSinstdiv,
                            iif(YEARCODE is null,'',YEARCODE) as NOTEyearcode,
                            iif(TERMCODE is null,'',TERMCODE) as NOTEtermcode,
                            iif(OLD_DIV_CODE is null,'',OLD_DIV_CODE) as PXolddivcode,
                            iif(SUBJECT is null,'',SUBJECT) as NOTEsubject, 
                            iif(NOTE is null,'',NOTE) as NOTEnote,
                            iif(USERNAME is null,'',USERNAME) as NOTEusername,
                            iif(STATUS is null,'',STATUS) as NOTEstatus,
                            iif(UPDATE_BY is null,'',UPDATE_BY) as NOTEupdateby,
                            iif(UPDATE_DATE is null,'',UPDATE_DATE) as NOTEupdatedate,
                            iif(FIRSTNAME is null,'',FIRSTNAME) as FACfirstname,
                            iif(LASTNAME is null,'',LASTNAME) as FAClastname,
                            iif(SSN is null,'',SSN) as FACssn,
                            iif(APPROVAL_DATE is null,'',APPROVAL_DATE) as NOTEapprovaldate,
                            iif(EXPIRATION_DATE is null,'',EXPIRATION_DATE) as NOTEexpirationdate,
                            iif(FAC_TYPE is null,'',FAC_TYPE) as FACinsttype,
                            iif(NOTE_ID is null,'',NOTE_ID) as NOTEid
                            from
                            FacCred_NOTES_111814;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("FACappid");
            DataColumn dc1 = new DataColumn("FACidnum");
            DataColumn dc2 = new DataColumn("NOTEcreatedate");
            DataColumn dc3 = new DataColumn("CRSappid");
            DataColumn dc4 = new DataColumn("CRSdesc");
            DataColumn dc5 = new DataColumn("CRSinstdiv");
            DataColumn dc6 = new DataColumn("NOTEyearcode");
            DataColumn dc7 = new DataColumn("NOTEtermcode");
            DataColumn dc8 = new DataColumn("PXolddivcode");
            DataColumn dc9 = new DataColumn("NOTEsubject");
            DataColumn dc10 = new DataColumn("NOTEnote");
            DataColumn dc11 = new DataColumn("NOTEusername");
            DataColumn dc12 = new DataColumn("NOTEstatus");
            DataColumn dc13 = new DataColumn("NOTEupdateby");
            DataColumn dc14 = new DataColumn("NOTEupdatedate");
            DataColumn dc15 = new DataColumn("FACfirstname");
            DataColumn dc16 = new DataColumn("FAClastname");
            DataColumn dc17 = new DataColumn("FACssn");
            DataColumn dc18 = new DataColumn("NOTEapprovaldate");
            DataColumn dc19 = new DataColumn("NOTEexpirationdate");
            DataColumn dc20 = new DataColumn("FACinsttype");
            DataColumn dc21 = new DataColumn("NOTEid");

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
            dt.Columns.Add(dc17);
            dt.Columns.Add(dc18);
            dt.Columns.Add(dc19);
            dt.Columns.Add(dc20);
            dt.Columns.Add(dc21);

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("NOTEid", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["FACappid"] = dr["FACappid"].ToString().Trim();
                        mydr["FACidnum"] = dr["FACidnum"].ToString().Trim();
                        mydr["NOTEcreatedate"] = dr["NOTEcreatedate"].ToString().Trim();
                        mydr["CRSappid"] = dr["CRSappid"].ToString().Trim();
                        mydr["CRSdesc"] = dr["CRSdesc"].ToString().Trim();
                        mydr["CRSinstdiv"] = dr["CRSinstdiv"].ToString().Trim();
                        mydr["NOTEyearcode"] = dr["NOTEyearcode"].ToString().Trim();
                        mydr["NOTEtermcode"] = dr["NOTEtermcode"].ToString().Trim();
                        mydr["PXolddivcode"] = dr["PXolddivcode"].ToString().Trim();
                        mydr["NOTEsubject"] = dr["NOTEsubject"].ToString().Trim();
                        mydr["NOTEnote"] = dr["NOTEnote"].ToString().Trim();
                        mydr["NOTEusername"] = dr["NOTEusername"].ToString().Trim();
                        mydr["NOTEstatus"] = dr["NOTEstatus"].ToString().Trim();
                        mydr["NOTEupdateby"] = dr["NOTEupdateby"].ToString().Trim();
                        mydr["NOTEupdatedate"] = dr["NOTEupdatedate"].ToString().Trim();
                        mydr["FACfirstname"] = dr["FACfirstname"].ToString().Trim();
                        mydr["FAClastname"] = dr["FAClastname"].ToString().Trim();
                        mydr["FACssn"] = dr["FACssn"].ToString().Trim();
                        mydr["NOTEapprovaldate"] = dr["NOTEapprovaldate"].ToString().Trim();
                        mydr["NOTEexpirationdate"] = dr["NOTEexpirationdate"].ToString().Trim();
                        mydr["FACinsttype"] = dr["FACinsttype"].ToString().Trim();
                        mydr["NOTEid"] = dr["NOTEid"].ToString().Trim();

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


        public bool InsertUpdateNote(   string note_id, 
                                        string facappid, 
                                        string facidnum, 
                                        string createdate,                                       
                                        string courseappid, 
                                        string coursedesc, 
                                        string instdiv, 
                                        string yearcode, 
                                        string termcode, 
                                        string subject,
                                        string note, 
                                        string username,                        
                                        string status, 
                                        string updateby,
                                        string updatedate,
                                        string approvaldate, 
                                        string expirationdate, 
                                        string factype,                                        
                                        string note_level, 
                                        string note_type,
                                        string userlevel
                                     )
        {
            string STMT = String.Empty;

            if (userlevel == "Approver1" || userlevel == "Approver2" || userlevel == "Approver3" || userlevel == "FacCredUser")
            {
                STMT = @" IF (SELECT count(*) from FACCRED_NOTES  where NOTE_ID = @note_id  ) = 0
                               INSERT INTO FACCRED_NOTES VALUES(@facappid, @facidnum, @createdate, @courseappid, @coursedesc, @instdiv, @yearcode, @termcode, @subject, @note, @username, @status, @updateby, @updatedate,
                                                                @approvaldate, @expirationdate, @factype, @note_level, @note_type)

                               ELSE UPDATE FACCRED_NOTES 
                                    SET 
                                        FAC_APPID = @facappid, 
                                        FAC_ID_NUM = @facidnum, 
                                        CREATE_DATE = @createdate, 
                                        COURSE_APPID = @courseappid, 
                                        COURSE_DESC = @coursedesc, 
                                        INST_DIV_CODE = @instdiv, 
                                        YEARCODE = @yearcode, 
                                        TERMCODE = @termcode, 
                                        SUBJECT = @subject, 
                                        NOTE = @note, 
                                        USERNAME = @username, 
                                        STATUS = @status, 
                                        UPDATE_BY = @updateby, 
                                        UPDATE_DATE = @updatedate,
                                        APPROVAL_DATE = @approvaldate, 
                                        EXPIRATION_DATE = @expirationdate, 
                                        FAC_TYPE = @factype, 
                                        NOTE_LEVEL = @note_level, 
                                        NOTE_TYPE = @note_type   
                                    WHERE NOTE_ID = @note_id;";

            }

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                               CommandType.Text,
                               new ParamStruct[]{
                                    new ParamStruct("facappid", facappid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("facidnum", facidnum, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("createdate", createdate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("courseappid", courseappid, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("coursedesc", coursedesc, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("instdiv", instdiv, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("subject", subject, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("note", note, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("username", username, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("status", status, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("updateby", updateby, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("updatedate", updatedate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("approvaldate", approvaldate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("expirationdate", expirationdate, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("factype", factype, DbType.String, ParameterDirection.Input),                                    
                                    new ParamStruct("note_level", username, DbType.String, ParameterDirection.Input),
                                    new ParamStruct("note_type", username, DbType.String, ParameterDirection.Input)                                                                           
                               });

                return true;
            }
            catch (Exception ex)
            {

                ExceptionManager.Publish(ex);
                return false;
            }

        }
        //-----------------------



        public DataTable getPXCoursesSQL()
        {
            string STMT = @"select 
                            REVNUMBER as revnumber,
                            REVSTRING AS revstring,
                            SSN as ssn,
                            DIVCODE as divcode,
                            FQSID as fqsid,
                            FQSNUMBER as fqsnumber,
                            CRSCODE as crscode,
                            CRS_KEY as crs_key,
                            ZERO1 as zero1
                            from
		                        FacCred_PXCOURSES_111814;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("revnumber");
            DataColumn dc1 = new DataColumn("revstring");
            DataColumn dc2 = new DataColumn("ssn");
            DataColumn dc3 = new DataColumn("divcode");
            DataColumn dc4 = new DataColumn("fqsid");
            DataColumn dc5 = new DataColumn("fqsnumber");
            DataColumn dc6 = new DataColumn("crscode");
            DataColumn dc7 = new DataColumn("crs_key");
            DataColumn dc8 = new DataColumn("zero1");

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
                                                new ParamStruct("revnumber", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["revnumber"] = dr["revnumber"].ToString().Trim();
                        mydr["revstring"] = dr["revstring"].ToString().Trim();
                        mydr["ssn"] = dr["ssn"].ToString().Trim();
                        mydr["divcode"] = dr["divcode"].ToString().Trim();
                        mydr["fqsid"] = dr["fqsid"].ToString().Trim();
                        mydr["fqsnumber"] = dr["fqsnumber"].ToString().Trim();
                        mydr["crscode"] = dr["crscode"].ToString().Trim();
                        mydr["crs_key"] = dr["crs_key"].ToString().Trim();
                        mydr["zero1"] = dr["zero1"].ToString().Trim();

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

        //-----------------------

        public DataTable getPXCodesSQL()
        {
            string STMT = @"select 
                            CODE as code,
                            TRANSLATION AS translation,
                            SHORTTR as shorttr,
                            SHORTTR2 as shorttr2,
                            DSPCODE as dspcode,
                            PREFIX as prefix,
                            DIVTR as divtr
                            from
		                        FacCred_PXCODES_111814;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("code");
            DataColumn dc1 = new DataColumn("translation");
            DataColumn dc2 = new DataColumn("shorttr");
            DataColumn dc3 = new DataColumn("shorttr2");
            DataColumn dc4 = new DataColumn("dspcode");
            DataColumn dc5 = new DataColumn("prefix");
            DataColumn dc6 = new DataColumn("divtr");
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                                            CommandType.Text,
                                            new ParamStruct[]{
                                                new ParamStruct("code", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["code"] = dr["code"].ToString().Trim();
                        mydr["translation"] = dr["translation"].ToString().Trim();
                        mydr["shorttr"] = dr["shorttr"].ToString().Trim();
                        mydr["shorttr2"] = dr["shorttr2"].ToString().Trim();
                        mydr["dspcode"] = dr["dspcode"].ToString().Trim();
                        mydr["prefix"] = dr["prefix"].ToString().Trim();
                        mydr["divtr"] = dr["divtr"].ToString().Trim();

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



        //-------------------------
        public DataTable getACAD_CRED_SQL()
        {
            string STMT = @"select 
                            FAC_APPID as facappid,
                            FAC_ID_NUM as idnum,
                            CREATE_DATE as createdate,
                            COURSE_APPID as appid,
							COURSE_DESC as coursedesc,		                 		                    		                    
		                    INST_DIV_CODE as instdiv,
		                    YEARCODE as yearcode,
		                    TERMCODE as termcode,
                            OLD_DIV_CODE as olddivcode,
		                    ACADCRED as acadcred, 					
                            UPDATE_BY as updateby,
                            UPDATE_DATE as updatedate,
                            FIRSTNAME as firstname,
                            LASTNAME as lastname
	                        from
		                        FacCred_ACAD_CRED_111814;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("facappid");
            DataColumn dc1 = new DataColumn("idnum");
            DataColumn dc2 = new DataColumn("createdate");
            DataColumn dc3 = new DataColumn("appid");
            DataColumn dc4 = new DataColumn("coursedesc");
            DataColumn dc5 = new DataColumn("instdiv");
            DataColumn dc6 = new DataColumn("yearcode");
            DataColumn dc7 = new DataColumn("termcode");
            DataColumn dc8 = new DataColumn("olddivcode");
            DataColumn dc9 = new DataColumn("acadcred");
            DataColumn dc10 = new DataColumn("updateby");
            DataColumn dc11 = new DataColumn("updatedate");
            DataColumn dc12 = new DataColumn("firstname");
            DataColumn dc13 = new DataColumn("lastname");
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
                                                new ParamStruct("idnum", "1", DbType.String, ParameterDirection.Input)
                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["facappid"] = dr["facappid"].ToString().Trim();
                        mydr["idnum"] = dr["idnum"].ToString().Trim();
                        mydr["createdate"] = dr["createdate"].ToString().Trim();
                        mydr["appid"] = dr["appid"].ToString().Trim();
                        mydr["coursedesc"] = dr["coursedesc"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["olddivcode"] = dr["olddivcode"].ToString().Trim();
                        mydr["acadcred"] = dr["acadcred"].ToString().Trim();
                        mydr["updateby"] = dr["updateby"].ToString().Trim();
                        mydr["updatedate"] = dr["updatedate"].ToString().Trim();
                        mydr["firstname"] = dr["firstname"].ToString().Trim();
                        mydr["lastname"] = dr["lastname"].ToString().Trim();

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
       

        //-------------------------
        public DataTable getCOPY_OL_SQL()
        {
            string STMT = @"select 
                            FAC_APPID as facappid,
                            FAC_ID_NUM as idnum,
                            CREATE_DATE as createdate,
                            COURSE_APPID as appid,
							COURSE_DESC as coursedesc,		                 		                    		                    
		                    INST_DIV_CODE as instdiv,
		                    YEARCODE as yearcode,
		                    TERMCODE as termcode, 
                            OLD_DIV_CODE as olddivcode,                           
		                    COPY_OL as copyol, 					
                            UPDATE_BY as updateby,
                            UPDATE_DATE as updatedate,
                            FIRSTNAME as firstname,
                            LASTNAME as lastname
	                        from
		                        FacCred_COPY_OL_111814;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("facappid");
            DataColumn dc1 = new DataColumn("idnum");
            DataColumn dc2 = new DataColumn("createdate");
            DataColumn dc3 = new DataColumn("appid");
            DataColumn dc4 = new DataColumn("coursedesc");
            DataColumn dc5 = new DataColumn("instdiv");
            DataColumn dc6 = new DataColumn("yearcode");
            DataColumn dc7 = new DataColumn("termcode");
            DataColumn dc8 = new DataColumn("olddivcode");                      
            DataColumn dc9 = new DataColumn("copyol");
            DataColumn dc10 = new DataColumn("updateby");
            DataColumn dc11 = new DataColumn("updatedate");
            DataColumn dc12 = new DataColumn("firstname");
            DataColumn dc13 = new DataColumn("lastname");
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
                                                new ParamStruct("idnum", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["facappid"] = dr["facappid"].ToString().Trim();
                        mydr["idnum"] = dr["idnum"].ToString().Trim();
                        mydr["createdate"] = dr["createdate"].ToString().Trim();
                        mydr["appid"] = dr["appid"].ToString().Trim();
                        mydr["coursedesc"] = dr["coursedesc"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["olddivcode"] = dr["olddivcode"].ToString().Trim();
                        mydr["copyol"] = dr["copyol"].ToString().Trim();
                        mydr["updateby"] = dr["updateby"].ToString().Trim();
                        mydr["updatedate"] = dr["updatedate"].ToString().Trim();
                        mydr["firstname"] = dr["firstname"].ToString().Trim();
                        mydr["lastname"] = dr["lastname"].ToString().Trim();

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
        //-----------------------


        public DataTable getCREDIT_SQL()
        {
            string STMT = @"select 
                            FAC_APPID as facappid,
                            FAC_ID_NUM as idnum,
                            CREATE_DATE as createdate,
                            COURSE_APPID as appid,
							COURSE_DESC as coursedesc,		                 		                    		                    
		                    INST_DIV_CODE as instdiv,
		                    YEARCODE as yearcode,
		                    TERMCODE as termcode, 
                            OLD_DIV_CODE as olddivcode,  
                            FQSID as fqsid,
                            FQSNUMBER as fqsnumber,
                            DSPCODE as dspcode,
                            CR_KEY as crkey,
                            COURSE as course,
                            TITLE as title,
                            INSTITUTE as institute,
                            CR_UHOURS as cruhours,
                            CR_GHOURS as crghours,
                            COPY_OL1 as copyol1,
                            INST_OL as instol,
                            CREDITID as creditid,
                            TITLE_OL as titleol,
                            ZERO1 as zero1,
                            UPDATE_BY as updateby,
                            UPDATE_DATE as updatedate,
                            FIRSTNAME as firstname,
                            LASTNAME as lastname
	                        from
		                        FacCred_CREDIT_111814;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("facappid");
            DataColumn dc1 = new DataColumn("idnum");
            DataColumn dc2 = new DataColumn("createdate");
            DataColumn dc3 = new DataColumn("appid");
            DataColumn dc4 = new DataColumn("coursedesc");
            DataColumn dc5 = new DataColumn("instdiv");
            DataColumn dc6 = new DataColumn("yearcode");
            DataColumn dc7 = new DataColumn("termcode");
            DataColumn dc8 = new DataColumn("olddivcode");
            DataColumn dc9 = new DataColumn("fqsid");
            DataColumn dc10 = new DataColumn("fqsnumber");
            DataColumn dc11 = new DataColumn("dspcode");
            DataColumn dc12 = new DataColumn("crkey");
            DataColumn dc13 = new DataColumn("course");
            DataColumn dc14 = new DataColumn("title");
            DataColumn dc15 = new DataColumn("institute");
            DataColumn dc16 = new DataColumn("cruhours");
            DataColumn dc17 = new DataColumn("crghours");
            DataColumn dc18 = new DataColumn("copyol1");
            DataColumn dc19 = new DataColumn("instol");
            DataColumn dc20 = new DataColumn("creditid");
            DataColumn dc21 = new DataColumn("titleol");
            DataColumn dc22 = new DataColumn("zero1");
            DataColumn dc23 = new DataColumn("updateby");
            DataColumn dc24 = new DataColumn("updatedate");
            DataColumn dc25 = new DataColumn("firstname");
            DataColumn dc26 = new DataColumn("lastname");
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
            dt.Columns.Add(dc17);
            dt.Columns.Add(dc18);
            dt.Columns.Add(dc19);
            dt.Columns.Add(dc20);
            dt.Columns.Add(dc21);
            dt.Columns.Add(dc22);
            dt.Columns.Add(dc23);
            dt.Columns.Add(dc24);
            dt.Columns.Add(dc25);
            dt.Columns.Add(dc26);

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
                        mydr["facappid"] = dr["facappid"].ToString().Trim();
                        mydr["idnum"] = dr["idnum"].ToString().Trim();
                        mydr["createdate"] = dr["createdate"].ToString().Trim();
                        mydr["appid"] = dr["appid"].ToString().Trim();
                        mydr["coursedesc"] = dr["coursedesc"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["olddivcode"] = dr["olddivcode"].ToString().Trim();
                        mydr["fqsid"] = dr["fqsid"].ToString().Trim();
                        mydr["fqsnumber"] = dr["fqsnumber"].ToString().Trim();
                        mydr["dspcode"] = dr["dspcode"].ToString().Trim();
                        mydr["crkey"] = dr["crkey"].ToString().Trim();
                        mydr["course"] = dr["course"].ToString().Trim();
                        mydr["title"] = dr["title"].ToString().Trim();
                        mydr["institute"] = dr["institute"].ToString().Trim();
                        mydr["cruhours"] = dr["cruhours"].ToString().Trim();
                        mydr["crghours"] = dr["crghours"].ToString().Trim();
                        mydr["copyol1"] = dr["copyol1"].ToString().Trim();
                        mydr["instol"] = dr["instol"].ToString().Trim();
                        mydr["creditid"] = dr["creditid"].ToString().Trim();
                        mydr["titleol"] = dr["titleol"].ToString().Trim();
                        mydr["zero1"] = dr["zero1"].ToString().Trim();
                        mydr["updateby"] = dr["updateby"].ToString().Trim();
                        mydr["updatedate"] = dr["updatedate"].ToString().Trim();
                        mydr["firstname"] = dr["firstname"].ToString().Trim();
                        mydr["lastname"] = dr["lastname"].ToString().Trim();

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


        //-------------------------
        public DataTable getOTHER_QUAL_SQL()
        {
            string STMT = @"select 
                            FAC_APPID as facappid,
                            FAC_ID_NUM as idnum,
                            CREATE_DATE as createdate,
                            COURSE_APPID as appid,
							COURSE_DESC as coursedesc,		                 		                    		                    
		                    INST_DIV_CODE as instdiv,
		                    YEARCODE as yearcode,
		                    TERMCODE as termcode, 
                            OLD_DIV_CODE as olddivcode,                          
		                    OTHER_QUAL as otherqual, 					
                            UPDATE_BY as updateby,
                            UPDATE_DATE as updatedate,
                            FIRSTNAME as firstname,
                            LASTNAME as lastname
	                        from
		                        FacCred_OTHER_QUAL_111814;";
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("facappid");
            DataColumn dc1 = new DataColumn("idnum");
            DataColumn dc2 = new DataColumn("createdate");
            DataColumn dc3 = new DataColumn("appid");
            DataColumn dc4 = new DataColumn("coursedesc");
            DataColumn dc5 = new DataColumn("instdiv");
            DataColumn dc6 = new DataColumn("yearcode");
            DataColumn dc7 = new DataColumn("termcode");
            DataColumn dc8 = new DataColumn("olddivcode");
            DataColumn dc9 = new DataColumn("otherqual");
            DataColumn dc10 = new DataColumn("updateby");
            DataColumn dc11 = new DataColumn("updatedate");
            DataColumn dc12 = new DataColumn("firstname");
            DataColumn dc13 = new DataColumn("lastname");
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
                                                new ParamStruct("idnum", "1", DbType.String, ParameterDirection.Input)
                                            });

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();
                        mydr["facappid"] = dr["facappid"].ToString().Trim();
                        mydr["idnum"] = dr["idnum"].ToString().Trim();
                        mydr["createdate"] = dr["createdate"].ToString().Trim();
                        mydr["appid"] = dr["appid"].ToString().Trim();
                        mydr["coursedesc"] = dr["coursedesc"].ToString().Trim();
                        mydr["instdiv"] = dr["instdiv"].ToString().Trim();
                        mydr["yearcode"] = dr["yearcode"].ToString().Trim();
                        mydr["termcode"] = dr["termcode"].ToString().Trim();
                        mydr["olddivcode"] = dr["olddivcode"].ToString().Trim();
                        mydr["otherqual"] = dr["otherqual"].ToString().Trim();
                        mydr["updateby"] = dr["updateby"].ToString().Trim();
                        mydr["updatedate"] = dr["updatedate"].ToString().Trim();
                        mydr["firstname"] = dr["firstname"].ToString().Trim();
                        mydr["lastname"] = dr["lastname"].ToString().Trim();

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
        //-----------------------













    }
}

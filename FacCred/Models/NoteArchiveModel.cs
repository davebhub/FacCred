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
    public class NoteArchiveModel : System.Web.UI.UserControl
    {



        public DataTable getFacultyArchiveNotes(string FACidnum, string termcode, string yearcode, string schoolcde, string instdiv)
        {

            string STMT =
                        @"SELECT NOTE_ID 
                          ,FAC_APPID 
                          ,FAC_ID_NUM 
                          ,SM_APPID 
                          ,CRS_CDE 
                          ,CRS_TITLE 
                          ,DIV_CDE 
                          ,INSTIT_DIV_CDE 
                          ,SCHOOL_CDE 
                          ,YEARCODE 
                          ,TERMCODE 
                          ,SUBJECT 
                          ,STATUS 
                          ,NOTE 
                          ,NOTE_TYPE 
                          ,NOTE_LEVEL 
                          ,FAC_TYPE 
                          ,APPROVAL_DATE 
                          ,EXPIRATION_DATE 
                          ,CREATE_BY 
                          ,CREATE_DATE 
                          ,UPDATE_BY 
                          ,UPDATE_DATE 
                      FROM FACCRED_NOTES_ARCHIVE
                      WHERE
	                    FAC_ID_NUM = @FACidnum 
	                    AND (TERMCODE = @termcode OR TERMCODE = '')
	                    AND (YEARCODE = @yearcode OR YEARCODE = '')
	                    AND (SCHOOL_CDE = @schoolcde OR SCHOOL_CDE = '')
	                    AND (INSTIT_DIV_CDE = @instdiv OR INSTIT_DIV_CDE = '')
                      order by UPDATE_DATE DESC";


            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("NOTE_ID");
            DataColumn dc1 = new DataColumn("FAC_APPID");
            DataColumn dc2 = new DataColumn("FAC_ID_NUM");
            DataColumn dc3 = new DataColumn("SM_APPID");
            DataColumn dc4 = new DataColumn("CRS_CDE");
            DataColumn dc5 = new DataColumn("CRS_TITLE");
            DataColumn dc6 = new DataColumn("DIV_CDE");
            DataColumn dc7 = new DataColumn("INSTIT_DIV_CDE");
            DataColumn dc8 = new DataColumn("SCHOOL_CDE");
            DataColumn dc9 = new DataColumn("YEARCODE");
            DataColumn dc10 = new DataColumn("TERMCODE");
            DataColumn dc11 = new DataColumn("SUBJECT");
            DataColumn dc12 = new DataColumn("STATUS");
            DataColumn dc13 = new DataColumn("NOTE");
            DataColumn dc14 = new DataColumn("NOTE_TYPE");
            DataColumn dc15 = new DataColumn("NOTE_LEVEL");
            DataColumn dc16 = new DataColumn("FAC_TYPE");
            DataColumn dc17 = new DataColumn("APPROVAL_DATE");
            DataColumn dc18 = new DataColumn("EXPIRATION_DATE");
            DataColumn dc19 = new DataColumn("CREATE_BY");
            DataColumn dc20 = new DataColumn("CREATE_DATE");
            DataColumn dc21 = new DataColumn("UPDATE_BY");
            DataColumn dc22 = new DataColumn("UPDATE_DATE");


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


            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("FACidnum", FACidnum, DbType.String, ParameterDirection.Input),
                        new ParamStruct("termcode", termcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("yearcode", yearcode, DbType.String, ParameterDirection.Input),
                        new ParamStruct("schoolcde", schoolcde, DbType.String, ParameterDirection.Input),
                        new ParamStruct("instdiv", instdiv, DbType.String, ParameterDirection.Input)
                    });
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow mydr = dt.NewRow();

                        mydr["NOTE_ID"] = dr["NOTE_ID"].ToString().Trim();
                        mydr["FAC_APPID"] = dr["FAC_APPID"].ToString().Trim();
                        mydr["FAC_ID_NUM"] = dr["FAC_ID_NUM"].ToString().Trim();
                        mydr["SM_APPID"] = dr["SM_APPID"].ToString().Trim();
                        mydr["CRS_CDE"] = dr["CRS_CDE"].ToString().Trim();
                        mydr["CRS_TITLE"] = dr["CRS_TITLE"].ToString().Trim();
                        mydr["DIV_CDE"] = dr["DIV_CDE"].ToString().Trim();
                        mydr["INSTIT_DIV_CDE"] = dr["INSTIT_DIV_CDE"].ToString().Trim();
                        mydr["SCHOOL_CDE"] = dr["SCHOOL_CDE"].ToString().Trim();
                        mydr["YEARCODE"] = dr["YEARCODE"].ToString().Trim();
                        mydr["TERMCODE"] = dr["TERMCODE"].ToString().Trim();
                        mydr["SUBJECT"] = dr["SUBJECT"].ToString().Trim();
                        mydr["STATUS"] = dr["STATUS"].ToString().Trim();
                        mydr["NOTE"] = dr["NOTE"].ToString().Trim();
                        mydr["NOTE_TYPE"] = dr["NOTE_TYPE"].ToString().Trim();
                        mydr["NOTE_LEVEL"] = dr["NOTE_LEVEL"].ToString().Trim();
                        mydr["FAC_TYPE"] = dr["FAC_TYPE"].ToString().Trim();
                        mydr["APPROVAL_DATE"] = dr["APPROVAL_DATE"].ToString().Trim();
                        mydr["EXPIRATION_DATE"] = dr["EXPIRATION_DATE"].ToString().Trim();
                        mydr["CREATE_BY"] = dr["CREATE_BY"].ToString().Trim();
                        mydr["CREATE_DATE"] = dr["CREATE_DATE"].ToString().Trim();
                        mydr["UPDATE_BY"] = dr["UPDATE_BY"].ToString().Trim();
                        mydr["UPDATE_DATE"] = dr["UPDATE_DATE"].ToString().Trim();

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
                return rtnNoNoteRecordsFound();
            }
        }


        public bool moveArchiveToNote(Guid noteid)
        {

            string STMT =
            @"INSERT INTO FACCRED_NOTES(
                        NOTE_ID
                       ,FAC_APPID
                       ,FAC_ID_NUM
                       ,SM_APPID
                       ,CRS_CDE
                       ,CRS_TITLE
                       ,DIV_CDE
                       ,INSTIT_DIV_CDE
                       ,SCHOOL_CDE
                       ,YEARCODE
                       ,TERMCODE
                       ,SUBJECT
                       ,STATUS
                       ,NOTE
                       ,NOTE_TYPE
                       ,NOTE_LEVEL
                       ,FAC_TYPE
                       ,APPROVAL_DATE
                       ,EXPIRATION_DATE
                       ,CREATE_BY
                       ,CREATE_DATE
                       ,UPDATE_BY
                       ,UPDATE_DATE
                        )
                    SELECT 
                        NOTE_ID
                       ,FAC_APPID
                       ,FAC_ID_NUM
                       ,SM_APPID
                       ,CRS_CDE
                       ,CRS_TITLE
                       ,DIV_CDE
                       ,INSTIT_DIV_CDE
                       ,SCHOOL_CDE
                       ,YEARCODE
                       ,TERMCODE
                       ,SUBJECT
                       ,STATUS
                       ,NOTE
                       ,NOTE_TYPE
                       ,NOTE_LEVEL
                       ,FAC_TYPE
                       ,APPROVAL_DATE
                       ,EXPIRATION_DATE
                       ,CREATE_BY
                       ,CREATE_DATE
                       ,UPDATE_BY
                       ,UPDATE_DATE
                FROM FACCRED_NOTES_ARCHIVE
            WHERE NOTE_ID = @noteid;

            DELETE FROM FACCRED_NOTES_ARCHIVE
            WHERE NOTE_ID = @noteid;";

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("noteid", noteid, DbType.Guid, ParameterDirection.Input)
                    });

                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }

        }


        public bool deleteOneArchiveNote(Guid noteid)
        {

            string STMT =
            @"DELETE FROM FACCRED_NOTES_ARCHIVE
              WHERE NOTE_ID = @noteid;";

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                DataSet ds = da.execDataSet(STMT,
                    CommandType.Text,
                    new ParamStruct[]
                    {
                        new ParamStruct("noteid", noteid, DbType.Guid, ParameterDirection.Input)
                    });

                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }

        }







        public DataTable rtnNoNoteRecordsFound()
        {
            DataTable table1 = new DataTable();


            table1.Columns.Add("NOTE_ID");
            table1.Columns.Add("FAC_APPID");
            table1.Columns.Add("FAC_ID_NUM");
            table1.Columns.Add("SM_APPID");
            table1.Columns.Add("CRS_CDE");
            table1.Columns.Add("CRS_TITLE");
            table1.Columns.Add("DIV_CDE");
            table1.Columns.Add("INSTIT_DIV_CDE");
            table1.Columns.Add("SCHOOL_CDE");
            table1.Columns.Add("YEARCODE");
            table1.Columns.Add("TERMCODE");
            table1.Columns.Add("SUBJECT");
            table1.Columns.Add("STATUS");
            table1.Columns.Add("NOTE");
            table1.Columns.Add("NOTE_TYPE");
            table1.Columns.Add("NOTE_LEVEL");
            table1.Columns.Add("FAC_TYPE");
            table1.Columns.Add("APPROVAL_DATE");
            table1.Columns.Add("EXPIRATION_DATE");
            table1.Columns.Add("CREATE_BY");
            table1.Columns.Add("CREATE_DATE");
            table1.Columns.Add("UPDATE_BY");
            table1.Columns.Add("UPDATE_DATE");


            table1.Rows.Add("", "", "no records found");

            //DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            return table1;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.Data;

namespace FacCred.Presenters
{
    public class CredentialsPresenter
    {
        static CredentialsModel model = new CredentialsModel();
        
        public DataSet getDataSQLByID(string FACidnum)
        {
            //same model call but using LINQ to filter by ID
            DataTable dt = model.getDataSQL();

            
            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("FACidnum") == FACidnum);

            if (dataRow.Count<DataRow>() > 0 ) { 
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }
            // if you don't find anything for the selected id_num, then return everything
            // return getDataSQLDataSet();
            return rtnNoCredsFound();
        }

        public DataSet getDataSQLDataSet()
        {
            //same model call but returning the full dataset
            DataTable dt = model.getDataSQL();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoCredsFound();
        }


        public DataSet getNotesSQLDataSet()
        {
            DataTable dt = model.getNotesSQL();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoNotesFound();
        }

        public DataSet getNotesSQLDataSetID(string FACidnum)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getNotesSQL();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("FACidnum") == FACidnum);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoNotesFound();
        }

        public DataSet getPXCoursesSQLDataSet()
        {
            DataTable dt = model.getPXCoursesSQL();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoPXCoursesFound();
        }

        public DataSet getPXCodesSQLDataSet()
        {
            DataTable dt = model.getPXCodesSQL();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoPXCodesFound();
        }

        public DataSet getACAD_CREDSQLDataSet()
        {
            DataTable dt = model.getACAD_CRED_SQL();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoACAD_CREDFound();
        }

        public DataSet getCOPY_OL_SQLDataSet()
        {
            DataTable dt = model.getCOPY_OL_SQL();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoCOPY_OLFound();
        }

        public DataSet getCREDIT_SQLDataSet()
        {
            
            DataTable dt = model.getCREDIT_SQL();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoCREDITFound();
        }

        public DataSet getOTHER_QUAL_SQLDataSet()
        {
            DataTable dt = model.getOTHER_QUAL_SQL();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();
            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoOTHER_QUALFound();
        }


        public bool InsertUpdateNote(string note_id,
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
                                        string userlevel)
        {

            try
            {


                model.InsertUpdateNote(note_id,
                                       facappid,
                                       facidnum,
                                       createdate,
                                       courseappid,
                                       coursedesc,
                                       instdiv,
                                       yearcode,
                                       termcode,
                                       subject,
                                       note,
                                       username,
                                       status,
                                       updateby,
                                       updatedate,
                                       approvaldate,
                                       expirationdate,
                                       factype,
                                       note_level,
                                       note_type,
                                       userlevel);
                return true;
            }
            catch
            {
                return false;
            }
            
        }




        public DataSet rtnNoCredsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("facqual_no");
            table1.Columns.Add("degree");
           // table1.Columns.Add("institution");
            table1.Columns.Add("received");
          //  table1.Columns.Add("discipline");
            table1.Columns.Add("idnum");
            table1.Columns.Add("lastname");
            table1.Columns.Add("firstname");
            table1.Columns.Add("qualtxt");
            table1.Columns.Add("highest");

            table1.Rows.Add("facqual_no", "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }


        public DataSet rtnNoPXCoursesFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("revnumber");
            table1.Columns.Add("revstring");
            table1.Columns.Add("ssn");
            table1.Columns.Add("divcode");
            table1.Columns.Add("fqsid");
            table1.Columns.Add("fqsnumber");
            table1.Columns.Add("crscode");
            table1.Columns.Add("crs_key");
            table1.Columns.Add("zero1");


            table1.Rows.Add("revnumber", "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }

        public DataSet rtnNoOTHER_QUALFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("revnumber");
            table1.Columns.Add("revstring");
            table1.Columns.Add("ssn");
            table1.Columns.Add("divcode");
            table1.Columns.Add("fqsid");
            table1.Columns.Add("fqsnumber");
            table1.Columns.Add("crscode");
            table1.Columns.Add("crs_key");
            table1.Columns.Add("zero1");


            table1.Rows.Add("revnumber", "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }
        public DataSet rtnNoCREDITFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("revnumber");
            table1.Columns.Add("revstring");
            table1.Columns.Add("ssn");
            table1.Columns.Add("divcode");
            table1.Columns.Add("fqsid");
            table1.Columns.Add("fqsnumber");
            table1.Columns.Add("crscode");
            table1.Columns.Add("crs_key");
            table1.Columns.Add("zero1");


            table1.Rows.Add("revnumber", "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }
        public DataSet rtnNoCOPY_OLFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("revnumber");
            table1.Columns.Add("revstring");
            table1.Columns.Add("ssn");
            table1.Columns.Add("divcode");
            table1.Columns.Add("fqsid");
            table1.Columns.Add("fqsnumber");
            table1.Columns.Add("crscode");
            table1.Columns.Add("crs_key");
            table1.Columns.Add("zero1");


            table1.Rows.Add("revnumber", "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }
        public DataSet rtnNoACAD_CREDFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("revnumber");
            table1.Columns.Add("revstring");
            table1.Columns.Add("ssn");
            table1.Columns.Add("divcode");
            table1.Columns.Add("fqsid");
            table1.Columns.Add("fqsnumber");
            table1.Columns.Add("crscode");
            table1.Columns.Add("crs_key");
            table1.Columns.Add("zero1");


            table1.Rows.Add("revnumber", "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }
        public DataSet rtnNoPXCodesFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("revnumber");
            table1.Columns.Add("revstring");
            table1.Columns.Add("ssn");
            table1.Columns.Add("divcode");
            table1.Columns.Add("fqsid");
            table1.Columns.Add("fqsnumber");
            table1.Columns.Add("crscode");
            table1.Columns.Add("crs_key");
            table1.Columns.Add("zero1");


            table1.Rows.Add("revnumber", "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }



        public DataSet rtnNoNotesFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("NOTEcreatedate");
            table1.Columns.Add("CRSappid");
            table1.Columns.Add("CRSdesc");
            table1.Columns.Add("CRSinstdiv");
            table1.Columns.Add("NOTEyearcode");
            table1.Columns.Add("NOTEtermcode");
            table1.Columns.Add("PXolddivcode");
            table1.Columns.Add("NOTEsubject");
            table1.Columns.Add("NOTEnote");
            table1.Columns.Add("NOTEusername");
            table1.Columns.Add("NOTEstatus");
            table1.Columns.Add("NOTEupdateby");
            table1.Columns.Add("NOTEupdatedate");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACssn");
            table1.Columns.Add("NOTEapprovaldate");
            table1.Columns.Add("NOTEexpirationdate");
            table1.Columns.Add("FACinsttype");
            table1.Columns.Add("NOTEid");

            table1.Rows.Add( "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }

        public DataSet rtnNoCoursesFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("revnumber");
            table1.Columns.Add("revstring");
            table1.Columns.Add("ssn");
            table1.Columns.Add("divcode");
            table1.Columns.Add("fqsid");
            table1.Columns.Add("fqsnumber");
            table1.Columns.Add("crscode");
            table1.Columns.Add("crs_key");
            table1.Columns.Add("zero1");


            table1.Rows.Add("revnumber", "no data found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }






        public string getIDNum()
        {
            return model.getIDNum();
        }

        public void setIDNum(string idnum)
        {
            model.setIDNum(idnum);
        }

    }
}
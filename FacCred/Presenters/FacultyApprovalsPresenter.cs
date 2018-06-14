using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.Data;
using System.IO;

namespace FacCred.Presenters
{
    public class FacultyApprovalsPresenter
    {
        static FacultyApprovalsModel facultyApprovalsModel = new FacultyApprovalsModel();



        public DataSet getAllFacultyApprovals(string userID, string firstName, string lastName)
        {
            //same model call but returning the full dataset
            DataTable dt = facultyApprovalsModel.getAllFacultyApprovalsLIU(userID, firstName, lastName);
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoAllFacultyRecordsFound();

        }




        //APPROVER1   ------------------------------------------------------------------------------------------------

        public DataSet getYourApprover1Faculty(string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover1Faculty(userID,firstName,lastName);

            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoFacultyDisciplineFound();
        }


        public DataSet getYourApprover1FacultyDiscipline()
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover1FacultyDiscipline();

            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoFacultyDisciplineFound();
        }




        public DataSet getYourApprover1RecordsFaculty(string FACidnum, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover1RecordsFaculty(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable()
                .Where(x => x.Field<string>("FACidnum") == FACidnum);


            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoApprover1RecordsFound();
        }



        //APPROVER2  -------------------------------------------------------------------------------------------------------

        public DataSet getYourApprover2Faculty(string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover2Faculty(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoFacultyDisciplineFound();
        }
        public DataSet getYourApprover2FacultyDiscipline(string aprLevel, string yrcode, string trmcode, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover2FacultyDiscipline(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yrcde") == yrcode).Where(x => x.Field<string>("trmcde") == trmcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoRecordsFound();
        }

        //public DataSet getYourApprover2RecordsFaculty(string aprLevel, string yrcode, string trmcode)
        //{
        //    //same model call but using LINQ to filter 
        //    DataTable dt = facultyApprovalsModel.getApprover2Records(userID, firstName, lastName);

        //    var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yrcde") == yrcode).Where(x => x.Field<string>("trmcde") == trmcode).Where(x => x.Field<string>("FACidnum") == FACidnum);

        //    if (dataRow.Count<DataRow>() > 0)
        //    {
        //        DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
        //        DataSet ds = new DataSet();
        //        ds.Tables.Add(boundTable);

        //        return ds;
        //    }

        //    return rtnNoApprover2RecordsFound();
        //}

        public DataSet getYourApprover2RecordsFaculty(string FACidnum, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover2RecordsFaculty(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable()
                .Where(x => x.Field<string>("FACidnum") == FACidnum);


            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoApprover2RecordsFound();
        }


        //APPROVER3  --------------------------------------------------------------------------------------------------

        public DataSet getYourApprover3Faculty(string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover3Faculty(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoFacultyDisciplineFound();
        }

        public DataSet getYourApprover3FacultyDiscipline(string aprLevel, string yrcode, string trmcode, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover3FacultyDiscipline(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yrcde") == yrcode).Where(x => x.Field<string>("trmcde") == trmcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoRecordsFound();
        }

        //public DataSet getYourApprover3RecordsFaculty(string aprLevel, string yrcode, string trmcode, string FACidnum, string userID, string firstName, string lastName)
        //{
        //    //same model call but using LINQ to filter 
        //    DataTable dt = facultyApprovalsModel.getApprover3Records(userID, firstName, lastName);

        //    var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yrcde") == yrcode).Where(x => x.Field<string>("trmcde") == trmcode).Where(x => x.Field<string>("FACidnum") == FACidnum);

        //    if (dataRow.Count<DataRow>() > 0)
        //    {
        //        DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
        //        DataSet ds = new DataSet();
        //        ds.Tables.Add(boundTable);

        //        return ds;
        //    }

        //    return rtnNoRecordsFound();
        //}

        public DataSet getYourApprover3RecordsFaculty(string FACidnum, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getApprover3RecordsFaculty(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable()
                .Where(x => x.Field<string>("FACidnum") == FACidnum);


            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoApprover2RecordsFound();
        }




        //FACCRED USER  ------------------------------------------------------------------------------------------------
        public DataSet getYourFacCredUserFacultyDiscipline(string aprLevel, string yrcode, string trmcode, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getFacCredUserFacultyDiscipline(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yrcde") == yrcode).Where(x => x.Field<string>("trmcde") == trmcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoRecordsFound();
        }

        public DataSet getYourFacCredUserRecordsFaculty(string aprLevel, string yrcode, string trmcode, string FACidnum, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = facultyApprovalsModel.getFacCredUserRecords(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yrcde") == yrcode).Where(x => x.Field<string>("trmcde") == trmcode).Where(x => x.Field<string>("FACidnum") == FACidnum);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoRecordsFound();
        }


        //GENERAL  -----------------------------------------------------------------------------------------------------
        public bool InsertUpdateFacultyApproval(string approvalCode,
                                                string FACappid,
                                                string FACidnum,
                                                string div_cde,
                                                string instit_div_cde,
                                                string school_cde,
                                                string lastname,
                                                string firstname,
                                                string FACinstructorType,
                                                string approvalDate,
                                                string expirationDate,
                                                string modDate,
                                                string userlevel
                                            )
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.InsertUpdateFacultyApproval( approvalCode,
                                                                     FACappid,
                                                                     FACidnum,
                                                                     div_cde,
                                                                     instit_div_cde,
                                                                     school_cde,
                                                                     lastname,
                                                                     firstname,
                                                                     FACinstructorType,
                                                                     approvalDate,
                                                                     expirationDate,
                                                                     modDate,
                                                                     userlevel
                                                                        );

            return rtn;
        }


        //------------  INSTDIV  ---------------------------------------------------------------------

        public bool InsertFacultyInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                     string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.InsertFacultyInstDivRecords(approve, FACappid, FACidnum,   userlevel,  firstname, lastname, FACtype, approvaldate, expirationdate, moddate, instdiv);

            return rtn;
        }

        public bool UpdateFacultyInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.UpdateFacultyInstDivRecords(approve, FACappid, FACidnum,  userlevel,  firstname, lastname, FACtype,approvaldate, expirationdate, moddate, instdiv);

            

            return rtn;
        }

        //--------- DIVISION -----------------------------------------------------------------------------

        public bool InsertFacultyDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                        string FACtype, string approvaldate, string expirationdate, string moddate, string divcde)
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.InsertFacultyDivisionRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, divcde);

            return rtn;
        }

        public bool UpdateFacultyDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string divcde)
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.UpdateFacultyDivisionRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, divcde);



            return rtn;
        }

        //---------  SCHOOL CODE -------------------------------------------------------------------------


        public bool InsertFacultySchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                        string FACtype, string approvaldate, string expirationdate, string moddate, string schoolcde)
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.InsertFacultySchoolCodeRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, schoolcde);

            return rtn;
        }

        public bool UpdateFacultySchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string schoolcde)
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.UpdateFacultySchoolCodeRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, schoolcde);



            return rtn;
        }


        //---------  DISCIPLINE -------------------------------------------------------------------------


        public bool InsertFacultyDisciplineRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname,
                                                        string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.InsertFacultyDisciplineRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, instdiv);

            return rtn;
        }

        public bool UpdateFacultyDisciplineRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            bool rtn = false;

            rtn = facultyApprovalsModel.UpdateFacultyDisciplineRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, instdiv);



            return rtn;
        }



        public DataSet rtnNoApproverFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
        
            table1.Columns.Add("instdiv");
            table1.Columns.Add("yrcde");
            table1.Columns.Add("trmcde");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("approver");

            table1.Rows.Add("no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }


        public DataSet rtnNoRecordsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("crscde");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("yrcde");
            table1.Columns.Add("trmcde");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("approver");
            table1.Columns.Add("approver1");
            table1.Columns.Add("approver2");
            table1.Columns.Add("approver3");
            table1.Columns.Add("moddate");


            table1.Rows.Add("no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }


        public DataSet rtnNoAllFacultyRecordsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("divcode");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("schoolcode");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("approver1");
            table1.Columns.Add("approver2");
            table1.Columns.Add("approver3");
            table1.Columns.Add("approvalDate");
            table1.Columns.Add("expirationDate");
            table1.Columns.Add("moddate");

            table1.Rows.Add("","","no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }




        public DataSet rtnNoFacultyDisciplineFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("approver");

            table1.Rows.Add("","","","","no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }



        public DataSet rtnNoApprover2RecordsFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("FACdivcode");
            table1.Columns.Add("FACinstdiv");
            table1.Columns.Add("FACschoolcode");
            table1.Columns.Add("approver");
            table1.Columns.Add("approvalDate");
            table1.Columns.Add("expirationDate");

            table1.Rows.Add("", "", "no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }


        public DataSet rtnNoApprover1RecordsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("crscde");
            table1.Columns.Add("CRStitle");
            table1.Columns.Add("FACdivcode");
            table1.Columns.Add("FACinstdiv");
            table1.Columns.Add("FACschoolcode");
            table1.Columns.Add("yrcde");
            table1.Columns.Add("trmcde");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("approver");
            table1.Columns.Add("approver1");
            table1.Columns.Add("approver2");
            table1.Columns.Add("approver3");
            table1.Columns.Add("moddate");
            table1.Columns.Add("approvalDate");
            table1.Columns.Add("expirationDate");

            table1.Rows.Add("", "", "no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }




    }
}
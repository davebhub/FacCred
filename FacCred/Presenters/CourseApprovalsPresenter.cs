using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Models;
using System.Data;
using System.IO;


namespace FacCred.Presenters
{
    public class CourseApprovalsPresenter
    {
        static CourseApprovalsModel model = new CourseApprovalsModel();


        //public string approverLevelSQL(string username)
        //{
        //    string rtn = "";

        //    rtn = model.approverLevelSQL(username);

        //    return rtn;
        //}


        public DataSet getAllCourseApprovals()
        {
            //same model call but returning the full dataset
            DataTable dt = model.getAllCourseApprovals();
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoCourseRecordsFound();

        }

        public DataSet getAllCourseApprovalsYT(string yearcode, string termcode, string userID, string firstName, string lastName)
        {
            //same model call but returning the full dataset
            DataTable dt = model.getAllCourseApprovalsLIU(userID, firstName, lastName);
            DataSet ds = new DataSet();

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yearcode") == yearcode).Where(x => x.Field<string>("termcode") == termcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return rtnNoCourseRecordsFound();

        }


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
            bool rtn = false;

            rtn = model.InsertUpdateCourseApproval(approvalCode,
                                                    FACappid,
                                                    FACidnum,
                                                    SM_appid,
                                                    yearcode,
                                                    termcode,
                                                    div_cde,
                                                    instit_div_cde,
                                                    school_cde,
                                                    crs_cde,
                                                    crs_title,
                                                    lastname,
                                                    firstname,
                                                    FACinstructorType,
                                                    userlevel,
                                                    moddate);

            return rtn;
        }






        //-------  APPROVER1  ------------------------------------------------------------------

        //public DataSet getYourApprover1CoursesDiscipline(string aprLevel, string yearcode, string termcode, string userID, string firstName, string lastName)
        //{
        //    //same model call but using LINQ to filter 
        //    DataTable dt = model.getApprover1CoursesDiscipline(userID, firstName, lastName);

        //    var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yearcode") == yearcode).Where(x => x.Field<string>("termcode") == termcode);

        //    if (dataRow.Count<DataRow>() > 0)
        //    {
        //        DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
        //        DataSet ds = new DataSet();
        //        ds.Tables.Add(boundTable);

        //        return ds;
        //    }

        //    return rtnNoRecordsFound();
        //}

        public DataSet getYourApprover1CoursesSM(string aprLevel, string yearcode, string termcode, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getApprover1CoursesSM(yearcode, termcode, userID, firstName, lastName);

            //var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yearcode") == yearcode).Where(x => x.Field<string>("termcode") == termcode);
            var dataRow = dt.AsEnumerable();

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCourseRecordsFound();
        }

        public DataSet getYourApprover1Courses(string aprLevel, string yearcode, string termcode, string instdiv, string FACidnum, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getApprover1Courses(yearcode, termcode, userID , firstName, lastName);

            var dataRow = dt.AsEnumerable()
                .Where(x => x.Field<string>("FACidnum") == FACidnum)
                .Where(x => x.Field<string>("instdiv") == instdiv);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCourseRecordsFound();
        }


        //-------  APPROVER2  ------------------------------------------------------------------



        public DataSet getYourApprover2CoursesSM(string aprLevel, string yearcode, string termcode, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getApprover2CoursesSM(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yearcode") == yearcode).Where(x => x.Field<string>("termcode") == termcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCourseRecordsFound();
        }

        public DataSet getYourApprover2Courses(string aprLevel, string yearcode, string termcode, string instdiv, string FACidnum, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getApprover2Courses(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yearcode") == yearcode)
                .Where(x => x.Field<string>("termcode") == termcode)
                .Where(x => x.Field<string>("FACidnum") == FACidnum)
                .Where(x => x.Field<string>("instdiv") == instdiv);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCourseRecordsFound();
        }


        //-------  APPROVER3  ------------------------------------------------------------------


        public DataSet getYourApprover3CoursesSM(string aprLevel, string yearcode, string termcode, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getApprover3CoursesSM(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yearcode") == yearcode).Where(x => x.Field<string>("termcode") == termcode);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCourseRecordsFound();
        }

        public DataSet getYourApprover3Courses(string aprLevel, string yearcode, string termcode, string instdiv, string FACidnum, string userID, string firstName, string lastName)
        {
            //same model call but using LINQ to filter 
            DataTable dt = model.getApprover3Courses(userID, firstName, lastName);

            var dataRow = dt.AsEnumerable().Where(x => x.Field<string>("yearcode") == yearcode)
                .Where(x => x.Field<string>("termcode") == termcode)
                .Where(x => x.Field<string>("FACidnum") == FACidnum)
                .Where(x => x.Field<string>("instdiv") == instdiv);

            if (dataRow.Count<DataRow>() > 0)
            {
                DataTable boundTable = dataRow.CopyToDataTable<DataRow>();
                DataSet ds = new DataSet();
                ds.Tables.Add(boundTable);

                return ds;
            }

            return rtnNoCourseRecordsFound();
        }





        //----------  DIVISION  ------------------------------------------------------------------


        public bool InsertCourseDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname,  string moddate, string divcode)
        {
            bool rtn = false;
            rtn = model.InsertCourseDivisionRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname, moddate, divcode);

            return rtn;
        }

        public bool UpdateCourseDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname,  string moddate, string divcode)
        {
            bool rtn = false;
            rtn = model.UpdateCourseDivisionRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname, moddate, divcode);

            return rtn;
        }


        //----------  INST_DIV  ------------------------------------------------------------------


        public bool InsertCourseInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname, string moddate, string instdiv)
        {
            bool rtn = false;
            rtn = model.InsertCourseInstDivRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname, moddate, instdiv);

            return rtn;
        }

        public bool UpdateCourseInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname, string moddate, string instdiv)
        {
            bool rtn = false;
            rtn = model.UpdateCourseInstDivRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname, moddate, instdiv);

            return rtn;
        }
        //----------  SCHOOL CODE  ------------------------------------------------------------------


        public bool InsertCourseSchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname, string moddate, string schoolcode)
        {
            bool rtn = false;
            rtn = model.InsertCourseSchoolCodeRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname, moddate, schoolcode);

            return rtn;
        }

        public bool UpdateCourseSchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname,  string moddate, string schoolcode)
        {
            bool rtn = false;
            rtn = model.UpdateCourseSchoolCodeRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname,  moddate, schoolcode);

            return rtn;
        }



        //-------------------------------------------------------------------------------------------------

        public DataSet rtnNoApproverFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("crscde");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("yearcode");
            table1.Columns.Add("termcode");
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
            table1.Columns.Add("yearcode");
            table1.Columns.Add("termcode");
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

        public DataSet rtnNoApprovalRecordsFound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("crscde");
            table1.Columns.Add("CRStitle");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("yearcode");
            table1.Columns.Add("termcode");
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

        public DataSet rtnNoCourseRecordsFound()
        {
            DataTable table1 = new DataTable();

            table1.Columns.Add("FACappid");
            table1.Columns.Add("FACidnum");
            table1.Columns.Add("SM_appid");
            table1.Columns.Add("yearcode");
            table1.Columns.Add("termcode");
            table1.Columns.Add("divcode");
            table1.Columns.Add("instdiv");
            table1.Columns.Add("schoolcode");
            table1.Columns.Add("crscde");
            table1.Columns.Add("crstitle");
            table1.Columns.Add("FAClastname");
            table1.Columns.Add("FACfirstname");
            table1.Columns.Add("FACtype");
            table1.Columns.Add("approver");
            table1.Columns.Add("approver1");
            table1.Columns.Add("approver2");
            table1.Columns.Add("approver3");
            table1.Columns.Add("moddate");

            table1.Rows.Add("","","","no records found");

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }

    }


}
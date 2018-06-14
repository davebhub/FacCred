using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Presenters;
using FacCred.Views.Interfaces;
using System.Data;
using System.IO;

namespace FacCred.Views
{
    public class CourseApprovalsView : ICourseApprovalsView
    {
        static CourseApprovalsPresenter presenter = new CourseApprovalsPresenter();

        public DataSet getAllCourseApprovals()
        {
            DataSet ds = presenter.getAllCourseApprovals();
            return ds;
        }

        public DataSet getAllCourseApprovalsYT(string yearcode, string termcode, string userID, string firstName, string lastName)
        {
            DataSet ds = presenter.getAllCourseApprovalsYT(yearcode,termcode, userID, firstName, lastName);
            return ds;
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

            rtn = presenter.InsertUpdateCourseApproval(approvalCode,
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






        //-------APPROVER1 ----------------------------------------------------


        public DataSet getYourApprover1CoursesSM(string aprLevel, string year, string term, string userID, string firstName, string lastName)
        {
            DataSet ds = presenter.getYourApprover1CoursesSM(aprLevel, year, term, userID, firstName, lastName);
            return ds;
        }
        public DataSet getYourApprover1Courses(string aprLevel, string year, string term, string instdiv, string FACidnum, string userID, string firstName, string lastName)
        {
            DataSet ds = presenter.getYourApprover1Courses(aprLevel, year, term, instdiv, FACidnum, userID, firstName, lastName);
            return ds;
        }

        //-------APPROVER2 ----------------------------------------------------


        public DataSet getYourApprover2CoursesSM(string aprLevel, string year, string term, string userID, string firstName, string lastName)
        {
            DataSet ds = presenter.getYourApprover2CoursesSM(aprLevel, year, term, userID, firstName, lastName);
            return ds;
        }
        public DataSet getYourApprover2Courses(string aprLevel, string year, string term, string instdiv, string FACidnum, string userID, string firstName, string lastName)
        {
            DataSet ds = presenter.getYourApprover2Courses(aprLevel, year, term, instdiv, FACidnum, userID, firstName, lastName);
            return ds;
        }

        //-------APPROVER3 ----------------------------------------------------


        public DataSet getYourApprover3CoursesSM(string aprLevel, string year, string term, string userID, string firstName, string lastName)
        {
            DataSet ds = presenter.getYourApprover3CoursesSM(aprLevel, year, term, userID, firstName, lastName);
            return ds;
        }
        public DataSet getYourApprover3Courses(string aprLevel, string year, string term, string instdiv, string FACidnum, string userID, string firstName, string lastName)
        {
            DataSet ds = presenter.getYourApprover3Courses(aprLevel, year, term, instdiv, FACidnum, userID, firstName, lastName);
            return ds;
        }

        //-----------------  DIVISION -------------------------------------------------------

        public bool InsertCourseDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname, string moddate, string divcode)
        {
            bool rtn = false;
            rtn = presenter.InsertCourseDivisionRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname, moddate, divcode);

            return rtn;
        }

        public bool UpdateCourseDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname, string moddate, string divcode)
        {
            bool rtn = false;
            rtn = presenter.UpdateCourseDivisionRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname, moddate, divcode);

            return rtn;
        }


        //-------------- INST_DIV  --------------------------------------------------

        public bool InsertCourseInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname,  string moddate, string instdiv)
        {
            bool rtn = false;
            rtn = presenter.InsertCourseInstDivRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname,  moddate, instdiv);

            return rtn;
        }

        public bool UpdateCourseInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname,  string moddate, string instdiv)
        {
            bool rtn = false;
            rtn = presenter.UpdateCourseInstDivRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname, moddate, instdiv);

            return rtn;
        }




        //-------------- SCHOOL CODE  --------------------------------------------------

        public bool InsertCourseSchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname,  string moddate, string schoolcode)
        {
            bool rtn = false;
            rtn = presenter.InsertCourseSchoolCodeRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname,  moddate, schoolcode);

            return rtn;
        }

        public bool UpdateCourseSchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string yearcode, string termcode, string firstname, string lastname, string moddate, string schoolcode)
        {
            bool rtn = false;
            rtn = presenter.UpdateCourseSchoolCodeRecords(approve, FACappid, FACidnum, userlevel, yearcode, termcode, firstname, lastname,  moddate, schoolcode);

            return rtn;
        }





    }
}
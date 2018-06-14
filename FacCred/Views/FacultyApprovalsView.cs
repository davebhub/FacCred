using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Presenters;
using FacCred.Views.Interfaces;
using System.Data;
using System.IO;
using Jenzabar.Portal.Web.WebApiControllers;

namespace FacCred.Views
{
    public class FacultyApprovalsView
    {
        static FacultyApprovalsPresenter facultyApprovalsPresenter = new FacultyApprovalsPresenter();

        public DataSet getAllFacultyApprovalsLIU(string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getAllFacultyApprovals(userID, firstName, lastName);
            return ds;
        }




        //  APPROVER1


        public DataSet getYourApprover1Faculty(string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover1Faculty(userID, firstName, lastName);
            return ds;
        }

        public DataSet getYourApprover1FacultyDiscipline()
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover1FacultyDiscipline();
            return ds;
        }


        public DataSet getYourApprover1RecordsFaculty(string FACidnum, string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover1RecordsFaculty(FACidnum, userID, firstName, lastName);
            return ds;
        }





        //APPROVER2

        public DataSet getYourApprover2Faculty(string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover2Faculty(userID, firstName, lastName);
            return ds;
        }
        public DataSet getYourApprover2FacultyDiscipline(string aprLevel, string year, string term, string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover2FacultyDiscipline(aprLevel, year, term, userID, firstName, lastName);
            return ds;
        }
        public DataSet getYourApprover2RecordsFaculty(string FACidnum, string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover2RecordsFaculty(FACidnum, userID, firstName, lastName);
            return ds;
        }



        //APPROVER3

        public DataSet getYourApprover3Faculty(string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover3Faculty(userID, firstName, lastName);
            return ds;
        }
        public DataSet getYourApprover3FacultyDiscipline(string aprLevel, string year, string term, string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover3FacultyDiscipline(aprLevel, year, term, userID, firstName, lastName);
            return ds;
        }

        public DataSet getYourApprover3RecordsFaculty(string FACidnum, string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourApprover3RecordsFaculty(FACidnum, userID, firstName, lastName);
            return ds;
        }



        //FACCRED USER
        public DataSet getYourFacCredUserFacultyDiscipline(string aprLevel, string year, string term , string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourFacCredUserFacultyDiscipline(aprLevel, year, term, userID, firstName, lastName);
            return ds;
        }

        public DataSet getYourFacCredRecordsFaculty(string aprLevel, string year, string term, string idnum, string userID, string firstName, string lastName)
        {
            DataSet ds = facultyApprovalsPresenter.getYourFacCredUserRecordsFaculty(aprLevel, year, term, idnum, userID, firstName, lastName);
            return ds;
        }


        //GENERAL 

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

            rtn = facultyApprovalsPresenter.InsertUpdateFacultyApproval(approvalCode,
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




         //-----------------   INSTDIV    ---------------------------------------------------------------------------

        public bool InsertFacultyInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            bool rtn = false;

            rtn = facultyApprovalsPresenter.InsertFacultyInstDivRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, instdiv);

            return rtn;
        }

        public bool UpdateFacultyInstDivRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            bool rtn = false;

            rtn = facultyApprovalsPresenter.UpdateFacultyInstDivRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, instdiv);

            return rtn;
        }


        //-----------------   DIVISION    ---------------------------------------------------------------------------

        public bool InsertFacultyDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string divcde)
        {
            bool rtn = false;

            rtn = facultyApprovalsPresenter.InsertFacultyDivisionRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, divcde);

            return rtn;
        }

        public bool UpdateFacultyDivisionRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string divcde)
        {
            bool rtn = false;

            rtn = facultyApprovalsPresenter.UpdateFacultyDivisionRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, divcde);

            return rtn;
        }

        //-----------------   SCHOOL CODE    ---------------------------------------------------------------------------

        public bool InsertFacultySchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string schoolcde)
        {
            bool rtn = false;

            rtn = facultyApprovalsPresenter.InsertFacultySchoolCodeRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, schoolcde);

            return rtn;
        }

        public bool UpdateFacultySchoolCodeRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string schoolcde)
        {
            bool rtn = false;

            rtn = facultyApprovalsPresenter.UpdateFacultySchoolCodeRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, schoolcde);

            return rtn;
        }

        //-----------------   DISCIPLINE   ---------------------------------------------------------------------------

        public bool InsertFacultyDisciplineRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            bool rtn = false;

            rtn = facultyApprovalsPresenter.InsertFacultyDisciplineRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, instdiv);

            return rtn;
        }

        public bool UpdateFacultyDisciplineRecords(string approve, string FACappid, string FACidnum, string userlevel, string firstname, string lastname, string FACtype, string approvaldate, string expirationdate, string moddate, string instdiv)
        {
            bool rtn = false;

            rtn = facultyApprovalsPresenter.UpdateFacultyDisciplineRecords(approve, FACappid, FACidnum, userlevel, firstname, lastname, FACtype, approvaldate, expirationdate, moddate, instdiv);

            return rtn;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Presenters;
using System.Data;
using System.IO;

namespace FacCred.Views
{
    public class DropDownView
    {

        static DropDownPresenter presenter = new DropDownPresenter();

        public DataSet getYears()
        {
            DataSet ds  = presenter.getYears();
            return ds;
        }

        public DataSet getTerms()
        {
            DataSet ds = presenter.getTerms();
            return ds;
        }

        public DataSet getApprovalCodes()
        {
            DataSet ds = presenter.getApprovalCodes();
            return ds;
        }

        public DataSet getStatusCodes()
        {
            DataSet ds = presenter.getStatusCodes();
            return ds;
        }

        public DataSet getNoteTypes()
        {
            DataSet ds = presenter.getNoteTypes();
            return ds;
        }

        public DataSet getNoteTypes_filter()
        {
            DataSet ds = presenter.getNoteTypes_filter();
            return ds;
        }

        public DataSet getNoteLevels()
        {
            DataSet ds = presenter.getNoteLevels();
            return ds;
        }

        public DataSet getNoteLevels_filter()
        {
            DataSet ds = presenter.getNoteLevels_filter();
            return ds;
        }


        public DataSet getInstDivisions()
        {
            DataSet ds = presenter.getInstDivisions();

            return ds;
        }

        public DataSet getInstDivisionsUserAccess(string userID)
        {
            DataSet ds = presenter.getInstDivisionsUserAccess(userID);

            return ds;
        }

        public DataSet getSchoolCodeUserAccess(string userID)
        {
            DataSet ds = presenter.getSchoolCodeUserAccess(userID);

            return ds;
        }

        public DataSet getDivisions()
        {
            DataSet ds = presenter.getDivisions();

            return ds;
        }

        public DataSet getSchoolCodes()
        {
            DataSet ds = presenter.getSchoolCodes();

            return ds;
        }



        public DataSet getSpecificDivisions(string idnum, string yearcode, string termcode)
        {
            DataSet ds = presenter.getSpecificDivisions(idnum, yearcode, termcode);

            return ds;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Presenters;
using FacCred.Views.Interfaces;
using System.Data;

namespace FacCred.Views
{
    public partial class FacultyView : IFacultyView
    {

        static FacultyPresenter presenter = new FacultyPresenter();


        public DataTable getDataSQLByID(string FACidnum, string year, string term)
        {
            
            DataTable dt = presenter.getDataSQLByID(FACidnum, year, term);
            return dt;
        }

        public DataSet getDataSQLDataSet(string year, string term)
        {
            DataSet ds = presenter.getDataSQLDataSet(year, term);
            return ds;
        }

        public void ExecuteFacultyReset()
        {
            presenter.ExecuteFacultyRefresh();
        }

        public DataTable getUserAccessFaculty(string userID, string firstName, string lastName, string year, string term)
        {
            DataTable dt = presenter.getUserAccessFaculty(userID, firstName, lastName, year, term);
            return dt;
        }


        public DataTable getFacultyXREF(string FACappid, string FACidnum)
        {
            DataTable dt = presenter.getFacultyXREF(FACappid, FACidnum);

            return dt;
        }


        public bool insertOneFacultyXREF(Guid xref_id, string FACappid, string FACidnum, string divcode, string instdiv, string schoolcode)
        {
            return presenter.insertOneFacultyXREF(xref_id, FACappid, FACidnum, divcode, instdiv, schoolcode);
        }

        public bool deleteOneFacultyXREF(Guid id)
        {
            return presenter.deleteOneFacultyXREF(id);
        }


    }
}
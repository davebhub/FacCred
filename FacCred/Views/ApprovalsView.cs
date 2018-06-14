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
    public class ApprovalsView : IApprovalsView
    {
        static ApprovalsPresenter presenter = new ApprovalsPresenter();

        public DataSet getAllFacultyApprovals()
        {
            DataSet ds = presenter.getAllFacultyApprovals();
            return ds;
        }

        public DataSet getAllCourseApprovals()
        {
            DataSet ds = presenter.getAllCourseApprovals();
            return ds;
        }



        public DataSet getFacultyApprovalsByYT(string year, string term)
        {
            DataSet ds = presenter.getFacultyApprovalsByYT(year, term);
            return ds;
        }



        public string approverLevelSQL(string firstName, string lastName)
        {
            string rtn = "";

            rtn = presenter.approverLevelSQL(firstName, lastName);

            return rtn;
        }

    }
}
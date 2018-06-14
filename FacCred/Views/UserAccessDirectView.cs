using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FacCred.Views.Interfaces;
using FacCred.Presenters;

namespace FacCred.Views
{
    public class UserAccessDirectView : IUserAccessDirectView
    {
        static UserAccessDirectPresenter presenter = new UserAccessDirectPresenter();

        public DataSet getDataSQLDataSet()
        {
            throw new NotImplementedException();
        }

       
        public DataSet AllUserAccessSQL()
        {
            DataSet ds = presenter.AllUserAccessSQL();
            return ds;
        }

        public DataSet GetOneUserDirectAccess(string userid)
        {
            DataSet ds = presenter.GetOneUserDirectAccess(userid);
            return ds;
        }

        public bool DeleteOneUserDirectAccess(string id)
        {
            bool rtn = presenter.DeleteOneUserDirectAccess(id);

            return rtn;

        }

        public bool InsertOneRecordDirectAccess(Guid id, string userid, string firstname, string lastname,
            string schoolcode)
        {
            bool rtn = presenter.InsertOneRecordDirectAccess(id, userid, firstname, lastname, schoolcode);

            return rtn;
        }


    }
}
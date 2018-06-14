using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacCred.Presenters;
using FacCred.Views.Interfaces;
using System.Data;

namespace FacCred.Views
{
    public partial class CredentialsView : ICredentialsView
    {

        static CredentialsPresenter presenter = new CredentialsPresenter();

        public DataSet getDataSQLByID(string idnum)
        {
            
            DataSet ds = presenter.getDataSQLByID(idnum);
            return ds;
        }

        public DataSet getDataSQLDataSet()
        {
            DataSet ds = presenter.getDataSQLDataSet();
            return ds;
        }

        public DataSet getNotesSQLDataSet()
        {
            DataSet ds = presenter.getNotesSQLDataSet();
            return ds;
        }
        public DataSet getNotesSQLDataSetID(string idnum)
        {
            DataSet ds = presenter.getNotesSQLDataSetID(idnum);
            return ds;
        }

        public DataSet getPXCoursesSQLDataSet()
        {
            DataSet ds = presenter.getPXCoursesSQLDataSet();
            return ds;
        }


        public DataSet getPXCodesSQLDataSet()
        {
            DataSet ds = presenter.getPXCodesSQLDataSet();
            return ds;
        }

        public DataSet getACAD_CRED_SQLDataSet()
        {
            DataSet ds = presenter.getACAD_CREDSQLDataSet();
            return ds;
        }

        public DataSet getCOPY_OL_SQLDataSet()
        {
            DataSet ds = presenter.getCOPY_OL_SQLDataSet();
            return ds;
        }

        public DataSet getCREDITSQLDataSet()
        {
            DataSet ds = presenter.getCREDIT_SQLDataSet();
            return ds;
        }


        public DataSet getOTHER_QUALSQLDataSet()
        {
            DataSet ds = presenter.getOTHER_QUAL_SQLDataSet();
            return ds;
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
                presenter.InsertUpdateNote(note_id,
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





        public void setIDNum(string idnum)
        {
            presenter.setIDNum(idnum);
        }

        public string getIDNum()
        {
            return presenter.getIDNum();
        }
    }
}
using System;
using System.Data;
using Jenzabar.Portal.Framework.Web.UI;
using FacCred.Presenters;


namespace FacCred.Screens
{
    public partial class DataTableTest : PortletViewBase
    {
        EDUEarnHistPresenter presenter = new EDUEarnHistPresenter();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e); 

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string conn =
            ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);

            SqlCommand cmd = new SqlCommand("SPState", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.Dispose();
            */

            DataTable dt = presenter.getDataSQLByID();

            grdDegrees.DataSource = dt;
            grdDegrees.DataBind();
        }

        protected void LoadNextView(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("DefaultView");
        }

    }
}
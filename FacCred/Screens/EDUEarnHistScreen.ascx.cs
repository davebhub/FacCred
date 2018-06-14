using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jenzabar.Portal.Framework.Web.UI;
using System.IO;
using FacCred.Views;
using System.Data;
using Jenzabar.Portal.Framework;

namespace FacCred.Screens
{
    public partial class EDUEarnHistScreen : PortletViewBase
    {
        EDUEarnHistView eduView = new EDUEarnHistView();


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            //display the selected faculty member
            //if (Session["newSearch"].ToString() == "false")
            //{
            //    searchFacName.Text = "Faculty Member: " + Session["firstname"].ToString() + " " + Session["lastname"].ToString();
            //}
            //else
            //{
            //    searchFacName.Text = "All Faculty Members";
            //}

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            ParentPortlet.PreviousScreen();
        }


        protected void btnFetch_clicked(object sender, EventArgs e)
        {

        }

        protected void gv_grdDegrees_PreRender(object sender, EventArgs e)
        {

            gv_grdDegrees.DataSource = eduView.getDataSQLByID(Session["FACappid"].ToString(), Session["FACidnum"].ToString());
            gv_grdDegrees.DataBind();



            if (gv_grdDegrees.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_grdDegrees.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_grdDegrees.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_grdDegrees.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }

        protected void gv_grdDegrees_IndexChanging(object sender, EventArgs e)
        {

        }

        //      onrowcommand="gv_grdDegrees_RowCommand"  
        protected void gv_grdDegrees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_grdDegrees.Rows[rowIndex];

            //Session["Nfirstname"] = row.Cells[1].Text;
            //Session["Nlastname"] = row.Cells[2].Text;
            //Session["Nsubject"] = row.Cells[3].Text;
            //Session["Nnote"] = row.Cells[4].Text;
            //Session["Ncreated"] = row.Cells[5].Text;
            //Session["Nstatus"] = row.Cells[6].Text;
            //Session["Naprdate"] = row.Cells[7].Text;
            //Session["Nexpdate"] = row.Cells[8].Text;
            //Session["Nupddate"] = row.Cells[9].Text;
            //Session["Nupdby"] = row.Cells[10].Text;
            //Session["Ninstdiv"] = row.Cells[11].Text;
            //Session["Nyear"] = row.Cells[12].Text;
            //Session["Nterm"] = row.Cells[13].Text;
            //Session["Ncrsappid"] = row.Cells[14].Text;
            //Session["Ncourse"] = row.Cells[15].Text;
            //Session["Nfacidnum"] = row.Cells[16].Text;
            //Session["Nfacappid"] = row.Cells[17].Text;
            //Session["Nfactype"] = row.Cells[18].Text;
            //Session["Nusername"] = row.Cells[19].Text;
            //Session["Nssn"] = row.Cells[20].Text;
            //Session["Nolddivcode"] = row.Cells[21].Text;


            switch (cmdName)
            {
                case "gv_grdDegrees_Select":
                    {
                        //if (row.Cells[17].Text == "no data found")
                        //{
                        //    //die sucker !
                        //}
                        //else
                        //{
                        //    ParentPortlet.NextScreen("NotesUpdateScreen");
                        //}
                    }
                    break;
                case "gv_Your_Approvals_Remarks":
                    {

                    }
                    break;
            }
        }




        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {


            // Get the currently selected row using the SelectedRow property.


            /*
            GridViewRow row = this.GridView3.SelectedRow;
            this.IDtxt.Text = row.Cells[0].Text;
            this.NAMEtxt.Text = row.Cells[1].Text;
            this.DESCtxt.Text = row.Cells[2].Text;
            */
        }








    }
}
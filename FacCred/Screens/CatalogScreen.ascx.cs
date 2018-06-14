using System;
using Jenzabar.Portal.Framework.Web.UI;
using FacCred.Views;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using FacCred.Models.Interfaces;
using FacCred.Models;
using System.Data;
using FacCred.Views.Interfaces;
using FacCred.Presenters;
using System.Web;
using Jenzabar.Portal.Framework;

namespace FacCred.Screens
{
    public partial class CatalogScreen : PortletViewBase
    {
        static CatalogView catalogview = new CatalogView();
        //static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            //display the selected faculty member
            searchFacName.Text = "";
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
            //word
        }

        protected void lb_newSearch_click(object sender, EventArgs e)
        {
            Session["newSearch"] = "true";
            searchFacName.Text = "";
        }

        protected void gv_Catalog_IndexChanging(object sender, EventArgs e)
        {
            //word
        }

        //gv_Catalog    ----------------------------------------------------------------------------
        protected void gv_Catalog_PreRender(object sender, EventArgs e)
        {

            //if (Session["newSearch"].ToString() == "false")
            //{
            //    //gv_Catalog.DataSource = catalogview.getDataSQLByID(Session["facidnum"].ToString());
            //   // gv_Catalog.DataBind();
            //}
            //else
            //{


            //}


            gv_Catalog.DataSource = catalogview.getDataSQLDataSet();
            gv_Catalog.DataBind();


            if (gv_Catalog.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Catalog.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Catalog.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Catalog.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            startLoad();
        }



        protected void gv_Catalog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Catalog.Rows[rowIndex];

            // FACULTY VALUES:
            //Session["facappid"] = row.Cells[1].Text;
            //Session["facidnum"] = row.Cells[2].Text;
            //Session["lastname"] = row.Cells[3].Text;
            //Session["firstname"] = row.Cells[4].Text;
            //Session["certification"] = row.Cells[5].Text;
            //Session["insttype"] = row.Cells[6].Text;
            //Session["capacity"] = row.Cells[7].Text;
            //Session["conflict"] = row.Cells[8].Text;
            //Session["requisite"] = row.Cells[9].Text;


            switch (cmdName)
            {
                case "gv_Catalog_Select":
                    {
                       // Session["newSearch"] = "false";
                        //if (Session["userLevel"].ToString() == "Approver1" || Session["userLevel"].ToString() == "Approver2" || Session["userLevel"].ToString() == "Approver3")
                        //{
                        //    ParentPortlet.NextScreen("UpdateScreen");
                        //}
                    }
                    break;
                case "gv_Catalog_Note":
                    {
                        //Session["facnote"] = "";
                        //ParentPortlet.NextScreen("FacultyNoteScreen");
                    }
                    break;
            }
        }


    }
}
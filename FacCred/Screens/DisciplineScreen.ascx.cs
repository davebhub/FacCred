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
    public partial class DisciplineScreen : PortletViewBase
    {
        static DisciplineView disciplineview = new DisciplineView();
        static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            startLoad();
        }

        protected void startLoad()
        {

            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            //display the selected faculty member
            if (Session["newSearch"].ToString() == "false")
            {
                searchFacName.Text = "Faculty Member: " + Session["FACfirstname"].ToString() + " " + Session["FAClastname"].ToString();
            }
            else
            {
                searchFacName.Text = "All Faculty Members";
            }

             searchDiscipline.Text = Session["FACinstdiv"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //word
        }

        protected void lb_newDisciplineSearch_click(object sender, EventArgs e)
        {
            Session["CATdiv"] = "";
            Session["CATdivdesc"] = "";
            Session["CATinstdiv"] = "";
            Session["CATinstdivdesc"] = "";
            Session["CATschoolcde"] = "";
            //Session["FACinstdiv"] = "DISCIPLINE: Not Selected ";
            //searchDiscipline.Text = "DISCIPLINE: Not Selected ";
        }

        //gv_Discipline    ----------------------------------------------------------------------------
        protected void gv_Discipline_PreRender(object sender, EventArgs e)
        {
            if (Session["CATdiv"].ToString() == "")
            {
                gv_Discipline.DataSource = disciplineview.getDataSQLDataSet();
                gv_Discipline.DataBind();
            }
            else if (Session["CATschoolcde"].ToString() == "&nbsp;" && Session["CATinstdiv"].ToString() == "&nbsp;") 
            {
                gv_Discipline.DataSource = disciplineview.getDataSQLByD(Session["CATdiv"].ToString());
                gv_Discipline.DataBind();
            }
            else if (Session["CATschoolcde"].ToString() == "&nbsp;") 
            {
                gv_Discipline.DataSource = disciplineview.getDataSQLByDI(Session["CATdiv"].ToString(), Session["CATinstdiv"].ToString());
                gv_Discipline.DataBind();
            }
            else
            {
                gv_Discipline.DataSource = disciplineview.getDataSQLByDIS(Session["CATdiv"].ToString(), Session["CATinstdiv"].ToString(), Session["CATschoolcde"].ToString());
                gv_Discipline.DataBind();
            }


            if (gv_Discipline.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Discipline.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Discipline.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Discipline.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }

        protected void gv_Discipline_IndexChanging(object sender, EventArgs e)
        {
            //word
        }

        protected void gv_Discipline_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Discipline.Rows[rowIndex];

            // DISCIPLINE VALUES:
            Session["CATdiv"] = row.Cells[1].Text;
            Session["CATdivdesc"] = row.Cells[2].Text;
            Session["CATinstdiv"] = row.Cells[3].Text;
            Session["CATinstdivdesc"] = row.Cells[4].Text;
            Session["CATschoolcde"] = row.Cells[5].Text;

            switch (cmdName)
            {
                case "gv_Discipline_Select":
                    {
                        searchDiscipline.Text = "DISCIPLINE: " + Session["CATdiv"].ToString() + " : " + Session["CATinstdiv"].ToString() + " : " + Session["CATschoolcde"].ToString();
                        Session["FACinstdiv"] = searchDiscipline.Text ;

                        //if (Session["userLevel"].ToString() == "Approver1" || Session["userLevel"].ToString() == "Approver2" || Session["userLevel"].ToString() == "Approver3")
                        //{
                        //    ParentPortlet.NextScreen("UpdateScreen");
                        //}
                    }
                    break;
                case "gv_Course_Note":
                    {
                        Session["coursenote"] = "";
                        // ParentPortlet.NextScreen("CoursesNoteScreen");
                    }
                    break;
            }
        }


    }
}
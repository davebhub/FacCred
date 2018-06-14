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
    public partial class CoursesScreen : PortletViewBase
    {
        static CoursesView coursesview = new CoursesView();
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
            //if (Session["newSearch"].ToString() == "false")
            //{
            //    searchFacName.Text = "Faculty Member: " + Session["FACfirstname"].ToString() + " " + Session["FAClastname"].ToString();
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

        protected void lb_newCourseSearch_click(object sender, EventArgs e)
        {
            //if (Session["newSearch"].ToString() == "true" )
            //{
            //    Session["FACidnum"] = "";
            //}

            //Session["CRSappid"] = "";
            //lb_newCourseSearch.Visible = true;
        }

        //gv_Courses    ----------------------------------------------------------------------------
        protected void gv_Courses_PreRender(object sender, EventArgs e)
        {
            //if ( Session["CRSappid"].ToString().Length > 0 && Session["FACidnum"].ToString().Length > 0)
            //{
            //    gv_Courses.DataSource = coursesview.getDataSQLByCIDYT(Session["CRSappid"].ToString(), Session["FACidnum"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Courses.DataBind();
            //}
            //else if ( Session["FACidnum"].ToString().Length > 0 && Session["CRSappid"].ToString().Length == 0) 
            //{

            //    gv_Courses.DataSource = coursesview.getDataSQLByIDYT(Session["FACidnum"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //    gv_Courses.DataBind();
            //}
            //else
            //{
                gv_Courses.DataSource = coursesview.getDataSQLByYT(Session["yearcode"].ToString(), Session["termcode"].ToString());
                gv_Courses.DataBind();
            //}


            if (gv_Courses.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Courses.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Courses.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Courses.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }

        protected void gv_Courses_IndexChanging(object sender, EventArgs e)
        {
            //word
        }

        protected void gv_Courses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Courses.Rows[rowIndex];

            // COURSE VALUES:
            Session["FACidnum"] = row.Cells[10].Text;
            Session["FAClastname"] = row.Cells[8].Text;
            Session["FACfirstname"] = row.Cells[9].Text;
            Session["CRSyearcode"] = row.Cells[2].Text;
            Session["CRStermcode"] = row.Cells[3].Text;
            Session["CSRdesc"] = row.Cells[1].Text;
            //Session["FACload"] = row.Cells[8].Text;
            //Session["FAClead"] = row.Cells[9].Text;
            Session["CRSappid"] = row.Cells[11].Text;
            Session["CRSinstdiv"] = row.Cells[6].Text;
            Session["CRSschoolcode"] = row.Cells[7].Text;

            switch (cmdName)
            {
                case "gv_Courses_Select":
                    {


                        //lb_newCourseSearch.Visible = true;
                        //Session["newSearch"] = "false";
                        //Session["newCourseSearch"] = "false";
                        //Session["courseSelected"] = "true";
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
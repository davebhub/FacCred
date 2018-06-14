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
    public partial class NotesScreen : PortletViewBase
    {
        static CredentialsView credentialsview = new CredentialsView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            //display the selected faculty member, or all faculty and turn on button to create new faculty 
            //if (Session["newSearch"].ToString() == "false")
            //{
            //    lb_NewNote.Visible = true;
            //    searchFacName.Text = "Faculty Member: " + Session["FACfirstname"].ToString() + " " + Session["FAClastname"].ToString();

               //// if the user has also selected a course then turn on the new course note button
               //if (Session["CRSappid"].ToString() == "")
               // {
               //     lb_NewNote.Visible = false;
               // }
               // else 
               // {
               //     lb_NewCourseNote.Visible = true;
               // } 
            //}
            //else
            //{
            //    lb_NewNote.Visible = false;
            //    //lb_NewCourseNote.Visible = false;
            //    searchFacName.Text = "All Faculty Members";
            //}

            searchDiscipline.Text = Session["FACinstdiv"].ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lb_NewNote_click(object sender, EventArgs e)
        {
            //ParentPortlet.NextScreen("FacultyNoteScreen");
            ParentPortlet.NextScreen("NotesUpdateScreen");
        }
        protected void lb_NewCourseNote_click(object sender, EventArgs e)
        {
            //ParentPortlet.NextScreen("CourseNotesScreen");
        }

        protected void gv_Notes_PreRender(object sender, EventArgs e)
        {
            if (Session["newSearch"].ToString() == "false")
            {
                gv_Notes.DataSource = credentialsview.getNotesSQLDataSetID(Session["FACidnum"].ToString() );
                gv_Notes.DataBind();
            }
            else
            {
                gv_Notes.DataSource = credentialsview.getNotesSQLDataSet();
                gv_Notes.DataBind();
            }


            if (gv_Notes.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Notes.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Notes.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Notes.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }


        protected void gv_Notes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Notes.Rows[rowIndex];

            Session["FACfirstname"] = row.Cells[1].Text;
            Session["FAClastname"] = row.Cells[2].Text;
            Session["NOTEsubject"] = row.Cells[3].Text;
            Session["NOTEnote"] = row.Cells[4].Text;
            Session["NOTEcreated"] = row.Cells[5].Text;
            Session["NOTEstatus"] = row.Cells[6].Text;
            Session["NOTEaprdate"] = row.Cells[7].Text;
            Session["NOTEexpdate"] = row.Cells[8].Text;
            Session["NOTEupddate"] = row.Cells[9].Text;
            Session["NOTEupdby"] = row.Cells[10].Text;
            Session["CRSinstdiv"] = row.Cells[11].Text;
            Session["NOTEyear"] = row.Cells[12].Text;
            Session["NOTEterm"] = row.Cells[13].Text;
            Session["CRSappid"] = row.Cells[14].Text;
            Session["CRSdesc"] = row.Cells[15].Text;
            Session["FACidnum"] = row.Cells[16].Text;
            Session["FACappid"] = row.Cells[17].Text;
            Session["FACinstructorType"] = row.Cells[18].Text;           
            Session["NOTEusername"] = row.Cells[19].Text;
            Session["FACssn"] = row.Cells[20].Text;
            Session["PXolddivcode"] = row.Cells[21].Text;
           // Session["NOTEid"] = row.Cells[22].Text;


            switch (cmdName)
            {
                case "gv_Notes_select":
                    {
                        if (row.Cells[17].Text == "no data found") 
                        {
                            //die sucker !
                        }
                        else
                        {
                            ParentPortlet.NextScreen("NotesUpdateScreen");
                        }                      
                    }
                    break;
                case "gv_Your_Approvals_Remarks":
                    {

                    }
                    break;
            }
        }

        protected void gv_Notes_IndexChanging(object sender, EventArgs e)
        {

        }

        

    }
}
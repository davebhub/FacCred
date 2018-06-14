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
    public partial class FacultyScreen : PortletViewBase
    {
        static FacultyView facultyview = new FacultyView();
        static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            if (Session["userLevel"].ToString() == "FacCredAdmin")
            {
                btn_Faculty_Refresh.Visible = true;
            }
            else
            {
                btn_Faculty_Refresh.Visible = false;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //word
        }


        protected void btn_Faculty_Refresh_Click(object sender, EventArgs e)
        {
            if (Session["userLevel"].ToString() == "FacCredAdmin")
            {
                facultyview.ExecuteFacultyReset();
                ParentPortlet.ShowFeedback(FeedbackType.Success, "Faculty Successfully Refreshed");
            }
            else
            {
                ParentPortlet.ShowFeedback(FeedbackType.Error, "FacCredAdmin must run this process");
            }

        }

        protected void gv_Approvals_IndexChanging(object sender, EventArgs e)
        {
            //word
        }

        //gv_Faculty    ----------------------------------------------------------------------------
        protected void gv_Faculty_PreRender(object sender, EventArgs e)
        {


           // if (PortalUser.Current.DisplayName == "FacCredAdmin" || PortalUser.Current.DisplayName == "Administrator Administrator")
            if (Session["userLevel"].ToString() == "FacCredAdmin") 
            {
                gv_Faculty.DataSource = facultyview.getDataSQLDataSet(Session["yearcode"].ToString(), Session["termcode"].ToString());
                gv_Faculty.DataBind();
            }
            else
            {
                gv_Faculty.DataSource = facultyview.getUserAccessFaculty(Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString() );
                gv_Faculty.DataBind();
            }

 

            if (gv_Faculty.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Faculty.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Faculty.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Faculty.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            startLoad();
        }

        protected void gv_Faculty_IndexChanging(object sender, EventArgs e)
        {
            //word
        }

        protected void gv_Faculty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Faculty.Rows[rowIndex];

            Session["FACappid"] = (string)this.gv_Faculty.DataKeys[rowIndex]["FACappid"];
            Session["FACidnum"] = (string)this.gv_Faculty.DataKeys[rowIndex]["FACidnum"];

            // FACULTY VALUES:
            Session["FAClastname"] = row.Cells[0].Text;
            Session["FACfirstname"] = row.Cells[1].Text;
            Session["FACinstructorType"] = row.Cells[2].Text;
            Session["FACdivcode"] = row.Cells[3].Text;
            Session["FACinstdiv"] = row.Cells[4].Text;
            Session["FACschoolcode"] = row.Cells[5].Text;



            //CLEAR OUT the Course Fields
            Session["CRSDesc"] = "";
            Session["CRSappid"] = "";
            Session["FACload"] = "";
            Session["FAClead"] = "";
            Session["CRSinstdiv"] = "";
            Session["CRSschoolcode"] = "";
  


            switch (cmdName)
            {

                case "gv_Faculty_Note":
                    {
                        Session["NOTEnote"] = "";
                        ParentPortlet.NextScreen("FacultyNoteScreen");
                    }
                    break;
                case "gv_Faculty_Discipline":
                    {
                        if (Session["userLevel"].ToString() != "FacCredUser" )
                        {
                            ParentPortlet.NextScreen("DisciplineUpdateScreen");
                        }
                        else
                        {
                            ParentPortlet.ShowFeedback(FeedbackType.Message, "Only for Approvers");
                        }
                        
                    }
                    break;
                case "gv_Faculty_Degree":
                    {
                        ParentPortlet.NextScreen("EDUEarnHistScreen");
                    }
                    break;
            }
        }


    }
}
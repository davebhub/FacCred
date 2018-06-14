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
    public partial class EXCredentialsScreen : PortletViewBase
    {
        static CredentialsView view = new CredentialsView();


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;

            if (Session["newSearch"].ToString() == "false")
            {
                facMember.Visible = true;
                searchFacName.Text = Session["firstname"].ToString() + " " + Session["lastname"].ToString();
            }
            else
            {
                facMember.Visible = false;
                searchFacName.Text = "All EX-Credential Records";
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_EXCredentials_PreRender(object sender, EventArgs e)
        {
            //testing only, remove and use the if block later
            gv_EXCredentials.DataSource = view.getDataSQLDataSet();
            gv_EXCredentials.DataBind();


            //if (Session["idnum"].ToString().Length < 2)
            //{
            //    gv_EXCredentials.DataSource = view.getDataSQLDataSet();
            //    gv_EXCredentials.DataBind();
            //}
            //else
            //{
            //    gv_EXCredentials.DataSource = view.getDataSQLByID(Session["idnum"].ToString());
            //    gv_EXCredentials.DataBind();
            //}
            



            if (gv_EXCredentials.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_EXCredentials.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_EXCredentials.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_EXCredentials.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        protected void gv_EXCredentials_SelectedIndexChanged(object sender, EventArgs e)
        {


            string idnum = "0";
            int idx = 1; // 0=first, 1=second column etc . . .
            idnum = gv_EXCredentials.SelectedRow.Cells[idx].Text;

            gv_EXCredentials.DataSource = view.getDataSQLByID(Session["idnum"].ToString());
            gv_EXCredentials.DataBind();

        }


        protected void gv_EXCredentials_IndexChanging(object sender, EventArgs e)
        {




        }




        protected void gv_EXCredentials_ButtonField(object sender, EventArgs e)
        {

        }


        protected void gv_EXCredentials_Credentials(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gv_EXCredentials_Courses(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gv_EXCredentials_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();
            string id_num = String.Empty;

            //switch (cmdName)
            //{
            //    case "gv_CredPartial_Credentials":
            //        {
            //            id_num = gv_EXCredentials.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();


            //            ParentPortlet.NextScreen("CredentialsScreen");
            //        }
            //        break;
            //    case "gv_CredPartial_Courses":
            //        {
            //            id_num = gv_EXCredentials.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();


            //            ParentPortlet.NextScreen("CoursesScreen");
            //        }
            //        break;
            //}



            /*
            string ctrlName = ((Control)sender).ID;
            Guid WidgetID = Guid.Empty;
            string commandName = e.CommandName;
        
            switch (ctrlName)
            {
                case "GridView3":
                    WidgetID = GridView3.DataKeys[e.CommandArgument.ToString()].Value.ToString();
                    break;
                case "grdCerts":
                    facqual_no = grdCerts.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();
                    break;
                case "grdQuals":
                    facqual_no = grdQuals.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();
                    break;
            }
          

            Session["SelectedQual"] = WidgetID;


            switch (commandName)
            {
                case "DeleteRow":
                    // Session["CredentialAction"] = "Delete";
                    //Session["SelectcedID"] = GridView3.ID;
                    //loadDisplays();

                    //removeSelectedItem(selectedID, WidgetID);
                    //GridView3_RowDeleting(selectedID, e);
                    break;
                case "View":

                    Session["CredentialAction"] = "View";

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView3.Rows[index];
                    var dataId = row.Cells[0].Text;
                    var dataName = row.Cells[1].Text;
                    var dataDesc = row.Cells[2].Text;
                    this.IDtxt.Text = dataId;
                    this.NAMEtxt.Text = dataName;
                    this.DESCtxt.Text = dataDesc;

                    break;
                case "EditRow":

                    //GridView3_RowEditing(selectedID,  e);
                    //Session["CredentialAction"] = "Edit";
                    break;


                default:
                    break;
            }



        
            if (commandName == "View" || commandName == "Edit")
            {

                if (isLoginPortlet)
                {
                    switch (ctrlName)
                    {
                        case "grdDegrees":
                            //HttpContext.Current.Session["nextScreen"] = "AddDegree";
                            this.CurrentLoginData.LoginState["nextScreen"] = "AddDegree";
                            this.NextLoginPage();
                            break;
                        case "grdCerts":
                            //HttpContext.Current.Session["nextScreen"] = "AddCert";
                            this.CurrentLoginData.LoginState["nextScreen"] = "AddCert";
                            this.NextLoginPage();
                            break;
                        case "grdQuals":
                            //HttpContext.Current.Session["nextScreen"] = "AddOther";
                            this.CurrentLoginData.LoginState["nextScreen"] = "AddOther";
                            this.NextLoginPage();
                            break;
                    }
                }
                else
                {
                    switch (ctrlName)
                    {
                        case "grdDegrees":
                            this.ParentPortlet.NextScreen("AddDegree");
                            break;
                        case "grdCerts":
                            this.ParentPortlet.NextScreen("AddCert");
                            break;
                        case "grdQuals":
                            this.ParentPortlet.NextScreen("AddOther");
                            break;
                    }
                }
                */

            string pause = String.Empty;
        }

        public void LoadFacultyScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("FacultyScreen");
        }

        public void LoadDefaultView(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("DefaultView");
        }

        public void LoadNextView(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("DefaultView");
        }

        public void LoadEDUEarnHistScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("EDUEarnHistScreen");
        }

        public void LoadCoursesScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("CoursesScreen");
        }

        public void LoadCredentialsScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("CredentialsScreen");
        }
    }
}
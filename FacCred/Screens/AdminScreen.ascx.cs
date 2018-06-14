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
using System.Collections;
using Jenzabar.Portal.Framework;

namespace FacCred.Screens
{
    public partial class AdminScreen : PortletViewBase
    {
        static CredentialsView view = new CredentialsView();


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Trace.IsEnabled = true;
            startLoad();

        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void GridView1_PreRender(object sender, EventArgs e)
        //{
        //    if (Session["idnum"].ToString().Length  > 1)
        //    {
        //        GridView1.DataSource = view.getDataSQLByID(Session["idnum"].ToString());
        //        GridView1.DataBind();

        //        //lbl_FirstName.Text = Session["firstname"].ToString();
        //        //lbl_LastName.Text = Session["lastname"].ToString();
        //    }
        //    else
        //    {
        //        GridView1.DataSource = view.getDataSQLDataSet();
        //        GridView1.DataBind();

        //        //lbl_FirstName.Text = "";
        //        //lbl_LastName.Text = "";
        //    }




        //    if (GridView1.Rows.Count > 0)
        //    {
        //        //Replace the <td> with <th> and adds the scope attribute
        //        GridView1.UseAccessibleHeader = true;

        //        //Adds the <thead> and <tbody> elements required for DataTables to work
        //        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

        //        //Adds the <tfoot> element required for DataTables to work
        //        GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
        //    }
        //}



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //int idx = 1; // 0=first, 1=second column etc . . .
            //Label1.Text = GridView1.SelectedRow.Cells[idx].Text;
        }


        protected void GridView1_IndexChanging(object sender, EventArgs e)
        {


            //int idx = 1; // 0=first, 1=second column etc . . .
            //Label1.Text = GridView1.SelectedRow.Cells[idx].Text;
        }




        protected void GridView1_ButtonField(object sender, EventArgs e)
        {

        }


        protected void GridView1_Credentials(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_Courses(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();
            string id_num = String.Empty;

            //switch (cmdName)
            //{
            //    case "GridView1_Credentials":
            //        {
            //            id_num = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();

            //            ParentPortlet.NextScreen("CredentialsScreen");
            //        }
            //        break;
            //    case "GridView1_Courses":
            //        {
            //            id_num = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();


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

        public void LoadNotesScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("NotesScreen");
        }

        public void LoadPXCoursesScreen(object sender, EventArgs e)
        {
            //ClientScriptManager cs = Page.ClientScript;
            ////string script = "$('div#divLoading').addClass('show');";
            //cs.RegisterClientScriptBlock(Page.GetType(), "loading", "showLoading()", true);

            ParentPortlet.NextScreen("PXCoursesScreen");
        }


        public void LoadPXCodesScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("PXCodesScreen");
        }
        public void LoadAcadCredScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("ACADCREDScreen");
        }
        public void LoadCopyOLScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("COPYOLScreen");
        }
        public void LoadCreditScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("CREDITScreen");
        }
        public void LoadOtherQualScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("OTHERQUALScreen");
        }

        public void LoadEXCredentialsScreen(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("EXCredentialsScreen");
        }


    }
}

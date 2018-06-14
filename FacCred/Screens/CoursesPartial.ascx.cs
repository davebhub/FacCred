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

namespace FacCred.Screens
{
    public partial class CoursesPartial : PortletViewBase
    {
        static CoursesView view = new CoursesView();


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_coursesPartial_PreRender(object sender, EventArgs e)
        {

            gv_coursesPartial.DataSource = view.getDataSQLDataSet();
            gv_coursesPartial.DataBind();



            if (gv_coursesPartial.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_coursesPartial.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_coursesPartial.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_coursesPartial.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        protected void gv_coursesPartial_SelectedIndexChanged(object sender, EventArgs e)
        {


           // int idx = 1; // 0=first, 1=second column etc . . .
            //Label1.Text = gv_coursesPartial.SelectedRow.Cells[idx].Text;
        }


        protected void gv_coursesPartial_IndexChanging(object sender, EventArgs e)
        {


          //  int idx = 1; // 0=first, 1=second column etc . . .
           // Label1.Text = gv_coursesPartial.SelectedRow.Cells[idx].Text;
        }




        protected void gv_coursesPartial_ButtonField(object sender, EventArgs e)
        {

        }


        protected void gv_coursesPartial_Credentials(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gv_coursesPartial_Courses(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gv_coursesPartial_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();
            string id_num = String.Empty;

            switch (cmdName)
            {
                case "gv_coursesPartial_Credentials":
                    {
                        id_num = gv_coursesPartial.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();


                        ParentPortlet.NextScreen("CredentialsScreen");
                    }
                    break;
                case "gv_coursesPartial_Courses":
                    {
                        id_num = gv_coursesPartial.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();


                        ParentPortlet.NextScreen("CoursesScreen");
                    }
                    break;
            }

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
    }
}
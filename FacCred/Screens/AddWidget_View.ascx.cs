using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Jenzabar.Portal.Framework.Web.UI;

namespace FacCred.Screens
{
    public partial class AddWidget_View : PortletViewBase
    {

        //WidgetsMapperService WidgetsService = new WidgetsMapperService();
        //WidgetsNHibernate Widgets = new WidgetsNHibernate();

        //CUS_WidgetsDataContext widgetContext = new CUS_WidgetsDataContext();

        //private string cxConnStr = String.Empty;
        private Guid selectedID = Guid.Empty;
        private bool isLoginPortlet = false;

        //public object GridView3 { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
           // GridView3.DataSource = widgetContext.CUS_Widgets;
           // GridView3.DataBind();

        }


        protected void btnSave_clicked(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            {
                outputFile.WriteLine("btnSave_click clicked from AddWidget_View ");
            }

          //  var widgetTable = from CUS_Widget in widgetContext.GetTable<CUS_Widget>() select CUS_Widget;


            /*
            Widgets.PortletID = ParentPortlet.PortletDisplay.Portlet.ID;
            Widgets.UserID = PortalUser.Current.ID;
            Widgets.Name = NAMEtxt.Text;
            Widgets.Description = DESCtxt.Text;

            
            
            try
            {
                WidgetsService.Save(Widgets);
            }
            catch (Exception except)
            {
                ExceptionManager.Publish(except);

                using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
                {
                    outputFile.WriteLine("PortletID: " + Widgets.PortletID.ToString());
                    outputFile.WriteLine("UserID: " + Widgets.UserID.ToString());
                    outputFile.WriteLine("Name: " + Widgets.Name.ToString());
                    outputFile.WriteLine("Description: " + Widgets.Description.ToString());
                    outputFile.WriteLine(except.ToString());
                }
            }
            */

        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            Guid WidgetID = Guid.Empty;
            string commandName = e.CommandName;
            /*
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
            */

            Session["SelectedQual"] = WidgetID;


            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            {
                outputFile.WriteLine("commandName = " + commandName.ToString());
            }

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



            /*
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


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            {
                outputFile.WriteLine("OnSelectedIndexChanged ");
            }

            // Get the currently selected row using the SelectedRow property.



            GridViewRow row = this.GridView3.SelectedRow;
            this.IDtxt.Text = row.Cells[0].Text;
            this.NAMEtxt.Text = row.Cells[1].Text;
            this.DESCtxt.Text = row.Cells[2].Text;

        }

        private void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }


        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void loadDisplays()
        {
            Guid widget = selectedID;
            //getDegreeDisplay(userID);
            //getCertDisplay(userID);
            //getQualDisplay(userID);
        }



        private bool removeSelectedItem(object selectedID, Guid WidgetID)
        {
            /*
            string STMT = "update edu_earn_hist set dte_expired = GETDATE() where id_num=@id and ed_seq = @seq";
            try
            {
                
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();
                da.execNonQuery(STMT,
                                CommandType.Text,
                                new ParamStruct[]{
                                    new ParamStruct("id", id, DbType.Int32, ParameterDirection.Input),
                                    new ParamStruct("seq", facqulNo, DbType.String, ParameterDirection.Input)
                                });
                
                return true;
            }
            catch (Exception ex)
            {
               // errMsg.Visible = true;
               // errMsg.ErrorMessage = ex.Message.ToString();
                ExceptionManager.Publish(ex);
                return false;
            }
            */

            return true;
        }






        protected void btnFetch_clicked(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            {
                outputFile.WriteLine("btnFetch_click clicked from AddWidget_View ");
            }
        }



        protected void LoadNextView(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            {
                outputFile.WriteLine("LoadDefaultView clicked from AddWidget_View ");
            }

            ParentPortlet.NextScreen("DefaultView");

        }


    }
}
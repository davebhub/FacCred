using Jenzabar.Portal.Framework.Web.UI;
using System;
using System.Collections.Generic;
using Jenzabar.Portal.Framework;
using System.IO;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using FacCred.cs;

namespace FacCred.Screens
{
    public partial class Widget : PortletViewBase
    {
        //CUS_WidgetsDataContext widgetContext = new CUS_WidgetsDataContext();
        WidgetsMapperService widgetsService = new WidgetsMapperService();
        WidgetsNHibernate Widgets = new WidgetsNHibernate();




        protected void Page_Load(object sender, EventArgs e)
        {

            /*
            IQueryable<EDU_EARN_HIST> list = db.EDU_EARN_HIST.Where(c => c.APPID > 1);

            

            List<string> localStrings = new List<string>();
            

            GridView1.DataSource = list;
            GridView1.DataBind();
            */

        }

        protected void LoadNextView(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            {
                outputFile.WriteLine("LoadDefaultView clicked from AddWidget_View ");
            }

            ParentPortlet.NextScreen("DefaultView");

        }

        protected void btnSave_clicked(object sender, EventArgs e)
        {


            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            {
                outputFile.WriteLine("btnSave_click clicked from AddWidget_View ");
            }

            Guid widId = new Guid("7FD2C326-8987-41F4-8D9B-BDE6099758AE");

            Widgets.WidgetID = widId;
            Widgets.PortletID = ParentPortlet.PortletDisplay.Portlet.ID;
            Widgets.UserID = PortalUser.Current.ID;
            //Widgets.Name = txtName.Text;
            //Widgets.Description = txtDescription.Text;



            try
            {

                // widgetsService.UpdateWidget(Widgets.WidgetID,Widgets.Name,Widgets.Description);
                IList<WidgetsNHibernate> newly = widgetsService.GetWidgets(Widgets.PortletID, Widgets.UserID);



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
                    outputFile.WriteLine("widgetService: " + widgetsService.ToString());
                    outputFile.WriteLine(except.ToString());
                }
            }

        }



    }
}
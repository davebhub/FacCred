using System;
using System.Web.UI.WebControls;
using Jenzabar.Portal.Framework.Web.UI;

namespace FacCred
{
    public partial class JunkScreen : PortletViewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsFirstLoad)
            {
                InitScreen();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            //ggWidgets.DeleteCommand += GgWidgets_DeleteCommand;
            //ggWidgets.EditCommand += GgWidgets_EditCommand;
            base.OnInit(e);
        }

        private void ggNotes_EditCommand(object source, DataGridCommandEventArgs e)
        {
            //ParentPortlet.PortletViewState["EditId"] = ggWidgets.DataKeys[e.Item.ItemIndex].ToString();  // Don't Do This
            //ParentPortlet.Session["EditId"] = ggWidgets.DataKeys[e.Item.ItemIndex].ToString(); // Do this instead
            //ParentPortlet.NextScreen("AddWidget");
        }

        private void ggNotes_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            //var widgetService = new WidgetsMapperService();
            //Guid widgetId = new Guid(ggWidgets.DataKeys[e.Item.ItemIndex].ToString());
            //var widget = widgetService.GetWidget(widgetId);

            //try
            //{
            //    widgetService.Delete(widget);
            //}
            //catch (Exception exception)
            //{
            //    ParentPortlet.ShowFeedback(FeedbackType.Error,
            //        "Widget not deleted : " + exception.Message);
            //    ExceptionManager.Publish(exception);
            //}

            InitScreen();
        }

        private void InitScreen()
        {
            //var widgetService = new WidgetsMapperService();
            //ggWidgets.DataSource = widgetService.GetWidgets(
            //    ParentPortlet.PortletDisplay.ID,
            //    PortalUser.Current.ID);
            //ggWidgets.DataBind();
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //var widgetService = new WidgetsMapperService();
            //widgetService.RemoveWidgets(ParentPortlet.Portlet.ID);
        }
    }
}
using System;
using Jenzabar.Portal.Framework.Web.UI;
using Jenzabar.Portal.Framework.Web;
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
using FacCred.Entities;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using Jenzabar.Portal.Framework;

namespace FacCred.Screens
{
    public partial class UserAccessUpdateScreen : PortletViewBase
    {
        static DropDownView ddview = new DropDownView();
        static UserAccessView view = new UserAccessView();

        protected override void OnInit(EventArgs e)
        {
            ggUserAccess.DeleteCommand += ggUserAccess_DeleteCommand;
            //ggDisciplines.EditCommand += ggDisciplines_EditCommand;

            base.OnInit(e);
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;Session["userLevel"].ToString();
            userName.Text = Session["SelectedUserFirstName"].ToString() + " " + Session["SelectedUserLastName"].ToString() ;

            loadDropDowns();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsFirstLoad)
            {
                InitScreen();
            }
        }

        private void InitScreen()
        {
            var userAccessService = new UserAccessMapperService();

            //var userAccess = userAccessService.GetOneUserAccess(userName.Text);
            ggUserAccess.DataSource = userAccessService.GetOneUserAccess(Session["SelectedUserID"].ToString(), Session["SelectedUserFirstName"].ToString(), Session["SelectedUserLastName"].ToString());
            ggUserAccess.DataBind();
        }




        protected void btn_ADD_Click(object sender, EventArgs e)
        {
            UserAccessMapperService userAccessService = new UserAccessMapperService();
            UserAccessNHibernate userAccess = new UserAccessNHibernate();

            Guid newId = Guid.NewGuid();

            //ADD A NEW DISCIPLINE
            userAccess = new UserAccessNHibernate
            {
                ID = newId,
                USER_ID = Session["SelectedUserID"].ToString(),
                FIRST_NAME = Session["SelectedUserFirstName"].ToString(),
                LAST_NAME = Session["SelectedUserLastName"].ToString(),
                SCHOOL_CDE = ddl_SchoolCodes.SelectedValue,

            };

            if (ddl_SchoolCodes.SelectedValue.Length < 2)
            {
                ParentPortlet.ShowFeedback("Please Select a School Code before Saving.");
                return;
            }

            var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();

            try
            {
                using (var transaction = nHibernateSession.BeginTransaction())
                {
                    nHibernateSession.Save(userAccess);
                    transaction.Commit();

                    ParentPortlet.ShowFeedback(FeedbackType.Success, "Access Successfully Added!");
                }
            }
            catch (Exception exception)
            {
                var msg = PortalUser.Current.IsSiteAdmin
                    ? "Selected Access was not added! Error: " + exception.Message
                    : "Selected Access was not added! ";

                this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);
                ExceptionManager.Publish(exception);
                return;
            }
            finally
            {
                nHibernateSession.Close();
            }

            InitScreen();
        }

        private void ggUserAccess_DeleteCommand(object sender, DataGridCommandEventArgs e)
        {
            var userAccessService = new UserAccessMapperService();

            Guid userAccessID = new Guid(ggUserAccess.DataKeys[e.Item.ItemIndex].ToString());

            try
            {
                userAccessService.DeleteUserAccess(userAccessID);
            }
            catch (Exception exception)
            {
                var msg = PortalUser.Current.IsSiteAdmin
                    ? "Selected Access was not Deleted. " + exception.Message
                    : "Selected Access was not Deleted.";

                this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

                ExceptionManager.Publish(exception);
                return;
            }

            ParentPortlet.Session["EditId"] = null;
            InitScreen();
        }





        private void loadDropDowns()
        {
            ddl_SchoolCodes.DataSource = ddview.getSchoolCodes();
            ddl_SchoolCodes.DataBind();

        }



        protected void btn_Back_Click(object sender, EventArgs e)
        {
 
            ParentPortlet.PreviousScreen();
        }




    }
}
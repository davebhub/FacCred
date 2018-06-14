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
    public partial class UserAccessDirectUpdateScreen : PortletViewBase
    {
        static DropDownView ddview = new DropDownView();
        static UserAccessDirectView view = new UserAccessDirectView();

        protected override void OnInit(EventArgs e)
        {


            base.OnInit(e);
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName; Session["userLevel"].ToString();
            userName.Text = Session["SelectedUserFirstName"].ToString() + " " + Session["SelectedUserLastName"].ToString();

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
           // var userAccessService = new UserAccessMapperService();

            //var userAccess = userAccessService.GetOneUserAccess(userName.Text);
            //ggUserAccess.DataSource = userAccessService.GetOneUserAccess(Session["SelectedUserID"].ToString(), Session["SelectedUserFirstName"].ToString(), Session["SelectedUserLastName"].ToString());
            //ggUserAccess.DataBind();
        }




        protected void btn_ADD_Click(object sender, EventArgs e)
        {
            //UserAccessMapperService userAccessService = new UserAccessMapperService();
            //UserAccessNHibernate userAccess = new UserAccessNHibernate();

            Guid newId = Guid.NewGuid();

            ////ADD A NEW DISCIPLINE
            //userAccess = new UserAccessNHibernate
            //{
            Guid ID = newId;
            string USER_ID = Session["SelectedUserID"].ToString();
            string FIRST_NAME = Session["SelectedUserFirstName"].ToString();
            string LAST_NAME = Session["SelectedUserLastName"].ToString();
            string SCHOOL_CDE = ddl_SchoolCodes.SelectedValue;

            //};

            if (ddl_SchoolCodes.SelectedValue.Length < 2)
            {
                ParentPortlet.ShowFeedback("Please Select a School Code before Saving.");
                return;
            }

            try
            {
                bool rtn = view.InsertOneRecordDirectAccess(ID, USER_ID, FIRST_NAME, LAST_NAME, SCHOOL_CDE);

                if (rtn)
                {
                    // inserted 
                    ParentPortlet.ShowFeedback(FeedbackType.Message, "The selected record was successfully added");
                }
                else
                {
                    // failed
                    ParentPortlet.ShowFeedback(FeedbackType.Error, "Record was not added, please try again");
                }
            }
            catch (Exception exception)
            {
                this.ParentPortlet.ShowFeedback(FeedbackType.Error, "Trouble adding a new record");
                ExceptionManager.Publish(exception);
                return;
            }

            //var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();

            //try
            //{
            //    using (var transaction = nHibernateSession.BeginTransaction())
            //    {
            //        nHibernateSession.Save(userAccess);
            //        transaction.Commit();

            //        ParentPortlet.ShowFeedback(FeedbackType.Success, "Access Successfully Added!");
            //    }
            //}
            //catch (Exception exception)
            //{
            //    var msg = PortalUser.Current.IsSiteAdmin
            //        ? "Selected Access was not added! Error: " + exception.Message
            //        : "Selected Access was not added! ";

            //    this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);
            //    ExceptionManager.Publish(exception);
            //    return;
            //}
            //finally
            //{
            //    nHibernateSession.Close();
            //}

            InitScreen();
        }

        private void ggUserAccess_DeleteCommand(object sender, DataGridCommandEventArgs e)
        {
            //var userAccessService = new UserAccessMapperService();

            //Guid userAccessID = new Guid(ggUserAccess.DataKeys[e.Item.ItemIndex].ToString());

            //try
            //{
            //    userAccessService.DeleteUserAccess(userAccessID);
            //}
            //catch (Exception exception)
            //{
            //    var msg = PortalUser.Current.IsSiteAdmin
            //        ? "Selected Access was not Deleted. " + exception.Message
            //        : "Selected Access was not Deleted.";

            //    this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

            //    ExceptionManager.Publish(exception);
            //    return;
            //}

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


        //-------------------------------------------------------------------------------------------------

        //gv_Faculty    ----------------------------------------------------------------------------
        protected void gv_DirectAccess_PreRender(object sender, EventArgs e)
        {


            // if (PortalUser.Current.DisplayName == "FacCredAdmin" || PortalUser.Current.DisplayName == "Administrator Administrator")
            if (Session["userLevel"].ToString() == "FacCredAdmin")
            {
                gv_DirectAccess.DataSource = view.GetOneUserDirectAccess(Session["SelectedUserID"].ToString());
                gv_DirectAccess.DataBind();
            }
            //else
            //{
            //    gv_DirectAccess.DataSource = view.getUserAccessFaculty(Session["LIUuserid"].ToString(), Session["LIUfirstname"].ToString(), Session["LIUlastname"].ToString());
            //    gv_DirectAccess.DataBind();
            //}



            if (gv_DirectAccess.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_DirectAccess.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_DirectAccess.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_DirectAccess.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            //startLoad();
        }

        protected void gv_DirectAccess_IndexChanging(object sender, EventArgs e)
        {
            //word
        }

        protected void gv_DirectAccess_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_DirectAccess.Rows[rowIndex];

            Session["SCA_ID"] = (string)this.gv_DirectAccess.DataKeys[rowIndex]["ID"];
            Session["SCA_USER_ID"] = (string)this.gv_DirectAccess.DataKeys[rowIndex]["USER_ID"];

            Session["SCA_schoolcode"] = row.Cells[2].Text;




            switch (cmdName)
            {

                case "gv_DirectAccess_Remove":
                {
                    RemoveSelectedSchoolCodeAccess();
                    Session["SCA_ID"] = null;
                    Session["SCA_USER_ID"] = null;
                    Session["SCA_schoolcode"] = null;
                    InitScreen();
                }
                break;
            }
        }


        protected void RemoveSelectedSchoolCodeAccess()
        {
            bool rtn = view.DeleteOneUserDirectAccess(Session["SCA_ID"].ToString());

            if (rtn)
            {
                // deleted 
                ParentPortlet.ShowFeedback(FeedbackType.Message, "The selected record was successfully removed");
            }
            else
            {
                // failed
                ParentPortlet.ShowFeedback(FeedbackType.Error, "Record was not deleted, please try again");
            }
        }


    }
}
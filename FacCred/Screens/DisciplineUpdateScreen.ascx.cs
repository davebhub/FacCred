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
    public partial class DisciplineUpdateScreen : PortletViewBase
    {
        static DropDownView ddview = new DropDownView();
        //static DisciplineView disciplineView = new DisciplineView();
        static FacultyView facultyView = new FacultyView();


        protected override void OnInit(EventArgs e)
        {
            ggDisciplines.DeleteCommand += ggDisciplines_DeleteCommand;
            //ggDisciplines.EditCommand += ggDisciplines_EditCommand;

            base.OnInit(e);
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;Session["userLevel"].ToString();
            facName.Text = Session["FACinstructorType"].ToString() + " : " + Session["FACfirstname"].ToString() + ' ' + Session["FAClastname"].ToString();

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
            //var disciplineService = new DisciplinesMapperService();
            //var disciplines = disciplineService.GetFacultyDisciplines(Session["FACappid"].ToString(), Session["FACidnum"].ToString());

            ggDisciplines.DataSource = facultyView.getFacultyXREF(Session["FACappid"].ToString(), Session["FACidnum"].ToString());
            ggDisciplines.DataBind();
        }


        private void loadTextFields()
        {
            if (Session["FACidnum"].ToString().Length > 1)
            {
                //searchFacName.Text = Session["FACfirstname"].ToString() + ' ' + Session["FAClastname"].ToString() + ":" + Session["FACinstructorType"].ToString();
                //lbl_idnum.Text = Session["FACidnum"].ToString();
                //lbl_FirstName.Text = Session["FACfirstname"].ToString();
                //lbl_LastName.Text = Session["FAClastname"].ToString();
                //lbl_instType.Text = Session["FACinstructorType"].ToString();
                //btn_CourseSave.Enabled = true;
            }
        }



        //----------------------- update section  --------------------------------

        protected void ddl_Status_codes_OnLoad(object sender, EventArgs e)
        {
            // ddl_Status_codes.SelectedValue = "A";
        }

        protected void ddl_Status_codes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
            // string approvalCode = DropDownList_approval.SelectedValue.ToString();
            // Session["approvalCode"] = approvalCode;
        }

        protected void ddl_InstDiv_OnLoad(object sender, EventArgs e)
        {

        }

        protected void ddl_InstDiv_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
            // string approvalCode = DropDownList_approval.SelectedValue.ToString();
            // Session["approvalCode"] = approvalCode;
        }





        protected void btn_ADD_Click(object sender, EventArgs e)
        {

            if (ddl_InstDiv.SelectedValue.Length < 1 || ddl_Divisions.SelectedValue.Length < 1 || ddl_SchoolCodes.SelectedValue.Length < 1)
            {
                ParentPortlet.ShowFeedback(FeedbackType.Error, "Please select a value from Each of the three dropdowns before Adding");
                return;
            }

            Guid newId = Guid.NewGuid();
            bool rtn = false;


            try
            {
                rtn = facultyView.insertOneFacultyXREF(newId, Session["FACappid"].ToString(), Session["FACidnum"].ToString(),
                    ddl_Divisions.SelectedValue, ddl_InstDiv.SelectedValue, ddl_SchoolCodes.SelectedValue);

                if (rtn)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Success, "XREF Successfully Added!");
                }
                else
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Error, "XREF was not Added!");
                }

            }
            catch (Exception exception)
            {
                var msg = PortalUser.Current.IsSiteAdmin
                    ? "This discipline was not added! Error: " + exception.Message
                    : "This discipline was not added! ";

                this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);
                ExceptionManager.Publish(exception);
                return;
            }


            ////DisciplinesMapperService disciplineService = new DisciplinesMapperService();
            ////DisciplinesNHibernate discipline = new DisciplinesNHibernate();

            ////ADD A NEW DISCIPLINE
            //discipline = new DisciplinesNHibernate
            //{
            //    ID = newId,
            //    FAC_APPID = Session["FACappid"].ToString(),
            //    FAC_ID_NUM = Session["FACidnum"].ToString(),
            //    DIV_CDE = ddl_Divisions.SelectedValue,
            //    INSTIT_DIV_CDE = ddl_InstDiv.SelectedValue,
            //    SCHOOL_CDE = ddl_SchoolCodes.SelectedValue,
            //};


            //var nHibernateSession = new NHibernateFactory().GetSessionFactory().OpenSession();

            //try
            //{
            //    using (var transaction = nHibernateSession.BeginTransaction())
            //    {
            //        nHibernateSession.Save(discipline);
            //        transaction.Commit();

            //        ParentPortlet.ShowFeedback(FeedbackType.Success, "Discipline Successfully Added!");
            //    }
            //}
            //catch (Exception exception)
            //{
            //    var msg = PortalUser.Current.IsSiteAdmin
            //        ? "This discipline was not added! Error: " + exception.Message
            //        : "This discipline was not added! ";

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



        private void ggDisciplines_DeleteCommand(object sender, DataGridCommandEventArgs e)
        {
            //var disciplinesService = new DisciplinesMapperService();

            Guid disciplineId = new Guid(ggDisciplines.DataKeys[e.Item.ItemIndex].ToString());
            bool rtn = false;

            try
            {
                // disciplinesService.DeleteDiscipline(disciplineId);
                rtn = facultyView.deleteOneFacultyXREF(disciplineId);

                if (rtn)
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Success, "XREF Successfully Removed!");
                }
                else
                {
                    ParentPortlet.ShowFeedback(FeedbackType.Error, "XREF was not Removed!");
                }

            }
            catch (Exception exception)
            {
                var msg = PortalUser.Current.IsSiteAdmin
                    ? "This Discipline was not Deleted. " + exception.Message
                    : "This Discipline was not Deleted.";

                this.ParentPortlet.ShowFeedback(FeedbackType.Error, msg);

                ExceptionManager.Publish(exception);
                return;
            }

            ParentPortlet.Session["EditId"] = null;
            InitScreen();
        }





        private void loadDropDowns()
        {


            ddl_Divisions.DataSource = ddview.getDivisions();
            ddl_Divisions.DataBind();


            ddl_InstDiv.DataSource = ddview.getInstDivisions();
            ddl_InstDiv.DataBind();


            // BECAUSE THEY ARE SECURED
            if (Session["userLevel"].ToString() == "FacCredAdmin")
            {
                ddl_SchoolCodes.DataSource = ddview.getSchoolCodes();
                ddl_SchoolCodes.DataBind();
            }
            else
            {
                ddl_SchoolCodes.DataSource = ddview.getSchoolCodeUserAccess(Session["LIUuserid"].ToString());
                ddl_SchoolCodes.DataBind();
            }




            loadTextFields();

            //reloadDivisionDropDown();

        }



        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Session["FACinstdiv"] = "";
            ParentPortlet.PreviousScreen();
        }




    }
}
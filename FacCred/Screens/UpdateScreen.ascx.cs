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
    public partial class UpdateScreen : PortletViewBase
    {
        //static ApprovalsView approveview = new ApprovalsView();
        static FacultyApprovalsView facultyApprovalsView = new FacultyApprovalsView();
        static CourseApprovalsView courseApprovalsView = new CourseApprovalsView();
        static DropDownView ddview = new DropDownView();
        static CredentialsView credentialsview = new CredentialsView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;
            loadDropDowns();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void loadDropDowns()
        {
            DropDownList_approval.DataSource = ddview.getApprovalCodes();
            DropDownList_approval.DataBind();

            loadTextFields();

            //reloadDivisionDropDown();
            
        }

        private void loadTextFields()
        {
            if (Session["FACidnum"].ToString().Length > 1)
            {
                txt_idnum.Text = Session["FACidnum"].ToString();
                txt_FirstName.Text = Session["FACfirstname"].ToString();
                txt_LastName.Text = Session["FAClastname"].ToString();
                btn_CourseSave.Enabled = true;
            }

            if (Session["CRSappid"].ToString().Length > 1)
            {
                txt_CourseAppid.Text = Session["CRSappid"].ToString();
                txt_CourseDesc.Text = Session["CRSdesc"].ToString();
                txt_CourseTerm.Text = Session["termcode"].ToString();
                txt_CourseYear.Text = Session["yearcode"].ToString();
                txt_instType.Text = Session["FACinstructorType"].ToString();
                txt_InstDiv.Text = Session["CRSinstdiv"].ToString();
                if (txt_InstDiv.Text == "&nbsp;")
                {
                    txt_InstDiv.Text = "0";
                    Session["instdiv"] = "0";
                }
                
                btn_DivisionSave.Enabled = true;
            }

        }

        //protected void reloadDivisionDropDown()
        //{
        //    if (Session["idnum"].ToString().Length > 1)
        //    {
        //        DropDownList_divisions.DataSource = ddview.getSpecificDivisions(Session["idnum"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString() );
        //        DropDownList_divisions.DataBind();
        //    }
        //    else
        //    {
        //        DropDownList_divisions.DataSource = ddview.getInstitutDivisions();
        //        DropDownList_divisions.DataBind();
        //    }
        //}


        //protected void tryToLoadSessionVars()
        //{

        //}

        protected void gv_Approvals_IndexChanging(object sender, EventArgs e)
        {

        }

 

        protected void gv_Your_Approvals_IndexChanging(object sender, EventArgs e)
        {

        }



        //----------------------- update section  --------------------------------

        protected void DropDownList_approval_OnLoad(object sender, EventArgs e)
        {
           //  DropDownList_approval.SelectedValue = Session["approvalCode"].ToString();
            Session["approvalCode"] = "0";
        }

        protected void ddl_approval_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
            string approvalCode = DropDownList_approval.SelectedValue.ToString();
            Session["approvalCode"] = approvalCode;

        }

        //protected void DropDownList_divisions_OnLoad(object sender, EventArgs e)
        //{
        //    // DropDownList_approval.SelectedValue = Session["approvalCode"].ToString();
        //    Session["ddl_instdiv"] = "0";
        //}

        //protected void ddl_divisions_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //view.setYear(DropDownList_year.SelectedValue);
        //    string instDivCode = DropDownList_divisions.SelectedValue.ToString();
        //    Session["ddl_instdiv"] = instDivCode;
        //}




        protected void CourseSave_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if ( DropDownList_approval.SelectedValue.ToString() == "0")
                {
                    // die here, can't update division 0
                    
                    lbl_updateErrMsg.Text = "No Approval Status is Selected";


                }
                else
                {
                    //rtn = approveview.InsertUpdateApproval(
                    //        //Session["approvalCode"].ToString(),
                    //        DropDownList_approval.SelectedValue.ToString(),
                    //        Session["CRSappid"].ToString(),
                    //        Session["FACidnum"].ToString(),
                    //        Session["yearcode"].ToString(),
                    //        Session["termcode"].ToString(),
                    //        Session["userLevel"].ToString(),
                    //        Session["CRSdesc"].ToString(),
                    //        Session["FACfirstname"].ToString(),
                    //        Session["FAClastname"].ToString(),
                    //        Session["FACinstructorType"].ToString(),
                    //        rightNow,
                    //        txt_InstDiv.Text
                    //        );
                }
            }
            catch
            {

            }

            if (rtn)
            {
                //success
                lbl_updateErrMsg.Text  = " ";
                ParentPortlet.NextScreen("ApprovalsScreen");
            }

        }



        protected void DivisionSave_Click(object sender, EventArgs e)
        {
            bool insertRtn = false;
            bool updateRtn = false;

            updateRtn = UpdateDivisionRecs();

            if ( Session["userLevel"].ToString() == "Approver1")
            {
                insertRtn = InsertDivisionRecs();
            }
        }


        protected bool InsertDivisionRecs()
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (txt_InstDiv.Text == "0" | DropDownList_approval.SelectedValue.ToString() == "0")
                {
                    // die here, can't update division 0
                    lbl_updateErrMsg.Text  = "InstDivision = 0  --or--  No Approval Status is Selected";


                }
                else
                {
                    //rtn = facultyApprovalsView.InsertDisciplineRecords(
                    //        //Session["approvalCode"].ToString(),
                    //        DropDownList_approval.SelectedValue.ToString(),
                    //        Session["FACappid"].ToString(),
                    //        Session["FACidnum"].ToString(),
                    //        Session["yearcode"].ToString(),
                    //        Session["termcode"].ToString(),
                    //        Session["SM_appid"].ToString(),
                    //        Session["userLevel"].ToString(),
                    //        Session["CRSdesc"].ToString(),
                    //        Session["FACfirstname"].ToString(),
                    //        Session["FAClastname"].ToString(),
                    //        Session["FACinstructorType"].ToString(),
                    //        rightNow,
                    //        txt_InstDiv.Text 
                    //        //DropDownList_divisions.SelectedValue.ToString()
                    //     );
                }  
            }
            catch
            {

            }

            if (rtn)
            {
                //success
                lbl_updateErrMsg.Text = " ";
                ParentPortlet.NextScreen("ApprovalsScreen");
                
            }


            return rtn;
        }

        protected bool UpdateDivisionRecs()
        {

            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (txt_InstDiv.Text == "0" | DropDownList_approval.SelectedValue.ToString() == "0")
                {
                    // die here, can't update division 0
                    lbl_updateErrMsg.Text = "InstDivision = 0  --or--  No Approval Status is Selected";


                }
                else
                {

                    //rtn = approveview.UpdateDisciplineRecords(
                    //    //Session["approvalCode"].ToString(),
                    //    DropDownList_approval.SelectedValue.ToString(),
                    //    Session["FACappid"].ToString(),
                    //    Session["FACidnum"].ToString(),
                    //    Session["yearcode"].ToString(),
                    //    Session["termcode"].ToString(),
                    //    Session["SM_appid"].ToString(),
                    //    Session["userLevel"].ToString(),
                    //    Session["CRSdesc"].ToString(),
                    //    Session["FACfirstname"].ToString(),
                    //    Session["FAClastname"].ToString(),
                    //    Session["FACinstructorType"].ToString(),
                    //    rightNow,
                    //    txt_InstDiv.Text 
                    //    //DropDownList_divisions.SelectedValue.ToString()
                    //    );
                }
            }
            catch
            {

            }

            if (rtn)
            {
                //success

                lbl_updateErrMsg.Text = " ";
                ParentPortlet.NextScreen("ApprovalsScreen");
            }


            return rtn;
        }







    }
}
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
    public partial class ApprovalNoteScreen : PortletViewBase
    {
        //static ApprovalsView approveview = new ApprovalsView();
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
            ddl_Status_codes.DataSource = ddview.getStatusCodes();
            ddl_Status_codes.DataBind();

            loadTextFields();

            //reloadDivisionDropDown();

        }

        private void loadTextFields()
        {
            if (Session["idnum"].ToString().Length > 1)
            {
                lbl_idnum.Text = Session["idnum"].ToString();
                lbl_FirstName.Text = Session["firstname"].ToString();
                lbl_LastName.Text = Session["lastname"].ToString();
                //btn_CourseSave.Enabled = true;
            }

            if (Session["CRSappid"].ToString().Length > 1)
            {
                lbl_CourseAppid.Text = Session["CRSappid"].ToString();
                lbl_CourseDesc.Text = Session["CRSdesc"].ToString();
                lbl_CourseTerm.Text = Session["termcode"].ToString();
                lbl_CourseYear.Text = Session["yearcode"].ToString();
                lbl_instType.Text = Session["insttype"].ToString();
                lbl_InstDiv.Text = Session["instDiv"].ToString();
                if (lbl_InstDiv.Text == "&nbsp;")
                {
                    lbl_InstDiv.Text = "0";
                    Session["instdiv"] = "0";
                }


                //btn_DivisionSave.Enabled = true;
            }

            mytextarea.InnerText = Session["noteText"].ToString();

        }



        //----------------------- update section  --------------------------------

        protected void ddl_Status_codes_OnLoad(object sender, EventArgs e)
        {
              ddl_Status_codes.SelectedValue = "A";           
        }

        protected void ddl_Status_codes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
            // string approvalCode = DropDownList_approval.SelectedValue.ToString();
            // Session["approvalCode"] = approvalCode;
        }


        protected void FacultySave_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            ParentPortlet.NextScreen("ApprovalsScreen");
        }



        protected void CourseSave_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);



            if (rtn)
            {
                //success
                lbl_updateErrMsg.Text = " ";
                ParentPortlet.NextScreen("ApprovalsScreen");
            }
            else
            {
                //failure
                //lbl_updateErrMsg.Text = "not all fields were filled in. check the Approval Status";
            }
        }



        protected void DivisionSave_Click(object sender, EventArgs e)
        {
            bool insertRtn = false;
            bool updateRtn = false;

            updateRtn = UpdateDivisionRecs();

            if (Session["userLevel"].ToString() == "Approver1")
            {
                insertRtn = InsertDivisionRecs();
            }

            ParentPortlet.NextScreen("ApprovalsScreen");
        }


        protected bool InsertDivisionRecs()
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                if (lbl_InstDiv.Text == "0")
                {
                    // die here, can't update division 0
                    lbl_updateErrMsg.Text = "InstDivision = 0  --or--  No Approval Status is Selected";


                }
                else
                {
                    //rtn = approveview.InsertDivisionRecords(
                    //        //Session["approvalCode"].ToString(),
                    //        //DropDownList_approval.SelectedValue.ToString(),
                    //        Session["CRSappid"].ToString(),
                    //        Session["idnum"].ToString(),
                    //        Session["yearcode"].ToString(),
                    //        Session["termcode"].ToString(),
                    //        Session["userLevel"].ToString(),
                    //        Session["CRSdesc"].ToString(),
                    //        Session["firstname"].ToString(),
                    //        Session["lastname"].ToString(),
                    //        Session["insttype"].ToString(),
                    //        rightNow,
                    //        txt_InstDiv.Text
                    //     //DropDownList_divisions.SelectedValue.ToString()
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
                if (lbl_InstDiv.Text == "0")
                {
                    // die here, can't update division 0
                    lbl_updateErrMsg.Text = "InstDivision = 0  --or--  No Approval Status is Selected";


                }
                else
                {

                    //rtn = approveview.UpdateDivisionRecords(
                    //    //Session["approvalCode"].ToString(),
                    //   // DropDownList_approval.SelectedValue.ToString(),
                    //    Session["inaaapppstdiv"].ToString(),
                    //    Session["CRSappid"].ToString(),
                    //    Session["idnum"].ToString(),
                    //    Session["yearcode"].ToString(),
                    //    Session["termcode"].ToString(),
                    //    Session["userLevel"].ToString(),
                    //    Session["CRSdesc"].ToString(),
                    //    Session["firstname"].ToString(),
                    //    Session["lastname"].ToString(),
                    //    Session["insttype"].ToString(),
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
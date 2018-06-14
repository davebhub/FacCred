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
    public partial class NotesUpdateScreen : PortletViewBase
    {
        //static ApprovalsView approveview = new ApprovalsView();
        static DropDownView ddview = new DropDownView();
        //static CredentialsView credentialsview = new CredentialsView();

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
            // LOADED FROM THE NOTES SCREEN
            //Session["FACfirstname"] = row.Cells[1].Text;
            //Session["FAClastname"] = row.Cells[2].Text;
            //Session["NOTEsubject"] = row.Cells[3].Text;
            //Session["NOTEnote"] = row.Cells[4].Text;
            //Session["NOTEcreated"] = row.Cells[5].Text;
            //Session["NOTEstatus"] = row.Cells[6].Text;
            //Session["NOTEaprdate"] = row.Cells[7].Text;
            //Session["NOTEexpdate"] = row.Cells[8].Text;
            //Session["NOTEupddate"] = row.Cells[9].Text;
            //Session["NOTEupdby"] = row.Cells[10].Text;
            //Session["CRSinstdiv"] = row.Cells[11].Text;
            //Session["NOTEyear"] = row.Cells[12].Text;
            //Session["NOTEterm"] = row.Cells[13].Text;
            //Session["CRSappid"] = row.Cells[14].Text;
            //Session["CRSdesc"] = row.Cells[15].Text;
            //Session["FACidnum"] = row.Cells[16].Text;
            //Session["FACappid"] = row.Cells[17].Text;
            //Session["FACinstructorType"] = row.Cells[18].Text;
            //Session["NOTEusername"] = row.Cells[19].Text;
            //Session["NOTEssn"] = row.Cells[20].Text;
            //Session["PXolddivcode"] = row.Cells[21].Text;
            //Session["NOTEid"] = row.Cells[22].Text;


            lbl_firstName.Text = Session["FACfirstname"].ToString();
            lbl_lastName.Text = Session["FAClastname"].ToString();
            lbl_instType.Text = Session["FACinstructorType"].ToString();
            lbl_idnum.Text = Session["FACidnum"].ToString();

            lbl_CATdiv.Text = Session["CATdiv"].ToString() + " - " + Session["CATdivdesc"].ToString();
            lbl_CATinstdiv.Text = Session["CATinstdiv"].ToString() + " - " + Session["CATinstdivdesc"].ToString();
            lbl_CATschoolcde.Text = Session["CATschoolcde"].ToString();

            //lbl_courseDesc.Text = Session["CRSdesc"].ToString();
            //lbl_instDiv.Text = Session["CRSinstdiv"].ToString();
            //lbl_courseYear.Text = Session["NOTEyear"].ToString();
            //lbl_courseTerm.Text = Session["NOTEterm"].ToString();
            //lbl_courseAppid.Text = Session["CRSappid"].ToString();

            //lbl_PXssn.Text = Session["FACssn"].ToString();
            //lbl_PXdivCode.Text = Session["PXolddivcode"].ToString();

            mytextarea.InnerText = Session["NOTEnote"].ToString();
            txt_Subject.Text = Session["NOTEsubject"].ToString();

        }

        protected void gv_Approvals_IndexChanging(object sender, EventArgs e)
        {

        }



        protected void gv_Your_Approvals_IndexChanging(object sender, EventArgs e)
        {

        }



        //----------------------- update section  --------------------------------

        protected void ddl_Status_codes_OnLoad(object sender, EventArgs e)
        {
            //if (Session["NOTEstatus"].ToString() == "")
            //{
            //    ddl_Status_codes.SelectedValue = "A";
            //}
            //else
            //{
            //    ddl_Status_codes.SelectedValue = Session["NOTEstatus"].ToString();
               
            //}
            
            //Session["approvalCode"] = "0";
        }

        protected void ddl_Status_codes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
           // string approvalCode = DropDownList_approval.SelectedValue.ToString();
           // Session["approvalCode"] = approvalCode;

        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            ParentPortlet.NextScreen("NotesScreen");
        }

        protected void btn_Archive_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            ParentPortlet.NextScreen("NotesScreen");
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ParentPortlet.NextScreen("NotesScreen");
        }



        protected void CourseSave_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                //if (DropDownList_approval.SelectedValue.ToString() == "0")
                //{
                //    // die here, can't update division 0

                //    lbl_updateErrMsg.Text = "No Approval Status is Selected";

                //}
                //else
                //{
                //    rtn = approveview.InsertUpdateApproval(
                //            //Session["approvalCode"].ToString(),
                //            DropDownList_approval.SelectedValue.ToString(),
                //            Session["CRSappid"].ToString(),
                //            Session["idnum"].ToString(),
                //            Session["yearcode"].ToString(),
                //            Session["termcode"].ToString(),
                //            Session["userLevel"].ToString(),
                //            Session["CRSdesc"].ToString(),
                //            Session["firstname"].ToString(),
                //            Session["lastname"].ToString(),
                //            Session["insttype"].ToString(),
                //            rightNow,
                //            txt_InstDiv.Text
                //            );
                //}
            }
            catch
            {

            }

            if (rtn)
            {
                //success
                lbl_updateErrMsg.Text = " ";
                ParentPortlet.NextScreen("NotesScreen");
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

            ParentPortlet.NextScreen("NotesScreen");
        }


        protected bool InsertDivisionRecs()
        {
            bool rtn = false;
            string DateFormat = "yyyy-MM-dd HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);

            try
            {
                //if (txt_InstDiv.Text == "0" )
                //{
                //    // die here, can't update division 0
                //    lbl_updateErrMsg.Text = "InstDivision = 0  --or--  No Approval Status is Selected";


                //}
                //else
                //{
                //    //rtn = approveview.InsertDivisionRecords(
                //    //        //Session["approvalCode"].ToString(),
                //    //        //DropDownList_approval.SelectedValue.ToString(),
                //    //        Session["CRSappid"].ToString(),
                //    //        Session["idnum"].ToString(),
                //    //        Session["yearcode"].ToString(),
                //    //        Session["termcode"].ToString(),
                //    //        Session["userLevel"].ToString(),
                //    //        Session["CRSdesc"].ToString(),
                //    //        Session["firstname"].ToString(),
                //    //        Session["lastname"].ToString(),
                //    //        Session["insttype"].ToString(),
                //    //        rightNow,
                //    //        txt_InstDiv.Text
                //    //     //DropDownList_divisions.SelectedValue.ToString()
                //    //     );
                //}
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
            else
            {
                //failure - do not change screens

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
                //if (txt_InstDiv.Text == "0" )
                //{
                //    // die here, can't update division 0
                //    lbl_updateErrMsg.Text = "InstDivision = 0  --or--  No Approval Status is Selected";


                //}
                //else
                //{

                //    //rtn = approveview.UpdateDivisionRecords(
                //    //    //Session["approvalCode"].ToString(),
                //    //   // DropDownList_approval.SelectedValue.ToString(),
                //    //    Session["inaaapppstdiv"].ToString(),
                //    //    Session["CRSappid"].ToString(),
                //    //    Session["idnum"].ToString(),
                //    //    Session["yearcode"].ToString(),
                //    //    Session["termcode"].ToString(),
                //    //    Session["userLevel"].ToString(),
                //    //    Session["CRSdesc"].ToString(),
                //    //    Session["firstname"].ToString(),
                //    //    Session["lastname"].ToString(),
                //    //    Session["insttype"].ToString(),
                //    //    rightNow,
                //    //    txt_InstDiv.Text
                //    //    //DropDownList_divisions.SelectedValue.ToString()
                //    //    );
                //}
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
            else
            {
                //failure

            }

            return rtn;
        }



    }
}
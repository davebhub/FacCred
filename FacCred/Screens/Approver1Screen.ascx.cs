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


namespace FacCred.Screens
{
    public partial class Approver1Screen : PortletViewBase
    {
        ApprovalsView approveview = new ApprovalsView();
        static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_Approvals_PreRender(object sender, EventArgs e)
        {
            if (Session["yearcode"].ToString().Length > 1 & Session["termcode"].ToString().Length > 1)
            {
                gv_Approvals.DataSource = approveview.getApprovalsByYT(Session["yearcode"].ToString(), Session["termcode"].ToString());
                gv_Approvals.DataBind();
            }
            else
            {
                gv_Approvals.DataSource = approveview.getAllApprovals();
                gv_Approvals.DataBind();
            }


            if (gv_Approvals.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Approvals.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Approvals.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Approvals.FooterRow.TableSection = TableRowSection.TableFooter;
            }

            loadDropDowns();
        }




        private void loadDropDowns()
        {
            if (Session["idnum"] == null | Session["idnum"].ToString() == "0")
            {
                as_DropDownList_divisions.DataSource = ddview.getInstitutDivisions();
                as_DropDownList_divisions.DataBind();
            }
            else
            {
                reloadDivisionDropDown();
                loadTextFields();
            }


            as_DropDownList_approval.DataSource = ddview.getApprovalCodes();
            as_DropDownList_approval.DataBind();

        }

        private void loadTextFields()
        {
            if (Session["idnum"].ToString().Length > 1)
            {
                txt_idnum_as.Text = Session["idnum"].ToString();
                txt_FirstName_as.Text = Session["firstname"].ToString();
                txt_LastName_as.Text = Session["lastname"].ToString();
                btn_CourseSave_as.Enabled = true;
            }

            if (Session["courseAppid"].ToString().Length > 1)
            {
                txt_CourseAppid_as.Text = Session["courseAppid"].ToString();
                txt_CourseDesc_as.Text = Session["courseDesc"].ToString();
                txt_InstDiv_as.Text = Session["instDiv"].ToString();
                txt_CourseTerm_as.Text = Session["termcode"].ToString();
                txt_CourseYear_as.Text = Session["yearcode"].ToString();
                txt_instType_as.Text = Session["insttype"].ToString();
                btn_DivisionSave_as.Enabled = true;
            }

        }

        protected void reloadDivisionDropDown()
        {
            if (Session["idnum"].ToString().Length > 1)
            {
                as_DropDownList_divisions.DataSource = ddview.getSpecificDivisions(Session["idnum"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
                as_DropDownList_divisions.DataBind();
            }
            else
            {
                as_DropDownList_divisions.DataSource = ddview.getInstitutDivisions();
                as_DropDownList_divisions.DataBind();
            }
        }


        protected void gv_Approvals_IndexChanging(object sender, EventArgs e)
        {

        }

        protected void gv_Approvals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();
            string id_num = String.Empty;

            //switch (cmdName)
            //{
            //    case "gv_Approvals_Approver1":
            //        {
            //            id_num = gv_Approvals.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();

            //            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            //            { outputFile.WriteLine(" id_num: " + id_num.ToString()); }
            //            //ParentPortlet.NextScreen("CredentialsScreen");
            //        }
            //        break;
            //    case "gv_Approvals_Approver2":
            //        {
            //            id_num = gv_Approvals.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();

            //            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            //            { outputFile.WriteLine(" id_num: " + id_num.ToString()); }
            //            //ParentPortlet.NextScreen("CoursesScreen");
            //        }
            //        break;
            //}
        }

        protected void btn_newSearch_command(object sender, EventArgs e)
        {
            //Session["idnum"] = "0";
            //gv_Your_Approvals.DataSource = approveview.getYourApprovals(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //gv_Your_Approvals.DataBind();

            ////Session["courseAppid"] = "0";
            ////gv_Your_Approvals.DataSource = coursesView.getDataSQLByIDYT(Session["idnum"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            ////gv_Your_Approvals.DataBind();

            //txt_CourseDesc_as.Text = "";
            //txt_CourseTerm_as.Text = "";
            //txt_CourseYear_as.Text = "";
            //txt_FirstName_as.Text = "";
            //txt_idnum_as.Text = "";
            //txt_LastName_as.Text = "";
            //txt_instType_as.Text = "";
            //txt_InstDiv_as.Text = "";

            btn_DivisionSave_as.Enabled = false;
            btn_CourseSave_as.Enabled = false;

            reloadDivisionDropDown();
        }


        // gv_Your_Approvals    ----------------------------------------------------------------------------

        protected void gv_Your_Approvals_PreRender(object sender, EventArgs e)
        {
            if (txt_CourseDesc_as.Text.Length > 1)
            {
                gv_Your_Approvals.DataSource = approveview.getYourApprover1RecordsSpecific(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString(), Session["courseAppid"].ToString(), Session["idnum"].ToString());
                gv_Your_Approvals.DataBind();
            } 
            else
            {
                gv_Your_Approvals.DataSource = approveview.getYourApprovals(Session["userLevel"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
                gv_Your_Approvals.DataBind();
            }
            
            if (gv_Your_Approvals.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_Your_Approvals.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_Your_Approvals.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_Your_Approvals.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }

        protected void gv_Your_Approvals_IndexChanging(object sender, EventArgs e)
        {

        }

        protected void gv_Your_Approvals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_Your_Approvals.Rows[rowIndex];

            string id_num = String.Empty;
            string yearcode = String.Empty;
            string termcode = String.Empty;
            string courseAppid = String.Empty;
            string courseDesc = String.Empty;
            string instDiv = String.Empty;
            string lastName = String.Empty;
            string firstName = String.Empty;
            string instType = String.Empty;
          
            courseDesc = row.Cells[1].Text;
            instDiv = row.Cells[2].Text;
            lastName = row.Cells[5].Text;
            firstName = row.Cells[6].Text;
            instType = row.Cells[7].Text;
            id_num = row.Cells[8].Text;
            courseAppid = row.Cells[9].Text;

            // setting these here to properly load the other screens on select
            Session["idnum"] = id_num;
            Session["courseAppid"] = courseAppid;
            Session["courseDesc"] = courseDesc;
            Session["instDiv"] = instDiv;
            Session["firstname"] = firstName;
            Session["lastname"] = lastName;
            Session["insttype"] = instType;

            switch (cmdName)
            {
                case "gv_Your_Approvals_Approve":
                    {
                        // id_num = gv_Approvals.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();
                    }
                    break;
                case "gv_Your_Approvals_Remarks":
                    {
                        // id_num = gv_Approvals.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString();
                    }
                    break;
            }
        }




        //----------------------- update section  --------------------------------

        protected void as_DropDownList_approval_OnLoad(object sender, EventArgs e)
        {
            // DropDownList_approval.SelectedValue = Session["approvalCode"].ToString();
            //Session["approvalCode"] = "0";
        }

        protected void as_ddl_approval_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
            string approvalCode = as_DropDownList_approval.SelectedValue.ToString();
            //Session["approvalCode"] = approvalCode;

        }

        protected void as_DropDownList_divisions_OnLoad(object sender, EventArgs e)
        {
            // DropDownList_approval.SelectedValue = Session["approvalCode"].ToString();
            //Session["ddl_instdiv"] = "0";
        }

        protected void as_ddl_divisions_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //view.setYear(DropDownList_year.SelectedValue);
            string instDivCode = as_DropDownList_divisions.SelectedValue.ToString();
            //Session["ddl_instdiv"] = instDivCode;
        }


        protected void as_CourseSave_Click(object sender, EventArgs e)
        {
            bool rtn = false;

            string DateFormat = "yyyy-MM-d HH:mm:ss";
            string rightNow = DateTime.Now.ToString(DateFormat);


            //try
            //{



            rtn = approveview.InsertUpdateApproval(
                        Session["approvalCode"].ToString(),
                        Session["courseAppid"].ToString(),
                        Session["idnum"].ToString(),
                        Session["yearcode"].ToString(),
                        Session["termcode"].ToString(),
                        Session["userLevel"].ToString(),
                        Session["courseDesc"].ToString(),
                        Session["firstname"].ToString(),
                        Session["lastname"].ToString(),
                        Session["insttype"].ToString(),
                        rightNow,
                        Session["instdiv"].ToString());


            //}
            //catch
            //{
            using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
            {
                outputFile.WriteLine("CourseSave:  with approvalCode: " + Session["approvalCode"].ToString() +
                    " courseAppid: " + Session["courseAppid"].ToString() +
                    " idnum: " + Session["idnum"].ToString() +
                    " yearcode: " + Session["yearcode"].ToString() +
                    " termcode: " + Session["termcode"].ToString() +
                    " userLevel: " + Session["userLevel"].ToString() +
                    " courseDesc: " + Session["courseDesc"].ToString() +
                    " firstname: " + Session["firstname"].ToString() +
                    " lastname: " + Session["lastname"].ToString() +
                    " insttype: " + Session["insttype"].ToString() +
                    " now: " + rightNow
                    );
            }
            //}



            if (rtn)
            {
                //success
                using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
                {
                    outputFile.WriteLine("insertUpdate success");
                }
            }
            else
            {
                //failure
                using (StreamWriter outputFile = new StreamWriter("c:\\temp" + @"\log.txt", true))
                {
                    outputFile.WriteLine("insertUpdate failure");
                }
            }
        }


        protected void as_DivisionSave_Click(object sender, EventArgs e)
        {
            if (txt_FirstName_as.Text.Length < 1 | txt_CourseDesc_as.Text.Length < 1)
            {
                //do nothing because the fields are not populated.

            }
            else
            {
                //build the msg that you want to show
                string conformationMsg = " Are you sure?";
                //Call the JavaScript method
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "showUpdateConformation", "showUpdateConformation('" + conformationMsg + "');", true);

                // if the user clicks YES, the ConfirmButton_Click is called and will execute the logic for the SAVE
            }
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            //Put the logic to do the actual update here


            // unselect the course so the user can pick another one.
            //Session["courseAppid"] = "0";


            //gv_CoursesPartial.DataSource = coursesView.getDataSQLByIDYT(Session["idnum"].ToString(), Session["yearcode"].ToString(), Session["termcode"].ToString());
            //gv_CoursesPartial.DataBind();

            //txt_CourseDesc_as.Text = "";
            //txt_CourseTerm_as.Text = "";
            //txt_CourseYear_as.Text = "";

        }






    }
}
﻿using System;
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
    public partial class UserAccessDirectScreen : PortletViewBase
    {
        static UserAccessDirectView view = new UserAccessDirectView();
        static DropDownView ddview = new DropDownView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            startLoad();
        }

        protected void startLoad()
        {
            txt_sessionUserLevel.Text = Session["userLevel"].ToString() + " " + PortalUser.Current.FirstName + " " + PortalUser.Current.LastName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //word
        }



        //gv_User_Access    ----------------------------------------------------------------------------
        protected void gv_User_Access_Direct_PreRender(object sender, EventArgs e)
        {


            gv_User_Access_Direct.DataSource = view.AllUserAccessSQL();
            gv_User_Access_Direct.DataBind();


            if (gv_User_Access_Direct.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gv_User_Access_Direct.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gv_User_Access_Direct.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gv_User_Access_Direct.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }

        protected void gv_User_Access_Direct_IndexChanging(object sender, EventArgs e)
        {
            //nother word
        }

        protected void gv_User_Access_Direct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            string cmdName = e.CommandName.ToString();

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv_User_Access_Direct.Rows[rowIndex];


            Session["SelectedUserID"] = (string)this.gv_User_Access_Direct.DataKeys[rowIndex]["UserID"];
            Session["SelectedUserFirstName"] = row.Cells[1].Text;
            Session["SelectedUserLastName"] = row.Cells[2].Text;
            Session["SelectedDisplayName"] = row.Cells[3].Text;
            ;

            switch (cmdName)
            {
                case "gv_User_Access_Select":
                    {

                        ParentPortlet.NextScreen("UserAccessDirectUpdateScreen");

                    }
                    break;
                case "gv_Course_Note":
                    {

                        // ParentPortlet.NextScreen("CoursesNoteScreen");
                    }
                    break;
            }
        }


    }
}
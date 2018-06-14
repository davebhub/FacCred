using System;
using System.Data;
using System.IO;
using Jenzabar.ERP.EX.Data;
using Jenzabar.Common.ApplicationBlocks.ExceptionManagement;
using Jenzabar.Portal.Framework.Web.UI;
using Jenzabar.Portal.Framework.Web.UI.Controls;
using Jenzabar.Portal.Framework.Web;
using FacCred.Views;
using System.Linq;
using Jenzabar.ERP.EX.DAL;
using System.Web.UI.WebControls;
using Jenzabar.Portal.Framework.Facade;
using Jenzabar.Portal.Framework.Facade.Ldap;
using Jenzabar.Portal.Web.UI.Controls;
using Jenzabar.ICS;
using System.Web;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Web.UI.CommonPortlets.CampusDirectoryPortlet;
using System.Collections.Generic;
using Jenzabar.Portal.Web.UI.Controls.PrincipalSelector;

namespace FacCred
{
    public partial class DefaultView : PortletViewBase
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);           
        }

        public IPortalUserFacade UserFacade { get; set; }
        public void FacCred(IPortalUserFacade facade)
        {
            this.UserFacade = facade;
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //   var userAccess = ((FacCred)ParentPortlet).CheckUserAccess();
            
            

            var userFacade = UserFacade;
            var userf = UserFacade.FindByUsername("Administrator");

            var uf = userf.GetGroupMembership();
            // var aar = userf.GetGroupsThatHaveAdminAccess();
             var xyz = userf.GetTokenGroups();
            //PortalGroupFacade ldap = new PortalGroupFacade();
            Jenzabar.Portal.Web.UI.Controls.PrincipalSelector.UserSelector us = new Jenzabar.Portal.Web.UI.Controls.PrincipalSelector.UserSelector();

            //string wef = us.SelectedUsers.ToString();

            Jenzabar.Portal.Framework.PortalGroup appr1 = new PortalGroup();
            //String sss = appr1.DisplayName.ToString(); 

            //WebUtils.ViewStateViewer vsv = new WebUtils.ViewStateViewer();

            //GroupAccess ga = new GroupAccess();

            //List<Jenzabar.Portal.Framework.PortalGroup> gaList = new List<Jenzabar.Portal.Framework.PortalGroup>();

            //List<Jenzabar.Portal.Framework.PortalGroup> groupList = new List<Jenzabar.Portal.Framework.PortalGroup>();

            //groupList = UserFacade.FindByUsername("Administator").GetGroupMembership();


            //----------- these work ------
            //foreach (var item in uf)
            //{

            //}


            //foreach (var item in xyz)
            //{

            //}
            //--------------end working -------------

            // string vs = this.ViewState["rsShowBaseRoles"].ToString();
            //CampusGroup cg = new CampusGroup();
            //CampusGroupDefaultRoles cgdr = new CampusGroupDefaultRoles();

            //  RoleManager rm = new RoleManager;

            //  Roles role = new Roles(this.UserFacade); 

            RoleSelector rs = new RoleSelector();
            // var dl = rs.BaseRolesToShow.Length;
            //rs.AllMyContexts.ToString();
            // string rsStr = rs.UniqueID.ToString();
            //Object rst = rs.AllMyContexts;
          

        }


        //public void LoadNextView(object sender, EventArgs e)
        //{
        //    ParentPortlet.NextScreen("DefaultView");
        //}

        //public void LoadDefaultView(object sender, EventArgs e)
        //{
        //    ParentPortlet.NextScreen("DefaultView");
        //}

        //public void LoadFacultyScreen(object sender, EventArgs e)
        //{
        //    ParentPortlet.NextScreen("FacultyScreen");
        //}

        //public void LoadEDUEarnHistScreen(object sender, EventArgs e)
        //{
        //    ParentPortlet.NextScreen("EDUEarnHistScreen");
        //}

        //public void LoadCoursesScreen(object sender, EventArgs e)
        //{
        //    ParentPortlet.NextScreen("CoursesScreen");
        //}
        //public void LoadCredentialsScreen(object sender, EventArgs e)
        //{
        //    ParentPortlet.NextScreen("CredentialsScreen");
        //}


        // from Sam's code

        //public class GCFacultyCredentialsLoginPageProvider : ILoginPageProvider
        //{
        //    public bool HasLoginPagesFor(UserLoginData loginInfo)
        //    {
        //        string userid = loginInfo.UserLoggingIn.HostID.TrimStart('0');
        //        bool isFac = loginInfo.UserLoggingIn.IsMemberOf(PortalGroup.Faculty);
        //        if (isFac)
        //        {
        //            bool enable = !checkConfirmation(userid);
        //            if (enable)
        //            {
        //                //HttpContext.Current.Session["isLoginPortlet"] = true;
        //                HttpContext.Current.Session["LoginUserID"] = userid;
        //                return true;
        //            }
        //            else
        //            {
        //                //HttpContext.Current.Session["isLoginPortlet"] = false;
        //                HttpContext.Current.Session.Remove("LoginUserID");
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            //HttpContext.Current.Session["isLoginPortlet"] = false;
        //            HttpContext.Current.Session.Remove("LoginUserID");
        //            return false;
        //        }
        //    }

        //    public LoginPageViewBase GetNextLoginPage(UserLoginData loginInfo, PortletBase loginPortlet)
        //    {

        //        string nextScreen = String.Empty;
        //        string screenPath = String.Empty;

        //        HttpContext.Current.Session["sourceLoad"] = "LPP";

        //        if (loginInfo.LoginState["nextScreen"] != null && loginInfo.LoginState["nextScreen"].ToString() != String.Empty)
        //            nextScreen = loginInfo.LoginState["nextScreen"].ToString();
        //        switch (nextScreen)
        //        {
        //            case "AddCert":
        //                screenPath = "~/Portlets/CUS/ICS/CUS_GCFacultyCredentials/AddCertification.ascx";
        //                break;
        //            case "AddDegree":
        //                screenPath = "~/Portlets/CUS/ICS/CUS_GCFacultyCredentials/AddDegree.ascx";
        //                break;
        //            case "AddOther":
        //                screenPath = "~/Portlets/CUS/ICS/CUS_GCFacultyCredentials/AddQualification.ascx";
        //                break;
        //            default:
        //                screenPath = "~/Portlets/CUS/ICS/CUS_GCFacultyCredentials/Default_View.ascx";
        //                break;
        //        }
        //        return (LoginPageViewBase)PortletViewLoader.LoadPortletView(screenPath);
        //    }

        //    private bool checkConfirmation(string selectedID)
        //    {
        //        //Check to see if any of the credentials have been confirmed for the user during this term
        //        string STMT = @"select COUNT(*)
        //                    from EDU_EARN_HIST h
        //                    where h.ID_NUM=@id_num and h.UDEF_DTE_1 >= (
        //                    select y.TRM_BEGIN_DTE 
        //                    from REG_CONFIG r
        //                    join YEAR_TERM_TABLE y on r.CUR_YR_DFLT=y.YR_CDE and r.CUR_TRM_DFLT=y.TRM_CDE)";

        //        bool confirmed = true;

        //        try
        //        {
        //            DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();

        //            string recordCount1 = da.execScalar(STMT,
        //                                System.Data.CommandType.Text,
        //                                new ParamStruct[]{
        //                                new ParamStruct("id_num", selectedID, System.Data.DbType.Int32, System.Data.ParameterDirection.Input )
        //                                }).ToString();

        //            if (Convert.ToInt32(recordCount1) == 0)
        //                confirmed = false;
        //            else
        //                confirmed = true;

        //            return confirmed;
        //        }
        //        catch (Exception ex)
        //        {
        //            ExceptionManager.Publish(ex);
        //            return false;
        //        }
        //    }
        //}
    }
}
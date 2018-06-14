 using System;
using System.Web;
using Jenzabar.Portal.Framework.Web.UI;
using Jenzabar.Portal.Framework.Facade;
using Jenzabar.Common.Web.UI.Controls;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Framework.Web;
using FacCred.cs;
using System.IO;
using FacCred.Screens;
using System.Data.SqlClient;
using System.Configuration;
using FacCred.Views;

namespace FacCred
{
    public class FacCred : LinkablePortletBase
    {
        private string cxConnStr = String.Empty;
        private string selectedID = String.Empty;
        private string userName = String.Empty;
        private string memberOf = String.Empty;
        private string childrenOf = String.Empty;
        string membership = String.Empty;
        private bool isLoginPortlet = false;
        private PortletViewBase screen;
        private PortletUserCntl userCntl = new PortletUserCntl();
        bool canAdmin;
        string friendlyName = "Faculty Credentials";
        string purposeDesc;
        bool rtn = false;

        

        static ApprovalsView approveview = new ApprovalsView();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            PopulateToolbar();


            //Session["yearcode"] = null;
            //Session["termcode"] = null;

            Session["appCount"] = +1;

            if (Session["appCount"].Equals(1))
            {
                Session["yearcode"] = "YR";
                Session["termcode"] = "TR";

                if (Session["updateErrMsg"] == null) Session["updateErrMsg"] = "";
                if (Session["ddl_instdiv"] == null) Session["ddl_instdiv"] = "0";
                if (Session["instdiv"] == null) Session["instdiv"] = "0";
                if (Session["EditId"] == null) Session["EditId"] = "0";
                if (Session["newSearch"] == null) Session["newSearch"] = "true";
                if (Session["returningFromNotes"] == null) Session["returningFromNotes"] = "false";
                

                //FACULTY
                if (Session["FACidnum"] == null) Session["FACidnum"] = "0";
                if (Session["FACfirstname"] == null) Session["FACfirstname"] = "0";
                if (Session["FAClastname"] == null) Session["FAClastname"] = "0";
                if (Session["FACinstructorType"] == null) Session["FACinstructorType"] = "0";
                if (Session["FACdivcode"] == null) Session["FACdivcode"] = "";
                if (Session["FACinstdiv"] == null) Session["FACinstdiv"] = "";
                if (Session["FACdisciplineDesc"] == null) Session["disciplinedesc"] = "";
                if (Session["FACschoolcode"] == null) Session["FACschoolcode"] = "";
                if (Session["FACload"] == null) Session["FACload"] = "";
                if (Session["FAClead"] == null) Session["FAClead"] = "";

                //CATALOG
                if (Session["CATdiv"] == null) Session["CATdiv"] = "";
                if (Session["CATdivdesc"] == null) Session["CATdivdesc"] = "";
                if (Session["CATinstdiv"] == null) Session["CATinstdiv"] = "";
                if (Session["CATinstdivdesc"] == null) Session["CATinstdivdesc"] = "";
                if (Session["CATschoolcde"] == null) Session["CATschoolcde"] = "";

                //COURSE
                if (Session["CRSyearcode"] == null) Session["CRSyearcode"] = "";
                if (Session["CRStermcode"] == null) Session["CRStermcode"] = "";
                if (Session["CSRdesc"] == null) Session["CRSdesc"] = "";
                if (Session["CRSappid"] == null) Session["CRSappid"] = "";
                if (Session["CRSdivcode"] == null) Session["CRSdivcode"] = "";
                if (Session["CRSinstdiv"] == null) Session["CRSinstdiv"] = "";
                if (Session["CRSschoolcode"] == null) Session["CRSschoolcode"] = "";
                if (Session["approvalCourse"] == null) Session["approvalCourse"] = "";
                if (Session["SM_appid"] == null) Session["SM_appid"] = "";

                //NOTES
                if (Session["noteLevel"] == null) Session["noteLevel"] = "";
                if (Session["noteLevelFilter"] == null) Session["noteLevelFilter"] = "";

                //APPROVALS
                if (Session["approvalCourse"] == null) Session["approvalCourse"] = "";
                if (Session["approvalCourseTitle"] == null) Session["approvalCourseTitle"] = "";
                if (Session["approvalYear"] == null) Session["approvalYear"] = "";
                if (Session["approvalTerm"] == null) Session["approvalTerm"] = "";
                if (Session["approvalStatus"] == null) Session["approvalStatus"] = "";
                if (Session["approvalDivCode"] == null) Session["approvalDivCode"] = "";
                if (Session["approvalInstDiv"] == null) Session["approvalInstDiv"] = "";
                if (Session["approvalSchoolcode"] == null) Session["approvalSchoolcode"] = "";
                if (Session["approvalApprovalDate"] == null) Session["approvalApprovalDate"] = "";
                if (Session["approvalExpirationDate"] == null) Session["approvalExpirationDate"] = "";
                if (Session["approvalCode"] == null) Session["approvalCode"] = "";

                //LOGGED IN USER
                if (Session["userLevel"] == null) Session["userLevel"] = "";
                if (Session["LIUuserid"] == null) Session["LIUuserid"] = "";
                if (Session["LIUfirstname"] == null) Session["LIUfirstname"] = "";
                if (Session["LIUlastname"] == null) Session["LIUlastname"] = "";

                //SELECTED USER
                if (Session["SelectedUserID"] == null) Session["SelectedUserID"] = "";
                if (Session["SelectedUserFirstName"] == null) Session["SelectedUserFirstName"] = "";
                if (Session["SelectedUserLastName"] == null) Session["SelectedUserLastName"] = "";
                if (Session["SelectedUserDisplayName"] == null) Session["SelectedUserDisplayName"] = "";
            }


            if (!Page.IsPostBack)
            {               
                rtn = CheckUserAccess();             
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //-------------------------------------------------------------------------------------
        public Boolean PopulateToolbar()
        {
            Toolbar Manage = new Toolbar();
            MenuItem Default = new MenuItem("DefaultView", "FacCred/DefaultView.ascx");
            MenuItem Main = new MenuItem("MainView", "FacCred/MainView.ascx");
            //MenuItem Widget = new MenuItem("WidgetView", "FacCred/Screens/Widget.ascx");
            //MenuItem Widget = new MenuItem("WidgetView", "FacCred/Screens/AddWidget_View.ascx");
            MenuItem Widget = new MenuItem("WidgetView", "FacCred/Screens/DataTableTest.ascx");
            MenuItem EDUEarnHist = new MenuItem("EDUEarnHistScreen", "FacCred/Screens/EDUEarnHistScreen.ascx");
            MenuItem Faculty = new MenuItem("FacultyScreen", "FacCred/Screens/FacultyScreen.ascx");
            MenuItem FacultyApproval = new MenuItem("FacultyApprovalScreen", "FacCred/Screens/FacultyApprovalScreen.ascx");
            MenuItem FacultyApprovalUpdate = new MenuItem("FacultyApprovalUpdateScreen", "FacCred/Screens/FacultyApprovalUpdateScreen.ascx");
            MenuItem FacultyNote = new MenuItem("FacultyNoteScreen", "FacCred/Screens/FacultyNoteScreen.ascx");
            MenuItem FacultyNoteArchive = new MenuItem("FacultyNoteArchiveScreen", "FacCred/Screens/FacultyNoteArchiveScreen.ascx");
            MenuItem Courses = new MenuItem("CoursesScreen", "FacCred/Screens/CoursesScreen.ascx");
            MenuItem CourseApproval = new MenuItem("CourseApprovalScreen", "FacCred/Screens/CourseApprovalScreen.ascx");
            MenuItem CourseApprovalUpdate = new MenuItem("CourseApprovalUpdateScreen", "FacCred/Screens/CourseApprovalUpdateScreen.ascx");
            MenuItem Credentials = new MenuItem("CredentialsScreen", "FacCred/Screens/CredentialsScreen.ascx");
            MenuItem EXCredentials = new MenuItem("EXCredentialsScreen", "FacCred/Screens/EXCredentialsScreen.ascx");
            MenuItem Approvals = new MenuItem("ApprovalsScreen", "FacCred/Screens/ApprovalsScreen.ascx");
            MenuItem ApprovalNote = new MenuItem("ApprovalNoteScreen", "FacCred/Screens/ApprovalsScreen.ascx");
            MenuItem Approver1 = new MenuItem("Approver1Screen", "FacCred/Screens/Approver1Screen.ascx");
            MenuItem ApprovalUpdate = new MenuItem("ApprovalUpdateScreen", "FacCred/Screens/ApprovalUpdateScreen.ascx");
            MenuItem NotesUpdate = new MenuItem("NotesUpdateScreen", "FacCred/Screens/NotesUpdateScreen.ascx");
            MenuItem Status = new MenuItem("StatusScreen", "FacCred/Screens/StatusScreen.ascx");
            MenuItem Notes = new MenuItem("NotesScreen", "FacCred/Screens/NotesScreen.ascx");
            MenuItem PXCourses = new MenuItem("PXCoursesScreen", "FacCred/Screens/PXCoursesScreen.ascx");
            MenuItem PXCodes = new MenuItem("PXCodesScreen", "FacCred/Screens/PXCodesScreen.ascx");
            MenuItem OTHERQUAL = new MenuItem("OTHERQUALScreen", "FacCred/Screens/OTHERQUALScreen.ascx");
            MenuItem CREDIT = new MenuItem("CREDITScreen", "FacCred/Screens/CREDITScreen.ascx");
            MenuItem COPYOL = new MenuItem("COPYOLScreen", "FacCred/Screens/COPYOLScreen.ascx");
            MenuItem ACADCRED = new MenuItem("ACADCREDScreen", "FacCred/Screens/ACADCREDScreen.ascx");
            MenuItem Reports = new MenuItem("ReportsScreen", "FacCred/Screens/ReportsScreen.ascx");
            MenuItem Loading = new MenuItem("LoadingScreen", "FacCred/Screens/LoadingScreen.ascx");
            MenuItem Unauthorized = new MenuItem("UnauthorizedScreen", "FacCred/Screens/UnauthorizedScreen.ascx");
            MenuItem Catalog = new MenuItem("CatalogScreen", "FacCred/Screens/CatalogScreen.ascx");
            MenuItem Discipline = new MenuItem("DisciplineScreen", "FacCred/Screens/DisciplineScreen.ascx");
            MenuItem DisciplineUpdate = new MenuItem("DisciplineUpdateScreen", "FacCred/Screens/DisciplineUpdateScreen.ascx");
            MenuItem AdminScreen = new MenuItem("AdminScreen", "FacCred/Screens/AdminScreen.ascx");
            MenuItem BlankScreen = new MenuItem("BlankScreen", "FacCred/Screens/BlankScreen.ascx");
            MenuItem UserAccessScreen = new MenuItem("UserAccessScreen", "FacCred/Screens/UserAccessScreen.ascx");
            MenuItem UserAccessUpdateScreen = new MenuItem("UserAccessUpdateScreen", "FacCred/Screens/UserAccessUpdateScreen.ascx");
            MenuItem UserAccessDirectScreen = new MenuItem("UserAccessDirectScreen", "FacCred/Screens/UserAccessDirectScreen.ascx");
            MenuItem UserAccessDirectUpdateScreen = new MenuItem("UserAccessDirectUpdateScreen", "FacCred/Screens/UserAccessDirectUpdateScreen.ascx");

            Manage.MenuItems.Add(Default);
            Manage.MenuItems.Add(Main);
            Manage.MenuItems.Add(Widget);
            Manage.MenuItems.Add(EDUEarnHist);
            Manage.MenuItems.Add(Faculty);
            Manage.MenuItems.Add(FacultyApproval);
            Manage.MenuItems.Add(FacultyApprovalUpdate);
            Manage.MenuItems.Add(FacultyNote);
            Manage.MenuItems.Add(FacultyNoteArchive);
            Manage.MenuItems.Add(Courses);
            Manage.MenuItems.Add(CourseApproval);
            Manage.MenuItems.Add(CourseApprovalUpdate);
            Manage.MenuItems.Add(Credentials);
            Manage.MenuItems.Add(EXCredentials);
            Manage.MenuItems.Add(Approvals);
            Manage.MenuItems.Add(ApprovalNote);
            Manage.MenuItems.Add(Approver1);
            Manage.MenuItems.Add(ApprovalUpdate);
            Manage.MenuItems.Add(Status);
            Manage.MenuItems.Add(Notes);
            Manage.MenuItems.Add(NotesUpdate);
            Manage.MenuItems.Add(PXCourses);
            Manage.MenuItems.Add(PXCodes);
            Manage.MenuItems.Add(OTHERQUAL);
            Manage.MenuItems.Add(CREDIT);
            Manage.MenuItems.Add(COPYOL);
            Manage.MenuItems.Add(ACADCRED);
            Manage.MenuItems.Add(Reports);
            Manage.MenuItems.Add(Loading);
            Manage.MenuItems.Add(Unauthorized);
            Manage.MenuItems.Add(Catalog);
            Manage.MenuItems.Add(Discipline);
            Manage.MenuItems.Add(DisciplineUpdate);
            Manage.MenuItems.Add(AdminScreen);
            Manage.MenuItems.Add(BlankScreen);
            Manage.MenuItems.Add(UserAccessScreen);
            Manage.MenuItems.Add(UserAccessUpdateScreen);
            Manage.MenuItems.Add(UserAccessDirectScreen);
            Manage.MenuItems.Add(UserAccessDirectUpdateScreen);

            return true;
        }


        public void Toolbar_ItemCommand(MenuItem m)
        {
            NextScreen(m.ToString());
        }


        protected override PortletViewBase GetCurrentScreen()
        {
            switch (CurrentPortletScreenName)
            {
                case "MainView":
                    return LoadPortletView("FacCred/MainView.ascx");
                case "FacultyScreen":
                    return LoadPortletView("FacCred/Screens/FacultyScreen.ascx");
                case "FacultyApprovalScreen":
                    return LoadPortletView("FacCred/Screens/FacultyApprovalScreen.ascx");
                case "FacultyApprovalUpdateScreen":
                    return LoadPortletView("FacCred/Screens/FacultyApprovalUpdateScreen.ascx");
                case "FacultyNoteScreen":
                    return LoadPortletView("FacCred/Screens/FacultyNoteScreen.ascx");
                case "FacultyNoteArchiveScreen":
                    return LoadPortletView("FacCred/Screens/FacultyNoteArchiveScreen.ascx");
                case "WidgetView":
                    //return LoadPortletView("FacCred/Screens/Widget.ascx");
                    //return LoadPortletView("FacCred/Screens/AddWidget_View.ascx");
                    return LoadPortletView("FacCred/Screens/DataTableTest.ascx");
                case "EDUEarnHistScreen":
                    return LoadPortletView("FacCred/Screens/EDUEarnHistScreen.ascx");
                case "CoursesScreen":
                    return LoadPortletView("FacCred/Screens/CoursesScreen.ascx");
                case "CourseApprovalScreen":
                    return LoadPortletView("FacCred/Screens/CourseApprovalScreen.ascx");
                case "CourseApprovalUpdateScreen":
                    return LoadPortletView("FacCred/Screens/CourseApprovalUpdateScreen.ascx");
                case "CredentialsScreen":
                    return LoadPortletView("FacCred/Screens/CredentialsScreen.ascx");
                case "EXCredentialsScreen":
                    return LoadPortletView("FacCred/Screens/EXCredentialsScreen.ascx");
                case "ApprovalsScreen":
                    return LoadPortletView("FacCred/Screens/ApprovalsScreen.ascx");
                case "ApprovalNoteScreen":
                    return LoadPortletView("FacCred/Screens/ApprovalNoteScreen.ascx");
                case "Approver1Screen":
                    return LoadPortletView("FacCred/Screens/Approver1Screen.ascx");
                case "ApprovalUpdateScreen":
                    return LoadPortletView("FacCred/Screens/ApprovalUpdateScreen.ascx");
                case "StatusScreen":
                    return LoadPortletView("FacCred/Screens/StatusScreen.ascx");
                case "NotesScreen":
                    return LoadPortletView("FacCred/Screens/NotesScreen.ascx");
                case "NotesUpdateScreen":
                    return LoadPortletView("FacCred/Screens/NotesUpdateScreen.ascx");
                case "PXCoursesScreen":
                    return LoadPortletView("FacCred/Screens/PXCoursesScreen.ascx");
                case "PXCodesScreen":
                    return LoadPortletView("FacCred/Screens/PXCodesScreen.ascx");
                case "OTHERQUALScreen":
                    return LoadPortletView("FacCred/Screens/OTHERQUALScreen.ascx");
                case "CREDITScreen":
                    return LoadPortletView("FacCred/Screens/CREDITScreen.ascx");
                case "COPYOLScreen":
                    return LoadPortletView("FacCred/Screens/COPYOLScreen.ascx");
                case "ACADCREDScreen":
                    return LoadPortletView("FacCred/Screens/ACADCREDScreen.ascx");
                case "ReportsScreen":
                    return LoadPortletView("FacCred/Screens/ReportsScreen.ascx");
                case "LoadingScreen":
                    return LoadPortletView("FacCred/Screens/LoadingScreen.ascx");
                case "UnauthorizedScreen":
                    return LoadPortletView("FacCred/Screens/UnauthorizedScreen.ascx");
                case "CatalogScreen":
                    return LoadPortletView("FacCred/Screens/CatalogScreen.ascx");
                case "DisciplineScreen":
                    return LoadPortletView("FacCred/Screens/DisciplineScreen.ascx");
                case "DisciplineUpdateScreen":
                    return LoadPortletView("FacCred/Screens/DisciplineUpdateScreen.ascx");
                case "AdminScreen":
                    return LoadPortletView("FacCred/Screens/AdminScreen.ascx");
                case "BlankScreen":
                    return LoadPortletView("FacCred/Screens/BlankScreen.ascx");
                case "UserAccessScreen":
                    return LoadPortletView("FacCred/Screens/UserAccessScreen.ascx");
                case "UserAccessUpdateScreen":
                    return LoadPortletView("FacCred/Screens/UserAccessUpdateScreen.ascx");
                case "UserAccessDirectScreen":
                    return LoadPortletView("FacCred/Screens/UserAccessDirectScreen.ascx");
                case "UserAccessDirectUpdateScreen":
                    return LoadPortletView("FacCred/Screens/UserAccessDirectUpdateScreen.ascx");
                default:
                    return LoadPortletView("FacCred/DefaultView.ascx");
            }
        }
        //---------------------------------------------------------------------------------------



        public Boolean CheckUserAccess()
        {
            bool IsFirstLoad = userCntl.IsFirstLoad;
            bool loggedin = PortalUser.Current.HasLoggedIn;
          //  isLoginPortlet = HttpContext.Current.Session["sourceLoad"] == "LPP";
            if (!loggedin)
            {
                selectedID = HttpContext.Current.Session["LoginUserID"].ToString();
            }

            //Session["LIUuserid"] = HttpContext.Current.Session["LoginUserID"].ToString();
            Session["LIUuserid"] = PortalUser.Current.Guid;
            Session["LIUfirstname"] = PortalUser.Current.FirstName;
            Session["LIUlastname"] = PortalUser.Current.LastName;

            selectedID = PortalUser.Current.ID.ToString();
            userName = PortalUser.Current.Username;
            memberOf = PortalUser.Current.MemberOf.ToString();
            childrenOf = PortalUser.Current.Children.ToString();

  

            Session["userLevel"] = approveview.approverLevelSQL(PortalUser.Current.FirstName, PortalUser.Current.LastName);


            if (IsFirstLoad)
            {

                //loadDisplays();
                //lblName.Text = PortalUser.Current.DisplayName;
                //lblDept.Text = Bio.getDept(selectedID);
            }
            if (checkConfirmation())
                return true;
            //pnl1.Visible = true;
            else
                return false;
            //pnl1.Visible = false;

        }

        private bool checkConfirmation()
        {
            /*
            //Check to see if any of the credentials have been confirmed for the user during this term
            string STMT = @"select COUNT(*)
                            from EDU_EARN_HIST h
                            where h.ID_NUM=@id_num and h.UDEF_DTE_1 <= (
                            select y.TRM_BEGIN_DTE 
                            from REG_CONFIG r
                            join YEAR_TERM_TABLE y on r.CUR_YR_DFLT=y.YR_CDE and r.CUR_TRM_DFLT=y.TRM_CDE
                            where y.TRM_BEGIN_DTE <= GETDATE() and y.TRM_END_DTE >= GETDATE() and (y.TRM_CDE in ('10','20')))";

            bool confirmed = true;

            try
            {
                DataAccess da = CUS.EX.DAL.EXConnect.GetDataAccess();

                string recordCount1 = da.execScalar(STMT,
                                    System.Data.CommandType.Text,
                                    new ParamStruct[]{
                                        new ParamStruct("id_num", selectedID, System.Data.DbType.Int32, System.Data.ParameterDirection.Input )
                                    }).ToString();

                if (Convert.ToInt32(recordCount1) > 0)
                    confirmed = false;
                else
                    confirmed = true;

                return confirmed;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return false;
            }
            */

            return true;
        }
    }
}
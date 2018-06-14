using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacCred.Models.Interfaces
{
    interface IApprovalsModel
    {
        string getFacultyIdnum();
        void setFacultyIdnum(string s);
        string getFacultyFirstName();
        void setFacultyFirstName(string s);
        string getFacultyLastName();
        void setFacultyLastName(string s);


        string getCourseAppid();
        void setCourseAppid(string s);
        string getCourseDesc();
        void setCourseDesc(string s);

        string getCourseYear();
        void setCourseYear(string s);
        string getCourseTerm();
        void setCourseTerm(string s);

        string getApproverLevel();
        void setApproverLevel(string s);

        DataTable getAllFacultyApprovals();
        DataTable getAllCourseApprovals();
        DataTable getApprovalsByLevel(string s);

        void saveApproval();
        void deleteApproval();
        void updateApproval();



    }
}

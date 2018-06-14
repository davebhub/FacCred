using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Services;
using CUS.OdbcConnectionClass3;
using FacCred.Entities;
using Jenzabar.Common.Configuration;
using Jenzabar.Portal.Framework;


namespace FacCred
{
    /// <summary>
    /// Summary description for ERPService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ERPService : System.Web.Services.WebService
    {
        

        [WebMethod(EnableSession = true)]
        public Address SaveAddress(string addressType, string line1, string line2, string city, string st, string zip,
            string begDate)
        {
            var note = new NotesNHibernate();
            Address result = new Address();

            if (PortalUser.Current.IsGuest)
            {
                result.Success = false;
                result.Message = "You do not have permissions to this resource.";
                return result;
            }

            OdbcConnectionClass3 odbcConn = new OdbcConnectionClass3("ERPDataConnection.config");

            string insertAddressSql = @"S
				insert into CUS_Addresses5
				(ID_Number, Addr_Code, Addr_Line1, Addr_Line2, City, State, Zip, BeginDate)
				values
				(?,?,?,?,?,?,?,?)";

            Exception ex = null;

            List<OdbcParameter> parameters = new List<OdbcParameter>
            {
                new OdbcParameter("id", PortalUser.Current.HostID),
                new OdbcParameter("Addr_code", addressType),
                new OdbcParameter("addrLine1", line1),
                new OdbcParameter("addrLine2", line2),
                new OdbcParameter("city", city),
                new OdbcParameter("state", st),
                new OdbcParameter("zip", zip),
                new OdbcParameter("begdate", begDate),
            };

            odbcConn.ConnectToERP(insertAddressSql, ref ex, parameters);

            if (ex != null)
            {
                result.Message = ex.Message;
                result.Success = false;
                result.Value = "Failed to add address records";
            }
            else
            {
                result.Success = true;

                result.UserId = PortalUser.Current.HostID;
                result.Line1 = line1;
                result.Line2 = line2;
                result.City = city;
                result.State = st;
                result.Zip = zip;
                result.BeginDate = begDate;
                result.AddressType = addressType;

                result.Message = "Successfully added address record!";
            }

            return result;
        }

        [WebMethod(EnableSession = true)]


        public PersonRecord GetPerson(string userId)
        {
            PersonRecord person = new PersonRecord();

            if (PortalUser.Current.IsGuest)
            {
                person.Success = false;
                person.Message = "You do not have permissions to this resource.";
                return person;
            }
            else if (PortalUser.Current.HostID == userId || PortalUser.Current.IsSiteAdmin)
            {
                OdbcConnectionClass3 odbcConn = new OdbcConnectionClass3("ERPDataConnection.config");

                string stmt = "select * from CUS_Addresses5, FWK_User where ID_Number = ? and ID_Number = HostID";

                List<OdbcParameter> parameters = new List<OdbcParameter>
                {
                    new OdbcParameter("id", PortalUser.Current.HostID)
                };

                Exception ex = null;

                DataTable dt = odbcConn.ConnectToERP(stmt, ref ex, parameters);

                int cnt = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    if (cnt == 0)
                    {
                        person.FirstName = dr["FirstName"].ToString();
                        person.Middlename = dr["MiddleName"].ToString();
                        person.LastName = dr["LastName"].ToString();
                        person.Email = dr["Email"].ToString();
                    }
                    person.AddressList.Add(new Address
                    {
                        AddressType = dr["Addr_Code"].ToString(),
                        BeginDate = dr["BeginDate"].ToString(),
                        Line1 = dr["Addr_Line1"].ToString(),
                        Line2 = dr["Addr_Line2"].ToString(),
                        City = dr["City"].ToString(),
                        State = dr["State"].ToString(),
                        Zip = dr["Zip"].ToString(),
                        IsEmail = dr["Addr_Code"].ToString().Trim() == "EML"
                    });

                    cnt++;
                }
            }
            return person;
        }

    }

    public class ReturnData
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Value { get; set; }

        public ReturnData()
        {
            Success = true;
        }
    }

    public class Address : ReturnData
    {
        public string UserId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string BeginDate { get; set; }
        public string AddressType { get; set; }

        public bool IsEmail { get; set; }
    }

    public class PersonRecord : ReturnData
    {
        public string FirstName { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Address> AddressList { get; set; }

        public PersonRecord()
        {
            AddressList = new List<Address>();
        }
    }
}

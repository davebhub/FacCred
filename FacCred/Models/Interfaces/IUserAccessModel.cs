using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FacCred.Models.Interfaces
{
    public class IUserAccessModel
    {
        interface IDisciplineModel
        {
            DataTable getDataSQL();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacCred.Models.Interfaces
{
    interface IDropDowns
    {
        DataTable getYears();
        DataTable getTerms();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacCred.Views.Interfaces
{
    interface IDropDownView
    {
        DataSet getTerms();
        DataSet getYears();
    }
}

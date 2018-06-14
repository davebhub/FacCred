using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacCred.Reports
{
    public class GCReportParameter
    {
        private string _name = String.Empty;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _value = String.Empty;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private string _prompt = String.Empty;
        public string Prompt
        {
            get { return _prompt; }
            set { _prompt = value; }
        }

        public GCReportParameter() { }

        public GCReportParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public GCReportParameter(string name, string value, string prompt)
        {
            this.Name = name;
            this.Value = value;
            Prompt = prompt;
        }

        public String DisplayName()
        {
            return String.IsNullOrEmpty(Prompt) ? "(" + Name + ")" : Prompt;
        }

        public static List<GCReportParameter> buildParameterList(string parameters)
        {
            List<GCReportParameter> plist = new List<GCReportParameter>();
            if (parameters.Trim() != String.Empty)
            {
                string[] pArray = parameters.Split(';');

                int cnt = 0;
                foreach (string s in pArray)
                {
                    string tmp = s;
                    tmp = tmp.TrimStart('[');
                    tmp = tmp.TrimEnd(']');
                    string[] p = tmp.Split(',');
                    plist.Add(new GCReportParameter(p[0], p[1]));
                }
            }
            return plist;
        }
    }
}

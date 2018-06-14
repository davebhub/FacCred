using System;
using System.Runtime.Serialization;

namespace FacCred.Reports
{
    [DataContract]
    public class ReportSearchResult
    {
        [DataMember]
        public String ItemId { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String Location { get; set; }

        public ReportSearchResult()
        {
        }

        public ReportSearchResult(String itemId, string name, string location)
        {
            ItemId = itemId;
            Name = name;
            Location = location;
        }
    }
}
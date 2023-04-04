using System;
using System.Collections.Generic;
using System.Text;

namespace WOSProjectNew.JSONData
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Instance
    {
        public string Metric_Type { get; set; }
        public int Count { get; set; }
    }

    public class InstitutionID
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class Performance
    {
        public Period Period { get; set; }
        public List<Instance> Instance { get; set; }
    }

    public class Period
    {
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class ReportAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ReportFilter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ReportHeader
    {
        public DateTime Created { get; set; }
        public string Created_By { get; set; }
        public string Customer_ID { get; set; }
        public string Report_ID { get; set; }
        public string Release { get; set; }
        public string Report_Name { get; set; }
        public string Institution_Name { get; set; }
        public List<InstitutionID> Institution_ID { get; set; }
        public List<ReportFilter> Report_Filters { get; set; }
        public List<ReportAttribute> Report_Attributes { get; set; }
    }

    public class ReportItem
    {
        public string Platform { get; set; }
        public string Access_Method { get; set; }
        public List<Performance> Performance { get; set; }
    }

    public class Root
    {
        
        public ReportHeader Report_Header { get; set; }
        public List<ReportItem> Report_Items { get; set; }
    }


}

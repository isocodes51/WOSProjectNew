using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WOSProjectNew.Data
{
    public class EbscoJsonData 
    {
       

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

        public class ItemID
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
        }

        public class ReportItem
        {
            public string Platform { get; set; }
            public string Title { get; set; }
            public List<ItemID> Item_ID { get; set; }
            public string Publisher { get; set; }
            public List<Performance> Performance { get; set; }
        }

        public class Root
        {
            public ReportHeader Report_Header { get; set; }
            public List<ReportItem> Report_Items { get; set; }
        }


    }
}

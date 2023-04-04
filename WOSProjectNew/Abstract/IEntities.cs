using System;
using System.Collections.Generic;
using System.Text;

namespace WOSProjectNew.Abstract
{
    public interface IEntities
    {
        public string Method { get; set; }
        public string URL { get; set; }
        public string ApiKey { get; set; }
        public string UsrQuery { get; set; }
        public string DataBase { get; set; }
        public int Countx { get; set; }
        public int FirstRecord { get; set; }
        public string CustomerId { get; set; }
        public string RequestorId { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string DataType { get; set; }
        public string AccessMethod { get; set; }
        public string Granularity { get; set; }
        public string AttributesToShow { get; set; }

    }
}

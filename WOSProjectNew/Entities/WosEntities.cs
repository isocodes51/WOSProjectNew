using System;
using System.Collections.Generic;
using System.Text;
using WOSProjectNew.Abstract;

namespace WOSProjectNew.Entities
{
    public class WosEntities: IEntities
    {
        public string Method { get; set; }
        public string URL { get; set; }
        public string ApiKey { get; set; }
        public string UsrQuery { get; set; }
        public string DataBase { get; set; }
        public int Countx { get; set; }
        public int FirstRecord { get; set; }
        public string CustomerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RequestorId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BeginDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EndDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DataType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AccessMethod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

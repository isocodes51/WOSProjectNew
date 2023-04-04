using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WOSProjectNew.Abstract;
using WOSProjectNew.Entities;
using WOSProjectNew.JSONData;

namespace WOSProjectNew.Concrete
{
    public class EbscoManager2 : IDb
    {
        public void Conn(IEntities e)
        {
            
            HttpWebRequest xhr = WebRequest.Create(
                                  e.URL +
                                  "?customer_id=" + e.CustomerId +
                                  "&requestor_id=" + e.RequestorId +
                                  "&begin_date=" + e.BeginDate +
                                  "&end_date=" + e.EndDate +
                                  "&data_type=" + e.DataType +
                                  "&access_method=" + e.AccessMethod +
                                  "&granularity=" + e.Granularity
                               ) as HttpWebRequest;
           
            Console.WriteLine(xhr.RequestUri);
            xhr.Method = e.Method;
            
            string data = "";
            using (HttpWebResponse res = xhr.GetResponse() as HttpWebResponse)
            {
                Console.WriteLine("Status: " + res.StatusCode);
                Console.WriteLine("Header: " + res.Headers);
                StreamReader reader = new StreamReader(res.GetResponseStream());
                data = reader.ReadToEnd();
            }
            
            Root root = JsonConvert.DeserializeObject<Root>(data);

            //ReportHeader reportHeader = root.Report_Header;
            List<ReportItem> reportItem = root.Report_Items;
            int toplam = 0;
            foreach (var item in reportItem)
            {
                List<Performance> performance = item.Performance;
                foreach (var items in performance)
                {
                    List<Instance> instance = items.Instance;
                    foreach (var itemss in instance)
                    {
                        //Console.WriteLine(itemss.Metric_Type);
                      if(itemss.Metric_Type == "Unique_Item_Requests")
                        {
                            toplam+=itemss.Count;
                        }
                    }
                }

            }
            Console.WriteLine(toplam);

            //var message = reportHeader.Report_Name != null
            //    ? reportHeader.Report_Name
            //    : "Null Değer Dönüyor";
            //Console.WriteLine($"\n------Mesaj: {message}-------");
        }
    }
}

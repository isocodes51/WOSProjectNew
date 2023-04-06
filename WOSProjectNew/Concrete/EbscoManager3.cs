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
    public class EbscoManager3 : IDb
    {
        string data = "";
        int toplam = 0;
       
       
        
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

            //Console.WriteLine(xhr.RequestUri);
            xhr.Method = e.Method;


            using (HttpWebResponse res = xhr.GetResponse() as HttpWebResponse)
            {
                //Console.WriteLine("Status: " + res.StatusCode);
                //Console.WriteLine("Header: " + res.Headers);
                StreamReader reader = new StreamReader(res.GetResponseStream());
                data = reader.ReadToEnd();
            }
            GetCount(data);
            
        }


        public void GetCount(string myData)
        {
            
            Root root = JsonConvert.DeserializeObject<Root>(myData);
            //ReportHeader reportHeader = root.Report_Header;
            List<ReportItem> reportItem = root.Report_Items;
            List<int> toplamDeger = new List<int>();
            List<string> itemName = new List<string> { "Unique_Item_Requests", "Unique_Item_Investigations", "Total_Item_Requests", "Total_Item_Investigations" };
            List<Performance> performance;
            List<Instance> instance;

            foreach (var item in reportItem)
            {
                performance = item.Performance;
                foreach (var items in performance)
                {
                    instance = items.Instance;
                    foreach (var itemss in instance)
                    {
                       
                            if (itemss.Metric_Type == "Unique_Item_Requests")
                            {
                               // Console.WriteLine(itemName[i]);
                                toplam += itemss.Count;
                            }
                            
                        
                    }
                }
            }
            Console.WriteLine(toplam);
        }


       public void SonucGetir(IEntities e)
        {

            Conn(e);

           
               // Console.WriteLine(GetCount(data));
            
            
            
        }



    }    
}

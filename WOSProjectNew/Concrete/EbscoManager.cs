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
namespace WOSProjectNew.Concrete
{
    public class EbscoManager : IDb
    {
        public void Conn(IEntities e)
        {
            Console.WriteLine("URL: " +e.URL);
            HttpWebRequest xhr = (HttpWebRequest)HttpWebRequest.Create(
                                  e.URL +
                                  "?customer_id=" + e.CustomerId +
                                  "&requestor_id=" + e.RequestorId+
                                  "&begin_date="+e.BeginDate+
                                  "&end_date="+e.EndDate+
                                  "&data_type="+e.DataType+
                                  "&access_method="+e.AccessMethod+
                                  "&granularity=" + e.Granularity+
                                  "&attributes_to_show="+e.AttributesToShow
                               );

            xhr.Method = e.Method;
            HttpWebResponse res = xhr.GetResponse() as HttpWebResponse;
            Console.WriteLine("Status: " + res.StatusCode);
            Console.WriteLine("Content Type: " + res.ContentType);
            string data;

            using (Stream stream = res.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
                data = sr.ReadToEnd();
            }

            Console.WriteLine("------------------------");
            JToken jsonData = JToken.Parse(data);
            JObject myData = JsonConvert.DeserializeObject<JObject>(data);
           
            int total1 = 0, total2=0;
            foreach (var item in myData["Report_Items"])
            {
                Console.WriteLine(item["Performance"][0]["Instance"]);
                total1 += (int)item["Performance"][0]["Instance"][0]["Count"]; //Unique
                total2 += (int)item["Performance"][0]["Instance"][1]["Count"]; //Total
            }
            Console.WriteLine("Total: "+total2);
            Console.WriteLine("Unique: "+total1);
        }
    }
}

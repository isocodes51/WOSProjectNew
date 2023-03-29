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
                                  "data_type="+e.DataType+
                                  "access_method"+e.AccessMethod

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

            var jsonData = JObject.Parse(data).Children() ;
            List<JToken> tokens = jsonData.Children().Children().ToList();
            // int bulunanKayitSayisi = (int)tokens[0]["Report_Name"];
            //Console.WriteLine("Bulunan Kayıt Sayısı: " + bulunanKayitSayisi);

            //Console.WriteLine(tokens[1]);
            //Console.WriteLine("Sayı: "+tokens.Count);


            //Console.WriteLine(tokens[0]["Platform"]);
            Console.WriteLine(tokens.Count);    
           
               // Console.WriteLine(tokens[1]);
            
          for(int i=0; i < tokens.Count; i++)
            {
                foreach (var item in tokens[0])
                {
                    Console.WriteLine(item);
                }
                
            }
           









        }


    }
}

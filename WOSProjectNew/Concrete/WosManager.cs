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
using WOSProjectNew.Concrete;
using WOSProjectNew.Entities;


namespace WOSProjectNew
{
    public class WosManager :IWos
    {
        public void Conn(WosEntities e)
        {
          HttpWebRequest xhr = (HttpWebRequest)HttpWebRequest.Create(
                                  e.URL+
                                  "?databaseId="+e.DataBase+
                                  "&usrQuery="+e.UsrQuery+
                                  "&count="+e.Countx+
                                  "&firstRecord="+e.FirstRecord
                               );
           
            xhr.Method = e.Method;
            xhr.Headers.Add("X-ApiKey", e.ApiKey);

            HttpWebResponse res = xhr.GetResponse() as HttpWebResponse;

            Console.WriteLine("Status: "+res.StatusCode);
            Console.WriteLine("Content Type: "+res.ContentType);
            string data;
            //using (StreamReader sr = new StreamReader(res.GetResponseStream()))

            using (Stream stream = res.GetResponseStream())
            {

                StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
                data = sr.ReadToEnd();
               

               // List<WosDBEntities> items = JsonConvert.DeserializeObject<List<WosDBEntities>>(data);

            }


            // var it = JsonConvert.DeserializeObject<List<WosDBEntities>>(data);

            //foreach (WosDBEntities item in it)
            //{
            //    Console.WriteLine("Authors:" + item.Authors);
            //}

            //sr.Close();

            // List<WosDBEntities> items = JsonConvert.DeserializeObject<List<WosDBEntities>>(data);
            //WosDBEntitiesManager items = JsonConvert.DeserializeObject<WosDBEntitiesManager>(data);
            //Console.WriteLine("---------DATA---------------");
            
            //foreach (var item in items.dBEntities)
            //{
            //    Console.WriteLine(item.UT);
            //}




            Console.WriteLine("------------------------");
            //foreach (var item in items)
            //{
            //    Console.WriteLine(item.Authors);
            //}

            //foreach (var item in items.dBEntities)
            //{
            //    Console.WriteLine(item.UT);
            //}

            //var converter = new ExpandoObjectConverter();
            //dynamic jsonRes = JsonConvert.DeserializeObject<ExpandoObject>(data, converter);
            //jsonRes.Works = true;

            //dynamic jsonRes = JsonConvert.DeserializeObject(data);
            //foreach (var item in jsonRes)
            //{
            //    Console.WriteLine(item["UT"]);
            //}



            //foreach (WosDBEntities item in jsonRes)
            //{
            //    Console.WriteLine(item.UT);
            //}
            //foreach (var item in jsonRes)
            //{
            //    Console.WriteLine(item);
            //}

            var jsonData = JObject.Parse(data).Children();
            List<JToken> tokens = jsonData.Children().ToList();
            int bulunanKayitSayisi = (int)tokens[0]["RecordsFound"];
            Console.WriteLine("Bulunan Kayıt Sayısı: "+ bulunanKayitSayisi);
            
            
            for (int i=0; i<bulunanKayitSayisi; i++)
            {
                
                Console.WriteLine(tokens[1][i]["UT"]);
            }
           
            
            
            
            
            //Console.WriteLine(tokens[1][0]["Title"].ToString());
            //foreach (var item in tokens[1][0])
            //{
                
            //    //Console.WriteLine(tokens[1][0]["Author"]["Authors"].ToString(0).Trim());
            //    Console.WriteLine(item["UT"].ToString());
            //}
            
            //foreach (var item in tokens)
            //{
            //    Console.WriteLine(item["UT"].ToString());
            //}
            //foreach (var item in tokens)
            //{
            //    Console.WriteLine(item[1][0]["UT"].ToString());
            //}
            
           
           
        }


    }
    
}


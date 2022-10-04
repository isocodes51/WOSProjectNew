using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WOSProjectNew.Abstract;
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

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                var data = sr.ReadToEnd();
               

               // List<WosDBEntities> items = JsonConvert.DeserializeObject<List<WosDBEntities>>(data);
                
              var it = JsonConvert.DeserializeObject<List<WosDBEntities>>(data);
              
                foreach (WosDBEntities item in it)
                {
                    Console.WriteLine("Authors:"+item.Authors);
                }
                
                sr.Close();
            }


            





        }


    }
    
}


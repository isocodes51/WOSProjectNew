using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WOSProjectNew
{
    public class Connection
    {
        public void Conn()
        {
            HttpWebRequest xhr = (HttpWebRequest)HttpWebRequest.Create("https://wos-api.clarivate.com/api/woslite/?databaseId=WOS&usrQuery=TS%3D%28cadmium%29&count=5&firstRecord=1");
            xhr.Method = "GET";
            xhr.Headers.Add("X-ApiKey", "6b46ffda86a7a3e9aa2336cd846bfd5f09e18708");

            HttpWebResponse res = xhr.GetResponse() as HttpWebResponse;

            StreamReader sr = new StreamReader(res.GetResponseStream());
            string data = sr.ReadToEnd();
            sr.Close();
            xhr.ContentType = "text/xml";
            Console.WriteLine("Data:" + data);



        }

        //public void Conn2()
        //{
        //    HttpClient client = new HttpClient();

        //    HttpRequestMessage request = new HttpRequestMessage(System.Net.Http.HttpMethod.Get, "https://wos-api.clarivate.com/api/woslite/?databaseId=WOS&lang=English&usrQuery=%C5%9EE%C5%9EEN%2C%20YAS%C4%B0N&count=100&firstRecord=1");

        //    request.Headers.Add("accept", "application/json");
        //    request.Headers.Add("X-ApiKey", "6b46ffda86a7a3e9aa2336cd846bfd5f09e18708");

        //    //HttpResponseMessage response = await client.SendAsync(request);
        //    //response.EnsureSuccessStatusCode();
        //    //string responseBody = await response.Content.ReadAsStringAsync();
        //}

    }
}
}

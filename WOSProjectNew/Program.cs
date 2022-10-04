using System;
using WOSProjectNew.Entities;
namespace WOSProjectNew
{
    public class Program
    {
        static void Main(string[] args)
        {
            WosEntities ent = new WosEntities();
            ent.URL = "https://wos-api.clarivate.com/api/woslite/";
            ent.DataBase = "WOS";
            ent.ApiKey = "6b46ffda86a7a3e9aa2336cd846bfd5f09e18708";
            ent.Method = "GET";
            ent.UsrQuery = "AI=(AAH-5920-2020)";
            ent.Countx = 5;
            ent.FirstRecord = 4;
             
            WosManager wos = new WosManager();
                wos.Conn(ent);
        }
    }
}

using System;
using WOSProjectNew.Abstract;
using WOSProjectNew.Concrete;
using WOSProjectNew.Entities;
namespace WOSProjectNew
{
    public class Program
    {
        static void Main(string[] args)
        {
           IEntities ent = new WosEntities()
            {
              URL = "https://wos-api.clarivate.com/api/woslite/",
              DataBase = "WOS",
              ApiKey = "6b46ffda86a7a3e9aa2336cd846bfd5f09e18708",
              Method = "GET",
              UsrQuery = "AI=(AAH-5920-2020)",
              Countx = 4,
              FirstRecord = 1
            };

            IEntities ent2 = new EbscoEntities
            {
                URL = "https://sushi.ebscohost.com/R5/reports/tr",
                CustomerId = "s1043226",
                RequestorId = "252301c4-8da9-4de7-88ab-96afc989a17d",
                Method="GET",
                BeginDate="2022-01-01",
                EndDate="2022-12-31",
                DataType="Journal",
                AccessMethod="Regular"
            };

            //IDb wos = new WosManager();
            //    wos.Conn(ent);

            IDb ebs = new EbscoManager();
            ebs.Conn(ent2);
        }
    }
}

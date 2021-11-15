using DBCovid.Data;
using DBCovid.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class HomeController : Controller
    {
        private DBCovidContext data = new DBCovidContext();
        public ActionResult Index()
        {
            getdataAsync();
            return View();
        }

        public async Task getdataAsync()
        {
            try
            {
                HttpClient client = new HttpClient();

                //HttpResponseMessage lTinh = await client.GetAsync("https://provinces.open-api.vn/api/p/");
                //HttpResponseMessage lHuyen = await client.GetAsync("https://provinces.open-api.vn/api/d/");
                HttpResponseMessage lXa = await client.GetAsync("https://provinces.open-api.vn/api/w/");

                //var tinh = new List<Tinhs>();
                var huyen = new List<Huyens>();
                var xa = new List<Xas>();

                //if (lTinh.IsSuccessStatusCode)
                //{
                //    string categories = await lTinh.Content.ReadAsStringAsync();
                //    tinh = (List<Tinhs>)JsonConvert.DeserializeObject(categories, new List<Tinhs>().GetType());

                //}
                //if (lHuyen.IsSuccessStatusCode)
                //{
                //    string categories = await lHuyen.Content.ReadAsStringAsync();
                //    huyen = (List<Huyens>)JsonConvert.DeserializeObject(categories, new List<Huyens>().GetType());
                //}
                if (lXa.IsSuccessStatusCode)
                {
                    string categories = await lXa.Content.ReadAsStringAsync();
                    xa = (List<Xas>)JsonConvert.DeserializeObject(categories, new List<Xas>().GetType());
                }
                //foreach (var it in tinh) {
                //    data.tinh.Add(new Tinh()
                //    {
                //        tenTinh = it.name,
                //        code = it.code
                //    });
                //    data.SaveChanges();
                //}
                //foreach (var it in huyen)
                //{
                //    data.huyen.Add(new Huyen()
                //    {
                //        tenHuyen = it.name,
                //        code = it.code,
                //        tinhID = data.tinh.Where(s => s.code == it.province_code).FirstOrDefault().ID
                //    });
                //    data.SaveChanges();
                //}
                foreach (var it in xa)
                {
                    data.xa.Add(new Xa()
                    {
                        tenXa = it.name,
                        code = it.code,
                        huyenID = data.huyen.Where(s => s.code == it.district_code).FirstOrDefault().ID
                    });
                    data.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        [Serializable]
        class Tinhs
        {
            public string name;
            public int code;
            public string division_type;
            public string codename;
            public string phone_code;
            public object[] districts;

        }
        [Serializable]
        class Huyens
        {
            public string name;
            public int code;
            public string division_type;
            public string codename;
            public int province_code;

        }
        [Serializable]
        class Xas
        {
            public string name;
            public int code;
            public string division_type;
            public string codename;
            public int district_code;
        }
    }
}
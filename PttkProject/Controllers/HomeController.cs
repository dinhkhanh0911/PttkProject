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
        public ActionResult Index()
        {
            getdataAsync();
            return View();
        }

        public async Task getdataAsync()
        {
            try
            {
                string url = "https://emoh.moh.gov.vn/api/khamchuabenh/tiem_nhan_kcb_xml";
                string tinh = "https://provinces.open-api.vn/api/p/";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://emoh.moh.gov.vn/api/tra-cuu-hoso-kcb?");

                var Items = new List<Items>();

                if (response.IsSuccessStatusCode)
                {
                    string categories = await response.Content.ReadAsStringAsync();
                    var ss = JsonConvert.DeserializeObject(categories, new List<Items>().GetType());

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        [Serializable]
        class Items
        {
            public string name;
            public int code;
            public string division_type;
            public string codename;
            public string phone_code;
            public object[] districts;

        }
    }
}
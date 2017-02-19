using MVC_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_Client.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:52661/api");
        HttpClient client = new HttpClient();

        public UserController()
        {
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            List<UserViewModel> modelList = new List<UserViewModel>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/userapi").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/userapi", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string msg = response.Content.ReadAsStringAsync().Result;
                if (msg == "created")
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
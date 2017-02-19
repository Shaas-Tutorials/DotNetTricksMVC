using MVC_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

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
           
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/userapi").Result;
            if (response.IsSuccessStatusCode)
            {
                //string data = response.Content.ReadAsStringAsync().Result;
                //modelList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);

                var serializer = new XmlSerializer(typeof(List<UserViewModel>));
                Stream stream = response.Content.ReadAsStreamAsync().Result;
                modelList = serializer.Deserialize(stream) as List<UserViewModel>;
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

        public ActionResult Edit(int id)
        {
            UserViewModel model = new UserViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/userapi/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<UserViewModel>(data);
            }
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/userapi/"+model.UserId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                string msg = response.Content.ReadAsStringAsync().Result;
                if (msg == "updated")
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            UserViewModel model = new UserViewModel();
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/userapi/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string msg = response.Content.ReadAsStringAsync().Result;
                if (msg == "true")
                {
                    return RedirectToAction("index");
                }
            }
            return RedirectToAction("index");
        }
    }
}
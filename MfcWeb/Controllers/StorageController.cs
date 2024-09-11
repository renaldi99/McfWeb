using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using MfcWeb.Models;
using MfcWeb.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MfcWeb.Controllers
{
    public class StorageController : Controller
    {
        public IActionResult ListStorage()
        {
            var username = HttpContext.Session.GetString("username");
            ViewData["username"] = username;

            if (username == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public IActionResult LoadData()
        {
            var response = RestUtils.CallPost(Constans.WEB_URI + "/StorageLoc/GetListLocation", string.Empty, "application/json", 10);
            dynamic objcontent = JsonConvert.DeserializeObject<ExpandoObject>(response.ToString());
            return Json(objcontent);
        }

        public IActionResult AddStorage()
        {
            var username = HttpContext.Session.GetString("username");
            ViewData["username"] = username;

            if (username == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddStorage([FromBody] StorageModel entity)
        {
            if (ModelState.IsValid)
            {

                IDictionary<string, object> req = new Dictionary<string, object>
                {
                    {
                        "location_name", entity.location_name
                    },
                };
                var response = RestUtils.CallPost(Constans.WEB_URI + "/StorageLoc/InsertLocation", JsonConvert.SerializeObject(req), "application/json", 10);
                dynamic objcontent = JsonConvert.DeserializeObject<ExpandoObject>(response.ToString());
                int resStatusCode = (int)objcontent?.status_code;

                if (resStatusCode == 200)
                {
                    return Json("success");
                }

                return Json("fail");
            }

            return View();
        }
    }
}
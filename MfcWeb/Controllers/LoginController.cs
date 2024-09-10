using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MfcWeb.Models;
using MfcWeb.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MfcWeb
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([FromBody] UserLoginModel entity)
        {
            if (ModelState.IsValid)
            {
                IDictionary<string, object> req = new Dictionary<string, object>
                {
                    { "user_name", entity.username },
                    { "password", entity.password },
                };
                var response = RestUtils.CallPost(Constans.WEB_URI + "/User/LoginUser", JsonConvert.SerializeObject(req), "application/json", 10);
                dynamic objcontent = JsonConvert.DeserializeObject<ExpandoObject>(response.ToString());
                int resStatusCode = (int)objcontent?.status_code;

                if (resStatusCode == 200)
                {
                    HttpContext.Session.SetString("username", (string)objcontent.data.user_name);
                    HttpContext.Session.SetString("password", (string)objcontent.data.password);
                    HttpContext.Session.SetInt32("user_id", (int)objcontent.data.user_id);

                    return Json("success");
                }

                return Json("fail");
            }

            return View();
        }
    }
}
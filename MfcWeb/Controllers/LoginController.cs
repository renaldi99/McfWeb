using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using MfcWeb.Models;
using MfcWeb.Utility;
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
                // Handle the data
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
                    return Json(objcontent);
                }

                return BadRequest("Invalid login attempt");
            }

            return View();
        }
    }
}
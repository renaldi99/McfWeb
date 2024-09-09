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
    public class BpkbController : Controller
    {
        public IActionResult ListBpkb()
        {
            return View();
        }

        public IActionResult LoadData()
        {
            var response = RestUtils.CallPost(Constans.WEB_URI + "/BPKB/ListDataBpkb", string.Empty, "application/json", 10);
            dynamic objcontent = JsonConvert.DeserializeObject<ExpandoObject>(response.ToString());
            int resStatusCode = (int)objcontent?.status_code;
            return Json(objcontent);
        }
    }
}
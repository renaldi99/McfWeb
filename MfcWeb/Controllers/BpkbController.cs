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
            var response = RestUtils.CallPost(Constans.WEB_URI + "/BPKB/ListDataBpkb", string.Empty, "application/json", 10);
            dynamic objcontent = JsonConvert.DeserializeObject<ExpandoObject>(response.ToString());
            return Json(objcontent);
        }

        public IActionResult AddBpkb()
        {
            var username = HttpContext.Session.GetString("username");
            var user_id = HttpContext.Session.GetInt32("user_id");
            ViewData["username"] = username;
            ViewData["user_id"] = user_id;

            if (username == null)
            {
                return RedirectToAction("Login", "Login");
            }


            return View();
        }

        public IActionResult LoadStorage()
        {
            var response = RestUtils.CallPost(Constans.WEB_URI + "/StorageLoc/GetListLocation", string.Empty, "application/json", 10);
            dynamic objcontent = JsonConvert.DeserializeObject<ExpandoObject>(response.ToString());
            return Json(objcontent);
        }

        [HttpPost]
        public IActionResult AddBpkb([FromBody] InputBpkbModel entity)
        {
            if (ModelState.IsValid)
            {
                DateTime bpkb_date_in = DateTime.ParseExact(entity.bpkb_date_in, "yyyy-MM-dd HH:mm:ss", null);
                DateTime bpkb_date = DateTime.ParseExact(entity.bpkb_date, "yyyy-MM-dd HH:mm:ss", null);
                DateTime faktur_date = DateTime.ParseExact(entity.faktur_date, "yyyy-MM-dd HH:mm:ss", null);

                IDictionary<string, object> req = new Dictionary<string, object>
                {
                    {
                        "branch_id", entity.branch_id
                    },
                    {
                        "bpkb_no", entity.bpkb_no
                    },
                    {
                        "bpkb_date_in", bpkb_date_in.ToString("yyyy-MM-ddTHH:mm:ss")
                    },
                    {
                        "bpkb_date", bpkb_date.ToString("yyyy-MM-ddTHH:mm:ss")
                    },
                    {
                        "faktur_no", entity.faktur_no
                    },
                    {
                        "faktur_date", faktur_date.ToString("yyyy-MM-ddTHH:mm:ss")
                    },
                    {
                        "police_no", entity.police_no
                    },
                    {
                        "location_id", entity.location_id
                    },
                    {
                        "user_id", entity.user_id
                    },
                };
                var response = RestUtils.CallPost(Constans.WEB_URI + "/BPKB/InsertDataBpkb", JsonConvert.SerializeObject(req), "application/json", 10);
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

        public IActionResult GetBpkb([FromQuery] int agreement_number)
        {
            var response = RestUtils.CallPost(Constans.WEB_URI + $"/BPKB/GetDataBpkbByAgreementNumber?agreement_number={agreement_number}", string.Empty, "application/json", 10);
            dynamic objcontent = JsonConvert.DeserializeObject<ExpandoObject>(response.ToString());
            return Json(objcontent);
        }

        public IActionResult UpdateBpkb([FromQuery] int agreement_number)
        {
            var username = HttpContext.Session.GetString("username");
            var user_id = HttpContext.Session.GetInt32("user_id");
            ViewData["username"] = username;
            ViewData["user_id"] = user_id;
            ViewData["agreement_number"] = agreement_number;

            if (username == null)
            {
                return RedirectToAction("Login", "Login");
            }


            return View();
        }

        [HttpPost]
        public IActionResult UpdateBpkb([FromBody] UpdateBpkbModel entity)
        {
            if (ModelState.IsValid)
            {
                DateTime bpkb_date_in = DateTime.ParseExact(entity.bpkb_date_in, "yyyy-MM-dd HH:mm:ss", null);
                DateTime bpkb_date = DateTime.ParseExact(entity.bpkb_date, "yyyy-MM-dd HH:mm:ss", null);
                DateTime faktur_date = DateTime.ParseExact(entity.faktur_date, "yyyy-MM-dd HH:mm:ss", null);

                IDictionary<string, object> req = new Dictionary<string, object>
                {
                    {
                        "agreement_number", entity.agreement_number
                    },
                    {
                        "branch_id", entity.branch_id
                    },
                    {
                        "bpkb_no", entity.bpkb_no
                    },
                    {
                        "bpkb_date_in", bpkb_date_in.ToString("yyyy-MM-ddTHH:mm:ss")
                    },
                    {
                        "bpkb_date", bpkb_date.ToString("yyyy-MM-ddTHH:mm:ss")
                    },
                    {
                        "faktur_no", entity.faktur_no
                    },
                    {
                        "faktur_date", faktur_date.ToString("yyyy-MM-ddTHH:mm:ss")
                    },
                    {
                        "police_no", entity.police_no
                    },
                    {
                        "location_id", entity.location_id
                    },
                    {
                        "user_id", entity.user_id
                    },
                };
                var response = RestUtils.CallPost(Constans.WEB_URI + "/BPKB/UpdateDataBpkb", JsonConvert.SerializeObject(req), "application/json", 10);
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
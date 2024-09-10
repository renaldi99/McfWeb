using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MfcWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MfcWeb.Controllers
{
    public class StorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStorage([FromBody] StorageModel entity)
        {
            return View();
        }
    }
}
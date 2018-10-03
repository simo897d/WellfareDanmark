using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WelfareDenmark.TrainingBuddy.Web.Models;

namespace WelfareDenmark.TrainingBuddy.Web.Controllers
{
    public class FrontPageController : Controller
    {
        public IActionResult PageOne()
        {

            return View();
        }
    }
}

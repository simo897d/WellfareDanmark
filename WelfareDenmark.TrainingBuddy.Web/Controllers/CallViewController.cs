using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WelfareDenmark.TrainingBuddy.Web.Controllers
{
    public class CallViewController : Controller
    {
        public IActionResult CallSite()
        {
            return View();
        }
    }
}
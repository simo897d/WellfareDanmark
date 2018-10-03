using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WelfareDenmark.TrainingBuddy.Web.Models;

namespace WelfareDenmark.TrainingBuddy.Web.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {

        public IActionResult Index() {
            return View();
        }

        public IActionResult CreateTeam()
        {
            return View();
        }
    }
}
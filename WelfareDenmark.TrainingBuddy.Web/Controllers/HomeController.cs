using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WelfareDenmark.TrainingBuddy.Web.Models;

namespace WelfareDenmark.TrainingBuddy.Web.Controllers
{
    public class HomeController : Controller
    {

        private TrainingBuddyDataContext _db { get; set; }

        public HomeController(TrainingBuddyDataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            User testUser1 = new User
            {
                Name = "Gerda Jørgensen",
                Username = "SlutyBitch02",
                Password = "HeyYo"
            };

            _db.TbUser.Add(testUser1);
            _db.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
        //private TrainingBuddyDataContext _db { get; set; }

        //public TeamController(TrainingBuddyDataContext db)
        //{
        //    _db = db;
        //}


        public IActionResult CreateTeam()
        {
            //RegisterViewModel testUser1 = new RegisterViewModel()
            //{
            //    Name = "Gerda Jørgensen",
            //    UserName = "SlutyBitch02",
            //    Password = "HeyYo"
            //};

            //_db.TbUser.Add(testUser1);
            //_db.SaveChanges();


            return View();
        }
    }
}
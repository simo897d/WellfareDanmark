using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WelfareDenmark.TrainingBuddy.Web.Models;

namespace WelfareDenmark.TrainingBuddy.Web.ViewComponents
{
    public class TeamListViewComponent : ViewComponent
    {
        private TrainingBuddyDataContext _db { get; set; }
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityDbContext _identityDb { get; set; }

        public TeamListViewComponent(TrainingBuddyDataContext db, UserManager<IdentityUser> userManager, IdentityDbContext identityDb)
        {
            _db = db;
            _userManager = userManager;
            _identityDb = identityDb;
        }

        public IViewComponentResult Invoke()
        {
            //List<IdentityUser> friends = new List<IdentityUser>();
            //List<UserRelationship> userRelationships = _db.UserRelationships.Where(u => u.UserId == "XXXXXX").ToList();

            //foreach (UserRelationship ur in userRelationships)
            //{
            //    IdentityUser friend = _identityDb.Users.FirstOrDefault(i => i.Id == ur.FriendId);
            //    friends.Add(friend);
            //}

            FriendListViewModel teamListViewModel = new FriendListViewModel
            {
                //Friends = friends
                Friends = new List<User>
                {
                    new User { Id = 1, Name = "Gerda Larsen" },
                    new User { Id = 2, Name = "Karsten Olsen" },
                    new User { Id = 3, Name = "Kim Nielsen" },
                    new User { Id = 4, Name = "Morten Pedersen" },
                    new User { Id = 5, Name = "Hanne Holm" }
                }
            };


            return View(teamListViewModel);
        }
    }
}

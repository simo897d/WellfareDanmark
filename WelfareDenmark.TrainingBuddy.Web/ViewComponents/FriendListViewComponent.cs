using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WelfareDenmark.TrainingBuddy.Web.Models;

namespace WelfareDenmark.TrainingBuddy.Web.ViewComponents
{
    public class FriendListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FriendListViewModel friendListViewModel = new FriendListViewModel
            {
                Users = new List<User>
                {
                    new User { Id = 1, Name = "Gerda Larsen" },
                    new User { Id = 2, Name = "Karsten Olsen" },
                    new User { Id = 3, Name = "Kim Nielsen" },
                    new User { Id = 4, Name = "Morten Pedersen" },
                    new User { Id = 5, Name = "Hanne Holm" }
                }
            };


            return View(friendListViewModel);
        }
    }
}

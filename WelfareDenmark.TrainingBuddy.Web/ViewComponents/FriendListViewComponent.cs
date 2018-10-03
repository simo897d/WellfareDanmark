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
                    new User { Name = "Gerda Larsen" },
                    new User { Name = "Karsten Olsen" },
                    new User { Name = "Kim Nielsen" },
                    new User { Name = "Morten Pedersen" },
                    new User { Name = "Hanne Holm" }
                }
            };


            return View(friendListViewModel);
        }
    }
}

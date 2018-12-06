using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WelfareDenmark.TrainingBuddy.Web.Models
{
    public class FriendListViewModel
    {
        public long Id { get; set; }
        public List<User> Friends { get; set; }
    }
}

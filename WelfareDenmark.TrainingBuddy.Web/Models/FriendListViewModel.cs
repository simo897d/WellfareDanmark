using System;
using System.Collections.Generic;

namespace WelfareDenmark.TrainingBuddy.Web.Models
{
    public class FriendListViewModel
    {
        public long Id { get; set; }
        public List<User> Users { get; set; }
    }
}

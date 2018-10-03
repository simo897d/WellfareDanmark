using System;
namespace WelfareDenmark.TrainingBuddy.Web.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace WelfareDenmark.TrainingBuddy.Web.Models
{
    public class UserRelationship
    {
        [Key]
        public long Id { get; set; }

        public string UserId { get; set; }
        public string FriendId { get; set; }
    }
}

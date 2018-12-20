using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace WelfareDenmark.TrainingBuddy.Web.Models
{
    public partial class TeamTable
    {
        public int TeamId { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime Date { get; set; }

        public Exercises Exercise { get; set; }
        public AspNetUsers User { get; set; }
    }
}

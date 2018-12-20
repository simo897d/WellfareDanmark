using System;
using System.Collections.Generic;

namespace WelfareDenmark.TrainingBuddy.Web.Models
{
    public partial class Exercises
    {
        public Exercises()
        {
            TeamTable = new HashSet<TeamTable>();
        }

        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }

        public ICollection<TeamTable> TeamTable { get; set; }
    }
}

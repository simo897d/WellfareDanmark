using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TeamAPI {
    public class TeamDataStore {
        public static TeamDataStore Current { get; } = new TeamDataStore();
        public TeamDataStore() {


            new Models.Users {
                Id = 1,
                Name = "Falke",
                Phone = 87484838
            };

            new Exercise {
                ExerciseID = 1,
                ExerciseName = "Armbøjninger"
            };

            new Teams{
                TeamsID = 1,
                Participants = null,
                Date = DateTime.Now,
                Exercises = null
            };
        }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}

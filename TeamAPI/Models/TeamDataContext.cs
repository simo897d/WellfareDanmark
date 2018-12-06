using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamAPI.Models;

namespace TeamAPI.Models
{
    public class TeamDataContext : DbContext
    {
        
        public TeamDataContext(DbContextOptions<TeamDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static TeamDataContext Current { get; internal set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}

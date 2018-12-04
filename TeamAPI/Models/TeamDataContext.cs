using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAPI.Models
{
    public class TeamDataContext : DbContext
    {
        public TeamDataContext(DbContextOptions<TeamDataContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<Teams> Teams { get; set; }
    }
}

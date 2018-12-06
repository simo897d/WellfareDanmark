using System;
using Microsoft.EntityFrameworkCore;

namespace WelfareDenmark.TrainingBuddy.Web.Models
{
    public class TrainingBuddyDataContext : DbContext
    {
        public DbSet<UserRelationship> UserRelationships { get; set; }

        public TrainingBuddyDataContext(DbContextOptions<TrainingBuddyDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

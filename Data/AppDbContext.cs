using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Task_Management_System.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<ProjectUser> ProjectUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Task>()
            .HasOne(u => u.Assignee);

            modelBuilder.Entity<Models.Task>()
            .HasOne(p => p.Project);

            modelBuilder.Entity<User>()
            .HasMany(p => p.Projects);

            modelBuilder.Entity<Project>()
            .HasOne(p => p.Creator);

            modelBuilder.Entity<Project>().Property(p => p.Id)
        .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.FirstName);
            modelBuilder.Entity<Models.Task>().Property(p => p.Id)
            .ValueGeneratedOnAdd();

        }
    }
}
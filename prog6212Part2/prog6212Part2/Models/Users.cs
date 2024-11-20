using Microsoft.EntityFrameworkCore;
using System;

namespace prog6212Part2.Models
{
    public class Users
    {
        public Guid UserId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; } 

        public string? Role { get; set; } 

        public string? Password { get; set; } 

        public string? Email { get; set; } 
    }

    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(b => b.UserId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Users>()
                .Property(b => b.Name)
                .IsRequired(); 

            modelBuilder.Entity<Users>()
                .Property(b => b.Surname)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(b => b.Role)
                .IsRequired(); 

            modelBuilder.Entity<Users>()
                .Property(b => b.Password)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(b => b.Email)
                .IsRequired();
        }
    }
}

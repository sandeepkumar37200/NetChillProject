using Microsoft.EntityFrameworkCore;
using Project.DAL.Domain_Models;
using Project.DAL.Seeders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AdminSeeder();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
    }
}

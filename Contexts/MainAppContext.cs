﻿using AonFreelancing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AonFreelancing.Contexts
{
    public class MainAppContext:IdentityDbContext<User, ApplicationRole, long>
    {
        // For TPT design, no need to define each one
        //public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<Client> Clients { get; set; }

        // instead, use User only
        public DbSet<User> Users { get; set; } // Will access Freelancers, Clients, SystemUsers through inheritance and ofType 

        public MainAppContext(DbContextOptions<MainAppContext> contextOptions) : base(contextOptions) {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // For TPT design
            builder.Entity<User>().ToTable("AspNetUsers");
            builder.Entity<Freelancer>().ToTable("Freelancers");
            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<SystemUser>().ToTable("SystemUsers");
            base.OnModelCreating(builder);
        }

    }
}

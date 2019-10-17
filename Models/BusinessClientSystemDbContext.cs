// <copyright file="BusinessClientSystemDbContext.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace BusinessClientSystem.Models
{
    using System;

    using Microsoft.EntityFrameworkCore;

    using SessionManagement.Models;

    public class BusinessClientSystemDbContext : DbContext
    {
        public BusinessClientSystemDbContext(DbContextOptions<BusinessClientSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Email);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

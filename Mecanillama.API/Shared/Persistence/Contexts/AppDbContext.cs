﻿using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mecanillama.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Customers
        builder.Entity<Customer>().ToTable("Customers");
        builder.Entity<Customer>().HasKey(p => p.Id);
        builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Entity<Customer>().Property(p => p.CarMake).IsRequired().HasMaxLength(200);
        builder.Entity<Customer>().Property(p => p.Address).IsRequired().HasMaxLength(200);
        builder.Entity<Customer>().Property(p => p.UserId).IsRequired();
        
        //Relationships
        builder.Entity<Customer>().HasMany(p => p.Appointments)
            .WithOne(p => p.Customer)
            .HasForeignKey(p => p.CustomerId);
        
        //Mechanics
        builder.Entity<Mechanic>().ToTable("Mechanics");
        builder.Entity<Mechanic>().HasKey(p => p.Id);
        builder.Entity<Mechanic>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Mechanic>().Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Entity<Mechanic>().Property(p => p.Description).IsRequired().HasMaxLength(300);
        builder.Entity<Mechanic>().Property(p => p.Phone).IsRequired();
        builder.Entity<Mechanic>().Property(p => p.Address).IsRequired().HasMaxLength(200);
        builder.Entity<Mechanic>().Property(p => p.UserId).IsRequired();

        //Relationships
        builder.Entity<Mechanic>().HasMany(p => p.Appointments)
            .WithOne(p => p.Mechanic)
            .HasForeignKey(p => p.MechanicId);
        
        builder.Entity<Mechanic>().HasMany(p => p.Reviews)
            .WithOne(p => p.Mechanic)
            .HasForeignKey(p => p.MechanicId);
        
        //Appointments
        builder.Entity<Appointment>().ToTable("Appointments");
        builder.Entity<Appointment>().HasKey(p => p.Id);
        builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appointment>().Property(p => p.Date).IsRequired().HasMaxLength(200);
        builder.Entity<Appointment>().Property(p => p.Time).IsRequired().HasMaxLength(200);
        builder.Entity<Appointment>().Property(p => p.CustomerId).IsRequired();
        builder.Entity<Appointment>().Property(p => p.MechanicId).IsRequired();

        //Relationships
        
        //Reviews
        builder.Entity<Review>().ToTable("Reviews");
        builder.Entity<Review>().HasKey(p => p.Id);
        builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(p => p.Comment).IsRequired().HasMaxLength(40);
        builder.Entity<Review>().Property(p => p.Score).IsRequired();
        
        //Relationships
        
        //Snake Case Conventions
        
        builder.UseSnakeCaseNamingConvention();
        
    }

}
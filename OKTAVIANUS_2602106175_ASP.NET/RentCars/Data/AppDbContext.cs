using System;
using Microsoft.EntityFrameworkCore;
using RentCars.Models;

namespace RentCars.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<MsCar> Car {get; set;}

    public DbSet<MsCarImages> CarImages {get; set;}

    public DbSet<MsCustomer> Customer {get; set;}

    public DbSet<MsEmployee> Employee {get; set;}

    public DbSet<TrMaintenance> Maintenance {get; set;}

    public DbSet<TrPayment> Payment {get; set;}

     public DbSet<TrRental> Rental {get; set;}
}

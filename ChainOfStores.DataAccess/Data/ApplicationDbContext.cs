﻿using ChainOfStores.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ChainOfStores.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Bakery> Bakeries { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { 
                    Id = 1,
                    FirstName = "Ara",
                    LastName = "Harutyunyan",
                    DateOfEmployment = new DateTime(2013, 01, 15),
                    PhoneNumber = "044785545",
                    ShopId=1,
                    SalaryId=1,
                    RoleId=1,
                    ImageURL= "https://images.pexels.com/photos/39866/entrepreneur-startup-start-up-man-39866.jpeg?auto=compress&cs=tinysrgb&w=600"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Arman",
                    LastName = "Baghdasaryan",
                    DateOfEmployment = new DateTime(2019, 01, 15),
                    PhoneNumber = "0995215495",
                    ShopId=2,
                    SalaryId = 1,
                    RoleId=3,
                    ImageURL= "https://images.pexels.com/photos/819530/pexels-photo-819530.jpeg?auto=compress&cs=tinysrgb&w=600"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Sona",
                    LastName = "Dadayan",
                    DateOfEmployment = new DateTime(2016, 01, 15),
                    PhoneNumber = "055975542",
                    StorageId=1,
                    SalaryId=1,
                    RoleId=2,
                    ImageURL= "https://images.pexels.com/photos/1181424/pexels-photo-1181424.jpeg?auto=compress&cs=tinysrgb&w=600"
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Anna",
                    LastName = "Babayan",
                    DateOfEmployment = new DateTime(2018, 01, 15),
                    PhoneNumber = "077987456",
                    StorageId = 2,
                    SalaryId=1,
                    RoleId=4,
                    ImageURL= "https://images.pexels.com/photos/354951/pexels-photo-354951.jpeg?auto=compress&cs=tinysrgb&w=600"
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Lia",
                    LastName = "Dadayan",
                    DateOfEmployment = new DateTime(2017, 01, 15),
                    PhoneNumber = "033123987",
                    BakeryId = 1,
                    SalaryId=1,
                    RoleId=4,
                    ImageURL= "https://images.pexels.com/photos/415263/pexels-photo-415263.jpeg?auto=compress&cs=tinysrgb&w=600"
                },
                new Employee
                {
                    Id = 6,
                    FirstName = "Nane",
                    LastName = "Dadayan",
                    DateOfEmployment = new DateTime(2014, 01, 15),
                    PhoneNumber = "099546231",
                    BakeryId = 2,
                    SalaryId=1,
                    RoleId=5,
                    ImageURL= "https://images.pexels.com/photos/415263/pexels-photo-415263.jpeg?auto=compress&cs=tinysrgb&w=600"
                },
                new Employee
                {
                    Id = 7,
                    FirstName = "Syune",
                    LastName = "Dadayan",
                    DateOfEmployment = new DateTime(2014, 01, 15),
                    PhoneNumber = "099548877",
                    BakeryId = 1,
                    SalaryId = 2,
                    RoleId = 5,
                    ImageURL= "https://images.pexels.com/photos/582039/pexels-photo-582039.jpeg?auto=compress&cs=tinysrgb&w=600"
                });

            modelBuilder.Entity<Bakery>().HasData(
                new Bakery {Id=1,PhoneNumber = "097547896",ShopId=1},
                new Bakery {Id=2,PhoneNumber = "010986325", ShopId=2});

            modelBuilder.Entity<Shop>().HasData(
                new Shop
                {
                    Id = 1,
                    Name = "Best",
                    Address = "Erevan, Hanrapetutyun str.44",
                    PhoneNumber = "055456324"
                },
                new Shop
                {
                    Id = 2,
                    Name = "Fine",
                    Address = "Erevan, Komitas str.36",
                    PhoneNumber = "055222222"
                });

            modelBuilder.Entity<Storage>().HasData(
                new Storage {Id=1,PhoneNumber = "066874532",ShopId = 1},
                new Storage { Id=2,PhoneNumber = "022987321", ShopId=2});

            modelBuilder.Entity<Salary>().HasData(
                new Salary { Id = 1, Name = "Junior", BaseSalary=200 },
                new Salary { Id = 2, Name = "Middle", BaseSalary=220 },
                new Salary { Id = 3, Name = "Senior", BaseSalary=250 });

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Manager" },
                new Role { Id=2, Name="Cashier"},
                new Role { Id=3, Name="Worker"},
                new Role { Id=4, Name="Cleaner"},
                new Role { Id=5, Name="Baker"}
                );
        }
    }
}

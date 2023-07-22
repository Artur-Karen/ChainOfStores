using ChainOfStores.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ChainOfStores.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Bakery> Bakeries { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { 
                    Id = 1,
                    FirstName = "Babken",
                    LastName = "Harutyunyan",
                    DateOfEmployment = new DateTime(2013, 01, 15),
                    PhoneNumber = "044785545",
                    ShopId=1,
                    SalaryId=1,
                    RoleId=1,
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Saribek",
                    LastName = "Baghdasaryan",
                    DateOfEmployment = new DateTime(2019, 01, 15),
                    PhoneNumber = "0995215495",
                    ShopId=2,
                    SalaryId = 1,
                    RoleId=3
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Vardush",
                    LastName = "Dadayan",
                    DateOfEmployment = new DateTime(2016, 01, 15),
                    PhoneNumber = "055975542",
                    StorageId=1,
                    SalaryId=1,
                    RoleId=2
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Margush",
                    LastName = "Babayan",
                    DateOfEmployment = new DateTime(2018, 01, 15),
                    PhoneNumber = "077987456",
                    StorageId = 2,
                    SalaryId=1,
                    RoleId=4
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Haykush",
                    LastName = "Dadayan",
                    DateOfEmployment = new DateTime(2017, 01, 15),
                    PhoneNumber = "033123987",
                    BakeryId = 1,
                    SalaryId=1,
                    RoleId=4
                },
                new Employee
                {
                    Id = 6,
                    FirstName = "Azgush",
                    LastName = "Dadayan",
                    DateOfEmployment = new DateTime(2014, 01, 15),
                    PhoneNumber = "099546231",
                    BakeryId = 2,
                    SalaryId=1,
                    RoleId=5
                },
                new Employee
                {
                    Id = 7,
                    FirstName = "Paycar",
                    LastName = "Dadayan",
                    DateOfEmployment = new DateTime(2014, 01, 15),
                    PhoneNumber = "099548877",
                    BakeryId = 1,
                    SalaryId = 2,
                    RoleId = 5
                });

            modelBuilder.Entity<Bakery>().HasData(
                new Bakery {Id=1,ShopId=1},
                new Bakery {Id=2, ShopId=2});

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
                new Storage {Id=1,ShopId = 1},
                new Storage { Id=2, ShopId=2});

            modelBuilder.Entity<Salary>().HasData(
                new Salary { Id = 1, Name = "Junior" },
                new Salary { Id = 2, Name = "Middle" },
                new Salary { Id = 3, Name = "Senior" });

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

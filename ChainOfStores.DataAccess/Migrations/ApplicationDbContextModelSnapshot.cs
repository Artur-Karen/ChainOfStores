﻿// <auto-generated />
using System;
using ChainOfStores.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChainOfStores.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChainOfStores.Models.Bakery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId")
                        .IsUnique()
                        .HasFilter("[ShopId] IS NOT NULL");

                    b.ToTable("Bakeries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "097547896",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2,
                            PhoneNumber = "010986325",
                            ShopId = 2
                        });
                });

            modelBuilder.Entity("ChainOfStores.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BakeryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("SalaryId")
                        .HasColumnType("int");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BakeryId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SalaryId");

                    b.HasIndex("ShopId");

                    b.HasIndex("StorageId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfEmployment = new DateTime(2013, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ara",
                            ImageURL = "https://images.pexels.com/photos/39866/entrepreneur-startup-start-up-man-39866.jpeg?auto=compress&cs=tinysrgb&w=600",
                            LastName = "Harutyunyan",
                            PhoneNumber = "044785545",
                            RoleId = 1,
                            SalaryId = 1,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateOfEmployment = new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Arman",
                            ImageURL = "https://images.pexels.com/photos/819530/pexels-photo-819530.jpeg?auto=compress&cs=tinysrgb&w=600",
                            LastName = "Baghdasaryan",
                            PhoneNumber = "0995215495",
                            RoleId = 3,
                            SalaryId = 1,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 3,
                            DateOfEmployment = new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sona",
                            ImageURL = "https://images.pexels.com/photos/1181424/pexels-photo-1181424.jpeg?auto=compress&cs=tinysrgb&w=600",
                            LastName = "Dadayan",
                            PhoneNumber = "055975542",
                            RoleId = 2,
                            SalaryId = 1,
                            StorageId = 1
                        },
                        new
                        {
                            Id = 4,
                            DateOfEmployment = new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Anna",
                            ImageURL = "https://images.pexels.com/photos/354951/pexels-photo-354951.jpeg?auto=compress&cs=tinysrgb&w=600",
                            LastName = "Babayan",
                            PhoneNumber = "077987456",
                            RoleId = 4,
                            SalaryId = 1,
                            StorageId = 2
                        },
                        new
                        {
                            Id = 5,
                            BakeryId = 1,
                            DateOfEmployment = new DateTime(2017, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lia",
                            ImageURL = "https://images.pexels.com/photos/415263/pexels-photo-415263.jpeg?auto=compress&cs=tinysrgb&w=600",
                            LastName = "Dadayan",
                            PhoneNumber = "033123987",
                            RoleId = 4,
                            SalaryId = 1
                        },
                        new
                        {
                            Id = 6,
                            BakeryId = 2,
                            DateOfEmployment = new DateTime(2014, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Nane",
                            ImageURL = "https://images.pexels.com/photos/415263/pexels-photo-415263.jpeg?auto=compress&cs=tinysrgb&w=600",
                            LastName = "Dadayan",
                            PhoneNumber = "099546231",
                            RoleId = 5,
                            SalaryId = 1
                        },
                        new
                        {
                            Id = 7,
                            BakeryId = 1,
                            DateOfEmployment = new DateTime(2014, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Syune",
                            ImageURL = "https://images.pexels.com/photos/582039/pexels-photo-582039.jpeg?auto=compress&cs=tinysrgb&w=600",
                            LastName = "Dadayan",
                            PhoneNumber = "099548877",
                            RoleId = 5,
                            SalaryId = 2
                        });
                });

            modelBuilder.Entity("ChainOfStores.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cashier"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Worker"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cleaner"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Baker"
                        });
                });

            modelBuilder.Entity("ChainOfStores.Models.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseSalary")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Salaries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseSalary = 200,
                            Name = "Junior"
                        },
                        new
                        {
                            Id = 2,
                            BaseSalary = 220,
                            Name = "Middle"
                        },
                        new
                        {
                            Id = 3,
                            BaseSalary = 250,
                            Name = "Senior"
                        });
                });

            modelBuilder.Entity("ChainOfStores.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Erevan, Hanrapetutyun str.44",
                            Name = "Best",
                            PhoneNumber = "055456324"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Erevan, Komitas str.36",
                            Name = "Fine",
                            PhoneNumber = "055222222"
                        });
                });

            modelBuilder.Entity("ChainOfStores.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId")
                        .IsUnique()
                        .HasFilter("[ShopId] IS NOT NULL");

                    b.ToTable("Storages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "066874532",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2,
                            PhoneNumber = "022987321",
                            ShopId = 2
                        });
                });

            modelBuilder.Entity("ChainOfStores.Models.Bakery", b =>
                {
                    b.HasOne("ChainOfStores.Models.Shop", "Shop")
                        .WithOne("Bakery")
                        .HasForeignKey("ChainOfStores.Models.Bakery", "ShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("ChainOfStores.Models.Employee", b =>
                {
                    b.HasOne("ChainOfStores.Models.Bakery", "Bakery")
                        .WithMany()
                        .HasForeignKey("BakeryId");

                    b.HasOne("ChainOfStores.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("ChainOfStores.Models.Salary", "Salary")
                        .WithMany()
                        .HasForeignKey("SalaryId");

                    b.HasOne("ChainOfStores.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.HasOne("ChainOfStores.Models.Storage", "Storage")
                        .WithMany()
                        .HasForeignKey("StorageId");

                    b.Navigation("Bakery");

                    b.Navigation("Role");

                    b.Navigation("Salary");

                    b.Navigation("Shop");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("ChainOfStores.Models.Storage", b =>
                {
                    b.HasOne("ChainOfStores.Models.Shop", "Shop")
                        .WithOne("Storage")
                        .HasForeignKey("ChainOfStores.Models.Storage", "ShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("ChainOfStores.Models.Shop", b =>
                {
                    b.Navigation("Bakery");

                    b.Navigation("Storage");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChainOfStores.Migrations
{
    /// <inheritdoc />
    public partial class ModelCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseSalary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bakeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bakeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bakeries_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    BakeryId = table.Column<int>(type: "int", nullable: true),
                    StorageId = table.Column<int>(type: "int", nullable: true),
                    SalaryId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Bakeries_BakeryId",
                        column: x => x.BakeryId,
                        principalTable: "Bakeries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Cashier" },
                    { 3, "Worker" },
                    { 4, "Cleaner" },
                    { 5, "Baker" }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "BaseSalary", "Name" },
                values: new object[,]
                {
                    { 1, 200, "Junior" },
                    { 2, 220, "Middle" },
                    { 3, 250, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Erevan, Hanrapetutyun str.44", "Best", "055456324" },
                    { 2, "Erevan, Komitas str.36", "Fine", "055222222" }
                });

            migrationBuilder.InsertData(
                table: "Bakeries",
                columns: new[] { "Id", "PhoneNumber", "ShopId" },
                values: new object[,]
                {
                    { 1, "097547896", 1 },
                    { 2, "010986325", 2 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BakeryId", "DateOfEmployment", "FirstName", "LastName", "PhoneNumber", "RoleId", "SalaryId", "ShopId", "StorageId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2013, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Babken", "Harutyunyan", "044785545", 1, 1, 1, null },
                    { 2, null, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saribek", "Baghdasaryan", "0995215495", 3, 1, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "Id", "PhoneNumber", "ShopId" },
                values: new object[,]
                {
                    { 1, "066874532", 1 },
                    { 2, "022987321", 2 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BakeryId", "DateOfEmployment", "FirstName", "LastName", "PhoneNumber", "RoleId", "SalaryId", "ShopId", "StorageId" },
                values: new object[,]
                {
                    { 3, null, new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vardush", "Dadayan", "055975542", 2, 1, null, 1 },
                    { 4, null, new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Margush", "Babayan", "077987456", 4, 1, null, 2 },
                    { 5, 1, new DateTime(2017, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haykush", "Dadayan", "033123987", 4, 1, null, null },
                    { 6, 2, new DateTime(2014, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azgush", "Dadayan", "099546231", 5, 1, null, null },
                    { 7, 1, new DateTime(2014, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paycar", "Dadayan", "099548877", 5, 2, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bakeries_ShopId",
                table: "Bakeries",
                column: "ShopId",
                unique: true,
                filter: "[ShopId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BakeryId",
                table: "Employees",
                column: "BakeryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SalaryId",
                table: "Employees",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShopId",
                table: "Employees",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StorageId",
                table: "Employees",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ShopId",
                table: "Storages",
                column: "ShopId",
                unique: true,
                filter: "[ShopId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Bakeries");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBApplication.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Apartment = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    FamilyId = table.Column<int>(nullable: false),
                    GeoLocation = table.Column<int>(nullable: false),
                    House = table.Column<string>(nullable: false),
                    PremiseId = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddressId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    HeadOfHousehold = table.Column<string>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Count = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FamilyID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MaritalStatus = table.Column<string>(nullable: false),
                    MembershipID = table.Column<int>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    MembershipBy = table.Column<string>(nullable: false),
                    PremiseId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Premises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddressId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    MembershipId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premises", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Premises");
        }
    }
}

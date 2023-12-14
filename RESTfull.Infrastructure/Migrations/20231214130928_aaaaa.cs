using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTfull.Infrastructure.Migrations
{
    public partial class aaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audiences",
                columns: table => new
                {
                    AudienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AudienceNumber = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AudienceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkplaceNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audiences", x => x.AudienceId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audiences");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppServer.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CompanyName = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    UserCategoryId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserCategoryName = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => x.UserCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    Mail = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    Birthday = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UserCategory_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Company_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

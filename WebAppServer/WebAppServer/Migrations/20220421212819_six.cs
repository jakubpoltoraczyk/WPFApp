using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppServer.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualTask",
                columns: table => new
                {
                    ActualTaskId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RealizationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Palet_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    User_Id = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CareSchedule_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualTask", x => x.ActualTaskId);
                });

            migrationBuilder.CreateTable(
                name: "CareSchedule",
                columns: table => new
                {
                    CareScheduleId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TypeOfCare_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TimeOfCare = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PaletPlantsType_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PriorityNumber = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareSchedule", x => x.CareScheduleId);
                });

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
                name: "Palet",
                columns: table => new
                {
                    PaletId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PaletNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PaletPlantsType_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DateOfPlanting = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palet", x => x.PaletId);
                });

            migrationBuilder.CreateTable(
                name: "PaletPlantsType",
                columns: table => new
                {
                    PaletPlantsTypeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PaletPlantsTypeName = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaletPlantsType", x => x.PaletPlantsTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfCare",
                columns: table => new
                {
                    TypeOfCareId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TypeOfCareName = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfCare", x => x.TypeOfCareId);
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
                name: "ActualTask");

            migrationBuilder.DropTable(
                name: "CareSchedule");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Palet");

            migrationBuilder.DropTable(
                name: "PaletPlantsType");

            migrationBuilder.DropTable(
                name: "TypeOfCare");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

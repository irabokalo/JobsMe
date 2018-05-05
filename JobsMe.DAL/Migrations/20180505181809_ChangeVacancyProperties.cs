using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsMe.DAL.Migrations
{
    public partial class ChangeVacancyProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                table: "Vacancies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "Vacancies",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "Vacancies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Hot",
                table: "Vacancies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Hot",
                table: "Vacancies");

            migrationBuilder.AlterColumn<string>(
                name: "Salary",
                table: "Vacancies",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Experience",
                table: "Vacancies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

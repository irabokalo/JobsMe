using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsMe.DAL.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Vacancies_VacancyId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsibilities_Vacancies_VacancyId",
                table: "Responsibilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Users_UserId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Vacancies_VacancyId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_VacancyId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Responsibilities_VacancyId",
                table: "Responsibilities");

            migrationBuilder.DropIndex(
                name: "IX_Offers_VacancyId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "Offers");

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => new { x.UserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyOffer",
                columns: table => new
                {
                    VacancyId = table.Column<int>(nullable: false),
                    OfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyOffer", x => new { x.VacancyId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_VacancyOffer_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyOffer_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyResponsibility",
                columns: table => new
                {
                    VacancyId = table.Column<int>(nullable: false),
                    ResponsibilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyResponsibility", x => new { x.VacancyId, x.ResponsibilityId });
                    table.ForeignKey(
                        name: "FK_VacancyResponsibility_Responsibilities_ResponsibilityId",
                        column: x => x.ResponsibilityId,
                        principalTable: "Responsibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyResponsibility_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancySkill",
                columns: table => new
                {
                    VacancyId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancySkill", x => new { x.VacancyId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_VacancySkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancySkill_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyOffer_OfferId",
                table: "VacancyOffer",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyResponsibility_ResponsibilityId",
                table: "VacancyResponsibility",
                column: "ResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancySkill_SkillId",
                table: "VacancySkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "VacancyOffer");

            migrationBuilder.DropTable(
                name: "VacancyResponsibility");

            migrationBuilder.DropTable(
                name: "VacancySkill");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "Responsibilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "Offers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserId",
                table: "Skills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_VacancyId",
                table: "Skills",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibilities_VacancyId",
                table: "Responsibilities",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_VacancyId",
                table: "Offers",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Vacancies_VacancyId",
                table: "Offers",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibilities_Vacancies_VacancyId",
                table: "Responsibilities",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Users_UserId",
                table: "Skills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Vacancies_VacancyId",
                table: "Skills",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

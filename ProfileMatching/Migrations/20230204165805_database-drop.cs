using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileMatching.Migrations
{
    public partial class databasedrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_ApplicantId1",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_jobPositions_companies_CompanyId",
                table: "jobPositions");

            migrationBuilder.DropTable(
                name: "ProfileMatchingResults");

            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobPositions",
                table: "jobPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ApplicantId1",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "ApplicantId1",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DateIssued",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "jobPositions",
                newName: "JobPosition");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_jobPositions_CompanyId",
                table: "JobPosition",
                newName: "IX_JobPosition_CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "JobPosition",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Document",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPosition",
                table: "JobPosition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosition_userId",
                table: "JobPosition",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_ApplicantId",
                table: "Document",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_AspNetUsers_ApplicantId",
                table: "Document",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosition_AspNetUsers_userId",
                table: "JobPosition",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosition_Company_CompanyId",
                table: "JobPosition",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_AspNetUsers_ApplicantId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosition_AspNetUsers_userId",
                table: "JobPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosition_Company_CompanyId",
                table: "JobPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPosition",
                table: "JobPosition");

            migrationBuilder.DropIndex(
                name: "IX_JobPosition_userId",
                table: "JobPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_ApplicantId",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "JobPosition");

            migrationBuilder.RenameTable(
                name: "JobPosition",
                newName: "jobPositions");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "companies");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosition_CompanyId",
                table: "jobPositions",
                newName: "IX_jobPositions_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "Documents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantId1",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateIssued",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastUpdated",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobPositions",
                table: "jobPositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobPositionId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applications_AspNetUsers_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_jobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "jobPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileMatchingResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileMatchingResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileMatchingResults_applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "applications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ApplicantId1",
                table: "Documents",
                column: "ApplicantId1");

            migrationBuilder.CreateIndex(
                name: "IX_applications_ApplicantId",
                table: "applications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_JobPositionId",
                table: "applications",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileMatchingResults_ApplicationId",
                table: "ProfileMatchingResults",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_ApplicantId1",
                table: "Documents",
                column: "ApplicantId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobPositions_companies_CompanyId",
                table: "jobPositions",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileMatching.Migrations
{
    public partial class FixedToMatchIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_AspNetUsers_ApplicantId",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_AppUserId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_jobPositions_companies_CompanyId",
                table: "jobPositions");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AppUserId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "jobPositions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicantId1",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "applications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ApplicantId1",
                table: "Documents",
                column: "ApplicantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_AspNetUsers_ApplicantId",
                table: "applications",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_AspNetUsers_ApplicantId",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_ApplicantId1",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_jobPositions_companies_CompanyId",
                table: "jobPositions");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ApplicantId1",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ApplicantId1",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "jobPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "applications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AppUserId",
                table: "Documents",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_AspNetUsers_ApplicantId",
                table: "applications",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_AppUserId",
                table: "Documents",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_jobPositions_companies_CompanyId",
                table: "jobPositions",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id");
        }
    }
}

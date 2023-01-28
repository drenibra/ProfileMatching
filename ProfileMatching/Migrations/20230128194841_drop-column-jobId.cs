using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileMatching.Migrations
{
    public partial class dropcolumnjobId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileMatchingResults_jobPositions_JobPositionId",
                table: "ProfileMatchingResults");

            migrationBuilder.DropIndex(
                name: "IX_ProfileMatchingResults_JobPositionId",
                table: "ProfileMatchingResults");

            migrationBuilder.DropColumn(
                name: "JobPositionId",
                table: "ProfileMatchingResults");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobPositionId",
                table: "ProfileMatchingResults",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "applicants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "applicants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileMatchingResults_JobPositionId",
                table: "ProfileMatchingResults",
                column: "JobPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileMatchingResults_jobPositions_JobPositionId",
                table: "ProfileMatchingResults",
                column: "JobPositionId",
                principalTable: "jobPositions",
                principalColumn: "Id");
        }
    }
}

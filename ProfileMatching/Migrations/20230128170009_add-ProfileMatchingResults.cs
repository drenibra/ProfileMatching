using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileMatching.Migrations
{
    public partial class addProfileMatchingResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileMatchingResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<double>(type: "float", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    JobPositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileMatchingResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileMatchingResults_applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProfileMatchingResults_jobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "jobPositions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileMatchingResults_ApplicationId",
                table: "ProfileMatchingResults",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileMatchingResults_JobPositionId",
                table: "ProfileMatchingResults",
                column: "JobPositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileMatchingResults");
        }
    }
}

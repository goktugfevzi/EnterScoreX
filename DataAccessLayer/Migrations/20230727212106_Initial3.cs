using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FixtureID",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FixtureID",
                table: "Matches",
                column: "FixtureID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Fixtures_FixtureID",
                table: "Matches",
                column: "FixtureID",
                principalTable: "Fixtures",
                principalColumn: "FixtureID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Fixtures_FixtureID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_FixtureID",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "FixtureID",
                table: "Matches");
        }
    }
}

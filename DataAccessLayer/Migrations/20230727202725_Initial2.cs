using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Fixtures_FixtureID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_FixtureID",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "FixtureID",
                table: "Matches",
                newName: "HomeTeamGoals");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamGoals",
                table: "Matches",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeamGoals",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "HomeTeamGoals",
                table: "Matches",
                newName: "FixtureID");

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
    }
}

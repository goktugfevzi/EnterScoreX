using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Table_Completed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Matches_MatchID",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_MatchID",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "MatchID",
                table: "Results",
                newName: "Week");

            migrationBuilder.RenameColumn(
                name: "ResultID",
                table: "Results",
                newName: "FixtureID");

            migrationBuilder.RenameColumn(
                name: "PositionName",
                table: "Positions",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "WeekCompleted",
                table: "Results",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Referees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GoalAgainstTeamID",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalForTeamID",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalAgainstTeamID",
                table: "Goals",
                column: "GoalAgainstTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalForTeamID",
                table: "Goals",
                column: "GoalForTeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Teams_GoalAgainstTeamID",
                table: "Goals",
                column: "GoalAgainstTeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Teams_GoalForTeamID",
                table: "Goals",
                column: "GoalForTeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Teams_GoalAgainstTeamID",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Teams_GoalForTeamID",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Goals_GoalAgainstTeamID",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_GoalForTeamID",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "WeekCompleted",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "GoalAgainstTeamID",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "GoalForTeamID",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "Week",
                table: "Results",
                newName: "MatchID");

            migrationBuilder.RenameColumn(
                name: "FixtureID",
                table: "Results",
                newName: "ResultID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Positions",
                newName: "PositionName");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Referees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_MatchID",
                table: "Results",
                column: "MatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Matches_MatchID",
                table: "Results",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

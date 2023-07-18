using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Messi_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameTime",
                table: "PlayerStatistics");

            migrationBuilder.RenameColumn(
                name: "VictoryNumber",
                table: "TeamStatistics",
                newName: "WinCount");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "TeamStatistics",
                newName: "Points");

            migrationBuilder.RenameColumn(
                name: "GoalScored",
                table: "TeamStatistics",
                newName: "GoalsFor");

            migrationBuilder.RenameColumn(
                name: "GoalConceded",
                table: "TeamStatistics",
                newName: "GoalsAgainst");

            migrationBuilder.RenameColumn(
                name: "DrawNumber",
                table: "TeamStatistics",
                newName: "PlayedCount");

            migrationBuilder.RenameColumn(
                name: "DefeatNumber",
                table: "TeamStatistics",
                newName: "LoseCount");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Players",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "DrawCount",
                table: "TeamStatistics",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CoachID",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AsistScore",
                table: "PlayerStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionID",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamAirealDualSuccess",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamFoulCount",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamPassSuccess",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamShots",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamShotsOnTarget",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamAirealDualSuccess",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamFoulCount",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamPassSuccess",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamShots",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamShotsOnTarget",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefereeID",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonID",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Coachs",
                columns: table => new
                {
                    CoachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coachs", x => x.CoachID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    RefereeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.RefereeID);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachID",
                table: "Teams",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionID",
                table: "Players",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeID",
                table: "Matches",
                column: "RefereeID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonID",
                table: "Matches",
                column: "SeasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StadiumID",
                table: "Matches",
                column: "StadiumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Referees_RefereeID",
                table: "Matches",
                column: "RefereeID",
                principalTable: "Referees",
                principalColumn: "RefereeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonID",
                table: "Matches",
                column: "SeasonID",
                principalTable: "Seasons",
                principalColumn: "SeasonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadiums_StadiumID",
                table: "Matches",
                column: "StadiumID",
                principalTable: "Stadiums",
                principalColumn: "StadiumID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionID",
                table: "Players",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Coachs_CoachID",
                table: "Teams",
                column: "CoachID",
                principalTable: "Coachs",
                principalColumn: "CoachID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Referees_RefereeID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadiums_StadiumID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionID",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Coachs_CoachID",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Coachs");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Referees");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CoachID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Players_PositionID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Matches_RefereeID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_SeasonID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_StadiumID",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "DrawCount",
                table: "TeamStatistics");

            migrationBuilder.DropColumn(
                name: "CoachID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "AsistScore",
                table: "PlayerStatistics");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PositionID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AwayTeamAirealDualSuccess",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayTeamFoulCount",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayTeamPassSuccess",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayTeamShots",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayTeamShotsOnTarget",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamAirealDualSuccess",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamFoulCount",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamPassSuccess",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamShots",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamShotsOnTarget",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "RefereeID",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SeasonID",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "WinCount",
                table: "TeamStatistics",
                newName: "VictoryNumber");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "TeamStatistics",
                newName: "Point");

            migrationBuilder.RenameColumn(
                name: "PlayedCount",
                table: "TeamStatistics",
                newName: "DrawNumber");

            migrationBuilder.RenameColumn(
                name: "LoseCount",
                table: "TeamStatistics",
                newName: "DefeatNumber");

            migrationBuilder.RenameColumn(
                name: "GoalsFor",
                table: "TeamStatistics",
                newName: "GoalScored");

            migrationBuilder.RenameColumn(
                name: "GoalsAgainst",
                table: "TeamStatistics",
                newName: "GoalConceded");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Players",
                newName: "Position");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameTime",
                table: "PlayerStatistics",
                type: "int",
                nullable: true);
        }
    }
}

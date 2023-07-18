using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Teams",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TeamImageUrl",
                table: "Teams",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "StadiumURL",
                table: "Stadiums",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StadiumName",
                table: "Stadiums",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "PlayerPosition",
                table: "Players",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "PlayerNumber",
                table: "Players",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "PlayerNationality",
                table: "Players",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "PlayerName",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PlayerImageURL",
                table: "Players",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "PlayerBirthDate",
                table: "Players",
                newName: "BirthDate");

            migrationBuilder.CreateIndex(
                name: "IX_Results_MatchID",
                table: "Results",
                column: "MatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Matches_MatchID",
                table: "Results",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Matches_MatchID",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_MatchID",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teams",
                newName: "TeamName");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Teams",
                newName: "TeamImageUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stadiums",
                newName: "StadiumURL");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Stadiums",
                newName: "StadiumName");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Players",
                newName: "PlayerPosition");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Players",
                newName: "PlayerNumber");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Players",
                newName: "PlayerNationality");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "PlayerName");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Players",
                newName: "PlayerImageURL");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Players",
                newName: "PlayerBirthDate");
        }
    }
}

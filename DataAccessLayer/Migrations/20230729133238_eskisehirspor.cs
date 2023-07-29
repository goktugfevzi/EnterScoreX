using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class eskisehirspor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SavedFileName",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedFileName",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedUrl",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedFileName",
                table: "Referees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedUrl",
                table: "Referees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedFileName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedFileName",
                table: "Coachs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedUrl",
                table: "Coachs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavedFileName",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SavedUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SavedFileName",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "SavedUrl",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "SavedFileName",
                table: "Referees");

            migrationBuilder.DropColumn(
                name: "SavedUrl",
                table: "Referees");

            migrationBuilder.DropColumn(
                name: "SavedFileName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SavedUrl",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SavedFileName",
                table: "Coachs");

            migrationBuilder.DropColumn(
                name: "SavedUrl",
                table: "Coachs");
        }
    }
}

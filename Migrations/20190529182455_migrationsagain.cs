using Microsoft.EntityFrameworkCore.Migrations;

namespace gorillatree.Migrations
{
    public partial class migrationsagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreeId",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreeId",
                table: "Users");
        }
    }
}

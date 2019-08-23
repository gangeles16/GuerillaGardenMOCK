using Microsoft.EntityFrameworkCore.Migrations;

namespace gorillatree.Migrations
{
    public partial class NewMigrationsimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Trees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Trees");
        }
    }
}

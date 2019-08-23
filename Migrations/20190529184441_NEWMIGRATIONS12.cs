using Microsoft.EntityFrameworkCore.Migrations;

namespace gorillatree.Migrations
{
    public partial class NEWMIGRATIONS12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TreeType",
                table: "Trees",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Trees",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FlowerType",
                table: "Trees",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TreeType",
                table: "Trees",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Trees",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "FlowerType",
                table: "Trees",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace InfomedBenner.Data.Migrations
{
    public partial class newt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "RedeUnimed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "RedeUnimed");
        }
    }
}

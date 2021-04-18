using Microsoft.EntityFrameworkCore.Migrations;

namespace StartSpelerMVC.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvenementNaam",
                table: "Evenement",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvenementNaam",
                table: "Evenement");
        }
    }
}

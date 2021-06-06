using Microsoft.EntityFrameworkCore.Migrations;

namespace StartSpelerMVC.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaart_Persoon_PersoonID",
                table: "Drankkaart");

            migrationBuilder.DropForeignKey(
                name: "FK_Persoon_AspNetUsers_UserID",
                table: "Persoon");

            migrationBuilder.DropIndex(
                name: "IX_Persoon_UserID",
                table: "Persoon");

            migrationBuilder.AddColumn<int>(
                name: "BestellingID",
                table: "Product",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Persoon",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersoonID",
                table: "Drankkaart",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BestellingID",
                table: "Product",
                column: "BestellingID");

            migrationBuilder.CreateIndex(
                name: "IX_Persoon_UserID",
                table: "Persoon",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaart_Persoon_PersoonID",
                table: "Drankkaart",
                column: "PersoonID",
                principalTable: "Persoon",
                principalColumn: "Persoon_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persoon_AspNetUsers_UserID",
                table: "Persoon",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Bestelling_BestellingID",
                table: "Product",
                column: "BestellingID",
                principalTable: "Bestelling",
                principalColumn: "BestellingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaart_Persoon_PersoonID",
                table: "Drankkaart");

            migrationBuilder.DropForeignKey(
                name: "FK_Persoon_AspNetUsers_UserID",
                table: "Persoon");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Bestelling_BestellingID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BestellingID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Persoon_UserID",
                table: "Persoon");

            migrationBuilder.DropColumn(
                name: "BestellingID",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Persoon",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PersoonID",
                table: "Drankkaart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persoon_UserID",
                table: "Persoon",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaart_Persoon_PersoonID",
                table: "Drankkaart",
                column: "PersoonID",
                principalTable: "Persoon",
                principalColumn: "Persoon_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persoon_AspNetUsers_UserID",
                table: "Persoon",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
